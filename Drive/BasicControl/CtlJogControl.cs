using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Motion_Designer
{
	public enum NET_TYPE { SV_NET, EtherCAT };

	public partial class CtlJogControl : UserControl
	{
		#region メンバ変数

		private int ServoStatusIndex = 0;

		private const int MAX_STS_INDEX = 3;
		private const int MIN_STS_INDEX = 0;

		private NET_TYPE _NetType = NET_TYPE.SV_NET;		//0：SV-NET 1：EtherCAT

		private const int MAX_CTRL_MODE = 5;

		private int ControlMode = new int();

		static private int CtrlModeIndex = new int();
		static private bool[] IsButtonLock = new bool[MAX_CTRL_MODE] { false, false, false, false, false };

		static private bool[] IsHardStop = new bool[MAX_CTRL_MODE] { false, false, false, false, false };
		static private bool[] IsVelocityLimit = new bool[MAX_CTRL_MODE] { true, true, true, true, true };

		static private bool IsPositionAbs = false;
		static private bool IsPositionContinue = true;
		static private int ContinueTime = 500;

		private int NowPosition = new int();
		private int NowVelocity = new int();

		private bool PositionCCW = new bool();
		private int WaitCnt = new int();

		private bool IsBoldStatusLabel = new bool();

		#endregion

		public CtlJogControl()
		{
			InitializeComponent();

			pnlSetting.Controls.Add(grpTeaching1);
			pnlSetting.Controls.Add(grpTeaching2);

			grpTeaching1.Location = grpPosition1.Location;
			grpTeaching2.Location = grpPosition2.Location;

			ctlNumTargetVelocity.NumInputValueChanged += new dNumInputValueCheange(ctlNumTargetVelocity_NumInputValueChanged);
			ctlNumTargetAcceleration.NumInputValueChanged += new dNumInputValueCheange(ctlNumTargetAcceleration_NumInputValueChanged);
			ctlNumTargetDeceleration.NumInputValueChanged += new dNumInputValueCheange(ctlNumTargetDeceleration_NumInputValueChanged);
		
			ctlNumTargetPosition1.NumInputValueChanged += new dNumInputValueCheange(ctlNumTargetPosition1_NumInputValueChanged);
			ctlNumTargetPosition2.NumInputValueChanged += new dNumInputValueCheange(ctlNumTargetPosition2_NumInputValueChanged);

			for (int i = 0; i < MAX_CTRL_MODE; i++)
			{
				IsHardStop[i] = false;
				IsVelocityLimit[i] = true;
				IsButtonLock[i] = false;
			}

			IsButtonLock[1] = true;			//位置制御はボタンロック有効

			NowVelocity = ctlNumTargetVelocity.IntValue;

            //↓↓↓ KASHIYAMA Mode 20190624 Kimura add ↓↓↓
            if (Properties.Settings.Default.PASSWORD_KASHIYAMA == true)
            {
                grpServoFeedBack.Size = new Size(220, 185);
                fpnlFeedback.Size = new Size(210, 132);
                lblSep2.Size = new Size(208, 5);

                fpnlKashiyamaMonitor.Visible = true;
            }

            //↑↑↑ KASHIYAMA Mode 20190624 Kimura add ↑↑↑
		}

		#region Form Event

		private void CtlJogControl_Load(object sender, EventArgs e)
		{
			int idx = CtrlModeIndex;

			if (IsPositionAbs)
			{
				rdoAbs.Checked = true;
			}

			RadioButton_CheckedChanged(null, null);

			chkContinue.Checked = IsPositionContinue;
			chkButtonLock.Checked = IsButtonLock[idx];
			chkHardStop.Checked = IsHardStop[idx];
			chkVelocityLimit.Checked = IsVelocityLimit[idx];

			chkContinue_CheckedChanged(null, null);
			chkButtonLock_CheckedChanged(null, null);
			chkHardStop_CheckedChanged(null, null);
			chkVelocityLimit_CheckedChanged(null, null);

			RadioButton_CheckedChanged(null, null);

			numContinue.Value = ContinueTime;
		}

		#endregion

		#region NumInput Callback

		void ctlNumTargetPosition1_NumInputValueChanged()
		{

		}

		void ctlNumTargetPosition2_NumInputValueChanged()
		{

		}

		void ctlNumTargetAcceleration_NumInputValueChanged()
		{
			UpdateAccDccTime();			
		}

		void ctlNumTargetDeceleration_NumInputValueChanged()
		{
			UpdateAccDccTime();	
		}

		void ctlNumTargetVelocity_NumInputValueChanged()
		{
			int now = ctlNumTargetVelocity.IntValue;
			int old = NowVelocity;

			if ((Math.Abs(now) - Math.Abs(old)) >= 1000)	//速度変化1000rpm以上なら注意メッセージ
			{
				ctlNumTargetVelocity.IntValue = old;

				string txt = old.ToString() + " --> " + now.ToString();

				if (UserMessageBox.JogControlVelocityInputValueWarning1(txt) != DialogResult.Yes)
				{
					return;
				}

				if (Math.Abs(now) > 3000)					//更に3000rpmより大きければ注意メッセージ
				{
					if (UserMessageBox.JogControlVelocityInputValueWarning2(txt) != DialogResult.Yes)
					{
						return;
					}
				}
			
				ctlNumTargetVelocity.IntValue = now;
			}

			UpdateAccDccTime();

			NowVelocity = ctlNumTargetVelocity.IntValue;
		}

		#endregion

		public NET_TYPE NetType
		{
			set { _NetType = value; UpdateStatusLabel(); }
			get { return _NetType; }
		}

		public void SetContorlMode()
		{
			int mode = CMonitor.GetParameter(CParamID.ControlMode);

			if (mode == ControlMode) { return; }

			ControlMode = mode;

            switch (Culture.Name)
            {
                default:
                case Culture.JP:
                    btnCw.Font = AppFont.MeiryoRegular8;
                    btnCcw.Font = AppFont.MeiryoRegular8;
                    break;

                case Culture.US:
                    btnCw.Font = AppFont.MeiryoRegular8;
                    btnCcw.Font = AppFont.MeiryoRegular8;
                    break;

                case Culture.CN:
                    btnCw.Font = AppFont.MicrosoftYaHeiRegular7;
                    btnCcw.Font = AppFont.MicrosoftYaHeiRegular7;
                    break;
            }

			switch (mode)
			{
				default:
				case 0:		//制御無し

					grpVelocity.Enabled = false;
					grpPosition1.Enabled = false;
					grpPosition2.Enabled = false;
					grpTeaching1.Enabled = false;
					grpTeaching2.Enabled = false;
					grpAcceleration.Enabled = false;
					grpDeceleration.Enabled = false;
					grpServoCommand.Enabled = false;

					if (mode == 14)
					{
						grpServoCommand.Enabled = true;
						btnServoOn.Enabled = false;
						btnCw.Enabled = false;
						btnCcw.Enabled = false;
						btnStop.Enabled = false;
					}

					PositionSettingEnable(false);

					btnCw.Text = UserText.CtlJogControlCw;
					btnCcw.Text = UserText.CtlJogControlCcw;

					CtrlModeIndex = 0;
					TimerJog.Enabled = false;

					break;

				case 1:		//位置制御

					grpVelocity.Enabled = true;
					grpPosition1.Enabled = true;
					grpTeaching1.Enabled = false;
					grpTeaching2.Enabled = false;
					grpAcceleration.Enabled = true;
					grpDeceleration.Enabled = true;
					grpServoCommand.Enabled = true;

					grpPosition1.Visible = true;
					grpPosition2.Visible = true;
					grpTeaching1.Visible = false;
					grpTeaching2.Visible = false;

					ctlNumTargetPosition1.IntValue = Convert.ToInt32(lblTeaching1.Text);
					ctlNumTargetPosition2.IntValue = Convert.ToInt32(lblTeaching2.Text);

					grpVelocity.Text = UserText.CtlJogControlTargetVelocity;

					PositionSettingEnable(true);

					btnCw.Text = UserText.CtlJogControlMove;
					btnCcw.Text = UserText.CtlJogControlMove;

					btnServoOn.Enabled = true;
					btnCw.Enabled = true;
					btnCcw.Enabled = true;
					btnStop.Enabled = true;

					ctlNumTargetVelocity.SingedEnable = false;		//20160328 add

                    switch (Culture.Name)
                    {
                        default:
                        case Culture.JP:
                            btnCw.Font = AppFont.MeiryoRegular8;
                            btnCcw.Font = AppFont.MeiryoRegular8;
                            break;

                        case Culture.US:
                            btnCw.Font = AppFont.MeiryoRegular8;
                            btnCcw.Font = AppFont.MeiryoRegular8;
                            break;

                        case Culture.CN:
                            btnCw.Font = AppFont.MicrosoftYaHeiRegular8;
                            btnCcw.Font = AppFont.MicrosoftYaHeiRegular8;
                            break;
                    }

					CtrlModeIndex = 1;

					RadioButton_CheckedChanged(null, null);

					break;

				case 2:		//速度制御

					grpVelocity.Enabled = true;
					grpPosition1.Enabled = false;
					grpPosition2.Enabled = false;
					grpTeaching1.Enabled = true;
					grpTeaching2.Enabled = true;
					grpAcceleration.Enabled = true;
					grpDeceleration.Enabled = true;
					grpServoCommand.Enabled = true;

					grpPosition1.Visible = false;
					grpPosition2.Visible = false;
					grpTeaching1.Visible = true;
					grpTeaching2.Visible = true;

					lblTeaching1.Text = ctlNumTargetPosition1.IntValue.ToString();
					lblTeaching2.Text = ctlNumTargetPosition2.IntValue.ToString();

					grpVelocity.Text = UserText.CtlJogControlCommandVelocity;

					PositionSettingEnable(false);

					btnCw.Text = UserText.CtlJogControlCw;
					btnCcw.Text = UserText.CtlJogControlCcw;

					btnServoOn.Enabled = true;
					btnCw.Enabled = true;
					btnCcw.Enabled = true;
					btnStop.Enabled = true;

					ctlNumTargetVelocity.SingedEnable = true;		//20160328 add

					CtrlModeIndex = 2;
					TimerJog.Enabled = false;

					break;

				case 3:		//電流制御

					grpVelocity.Enabled = true;
					grpPosition1.Enabled = false;
					grpPosition2.Enabled = false;
					grpTeaching1.Enabled = false;
					grpTeaching2.Enabled = false;
					grpAcceleration.Enabled = false;
					grpDeceleration.Enabled = false;
					grpServoCommand.Enabled = true;

					grpVelocity.Text = UserText.CtlJogControlCommandCurrent;

					PositionSettingEnable(false);

					btnCw.Text = UserText.CtlJogControlCw;
					btnCcw.Text = UserText.CtlJogControlCcw;

					btnServoOn.Enabled = true;
					btnCw.Enabled = true;
					btnCcw.Enabled = true;
					btnStop.Enabled = true;

					ctlNumTargetVelocity.SingedEnable = true;		//20160328 add

					CtrlModeIndex = 3;
					TimerJog.Enabled = false;

					break;

                //↓↓↓ KASHIYAMA Mode 20190930 Kimura add ↓↓↓ 

                case 7: // I/O速度制御

                    if (Properties.Settings.Default.PASSWORD_KASHIYAMA == true)
                    {
                        grpVelocity.Enabled = false;
                        grpPosition1.Enabled = false;
                        grpPosition2.Enabled = false;
                        grpTeaching1.Enabled = false;
                        grpTeaching2.Enabled = false;
                        grpAcceleration.Enabled = false;
                        grpDeceleration.Enabled = false;
                        grpServoCommand.Enabled = true;

                        PositionSettingEnable(false);

                        btnServoOn.Enabled = true;
                        btnCw.Enabled = true;
                        btnCcw.Enabled = true;
                        btnStop.Enabled = true;

                        CtrlModeIndex = 4;
                        TimerJog.Enabled = false;
                    }

                    break;
                
                //↑↑↑ KASHIYAMA Mode 20190930 Kimura add ↑↑↑

			}

			UpdateCheckBox();
		}

		private void PositionSettingEnable(bool enable)
		{
			rdoInc.Enabled = enable;
			rdoAbs.Enabled = enable;

			chkContinue.Enabled = enable;
			lblContinue.Enabled = enable;
			numContinue.Enabled = enable;
		}

		public void SetServoFeedBack()
		{
			PositionText = CMonitor.GetParameter(CParamID.FeedbackPosition).ToString();
			VelocityText = CMonitor.GetParameter(CParamID.FeedbackVelocity).ToString();
			CurrentText = (CMonitor.GetParameter(CParamID.FeedbackCurrent) * 0.01).ToString("F2");

			OverLoadText = (CMonitor.GetParameter(CParamID.OverLoadMonitor) * 0.1).ToString("F1");
			DriverTempText = (CMonitor.GetParameter(CParamID.DriverTemp) * 0.1).ToString("F1");
			PowerVoltageText = (CMonitor.GetParameter(CParamID.PowerVoltage) * 0.1).ToString("F1");

            //↓↓↓ KASHIYAMA Mode 20190624 Kimura add ↓↓↓
            if (Properties.Settings.Default.PASSWORD_KASHIYAMA == true)
            {
                OutputPowerText = (CMonitor.GetParameter(CParamID.OutputPower) * 0.1).ToString("F1");
            }
            //↑↑↑ KASHIYAMA Mode 20190624 Kimura add ↑↑↑

			int sts = CMonitor.GetParameter(CParamID.ServoStatus);
			int alm = CMonitor.GetParameter(CParamID.AlarmCode);

			SetSvaStatus(sts, alm);
		}

		public void SetTargetData()
		{
			int mode = CMonitor.GetParameter(CParamID.ControlMode);

			switch (mode)
			{
				default:
				case 1:
					ctlNumTargetVelocity.IntValue = CMonitor.GetParameter(CParamID.TargetVelocity);
					break;
				case 2:
					ctlNumTargetVelocity.IntValue = CMonitor.GetParameter(CParamID.CommandVelocity);
					break;
				case 3:
					ctlNumTargetVelocity.IntValue = CMonitor.GetParameter(CParamID.CommandCurrent);
					break;
			}

			ctlNumTargetPosition1.IntValue = CMonitor.GetParameter(CParamID.TargetPosition);

			ctlNumTargetAcceleration.IntValue = CMonitor.GetParameter(CParamID.TargetAcceleration);
			ctlNumTargetDeceleration.IntValue = CMonitor.GetParameter(CParamID.TargetDeceleration);

			UpdateAccDccTime();
		}

		public void SetTargetData(int mode)
		{
			switch (mode)
			{
				default:
				case 1:
					ctlNumTargetVelocity.IntValue = CMonitor.GetParameter(CParamID.TargetVelocity);
					break;
				case 2:
					ctlNumTargetVelocity.IntValue = CMonitor.GetParameter(CParamID.CommandVelocity);
					break;
				case 3:
					ctlNumTargetVelocity.IntValue = CMonitor.GetParameter(CParamID.CommandCurrent);
					break;
			}

			//制御モード変更で目標位置は更新しない
			//ctlNumTargetPosition.IntValue = CMonitor.TargetPosition;

			UpdateAccDccTime();

		}

		public int TargetVelocity		//20160315 add
		{
			set { ctlNumTargetVelocity.IntValue = value; }
			get { return ctlNumTargetVelocity.IntValue; }
		}

		private void UpdateCheckBox()
		{
			chkButtonLock.Checked = IsButtonLock[CtrlModeIndex];
			chkHardStop.Checked = IsHardStop[CtrlModeIndex];
			chkVelocityLimit.Checked = IsVelocityLimit[CtrlModeIndex];
		}

		public void UpdateAccDccTime()
		{
			int vel = ctlNumTargetVelocity.IntValue;
			int acc = ctlNumTargetAcceleration.IntValue;
			int dcc = ctlNumTargetDeceleration.IntValue;

			vel = (int)Math.Abs(vel);
			lblAccTime.Text = (vel / (acc * 10.0) * 1000.0).ToString("F1") + " [msec]";
			lblDccTime.Text = (vel / (dcc * 10.0) * 1000.0).ToString("F1") + " [msec]";
		}

		private bool ServoCommandClear = new bool();

		public void SetSvaStatus(int status, int almcode)
		{
			if ((status & 0x08) == 0x08)
			{
				lblSvdAlarm.Visible = true;
				lblSvdAlarm.Text = "Alarm Code " + almcode.ToString();

				if (!ServoCommandClear)
				{
					int cmd = 0;	//ServoCommand All Clear
		
					if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) { return; }

					ServoCommandClear = true;
				}
				//JogStop();		//20160715 add
			}
			else
			{
				ServoCommandClear = false;
				lblSvdAlarm.Visible = false;
			}

			switch (ServoStatusIndex)
			{
				default:
				case 0:
					break;

				case 1:
					status = status >> 8;
					break;

				case 2:
					status = status >> 16;
					break;

				case 3:
					status = status >> 24;
					break;
			}


			if ((status & 0x01) == 0x01)
			{
				ServoOnBackColor = Color.Red;
			}
			else
			{
				ServoOnBackColor = Color.Black;
			}

			if ((status & 0x02) == 0x02)
			{
				ProfileBackColor = Color.Red;
			}
			else
			{
				ProfileBackColor = Color.Black;
			}

			if ((status & 0x04) == 0x04)
			{
				InPositionBackColor = Color.Red;
			}
			else
			{
				InPositionBackColor = Color.Black;
			}

			if ((status & 0x08) == 0x08)
			{
				FaultBackColor = Color.Red;
			}
			else
			{
				FaultBackColor = Color.Black;
			}

			if ((status & 0x10) == 0x10)
			{
				ForwardLimitBackColor = Color.Red;
			}
			else
			{
				ForwardLimitBackColor = Color.Black;
			}

			if ((status & 0x20) == 0x20)
			{
				ReverseLimitBackColor = Color.Red;
			}
			else
			{
				ReverseLimitBackColor = Color.Black;
			}

			if ((status & 0x40) == 0x40)
			{
				TorqueLimitBackColor = Color.Red;
			}
			else
			{
				TorqueLimitBackColor = Color.Black;
			}

			if ((status & 0x80) == 0x80)
			{
				VelocityLimitBackColor = Color.Red;
			}
			else
			{
				VelocityLimitBackColor = Color.Black;
			}
		
		}

		private void UpdateStatusLabel()
		{
			if (NetType == NET_TYPE.SV_NET)
			{
				switch (ServoStatusIndex)
				{
					case 0:
						lblServoOn.Text = UserText.CtlJogControlServoOn;				//b0
						lblProfile.Text = UserText.CtlJogControlProfile;				//b1
						lblInPosition.Text = UserText.CtlJogControlInposition;			//b2
						lblFault.Text = UserText.CtlJogControlAlarm;					//b3
						lblForwardLimit.Text = UserText.CtlJogControlPositiveLimit;		//b4
						lblReverseLimit.Text = UserText.CtlJogControlNegativeLimit;		//b5
						lblTorqueLimit.Text = UserText.CtlJogControlTorqueLimit;		//b6
						lblVelocityLimit.Text = UserText.CtlJogControlVelocityLimit;	//b7

						lblStatusPage.Text = "1/4";

						break;

					case 1:

						lblServoOn.Text = UserText.CtlJogControlPositionErrorOver;		//b8
						lblProfile.Text = UserText.CtlJogControlServoReady;				//b9
						lblInPosition.Text = UserText.CtlJogControlHoming;				//b10
						lblFault.Text = UserText.CtlJogControlSecondGain;				//b11
						lblForwardLimit.Text = UserText.CtlJogControlBattWarning;		//b12
						lblReverseLimit.Text = UserText.CtlJogControlPowerVoltageError;	//b13
						lblTorqueLimit.Text = UserText.CtlJogControlStopVelocity;		//b14
                        lblVelocityLimit.Text = UserText.CtlJogControlServoStatusB15;	//b15 KASHIYAMA Mode 20190624 Kimura update

						lblStatusPage.Text = "2/4";

						break;

					case 2:

						lblServoOn.Text = UserText.CtlJogControlMechBrake;				//b16
						lblProfile.Text = UserText.CtlJogControlReserve;				//b17
                        lblInPosition.Text = UserText.CtlJogControlServoStatusB18;		//b18 KASHIYAMA Mode 20190624 Kimura update
                        lblFault.Text = UserText.CtlJogControlServoStatusB19;			//b19 KASHIYAMA Mode 20190624 Kimura update
                        lblForwardLimit.Text = UserText.CtlJogControlServoStatusB20;	//b20 KASHIYAMA Mode 20190624 Kimura update
                        lblReverseLimit.Text = UserText.CtlJogControlServoStatusB21;	//b21 KASHIYAMA Mode 20190624 Kimura update
                        lblTorqueLimit.Text = UserText.CtlJogControlServoStatusB22;		//b22 KASHIYAMA Mode 20190624 Kimura update
						lblVelocityLimit.Text = UserText.CtlJogControlReserve;			//b23

						lblStatusPage.Text = "3/4";

						break;

					case 3:

						lblServoOn.Text = UserText.CtlJogControlReachTargetPosition;	//b24
						lblProfile.Text = UserText.CtlJogControlReserve;				//b25
						lblInPosition.Text = UserText.CtlJogControlReserve;				//b26
						lblFault.Text = UserText.CtlJogControlReserve;					//b27
						lblForwardLimit.Text = UserText.CtlJogControlReserve;			//b28
						lblReverseLimit.Text = UserText.CtlJogControlReserve;			//b29
						lblTorqueLimit.Text = UserText.CtlJogControlReserve;			//b30
						lblVelocityLimit.Text = UserText.CtlJogControlReserve;			//b31

						lblStatusPage.Text = "4/4";

						break;
				}
			}
			else if (NetType == NET_TYPE.EtherCAT)
			{
				switch (ServoStatusIndex)
				{
					case 0:

						lblServoOn.Text = UserText.CtlJogControlEcatMainPowerOff;
						lblProfile.Text = UserText.CtlJogControlEcatServoOn;
						lblInPosition.Text = UserText.CtlJogControlEcatServoReady;
						lblFault.Text = UserText.CtlJogControlEcatAlarm;
						lblForwardLimit.Text = UserText.CtlJogControlEcatMainPowerOn;
						lblReverseLimit.Text = UserText.CtlJogControlEcatQStop;
						lblTorqueLimit.Text = UserText.CtlJogControlEcatInitEnd;
						lblVelocityLimit.Text = UserText.CtlJogControlEcatWarning;
						break;

					case 1:

						lblServoOn.Text = UserText.CtlJogControlEcatManufacturerReserve;
						lblProfile.Text = UserText.CtlJogControlEcatRemote;
						lblInPosition.Text = UserText.CtlJogControlEcatTarget;
						lblFault.Text = UserText.CtlJogControlEcatInternalLimit;			//内部制限機能有効
						lblForwardLimit.Text = UserText.CtlJogControlEcatIgnoreTarget;
						lblReverseLimit.Text = UserText.CtlJogControlEcatPositionErrorOver;
						lblTorqueLimit.Text = UserText.CtlJogControlEcatManufacturerReserve;
						lblVelocityLimit.Text = UserText.CtlJogControlEcatManufacturerReserve;

						break;

				}
			}
		}

		public void CollapseJogControl()
		{
			tabJogControl.Visible = true;
			tabJogControl.Dock = DockStyle.Fill;

			tabJogControl.TabPages[0].Controls.Add(pnlCommand);
			tabJogControl.TabPages[1].Controls.Add(pnlSetting);

			pnlCommand.Location = new Point(0, 0);
			pnlSetting.Location = new Point(0, 0);
		}

		public void ExpandJogControl()
		{
			this.Controls.Add(pnlCommand);
			this.Controls.Add(pnlSetting);

			pnlCommand.Location = new Point(0, 0);
			pnlSetting.Location = new Point(230, 0);

			tabJogControl.Visible = false;
		}

		public void JogStopped()
		{
			JogStop();
		}

		#region Feedback Text Property

		public string PositionText
		{
			set
			{
				txtPosition.Text = value;
			}

			get
			{
				return txtPosition.Text;
			}
		}

		public string VelocityText
		{
			set
			{
				txtVelocity.Text = value;
			}
		}

		public string CurrentText
		{
			set
			{
				txtCurrent.Text = value;
			}
		}

		public string OverLoadText
		{
			set
			{
				txtOverload.Text = value;
			}
		}

		public string DriverTempText
		{
			set
			{
				txtDriverTemp.Text = value;
			}
		}

		public string PowerVoltageText
		{
			set
			{
				txtPowerVoltage.Text = value;
			}
		}

        //↓↓↓ KASHIYAMA Mode 20190624 Kimura add ↓↓↓
        public string OutputPowerText
        {
            set
            {
                txtOutputPower.Text = value;
            }
        }
        //↑↑↑ KASHIYAMA Mode 20190624 Kimura add ↑↑↑

		#endregion

		#region Status Label Property

		public string PositionUnitLabel
		{
			set
			{
				lblPosUnit.Text = value;
			}
		}

		public string VelocityUnitLabel
		{
			set
			{
				lblVelUnit.Text = value;
			}
		}

		public string CurrentUnitLabel
		{
			set
			{
				lblCurUnit.Text = value;
			}
		}

		public string ServoOnText
		{
			set { lblServoOn.Text = value; }
		}

		public string ProfileText
		{
			set { lblProfile.Text = value; }
		}

		public string InPositionText
		{
			set { lblInPosition.Text = value; }
		}

		public string FaultText
		{
			set { lblFault.Text = value; }
		}

		public string ForwardLimitText
		{
			set { lblForwardLimit.Text = value; }
		}

		public string ReverseLimitText
		{
			set { lblReverseLimit.Text = value; }
		}

		public string TorqueLimitText
		{
			set { lblTorqueLimit.Text = value; }
		}

		public string VelocityLimitText
		{
			set { lblVelocityLimit.Text = value; }
		}

		#endregion

		#region Status BackColor

		public Color ServoOnBackColor
		{
			get
			{
				return picServoOn.BackColor;
			}

			set
			{
				picServoOn.BackColor = value;

				if (!IsBoldStatusLabel) { return; }

				if (value == Color.Red)
				{
                    switch (Culture.Name)
                    {
                        default:
                        case Culture.JP:
                            lblServoOn.Font = AppFont.MeiryoBold7;
                            break;

                        case Culture.US:
                            lblServoOn.Font = AppFont.MeiryoBold7;
                            break;

                        case Culture.CN:
                            lblServoOn.Font = AppFont.MicrosoftYaHeiBold7;
                            break;
                    }
				}
				else
				{
                    switch (Culture.Name)
                    {
                        default:
                        case Culture.JP:
                            lblServoOn.Font = AppFont.MeiryoRegular7;
                            break;

                        case Culture.US:
                            lblServoOn.Font = AppFont.MeiryoRegular7;
                            break;

                        case Culture.CN:
                            lblServoOn.Font = AppFont.MicrosoftYaHeiRegular7;
                            break;
                    }
				}
			}
		}

		public Color ProfileBackColor
		{
			get
			{
				return picProfile.BackColor;
			}

			set
			{
				picProfile.BackColor = value;

				if (!IsBoldStatusLabel) { return; }

				if (value == Color.Red)
				{
                    switch (Culture.Name)
                    {
                        default:
                        case Culture.JP:
                            lblProfile.Font = AppFont.MeiryoBold7;
                            break;

                        case Culture.US:
                            lblProfile.Font = AppFont.MeiryoBold7;
                            break;

                        case Culture.CN:
                            lblProfile.Font = AppFont.MicrosoftYaHeiBold7;
                            break;
                    }
				}
				else
				{
                    switch (Culture.Name)
                    {
                        default:
                        case Culture.JP:
                            lblProfile.Font = AppFont.MeiryoRegular7;
                            break;

                        case Culture.US:
                            lblProfile.Font = AppFont.MeiryoRegular7;
                            break;

                        case Culture.CN:
                            lblProfile.Font = AppFont.MicrosoftYaHeiRegular7;
                            break;
                    }
				}
			}
		}

		public Color InPositionBackColor
		{
			get
			{
				return picInPosition.BackColor;
			}

			set
			{
				picInPosition.BackColor = value;

				if (!IsBoldStatusLabel) { return; }

				if (value == Color.Red)
				{
                    switch (Culture.Name)
                    {
                        default:
                        case Culture.JP:
                            lblInPosition.Font = AppFont.MeiryoBold7;
                            break;

                        case Culture.US:
                            lblInPosition.Font = AppFont.MeiryoBold7;
                            break;

                        case Culture.CN:
                            lblInPosition.Font = AppFont.MicrosoftYaHeiBold7;
                            break;
                    }
				}
				else
				{
                    switch (Culture.Name)
                    {
                        default:
                        case Culture.JP:
                            lblInPosition.Font = AppFont.MeiryoRegular7;
                            break;

                        case Culture.US:
                            lblInPosition.Font = AppFont.MeiryoRegular7;
                            break;

                        case Culture.CN:
                            lblInPosition.Font = AppFont.MicrosoftYaHeiRegular7;
                            break;
                    }
				}
			}
		}

		public Color FaultBackColor
		{
			get
			{
				return picFault.BackColor;
			}

			set
			{
				picFault.BackColor = value;

				if (!IsBoldStatusLabel) { return; }

				if (value == Color.Red)
				{
                    switch (Culture.Name)
                    {
                        default:
                        case Culture.JP:
                            lblFault.Font = AppFont.MeiryoBold7;
                            break;

                        case Culture.US:
                            lblFault.Font = AppFont.MeiryoBold7;
                            break;

                        case Culture.CN:
                            lblFault.Font = AppFont.MicrosoftYaHeiBold7;
                            break;
                    }
				}
				else
				{
                    switch (Culture.Name)
                    {
                        default:
                        case Culture.JP:
                            lblFault.Font = AppFont.MeiryoRegular7;
                            break;

                        case Culture.US:
                            lblFault.Font = AppFont.MeiryoRegular7;
                            break;

                        case Culture.CN:
                            lblFault.Font = AppFont.MicrosoftYaHeiRegular7;
                            break;
                    }
				}
			}
		}

		public Color ForwardLimitBackColor
		{
			get
			{
				return picForwardLimit.BackColor;
			}

			set
			{
				picForwardLimit.BackColor = value;

				if (!IsBoldStatusLabel) { return; }

				if (value == Color.Red)
				{
                    switch (Culture.Name)
                    {
                        default:
                        case Culture.JP:
                            lblForwardLimit.Font = AppFont.MeiryoBold7;
                            break;

                        case Culture.US:
                            lblForwardLimit.Font = AppFont.MeiryoBold7;
                            break;

                        case Culture.CN:
                            lblForwardLimit.Font = AppFont.MicrosoftYaHeiBold7;
                            break;
                    }
				}
				else
				{
                    switch (Culture.Name)
                    {
                        default:
                        case Culture.JP:
                            lblForwardLimit.Font = AppFont.MeiryoRegular7;
                            break;

                        case Culture.US:
                            lblForwardLimit.Font = AppFont.MeiryoRegular7;
                            break;

                        case Culture.CN:
                            lblForwardLimit.Font = AppFont.MicrosoftYaHeiRegular7;
                            break;
                    }
				}
			}
		}

		public Color ReverseLimitBackColor
		{
			get
			{
				return picReverseLimit.BackColor;
			}

			set
			{
				picReverseLimit.BackColor = value;

				if (!IsBoldStatusLabel) { return; }

				if (value == Color.Red)
				{
                    switch (Culture.Name)
                    {
                        default:
                        case Culture.JP:
                            lblReverseLimit.Font = AppFont.MeiryoBold7;
                            break;

                        case Culture.US:
                            lblReverseLimit.Font = AppFont.MeiryoBold7;
                            break;

                        case Culture.CN:
                            lblReverseLimit.Font = AppFont.MicrosoftYaHeiBold7;
                            break;
                    }
				}
				else
				{
                    switch (Culture.Name)
                    {
                        default:
                        case Culture.JP:
                            lblReverseLimit.Font = AppFont.MeiryoRegular7;
                            break;

                        case Culture.US:
                            lblReverseLimit.Font = AppFont.MeiryoRegular7;
                            break;

                        case Culture.CN:
                            lblReverseLimit.Font = AppFont.MicrosoftYaHeiRegular7;
                            break;
                    }
				}
			}
		}

		public Color TorqueLimitBackColor
		{
			get
			{
				return picTorqueLimit.BackColor;
			}

			set
			{
				picTorqueLimit.BackColor = value;

				if (!IsBoldStatusLabel) { return; }

				if (value == Color.Red)
				{
                    switch (Culture.Name)
                    {
                        default:
                        case Culture.JP:
                            lblTorqueLimit.Font = AppFont.MeiryoBold7;
                            break;

                        case Culture.US:
                            lblTorqueLimit.Font = AppFont.MeiryoBold7;
                            break;

                        case Culture.CN:
                            lblTorqueLimit.Font = AppFont.MicrosoftYaHeiBold7;
                            break;
                    }
				}
				else
				{
                    switch (Culture.Name)
                    {
                        default:
                        case Culture.JP:
                            lblTorqueLimit.Font = AppFont.MeiryoRegular7;
                            break;

                        case Culture.US:
                            lblTorqueLimit.Font = AppFont.MeiryoRegular7;
                            break;

                        case Culture.CN:
                            lblTorqueLimit.Font = AppFont.MicrosoftYaHeiRegular7;
                            break;
                    }
				}
			}
		}

		public Color VelocityLimitBackColor
		{
			get
			{
				return picVelocityLimit.BackColor;
			}

			set
			{
				picVelocityLimit.BackColor = value;

				if (!IsBoldStatusLabel) { return; }

				if (value == Color.Red)
				{
                    switch (Culture.Name)
                    {
                        default:
                        case Culture.JP:
                            lblVelocityLimit.Font = AppFont.MeiryoBold7;
                            break;

                        case Culture.US:
                            lblVelocityLimit.Font = AppFont.MeiryoBold7;
                            break;

                        case Culture.CN:
                            lblVelocityLimit.Font = AppFont.MicrosoftYaHeiBold7;
                            break;
                    }
				}
				else
				{
                    switch (Culture.Name)
                    {
                        default:
                        case Culture.JP:
                            lblVelocityLimit.Font = AppFont.MeiryoRegular7;
                            break;

                        case Culture.US:
                            lblVelocityLimit.Font = AppFont.MeiryoRegular7;
                            break;

                        case Culture.CN:
                            lblVelocityLimit.Font = AppFont.MicrosoftYaHeiRegular7;
                            break;
                    }
				}
			}
		}

		#endregion

		#region Button Event

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			if (!MainForm.IsUsbConnectBlink) { return; }

			SetTargetData();

			DataProgressDialog DataMsg = new DataProgressDialog();

			DataMsg.Start(UserText.CtlJogControlTargetReading, JogControlForm.ThisForm.Location, this.Size, false);
			DataMsg.Maximum = 10;

			for (int i = 0; i < 10; i++)
			{
				DataMsg.PerformStep();
				Thread.Sleep(10);
			}

			Thread.Sleep(500);

			DataMsg.Close();
		}

		private void btnGo2_Click(object sender, EventArgs e)
		{
			if (ServoStatusIndex >= MAX_STS_INDEX)
			{
				ServoStatusIndex = 0;
			}
			else
			{
				ServoStatusIndex++;
			}

			UpdateStatusLabel();
			lblDummy.Select();
		}

		private void btnBack2_Click(object sender, EventArgs e)
		{
			if (ServoStatusIndex <= MIN_STS_INDEX)
			{
				ServoStatusIndex = MAX_STS_INDEX;
			}
			else
			{
				ServoStatusIndex--;
			}

			UpdateStatusLabel();
			lblDummy.Select();
		}

		private void btnServoOn_Click(object sender, EventArgs e)
		{
			if (!MainForm.IsUsbConnectBlink) { return; }

			int cmd = CMonitor.GetParameter(CParamID.ServoCommand);
			
			cmd &= ~0x0030;		//Hard Stop & Smooth Stop Clear
			if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) { return; }

			cmd |= 0x0001;

			if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) { return; }
		}

		private void btnServoOff_Click(object sender, EventArgs e)
		{
			TimerJog.Enabled = false;

			if (!MainForm.IsUsbConnectBlink) { return; }

			int cmd = CMonitor.GetParameter(CParamID.ServoCommand);
			int sts = new int();
	
			cmd |= 0x0020;		//Smooth Stop bit Set

			if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) { return; }

			Thread.Sleep(100);

			CDataTool.SetNow(CDataTool.JOG_TIME);

			while ((sts & 0x4000) == 0x0000)
			{
				if (!CCommandTx.ReadSvNet(CParamID.ServoStatus, ref sts)) { return; }

				if (CDataTool.IsTimerLimit(CDataTool.JOG_TIME, 10)) { break; }
			}

			cmd &= ~0x0033;		//Servo On & Profile Start bit Clear & Smooth Stop & Hard Stop bit Clear
			
			if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) { return; }	
	
		}

		private void btnAlarmReset_Click(object sender, EventArgs e)
		{
			if (!MainForm.IsUsbConnectBlink) { return; }

			btnServoOff.PerformClick();

			int cmd = CMonitor.GetParameter(CParamID.ServoCommand);

			cmd |= 0x0008;

			if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) { return; }

			Thread.Sleep(100);

			cmd &= ~0x0008;

			if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) { return; }
		}

		private void btnPositionClear_Click(object sender, EventArgs e)
		{
			if (!MainForm.IsUsbConnectBlink) { return; }

			if ((CMonitor.GetParameter(CParamID.ServoStatus) & 0x01) == 0x01)		//サーボオン中はポジションリセット禁止
			{
				UserMessageBox.JogControlPositionResetWarning1();
				return;
			}

			if (DialogResult.No == UserMessageBox.JogControlPositionResetWarning2())
			{
				return;
			}

			int cmd = CMonitor.GetParameter(CParamID.ServoCommand);

			cmd |= 0x4000;

			if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) { return; }

			Thread.Sleep(100);

			cmd &= ~0x4000;

			if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) { return; }
		}

		private void btnCw_MouseDown(object sender, MouseEventArgs e)
		{
			if (!MainForm.IsUsbConnectBlink) { return; }

			NowPosition = CMonitor.GetParameter(CParamID.FeedbackPosition);

			int mode = CMonitor.GetParameter(CParamID.ControlMode);

			if (mode == 1)
			{
				JogCtrl(false);
			}
			else
			{
				JogCtrl(false);
			}
		}

		private void btnCcw_MouseDown(object sender, MouseEventArgs e)
		{
			if (!MainForm.IsUsbConnectBlink) { return; }

			NowPosition = CMonitor.GetParameter(CParamID.FeedbackPosition);

			int mode = CMonitor.GetParameter(CParamID.ControlMode);

			if (mode == 1)
			{
				JogCtrl(false);
			}
			else
			{
				JogCtrl(true);
			}
		}

		private void btnCw_MouseUp(object sender, MouseEventArgs e)
		{
			if (!IsButtonLock[CtrlModeIndex])
			{
				JogStop();
			}
		}

		private void btnCcw_MouseUp(object sender, MouseEventArgs e)
		{
			if (!IsButtonLock[CtrlModeIndex])
			{
				JogStop();
			}
		}

		private void btnSmoothStop_Click(object sender, EventArgs e)
		{
			JogStop();
		}

		private void JogCtrl(bool ccw)
		{
			int sts = CMonitor.GetParameter(CParamID.ServoStatus);

			if ((sts & 0x0001) == 0x0000) { TimerJog.Enabled = false; return; }			//20170711 update サーボオフなら終了
			if ((sts & 0x01F8) != 0x0000) { TimerJog.Enabled = false; return; }			//20170711 update アラームまたはリミット検出なら終了

			int mode = CMonitor.GetParameter(CParamID.ControlMode);
			int cmd = CMonitor.GetParameter(CParamID.ServoCommand);
			int ctrl = CMonitor.GetParameter(CParamID.ControlSwitch);

			int vel = ctlNumTargetVelocity.IntValue;
			int pos = new int();
			int pos1 = ctlNumTargetPosition1.IntValue;
			int pos2 = ctlNumTargetPosition2.IntValue;
			int acc = ctlNumTargetAcceleration.IntValue;
			int dcc = ctlNumTargetDeceleration.IntValue;

			cmd &= ~0x0030;		//Hard Stop & Smooth Stop Clear
			if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) { return; }

			PositionCCW = ccw;

			switch (mode)
			{
				default:
				case 0:			//制御無し

					break;

				case 1:			//位置制御

					if (rdoInc.Checked)
					{
						//相対位置
						if (pos1 == 0) { TimerJog.Enabled = false; return; }				//20170711 add TimerJog.Enabled = false;

						if (ccw)
						{
							//往復運転時の戻り移動（移動開始地点に戻る）
							pos = NowPosition;
						}
						else
						{
							//往復運転時の目標値移動
							pos = NowPosition + pos1;
						}
					}
					else
					{
						//絶対位置
						//if ((pos1 - pos2) == 0) { TimerJog.Enabled = false; return; }		//20190311 del
						
						if (ccw)
						{
							//絶対位置往復運転＋CCW（戻り位置）移動時に目標位置1と目標位置2の差が0なら停止処理
							if ((pos1 - pos2) == 0) { TimerJog.Enabled = false; return; }	//20190311 add

							//往復運転時の絶対目標位置2へ移動
							pos = pos2;
						}
						else
						{
							//往復運転時の絶対目標位置1へ移動
							pos = pos1;
						}
					}

					if (vel == 0) { TimerJog.Enabled = false; return; }		//20160328 add
					vel = Math.Abs(vel);									//20160328 add

					if (!CCommandTx.WriteSvNet(CParamID.TargetPosition, pos)) { return; }

					if (!CCommandTx.WriteSvNet(CParamID.TargetVelocity, vel)) { return; }

					if (!CCommandTx.WriteSvNet(CParamID.TargetAcceleration, acc)) { return; }

					if (!CCommandTx.WriteSvNet(CParamID.TargetDeceleration, dcc)) { return; }

					ctrl |= 0x0002;		//Profile bit auto Clear

					if (!CCommandTx.WriteSvNet(CParamID.ControlSwitch, ctrl)) { return; }

					cmd |= 0x0002;		//Profile Start bit Set

					if (IsVelocityLimit[CtrlModeIndex])		//20190522 add
					{
						cmd |= 0x0080;		//Smoothing On
					}
					else
					{
						cmd &= ~0x0080;		//Smoothing Off
					}

					if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) { return; }

					WaitCnt = 0;

					if (chkContinue.Checked && chkContinue.Enabled)
					{
						TimerJog.Enabled = true;
					}
					else
					{
						TimerJog.Enabled = false;
					}

					break;

				case 2:			//速度制御

					if (ccw) { vel = -vel; }

					if (IsVelocityLimit[CtrlModeIndex])
					{
						cmd |= 0x0080;		//Smoothing On
					}
					else
					{
						cmd &= ~0x0080;		//Smoothing Off
					}

					if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) { return; }

					if (!CCommandTx.WriteSvNet(CParamID.TargetAcceleration, acc)) { return; }

					if (!CCommandTx.WriteSvNet(CParamID.TargetDeceleration, dcc)) { return; }

					if (!CCommandTx.WriteSvNet(CParamID.CommandVelocity, vel)) { return; }

					break;

				case 3:			//電流制御

					if (ccw) { vel = -vel; }

					if (!CCommandTx.WriteSvNet(CParamID.CommandCurrent, vel)) { return; }
					break;
			}

		}

		private void JogStop()
		{
			TimerJog.Enabled = false;

			if (!MainForm.IsUsbConnectBlink) { return; }

			int cmd = CMonitor.GetParameter(CParamID.ServoCommand);
			int sts = CMonitor.GetParameter(CParamID.ServoStatus);
			
			cmd &= ~0x0002;		//Profile Start bit Clear

			if (IsHardStop[CtrlModeIndex])
			{
				cmd |= 0x0010;		//Hard Stop bit Set
			}
			else
			{
				cmd |= 0x0020;		//Smooth Stop bit Set
			}

			if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) { return; }

			if (CMonitor.GetParameter(CParamID.ControlMode) == 1 && (sts & 0x01) == 0x01 )
			{
				//位置制御かつサーボオンなら停止後に位置制御に変更。（ドライバは停止処理で速度制御モードに変更される為）
				TimerJogStop.Enabled = true;
			}
		}

		private void btnTeaching1_Click(object sender, EventArgs e)
		{
			if (!MainForm.IsUsbConnectBlink) { return; }

			lblTeaching1.Text = PositionText;
		}

		private void btnTeaching2_Click(object sender, EventArgs e)
		{
			if (!MainForm.IsUsbConnectBlink) { return; }

			lblTeaching2.Text = PositionText;
		}

		private void btnAbsReset_Click(object sender, EventArgs e)
		{
			if (!MainForm.IsUsbConnectBlink) { return; }

			if ((CMonitor.GetParameter(CParamID.ServoStatus) & 0x01) == 0x01)		//サーボオン中はABSエンコーダリセット禁止
			{
				UserMessageBox.JogControlAbsEncderResetWarning1();
				return;
			}

			if (DialogResult.No == UserMessageBox.JogControlAbsEncderResetWarning2())
			{
				return;
			}

			int cmd = CMonitor.GetParameter(CParamID.ServoCommand);

			cmd |= 0x8000;

			if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) { return; }

			Thread.Sleep(100);

			cmd &= ~0x8000;

			if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) { return; }
		}

		private void btnAnalogZeorAdjust_Click(object sender, EventArgs e)
		{
			if (!MainForm.IsUsbConnectBlink) { return; }

			if ((CMonitor.GetParameter(CParamID.ServoStatus) & 0x01) == 0x01)		//サーボオン中はABSエンコーダリセット禁止
			{
				UserMessageBox.JogControlAnalogZeroAdjustWarning1();
				return;
			}

			if (DialogResult.No == UserMessageBox.JogControlAnalogZeroAdjustWarning2())
			{
				return;
			}

			int cmd = CMonitor.GetParameter(CParamID.ServoCommand);

			cmd |= 0x0100;

			if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) { return; }

			Thread.Sleep(100);

			cmd &= ~0x0100;

			if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) { return; }
		}

		#endregion

		#region Jog Parameter

		private void chkButtonLock_CheckedChanged(object sender, EventArgs e)
		{
			IsButtonLock[CtrlModeIndex] = chkButtonLock.Checked;

			if (chkButtonLock.Checked)
			{
				chkButtonLock.BackColor = AppFont.ActiveBackColor;
			}
			else
			{
				chkButtonLock.BackColor = AppFont.NormalBackColor;
			}
		}

		private void chkHardStop_CheckedChanged(object sender, EventArgs e)
		{
			IsHardStop[CtrlModeIndex] = chkHardStop.Checked;

			if (chkHardStop.Checked)
			{
				chkHardStop.BackColor = AppFont.ActiveBackColor;
			}
			else
			{
				chkHardStop.BackColor = AppFont.NormalBackColor;
			}
		}

		private void chkVelocityLimit_CheckedChanged(object sender, EventArgs e)
		{
			IsVelocityLimit[CtrlModeIndex] = chkVelocityLimit.Checked;

			if (chkVelocityLimit.Checked)
			{
				chkVelocityLimit.BackColor = AppFont.ActiveBackColor;
			}
			else
			{
				chkVelocityLimit.BackColor = AppFont.NormalBackColor;
			}
		}

		private void chkContinue_CheckedChanged(object sender, EventArgs e)
		{
			if (chkContinue.Checked)
			{
				chkContinue.BackColor = AppFont.ActiveBackColor;

				if (rdoAbs.Checked)
				{
					grpPosition2.Enabled = true;
				}
			}
			else
			{
				chkContinue.BackColor = AppFont.NormalBackColor;

				grpPosition2.Enabled = false;
			}

		}

		private void numContinue_ValueChanged(object sender, EventArgs e)
		{
			ContinueTime = (int)numContinue.Value;
		}

		#endregion

		#region Timer Event

		private void TimerJog_Tick(object sender, EventArgs e)
		{
			if (MainForm.IsUsbWait) { return; }

			if (!MainForm.IsUsbConnect)
			{
				TimerJog.Enabled = false;
				return;
			}

			int sts = new int();

			sts = CMonitor.GetParameter(CParamID.ServoStatus);

			if ((sts & 0x02) == 0x02)
			{
				//プロファイルON
				WaitCnt = 0;
			}
			else
			{
				int wait = (int)numContinue.Value / 100 + 1;

				WaitCnt++;

				if (WaitCnt < wait) { return; }

				WaitCnt = 0;

				if(!chkContinue.Checked )
				{
					TimerJog.Enabled = false;
					return;
				}

				if (PositionCCW)
				{
					JogCtrl(false);
				}
				else
				{
					JogCtrl(true);
				}
			}
		}

		private void TimerJogStop_Tick(object sender, EventArgs e)
		{
			if (!MainForm.IsUsbConnect)
			{
				TimerJogStop.Enabled = false;
				return;
			}

			int sts = new int();

			sts = CMonitor.GetParameter(CParamID.ServoStatus);

			if ((sts & 0x4000) == 0x4000)
			{
				//停止速度状態
				TimerJogStop.Enabled = false;

				//サーボオン処理で位置制御モードへ
				btnServoOn.PerformClick();
			}
		}

		#endregion

		private void CtlJogControl_Click(object sender, EventArgs e)
		{
			lblDummy.Select();
		}

		private void RadioButton_CheckedChanged(object sender, EventArgs e)
		{
			
            switch (Culture.Name)
            {
                default:
                case Culture.JP:
                    rdoAbs.Font = AppFont.MeiryoRegular8;
                    rdoInc.Font = AppFont.MeiryoRegular8;
                    break;

                case Culture.US:
                    rdoAbs.Font = AppFont.MeiryoRegular8;
                    rdoInc.Font = AppFont.MeiryoRegular8;
                    break;

                case Culture.CN:
                    rdoAbs.Font = AppFont.MicrosoftYaHeiRegular8;
                    rdoInc.Font = AppFont.MicrosoftYaHeiRegular8;
                    break;
            }
            
            rdoAbs.ForeColor = Color.Black;
			rdoInc.ForeColor = Color.Black;
			rdoAbs.BackColor = AppFont.NormalBackColor;
			rdoInc.BackColor = AppFont.NormalBackColor;
			
			if (rdoAbs.Checked)
			{
				rdoAbs.BackColor = AppFont.ActiveBackColor;

				IsPositionAbs = true;

				if (chkContinue.Checked && CtrlModeIndex == 1)
				{
					grpPosition2.Enabled = true;
				}
			}

			if (rdoInc.Checked)
			{
				rdoInc.BackColor = AppFont.ActiveBackColor;

				grpPosition2.Enabled = false;

				IsPositionAbs = false;
			}

			TimerJog.Enabled = false;		//20190311 相対位置・絶対位置の切り替え時、往復動作停止
		}

		private void CheckBox_CheckStateChanged(object sender, EventArgs e)
		{
			CheckBox chk = (CheckBox)sender;

			if (chk.Checked)
			{

                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        chk.Font = AppFont.MeiryoBold8;
                        break;

                    case Culture.US:
                        chk.Font = AppFont.MeiryoBold8;
                        break;

                    case Culture.CN:
                        chk.Font = AppFont.MicrosoftYaHeiBold8;
                        break;
                }

                chk.ForeColor = AppFont.ActiveForeColor;
			}
			else
			{
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        chk.Font = AppFont.MeiryoRegular8;
                        break;

                    case Culture.US:
                        chk.Font = AppFont.MeiryoRegular8;
                        break;

                    case Culture.CN:
                        chk.Font = AppFont.MicrosoftYaHeiRegular8;
                        break;
                }
                
                chk.ForeColor = AppFont.NormalForeColor;
			}

		}

		private void Control_MouseHover(object sender, EventArgs e)
		{
			JogControlForm.ThisForm.Select();
		}

        #region カルチャリソース切り替え

        public void ViewCultureResouceChanged()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CtlJogControl));
            
            toolTipJog.SetToolTip(this, resources.GetString("$this.ToolTip"));
            toolTipJog.SetToolTip(btnBack2, resources.GetString("btnBack2.ToolTip"));
            toolTipJog.SetToolTip(btnGo2, resources.GetString("btnGo2.ToolTip"));
            toolTipJog.SetToolTip(button1, resources.GetString("button1.ToolTip"));
            toolTipJog.SetToolTip(ctlNumTargetAcceleration, resources.GetString("ctlNumTargetAcceleration.ToolTip"));
            toolTipJog.SetToolTip(ctlNumTargetDeceleration, resources.GetString("ctlNumTargetDeceleration.ToolTip"));
            toolTipJog.SetToolTip(ctlNumTargetPosition1, resources.GetString("ctlNumTargetPosition1.ToolTip"));
            toolTipJog.SetToolTip(ctlNumTargetPosition2, resources.GetString("ctlNumTargetPosition2.ToolTip"));
            toolTipJog.SetToolTip(ctlNumTargetVelocity, resources.GetString("ctlNumTargetVelocity.ToolTip"));
            toolTipJog.SetToolTip(fpnlFeedback, resources.GetString("fpnlFeedback.ToolTip"));
            toolTipJog.SetToolTip(fpnlStatus, resources.GetString("fpnlStatus.ToolTip"));
            toolTipJog.SetToolTip(grpAcceleration, resources.GetString("grpAcceleration.ToolTip"));
            toolTipJog.SetToolTip(grpDeceleration, resources.GetString("grpDeceleration.ToolTip"));
            toolTipJog.SetToolTip(grpPosition1, resources.GetString("grpPosition1.ToolTip"));
            toolTipJog.SetToolTip(grpPosition2, resources.GetString("grpPosition2.ToolTip"));
            toolTipJog.SetToolTip(grpServoCommand, resources.GetString("grpServoCommand.ToolTip"));
            toolTipJog.SetToolTip(grpServoFeedBack, resources.GetString("grpServoFeedBack.ToolTip"));
            toolTipJog.SetToolTip(grpServoStatus, resources.GetString("grpServoStatus.ToolTip"));
            toolTipJog.SetToolTip(grpVelocity, resources.GetString("grpVelocity.ToolTip"));
            toolTipJog.SetToolTip(lblAccTime, resources.GetString("lblAccTime.ToolTip"));
            toolTipJog.SetToolTip(lblCurrent, resources.GetString("lblCurrent.ToolTip"));
            toolTipJog.SetToolTip(lblCurUnit, resources.GetString("lblCurUnit.ToolTip"));
            toolTipJog.SetToolTip(lblDccTime, resources.GetString("lblDccTime.ToolTip"));
            toolTipJog.SetToolTip(lblDriverTemp, resources.GetString("lblDriverTemp.ToolTip"));
            toolTipJog.SetToolTip(lblDriverTempUnit, resources.GetString("lblDriverTempUnit.ToolTip"));
            toolTipJog.SetToolTip(lblFault, resources.GetString("lblFault.ToolTip"));
            toolTipJog.SetToolTip(lblForwardLimit, resources.GetString("lblForwardLimit.ToolTip"));
            toolTipJog.SetToolTip(lblInPosition, resources.GetString("lblInPosition.ToolTip"));
            toolTipJog.SetToolTip(lblOverLoad, resources.GetString("lblOverLoad.ToolTip"));
            toolTipJog.SetToolTip(lblPosition, resources.GetString("lblPosition.ToolTip"));
            toolTipJog.SetToolTip(lblPosUnit, resources.GetString("lblPosUnit.ToolTip"));
            toolTipJog.SetToolTip(lblPowerVoltage, resources.GetString("lblPowerVoltage.ToolTip"));
            toolTipJog.SetToolTip(lblPowerVoltageUnit, resources.GetString("lblPowerVoltageUnit.ToolTip"));
            toolTipJog.SetToolTip(lblProfile, resources.GetString("lblProfile.ToolTip"));
            toolTipJog.SetToolTip(lblReverseLimit, resources.GetString("lblReverseLimit.ToolTip"));
            toolTipJog.SetToolTip(lblSep1, resources.GetString("lblSep1.ToolTip"));
            toolTipJog.SetToolTip(lblSep2, resources.GetString("lblSep2.ToolTip"));
            toolTipJog.SetToolTip(lblServoOn, resources.GetString("lblServoOn.ToolTip"));
            toolTipJog.SetToolTip(lblStatusPage, resources.GetString("lblStatusPage.ToolTip"));
            toolTipJog.SetToolTip(lblSvdAlarm, resources.GetString("lblSvdAlarm.ToolTip"));
            toolTipJog.SetToolTip(lblTarget, resources.GetString("lblTarget.ToolTip"));
            toolTipJog.SetToolTip(lblTorqueLimit, resources.GetString("lblTorqueLimit.ToolTip"));
            toolTipJog.SetToolTip(lblVelocity, resources.GetString("lblVelocity.ToolTip"));
            toolTipJog.SetToolTip(lblVelocityLimit, resources.GetString("lblVelocityLimit.ToolTip"));
            toolTipJog.SetToolTip(lblVelUnit, resources.GetString("lblVelUnit.ToolTip"));
            toolTipJog.SetToolTip(llblOverLoadUnit, resources.GetString("llblOverLoadUnit.ToolTip"));
            toolTipJog.SetToolTip(picFault, resources.GetString("picFault.ToolTip"));
            toolTipJog.SetToolTip(picForwardLimit, resources.GetString("picForwardLimit.ToolTip"));
            toolTipJog.SetToolTip(picInPosition, resources.GetString("picInPosition.ToolTip"));
            toolTipJog.SetToolTip(picProfile, resources.GetString("picProfile.ToolTip"));
            toolTipJog.SetToolTip(picReverseLimit, resources.GetString("picReverseLimit.ToolTip"));
            toolTipJog.SetToolTip(picServoOn, resources.GetString("picServoOn.ToolTip"));
            toolTipJog.SetToolTip(picTorqueLimit, resources.GetString("picTorqueLimit.ToolTip"));
            toolTipJog.SetToolTip(picVelocityLimit, resources.GetString("picVelocityLimit.ToolTip"));
            toolTipJog.SetToolTip(pnlCommand, resources.GetString("pnlCommand.ToolTip"));
            toolTipJog.SetToolTip(pnlSetting, resources.GetString("pnlSetting.ToolTip"));
            toolTipJog.SetToolTip(tabJogControl, resources.GetString("tabJogControl.ToolTip"));
            toolTipJog.SetToolTip(tabJogSetting, resources.GetString("tabJogSetting.ToolTip"));
            toolTipJog.SetToolTip(tabPage1, resources.GetString("tabPage1.ToolTip"));
			toolTipJog.SetToolTip(tabPage2, resources.GetString("tabPage2.ToolTip"));
			toolTipJog.SetToolTip(tabPage3, resources.GetString("tabPage3.ToolTip"));
			toolTipJog.SetToolTip(tabPageCommand, resources.GetString("tabPageCommand.ToolTip"));
            toolTipJog.SetToolTip(tabPageSetting, resources.GetString("tabPageSetting.ToolTip"));
            toolTipJog.SetToolTip(txtCurrent, resources.GetString("txtCurrent.ToolTip"));
            toolTipJog.SetToolTip(txtDriverTemp, resources.GetString("txtDriverTemp.ToolTip"));
            toolTipJog.SetToolTip(txtOverload, resources.GetString("txtOverload.ToolTip"));
            toolTipJog.SetToolTip(txtPosition, resources.GetString("txtPosition.ToolTip"));
            toolTipJog.SetToolTip(txtPowerVoltage, resources.GetString("txtPowerVoltage.ToolTip"));
            toolTipJog.SetToolTip(txtVelocity, resources.GetString("txtVelocity.ToolTip"));
            toolTipJog.SetToolTip(lblDummy, resources.GetString("ulblDummy.ToolTip"));
            toolTipJog.SetToolTip(btnAlarmReset, resources.GetString("btnAlarmReset.ToolTip"));
            toolTipJog.SetToolTip(btnServoOff, resources.GetString("btnServoOff.ToolTip"));
            toolTipJog.SetToolTip(btnServoOn, resources.GetString("btnServoOn.ToolTip"));
            toolTipJog.SetToolTip(btnStop, resources.GetString("btnStop.ToolTip"));
            toolTipJog.SetToolTip(btnCcw, resources.GetString("btnCcw.ToolTip"));
            toolTipJog.SetToolTip(btnCw, resources.GetString("btnCw.ToolTip"));
            toolTipJog.SetToolTip(chkContinue, resources.GetString("chkContinue.ToolTip"));
            toolTipJog.SetToolTip(rdoInc, resources.GetString("rdoInc.ToolTip"));
            toolTipJog.SetToolTip(rdoAbs, resources.GetString("rdoAbs.ToolTip"));
            toolTipJog.SetToolTip(chkHardStop, resources.GetString("chkHardStop.ToolTip"));
            toolTipJog.SetToolTip(lblContinue, resources.GetString("lblContinue.ToolTip"));
            toolTipJog.SetToolTip(numContinue, resources.GetString("numContinue.ToolTip"));
            toolTipJog.SetToolTip(btnUpdate, resources.GetString("btnUpdate.ToolTip"));
            toolTipJog.SetToolTip(chkButtonLock, resources.GetString("chkButtonLock.ToolTip"));
            toolTipJog.SetToolTip(btnPositionClear, resources.GetString("btnPositionClear.ToolTip"));
			toolTipJog.SetToolTip(chkVelocityLimit, resources.GetString("chkVelocityLimit.ToolTip"));
			toolTipJog.SetToolTip(btnAbsReset, resources.GetString("btnAbsReset.ToolTip"));
			toolTipJog.SetToolTip(btnAnalogZeorAdjust, resources.GetString("btnAnalogZeorAdjust.ToolTip"));

            llblOverLoadUnit.Font = (Font)resources.GetObject("llblOverLoadUnit.Font");
            lblCurUnit.Font = (Font)resources.GetObject("lblCurUnit.Font");
            lblDriverTempUnit.Font = (Font)resources.GetObject("lblDriverTempUnit.Font");
            lblPosUnit.Font = (Font)resources.GetObject("lblPosUnit.Font");
            lblVelUnit.Font = (Font)resources.GetObject("lblVelUnit.Font");
            lblPowerVoltageUnit.Font = (Font)resources.GetObject("lblPowerVoltageUnit.Font");
            btnCw.Font = (Font)resources.GetObject("btnCw.Font");
            btnCcw.Font = (Font)resources.GetObject("btnCcw.Font");
            txtCurrent.Font = (Font)resources.GetObject("txtCurrent.Font");
            txtDriverTemp.Font = (Font)resources.GetObject("txtDriverTemp.Font");
            txtOverload.Font = (Font)resources.GetObject("txtOverload.Font");
            txtPosition.Font = (Font)resources.GetObject("txtPosition.Font");
            txtPowerVoltage.Font = (Font)resources.GetObject("txtPowerVoltage.Font");
            txtVelocity.Font = (Font)resources.GetObject("txtVelocity.Font");
            lblStatusPage.Font = (Font)resources.GetObject("lblStatusPage.Font");
            lblSvdAlarm.Font = (Font)resources.GetObject("lblSvdAlarm.Font");
            btnAlarmReset.Font = (Font)resources.GetObject("btnAlarmReset.Font");
            lblFault.Font = (Font)resources.GetObject("lblFault.Font");
            lblInPosition.Font = (Font)resources.GetObject("lblInPosition.Font");
            grpServoCommand.Font = (Font)resources.GetObject("grpServoCommand.Font");
            btnServoOff.Font = (Font)resources.GetObject("btnServoOff.Font");
            btnServoOn.Font = (Font)resources.GetObject("btnServoOn.Font");
            lblServoOn.Font = (Font)resources.GetObject("lblServoOn.Font");
            tabPageCommand.Font = (Font)resources.GetObject("tabPageCommand.Font");
            tabPageSetting.Font = (Font)resources.GetObject("tabPageSetting.Font");
            grpServoStatus.Font = (Font)resources.GetObject("grpServoStatus.Font");
            lblTorqueLimit.Font = (Font)resources.GetObject("lblTorqueLimit.Font");
            grpServoFeedBack.Font = (Font)resources.GetObject("grpServoFeedBack.Font");
            lblProfile.Font = (Font)resources.GetObject("lblProfile.Font");
            lblPosition.Font = (Font)resources.GetObject("lblPosition.Font");
            btnPositionClear.Font = (Font)resources.GetObject("btnPositionClear.Font");
            btnStop.Font = (Font)resources.GetObject("btnStop.Font");
            chkHardStop.Font = (Font)resources.GetObject("chkHardStop.Font");
            lblDriverTemp.Font = (Font)resources.GetObject("lblDriverTemp.Font");
            btnBack2.Font = (Font)resources.GetObject("btnBack2.Font");
            ctlNumTargetAcceleration.UnitFont = (Font)resources.GetObject("ctlNumTargetAcceleration.UnitFont");
            grpAcceleration.Font = (Font)resources.GetObject("grpAcceleration.Font");
            lblAccTime.Font = (Font)resources.GetObject("lblAccTime.Font");
			tabPage1.Font = (Font)resources.GetObject("tabPage1.Font");
			tabPage2.Font = (Font)resources.GetObject("tabPage2.Font");
			tabPage3.Font = (Font)resources.GetObject("tabPage3.Font");
			chkContinue.Font = (Font)resources.GetObject("chkContinue.Font");
            lblContinue.Font = (Font)resources.GetObject("lblContinue.Font");
            lblTarget.Font = (Font)resources.GetObject("lblTarget.Font");
            btnGo2.Font = (Font)resources.GetObject("btnGo2.Font");
            lblForwardLimit.Font = (Font)resources.GetObject("lblForwardLimit.Font");
            chkButtonLock.Font = (Font)resources.GetObject("chkButtonLock.Font");
            ctlNumTargetDeceleration.UnitFont = (Font)resources.GetObject("ctlNumTargetDeceleration.UnitFont");
            grpDeceleration.Font = (Font)resources.GetObject("grpDeceleration.Font");
            lblDccTime.Font = (Font)resources.GetObject("lblDccTime.Font");
            ctlNumTargetPosition1.UnitFont = (Font)resources.GetObject("ctlNumTargetPosition1.UnitFont");
            ctlNumTargetPosition2.UnitFont = (Font)resources.GetObject("ctlNumTargetPosition2.UnitFont");
            grpPosition1.Font = (Font)resources.GetObject("grpPosition1.Font");
            grpPosition2.Font = (Font)resources.GetObject("grpPosition2.Font");
            btnUpdate.Font = (Font)resources.GetObject("btnUpdate.Font");
            ctlNumTargetAcceleration.TitleFont = (Font)resources.GetObject("ctlNumTargetAcceleration.TitleFont");
            ctlNumTargetDeceleration.TitleFont = (Font)resources.GetObject("ctlNumTargetDeceleration.TitleFont");
            ctlNumTargetPosition1.TitleFont = (Font)resources.GetObject("ctlNumTargetPosition1.TitleFont");
            ctlNumTargetPosition2.TitleFont = (Font)resources.GetObject("ctlNumTargetPosition2.TitleFont");
            ctlNumTargetVelocity.TitleFont = (Font)resources.GetObject("ctlNumTargetVelocity.TitleFont");
            ctlNumTargetVelocity.UnitFont = (Font)resources.GetObject("ctlNumTargetVelocity.UnitFont");
            grpVelocity.Font = (Font)resources.GetObject("grpVelocity.Font");
            rdoInc.Font = (Font)resources.GetObject("rdoInc.Font");
            rdoAbs.Font = (Font)resources.GetObject("rdoAbs.Font");
            lblReverseLimit.Font = (Font)resources.GetObject("lblReverseLimit.Font");
            lblVelocity.Font = (Font)resources.GetObject("lblVelocity.Font");
            lblVelocityLimit.Font = (Font)resources.GetObject("lblVelocityLimit.Font");
            chkVelocityLimit.Font = (Font)resources.GetObject("chkVelocityLimit.Font");
            lblOverLoad.Font = (Font)resources.GetObject("lblOverLoad.Font");
            lblCurrent.Font = (Font)resources.GetObject("lblCurrent.Font");
            lblPowerVoltage.Font = (Font)resources.GetObject("lblPowerVoltage.Font");
            tabJogControl.Font = (Font)resources.GetObject("tabJogControl.Font");
			grpTeaching1.Font = (Font)resources.GetObject("grpTeaching1.Font");
			grpTeaching2.Font = (Font)resources.GetObject("grpTeaching2.Font");
			btnTeaching1.Font = (Font)resources.GetObject("btnTeaching1.Font");
			btnTeaching2.Font = (Font)resources.GetObject("btnTeaching2.Font");
			lblTeaching1.Font = (Font)resources.GetObject("lblTeaching1.Font");
			lblTeaching2.Font = (Font)resources.GetObject("lblTeaching2.Font");
			btnAbsReset.Font = (Font)resources.GetObject("btnAbsReset.Font");
			btnAnalogZeorAdjust.Font = (Font)resources.GetObject("btnAnalogZeorAdjust.Font");

            llblOverLoadUnit.Text = resources.GetString("llblOverLoadUnit.Text");
            lblCurUnit.Text = resources.GetString("lblCurUnit.Text");
            lblDriverTempUnit.Text = resources.GetString("lblDriverTempUnit.Text");
            lblPosUnit.Text = resources.GetString("lblPosUnit.Text");
            lblVelUnit.Text = resources.GetString("lblVelUnit.Text");
            lblPowerVoltageUnit.Text = resources.GetString("lblPowerVoltageUnit.Text");
            btnCw.Text = resources.GetString("btnCw.Text");
            btnCcw.Text = resources.GetString("btnCcw.Text");
            txtCurrent.Text = resources.GetString("txtCurrent.Text");
            txtDriverTemp.Text = resources.GetString("txtDriverTemp.Text");
            txtOverload.Text = resources.GetString("txtOverload.Text");
            txtPosition.Text = resources.GetString("txtPosition.Text");
            txtPowerVoltage.Text = resources.GetString("txtPowerVoltage.Text");
            txtVelocity.Text = resources.GetString("txtVelocity.Text");
            lblStatusPage.Text = resources.GetString("lblStatusPage.Text");
            lblSvdAlarm.Text = resources.GetString("lblSvdAlarm.Text");
            btnAlarmReset.Text = resources.GetString("btnAlarmReset.Text");
            lblFault.Text = resources.GetString("lblFault.Text");
            lblInPosition.Text = resources.GetString("lblInPosition.Text");
            grpServoCommand.Text = resources.GetString("grpServoCommand.Text");
            btnServoOff.Text = resources.GetString("btnServoOff.Text");
            btnServoOn.Text = resources.GetString("btnServoOn.Text");
            lblServoOn.Text = resources.GetString("lblServoOn.Text");
            tabPageCommand.Text = resources.GetString("tabPageCommand.Text");
            tabPageSetting.Text = resources.GetString("tabPageSetting.Text");
            grpServoStatus.Text = resources.GetString("grpServoStatus.Text");
            lblTorqueLimit.Text = resources.GetString("lblTorqueLimit.Text");
            grpServoFeedBack.Text = resources.GetString("grpServoFeedBack.Text");
            lblProfile.Text = resources.GetString("lblProfile.Text");
            lblPosition.Text = resources.GetString("lblPosition.Text");
            btnPositionClear.Text = resources.GetString("btnPositionClear.Text");
            btnStop.Text = resources.GetString("btnStop.Text");
            chkHardStop.Text = resources.GetString("chkHardStop.Text");
            lblDriverTemp.Text = resources.GetString("lblDriverTemp.Text");
            btnBack2.Text = resources.GetString("btnBack2.Text");
            ctlNumTargetAcceleration.UnitText = resources.GetString("ctlNumTargetAcceleration.UnitText");
            grpAcceleration.Text = resources.GetString("grpAcceleration.Text");
            lblAccTime.Text = resources.GetString("lblAccTime.Text");
			tabPage1.Text = resources.GetString("tabPage1.Text");
			tabPage2.Text = resources.GetString("tabPage2.Text");
			tabPage3.Text = resources.GetString("tabPage3.Text");
			chkContinue.Text = resources.GetString("chkContinue.Text");
            lblContinue.Text = resources.GetString("lblContinue.Text");
            lblTarget.Text = resources.GetString("lblTarget.Text");
            btnGo2.Text = resources.GetString("btnGo2.Text");
            lblForwardLimit.Text = resources.GetString("lblForwardLimit.Text");
            chkButtonLock.Text = resources.GetString("chkButtonLock.Text");
            ctlNumTargetDeceleration.UnitText = resources.GetString("ctlNumTargetDeceleration.UnitText");
            grpDeceleration.Text = resources.GetString("grpDeceleration.Text");
            lblDccTime.Text = resources.GetString("lblDccTime.Text");
            ctlNumTargetPosition1.UnitText = resources.GetString("ctlNumTargetPosition1.UnitText");
            ctlNumTargetPosition2.UnitText = resources.GetString("ctlNumTargetPosition2.UnitText");
            grpPosition1.Text = resources.GetString("grpPosition1.Text");
            grpPosition2.Text = resources.GetString("grpPosition2.Text");
            btnUpdate.Text = resources.GetString("btnUpdate.Text");
            ctlNumTargetAcceleration.TitleText = resources.GetString("ctlNumTargetAcceleration.TitleText");
            ctlNumTargetDeceleration.TitleText = resources.GetString("ctlNumTargetDeceleration.TitleText");
            ctlNumTargetPosition1.TitleText = resources.GetString("ctlNumTargetPosition1.TitleText");
            ctlNumTargetPosition2.TitleText = resources.GetString("ctlNumTargetPosition2.TitleText");
            ctlNumTargetVelocity.TitleText = resources.GetString("ctlNumTargetVelocity.TitleText");
            ctlNumTargetVelocity.UnitText = resources.GetString("ctlNumTargetVelocity.UnitText");
            grpVelocity.Text = resources.GetString("grpVelocity.Text");
            rdoInc.Text = resources.GetString("rdoInc.Text");
            rdoAbs.Text = resources.GetString("rdoAbs.Text");
            lblReverseLimit.Text = resources.GetString("lblReverseLimit.Text");
            lblVelocity.Text = resources.GetString("lblVelocity.Text");
            lblVelocityLimit.Text = resources.GetString("lblVelocityLimit.Text");
            chkVelocityLimit.Text = resources.GetString("chkVelocityLimit.Text");
            lblOverLoad.Text = resources.GetString("lblOverLoad.Text");
            lblCurrent.Text = resources.GetString("lblCurrent.Text");
            lblPowerVoltage.Text = resources.GetString("lblPowerVoltage.Text");
            tabJogControl.Text = resources.GetString("tabJogControl.Text");
			grpTeaching1.Text = resources.GetString("grpTeaching1.Text");
			grpTeaching2.Text = resources.GetString("grpTeaching2.Text");
			btnTeaching1.Text = resources.GetString("btnTeaching1.Text");
			btnTeaching2.Text = resources.GetString("btnTeaching2.Text");
			lblTeaching1.Text = resources.GetString("lblTeaching1.Text");
			lblTeaching2.Text = resources.GetString("lblTeaching2.Text");
			btnAbsReset.Text = resources.GetString("btnAbsReset.Text");
			btnAnalogZeorAdjust.Text = resources.GetString("btnAnalogZeorAdjust.Text");
        }

        #endregion

        #region タブオーナードロー

        /// <summary>
        /// ジョグタブオーナードローイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabJogControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tab = (TabControl)sender;
            string txt = tab.TabPages[e.Index].Text;

            Font font;

            LinearGradientBrush gb = new LinearGradientBrush(e.Bounds,
                                                             Color.Cyan,
                                                             Color.DodgerBlue,
                                                             LinearGradientMode.Vertical);

            //タブのテキストと背景を描画するためのブラシを決定する           
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                //選択されているタブ
                font = new Font(e.Font.FontFamily, e.Font.Size, FontStyle.Bold);
                e.Graphics.FillRectangle(gb, e.Bounds);
            }
            else
            {
                //選択されていないタブ
                font = new Font(e.Font.FontFamily, e.Font.Size, FontStyle.Regular);
                e.Graphics.FillRectangle(Brushes.WhiteSmoke, e.Bounds);
            }

            StringFormat sf = new StringFormat();

            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            e.Graphics.DrawString(txt, font, Brushes.Navy, e.Bounds, sf);

            gb.Dispose();
        }

        #endregion



    }
}
