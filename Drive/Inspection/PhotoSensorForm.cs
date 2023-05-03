#define PreTest         //テスト用

using System;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
    public partial class PhotoSensorForm : Form
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

        static public PhotoSensorForm ThisForm
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

        public bool ButtonEnabled
        {
            set
            {
                if (value)
                {
                    btnStartMount.ForeColor = Color.Navy;
                    if (LblStatus.Text == MSG_WAIT || LblStatus.Text == MSG_PHOTO) btnStopMount.ForeColor = Color.Navy;
                    btnStartAction.ForeColor = Color.Navy;
                    if (LblStatus.Text == MSG_WAIT || LblStatus.Text == MSG_OPERATIORN) btnStopAction.ForeColor = Color.Navy;
                    btnStartClutch.ForeColor = Color.Navy;
                }
                else
                {
                    btnStartMount.ForeColor = Color.DarkGray;
                    if (LblStatus.Text == MSG_WAIT || LblStatus.Text == MSG_OPERATIORN) btnStopMount.ForeColor = Color.DarkGray;
                    btnStartAction.ForeColor = Color.DarkGray;
                    if (LblStatus.Text == MSG_WAIT || LblStatus.Text == MSG_PHOTO) btnStopAction.ForeColor = Color.DarkGray;
                    btnStartClutch.ForeColor = Color.DarkGray;
                }

                btnStartMount.Enabled = value;
                if (LblStatus.Text == MSG_WAIT || LblStatus.Text == MSG_OPERATIORN) btnStopMount.Enabled = value;
                btnStartAction.Enabled = value;
                if (LblStatus.Text == MSG_WAIT || LblStatus.Text == MSG_PHOTO) btnStopAction.Enabled = value;
                btnStartClutch.Enabled = value;
            }
        }

        public bool FormEnabled
        {
            set
            {
                ButtonEnabled = value;

                toolStripPhoto.Enabled = value;

                mform.ControlMainFormEnabled = value;
                vform.ViewMainFormEnabled = value;
            }
        }
        #endregion

        #region 定数

        private const bool CW = false;                              // CW方向回転指示
        private const bool CCW = true;                              // CCW方向回転指示

        private const bool TimeViewEnabled = true;                  // 経過時刻表示有効
        private const bool TimeViewDisabled = false;                // 経過時刻表示無効

    
        private const int RPM100 = 100;                             // 100[rpm]

        private const int LogTime = 1;                              //ログ時間 1[sec] 

        private int MAX_CLUTCH_CNT = 20;                            //クラッチ切替最大数

        private const string MSG_WAIT = "開始待ち";
        private const string MSG_PHOTO = "フォトセンサ取付中";
        private const string MSG_CLUTCH_ONOFF = "クラッチ切替動作中";
        private const string MSG_OPERATIORN = "動作確認中";

        private const string MSG_HITRQCW = "ﾓｰﾀ回転 高ﾄﾙｸ CW動作中";
        private const string MSG_HITRQCCW = "ﾓｰﾀ回転 高ﾄﾙｸ CCW動作中";
        private const string MSG_HISPDCW = "ﾓｰﾀ回転 高速回転 CW動作中";
        private const string MSG_HISPDCCW = "ﾓｰﾀ回転 高速回転 CCW動作中";

        private const string MSG_UPTLQLOW = "ﾓｰﾀ電流 起動直後 高ﾄﾙｸ 低速動作中";
        private const string MSG_UPTLQHIGH = "ﾓｰﾀ電流 起動直後 高ﾄﾙｸ 高速動作中";
        private const string MSG_UPHISPLOW = "ﾓｰﾀ電流 起動直後 高速回転 低速動作中";
        private const string MSG_UPHISPHI = "ﾓｰﾀ電流 起動直後 高速回転 高速動作中";

        private const string MSG_CTIRTTLQHI = "ﾓｰﾀ電流 連続回転 高ﾄﾙｸ 高速動作中";
        private const string MSG_CTIRTSPDHI = "ﾓｰﾀ電流 連続回転 高速回転 高速動作中";

        private const string MSG_CLUTCH = "クラッチ測定中";

        private const string MSG_NONE = "";

        private const string TITLE_PHOTO = "フォトセンサ取付";
        private const string TITLE_MOTOR__ROTATION = "モータ回転確認";
        private const string TITLE_MOTOR_CURRENT = "モータ電流測定";
        private const string TITLE_CLUTCH_OPE = "クラッチ動作";

        private const string MSG_INPUT_PHOTO = "距離を入力し【OK】ボタンを押してください。";

        private const string MSG_INPUT_CLUTCH = "ギャップを入力し【OK】ボタンを押してください。";

        #region フォトセンサ／動作確認シーケンス

        private enum Motion
        {
            #region フォトセンサ取付

            Photo1, Photo2, Photo3, Photo4, Photo5, Photo6, Photo7, Photo8, Photo9, Photo10, Photo11,

            #endregion

            #region 回転動作確認

            //高トルクモードCW
            ChkTlqVelCW1, ChkTlqVelCW2, ChkTlqVelCW3, ChkTlqVelCW4, ChkTlqVelCW5,

            ///高トルクモードCCW
            ChkTlqVelCCW1, ChkTlqVelCCW2, ChkTlqVelCCW3, ChkTlqVelCCW4, ChkTlqVelCCW5,

            //高速回転モードCW 
            ChkhighVelCW1, ChkhighVelCW2, ChkhighVelCW3, ChkhighVelCW4, ChkhighVelCW5,

            //高速回転モードCCW 
            ChkhighVelCCW1, ChkhighVelCCW2, ChkhighVelCCW3, ChkhighVelCCW4, ChkhighVelCCW5,

            #endregion

            #region モータ電流測定

            //起動直後_高トルクモード 低速
            ChkStLowTlpCur1, ChkStLowTlpCur2, ChkStLowTlpCur3, ChkStLowTlpCur4, ChkStLowTlpCur5,

            //起動直後_高トルクモード 高速
            ChkStHighTlpCur1, ChkStHighTlpCur2, ChkStHighTlpCur3, ChkStHighTlpCur4, ChkStHighTlpCur5,

            //起動直後_高速回転モード 低速
            ChkStHighSpRowCur1, ChkStHighSpRowCur2, ChkStHighSpRowCur3, ChkStHighSpRowCur4, ChkStHighSpRowCur5,

            //起動直後_高速回転モード 高速
            ChkStHighSpHighCur1, ChkStHighSpHighCur2, ChkStHighSpHighCur3, ChkStHighSpHighCur4, ChkStHighSpHighCur5,

            //連続回転_高トルクモード 高速
            ChkContiHighTlpCur1, ChkContiHighTlpCur2, ChkContiHighTlpCur3, ChkContiHighTlpCur4, ChkContiHighTlpCur5,

            //連続回転_高速回転モード 高速
            ChkContiHighSpHighCur1, ChkContiHighSpHighCur2, ChkContiHighSpHighCur3, ChkContiHighSpHighCur4, ChkContiHighSpHighCur5,

            #endregion

            #region クラッチ動作

            Clutch1, Clutch2, Clutch3,

            #endregion

            #region ログデータ取得

            LogGet1, LogGet2, LogGet3, LogGet4, LogGet5, LogGet6,

            #endregion

            #region 停止

            Stop1, Stop2, Stop3, Stop4, Stop5,

            #endregion

            #region アイドリング

            None

            #endregion

        };

        #endregion

        #endregion

        #region 変数

        static private Point FormPosition = new Point(0, 0);

        private MainForm mform;
        private ViewMainForm vform;

        private int ResizeHeight = new int();
        private int ResizeWidth = new int();

        static private PhotoSensorForm _ThisForm;
        private bool _IsCollapseLayout = new bool();
        private bool _IsExist = new bool();
        private MdiClient ThisMdiClient;

        //検査結果保存先フォルダ
        private string LogFolder = string.Empty;

        public bool IsGetLog = false;   //メインフォームへログデータ取得要求
        private bool IsSetLog = false;  //ログデータ受信取得要求

        //オシロログデータ操作
        private int LogPtr = 0;
        private int[] LogVelData = null;
        private int[] LogCurData = null;
        private int LogLength = 0;

        //バーコード
        public bool IsBarcode = false;

        //停止指示
        private bool IsStop = false;

        //監視タイマー
        private readonly Stopwatch WaitTimer = new Stopwatch();

        private Motion MotinStep = Motion.None;
        private Motion bkMotinStep = Motion.None;

        //回転動作
        private string strFbVelocity = string.Empty;
        private int CommandVelocity = 0;

        //電流測定
        private MotorInf motorInf = new MotorInf();

        //クラッチ切替回数
        private int ClutchCount = 0;

        //測定結果
        private ResultData rd = null;
        
        //測定結果完了メッセージ
        private ResultMessage rm = new ResultMessage();

        #endregion

        #region コンストラクタ

        public PhotoSensorForm(MainForm _mform, ViewMainForm _vform)
        {
            InitializeComponent();

            vform = _vform;
            mform = _mform;

            _ThisForm = this;
            _IsExist = true;

            //MdiClientの取得
            ThisMdiClient = MainForm.ThisForm.GetMdiClient();
        }

        #endregion

        #region フォーム

        private void PhotoSensorForm_Load(object sender, EventArgs e)
        {
            InitFormLayout();
            
            //開始待ち
            LblStatus.Text = MSG_WAIT;

            LogLength = LogTime * 1000;         // ログ採取時間 1sec -> 1000ms 
            LogCurData = new int[LogLength];
            LogVelData = new int[LogLength];
            LogPtr = 0;

            ButtonEnabled = false;
        }

        private void PhotoSensorForm_Shown(object sender, EventArgs e)
        {
            //動作情報取得
            if (!OptionPhoto.GetAllLoadTest())
            {
                MessageBox.Show(this,
                                "動作情報ファイルの読込みが出来ません。",
                                "動作環境",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }
            else
            {
                if (DataBaseDialog.GetDBParameters())
                {
                    txtBarcode.Focus();
                }
                else
                {
                    MessageBox.Show(this,
                                    "データベース情報の読込みが出来ません。",
                                    "データベース",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }

            AddMotorType();

            if (cmbModel.Items.Count > 0) cmbModel.SelectedIndex = 0;
        }

        private void PhotoSensorForm_FormClosing(object sender, FormClosingEventArgs e)
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

            FormEnabled = true;
        }

        private void PhotoSensorForm_Resize(object sender, EventArgs e)
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

        #region フォトセンサ取付

        /// <summary>
        /// 開始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartMount_Click(object sender, EventArgs e)
        {
            if (!MainForm.IsUsbConnectBlink) { return; }
           
            MotinStep = Motion.Photo1;
        }

        /// <summary>
        /// 停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStopMount_Click(object sender, EventArgs e)
        {
            if (!MainForm.IsUsbConnectBlink) { return; }

            IsStop = true;
        }

        #endregion

        #region 動作確認

        /// <summary>
        /// 開始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartAction_Click(object sender, EventArgs e)
        {
            if (!MainForm.IsUsbConnectBlink) { return; }

            LogPtr = 0;
            MotinStep = Motion.ChkTlqVelCW1;
        }

        /// <summary>
        /// 停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStopAction_Click(object sender, EventArgs e)
        {
            if (!MainForm.IsUsbConnectBlink) { return; }

            IsStop = true;
        }

        #endregion

        #region クラッチ動作

        /// <summary>
        /// 開始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartClutch_Click(object sender, EventArgs e)
        {
            if (!MainForm.IsUsbConnectBlink) { return; }

            MotinStep = Motion.Clutch1;
        }

        #endregion

        #region 動作環境 

        private void btnOption_Click(object sender, EventArgs e)
        {
            PasswordDialog f = new PasswordDialog();

            f.ViewStartPosition = FormStartPosition.CenterScreen;

            if (f.ShowDialog() == DialogResult.OK)
            {
                if (f.PasswordText.ToUpper() == InspectionDef.PASSWORD)
                {
                    OptionPhoto optphoto = new OptionPhoto();
                    
                    if(optphoto.ShowDialog() == DialogResult.OK)
                    {
                        SetMotorInformation();
                        AddMotorType();
                    }
                }
                else
                {
                    MessageBox.Show(this,
                                    "動作情報ファイルの読込みが出来ません。",
                                    "動作環境",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region 結果消去

        private void btnReset_Click(object sender, EventArgs e)
        {
            AllReset();
        }


        /// <summary>
        /// フォトセンサ取付測定結果リセット
        /// </summary>
        private void ResetPhotoSensorMeasurement()
        {
            rd.ClearPhotoSensorMeasurement();
        }

        /// <summary>
        /// 動作確認測定結果リセット
        /// </summary>
        private void ResetMotorRotationMeasurement()
        {
            rd.ClearMotorRotationMeasurement();

            lblHighTorqueCWVel.Text = string.Empty;
            lblHighTorqueCCWVel.Text = string.Empty;
            lblHighSpeedCWVel.Text = string.Empty;
            lblHighSpeedCCWVel.Text = string.Empty;

            lblHighTorqueCWVel.BackColor = Color.White;
            lblHighTorqueCCWVel.BackColor = Color.White;
            lblHighSpeedCWVel.BackColor = Color.White;
            lblHighSpeedCCWVel.BackColor = Color.White;

            lblTrqLowVelStart.Text = string.Empty;
            lblTrqHighVelStart.Text = string.Empty;
            lblRotationLowVel.Text = string.Empty;
            lblRotationHighVel.Text = string.Empty;
            lblTrqHighVelConti.Text = string.Empty;
            lblRotationHighConti.Text = string.Empty;

            lblTrqLowVelStart.BackColor = Color.White;
            lblTrqHighVelStart.BackColor = Color.White;
            lblRotationLowVel.BackColor = Color.White;
            lblRotationHighVel.BackColor = Color.White;
            lblTrqHighVelConti.BackColor = Color.White;
            lblRotationHighConti.BackColor = Color.White;
        }

        /// <summary>
        /// クラッチ動作測定結果リセット
        /// </summary>
        private void ResetClutchOperation()
        {
            rd.ClearClutchOperation();
        }

        /// <summary>
        /// 全測定結果リセット
        /// </summary>
        private void AllReset()
        {
            ResetPhotoSensorMeasurement();
            ResetMotorRotationMeasurement();
            ResetClutchOperation();
        }

        #endregion

        #region フォトセンサ取付／動作確認

        public void PhotoMotinProc()
        {
            switch (MotinStep)
            {
                #region フォトセンサ取付

                #region 無通電状態測定開始

                case Motion.Photo1:

                    MotinStep = Motion.None;

                    if (MessageBox.Show(this,
                                        "無通電状態での測定を実施してください。" + Environment.NewLine +
                                        "準備がよろしければ、【OK】ボタンを押してください。",
                                        TITLE_PHOTO,
                                        MessageBoxButtons.OKCancel,
                                        MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        AllReset();

                        LblStatus.Text = MSG_PHOTO;
                        TimerBlink.Enabled = true;

                        FormEnabled = false;

                        //フォトセンサ取付前のパラメータ設定
                        if (!SetPhotoSensorMountParameter())
                        {
                            ViewErrorMesssage(TITLE_PHOTO,
                                              "フォトセンサ取付前のパラメータ設定が異常です。(Photo1)");
                        }
                        else
                        {
                            if (ServoControl.ClutchExcitation(ServoDef.OFF))
                            {
                                MotinStep = Motion.Photo2;
                            }
                            else
                            {
                                ViewErrorMesssage(TITLE_PHOTO,
                                                  "クラッチの励磁ＯＦＦに失敗しました。(Photo1)");
                            }
                        }
                    }
                    else
                    {
                        StopMeasurement();
                    }

                    break;

                #endregion

                #region 無通電状態測定値入力

                case Motion.Photo2:

                    MotinStep = Motion.None;

                    //無通電状態の距離入力
                    if (InputValueMessageBox(TITLE_PHOTO, MSG_INPUT_PHOTO, "[mm]", ref rd.HighTorquePos))
                    {
                        MotinStep = Motion.Photo3;
                    }
                    else
                    {
                        //再入力
                        MotinStep = Motion.Photo2;
                    }

                    break;

                #endregion

                #region 通電状態測定開始

                case Motion.Photo3:

                    MotinStep = Motion.None;

                    if (MessageBox.Show(this,
                                        "通電状態での測定を実施してください。" + Environment.NewLine +
                                        "準備がよろしければ、【OK】ボタンを押してください。",
                                        TITLE_PHOTO,
                                        MessageBoxButtons.OKCancel,
                                        MessageBoxIcon.Question) == DialogResult.OK)
                    {

                        if (ServoControl.ClutchExcitation(ServoDef.ON))
                        {
                            MotinStep = Motion.Photo4;
                        }
                        else
                        {
                            ViewErrorMesssage(TITLE_PHOTO,
                                              "クラッチの励磁ＯＮに失敗しました。(Photo3)");
                        }
                    }
                    else
                    {
                        StopMeasurement();
                    }

                    break;

                #endregion

                #region 通電状態測定値入力

                case Motion.Photo4:

                    MotinStep = Motion.None;

                    //通電状態の距離入力
                    if (InputValueMessageBox(TITLE_PHOTO, MSG_INPUT_PHOTO, "[mm]", ref rd.HighSpeedPos))
                    {
                        MotinStep = Motion.Photo5;
                    }
                    else
                    {
                        //再入力
                        MotinStep = Motion.Photo4;
                    }

                    break;

                #endregion

                #region クラッチ切替時異音確認

                case Motion.Photo5:

                    MotinStep = Motion.None;

                    if (MessageBox.Show(this,
                                        "クラッチ切替時に異音がないことを確認ください。" + Environment.NewLine +
                                        "準備がよろしければ、【OK】ボタンを押してください。",
                                        TITLE_PHOTO,
                                        MessageBoxButtons.OKCancel,
                                        MessageBoxIcon.Question) == DialogResult.OK)
                    {

                        this.Cursor = Cursors.WaitCursor;

                        ClutchCount = 0;    //クラッチ切替数クリア
                        StatusClutchOnOff();
                        MotinStep = Motion.Photo6;
                    }
                    else
                    {
                        StopMeasurement();
                    }

                    break;

                case Motion.Photo6:

                    //高トルクモード
                    if (CCommandTx.WriteSvNet(CParamID.ClutchExcitation, ServoDef.OFF))
                    {
                        WaitTimer.Start();
                        MotinStep = Motion.Photo7;
                    }
                    else
                    {
                        ViewErrorMesssage(TITLE_PHOTO,
                                          "クラッチの励磁ＯＦＦに失敗しました。(Photo6)");
                    }

                    break;

                case Motion.Photo7:
                    //２待つ
                    Wait(TimeViewDisabled, MSG_NONE, InspectionDef.WAIT_2s, Motion.Photo8);
                    break;

                case Motion.Photo8:

                    //高速回転モード
                    if (CCommandTx.WriteSvNet(CParamID.ClutchExcitation, ServoDef.ON))
                    {
                        WaitTimer.Start();
                        MotinStep = Motion.Photo9;
                    }
                    else
                    {
                        ViewErrorMesssage(TITLE_PHOTO,
                                          "クラッチの励磁ＯＮに失敗しました。(Photo8)");
                    }

                    break;

                case Motion.Photo9:
                    //２秒待つ
                    Wait(TimeViewDisabled, MSG_NONE, InspectionDef.WAIT_2s, Motion.Photo10);
                    break;

                case Motion.Photo10:

                    if (ClutchCount < MAX_CLUTCH_CNT)
                    {
                        MotinStep = Motion.Photo6;
                        ClutchCount++;
                    }
                    else
                    {
                        //終了
                        MotinStep = Motion.Photo11;
                    }

                    StatusClutchOnOff();
                    break;

                #region 完了

                case Motion.Photo11:

                    MotinStep = Motion.None;

                    StopMeasurement();

                    rm.ShowDialog();

                    //フォトセンサ取付完了
                    rd.PhotoComplete();

                    btnStartAction.Focus();

                    break;

                #endregion

                #endregion

                #endregion

                #region 動作確認

                #region モータ回転確認

                #region 高トルクモード

                #region CW回転

                #region 開始

                case Motion.ChkTlqVelCW1:

                    MotinStep = Motion.None;

                    //動作確認前のパラメータ設定
                    if (SetOperationCheckParameter())
                    {
                        if (MessageBox.Show(this,
                                            "モータが高トルクモードでCW/CCW回転します。" + Environment.NewLine +
                                            "準備がよろしければ、【OK】ボタンを押してください。",
                                            TITLE_MOTOR__ROTATION,
                                            MessageBoxButtons.OKCancel,
                                            MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            this.Cursor = Cursors.WaitCursor;

                            ResetMotorRotationMeasurement();

                            LblStatus.Text = MSG_OPERATIORN;
                            TimerBlink.Enabled = true;

                            FormEnabled = false;

                            //クラッチ励磁ＯＦＦ
                            if (ServoControl.ClutchExcitation(ServoDef.OFF))
                            {
                                StartJog(CW, RPM100);

                                WaitTimer.Start();
                                MotinStep = Motion.ChkTlqVelCW2;
                            }
                            else
                            {
                                ViewErrorMesssage(TITLE_MOTOR__ROTATION,
                                                  "クラッチの励磁ＯＦＦに失敗しました。(ChkTlqVelCW1)");
                            }
                        }
                        else
                        {
                            StopMeasurement();
                        }
                    }
                    else
                    {
                        ViewErrorMesssage(TITLE_MOTOR__ROTATION,
                                          "動作確認前のパラメータ設定が異常です。(ChkTlqVelCW1)");
                    }
                    break;

                #endregion

                #region 回転時間１秒

                case Motion.ChkTlqVelCW2:
                    if (!WaitVel(MSG_HITRQCW, InspectionDef.WAIT_1s, Motion.ChkTlqVelCW3))
                    {
                        ViewErrorMesssage(TITLE_MOTOR__ROTATION,
                                          "速度データが取得出来ません。(ChkTlqVelCW2)");
                    }
                    break;

                #endregion

                #region 回転停止 

                case Motion.ChkTlqVelCW3:

                    JogStop();

                    MotinStep = Motion.ChkTlqVelCW4;
                    WaitTimer.Start();

                    break;

                #endregion

                #region 停止最大５秒待ち

                case Motion.ChkTlqVelCW4:

                    if (!WaitJogStop(InspectionDef.WAIT_5s, Motion.ChkTlqVelCW5))
                    {
                        ViewErrorMesssage(TITLE_MOTOR__ROTATION,
                                         "ジョグ停止指示の待ち時間を経過しました。(ChkTlqVelCW4)");
                    }

                    break;

                #endregion

                #region 回転速度判定

                case Motion.ChkTlqVelCW5:

                    MotinStep = Motion.ChkTlqVelCCW1;

                    if (JudgementVelocity(CW, ref rd.HighTorqueCWVel))
                    {
                        //正常
                        ResultPass(lblHighTorqueCWVel, rd.HighTorqueCWVel.ToString());
                    }
                    else
                    {
                        //異常
                        ResultFail(lblHighTorqueCWVel, rd.HighTorqueCWVel.ToString());
                    }

                    break;

                #endregion

                #endregion

                #region CCW回転

                #region 開始

                case Motion.ChkTlqVelCCW1:

                    StartJog(CCW, RPM100);

                    MotinStep = Motion.ChkTlqVelCCW2;
                    WaitTimer.Start();

                    break;

                #endregion

                #region 回転時間１秒　 

                case Motion.ChkTlqVelCCW2:

                    if (!WaitVel(MSG_HITRQCCW, InspectionDef.WAIT_1s, Motion.ChkTlqVelCCW3))
                    {
                        ViewErrorMesssage(TITLE_MOTOR__ROTATION,
                                          "速度データが取得出来ません。(ChkTlqVelCCW2)");
                    }

                    break;

                #endregion

                #region 回転停止

                case Motion.ChkTlqVelCCW3:

                    JogStop();

                    MotinStep = Motion.ChkTlqVelCCW4;
                    WaitTimer.Start();

                    break;

                #endregion

                #region 停止最大５秒待ち

                case Motion.ChkTlqVelCCW4:

                    if (!WaitJogStop(InspectionDef.WAIT_5s, Motion.ChkTlqVelCCW5))
                    {
                        ViewErrorMesssage(TITLE_MOTOR__ROTATION,
                                         "ジョグ停止指示の待ち時間を経過しました。(ChkTlqVelCCW4)");
                    }

                    break;

                #endregion

                #region 回転速度判定

                case Motion.ChkTlqVelCCW5:

                    MotinStep = Motion.ChkhighVelCW1;

                    if (JudgementVelocity(CCW, ref rd.HighTorqueCCWVel))
                    {
                        //正常
                        ResultPass(lblHighTorqueCCWVel, rd.HighTorqueCCWVel.ToString());
                    }
                    else
                    {
                        //異常
                        ResultFail(lblHighTorqueCCWVel, rd.HighTorqueCCWVel.ToString());
                    }

                    break;

                #endregion

                #endregion

                #endregion

                #region 高速回転モード

                #region CW回転

                #region 開始

                case Motion.ChkhighVelCW1:

                    MotinStep = Motion.None;

                    if (ServoControl.ServoON(ServoDef.WAIT_100ms))
                    {
                        if (MessageBox.Show(this,
                                            "モータが高速回転モードでCW/CCW回転します。" + Environment.NewLine +
                                            "準備がよろしければ、【OK】ボタンを押してください。",
                                            TITLE_MOTOR__ROTATION,
                                            MessageBoxButtons.OKCancel,
                                            MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            LblStatus.Text = MSG_OPERATIORN;
                            TimerBlink.Enabled = true;

                            //クラッチ励磁ＯＮ
                            if (ServoControl.ClutchExcitation(ServoDef.ON))
                            {
                                StartJog(CW, RPM100);

                                WaitTimer.Start();
                                MotinStep = Motion.ChkhighVelCW2;
                            }
                            else
                            {
                                ViewErrorMesssage(TITLE_MOTOR__ROTATION,
                                                  "クラッチの励磁ＯＮに失敗しました。(ChkhighVelCW1)");
                            }
                        }
                        else
                        {
                            StopMeasurement();
                        }
                    }
                    else
                    {
                        ViewErrorMesssage(TITLE_MOTOR__ROTATION,
                                          "サーボＯＮに失敗しました。(ChkhighVelCW1)");
                    }

                    break;

                #endregion

                #region 回転時間１秒

                case Motion.ChkhighVelCW2:
                    if (!WaitVel(MSG_HISPDCW, InspectionDef.WAIT_1s, Motion.ChkhighVelCW3))
                    {
                        ViewErrorMesssage(TITLE_MOTOR__ROTATION,
                                         "速度データが取得出来ません。(ChkhighVelCW2)");
                    }
                    break;

                #endregion

                #region 回転停止 

                case Motion.ChkhighVelCW3:

                    JogStop();

                    MotinStep = Motion.ChkhighVelCW4;
                    WaitTimer.Start();

                    break;

                #endregion

                #region 停止最大５秒待ち

                case Motion.ChkhighVelCW4:

                    if (!WaitJogStop(InspectionDef.WAIT_5s, Motion.ChkhighVelCW5))
                    {
                        ViewErrorMesssage(TITLE_MOTOR__ROTATION,
                                         "ジョグ停止指示の待ち時間を経過しました。(ChkhighVelCW4)");
                    }

                    break;

                #endregion

                #region 回転速度判定

                case Motion.ChkhighVelCW5:

                    MotinStep = Motion.ChkhighVelCCW1;

                    if (JudgementVelocity(CW, ref rd.HighSpeedCWVel))
                    {
                        //正常
                        ResultPass(lblHighSpeedCWVel, rd.HighSpeedCWVel.ToString());
                    }
                    else
                    {
                        //異常
                        ResultFail(lblHighSpeedCWVel, rd.HighSpeedCWVel.ToString());
                    }

                    break;

                #endregion

                #endregion

                #region CCW回転

                #region 開始

                case Motion.ChkhighVelCCW1:

                    StartJog(CCW, RPM100);

                    WaitTimer.Start();
                    MotinStep = Motion.ChkhighVelCCW2;

                    break;

                #endregion

                #region 回転時間１秒　 

                case Motion.ChkhighVelCCW2:

                    if (!WaitVel(MSG_HISPDCCW, InspectionDef.WAIT_1s, Motion.ChkhighVelCCW3))
                    {
                        ViewErrorMesssage(TITLE_MOTOR__ROTATION,
                                          "速度データが取得出来ません。(ChkhighVelCCW2)");
                    }

                    break;

                #endregion

                #region 回転停止

                case Motion.ChkhighVelCCW3:

                    JogStop();

                    MotinStep = Motion.ChkhighVelCCW4;
                    WaitTimer.Start();

                    break;

                #endregion

                #region 停止最大５秒待ち

                case Motion.ChkhighVelCCW4:

                    if (!WaitJogStop(InspectionDef.WAIT_5s, Motion.ChkhighVelCCW5))
                    {
                        ViewErrorMesssage(TITLE_MOTOR__ROTATION,
                                         "ジョグ停止指示の待ち時間を経過しました。(ChkhighVelCCW4)");
                    }

                    break;

                #endregion

                #region 回転速度判定

                case Motion.ChkhighVelCCW5:

                    MotinStep = Motion.ChkStLowTlpCur1;

                    if (JudgementVelocity(CCW, ref rd.HighSpeedCCWVel))
                    {
                        //正常
                        ResultPass(lblHighSpeedCCWVel, rd.HighSpeedCCWVel.ToString());
                    }
                    else
                    {
                        //異常
                        ResultFail(lblHighSpeedCCWVel, rd.HighSpeedCCWVel.ToString());
                    }

                    break;

                #endregion

                #endregion

                #endregion

                #endregion

                #region モータ電流測定

                #region 起動直後_高トルクモード(低速)

                #region ジョグ低速

                case Motion.ChkStLowTlpCur1:

                    MotinStep = Motion.None;

                    //動作確認前のパラメータ設定
                    if (SetOperationCheckParameter())
                    {
                        if (MessageBox.Show(this,
                                            "モータ電流測定を実施します。" + Environment.NewLine +
                                            "準備がよろしければ、【OK】ボタンを押してください。",
                                            TITLE_MOTOR_CURRENT,
                                            MessageBoxButtons.OKCancel,
                                            MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            LblStatus.Text = MSG_OPERATIORN;
                            TimerBlink.Enabled = true;

                            FormEnabled = false;

                            //クラッチ励磁ＯＦＦ
                            if (ServoControl.ClutchExcitation(ServoDef.OFF))
                            {
                                StartJog(CW, motorInf.StartupTlqLow);

                                WaitTimer.Start();
                                MotinStep = Motion.ChkStLowTlpCur2;
                            }
                            else
                            {
                                ViewErrorMesssage(TITLE_MOTOR__ROTATION,
                                                  "クラッチの励磁ＯＦＦに失敗しました。");
                            }
                        }
                        else
                        {
                            StopMeasurement();
                        }
                    }
                    else
                    {
                        ViewErrorMesssage(TITLE_MOTOR__ROTATION,
                                          "動作確認前のパラメータ設定が異常です。");
                    }
                    break;

                #endregion

                #region CW回転安定待ち時間５秒　 

                case Motion.ChkStLowTlpCur2:
                    Wait(TimeViewEnabled, MSG_UPTLQLOW, InspectionDef.WAIT_5s, Motion.ChkStLowTlpCur3);
                    break;

                #endregion

                #region 低速ログデータ取得

                case Motion.ChkStLowTlpCur3:
                    MotinStep = Motion.LogGet1;
                    bkMotinStep = Motion.ChkStLowTlpCur4;
                    break;

                #endregion

                #region  起動直後_高トルクモード(低速)測定値算出

                case Motion.ChkStLowTlpCur4:

                    //瞬時電流の最大値取得
                    rd.StartupTlqLowCur = Maximum(LogCurData) * 0.01f;

                    //瞬時電流のログ保存
                    rd.LogStartupTlqLowCur = LogCurDataSave(LogCurData);

                    //結果表示
                    ResultPass(lblTrqLowVelStart, rd.StartupTlqLowCur.ToString("F2"));
                    
                    //WaitTimer.Start();
                    MotinStep = Motion.ChkStHighTlpCur1;

                    break;

                #endregion

                #region 次のシーケンスまで５秒待ち(未使用)

                //case Motion.ChkStLowTlpCur5:
                //    Wait(WAIT_5s, Motion.ChkStHighTlpCur1);
                //    break;

                #endregion

                #endregion

                #region 起動直後_高トルクモード(高速)

                #region ジョグ高速

                case Motion.ChkStHighTlpCur1:

                    StartJog(CW, motorInf.StartupTlqHigh);

                    WaitTimer.Start();
                    MotinStep = Motion.ChkStHighTlpCur2;

                    break;

                #endregion

                #region CW回転安定待ち時間５秒　 

                case Motion.ChkStHighTlpCur2:
                    Wait(TimeViewEnabled, MSG_UPTLQHIGH, InspectionDef.WAIT_5s, Motion.ChkStHighTlpCur3);
                    break;

                #endregion

                #region 高速ログデータ取得

                case Motion.ChkStHighTlpCur3:
                    MotinStep = Motion.LogGet1;
                    bkMotinStep = Motion.ChkStHighTlpCur4;
                    break;

                #endregion

                #region  起動直後_高トルクモード(高速)測定値算出

                case Motion.ChkStHighTlpCur4:

                    //瞬時電流の最大値取得
                    rd.StartupTlqHighwCur = Maximum(LogCurData) * 0.01f;

                    //瞬時電流のログ保存
                    rd.LogStartupTlqHighwCur = LogCurDataSave(LogCurData);

                    //結果表示
                    ResultPass(lblTrqHighVelStart, rd.StartupTlqHighwCur.ToString("F2"));

                    //WaitTimer.Start();
                    MotinStep = Motion.ChkStHighSpRowCur1;

                    break;

                #endregion

                #region 次のシーケンスまで５秒待ち(未使用)

                //case Motion.ChkStHighTlpCur5:
                //    Wait(WAIT_5s, Motion.ChkStHighSpRowCur1);
                //    break;

                #endregion

                #endregion

                #region 起動直後_高速回転モード(低速)

                #region ジョグ低速

                case Motion.ChkStHighSpRowCur1:

                    //クラッチ励磁ＯＮ
                    if (ServoControl.ClutchExcitation(ServoDef.ON))
                    {
                        StartJog(CW, motorInf.StartupHighSpLow);

                        WaitTimer.Start();
                        MotinStep = Motion.ChkStHighSpRowCur2;
                    }
                    else
                    {
                        ViewErrorMesssage(TITLE_MOTOR__ROTATION,
                                          "クラッチの励磁ＯＮに失敗しました。");
                    }

                    break;

                #endregion

                #region CW回転安定待ち時間５秒　 

                case Motion.ChkStHighSpRowCur2:
                    Wait(TimeViewEnabled, MSG_UPHISPLOW, InspectionDef.WAIT_5s, Motion.ChkStHighSpRowCur3);
                    break;

                #endregion

                #region 低速ログデータ取得

                case Motion.ChkStHighSpRowCur3:
                    MotinStep = Motion.LogGet1;
                    bkMotinStep = Motion.ChkStHighSpRowCur4;
                    break;

                #endregion

                #region  起動直後_高速回転モード(低速)測定値算出

                case Motion.ChkStHighSpRowCur4:

                    //瞬時電流の最大値取得
                    rd.StartupHighSpLowCur = Maximum(LogCurData) * 0.01f;

                    //瞬時電流のログ保存
                    rd.LogStartupHighSpLowCur = LogCurDataSave(LogCurData);

                    //結果表示
                    ResultPass(lblRotationLowVel, rd.StartupHighSpLowCur.ToString("F2"));

                    //WaitTimer.Start();
                    MotinStep = Motion.ChkStHighSpHighCur1;

                    break;

                #endregion

                #region 次のシーケンスまで５秒待ち

                //case Motion.ChkStHighSpRowCur5:
                //    Wait(WAIT_5s, Motion.ChkStHighSpHighCur1);
                //    break;

                #endregion

                #endregion

                #region 起動直後_高速回転モード(高速)

                #region ジョグ高速

                case Motion.ChkStHighSpHighCur1:

                    StartJog(CW, motorInf.StartupHighSpHigh);

                    WaitTimer.Start();
                    MotinStep = Motion.ChkStHighSpHighCur2;

                    break;

                #endregion

                #region CW回転安定待ち時間５秒　 

                case Motion.ChkStHighSpHighCur2:
                    Wait(TimeViewEnabled, MSG_UPHISPHI, InspectionDef.WAIT_5s, Motion.ChkStHighSpHighCur3);
                    break;

                #endregion

                #region 高速ログデータ取得

                case Motion.ChkStHighSpHighCur3:
                    MotinStep = Motion.LogGet1;
                    bkMotinStep = Motion.ChkStHighSpHighCur4;
                    break;

                #endregion

                #region  起動直後_高速回転(高速)測定値算出

                case Motion.ChkStHighSpHighCur4:

                    //瞬時電流の最大値取得
                    rd.StartupHighSpHighCur = Maximum(LogCurData) * 0.01f;

                    //瞬時電流のログ保存
                    rd.LogStartupHighSpHighCur = LogCurDataSave(LogCurData);
                    
                    //結果表示
                    ResultPass(lblRotationHighVel, rd.StartupHighSpHighCur.ToString("F2"));

                    //WaitTimer.Start();
                    MotinStep = Motion.ChkContiHighTlpCur1;

                    break;

                #endregion

                #region 次のシーケンスまで５秒待ち

                //case Motion.ChkStHighSpHighCur5:
                //    Wait(WAIT_5s, Motion.ChkContiHighTlpCur1);
                //    break;

                #endregion

                #endregion

                #region 連続回転_高トルクモード(高速)

                #region ジョグ高速

                case Motion.ChkContiHighTlpCur1:

                    //クラッチ励磁ＯＦＦ
                    if (ServoControl.ClutchExcitation(ServoDef.OFF))
                    {
                        StartJog(CW, motorInf.ContiRotateTlqHigh);

                        WaitTimer.Start();
                        MotinStep = Motion.ChkContiHighTlpCur2;
                    }
                    else
                    {
                        ViewErrorMesssage(TITLE_MOTOR__ROTATION,
                                          "クラッチの励磁ＯＦＦに失敗しました。");
                    }

                    break;

                #endregion

                #region CW回転１０分　 

                case Motion.ChkContiHighTlpCur2:
                    Wait(TimeViewEnabled, MSG_CTIRTTLQHI, InspectionDef.WAIT_10m, Motion.ChkContiHighTlpCur3);
                    break;

                #endregion

                #region 高速ログデータ取得

                case Motion.ChkContiHighTlpCur3:
                    MotinStep = Motion.LogGet1;
                    bkMotinStep = Motion.ChkContiHighTlpCur4;
                    break;

                #endregion

                #region  連続回転_高トルクモード(高速)測定値算出/判定

                case Motion.ChkContiHighTlpCur4:

                    MotinStep = Motion.ChkContiHighSpHighCur1;

                    //瞬時電流の最大値取得
                    rd.ContiRotateTlqHighCur = Maximum(LogCurData) * 0.01f;

                    //瞬時電流のログ保存
                    rd.LogContiRotateTlqHighCur = LogCurDataSave(LogCurData);

                    //判定
                    if (rd.ContiRotateTlqHighCur <= motorInf.ContiRotateTlqCur)
                    {
                        //正常
                        ResultPass(lblTrqHighVelConti, rd.ContiRotateTlqHighCur.ToString("F2"));
                    }
                    else
                    {
                        //異常
                        ResultFail(lblTrqHighVelConti, rd.ContiRotateTlqHighCur.ToString("F2"));
                    }

                    //WaitTimer.Start();
                    //MotinStep = Motion.ChkContiHighTlpCur5;

                    break;

                #endregion

                #region 次のシーケンスまで５秒待ち(未使用)

                //case Motion.ChkContiHighTlpCur5:
                //    Wait(WAIT_5s, Motion.ChkContiHighSpHighCur1);
                //    break;

                #endregion

                #endregion

                #region 連続回転_高速回転モード(高速)

                #region ジョグ高速

                case Motion.ChkContiHighSpHighCur1:

                    //クラッチ励磁ＯＮ
                    if (ServoControl.ClutchExcitation(ServoDef.ON))
                    {
                        StartJog(CW, motorInf.ContiRotateSpHigh);

                        WaitTimer.Start();
                        MotinStep = Motion.ChkContiHighSpHighCur2;
                    }
                    else
                    {
                        ViewErrorMesssage(TITLE_MOTOR__ROTATION,
                                          "クラッチの励磁ＯＮに失敗しました。");
                    }

                    break;

                #endregion

                #region CW回転１０分　 

                case Motion.ChkContiHighSpHighCur2:
                    Wait(TimeViewEnabled, MSG_CTIRTSPDHI, InspectionDef.WAIT_10m, Motion.ChkContiHighSpHighCur3);
                    break;

                #endregion

                #region 高速ログデータ取得

                case Motion.ChkContiHighSpHighCur3:
                    MotinStep = Motion.LogGet1;
                    bkMotinStep = Motion.ChkContiHighSpHighCur4;
                    break;

                #endregion

                #region  連続回転_高速回転モード(高速)測定値算出/判定

                case Motion.ChkContiHighSpHighCur4:

                    MotinStep = Motion.None;

                    //瞬時電流の最大値取得
                    rd.ContiRotateSpHighhCur = Maximum(LogCurData) * 0.01f;

                    //瞬時電流のログ保存
                    rd.LogContiRotateSpHighhCur = LogCurDataSave(LogCurData);

                    //判定
                    if (rd.ContiRotateSpHighhCur <= motorInf.ContiRotateSpHighCur)
                    {
                        //正常
                        ResultPass(lblRotationHighConti, rd.ContiRotateSpHighhCur.ToString("F2"));
                    }
                    else
                    {
                        //異常
                        ResultPass(lblRotationHighConti, rd.ContiRotateSpHighhCur.ToString("F2"));
                    }

                    StopMeasurement();

                    //完了
                    rm.ShowDialog();

                    //動作確認完了
                    rd.MotorComplete();

                    btnStartClutch.Focus();

                    //WaitTimer.Start();
                    //MotinStep = Motion.ChkContiHighSpHighCur5;

                    break;

                #endregion

                #region 次のシーケンスまで５秒待ち(未使用)

                //case Motion.ChkContiHighSpHighCur5:
                //    Wait(WAIT_5s, Motion.ChkContiHighSpHighCur6);
                //    break;

                #endregion

                #endregion

                #endregion

                #endregion

                #region クラッチ動作

                case Motion.Clutch1:

                    MotinStep = Motion.None;

                    if (MessageBox.Show(this,
                                        "ギャップの測定をしてください。" + Environment.NewLine +
                                        "準備がよろしければ、【OK】ボタンを押してください。",
                                        TITLE_PHOTO,
                                        MessageBoxButtons.OKCancel,
                                        MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        ResetClutchOperation();

                        LblStatus.Text = MSG_CLUTCH;
                        TimerBlink.Enabled = true;

                        FormEnabled = false;

                        //フォトセンサ取付前のパラメータ設定

                        if (ServoControl.ClutchExcitation(ServoDef.ON))
                        {
                            MotinStep = Motion.Clutch2;
                        }
                        else
                        {
                            ViewErrorMesssage(TITLE_PHOTO,
                                              "クラッチの励磁ＯＮに失敗しました。(Clutch1)");
                        }
                    }
                    else
                    {
                        StopMeasurement();
                    }

                    break;

                case Motion.Clutch2:

                    MotinStep = Motion.None;

                    //ギャップの入力
                    if (InputValueMessageBox(TITLE_CLUTCH_OPE, MSG_INPUT_CLUTCH, "[mm]", ref rd.ClutchGap))
                    {
                        MotinStep = Motion.Clutch3;
                    }
                    else
                    {
                        //再入力
                        MotinStep = Motion.Clutch2;
                    }

                    break;

                case Motion.Clutch3:

                    MotinStep = Motion.None;

                    StopMeasurement();

                    rm.ShowDialog();

                    //クラッチ動作完了
                    rd.ClutchComplete();

                    break;

                #endregion

                #region ログデータ取得要求

                case Motion.LogGet1:

                    IsGetLog = true;    //メインへログデータ取得要求
                    IsSetLog = false;
                    MotinStep = Motion.LogGet2;
                    break;

                case Motion.LogGet2:
                    WaitTimer.Reset();
                    WaitTimer.Start();
                    MotinStep = Motion.LogGet3;
                    break;

                case Motion.LogGet3:
                    //ログ採取完了まで最大5秒待つ
                    if(!WaitLog(InspectionDef.WAIT_5s, Motion.LogGet4))
                    {
                        ViewErrorMesssage(TITLE_MOTOR__ROTATION,
                                        "ログ採取完了が完了待ち時間を経過しました。(" + bkMotinStep.ToString() + ")");
                    }
                    break;

                case Motion.LogGet4:

                    //ジョグ停止
                    JogStop();

                    MotinStep = Motion.LogGet5;
                    WaitTimer.Start();

                    break;

                case Motion.LogGet5:

                    //停止のステータスを最大１０秒待つ
                    if (!WaitJogStop(InspectionDef.WAIT_10s, Motion.LogGet6))
                    {
                        ViewErrorMesssage(TITLE_MOTOR__ROTATION,
                                         "ジョグ停止指示の待ち時間を経過しました。(" + bkMotinStep.ToString() + ")");
                    }

                    break;

                case Motion.LogGet6:

                    //ログ受信?
                    if (IsSetLog)
                    {
                        //ログデータ取得成功
                        MotinStep = bkMotinStep;
                    }
                    else
                    {
                        //ログデータ取得失敗
                        MotinStep = Motion.None;

                        ViewErrorMesssage(TITLE_MOTOR__ROTATION,
                                          "電流値のログデータの取得に失敗しました。(" + bkMotinStep.ToString() + ")");
                    }

                    break;

                #endregion

                #region 停止

                case Motion.Stop1:

                    WaitTimer.Reset();
                    WaitTimer.Start();

                    MotinStep = Motion.Stop2;
                    break;

                case Motion.Stop2:

                    //停止まで最大１０秒待つ
                    if (!WaitJogStop(InspectionDef.WAIT_10s, Motion.Stop3))
                    {
                        ViewErrorMesssage("停止",
                                          "ジョグ停止指示の待ち時間を経過しました。(Stop2)");
                    }

                    break;

                case Motion.Stop3:

                    StopMeasurement();

                    MotinStep = Motion.None;

                    break;

                #endregion

                #region アイドリング

                case Motion.None:
                    break;

                    #endregion
            }

            #region 停止指示あり？

            if (IsStop)
            {
                JogStop();
                MotinStep = Motion.Stop1;

                IsStop = false;
            }

            #endregion
        }

        #endregion

        #region クラッチ切替ステータス表示

        private void StatusClutchOnOff()
        {
            LblStatus.Text = MSG_CLUTCH_ONOFF + " [" + ClutchCount.ToString("00") + "/" + MAX_CLUTCH_CNT.ToString("00") + "]";
        }

        #endregion

        #region 正常メッセージ

        private void ViewNormalMesssage(string title, string msg)
        {
            StopMeasurement();

            MessageBox.Show(this,
                            msg,
                            title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        #endregion

        #region 異常時メッセージ

        private void ViewErrorMesssage(string title, string msg)
        {
            StopMeasurement();

            MessageBox.Show(this,
                            msg,
                            title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }

        #endregion

        #region 待ち

        /// <summary>
        /// 単純待ち
        /// </summary>
        /// <param name="waittime"></param>
        /// <param name="next"></param>
        private void Wait(bool btimeview, string msg, long waittime, Motion next)
        {
            //経過時間表示?
            if (btimeview)
            {
                //総時間を算出
                TimeSpan ts = new TimeSpan(0, 0, (int)(waittime / 1000));

                //経過時間[分:秒]／総時間[分:秒]を表示
                LblStatus.Text = msg + " [" + WaitTimer.Elapsed.Minutes.ToString("00") + ":" +
                                              WaitTimer.Elapsed.Seconds.ToString("00") + "/" +
                                              ts.Minutes.ToString("00") + ":" +
                                              ts.Seconds.ToString("00") + "]";
            }

            if (WaitTimer.ElapsedMilliseconds > waittime)
            {
                //指定した時間が経過?
                MotinStep = next;
                WaitTimer.Reset();
            }
        }

        /// <summary>
        /// 速度データ採取待ち
        /// </summary>
        /// <param name="waittime"></param>
        /// <param name="next"></param>
        private bool WaitVel(string msg, long waittime, Motion next)
        {
            int vel = 0;

            //総時間を算出
            TimeSpan ts = new TimeSpan(0, 0, (int)(waittime / 1000));

            LblStatus.Text = msg + " [" + WaitTimer.Elapsed.Minutes.ToString("00") + ":" +
                                          WaitTimer.Elapsed.Seconds.ToString("00") + "/" +
                                          ts.Minutes.ToString("00") + ":" +
                                          ts.Seconds.ToString("00") + "]";

            if (WaitTimer.ElapsedMilliseconds > waittime)
            {
                //指定した時間が経過?
                MotinStep = next;
                WaitTimer.Reset();
            }
            else
            {
                if (CCommandTx.ReadSvNet(CParamID.FeedbackVelocity, ref vel))
                {
                    strFbVelocity += vel.ToString() + ",";
                }
                else
                {
                    WaitTimer.Reset();
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// ログデータ採取待ち
        /// </summary>
        /// <param name="waittime"></param>
        /// <param name="next"></param>
        private bool WaitLog(long waittime, Motion next)
        {
            if (WaitTimer.ElapsedMilliseconds > waittime)
            {
                //指定した時間が経過?
                //MotinStep = next;
                WaitTimer.Reset();
                return false;
            }
            else
            {
                //ログデータ取得
                if (IsSetLog)
                {
                    MotinStep = next;
                    WaitTimer.Reset();
                }

                return true;
            }
        }

        /// <summary>
        /// ジョグ停止待ち
        /// </summary>
        /// <param name="waittime"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        private bool WaitJogStop(long waittime, Motion next)
        {
            int sts = 0;

            if (WaitTimer.ElapsedMilliseconds > waittime)
            {
                //指定した時間が経過?
                WaitTimer.Reset();
                return false;
            }
            else
            {
                if (CCommandTx.ReadSvNet(CParamID.ServoStatus, ref sts))
                {
                    //ジョグ停止？
                    if ((sts & 0x4000) == 0x4000)
                    {
                        WaitTimer.Reset();
                        MotinStep = next;
                    }
                }
                else
                {
                    WaitTimer.Reset();
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region ログデータ

        /// <summary>
        /// 取得
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="log_num"></param>
        /// <param name="fft_on"></param>
        public void UpdateLogData(ref int[] buf, int log_num, bool fft_on)
        {
            int off = new int();

            if (fft_on)
            {
                off = LogWork.KindNum;
            }
            else
            {
                off = LogWork.MonNum;
            }

            for (int i = 0, j = 0; i < log_num; i++, j += off)
            {

                //LogData[LogWork.POS, LogPtr] = buf[j + 0];      //位置
                LogVelData[LogPtr] = buf[j + 1];      //瞬時速度
                LogCurData[LogPtr] = buf[j + 2];      //瞬時電流

                //LogData[LogWork.STS, LogPtr] = buf[j + 3];      //ステータス
                //LogData[LogWork.PRM1, LogPtr] = buf[j + 4];     //パラメタ1
                //LogData[LogWork.PRM2, LogPtr] = buf[j + 5];     //パラメタ2
                //LogData[LogWork.PRM3, LogPtr] = buf[j + 6];     //パラメタ3

                LogPtr++;

                if (LogPtr >= LogLength)
                {
                    IsSetLog = true;
                    IsGetLog = false;
                    LogPtr = 0;
                }
            }
        }

        /// <summary>
        /// 瞬時電流値データ保存
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        private string LogCurDataSave(int[] log)
        {
            string str = string.Empty;

            if (log.Length > 0)
            {
                foreach (int dat in log)
                {
                    float fval = dat * 0.01f;

                    str += fval.ToString("F2") + "\t";
                }

                str = str.Substring(0, str.Length - 1);
            }

            return str;
        }

        #endregion

        #region 測定結果

        private void ResultPass(Label lbl, string strval)
        {
            lbl.ForeColor = Color.White;
            lbl.BackColor = Color.Blue;

            lbl.Text = strval;
        }

        private void ResultFail(Label lbl, string strval)
        {
            lbl.ForeColor = Color.White;
            lbl.BackColor = Color.Red;

            lbl.Text = strval;
        }

        #endregion

        #region 速度判定

        private bool JudgementVelocity(bool ccw, ref int ave_vel)
        {
            const int range = 10;   //誤差10%

            int min;
            int max;

            try
            {
                if (ccw)
                {
                    min = CommandVelocity + (CommandVelocity / range);
                    max = CommandVelocity - (CommandVelocity / range);
                }
                else
                {
                    min = CommandVelocity - (CommandVelocity / range);
                    max = CommandVelocity + (CommandVelocity / range);
                }

                if (strFbVelocity == string.Empty) return false;

                string[] strbuff = strFbVelocity.Substring(0, strFbVelocity.Length - 1).Split(',');

                if (strbuff.Length == 0) return false;

                int[] aryval = new int[strbuff.Length];

                for (int i = 0; i < strbuff.Length; i++)
                {
                    if (!int.TryParse(strbuff[i], out aryval[i])) return false;
                }

                int min_v = Minimum(aryval);

                int max_v = Maximum(aryval);

                //平均値を求める
                ave_vel = Average(aryval);

                Debug.WriteLine("平均 = " + ave_vel.ToString() + "[rpm]" + " 最小 = " + min_v.ToString() + "[rpm]" + " 最大 = " + max_v.ToString() + "[rpm]");

                return ave_vel >= min && ave_vel <= max;
            }
            catch
            {
                Debug.WriteLine("!!! CheckVelocity Error !!!!");

                return false;
            }
        }

        #endregion

        #region 停止

        private void StopMeasurement()
        {
            this.Cursor = Cursors.Default;

            LblStatus.Text = MSG_WAIT;

            MotinStep = Motion.None;

            TimerBlink.Enabled = false;

            FormEnabled = true;

            ServoControl.ClutchExcitation(ServoDef.OFF);

            ServoControl.ServoOFF();

            LblStatus.StartColor = Color.White;
            LblStatus.EndColor = Color.White;
        }

        #endregion

        #region フォトセンサ取付用パラメータ設定

        private bool SetPhotoSensorMountParameter()
        {
            if (!CCommandTx.WriteSvNet(CParamID.VelocityInputMode, 0)) return false;

            if (!ServoControl.ControlMode(2, true)) return false;

            if (!ServoControl.ServoON(ServoDef.WAIT_100ms)) return false;

            return true;
        }

        #endregion

        #region 動作確認用パラメータ設定

        private bool SetOperationCheckParameter()
        {
            if (!CCommandTx.WriteSvNet(CParamID.VelocityInputMode, 0)) return false;

            if (!ServoControl.ControlMode(2, true)) return false;

            //瞬時速度設定
            if (!CCommandTx.WriteSvNet(CParamID.LogKind2, 1)) { return false; }

            //瞬時電流設定
            if (!CCommandTx.WriteSvNet(CParamID.LogKind3, 1)) { return false; }

            //サーボオン
            if (!ServoControl.ServoON(ServoDef.WAIT_100ms)) return false;

            return true;
        }

        #endregion

        #region ジョグ

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ccw"></param>
        /// <param name="vel"></param>
        /// <returns></returns>
        private bool StartJog(bool ccw, int vel)
        {
            const int acc = 100;    //加速度 [10rpm/s]
            const int dcc = 100;    //減速度 [10rpm/s]

            strFbVelocity = string.Empty;

            CommandVelocity = ccw ? -vel : vel;

            int cmd = CMonitor.GetParameter(CParamID.ServoCommand);

            cmd &= ~0x0030;     //Hard Stop & Smooth Stop Clear
            if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) { return false; }

            cmd |= 0x0080;      //Smoothing On

            if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) { return false; }

            if (!CCommandTx.WriteSvNet(CParamID.TargetAcceleration, acc)) { return false; }

            if (!CCommandTx.WriteSvNet(CParamID.TargetDeceleration, dcc)) { return false; }

            if (!CCommandTx.WriteSvNet(CParamID.CommandVelocity, CommandVelocity)) { return false; }

            Thread.Sleep(500);

            return true;
        }

        /// <summary>
        /// 停止
        /// </summary>
        private void JogStop()
        {
            int cmd = CMonitor.GetParameter(CParamID.ServoCommand);
            int sts = CMonitor.GetParameter(CParamID.ServoStatus);

            cmd |= 0x0020;      //Smooth Stop bit Set

            if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) { return; }
        }

        #endregion

        #region 動作確認定義情報取得

        private void txtMotorType_TextChanged(object sender, EventArgs e)
        {
            SetMotorInformation();
        }

        /// <summary>
        ///  動作確認定義情報取得
        /// </summary>
        private void SetMotorInformation()
        {
            IsBarcode = false;
            ButtonEnabled = false;

            if (txtBarcode.Text != string.Empty)
            {
                for (int i = 0; i < InspectionDef.pHotoParamters.Length; i++)
                {
                    if (InspectionDef.pHotoParamters[i].MotorType == txtMotorType.Text)
                    {
                        motorInf.Model = InspectionDef.pHotoParamters[i].MotorType;
                        motorInf.StartupTlqLow = InspectionDef.pHotoParamters[i].StartupTlqLow;
                        motorInf.StartupTlqHigh = InspectionDef.pHotoParamters[i].StartupTlqHigh;
                        motorInf.StartupHighSpLow = InspectionDef.pHotoParamters[i].StartupHighSpLow;
                        motorInf.StartupHighSpHigh = InspectionDef.pHotoParamters[i].StartupHighSpHigh;
                        motorInf.ContiRotateTlqHigh = InspectionDef.pHotoParamters[i].ContiRotateTlqHigh;
                        motorInf.ContiRotateSpHigh = InspectionDef.pHotoParamters[i].ContiRotateSpHigh;
                        motorInf.ContiRotateTlqCur = InspectionDef.pHotoParamters[i].ContiRotateTlqCur;
                        motorInf.ContiRotateSpHighCur = InspectionDef.pHotoParamters[i].ContiRotateSpHighCur;

                        ButtonEnabled = true;

                        IsBarcode = true;
                        break;
                    }
                }
            }
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
                txtMotorType.Text = cmbModel.Text;
                SetMotorInformation();

                //測定結果生成
                if (rd != null)
                {
                    rd.Dispose();
                    rd = null;
                }

                rd = new ResultData(txtBarcode.Text, txtMotorType.Text, false);
                
                ButtonEnabled = true;
            }
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

        #region 測定結果入力

        private bool InputValueMessageBox(string caption, string msg, string unit, ref float val)
        {
            bool bret = false;

            InputMessage finp = new InputMessage
            {
                Text = caption,

                Message = msg,
                Unit = unit,
            };

            finp.StartPosition = FormStartPosition.CenterScreen;

            if (finp.ShowDialog() == DialogResult.OK) bret = true;

            val = finp.Value;

            return bret;
        }

        #endregion

        #region 平均値

        /// <summary>
        /// 平均値
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        private int Average(params int[] nums)
        {
            if (nums.Length == 0) return 0;

            int val = 0;

            for (int i = 0; i < nums.Length; i++) val += nums[i];

            val /= nums.Length;

            return val;
        }

        #endregion

        #region 最小値

        /// <summary>
        /// 最小値
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        private int Minimum(params int[] nums)
        {
            if (nums.Length == 0)
            {
                throw new Exception("Array is empty");
            }

            int min = int.MaxValue;

            foreach (var i in nums)
            {
                if (i < min)
                {
                    min = i;
                }
            }

            return min;
        }

        #endregion

        #region 最大値

        /// <summary>
        /// 最大値
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        private int Maximum(params int[] nums)
        {
            if (nums.Length == 0)
            {
                throw new Exception("Array is empty");
            }

            int max = int.MinValue;

            for (int i = 0; i < nums.Length; i++)
            {
                //絶対値
                int val = Math.Abs(nums[i]);

                if (val > max)
                {
                    max = val;
                }
            }

            return max;
        }

        #endregion

        #region モータ動作情報テキストファイル読込み(未使用)

        //private bool bLoadMotorOperation()
        //{
        //    try
        //    {
        //        string path = Path.Combine(Application.StartupPath, "Config");

        //        path = Path.Combine(path, "Photo_Sensor.txt");

        //        using (StreamReader file = new StreamReader(path,Encoding.Default))
        //        {
        //            string strbuff = file.ReadToEnd();

        //            string work = strbuff.Replace("\r\n", " ");

        //            char[] del = { ' ' };
        //            string[] buf = work.Split(del);

        //            if (buf.Length < 3) return false;

        //            motorInfread = new MotorInf[buf.Length - 1];

        //            for(int i = 1; i < buf.Length; i++)
        //            {
        //                string[] line = buf[i].Split(',');

        //                if (line.Length < 9) return false;

        //                string model = line[0];

        //                if (!int.TryParse(line[1], out int startuptlqlow)) return false;
        //                if (!int.TryParse(line[2], out int startuptlqhigh)) return false;
        //                if (!int.TryParse(line[3], out int startuphighsplow)) return false;
        //                if (!int.TryParse(line[4], out int startuphighsphigh)) return false;
        //                if (!int.TryParse(line[5], out int contirotatetlqhigh)) return false;
        //                if (!int.TryParse(line[6], out int contirotatesphigh)) return false;
        //                if (!float.TryParse(line[7], out float contirotatetlqcur)) return false;
        //                if (!float.TryParse(line[8], out float contirotatesphighcur)) return false;

        //                motorInfread[i - 1] = new MotorInf(model,
        //                                                   startuptlqlow,
        //                                                   startuptlqhigh,
        //                                                   startuphighsplow,
        //                                                   startuphighsphigh,
        //                                                   contirotatetlqhigh,
        //                                                   contirotatesphigh,
        //                                                   contirotatetlqcur,
        //                                                   contirotatesphighcur);
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        return false;
        //    }

        //    return true;
        //}

        #endregion

        #region モータ動作環境クラス

        private class MotorInf
        {
            /// <summary>
            /// モータ型式
            /// </summary>
            public string Model;

            /// <summary>
            /// 起動直後_高ﾄﾙｸﾓｰﾄﾞ低速
            /// </summary>
            public int StartupTlqLow;

            /// <summary>
            /// 起動直後_高ﾄﾙｸﾓｰﾄﾞ高速
            /// </summary>
            public int StartupTlqHigh;

            /// <summary>
            /// 起動直後_高速回転ﾓｰﾄﾞ低速
            /// </summary>
            public int StartupHighSpLow;

            /// <summary>
            /// 起動直後_高速回転ﾓｰﾄﾞ高速
            /// </summary>
            public int StartupHighSpHigh;

            /// <summary>
            /// 連続回転_高ﾄﾙｸﾓｰﾄﾞ高速
            /// </summary>
            public int ContiRotateTlqHigh;

            /// <summary>
            /// 連続回転_高速回転ﾓｰﾄﾞ
            /// </summary>
            public int ContiRotateSpHigh;

            /// <summary>
            /// 連続回転_高ﾄﾙｸﾓｰﾄﾞ判定電流値
            /// </summary>
            public float ContiRotateTlqCur;

            /// <summary>
            /// 連続回転_高速回転ﾓｰﾄﾞ判定電流値
            /// </summary>
            public float ContiRotateSpHighCur;

            public MotorInf() { }

            public MotorInf(string _Model,
                            int _StartupTlqLow, int _StartupTlqHigh,
                            int _StartupHighSpLow, int _StartupHighSpHigh,
                            int _ContiRotateTlqHigh, int _ContiRotateSpHigh,
                            float _ContiRotateTlqCur, float _ContiRotateSpHighCur)
            {
                Model = _Model;
                StartupTlqLow = _StartupTlqLow;
                StartupTlqHigh = _StartupTlqHigh;
                StartupHighSpLow = _StartupHighSpLow;
                StartupHighSpHigh = _StartupHighSpHigh;
                ContiRotateTlqHigh = _ContiRotateTlqHigh;
                ContiRotateSpHigh = _ContiRotateSpHigh;
                ContiRotateTlqCur = _ContiRotateTlqCur;
                ContiRotateSpHighCur = _ContiRotateSpHighCur;

            }
        }

        #endregion

        #region モータ形式変更

        private void cmbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMotorType.Text = cmbModel.Text;
            SetMotorInformation();

            if (txtBarcode.Text != string.Empty)
            {
                //測定結果生成
                if (rd != null)
                {
                    rd.Dispose();
                    rd = null;
                }

                rd = new ResultData(txtBarcode.Text, txtMotorType.Text, false);
            }
        }

        #endregion

        #region モータ形式コンボ追加

        private void AddMotorType()
        {
            int bkselectidx = cmbModel.SelectedIndex;

            cmbModel.Items.Clear();

            for (int i = 0; i < InspectionDef.pHotoParamters.Length; i++)
            {
                if (InspectionDef.pHotoParamters[i].MotorType != string.Empty)
                {
                    if (!cmbModel.Items.Contains(InspectionDef.pHotoParamters[i].MotorType))
                    {
                        cmbModel.Items.Add(InspectionDef.pHotoParamters[i].MotorType);
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
    }

    #region 測定値設定クラス 

    public class ResultData : IDisposable
    {
        #region 定数

        private const string RESULT_FOLDER = @"\Result";   // 測定結果ファイル格納フォルダ

        #endregion

        #region 変数

        /// <summary>
        /// ログファイルフルパス
        /// </summary>
        private string FullPathLogFile = string.Empty;

        /// <summary>
        /// 日付／時刻
        /// </summary>
        private string strDateTime = string.Empty;

        /// <summary>
        /// バーコード
        /// </summary>
        private string Barcode;

        /// <summary>
        /// モータ形式
        /// </summary>
        private string MotorType;

        /// <summary>
        /// ログデータ書込み
        /// </summary>
        private bool blogdate;

        /// <summary>
        /// フォトセンサ取付完了
        /// </summary>
        private bool IsPhoto = false;

        /// <summary>
        /// 動作確認完了
        /// </summary>
        private bool IsMotor = false;

        /// <summary>
        /// クラッチ動作完了
        /// </summary>
        private bool IsClutch = false;

        #region フォトセンサ取付測定値

        /// <summary>
        /// 高トルクモード位置決め実測値
        /// </summary>
        public float HighTorquePos = 0f;

        /// <summary>
        /// 高速モード位置決め実測値
        /// </summary>
        public float HighSpeedPos = 0f;

        #endregion

        #region モータ回転確認結果測定値

        /// <summary>
        /// 高トルクモードCW方向モータ回転速度
        /// </summary>
        public int HighTorqueCWVel = 0;

        /// <summary>
        ///  高速モードCW方向モータ回転速度
        /// </summary>
        public int HighSpeedCWVel = 0;

        /// <summary>
        /// 高トルクモードCCW方向モータ回転速度
        /// </summary>
        public int HighTorqueCCWVel = 0;

        /// <summary>
        ///  高速モードCCW方向モータ回転速度
        /// </summary>
        public int HighSpeedCCWVel = 0;

        #endregion

        #region モータ電流測定値

        /// <summary>
        /// 起動直後_高トルクモード電流測定(低速)
        /// </summary>
        public float StartupTlqLowCur = 0f;

        /// <summary>
        /// 起動直後_高トルクモード電流測定(高速)
        /// </summary>
        public float StartupTlqHighwCur = 0f;

        /// <summary>
        /// 起動直後_高速回転モード電流測定(低速)
        /// </summary>
        public float StartupHighSpLowCur = 0f;

        /// <summary>
        /// 起動直後_高速回転モード電流測定(高速)
        /// </summary>
        public float StartupHighSpHighCur = 0f;

        /// <summary>
        /// 連続回転_高トルク回転モード電流測定(高速)
        /// </summary>
        public float ContiRotateTlqHighCur = 0f;

        /// <summary>
        /// 連続回転_高速回転モード電流測定(高速)
        /// </summary>
        public float ContiRotateSpHighhCur = 0f;

        /// <summary>
        /// 起動直後_高トルクモード電流測定(低速)ログ
        /// </summary>
        public string LogStartupTlqLowCur = string.Empty;

        /// <summary>
        /// 起動直後_高トルクモード電流測定(高速)ログ
        /// </summary>
        public string LogStartupTlqHighwCur = string.Empty;

        /// <summary>
        /// 起動直後_高速回転モード電流測定(低速)ログ
        /// </summary>
        public string LogStartupHighSpLowCur = string.Empty;

        /// <summary>
        /// 起動直後_高速回転モード電流測定(高速)ログ
        /// </summary>
        public string LogStartupHighSpHighCur = string.Empty;

        /// <summary>
        /// 連続回転_高トルク回転モード電流測定(高速)ログ
        /// </summary>
        public string LogContiRotateTlqHighCur = string.Empty;

        /// <summary>
        /// 連続回転_高速回転モード電流測定(高速)ログ
        /// </summary>
        public string LogContiRotateSpHighhCur = string.Empty;

        #endregion

        #region クラッチ動作

        public float ClutchGap = 0f;

        #endregion

        #endregion

        #region コンストラクタ

        public ResultData() { }

        public ResultData(string _Barcode, string _MotorType, bool _blogdate)
        {

            MotorType = _MotorType;
            blogdate = _blogdate;

            IsPhoto = false;
            IsMotor = false;
            IsClutch = false;

            //バーコードが違い場合、新規にログファイルを生成する
            
            if (Barcode != _Barcode)
            {
                Barcode = _Barcode;

                //ログフォルダ
                string LogFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + RESULT_FOLDER;

                //フォルダ生成
                if (!Directory.Exists(LogFolder))
                {
                    Directory.CreateDirectory(LogFolder);
                }

                //現在の日付時刻を取得
                DateTime dt = DateTime.Now;

                string date = String.Format("{0:yyyyMMdd}", dt);
                string time = String.Format("{0:HHmmss}", dt);

                //日時を保存
                strDateTime = String.Format("{0:yyyy/MM/dd} ", dt) + String.Format("{0:HH:mm:ss}", dt);

                // 日付フォルダ+形式フォルダ
                string strDateFolder = LogFolder + @"\" + date + @"\" + MotorType;

                //  日付フォルダ+形式フォルダが既に存在するか？
                if (!Directory.Exists(strDateFolder))
                {
                    // フォルダ生成
                    Directory.CreateDirectory(strDateFolder);
                }

                // ファイル名設定
                FullPathLogFile = strDateFolder + @"\" + Barcode + "_" + date +time + ".txt";

                //ヘッダ書込み
                WriteLogHeader();
            }
        }

        #endregion

        #region 破棄

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion

        #region フォトセンサ取付結果測定値クリア

        /// <summary>
        /// フォトセンサ取付結果測定値クリア
        /// </summary>
        public void ClearPhotoSensorMeasurement()
        {
            IsPhoto = false;

            HighTorquePos = 0f;
            HighSpeedPos = 0f;
        }

        #endregion

        #region  モータ回転確認結果測定値クリア

        /// <summary>
        /// モータ回転確認結果測定値クリア
        /// </summary>
        public void ClearMotorRotationMeasurement()
        {
            IsMotor = false;

            HighTorqueCWVel = 0;
            HighSpeedCWVel = 0;
            HighTorqueCCWVel = 0;
            HighSpeedCCWVel = 0;

            StartupTlqLowCur = 0f;
            StartupTlqHighwCur = 0f;
            StartupHighSpLowCur = 0f;
            StartupHighSpHighCur = 0f;
            ContiRotateTlqHighCur = 0f;
            ContiRotateSpHighhCur = 0f;

            LogStartupTlqLowCur = string.Empty;
            LogStartupTlqHighwCur = string.Empty;
            LogStartupHighSpLowCur = string.Empty;
            LogStartupHighSpHighCur = string.Empty;
            LogContiRotateTlqHighCur = string.Empty;
            LogContiRotateSpHighhCur = string.Empty;
        }

        #endregion

        #region クラッチ動作測定値クリア

        /// <summary>
        /// クラッチ動作測定値クリア
        /// </summary>
        public void ClearClutchOperation()
        {
            ClutchGap = 0f;
        }

        #endregion

        #region フォトセンサ取付完了設定

        /// <summary>
        /// フォトセンサ取付完了設定
        /// </summary>
        public void PhotoComplete()
        {
            WriteLogPhoto();
        }

        #endregion

        #region 動作確認完了設定

        /// <summary>
        /// 動作確認完了設定
        /// </summary>
        public void MotorComplete()
        {
            WriteLogMotor();
        }

        #endregion

        #region クラッチ動作完了設定
        
        /// <summary>
        /// クラッチ動作完了設定
        /// </summary>
        public void ClutchComplete()
        {
            WriteLogClutch();
        }

        #endregion

        #region 計測結果ファイル書込み
        
        /// <summary>
        /// ログヘッダ書込み
        /// </summary>
        private void WriteLogHeader()
        {
            try
            {
                //ログデータ書込み
                using (StreamWriter sw = new StreamWriter(FullPathLogFile, false, Encoding.Default))
                {
                    sw.WriteLine("■フォトセンサ取付/動作結果確認結果");
                    sw.WriteLine(string.Empty);

                    sw.WriteLine("日付：" + strDateTime);
                    sw.WriteLine("形式：" + MotorType);
                   
                    sw.Close();
                }
            }
            catch
            {
                MessageBox.Show("ログファイルのヘッダ保存が出来ませんでした。",
                                "ログファイル",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// フォトセンサ取付ログ書込み
        /// </summary>

        private void WriteLogPhoto()
        {
            try
            {

                string strdate = string.Empty;

                //ログデータ書込み
                using (StreamWriter sw = new StreamWriter(FullPathLogFile, true, Encoding.Default))
                {

                    if (!IsPhoto && !IsMotor && !IsClutch)
                    {
                        strdate = strDateTime;
                    }
                    else
                    {
                        DateTime dt = DateTime.Now;
                        strdate =  dt.ToString();

                    }

                    sw.WriteLine(string.Empty);

                    sw.WriteLine("  ■フォトセンサ取付結果(" + strdate + ")");
                    sw.WriteLine("    1.フォトセンサ_無通電距離  ：" + HighTorquePos.ToString("F1") + "[mm]");
                    sw.WriteLine("    2.フォトセンサ_通電距離    ：" + HighSpeedPos.ToString("F1") + "[mm]");

                    IsPhoto = true;

                    sw.Close();
                }
            }
            catch
            {
                MessageBox.Show("フォトセンサ取付ログ保存が出来ませんでした。",
                                "ログファイル保存",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 動作確認ログ書込み
        /// </summary>
        private void WriteLogMotor()
        {
            try
            {

                string strdate = string.Empty;

                //ログデータ書込み
                using (StreamWriter sw = new StreamWriter(FullPathLogFile, true, Encoding.Default))
                {
                    if (!IsPhoto && !IsMotor && !IsClutch)
                    {
                        strdate = strDateTime;
                    }
                    else
                    {
                        DateTime dt = DateTime.Now;
                        strdate = dt.ToString();
                    }
                    
                    sw.WriteLine(string.Empty);

                    sw.WriteLine("  ■動作確認結果(" + strdate + ")");
                    sw.WriteLine("    3.モータ回転ＣＷ_高トルク  ：" + HighTorqueCWVel.ToString() + "[rpm]");
                    sw.WriteLine("    4.モータ回転ＣＣＷ_高トルク：" + HighTorqueCCWVel.ToString() + "[rpm]");
                    sw.WriteLine("    5.モータ回転ＣＷ_高速回転  ：" + HighSpeedCWVel.ToString() + "[rpm]");
                    sw.WriteLine("    6.モータ回転ＣＣＷ_高速回転：" + HighSpeedCCWVel.ToString() + "[rpm]");
                    sw.WriteLine("    7.起動直後_高トルク_低速   ：" + StartupTlqLowCur.ToString("F2") + "[A]");
                    sw.WriteLine("    8.起動直後_高トルク_高速   ：" + StartupTlqHighwCur.ToString("F2") + "[A]");
                    sw.WriteLine("    9.起動直後_高速回転_低速   ：" + StartupHighSpLowCur.ToString("F2") + "[A]");
                    sw.WriteLine("   10.起動直後_高速回転_高速   ：" + StartupHighSpHighCur.ToString("F2") + "[A]");
                    sw.WriteLine("   11.連続回転_高トルク_高速   ：" + ContiRotateTlqHighCur.ToString("F2") + "[A]");
                    sw.WriteLine("   12.連続回転_高速回転_高速   ：" + ContiRotateSpHighhCur.ToString("F2") + "[A]");

                    //ログデータ書込み要求
                    if (blogdate)
                    {
                        sw.WriteLine(Environment.NewLine);
                        sw.WriteLine("【起動直後_高トルク_低速ログ[A]】");
                        sw.WriteLine(LogStartupTlqLowCur);

                        sw.WriteLine(Environment.NewLine);
                        sw.WriteLine("【起動直後_高トルク_高速ログ[A]】");
                        sw.WriteLine(LogStartupTlqHighwCur);

                        sw.WriteLine(Environment.NewLine);
                        sw.WriteLine("【起動直後_高速回転_低速ログ[A]】");
                        sw.WriteLine(LogStartupHighSpLowCur);

                        sw.WriteLine(Environment.NewLine);
                        sw.WriteLine("【起動直後_高速回転_高速ログ[A]】");
                        sw.WriteLine(LogStartupHighSpHighCur);

                        sw.WriteLine(Environment.NewLine);
                        sw.WriteLine("【連続回転_高トルク_高速ログ[A]】");
                        sw.WriteLine(LogContiRotateTlqHighCur);

                        sw.WriteLine(Environment.NewLine);
                        sw.WriteLine("【連続回転_高速回転_高速ログ[A]】");
                        sw.WriteLine(LogContiRotateSpHighhCur);
                    }

                    IsMotor = true;

                    sw.Close();
                }
            }
            catch
            {
                MessageBox.Show("フォトセンサ取付ログ保存が出来ませんでした。",
                                "ログファイル保存",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }


        /// <summary>
        /// クラッチ動作ログ書込み
        /// </summary>
        private void WriteLogClutch()
        {
            try
            {
                string strdate = string.Empty;

                //ログデータ書込み
                using (StreamWriter sw = new StreamWriter(FullPathLogFile, true, Encoding.Default))
                {

                    if (!IsPhoto && !IsMotor && !IsClutch)
                    {
                        strdate = strDateTime;
                    }
                    else
                    {
                        DateTime dt = DateTime.Now;
                        strdate = dt.ToString();
                    }

                    sw.WriteLine(string.Empty);

                    sw.WriteLine("  ■クラッチ動作結果(" + strdate + ")");
                    sw.WriteLine("   13.クラッチ動作_ギャップ    ：" + ClutchGap.ToString("F1") + "[mm]");

                    IsClutch = true;

                    sw.Close();
                }
            }
            catch
            {
                MessageBox.Show("クラッチ動作ログ保存が出来ませんでした。",
                                "ログファイル保存",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        #endregion
    }

    #endregion

}
