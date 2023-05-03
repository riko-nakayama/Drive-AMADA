  //#define PreTest         //TAD5048以外でのテスト用
//#define CurNoTest       //電流監視なし

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Runtime.InteropServices;

namespace Motion_Designer
{
    public partial class InspectionForm : Form
    {

        #region プロパティ

        public bool IsCollapseLayout
        {
            set
            {
                _IsCollapseLayout = value;

                if (_IsCollapseLayout)
                {
                    //CollapseSimpleControl();
                }
                else
                {
                    //ExpandSimpleControl();
                }
            }

            get { return _IsCollapseLayout; }
        }

        public bool IsExist
        {
            set { _IsExist = value; }
            get { return _IsExist; }
        }

        #endregion

        #region 定数

        private const int ON = 50;  //1;                                    // 強制的に高速側へシーケンススタート　　(旧：クラッチ強制励磁ON指示)
        private const int OFF = 40; //99;                                   // 強制的に低速側へシーケンススタート    (旧：クラッチ強制励磁OFF指示)

        private const string Excitation_ON = "励磁ON";
        private const string Excitation_OFF = "励磁OFF";

        private const string Motor_Stop = "-";
        private const string Motor_CW = "CW";
        private const string Motor_CCW = "CCW";

        private const string RESULT_FOLDER = @"\LoadTest_Result";   // 検査結果ファイル格納フォルダ

        private const string MSG_START = "検査中";                  //検査中                        
        private const string MSG_STOP = "Stop";                     // 停止            
        private const string MSG_PASS = "Pass";                     // 合格
        private const string MSG_FAIL = "Fail";                     // 不合格

        private const string MSG_COMERR = "COMERR ";                // 通信異常
        private const string MSG_INPOSERR = "INPOSERR ";            // インポジションエラー　
        private const string MSG_TEMPERR = "TEMPERR ";              // 温度監視異常（既定温度に達していない）
        private const string MSG_POWERR = "SWPOWERR ";              // スイッチング 電源異常
        private const string MSG_CURERR = "CURERR ";                // 電流監視異常
        private const string MSG_CLTCHERR = "ClutchERR ";           // クラッチ異常

        private const long INPOS_WATCH = 60000;                     // インポジション監視時間 [1m]

        private const int MAX_CLUTCH_TIME = 100;                    // クラッチ切替基準時間[msec] 
        //エージング動作
        private enum Aging
        {
            Start, ControlMode, ServoON, StartTimer1, Wait1,
            Profile1, InPos1, Profile2, InPos2, StartTimer2, Wait2,
            Profile3, InPos3, Profile4, InPos4, CycleUp, Stop1, Stop2, None,
            StartTimer1_2, Wait1_2, StartTimer2_1, Wait2_1
        };

        #endregion

        #region 変数

        static private Point FormPosition = new Point(0, 0);

        private MainForm mform;
        private ViewMainForm vform;

        private int ResizeHeight = new int();
        private int ResizeWidth = new int();

        static private InspectionForm _ThisForm;
        private bool _IsCollapseLayout = new bool();
        private bool _IsExist = new bool();
        private MdiClient ThisMdiClient;

        //試験パラメータ
        static public InspParamters[] insppara = new InspParamters[InspectionDef.MAX_PARA];

        //試験サイクルカウント
        private int CycleCount = 0;

        /// モータ形式インデックス
        private int ParaIndex = -1;

        //エージング時間計測
        private readonly Stopwatch InspectionTimer = new Stopwatch();

        //エージング時間計測ステータス表示用
        private readonly Stopwatch AgingElapsed = new Stopwatch();

        //ドライバアラーム監視時間計測
        private readonly Stopwatch AlarmCheckTimer = new Stopwatch();

        //プロファイル開始待ち時間計測
        private readonly Stopwatch ProfileWaitTimer = new Stopwatch();

        //インポジション監視時間計測
        private readonly Stopwatch InPositionTimer = new Stopwatch();

        //エージング情報
        private AgingInformation aginginfo = new AgingInformation();

        //プロファイル動作テーブル
        private readonly ProfileTable[] profileTables = new ProfileTable[4];

        //エージング処理ステップ
        private Aging AgingActionStep = Aging.None;

        //ログ情報
        private string LogMsg = string.Empty;

        //試験中指示
        private bool IsInspection = false;

        //処理中指示(メインからTrueの場合、呼び出されない)
        public bool IsProc = false;

        //検査結果保存先フォルダ
        private string LogFolder = string.Empty;

        //スイッチング 電源状態
        private bool IsPowerSupplyON = false;

        //電流値監視
        private int HighModeCurUp = 0;
        private int LowModeCurUp = 0;

        private int HighModeCurDown = 0;
        private int LowModeCurDown = 0;

        private string CurMsg = string.Empty;

        //総サイクル数
        private string TotalCycle = "000";

        private int bkClutchFailCnt = 0;

        #endregion

        #region コンストラクタ

        public InspectionForm(MainForm _mform, ViewMainForm _vform)
        {
            InitializeComponent();

            vform = _vform;
            mform = _mform;

            _ThisForm = this;
            _IsExist = true;

            //MdiClientの取得
            ThisMdiClient = MainForm.ThisForm.GetMdiClient();

            //プロファイルデータ初期化
            for (int i = 0; i < profileTables.Length; i++)
            {
                profileTables[i] = new ProfileTable();
            }
        }

        #endregion 

        #region フォーム

        static public InspectionForm ThisForm
        {
            get { return _ThisForm; }
        }

        public bool EnableUpdate
        {
            get
            {
                if (!this.Visible) { return false; }
                if (this.WindowState == FormWindowState.Minimized) { return false; }

                return true;
            }
        }

        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InspectionForm_Load(object sender, EventArgs e)
        {
            InitFormLayout();

            //ログフォルダ
            LogFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + RESULT_FOLDER;

            //フォルダ生成
            if (!Directory.Exists(LogFolder))
            {
                Directory.CreateDirectory(LogFolder);
            }
        }

        private void InspectionForm_Shown(object sender, EventArgs e)
        {
            // COM Port
            string[] ports = SerialPort.GetPortNames();

            if (ports.Length > 0)
            {
                foreach (string port in ports)
                {
                    cmbCOMPort.Items.Add(port);
                }

                if (Properties.Settings.Default.COMPort != cmbCOMPort.Text)
                {
                    cmbCOMPort.Text = Properties.Settings.Default.COMPort;
                }
                else
                {
                    if (cmbCOMPort.Items.Count > 0)
                    {
                        cmbCOMPort.SelectedIndex = 0;
                    }
                }
            }

            //検査INIファイル取得
            if (!OptionInspection.GetAllLoadTest())
            {
                MessageBox.Show("試験パラメータを取得に失敗しました。",
                                "試験パラメータ",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            //モータ型式を登録
            AddMotorType();

            if (cmbModel.Items.Count > 0) cmbModel.SelectedIndex = 0;

            //モータ設置方向
            cmbMotorDir.SelectedIndex = Properties.Settings.Default.MotorDir;

            //データベース情報取得
            if (DataBaseDialog.GetDBParameters())
            {
                txtBarcode.Focus();
            }
            else
            {
                MessageBox.Show("データベース情報の読込みが出来ません。",
                                "データベース",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        public void InitFormLayout()
        {
            if (ThisForm == null) { return; }

            //MdiClientの取得
            MdiClient mc = MainForm.ThisForm.GetMdiClient();

            int w = mc.ClientRectangle.Width;
            int h = mc.ClientRectangle.Height;

            ThisForm.Location = new Point(0, 0);
            ThisForm.Size = new Size(w, h);

            ThisForm.WindowState = FormWindowState.Normal;
        }

        private void InspectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                FormPosition = this.Location;
            }

            if (e.CloseReason == CloseReason.MdiFormClosing)
            {

            }
            else
            {
                _IsExist = false;
            }
        }

        private void InspectionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (SerialPort.IsOpen) ComClose();
        }

        private void InspectionForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                InitFormLayout();

                ResizeWidth = ThisMdiClient.ClientRectangle.Width;
                ResizeHeight = ThisMdiClient.ClientRectangle.Height;

                TimerResize.Enabled = true;
            }
        }

        #endregion

        #region Timer Event

        private void TimerResize_Tick(object sender, EventArgs e)
        {
            int w = ThisMdiClient.ClientRectangle.Width;
            int h = ThisMdiClient.ClientRectangle.Height;

            if (ResizeWidth != w || ResizeHeight != h)
            {
                InitFormLayout();
            }

            TimerResize.Enabled = false;
        }

        #endregion

        #region メニュー

        /// <summary>
        /// 試験開始ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!MainForm.IsUsbConnectBlink) { return; }

            AgingStart();
        }

        /// <summary>
        /// 試験中断ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (!aginginfo.DriverAlarm) SetStopStatus();

            //減速停止指示
            AgingActionStep = Aging.Stop1;

            //ログファイル生成
            WriteFileAgingResult();
        }

        /// <summary>
        /// 機種設定ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModelSet_Click(object sender, EventArgs e)
        {
            PasswordDialog f = new PasswordDialog();
            f.ViewStartPosition = FormStartPosition.CenterScreen;

            if (f.ShowDialog() == DialogResult.OK)
            {
                if (f.PasswordText.ToUpper() == InspectionDef.PASSWORD)
                {
                    OptionInspection optinsp = new OptionInspection();
                    optinsp.ShowDialog();

                    UpdateParametersList();
                    AddMotorType();
                }
                else
                {

                    MessageBox.Show("環境設定が出来ません。",
                                    "環境設定",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// ログリセットボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("表示されているログをクリアします。" + Environment.NewLine +
                                                    "よろしいですか?",
                                                    "ログクリア",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question))
            {
                LblStatus.Text = string.Empty;

                TxtLogMessage.Clear();
                LblDummy.Focus();
            }
        }

        /// <summary>
        /// カウントクリア
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCountClear_Click(object sender, EventArgs e)
        {
            if (!MainForm.IsUsbConnectBlink) { return; }

            if (DialogResult.Yes == MessageBox.Show("クラッチ切替の情報を全てクリアします。" + Environment.NewLine +
                                                    "よろしいですか?",
                                                    "カウントクリア",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question))
            {
                //カウントクリア
                if (ClearClutchSwitchInfo())
                {
                    GetHSClutch();
                    GetTrqClutch();
                }
                else
                {
                    MessageBox.Show("クラッチ切替情報のクリアが出来ません。",
                                    "カウントクリア",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region 励磁電流

        private bool IsNotchkCur = false;

        private void chkCurSet1_CheckedChanged(object sender, EventArgs e)
        {
            if (IsNotchkCur)
            {
                IsNotchkCur = false;
                return;
            }

            if (chkCurSet1.Checked)
            {
                if (ExcitationCurON(lblExcitationCur1.Text))
                {
                    chkCurSet1.Text = Excitation_ON;
                    chkCurSet1.BackColor = Color.Lime;
                }
                else
                {
                    IsNotchkCur = true;
                    chkCurSet1.Checked = false;

                    MessageBox.Show("励磁電流をＯＮ出来ません。",
                                    "励磁電流1",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            else
            {
                if (ExcitationCurOFF())
                {
                    chkCurSet1.Text = Excitation_OFF;
                    chkCurSet1.BackColor = Color.Gainsboro;
                }
                else
                {
                    IsNotchkCur = true;
                    chkCurSet1.Checked = true;

                    MessageBox.Show("励磁電流1をＯＦＦ出来ません。",
                                    "励磁電流1",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private void chkCurSet2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCurSet2.Checked)
            {
                if (ExcitationCurON(lblExcitationCur2.Text))
                {
                    chkCurSet2.Text = Excitation_ON;
                    chkCurSet2.BackColor = Color.Lime;
                }
                else
                {
                    IsNotchkCur = true;
                    chkCurSet2.Checked = false;

                    MessageBox.Show("励磁電流をＯＮ出来ません。",
                                    "励磁電流2",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            else
            {
                if (ExcitationCurOFF())
                {
                    chkCurSet2.Text = Excitation_OFF;
                    chkCurSet2.BackColor = Color.Gainsboro;
                }
                else
                {
                    IsNotchkCur = true;
                    chkCurSet2.Checked = true;

                    MessageBox.Show("励磁電流2をＯＦＦ出来ません。",
                                    "励磁電流2",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private bool ExcitationCurON(string strval)
        {
            if (!SerialPort.IsOpen)
            {
                if (!ComOpen()) return false;
            }

            //励磁
            if (!ExcitationCurrrent(strval)) return false;

            return PowerSupplyON();
        }

        private bool ExcitationCurOFF()
        {
            if (!SerialPort.IsOpen)
            {
                if (!ComOpen()) return false;
            }

            return PowerSupplyOFF();
        }

        #endregion

        #region プロファイル動作設定

        private void SetProfile()
        {
            //プロファイル動作１
            //profileTables[0].Position = GetPosition(insppara[ParaIndex].HighVelocity);
            profileTables[0].Position = -GetPosition(insppara[ParaIndex].HighVelocity);
            profileTables[0].Velocity = insppara[ParaIndex].HighVelocity;
            profileTables[0].Acceleration = GetAcceleration(insppara[ParaIndex].HighVelocity);
            profileTables[0].Deceleration = GetDeceleration(insppara[ParaIndex].HighVelocity);

            //プロファイル動作２
            //profileTables[1].Position = GetPosition(insppara[ParaIndex].LowVelocity);
            profileTables[1].Position = -GetPosition(insppara[ParaIndex].LowVelocity);
            profileTables[1].Velocity = insppara[ParaIndex].LowVelocity;
            profileTables[1].Acceleration = GetAcceleration(insppara[ParaIndex].LowVelocity);
            profileTables[1].Deceleration = GetDeceleration(insppara[ParaIndex].LowVelocity);

            //プロファイル動作３
            //profileTables[2].Position = -GetPosition(insppara[ParaIndex].LowVelocity);
            profileTables[2].Position = GetPosition(insppara[ParaIndex].LowVelocity);
            profileTables[2].Velocity = insppara[ParaIndex].LowVelocity;
            profileTables[2].Acceleration = GetAcceleration(insppara[ParaIndex].LowVelocity);
            profileTables[2].Deceleration = GetDeceleration(insppara[ParaIndex].LowVelocity);

            //プロファイル動作４
            profileTables[3].Position = GetPosition(insppara[ParaIndex].HighVelocity);
            profileTables[3].Velocity = insppara[ParaIndex].HighVelocity;
            profileTables[3].Acceleration = GetAcceleration(insppara[ParaIndex].HighVelocity);
            profileTables[3].Deceleration = GetDeceleration(insppara[ParaIndex].HighVelocity);
        }

        private int GetPosition(int vel)
        {
            //const float dirtime = 7.5f;     // 回転時間 7.5[s]
            const float dirtime = 1.5f;     // 回転時間 1.5[s]

            return (int)Math.Round((dirtime * (vel / 60f)) *
                                   CMonitor.GetParameter(CParamID.EncderResolution));
        }

        private int GetAcceleration(int vel)
        {
            const int acctime = 300;        // 加速時間 300[ms]

            return (int)Math.Round((((float)vel / acctime) * 100));
        }

        private int GetDeceleration(int vel)
        {
            const int dectime = 300;        // 減速時間 300[ms]

            return (int)Math.Round((((float)vel / dectime) * 100));
        }

        #endregion

        #region 負荷試験

        //int f_hstime = 0;
        int hstime = 0;
        int tlqtime = 0;

        public void LoadInspectionProc()
        {
            int pos = 0;
          
            //試験開始が指示されているか？
            if (!IsInspection) return;

            Random r = new Random();

            IsProc = true;

            switch (AgingActionStep)
            {
                #region エージング開始

                case Aging.Start:

                    //位置リセット
                    if (!ServoControl.PositionReset()) { aginginfo.COMError = true; break; }

                    //クラッチ切替情報クリア
                    //カウントクリア
                    if (!ClearClutchSwitchInfo()) { aginginfo.COMError = true; break; }

                    //プロファイル動作パターン設定
                    SetProfile();

                    //モータ回転方法停止表示
                    ViewMotorRotate(Motor_Stop);

                    InspectionTimer.Start();
                    AlarmCheckTimer.Start();

#if !PreTest

                    if (!SerialPort.IsOpen)
                    {
                        if (!ComOpen()) { aginginfo.PowerSupplyError = true; break; }
                    }

#endif

                    WriteLogMessage("Load Inspection : Start");

                    AgingActionStep = Aging.ControlMode;
                    break;

                #endregion

                #region 位置制御設定

                case Aging.ControlMode:

                    //位置制御設定
                    if (!ControlMode(1)) { aginginfo.COMError = true; }

                    AgingActionStep = Aging.ServoON;

                    break;

                #endregion

                #region サーボオン

                case Aging.ServoON:

                    //サーボON
                    if (!ServoControl.ServoON((int)InspectionDef.WAIT_1s)) { aginginfo.COMError = true; }

#if !PreTest

                    //励磁
                    if (!ExcitationCurrrent(lblExcitationCur1.Text)) { aginginfo.PowerSupplyError = true; break; }

                    //クラッチ励磁ON
                    if (!ServoControl.ClutchExcitation(ON)) { aginginfo.COMError = true; break; }

#endif

                    AgingActionStep = Aging.StartTimer1;
                    break;

                #endregion

                #region 次の動作まで10ms待ち

                case Aging.StartTimer1:

                    //プロファイル動作開始待ちタイマー起動
                    ProfileWaitTimer.Start();
                    AgingActionStep = Aging.Wait1;
                    break;

                case Aging.Wait1:

                    //プロファイル動作を10ms後に開始する
                    Wait(InspectionDef.WAIT_10ms, Aging.Profile1);
                    break;

                #endregion

                #region 動作パターン１

                case Aging.Profile1:

                    //クラッチ状態監視
                    //if (!ClutchSwitchState()) { aginginfo.ClutchError = true; break; }

                    bkClutchFailCnt = aginginfo.ClutchFailCnt;

                    // 高速側クラッチ切替時間監視
                    //if (!CheckHSClutchSwitchTime(ref f_hstime)) { aginginfo.COMError = true; break; }

                    //回転方向表示
                    ViewMotorRotate(Motor_CW);

                    if (!CCommandTx.ReadSvNet(CParamID.FeedbackPosition, ref pos)) { aginginfo.COMError = true; break; }

                    if (!StartProfile(Aging.InPos1,
                                      //profileTables[0].Position + pos,
                                      profileTables[0].Position + pos + r.Next(0, 10240),
                                      profileTables[0].Velocity,
                                      profileTables[0].Acceleration,
                                      profileTables[0].Deceleration)) { aginginfo.COMError = true; }
                    break;

                case Aging.InPos1:

                    //動作パターン１のインポジション待ち
                    if (!InPositionWait(Aging.StartTimer1_2,
                                        profileTables[0].Position,
                                        profileTables[0].Velocity,
                                        HighModeCurUp,
                                        HighModeCurDown)) { aginginfo.COMError = true; }
                    break;

                #endregion

                #region 次の動作まで200ms待ち

                case Aging.StartTimer1_2:

#if !PreTest

                    //励磁
                    if (!ExcitationCurrrent(lblExcitationCur2.Text)) { aginginfo.PowerSupplyError = true; break; }

                    //クラッチ励磁OFF
                    if (!ServoControl.ClutchExcitation(OFF)) { aginginfo.COMError = true; break; }

#endif

                    //プロファイル動作開始待ちタイマー起動
                    ProfileWaitTimer.Start();

                    AgingActionStep = Aging.Wait1_2;
                    break;

                case Aging.Wait1_2:
                    //プロファイル動作を200ms秒後に開始する
                    Wait(InspectionDef.WAIT_200ms, Aging.Profile2);
                    break;

                #endregion

                #region 動作パターン２
                case Aging.Profile2:

                    //クラッチ状態監視
                    //if (!ClutchSwitchState()) { aginginfo.ClutchError = true; break; }

                    // 高トルククラッチ切替時間監視
                    if (!CheckTrqClutchSwitchTime(ref tlqtime)) { aginginfo.COMError = true; break; }

                    //回転方向表示
                    ViewMotorRotate(Motor_CW);

                    if (!CCommandTx.ReadSvNet(CParamID.FeedbackPosition, ref pos)) { aginginfo.COMError = true; break; }

                    if (!StartProfile(Aging.InPos2,
                                      pos - profileTables[1].Position + r.Next(0, 10240),
                                      //pos - profileTables[1].Position,
                                      profileTables[1].Velocity,
                                      profileTables[1].Acceleration,
                                      profileTables[1].Deceleration)) { aginginfo.COMError = true; }
                    break;

                case Aging.InPos2:

                    //動作パターン２のインポジション待ち
                    if (!InPositionWait(Aging.StartTimer2,
                                        profileTables[1].Position,
                                        profileTables[1].Velocity,
                                        LowModeCurUp,
                                        LowModeCurDown)) { aginginfo.COMError = true; }
                    break;

                #endregion

                #region 次の動作まで10ms待ち

                case Aging.StartTimer2:

                    //プロファイル動作開始待ちタイマー起動
                    ProfileWaitTimer.Start();
                    AgingActionStep = Aging.Wait2;
                    break;

                case Aging.Wait2:

                    //プロファイル動作を10ms後に開始する
                    Wait(InspectionDef.WAIT_10ms, Aging.Profile3);
                    break;

                #endregion

                #region 動作パターン３

                case Aging.Profile3:

                    ViewMotorRotate(Motor_CCW);

                    if (!CCommandTx.ReadSvNet(CParamID.FeedbackPosition, ref pos)) { aginginfo.COMError = true; break; }

                    if (!StartProfile(Aging.InPos3,
                                      //pos - profileTables[2].Position ,
                                      pos - profileTables[2].Position + r.Next(0, 10240),
                                      profileTables[2].Velocity,
                                    　profileTables[2].Acceleration,
                                    　profileTables[2].Deceleration)) { aginginfo.COMError = true; }
                    break;

                case Aging.InPos3:

                    //動作パターン３のインポジション待ち
                    if (!InPositionWait(Aging.StartTimer2_1,
                                        profileTables[2].Position,
                                        profileTables[2].Velocity,
                                        LowModeCurUp,
                                        LowModeCurDown)) { aginginfo.COMError = true; }
                    break;

                #endregion

                #region 次の動作まで200ms待ち

                case Aging.StartTimer2_1:

#if !PreTest

                    //励磁
                    if (!ExcitationCurrrent(lblExcitationCur1.Text)) { aginginfo.PowerSupplyError = true; break; }

                    //クラッチ励磁ON
                    if (!ServoControl.ClutchExcitation(ON)) { aginginfo.COMError = true; break; }

#endif

                    //プロファイル動作開始待ちタイマー起動
                    ProfileWaitTimer.Start();
                    AgingActionStep = Aging.Wait2_1;
                    break;

                case Aging.Wait2_1:
                    //プロファイル動作を200ms秒後に開始する
                    Wait(InspectionDef.WAIT_200ms, Aging.Profile4);
                    break;

                #endregion

                #region 動作パターン４

                case Aging.Profile4:

                    //クラッチ状態監視
                    //if (!ClutchSwitchState()) { aginginfo.ClutchError = true; break; }

                    // 高速側クラッチ切替時間監視
                    if (!CheckHSClutchSwitchTime(ref hstime)) { aginginfo.COMError = true; break; }

                    //回転方向表示
                    ViewMotorRotate(Motor_CCW);

                    if (!CCommandTx.ReadSvNet(CParamID.FeedbackPosition, ref pos)) { aginginfo.COMError = true; break; }

                    if (!StartProfile(Aging.InPos4,
                                       //pos + profileTables[3].Position,
                                       pos + profileTables[3].Position + r.Next(0, 10240),
                                       profileTables[3].Velocity,
                                       profileTables[3].Acceleration,
                                       profileTables[3].Deceleration)) { aginginfo.COMError = true; }
                    break;

                case Aging.InPos4:

                    //動作パターン４のインポジション待ち
                    if (!InPositionWait(Aging.CycleUp,
                                        profileTables[3].Position,
                                        profileTables[3].Velocity,
                                        HighModeCurUp,
                                        HighModeCurDown)) { aginginfo.COMError = true; }
                    break;

                #endregion

                #region サイクルカウントアップ

                case Aging.CycleUp:

                    CycleCount++;
                    lblCycle.Text = CycleCount.ToString("000") + "/" + TotalCycle;

                    //現在の日付時刻取得
                    LogMsg = String.Format("{0:yyyy/MM/dd HH:mm:ss} ", DateTime.Now); ;

                    //if (CycleCount > 0)
                    //{
                    //    //ドライバ正常
                    //    string strcycle = (CycleCount > 1) ? " cycles: " : " cycle : ";
                    //    string strresult = "OK ";
                        
                    //    if (bkClutchFailCnt != aginginfo.ClutchFailCnt)
                    //    {
                    //        strresult = "Clutch NG ";
                    //    }

                    //    //初回試験？
                    //    if (CycleCount == 1)
                    //    {

                    //        LogMsg += CycleCount.ToString() + strcycle + strresult + Environment.NewLine +
                    //                                                     CycleCount.ToString() + " Clutch Time: High1 = " + f_hstime.ToString() + " " +
                    //                                                     "Torque = " + tlqtime.ToString() + " " +
                    //                                                     "High2 = " + hstime.ToString();
                    //    }
                    //    else
                    //    {
                    //        LogMsg += CycleCount.ToString() + strcycle + strresult + Environment.NewLine +
                    //                                                     CycleCount.ToString() + " Clutch Time: High = " + f_hstime.ToString() + " " +
                    //                                                     "Torque = " + tlqtime.ToString();
                    //    }
                    //}

                    //ViewLogMessage();

                    //１００サイクル実施？
                    if (CycleCount < int.Parse(TotalCycle))
                    {
                        AgingActionStep = Aging.StartTimer1;

                        //ドライバ正常
                        string strcycle = (CycleCount > 1) ? " cycles: " : " cycle : ";
                        string strresult = "OK ";

                        if (bkClutchFailCnt != aginginfo.ClutchFailCnt)
                        {
                            strresult = "Clutch NG ";
                        }

                        LogMsg += CycleCount.ToString() + strcycle + strresult +
                                    " High = " + hstime.ToString() + " " +
                                    "Torque = " + tlqtime.ToString();
                                                                     

                        ////初回試験？
                        //if (CycleCount == 1)
                        //{

                        //    LogMsg += CycleCount.ToString() + strcycle + strresult + 
                        //                                                 " Clutch Time: High1 = " + f_hstime.ToString() + " " +
                        //                                                 "Torque = " + tlqtime.ToString() + " " +
                        //                                                 "High2 = " + hstime.ToString();
                        //}
                        //else
                        //{
                        //    LogMsg += CycleCount.ToString() + strcycle + strresult + 
                        //                                                 " Clutch Time: High = " + f_hstime.ToString() + " " +
                        //                                                 "Torque = " + tlqtime.ToString();
                        //}

                        ViewLogMessage();
                    }
                    else
                    {
                        //終了
                        AgingStop();

                        //クラッチ切替チェック
                        int HSSuccessCnt = 0;
                        int HSTotalCnt = 0;
                        int TrqSuccessCnt = 0;
                        int TrqTotalCnt = 0;

                        int hsClutchSuccess = 0;
                        int TrqClutchSuccess = 0;

                        if (!CCommandTx.ReadSvNet(CParamID.HSSuccessCnt, ref HSSuccessCnt)) { aginginfo.COMError = true; break; };
                        if (!CCommandTx.ReadSvNet(CParamID.HSTotalCnt, ref HSTotalCnt)) { aginginfo.COMError = true; break; };
                        if (!CCommandTx.ReadSvNet(CParamID.TrqSuccessCnt, ref TrqSuccessCnt)) { aginginfo.COMError = true; break; };
                        if (!CCommandTx.ReadSvNet(CParamID.TrqTotalCnt, ref TrqTotalCnt)) { aginginfo.COMError = true; break; };

                        if (HSTotalCnt > 0)
                        {
                            hsClutchSuccess = (int)(((float)HSSuccessCnt / (float)HSTotalCnt) * 100);
                        }

                        if (TrqTotalCnt > 0)
                        {
                            TrqClutchSuccess = (int)(((float)TrqSuccessCnt / TrqTotalCnt) * 100);
                        }

                        if ( hsClutchSuccess >= 50 && TrqClutchSuccess >= 50 && aginginfo.ClutchFailCnt == 0)
                        {
                            aginginfo.ClutchError = false;
                        }
                        else
                        {
                            aginginfo.ClutchError = true;
                        }

                        string strresult = "OK ";

                        if (bkClutchFailCnt != aginginfo.ClutchFailCnt)
                        {
                            strresult = "Clutch NG ";
                        }

                        LogMsg += CycleCount.ToString() + " cycles: " + strresult +
                                                          " Clutch Time: High = " + hstime.ToString() + " " +
                                                          "Torque = " + tlqtime.ToString() + Environment.NewLine;

                        LogMsg += "High Clutch = " + hsClutchSuccess.ToString() + "[%] " +
                                  "Torque Clutch = " + TrqClutchSuccess.ToString() + "[%] " +
                                  "Clutch Fail = " + aginginfo.ClutchFailCnt.ToString() + "[times]";

                        ViewLogMessage();

                        ShowAgingResult();

                        //ログファイル生成
                        WriteFileAgingResult();
                    }

                    break;

                #endregion

                #region 停止

                case Aging.Stop1:

                    //減速停止
                    if (!SmoothStop()) { aginginfo.COMError = true; break; }

                    InPositionWait(Aging.Stop2, 0, 0, 0, 0);
                    break;

                case Aging.Stop2:

                    //減速停止後、エージング停止
                    AgingStop();
                    break;

                #endregion

                #region アイドリング

                default:
                case Aging.None:
                    break;
                    #endregion
            }

            //アラーム確認
            CheckDriverAlarm();

            //異常?
            if (aginginfo.DriverAlarm ||
                aginginfo.InPosError ||
                aginginfo.PowerSupplyError ||
                aginginfo.CurrentError)
                //aginginfo.ClutchError)
            {
                //強制停止
                AgingForcedStop();
            }

            if (aginginfo.COMError) AgingActionStep = Aging.None;

            IsProc = false;
        }

        #endregion

        #region モータ情報/クラッチ切替情報

        public void SetMonitorFeedBack()
        {
            lblCur.Text = (CMonitor.GetParameter(CParamID.FeedbackCurrent) * 0.01).ToString("F2");          // モータ電流 
            lblTemp.Text = (CMonitor.GetParameter(CParamID.MotorTemp) * 0.1).ToString("F1");                // モータ温度

            //GetClutchInformation();
        }

        /// <summary>
        /// クラッチ切替情報取得
        /// </summary>
        private void GetClutchInformation()
        {
            lblHSTotalCnt.Text = CMonitor.GetParameter(CParamID.HSTotalCnt).ToString();                     // 高速側トータル回数カウント
            lblHSSuccessCnt.Text = CMonitor.GetParameter(CParamID.HSSuccessCnt).ToString();                 // 高速側成功回数カウント
            lblHSClutchSwitchTime.Text = CMonitor.GetParameter(CParamID.HSClutchSwitchTime).ToString();     // 高速側クラッチ切替時間

            lblTrqTotalCnt.Text = CMonitor.GetParameter(CParamID.TrqTotalCnt).ToString();                   // 高トルク側トータル回数カウント
            lblTrqSuccessCnt.Text = CMonitor.GetParameter(CParamID.TrqSuccessCnt).ToString();               // 高トルク側成功回数カウント
            lblTrqClutchSwitchTime.Text = CMonitor.GetParameter(CParamID.TrqClutchSwitchTime).ToString();   // 高トルククラッチ切替時間
        }

        #endregion

        #region エージング強制停止

        private void AgingForcedStop()
        {
            //エージング停止
            AgingStop();

            ShowAgingResult();

            //ログファイル生成
            WriteFileAgingResult();

            LblDummy.Focus();
        }

        #endregion

        #region エージング結果表示

        private void ShowAgingResult()
        {
            if (aginginfo.DriverAlarm ||
                aginginfo.PowerSupplyError ||
                aginginfo.CurrentError ||
                aginginfo.ClutchError)
            {
                SetFailResult();
            }
            else
            {
                SetPassResult();
            }

            WriteLogMessage("Load Inspection : Finish");
        }

        #endregion

        #region ドライバアラームチェック

        private string strdatetime;

        private void CheckDriverAlarm()
        {
            // アラーム番号
            string stralrm;

            int sts = 0;
            int alarm = 0;

            //現在の日付時刻取得
            strdatetime = String.Format("{0:yyyy/MM/dd HH:mm:ss} ", DateTime.Now);

            LogMsg = strdatetime;

            //インポジエラー？
            if (aginginfo.InPosError)
            {
                LogMsg += "Alarm " + MSG_INPOSERR;
            }
            //通信エラー？
            else if (aginginfo.COMError)
            {
                //ここに来る前に既に通信異常の場合
                LogMsg += "Alarm " + MSG_COMERR;
            }
            // スイッチング 電源異常
            else if (aginginfo.PowerSupplyError)
            {
                LogMsg += "Alarm " + MSG_POWERR;
            }
            //電流監視異常
            else if (aginginfo.CurrentError)
            {
                LogMsg += "Alarm " + MSG_CURERR + CurMsg;
            }
            //クラッチ異常
            //else if (aginginfo.ClutchError)
            //{
            //    LogMsg += "Alarm " + MSG_CLTCHERR;
            //}
            else
            {
                //サーボステータス取得
                if (CCommandTx.ReadSvNet(CParamID.ServoStatus, ref sts))
                {
                    //ドライバアラーム検出?
                    if ((sts & 0x08) == 0x08)
                    {
                        //アラームコード
                        if (CCommandTx.ReadSvNet(CParamID.AlarmCode, ref alarm))
                        {
                            stralrm = alarm.ToString();
                        }
                        else
                        {
                            //通信異常
                            aginginfo.COMError = true;
                            stralrm = MSG_COMERR;
                        }

                        //アラーム番号設定
                        LogMsg += " Driver Alarm" + stralrm + " ";

                        aginginfo.DriverAlarm = true;
                        aginginfo.AlarmNumber = alarm;
                    }
                }
                else
                {
                    //通信異常
                    LogMsg += "Alarm " + MSG_COMERR;
                    aginginfo.COMError = true;
                }
            }

            if (LogMsg != strdatetime) ViewLogMessage();

        }

        #endregion

        #region 試験開始

        private void AgingStart()
        {
            IsInspection = true;

            LblStatus.Text = MSG_START;

            lblCur.ForeColor = Color.Lime;
            lblTemp.ForeColor = Color.Lime;

            LblLogTimeSpan.ForeColor = Color.Lime;
            lblCycle.ForeColor = Color.Lime;

            lblHSTotalCnt.ForeColor = Color.Lime;
            lblHSSuccessCnt.ForeColor = Color.Lime;
            lblHSClutchSwitchTime.ForeColor = Color.Lime;
            lblTrqTotalCnt.ForeColor = Color.Lime;
            lblTrqSuccessCnt.ForeColor = Color.Lime;
            lblTrqClutchSwitchTime.ForeColor = Color.Lime;

            LblStatus.ForeColor = Color.Black;

            LblStatus.StartColor = Color.White;
            LblStatus.EndColor = Color.White;

            CycleCount = 0;
            lblCycle.Text = CycleCount.ToString("000") + "/" + TotalCycle;

            TimerBlink.Enabled = true;

            this.Refresh();

            AgingActionStep = 0;

            TxtLogMessage.Clear();

            AllClearAgingInformation();

            AgingActionStep = Aging.Start;

            AgingElapsed.Reset();
            AgingElapsed.Start();

            btnStart.Enabled = false;

            cmbModel.Enabled = false;
            chkCurSet1.Enabled = false;
            chkCurSet2.Enabled = false;

            //検査中はDriveの他の機能を使用不可
            mform.ControlMainFormEnabled = false;
            vform.ViewMainFormEnabled = false;

            HighModeCurUp = (int)(float.Parse(lblHighModeConstantUp.Text) / 0.01f);
            LowModeCurUp = (int)(float.Parse(lblLowModeConstantUp.Text) / 0.01f);

            HighModeCurDown = (int)(float.Parse(lblHighModeConstantDown.Text) / 0.01f);
            LowModeCurDown = (int)(float.Parse(lblLowModeConstantDown.Text) / 0.01f);

            LblDummy.Focus();
        }

        #endregion

        #region 試験停止

        private void AgingStop()
        {
            IsInspection = false;
            TimerBlink.Enabled = false;

            ServoControl.ServoOFF();

            ServoControl.ClutchExcitation(OFF);

            ExcitationCurOFF();

            LblStatus.StartColor = Color.White;
            LblStatus.EndColor = Color.White;

            InspectionTimer.Reset();
            AlarmCheckTimer.Reset();
            ProfileWaitTimer.Reset();

            lblCur.ForeColor = Color.Gray;
            lblTemp.ForeColor = Color.Gray;

            LblLogTimeSpan.ForeColor = Color.Gray;
            lblCycle.ForeColor = Color.Gray;

            lblHSTotalCnt.ForeColor = Color.Gray;
            lblHSSuccessCnt.ForeColor = Color.Gray;
            lblHSClutchSwitchTime.ForeColor = Color.Gray;
            lblTrqTotalCnt.ForeColor = Color.Gray;
            lblTrqSuccessCnt.ForeColor = Color.Gray;
            lblTrqClutchSwitchTime.ForeColor = Color.Gray;

            btnStart.Enabled = true;

            cmbModel.Enabled = true;
            chkCurSet1.Enabled = true;
            chkCurSet2.Enabled = true;

            //Driveの他の機能の使用不可解除
            mform.ControlMainFormEnabled = true;
            vform.ViewMainFormEnabled = true;

            AgingActionStep = Aging.None;

            AgingElapsed.Stop();
        }

        #endregion

        #region 待ち

        private void Wait(long waittime, Aging next)
        {
            if (ProfileWaitTimer.ElapsedMilliseconds > waittime)
            {
                //指定して時間が経過後、プロファイル動作を開始する
                AgingActionStep = next;
                ProfileWaitTimer.Reset();
            }
            else
            {
                //モータ回転方法停止表示
                ViewMotorRotate(Motor_Stop);
            }
        }

        #endregion

        #region プロファイル開始

        /// <summary>
        /// プロファイル開始
        /// </summary>
        /// <param name="pos">目標位置</param>
        /// <param name="vel">目標速度</param>
        /// <param name="acc">加速度</param>
        /// <param name="dec">減速度</param>
        private bool StartProfile(Aging next, int pos, int vel, int acc, int dec)
        {
            if (!ProfileOperation(pos, vel, acc, dec)) return false;

            AgingActionStep = next;
            Thread.Sleep(100);
            InPositionTimer.Start();

            return true;
        }

        #endregion

        #region インポジション待ち

        private bool InPositionWait(Aging next, int pos, int vel, int cur_up, int cur_down)
        {
            //インポジション待ち
            if (!InPosition()) return false;

            //インポジ状態か?
            if (aginginfo.InPosition)
            {
                aginginfo.InPosition = false;

                AgingActionStep = next;

                InPositionTimer.Reset();

                //モータ回転方法停止表示
                ViewMotorRotate(Motor_Stop);
            }
            else
            {
#if !CurNoTest

                if (pos != 0 && vel != 0 && cur_up != 0 && cur_down != 0)
                {
                    if (Math.Sign(pos) == 1)
                    {
                        Debug.WriteLine("vel = " + CMonitor.GetParameter(CParamID.FeedbackVelocity).ToString());

                        if (cmbMotorDir.Text == "上")
                        {
                            if (CMonitor.GetParameter(CParamID.FeedbackVelocity) <= -vel)
                            {
                                //上限
                                if (CMonitor.GetParameter(CParamID.FeedbackCurrent) > cur_up)
                                {
                                    CurMsg = "(Current_High = " + (CMonitor.GetParameter(CParamID.FeedbackCurrent) * 0.01f).ToString() + "[A])";
                                    aginginfo.CurrentError = true;
                                    return true;
                                }

                                //下限
                                if (CMonitor.GetParameter(CParamID.FeedbackCurrent) < cur_down)
                                {
                                    CurMsg = "(Current_Low = " + (CMonitor.GetParameter(CParamID.FeedbackCurrent) * 0.01f).ToString() + "[A])";
                                    aginginfo.CurrentError = true;
                                    return true;
                                }
                            }
                        }
                        else
                        {
                            // 下
                            if (CMonitor.GetParameter(CParamID.FeedbackVelocity) >= vel)
                            {
                                //上限
                                if (CMonitor.GetParameter(CParamID.FeedbackCurrent) > cur_up)
                                {
                                    CurMsg = "(Current_High = " + (CMonitor.GetParameter(CParamID.FeedbackCurrent) * 0.01f).ToString() + "[A])";
                                    aginginfo.CurrentError = true;
                                    return true;
                                }

                                //下限
                                if (CMonitor.GetParameter(CParamID.FeedbackCurrent) < cur_down)
                                {
                                    CurMsg = "(Current_Low = " + (CMonitor.GetParameter(CParamID.FeedbackCurrent) * 0.01f).ToString() + "[A])";
                                    aginginfo.CurrentError = true;
                                    return true;
                                }
                            }

                        }
                    }
                    else if (Math.Sign(pos) == -1)
                    {
                        if (cmbMotorDir.Text == "上")
                        {

                            if (CMonitor.GetParameter(CParamID.FeedbackVelocity) >= vel)
                            {
                                //上限
                                if (CMonitor.GetParameter(CParamID.FeedbackCurrent) < -cur_up)
                                {
                                    CurMsg = "(Current_High = " + (CMonitor.GetParameter(CParamID.FeedbackCurrent) * 0.01f).ToString() + "[A])";
                                    aginginfo.CurrentError = true;
                                    return true;
                                }

                                //下限
                                if (CMonitor.GetParameter(CParamID.FeedbackCurrent) > -cur_down)
                                {
                                    CurMsg = "(Current_Low = " + (CMonitor.GetParameter(CParamID.FeedbackCurrent) * 0.01f).ToString() + "[A])";
                                    aginginfo.CurrentError = true;
                                    return true;
                                }
                            }
                        }
                        else
                        {
                            if (CMonitor.GetParameter(CParamID.FeedbackVelocity) <= -vel)
                            {
                                //上限
                                if (CMonitor.GetParameter(CParamID.FeedbackCurrent) < -cur_up)
                                {
                                    CurMsg = "(Current_High = " + (CMonitor.GetParameter(CParamID.FeedbackCurrent) * 0.01f).ToString() + "[A])";
                                    aginginfo.CurrentError = true;
                                    return true;
                                }

                                //下限
                                if (CMonitor.GetParameter(CParamID.FeedbackCurrent) > -cur_down)
                                {
                                    CurMsg = "(Current__Low = " + (CMonitor.GetParameter(CParamID.FeedbackCurrent) * 0.01f).ToString() + "[A])";
                                    aginginfo.CurrentError = true;
                                    return true;
                                }
                            }
                        }
                    }
                }

#endif

                //インポジ待ち(最大１分)
                if (InPositionTimer.ElapsedMilliseconds > INPOS_WATCH)
                {
                    if (!aginginfo.InPosition)
                    {
                        aginginfo.InPosError = true;
                    }

                    AgingActionStep = next;
                    InPositionTimer.Reset();
                }
            }

            return true;
        }

        #endregion

        #region STOP表示

        private void SetStopStatus()
        {
            TimerBlink.Enabled = false;

            LblStatus.ForeColor = Color.Red;
            LblStatus.StartColor = Color.White;
            LblStatus.EndColor = Color.White;

            LblStatus.Text = MSG_STOP;

            //モータ回転方法停止表示
            ViewMotorRotate(Motor_Stop);

            //ログ表示
            WriteLogMessage("Load Inspection : Stop");
        }

        #endregion

        #region PASS表示

        private void SetPassResult()
        {
            LblStatus.ForeColor = Color.Black;

            LblStatus.StartColor = Color.Lime;
            LblStatus.EndColor = Color.Lime;

            LblStatus.Text = MSG_PASS;
        }

        #endregion

        #region FAIL表示

        private void SetFailResult()
        {
            LblStatus.ForeColor = Color.White;

            LblStatus.StartColor = Color.Red;
            LblStatus.EndColor = Color.Red;

            LblStatus.Text = MSG_FAIL;
        }

        #endregion

        #region モータ回転方向表示

        private void ViewMotorRotate(string strdir)
        {
            lblDir.Text = strdir;

            switch (strdir)
            {
                case Motor_CW:
                    lblDir.ForeColor = Color.Cyan;
                    break;

                case Motor_CCW:
                    lblDir.ForeColor = Color.Magenta;
                    break;

                case Motor_Stop:
                    lblDir.ForeColor = Color.White;
                    break;
            }
        }

        #endregion

        #region 制御モード設定

        private bool ControlMode(int mode)
        {
            int sts = 0;
            int contorlmode = 0;

            if (!CCommandTx.ReadSvNet(CParamID.ServoStatus, ref sts)) return false;

            if (!CCommandTx.ReadSvNet(CParamID.ControlMode, ref contorlmode)) return false;

            //サーボＯＮ中？
            if ((sts & 0x01) == 0x01)
            {
                if (!ServoControl.ServoOFF()) return false;
            }

            if (contorlmode != mode)
            {
                if (!CCommandTx.WriteSvNet(CParamID.ControlMode, mode)) return false;
            }

            return true;
        }

        #endregion

        #region サーボON(未使用)

        //public bool ServoON()
        //{
        //    int cmd = 0;

        //    if (!CCommandTx.ReadSvNet(CParamID.ServoCommand, ref cmd)) return false;

        //    cmd &= ~0x0030;     //Hard Stop & Smooth Stop Clear
        //    if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) return false;

        //    cmd |= 0x0001;

        //    if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) return false;

        //    //Thread.Sleep(100);
        //    Thread.Sleep((int)InspectionDef.WAIT_1s);

        //    return true;
        //}

        #endregion

        #region サーボOFF(未使用)

        //public bool ServoOFF()
        //{
        //    int cmd = 0;

        //    if (!CCommandTx.ReadSvNet(CParamID.ServoCommand, ref cmd)) return false;

        //    cmd |= 0x0020;      //Smooth Stop bit Set
        //    if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) return false;

        //    Thread.Sleep(100);

        //    cmd &= ~0x0033;     //Servo On & Profile Start bit Clear & Smooth Stop & Hard Stop bit Clear

        //    if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) return false;

        //    return true;
        //}

        #endregion

        #region 減速停止

        private bool SmoothStop()
        {
            int cmd = 0;

            if (!CCommandTx.ReadSvNet(CParamID.ServoCommand, ref cmd)) return false;

            cmd &= ~0x0002;     //Profile Start bit Clear

            cmd |= 0x0020;      //Smooth Stop bit Set

            if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) return false;

            return true;
        }

        #endregion

        #region プロファイル動作

        /// <summary>
        /// <summary>
        /// プロファイル動作（単軸）
        /// </summary>
        /// <param name="axis"></param>
        /// <returns></returns>
        private bool ProfileOperation(int pos, int vel, int acc, int dec)
        {
            int cmd = 0;
            int ctrl = 0;

            //位置リセット
            //if (!PositionReset()) return false;

            // 加速度
            if (!CCommandTx.WriteSvNet(CParamID.TargetAcceleration, acc)) return false;

            // 減速度
            if (!CCommandTx.WriteSvNet(CParamID.TargetDeceleration, dec)) return false;

            // 目標位置
            if (!CCommandTx.WriteSvNet(CParamID.TargetPosition, pos)) return false;

            // 目標速度
            if (!CCommandTx.WriteSvNet(CParamID.TargetVelocity, vel)) return false;

            if (!CCommandTx.ReadSvNet(CParamID.ServoCommand, ref cmd)) return false;
            if (!CCommandTx.ReadSvNet(CParamID.ControlSwitch, ref ctrl)) return false;

            ctrl |= 0x0002;     //Profile bit auto Clear
            if (!CCommandTx.WriteSvNet(CParamID.ControlSwitch, ctrl)) return false;

            cmd |= 0x0002;      //Profile Start bit Set
            cmd |= 0x0080;		//Smoothing On

            if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) return false;

            return true;
        }

        #endregion

        #region 位置情報リセット(未使用)

        //private bool PositionReset()
        //{
        //    int cmd = 0;

        //    if (!CCommandTx.ReadSvNet(CParamID.ServoCommand, ref cmd)) return false;

        //    cmd |= 0x4000;
        //    if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) return false;

        //    Thread.Sleep(100);

        //    cmd &= ~0x4000;
        //    if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) return false;

        //    return true;
        //}

        #endregion

        #region インポジション待ち

        /// <summary>
        /// インポジション待ち
        /// </summary>
        /// <param name="axis"></param>
        /// <returns></returns>
        private bool InPosition()
        {
            int sts = 0;

            if (!CCommandTx.ReadSvNet(CParamID.ServoStatus, ref sts)) return false;

            if ((sts & 0x04) == 0x04)
            {
                aginginfo.InPosition = true;
            }
            else
            {
                aginginfo.InPosition = false;
            }

            return true;
        }

        #endregion

        #region クラッチ励磁(未使用)

        //private bool ClutchExcitation(int data)
        //{
        //    return CCommandTx.WriteSvNet(CParamID.ClutchExcitation, data);
        //}

        #endregion

        #region 励磁電流

        private bool ExcitationCurrrent(string strval)
        {
            //励磁電流設定
            if (!SetCurrentValue(strval)) return false;

            //スイッチング電源ＯＮ状態？
            if (!IsPowerSupplyON)
            {
                //スイッチング電源ＯＮ
                if (!PowerSupplyON()) return false;
                IsPowerSupplyON = true;
            }

            return true;
        }

        #endregion

        #region スイッチング電源

        /// <summary>
        /// 通信ポートオープン
        /// </summary>
        /// <returns></returns>
        private bool ComOpen()
        {
            bool bret = true;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SerialPort.PortName = cmbCOMPort.Text;
                SerialPort.BaudRate = 9600;
                SerialPort.DataBits = 8;
                SerialPort.StopBits = StopBits.One;
                SerialPort.Parity = Parity.None;
                SerialPort.Handshake = Handshake.None;
                SerialPort.Open();
                SerialPort.DiscardInBuffer();
                SerialPort.WriteLine("*cls;:OUTP OFF" + '\n');
            }
            catch
            {
                bret = true;
            }

            Cursor.Current = Cursors.Default;

            return bret;
        }

        /// <summary>
        /// 通信ポートクローズ
        /// </summary>
        private void ComClose()
        {
            if (SerialPort.IsOpen)
            {
                PowerSupplyOFF();
                Thread.Sleep(200);
                SerialPort.Close();
            }
        }

        /// <summary>
        /// スイッチング 電源ＯＮ
        /// </summary>
        /// <returns></returns>
        private bool PowerSupplyON()
        {
            if (!SerialPort.IsOpen) return false;

            try
            {
                SerialPort.WriteLine(":OUTP ON" + '\n');
                IsPowerSupplyON = true;
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// スイッチング 電源ＯＦＦ
        /// </summary>
        /// <returns></returns>
        private bool PowerSupplyOFF()
        {
            if (!SerialPort.IsOpen) return false;

            try
            {
                SerialPort.WriteLine(":OUTP OFF" + '\n');
                IsPowerSupplyON = false;
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// スイッチング 電源電流値設定
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        private bool SetCurrentValue(string strValue)
        {
            if (!SerialPort.IsOpen) return false;

            try
            {
                SerialPort.WriteLine(":DISP:MENU 3;:CURR " + strValue + '\n');
            }
            catch
            {
                return false;
            }

            return true;

        }

        #endregion

        #region エージング情報取得／設定

        /// <summary>
        /// 全AgingInformationクリア
        /// </summary>
        private void AllClearAgingInformation()
        {
            aginginfo.COMError = false;
            aginginfo.DriverAlarm = false;
            aginginfo.AlarmNumber = 0;
            aginginfo.InPosition = false;
            aginginfo.InPosError = false;
            aginginfo.PowerSupplyError = false;
            aginginfo.CurrentError = false;
            aginginfo.ClutchError = false;

            aginginfo.ClutchFailCnt = 0;
        }

        #endregion

        #region モータ形式変更

        private void cmbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateParametersList();
        }

        #endregion

        #region モータ形式コンボ追加

        private void AddMotorType()
        {
            int bkselectidx = cmbModel.SelectedIndex;

            cmbModel.Items.Clear();

            for (int i = 0; i < insppara.Length; i++)
            {
                if (insppara[i].MotorType != string.Empty)
                {
                    if (!cmbModel.Items.Contains(insppara[i].MotorType))
                    {
                        cmbModel.Items.Add(insppara[i].MotorType);
                    }
                }
            }

            if (cmbModel.Items.Count > bkselectidx)
            {
                cmbModel.SelectedIndex = bkselectidx;
            }
            else
            {
                cmbModel.SelectedIndex = 0;
            }
        }

        #endregion

        #region 試験パラメータ更新

        private void UpdateParametersList()
        {
            if (cmbModel.Text != string.Empty)
            {
                for (int i = 0; i < insppara.Length; i++)
                {
                    if (insppara[i].MotorType == cmbModel.Text)
                    {
                        lblLowVelocity.Text = insppara[i].LowVelocity.ToString();
                        lblHighVelocity.Text = insppara[i].HighVelocity.ToString();
                        lblExcitationCur1.Text = insppara[i].ExcitationCur1.ToString("F2");
                        lblExcitationCur2.Text = insppara[i].ExcitationCur2.ToString("F2");
                        lblHighModeUp.Text = insppara[i].HighModeUp.ToString("F2");
                        lblHighModeConstantUp.Text = insppara[i].HighModeConstantUp.ToString("F2");
                        lblHighModeDown.Text = insppara[i].HighModeDown.ToString("F2");
                        lblLowModeUp.Text = insppara[i].LowModeUp.ToString("F2");
                        lblLowModeConstantUp.Text = insppara[i].LowModeConstantUp.ToString("F2");
                        lblLowModeDown.Text = insppara[i].LowModeDown.ToString("F2");

                        lblHighModeConstantDown.Text = insppara[i].HighModeConstantDown.ToString("F2");
                        lblLowModeConstantDown.Text = insppara[i].LowModeConstantDown.ToString("F2");

                        string[] str = lblCycle.Text.Split('/');

                        TotalCycle = insppara[i].Cycle.ToString("000");

                        string strcycle = str[0] + "/" + TotalCycle;

                        if (strcycle != lblCycle.Text) lblCycle.Text = strcycle;

                        //選択されたモータ形式のパラメータインデックスを設定
                        ParaIndex = i;
                    }
                }
            }
            else
            {
                ParaIndex = -1;
            }
        }

        #endregion

        #region エージング経過時間ステータス表示

        private void TimerLogTimeSpan_Tick(object sender, EventArgs e)
        {
            //エージング経過時間
            LblLogTimeSpan.Text = AgingElapsed.Elapsed.Hours.ToString("00") + ":" +
                                  AgingElapsed.Elapsed.Minutes.ToString("00") + ":" +
                                  AgingElapsed.Elapsed.Seconds.ToString("00");
        }

        #endregion

        #region ボタン領域アクティブ

        private void Control_MouseEnter(object sender, EventArgs e)
        {
            this.Select();
        }

        private void Control_MouseHover(object sender, EventArgs e)
        {
            this.Select();
        }

        #endregion

        #region ステータス点滅タイマー

        private void TimerBlink_Tick(object sender, EventArgs e)
        {
            if (LblStatus.EndColor == Color.Yellow)
            {
                LblStatus.ForeColor = Color.Black;

                LblStatus.StartColor = Color.White;
                LblStatus.EndColor = Color.White;
            }
            else
            {
                LblStatus.ForeColor = Color.Black;

                LblStatus.StartColor = Color.White;
                LblStatus.EndColor = Color.Yellow;
            }

            LblStatus.Refresh();
        }

        #endregion

        #region ログ

        /// <summary>
        /// 検査結果ログ書込み
        /// </summary>
        /// <param name="msg"></param>
        private void WriteLogMessage(string msg)
        {
            strdatetime = String.Format("{0:yyyy/MM/dd HH:mm:ss} ", DateTime.Now);
            LogMsg = strdatetime + msg;

            ViewLogMessage();
        }

        /// <summary>
        /// ログ情報表示
        /// </summary>
        private void ViewLogMessage()
        {
            TxtLogMessage.AppendText(LogMsg + Environment.NewLine);
            TxtLogMessage.SelectionStart = TxtLogMessage.Text.Length;
            TxtLogMessage.ScrollToCaret();

            TxtLogMessage.Refresh();
        }

        private void WriteFileAgingResult()
        {
            // 日付フォルダ
            string strDateFolder = LogFolder + @"\" + String.Format("{0:yyyyMMdd} ", DateTime.Now);

            // 日付フォルダ作成が既に存在するか？
            if (!Directory.Exists(strDateFolder))
            {
                // フォルダ生成
                Directory.CreateDirectory(strDateFolder);
            }

            // 時刻取得
            string strTime = "_" + String.Format("{0:HHmmss} ", DateTime.Now);

            try
            {
                // ファイル名設定
                string strfile = strDateFolder + @"\SN_" + "A" + txtBarcode.Text + strTime + ".txt";

                //ログデータ書込み
                using (StreamWriter sw = new StreamWriter(strfile, false, Encoding.Default))
                {
                    //検査結果
                    sw.WriteLine("[Result]");
                    sw.WriteLine(LblStatus.Text + Environment.NewLine);

                    //検査ログ
                    sw.WriteLine("[Log]");
                    sw.WriteLine(TxtLogMessage.Text);
                }
            }
            catch
            {
                MessageBox.Show("ログファイル保存の保存が出来ませんでした。",
                                "ログファイル保存",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region シリアル通信ポート

        private void cmbCOMPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.COMPort = cmbCOMPort.Text;
            LblDummy.Focus();
        }

        private void cmbCOMPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;   // キー入力不可
        }

        #endregion

        #region サイクル回数設定

        private void lblCycle_DoubleClick(object sender, EventArgs e)
        {
            InspectionCycle inspcycle = new InspectionCycle();
            inspcycle.ShowDialog();
        }

        #endregion

        #region モータ設置方向

        private bool bnotchg = false;

        private void cmbMotorDir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!bnotchg) { bnotchg = true; return; }

            if (Properties.Settings.Default.MotorDir != cmbMotorDir.SelectedIndex)
            {
                PasswordDialog f = new PasswordDialog();
                f.ViewStartPosition = FormStartPosition.CenterScreen;

                if (f.ShowDialog() == DialogResult.OK)
                {
                    if (f.PasswordText.ToUpper() == InspectionDef.PASSWORD)
                    {
                        Properties.Settings.Default.MotorDir = cmbMotorDir.SelectedIndex;
                    }
                    else
                    {

                        MessageBox.Show("パスワードが違います。",
                                        "モータ設置方向",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Warning);

                        bnotchg = false;
                        cmbMotorDir.SelectedIndex = Properties.Settings.Default.MotorDir;
                    }
                }
                else
                {
                    bnotchg = false;
                    cmbMotorDir.SelectedIndex = Properties.Settings.Default.MotorDir;
                }
            }

            LblDummy.Focus();
        }

        #endregion

        #region 高速側クラッチ切替時間判定
        
        private bool CheckHSClutchSwitchTime(ref int time)
        {
            if (!CCommandTx.ReadSvNet(CParamID.HSClutchSwitchTime, ref time)) return false;

            //クラッチ切替時間が100msecを超えているか？
            if (time > MAX_CLUTCH_TIME)
            {
                aginginfo.ClutchFailCnt++;
                //aginginfo.CurrentError = true;
            }
            else
            {
                //aginginfo.CurrentError = false;
            }

            if (!GetHSClutch()) return false;

            return true;
        }

        private bool GetHSClutch()
        {
            int HSTotalCnt = 0;
            int HSSuccessCnt = 0;
            int HSClutchSwitchTime = 0;

            if (!CCommandTx.ReadSvNet(CParamID.HSTotalCnt, ref HSTotalCnt)) return false;
            if (!CCommandTx.ReadSvNet(CParamID.HSSuccessCnt, ref HSSuccessCnt)) return false;
            if (!CCommandTx.ReadSvNet(CParamID.HSClutchSwitchTime, ref HSClutchSwitchTime)) return false;

            lblHSTotalCnt.Text = HSTotalCnt.ToString();                     // 高速側トータル回数カウント
            lblHSSuccessCnt.Text = HSSuccessCnt.ToString();                 // 高速側成功回数カウント
            lblHSClutchSwitchTime.Text = HSClutchSwitchTime.ToString();     // 高速側クラッチ切替時間

            return true;
        }

        #endregion

        #region クラッチ切替情報クリア

        private bool ClearClutchSwitchInfo()
        {
            return CCommandTx.WriteSvNet(CParamID.CounterClear, 0x800000);
        }

        #endregion

        #region 高トルク側クラッチ切替時間判定

        private bool CheckTrqClutchSwitchTime(ref int time)
        {  
            if (!CCommandTx.ReadSvNet(CParamID.TrqClutchSwitchTime, ref time)) return false;

            //クラッチ切替時間が100msecを超えているか？
            if (time > MAX_CLUTCH_TIME)
            {
                aginginfo.ClutchFailCnt++;
                //aginginfo.CurrentError = true;
            }
            else
            {
                //aginginfo.CurrentError = false;
            }

            if (!GetTrqClutch()) return false;

            return true;
        }

        private bool GetTrqClutch()
        {
            int TrqTotalCnt = 0;
            int TrqSuccessCnt = 0;
            int TrqClutchSwitchTime = 0;

            if (!CCommandTx.ReadSvNet(CParamID.TrqTotalCnt, ref TrqTotalCnt)) return false;
            if (!CCommandTx.ReadSvNet(CParamID.TrqSuccessCnt, ref TrqSuccessCnt)) return false;
            if (!CCommandTx.ReadSvNet(CParamID.TrqClutchSwitchTime, ref TrqClutchSwitchTime)) return false;

            lblTrqTotalCnt.Text = TrqTotalCnt.ToString();                   // 高トルク側トータル回数カウント
            lblTrqSuccessCnt.Text = TrqSuccessCnt.ToString();               // 高トルク側成功回数カウント
            lblTrqClutchSwitchTime.Text = TrqClutchSwitchTime.ToString();   // 高トルククラッチ切替時間

            return true;
        }

        #endregion

        #region クラッチスイッチ状態

        private bool ClutchSwitchState()
        {
            int sts = CMonitor.GetParameter(CParamID.TestMonitor1);

            if ((sts & 0x30) != 0x30)
            {
                if ((sts & 0x10) == 0x10) return true;

                if ((sts & 0x20) == 0x20) return true;
            }

            return false;

            #endregion

        }

        #region プロファイル動作テーブルクラス

        public class ProfileTable
        {

            /// <summary>
            /// 目標位置
            /// </summary>
            public int Position = 0;

            /// <summary>
            /// 目標速度
            /// </summary>
            public int Velocity = 0;

            /// <summary>
            /// 加速度
            /// </summary>
            public int Acceleration = 0;

            /// <summary>
            /// 減速度
            /// </summary>
            public int Deceleration = 0;

            public ProfileTable() { }

            public ProfileTable(int pos, int vel, int acc, int dec)
            {

                Position = pos;
                Velocity = vel;
                Acceleration = acc;
                Deceleration = dec;
            }
        }

        #endregion

        #region エージング情報クラス

        public class AgingInformation
        {
            /// <summary>
            /// シリアル番号
            /// </summary>
            public int serialNumber = 0;

            /// <summary>
            /// アラーム情報
            /// </summary>
            public bool DriverAlarm = false;

            /// <summary>
            /// 通信異常情報
            /// </summary>
            public bool COMError = false;

            /// <summary>
            /// インポジエラー
            /// </summary>
            public bool InPosError = false;

            /// <summary>
            /// 温度異常
            /// </summary>
            public bool TempError = false;

            /// <summary>
            /// アラーム番号 
            /// </summary>
            public int AlarmNumber = 0;

            /// <summary>
            /// インポジ待ち
            /// </summary>
            public bool InPosition = false;

            /// <summary>
            /// スイッチング 電源異常
            /// </summary>
            public bool PowerSupplyError = false;

            /// <summary>
            /// 電流監視異常
            /// </summary>
            public bool CurrentError = false;

            /// <summary>
            /// クラッチ異常
            /// </summary>
            public bool ClutchError = false;

            /// <summary>
            /// 現在ドライバ温度
            /// </summary>
            public float CurrntDrvTemp = 0;

            /// <summary>
            /// クラッチ切替失敗カウント
            /// </summary>
            public int ClutchFailCnt = 0;

            public AgingInformation() { }

        }

        #endregion

        #region バーコード

        private void txtBarcode_MouseEnter(object sender, EventArgs e)
        {
            txtBarcode.SelectAll();
            txtBarcode.Focus();
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            if (txtBarcode.Text.Length == 11)
            {
                toolStripInspection.Focus();
            }
        }

        #endregion

    }
}
