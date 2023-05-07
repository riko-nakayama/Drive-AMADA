using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
	public partial class VibrationTestForm : Form
	{
		#region 変数

		static private Point FormPosition = new Point(0, 0);

		private MainForm mform;
		private ViewMainForm vform;

		private int ResizeHeight = new int();
		private int ResizeWidth = new int();

		static private VibrationTestForm _ThisForm;
		private bool _IsCollapseLayout = new bool();
		private bool _IsExist = new bool();
		private MdiClient ThisMdiClient;

		private decimal BackupLowSpeed = new decimal();
		private decimal BackupMiddleSpeed = new decimal();
		private decimal BackupHighSpeed = new decimal();


		#endregion

		public VibrationTestForm()
		{
			InitializeComponent();
		}

		public VibrationTestForm(MainForm _mform, ViewMainForm _vform)
		{
			InitializeComponent();

			vform = _vform;
			mform = _mform;

			_ThisForm = this;
			_IsExist = true;

			//MdiClientの取得
			ThisMdiClient = MainForm.ThisForm.GetMdiClient();
		}

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

		#region フォーム

		static public VibrationTestForm ThisForm
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
		private void VibrationTestForm_Load(object sender, EventArgs e)
		{
			InitFormLayout();

			BackupLowSpeed = numLow.Value;
			BackupMiddleSpeed = numMiddle.Value;
			BackupHighSpeed = numHigh.Value;
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

		private void VibrationTestForm_FormClosing(object sender, FormClosingEventArgs e)
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

		private void VibrationTestForm_Resize(object sender, EventArgs e)
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

		#region ボタンクリックイベント
		private void btnServoOn_Click(object sender, EventArgs e)
		{
			if (!MainForm.IsUsbConnectBlink) { return; }

			if (!ServoControl.ServoON(ServoDef.WAIT_100ms))
			{
				MessageBox.Show("サーボＯＮに失敗しました。(BtnServoON)",
								"サーボＯＮ",
								MessageBoxButtons.OK,
								MessageBoxIcon.Error);
			}
		}

		private void btnServoOff_Click(object sender, EventArgs e)
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

		private void btnAlaramReset_Click(object sender, EventArgs e)
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

		private void btnHs_Click(object sender, EventArgs e)
		{
			if (!MainForm.IsUsbConnectBlink) { return; }

			//クラッチ励磁ON
			if (!ServoControl.ClutchExcitation(50))
			{
				MessageBox.Show("クラッチの切り替えに失敗しました。(BTN)",
								"クラッチ高速側切り替え",
								MessageBoxButtons.OK,
								MessageBoxIcon.Error);
			}
		}

		private void btnLs_Click(object sender, EventArgs e)
		{
			if (!MainForm.IsUsbConnectBlink) { return; }

			//クラッチ励磁OFF
			if (!ServoControl.ClutchExcitation(40))
			{
				MessageBox.Show("クラッチの切り替えに失敗しました。(BTN)",
								"クラッチ低速側切り替え",
								MessageBoxButtons.OK,
								MessageBoxIcon.Error);
			}
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			bool success = true;

			if (!MainForm.IsUsbConnectBlink) { return; }

			//速度制御
			if (ServoControl.ControlMode(2, true))
			{
				success = false;
			}

			if (rdoHsClutch.Checked)
			{
				ServoControl.ClutchExcitation(50);
			}
			else
			{
				ServoControl.ClutchExcitation(40);
			}

			int cmd_vel = new int();
			bool dir = new bool();

			if (rdoHigh.Checked)
			{
				cmd_vel = (int)numHigh.Value;
			}
			else if (rdoMiddle.Checked)
			{
				cmd_vel = (int)numMiddle.Value;
			}

			else if (rdoLow.Checked)
			{
				cmd_vel = (int)numLow.Value;
			}

			if (rdoCw.Checked) { dir = true; }

			if (!ServoControl.StartJog(dir, cmd_vel, cmd_vel, cmd_vel))
			{
				success = false;
			}

			if (!success)
			{
				MessageBox.Show("モータ回転開始に失敗しました。(BTN)",
								"モータ回転開始",
								MessageBoxButtons.OK,
								MessageBoxIcon.Error);
			}
		}

		private void btnHsStop_Click(object sender, EventArgs e)
		{

			//モータ停止
			if (!ServoControl.StopJog())
			{
				MessageBox.Show("モータ回転停止に失敗しました。(BTN)",
								"モータ回転停止",
								MessageBoxButtons.OK,
								MessageBoxIcon.Error);
			}
		}

		#endregion

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

		private void rdoHsClutch_CheckedChanged(object sender, EventArgs e)
		{
			if (rdoHsClutch.Checked)
			{
				rdoHsClutch.BackColor = Color.Gold;
				rdoLsClutch.BackColor = SystemColors.Control;
			}
			else
			{
				rdoHsClutch.BackColor = SystemColors.Control;
				rdoLsClutch.BackColor = Color.Gold;
			}
		}

		private void rdoCw_CheckedChanged(object sender, EventArgs e)
		{
			if (rdoCw.Checked)
			{
				rdoCw.BackColor = Color.Gold;
				rdoCcw.BackColor = SystemColors.Control;
			}
			else
			{
				rdoCw.BackColor = SystemColors.Control;
				rdoCcw.BackColor = Color.Gold;
			}
		}

		private void rdoLow_CheckedChanged(object sender, EventArgs e)
		{
			if (rdoLow.Checked)
			{
				rdoLow.BackColor = Color.Gold;
				rdoMiddle.BackColor = SystemColors.Control;
				rdoHigh.BackColor = SystemColors.Control;
			}
			else if (rdoMiddle.Checked)
			{
				rdoLow.BackColor = SystemColors.Control;
				rdoMiddle.BackColor = Color.Gold;
				rdoHigh.BackColor = SystemColors.Control;
			}
			else
			{
				rdoLow.BackColor = SystemColors.Control;
				rdoMiddle.BackColor = SystemColors.Control;
				rdoHigh.BackColor = Color.Gold;
			}
		}


		private bool event_lock = new bool();

		private void numSpeed_ValueChanged(object sender, EventArgs e)
		{
			if (event_lock) { return; }

			NumericUpDown num = (NumericUpDown)sender;

			PasswordDialog f = new PasswordDialog();
			f.ViewStartPosition = FormStartPosition.CenterScreen;

			if (f.ShowDialog() == DialogResult.OK)
			{
				if (f.PasswordText.ToUpper() == InspectionDef.PASSWORD)
				{
					switch (num.Tag.ToString())
					{
						case "Low":
							BackupLowSpeed = numLow.Value;
							break;

						case "Middle":
							BackupMiddleSpeed = numMiddle.Value;
							break;

						case "High":
							BackupHighSpeed = numHigh.Value;
							break;

					}
				}
				else
				{
					event_lock = true;

					switch (num.Tag.ToString())
					{
						case "Low":
							numLow.Value = BackupLowSpeed;
							break;

						case "Middle":
							numMiddle.Value = BackupMiddleSpeed;
							break;

						case "High":
							numHigh.Value = BackupHighSpeed;
							break;
					}

					MessageBox.Show("設定変更が出来ません。",
							"設定設定",
							MessageBoxButtons.OK,
							MessageBoxIcon.Warning);

					event_lock = false;

					btnStop.Select();
				}
			}
			else
			{
				event_lock = true;

				switch (num.Tag.ToString())
				{
					case "Low":
						numLow.Value = BackupLowSpeed;
						break;

					case "Middle":
						numMiddle.Value = BackupMiddleSpeed;
						break;

					case "High":
						numHigh.Value = BackupHighSpeed;
						break;
				}

				MessageBox.Show("設定変更が出来ません。",
						"設定設定",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);

				event_lock = false;

				btnStop.Select();
			}
		}

	
	
	}
}
