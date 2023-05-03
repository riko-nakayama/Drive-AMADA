using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
	public partial class ServoMonitorForm : Form
	{
		static private Point FormPosition = new Point(0, 0);
        static private Size FormSize = new Size(420, 240);

		static private ServoMonitorForm _ThisForm;

		private bool _IsExist = new bool();

		private const int MAX_STS_INDEX = 3;
		private const int MIN_STS_INDEX = 0;

		private NET_TYPE _NetType = NET_TYPE.SV_NET;		//0：SV-NET 1：EtherCAT

		private int ServoStatusIndex = 0;

		public ServoMonitorForm()
		{
			InitializeComponent();

			_ThisForm = this;
			_IsExist = true;
		}

		static public ServoMonitorForm ThisForm
		{
			get { return _ThisForm; }
		}

		public bool IsExist
		{
			get { return _IsExist; }
		}

		public NET_TYPE NetType
		{
			set { _NetType = value; UpdateStatusLabel(); }
			get { return _NetType; }
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

		public void InitFormLayout()
		{
			if (ThisForm == null) { return; }

			//MdiClientの取得
			MdiClient mc = MainForm.ThisForm.GetMdiClient();

			int w = mc.ClientRectangle.Width;
			int h = mc.ClientRectangle.Height;

			ThisForm.Location = new Point(0, 0);
			ThisForm.Size = new Size(w, this.Height);

			ThisForm.WindowState = FormWindowState.Normal;
			ThisForm.ControlBox = false;
		}

		public void SetServoFeedBack()
		{
			txtPosition.Text = CMonitor.GetParameter(CParamID.FeedbackPosition).ToString();
			txtVelocity.Text = CMonitor.GetParameter(CParamID.FeedbackVelocity).ToString();
			txtCurrent.Text = (CMonitor.GetParameter(CParamID.FeedbackCurrent) * 0.01).ToString("F2");

			txtOverload.Text = (CMonitor.GetParameter(CParamID.OverLoadMonitor) * 0.1).ToString("F1");
			txtDriverTemp.Text = (CMonitor.GetParameter(CParamID.DriverTemp) * 0.1).ToString("F1");
			txtPowerVoltage.Text = (CMonitor.GetParameter(CParamID.PowerVoltage) * 0.1).ToString("F1");

            //↓↓↓ KASHIYAMA Mode 20190624 Kimura add ↓↓↓
            if (Properties.Settings.Default.PASSWORD_KASHIYAMA == true)
            {
                txtOutputPower.Text = (CMonitor.GetParameter(CParamID.OutputPower) * 0.1).ToString("F1");
            }
            //↑↑↑ KASHIYAMA Mode 20190624 Kimura add ↑↑↑

			int sts = CMonitor.GetParameter(CParamID.ServoStatus);
			int alm = CMonitor.GetParameter(CParamID.AlarmCode);

			SetSvaStatus(sts, alm);
		}

		public void SetSvaStatus(int status, int almcode)
		{
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

			PictureBox[] pic_arr = new PictureBox[8];

			pic_arr[0] = picBit0;
			pic_arr[1] = picBit1;
			pic_arr[2] = picBit2;
			pic_arr[3] = picBit3;
			pic_arr[4] = picBit4;
			pic_arr[5] = picBit5;
			pic_arr[6] = picBit6;
			pic_arr[7] = picBit7;

			for (int i = 0, b = 1; i < pic_arr.Length; i++, b<<=1)
			{
				if ((status & b) == b)
				{
					pic_arr[i].BackColor = Color.Red;
				}
				else
				{
					pic_arr[i].BackColor = Color.Black;
				}
			}
		
		}

		private void ServoMonitorForm_Load(object sender, EventArgs e)
		{
			if (FormPosition.X > 0)
			{
				this.Size = FormSize;
				this.Location = FormPosition;
			}

			UpdateStatusLabel();

            //↓↓↓ KASHIYAMA Mode 20190624 Kimura add ↓↓↓
            if (Properties.Settings.Default.PASSWORD_KASHIYAMA == true)
            {
                fpnlKashiyamaMonitor.Visible = true;
            }
            //↑↑↑ KASHIYAMA Mode 20190624 Kimura add ↑↑↑

			lblDummy.Select();
		}

		private void ServoMonitorForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.WindowState != FormWindowState.Minimized)
			{
				FormPosition = this.Location;
			}

			FormSize = this.Size;

			_IsExist = false;
		}

		private void UpdateStatusLabel()
		{
			if (NetType == NET_TYPE.SV_NET)
			{
				switch (ServoStatusIndex)
				{
					case 0:
						lblBit0.Text = UserText.CtlJogControlServoOn;				//b0
						lblBit1.Text = UserText.CtlJogControlProfile;				//b1
						lblBit2.Text = UserText.CtlJogControlInposition;			//b2
						lblBit3.Text = UserText.CtlJogControlAlarm;					//b3
						lblBit4.Text = UserText.CtlJogControlPositiveLimit;			//b4
						lblBit5.Text = UserText.CtlJogControlNegativeLimit;			//b5
						lblBit6.Text = UserText.CtlJogControlTorqueLimit;			//b6
						lblBit7.Text = UserText.CtlJogControlVelocityLimit;			//b7

						lblB0.Text = "Bit0";
						lblB1.Text = "Bit1";
						lblB2.Text = "Bit2";
						lblB3.Text = "Bit3";
						lblB4.Text = "Bit4";
						lblB5.Text = "Bit5";
						lblB6.Text = "Bit6";
						lblB7.Text = "Bit7";

						lblStatusPage.Text = "1/4";

						break;

					case 1:

						lblBit0.Text = UserText.CtlJogControlPositionErrorOver;		//b8
						lblBit1.Text = UserText.CtlJogControlServoReady;			//b9
						lblBit2.Text = UserText.CtlJogControlHoming;				//b10
						lblBit3.Text = UserText.CtlJogControlSecondGain;			//b11
						lblBit4.Text = UserText.CtlJogControlBattWarning;			//b12
						lblBit5.Text = UserText.CtlJogControlPowerVoltageError;		//b13
						lblBit6.Text = UserText.CtlJogControlStopVelocity;			//b14
                        lblBit7.Text = UserText.CtlJogControlServoStatusB15;		//b15 KASHIYAMA Mode 20190624 Kimura update

						lblB0.Text = "Bit8";
						lblB1.Text = "Bit9";
						lblB2.Text = "Bit10";
						lblB3.Text = "Bit11";
						lblB4.Text = "Bit12";
						lblB5.Text = "Bit13";
						lblB6.Text = "Bit14";
						lblB7.Text = "Bit15";

						lblStatusPage.Text = "2/4";

						break;

					case 2:

						lblBit0.Text = UserText.CtlJogControlMechBrake;				//b16
						lblBit1.Text = UserText.CtlJogControlReserve;				//b17
                        lblBit2.Text = UserText.CtlJogControlServoStatusB18;		//b18 KASHIYAMA Mode 20190624 Kimura update
                        lblBit3.Text = UserText.CtlJogControlServoStatusB19;		//b19 KASHIYAMA Mode 20190624 Kimura update
                        lblBit4.Text = UserText.CtlJogControlServoStatusB20;		//b20 KASHIYAMA Mode 20190624 Kimura update
                        lblBit5.Text = UserText.CtlJogControlServoStatusB21;		//b21 KASHIYAMA Mode 20190624 Kimura update
                        lblBit6.Text = UserText.CtlJogControlServoStatusB22;		//b22 KASHIYAMA Mode 20190624 Kimura update
						lblBit7.Text = UserText.CtlJogControlReserve;				//b23

						lblB0.Text = "Bit16";
						lblB1.Text = "Bit17";
						lblB2.Text = "Bit18";
						lblB3.Text = "Bit19";
						lblB4.Text = "Bit20";
						lblB5.Text = "Bit21";
						lblB6.Text = "Bit22";
						lblB7.Text = "Bit23";

						lblStatusPage.Text = "3/4";

						break;

					case 3:

						lblBit0.Text = UserText.CtlJogControlReachTargetPosition;	//b24
						lblBit1.Text = UserText.CtlJogControlReserve;				//b25
						lblBit2.Text = UserText.CtlJogControlReserve;				//b26
						lblBit3.Text = UserText.CtlJogControlReserve;				//b27
						lblBit4.Text = UserText.CtlJogControlReserve;				//b28
						lblBit5.Text = UserText.CtlJogControlReserve;				//b29
						lblBit6.Text = UserText.CtlJogControlReserve;				//b30
						lblBit7.Text = UserText.CtlJogControlReserve;				//b31

						lblB0.Text = "Bit24";
						lblB1.Text = "Bit25";
						lblB2.Text = "Bit26";
						lblB3.Text = "Bit27";
						lblB4.Text = "Bit28";
						lblB5.Text = "Bit29";
						lblB6.Text = "Bit30";
						lblB7.Text = "Bit31";

						lblStatusPage.Text = "4/4";

						break;
				}
			}
			else if (NetType == NET_TYPE.EtherCAT)
			{
				switch (ServoStatusIndex)
				{
					case 0:

						lblBit0.Text = UserText.CtlJogControlEcatMainPowerOff;
						lblBit1.Text = UserText.CtlJogControlEcatServoOn;
						lblBit2.Text = UserText.CtlJogControlEcatServoReady;
						lblBit3.Text = UserText.CtlJogControlEcatAlarm;
						lblBit4.Text = UserText.CtlJogControlEcatMainPowerOn;
						lblBit5.Text = UserText.CtlJogControlEcatQStop;
						lblBit6.Text = UserText.CtlJogControlEcatInitEnd;
						lblBit7.Text = UserText.CtlJogControlEcatWarning;

						lblB0.Text = "Bit0";
						lblB1.Text = "Bit1";
						lblB2.Text = "Bit2";
						lblB3.Text = "Bit3";
						lblB4.Text = "Bit4";
						lblB5.Text = "Bit5";
						lblB6.Text = "Bit6";
						lblB7.Text = "Bit7";

						lblStatusPage.Text = "1/2";

						break;

					case 1:

						lblBit0.Text = UserText.CtlJogControlEcatManufacturerReserve;
						lblBit1.Text = UserText.CtlJogControlEcatRemote;
						lblBit2.Text = UserText.CtlJogControlEcatTarget;
						lblBit3.Text = UserText.CtlJogControlEcatInternalLimit;			//内部制限機能有効
						lblBit4.Text = UserText.CtlJogControlEcatIgnoreTarget;
						lblBit5.Text = UserText.CtlJogControlEcatPositionErrorOver;
						lblBit6.Text = UserText.CtlJogControlEcatManufacturerReserve;
						lblBit7.Text = UserText.CtlJogControlEcatManufacturerReserve;

						lblB0.Text = "Bit8";
						lblB1.Text = "Bit9";
						lblB2.Text = "Bit10";
						lblB3.Text = "Bit11";
						lblB4.Text = "Bit12";
						lblB5.Text = "Bit13";
						lblB6.Text = "Bit14";
						lblB7.Text = "Bit15";

						lblStatusPage.Text = "2/2";

						break;
				}
			}
		}

		private void btnNext_Click(object sender, EventArgs e)
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

		private void btnPrev_Click(object sender, EventArgs e)
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

        #region カルチャリソース切り替え

        //↓↓↓ ART HIKARI Mode 20181210 Kimura add ↓↓↓

        public void ViewCultureResouceChanged()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ServoMonitorForm));

            this.Font = (Font)resources.GetObject("$this.Font");

            grpStatus.Font = (Font)resources.GetObject("grpStatus.Font");
            grpServoFeedBack.Font = (Font)resources.GetObject("grpServoFeedBack.Font");
            lblPosition.Font = (Font)resources.GetObject("lblPosition.Font");
            lblVelocity.Font = (Font)resources.GetObject("lblVelocity.Font");
            lblCurrent.Font = (Font)resources.GetObject("lblCurrent.Font");
            lblOverLoad.Font = (Font)resources.GetObject("lblOverLoad.Font");
            lblDriverTemp.Font = (Font)resources.GetObject("lblDriverTemp.Font");
            lblPowerVoltage.Font = (Font)resources.GetObject("lblPowerVoltage.Font");
            
            this.Text = resources.GetString("$this.Text");

            grpStatus.Text = resources.GetString("grpStatus.Text");
            grpServoFeedBack.Text = resources.GetString("grpServoFeedBack.Text");
            lblPosition.Text = resources.GetString("lblPosition.Text");
            lblVelocity.Text = resources.GetString("lblVelocity.Text");
            lblCurrent.Text = resources.GetString("lblCurrent.Text");
            lblOverLoad.Text = resources.GetString("lblOverLoad.Text");
            lblDriverTemp.Text = resources.GetString("lblDriverTemp.Text");
            lblPowerVoltage.Text = resources.GetString("lblPowerVoltage.Text");

            UpdateStatusLabel();
        }

        //↑↑↑ ART HIKARI Mode 20181210 Kimura add ↑↑↑

        #endregion
	
	}
}