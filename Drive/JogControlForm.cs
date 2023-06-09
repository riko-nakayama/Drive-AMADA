using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Motion_Designer
{

	public partial class JogControlForm : Form
	{
		static private Point FormPosition = new Point(0, 0);

		static private JogControlForm _ThisForm;

		static private int _ControlMode = 0;

		private bool CommboControlModeOpen = new bool();

		private int ResizeHeight = new int();
		private int ResizeWidth = new int();

		private MdiClient ThisMdiClient;

		private bool _IsExist = new bool();
		private bool _IsCollapseLayout = new bool();

		private bool DisableComboEvent = new bool();
		private bool DisableFeedback = new bool();

		public JogControlForm()
		{
			InitializeComponent();

			_ThisForm = this;
			_IsExist = true;

			//MdiClientの取得
			ThisMdiClient = MainForm.ThisForm.GetMdiClient();

		}

		static public JogControlForm ThisForm
		{
			get { return _ThisForm; }
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

		public bool EnableUpdate
		{
			get
			{
				if (!this.Visible) { return false; }
				if (this.WindowState == FormWindowState.Minimized) { return false; }

				return true;
			}
		}

		public bool IsCollapseLayout
		{
			set
			{
				_IsCollapseLayout = value;

				if (_IsCollapseLayout)
				{
					ctlJog.CollapseJogControl();
				}
				else
				{
					ctlJog.ExpandJogControl();
				}
			}

			get { return _IsCollapseLayout; }
		}

		public bool IsExist
		{
			set { _IsExist = value; }
			get { return _IsExist; }
		}

		static public int ControlMode
		{
			set { _ControlMode = value; }
			get { return _ControlMode; }
		}

		public void JogStop()
		{
			if (ThisForm != null)
			{
				ThisForm.ctlJog.JogStopped();
			}
		}

		#region Feedback

		public void SetJogFeedBack()
		{
			if (DisableFeedback) { return; }

			DisableComboEvent = true;

			if (!CommboControlModeOpen)
			{
				switch (CMonitor.GetParameter(CParamID.ControlMode))
				{
					default:
					case 0:
						cmbControlMode.SelectedIndex = 0;	//制御無し
						break;
					case 1:
						cmbControlMode.SelectedIndex = 1;	//位置制御
						break;
					case 2:
						cmbControlMode.SelectedIndex = 2;	//速度制御
						break;
					case 3:
						cmbControlMode.SelectedIndex = 3;	//電流制御
						WasCurrentMode = true;
						WasProgramMode = false;
						break;
					case 14:
						cmbControlMode.SelectedIndex = 4;	//プログラム
						WasCurrentMode = false;
						WasProgramMode = true;
						break;
                    
                    //↓↓↓ KASHIYAMA Mode 20190930 Kimura add ↓↓↓
                    case 7:
                        if (Properties.Settings.Default.PASSWORD_KASHIYAMA == true)
                        {
							if( cmbControlMode.Items.Count >= 6 )
							{
								cmbControlMode.SelectedIndex = 5;	//I/O速度制御
							}
                        }
                        break;
                    //↑↑↑ KASHIYAMA Mode 20190930 Kimura add ↑↑↑

				}
			}

			ctlJog.SetContorlMode();
			ctlJog.SetServoFeedBack();

			DisableComboEvent = false;
		}

		#endregion

		#region Form Event

		private void JogControlForm_Load(object sender, EventArgs e)
		{
			//InitFormLayout();

			DisableComboEvent = true;		//20160328 add

            ViewCultureResouceChanged();

			DisableComboEvent = true;		//20160328 add

			ctlJog.UpdateAccDccTime();

			lblDummy.Select();

		}

		private void JogControlForm_FormClosing(object sender, FormClosingEventArgs e)
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

		private void JogControlForm_Resize(object sender, EventArgs e)
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

		private void ctlJog_Click(object sender, EventArgs e)
		{
			this.Activate();
		}

		#endregion

		#region Combo Event

		private void cmbJog_KeyDown(object sender, KeyEventArgs e)
		{
			e.Handled = true;
		}

		private void cmbJog_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = true;
		}

		private bool WasCurrentMode = new bool();
		private bool WasProgramMode = new bool();
		private int BackupTargetVelocity = new int();

		private void cmbMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (DisableComboEvent) { return; }

			DisableFeedback = true;
			TimerWait.Interval = 500;
			TimerWait.Enabled = true;

			switch (cmbControlMode.Text)
			{
				default:
				case "制御無し":
                case "无控制":
                case "No Control":

					ControlMode = 0;		//制御無し

					if (WasCurrentMode)		//20150315 add
					{
						WasCurrentMode = false;
						ctlJog.TargetVelocity = BackupTargetVelocity;
					}
					break;

				case "位置制御":
                case "位置控制":
                case "Position Control":

					ControlMode = 1;		//位置制御モード

					if (WasCurrentMode)		//20150315 add
					{
						WasCurrentMode = false;
						ctlJog.TargetVelocity = BackupTargetVelocity;
					}
					break;

				case "速度制御":
                case "速度控制":
                case "Speed Control":

					ControlMode = 2;		//速度制御モード

					if (WasCurrentMode)		//20150315 add
					{
						WasCurrentMode = false;
						ctlJog.TargetVelocity = BackupTargetVelocity;
					}
					break;

				case "電流制御":
                case "电流控制":
                case "Current Control":

					if (MainForm.IsUsbConnect)
					{
						int sts = CMonitor.GetParameter(CParamID.ServoStatus);
						int cmd = CMonitor.GetParameter(CParamID.ServoCommand);

						if ((sts & 0x01) == 0x01)
						{
							TimerWait.Enabled = false;			//フラグクリア用タイマ一時停止

							if (UserMessageBox.CommonServoOff() == DialogResult.Yes)
							{
								//サーボオフ
								cmd = cmd & ~0x01;
								CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd);

								TimerWait.Enabled = true;		//フラグクリア用タイマ再開
							}
							else
							{
								DisableComboEvent = true;

								switch (ControlMode)
								{
									case 0:
									case 1:
									case 2:
										cmbControlMode.SelectedIndex = ControlMode;
										break;

									case 14:
										cmbControlMode.SelectedIndex = 4;
										break;

									default:
										cmbControlMode.SelectedIndex = 0;
										break;
								}

								TimerWait.Enabled = true;		//フラグクリア用タイマ再開
								DisableComboEvent = false;
								return;
							}
						}
					}

					ControlMode = 3;		//電流制御モード

					BackupTargetVelocity = ctlJog.TargetVelocity;	//20150315 add
					WasCurrentMode = true;							//20150315 add
					ctlJog.TargetVelocity = 0;						//20150315 add
					break;

				case "プログラム":
				case "程序控制":
                case "Program":
					
					ControlMode = 14;		//簡易プログラムモード

					if (WasCurrentMode)
					{
						WasCurrentMode = false;
						ctlJog.TargetVelocity = BackupTargetVelocity;
					}

					WasProgramMode = true;
					break;

                //↓↓↓ KASHIYAMA Mode 20190930 Kimura add ↓↓↓
                case "I/O速度制御":
                    ControlMode = 7;		//I/O速度制御
                    break;
                //↑↑↑ KASHIYAMA Mode 20190930 Kimura add ↑↑↑
			}

			if (!MainForm.IsUsbConnectBlink) { return; }

			int mode = new int();
	
			switch (ControlMode)
			{
				default:
				case 0:
				case 14:
					break;

				case 1:
					
					mode = CMonitor.GetParameter(CParamID.PositionInputMode);

					if (mode != 0)
					{
						if (UserMessageBox.JogControlPositionInputModeWarning() == DialogResult.Yes)
						{
							if (!CCommandTx.WriteSvNet(CParamID.PositionInputMode, 0)) { return; }	//位置指令モードをSV-NETへ
						}
					}
					
					break;

				case 2:

					mode = CMonitor.GetParameter(CParamID.VelocityInputMode);

					if (mode != 0)
					{
						if (UserMessageBox.JogControlVelocityInputModeWarning() == DialogResult.Yes)
						{
							if (!CCommandTx.WriteSvNet(CParamID.VelocityInputMode, 0)) { return; }	//速度指令モードをSV-NETへ
						}
					}
					
					break;

				case 3:

					mode = CMonitor.GetParameter(CParamID.CurrentInputMode);

					if (mode != 0)
					{
						if (UserMessageBox.JogControlCurrentInputModeWarning() == DialogResult.Yes)
						{
							if (!CCommandTx.WriteSvNet(CParamID.CurrentInputMode, 0)) { return; }	//電流指令モードをSV-NETへ
						}
					}
					break;

			}

			Thread.Sleep(100);

			if (ControlMode != 14 && WasProgramMode)
			{
				//プログラムモードから他の制御モードへ変更された場合は強制サーボオフ
				WasProgramMode = false;

				int cmd = CMonitor.GetParameter(CParamID.ServoCommand);

				cmd = cmd & ~0x01;

				CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd);

				Thread.Sleep(100);
			}

			if (!CCommandTx.WriteSvNet(CParamID.ControlMode, ControlMode)) { return; }

			ctlJog.SetContorlMode();

			lblDummy.Select();
		}

		private void btnNextMode_Click(object sender, EventArgs e)
		{
			if (cmbControlMode.SelectedIndex < cmbControlMode.Items.Count - 1)
			{
				cmbControlMode.SelectedIndex++;
			}
		}

		private void btnBackMode_Click(object sender, EventArgs e)
		{
			if (cmbControlMode.SelectedIndex > 0)
			{
				cmbControlMode.SelectedIndex--;
			}
		}

		private void cmbControlMode_DropDown(object sender, EventArgs e)
		{
			CommboControlModeOpen = true;
		}

		private void cmbControlMode_DropDownClosed(object sender, EventArgs e)
		{
			CommboControlModeOpen = false;
			lblDummy.Select();
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

		private void TimerWait_Tick(object sender, EventArgs e)
		{
			DisableFeedback = false;
			TimerWait.Enabled = false;
		}

		#endregion

		private void Control_MouseHover(object sender, EventArgs e)
		{
			this.Select();
		}

		private void Control_MouseEnter(object sender, EventArgs e)
		{
			this.Select();
		}

        #region カルチャリソース切り替え

        public void ViewCultureResouceChanged()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(JogControlForm));

            InitFormLayout();

            tlblControlMode.Font = (Font)resources.GetObject("tlblControlMode.Font");
            cmbControlMode.Font = (Font)resources.GetObject("tlblControlMode.Font");    // 何故かcmbControlMode.Fontだと日本語フォントがUIになる？？？？ 

            this.Text = resources.GetString("$this.Text");
            tlblControlMode.Text = resources.GetString("tlblControlMode.Text");
            cmbControlMode.Text = resources.GetString("cmbControlMode.Text");
            btnBackMode.ToolTipText = resources.GetString("btnBackMode.ToolTipText");
            btnNextMode.ToolTipText = resources.GetString("btnNextMode.ToolTipText");

            cmbControlMode.Items.Clear();

            cmbControlMode.Items.AddRange(new object[] {
            resources.GetString("cmbControlMode.Items"),
            resources.GetString("cmbControlMode.Items1"),
            resources.GetString("cmbControlMode.Items2"),
            resources.GetString("cmbControlMode.Items3"),
			resources.GetString("cmbControlMode.Items4")});

            //↓↓↓ KASHIYAMA Mode 20190930 Kimura add ↓↓↓ 
            if (Properties.Settings.Default.PASSWORD_KASHIYAMA == true)
            {
                cmbControlMode.Items.Add("I/O速度制御");
            }
            //↑↑↑ KASHIYAMA Mode 20190930 Kimura add ↑↑↑

            //↓↓↓ KASHIYAMA Mode 20190624 Kimura update ↓↓↓
            //リソースが標準モードに戻ってしまうので、KASHIYAMA Mode時は変更しない。
            if (Properties.Settings.Default.PASSWORD_KASHIYAMA == false)
            {
                ctlJog.ViewCultureResouceChanged();
            }
            //↑↑↑ KASHIYAMA Mode 20190624 Kimura update ↑↑↑
        }

        #endregion
	}
}