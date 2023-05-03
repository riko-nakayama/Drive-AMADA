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
	public partial class TeachingDialog : Form
	{
		private int BackupControlMode = new int();
		private int BackupVelocityInputMode = new int();

		static private int _TuningPosition = new int();
		static private int _TargetPosition = new int();

		static bool _FixedTuningPosition = new bool();
		static bool _FixedTargetPosition = new bool();

		private PictureBox[] picArray = new PictureBox[8];
		private Label[] lblArray = new Label[8];

		private bool TargetPositionOk = new bool();
		private bool StartPositionOk = new bool();

		public TeachingDialog()
		{
			InitializeComponent();

			picArray[0] = picServoOn;
			picArray[1] = picProfile;
			picArray[2] = picInPosition;
			picArray[3] = picFault;
			picArray[4] = picForwardLimit;
			picArray[5] = picReverseLimit;
			picArray[6] = picTorqueLimit;
			picArray[7] = picVelocityLimit;

			lblArray[0] = lblServoOn;
			lblArray[1] = lblProfile;
			lblArray[2] = lblInPosition;
			lblArray[3] = lblFault;
			lblArray[4] = lblForwardLimit;
			lblArray[5] = lblReverseLimit;
			lblArray[6] = lblTorqueLimit;
			lblArray[7] = lblVelocityLimit;

			BackupControlMode = CMonitor.GetParameter(CParamID.ControlMode);
			BackupVelocityInputMode = CMonitor.GetParameter(CParamID.VelocityInputMode);

			FixedTuningPosition = false;
			FixedTargetPosition = false;

			TimerMain.Enabled = true;
		}

		static public bool FixedTuningPosition
		{
			set { _FixedTuningPosition = value; }
			get { return _FixedTuningPosition; }
		}

		static public bool FixedTargetPosition
		{
			set { _FixedTargetPosition = value; }
			get { return _FixedTargetPosition; }
		}

		static public int TuningPosition
		{
			set { _TuningPosition = value; }
			get { return _TuningPosition; }
		}

		static public int TargetPosition
		{
			set { _TargetPosition = value; }
			get { return _TargetPosition; }
		}

		private void TeachingForm_Load(object sender, EventArgs e)
		{
			//ティーチングはウィザードから呼ばれるため子フォームの制御は不要
			//ChildFormControl.SetOpacity(0.0);
			
			//速度制御モード
			if (!CCommandTx.WriteSvNet(CParamID.ControlMode, 2)) { return; }
			//速度制御指令タイプ
			if (!CCommandTx.WriteSvNet(CParamID.VelocityInputMode, 0)) { return; }

			rdoVel_CheckedChanged(null, null);
		}

		private void TeachingForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if ((CMonitor.GetParameter(CParamID.ServoStatus) & 0x01) == 0x01)
			{
				DialogResult ret = UserMessageBox.CommonServoOff();

				if (ret == DialogResult.Yes)
				{
					btnServoOff_Click(null, null);
				}
				else
				{
					e.Cancel = true;
					return;
				}
			}
	
			//制御モードを起動前に変更
			if (!CCommandTx.WriteSvNet(CParamID.ControlMode, BackupControlMode)) { return; }
			//速度制御指令タイプを起動前に変更
			if (!CCommandTx.WriteSvNet(CParamID.VelocityInputMode, BackupVelocityInputMode)) { return; }
		
		}

		private void TeachingForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			//ティーチングはウィザードから呼ばれるため子フォームの制御は不要
			//ChildFormControl.SetOpacity(1.0);
		}

		private void btnServoOn_Click(object sender, EventArgs e)
		{
			if (!MainForm.IsUsbConnectBlink) { return; }

			int cmd = CMonitor.GetParameter(CParamID.ServoCommand);

			cmd &= ~0x0030;		//Hard Stop & Smooth Stop Clear
			if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) { return; }

			//速度制御モード
			if (!CCommandTx.WriteSvNet(CParamID.ControlMode, 2)) { return; }

			cmd |= 0x0001;

			if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) { return; }

		}

		private void btnServoOff_Click(object sender, EventArgs e)
		{
			if (!MainForm.IsUsbConnectBlink) { return; }

			int cmd = CMonitor.GetParameter(CParamID.ServoCommand);
			int sts = new int();

			cmd |= 0x0020;		//Smooth Stop bit Set

			if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) { return; }

			Thread.Sleep(100);

			CDataTool.SetNow(CDataTool.TEACH_TIME);

			while ((sts & 0x4000) == 0x0000)
			{
				if (!CCommandTx.ReadSvNet(CParamID.ServoStatus, ref sts)) { return; }

				if (CDataTool.IsTimerLimit(CDataTool.TEACH_TIME, 10)) { break; }
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

			if ((CMonitor.GetParameter(CParamID.ServoStatus) & 0x04) == 0x00) { return; }		//軸動作中はポジションリセット禁止

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

			JogCtrl(false);
		}

		private void btnCcw_MouseDown(object sender, MouseEventArgs e)
		{
			if (!MainForm.IsUsbConnectBlink) { return; }

			JogCtrl(true);
		}

		private void btnCw_MouseUp(object sender, MouseEventArgs e)
		{
			JogStop();
		}

		private void btnCcw_MouseUp(object sender, MouseEventArgs e)
		{
			JogStop();
		}

		private void btnSmoothStop_Click(object sender, EventArgs e)
		{
			JogStop();
		}

		private void JogCtrl(bool ccw)
		{
			if ((CMonitor.GetParameter(CParamID.ServoStatus) & 0x01) == 0x00) { return; }

			int mode = CMonitor.GetParameter(CParamID.ControlMode);
			int cmd = CMonitor.GetParameter(CParamID.ServoCommand);
			int ctrl = CMonitor.GetParameter(CParamID.ControlSwitch);

			int vel = new int();
			//int acc = new int();
			//int dcc = new int();

			if (rdo10.Checked)
			{
				vel = 10;
			}
			else if (rdo50.Checked)
			{
				vel = 50;
			}
			else if (rdo100.Checked)
			{
				vel = 100;
			}

			cmd &= ~0x0030;		//Hard Stop & Smooth Stop Clear
			if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) { return; }

			if (ccw) { vel = -vel; }

			cmd |= 0x0080;		//Smoothing On
			if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) { return; }
		
			//if (!CCommandTx.WriteSvNet(CParamID.TargetAcceleration, acc)) { return; }

			//if (!CCommandTx.WriteSvNet(CParamID.TargetDeceleration, dcc)) { return; }

			if (!CCommandTx.WriteSvNet(CParamID.CommandVelocity, vel)) { return; }

		}

		private void JogStop()
		{
			if (!MainForm.IsUsbConnectBlink) { return; }

			int cmd = CMonitor.GetParameter(CParamID.ServoCommand);
			int sts = CMonitor.GetParameter(CParamID.ServoStatus);

			cmd &= ~0x0002;		//Profile Start bit Clear
			cmd |= 0x0020;		//Smooth Stop bit Set
			if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) { UserMessageBox.CommonUsbError(); return; }
		}

		private void TimerMain_Tick(object sender, EventArgs e)
		{
			lblNowPosition.Text = CMonitor.GetParameter(CParamID.FeedbackPosition).ToString();

			int status = CMonitor.GetParameter(CParamID.ServoStatus);

			for (int i = 0, b = 1; i < 8; i++, b<<=1)
			{
				if ((status & b) == b)
				{
					picArray[i].BackColor = Color.Red;
					lblArray[i].Font = AppFont.MeiryoBold7;
				}
				else
				{
					picArray[i].BackColor = Color.Black;
					lblArray[i].Font = AppFont.MeiryoRegular7;
				}
			}

			if (StartPositionOk == false)
			{
				if (btnTeachStart.BackColor == Color.Gold)
				{
					btnTeachStart.BackColor = SystemColors.Control;
				}
				else
				{
					btnTeachStart.BackColor = Color.Gold;
				}
			}

			if (TargetPositionOk == false)
			{
				if (btnTeachTarget.BackColor == Color.Gold)
				{
					btnTeachTarget.BackColor = SystemColors.Control;
				}
				else
				{
					btnTeachTarget.BackColor = Color.Gold;
				}
			}

			if (StartPositionOk && TargetPositionOk)
			{
				btnFinish.Enabled = true;

				if (btnFinish.BackColor == Color.Gold)
				{
					btnFinish.BackColor = SystemColors.Control;
				}
				else
				{
					btnFinish.BackColor = Color.Gold;
				}
			}
			else
			{
				btnFinish.Enabled = false;
				btnFinish.BackColor = SystemColors.Control;
			}

		}

		private void btnTeachTarget_Click(object sender, EventArgs e)
		{
			FixedTargetPosition = true;

			TargetPosition = CMonitor.GetParameter(CParamID.FeedbackPosition);
			lblTargetPosition.Text = TargetPosition.ToString();
			lblTargetPosition.BackColor = Color.Gold;

			btnTeachTarget.BackColor = SystemColors.Control;

			TargetPositionOk = true;
		}

		private void btnTeachStart_Click(object sender, EventArgs e)
		{
			FixedTuningPosition = true;

			TuningPosition = CMonitor.GetParameter(CParamID.FeedbackPosition);
			lblStartPosition.Text = TuningPosition.ToString();
			lblStartPosition.BackColor = Color.Gold;

			btnTeachStart.BackColor = SystemColors.Control;

			StartPositionOk = true;
		}

		private void btnClearStart_Click(object sender, EventArgs e)
		{
			lblStartPosition.BackColor = Color.Gainsboro;
			lblStartPosition.Text = "?????";

			StartPositionOk = false;
		}

		private void btnClearTarget_Click(object sender, EventArgs e)
		{
			lblTargetPosition.BackColor = Color.Gainsboro;
			lblTargetPosition.Text = "?????";

			TargetPositionOk = false;
		}

		private void btnFinish_Click(object sender, EventArgs e)
		{
			DialogResult ret = UserMessageBox.TeachingFinsh();

			if (ret == DialogResult.Yes)
			{
				this.Close();
			}
		}

		private void rdoVel_CheckedChanged(object sender, EventArgs e)
		{
			rdo10.BackColor = SystemColors.Control;
			rdo50.BackColor = SystemColors.Control;
			rdo100.BackColor = SystemColors.Control;

			if (rdo10.Checked) { rdo10.BackColor = Color.Gold; }
			if (rdo50.Checked) { rdo50.BackColor = Color.Gold; }
			if (rdo100.Checked) { rdo100.BackColor = Color.Gold; }
		}


	}
}