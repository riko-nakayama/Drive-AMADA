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
using System.Runtime.InteropServices;

namespace Motion_Designer
{
	public partial class AutoTuningForm : Form
	{
        #region リッチテキスト行間変更用API定義

        const int EM_SETPARAFORMAT = 0x0447;
        const uint PFM_LINESPACING = 0x00000100;

        [StructLayout(LayoutKind.Sequential)]
        public struct PARAFORMAT2
        {
            public uint cbSize;
            public uint dwMask;
            public short wNumbering;
            public short wReserved;
            public int dxStartIndent;
            public int dxRightIndent;
            public int dxOffset;
            public short wAlignment;
            public short cTabCount;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public int[] rgxTabs;
            public int dySpaceBefore;
            public int dySpaceAfter;
            public int dyLineSpacing;
            public short sStyle;
            public byte bLineSpacingRule;
            public byte bOutlineLevel;
            public short wShadingWeight;
            public short wShadingStyle;
            public short wNumberingStart;
            public short wNumberingStyle;
            public short wNumberingTab;
            public short wBorderSpace;
            public short wBorderWidth;
            public short wBorders;
        }

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        private extern static int SendMessage(IntPtr hwnd, int msg, IntPtr wparam, ref PARAFORMAT2 pf2);

        #endregion

        static private Point FormPosition = new Point(0, 0);
		static private Size FormSize = new Size(560, 640);

		static private AutoTuningForm _ThisForm;

		private SaveProgressDialog SaveMsg = new SaveProgressDialog();

		private bool _IsCollapseLayout = new bool();

		private bool _IsExist = new bool();

		private int[] BackupParameter = new int[CMonitor.ParameterSize];

		private int NowPosition = new int();

		private bool LoadTuningMeasEnd = new bool();
		private int LoadTuningRefCnt = new int();
		private int LoadTuningMeasCnt = new int();

		private bool IsTempTuning = new bool();
		private int TempTuningMeasCnt = new int();
		private int TempTuningRefCnt = new int();
		private double TempTuningCoeff = new double();

		private int LoadTuningCounter = new int();
		private int[] LoadTuningBuffer;
	
		private int LoadTuningStatusCheckWait = new int();
		private int LoadTuningUpdateResultWait = new int();

		private bool IsGainAdjustPause = new bool();
		private bool IsGainAdjustRepeat = new bool();
		
		private int AutoTuningSq = new int();

		private float[] SignalGain = new float[1000];
		private float[] SignalPhase = new float[1000];

		private int SweepVelocity = 100;
		private int SweepMaxFrq = 100;

		private const int ENC_RES_17B = 131072;

		private const int ENC_TYP_RESOLVER = 0;
		private const int ENC_TYP_COUNT_INC = 1;
		private const int ENC_TYP_17BIT_INC = 5;
		private const int ENC_TYP_17BIT_ABS = 6;
		private const int ENC_TYP_20BIT_INC = 7;
		private const int ENC_TYP_20BIT_ABS = 8;
		private const int ENC_TYP_23BIT_INC = 9;
		private const int ENC_TYP_23BIT_ABS = 10;

		private int _EncderResolution = new int();
		private int _EncderType = new int();
		private int _IncCount = new int();
		private int _RDType = new int();

		private int BackupPositionErrorPulse = new int();

		private int BackupControlMode = new int();

		private int BackupDynamicBreakCondition = new int();			//20170215 add

		private int ResizeHeight = new int();
		private int ResizeWidth = new int();

		private MdiClient ThisMdiClient;

		private DataProgressDialog DataMsg = new DataProgressDialog();

		public AutoTuningForm()
		{
			InitializeComponent();

			_ThisForm = this;
			_IsExist = true;

			//MdiClientの取得
			ThisMdiClient = MainForm.ThisForm.GetMdiClient();

			ctlNumTargetVelocity.NumInputValueChanged += new dNumInputValueCheange(ctlNumTargetVelocity_NumInputValueChanged);
			ctlNumTargetAcceleration.NumInputValueChanged += new dNumInputValueCheange(ctlNumTargetAcceleration_NumInputValueChanged);
			ctlNumTargetDeceleration.NumInputValueChanged += new dNumInputValueCheange(ctlNumTargetDeceleration_NumInputValueChanged);

			ctlNumStartPosition.NumInputValueChanged += new dNumInputValueCheange(ctlNum_NumInputValueChanged);
			ctlNumTargetPosition.NumInputValueChanged += new dNumInputValueCheange(ctlNum_NumInputValueChanged);

			ctlNumWaitTime.NumInputValueChanged += new dNumInputValueCheange(ctlNum_NumInputValueChanged);

			ctlNumTargetTime.NumInputValueChanged += new dNumInputValueCheange(ctlNum_NumInputValueChanged);
			ctlNumInposition.NumInputValueChanged += new dNumInputValueCheange(ctlNum_NumInputValueChanged);

			ctlNumLoadTuningKp.NumInputValueChanged += new dNumInputValueCheange(ctlNum_NumInputValueChanged);
			ctlNumLoadTuningKv.NumInputValueChanged += new dNumInputValueCheange(ctlNum_NumInputValueChanged);
			ctlNumLoadTuningKi.NumInputValueChanged += new dNumInputValueCheange(ctlNum_NumInputValueChanged);

			EncderResolution = ENC_RES_17B;

			InitTuningGrid();

		}

		static public AutoTuningForm ThisForm
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

		public void StopAutoTuning()
		{
			btnStop.PerformClick();
		}

		public bool IsCollapseLayout
		{
			set
			{
				_IsCollapseLayout = value;

				if (_IsCollapseLayout)
				{
					CollapseAutoTuningControl();
				}
				else
				{
					ExpandAutoTuningControl();
				}
			}

			get { return _IsCollapseLayout; }
		}

		public bool IsExist
		{
			set { _IsExist = value; }
			get { return _IsExist; }
		}

		#region Property

		public bool IsTuning
		{
			get
			{
				if (AutoTuningSq != 0)
				{
					if (AutoTuningSq == 2)
					{
						return false;
					}
					else
					{
						return true;
					}
				}
				else
				{
					return false;
				}
			}
		}

		public int IncCount
		{
			set { _IncCount = value; }
			get { return _IncCount; }
		}

		public int RDType
		{
			set { _RDType = value; }
			get { return _RDType; }
		}

		public int EncderType
		{
			set
			{
				_EncderType = value;

				switch (_EncderType)
				{
					case ENC_TYP_RESOLVER:

						switch(RDType)
						{
							default:
							case 0:
							case 1:
								EncderResolution = 2048;
								ctlNumInposition.IntValue = 4;
								break;
							case 2:
								EncderResolution = 4096;
								ctlNumInposition.IntValue = 8;
								break;
							case 4:
								EncderResolution = 8192;
								ctlNumInposition.IntValue = 16;
								break;
							case 5:
								EncderResolution = 10240;
								ctlNumInposition.IntValue = 20;
								break;
							case 8:
								EncderResolution = 16384;
								ctlNumInposition.IntValue = 32;
								break;
						}
				
						break;

					case ENC_TYP_COUNT_INC:

						switch (IncCount)
						{
							default:
							case 8000:

								EncderResolution = 8000;
								ctlNumInposition.IntValue = 16;
								break;

							case 8192:

								EncderResolution = 8192;
								ctlNumInposition.IntValue = 16;
								break;

							case 10000:

								EncderResolution = 10000;
								ctlNumInposition.IntValue = 20;
								break;
						}
					
						break;

					default:
					case ENC_TYP_17BIT_INC:
					case ENC_TYP_17BIT_ABS:

						EncderResolution = 131072;
						ctlNumInposition.IntValue = 64;
						break;

					case ENC_TYP_20BIT_INC:
					case ENC_TYP_20BIT_ABS:

						EncderResolution = 1048576;
						ctlNumInposition.IntValue = 512;
						break;

					case ENC_TYP_23BIT_INC:
					case ENC_TYP_23BIT_ABS:

						EncderResolution = 8388608;
						ctlNumInposition.IntValue = 4096;
						break;

				}
			}

			get { return _EncderType; }
		}

		public int EncderResolution
		{
			set
			{
				if (_EncderResolution != value)
				{
					_EncderResolution = value;
					InitTargetData();
				}
			}

			get { return _EncderResolution; }
		}

		#endregion

		#region NumInput Call back

		void ctlNum_NumInputValueChanged()
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
			UpdateAccDccTime();
		}

		#endregion

		#region Form Event

		private void AutoTuningForm_Load(object sender, EventArgs e)
		{
			//InitFormLayout();
            ViewCultureResouceChanged();

			RDType = CMonitor.GetParameter(CParamID.RDType);			//20160406 add
			EncderType = CMonitor.GetParameter(CParamID.EncderType);

			rdoMachineType_CheckedChanged(null, null);
			rdoTuningStrength_CheckedChanged(null, null);
			rdoTuningMode_CheckedChanged(null, null);
			rdoVelObsEnable_CheckedChanged(null, null);
			rdoTurboEnable_CheckedChanged(null, null);
	
			chkInc_CheckStateChanged(null, null);
		
			string path = Path.Combine(Application.StartupPath, "Config");

			path = Path.Combine(path, "tuning_config.txt");

			bConfigRead(path, false);

            //行間変更
            int size = Marshal.SizeOf(typeof(PARAFORMAT2));

            PARAFORMAT2 pf = new PARAFORMAT2();
            pf.cbSize = (uint)size;
            pf.dwMask = PFM_LINESPACING;
            pf.bLineSpacingRule = 4;
            pf.dyLineSpacing = 300; // 行間 ( twips )

            SendMessage(rtxtResult.Handle, EM_SETPARAFORMAT, IntPtr.Zero, ref pf);
            SendMessage(rtxtGainNow.Handle, EM_SETPARAFORMAT, IntPtr.Zero, ref pf);
            SendMessage(rtxtFFT_Peek.Handle, EM_SETPARAFORMAT, IntPtr.Zero, ref pf);

            //このオプションを付けないとRichTextで設定されたフォントが反映されない
            rtxtResult.LanguageOption = RichTextBoxLanguageOptions.DualFont;
            rtxtGainNow.LanguageOption = RichTextBoxLanguageOptions.DualFont;
            rtxtFFT_Peek.LanguageOption = RichTextBoxLanguageOptions.DualFont;

			UpdateAccDccTime();

			if (!Properties.Settings.Default.PASSWORD_LOCK && !Properties.Settings.Default.PASSWORD_TEMP)
			{
				toolStripTuningSetting.Visible = false;
				dgvSetting.Visible = false;
			}
		}

		private void AutoTuningForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.MdiFormClosing)
			{
	
			}
			else
			{
				if (AutoTuningSq != 0)
				{
					DialogResult ret = UserMessageBox.AutoTuningExecAutoTuning();

					if (ret == DialogResult.Yes)
					{
						StopAutoTuning();
					}
					else
					{
						e.Cancel = true;
						return;
					}
				}

				_IsExist = false;
			}
		}

		private void AutoTuningForm_Resize(object sender, EventArgs e)
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

		#region Button Event

		private bool CheckTheOtherSequence()
		{
			if (AutoTuningSq != 0) { UserMessageBox.AutoTuningExecOther(AutoTuningSq); return false; }

			//軸動作中の判定は厳しい。　上位がいつ動作させるのか分からない
			//int sts = new int();

			//for (int i = 0; i < 3; i++)
			//{
			//    sts = CMonitor.GetParameter(CParamID.ServoStatus);
			//    if ((sts & 0x02) == 0x02) { UserMessageBox.AutoTuningExecMoving(); return false; }
			//    if ((sts & 0x04) == 0x00) { UserMessageBox.AutoTuningExecMoving(); return false; }
			//    Thread.Sleep(100);
			//}

			return true;
		}

		private void btnWizard_Click(object sender, EventArgs e)
		{
			if (!MainForm.IsUsbConnectBlink) { return; }

			if (!CheckTheOtherSequence()) { return; }

			if (rdoDisk.Checked)
			{
				WizardDialog.TuningMachine = TuningMachine.Disk;
			}
			else if (rdoBelt.Checked)
			{
				WizardDialog.TuningMachine = TuningMachine.Belt;
			}
			else if (rdoScrew.Checked)
			{
				WizardDialog.TuningMachine = TuningMachine.Screw;
			}

			if (rdoLight.Checked)
			{
				WizardDialog.TuningStrength = TuningStrength.Light;
			}
			else if (rdoMiddle.Checked)
			{
				WizardDialog.TuningStrength = TuningStrength.Middle;
			}
			else if (rdoStrong.Checked)
			{
				WizardDialog.TuningStrength = TuningStrength.Strong;
			}

			if (rdoNormalPriorty.Checked)
			{
				WizardDialog.TuningMode = TuningPriorty.Normal;
			}
			else if (rdoPositionPriorty.Checked)
			{
				WizardDialog.TuningMode = TuningPriorty.Position;
			}
			else if (rdoStiffnessPriorty.Checked)
			{
				WizardDialog.TuningMode = TuningPriorty.Stiffness;
			}

			WizardDialog.EnableVelocityObserver = rdoVelObsEnable.Checked;

			WizardDialog.EnableTuningTurbo = rdoTurboEnable.Checked;

			WizardDialog.EncderResolution = EncderResolution;
			WizardDialog.LoadInertia = CMonitor.GetParameter(CParamID.Load);
			WizardDialog.InpositionWidth = ctlNumInposition.IntValue;
			WizardDialog.TargetTime = ctlNumTargetTime.IntValue;
			WizardDialog.TargetVelocity = ctlNumTargetVelocity.IntValue;
			WizardDialog.TargetAcceleration = ctlNumTargetAcceleration.IntValue;
			WizardDialog.TargetDeceleration = ctlNumTargetDeceleration.IntValue;
			WizardDialog.WaitTime = ctlNumWaitTime.IntValue;
			WizardDialog.TuningPosition = ctlNumStartPosition.IntValue;
			WizardDialog.TargetPosition = ctlNumTargetPosition.IntValue;

			WizardDialog wizForm = new WizardDialog();

			DialogResult ret =wizForm.ShowDialog();

			if (ret == DialogResult.Cancel) { return; }

			WriteLoadInertia(WizardDialog.LoadInertia);

			switch (WizardDialog.TuningMachine)
			{
				case TuningMachine.Disk:

					rdoDisk.Checked = true;
					break;

				case TuningMachine.Belt:

					rdoBelt.Checked = true;
					break;

				case TuningMachine.Screw:

					rdoScrew.Checked = true;
					break;
			}

			switch (WizardDialog.TuningStrength)
			{
				case TuningStrength.Light:

					rdoLight.Checked = true;
					break;

				case TuningStrength.Middle:

					rdoMiddle.Checked = true;
					break;

				case TuningStrength.Strong:

					rdoStrong.Checked = true;
					break;
			}

			switch (WizardDialog.TuningMode)
			{
				case TuningPriorty.Normal:

					rdoNormalPriorty.Checked = true;
					break;

				case TuningPriorty.Position:

					rdoPositionPriorty.Checked = true;
					break;

				case TuningPriorty.Stiffness:

					rdoStiffnessPriorty.Checked = true;
					break;
			}

			if (WizardDialog.EnableVelocityObserver)
			{
				rdoVelObsEnable.Checked = true;
			}
			else
			{
				rdoVelObsDisable.Checked = true;
			}

			if (WizardDialog.EnableTuningTurbo)
			{
				rdoTurboEnable.Checked = true;
			}
			else
			{
				rdoTurboDisable.Checked = true;
			}

			ctlNumInposition.IntValue = WizardDialog.InpositionWidth;

			ctlNumTargetTime.IntValue = WizardDialog.TargetTime;

			ctlNumTargetVelocity.IntValue = WizardDialog.TargetVelocity;

			ctlNumTargetAcceleration.IntValue = WizardDialog.TargetAcceleration;

			ctlNumTargetDeceleration.IntValue = WizardDialog.TargetDeceleration;

			ctlNumWaitTime.IntValue = WizardDialog.WaitTime;

			ctlNumStartPosition.IntValue = WizardDialog.TuningPosition;

			ctlNumTargetPosition.IntValue = WizardDialog.TargetPosition;

			chkInc.Checked = false;

			UpdateAccDccTime();

			if (ret == DialogResult.Retry)
			{
				StartMeasLoadInertia();
			}

			if (ret == DialogResult.OK)
			{
				StartAutoTuning();
			}

		}

		private void btnTuningControl_Click(object sender, EventArgs e)
		{
			TuningSelectDialog tuning_form = new TuningSelectDialog();

			DialogResult ret = tuning_form.ShowDialog();

			if (ret == DialogResult.OK)
			{
				switch (TuningSelectDialog.TuningRequest)
				{
					case TuningSelectDialog.TuningType.Load:

						StartMeasLoadInertia(); 
						break;

					case TuningSelectDialog.TuningType.Adjust:

						StartAutoTuning();
						break;

					case TuningSelectDialog.TuningType.Sweep:

						StartFrequencySweep();
						break;

					case TuningSelectDialog.TuningType.Friction:

						StartFrictionCompensation();
						break;

					default:

						break;
				}
			}
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			TimerAutoTuing.Enabled = false;

			ClearPauseAndRepeat();

			ClearAutoTuningSq();

			int sts = new int();

			SmoothStop();

			CDataTool.SetNow(CDataTool.TUNE_TIME);

			while ((sts & 0x4000) == 0x0000)
			{
				if (!CCommandTx.ReadSvNet(CParamID.ServoStatus, ref sts)) { return; }

				if (CDataTool.IsTimerLimit(CDataTool.TUNE_TIME, 10)) { break; }
			}

			//Servo Command All Clear
			WriteServoCommand(0);

		}

		private void btnPause_Click(object sender, EventArgs e)
		{
			if (btnPause.Text == UserText.AutoTuningPause)
			{
				btnPause.Text = UserText.AutoTuningResume;
				btnPause.BackColor = Color.Gold;
				IsGainAdjustPause = true;
			}
			else
			{
				btnPause.Text = UserText.AutoTuningPause;
				btnPause.BackColor = SystemColors.Control;
				IsGainAdjustPause = false;
			}
		}

		private void btnRepeat_Click(object sender, EventArgs e)
		{
			if (!MainForm.IsUsbConnectBlink) { return; }

			if (AutoTuningSq == 0 || AutoTuningSq == 100)
			{
				//確認運転
				if (btnRepeat.Text == UserText.AutoTuningRepeat)
				{
					DialogResult ret = UserMessageBox.AutoTuningTestTuning();

					if (ret == DialogResult.Cancel) { return; }

					btnRepeat.Text = UserText.AutoTuningRepeatStop;
					btnRepeat.BackColor = Color.Gold;
					IsGainAdjustRepeat = true;

					StartTestTuning();
				}
				else
				{
					btnRepeat.Text = UserText.AutoTuningRepeat;
					btnRepeat.BackColor = SystemColors.Control;
					IsGainAdjustRepeat = false;

					TimerAutoTuing.Enabled = false;
					ClearAutoTuningSq();
				}
			}
			else
			{
				if (btnRepeat.Text == UserText.AutoTuningRepeat)
				{
					btnRepeat.Text = UserText.AutoTuningResume;
					btnRepeat.BackColor = Color.Gold;
					IsGainAdjustRepeat = true;
				}
				else
				{
					btnRepeat.Text = UserText.AutoTuningRepeat;
					btnRepeat.BackColor = SystemColors.Control;
					IsGainAdjustRepeat = false;
				}
			}
		}

		private void btnStartPositionSet_Click(object sender, EventArgs e)
		{
			ctlNumStartPosition.IntValue = CMonitor.GetParameter(CParamID.FeedbackPosition);
		}

		private void btnTargetPosCopy_Click(object sender, EventArgs e)
		{
			ctlNumTargetPosition.IntValue = ctlNumStartPosition.IntValue;
		}

		private void btnConfigOutput_Click(object sender, EventArgs e)
		{
			try
			{
				SaveFileDialog.FileName = "tuning_config";
				SaveFileDialog.Filter = "Auto Tuning Config File (*.txt)|*.txt";

				//初期フォルダを設定する
				SaveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

				ChildFormControl.SetOpacity(0.0);

				DialogResult ret = SaveFileDialog.ShowDialog();

				ChildFormControl.SetOpacity(1.0);
		
				//保存ダイアログを設定する
				if (ret == DialogResult.OK)
				{
					DataMsg = new DataProgressDialog();
					DataMsg.Maximum = dgvSetting.Rows.Count;
					DataMsg.Start(UserText.AutoTuningFileSave, MainForm.ThisForm.Location, MainForm.ThisForm.ClientSize, false);

					this.Cursor = Cursors.WaitCursor;

					System.IO.StreamWriter file;

					file = new System.IO.StreamWriter(SaveFileDialog.FileName, false, System.Text.Encoding.Unicode);

					for (int i = 0; i < dgvSetting.Rows.Count; i++)
					{
						file.Write(dgvSetting[ITEM_COLUMN, i].Value.ToString() + "\t");
						file.Write("(" + dgvSetting[VALUE_COLUMN, i].Value.ToString() + ")");
						file.WriteLine("\n");

						DataMsg.PerformStep();
					}

					file.Close();
					this.Cursor = Cursors.Default;

					Thread.Sleep(500);

					DataMsg.Close();
			
				}
			}
			catch
			{
				this.Cursor = Cursors.Default;

				DataMsg.Close();
			
				UserMessageBox.CommonFileFormatError();
			}

		}

		private void btnConfigRead_Click(object sender, EventArgs e)
		{		
			try
			{
				OpenFileDialog.Filter = "Auto Tuning Config File (*.txt)|*.txt";

				//初期フォルダを設定する
				OpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

				ChildFormControl.SetOpacity(0.0);
		
				DialogResult ret = OpenFileDialog.ShowDialog();

				ChildFormControl.SetOpacity(1.0);
		
				if (ret == DialogResult.OK)
				{
					this.Cursor = Cursors.WaitCursor;

					bConfigRead(OpenFileDialog.FileName, true);

					this.Cursor = Cursors.Default;
				}
			}
			catch
			{
				this.Cursor = Cursors.Default;
			}
		}

		private void bConfigRead(string path, bool is_bar)
		{
			try
			{
				System.IO.StreamReader file = new System.IO.StreamReader(path);

				string name, value;
				string[] buf;
				string[] dgv = new string[dgvSetting.Rows.Count];

				name = file.ReadToEnd();
				name = name.Replace("\r\n", "");
				buf = name.Split('\n');

				if (is_bar)
				{
					DataMsg = new DataProgressDialog();
					DataMsg.Maximum = dgvSetting.Rows.Count;
					DataMsg.Start(UserText.AutoTuningFileRead, this.Location, this.ClientSize, false);
				}

				for (int i = 0; i < dgvSetting.Rows.Count; i++)
				{
					if (buf[i] == "\r") { continue; }

					int x, y;

					x = buf[i].IndexOf("\t");

					name = buf[i].Substring(0, x);

					if (name != dgvSetting.Rows[i].Cells[ITEM_COLUMN].Value.ToString())
					{
						throw new ArithmeticException();
					}

					x = buf[i].IndexOf("(");
					y = buf[i].IndexOf(")");

					value = buf[i].Substring(x + 1, y - x - 1);

					if (name.Contains("+++"))
					{
						if (value != "-1")
						{
							throw new ArithmeticException();
						}
					}

					if (CDataTool.IsHexNumeric32(value))
					{
						dgv[i] = value;
					}
					else if (CDataTool.IsRealNumeric(value))
					{
						dgv[i] = value;
					}
					else
					{
						throw new ArithmeticException();
					}

					if (is_bar) { DataMsg.PerformStep(); }
				}

				file.Close();

				if (is_bar)
				{
					Thread.Sleep(500);

					DataMsg.Close();
				}

				for (int i = 0; i < dgvSetting.Rows.Count; i++)
				{
					dgvSetting.Rows[i].Cells[VALUE_COLUMN].Value = dgv[i];
				}
			}
			catch
			{
				DataMsg.Close();

				UserMessageBox.AutoTuningConfigFileFormatError();
			}
		}

		private void ClearPauseAndRepeat()
		{
			btnPause.Text = UserText.AutoTuningPause;
			btnPause.BackColor = SystemColors.Control;
			IsGainAdjustPause = false;

			btnRepeat.Text = UserText.AutoTuningRepeat;
			btnRepeat.BackColor = SystemColors.Control;
			IsGainAdjustRepeat = false;
		}

		private bool EnableAutoTuningSq
		{
			get
			{
				int sq = new int();

				if (!CCommandTx.ReadSvNet(CParamID.AutoTuningSequence, ref sq)) { return false; }

				if (sq != 0) { return false; }

				return true;

			}

		}

		#endregion

		#region Radio Button Event

		private void rdoMachineType_CheckedChanged(object sender, EventArgs e)
		{
			rdoDisk.Font = AppFont.MeiryoRegular9;
			rdoBelt.Font = AppFont.MeiryoRegular9;
			rdoScrew.Font = AppFont.MeiryoRegular9;

			rdoDisk.ForeColor = AppFont.NormalForeColor;
			rdoBelt.ForeColor = AppFont.NormalForeColor;
			rdoScrew.ForeColor = AppFont.NormalForeColor;

			rdoDisk.BackColor = AppFont.NormalBackColor;
			rdoBelt.BackColor = AppFont.NormalBackColor;
			rdoScrew.BackColor = AppFont.NormalBackColor;

			if (rdoDisk.Checked)
			{
				rdoDisk.BackColor = AppFont.ActiveBackColor;
			}

			if (rdoBelt.Checked)
			{
				rdoBelt.BackColor = AppFont.ActiveBackColor;
			}

			if (rdoScrew.Checked)
			{
				rdoScrew.BackColor = AppFont.ActiveBackColor;
			}

		}

		private void rdoTuningStrength_CheckedChanged(object sender, EventArgs e)
		{
			rdoLight.Font = AppFont.MeiryoRegular9;
			rdoMiddle.Font = AppFont.MeiryoRegular9;
			rdoStrong.Font = AppFont.MeiryoRegular9;

			rdoLight.ForeColor = AppFont.NormalForeColor;
			rdoMiddle.ForeColor = AppFont.NormalForeColor;
			rdoStrong.ForeColor = AppFont.NormalForeColor;

			rdoLight.BackColor = AppFont.NormalBackColor;
			rdoMiddle.BackColor = AppFont.NormalBackColor;
			rdoStrong.BackColor = AppFont.NormalBackColor;

			if (rdoLight.Checked)
			{
				rdoLight.BackColor = AppFont.ActiveBackColor;
			}

			if (rdoMiddle.Checked)
			{
				rdoMiddle.BackColor = AppFont.ActiveBackColor;
			}

			if (rdoStrong.Checked)
			{
				rdoStrong.BackColor = AppFont.ActiveBackColor;
			}

		}

		private void rdoTuningMode_CheckedChanged(object sender, EventArgs e)
		{
			rdoNormalPriorty.Font = AppFont.MeiryoRegular9;
			rdoPositionPriorty.Font = AppFont.MeiryoRegular9;
			rdoStiffnessPriorty.Font = AppFont.MeiryoRegular9;

			rdoNormalPriorty.ForeColor = AppFont.NormalForeColor;
			rdoPositionPriorty.ForeColor = AppFont.NormalForeColor;
			rdoStiffnessPriorty.ForeColor = AppFont.NormalForeColor;

			rdoNormalPriorty.BackColor = AppFont.NormalBackColor;
			rdoPositionPriorty.BackColor = AppFont.NormalBackColor;
			rdoStiffnessPriorty.BackColor = AppFont.NormalBackColor;

			if (rdoNormalPriorty.Checked)
			{
				rdoNormalPriorty.BackColor = AppFont.ActiveBackColor;
			}

			if (rdoPositionPriorty.Checked)
			{
				rdoPositionPriorty.BackColor = AppFont.ActiveBackColor;
			}

			if (rdoStiffnessPriorty.Checked)
			{
				rdoStiffnessPriorty.BackColor = AppFont.ActiveBackColor;
			}

		}

		private void rdoVelObsEnable_CheckedChanged(object sender, EventArgs e)
		{
			rdoVelObsEnable.Font = AppFont.MeiryoRegular9;
			rdoVelObsDisable.Font = AppFont.MeiryoRegular9;

			rdoVelObsEnable.ForeColor = AppFont.NormalForeColor;
			rdoVelObsDisable.ForeColor = AppFont.NormalForeColor;

			rdoVelObsEnable.BackColor = AppFont.NormalBackColor;
			rdoVelObsDisable.BackColor = AppFont.NormalBackColor;

			if (rdoVelObsEnable.Checked)
			{
				rdoVelObsEnable.BackColor = AppFont.ActiveBackColor;
			}

			if (rdoVelObsDisable.Checked)
			{
				rdoVelObsDisable.BackColor = AppFont.ActiveBackColor;
			}

		}

		private void rdoTurboEnable_CheckedChanged(object sender, EventArgs e)
		{
			rdoTurboEnable.Font = AppFont.MeiryoRegular9;
			rdoTurboDisable.Font = AppFont.MeiryoRegular9;

			rdoTurboEnable.ForeColor = AppFont.NormalForeColor;
			rdoTurboDisable.ForeColor = AppFont.NormalForeColor;

			rdoTurboEnable.BackColor = AppFont.NormalBackColor;
			rdoTurboDisable.BackColor = AppFont.NormalBackColor;

			if (rdoTurboEnable.Checked)
			{
				rdoTurboEnable.BackColor = AppFont.ActiveBackColor;
			}

			if (rdoTurboDisable.Checked)
			{
				rdoTurboDisable.BackColor = AppFont.ActiveBackColor;
			}

		}

		#endregion

		#region CheckBox Event

		private void chkLoadTuning_CheckedChanged(object sender, EventArgs e)
		{
			if (chkLoadTuning.Checked)
			{
				grpLoadTuningGain.Enabled = true;
				grpLoadTuningSetting.Enabled = true;
			}
			else
			{
				grpLoadTuningGain.Enabled = false;
				grpLoadTuningSetting.Enabled = false;
			}
		}

		private void chkInc_CheckStateChanged(object sender, EventArgs e)
		{
			if (chkInc.Checked)
			{
				chkInc.BackColor = AppFont.ActiveBackColor;
			}
			else
			{
				chkInc.BackColor = AppFont.NormalBackColor;
			}

			if (chkInc.Checked)
			{
				grpStartPosition.Enabled = false;
			}
			else
			{
				grpStartPosition.Enabled = true;
			}
		}

		#endregion

		#region Parameter Function

		private bool StoreServoParameter()
		{
			bool ret = new bool();

			ret = StoreFillter();

			if (ret == false) { return ret; }

			ret = StoreServoGain();

			if (ret == false) { return ret; }

			return true;
		}

		private bool ReStoreServoParameter()
		{
			bool ret = new bool();

			ret = ReStoreFillter();

			if (ret == false) { return ret; }
			
			ReStoreServoGain();

			if (ret == false) { return ret; }

			return ret;

		}

		private bool ClearFillter()
		{
			bool ret = new bool();

			ret = ClearOldFillter();

			if (ret == false) { return false; }

			ret = ClearNewFillter();

			if (ret == false) { return false; }

			return true;
		}

		private bool StoreFillter()
		{
			bool ret = new bool();

			ret = StoreOldFillter();

			if (ret == false) { return false; }

			ret = StoreNewFillter();

			if (ret == false) { return false; }

			return true;
		}

		private bool ReStoreFillter()
		{
			bool ret = new bool();

			ret = ReStoreOldFillter();

			if (ret == false) { return false; }

			ret = ReStoreNewFillter();

			if (ret == false) { return false; }

			return true;
		}

		private bool StoreOldFillter()
		{
			if (!CCommandTx.ReadSvNet(CParamID.Lpf1_f, ref BackupParameter[CParamID.Lpf1_f])) { return false; }

			if (!CCommandTx.ReadSvNet(CParamID.Nf1_f, ref BackupParameter[CParamID.Nf1_f])) { return false; }
			if (!CCommandTx.ReadSvNet(CParamID.Nf1_d, ref BackupParameter[CParamID.Nf1_d])) { return false; }

			if (!CCommandTx.ReadSvNet(CParamID.Nf1_f, ref BackupParameter[CParamID.Nf2_f])) { return false; }
			if (!CCommandTx.ReadSvNet(CParamID.Nf2_d, ref BackupParameter[CParamID.Nf2_d])) { return false; }

			if (!CCommandTx.ReadSvNet(CParamID.KpffGain, ref BackupParameter[CParamID.KpffGain])) { return false; }

			return true;
		}

		private bool ReStoreOldFillter()
		{
			if (!CCommandTx.WriteSvNet(CParamID.Lpf1_f, BackupParameter[CParamID.Lpf1_f])) { return false; }
			if (!VerifyWriteParameter(CParamID.Lpf1_f, BackupParameter[CParamID.Lpf1_f])) { return false; }

			if (!CCommandTx.WriteSvNet(CParamID.Nf1_f, BackupParameter[CParamID.Nf1_f])) { return false; }
			if (!VerifyWriteParameter(CParamID.Nf1_f, BackupParameter[CParamID.Nf1_f])) { return false; }

			if (!CCommandTx.WriteSvNet(CParamID.Nf1_d, BackupParameter[CParamID.Nf1_d])) { return false; }
			if (!VerifyWriteParameter(CParamID.Nf1_d, BackupParameter[CParamID.Nf1_d])) { return false; }

			if (!CCommandTx.WriteSvNet(CParamID.Nf2_f, BackupParameter[CParamID.Nf2_f])) { return false; }
			if (!VerifyWriteParameter(CParamID.Nf2_f, BackupParameter[CParamID.Nf2_f])) { return false; }

			if (!CCommandTx.WriteSvNet(CParamID.Nf2_d, BackupParameter[CParamID.Nf2_d])) { return false; }
			if (!VerifyWriteParameter(CParamID.Nf2_d, BackupParameter[CParamID.Nf2_d])) { return false; }

			if (!CCommandTx.WriteSvNet(CParamID.KpffGain, BackupParameter[CParamID.KpffGain])) { return false; }
			if (!VerifyWriteParameter(CParamID.KpffGain, BackupParameter[CParamID.KpffGain])) { return false; }

			return true;
		}

		private bool ClearOldFillter()
		{
			if (!CCommandTx.WriteSvNet(CParamID.Lpf1_f, 0)) { return false; }
			if (!VerifyWriteParameter(CParamID.Lpf1_f, 0)) { return false; }

			if (!CCommandTx.WriteSvNet(CParamID.Nf1_f, 0)) { return false; }
			if (!VerifyWriteParameter(CParamID.Nf1_f, 0)) { return false; }

			if (!CCommandTx.WriteSvNet(CParamID.Nf1_d, 0)) { return false; }
			if (!VerifyWriteParameter(CParamID.Nf1_d, 0)) { return false; }

			if (!CCommandTx.WriteSvNet(CParamID.Nf2_f, 0)) { return false; }
			if (!VerifyWriteParameter(CParamID.Nf2_f, 0)) { return false; }

			if (!CCommandTx.WriteSvNet(CParamID.Nf2_d, 0)) { return false; }
			if (!VerifyWriteParameter(CParamID.Nf2_d, 0)) { return false; }

			if (!CCommandTx.WriteSvNet(CParamID.KpffGain, 0)) { return false; }
			if (!VerifyWriteParameter(CParamID.KpffGain, 0)) { return false; }

			return true;
		}

		private bool StoreNewFillter()
		{

			//ObserverSW
			if (!CCommandTx.ReadSvNet(CParamID.ObserberSwitch, ref BackupParameter[CParamID.ObserberSwitch])) { return false; }

			//C_LPF_f
			if (!CCommandTx.ReadSvNet(CParamID.C_LPF_f, ref BackupParameter[CParamID.C_LPF_f])) { return false; }
			//C_LPF_n
			if (!CCommandTx.ReadSvNet(CParamID.C_LPF_n, ref BackupParameter[CParamID.C_LPF_n])) { return false; }

			//V_LPF_f
			if (!CCommandTx.ReadSvNet(CParamID.V_LPF_f, ref BackupParameter[CParamID.V_LPF_f])) { return false; }

			if (MainForm.DriverRevision >= AppConst.UpTadVer520)
			{
				//C_FB_Lpf
				if (!CCommandTx.ReadSvNet(CParamID.C_FB_Lpf, ref BackupParameter[CParamID.C_FB_Lpf])) { return false; }
				//V_FB_Lpf
				if (!CCommandTx.ReadSvNet(CParamID.V_FB_Lpf, ref BackupParameter[CParamID.V_FB_Lpf])) { return false; }
			}

			//V_FB_n
			if (!CCommandTx.ReadSvNet(CParamID.V_FB_n, ref BackupParameter[CParamID.V_FB_n])) { return false; }
			//P_FB_n
			//if (!CCommandTx.ReadSvNet(CParamID.P_FB_n, ref BackupParameter[CParamID.P_FB_n])) { return false; }
	
			//C_NF1-f
			if (!CCommandTx.ReadSvNet(CParamID.C_NF1_f, ref BackupParameter[CParamID.C_NF1_f])) { return false; }
			//C_NF1-d
			if (!CCommandTx.ReadSvNet(CParamID.C_NF1_d, ref BackupParameter[CParamID.C_NF1_d])) { return false; }
			//C_NF1-q
			if (!CCommandTx.ReadSvNet(CParamID.C_NF1_q, ref BackupParameter[CParamID.C_NF1_q])) { return false; }
	
			//C_NF2-f
			if (!CCommandTx.ReadSvNet(CParamID.C_NF2_f, ref BackupParameter[CParamID.C_NF2_f])) { return false; }
			//C_NF2-d
			if (!CCommandTx.ReadSvNet(CParamID.C_NF2_d, ref BackupParameter[CParamID.C_NF2_d])) { return false; }
			//C_NF2-q
			if (!CCommandTx.ReadSvNet(CParamID.C_NF2_q, ref BackupParameter[CParamID.C_NF2_q])) { return false; }
	
			//C_NF3-f
			if (!CCommandTx.ReadSvNet(CParamID.C_NF3_f, ref BackupParameter[CParamID.C_NF3_f])) { return false; }
			//C_NF3-d
			if (!CCommandTx.ReadSvNet(CParamID.C_NF3_d, ref BackupParameter[CParamID.C_NF3_d])) { return false; }
			//C_NF3-q
			if (!CCommandTx.ReadSvNet(CParamID.C_NF3_q, ref BackupParameter[CParamID.C_NF3_q])) { return false; }
	
			//C_NF4-f
			if (!CCommandTx.ReadSvNet(CParamID.C_NF4_f, ref BackupParameter[CParamID.C_NF4_f])) { return false; }
			//C_NF4-d
			if (!CCommandTx.ReadSvNet(CParamID.C_NF4_d, ref BackupParameter[CParamID.C_NF4_d])) { return false; }
			//C_NF4-q
			if (!CCommandTx.ReadSvNet(CParamID.C_NF4_q, ref BackupParameter[CParamID.C_NF4_q])) { return false; }
	
			//C_NF5-f
			if (!CCommandTx.ReadSvNet(CParamID.C_NF5_f, ref BackupParameter[CParamID.C_NF5_f])) { return false; }
			//C_NF5-d
			if (!CCommandTx.ReadSvNet(CParamID.C_NF5_d, ref BackupParameter[CParamID.C_NF5_d])) { return false; }
			//C_NF5-q
			if (!CCommandTx.ReadSvNet(CParamID.C_NF5_q, ref BackupParameter[CParamID.C_NF5_q])) { return false; }

			//KvffGain
			if (!CCommandTx.ReadSvNet(CParamID.KvffGain, ref BackupParameter[CParamID.KvffGain])) { return false; }
			//KvffFillter
			if (!CCommandTx.ReadSvNet(CParamID.KvffFillter, ref BackupParameter[CParamID.KvffFillter])) { return false; }

			//FrictionCwTrq
			if (!CCommandTx.ReadSvNet(CParamID.FrictionCwTrq, ref BackupParameter[CParamID.FrictionCwTrq])) { return false; }
			//FrictionCcwTrq
			if (!CCommandTx.ReadSvNet(CParamID.FrictionCcwTrq, ref BackupParameter[CParamID.FrictionCcwTrq])) { return false; }
			//FrictionDynamicTrq
			if (!CCommandTx.ReadSvNet(CParamID.FrictionDynamicTrq, ref BackupParameter[CParamID.FrictionDynamicTrq])) { return false; }
			//FrictionGravityTrq
			if (!CCommandTx.ReadSvNet(CParamID.FrictionGravityTrq, ref BackupParameter[CParamID.FrictionGravityTrq])) { return false; }

			//TorqueObserverGain
			if (!CCommandTx.ReadSvNet(CParamID.TorqueObserverGain, ref BackupParameter[CParamID.TorqueObserverGain])) { return false; }
			//TorqueObserverFreq
			if (!CCommandTx.ReadSvNet(CParamID.TorqueObserverFreq, ref BackupParameter[CParamID.TorqueObserverFreq])) { return false; }
	
			//VelocityObserverTime
			if (!CCommandTx.ReadSvNet(CParamID.VelocityObserverTime, ref BackupParameter[CParamID.VelocityObserverTime])) { return false; }
			//VelocityObserverGain1
			if (!CCommandTx.ReadSvNet(CParamID.VelocityObserverGain1, ref BackupParameter[CParamID.VelocityObserverGain1])) { return false; }
			//VelocityObserverGain2
			if (!CCommandTx.ReadSvNet(CParamID.VelocityObserverGain2, ref BackupParameter[CParamID.VelocityObserverGain2])) { return false; }

			//ModelControlGain1
			if (!CCommandTx.ReadSvNet(CParamID.ModelControlGain1, ref BackupParameter[CParamID.ModelControlGain1])) { return false; }

			if (MainForm.DriverRevision >= AppConst.UpTadVer520)
			{
				//ModelControlGain2
				if (!CCommandTx.ReadSvNet(CParamID.ModelControlGain2, ref BackupParameter[CParamID.ModelControlGain2])) { return false; }
				//ModelControlGain3
				if (!CCommandTx.ReadSvNet(CParamID.ModelControlGain3, ref BackupParameter[CParamID.ModelControlGain3])) { return false; }
				//ModelControlGain4
				if (!CCommandTx.ReadSvNet(CParamID.ModelControlGain4, ref BackupParameter[CParamID.ModelControlGain4])) { return false; }
				//ModelControlGain5
				if (!CCommandTx.ReadSvNet(CParamID.ModelControlGain5, ref BackupParameter[CParamID.ModelControlGain5])) { return false; }

				//ModelControlFillter1
				if (!CCommandTx.ReadSvNet(CParamID.ModelControlFillter1, ref BackupParameter[CParamID.ModelControlFillter1])) { return false; }
				//ModelControlFillter2
				if (!CCommandTx.ReadSvNet(CParamID.ModelControlFillter2, ref BackupParameter[CParamID.ModelControlFillter2])) { return false; }
				//ModelControlFillter3
				if (!CCommandTx.ReadSvNet(CParamID.ModelControlFillter3, ref BackupParameter[CParamID.ModelControlFillter3])) { return false; }

				//ModelControlPrm1
				if (!CCommandTx.ReadSvNet(CParamID.ModelControlPrm1, ref BackupParameter[CParamID.ModelControlPrm1])) { return false; }
			}

			return true;
		}

		private bool ReStoreNewFillter()
		{
			//ObserverSW
			if (!CCommandTx.WriteSvNet(CParamID.ObserberSwitch, BackupParameter[CParamID.ObserberSwitch])) { return false; }
			if (!VerifyWriteParameter(CParamID.ObserberSwitch, BackupParameter[CParamID.ObserberSwitch])) { return false; }

			//C_LPF_f
			if (!CCommandTx.WriteSvNet(CParamID.C_LPF_f, BackupParameter[CParamID.C_LPF_f])) { return false; }
			if (!VerifyWriteParameter(CParamID.C_LPF_f, BackupParameter[CParamID.C_LPF_f])) { return false; }
			//C_LPF_n
			if (!CCommandTx.WriteSvNet(CParamID.C_LPF_n, BackupParameter[CParamID.C_LPF_n])) { return false; }
			if (!VerifyWriteParameter(CParamID.C_LPF_n, BackupParameter[CParamID.C_LPF_n])) { return false; }
			//V_LPF_f
			if (!CCommandTx.WriteSvNet(CParamID.V_LPF_f, BackupParameter[CParamID.V_LPF_f])) { return false; }
			if (!VerifyWriteParameter(CParamID.V_LPF_f, BackupParameter[CParamID.V_LPF_f])) { return false; }

			if (MainForm.DriverRevision >= AppConst.UpTadVer520)
			{
				//C_FB_Lpf
				if (!CCommandTx.WriteSvNet(CParamID.C_FB_Lpf, BackupParameter[CParamID.C_FB_Lpf])) { return false; }
				if (!VerifyWriteParameter(CParamID.C_FB_Lpf, BackupParameter[CParamID.C_FB_Lpf])) { return false; }
				//V_FB_Lpf
				if (!CCommandTx.WriteSvNet(CParamID.V_FB_Lpf, BackupParameter[CParamID.V_FB_Lpf])) { return false; }
				if (!VerifyWriteParameter(CParamID.V_FB_Lpf, BackupParameter[CParamID.V_FB_Lpf])) { return false; }
			}

			//V_FB_n
			if (!CCommandTx.WriteSvNet(CParamID.V_FB_n, BackupParameter[CParamID.V_FB_n])) { return false; }
			if (!VerifyWriteParameter(CParamID.V_FB_n, BackupParameter[CParamID.V_FB_n])) { return false; }
			//P_FB_n
			//if (!CCommandTx.WriteSvNet(CParamID.P_FB_n, BackupParameter[CParamID.P_FB_n])) { return false; }
			//if (!VerifyWriteParameter(CParamID.P_FB_n, BackupParameter[CParamID.P_FB_n])) { return false; }

			//C_NF1-f
			if (!CCommandTx.WriteSvNet(CParamID.C_NF1_f, BackupParameter[CParamID.C_NF1_f])) { return false; }
			if (!VerifyWriteParameter(CParamID.C_NF1_f, BackupParameter[CParamID.C_NF1_f])) { return false; }
			//C_NF1-d
			if (!CCommandTx.WriteSvNet(CParamID.C_NF1_d, BackupParameter[CParamID.C_NF1_d])) { return false; }
			if (!VerifyWriteParameter(CParamID.C_NF1_d, BackupParameter[CParamID.C_NF1_d])) { return false; }
			//C_NF1-q
			if (!CCommandTx.WriteSvNet(CParamID.C_NF1_q, BackupParameter[CParamID.C_NF1_q])) { return false; }
			if (!VerifyWriteParameter(CParamID.C_NF1_q, BackupParameter[CParamID.C_NF1_q])) { return false; }

			//C_NF2-f
			if (!CCommandTx.WriteSvNet(CParamID.C_NF2_f, BackupParameter[CParamID.C_NF2_f])) { return false; }
			if (!VerifyWriteParameter(CParamID.C_NF2_f, BackupParameter[CParamID.C_NF2_f])) { return false; }
			//C_NF2-d
			if (!CCommandTx.WriteSvNet(CParamID.C_NF2_d, BackupParameter[CParamID.C_NF2_d])) { return false; }
			if (!VerifyWriteParameter(CParamID.C_NF2_d, BackupParameter[CParamID.C_NF2_d])) { return false; }
			//C_NF2-q
			if (!CCommandTx.WriteSvNet(CParamID.C_NF2_q, BackupParameter[CParamID.C_NF2_q])) { return false; }
			if (!VerifyWriteParameter(CParamID.C_NF2_q, BackupParameter[CParamID.C_NF2_q])) { return false; }

			//C_NF3-f
			if (!CCommandTx.WriteSvNet(CParamID.C_NF3_f, BackupParameter[CParamID.C_NF3_f])) { return false; }
			if (!VerifyWriteParameter(CParamID.C_NF3_f, BackupParameter[CParamID.C_NF3_f])) { return false; }
			//C_NF3-d
			if (!CCommandTx.WriteSvNet(CParamID.C_NF3_d, BackupParameter[CParamID.C_NF3_d])) { return false; }
			if (!VerifyWriteParameter(CParamID.C_NF3_d, BackupParameter[CParamID.C_NF3_d])) { return false; }
			//C_NF3-q
			if (!CCommandTx.WriteSvNet(CParamID.C_NF3_q, BackupParameter[CParamID.C_NF3_q])) { return false; }
			if (!VerifyWriteParameter(CParamID.C_NF3_q, BackupParameter[CParamID.C_NF3_q])) { return false; }

			//C_NF4-f
			if (!CCommandTx.WriteSvNet(CParamID.C_NF4_f, BackupParameter[CParamID.C_NF4_f])) { return false; }
			if (!VerifyWriteParameter(CParamID.C_NF4_f, BackupParameter[CParamID.C_NF4_f])) { return false; }
			//C_NF4-d
			if (!CCommandTx.WriteSvNet(CParamID.C_NF4_d, BackupParameter[CParamID.C_NF4_d])) { return false; }
			if (!VerifyWriteParameter(CParamID.C_NF4_d, BackupParameter[CParamID.C_NF4_d])) { return false; }
			//C_NF4-q
			if (!CCommandTx.WriteSvNet(CParamID.C_NF4_q, BackupParameter[CParamID.C_NF4_q])) { return false; }
			if (!VerifyWriteParameter(CParamID.C_NF4_q, BackupParameter[CParamID.C_NF4_q])) { return false; }

			//C_NF5-f
			if (!CCommandTx.WriteSvNet(CParamID.C_NF5_f, BackupParameter[CParamID.C_NF5_f])) { return false; }
			if (!VerifyWriteParameter(CParamID.C_NF5_f, BackupParameter[CParamID.C_NF5_f])) { return false; }
			//C_NF5-d
			if (!CCommandTx.WriteSvNet(CParamID.C_NF5_d, BackupParameter[CParamID.C_NF5_d])) { return false; }
			if (!VerifyWriteParameter(CParamID.C_NF5_d, BackupParameter[CParamID.C_NF5_d])) { return false; }
			//C_NF5-q
			if (!CCommandTx.WriteSvNet(CParamID.C_NF5_q, BackupParameter[CParamID.C_NF5_q])) { return false; }
			if (!VerifyWriteParameter(CParamID.C_NF5_q, BackupParameter[CParamID.C_NF5_q])) { return false; }

			//KvffGain
			if (!CCommandTx.WriteSvNet(CParamID.KvffGain, BackupParameter[CParamID.KvffGain])) { return false; }
			if (!VerifyWriteParameter(CParamID.KvffGain, BackupParameter[CParamID.KvffGain])) { return false; }
			//KvffFillter
			if (!CCommandTx.WriteSvNet(CParamID.KvffFillter, BackupParameter[CParamID.KvffFillter])) { return false; }
			if (!VerifyWriteParameter(CParamID.KvffFillter, BackupParameter[CParamID.KvffFillter])) { return false; }

			//FrictionCwTrq
			if (!CCommandTx.WriteSvNet(CParamID.FrictionCwTrq, BackupParameter[CParamID.FrictionCwTrq])) { return false; }
			if (!VerifyWriteParameter(CParamID.FrictionCwTrq, BackupParameter[CParamID.FrictionCwTrq])) { return false; }
			//FrictionCcwTrq
			if (!CCommandTx.WriteSvNet(CParamID.FrictionCcwTrq, BackupParameter[CParamID.FrictionCcwTrq])) { return false; }
			if (!VerifyWriteParameter(CParamID.FrictionCcwTrq, BackupParameter[CParamID.FrictionCcwTrq])) { return false; }
			//FrictionDynamicTrq
			if (!CCommandTx.WriteSvNet(CParamID.FrictionDynamicTrq, BackupParameter[CParamID.FrictionDynamicTrq])) { return false; }
			if (!VerifyWriteParameter(CParamID.FrictionDynamicTrq, BackupParameter[CParamID.FrictionDynamicTrq])) { return false; }
			//FrictionGravityTrq
			if (!CCommandTx.WriteSvNet(CParamID.FrictionGravityTrq, BackupParameter[CParamID.FrictionGravityTrq])) { return false; }
			if (!VerifyWriteParameter(CParamID.FrictionGravityTrq, BackupParameter[CParamID.FrictionGravityTrq])) { return false; }

			//TorqueObserverGain
			if (!CCommandTx.WriteSvNet(CParamID.TorqueObserverGain, BackupParameter[CParamID.TorqueObserverGain])) { return false; }
			if (!VerifyWriteParameter(CParamID.TorqueObserverGain, BackupParameter[CParamID.TorqueObserverGain])) { return false; }
			//TorqueObserverFreq
			if (!CCommandTx.WriteSvNet(CParamID.TorqueObserverFreq, BackupParameter[CParamID.TorqueObserverFreq])) { return false; }
			if (!VerifyWriteParameter(CParamID.TorqueObserverFreq, BackupParameter[CParamID.TorqueObserverFreq])) { return false; }

			//VelocityObserverTime
			if (!CCommandTx.WriteSvNet(CParamID.VelocityObserverTime, BackupParameter[CParamID.VelocityObserverTime])) { return false; }
			if (!VerifyWriteParameter(CParamID.VelocityObserverTime, BackupParameter[CParamID.VelocityObserverTime])) { return false; }
			//VelocityObserverGain1
			if (!CCommandTx.WriteSvNet(CParamID.VelocityObserverGain1, BackupParameter[CParamID.VelocityObserverGain1])) { return false; }
			if (!VerifyWriteParameter(CParamID.VelocityObserverGain1, BackupParameter[CParamID.VelocityObserverGain1])) { return false; }
			//VelocityObserverGain2
			if (!CCommandTx.WriteSvNet(CParamID.VelocityObserverGain2, BackupParameter[CParamID.VelocityObserverGain2])) { return false; }
			if (!VerifyWriteParameter(CParamID.VelocityObserverGain2, BackupParameter[CParamID.VelocityObserverGain2])) { return false; }

			//ModelControlGain1
			if (!CCommandTx.WriteSvNet(CParamID.ModelControlGain1, BackupParameter[CParamID.ModelControlGain1])) { return false; }
			if (!VerifyWriteParameter(CParamID.ModelControlGain1, BackupParameter[CParamID.ModelControlGain1])) { return false; }

			if (MainForm.DriverRevision >= AppConst.UpTadVer520)
			{
				//ModelControlGain2
				if (!CCommandTx.WriteSvNet(CParamID.ModelControlGain2, BackupParameter[CParamID.ModelControlGain2])) { return false; }
				if (!VerifyWriteParameter(CParamID.ModelControlGain2, BackupParameter[CParamID.ModelControlGain2])) { return false; }
				//ModelControlGain3
				if (!CCommandTx.WriteSvNet(CParamID.ModelControlGain3, BackupParameter[CParamID.ModelControlGain3])) { return false; }
				if (!VerifyWriteParameter(CParamID.ModelControlGain3, BackupParameter[CParamID.ModelControlGain3])) { return false; }
				//ModelControlGain4
				if (!CCommandTx.WriteSvNet(CParamID.ModelControlGain4, BackupParameter[CParamID.ModelControlGain4])) { return false; }
				if (!VerifyWriteParameter(CParamID.ModelControlGain4, BackupParameter[CParamID.ModelControlGain4])) { return false; }
				//ModelControlGain5
				if (!CCommandTx.WriteSvNet(CParamID.ModelControlGain5, BackupParameter[CParamID.ModelControlGain5])) { return false; }
				if (!VerifyWriteParameter(CParamID.ModelControlGain5, BackupParameter[CParamID.ModelControlGain5])) { return false; }

				//ModelControlFillter1
				if (!CCommandTx.WriteSvNet(CParamID.ModelControlFillter1, BackupParameter[CParamID.ModelControlFillter1])) { return false; }
				if (!VerifyWriteParameter(CParamID.ModelControlFillter1, BackupParameter[CParamID.ModelControlFillter1])) { return false; }
				//ModelControlFillter2
				if (!CCommandTx.WriteSvNet(CParamID.ModelControlFillter2, BackupParameter[CParamID.ModelControlFillter2])) { return false; }
				if (!VerifyWriteParameter(CParamID.ModelControlFillter2, BackupParameter[CParamID.ModelControlFillter2])) { return false; }
				//ModelControlFillter3
				if (!CCommandTx.WriteSvNet(CParamID.ModelControlFillter3, BackupParameter[CParamID.ModelControlFillter3])) { return false; }
				if (!VerifyWriteParameter(CParamID.ModelControlFillter3, BackupParameter[CParamID.ModelControlFillter3])) { return false; }

				//ModelControlPrm1
				if (!CCommandTx.WriteSvNet(CParamID.ModelControlPrm1, BackupParameter[CParamID.ModelControlPrm1])) { return false; }
				if (!VerifyWriteParameter(CParamID.ModelControlPrm1, BackupParameter[CParamID.ModelControlPrm1])) { return false; }
			}

			return true;
		}

		private bool ClearNewFillter()
		{

			//ObserverSW
			if (!CCommandTx.WriteSvNet(CParamID.ObserberSwitch, 0)) { return false; }
			if (!VerifyWriteParameter(CParamID.ObserberSwitch, 0)) { return false; }

			//C_LPF_f
			if (!CCommandTx.WriteSvNet(CParamID.C_LPF_f, 0)) { return false; }
			if (!VerifyWriteParameter(CParamID.C_LPF_f, 0)) { return false; }
			//C_LPF_n
			if (!CCommandTx.WriteSvNet(CParamID.C_LPF_n, 0)) { return false; }
			if (!VerifyWriteParameter(CParamID.C_LPF_n, 0)) { return false; }
			//V_LPF_f
			if (!CCommandTx.WriteSvNet(CParamID.V_LPF_f, 0)) { return false; }
			if (!VerifyWriteParameter(CParamID.V_LPF_f, 0)) { return false; }

			if (MainForm.DriverRevision >= AppConst.UpTadVer520)
			{
				//C_FB_Lpf
				if (!CCommandTx.WriteSvNet(CParamID.C_FB_Lpf, 0)) { return false; }
				if (!VerifyWriteParameter(CParamID.C_FB_Lpf, 0)) { return false; }
				//V_FB_Lpf
				if (!CCommandTx.WriteSvNet(CParamID.V_FB_Lpf, 0)) { return false; }
				if (!VerifyWriteParameter(CParamID.V_FB_Lpf, 0)) { return false; }
			}

			//V_FB_n
			if (!CCommandTx.WriteSvNet(CParamID.V_FB_n, 0)) { return false; }
			if (!VerifyWriteParameter(CParamID.V_FB_n, 0)) { return false; }
			//P_FB_n
			//if (!CCommandTx.WriteSvNet(CParamID.P_FB_n, 0)) { return false; }
			//if (!VerifyWriteParameter(CParamID.P_FB_n, 0)) { return false; }

			//C_NF1-f
			if (!CCommandTx.WriteSvNet(CParamID.C_NF1_f, 0)) { return false; }
			if (!VerifyWriteParameter(CParamID.C_NF1_f, 0)) { return false; }
			//C_NF1-d
			if (!CCommandTx.WriteSvNet(CParamID.C_NF1_d, 0)) { return false; }
			if (!VerifyWriteParameter(CParamID.C_NF1_d, 0)) { return false; }
			//C_NF1-q
			if (!CCommandTx.WriteSvNet(CParamID.C_NF1_q, 50)) { return false; }
			if (!VerifyWriteParameter(CParamID.C_NF1_q, 50)) { return false; }

			//C_NF2-f
			if (!CCommandTx.WriteSvNet(CParamID.C_NF2_f, 0)) { return false; }
			if (!VerifyWriteParameter(CParamID.C_NF2_f, 0)) { return false; }
			//C_NF2-d
			if (!CCommandTx.WriteSvNet(CParamID.C_NF2_d, 0)) { return false; }
			if (!VerifyWriteParameter(CParamID.C_NF2_d, 0)) { return false; }
			//C_NF2-q
			if (!CCommandTx.WriteSvNet(CParamID.C_NF2_q, 50)) { return false; }
			if (!VerifyWriteParameter(CParamID.C_NF2_q, 50)) { return false; }

			//C_NF3-f
			if (!CCommandTx.WriteSvNet(CParamID.C_NF3_f, 0)) { return false; }
			if (!VerifyWriteParameter(CParamID.C_NF3_f, 0)) { return false; }
			//C_NF3-d
			if (!CCommandTx.WriteSvNet(CParamID.C_NF3_d, 0)) { return false; }
			if (!VerifyWriteParameter(CParamID.C_NF3_d, 0)) { return false; }
			//C_NF3-q
			if (!CCommandTx.WriteSvNet(CParamID.C_NF3_q, 50)) { return false; }
			if (!VerifyWriteParameter(CParamID.C_NF3_q, 50)) { return false; }

			//C_NF4-f
			if (!CCommandTx.WriteSvNet(CParamID.C_NF4_f, 0)) { return false; }
			if (!VerifyWriteParameter(CParamID.C_NF4_f, 0)) { return false; }
			//C_NF4-d
			if (!CCommandTx.WriteSvNet(CParamID.C_NF4_d, 0)) { return false; }
			if (!VerifyWriteParameter(CParamID.C_NF4_d, 0)) { return false; }
			//C_NF4-q
			if (!CCommandTx.WriteSvNet(CParamID.C_NF4_q, 50)) { return false; }
			if (!VerifyWriteParameter(CParamID.C_NF4_q, 50)) { return false; }

			//C_NF5-f
			if (!CCommandTx.WriteSvNet(CParamID.C_NF5_f, 0)) { return false; }
			if (!VerifyWriteParameter(CParamID.C_NF5_f, 0)) { return false; }
			//C_NF5-d
			if (!CCommandTx.WriteSvNet(CParamID.C_NF5_d, 0)) { return false; }
			if (!VerifyWriteParameter(CParamID.C_NF5_d, 0)) { return false; }
			//C_NF5-q
			if (!CCommandTx.WriteSvNet(CParamID.C_NF5_q, 50)) { return false; }
			if (!VerifyWriteParameter(CParamID.C_NF5_q, 50)) { return false; }

			//KvffGain
			if (!CCommandTx.WriteSvNet(CParamID.KvffGain, 0)) { return false; }
			if (!VerifyWriteParameter(CParamID.KvffGain, 0)) { return false; }
			//KvffFillter
			if (!CCommandTx.WriteSvNet(CParamID.KvffFillter, 0)) { return false; }
			if (!VerifyWriteParameter(CParamID.KvffFillter, 0)) { return false; }

			/*
			//FrictionCwTrq
			if (!CCommandTx.WriteSvNet(CParamID.FrictionCwTrq, 0)) { return false; }
			if (!VerifyWriteParameter(CParamID.FrictionCwTrq, 0)) { return false; }
			//FrictionCcwTrq
			if (!CCommandTx.WriteSvNet(CParamID.FrictionCcwTrq, 0)) { return false; }
			if (!VerifyWriteParameter(CParamID.FrictionCcwTrq, 0)) { return false; }
			//FrictionDynamicTrq
			if (!CCommandTx.WriteSvNet(CParamID.FrictionDynamicTrq, 0)) { return false; }
			if (!VerifyWriteParameter(CParamID.FrictionDynamicTrq, 0)) { return false; }
			//FrictionGravityTrq
			if (!CCommandTx.WriteSvNet(CParamID.FrictionGravityTrq, 0)) { return false; }
			if (!VerifyWriteParameter(CParamID.FrictionGravityTrq, 0)) { return false; }
			*/

			//TorqueObserverGain
			if (!CCommandTx.WriteSvNet(CParamID.TorqueObserverGain, 100)) { return false; }
			if (!VerifyWriteParameter(CParamID.TorqueObserverGain, 100)) { return false; }
			//TorqueObserverFreq
			if (!CCommandTx.WriteSvNet(CParamID.TorqueObserverFreq, 500)) { return false; }
			if (!VerifyWriteParameter(CParamID.TorqueObserverFreq, 500)) { return false; }

			//VelocityObserverTime
			if (!CCommandTx.WriteSvNet(CParamID.VelocityObserverTime, 5)) { return false; }
			if (!VerifyWriteParameter(CParamID.VelocityObserverTime, 5)) { return false; }
			//VelocityObserverGain1
			if (!CCommandTx.WriteSvNet(CParamID.VelocityObserverGain1, 50)) { return false; }
			if (!VerifyWriteParameter(CParamID.VelocityObserverGain1, 50)) { return false; }
			//VelocityObserverGain2
			if (!CCommandTx.WriteSvNet(CParamID.VelocityObserverGain2, 50)) { return false; }
			if (!VerifyWriteParameter(CParamID.VelocityObserverGain2, 50)) { return false; }

			//ModelControlGain1
			if (!CCommandTx.WriteSvNet(CParamID.ModelControlGain1, 100)) { return false; }
			if (!VerifyWriteParameter(CParamID.ModelControlGain1, 100)) { return false; }

			if (MainForm.DriverRevision >= AppConst.UpTadVer520)
			{
				//ModelControlGain2
				if (!CCommandTx.WriteSvNet(CParamID.ModelControlGain2, 100)) { return false; }
				if (!VerifyWriteParameter(CParamID.ModelControlGain2, 100)) { return false; }
				//ModelControlGain3
				if (!CCommandTx.WriteSvNet(CParamID.ModelControlGain3, 100)) { return false; }
				if (!VerifyWriteParameter(CParamID.ModelControlGain3, 100)) { return false; }
				//ModelControlGain4
				if (!CCommandTx.WriteSvNet(CParamID.ModelControlGain4, 100)) { return false; }
				if (!VerifyWriteParameter(CParamID.ModelControlGain4, 100)) { return false; }
				//ModelControlGain5
				if (!CCommandTx.WriteSvNet(CParamID.ModelControlGain5, 100)) { return false; }
				if (!VerifyWriteParameter(CParamID.ModelControlGain5, 100)) { return false; }

				//ModelControlFillter1
				if (!CCommandTx.WriteSvNet(CParamID.ModelControlFillter1, 0)) { return false; }
				if (!VerifyWriteParameter(CParamID.ModelControlFillter1, 0)) { return false; }
				//ModelControlFillter2
				if (!CCommandTx.WriteSvNet(CParamID.ModelControlFillter2, 0)) { return false; }
				if (!VerifyWriteParameter(CParamID.ModelControlFillter2, 0)) { return false; }
				//ModelControlFillter3
				if (!CCommandTx.WriteSvNet(CParamID.ModelControlFillter3, 0)) { return false; }
				if (!VerifyWriteParameter(CParamID.ModelControlFillter3, 0)) { return false; }

				//ModelControlPrm1
				if (!CCommandTx.WriteSvNet(CParamID.ModelControlPrm1, 0)) { return false; }
				if (!VerifyWriteParameter(CParamID.ModelControlPrm1, 0)) { return false; }
			}
		
			return true;
		}

		private bool StoreServoGain()
		{
			if (!CCommandTx.ReadSvNet(CParamID.Kp1, ref BackupParameter[CParamID.Kp1])) { return false; }
			if (!CCommandTx.ReadSvNet(CParamID.Kv1, ref BackupParameter[CParamID.Kv1])) { return false; }
			if (!CCommandTx.ReadSvNet(CParamID.Ki1, ref BackupParameter[CParamID.Ki1])) { return false; }

			if (!CCommandTx.ReadSvNet(CParamID.Load, ref BackupParameter[CParamID.Load])) { return false; }

			return true;
		}

		private bool ReStoreServoGain()
		{
			if (!CCommandTx.WriteSvNet(CParamID.Kp1, BackupParameter[CParamID.Kp1])) { return false; }
			if (!VerifyWriteParameter(CParamID.Kp1, BackupParameter[CParamID.Kp1])) { return false; }

			if (!CCommandTx.WriteSvNet(CParamID.Kv1, BackupParameter[CParamID.Kv1])) { return false; }
			if (!VerifyWriteParameter(CParamID.Kv1, BackupParameter[CParamID.Kv1])) { return false; }

			if (!CCommandTx.WriteSvNet(CParamID.Ki1, BackupParameter[CParamID.Ki1])) { return false; }
			if (!VerifyWriteParameter(CParamID.Ki1, BackupParameter[CParamID.Ki1])) { return false; }

			if (!CCommandTx.WriteSvNet(CParamID.Load, BackupParameter[CParamID.Load])) { return false; }
			if (!VerifyWriteParameter(CParamID.Load, BackupParameter[CParamID.Load])) { return false; }

			return true;
		}

		private void ServoOn()
		{
			int cmd = ReadServoCommand();
		
			cmd |= 0x01;
			
			WriteServoCommand(cmd);
		}

		private void ServoOff()
		{
			int cmd = ReadServoCommand();

			cmd &= ~0x01;

			WriteServoCommand(cmd);
		}

		private void StartProfile()
		{
			int cmd = ReadServoCommand();

			cmd |=  0x02;				//Profile Start bit Set
			cmd &= ~0x30;				//Hard Stop & Smooth Stop bit Clear

			WriteServoCommand(cmd);
		}

		private void ClearStop()
		{
			int cmd = ReadServoCommand();

			cmd &= ~0x30;				//Hard Stop & Smooth Stop bit Clear

			WriteServoCommand(cmd);
		}

		private void SmoothStop()
		{
			int cmd = ReadServoCommand();

			cmd |= 0x20;				//Smooth Stop bit Set

			WriteServoCommand(cmd);

		}

		private void ProfileBitAutoClear()
		{
			int ctrl_sw = CMonitor.GetParameter(CParamID.ControlSwitch);

			ctrl_sw = ctrl_sw | 0x02;

			WriteControlSwitch(ctrl_sw);

		}

		private bool WriteLogKindAutoTuning()
		{
			//位置ログを位置偏差
			if (!CCommandTx.WriteSvNet(CParamID.LogKind1, 0)) { return false; }
			if (!VerifyWriteParameter(CParamID.LogKind1, 0)) { return false; }
			//速度ログを現在速度（モニタ速度）
			if (!CCommandTx.WriteSvNet(CParamID.LogKind2, 0)) { return false; }
			if (!VerifyWriteParameter(CParamID.LogKind2, 0)) { return false; }
			//電流ログを現在電流（モニタ電流）
			if (!CCommandTx.WriteSvNet(CParamID.LogKind3, 0)) { return false; }
			if (!VerifyWriteParameter(CParamID.LogKind3, 0)) { return false; }

			return true;
		}

		private bool WriteProfileData(int pos, int vel, int acc, int dcc)
		{
			if (!CCommandTx.WriteSvNet(CParamID.TargetPosition, pos)) { return false; }
			if (!VerifyWriteParameter(CParamID.TargetPosition, pos)) { return false; }

			if (!CCommandTx.WriteSvNet(CParamID.TargetVelocity, vel)) { return false; }
			if (!VerifyWriteParameter(CParamID.TargetVelocity, vel)) { return false; }
		
			if (!CCommandTx.WriteSvNet(CParamID.TargetAcceleration, acc)) { return false; }
			if (!VerifyWriteParameter(CParamID.TargetAcceleration, acc)) { return false; }
			
			if (!CCommandTx.WriteSvNet(CParamID.TargetDeceleration, dcc)) { return false; }
			if (!VerifyWriteParameter(CParamID.TargetDeceleration, dcc)) { return false; }

			return true;
		}

		private bool WriteTargetPosition(int pos)
		{
			if (!CCommandTx.WriteSvNet(CParamID.TargetPosition, pos)) { return false; }

			if (!VerifyWriteParameter(CParamID.TargetPosition, pos)) { return false; }

			return true;
		}

		private bool WriteTargetVelocity(int vel)
		{
			if (!CCommandTx.WriteSvNet(CParamID.TargetVelocity, vel)) { return false; }

			if (!VerifyWriteParameter(CParamID.TargetVelocity, vel)) { return false; }

			return true;
		}

		private bool WriteCommandVelocity(int vel)
		{
			if (!CCommandTx.WriteSvNet(CParamID.CommandVelocity, vel)) { return false; }

			if (!VerifyWriteParameter(CParamID.CommandVelocity, vel)) { return false; }

			return true;
		}

		private bool WriteVelocityObserver(bool on, bool tdis, int time)
		{
			int obs_sw = CMonitor.GetParameter(CParamID.ObserberSwitch);

			if (on)
			{
				obs_sw |= 0x10;
				//if (!CCommandTx.WriteSvNet(CParamID.VelocityObserverEnable, 1)) { return false; }
				//if (!VerifyWriteParameter(CParamID.VelocityObserverEnable, 1)) { return false; }
			}
			else
			{
				obs_sw &= ~0x10;
				//if (!CCommandTx.WriteSvNet(CParamID.VelocityObserverEnable, 0)) { return false; }
				//if (!VerifyWriteParameter(CParamID.VelocityObserverEnable, 0)) { return false; }
			}

			if (tdis)
			{
				obs_sw |= 0x20;
				//if (!CCommandTx.WriteSvNet(CParamID.VelocityObserverTdis, 1)) { return false; }
				//if (!VerifyWriteParameter(CParamID.VelocityObserverTdis, 1)) { return false; }
			}
			else
			{
				obs_sw &= ~0x20;
				//if (!CCommandTx.WriteSvNet(CParamID.VelocityObserverTdis, 0)) { return false; }
				//if (!VerifyWriteParameter(CParamID.VelocityObserverTdis, 0)) { return false; }
			}

			if (!CCommandTx.WriteSvNet(CParamID.ObserberSwitch, obs_sw)) { return false; }
			if (!VerifyWriteParameter(CParamID.ObserberSwitch, obs_sw)) { return false; }

			if (!CCommandTx.WriteSvNet(CParamID.VelocityObserverTime, time)) { return false; }
			if (!VerifyWriteParameter(CParamID.VelocityObserverTime, time)) { return false; }

			return true;
		}

		private bool WriteControlMode(int mode)
		{
			if (!CCommandTx.WriteSvNet(CParamID.ControlMode, mode)) { return false; }

			if (!VerifyWriteParameter(CParamID.ControlMode, mode)) { return false; }

			return true;
		}

		private bool WritePulseError(int pls)
		{
			//位置偏差エラー検出パルス設定
			if (!CCommandTx.WriteSvNet(CParamID.PositionErrorPulse, pls)) { return false; }

			if (!VerifyWriteParameter(CParamID.PositionErrorPulse, pls)) { return false; }

			return true;
		}

		//20170215 add
		private bool WriteDynamicBreakCondition(int cond)
		{
			//位置偏差エラー検出パルス設定
			if (!CCommandTx.WriteSvNet(CParamID.DynamicBreakCondition, cond)) { return false; }

			if (!VerifyWriteParameter(CParamID.DynamicBreakCondition, cond)) { return false; }

			return true;
		}

		//20170822 add
		private bool WritePositionInputMode(int mode)
		{
			//位置指令選択
			if (!CCommandTx.WriteSvNet(CParamID.PositionInputMode, mode)) { return false; }

			if (!VerifyWriteParameter(CParamID.PositionInputMode, mode)) { return false; }

			return true;
		}

		//20170822 add
		private bool WriteVelocityInputMode(int mode)
		{
			//速度指令選択
			if (!CCommandTx.WriteSvNet(CParamID.VelocityInputMode, mode)) { return false; }

			if (!VerifyWriteParameter(CParamID.VelocityInputMode, mode)) { return false; }

			return true;
		}

		private bool WriteInpositionWidth(int pls)
		{
			if (!CCommandTx.WriteSvNet(CParamID.InpositionWidth, pls)) { return false; }

			if (!VerifyWriteParameter(CParamID.InpositionWidth, pls)) { return false; }

			return true;
		}

		private bool WriteLoadInertia(int load)
		{
			if (!CCommandTx.WriteSvNet(CParamID.Load, load)) { return false; }

			if (!VerifyWriteParameter(CParamID.Load, load)) { return false; }

			return true;
		}

		private bool WriteServoCommand(int cmd)
		{
			if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) { return false; }

			//サーボコマンドはProfileBITが自動OFFの場合がある
			//cmd &= ~0x02;
			//if (!VerifyWriteParameter(CParamID.ServoCommand, cmd)) { return false; }

			return true;
		}

		private bool WriteControlSwitch(int ctrl_sw)
		{
			if (!CCommandTx.WriteSvNet(CParamID.ControlSwitch, ctrl_sw)) { return false; }

			if (!VerifyWriteParameter(CParamID.ControlSwitch, ctrl_sw)) { return false; }

			return true;
		}

		private bool WriteAutoTuningSq(int sq)
		{
			if (!CCommandTx.WriteSvNet(CParamID.AutoTuningSequence, sq)) { return false; }

			if (!VerifyWriteParameter(CParamID.AutoTuningSequence, sq)) { return false; }

			return true;
		}

		private bool WriteTuningVibrationSetting(int div, int cnt)
		{
			if (!CCommandTx.WriteSvNet(CParamID.CurrentVibrationDiv, div)) { return false; }

			if (!VerifyWriteParameter(CParamID.CurrentVibrationDiv, div)) { return false; }

			if (!CCommandTx.WriteSvNet(CParamID.CurrentVibrationCnt, cnt)) { return false; }

			if (!VerifyWriteParameter(CParamID.CurrentVibrationCnt, cnt)) { return false; }

			return true;
		}

		private bool WriteCurrentGain(int kcp, int kci)
		{
			if (!CCommandTx.WriteSvNet(CParamID.Kcp1, kcp)) { return false; }

			if (!VerifyWriteParameter(CParamID.Kcp1, kcp)) { return false; }

			if (!CCommandTx.WriteSvNet(CParamID.Kci1, kci)) { return false; }

			if (!VerifyWriteParameter(CParamID.Kci1, kci)) { return false; }

			return true;
		}

		private bool WriteFeedbackLowpassFillter(int c_fb_f, int v_fb_f)
		{
			if (MainForm.DriverRevision >= AppConst.UpTadVer520)
			{
				if (!CCommandTx.WriteSvNet(CParamID.C_FB_Lpf, c_fb_f)) { return false; }

				if (!VerifyWriteParameter(CParamID.C_FB_Lpf, c_fb_f)) { return false; }

				if (!CCommandTx.WriteSvNet(CParamID.V_FB_Lpf, v_fb_f)) { return false; }

				if (!VerifyWriteParameter(CParamID.V_FB_Lpf, v_fb_f)) { return false; }
			}

			return true;
		}

		private bool WriteFeedbackMovingFillter(int v_fb_n)		//20161031 add
		{
			if (!CCommandTx.WriteSvNet(CParamID.V_FB_n, v_fb_n)) { return false; }

			if (!VerifyWriteParameter(CParamID.V_FB_n, v_fb_n)) { return false; }

			return true;
		}

		private bool WriteLowpassFillter(int frq)
		{
			if (!CCommandTx.WriteSvNet(CParamID.C_LPF_f, frq)) { return false; }

			if (!VerifyWriteParameter(CParamID.C_LPF_f, frq)) { return false; }

			return true;
		}

		private int ReadServoCommand()
		{
			int cmd = new int();

			if (!CCommandTx.ReadSvNet(CParamID.ServoCommand, ref cmd)) { return cmd; }

			return cmd;
		}

		private bool VerifyWriteParameter(int id, int wr_data)
		{
			CDataTool.SetNow(CDataTool.TUNE_TIME);

			int rd_data = new int();

			int x = new int();

			do
			{
				if (x >= 1)
				{
					if (!CCommandTx.WriteSvNet(id, wr_data))
					{
						UserMessageBox.AutoTuningVerifyWriteError();
						return false;
					}

					Thread.Sleep(50);
				}

				if (!CCommandTx.ReadSvNet(id, ref rd_data))
				{
					UserMessageBox.AutoTuningVerifyReadError();
					return false;
				}

				if (CDataTool.IsTimerLimit(CDataTool.TUNE_TIME, 2))
				//if (CDataTool.IsTimerLimit(CDataTool.TUNE_TIME, 5))
				{
					//UserMessageBox.AutoTuningVerifyTimeLimit();
					return false;
				}

				x++;

			} while (wr_data != rd_data);

			return true;
		}

		//20170822 add
		private bool BackupOtherParameter(bool pos_ctrl, int p_err_mul)
		{
			int mode = new int();

			//位置偏差エラー検出パルス保存
			BackupPositionErrorPulse = CMonitor.GetParameter(CParamID.PositionErrorPulse);

			//位置偏差エラー検出パルス設定				20170822 update * p_err_mul		20170217 update *10 → *1
			if (!WritePulseError(EncderResolution * p_err_mul)) { return false; }

			//ダイナミックブレーキ駆動条件保存			20170215 update
			BackupDynamicBreakCondition = CMonitor.GetParameter(CParamID.DynamicBreakCondition);

			//ダイナミックブレーキ駆動条件設定（アラーム発生でダイナミックブレーキ）	20170215 update
			if (!WriteDynamicBreakCondition(1)) { return false; }

			if (pos_ctrl)
			{
				mode = CMonitor.GetParameter(CParamID.PositionInputMode);

				if (mode != 0)
				{
					if (UserMessageBox.JogControlPositionInputModeWarning() == DialogResult.Yes)
					{
						//位置指令選択設定　プロファイル動作可		20170822 add
						if (!WritePositionInputMode(0)) { return false; }

						Thread.Sleep(500);
					}
					else
					{
						return false;
					}
				}
			}
			else
			{
				mode = CMonitor.GetParameter(CParamID.VelocityInputMode);

				if (mode != 0)
				{
					if (UserMessageBox.JogControlVelocityInputModeWarning() == DialogResult.Yes)
					{
						//速度指令選択設定　プロファイル動作可		20170822 add
						if (!WriteVelocityInputMode(0)) { return false; }

						Thread.Sleep(500);
					}
					else
					{
						return false;
					}
				}
			}

			return true;
		}

		#endregion

		#region Servo Gain Parameter

		private bool SetServoGain(int kp, int kv, int ki)
		{
			//サーボゲイン設定
			//Kp1
			if (!CCommandTx.WriteSvNet(CParamID.Kp1, kp)) { return false; }
			AppendResultText(UserText.AutoTuningKpSetup + "\n");
			AppendResultText(UserText.AutoTuningAdjustDot + "Kp1 = " + kp.ToString() + "\n");
			//Kv1
			if (!CCommandTx.WriteSvNet(CParamID.Kv1, kv)) { return false; }
			AppendResultText(UserText.AutoTuningKvSetup + "\n");
			AppendResultText(UserText.AutoTuningAdjustDot + "Kv1 = " + kv.ToString() + "\n");
			//Ki1
			if (!CCommandTx.WriteSvNet(CParamID.Ki1, ki)) { return false; }
			AppendResultText(UserText.AutoTuningKiSetup + "\n");
			AppendResultText(UserText.AutoTuningAdjustDot + "Ki1 = " + ki.ToString() + "\n");

			NowGain.Kpp = kp;
			NowGain.Kvp = kv;
			NowGain.Kvi = ki;

			return true;
		}

		private bool SetKpp(int kpp)
		{
			//サーボゲイン設定
			//Kp1
			if (!CCommandTx.WriteSvNet(CParamID.Kp1, kpp)) { return false; }

			AppendResultText(UserText.AutoTuningKpSetup + "\n");
			AppendResultText(UserText.AutoTuningAdjustDot + "Kp1 = " + kpp.ToString() + "\n");
	
			NowGain.Kpp = kpp;

			return true;
		}

		private bool SetKvp(int kvp)
		{
			//サーボゲイン設定
			//Kv1
			if (!CCommandTx.WriteSvNet(CParamID.Kv1, kvp)) { return false; }

			AppendResultText(UserText.AutoTuningKvSetup + "\n");
			AppendResultText(UserText.AutoTuningAdjustDot + "Kv1 = " + kvp.ToString() + "\n");

			NowGain.Kvp = kvp;

			return true;
		}

		private bool SetKvi(int kvi)
		{
			//サーボゲイン設定
			//Ki1
			if (!CCommandTx.WriteSvNet(CParamID.Ki1, kvi)) { return false; }

			AppendResultText(UserText.AutoTuningKiSetup + "\n");
			AppendResultText(UserText.AutoTuningAdjustDot + "Ki1 = " + kvi.ToString() + "\n");

			NowGain.Kvi = kvi;

			return true;
		}

		#endregion

		#region Load Inertia Function

		private void StartMeasLoadInertia()
		{
			if (!MainForm.IsUsbConnectBlink) { return; }

			if (!CheckTheOtherSequence()) { return; }

			if (JogControlForm.ThisForm != null) { JogControlForm.ThisForm.JogStop(); }		//20161031 add

			DialogResult ret = UserMessageBox.AutoTuningCalcLoadInertia();

			if (ret == DialogResult.Cancel) { return; }

			LoadTuningRefCnt = (int)numLoadTuningCnt.Value * 2;			//イナーシャ推定　　往復回数×2
			TempTuningRefCnt = (int)numTempTuningCnt.Value * 2;			//仮イナーシャ推定　往復回数×2
			TempTuningCoeff = (double)numTempTuningCoeff.Value * 0.01;	//仮イナーシャ推定係数

			LoadTuningBuffer = new int[LoadTuningRefCnt + TempTuningRefCnt];

			tabTuning.SelectTab("tabPageTuningOutput");

			this.Refresh();

			TimerAutoTuing.Enabled = false;

			MainForm.ThisForm.EnableTimerMain = false;		//20161129 add

			//チューニング停止フラグクリア
			ClearPauseAndRepeat();

			//サーボオフ
			ServoOff();

			Thread.Sleep(500);

			//ストップビットクリア
			ClearStop();

			//現在のゲイン＆フィルタ設定値を保存
			if (!StoreServoParameter()) { return; }

			//チューニング後に元に戻すパラメータを保存		20170822 update
			if (!BackupOtherParameter(true, 1)) { return; }

			//位置制御へ
			WriteControlMode(1);

			//瞬時速度オブザーバOFF
			WriteVelocityObserver(false, false, 0);

			//プロファイルデータ設定
			int rev = (int)numLoadTuningRev.Value;
			int vel = (int)numLoadTuningVel.Value;
			int acc = (int)numLoadTuningAcc.Value;

			NowPosition = CMonitor.GetParameter(CParamID.FeedbackPosition);				//20170215 update feedback→command 20170222 update command→feedback

			WriteProfileData(NowPosition + EncderResolution * rev, vel, acc, acc);		//20150315 update
		
			int kp = ctlNumLoadTuningKp.IntValue;
			int kv = ctlNumLoadTuningKv.IntValue;
			int ki = ctlNumLoadTuningKi.IntValue;

			//サーボゲイン設定
			SetServoGain(kp, kv, ki);

			//負荷イナーシャクリア
			WriteLoadInertia(0);

			//フィルタ設定クリア
			ClearFillter();

			switch (EncderType)
			{
				case ENC_TYP_RESOLVER:		//resolver

					SetLowpassFillter(600);
					break;

				case ENC_TYP_COUNT_INC:	//inc

					SetLowpassFillter(600);
					break;

				default:
				case ENC_TYP_17BIT_INC:
				case ENC_TYP_17BIT_ABS:
				case ENC_TYP_20BIT_INC:
				case ENC_TYP_20BIT_ABS:
				case ENC_TYP_23BIT_INC:
				case ENC_TYP_23BIT_ABS:

					SetLowpassFillter(600);
					break;
			}

			Thread.Sleep(500);

			//プロファイルビット自動クリア
			ProfileBitAutoClear();

			//サーボオン
			ServoOn();		//20160406 add

			//オートチューニングシーケンス設定
			SetAutoTuningSq(1);

			Thread.Sleep(500);

			WriteAutoTuningSq(0);

			Thread.Sleep(50);

			LoadTuningMeasEnd = false;
			LoadTuningMeasCnt = 0;
			TempTuningMeasCnt = 0;

			LoadTuningStatusCheckWait = 10;
			LoadTuningUpdateResultWait = 2;

			LoadTuningCounter = 0;

			IsTempTuning = true;

			rtxtResult.Text = "";

			MainForm.IsReadLogOk = true;
						
			AutoTuningLoadInertia(true);

			TimerAutoTuing.Enabled = true;

			MainForm.ThisForm.EnableTimerMain = true;		//20161129 add

		}

		private void AutoTuningLoadInertia(bool cw)
		{
			int pos = new int();
			int rev = (int)numLoadTuningRev.Value;				//20150315 update
		
			if (cw)
			{
				pos = NowPosition + EncderResolution * rev;		//20150315 update
			}
			else
			{
				pos = NowPosition;
			}

			WriteTargetPosition(pos);

			SetAutoTuningSq(AutoTuningSq);						//チューニングシーケンス設定

			StartProfile();

			LoadTuningStatusCheckWait = 10;
			LoadTuningUpdateResultWait = 2;

			Thread.Sleep(100);

		}
	
		private int CalcLoadInertiaResult(int n)
		{
			int load = new int();
			int result = new int();

			for (int i = 0; i < n; i++)
			{
				load += LoadTuningBuffer[i];
			}

			result = load / n;

			return result;
		}

		#endregion

		#region Frequency Sweep Function

		private void StartFrequencySweep()
		{
			if (!MainForm.IsUsbConnectBlink) { return; }

			if (!CheckTheOtherSequence()) { return; }

			if (JogControlForm.ThisForm != null) { JogControlForm.ThisForm.JogStop(); }		//20161031 add

			FrequencySweepDialog frq_form = new FrequencySweepDialog();

			DialogResult ret = frq_form.ShowDialog();

			if (ret != DialogResult.OK) { return; }

			BodeGraphForm.ThisForm.IsViewHold = false;

			ret = UserMessageBox.AutoTuningAdjustServoGain();

			if (ret == DialogResult.Cancel) { return; }

			ClearPauseAndRepeat();

			if (!StoreServoParameter()) { return; }

			//チューニング後に元に戻すパラメータを保存		20170822 update
			if (!BackupOtherParameter(false, 10)) { return; }

			BackupControlMode = CMonitor.GetParameter(CParamID.ControlMode);

			//コマンド速度設定 0rpm
			WriteCommandVelocity(0);

			//速度制御へ
			WriteControlMode(2);

			SweepVelocity = FrequencySweepDialog.SweepVelocity;
			SweepMaxFrq = FrequencySweepDialog.SweepMaxFrq;

			if (SweepVelocity <= 100) { SweepVelocity = 100; }
			if (SweepMaxFrq <= 20) { SweepMaxFrq = 20; }

			//ターゲット速度設定
			WriteTargetVelocity(SweepVelocity);

			//スイープ最大周波数
			CCommandTx.WriteSvNet(CParamID.SweepMaxFrq, SweepMaxFrq);
			
			Thread.Sleep(500);

			//プロファイルビット自動クリア
			ProfileBitAutoClear();

			//サーボオン
			ServoOn();

			Thread.Sleep(500);

			//オートチューニングシーケンス設定
			SetAutoTuningSq(2);

			Thread.Sleep(500);

			LoadTuningMeasCnt = 0;
			TimerAutoTuing.Enabled = true;
		}

		#endregion

		#region Friction Compensation Function

		private void StartFrictionCompensation()
		{
			if (!MainForm.IsUsbConnectBlink) { return; }

			if (!CheckTheOtherSequence()) { return; }

			if (JogControlForm.ThisForm != null) { JogControlForm.ThisForm.JogStop(); }		//20161031 add

			FrictionControlDialog frc_form = new FrictionControlDialog();

			DialogResult ret = frc_form.ShowDialog();

			if (ret != DialogResult.OK) { return; }

			ret = UserMessageBox.AutoTuningFrictionCompensation();

			if (ret == DialogResult.Cancel) { return; }

			tabTuning.SelectTab("tabPageTuningOutput");

			this.Refresh();

			TimerAutoTuing.Enabled = false;

			//チューニング停止フラグクリア
			ClearPauseAndRepeat();

			//サーボオフ
			ServoOff();

			Thread.Sleep(500);

			//ストップビットクリア
			ClearStop();

			//現在のゲイン＆フィルタ設定値を保存
			if (StoreServoParameter()) { return; }

			int mode = CMonitor.GetParameter(CParamID.ControlMode);

			//摩擦補正自動補正モードへ
			WriteControlMode(6);

			Thread.Sleep(500);

			//サーボオン
			ServoOn();

			Thread.Sleep(500);		//20160406 add

			rtxtResult.AppendText("\n");
			rtxtResult.AppendText(UserText.AutoTuningFrictionStart);
			rtxtResult.AppendText("\n");
			rtxtResult.AppendText("\n");

			rtxtResult.AppendText(UserText.AutoTuningFrictionCalc);
			rtxtResult.AppendText("\n");
			rtxtResult.AppendText("\n");

			rtxtResult.ScrollToCaret();
			rtxtResult.Update();

			SaveMsg = new SaveProgressDialog();

			SaveMsg.StartFrictionCompensation(this.Location, this.Size, 20);

			SaveMsg.Close();

			int cw_trq = CMonitor.GetParameter(CParamID.FrictionCwTrq);
			int ccw_trq = CMonitor.GetParameter(CParamID.FrictionCcwTrq);

			rtxtResult.AppendText(UserText.AutoTuningCwNowValue + "  " + cw_trq.ToString() + " [0.01A] ");
			rtxtResult.AppendText("\n");
			rtxtResult.AppendText(UserText.AutoTuningCcwNowValue + "  " + ccw_trq.ToString() + " [0.01A] ");
			rtxtResult.AppendText("\n");

			rtxtResult.AppendText("\n");
			rtxtResult.AppendText(UserText.AutoTuningFrictionFinish);
			rtxtResult.AppendText("\n");
			rtxtResult.AppendText("\n");

			rtxtResult.ScrollToCaret();

			//制御モードを元に戻す
			WriteControlMode(mode);

			UserMessageBox.AutoTuningFrictionCompensationFinish(cw_trq.ToString(), ccw_trq.ToString());

		}

		#endregion

		#region Test Tuning

		private void StartTestTuning()
		{
			TimerAutoTuing.Enabled = false;

			//サーボオフ
			ServoOff();

			Thread.Sleep(500);

			//ストップビットクリア
			ClearStop();

			if (chkInc.Checked)
			{
				NowPosition = CMonitor.GetParameter(CParamID.FeedbackPosition);		//20170215 update feedback→command 20170222 update command→feedback
			}
			else
			{
				NowPosition = ctlNumStartPosition.IntValue;
			}

			UserParameter.StartPosition = NowPosition;

			int now = ctlNumStartPosition.IntValue;
			int pos = ctlNumTargetPosition.IntValue;
			int vel = ctlNumTargetVelocity.IntValue;
			int acc = ctlNumTargetAcceleration.IntValue;
			int dcc = ctlNumTargetDeceleration.IntValue;
			int wait = ctlNumWaitTime.IntValue;
			int inpos = ctlNumInposition.IntValue;

			//プロファイルデータ設定
			WriteProfileData(pos, vel, acc, dcc);

			//インポジション検出パルス数設定　※ユーザー設定項目
			WriteInpositionWidth(inpos);

			//位置偏差エラー検出パルス保存
			BackupPositionErrorPulse = CMonitor.GetParameter(CParamID.PositionErrorPulse);

			//位置偏差エラー検出パルス設定
			WritePulseError(EncderResolution * 10);

			//ダイナミックブレーキ駆動条件保存	20170215 update
			BackupDynamicBreakCondition = CMonitor.GetParameter(CParamID.DynamicBreakCondition);

			//ダイナミックブレーキ駆動条件設定（アラーム発生でダイナミックブレーキ）	20170215 update
			WriteDynamicBreakCondition(1);

			//位置制御へ
			WriteControlMode(1);

			Thread.Sleep(500);

			//プロファイルビット自動クリア
			ProfileBitAutoClear();

			//サーボオン
			ServoOn();		//20160406 add

			Thread.Sleep(500);

			//オートチューニングシーケンス設定
			AutoTuningSq = 100;

			MoveTestTuning(true);

			TimerAutoTuing.Enabled = true;

		}

		private void MoveTestTuning(bool cw)
		{

			int pos = new int();

			if (cw)
			{
				if (chkInc.Checked)
				{
					pos = NowPosition + ctlNumTargetPosition.IntValue;
				}
				else
				{
					pos = ctlNumTargetPosition.IntValue;
				}
			}
			else
			{
				pos = NowPosition;
			}

			UserParameter.TargetPosition = pos;

			//now_pos + 2rev
			WriteTargetPosition(pos);

			StartProfile();

		}

		#endregion

		#region Timer Event

		private bool CW_Move_Ok = new bool();
		private int  ServoStatus = new int();
		private int  ServoErrorCounter = new int();

		private int AutoTuningUsbErrorCnt = new int();		//20170127 add

		private void TimerAutoTuing_Tick(object sender, EventArgs e)
		{
			if (MainForm.IsUsbWait) { return; }

			if (!MainForm.IsUsbConnect)
			{
				AutoTuningUsbErrorCnt++;

				if (AutoTuningSq >= 1 && AutoTuningSq <= 3)
				{
					int usb_wait = 3000 / TimerAutoTuing.Interval;		//3秒間待ち	20170217 update 10 → 3

					if (AutoTuningUsbErrorCnt >= usb_wait)
					{
						TimerAutoTuing.Enabled = false;
						AutoTuningSq = 0;
						UserMessageBox.AutoTuningVerifyTimeLimit();
					}
				}
				else
				{
					TimerAutoTuing.Enabled = false;
					AutoTuningSq = 0;				
				}

				return;
			}

			AutoTuningUsbErrorCnt = 0;

			CCommandTx.ReadSvNet(CParamID.ServoStatus, ref ServoStatus);

			if ((ServoStatus & 0x08) == 0x08)
			{
				if (++ServoErrorCounter <= 5) { return; }

				//アラーム発生中
				TimerAutoTuing.Enabled = false;
				ClearAutoTuningSq();

				pnlVibration.BackColor = Color.LightPink;
				lblVibration.Text = UserText.AutoTuningAlarmDetect;
				UserMessageBox.AutoTuningAlarmDetect();
				return;
			}

			if ((ServoStatus & 0x01) == 0x00 && IsWaitVB == false)
			{
				if (++ServoErrorCounter <= 5) { return; }

				//サーボオフ
				TimerAutoTuing.Enabled = false;
				ClearAutoTuningSq();

				UserMessageBox.AutoTuningServoOffInformation();
				return;
			}

			ServoErrorCounter = 0;

			if ((ServoStatus & 0x40000) == 0x40000)
			{
				//振動検出
				lblVibration.BackColor = Color.LightPink;
				lblVibration.Text = UserText.AutoTuningVibrationDetect;
				_IsCurrentVB = true;
			}
			else
			{
				lblVibration.BackColor = Color.LightCyan;
				lblVibration.Text = UserText.AutoTuningReady;
			}

			switch (AutoTuningSq)
			{
				#region 負荷イナーシャ推定
				case 1:

					if (--LoadTuningStatusCheckWait >= 0) { break; }

					if ((ServoStatus & 0x02) == 0x02)
					{
						//プロファイル動作中
					}
					else
					{
						if (--LoadTuningUpdateResultWait >= 0) { break; }

						int load = new int();

                        // ↓↓↓ 20210324 Kimura update ↓↓↓
                        int motor =  CDataTool.GetInertiaDiameter(CMonitor.GetParameter(CParamID.MotorInertia));
                        //int motor = CMonitor.GetParameter(CParamID.MotorInertia);
                        // ↑↑↑ 20210324 Kimura update ↑↑↑

						//チューニングシーケンスリセット
						CCommandTx.WriteSvNet(CParamID.AutoTuningSequence, 0);

						Thread.Sleep(50);

						CCommandTx.ReadSvNet(CParamID.TempLoadInertia, ref load);

                        // ↓↓↓ 20210324 Kimura add ↓↓↓
                        string strload = load.ToString();
                        load = CDataTool.GetInertiaDiameter(load);
                        // ↑↑↑ 20210324 Kimura add ↑↑↑

                        LoadTuningBuffer[LoadTuningCounter] = load;

						LoadTuningCounter++;

						if (LoadTuningCounter >= LoadTuningBuffer.Length)							//20170131 add
						{
							LoadTuningCounter = LoadTuningBuffer.Length - 1;
						}
					
						if (MainForm.IsReadLogOk)
						{
                            // ↓↓↓ 20210324 Kimura update ↓↓↓
                            //AppendResultText(load.ToString() + " [g・cm2] " + "\n");
                            AppendResultText(strload + UserText.InertiaUnit + "\n");
                            // ↑↑↑ 20210324 Kimura update ↑↑↑
						}
						else
						{
							MainForm.IsReadLogOk = true;											//20170131 add

							LoadTuningCounter--;

							if (LoadTuningCounter < 0)												//20170131 add
							{
								LoadTuningCounter = 0;
							}
					
							AppendResultText(UserText.AutoTuningComunicationDataUpdating + "\n");
							return;
						}
			
						if (IsTempTuning)
						{
							//仮イナーシャ推定
							TempTuningMeasCnt++;

							if (TempTuningMeasCnt >= TempTuningRefCnt)
							{
								//仮イナーシャ推定完了
								IsTempTuning = false;

								LoadTuningCounter = 0;

								load = CalcLoadInertiaResult(TempTuningRefCnt);

								AppendResultText("\n");

                                // ↓↓↓ 20210324 Kimura update ↓↓↓
                                int iload = CDataTool.SetInertiaDiameter(load);
                                AppendResultText(iload.ToString() + UserText.InertiaUnit + "\n");
                                //AppendResultText(load.ToString() + " [g・cm2] " + "\n");
                                // ↑↑↑ 20210324 Kimura update ↑↑↑

                                load = (int)((double)load * TempTuningCoeff);

                                // ↓↓↓ 20210324 Kimura update ↓↓↓
                                strload = load.ToString();
                                AppendResultText(strload + UserText.InertiaUnit + "\n");
                                //AppendResultText(load.ToString() + " [g・cm2] " + "\n");
                                // ↑↑↑ 20210324 Kimura update ↑↑↑
                                
                                AppendResultText("\n");

                                // ↓↓↓ 20210324 Kimura add ↓↓↓
                                load = CDataTool.SetInertiaDiameter(load); 
                                // ↑↑↑ 20210324 Kimura add ↑↑↑

                                CCommandTx.WriteSvNet(CParamID.Load, load);

								Thread.Sleep(1000);		//20160406 add

								AutoTuningLoadInertia(true);
							}
							else
							{
								MainForm.IsReadLogOk = true;

								if ((LoadTuningCounter % 2) == 1)
								{
									AutoTuningLoadInertia(false);
								}
								else
								{
									AutoTuningLoadInertia(true);
								}
							}
						}
						else
						{
							//イナーシャ推定
							LoadTuningMeasCnt++;

							if (LoadTuningMeasCnt >= LoadTuningRefCnt)
							{
								//イナーシャ推定完了
								TimerAutoTuing.Enabled = false;

								load = CalcLoadInertiaResult(LoadTuningRefCnt);

								ClearAutoTuningSq();			//完了

								AutoTuningLoadInertia(false);	//開始位置へ戻る

								AppendResultText("\n");

                                // ↓↓↓ 20210324 Kimura update ↓↓↓
                                int iload = CDataTool.SetInertiaDiameter(load);
                                
                                AppendResultText(UserText.AutoTuningInertiaEstimate + iload.ToString() + UserText.InertiaUnit + "\n");
                                AppendResultText(UserText.AutoTuningMotorInertia + CMonitor.GetParameter(CParamID.MotorInertia).ToString() + UserText.InertiaUnit + "\n");
                                
                                
                                //AppendResultText(UserText.AutoTuningInertiaEstimate + load.ToString() + "[g・cm2]" + "\n");
                                //AppendResultText(UserText.AutoTuningMotorInertia + motor.ToString() + "[g・cm2]" + "\n");
                                // ↑↑↑ 20210324 Kimura update ↑↑↑
                                
                                AppendResultText(UserText.AutoTuningInertiaRatio + ((double)load / (double)motor).ToString("F2") + UserText.AutoTuningInertiaRatioUnit + "\n");
                               
								AppendResultText("\n");

								//チューニングパラメータ取得
								InitTuningParameter();

								//サーボゲイン初期設定
								InitLoadGain(load);

                                // ↓↓↓ 20210324 Kimura add ↓↓↓
                                int bkload = load;
                                load = CDataTool.SetInertiaDiameter(load);
                                // ↑↑↑ 20210324 Kimura add ↑↑↑

								CCommandTx.WriteSvNet(CParamID.Load, load);

								LoadTuningMeasEnd = true;		//負荷イナーシャ書き込み後にフラグ設定

                                // ↓↓↓ 20210324 Kimura update ↓↓↓
                                //UserMessageBox.AutoTuningLoadInertiaFinish(bkload.ToString());
								UserMessageBox.AutoTuningLoadInertiaFinish(load.ToString());
                                // ↑↑↑ 20210324 Kimura update ↑↑↑

							}
							else
							{
								MainForm.IsReadLogOk = true;

								if ((LoadTuningCounter % 2) == 1)
								{
									AutoTuningLoadInertia(false);
								}
								else
								{
									AutoTuningLoadInertia(true);
								}
							}
						}

					}
					break;

				#endregion

				#region 周波数スイープ

				case 2:

					//if (ServoStatus == 2)
					if (CMonitor.GetParameter(CParamID.AutoTuningSequence) == 2)
					{
						//周波数スイープ中
					}
					else
					{
						//RestoreServoParameter();

						TimerAutoTuing.Enabled = false;

						int sweep_buf = 500;	//Frequency Sweep Max
						int sweep_len = FrequencySweepDialog.SweepMaxFrq;

						float[] buf = new float[sweep_buf];

						//ゲインデータ取得 Page1
						CCommandTx.ReadFrequecySweepData(Convert.ToByte('f'), 0, 0, ref buf);

						for (int i = 0; i < sweep_len; i++)
						{
							if (i < 5)		//5Hz～
							{
								buf[i] = buf[5];
							}

							if (i > 0)
							{
								buf[i] = 20.0F * (float)Math.Log10(buf[i] / SweepVelocity);
								SignalGain[i - 1] = buf[i];		//ボード線図は1Hz～
							}
						}

						BodeGraphForm.ThisForm.ctlBodeGain.SetSweepData(0, sweep_len - 1, SignalGain);
						
						BodeGraphForm.ThisForm.IsViewHold = true;

						WriteControlMode(BackupControlMode);

						//位相データ取得 Page1
						//CCommandTx.ReadFrequecySweepData(Convert.ToByte('f'), 1, 0, ref buf);

						//for (int i = 0; i < sweep_len; i++)
						//{
						//    if (i < 5)
						//    {
						//        buf[i] = buf[5];
						//    }

						//    if (i > 0)
						//    {
						//        buf[i] = 90.0F - buf[i];
						//        SignalPhase[i - 1] = buf[i];	//ボード線図は1Hz～
						//    }
						//}

						ClearAutoTuningSq();		//完了

						UserMessageBox.AutoTuningFrequencySweepFinish();
					}

					break;

				#endregion

				#region サーボゲイン調整
				case 3:

					CalcStopWatch();

					if (IsGainAdjustPause) { break; }

					CheckTheCurrentVibration();

					if (IsWaitVB) { break; }

					if ((ServoStatus & 0x02) == 0x02)
					{
						//プロファイル動作中
					}
					else
					{
						int wait = ctlNumWaitTime.IntValue / 100 + 1;
						
						AdjustMeasWait++;

						if (AdjustMeasWait >= wait)	//500msec Wait
						{
							AdjustMeasWait = 0;

							AdjustMeasDir++;

							ClearTuningResult();

							if ((AdjustMeasDir) % 2 == 1)
							{
								if (MainForm.IsReadLogOk)
								{
									MeasureLogData(true);
									CW_Move_Ok = true;
								}
								else
								{
									MainForm.IsReadLogOk = true;
									
									AppendResultText(UserText.AutoTuningComunicationDataUpdating + "\n");
									CW_Move_Ok = false;
								}

								UpdateGainNowText();

								MoveAutoTuning(false);		//負方向へ動作開始
							}
							else
							{
								if (MainForm.IsReadLogOk && CW_Move_Ok)
								{
									MeasureLogData(false);

									if (!IsGainAdjustRepeat)
									{
										if (AdjustServoGain() == false)	//往復動作完了　ゲイン調整
										{
											btnStop.PerformClick();
											break;
										}
									}
								}
								else
								{
									MainForm.IsReadLogOk = true;

									AppendResultText(UserText.AutoTuningComunicationDataUpdating + "\n");
								}

								if (AutoTuningSq == 0)
								{
									MoveAutoTuning(false);		//ゲイン調整完了　開始位置へ移動
								}
								else
								{
									MoveAutoTuning(true);		//正方向へ動作開始
								}
							
							}
						}
					}

					break;

				#endregion

				#region テスト運転
				case 100:

					if (IsGainAdjustPause) { break; }

					if ((ServoStatus & 0x02) == 0x02)
					{
						//プロファイル動作中
					}
					else
					{
						int wait = ctlNumWaitTime.IntValue / 100 + 1;

						AdjustMeasWait++;

						if (AdjustMeasWait >= wait)	//500msec Wait
						{
							AdjustMeasWait = 0;

							AdjustMeasDir++;

							ClearTuningResult();

							if (IsGainAdjustRepeat)
							{
								if ((AdjustMeasDir) % 2 == 1)
								{
									if (MainForm.IsReadLogOk)
									{
										MeasureLogData(true);	//FFT更新
									}
									else
									{
										MainForm.IsReadLogOk = true;
									}

									MoveTestTuning(false);		//負方向へ動作開始
								}
								else
								{
									if (MainForm.IsReadLogOk)
									{
										MeasureLogData(false);	//FFT更新
									}
									else
									{
										MainForm.IsReadLogOk = true;
									}
									
									MoveAutoTuning(true);		//正方向へ動作開始
								}

								UpdateGainNowText();
							}
							else
							{
								MoveTestTuning(false);			//開始位置へ動作開始

								ClearAutoTuningSq();			//20170215 update

								//AutoTuningSq = 0;
							}
						}
					}

					break;

				#endregion
			}
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

		private void SetAutoTuningSq(int sq)
		{
			AutoTuningSq = sq;
			WriteAutoTuningSq(AutoTuningSq);
		}

		private void ClearAutoTuningSq()
		{
			AutoTuningSq = 0;
			WriteAutoTuningSq(AutoTuningSq);

			if (BackupPositionErrorPulse != 0)
			{
				WritePulseError(BackupPositionErrorPulse);						//20170215 update
			}

			if (BackupDynamicBreakCondition >= 0 && BackupDynamicBreakCondition <= 3)
			{
				WriteDynamicBreakCondition(BackupDynamicBreakCondition);		//20170215 update
			}
		}

		private void CalcStopWatch()
		{
			int sec = new int();
			int min = new int();

			if (StartMinute > DateTime.Now.Minute)
			{
				min = DateTime.Now.Minute - StartMinute + 60;
			}
			else
			{
				min = DateTime.Now.Minute - StartMinute;
			}

			if (StartSecond > DateTime.Now.Second)
			{
				min--;
				sec = DateTime.Now.Second - StartSecond + 60;
			}
			else
			{
				sec = DateTime.Now.Second - StartSecond;
			}

			lblStopWatch.Text = min.ToString("D2") + ":" + sec.ToString("D2");
		}

		public void InitTargetData()
		{

			ctlNumTargetPosition.IntValue = EncderResolution * 5;
			ctlNumTargetVelocity.IntValue = 500;
			ctlNumTargetAcceleration.IntValue = 500;
			ctlNumTargetDeceleration.IntValue = 500;

			UpdateAccDccTime();
		}

		private void UpdateAccDccTime()
		{
			int vel = ctlNumTargetVelocity.IntValue;
			int acc = ctlNumTargetAcceleration.IntValue;
			int dcc = ctlNumTargetDeceleration.IntValue;

			vel = (int)Math.Abs(vel);
			lblAccTime.Text = (vel / (acc * 10.0) * 1000.0).ToString("F1") + " [msec]";
			lblDccTime.Text = (vel / (dcc * 10.0) * 1000.0).ToString("F1") + " [msec]";

		}

		private void tabPageTuningTarget_Click(object sender, EventArgs e)
		{
			lblSelect.Select();
		}

		private void tabPageTuningMode_Click(object sender, EventArgs e)
		{
			lblSelect.Select();
		}

		private void Control_MouseHover(object sender, EventArgs e)
		{
			this.Select();
		}

		private void Control_MouseEnter(object sender, EventArgs e)
		{
			this.Select();
		}

		private bool DisableResultTextScroll = new bool();
		private bool DisableGainNowTextScroll = new bool();

		private string ResultText = string.Empty;
		private bool ResultBuffer = new bool();

		private void AppendResultText(string txt)
		{
			if (DisableResultTextScroll == false)
			{
				if (ResultBuffer)
				{
					rtxtResult.AppendText(ResultText);
					ResultBuffer = false;
					ResultText = string.Empty;
				}
				else
				{
					rtxtResult.AppendText(txt);
				}
				rtxtResult.ScrollToCaret();
			}
			else
			{
				ResultBuffer = true;
				ResultText += txt;
			}
		}

		private void UpdateGainNowText()
		{
			if (DisableGainNowTextScroll == false)
			{
				rtxtGainNow.Text = "";

				//rtxtGainNow.AppendText(UserText.AutoTuningServoGain + "\n");
				rtxtGainNow.AppendText(UserText.AutoTuningKp + "\n");
				rtxtGainNow.AppendText("  " + CMonitor.GetParameter(CParamID.Kp1).ToString() + " [rad/s]" + "\n");
				rtxtGainNow.AppendText(UserText.AutoTuningKv + "\n");
				rtxtGainNow.AppendText("  " + CMonitor.GetParameter(CParamID.Kv1).ToString() + " [rad/s]" + "\n");
				rtxtGainNow.AppendText(UserText.AutoTuningKi + "\n");
				rtxtGainNow.AppendText("  " + CMonitor.GetParameter(CParamID.Ki1).ToString() + " [1/s]" + "\n");
				rtxtGainNow.AppendText(UserText.AutoTuningLoad + "\n");
                
                // ↓↓↓ 20210324 Kimura update ↓↓↓
                rtxtGainNow.AppendText("  " + CMonitor.GetParameter(CParamID.Load).ToString() + UserText.InertiaUnit + "\n");
                //rtxtGainNow.AppendText("  " + CMonitor.GetParameter(CParamID.Load).ToString() + " [kg.m2]" + "\n");
                // ↑↑↑ 20210324 Kimura update ↑↑↑

                //rtxtGainNow.AppendText("\n");

				rtxtGainNow.AppendText(UserText.AutoTuningLowpassFillter + "\n");
				rtxtGainNow.AppendText("  " + CMonitor.GetParameter(CParamID.C_LPF_f).ToString() + " [Hz]" + "\n");

				rtxtGainNow.AppendText(UserText.AutoTuningNotchFillter1 + "\n");
				rtxtGainNow.AppendText("  " + CMonitor.GetParameter(CParamID.C_NF1_f).ToString() + " [Hz]");
				rtxtGainNow.AppendText("  " + CMonitor.GetParameter(CParamID.C_NF1_d).ToString());
				rtxtGainNow.AppendText("  " + CMonitor.GetParameter(CParamID.C_NF1_q).ToString() + "\n");

				rtxtGainNow.AppendText(UserText.AutoTuningNotchFillter2 + "\n");
				rtxtGainNow.AppendText("  " + CMonitor.GetParameter(CParamID.C_NF2_f).ToString() + " [Hz]");
				rtxtGainNow.AppendText("  " + CMonitor.GetParameter(CParamID.C_NF2_d).ToString());
				rtxtGainNow.AppendText("  " + CMonitor.GetParameter(CParamID.C_NF2_q).ToString() + "\n");

				rtxtGainNow.AppendText(UserText.AutoTuningNotchFillter3 + "\n");
				rtxtGainNow.AppendText("  " + CMonitor.GetParameter(CParamID.C_NF3_f).ToString() + " [Hz]");
				rtxtGainNow.AppendText("  " + CMonitor.GetParameter(CParamID.C_NF3_d).ToString());
				rtxtGainNow.AppendText("  " + CMonitor.GetParameter(CParamID.C_NF3_q).ToString() + "\n");

				rtxtGainNow.AppendText(UserText.AutoTuningNotchFillter4 + "\n");
				rtxtGainNow.AppendText("  " + CMonitor.GetParameter(CParamID.C_NF4_f).ToString() + " [Hz]");
				rtxtGainNow.AppendText("  " + CMonitor.GetParameter(CParamID.C_NF4_d).ToString());
				rtxtGainNow.AppendText("  " + CMonitor.GetParameter(CParamID.C_NF4_q).ToString() + "\n");

				rtxtGainNow.AppendText(UserText.AutoTuningNotchFillter5 + "\n");
				rtxtGainNow.AppendText("  " + CMonitor.GetParameter(CParamID.C_NF5_f).ToString() + " [Hz]");
				rtxtGainNow.AppendText("  " + CMonitor.GetParameter(CParamID.C_NF5_d).ToString());
				rtxtGainNow.AppendText("  " + CMonitor.GetParameter(CParamID.C_NF5_q).ToString() + "\n");

				rtxtGainNow.AppendText("\n");
				rtxtGainNow.AppendText("  " + UserText.AutoTuningTuningNum + AdjustActCount.ToString() + UserText.AutoTuningNum + "\n");
                rtxtGainNow.AppendText("  " + UserText.AutoTuningGainSetupNum + GainAdjustCount.ToString() + UserText.AutoTuningNum + "\n");
				//rtxtGainNow.AppendText("\n");
                rtxtGainNow.AppendText("  " + UserText.AutoTuningVibrationNum + PerrVibrationCount.ToString() + UserText.AutoTuningNum + "\n");
			}
		}

		private void rtxtResult_Enter(object sender, EventArgs e)
		{
			//DisableResultTextScroll = true;
		}

		private void rtxtResult_Leave(object sender, EventArgs e)
		{
			DisableResultTextScroll = false;
			rtxtResult.BackColor = SystemColors.Control;
		}

		private void rtxtResult_MouseDown(object sender, MouseEventArgs e)
		{
			DisableResultTextScroll = true;
			rtxtResult.BackColor = Color.LightGray;
		}

		private void rtxtResult_MouseLeave(object sender, EventArgs e)
		{
			if (DisableResultTextScroll)
			{
				rtxtGainNow.Focus();
				DisableResultTextScroll = false;
				rtxtResult.BackColor = SystemColors.Control;
			}
		}

		private void rtxtGainNow_Enter(object sender, EventArgs e)
		{
			//DisableGainNowTextScroll = true;
		}

		private void rtxtGainNow_Leave(object sender, EventArgs e)
		{
			DisableGainNowTextScroll = false;
			rtxtGainNow.BackColor = SystemColors.Control;
		}

		private void rtxtGainNow_MouseDown(object sender, MouseEventArgs e)
		{
			DisableGainNowTextScroll = true;
			rtxtGainNow.BackColor = Color.LightGray;
		}

		private void rtxtGainNow_MouseLeave(object sender, EventArgs e)
		{
			if (DisableGainNowTextScroll)
			{
				rtxtResult.Focus();
				DisableGainNowTextScroll = false;
				rtxtGainNow.BackColor = SystemColors.Control;
			}
		}

		private void CollapseAutoTuningControl()
		{
			grpMachineType.Location = new Point(15, 10);
			grpGainStrength.Location = new Point(125, 10);
			grpTuningMode.Location = new Point(15, 130);
			grpVelocityObserver.Location = new Point(125, 130);
			grpInposition.Location = new Point(15, 250);
			grpTargetTime.Location = new Point(125, 250);
			grpTuningTurbo.Location = new Point(15, 370);
			chkLoadTuning.Location = new Point(15, 490);
			grpLoadTuningGain.Location = new Point(15, 525);
			grpLoadTuningSetting.Location = new Point(15, 680);
		
			splOutput.Orientation = Orientation.Horizontal;
			splOutput.SplitterDistance = splOutput.Height / 2;

			pnlVibration.Width = 100;
			lblStopWatch.Width = 80;
			btnStop.Width = 80;

			pnlVibration.Location = new Point(15, 10);
			lblStopWatch.Location = new Point(130, 10);
			btnStop.Location = new Point(225, 10);

            switch (Culture.Name)
            {
                default:
                case Culture.JP:
                    lblVibration.Font = AppFont.MeiryoRegular12;
                    lblStopWatch.Font = AppFont.MeiryoRegular14;
                    break;

                case Culture.US:
                    lblVibration.Font = AppFont.MeiryoRegular12;
                    lblStopWatch.Font = AppFont.MeiryoRegular14;
                    break;

                case Culture.CN:
                    lblVibration.Font = AppFont.MicrosoftYaHeiRegular12;
                    lblStopWatch.Font = AppFont.MicrosoftYaHeiRegular14;
                    break;
            }

		}

		private void ExpandAutoTuningControl()
		{
			grpMachineType.Location = new Point(15, 10);
			grpGainStrength.Location = new Point(125, 10);
			grpTuningMode.Location = new Point(235, 10);
			grpVelocityObserver.Location = new Point(345, 10);
			grpInposition.Location = new Point(15, 130);
			grpTargetTime.Location = new Point(125, 130);
			grpTuningTurbo.Location = new Point(235, 130);
			chkLoadTuning.Location = new Point(15, 250);
			grpLoadTuningGain.Location = new Point(15, 285);
			grpLoadTuningSetting.Location = new Point(15, 440);
		
			splOutput.Orientation = Orientation.Vertical;
			splOutput.SplitterDistance = 265;		// splOutput.Width / 2;

			pnlVibration.Width = 137;
			lblStopWatch.Width = 137;
			btnStop.Width = 140;

			pnlVibration.Location = new Point(15, 10);
			lblStopWatch.Location = new Point(165, 10);
			btnStop.Location = new Point(320, 10);

            switch (Culture.Name)
            {
                default:
                case Culture.JP:
                    lblVibration.Font = AppFont.MeiryoRegular16;
                    lblStopWatch.Font = AppFont.MeiryoRegular18;
                    break;

                case Culture.US:
                    lblVibration.Font = AppFont.MeiryoRegular16;
                    lblStopWatch.Font = AppFont.MeiryoRegular18;
                    break;

                case Culture.CN:
                    lblVibration.Font = AppFont.MicrosoftYaHeiRegular16;
                    lblStopWatch.Font = AppFont.MicrosoftYaHeiRegular18;
                    break;
            }
		}

		public void CallMeasLoadInertia()
		{
			StartMeasLoadInertia();
		}

		public void CallFrictionCompensation()
		{
			StartFrictionCompensation();
		}

		public void CallTuningStop()
		{
			btnStop.PerformClick();
		}

		public bool CallLoadTuningState()
		{
			if (ThisForm.LoadTuningMeasEnd)
			{
				//WizardForm.LoadInertia = CMonitor.GetParameter(CParamID.Load);
				
				int load = new int();
				CCommandTx.ReadSvNet(CParamID.Load, ref load);		//更新までの時間差有り。

                WizardDialog.LoadInertia = load;
			}

			return LoadTuningMeasEnd;
		}

		public bool CallStoreServoParameter()
		{
			return StoreServoParameter();
		}

		public bool CallReStoreServoParameter()
		{
			return ReStoreServoParameter();
		}

		public bool CallClearFillter()
		{
			return ClearFillter();
		}

		public bool CallSetTeachingServoGain()
		{

			//チューニングパラメータ取得
			InitTuningParameter();

            // ↓↓↓ 20210324 Kimura update ↓↓↓
            int load = CDataTool.GetInertiaDiameter(CMonitor.GetParameter(CParamID.Load));
            //int load = CMonitor.GetParameter(CParamID.Load);
            // ↑↑↑ 20210324 Kimura update ↑↑↑

			//サーボゲイン初期設定
			InitLoadGain(load);

			//ローパスフィルタ設定
			SetLowpassFillter(600);

			//瞬時速度オブザーバOFF
			WriteVelocityObserver(false, false, 0);
	
			return true;

		}

		private const int NO_COLUMN = 0;
		private const int ITEM_COLUMN = 1;
		private const int VALUE_COLUMN = 2;

		private const int PRM_SIZE = 200;

		private string BackupText;

		private void InitTuningGrid()
		{
			int row = 0;

			dgvSetting.Rows.Add();

			#region ゲインに関する設定

			dgvSetting[ITEM_COLUMN, row].Value = "+++ Gain Setting +++";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.TitleGain;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Init Kcp 23B OBS [rad/s]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.InitKcp_23B_OBS;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Init Kcp 17B OBS [rad/s]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.InitKcp_17B_OBS;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Init Kcp INC OBS [rad/s]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.InitKcp_INC_OBS;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Init Kcp RES OBS [rad/s]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.InitKcp_RES_OBS;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Init Kcp 23B [rad/s]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.InitKcp_23B;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Init Kcp 17B [rad/s]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.InitKcp_17B;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Init Kcp INC [rad/s]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.InitKcp_INC;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Init Kcp RES [rad/s]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.InitKcp_RES;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Init Kci 23B [1/s]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.InitKci_23B;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Init Kci 17B [1/s]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.InitKci_17B;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Init Kci INC [1/s]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.InitKci_INC;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Init Kci RES [1/s]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.InitKci_RES;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Init Kpp [rad/s]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.InitKpp;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Init Kvp [rad/s]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.InitKvp;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Init Kvi [1/s]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.InitKvi;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Up Kpp [rad/s]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.UpKpp;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Up Kvp [rad/s]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.UpKvp;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Up Kvi [1/s]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.UpKvi;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Up Kpp Max [rad/s]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.UpKppMax;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Up Kvp Max [rad/s]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.UpKvpMax;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Up Kvi Max [1/s]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.UpKviMax;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Up Kpp Delta[rad/s]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.UpKppDelta;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Up Kvp Delta [rad/s]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.UpKvpDelta;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Up Kvi Delta [1/s]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.UpKviDelta;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Coeff Init Gain Belt [InitGain*%]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.CoeffInitGain_Belt;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Coeff Init Gain Screw [InitGain*%]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.CoeffInitGain_Screw;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Coeff Init Gain Disk [InitGain*%]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.CoeffInitGain_Disk;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Coeff Up Gain Belt [UpGain*%]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.CoeffUpGain_Belt;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Coeff Up Gain Screw [UpGain*%]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.CoeffUpGain_Screw;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Coeff Up Gain Disk [UpGain*%]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.CoeffUpGain_Disk;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Coeff Kpp Normal [Kvp*%]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.CoeffKpp_Normal;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Coeff Kpp Position [Kvp*%]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.CoeffKpp_Position;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Coeff Kpp Stiffness [Kvp*%]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.CoeffKpp_Stiffness;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Coeff Kvi Belt [Kvi*%]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.CoeffKvi_Belt;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Coeff Kvi Screw [Kvi*%]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.CoeffKvi_Screw;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Coeff Kvi Disk [Kvi*%]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.CoeffKvi_Disk;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Max Kvi Belt [1/s]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.MaxKvi_Belt;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Max Kvi Screw [1/s]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.MaxKvi_Screw;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Max Kvi Disk [1/s]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.MaxKvi_Disk;
			dgvSetting.Rows.Add(); row++;

			#endregion

			#region	フィルタに関する設定

			dgvSetting[ITEM_COLUMN, row].Value = "+++ Fillter Setting +++";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.TitleFillter;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Notch Fillter Max Frq [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.NotchMaxFrq;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Notch Fillter Min Frq [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.NotchMinFrq;
			dgvSetting.Rows.Add(); row++;
	
			dgvSetting[ITEM_COLUMN, row].Value = "Notch Fillter Apply Amplitude [dB]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.NotchApplyAmp;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Notch Fillter Default Width";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.NotchDefWidth;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Notch Fillter Default Depth";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.NotchDefDepth;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Notch Fillter Sub Width";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.NotchSubWidth;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Notch Fillter Sub Depth";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.NotchSubDepth;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Lowpass Fillter Max Frq [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.LpfMaxFrq;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Lowpass Fillter Min Frq [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.LpfMinFrq;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Lowpass Fillter Frq Coeff [%]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.LpfFrqCoeff;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Lowpass Fillter 23B [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.LpfInit_23B;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Lowpass Fillter 17B [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.LpfInit_17B;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Lowpass Fillter INC [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.LpfInit_INC;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Lowpass Fillter RES [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.LpfInit_RES;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Lowpass Fillter 23B VOBS [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.LpfInit_23B_VelObs;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Lowpass Fillter 17B VOBS [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.LpfInit_17B_VelObs;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Lowpass Fillter INC VOBS [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.LpfInit_INC_VelObs;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Lowpass Fillter RES VOBS [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.LpfInit_RES_VelObs;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Current Feedback Fillter 23B [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.C_FB_Lpf_23B;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Current Feedback Fillter 17B [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.C_FB_Lpf_17B;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Current Feedback Fillter INC [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.C_FB_Lpf_INC;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Current Feedback Fillter RES [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.C_FB_Lpf_RES;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Velocity Feedback Fillter 23B [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.V_FB_Lpf_23B;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Velocity Feedback Fillter 17B [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.V_FB_Lpf_17B;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Velocity Feedback Fillter INC [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.V_FB_Lpf_INC;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Velocity Feedback Fillter RES [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.V_FB_Lpf_RES;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Velocity Feedback Fillter2 23B [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.V_FB_n_23B;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Velocity Feedback Fillter2 17B [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.V_FB_n_17B;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Velocity Feedback Fillter2 INC [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.V_FB_n_INC;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Velocity Feedback Fillter2 RES [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.V_FB_n_RES;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Current Feedback Fillter 23B VOBS [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.C_FB_Lpf_23B_VelObs;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Current Feedback Fillter 17B VOBS [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.C_FB_Lpf_17B_VelObs;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Current Feedback Fillter INC VOBS [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.C_FB_Lpf_INC_VelObs;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Current Feedback Fillter RES VOBS [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.C_FB_Lpf_RES_VelObs;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Velocity Feedback Fillter 23B VOBS [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.V_FB_Lpf_23B_VelObs;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Velocity Feedback Fillter 17B VOBS [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.V_FB_Lpf_17B_VelObs;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Velocity Feedback Fillter INC VOBS [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.V_FB_Lpf_INC_VelObs;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Velocity Feedback Fillter RES VOBS [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.V_FB_Lpf_RES_VelObs;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Velocity Feedback Fillter2 23B VOBS [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.V_FB_n_23B_VelObs;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Velocity Feedback Fillter2 17B VOBS [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.V_FB_n_17B_VelObs;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Velocity Feedback Fillter2 INC VOBS [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.V_FB_n_INC_VelObs;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Velocity Feedback Fillter2 RES VOBS [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.V_FB_n_RES_VelObs;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "FFT 10db Serch Max Frq Belt [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.FFT10dbSearchMaxFrq_Belt;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "FFT 10db Serch Min Frq Belt [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.FFT10dbSearchMinFrq_Belt;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "FFT 10db Serch Max Frq Screw [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.FFT10dbSearchMaxFrq_Screw;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "FFT 10db Serch Min Frq Screw [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.FFT10dbSearchMinFrq_Screw;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "FFT 10db Serch Max Frq Disk [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.FFT10dbSearchMaxFrq_Disk;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "FFT 10db Serch Min Frq Disk [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.FFT10dbSearchMinFrq_Disk;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "FFT 6db Serch Max Frq Belt [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.FFT6dbSearchMaxFrq_Belt;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "FFT 6db Serch Min Frq Belt [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.FFT6dbSearchMinFrq_Belt;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "FFT 6db Serch Max Frq Screw [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.FFT6dbSearchMaxFrq_Screw;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "FFT 6db Serch Min Frq Screw [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.FFT6dbSearchMinFrq_Screw;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "FFT 6db Serch Max Frq Disk [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.FFT6dbSearchMaxFrq_Disk;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "FFT 6db Serch Min Frq Disk [Hz]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.FFT6dbSearchMinFrq_Disk;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Notch Fillter Max Num Light [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.NotchMaxNum_Light;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Notch Fillter Max Num Middle [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.NotchMaxNum_Middle;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Notch Fillter Max Num Strong [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.NotchMaxNum_Strong;
			dgvSetting.Rows.Add(); row++;

			#endregion

			#region オブザーバに関する設定

			dgvSetting[ITEM_COLUMN, row].Value = "+++ Observer Setting +++";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.TitleObserver;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Velocity Observer Time 23B High [msec]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.VelObsTime_23B_High;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Velocity Observer Time 17B High [msec]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.VelObsTime_17B_High;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Velocity Observer Time INC High [msec]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.VelObsTime_INC_High;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Velocity Observer Time RES High [msec]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.VelObsTime_RES_High;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Velocity Observer Time 23B Mid [msec]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.VelObsTime_23B_Mid;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Velocity Observer Time 17B Mid [msec]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.VelObsTime_17B_Mid;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Velocity Observer Time INC Mid [msec]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.VelObsTime_INC_Mid;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Velocity Observer Time RES Mid [msec]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.VelObsTime_RES_Mid;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Velocity Observer Time 23B Low [msec]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.VelObsTime_23B_Low;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Velocity Observer Time 17B Low [msec]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.VelObsTime_17B_Low;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Velocity Observer Time INC Low [msec]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.VelObsTime_INC_Low;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Velocity Observer Time RES Low [msec]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.VelObsTime_RES_Low;
			dgvSetting.Rows.Add(); row++;

			#endregion

			#region パルス判定に関する設定

			dgvSetting[ITEM_COLUMN, row].Value = "+++ Pulse Setting +++";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.TitlePulse;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Split Pulse 23B [pulse]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.SplitErrorPulse_23B;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Split Pulse 17B [pulse]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.SplitErrorPulse_17B;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Split Pulse INC [pulse]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.SplitErrorPulse_INC;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Split Pulse RES [pulse]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.SplitErrorPulse_RES;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Fast Overshoot Time [msec]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.FastOvershootTime;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Overshoot Pulse 23B [Inpos/N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.OvershootErrorPulse_23B;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Overshoot Pulse 17B [Inpos/N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.OvershootErrorPulse_17B;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Overshoot Pulse INC [Inpos/N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.OvershootErrorPulse_INC;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Overshoot Pulse RES [Inpos/N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.OvershootErrorPulse_RES;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Position Error Vibration Pulse 23B [pulse]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.PerrVBPulse_23B;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Position Error Vibration Pulse 17B [pulse]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.PerrVBPulse_17B;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Position Error Vibration Pulse INC [pulse]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.PerrVBPulse_INC;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Position Error Vibration Pulse RES [pulse]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.PerrVBPulse_RES;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Position Error Vibration Count Is Safe Stop Light [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.PerrVBIsSafeStopCount_Light;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Position Error Vibration Count Is Safe Stop Middle [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.PerrVBIsSafeStopCount_Middle;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Position Error Vibration Count Is Safe Stop Strong [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.PerrVBIsSafeStopCount_Strong;
			dgvSetting.Rows.Add(); row++;

			#endregion

			#region	終了条件に関する設定

			dgvSetting[ITEM_COLUMN, row].Value = "+++ Finish Setting +++";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.TitleFinish;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Finish Gain Adjust Count [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.FinishGainAdjustCount;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Finish Safe Stop Count Light [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.FinishSafeStopCount_Light;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Finish Safe Stop Count Middle [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.FinishSafeStopCount_Middle;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Finish Safe Stop Count Strong [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.FinishSafeStopCount_Strong;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Finish Safe Stop Kpp Limit Light [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.FinishSafeStopKppLimit_Light;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Finish Safe Stop Kpp Limit Middle [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.FinishSafeStopKppLimit_Middle;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Finish Safe Stop Kpp Limit Strong [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.FinishSafeStopKppLimit_Strong;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Finish Safe Stop Kvp Limit Light [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.FinishSafeStopKvpLimit_Light;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Finish Safe Stop Kvp Limit Middle [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.FinishSafeStopKvpLimit_Middle;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Finish Safe Stop Kvp Limit Strong [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.FinishSafeStopKvpLimit_Strong;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Finish Safe Stop Time Light [msec]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.FinishSafeStopTime_Light;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Finish Safe Stop Time Middle [msec]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.FinishSafeStopTime_Middle;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Finish Safe Stop Time Strong [msec]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.FinishSafeStopTime_Strong;
			dgvSetting.Rows.Add(); row++;

			#endregion

			#region 振動検出に関する設定

			dgvSetting[ITEM_COLUMN, row].Value = "+++ Vibration Setting +++";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.TitleVibration;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Current Vibration Kvp Limit Light [%]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.CurVBKvpLimit_Light;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Current Vibration Kvp Limit Middle [%]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.CurVBKvpLimit_Middle;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Current Vibration Kvp Limit Strong [%]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.CurVBKvpLimit_Strong;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Current Vibration Kvp Limit Count [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.CurVBKvpLimitCount;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Current Vibration Notch Fillter Limit Count [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.CurVBNFLimitCount;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Current Vibration FFT Limit Count [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.CurVBFFTLimitCount;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Position Error Vibration Count [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.PerrVBNumLimitCount;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Current Vibration Detect Divid Small Inertia [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.CurVBDetectDiv00;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Current Vibration Detect Count Small Inertia [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.CurVBDetectCnt00;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Current Vibration Detect Divid Medium Inertia [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.CurVBDetectDiv10;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Current Vibration Detect Count Medium Inertia [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.CurVBDetectCnt10;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Current Vibration Detect Divid Large Inertia [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.CurVBDetectDiv20;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Current Vibration Detect Count Large Inertia [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.CurVBDetectCnt20;
			dgvSetting.Rows.Add(); row++;

			#endregion

			#region リトライに関する設定

			dgvSetting[ITEM_COLUMN, row].Value = "+++ Retry Setting +++";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.TitleRetry;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Retry Count Position Vibration [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.RetryCountPerrVB;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Retry Count Current Vibration [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.RetryCountCurVB;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Retry Count Current Vibration Init Gain [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.RetryCountCurVBInitGain;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Retry Coeff Init Gain [%]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.RetryCoeffInitGain;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Retry Coeff Up Gain [%]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.RetryCoeffUpGain;
			dgvSetting.Rows.Add(); row++;


			dgvSetting[ITEM_COLUMN, row].Value = "Retry Num Init Gain [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.RetryNumInitGain;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Retry Num Notch Fillter [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.RetryNumNotch;
			dgvSetting.Rows.Add(); row++;

			#endregion

			#region 負荷に関する設定

			dgvSetting[ITEM_COLUMN, row].Value = "+++ Load Setting +++";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.TitleLoad;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Load Tuning After Gain Div [gain/N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.LoadTuningAfterGainDiv;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Init Gain Load Ratio Div [load/N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.InitGainLoadRatioDiv;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Up Gain Load Ratio Div [load/N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.UpGainLoadRatioDiv;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Spring Constant Belt [N-m/rad]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.SpringConstant_Belt;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Spring Constant Screw [N-m/rad]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.SpringConstant_Screw;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Spring Constant Disk [N-m/rad]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.SpringConstant_Disk;
			dgvSetting.Rows.Add(); row++;

			#endregion

			#region ロールバックに関する設定

			dgvSetting[ITEM_COLUMN, row].Value = "+++ Rollback Setting +++";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.TitleRollback;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Rollback Perr VB Count Light [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.RollbackPerrVBCount_Light;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Rollback Perr VB Count Middle [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.RollbackPerrVBCount_Middle;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Rollback Perr VB Count Strong [N]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.RollbackPerrVBCount_Strong;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Rollback VB Gain Light [%]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.RollbackVBGain_Light;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Rollback VB Gain Middle [%]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.RollbackVBGain_Middle;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Rollback VB Gain Strong [%]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.RollbackVBGain_Strong;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Rollback FFT dB Light [dB]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.RollbackCurVBdB_Light;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Rollback FFT dB Middle [dB]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.RollbackCurVBdB_Middle;
			dgvSetting.Rows.Add(); row++;

			dgvSetting[ITEM_COLUMN, row].Value = "Rollback FFT dB Strong [dB]";
			dgvSetting[VALUE_COLUMN, row].Value = TuningParameter.RollbackCurVBdB_Strong;
			//dgvSetting.Rows.Add(); row++;

			#endregion

			for (int i = 0; i < dgvSetting.Rows.Count; i++)
			{
				dgvSetting[NO_COLUMN, i].Value = (i+1).ToString();
			}
		}

		private void dgvSetting_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			int r = dgvSetting.CurrentCell.RowIndex;
			int c = dgvSetting.CurrentCell.ColumnIndex;

			BackupText = dgvSetting[c, r].Value.ToString();

			dgvSetting[c, r].Style.ForeColor = Color.Red;

		}

		private void dgvSetting_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			int r = dgvSetting.CurrentCell.RowIndex;
			int c = dgvSetting.CurrentCell.ColumnIndex;

			string s = dgvSetting[c, r].Value.ToString();

			if (!CDataTool.IsRealNumeric(s))
			{
				UserMessageBox.AutoTuningInputDataError();
				dgvSetting[c, r].Value = BackupText;
			}

			dgvSetting[c, r].Style.ForeColor = Color.Black;
		
		}

        #region カルチャリソース切り替え

        public void ViewCultureResouceChanged()
        {

            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AutoTuningForm));

            InitFormLayout();

            this.Font = (Font)resources.GetObject("$this.Font");
			btnAutoTuningWizard.Font = (Font)resources.GetObject("btnAutoTuningWizard.Font");
			btnTuningControl.Font = (Font)resources.GetObject("btnTuningControl.Font");
			btnConfigOutput.Font = (Font)resources.GetObject("btnConfigOutput.Font");
            btnConfigRead.Font = (Font)resources.GetObject("btnConfigRead.Font");
            btnPause.Font = (Font)resources.GetObject("btnPause.Font");
            btnRepeat.Font = (Font)resources.GetObject("btnRepeat.Font");
            btnStop.Font = (Font)resources.GetObject("btnStop.Font");
            btnStop2.Font = (Font)resources.GetObject("btnStop2.Font");
            chkInc.Font = (Font)resources.GetObject("chkInc.Font");
            chkLoadTuning.Font = (Font)resources.GetObject("chkLoadTuning.Font");
            ctlNumericInputInt1.TitleFont = (Font)resources.GetObject("ctlNumericInputInt1.TitleFont");
            ctlNumericInputInt1.UnitFont = (Font)resources.GetObject("ctlNumericInputInt1.UnitFont");
            ctlNumInposition.TitleFont = (Font)resources.GetObject("ctlNumInposition.TitleFont");
            ctlNumInposition.UnitFont = (Font)resources.GetObject("ctlNumInposition.UnitFont");
            ctlNumLoadTuningKi.TitleFont = (Font)resources.GetObject("ctlNumLoadTuningKi.TitleFont");
            ctlNumLoadTuningKi.UnitFont = (Font)resources.GetObject("ctlNumLoadTuningKi.UnitFont");
            ctlNumLoadTuningKp.TitleFont = (Font)resources.GetObject("ctlNumLoadTuningKp.TitleFont");
            ctlNumLoadTuningKp.UnitFont = (Font)resources.GetObject("ctlNumLoadTuningKp.UnitFont");
            ctlNumLoadTuningKv.TitleFont = (Font)resources.GetObject("ctlNumLoadTuningKv.TitleFont");
            ctlNumLoadTuningKv.UnitFont = (Font)resources.GetObject("ctlNumLoadTuningKv.UnitFont");
            ctlNumStartPosition.TitleFont = (Font)resources.GetObject("ctlNumStartPosition.TitleFont");
            ctlNumStartPosition.UnitFont = (Font)resources.GetObject("ctlNumStartPosition.UnitFont");
            ctlNumTargetAcceleration.TitleFont = (Font)resources.GetObject("ctlNumTargetAcceleration.TitleFont");
            ctlNumTargetAcceleration.UnitFont = (Font)resources.GetObject("ctlNumTargetAcceleration.UnitFont");
            ctlNumTargetDeceleration.TitleFont = (Font)resources.GetObject("ctlNumTargetDeceleration.TitleFont");
            ctlNumTargetDeceleration.UnitFont = (Font)resources.GetObject("ctlNumTargetDeceleration.UnitFont");
            ctlNumTargetPosition.TitleFont = (Font)resources.GetObject("ctlNumTargetPosition.TitleFont");
            ctlNumTargetPosition.UnitFont = (Font)resources.GetObject("ctlNumTargetPosition.UnitFont");
            ctlNumTargetTime.TitleFont = (Font)resources.GetObject("ctlNumTargetTime.TitleFont");
            ctlNumTargetTime.UnitFont = (Font)resources.GetObject("ctlNumTargetTime.UnitFont");
            ctlNumTargetVelocity.TitleFont = (Font)resources.GetObject("ctlNumTargetVelocity.TitleFont");
            ctlNumTargetVelocity.UnitFont = (Font)resources.GetObject("ctlNumTargetVelocity.UnitFont");
            ctlNumWaitTime.TitleFont = (Font)resources.GetObject("ctlNumWaitTime.TitleFont");
            ctlNumWaitTime.UnitFont = (Font)resources.GetObject("ctlNumWaitTime.UnitFont");
            grpAcceleration.Font = (Font)resources.GetObject("grpAcceleration.Font");
            grpDeceleration.Font = (Font)resources.GetObject("grpDeceleration.Font");
            grpGainStrength.Font = (Font)resources.GetObject("grpGainStrength.Font");
            grpInposition.Font = (Font)resources.GetObject("grpInposition.Font");
            grpLoadTuningGain.Font = (Font)resources.GetObject("grpLoadTuningGain.Font");
            grpLoadTuningKi.Font = (Font)resources.GetObject("grpLoadTuningKi.Font");
            grpLoadTuningKp.Font = (Font)resources.GetObject("grpLoadTuningKp.Font");
            grpLoadTuningKv.Font = (Font)resources.GetObject("grpLoadTuningKv.Font");
            grpLoadTuningSetting.Font = (Font)resources.GetObject("grpLoadTuningSetting.Font");
            grpMachineType.Font = (Font)resources.GetObject("grpMachineType.Font");
            grpStartPosition.Font = (Font)resources.GetObject("grpStartPosition.Font");
            grpTargetPosition.Font = (Font)resources.GetObject("grpTargetPosition.Font");
            grpTargetTime.Font = (Font)resources.GetObject("grpTargetTime.Font");
            grpTuningMode.Font = (Font)resources.GetObject("grpTuningMode.Font");
            grpTuningTurbo.Font = (Font)resources.GetObject("grpTuningTurbo.Font");
            grpVelocity.Font = (Font)resources.GetObject("grpVelocity.Font");
            grpVelocityObserver.Font = (Font)resources.GetObject("grpVelocityObserver.Font");
            grpWait.Font = (Font)resources.GetObject("grpWait.Font");
            lblAccTime.Font = (Font)resources.GetObject("lblAccTime.Font");
            lblDccTime.Font = (Font)resources.GetObject("lblDccTime.Font");
            lblInc.Font = (Font)resources.GetObject(" lblInc.Font");
            lblInposWidthUnit.Font = (Font)resources.GetObject("lblInposWidthUnit.Font");
            lblLoadTuningCnt.Font = (Font)resources.GetObject("lblLoadTuningCnt.Font");
            lblLoadTuningKi.Font = (Font)resources.GetObject("lblLoadTuningKi.Font");
            lblLoadTuningKp.Font = (Font)resources.GetObject("lblLoadTuningKp.Font");
            lblLoadTuningKv.Font = (Font)resources.GetObject("lblLoadTuningKv.Font");
            lblSelect.Font = (Font)resources.GetObject("lblSelect.Font");
            lblStopWatch.Font = (Font)resources.GetObject("lblStopWatch.Font");
            lblTargetTimeUnit.Font = (Font)resources.GetObject("lblTargetTimeUnit.Font");
            lblTempTuningCnt.Font = (Font)resources.GetObject("lblTempTuningCnt.Font");
            lblTempTuningCoeff.Font = (Font)resources.GetObject("lblTempTuningCoeff.Font");
            lblVibration.Font = (Font)resources.GetObject("lblVibration.Font");
            rdoBelt.Font = (Font)resources.GetObject("rdoBelt.Font");
            rdoDisk.Font = (Font)resources.GetObject("rdoDisk.Font");
            rdoLight.Font = (Font)resources.GetObject("rdoLight.Font");
            rdoMiddle.Font = (Font)resources.GetObject("rdoMiddle.Font");
            rdoNormalPriorty.Font = (Font)resources.GetObject("rdoNormalPriorty.Font");
            rdoPositionPriorty.Font = (Font)resources.GetObject("rdoPositionPriorty.Font");
            rdoScrew.Font = (Font)resources.GetObject("rdoScrew.Font");
            rdoStiffnessPriorty.Font = (Font)resources.GetObject("rdoStiffnessPriorty.Font");
            rdoStrong.Font = (Font)resources.GetObject("rdoStrong.Font");
            rdoTurboDisable.Font = (Font)resources.GetObject("rdoTurboDisable.Font");
            rdoTurboEnable.Font = (Font)resources.GetObject("rdoTurboEnable.Font");
            rdoVelObsDisable.Font = (Font)resources.GetObject("rdoVelObsDisable.Font");
            rdoVelObsEnable.Font = (Font)resources.GetObject("rdoVelObsEnable.Font");
            rtxtFFT_Peek.Font = (Font)resources.GetObject("rtxtFFT_Peek.Font");
            rtxtGainNow.Font = (Font)resources.GetObject("rtxtGainNow.Font");
            rtxtResult.Font = (Font)resources.GetObject("rtxtResult.Font");
            tabPageGainNow.Font = (Font)resources.GetObject("tabPageGainNow.Font");
            tabPageOutput1.Font = (Font)resources.GetObject("tabPageOutput1.Font");
            tabPageOutput2.Font = (Font)resources.GetObject("tabPageOutput2.Font");
            toolStripAutoTuning.Font = (Font)resources.GetObject("toolStripAutoTuning.Font");
            toolStripAutoTuning2.Font = (Font)resources.GetObject("toolStripAutoTuning2.Font");
            tabTuning.Font = (Font)resources.GetObject("tabTuning.Font");
            tabAutoTuning.Font = (Font)resources.GetObject("tabAutoTuning.Font");

            tabTuning.ItemSize = (Size)resources.GetObject("tabTuning.ItemSize");

            this.Text = resources.GetString("$this.Text");
			btnAutoTuningWizard.Text = resources.GetString("btnAutoTuningWizard.Text");
			btnTuningControl.Text = resources.GetString("btnTuningControl.Text");
			btnConfigOutput.Text = resources.GetString("btnConfigOutput.Text");
            btnConfigRead.Text = resources.GetString("btnConfigRead.Text");
            btnPause.Text = resources.GetString("btnPause.Text");
            btnRepeat.Text = resources.GetString("btnRepeat.Text");
            btnStop.Text = resources.GetString("btnStop.Text");
            btnStop2.Text = resources.GetString("btnStop2.Text");
            chkInc.Text = resources.GetString("chkInc.Text");
            chkLoadTuning.Text = resources.GetString("chkLoadTuning.Text");
            ClassName.HeaderText = resources.GetString("ClassName.HeaderText");
            ctlNumericInputInt1.TitleText = resources.GetString("ctlNumericInputInt1.TitleText");
            ctlNumericInputInt1.UnitText = resources.GetString("ctlNumericInputInt1.UnitText");
            ctlNumInposition.TitleText = resources.GetString("ctlNumInposition.TitleText");
            ctlNumInposition.UnitText = resources.GetString("ctlNumInposition.UnitText");
            ctlNumLoadTuningKi.TitleText = resources.GetString("ctlNumLoadTuningKi.TitleText");
            ctlNumLoadTuningKi.UnitText = resources.GetString("ctlNumLoadTuningKi.UnitText");
            ctlNumLoadTuningKp.TitleText = resources.GetString("ctlNumLoadTuningKp.TitleText");
            ctlNumLoadTuningKp.UnitText = resources.GetString("ctlNumLoadTuningKp.UnitText");
            ctlNumLoadTuningKv.TitleText = resources.GetString("ctlNumLoadTuningKv.TitleText");
            ctlNumLoadTuningKv.UnitText = resources.GetString("ctlNumLoadTuningKv.UnitText");
            ctlNumStartPosition.TitleText = resources.GetString("ctlNumStartPosition.TitleText");
            ctlNumStartPosition.UnitText = resources.GetString("ctlNumStartPosition.UnitText");
            ctlNumTargetAcceleration.TitleText = resources.GetString("ctlNumTargetAcceleration.TitleText");
            ctlNumTargetAcceleration.UnitText = resources.GetString("ctlNumTargetAcceleration.UnitText");
            ctlNumTargetDeceleration.TitleText  = resources.GetString("ctlNumTargetDeceleration.TitleText");
            ctlNumTargetDeceleration.UnitText = resources.GetString("ctlNumTargetDeceleration.UnitText");
            ctlNumTargetPosition.TitleText = resources.GetString("ctlNumTargetPosition.TitleText");
            ctlNumTargetPosition.UnitText = resources.GetString("ctlNumTargetPosition.UnitText");
            ctlNumTargetTime.TitleText = resources.GetString("ctlNumTargetTime.TitleText");
            ctlNumTargetTime.UnitText = resources.GetString("ctlNumTargetTime.UnitText");
            ctlNumTargetVelocity.TitleText = resources.GetString("ctlNumTargetVelocity.TitleText");
            ctlNumTargetVelocity.UnitText = resources.GetString("ctlNumTargetVelocity.UnitText");
            ctlNumWaitTime.TitleText = resources.GetString("ctlNumWaitTime.TitleText");
            ctlNumWaitTime.UnitText = resources.GetString("ctlNumWaitTime.UnitText");
            grpAcceleration.Text = resources.GetString("grpAcceleration.Text");
            grpDeceleration.Text = resources.GetString("grpDeceleration.Text");
            grpGainStrength.Text = resources.GetString("grpGainStrength.Text");
            grpInposition.Text = resources.GetString("grpInposition.Text");
            grpLoadTuningGain.Text = resources.GetString("grpLoadTuningGain.Text");
            grpLoadTuningKi.Text = resources.GetString("grpLoadTuningKi.Text");
            grpLoadTuningKp.Text = resources.GetString("grpLoadTuningKp.Text");
            grpLoadTuningKv.Text = resources.GetString("grpLoadTuningKv.Text");
            grpLoadTuningSetting.Text = resources.GetString("grpLoadTuningSetting.Text");
            grpMachineType.Text = resources.GetString("grpMachineType.Text");
            grpStartPosition.Text = resources.GetString("grpStartPosition.Text");
            grpTargetPosition.Text = resources.GetString("grpTargetPosition.Text");
            grpTargetTime.Text = resources.GetString("grpTargetTime.Text");
            grpTuningMode.Text = resources.GetString("grpTuningMode.Text");
            grpTuningTurbo.Text = resources.GetString("grpTuningTurbo.Text");
            grpVelocity.Text = resources.GetString("grpVelocity.Text");
            grpVelocityObserver.Text  = resources.GetString("grpVelocityObserver.Text");
            grpWait.Text = resources.GetString("grpWait.Text");
            ID.HeaderText = resources.GetString("ID.HeaderText");
            lblAccTime.Text = resources.GetString("lblAccTime.Text");
            lblDccTime.Text = resources.GetString("lblDccTime.Text");
            lblInc.Text = resources.GetString(" lblInc.Text");
            lblInposWidthUnit.Text = resources.GetString("lblInposWidthUnit.Text");
            lblLoadTuningCnt.Text = resources.GetString("lblLoadTuningCnt.Text");
            lblLoadTuningKi.Text = resources.GetString("lblLoadTuningKi.Text");
            lblLoadTuningKp.Text = resources.GetString("lblLoadTuningKp.Text");
            lblLoadTuningKv.Text = resources.GetString("lblLoadTuningKv.Text");
            lblSelect.Text = resources.GetString("lblSelect.Text");
            lblStopWatch.Text = resources.GetString("lblStopWatch.Text");
            lblTargetTimeUnit.Text = resources.GetString("lblTargetTimeUnit.Text");
            lblTempTuningCnt.Text = resources.GetString("lblTempTuningCnt.Text");
            lblTempTuningCoeff.Text = resources.GetString("lblTempTuningCoeff.Text");
            lblVibration.Text = resources.GetString("lblVibration.Text");
            OldValue.HeaderText = resources.GetString("OldValue.HeaderText");
            rdoBelt.Text = resources.GetString("rdoBelt.Text");
            rdoDisk.Text = resources.GetString("rdoDisk.Text");
            rdoLight.Text = resources.GetString("rdoLight.Text");
            rdoMiddle.Text = resources.GetString("rdoMiddle.Text");
            rdoNormalPriorty.Text = resources.GetString("rdoNormalPriorty.Text");
            rdoPositionPriorty.Text = resources.GetString("rdoPositionPriorty.Text");
            rdoScrew.Text = resources.GetString("rdoScrew.Text");
            rdoStiffnessPriorty.Text = resources.GetString("rdoStiffnessPriorty.Text");
            rdoStrong.Text = resources.GetString("rdoStrong.Text");
            rdoTurboDisable.Text = resources.GetString("rdoTurboDisable.Text");
            rdoTurboEnable.Text = resources.GetString("rdoTurboEnable.Text");
            rdoVelObsDisable.Text = resources.GetString("rdoVelObsDisable.Text");
            rdoVelObsEnable.Text = resources.GetString("rdoVelObsEnable.Text");
            rtxtFFT_Peek.Text = resources.GetString("rtxtFFT_Peek.Text");
            rtxtGainNow.Text = resources.GetString("rtxtGainNow.Text");
            rtxtResult.Text = resources.GetString("rtxtResult.Text");
            tabPageGainNow.Text = resources.GetString("tabPageGainNow.Text");
            tabPageOutput1.Text = resources.GetString("tabPageOutput1.Text");
            tabPageOutput2.Text = resources.GetString("tabPageOutput2.Text");
            tabPageTuningMode.Text = resources.GetString("tabPageTuningMode.Text");
            tabPageTuningOutput.Text = resources.GetString("tabPageTuningOutput.Text");
            tabPageTuningParameter.Text = resources.GetString("tabPageTuningParameter.Text");
            tabPageTuningTarget.Text = resources.GetString("tabPageTuningTarget.Text");
            toolStripAutoTuning.Text = resources.GetString("toolStripAutoTuning.Text");
            toolStripAutoTuning2.Text = resources.GetString("toolStripAutoTuning2.Text");

            if (IsCollapseLayout)
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        lblVibration.Font = AppFont.MeiryoRegular12;
                        lblStopWatch.Font = AppFont.MeiryoRegular14;
                        break;

                    case Culture.US:
                        lblVibration.Font = AppFont.MeiryoRegular12;
                        lblStopWatch.Font = AppFont.MeiryoRegular14;
                        break;

                    case Culture.CN:
                        lblVibration.Font = AppFont.MicrosoftYaHeiRegular12;
                        lblStopWatch.Font = AppFont.MicrosoftYaHeiRegular14;
                        break;
                }

            }
            else
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        lblVibration.Font = AppFont.MeiryoRegular16;
                        lblStopWatch.Font = AppFont.MeiryoRegular18;
                        break;

                    case Culture.US:
                        lblVibration.Font = AppFont.MeiryoRegular16;
                        lblStopWatch.Font = AppFont.MeiryoRegular18;
                        break;

                    case Culture.CN:
                        lblVibration.Font = AppFont.MicrosoftYaHeiRegular16;
                        lblStopWatch.Font = AppFont.MicrosoftYaHeiRegular18;
                        break;
                }
            
            }
        }

        #endregion

        /// <summary>
        /// オートチューニングタブオーナードローイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabTuning_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tab = (TabControl)sender;
            string txt = tab.TabPages[e.Index].Text;

            Font font = new Font(e.Font.FontFamily, e.Font.Size, FontStyle.Regular);
            
            
            LinearGradientBrush gb = new LinearGradientBrush(e.Bounds,
                                                             Color.Cyan,
                                                             Color.DodgerBlue,
                                                             LinearGradientMode.Vertical);

            //タブのテキストと背景を描画するためのブラシを決定する           
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                //選択されているタブ
                //font = new Font(e.Font.FontFamily, e.Font.Size, FontStyle.Bold);
                //e.Graphics.FillRectangle(gb, e.Bounds);
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
            }
            else
            {
                //選択されていないタブ
                //font = new Font(e.Font.FontFamily, e.Font.Size, FontStyle.Regular);
                e.Graphics.FillRectangle(Brushes.WhiteSmoke, e.Bounds);
            }

            

            StringFormat sf = new StringFormat();

            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            e.Graphics.DrawString(txt, font, Brushes.Black, e.Bounds, sf);
        }
	}

}