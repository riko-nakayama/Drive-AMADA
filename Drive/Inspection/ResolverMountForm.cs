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
    public partial class ResolverMountForm : Form
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

        public bool ButtonEnabled
        {
            set
            {
                if (value)
                {
                    BtnServoON.ForeColor = Color.Navy;
                    BtnServoOFF.ForeColor = Color.Navy;
                    BtnBreakON.ForeColor = Color.Navy;
                    BtnBreakOFF.ForeColor = Color.Navy;
                    BtnZeroLock.ForeColor = Color.Navy;
                    BtnCW.ForeColor = Color.Navy;
                    BtnCCW.ForeColor = Color.Navy;
                    BtnRotate.ForeColor = Color.Navy;
                    BtnAlarmReset.ForeColor = Color.Navy;
                }
                else
                {
                    BtnServoON.ForeColor = Color.DarkGray;
                    BtnServoOFF.ForeColor = Color.DarkGray;
                    BtnBreakON.ForeColor = Color.DarkGray;
                    BtnBreakOFF.ForeColor = Color.DarkGray;
                    BtnZeroLock.ForeColor = Color.DarkGray;
                    BtnCW.ForeColor = Color.DarkGray;
                    BtnCCW.ForeColor = Color.DarkGray;
                    BtnRotate.ForeColor = Color.DarkGray;
                    BtnAlarmReset.ForeColor = Color.DarkGray;
                }

                BtnServoON.Enabled = value;
                BtnServoOFF.Enabled = value;
                BtnBreakON.Enabled = value;
                BtnBreakOFF.Enabled = value;
                BtnZeroLock.Enabled = value;
                BtnCW.Enabled = value;
                BtnCCW.Enabled = value;
                BtnRotate.Enabled = value;
                BtnAlarmReset.Enabled = value;
            }

            get { return BtnServoON.Enabled; }
        }

        #endregion

        #region 定数

        private enum MotorAction { CW, CCW, InPos, None };

        #endregion

        #region 変数

        static private Point FormPosition = new Point(0, 0);

        private MainForm mform;
        private ViewMainForm vform;

        private int ResizeHeight = new int();
        private int ResizeWidth = new int();

        static private ResolverMountForm _ThisForm;
        private bool _IsCollapseLayout = new bool();
        private bool _IsExist = new bool();
        private MdiClient ThisMdiClient;

        private MotorAction action = MotorAction.None;

        private int TargetVelocity = 0;
        private int Acceleration = 0;
        private int Deceleration = 0;
        private int RotationTime = 0;

        private bool IsCW_CCW = false;  //CW/CCW連続回転指示？

        #endregion

        #region コンストラクタ

        public ResolverMountForm(MainForm _mform, ViewMainForm _vform)
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

        static public ResolverMountForm ThisForm
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
        }

        private void InspectionForm_Shown(object sender, EventArgs e)
        {
            if (bLoadResolverMount())
            {
                if (MainForm.IsUsbConnectBlink)
                {
                    //サーボオフ
                    if (ServoControl.ServoOFF())
                    {
                        //ブレーキオフ
                        if (!BreakOFF())
                        {
                            MessageBox.Show("ブレーキオフに失敗しました。(INIT)",
                                            "ブレーキ",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("サーボオフに失敗しました。(INIT)",
                                        "サーボオフ",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("レゾルバ取付で使用する動作設定ファイルの読込みに失敗しました。",
                                "レゾルバ取付",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
           
            LblDummy.Focus();
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

        #region サーボオン 

        private void BtnServoON_Click(object sender, EventArgs e)
        {
            if (!MainForm.IsUsbConnectBlink) { return; }

            //ドライバアラームチェック
            if (CheckDriverAlarm())
            {
                //位置制御
                if (ServoControl.ControlMode(1 , true))
                {
                    if (!ServoControl.ServoON(ServoDef.WAIT_100ms))
                    {
                        MessageBox.Show("サーボＯＮに失敗しました。(BtnServoON)",
                                        "サーボＯＮ",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("位置制御モードの設定に失敗しました。(BtnServoON)",
                                    "サーボＯＮ",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("ドライバアラームクリア処理に失敗しました。(BtnServoON)",
                                "サーボＯＮ",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        #endregion

        #region サーボオフ

        private void BtnServoOFF_Click(object sender, EventArgs e)
        {
            if (!MainForm.IsUsbConnectBlink) { return; }

            if (!ServoControl.ServoOFF())
            {
                MessageBox.Show("サーボＯＦＦに失敗しました。(BtnServoOFF)",
                                "サーボＯＦＦ",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        #endregion

        #region ブレーキオン

        private void BtnBreakON_Click(object sender, EventArgs e)
        {
            if (!MainForm.IsUsbConnectBlink) { return; }

            if (!BreakON())
            {
                MessageBox.Show("ブレーキオンに失敗しました。(BtnBreakO)",
                                "ブレーキ",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private bool BreakON()
        {
            return ServoControl.BreakRelease(99);
        }

        #endregion

        #region ブレーキオフ

        private void BtnBreakOFF_Click(object sender, EventArgs e)
        {
            if (!MainForm.IsUsbConnectBlink) { return; }

            if(!BreakOFF())
            {
                MessageBox.Show("ブレーキオフに失敗しました。(BTN)",
                                "ブレーキ",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private bool BreakOFF()
        {
            return ServoControl.BreakRelease(1);
        }

        #endregion

        #region 零点ロック

        private void BtnZeroLock_Click(object sender, EventArgs e)
        {
            if (!MainForm.IsUsbConnectBlink) { return; }

            //ブレーキオフ
            if (BreakOFF())
            {
                //零点ロックモード
                if (ServoControl.ControlMode(40, true))
                {
                    //サーボオン
                    if (ServoControl.ServoON(100))
                    {
                        Thread.Sleep(2000);

                        //サーボオフ
                        if (!ServoControl.ServoOFF())
                        {
                            MessageBox.Show("サーボＯＦＦに失敗しました。(ZeroLock)",
                                            "サーボＯＦＦ",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                        }
                        //ブレーキオン
                        else if (!BreakON())
                        {
                            MessageBox.Show("ブレーキオンに失敗しました。(ZeroLock)",
                                            "ブレーキ",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        MessageBox.Show("サーボＯＮに失敗しました。(ZeroLock)",
                                        "零点ロック",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("零点ロックの設定に失敗しました。(ZeroLock)",
                                    "零点ロック",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("ブレーキオフに失敗しました。(ZeroLock)",
                                "ブレーキ",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        #endregion

        #region ＣＷ／ＣＣＷ回転

        private void BtnRotate_Click(object sender, EventArgs e)
        {
            if (!MainForm.IsUsbConnectBlink) { return; }

            if (MessageBox.Show("零点ロック後にセンサコネクタをドライバ側に繋ぎ変え、" + Environment.NewLine +
                                "ドライバの電源をＯＦＦ／ＯＮしてください。" + Environment.NewLine +
                                "ＯＮ後に”はいを”押下すると、CW/CCWに回転します。",
                                "回転確認",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                IsCW_CCW = true;
                action = MotorAction.CW;
                TimerMotorAction.Enabled = true;

                LblDummy.Focus();
            }
        }

        #endregion

        #region ＣＷ回転

    
        private void BtnCW_Click(object sender, EventArgs e)
        {
            if (!MainForm.IsUsbConnectBlink) { return; }

            if (MessageBox.Show("ＣＷに回転をします。",
                                "回転確認",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                IsCW_CCW = false;
                action = MotorAction.CW;
                TimerMotorAction.Enabled = true;
                
                LblDummy.Focus();
            }
        }

        #endregion

        #region ＣＣＷ回転

        private void BtnCCW_Click(object sender, EventArgs e)
        {
            if (!MainForm.IsUsbConnectBlink) { return; }

            if  (MessageBox.Show("ＣＣＷに回転をします。",
                                 "回転確認",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question) == DialogResult.Yes)
            {
                IsCW_CCW = false;
                action = MotorAction.CCW;
                TimerMotorAction.Enabled = true;

                LblDummy.Focus();
            }
        }

        #endregion

        #region モータ回転

        string msg = string.Empty;

        /// <summary>
        /// モータ回転制御タイマー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerMotorAction_Tick(object sender, EventArgs e)
        {
            int svsts = 0;

            switch (action)
            {
                case MotorAction.CW:

                    msg = "ＣＷ回転";
                    
                    ButtonEnabled = false;

                    if (MotorDirection(false))
                    {
                        action = MotorAction.InPos;
                    }
                    else
                    {
                        ViewMessage(msg + "に失敗しました。",
                                    msg,
                                    MessageBoxIcon.Error);
                    }

                    break;

                case MotorAction.CCW:

                    msg = "ＣＣＷ回転";

                    ButtonEnabled = false;

                    if (MotorDirection(true))
                    {
                        action = MotorAction.InPos;
                    }
                    else
                    {
                        ViewMessage(msg + "に失敗しました。",
                                    msg,
                                    MessageBoxIcon.Error);
                    }

                    break;

                case MotorAction.InPos:

                    //サーボステータス取得
                    if (CCommandTx.ReadSvNet(CParamID.ServoStatus, ref svsts))
                    {
                        //ドライバアラーム発生?
                        if ((svsts & 0x08) == 0x08)
                        {
                            if (!BreakOFF()) return;

                            if (!ServoControl.ControlMode(40, false)) return;

                            ViewMessage("回転中ドライバアラームが発生しました。",
                                        "回転異常",
                                        MessageBoxIcon.Error);

                            return;
                        }

                        //InPosition?
                        if ((svsts & 0x04) == 0x04)
                        {
                            //CW/CCW回転指示？
                            if (IsCW_CCW)
                            {
                                if (msg == "ＣＷ回転")
                                {
                                    Thread.Sleep(2000);

                                    action = MotorAction.CCW;
                                }
                                else
                                {
                                    ButtonEnabled = true;
                                    Thread.Sleep(1000);

                                    if (!BreakOFF()) return;

                                    if (!ServoControl.ServoOFF()) return;

                                    action = MotorAction.None;
                                    TimerMotorAction.Enabled = false;

                                    MessageBox.Show("ＣＷ／ＣＣＷ回転正常終了",
                                                    "回転確認",
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                ButtonEnabled = true;
                                Thread.Sleep(1000);

                                if (!BreakOFF()) return;

                                if (!ServoControl.ServoOFF()) return;

                                action = MotorAction.None;
                                TimerMotorAction.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        ViewMessage(msg + "に失敗しました。",
                                    msg,
                                    MessageBoxIcon.Error);
                    }

                    break;

                case MotorAction.None:
                    break;
            }
        }

        private void ViewMessage(string msg, string caption , MessageBoxIcon icon)
        {
            action = MotorAction.None;
            TimerMotorAction.Enabled = false;
            ButtonEnabled = true;
            
            MessageBox.Show(msg,
                            caption,
                            MessageBoxButtons.OK,
                            icon);

            if (icon == MessageBoxIcon.Information)
            {
                TimerMotorAction.Enabled = true;
            }
        }
       
        /// <summary>
        /// モータ回転
        /// </summary>
        /// <param name="ccw"></param>
        /// <returns></returns>
        private bool MotorDirection(bool ccw)
        {
            int sts = 0;

            if (!CCommandTx.ReadSvNet(CParamID.ServoStatus, ref sts)) return false;
           
            int acctime = (int)Math.Round((((float)TargetVelocity / (Acceleration * 10) * 1000)));
            int time = ((RotationTime * 1000) - acctime) / 1000;

            //目標位置
            int pos = (int)Math.Round((time * (TargetVelocity / 60f)) * 
                                      CMonitor.GetParameter(CParamID.EncderResolution));
                        
            if (ccw) pos = -pos;

            if (!ServoControl.BreakRelease(0)) return false;

            if (!ServoControl.ControlMode(1 , true)) return false;

            if(!ServoControl.ServoON(ServoDef.WAIT_100ms)) return false;

            if (!ServoControl.ProfileOperation(true, 
                                               pos, 
                                               Acceleration,
                                               Deceleration,
                                               TargetVelocity)) return false;

            Thread.Sleep(100);

            return true;
        }

        #endregion

        #region 制御モード設定

        //private bool ControlMode(int mode , bool breset)
        //{
        //    int sts =0 ;
        //    int contorlmode = 0;

        //    if (!CCommandTx.ReadSvNet(CParamID.ServoStatus, ref sts)) return false;

        //    if (!CCommandTx.ReadSvNet(CParamID.ControlMode, ref contorlmode)) return false;

        //    if (contorlmode != mode)
        //    {
        //        if (!CCommandTx.WriteSvNet(CParamID.ControlMode, mode)) return false;
        //    }

        //    if(breset)
        //        if(!AlarmReset()) return false;

        //    return true;
        //}

        #endregion

        #region サーボON

        //public bool ServoON()
        //{
        //     int cmd = 0;

        //    if (!CCommandTx.ReadSvNet(CParamID.ServoCommand, ref cmd)) return false;

        //    cmd &= ~0x0030;     //Hard Stop & Smooth Stop Clear
        //    if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) return false;

        //    cmd |= 0x0001;

        //    if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) return false;

        //    Thread.Sleep(100);

        //    return true;
        //}

        #endregion

        #region サーボOFF

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

        #region プロファイル動作

        /// <summary>
        /// <summary>
        /// プロファイル動作
        /// </summary>
        /// <param name="axis"></param>
        /// <returns></returns>
        //private bool ProfileOperation(int pos)
        //{
        //    int cmd = 0;
        //    int ctrl = 0;

        //    //位置リセット
        //    if (!PositionReset()) return false;

        //    // 加速度
        //    if (!CCommandTx.WriteSvNet(CParamID.TargetAcceleration, Acceleration)) return false;

        //    // 減速度
        //    if (!CCommandTx.WriteSvNet(CParamID.TargetDeceleration, Deceleration)) return false;

        //    // 目標位置
        //    if (!CCommandTx.WriteSvNet(CParamID.TargetPosition , pos)) return false;

        //    // 目標速度
        //    if (!CCommandTx.WriteSvNet(CParamID.TargetVelocity , TargetVelocity)) return false;

        //    if (!CCommandTx.ReadSvNet(CParamID.ServoCommand, ref cmd)) return false;
        //    if (!CCommandTx.ReadSvNet(CParamID.ControlSwitch, ref ctrl)) return false;

        //    ctrl |= 0x0002;     //Profile bit auto Clear
        //    if (!CCommandTx.WriteSvNet(CParamID.ControlSwitch, ctrl)) return false;

        //    cmd |= 0x0002;      //Profile Start bit Set
        //    cmd |= 0x0080;		//Smoothing On

        //    if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) return false;

        //    return true;
        //}

        #endregion

        #region ドライバアラームチェック
        private bool CheckDriverAlarm()
        {
            int sts = CMonitor.GetParameter(CParamID.ServoStatus);

            //ドライバアラーム検出?
            if ((sts & 0x08) == 0x08)
            {
                //アラームリセット
                if (!ServoControl.AlarmReset()) return false;

                //位置情報リセット
                if (!ServoControl.PositionReset()) return false;
            }

            return true;
        }

        #endregion

        #region 位置情報リセット

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

        #region アラームリセット
        
        private void BtnAlarmReset_Click(object sender, EventArgs e)
        {
            if (!MainForm.IsUsbConnectBlink) { return; }

            if (!ServoControl.AlarmReset())
            {
                MessageBox.Show("アラームリセットに失敗しました。(BTN)",
                                "アラームリセット",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        //private bool AlarmReset()
        //{
        //    int cmd = CMonitor.GetParameter(CParamID.ServoCommand);

        //    cmd |= 0x0008;

        //    if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) return false;

        //    Thread.Sleep(500);

        //    cmd &= ~0x0008;

        //    if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) return false;

        //    Thread.Sleep(100);

        //    return true;
        //}

        #endregion

        #region ブレーキ

        //public static bool BreakRelease(int rel)
        //{
        //    //ブレーキ強制解放過
        //    return CCommandTx.WriteSvNet(CParamID.ForcedBrakeoff, rel);
        //}

        #endregion

        #region モニタ情報

        public void SetMonitorFeedBack()
        {
            int svsts = CMonitor.GetParameter(CParamID.ServoStatus);

            if ((svsts & 0x01) == 0x01)
            {
                LblServo.Text = "サーボON";
                LblServo.EndColor = Color.Lime;
            }
            else
            {
                LblServo.Text = "サーボOFF";
                LblServo.EndColor = Color.White;
            }

            if ((svsts & 0x10000) == 0x10000)
            {
                LblBreak.Text = "ブレーキOFF";
                LblBreak.EndColor = Color.White;
            }
            else
            {
                LblBreak.Text = "ブレーキON";
                LblBreak.EndColor = Color.Red;
            }
        }

        #endregion

        #region モータ回転情報設定

        private void NumTargetVelocity_ValueChanged(object sender, EventArgs e)
        {
            TargetVelocity = (int )NumTargetVelocity.Value;
        }

        private void NumAcceleration_ValueChanged(object sender, EventArgs e)
        {
            Acceleration = (int)NumAcceleration.Value;
        }

        private void NumDeceleration_ValueChanged(object sender, EventArgs e)
        {
            Deceleration = (int)NumDeceleration.Value;
        }

        private void NumRotationTime_ValueChanged(object sender, EventArgs e)
        {
            RotationTime = (int)NumRotationTime.Value;
        }

        #endregion

        #region モータ回転情報テキストファイル読込み

        private bool bLoadResolverMount()
        {
            try
            {
                string path = Path.Combine(Application.StartupPath, "Config");

                path = Path.Combine(path, "Resolver_mount.txt");

                using (StreamReader file = new StreamReader(path ,Encoding.Default))
                {
                    string strbuff = file.ReadToEnd();

                    string work = strbuff.Replace("\r\n", " ");

                    char[] del = { ' ', '=' };
                    string[] buf = work.Split(del);

                    if (buf.Length != 8) return false;

                    if (!int.TryParse(buf[1], out TargetVelocity)) return false;
                    if (!int.TryParse(buf[3], out Acceleration)) return false;
                    if (!int.TryParse(buf[5], out Deceleration)) return false;
                    if (!int.TryParse(buf[7], out RotationTime)) return false;

                    NumTargetVelocity.Value = TargetVelocity;
                    NumAcceleration.Value = Acceleration;
                    NumDeceleration.Value = Deceleration;
                    NumRotationTime.Value = RotationTime;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        #endregion

    }
}
