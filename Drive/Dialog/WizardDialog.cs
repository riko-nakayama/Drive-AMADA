using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace Motion_Designer
{
	public partial class WizardDialog : Form
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

		static private int _LoadInertia = new int();

		static private TuningMachine _TuningMachine = TuningMachine.Disk;
		static private TuningStrength _TuningStrength = TuningStrength.Light;
		static private TuningPriorty _TuningMode = TuningPriorty.Normal;

		static private bool _EnableVelocityObserver = new bool();
		static private bool _EnableTuningTurbo = new bool();
		static private int _InpositionWidth = new int();
		static private int _TargetTime = new int();

		static private int _TargetVelocity = new int();
		static private int _TargetAcceleration = new int();
		static private int _TargetDeceleration = new int();
		static private int _WaitTime = new int();
		static private int _TuningPosition = new int();
		static private int _TargetPosition = new int();

		static private int _EncderResolution = new int();

		private bool CancelCloseMessage = new bool();

		public WizardDialog()
		{
			InitializeComponent();

			ctlNumLoad.NumInputValueChanged += new dNumInputValueCheange(ctlNumLoad_NumInputValueChanged);
			ctlNumInposition.NumInputValueChanged += new dNumInputValueCheange(ctlNumInposition_NumInputValueChanged);
			ctlNumTargetTime.NumInputValueChanged += new dNumInputValueCheange(ctlNumTargetTime_NumInputValueChanged);
			ctlNumTargetVelocity.NumInputValueChanged += new dNumInputValueCheange(ctlNumTargetVelocity_NumInputValueChanged);
			ctlNumTargetAcceleration.NumInputValueChanged += new dNumInputValueCheange(ctlNumTargetAcceleration_NumInputValueChanged);
			ctlNumTargetDeceleration.NumInputValueChanged += new dNumInputValueCheange(ctlNumTargetDeceleration_NumInputValueChanged);
			ctlNumWaitTime.NumInputValueChanged += new dNumInputValueCheange(ctlNumWaitTime_NumInputValueChanged);
			ctlNumStartPosition.NumInputValueChanged += new dNumInputValueCheange(ctlNumStartPosition_NumInputValueChanged);
			ctlNumTargetPosition.NumInputValueChanged += new dNumInputValueCheange(ctlNumTargetPosition_NumInputValueChanged);
	
		}

		void ctlNumTargetPosition_NumInputValueChanged()
		{
			TargetPosition = ctlNumTargetPosition.IntValue;
		}

		void ctlNumStartPosition_NumInputValueChanged()
		{
			TuningPosition = ctlNumStartPosition.IntValue;
		}

		void ctlNumWaitTime_NumInputValueChanged()
		{
			WaitTime = ctlNumWaitTime.IntValue;
		}

		void ctlNumTargetDeceleration_NumInputValueChanged()
		{
			TargetDeceleration = ctlNumTargetDeceleration.IntValue;
			UpdateAccDccTime();
		}

		void ctlNumTargetAcceleration_NumInputValueChanged()
		{
			TargetAcceleration = ctlNumTargetAcceleration.IntValue;
			UpdateAccDccTime();
		}

		void ctlNumTargetVelocity_NumInputValueChanged()
		{
			TargetVelocity = ctlNumTargetVelocity.IntValue;
			UpdateAccDccTime();
		}

		void ctlNumTargetTime_NumInputValueChanged()
		{
			TargetTime = ctlNumTargetTime.IntValue;
		}

		void ctlNumInposition_NumInputValueChanged()
		{
			InpositionWidth = ctlNumInposition.IntValue;
		}

		void ctlNumLoad_NumInputValueChanged()
		{
			LoadInertia = ctlNumLoad.IntValue;
		}

		private void WizardForm_Load(object sender, EventArgs e)
		{
			ChildFormControl.SetOpacity(0.0);
			ChildFormControl.PropertyLock = true;

			//行間変更
			int size = Marshal.SizeOf(typeof(PARAFORMAT2));

			PARAFORMAT2 pf = new PARAFORMAT2();
			pf.cbSize = (uint)size;
			pf.dwMask = PFM_LINESPACING;
			pf.bLineSpacingRule = 4;
			pf.dyLineSpacing = 350; // 行間 ( twips )

			SendMessage(rtxtWizard.Handle, EM_SETPARAFORMAT, IntPtr.Zero, ref pf);

			//このオプションを付けないとRichTextで設定されたフォントが反映されない
			rtxtWizard.LanguageOption = RichTextBoxLanguageOptions.DualFont;

			tabWizard.TabPages.RemoveAt(10);		//20160404 add

			UpdateAccDccTime();

		}

		private void WizardForm_Shown(object sender, EventArgs e)
		{
			ctlNumLoad.IntValue = LoadInertia;

            // ↓↓↓ 20210324 Kimura update ↓↓↓
            lblLoadNow.Text = UserText.WizardNowValue + LoadInertia.ToString() + UserText.InertiaUnit + UserText.WizardIs;
            //lblLoadNow.Text = UserText.WizardNowValue + LoadInertia.ToString() + "[g・cm]" + UserText.WizardIs;
            // ↑↑↑ 20210324 Kimura update ↑↑↑

            // ↓↓↓ 20210324 Kimura add ↓↓↓
            lblUnit.Text = UserText.InertiaUnit;
            // ↑↑↑ 20210324 Kimura add ↑↑↑

			switch (TuningMachine)
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

			switch (TuningStrength)
			{
				case TuningStrength.Light:

					rdoLight.Checked = true;
					break;

				case TuningStrength.Middle:

					rdoMidlle.Checked = true;
					break;

				case TuningStrength.Strong:

					rdoStrong.Checked = true;
					break;
			}

			switch (TuningMode)
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

			if (EnableVelocityObserver)
			{
				rdoVelObsEnable.Checked = true;
			}
			else
			{
				rdoVelObsDisable.Checked = true;
			}

			if (EnableTuningTurbo)
			{
				rdoTurboEnable.Checked = true;
			}
			else
			{
				rdoTurboDisable.Checked = true;
			}
            
			ctlNumInposition.IntValue = InpositionWidth;
			lblInpositionNow.Text = UserText.WizardNowValue + InpositionWidth.ToString() + "[pulse]" + UserText.WizardIs;
			lblEncderPulse.Text = UserText.WizardRevolution + EncderResolution.ToString() + "[pulse]" + UserText.WizardIs;

			ctlNumTargetTime.IntValue = TargetTime;
			lblTargetTimeNow.Text = UserText.WizardNowValue + TargetTime.ToString() + "[msec]" + UserText.WizardIs;

			ctlNumTargetVelocity.IntValue = TargetVelocity;
			ctlNumTargetAcceleration.IntValue = TargetAcceleration;
			ctlNumTargetDeceleration.IntValue = TargetDeceleration;
			ctlNumWaitTime.IntValue = WaitTime;
			ctlNumStartPosition.IntValue = TuningPosition;
			ctlNumTargetPosition.IntValue = TargetPosition;		
			
			rdoMachineType_CheckedChanged(null, null);
			rdoTuningStrength_CheckedChanged(null, null);
			rdoTuningMode_CheckedChanged(null, null);
			rdoVelObsEnable_CheckedChanged(null, null);

			int cw_trq = CMonitor.GetParameter(CParamID.FrictionCwTrq);
			int ccw_trq = CMonitor.GetParameter(CParamID.FrictionCcwTrq);

			lblFrictionCwNow.Text = UserText.WizardFrictionCwNowValue + cw_trq.ToString() + "[0.01A]" + UserText.WizardIs;
			lblFrictionCcwNow.Text = UserText.WizardFrictionCcwNowValue + ccw_trq.ToString() + "[0.01A]" + UserText.WizardIs;
		}

		private void WizardForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!CancelCloseMessage)
			{
				DialogResult ret = UserMessageBox.WizardClose();

				if (ret == DialogResult.No)
				{
					e.Cancel = true;
				}

				this.DialogResult = DialogResult.Cancel;
			}
		}

		private void WizardForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			ChildFormControl.PropertyLock = false;
			ChildFormControl.SetOpacity(1.0);
		}

		static public int LoadInertia
		{
			set { _LoadInertia = value; }
			get { return _LoadInertia; }
		}

		static public TuningMachine TuningMachine
		{
			set { _TuningMachine = value; }
			get { return _TuningMachine; }
		}

		static public TuningStrength TuningStrength
		{
			set { _TuningStrength = value; }
			get { return _TuningStrength; }
		}

		static public TuningPriorty TuningMode
		{
			set { _TuningMode = value; }
			get { return _TuningMode; }
		}

		static public bool EnableVelocityObserver
		{
			set { _EnableVelocityObserver = value; }
			get { return _EnableVelocityObserver; }

		}

		static public bool EnableTuningTurbo
		{
			set { _EnableTuningTurbo = value; }
			get { return _EnableTuningTurbo; }

		}

		static public int InpositionWidth
		{
			set { _InpositionWidth = value; }
			get { return _InpositionWidth; }
		}

		static public int TargetTime
		{
			set { _TargetTime = value; }
			get { return _TargetTime; }
		}

		static public int TargetVelocity
		{
			set { _TargetVelocity = value; }
			get { return _TargetVelocity; }
		}

		static public int TargetAcceleration
		{
			set { _TargetAcceleration = value; }
			get { return _TargetAcceleration; }
		}

		static public int TargetDeceleration
		{
			set { _TargetDeceleration = value; }
			get { return _TargetDeceleration; }
		}

		static public int WaitTime
		{
			set { _WaitTime = value; }
			get { return _WaitTime; }
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

		static public int EncderResolution
		{
			set { _EncderResolution = value; }
			get { return _EncderResolution; }
		}

		private void btnNext_Click(object sender, EventArgs e)
		{
			int n = tabWizard.TabCount;

			int s = tabWizard.SelectedIndex;

			if (s < n - 1)
			{
				tabWizard.SelectedIndex = s + 1;
			}
			else
			{
				btnAutoTuningStart.PerformClick();
			}
			
		}

		private void btnPrev_Click(object sender, EventArgs e)
		{
			int s = tabWizard.SelectedIndex;

			if (s > 0)
			{
				tabWizard.SelectedIndex = s - 1;
			}
		}

		private void btnLoadTuning_Click(object sender, EventArgs e)
		{
			AutoTuningForm.ThisForm.CallMeasLoadInertia();

			TimerLoad.Interval = 1000;
			TimerLoad.Start();

		}

		private void btnLoadTuningStop_Click(object sender, EventArgs e)
		{
			AutoTuningForm.ThisForm.CallTuningStop();

			TimerLoad.Enabled = false;
		}

		private void btnFriction_Click(object sender, EventArgs e)
		{
			AutoTuningForm.ThisForm.CallFrictionCompensation();

			TimerFriction.Interval = 1000;
			TimerFriction.Start();

		}

		private void btnTeaching_Click(object sender, EventArgs e)
		{
			if (!MainForm.IsUsbConnectBlink) { return; }

			TeachingDialog teachForm = new TeachingDialog();

			AutoTuningForm.ThisForm.CallStoreServoParameter();

			AutoTuningForm.ThisForm.CallClearFillter();

			AutoTuningForm.ThisForm.CallSetTeachingServoGain();

			teachForm.ShowDialog();

			AutoTuningForm.ThisForm.CallReStoreServoParameter();

			if (TeachingDialog.FixedTuningPosition)
			{
				TuningPosition = TeachingDialog.TuningPosition;
				ctlNumStartPosition.IntValue = TeachingDialog.TuningPosition;
			}

			if (TeachingDialog.FixedTargetPosition)
			{
				TargetPosition = TeachingDialog.TargetPosition;
				ctlNumTargetPosition.IntValue = TeachingDialog.TargetPosition;
			}
		}

		private void btnStopWizard_Click(object sender, EventArgs e)
		{
			DialogResult ret = UserMessageBox.WizardClose();

			if (ret == DialogResult.Yes)
			{
				CancelCloseMessage = true;
			
				this.DialogResult = DialogResult.Cancel;
				this.Close();
			}
		}

		private void btnAutoTuningStart_Click(object sender, EventArgs e)
		{
			DialogResult ret = DialogResult.No;

			if (TargetVelocity <= 0)
			{
				UserMessageBox.WizardTuningVelocityWarning();
				return;
			}

			if (TargetAcceleration <= 10)
			{
				UserMessageBox.WizardTuningAccelerationWarning();
				return;
			}

			if (TargetDeceleration <= 10)
			{
				UserMessageBox.WizardTuningDecelerationWarning();
				return;
			}

			//20160329 del
			//if ((Math.Abs(TargetPosition - TuningPosition)) <= EncderResolution)
			//{
			//    UserMessageBox.WizardTuningPositionWarning();
			//    return;
			//}

			if (InpositionWidth < 1)
			{
				UserMessageBox.WizardTuningInPositionWidthWarning();
				return;
			}

			if (LoadInertia <= 0)
			{
				ret = UserMessageBox.WizardTuningLoadInertiaWarning();

				if (ret == DialogResult.No) { return; }
			}

			ret = UserMessageBox.WizardVerityTuningSetting();

			if (ret == DialogResult.No) { return; }

			CancelCloseMessage = true;
			this.DialogResult = DialogResult.OK;

			this.Close();
		}

		private void rdoMachineType_CheckedChanged(object sender, EventArgs e)
		{
            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    rdoDisk.Font = AppFont.MeiryoRegular9;
                    rdoBelt.Font = AppFont.MeiryoRegular9;
                    rdoScrew.Font = AppFont.MeiryoRegular9;
                    break;

                case Culture.US:

                    rdoDisk.Font = AppFont.MeiryoRegular9;
                    rdoBelt.Font = AppFont.MeiryoRegular9;
                    rdoScrew.Font = AppFont.MeiryoRegular9;
                    break;

                case Culture.CN:

                    rdoDisk.Font = AppFont.MicrosoftYaHeiRegular10;
                    rdoBelt.Font = AppFont.MicrosoftYaHeiRegular10;
                    rdoScrew.Font = AppFont.MicrosoftYaHeiRegular10;
                    break;
            }

			rdoDisk.ForeColor = AppFont.NormalForeColor;
			rdoBelt.ForeColor = AppFont.NormalForeColor;
			rdoScrew.ForeColor = AppFont.NormalForeColor;

			rdoDisk.BackColor = AppFont.NormalBackColor;
			rdoBelt.BackColor = AppFont.NormalBackColor;
			rdoScrew.BackColor = AppFont.NormalBackColor;

			if (rdoDisk.Checked)
			{
				rdoDisk.BackColor = AppFont.ActiveBackColor;
				TuningMachine = TuningMachine.Disk;
			}

			if (rdoBelt.Checked)
			{
				rdoBelt.BackColor = AppFont.ActiveBackColor;
				TuningMachine = TuningMachine.Belt;
			}

			if (rdoScrew.Checked)
			{
				rdoScrew.BackColor = AppFont.ActiveBackColor;
				TuningMachine = TuningMachine.Screw;
			}

		}

		private void rdoTuningStrength_CheckedChanged(object sender, EventArgs e)
		{

            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    rdoLight.Font = AppFont.MeiryoRegular9;
			        rdoMidlle.Font = AppFont.MeiryoRegular9;
                    rdoStrong.Font = AppFont.MeiryoRegular9;
                    break;

                case Culture.US:

                    rdoLight.Font = AppFont.MeiryoRegular9;
			        rdoMidlle.Font = AppFont.MeiryoRegular9;
			        rdoStrong.Font = AppFont.MeiryoRegular9;
                    break;

                case Culture.CN:

                    rdoLight.Font = AppFont.MicrosoftYaHeiRegular10;
                    rdoMidlle.Font = AppFont.MicrosoftYaHeiRegular10;
                    rdoStrong.Font = AppFont.MicrosoftYaHeiRegular10;
                    break;
            }

			rdoLight.ForeColor = AppFont.NormalForeColor;
			rdoMidlle.ForeColor = AppFont.NormalForeColor;
			rdoStrong.ForeColor = AppFont.NormalForeColor;

			rdoLight.BackColor = AppFont.NormalBackColor;
			rdoMidlle.BackColor = AppFont.NormalBackColor;
			rdoStrong.BackColor = AppFont.NormalBackColor;

			if (rdoLight.Checked)
			{
				rdoLight.BackColor = AppFont.ActiveBackColor;
				TuningStrength = TuningStrength.Light;
			}

			if (rdoMidlle.Checked)
			{
				rdoMidlle.BackColor = AppFont.ActiveBackColor;
				TuningStrength = TuningStrength.Middle;
			}

			if (rdoStrong.Checked)
			{
				rdoStrong.BackColor = AppFont.ActiveBackColor;
				TuningStrength = TuningStrength.Strong;
			}

		}

		private void rdoTuningMode_CheckedChanged(object sender, EventArgs e)
		{
			
            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    rdoNormalPriorty.Font = AppFont.MeiryoRegular9;
                    rdoPositionPriorty.Font = AppFont.MeiryoRegular9;
                    rdoStiffnessPriorty.Font = AppFont.MeiryoRegular9;
                    break;

                case Culture.US:

                    rdoNormalPriorty.Font = AppFont.MeiryoRegular9;
                    rdoPositionPriorty.Font = AppFont.MeiryoRegular9;
                    rdoStiffnessPriorty.Font = AppFont.MeiryoRegular9;
                    break;

                case Culture.CN:

                    rdoNormalPriorty.Font = AppFont.MicrosoftYaHeiRegular10;
                    rdoPositionPriorty.Font = AppFont.MicrosoftYaHeiRegular10;
                    rdoStiffnessPriorty.Font = AppFont.MicrosoftYaHeiRegular10;
                    break;
            }

			rdoNormalPriorty.ForeColor = AppFont.NormalForeColor;
			rdoPositionPriorty.ForeColor = AppFont.NormalForeColor;
			rdoStiffnessPriorty.ForeColor = AppFont.NormalForeColor;

			rdoNormalPriorty.BackColor = AppFont.NormalBackColor;
			rdoPositionPriorty.BackColor = AppFont.NormalBackColor;
			rdoStiffnessPriorty.BackColor = AppFont.NormalBackColor;

			if (rdoNormalPriorty.Checked)
			{
				rdoNormalPriorty.BackColor = AppFont.ActiveBackColor;
				TuningMode = TuningPriorty.Normal;
			}

			if (rdoPositionPriorty.Checked)
			{
				rdoPositionPriorty.BackColor = AppFont.ActiveBackColor;
				TuningMode = TuningPriorty.Position;
			}

			if (rdoStiffnessPriorty.Checked)
			{
				rdoStiffnessPriorty.BackColor = AppFont.ActiveBackColor;
				TuningMode = TuningPriorty.Stiffness;
			}

		}

		private void rdoVelObsEnable_CheckedChanged(object sender, EventArgs e)
		{
		
            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    rdoVelObsEnable.Font = AppFont.MeiryoRegular9;
                    rdoVelObsDisable.Font = AppFont.MeiryoRegular9;
                    break;

                case Culture.US:

                    rdoVelObsEnable.Font = AppFont.MeiryoRegular9;
                    rdoVelObsDisable.Font = AppFont.MeiryoRegular9;
                    break;

                case Culture.CN:

                    rdoVelObsEnable.Font = AppFont.MicrosoftYaHeiRegular10;
                    rdoVelObsDisable.Font = AppFont.MicrosoftYaHeiRegular10;
                    break;
            }

			rdoVelObsEnable.ForeColor = AppFont.NormalForeColor;
			rdoVelObsDisable.ForeColor = AppFont.NormalForeColor;

			rdoVelObsEnable.BackColor = AppFont.NormalBackColor;
			rdoVelObsDisable.BackColor = AppFont.NormalBackColor;

			if (rdoVelObsEnable.Checked)
			{
				EnableVelocityObserver = true;
				rdoVelObsEnable.BackColor = AppFont.ActiveBackColor;
			}
			else
			{
				EnableVelocityObserver = false;
				rdoVelObsDisable.BackColor = AppFont.ActiveBackColor;
			}
		}

		private void rdoTurboEnable_CheckedChanged(object sender, EventArgs e)
		{
			
            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    rdoTurboEnable.Font = AppFont.MeiryoRegular9;
                    rdoTurboDisable.Font = AppFont.MeiryoRegular9;
                    break;

                case Culture.US:

                    rdoTurboEnable.Font = AppFont.MeiryoRegular9;
                    rdoTurboDisable.Font = AppFont.MeiryoRegular9;
                    break;

                case Culture.CN:

                    rdoTurboEnable.Font = AppFont.MicrosoftYaHeiRegular10;
                    rdoTurboDisable.Font = AppFont.MicrosoftYaHeiRegular10;
                    break;
            }

			rdoTurboEnable.ForeColor = AppFont.NormalForeColor;
			rdoTurboDisable.ForeColor = AppFont.NormalForeColor;

			rdoTurboEnable.BackColor = AppFont.NormalBackColor;
			rdoTurboDisable.BackColor = AppFont.NormalBackColor;

			if (rdoTurboEnable.Checked)
			{
				EnableTuningTurbo = true;
				rdoTurboEnable.BackColor = AppFont.ActiveBackColor;
			}
			else
			{
				EnableTuningTurbo = false;
				rdoTurboDisable.BackColor = AppFont.ActiveBackColor;
			}
		}

		private void TabPage_Click(object sender, EventArgs e)
		{
			lblDmy.Select();
		}

		private void tabWizard_SelectedIndexChanged(object sender, EventArgs e)
		{
			int n = tabWizard.SelectedIndex;

			string tag = tabWizard.TabPages[n].Tag.ToString();

			btnAutoTuningStart.Enabled = false;
			btnAutoTuningStart.BackColor = SystemColors.Control;

			TimerWizard.Enabled = false;

			switch (tag)
			{
				default:

					btnNext.Text = UserText.WizardNext;
					btnNext.BackColor = SystemColors.Control;
					break;

				case "End":

					//最終ページ
					btnNext.Text = UserText.WizardExec;

					rtxtWizard.Clear();

					rtxtWizard.AppendText("\n");

                    // ↓↓↓ 20210324 Kimura update ↓↓↓
                    rtxtWizard.AppendText(UserText.TuningParameterInertia + LoadInertia.ToString() + UserText.InertiaUnit);
					//rtxtWizard.AppendText(UserText.TuningParameterInertia + LoadInertia.ToString() + "[g・cm]");
                    // ↑↑↑ 20210324 Kimura update ↑↑↑
                    
                    rtxtWizard.AppendText("\n");

					switch (TuningMachine)
					{
						case TuningMachine.Disk:
							rtxtWizard.AppendText(UserText.TuningParameterMachineTypeDisk);
							break;

						case TuningMachine.Belt:
							rtxtWizard.AppendText(UserText.TuningParameterMachineTypeBelt);
							break;

						case TuningMachine.Screw:
							rtxtWizard.AppendText(UserText.TuningParameterMachineTypeScrew);
							break;
					}

					rtxtWizard.AppendText("\n");

					switch (TuningStrength)
					{
						case TuningStrength.Light:
							rtxtWizard.AppendText(UserText.TuningParameterTuningStrengthLight);
							break;

						case TuningStrength.Middle:
							rtxtWizard.AppendText(UserText.TuningParameterTuningStrengthMiddle);
							break;

						case TuningStrength.Strong:
							rtxtWizard.AppendText(UserText.TuningParameterTuningStrengthStrong);
							break;
					}

					rtxtWizard.AppendText("\n");

					switch (TuningMode)
					{
						case TuningPriorty.Normal:
							rtxtWizard.AppendText(UserText.TuningParameterTuningPriortyNormal);
							break;

						case TuningPriorty.Position:
							rtxtWizard.AppendText(UserText.TuningParameterTuningPriortyPosition);
							break;

						case TuningPriorty.Stiffness:
							rtxtWizard.AppendText(UserText.TuningParameterTuningPriortyStiffness);
							break;
					}

					rtxtWizard.AppendText("\n");

					if (EnableVelocityObserver)
					{
						rtxtWizard.AppendText(UserText.TuningParameterLoadStable);
					}
					else
					{
						rtxtWizard.AppendText(UserText.TuningParameterLoadUnstable);
					}

					rtxtWizard.AppendText("\n");

					if (EnableTuningTurbo)
					{
						rtxtWizard.AppendText(UserText.TuningParameterTurboEnable);
					}
					else
					{
						rtxtWizard.AppendText(UserText.TuningParameterTurboDisable);
					}

					rtxtWizard.AppendText("\n");

					rtxtWizard.AppendText(UserText.TuningParameterTargetVelocity + TargetVelocity.ToString() + "[rpm]");
					rtxtWizard.AppendText("\n");

					rtxtWizard.AppendText(UserText.TuningParameterTargetAcceleration + TargetAcceleration.ToString() + "[10rpm/sec]");
					rtxtWizard.AppendText("\n");

					rtxtWizard.AppendText(UserText.TuningParameterTargetDeceleration + TargetDeceleration.ToString() + "[10rpm/sec]");
					rtxtWizard.AppendText("\n");

					rtxtWizard.AppendText(UserText.TuningParameterWaitTime + WaitTime.ToString() + "[msec]");
					rtxtWizard.AppendText("\n");

					rtxtWizard.AppendText(UserText.TuningParameterStartPosition + TuningPosition.ToString() + "[pulse]");
					rtxtWizard.AppendText("\n");

					rtxtWizard.AppendText(UserText.TuningParameterTargetPosition + TargetPosition.ToString() + "[pulse]");
					rtxtWizard.AppendText("\n");

					btnAutoTuningStart.Enabled = true;

					TimerWizard.Enabled = true;
					TimerWizard.Interval = 500;

					break;
			}
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

		private void TimerWizard_Tick(object sender, EventArgs e)
		{
			if (btnAutoTuningStart.BackColor == Color.Cyan)
			{
				btnAutoTuningStart.BackColor = SystemColors.Control;
				btnNext.BackColor = SystemColors.Control;
			}
			else
			{
				btnAutoTuningStart.BackColor = Color.Cyan;
				btnNext.BackColor = Color.Cyan;
			}
		}

		private void TimerLoad_Tick(object sender, EventArgs e)
		{
			bool end = AutoTuningForm.ThisForm.CallLoadTuningState();

			if (end)
			{
				TimerLoad.Enabled = false;
				ctlNumLoad.IntValue = LoadInertia;

                // ↓↓↓ 20210324 Kimura update ↓↓
                lblLoadNow.Text = UserText.WizardNowValue + LoadInertia.ToString() + UserText.InertiaUnit + UserText.WizardIs;
                //lblLoadNow.Text = UserText.WizardNowValue + LoadInertia.ToString() + "[g・cm]" + UserText.WizardIs;
                // ↑↑↑ 20210324 Kimura update ↑↑↑
			}
		}

		private void TimerFriction_Tick(object sender, EventArgs e)
		{
			TimerFriction.Enabled = false;

			int cw_trq = CMonitor.GetParameter(CParamID.FrictionCwTrq);
			int ccw_trq = CMonitor.GetParameter(CParamID.FrictionCcwTrq);

			lblFrictionCwNow.Text = UserText.WizardFrictionCwNowValue + "  " + cw_trq.ToString() + " [0.01A] " + UserText.WizardIs;
			lblFrictionCcwNow.Text = UserText.WizardFrictionCcwNowValue + "  " + ccw_trq.ToString() + " [0.01A] " + UserText.WizardIs;
		
		}

        #region タブオーナードロー

        /// <summary>
        /// ウィザードタブオーナードローイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabWizard_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tab = (TabControl)sender;
            string txt = tab.TabPages[e.Index].Text;

            Font font;

            LinearGradientBrush f_gb = new LinearGradientBrush(e.Bounds,
                                                               Color.Cyan,
                                                               Color.DodgerBlue,
                                                               LinearGradientMode.Vertical);

            LinearGradientBrush g_gb = new LinearGradientBrush(e.Bounds,
                                                               Color.LightGray,
                                                               Color.White,
                                                               LinearGradientMode.Vertical);

            //タブのテキストと背景を描画するためのブラシを決定する           
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                //選択されているタブ
                font = new Font(e.Font.FontFamily, e.Font.Size, FontStyle.Bold);
                e.Graphics.FillRectangle(f_gb, e.Bounds);
            }
            else
            {
                //選択されていないタブ
                font = new Font(e.Font.FontFamily, e.Font.Size, FontStyle.Regular);
                e.Graphics.FillRectangle(g_gb, e.Bounds);
            }

            StringFormat sf = new StringFormat();

            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            Rectangle rect = e.Bounds;

            switch (Culture.Name)
            {
                default:
                case Culture.JP:
                    rect.Y += 3;
                    break;

                case Culture.US:
                    rect.Y += 3;
                    break;

                case Culture.CN:
                    break;
            }

            e.Graphics.DrawString(txt, font, Brushes.Black, rect, sf);

            f_gb.Dispose();
            g_gb.Dispose();
        }

        #endregion

    }
}