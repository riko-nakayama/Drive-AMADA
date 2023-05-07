using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Threading;

using System.Diagnostics;
using System.IO;

using System.Globalization;


namespace Motion_Designer
{
	public partial class MainForm : Form
	{
		private JogControlForm jogForm;
		private GainControlForm gainForm;
        private frmBasicProgramOperation2 simpForm;

        private InspectionForm inspForm;    // Ver1.33 add AMADA Inspection

        private ResolverMountForm rslvForm; // Ver1.34 add 

		private PhotoSensorForm photoForm;  // Ver1.35 add 

		private VibrationTestForm vibForm;  // nakayama add amada 

		private ParameterForm prmForm;
		private DigitalOsilloForm waveForm;
		private AutoTuningForm autoForm;
		private BodeGraphForm bodeForm;

		private ViewMainForm viewForm;

		private IoMonitorForm iomonForm;
		private ServoMonitorForm svmonForm;
        private AlarmHistoryForm alrmhisForm;

		private ManualNavigatorForm mNaviForm;

		//↓↓↓ ART HIKARI Mode 20170919 Kimura add ↓↓↓
		private IoMonitorHikariForm iomonhikariForm;
		//↑↑↑ ART HIKARI Mode 20170919 Kimura add ↑↑↑

		private DebugMonitorForm[] dbgMonForm = new DebugMonitorForm[4];

		static private bool _IsUsbConnect = new bool();
		static private bool _IsUsbWait = new bool();
	
		static private MainForm mainForm = new MainForm();

		static private bool _IsCollapseLayout = new bool();

		static private bool _IsForceShutDown = new bool();

		private const int ExpandWidth = 520;
		//private const int CollapseWidth = 350;
		private const int CollapseWidth = 300;

		private int LayoutWidth = new int();

		private int ScreenHeight = new int();
		private int ScreenWidth = new int();

		private int ResizeHeight = new int();
		private int ResizeWidth = new int();

		private MdiClient ThisMdiClient;

		private AppLayout ThisLayout;

		private FormWindowState NowWindowState = FormWindowState.Normal;

		private CultureInfo _ThisCulture;

		private const int USB_RETRY_CNT = 3;

		public MainForm()
		{
			AppConst.WinodwsOS = Environment.OSVersion;

			_ThisCulture =  CultureInfo.CurrentCulture;

			SplashForm.NowLoadingText = "Now Loading ..    25%";
			SplashForm.RefreshSplash();

			InitializeComponent();

			mainForm = this;

			ThisMdiClient = this.GetMdiClient();

			IsCollapseLayout = Properties.Settings.Default.CollapseLayout;
			ThisLayout = (AppLayout)Properties.Settings.Default.ThisLayout;

			Microsoft.Win32.SystemEvents.PowerModeChanged += 
				new Microsoft.Win32.PowerModeChangedEventHandler(SystemEvents_PowerModeChanged);	//20161031 add

			//20161102 add 一時解除用パスワードをロック
			Properties.Settings.Default.PASSWORD_TEMP = false;

			//Properties.Settings.Default.PASSWORD_HIKARI = ArtHikariInfo.Enabled;
		
		}

		//20161031 add
		private void SystemEvents_PowerModeChanged(object sender, Microsoft.Win32.PowerModeChangedEventArgs e)
		{
			try
			{
				//----------------------
				// 現在時刻を取得
				//----------------------
				String sysdate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

				//----------------------
				// 電源状態を画面に表示
				//----------------------
				switch (e.Mode)
				{
					case Microsoft.Win32.PowerModes.Suspend:
						DisConnectUsb();
						//richTextBox1.Text += sysdate + " サスペンドされました。" + Environment.NewLine;
						break;
					case Microsoft.Win32.PowerModes.Resume:
						//richTextBox1.Text += sysdate + " レジュームされました。" + Environment.NewLine;
						break;
				}
			}
			catch
			{

			}
		}

        // ↓↓↓ Ver1.33 add AMADA Inspection
        public bool ControlMainFormEnabled
        {
            set
            {
                menuStripMain.Enabled = value;
                tbtnJogControl.Enabled = value;
                tbtnAutoTuning.Enabled = value;
                tbtnProgram.Enabled = value;

				// Ver1.35 update ↓↓↓
				tbtnInspection.Enabled = value;
				tbtnResolverMount.Enabled = value;
				tbtnPhotoSensor.Enabled = value;
				// Ver1.35 update ↑↑↑
			}
		}
        // ↑↑↑ Ver1.33 add AMADA Inspection

		public MdiClient GetMdiClient()
		{
			foreach (System.Windows.Forms.Control c in this.Controls)
			{
				if (c is System.Windows.Forms.MdiClient)
				{
					return (System.Windows.Forms.MdiClient)c;
				}
			}

			return null;
		}

		public bool IsCollapseLayout
		{
			set
			{
				_IsCollapseLayout = value;

				if (_IsCollapseLayout)
				{
					LayoutWidth = CollapseWidth;
				}
				else
				{
					LayoutWidth = ExpandWidth;
				}

				Properties.Settings.Default.CollapseLayout = _IsCollapseLayout;
			}

			get { return _IsCollapseLayout; }
		}

		#region Static Property

		static public bool IsUsbConnectBlink
		{
			get
			{
				if (IsUsbConnect)
				{
					return true;
				}
				else
				{
					mainForm.TimerBlink.Interval = 100;
					mainForm.TimerBlink.Enabled = true;
					mainForm.BlinkCount = 0;

					return false;
				}
			}
		}

		static public bool IsUsbConnect
		{
			set { _IsUsbConnect = value; }
			get { return _IsUsbConnect; }
		}

		static public bool IsUsbWait
		{
			set { _IsUsbWait = value; }
			get { return _IsUsbWait; }
		}

		static public bool EnableMainTimer
		{
			set
			{
				mainForm.TimerMain.Enabled = value;
			}
		}

		static public bool IsReadLogOk
		{
			set { _IsReadLogOk = value; }
			get { return _IsReadLogOk; }
		}

		static public MainForm ThisForm
		{
			get { return mainForm; }
		}

		static public void CallCloseUsb()
		{
			IsUsbConnect = false;

			mainForm.lblUsb.Text = UserText.MainUSBDetach;

			mainForm.TimerWarning.Enabled = false;

			mainForm.lblUsb.BackColor = SystemColors.Control;
			mainForm.lblModel.BackColor = SystemColors.Control;
			mainForm.lblRevision.BackColor = SystemColors.Control;
			mainForm.lblSerial.BackColor = SystemColors.Control;

			mainForm.lblAlarm.BackColor = SystemColors.Control;
			mainForm.lblServoOn.BackColor = SystemColors.Control;

			mainForm.CloseUsb();
		}

		static public bool IsForceShutDown
		{
			set { _IsForceShutDown = value; }
			get { return _IsForceShutDown; }
		}

		static public int DriverModel
		{
			get { return _DriverModel; }
		}

		static public int DriverRevision
		{
			get { return _DriverRevision; }
		}

		public enum CPU_TYP { STM32F, RZT1 }

		static public CPU_TYP DriverCPU
		{
			get
			{
                //20220106 Ver1.31 Update ↓ 
                if (DriverModel == 8830 ||
                    DriverModel == 8850 ||
                    DriverModel == 5048)
				{
					return CPU_TYP.RZT1;
				}
				else
				{
					return CPU_TYP.STM32F;
				}
                //20220106 Ver1.31 Update ↑ 
			}
		}

		public bool EnableTimerMain
		{
			set { TimerMain.Enabled = value; }
		}

		#endregion

		#region Form Event

		private void MainForm_Load(object sender, EventArgs e)
		{			
			this.Opacity = 0.0;

            // TAD8821 Mode 20220921 Kimura add 
            if (Properties.Settings.Default.PASSWORD_TAD8821)
            {
                tbtnAutoTuning.Enabled = false;
                ToolStripMenuItemUpgrade.Enabled = false;
            }

            // Ver1.33 add
            tbtnInspection.Visible = Properties.Settings.Default.PASSWORD_AMADATEST; 

            //Ver1.34 add
            tbtnResolverMount.Visible = Properties.Settings.Default.PASSWORD_AMADATEST;

			//Ver1.35 add
			tbtnPhotoSensor.Visible = Properties.Settings.Default.PASSWORD_AMADATEST;
		}

		private void MainForm_Shown(object sender, EventArgs e)
		{
			//ディスプレイの高さ
			ScreenHeight = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
	
			//ディスプレイの幅
			ScreenWidth = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;

			this.Location = new Point(0, 0);

			this.Width = LayoutWidth;
			this.Height = ScreenHeight;

			this.Refresh();

			autoForm = new AutoTuningForm();
			autoForm.MdiParent = this;
			autoForm.IsCollapseLayout = IsCollapseLayout;

			jogForm = new JogControlForm();
			jogForm.MdiParent = this;
			jogForm.IsCollapseLayout = IsCollapseLayout;

            simpForm = new frmBasicProgramOperation2();
            simpForm.MdiParent = this;
            simpForm.IsCollapseLayout = IsCollapseLayout;

			while (jogForm == null) { }

			SplashForm.NowLoadingText = "Now Loading ...   50%";
			SplashForm.RefreshSplash();

			viewForm = new ViewMainForm();
			viewForm.Opacity = 0.0;
			viewForm.Show();
			viewForm.Location = new Point(LayoutWidth, 0);
			viewForm.Height = ScreenHeight;
			viewForm.Width = ScreenWidth - LayoutWidth;

            // ↓↓↓ Ver1.33 add AMADA Inspection
            if (Properties.Settings.Default.PASSWORD_AMADATEST)
            {
                inspForm = new InspectionForm(this , viewForm);
                inspForm.MdiParent = this;
                inspForm.IsCollapseLayout = IsCollapseLayout;

                // ↓↓↓ Ver1.34 add
                rslvForm = new ResolverMountForm(this, viewForm);
                rslvForm.MdiParent = this;
                rslvForm.IsCollapseLayout = IsCollapseLayout;
				// ↑↑↑ Ver1.34 add

				// ↓↓↓ Ver1.35 add
				photoForm = new PhotoSensorForm(this, viewForm);
				photoForm.MdiParent = this;
				photoForm.IsCollapseLayout = IsCollapseLayout;
				// ↑↑↑ Ver1.35 add
			}
            // ↑↑↑ Ver1.33 add AMADA Inspection

			prmForm = new ParameterForm(SV_NET_DEVICE_TYPE.DRIVER);
			prmForm.MdiParent = viewForm;

			gainForm = new GainControlForm();
			gainForm.MdiParent = viewForm;

			while (gainForm == null) { }
		
			SplashForm.NowLoadingText = "Now Loading ....  75%";
			SplashForm.RefreshSplash();

			bodeForm = new BodeGraphForm();
			bodeForm.MdiParent = viewForm;

			waveForm = new DigitalOsilloForm();
			waveForm.MdiParent = viewForm;

			while (waveForm == null) { }
			
			SplashForm.NowLoadingText = "Now Loading ..... 100%";
			SplashForm.RefreshSplash();

			TimerInit.Interval = 50;
			TimerInit.Enabled = true;

		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			//20161108 add
			if (simpForm != null)
			{
				if (simpForm.IsProgramExec)
				{
					e.Cancel = true;
					return;
				}
			}

			if (autoForm != null)
			{
				if (autoForm.IsTuning)
				{
					DialogResult ret = UserMessageBox.AutoTuningExecAutoTuning();

					if (ret == DialogResult.Yes)
					{
						autoForm.StopAutoTuning();
					}
					else
					{
						e.Cancel = true;
						return;
					}
				}
			}

			if (IsUsbConnect)
			{
				int sts = CMonitor.GetParameter(CParamID.ServoStatus);

				if ((sts & 0x01) == 0x01)		//サーボオンなら終了時、注意メッセージ
				{
					if (DialogResult.Yes == UserMessageBox.MainServoOnWarning2())
					{
						ServoOffCommand();
					}
				}
			}

			if (!IsForceShutDown)
			{
				this.Opacity = 0.0;
				viewForm.Opacity = 0.0;

				ChildFormControl.SetOpacity(0.0);

				//ret = UserMessageBox.ViewMainDriveClose();
	
				if (Properties.Settings.Default.CLOSE_MSG_DISABLE == false)
				{
					DriveCloseDialog f = new DriveCloseDialog();

					DialogResult ret = f.ShowDialog();

					if (ret == DialogResult.Cancel)
					{
						e.Cancel = true;

						this.Opacity = 1.0;
						viewForm.Opacity = 1.0;

						ChildFormControl.SetOpacity(1.0);

						return;
					}
				}
			}
		
			IsForceShutDown = false;

			Properties.Settings.Default.ThisLayout = (int)ThisLayout;

			Properties.Settings.Default.Save();

			CloseUsb();

			Microsoft.Win32.SystemEvents.PowerModeChanged -=
				new Microsoft.Win32.PowerModeChangedEventHandler(SystemEvents_PowerModeChanged);	//20161031 add

		}

		private void MainForm_ResizeEnd(object sender, EventArgs e)
		{
			int w = ThisMdiClient.ClientRectangle.Width;
			int h = ThisMdiClient.ClientRectangle.Height;

			ResizeWidth = w;
			ResizeHeight = h;

			//LoadJogControl();
			//LoadAutoTuning();

			if (jogForm != null)
			{
				jogForm.Location = new Point(0, 0);
				jogForm.Size = new Size(w, h);
				jogForm.WindowState = FormWindowState.Normal;
			}

			if (autoForm != null)
			{
				autoForm.Location = new Point(0, 0);
				autoForm.Size = new Size(w, h);
				autoForm.WindowState = FormWindowState.Normal;
			}

            if (simpForm != null)
            {
                simpForm.Location = new Point(0, 0);
                simpForm.Size = new Size(w, h);
                simpForm.WindowState = FormWindowState.Normal;
            }

            // ↓↓↓ Ver1.33 add AMADA Inspection
            if (inspForm != null)
            {
                inspForm.Location = new Point(0, 0);
                inspForm.Size = new Size(w, h);
                inspForm.WindowState = FormWindowState.Normal;
            }
            // ↑↑↑ Ver1.33 add AMADA Inspection

            // ↓↓↓ Ver1.34 add
            if (rslvForm != null)
            {
                rslvForm.Location = new Point(0, 0);
                rslvForm.Size = new Size(w, h);
                rslvForm.WindowState = FormWindowState.Normal;
            }
			// ↑↑↑ Ver1.34 add

			// ↓↓↓ Ver1.35 add
			if (photoForm != null)
			{
				photoForm.Location = new Point(0, 0);
				photoForm.Size = new Size(w, h);
				photoForm.WindowState = FormWindowState.Normal;
			}
			// ↑↑↑ Ver1.35 add

			// nakayama add amada
			if (vibForm != null)
			{
				vibForm.Location = new Point(0, 0);
				vibForm.Size = new Size(w, h);
				vibForm.WindowState = FormWindowState.Normal;
			}

			TimerResize.Enabled = true;
			
		}

		private void MainForm_SizeChanged(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Maximized)
			{
				NowWindowState = FormWindowState.Maximized;

				MainForm_ResizeEnd(null, null);
			}
			else
			{
				if (NowWindowState == FormWindowState.Maximized)
				{
					NowWindowState = FormWindowState.Normal;

					MainForm_ResizeEnd(null, null);
				}
			}
		}

		#endregion

		#region USB Event

		private int UsbRetryCnt = new int();

		private bool OpenUsb()
		{
			if (CUsb.InitCUsb())
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private void CloseUsb()
		{
			CUsb.UnInitCUsb();
		}

		private void DisConnectUsb()
		{
			if (IsUsbConnect)
			{
				IsUsbConnect = false;
				
				lblUsb.Text = UserText.MainUSBDetach;

				TimerWarning.Enabled = false;
				
				lblUsb.BackColor = SystemColors.Control;
				lblModel.BackColor = SystemColors.Control;
				lblRevision.BackColor = SystemColors.Control;
				lblSerial.BackColor = SystemColors.Control;

				lblAlarm.BackColor = SystemColors.Control;
				lblServoOn.BackColor = SystemColors.Control;

				MonitorReady = false;
				MonitorSq = 0;

				CloseUsb();
			}
		}

		private void RetryUsb()
		{
			UsbRetryCnt++;

			IsUsbWait = true;

			#if DEBUG
			Debug.WriteLine("*** RETRY COMMAND USB ***");
			#endif

			TimerMain.Enabled = false;

			if (UsbRetryCnt > USB_RETRY_CNT)
			{
				DisConnectUsb();						//devconExecの前に実行すること

				CUsb.StartSerchCDC();					//20170201 add

				if( CUsb.IsCDCConnect)					//20170201 add デバイスマネージャーで認識しているのにUSB通信エラーの場合はDevConで再接続処理。
				{
					try
					{
						//ノイズによりWindowsがUSB（COM）デバイスを切り離している状態かもしれない。
						//デバイスマネージャーに認識しているのにUSBにアクセス出来ない。
						//devcon.exeでデバイスを直接操作（再接続処理）する。

						CUsb.devconExec(false);			//デバイスの無効

						CUsb.devconExec(true);			//デバイスの有効

						#if DEBUG
						Debug.WriteLine("$$$ DEVCON_RETRY $$$");
						#endif
					}
					catch
					{

					}
				}

				IsUsbWait = false;

			}
			else
			{
				byte[] buf = new byte[64];

				CCommandTx.RequestCommandCode('S', buf);
			}

			TimerMain.Enabled = true;

		}

		private void ClearUsbError()
		{
			UsbRetryCnt = 0;
			IsUsbWait = false;
		}

		#endregion

		#region Timer Event

		private int  MonitorSq = new int();
		private bool MonitorReady = new bool();

		static private bool _IsReadLogOk = true;

		private FFT_IF FFT_Ctrl = new FFT_IF();

		private int[] SvBuf = new int[256];
		private int[] LogBuf = new int[8192];
		private int[] WaveBuf = new int[100000];

		static private int _DriverModel = new int();
		static private int _DriverRevision = new int();

		private void TimerMain_Tick(object sender, EventArgs e)
		{
            if (!jogForm.IsExist && !autoForm.IsExist && !simpForm.IsExist) { pnlMain.Visible = true; }

			if (!prmForm.IsExist && !gainForm.IsExist && !waveForm.IsExist && !bodeForm.IsExist) { viewForm.VisibleWorkspaceLog = true; }
			
			if( viewForm != null )
			{
				if (svmonForm != null) { viewForm.VisibleServoMonitor = svmonForm.IsExist; }
				if (iomonForm != null) { viewForm.VisibleIoMonitor = iomonForm.IsExist; }
			}

			if( IsInitWait )
			{
				IsInitWait = false;

				mainForm.Opacity = 1.0;
				viewForm.Opacity = 1.0;
			}

			if (!IsUsbConnect)
			{
				MonitorReady = false;		//20161102 update

				if (OpenUsb())
				{
					if (TimerBlink.Enabled) { TimerBlink.Enabled = false; }

					byte[] buf = new byte[64];

					CCommandTx.RequestCommandCode('S', buf);
	
					IsUsbConnect = true;
					lblUsb.Text = UserText.MainUSBAttach;
					lblUsb.BackColor = Color.LightGreen;
					lblModel.BackColor = Color.LightYellow;
					lblRevision.BackColor = Color.LightYellow;
					lblSerial.BackColor = Color.LightYellow;
					Thread.Sleep(500);
				}
				else
				{
					DisConnectUsb();
					return;
				}
			}
			else
			{

				if (++MonitorSq > 1) { MonitorSq = 0; MonitorReady = true; }

				switch (MonitorSq)
				{
					case 0:

						if (!CCommandTx.ReadSvNetAll(MonitorSq, ref SvBuf))
						{
							#if DEBUG
							Debug.WriteLine("!!! READ SV-NET1 ERROR !!!");
							#endif

							RetryUsb();
							return;
						}
						else
						{
							#if DEBUG
							Debug.WriteLine("<<< READ SV-NET1 >>>");
							#endif

							CMonitor.SetParameter(MonitorSq, SvBuf);
							ClearUsbError();
						}

						break;

					case 1:

						if (!CCommandTx.ReadSvNetAll(MonitorSq, ref SvBuf))
						{
							#if DEBUG
							Debug.WriteLine("!!! READ SV-NET2 ERROR !!!");
							#endif

							RetryUsb();
							return;
						}
						else
						{
							#if DEBUG
							Debug.WriteLine("<<< READ SV-NET2 >>>");
							#endif

							CMonitor.SetParameter(MonitorSq, SvBuf);
							ClearUsbError();
						}

						break;
				
				}

				if (MonitorReady == false) { return; }

                /* ----- TI debug 
				if (LogWork.LogPeriod != CMonitor.GetParameter(CParamID.LogPeriod))
				{
					CCommandTx.WriteSvNet(CParamID.LogPeriod, LogWork.LogPeriod);
				}
                */

				_DriverModel = CMonitor.GetParameter(CParamID.ModelNo);
				_DriverRevision = CMonitor.GetParameter(CParamID.Revision);

                //↓↓↓ KASHIYAMA Mode 20190624 Kimura update ↓↓↓
                if (Properties.Settings.Default.PASSWORD_KASHIYAMA == false)
                {
                    lblModel.Text = "TAD" + CMonitor.GetParameter(CParamID.ModelNo).ToString();
                }
                else
                {
                    //KASHIYAMA Modeの場合は、１６進数表記
                    lblModel.Text = "TAD" + CMonitor.GetParameter(CParamID.ModelNo).ToString("X");
                }
                //↑↑↑ KASHIYAMA Mode 20190624 Kimura update ↑↑↑
                
                lblRevision.Text = "Rev. " + CMonitor.GetParameter(CParamID.Revision).ToString();
				lblSerial.Text   = "S/N "  + CMonitor.GetParameter(CParamID.Serial).ToString("D5");

				int  sts = CMonitor.GetParameter(CParamID.ServoStatus);
				bool err = new bool();

				if ((sts & 0x08) == 0x08)
				{
					err = true;
				}
				else
				{
					if ((sts & 0xF0) != 0)
					{
						err = true;
					}
					else
					{
						lblAlarm.Text = UserText.MainReady;
						lblAlarm.BackColor = Color.LightCyan;
					}
				}

				if ((sts & 0x01) == 0x01)
				{
					lblServoOn.Text = UserText.MainServoOn;
					lblServoOn.BackColor = Color.Gold;
				}
				else
				{
					lblServoOn.Text = UserText.MainServoOff;
					lblServoOn.BackColor = Color.LightCyan;
				}

				if (err)
				{
					TimerWarning.Interval = 500;
					TimerWarning.Enabled = true;

                    if (simpForm.Visible) { simpForm.ResetProgrameStart(); }
				}
				else
				{
					TimerWarning.Enabled = false;
				}

				if (svmonForm != null)
				{
					if (svmonForm.EnableUpdate) { svmonForm.SetServoFeedBack(); }
				}

				if (iomonForm != null)
				{
					if (iomonForm.EnableUpdate) { iomonForm.SetIoFeedBack(); }
				}

				//↓↓↓ ART HIKARI Mode 20170919 Kimura add ↓↓↓
				if (iomonhikariForm != null)
				{
					if (iomonhikariForm.EnableUpdate) { iomonhikariForm.SetIoFeedBack(); }
				}
				//↑↑↑ ART HIKARI Mode 20170919 Kimura add ↑↑↑

				if (jogForm != null)
				{
					if (jogForm.EnableUpdate) { jogForm.SetJogFeedBack(); }
				}

				if (gainForm != null)
				{                    
                    if (gainForm.EnableUpdate) { gainForm.SetServoGain(); }
				}

                // ↓↓↓ Ver1.33 add AMADA Inspection
                if (inspForm != null)
                {
                    if (inspForm.EnableUpdate)
                    {
                        if (!inspForm.IsProc)
                        {
                            inspForm.LoadInspectionProc();
                        }

                        inspForm.SetMonitorFeedBack();
                    }
                }
                // ↑↑↑ Ver1.33 add AMADA Inspection

                // ↓↓↓ Ver1.34 add
                if (rslvForm != null)
                {
                    if (rslvForm.EnableUpdate)
                    {
                        rslvForm.SetMonitorFeedBack();
                    }
                }
				// ↑↑↑ Ver1.34 add

				// ↓↓↓ Ver1.35 add
				if (photoForm != null)
				{
					if ( photoForm.EnableUpdate)
					{
						photoForm.PhotoMotinProc();
					}
				}
				// ↑↑↑ Ver1.35 add

				if (CMonitor.GetParameter(CParamID.ControlMode) == 14)
				{
					//簡易コントロールモード
					tbtnAutoTuning.Enabled = false;
				}
				else
				{
                    // TAD8821 Mode 20220921 Kimura add 
                    if (!Properties.Settings.Default.PASSWORD_TAD8821)
                    {
                        // ↓↓↓ Ver1.33 add AMADA Inspection
                        if (!Properties.Settings.Default.PASSWORD_AMADATEST)
                        {
                            tbtnAutoTuning.Enabled = true;
                        }
                    }
                    // ↑↑↑ Ver1.33 add AMADA Inspection
				}

				if (autoForm != null)
				{
					if (autoForm.EnableUpdate)
					{
						if (CMonitor.GetParameter(CParamID.ControlMode) == 14)
						{
							//簡易コントロールモード
							autoForm.Visible = false; ;
						}
						else
						{
							autoForm.Visible = true;

							int rd_typ = CMonitor.GetParameter(CParamID.RDType);
							int enc_typ = CMonitor.GetParameter(CParamID.EncderType);
							int inc_cnt = CMonitor.GetParameter(CParamID.EncderResolution);

							bool update = new bool();

							if (autoForm.RDType != rd_typ) { update = true; }

							if (autoForm.EncderType != enc_typ) { update = true; }

							if (autoForm.IncCount != inc_cnt) { update = true; }

							if (update)
							{
								autoForm.RDType = rd_typ;
								autoForm.IncCount = inc_cnt;
								autoForm.EncderType = enc_typ;	//EncderTypeは最後
							}
						}
					}
				}

				if (prmForm != null)
				{
					if (prmForm.EnableUpdate && prmForm.IsAutoRefresh)
					{
						prmForm.UpdateRefreshDataDisplay(CMonitor.GetBufPtr());
					}

                    // ↓↓↓ ART HIKARI Mode 20191220 Kimura add ↓↓↓
                    if (Properties.Settings.Default.PASSWORD_HIKARI)
                    {
                        if ((CMonitor.GetParameter(CParamID.ServoStatus) & 0x01) == 0x01)
                        {
                            //サーボオン中ならパラメータ保存ボタン無効
                            prmForm.SaveButtonEnabled = false;
                        }
                        else
                        {
                            prmForm.SaveButtonEnabled = true;
                        }
                    }
                    //↑↑↑ ART HIKARI Mode 20191220 Kimura add ↑↑↑
				}

                if (!Properties.Settings.Default.PASSWORD_TAD8821) // TAD8821 Mode 20220921 Kimura add 
                {
                    if (waveForm != null)
                    {
                        if (MonitorSq == 1)
                        {
                            waveForm.UpdateLogKind();
                        }
                    }

                    for (int i = 0; i < dbgMonForm.Length; i++)		//20190315 add
                    {
                        if (dbgMonForm[i] != null)
                        {
                            dbgMonForm[i].ReadRam();
                        }
                    }

                    //20170123 del
                    //if (!AppConst.UpWinodws7)			//20161102 add Winodws7以下ならオートチューニング&オシロ&FFTは禁止
                    //{
                    //    AutoTuningForm.ThisForm.Enabled = false;
                    //    DigitalOsilloForm.ThisForm.Enabled = false;
                    //    BodeGraphForm.ThisForm.Enabled = false;
                    //    return;
                    //}

                    AutoTuningForm.ThisForm.Enabled = true;
                    DigitalOsilloForm.ThisForm.Enabled = true;
                    BodeGraphForm.ThisForm.Enabled = true;

                    int log_num = new int();
                    int log_kind = new int();
                    int wav_num = new int();
                    int buf_ptr = new int();

                    bool req_data = new bool();
                    bool is_tune = new bool();
                    bool fft_on = new bool();

					
					if (autoForm != null)
                    {
                        if (autoForm.IsTuning)
                        {
                            //オートチューニング中
                            req_data = true;
                            is_tune = true;

                            if (waveForm != null) { waveForm.HoldEnabled = false; }
                            if (bodeForm != null) { bodeForm.HoldEnabled = false; }
                        }
                        else
                        {
                            if (waveForm != null) { waveForm.HoldEnabled = true; }
                            if (bodeForm != null) { bodeForm.HoldEnabled = true; }
                        }
                    }

                    if (waveForm != null)
                    {
                        if (waveForm.EnableDrawWave)
                        {
                            //デジタルオシロが描画可能
                            req_data = true;
                        }
					}

					if (bodeForm != null)
                    {
                        log_kind = LogWork.KindNum;
                        fft_on = true;

                        if (is_tune)
                        {
                            //オートチューニング中はFFT取得
                            req_data = true;
                        }
                        else
                        {
                            if (bodeForm.IsViewHold || !bodeForm.EnableUpdate)
                            {
                                //FFT停止中またはFFTグラフ非表示
                                if (CheckTheTAD88xxVersion(500))		//通信データ量低減処理（FFT無し）はver.5.00以上 ReadLogData()が未対応。
                                {
                                    log_kind = LogWork.MonNum;
                                    fft_on = false;
                                }
                            }
                            else
                            {
                                req_data = true;
                            }
                        }
                    }

					// Ver1.35 update ↓↓↓ 
					bool bphotoFormEnableUpdate = false;

					if (photoForm != null) bphotoFormEnableUpdate = photoForm.EnableUpdate;

					//if (req_data)
					if (req_data || bphotoFormEnableUpdate) 
                    {
					// Ver1.35 update ↑ ↑↑
#if DEBUG
						Debug.WriteLine("<<< READ LOG >>>");
#endif

                        do
                        {
                            if (!CCommandTx.ReadLogData(ref LogBuf, ref log_num, fft_on))
                            {
#if DEBUG
                                Debug.WriteLine("!!! READ LOG ERROR !!!");
#endif

                                RetryUsb();
                                IsReadLogOk = false;
                                return;
                            }
                            else
                            {
                                ClearUsbError();
                            }

#if DEBUG
                            Debug.WriteLine(UserText.MainLogNum + log_num.ToString());
#endif

                            for (int i = 0; i < (log_num * log_kind); i++)
                            {
                                WaveBuf[buf_ptr] = LogBuf[i];

                                buf_ptr++;

                                if (buf_ptr >= WaveBuf.Length) { break; }
                            }

                            if (buf_ptr >= WaveBuf.Length) { break; }

                            wav_num += log_num;

                        } while (log_num >= CCommandTx.RequestLogNum);
                    }

                    if (req_data || is_tune)
                    {
                        waveForm.UpdateLogData(ref WaveBuf, wav_num, fft_on);
                    }

					//Ver1.35 add ↓↓↓
					if (bphotoFormEnableUpdate)
                    {
						if(photoForm.IsGetLog) photoForm.UpdateLogData(ref WaveBuf, wav_num, fft_on);
					}
					//Ver1.35 add ↑↑↑

					if (bodeForm != null && !is_tune && req_data)
                    {
                        if (bodeForm.EnableUpdate)
                        {
                            if (waveForm.EnableReadFFT)
                            {
                                waveForm.EnableReadFFT = false;

                                //↓↓↓ KASHIYAMA Mode 20200214 Kimura update ↓↓↓
                                if (Properties.Settings.Default.PASSWORD_KASHIYAMA == false)
                                {
                                    FFT_C.FRQ = CMonitor.GetParameter(CParamID.LogFFT_Frq);
                                }
                                //↑↑↑ KASHIYAMA Mode 20200214 Kimura update ↑↑↑

                                double[] fftIn = waveForm.GetFFT_InBuf();
                                double[] fftOut = waveForm.GetFFT_OutBuf();

                                FFT_Ctrl.CalcFFT_CS(-1, FFT_C.FFT_Ave_n, fftOut, false);
                                FFT_Ctrl.CalcFFT_AverageAdd(FFT_C.FFT_Ave_n, ref fftIn);
                                FFT_Ctrl.CalcFFT_PeekFillter(ref fftIn, ref fftIn);

                                bodeForm.ctlBodeGain.SetBodeData(0, FFT_C.Bode_n, fftIn);
                            }
                        }
                    }
                }
			}
                 
		}

		private void TimerResize_Tick(object sender, EventArgs e)
		{
			int w = ThisMdiClient.ClientRectangle.Width;
			int h = ThisMdiClient.ClientRectangle.Height;

			Form act_form = new Form();

			if (ResizeWidth != w || ResizeHeight != h)
			{
				if (jogForm != null && jogForm.WindowState != FormWindowState.Minimized)
				{
					jogForm.Location = new Point(0, 0);
					jogForm.Size = new Size(w, h);

					jogForm.WindowState = FormWindowState.Normal;
				}

				if (autoForm != null && autoForm.WindowState != FormWindowState.Minimized)
				{
					autoForm.Location = new Point(0, 0);
					autoForm.Size = new Size(w, h);

					autoForm.WindowState = FormWindowState.Normal;
				}

				if (simpForm != null && simpForm.WindowState != FormWindowState.Minimized)
				{
					simpForm.Location = new Point(0, 0);
					simpForm.Size = new Size(w, h);

					simpForm.WindowState = FormWindowState.Normal;
				}

                // ↓↓↓ Ver1.33 add AMADA
                if (Properties.Settings.Default.PASSWORD_AMADATEST)
                {
                    if (inspForm != null && inspForm.WindowState != FormWindowState.Minimized)
                    {
                        inspForm.Location = new Point(0, 0);
                        inspForm.Size = new Size(w, h);

                        inspForm.WindowState = FormWindowState.Normal;
                    }

                    // ↓↓↓ Ver1.34 add
                    if (rslvForm != null && rslvForm.WindowState != FormWindowState.Minimized)
                    {
                        rslvForm.Location = new Point(0, 0);
                        rslvForm.Size = new Size(w, h);

                        rslvForm.WindowState = FormWindowState.Normal;
                    }
                    // ↑↑↑ Ver1.34 add
                }
                // ↑↑↑ Ver1.33 add

			}

			TimerResize.Enabled = false;

		}

		private bool IsInitWait = new bool();
	
		private void TimerInit_Tick(object sender, EventArgs e)
		{
			if (SplashForm.GetOpacity() <= 0.0)
			{
				TimerInit.Enabled = false;
				TimerMain.Enabled = true;
				TimerMain.Interval = (int)Properties.Settings.Default.MainTimerInterval;

				SplashForm.CloseSplash();

                IsInitWait = true;

				//↓↓↓ ART HIKARI Mode 20170919 Kimura add ↓↓↓
				if (Properties.Settings.Default.PASSWORD_HIKARI)
				{
					ToolStripMenuItemLayout.Visible = false;

					tbtnJogControl.Visible = false;
					tbtnAutoTuning.Visible = false;
					tbtnProgram.Visible = false;

					ToolStripMenuItemServoMonitor.Visible = false;
					ToolStripMenuItemIoMonitor.Visible = false;

					tlblDummy.Visible = true;

					if (IsUsbConnect && MonitorReady == false)
					{
						return;
					}

					if (svmonForm == null)
					{
						svmonForm = new ServoMonitorForm();
						svmonForm.MdiParent = this;

						svmonForm.Show();
						svmonForm.InitFormLayout();
					}

					if (iomonhikariForm == null)
					{
						iomonhikariForm = new IoMonitorHikariForm();
						iomonhikariForm.MdiParent = this;

						iomonhikariForm.Show();
						iomonhikariForm.InitFormLayout(svmonForm.Height);
					}

					if (pnlMain.Visible) { pnlMain.Visible = false; }

					viewForm.ViewLayout = ViewMainForm.WindowLayout.Param;

					return;
				}
				//↑↑↑ ART HIKARI Mode 20170919 Kimura add ↑↑↑

				if (Properties.Settings.Default.ViewOpenDrive)
				{
					OpenDriveForm openForm = new OpenDriveForm();
					openForm.ShowDialog();

					IsCollapseLayout = OpenDriveForm.IsCollapseLayout;

					ThisLayout = OpenDriveForm.SelectLayout;
				}
				else
				{
					ThisLayout = (AppLayout)Properties.Settings.Default.ThisLayout;
				}
	
				switch (ThisLayout)
				{
					case AppLayout.Free:
						ThisLayout = AppLayout.Free;
						viewForm.ViewLayout = ViewMainForm.WindowLayout.Free;
						break;

					case AppLayout.Jog:

						JogLayout();
						break;

					case AppLayout.Parameter:

						ParameterLayout();
						break;

					case AppLayout.AutoTuning:

						AutoTuningLayout();
						break;

					case AppLayout.ManualTuning:

						ManualTuningLayout();
						break;
				}

				CollapseLayout();

				//IsInitWait = true;		
			}
			else
			{
				SplashForm.AddOpacity(-0.25);
			}
		}

		private void TimerWarning_Tick(object sender, EventArgs e)
		{
			int sts = CMonitor.GetParameter(CParamID.ServoStatus);

			if ((sts & 0x08) == 0x08)
			{
				if (lblAlarm.BackColor == SystemColors.Control)
				{
					lblAlarm.BackColor = Color.Pink;

					if (lblAlarm.Text == UserText.MainAlarmDetect)
					{
						lblAlarm.Text = UserText.MainAlarm + CMonitor.GetParameter(CParamID.AlarmCode).ToString();
					}
					else
					{
						lblAlarm.Text = UserText.MainAlarmDetect;
					}
				}
				else
				{
					lblAlarm.BackColor = SystemColors.Control;
				}
			}
			else
			{
				if ((sts & 0xF0) != 0)
				{
					if (lblAlarm.BackColor == SystemColors.Control)
					{
						lblAlarm.BackColor = Color.Gold;
					}
					else
					{
						lblAlarm.BackColor = SystemColors.Control;
					}

					if ((sts & 0x10) == 0x10)
					{
						lblAlarm.Text = UserText.MainPositiveLimit;
					}
					else if ((sts & 0x20) == 0x20)
					{
						lblAlarm.Text = UserText.MainNegativeLimit;
					}
					else if ((sts & 0x40) == 0x40)
					{
						lblAlarm.Text = UserText.MainTorqueLimit;
					}
					else if ((sts & 0x80) == 0x80)
					{
						lblAlarm.Text = UserText.MainVelocityLimit;
					}
				}
			}
		}

		private int BlinkCount = new int();

		private void TimerBlink_Tick(object sender, EventArgs e)
		{
			if (lblUsb.BackColor == SystemColors.Control)
			{
				lblUsb.BackColor = Color.Gold;
			}
			else
			{
				BlinkCount++;
				lblUsb.BackColor = SystemColors.Control;

				if (BlinkCount >= 3)
				{
					TimerBlink.Enabled = false;
				}
			}
		}

		#endregion

		#region Button Click Event

		private void btnJogControl_Click(object sender, EventArgs e)
		{
			LoadJogControl();
		}

		private void btnAutoTuning_Click(object sender, EventArgs e)
		{
			LoadAutoTuning();
		}

        private void tbtnProgram_Click(object sender, EventArgs e)
        {
            LoadSimpleControl();
        }

        // ↓↓↓ Ver1.33 add AMADA Inspection
        private void tbtnInspection_Click(object sender, EventArgs e)
        {
            LoadInspection();
        }
        // ↑↑↑ Ver1.33 add AMADA Inspection

        // ↓↓↓ Ver1.34 add
        private void tbtnResolverMount_Click(object sender, EventArgs e)
        {
            LoadResolverMount();
        }
		// ↑↑↑ Ver1.34 add

		// ↓↓↓ Ver1.35 add
		private void tbtnPhotoSensor_Click(object sender, EventArgs e)
		{
			LoadPhotoSensor();
		}
		// ↑↑↑ Ver1.35 add

		// nakayama add amada
		private void tbtnVibration_Click(object sender, EventArgs e)
		{
			LoadVibrationTest();
		}

		public void LoadJogControl()
		{
			//20171002 del
			//if (IsUsbConnect && MonitorReady == false)
			//{
			//    return;
			//}

			if (jogForm == null)
			{
				jogForm = new JogControlForm();
				jogForm.MdiParent = this;
				jogForm.IsCollapseLayout = IsCollapseLayout;
				jogForm.Show();
			}
			else if (jogForm.Visible == false)
			{
				if (jogForm.IsExist == false)
				{
					jogForm = new JogControlForm();
					jogForm.MdiParent = this;
					jogForm.IsCollapseLayout = IsCollapseLayout;
				}
				
				jogForm.Show();
				jogForm.InitFormLayout();
			
			}
			else if (jogForm.WindowState == FormWindowState.Minimized)
			{
				jogForm.WindowState = FormWindowState.Normal;
			}

			jogForm.Activate();

			if (pnlMain.Visible) { pnlMain.Visible = false; }
		}

		public void LoadAutoTuning()
		{
			if (autoForm == null)
			{
				autoForm = new AutoTuningForm();
				autoForm.MdiParent = this;
				autoForm.IsCollapseLayout = IsCollapseLayout;
				autoForm.Show();
			}
			else if (autoForm.Visible == false)
			{
				if (autoForm.IsExist == false)
				{
					autoForm = new AutoTuningForm();
					autoForm.MdiParent = this;
					autoForm.IsCollapseLayout = IsCollapseLayout;
				}
		
				autoForm.Show();
				autoForm.InitFormLayout();
			}
			else if (autoForm.WindowState == FormWindowState.Minimized)
			{
				autoForm.WindowState = FormWindowState.Normal;
			}

			autoForm.Activate();

			if (pnlMain.Visible) { pnlMain.Visible = false; }
		}

        public void LoadSimpleControl()
        {

            if (pnlMain.Visible) { pnlMain.Visible = false; }

            if (simpForm == null)
            {
                simpForm = new frmBasicProgramOperation2();
                simpForm.MdiParent = this;
                simpForm.IsCollapseLayout = IsCollapseLayout;
                simpForm.Show();
            }
            else if (simpForm.Visible == false)
            {
                if (simpForm.IsExist == false)
                {
                    simpForm = new frmBasicProgramOperation2();
                    simpForm.MdiParent = this;
                    simpForm.IsCollapseLayout = IsCollapseLayout;
                }

                simpForm.Show();
                simpForm.InitFormLayout();
            }
            else if (simpForm.WindowState == FormWindowState.Minimized)
            {
                simpForm.WindowState = FormWindowState.Normal;
            }

            simpForm.Activate();
        }

		public void LoadGainControl()
		{
			if (gainForm == null)
			{
				gainForm = new GainControlForm();
				gainForm.MdiParent = viewForm;
				gainForm.Show();
			}
			else if (gainForm.Visible == false)
			{
				if (gainForm.IsExist == false)
				{
					gainForm = new GainControlForm();
					gainForm.MdiParent = viewForm;
				}

				gainForm.Show();
				gainForm.InitFormLayout();
			}
			else if (gainForm.WindowState == FormWindowState.Minimized)
			{
				gainForm.WindowState = FormWindowState.Normal;
			}

			gainForm.Activate();

			if (viewForm.VisibleWorkspaceLog) { viewForm.VisibleWorkspaceLog = false; }
		}

		public void LoadParameterForm()
		{
			if (prmForm == null)
			{
				prmForm = new ParameterForm(SV_NET_DEVICE_TYPE.DRIVER);
				prmForm.MdiParent = viewForm;
				prmForm.Show();
			}
			else if (prmForm.Visible == false)
			{
				if (prmForm.IsExist == false)
				{
					prmForm = new ParameterForm(SV_NET_DEVICE_TYPE.DRIVER);
					prmForm.MdiParent = viewForm;
				}
				
				prmForm.Show();
				prmForm.InitFormLayout();
			}
			else if (prmForm.WindowState == FormWindowState.Minimized)
			{
				prmForm.WindowState = FormWindowState.Normal;
			}

			prmForm.Activate();

			if (viewForm.VisibleWorkspaceLog) { viewForm.VisibleWorkspaceLog = false; }
		}

		public void LoadDigitalOsillo()
		{		
			if (waveForm == null)
			{
				waveForm = new DigitalOsilloForm();
				waveForm.MdiParent = viewForm;
				waveForm.Show();
			}
			else if (waveForm.Visible == false)
			{
				if (waveForm.IsExist == false)
				{
					waveForm = new DigitalOsilloForm();
					waveForm.MdiParent = viewForm;
				}

				waveForm.Show();
				waveForm.InitFormLayout();
			}
			else if (waveForm.WindowState == FormWindowState.Minimized)
			{
				waveForm.WindowState = FormWindowState.Normal;
			}

			waveForm.Activate();

			if (viewForm.VisibleWorkspaceLog) { viewForm.VisibleWorkspaceLog = false; }
		}

		public void LoadBodeGraph()
		{
			if (bodeForm == null)
			{
				bodeForm = new BodeGraphForm();
				bodeForm.MdiParent = viewForm;
				bodeForm.Show();
			}
			else if (bodeForm.Visible == false)
			{
				if (bodeForm.IsExist == false)
				{
					bodeForm = new BodeGraphForm();
					bodeForm.MdiParent = viewForm;
				}
				
				bodeForm.Show();
				bodeForm.InitFormLayout();
			}
			else if (bodeForm.WindowState == FormWindowState.Minimized)
			{
				bodeForm.WindowState = FormWindowState.Normal;
			}

			bodeForm.Activate();

			if (viewForm.VisibleWorkspaceLog) { viewForm.VisibleWorkspaceLog = false; }

		}

        // ↓↓↓ Ver1.33 add AMADA Inspection
        public void LoadInspection()
        {
            if (inspForm == null)
            {
                inspForm = new InspectionForm(this , viewForm);
                inspForm.MdiParent = this;
                inspForm.IsCollapseLayout = IsCollapseLayout;
                inspForm.Show();
            }
            else if (inspForm.Visible == false)
            {
                if (inspForm.IsExist == false)
                {
                    inspForm = new InspectionForm(this , viewForm);
                    inspForm.MdiParent = this;
                    inspForm.IsCollapseLayout = IsCollapseLayout;
                }

                inspForm.Show();
                inspForm.InitFormLayout();
            }
            else if (inspForm.WindowState == FormWindowState.Minimized)
            {
                inspForm.WindowState = FormWindowState.Normal;
            }

            inspForm.Activate();

            if (pnlMain.Visible) { pnlMain.Visible = false; }
        }
        // ↑↑↑ Ver1.33 add AMADA Inspection

        // ↓↓↓ Ver1.34 add
        public void LoadResolverMount()
        {
            if (rslvForm == null)
            {
                rslvForm = new ResolverMountForm(this, viewForm);
                rslvForm.MdiParent = this;
                rslvForm.IsCollapseLayout = IsCollapseLayout;
                rslvForm.Show();
            }
            else if (rslvForm.Visible == false)
            {
                if (rslvForm.IsExist == false)
                {
                    rslvForm = new ResolverMountForm(this, viewForm);
                    rslvForm.MdiParent = this;
                    rslvForm.IsCollapseLayout = IsCollapseLayout;
                }

                rslvForm.Show();
                rslvForm.InitFormLayout();
            }
            else if (rslvForm.WindowState == FormWindowState.Minimized)
            {
                rslvForm.WindowState = FormWindowState.Normal;
            }

            rslvForm.Activate();

            if (pnlMain.Visible) { pnlMain.Visible = false; }
        }
		// ↑↑↑ Ver1.34 add

		// ↓↓↓ Ver1.35 add
		public void LoadPhotoSensor()
		{
			if (photoForm == null)
			{
				photoForm = new PhotoSensorForm(this, viewForm);
				photoForm.MdiParent = this;
				photoForm.IsCollapseLayout = IsCollapseLayout;
				photoForm.Show();
			}
			else if (photoForm.Visible == false)
			{
				if (photoForm.IsExist == false)
				{
					photoForm = new PhotoSensorForm(this, viewForm);
					photoForm.MdiParent = this;
					photoForm.IsCollapseLayout = IsCollapseLayout;
				}

				photoForm.Show();
				photoForm.InitFormLayout();
			}
			else if (photoForm.WindowState == FormWindowState.Minimized)
			{
				photoForm.WindowState = FormWindowState.Normal;
			}

			photoForm.Activate();

			if (pnlMain.Visible) { pnlMain.Visible = false; }

		}
		// ↑↑↑ Ver1.35 add

		// nakayama add amada
		public void LoadVibrationTest()
		{

			if (vibForm == null)
			{
				vibForm = new VibrationTestForm(this, viewForm);
				vibForm.MdiParent = this;
				vibForm.IsCollapseLayout = IsCollapseLayout;
				vibForm.Show();
			}
			else if (vibForm.Visible == false)
			{
				if (vibForm.IsExist == false)
				{
					vibForm = new VibrationTestForm(this, viewForm);
					vibForm.MdiParent = this;
					vibForm.IsCollapseLayout = IsCollapseLayout;
				}

				vibForm.Show();
				vibForm.InitFormLayout();
			}
			else if (vibForm.WindowState == FormWindowState.Minimized)
			{
				vibForm.WindowState = FormWindowState.Normal;
			}

			vibForm.Activate();

			if (pnlMain.Visible) { pnlMain.Visible = false; }
		}

		public void ViewFormClose()
		{
			prmForm.Close();
			waveForm.Close();
			bodeForm.Close();
			gainForm.Close();

			prmForm.IsExist = false;
			waveForm.IsExist = false;
			bodeForm.IsExist = false;
			gainForm.IsExist = false;

		}

		#endregion

		#region Toolbar Event

		private void ToolStripMenuItemEnd_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void ToolStripMenuItemInitLayout_Click(object sender, EventArgs e)
		{
			InitWorkSapce(this);
		}

		private void ToolStripMenuItemCollapseLayout_Click(object sender, EventArgs e)
		{
			if (ToolStripMenuItemCollapseLayout.Checked)
			{
				IsCollapseLayout = true;
			}
			else
			{
				IsCollapseLayout = false;
			}

			CollapseLayout();
		}
		
		private void ToolStripMenuItemLayout_DropDownOpening(object sender, EventArgs e)
		{
			if (IsCollapseLayout)
			{
				ToolStripMenuItemCollapseLayout.Checked = true;
			}
			else
			{
				ToolStripMenuItemCollapseLayout.Checked = false;
			}

			if (Properties.Settings.Default.ViewOpenDrive)
			{
				ToolStripMenuItemStart.Checked = true;
			}
			else
			{
				ToolStripMenuItemStart.Checked = false;
			}

			ToolStripMenuItemFree.Checked = false;
			ToolStripMenuItemJog.Checked = false;
			ToolStripMenuItemParameter.Checked = false;
			ToolStripMenuItemAutoTuning.Checked = false;
			ToolStripMenuItemGain.Checked = false;

			switch (ThisLayout)
			{
				case AppLayout.Free:

					ToolStripMenuItemFree.Checked = true;
					break;

				case AppLayout.Jog:

					ToolStripMenuItemJog.Checked = true;
					break;

				case AppLayout.Parameter:

					ToolStripMenuItemParameter.Checked = true;
					break;

				case AppLayout.AutoTuning:

					ToolStripMenuItemAutoTuning.Checked = true;
					break;

				case AppLayout.ManualTuning:

					ToolStripMenuItemGain.Checked = true;
					break;
			}

			if (viewForm.Visible)
			{
				ToolStripMenuItemViewWorkspace2.Checked = true;
			}
			else
			{
				ToolStripMenuItemViewWorkspace2.Checked = false;
			}

		}

		private void ToolStripMenuItemView_DropDownOpening(object sender, EventArgs e)
		{
			if (viewForm.Visible)
			{
				ToolStripMenuItemViewWorkspace.Checked = true;
			}
			else
			{
				ToolStripMenuItemViewWorkspace.Checked = false;
			}
			
		}

		private void ToolStripMenuItemViewWorkspace_Click(object sender, EventArgs e)
		{
			if (ToolStripMenuItemViewWorkspace.Checked || ToolStripMenuItemViewWorkspace2.Checked)
			{
				ViewMainForm.IsForceShutDown = true;
				viewForm.Close();
			}
			else
			{
				if (viewForm == null)
				{
					viewForm = new ViewMainForm();
					viewForm.Show();
				}
				else if (viewForm.Visible == false)
				{

					viewForm = new ViewMainForm();
					viewForm.Show();
				}
				else if (viewForm.WindowState == FormWindowState.Minimized)
				{
					viewForm.WindowState = FormWindowState.Normal;
				}

				viewForm.Width = ScreenWidth - LayoutWidth;
				viewForm.Height = ScreenHeight;
				viewForm.Location = new Point(LayoutWidth, 0);

				viewForm.Activate();

			}
		}

		private void ToolStripMenuItemUpgrade_Click(object sender, EventArgs e)
		{
		
			FirmwareUpgradeDialog dfuForm = new FirmwareUpgradeDialog();

			int sts = CMonitor.GetParameter(CParamID.ServoStatus);

			if ((sts & 0x01) == 0x01)
			{
				UserMessageBox.MainServoOnWarning();
				return;
			}
	
			dfuForm.ShowDialog();
		}

		private void ToolStripMenuItemFree_Click(object sender, EventArgs e)
		{
			FreeLayout();
		}

		private void ToolStripMenuItemJog_Click(object sender, EventArgs e)
		{
			JogLayout();
		}

		private void ToolStripMenuItemParameter_Click(object sender, EventArgs e)
		{
			ParameterLayout();
		}

		private void ToolStripMenuItemGain_Click(object sender, EventArgs e)
		{
			ManualTuningLayout();
		}

		private void ToolStripMenuItemAutoTuning_Click(object sender, EventArgs e)
		{
			AutoTuningLayout();
		}

		private void ToolStripMenuItemStart_Click(object sender, EventArgs e)
		{
			if (ToolStripMenuItemStart.Checked)
			{
				Properties.Settings.Default.ViewOpenDrive = false;
			}
			else
			{
				Properties.Settings.Default.ViewOpenDrive = true;
			}
		}

		private void ToolStripMenuItemHorizontal_Click(object sender, EventArgs e)
		{
			this.LayoutMdi(MdiLayout.TileHorizontal);
		}

		private void ToolStripMenuItemVertical_Click(object sender, EventArgs e)
		{
			this.LayoutMdi(MdiLayout.TileVertical);
		}

		private void ToolStripMenuItemCascade_Click(object sender, EventArgs e)
		{
			this.LayoutMdi(MdiLayout.Cascade);
		}

		private void ToolStripMenuItemVersion_Click(object sender, EventArgs e)
		{
			AboutBoxDialog abox = new AboutBoxDialog();
			abox.ShowDialog(this);
		}

		private void ToolStripMenuItemOption_Click(object sender, EventArgs e)
		{
			bool devcon = Properties.Settings.Default.DEV_CON_ENABLE;			//20170928 add
			bool close_msg = Properties.Settings.Default.CLOSE_MSG_DISABLE;
			string  culture  = Properties.Settings.Default.CultureType;
			decimal log_preiod = Properties.Settings.Default.LogPeriod;
			decimal interval = Properties.Settings.Default.MainTimerInterval;

            OptionSettingDialog f = new OptionSettingDialog();
			
			DialogResult ret = f.ShowDialog();

			if (DialogResult.OK == ret)
			{
				//ログ周期変更
				if (log_preiod != (int)Properties.Settings.Default.LogPeriod)
				{
					LogWork.LogPeriod = (int)Properties.Settings.Default.LogPeriod;

					if (LogWork.LogPeriod > 4) { LogWork.LogPeriod = 4; }
					if (LogWork.LogPeriod < 1) { LogWork.LogPeriod = 1; }

					if (CheckTheTAD88xxVersion(500))		//通信データ量低減処理（ログ周期変更）はver.5.00以上
					{
						CCommandTx.WriteSvNet(CParamID.LogPeriod, LogWork.LogPeriod);
					}
					else
					{
						LogWork.LogPeriod = 1;
						Properties.Settings.Default.LogPeriod = 1;
					}
				}

				//タイマ周期変更
				TimerMain.Interval = (int)Properties.Settings.Default.MainTimerInterval;
		
				//言語が切り替わった？
				if (culture != OptionSettingDialog.CultureName)
				{
					Culture.Name = OptionSettingDialog.CultureName;
					Properties.Settings.Default.CultureType = Culture.Name;

					Thread.CurrentThread.CurrentUICulture = new CultureInfo(Culture.Name);

					//各フォームの言語リソースをリアルタイムに変更
					ViewCultureResouceChanged();

					if (viewForm != null)
					{
						viewForm.ViewCultureResouceChanged();
					}

					if (jogForm != null && jogForm.Visible)
					{
						jogForm.ViewCultureResouceChanged();
					}

					if (autoForm != null && autoForm.Visible)
					{
						autoForm.ViewCultureResouceChanged();
					}

                    if (simpForm != null && simpForm.Visible)
                    {
                        simpForm.ViewCultureResouceChanged();
                    }

					if (waveForm != null && waveForm.Visible)
					{
						waveForm.ViewCultureResouceChanged();
					}

					if (prmForm != null && prmForm.Visible)
					{
						prmForm.ViewCultureResouceChanged();
					}

					if (bodeForm != null && bodeForm.Visible)
					{
						bodeForm.ViewCultureResouceChanged();
					}

					if (gainForm != null && gainForm.Visible)
					{
						gainForm.ViewCultureResouceChanged();
					}

					if (alrmhisForm != null && alrmhisForm.Visible)
					{
						alrmhisForm.ViewCultureResouceChanged();
					}

                    //↓↓↓ ART HIKARI Mode 20181210 Kimura add ↓↓↓

                    if (svmonForm != null && svmonForm.Visible)
                    {
                        svmonForm.ViewCultureResouceChanged();
                    }

                    if (iomonForm != null && iomonForm.Visible)
                    {
                        iomonForm.ViewCultureResouceChanged();
                    }

                    if (iomonhikariForm != null && iomonhikariForm.Visible)
                    {
                        iomonhikariForm.ViewCultureResouceChanged();
                    }

                    //↑↑↑ ART HIKARI Mode 20181210 Kimura add ↑↑↑
				}

				//↓↓↓ KASHIYAMA Mode 20190930 Kimura add ↓↓↓
				if (Properties.Settings.Default.PASSWORD_KASHIYAMA == true)
				{
					jogForm.ViewCultureResouceChanged();
				}
				//↑↑↑ KASHIYAMA Mode 20190930 Kimura add ↑↑↑
			}
			else
			{
				//キャンセル処理
				Properties.Settings.Default.DEV_CON_ENABLE = devcon;			//20170928 add
				Properties.Settings.Default.CLOSE_MSG_DISABLE = close_msg;
				Properties.Settings.Default.CultureType = culture;
				Properties.Settings.Default.MainTimerInterval = interval;
				Properties.Settings.Default.LogPeriod = log_preiod;
			}
		}

		private void ToolStripMenuItemIoMonitor_Click(object sender, EventArgs e)
		{
			if (iomonForm == null)
			{
				iomonForm = new IoMonitorForm();
				iomonForm.Show();
			}
			else if (iomonForm.Visible == false)
			{
				if (iomonForm.IsExist == false)
				{
					iomonForm = new IoMonitorForm();
				}

				iomonForm.Show();

			}
			else if (iomonForm.WindowState == FormWindowState.Minimized)
			{
				iomonForm.WindowState = FormWindowState.Normal;
			}

			iomonForm.Activate();
		}

		private void ToolStripMenuItemServoMonitor_Click(object sender, EventArgs e)
		{
			if (svmonForm == null)
			{
				svmonForm = new ServoMonitorForm();
				svmonForm.Show();
			}
			else if (svmonForm.Visible == false)
			{
				if (svmonForm.IsExist == false)
				{
					svmonForm = new ServoMonitorForm();
				}

				svmonForm.Show();

			}
			else if (svmonForm.WindowState == FormWindowState.Minimized)
			{
				svmonForm.WindowState = FormWindowState.Normal;
			}

			svmonForm.Activate();
		}

        private void ToolStripMenuItemAlarmHistory_Click(object sender, EventArgs e)
        {
            if (alrmhisForm == null)
			{
                alrmhisForm = new AlarmHistoryForm();
                alrmhisForm.Show();
			}
            else if (alrmhisForm.Visible == false)
			{
                if (alrmhisForm.IsExist == false)
				{
                    alrmhisForm = new AlarmHistoryForm();
				}

                alrmhisForm.Show();

			}
			else if (svmonForm.WindowState == FormWindowState.Minimized)
			{
                alrmhisForm.WindowState = FormWindowState.Normal;
			}

			alrmhisForm.Activate();
            
        }

		private void ToolStripMenuItemManualNavi_Click(object sender, EventArgs e)
		{
			if (mNaviForm == null) { mNaviForm = new ManualNavigatorForm(); mNaviForm.Show(); }
			else if (mNaviForm.Visible == false) { mNaviForm = new ManualNavigatorForm(); mNaviForm.Show(); }
			else if (mNaviForm.WindowState == FormWindowState.Minimized) { mNaviForm.WindowState = FormWindowState.Normal; }
			else { mNaviForm.Select(); }

			mNaviForm.TopMost = true;
			mNaviForm.Activate();
	
		}

		public void InitWorkSapce(Control ctrl)
		{
			Screen s = Screen.FromControl(ctrl);

			ScreenWidth = Screen.GetWorkingArea(ctrl).Width;
			ScreenHeight = Screen.GetWorkingArea(ctrl).Height;

			this.Width = LayoutWidth;
			this.Height = ScreenHeight;
			this.Location = new Point(s.Bounds.X, 0);

			if (this.WindowState != FormWindowState.Normal)
			{
				this.WindowState = FormWindowState.Normal;
			}

			MainForm_ResizeEnd(null, null);

			if (viewForm == null)
			{
				viewForm = new ViewMainForm();
			}
			else if (viewForm.Visible == false)
			{
				viewForm = new ViewMainForm();
			}

			viewForm.Show();

			viewForm.Width = ScreenWidth - LayoutWidth;
			viewForm.Height = ScreenHeight;
			viewForm.Location = new Point(s.Bounds.X + LayoutWidth, 0);

			if (viewForm.WindowState != FormWindowState.Normal)
			{
				viewForm.WindowState = FormWindowState.Normal;
			}

			viewForm.ForceResizeEvent();
		}

		#endregion

		#region StatusBar Event

		private void lblAlarm_DoubleClick(object sender, EventArgs e)
		{
			if (!IsUsbConnectBlink) { return; }

			if (lblAlarm.Text != UserText.MainReady)
			{
				DialogResult ret = UserMessageBox.MainAlarmReset();

				if (ret == DialogResult.Yes)
				{
					AlarmResetCommand();
				}
			}
		}

		private void lblServoOn_DoubleClick(object sender, EventArgs e)
		{
			if (!IsUsbConnectBlink) { return; }

			if (lblServoOn.Text == UserText.MainServoOn)
			{
				DialogResult ret = UserMessageBox.MainServoOff();

				if (ret == DialogResult.Yes)
				{
					ServoOffCommand();
				}
			}

			if (lblServoOn.Text == UserText.MainServoOff)
			{
				if (CMonitor.GetParameter(CParamID.ControlMode) == 14)
				{
					//簡易コントロールモード
					return;
				}

				DialogResult ret = UserMessageBox.MainServoOn();

				if (ret == DialogResult.Yes)
				{
					ServoOnCommand();
				}
			}
		}

		private void lblWorkInit_Click(object sender, EventArgs e)
		{
			InitWorkSapce(this);
		}

		#endregion

		private void ServoOnCommand()
		{
			int cmd = CMonitor.GetParameter(CParamID.ServoCommand);

			cmd &= ~0x0030;		//Hard Stop & Smooth Stop Clear
			if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) { return; }

			cmd |= 0x0001;

			if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) { return; }
		}

		private void ServoOffCommand()
		{
			int cmd = CMonitor.GetParameter(CParamID.ServoCommand);
			int sts = new int();

			cmd |= 0x0020;		//Smooth Stop bit Set

			if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) { return; }

			Thread.Sleep(100);

			CDataTool.SetNow(CDataTool.MAIN_TIME);

			while ((sts & 0x4000) == 0x0000)
			{
				if (!CCommandTx.ReadSvNet(CParamID.ServoStatus, ref sts)) { return; }

				if (CDataTool.IsTimerLimit(CDataTool.MAIN_TIME, 10)) { break; }
			}

			cmd &= ~0x0033;		//Servo On & Profile Start bit Clear & Smooth Stop & Hard Stop bit Clear

			if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) { return; }	
		}

		private void AlarmResetCommand()
		{
			int cmd = CMonitor.GetParameter(CParamID.ServoCommand);

			cmd |= 0x0008;

			if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) { return; }

			Thread.Sleep(100);

			cmd &= ~0x0008;

			if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) { return; }
		}

		private void Control_MouseHover(object sender, EventArgs e)
		{
			this.Select();
		}

		private void Control_MouseEnter(object sender, EventArgs e)
		{
			this.Select();
		}

		public void CollapseLayout()
		{
			if (IsCollapseLayout)
			{
				lblModel.Visible = false;
				lblRevision.Visible = false;
				lblSerial.Visible = false;
				ToolStripMenuItemFile.Visible = false;

				switch (Culture.Name)
				{
					case Culture.JP:
						tbtnJogControl.Text = "ジョグ";
						tbtnAutoTuning.Text = "チューニング";
						break;
					default:
						break;
				
				}

			}
			else
			{
				lblModel.Visible = true;
				lblRevision.Visible = true;
				lblSerial.Visible = true;
				ToolStripMenuItemFile.Visible = true;

				switch (Culture.Name)
				{
					case Culture.JP:
						tbtnJogControl.Text = "ジョグコントロール";
						tbtnAutoTuning.Text = "オートチューニング";
						break;
					default:
						break;

				}
			}

			jogForm.IsCollapseLayout = IsCollapseLayout;
			autoForm.IsCollapseLayout = IsCollapseLayout;

			InitWorkSapce(this);

		}

		public void FreeLayout()
		{
			viewForm.ViewLayout = ViewMainForm.WindowLayout.Free;

			ThisLayout = AppLayout.Free;

			Properties.Settings.Default.ThisLayout = (int)ThisLayout;
		}

		public void JogLayout()
		{
			InitWorkSapce(this);
			viewForm.ViewLayout = ViewMainForm.WindowLayout.Osillo;
			LoadJogControl();

			ThisLayout = AppLayout.Jog;

			Properties.Settings.Default.ThisLayout = (int)ThisLayout;
		}

		public void ParameterLayout()
		{
			InitWorkSapce(this);
			viewForm.ViewLayout = ViewMainForm.WindowLayout.Param;
			LoadJogControl();

			ThisLayout = AppLayout.Parameter;

			Properties.Settings.Default.ThisLayout = (int)ThisLayout;
		}

		public void AutoTuningLayout()
		{
			InitWorkSapce(this);
			viewForm.ViewLayout = ViewMainForm.WindowLayout.OsilloFFT;
			LoadAutoTuning();

			ThisLayout = AppLayout.AutoTuning;

			Properties.Settings.Default.ThisLayout = (int)ThisLayout;
		}

		public void ManualTuningLayout()
		{
			InitWorkSapce(this);
			viewForm.ViewLayout = ViewMainForm.WindowLayout.OsilloGain;
			LoadJogControl();

			ThisLayout = AppLayout.ManualTuning;

			Properties.Settings.Default.ThisLayout = (int)ThisLayout;
		}

		public void CancelLayout()
		{
			if (jogForm  != null) { jogForm.Close();  jogForm.IsExist  = false; }
			if (autoForm != null) { autoForm.Close(); autoForm.IsExist = false; }
			if (prmForm  != null) { prmForm.Close();  prmForm.IsExist  = false; }
			if (gainForm != null) { gainForm.Close(); gainForm.IsExist = false; }
			if (waveForm != null) { waveForm.Close(); waveForm.IsExist = false; }
			if (bodeForm != null) { bodeForm.Close(); bodeForm.IsExist = false; }
		
			Screen s = Screen.FromControl(this);

			ScreenWidth = Screen.GetWorkingArea(this).Width;
			ScreenHeight = Screen.GetWorkingArea(this).Height;

			this.Width = LayoutWidth;
			this.Height = ScreenHeight;
			this.Location = new Point(s.Bounds.X, 0);

			if (this.WindowState != FormWindowState.Normal)
			{
				this.WindowState = FormWindowState.Normal;
			}

			MainForm_ResizeEnd(null, null);

        }

		public void ViewServoMonitor()
		{
			if (svmonForm == null)
			{
				ToolStripMenuItemServoMonitor.PerformClick();
			}
			else if (svmonForm.Visible == false)
			{
				ToolStripMenuItemServoMonitor.PerformClick();
			}
			else if (svmonForm.WindowState == FormWindowState.Minimized)
			{
				ToolStripMenuItemServoMonitor.PerformClick();
			}
			else
			{
				svmonForm.Close();
			}
		}

		public void ViewIoMonitor()
		{
			if (iomonForm == null)
			{
				ToolStripMenuItemIoMonitor.PerformClick();
			}
			else if (iomonForm.Visible == false)
			{
				ToolStripMenuItemIoMonitor.PerformClick();
			}
			else if (iomonForm.WindowState == FormWindowState.Minimized)
			{
				ToolStripMenuItemIoMonitor.PerformClick();
			}
			else
			{
				iomonForm.Close();
			}
		}

		/// <summary>
		/// TAD88xxシリーズ本体バージョンチェック
		/// 引数ver以上ならtrue
		/// </summary>
		/// <param name="ver">バージョン</param>
		/// <returns></returns>
		private bool CheckTheTAD88xxVersion(int ver)
		{
			//↓↓↓ KASHIYAMA Mode 20200330 Kimura add ↓↓↓
            // KASHIYAMA Modeは無条件にtrue 
            if (Properties.Settings.Default.PASSWORD_KASHIYAMA == true)
            {
                return true;
            }

            //↑↑↑ KASHIYAMA Mode 20200330 Kimura add ↑↑↑

            //TAD88XXシリーズ本体バージョンチェック 引数ver
			int act = CMonitor.GetParameter(CParamID.Revision);

			if (act >= ver)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

        #region カルチャリソース切り替え

        public void ViewCultureResouceChanged()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));

            lblUsb.Font = (Font)resources.GetObject("lblUsb.Font");
            lblModel.Font = (Font)resources.GetObject("lblModel.Font");
            lblRevision.Font = (Font)resources.GetObject("lblRevision.Font");
            lblSerial.Font = (Font)resources.GetObject("lblSerial.Font");
            lblAlarm.Font = (Font)resources.GetObject("lblAlarm.Font");
            lblServoOn.Font = (Font)resources.GetObject("lblServoOn.Font");
            tbtnAutoTuning.Font = (Font)resources.GetObject("tbtnAutoTuning.Font");
			tbtnJogControl.Font = (Font)resources.GetObject("tbtnJogControl.Font");
			tbtnProgram.Font = (Font)resources.GetObject("tbtnProgram.Font");
			ToolStripMenuItemAutoTuning.Font = (Font)resources.GetObject("ToolStripMenuItemAutoTuning.Font");
            ToolStripMenuItemCascade.Font = (Font)resources.GetObject("ToolStripMenuItemCascade.Font");
            ToolStripMenuItemCollapseLayout.Font = (Font)resources.GetObject("ToolStripMenuItemCollapseLayout.Font");
            ToolStripMenuItemEnd.Font = (Font)resources.GetObject("ToolStripMenuItemEnd.Font");
            ToolStripMenuItemFile.Font = (Font)resources.GetObject("ToolStripMenuItemFile.Font");
            ToolStripMenuItemFree.Font = (Font)resources.GetObject("ToolStripMenuItemFree.Font");
            ToolStripMenuItemGain.Font = (Font)resources.GetObject("ToolStripMenuItemGain.Font");
            ToolStripMenuItemHelp.Font = (Font)resources.GetObject("ToolStripMenuItemHelp.Font");
            ToolStripMenuItemHorizontal.Font = (Font)resources.GetObject("ToolStripMenuItemHorizontal.Font");
            ToolStripMenuItemInitLayout.Font = (Font)resources.GetObject("ToolStripMenuItemInitLayout.Font");
            ToolStripMenuItemJog.Font = (Font)resources.GetObject("ToolStripMenuItemJog.Font");
            ToolStripMenuItemLayout.Font = (Font)resources.GetObject("ToolStripMenuItemLayout.Font");
            ToolStripMenuItemOption.Font = (Font)resources.GetObject("ToolStripMenuItemOption.Font");
            ToolStripMenuItemParameter.Font = (Font)resources.GetObject("ToolStripMenuItemParameter.Font");
            ToolStripMenuItemStart.Font = (Font)resources.GetObject("ToolStripMenuItemStart.Font");
            ToolStripMenuItemTool.Font = (Font)resources.GetObject("ToolStripMenuItemTool.Font");
			ToolStripMenuItemMonitor.Font = (Font)resources.GetObject("ToolStripMenuItemMonitor.Font");
			ToolStripMenuItemServoMonitor.Font = (Font)resources.GetObject("ToolStripMenuItemServoMonitor.Font");
			ToolStripMenuItemIoMonitor.Font = (Font)resources.GetObject("ToolStripMenuItemIoMonitor.Font");
			ToolStripMenuItemUpgrade.Font = (Font)resources.GetObject("ToolStripMenuItemUpgrade.Font");
            ToolStripMenuItemVersion.Font = (Font)resources.GetObject("ToolStripMenuItemVersion.Font");
            ToolStripMenuItemVertical.Font = (Font)resources.GetObject("ToolStripMenuItemVertical.Font");
            ToolStripMenuItemView.Font = (Font)resources.GetObject("ToolStripMenuItemView.Font");
            ToolStripMenuItemViewWorkspace.Font = (Font)resources.GetObject("ToolStripMenuItemViewWorkspace.Font");
            ToolStripMenuItemViewWorkspace2.Font = (Font)resources.GetObject("ToolStripMenuItemViewWorkspace2.Font");
			ToolStripMenuItemWindow.Font = (Font)resources.GetObject("ToolStripMenuItemWindow.Font");
			ToolStripMenuItemManualNavi.Font = (Font)resources.GetObject("ToolStripMenuItemManualNavi.Font");
			ToolStripMenuItemAlarmHistory.Font = (Font)resources.GetObject("ToolStripMenuItemAlarmHistory.Font");

            lblUsb.Text = resources.GetString("lblUsb.Text");
            lblModel.Text = resources.GetString("lblModel.Text");
            lblRevision.Text = resources.GetString("lblRevision.Text");
            lblSerial.Text = resources.GetString("lblSerial.Text");
            lblAlarm.Text = resources.GetString("lblAlarm.Text");
            lblServoOn.Text = resources.GetString("lblServoOn.Text");
            tbtnAutoTuning.Text = resources.GetString("tbtnAutoTuning.Text");
			tbtnJogControl.Text = resources.GetString("tbtnJogControl.Text");
			tbtnProgram.Text = resources.GetString("tbtnProgram.Text");
			ToolStripMenuItemAutoTuning.Text = resources.GetString("ToolStripMenuItemAutoTuning.Text");
            ToolStripMenuItemCascade.Text = resources.GetString("ToolStripMenuItemCascade.Text");
            ToolStripMenuItemCollapseLayout.Text = resources.GetString("ToolStripMenuItemCollapseLayout.Text");
            ToolStripMenuItemCollapseLayout.ToolTipText = resources.GetString("ToolStripMenuItemCollapseLayout.ToolTipText");
            ToolStripMenuItemEnd.Text = resources.GetString("ToolStripMenuItemEnd.Text");
            ToolStripMenuItemFile.Text = resources.GetString("ToolStripMenuItemFile.Text");
            ToolStripMenuItemFree.Text = resources.GetString("ToolStripMenuItemFree.Text");
            ToolStripMenuItemGain.Text = resources.GetString("ToolStripMenuItemGain.Text");
            ToolStripMenuItemHelp.Text = resources.GetString("ToolStripMenuItemHelp.Text");
            ToolStripMenuItemHorizontal.Text = resources.GetString("ToolStripMenuItemHorizontal.Text");
            ToolStripMenuItemInitLayout.Text = resources.GetString("ToolStripMenuItemInitLayout.Text");
            ToolStripMenuItemJog.Text = resources.GetString("ToolStripMenuItemJog.Text");
            ToolStripMenuItemLayout.Text = resources.GetString("ToolStripMenuItemLayout.Text");
            ToolStripMenuItemOption.Text = resources.GetString("ToolStripMenuItemOption.Text");
            ToolStripMenuItemParameter.Text = resources.GetString("ToolStripMenuItemParameter.Text");
            ToolStripMenuItemStart.Text = resources.GetString("ToolStripMenuItemStart.Text");
            ToolStripMenuItemTool.Text = resources.GetString("ToolStripMenuItemTool.Text");
			ToolStripMenuItemMonitor.Text = resources.GetString("ToolStripMenuItemMonitor.Text");
			ToolStripMenuItemServoMonitor.Text = resources.GetString("ToolStripMenuItemServoMonitor.Text");
			ToolStripMenuItemIoMonitor.Text = resources.GetString("ToolStripMenuItemIoMonitor.Text");
			ToolStripMenuItemUpgrade.Text = resources.GetString("ToolStripMenuItemUpgrade.Text");
			ToolStripMenuItemVersion.Text = resources.GetString("ToolStripMenuItemVersion.Text");
            ToolStripMenuItemVertical.Text = resources.GetString("ToolStripMenuItemVertical.Text");
            ToolStripMenuItemView.Text = resources.GetString("ToolStripMenuItemView.Text");
            ToolStripMenuItemViewWorkspace.Text = resources.GetString("ToolStripMenuItemViewWorkspace.Text");
            ToolStripMenuItemViewWorkspace2.Text = resources.GetString("ToolStripMenuItemViewWorkspace2.Text");
			ToolStripMenuItemWindow.Text = resources.GetString("ToolStripMenuItemWindow.Text");
			ToolStripMenuItemManualNavi.Text = resources.GetString("ToolStripMenuItemManualNavi.Text");
			ToolStripMenuItemAlarmHistory.Text = resources.GetString("ToolStripMenuItemAlarmHistory.Text");

        }

        #endregion

		private void ToolStripMenuItemDebugMonitor_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem item = (ToolStripMenuItem)sender;

			int idx = Convert.ToInt32(item.Tag);

			if (dbgMonForm[idx] == null)
			{
				dbgMonForm[idx] = new DebugMonitorForm();
				dbgMonForm[idx].Show();
			}
			else if (dbgMonForm[idx].Visible == false)
			{
				if (dbgMonForm[idx].IsExist == false)
				{
					dbgMonForm[idx] = new DebugMonitorForm();
				}

				dbgMonForm[idx].Show();

			}
			else if (dbgMonForm[idx].WindowState == FormWindowState.Minimized)
			{
				dbgMonForm[idx].WindowState = FormWindowState.Normal;
			}

			dbgMonForm[idx].Activate();
		}

	}

	public enum AppLayout
	{
		Free, Jog, Parameter, AutoTuning, ManualTuning
	}

	public static class AppConst		//20161031 add
	{
		public static OperatingSystem WinodwsOS;

		public const int UpTadVer520 = 520;
		
		public static bool UpWinodws7
		{
			get
			{
				//Windows 7 = Version 6.1
				if (WinodwsOS.Version.Major >= 6 && WinodwsOS.Version.Minor >= 1)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}
	}

	public static class AppFont
	{
		static public Font MeiryoBold7 = new Font("メイリオ", 7F, FontStyle.Bold);
		static public Font MeiryoRegular7 = new Font("メイリオ", 7F, FontStyle.Regular);

		static public Font MeiryoBold8 = new Font("メイリオ", 8F, FontStyle.Bold);
		static public Font MeiryoRegular8 = new Font("メイリオ", 8F, FontStyle.Regular);

		static public Font MeiryoBold9 = new Font("メイリオ", 9F, FontStyle.Bold);
		static public Font MeiryoRegular9 = new Font("メイリオ", 9F, FontStyle.Regular);

		static public Font MeiryoBold12 = new Font("メイリオ", 12F, FontStyle.Bold);
		static public Font MeiryoRegular12 = new Font("メイリオ", 12F, FontStyle.Regular);

		static public Font MeiryoBold14 = new Font("メイリオ", 14F, FontStyle.Bold);
		static public Font MeiryoRegular14 = new Font("メイリオ", 14F, FontStyle.Regular);

		static public Font MeiryoBold16 = new Font("メイリオ", 16F, FontStyle.Bold);
		static public Font MeiryoRegular16 = new Font("メイリオ", 16F, FontStyle.Regular);

		static public Font MeiryoBold18 = new Font("メイリオ", 18F, FontStyle.Bold);
		static public Font MeiryoRegular18 = new Font("メイリオ", 18F, FontStyle.Regular);

		static public Font ArialRegular7 = new Font("Arial", 7F, FontStyle.Regular);
		static public Font ArialRegular8 = new Font("Arial", 8F, FontStyle.Regular);
		static public Font ArialRegular10 = new Font("Arial", 10F, FontStyle.Regular);

		static public Font ArialBold7 = new Font("Arial", 7F, FontStyle.Bold);
		static public Font ArialBold8 = new Font("Arial", 8F, FontStyle.Bold);
		static public Font ArialBold9 = new Font("Arial", 9F, FontStyle.Bold);
		static public Font ArialBold10 = new Font("Arial", 10F, FontStyle.Bold);

        static public Font MicrosoftYaHeiBold7 = new Font("Microsoft YaHei", 6.75F, FontStyle.Bold);
        static public Font MicrosoftYaHeiBold8 = new Font("Microsoft YaHei", 8.25F, FontStyle.Bold);
        static public Font MicrosoftYaHeiBold9 = new Font("Microsoft YaHei", 9F, FontStyle.Bold);
        static public Font MicrosoftYaHeiBold10 = new Font("Microsoft YaHei", 9.75F, FontStyle.Bold);

        static public Font MicrosoftYaHeiRegular7 = new Font("Microsoft YaHei", 6.75F, FontStyle.Regular);
        static public Font MicrosoftYaHeiRegular8 = new Font("Microsoft YaHei", 8.25F, FontStyle.Regular);
        static public Font MicrosoftYaHeiRegular9 = new Font("Microsoft YaHei", 9F, FontStyle.Regular);
        static public Font MicrosoftYaHeiRegular10 = new Font("Microsoft YaHei", 9.75F, FontStyle.Regular);
        static public Font MicrosoftYaHeiRegular12 = new Font("Microsoft YaHei", 12F, FontStyle.Regular);
        static public Font MicrosoftYaHeiRegular14 = new Font("Microsoft YaHei", 14.25F, FontStyle.Regular);
        static public Font MicrosoftYaHeiRegular16 = new Font("Microsoft YaHei", 15.75F, FontStyle.Regular);
        static public Font MicrosoftYaHeiRegular18 = new Font("Microsoft YaHei", 18F, FontStyle.Regular);

		static public Color ActiveForeColor = Color.Navy;
		static public Color ActiveBackColor = Color.Gold;
		static public Color NormalForeColor = Color.Black;
		static public Color NormalBackColor = Color.Transparent;

	}

	public static class LogWork
	{
		public const int MonNum = 7;					//位置、速度、電流、ステータス、パラメタ1、パラメタ2、パラメタ3
		public const int FFTNum = 20;					//位置、速度、電流、ステータス、パラメタ1、パラメタ2、パラメタ3
		public const int KindNum = MonNum + FFTNum;		//位置、速度、電流、ステータス、パラメタ1、パラメタ2、パラメタ3　+　FFT20

		//static public int LogLength = (int)Properties.Settings.Default.LogTime + 1000;	//default:30sec 30sec×1000=30000msec
		static public int LogLength = (int)Properties.Settings.Default.LogTime * 1000;	//default:30sec 30sec×1000=30000msec
		static public int LogPeriod = (int)Properties.Settings.Default.LogPeriod;		//default:1msec

		public const int POS = 0;
		public const int VEL = 1;
		public const int CUR = 2;
		public const int STS = 3;
		public const int PRM1 = 4;
		public const int PRM2 = 5;
		public const int PRM3 = 6;

		public const int LOG1 = 7;
		public const int LOG2 = 8;
		public const int LOG3 = 9;
		public const int LOG4 = 10;
		public const int LOG5 = 11;
		public const int LOG6 = 12;
		public const int LOG7 = 13;
		public const int LOG8 = 14;
		public const int LOG9 = 15;
		public const int LOG10 = 16;
		public const int LOG11 = 17;
		public const int LOG12 = 18;
		public const int LOG13 = 19;
		public const int LOG14 = 20;
		public const int LOG15 = 21;
		public const int LOG16 = 22;
		public const int LOG17 = 23;
		public const int LOG18 = 24;
		public const int LOG19 = 25;
		public const int LOG20 = 26;

	}

	public static class ArtHikariInfo
	{
		public const bool Enabled = false;

		public const string AssemblyTitle = "";
		public const string AssemblyProduct = "Art Hikari Servo Gun";
		public const string AssemblyVersion = "Version 1.00";
		public const string AssemblyCopyright = "Copyright(C) 2017";
		public const string AssemblyCompany = "ART-HIKARI Co., Ltd.";

	}

    #region 言語カルチャ

    /// <summary>
    /// 言語カルチャ
    /// </summary>
    public static class Culture
    {
        /// <summary>
        /// 日本語
        /// </summary>
        public const string JP = "ja-JP";

        /// <summary>
        /// 英語
        /// </summary>
        public const string US = "en-US";

        /// <summary>
        /// 中国語
        /// </summary>
        public const string CN = "zh-CN";

        /// <summary>
        /// 現在のカルチャ言語
        /// </summary>
        public static string Name = JP;

        public const string JP_US_Font = "メイリオ";        //日本語、英語フォント
        public const string CN_Font = "Microsoft YaHei";    //中国語フォント
    }

    #endregion

}