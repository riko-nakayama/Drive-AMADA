using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
	public partial class CtlPlotMenu : UserControl
	{
		public delegate void dZoomClicked(object sender, EventArgs e);

		public event dZoomClicked ZoomClicked;

		public delegate void dControlStateChanged();
		public delegate void dValueOffsetChanged();
		public delegate void dViewCleared();
		public delegate void dViewHold(bool on);
		public delegate void dViewZoomed();
		public delegate void dScaleDivisionChanged();

		public event dControlStateChanged ControlStateChanged;
		public event dValueOffsetChanged ValueOffsetChanged;
		public event dViewCleared ViewCleared;
		public event dViewHold ViewHold;
		public event dViewZoomed ViewZoomed;
		public event dScaleDivisionChanged ScaleDivisionChanged;

        //↓↓↓ KASHIYAMA Mode 20200214 Kimura update ↓↓↓
        public delegate void dKashiyamaModeViewHold();
        public event dKashiyamaModeViewHold KashiyamaModeViewHold;

        ToolStripLabel[] HoldLabelCtrl = new ToolStripLabel[5];
        ToolStripLabel[] FFTHoldLineColorCtrl = new ToolStripLabel[5];

        private int HoldCount = 1;
        //↑↑↑ KASHIYAMA Mode 20200214 Kimura update ↑↑↑

		private const int MAX_CH = 8;

		ToolStripButton[] ViewEnableCtrl = new ToolStripButton[MAX_CH];
		ToolStripButton[] BackCtrl = new ToolStripButton[MAX_CH];
		ToolStripButton[] NextCtrl = new ToolStripButton[MAX_CH];
		ToolStripLabel[] SelectColorCtrl = new ToolStripLabel[MAX_CH];
		ToolStripLabel[] LineColorCtrl = new ToolStripLabel[MAX_CH];
		ToolStripComboBox[] LineWidthCtrl = new ToolStripComboBox[MAX_CH];

		string _CH1_Name = string.Empty;
		string _CH2_Name = string.Empty;
		string _CH3_Name = string.Empty;
		string _CH4_Name = string.Empty;
		string _CH5_Name = string.Empty;
		string _CH6_Name = string.Empty;
		string _CH7_Name = string.Empty;
		string _CH8_Name = string.Empty;

		private bool _IsViewHold = new bool();

		public CtlPlotMenu()
		{
			InitializeComponent();

			ViewEnableCtrl[0] = tbtnChannel0;
			ViewEnableCtrl[1] = tbtnChannel1;
			ViewEnableCtrl[2] = tbtnChannel2;
			ViewEnableCtrl[3] = tbtnChannel3;
			ViewEnableCtrl[4] = tbtnChannel4;
			ViewEnableCtrl[5] = tbtnChannel5;
			ViewEnableCtrl[6] = tbtnChannel6;
			ViewEnableCtrl[7] = tbtnChannel7;

			BackCtrl[0] = tbtnBack0;
			BackCtrl[1] = tbtnBack1;
			BackCtrl[2] = tbtnBack2;
			BackCtrl[3] = tbtnBack3;
			BackCtrl[4] = tbtnBack4;
			BackCtrl[5] = tbtnBack5;
			BackCtrl[6] = tbtnBack6;
			BackCtrl[7] = tbtnBack7;

			NextCtrl[0] = tbtnNext0;
			NextCtrl[1] = tbtnNext1;
			NextCtrl[2] = tbtnNext2;
			NextCtrl[3] = tbtnNext3;
			NextCtrl[4] = tbtnNext4;
			NextCtrl[5] = tbtnNext5;
			NextCtrl[6] = tbtnNext6;
			NextCtrl[7] = tbtnNext7;

			SelectColorCtrl[0] = tlblChannel0;
			SelectColorCtrl[1] = tlblChannel1;
			SelectColorCtrl[2] = tlblChannel2;
			SelectColorCtrl[3] = tlblChannel3;
			SelectColorCtrl[4] = tlblChannel4;
			SelectColorCtrl[5] = tlblChannel5;
			SelectColorCtrl[6] = tlblChannel6;
			SelectColorCtrl[7] = tlblChannel7;

			LineColorCtrl[0] = tlblColor0;
			LineColorCtrl[1] = tlblColor1;
			LineColorCtrl[2] = tlblColor2;
			LineColorCtrl[3] = tlblColor3;
			LineColorCtrl[4] = tlblColor4;
			LineColorCtrl[5] = tlblColor5;
			LineColorCtrl[6] = tlblColor6;
			LineColorCtrl[7] = tlblColor7;

			LineWidthCtrl[0] = tcmbChannel0;
			LineWidthCtrl[1] = tcmbChannel1;
			LineWidthCtrl[2] = tcmbChannel2;
			LineWidthCtrl[3] = tcmbChannel3;
			LineWidthCtrl[4] = tcmbChannel4;
			LineWidthCtrl[5] = tcmbChannel5;
			LineWidthCtrl[6] = tcmbChannel6;
			LineWidthCtrl[7] = tcmbChannel7;

            //↓↓↓ KASHIYAMA Mode 20200214 Kimura update ↓↓↓
            HoldLabelCtrl[0] = lblHold_0;
            HoldLabelCtrl[1] = lblHold_1;
            HoldLabelCtrl[2] = lblHold_2;
            HoldLabelCtrl[3] = lblHold_3;
            HoldLabelCtrl[4] = lblHold_4;

            FFTHoldLineColorCtrl[0] = tlblFFTHoldColor_0;
            FFTHoldLineColorCtrl[1] = tlblFFTHoldColor_1;
            FFTHoldLineColorCtrl[2] = tlblFFTHoldColor_2;
            FFTHoldLineColorCtrl[3] = tlblFFTHoldColor_3;
            FFTHoldLineColorCtrl[4] = tlblFFTHoldColor_4;
            //↑↑↑ KASHIYAMA Mode 20200214 Kimura update ↑↑↑
		}

		private void CtlPlotMenu_Load(object sender, EventArgs e)
		{
			ViewEnableCtrl[0].Text = CH1_Name + "_ON_";
			ViewEnableCtrl[1].Text = CH2_Name + "_ON_";
			ViewEnableCtrl[2].Text = CH3_Name + "_ON_";
			ViewEnableCtrl[3].Text = CH4_Name + "_ON_";
			ViewEnableCtrl[4].Text = CH5_Name + "_ON_";
			ViewEnableCtrl[5].Text = CH6_Name + "_ON_";
			ViewEnableCtrl[6].Text = CH7_Name + "_ON_";
			ViewEnableCtrl[7].Text = CH8_Name + "_ON_";

			for (int i = 0; i < ViewEnableCtrl.Length; i++)
			{
				ViewEnableCtrl[i].BackColor = Color.Gold;
			}

			InitMeasItem();

            //↓↓↓ KASHIYAMA Mode 20200214 Kimura update ↓↓↓
            ClearHoldLabelCtrlBackColor();
            //↑↑↑ KASHIYAMA Mode 20200214 Kimura update ↑↑↑
		}

		[Localizable(true)]

		public bool MathMode
		{
			get { return tbtnMath.Checked; }
		}

		public string BodeName
		{
			set { toolStripLabelName.Text = value; }
			get { return toolStripLabelName.Text; }
		}

		public string CH1_Name
		{
			set
			{
				_CH1_Name = value;

				if( tbtnChannel0.BackColor == Color.Gold )
				{
					tbtnChannel0.Text = _CH1_Name + "_ON_";
				}
				else
				{
					tbtnChannel0.Text = _CH1_Name + "_OFF";
				}
			}

			get { return _CH1_Name; }
		}

		public string CH2_Name
		{
			set
			{
				_CH2_Name = value;

				if (tbtnChannel1.BackColor == Color.Gold)
				{
					tbtnChannel1.Text = _CH2_Name + "_ON_";
				}
				else
				{
					tbtnChannel1.Text = _CH2_Name + "_OFF";
				}
			}
			
			get { return _CH2_Name; }
		}

		public string CH3_Name
		{
			set
			{
				_CH3_Name = value;

				if (tbtnChannel2.BackColor == Color.Gold)
				{
					tbtnChannel2.Text = _CH3_Name + "_ON_";
				}
				else
				{
					tbtnChannel2.Text = _CH3_Name + "_OFF";
				}
			}
			get { return _CH3_Name; }
		}

		public string CH4_Name
		{
			set
			{
				_CH4_Name = value;

				if (tbtnChannel3.BackColor == Color.Gold)
				{
					tbtnChannel3.Text = _CH4_Name + "_ON_";
				}
				else
				{
					tbtnChannel3.Text = _CH4_Name + "_OFF";
				}
			}
			get { return _CH4_Name; }
		}

		public string CH5_Name
		{
			set
			{
				_CH5_Name = value;

				if (tbtnChannel4.BackColor == Color.Gold)
				{
					tbtnChannel4.Text = _CH5_Name + "_ON_";
				}
				else
				{
					tbtnChannel4.Text = _CH5_Name + "_OFF";
				}
			}
			get { return _CH5_Name; }
		}

		public string CH6_Name
		{
			set
			{
				_CH6_Name = value;

				if (tbtnChannel5.BackColor == Color.Gold)
				{
					tbtnChannel5.Text = _CH6_Name + "_ON_";
				}
				else
				{
					tbtnChannel5.Text = _CH6_Name + "_OFF";
				}
			}
			get { return _CH6_Name; }
		}

		public string CH7_Name
		{
			set
			{
				_CH7_Name = value;

				if (tbtnChannel6.BackColor == Color.Gold)
				{
					tbtnChannel6.Text = _CH7_Name + "_ON_";
				}
				else
				{
					tbtnChannel6.Text = _CH7_Name + "_OFF";
				}
			}
			get { return _CH7_Name; }
		}

		public string CH8_Name
		{
			set
			{
				_CH8_Name = value;

				if (tbtnChannel7.BackColor == Color.Gold)
				{
					tbtnChannel7.Text = _CH8_Name + "_ON_";
				}
				else
				{
					tbtnChannel7.Text = _CH8_Name + "_OFF";
				}
			}
			get { return _CH8_Name; }
		}

		public bool EnableZoom
		{
			set
			{
				tbtnZoomP.Visible = value;
				tbtnZoomM.Visible = value;
				tsepZoomP.Visible = value;
				tsepZoomM.Visible = value;
				tlblTime.Visible = value;
			}
		}

		public bool EnableOffset
		{
			set
			{
				tbtnTopBack.Visible = value;
				tbtnEndBack.Visible = value;
				tbtnTopNext.Visible = value;
				tbtnEndNext.Visible = value;
				tcmbOffsetTop.Visible = value;
				tcmbOffsetEnd.Visible = value;
				tlblOffset.Visible = value;
				tsepOffset.Visible = value;
				tlblGainOffset.Visible = value;
				tsepY.Visible = value;
				//tlblTop.Visible = value;
				//tlblEnd.Visible = value;
			}
		}

		public double TopOffsetNumber
		{
			get
			{
				double n = 0;

				try
				{
					string txt =tcmbOffsetTop.Text;
					n = Convert.ToDouble(txt);			
				}
				catch
				{

				}
				return n;
			}
		}

		public double EndOffsetNumber
		{
			get
			{
				double n = 0;

				try
				{
					string txt = tcmbOffsetEnd.Text;
					n = Convert.ToDouble(txt);
				}
				catch
				{

				}
				return n;
			}
		}

		public int TopOffsetIndex
		{
			set
			{
				tcmbOffsetTop.SelectedIndex = value;
			}
		}

		public int EndOffsetIndex
		{
			set
			{
				tcmbOffsetEnd.SelectedIndex = value;
			}
		}

		public string OffsetUnit
		{
			set
			{
				tlblTop.Text = value;
				tlblEnd.Text = value;
			}
		}

		public bool VisibleFixed
		{
			set
			{
				tbtnFixed.Visible = value;
				tbtnFixedBack.Visible = value;
				tbtnFixedNext.Visible = value;
				tcmbFixed.Visible = value;
			}

			get
			{
				if (tbtnFixed.Visible &&
					tbtnFixedNext.Visible &&
					tbtnFixedBack.Visible &&
					tcmbFixed.Visible
					)
				{
					return true;
				}
				else
				{
					return false;
				}

			}
		}

		private bool VisibleFixedAll
		{
			set
			{
				tbtnFixed.Visible = value;
				tbtnFixedBack.Visible = value;
				tbtnFixedNext.Visible = value;
				tcmbFixed.Visible = value;
			}

			get
			{
				if (tbtnFixed.Visible &&
					tbtnFixedNext.Visible &&
					tbtnFixedBack.Visible &&
					tcmbFixed.Visible
					)
				{
					return true;
				}
				else
				{
					return false;
				}

			}
		}

		public bool VisibleChannelPuls
		{
			set { toolStripChannel.Visible = value; }
			get { return toolStripChannel.Visible; }
		}

		public bool VisibleChannelPuls2
		{
			set { toolStripChannel2.Visible = value; }
			get { return toolStripChannel2.Visible; }
		}

        //↓↓↓ KASHIYAMA Mode 20200214 Kimura update ↓↓↓
        public bool VisibleKASHIYAMAMode
        {
            set { toolStripKASHIYAMAMode.Visible = value; }
            get { return toolStripKASHIYAMAMode.Visible; }
        }
        //↑↑↑ KASHIYAMA Mode 20200214 Kimura update ↑↑↑

		public bool IsScaleFixed
		{
			get { return tbtnFixed.Checked; }
		}

		public double ScaleDivision
		{
			get { return Convert.ToDouble(tcmbFixed.Text); }
		}

		public bool IsViewHold
		{
			set
			{
				_IsViewHold = value;

				if (_IsViewHold)
				{
					tbtnHold.BackColor = Color.Gold;
					//tbtnHold.Text = UserText.CtlPlotMenuRestart;
				}
				else
				{
					tbtnHold.BackColor = SystemColors.Control;
					//tbtnHold.Text = UserText.CtlPlotMenuStop;
				}
			}

			get { return _IsViewHold; }
		}

		public bool HoldEnabled
		{
			set { tbtnHold.Enabled = value; }
			get { return tbtnHold.Enabled; }
		}

		public void ClearOffsetCommbo()
		{
			tcmbOffsetTop.Items.Clear();
			tcmbOffsetEnd.Items.Clear();
		}

		public void AddTopOffsetCommbo(List<string> item, string unit)
		{
			for (int i = 0; i < item.Count; i++)
			{
				tcmbOffsetTop.Items.Add(item[i]);
			}

			tlblTop.Text = unit;
		}

		public void AddEndOffsetCommbo(List<string> item, string unit)
		{
			for (int i = 0; i < item.Count; i++)
			{
				tcmbOffsetEnd.Items.Add(item[i]);
			}

			tlblEnd.Text = unit;
		}

		public bool GetViewEnable(int ch)
		{
			if (ch > MAX_CH) { return false; }

			if (ViewEnableCtrl[ch].BackColor == Color.Gold)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public void SetViewEnable(int ch, bool value)
		{
			if (ch > MAX_CH) { return; }

			if (value)
			{
				ViewEnableCtrl[ch].BackColor = Color.Gold;
			}
			else
			{
				ViewEnableCtrl[ch].BackColor = SystemColors.Control;
			}

		}

		public Color GetLineColor(int ch)
		{
			if (ch > MAX_CH) { return Color.Transparent; }

			return LineColorCtrl[ch].BackColor;
		}

		public void SetLineColor(int ch, Color value)
		{
			if (ch > MAX_CH) { return; }

			LineColorCtrl[ch].BackColor = value;
		}

		public float GetLineWidth(int ch)
		{
			if (ch > MAX_CH) { return 1.0f; }
		
			return Convert.ToSingle(LineWidthCtrl[ch].Text);
		}

		public void SetLineWidth(int ch, float value)
		{
			if (ch > MAX_CH) { return; }

			for (int i = 0; i < LineWidthCtrl[ch].Items.Count; i++)
			{
				if (LineWidthCtrl[ch].Items[i].ToString() == value.ToString())
				{
					LineWidthCtrl[ch].SelectedIndex = i;
					return;
				}
			}
		}

		private void Control_StateChanged(object sender, EventArgs e)
		{
			ControlStateChanged();
		}

		private void ColorSelect_Click(object sender, EventArgs e)
		{
			ToolStripLabel lbl = (ToolStripLabel)sender;

			ChildFormControl.SetOpacity(0.0);
		
			DialogResult ret = ColorDialogBode.ShowDialog();

			ChildFormControl.SetOpacity(1.0);
		
			if (ret == DialogResult.OK)
			{
				int ch = Convert.ToInt32(lbl.Tag);
	
				if (ch > MAX_CH) { return; }

				LineColorCtrl[ch].BackColor = ColorDialogBode.Color;
				ControlStateChanged();
			}
		}

		private void cmbSelect_KeyDown(object sender, KeyEventArgs e)
		{
			e.Handled = true;
		}

		private void cmbSelect_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = true;
		}

		private void btnNext_Click(object sender, EventArgs e)
		{
            ToolStripButton btn = (ToolStripButton)sender;
            ToolStripComboBox cmb = new ToolStripComboBox();

            int ch = Convert.ToInt32(btn.Tag);

            if (ch > MAX_CH) { return; }

            cmb = LineWidthCtrl[ch];

			if (cmb.SelectedIndex < cmb.Items.Count - 1)
			{
				cmb.SelectedIndex += 1;
			}
			else
			{
				cmb.SelectedIndex = 0;
			}
		}

		private void btnBack_Click(object sender, EventArgs e)
		{
			ToolStripButton btn = (ToolStripButton)sender;
            ToolStripComboBox cmb = new ToolStripComboBox();

            int ch = Convert.ToInt32(btn.Tag);

            if (ch > MAX_CH) { return; }

            cmb = LineWidthCtrl[ch];

			if (cmb.SelectedIndex > 0)
			{
				cmb.SelectedIndex -= 1;
			}
			else
			{
				cmb.SelectedIndex = cmb.Items.Count - 1;
			}
		}

		private void tbtnNextY_Click(object sender, EventArgs e)
		{
			NextY_Event(sender, e);
		}

		private void tbtnBackY_Click(object sender, EventArgs e)
		{
			BackY_Event(sender, e);
		}

		private void NextY_Event(object sender, EventArgs e)
		{

			ToolStripButton btn = (ToolStripButton)sender;
			ToolStripComboBox cmb = new ToolStripComboBox();

			if (btn.Tag.ToString() == "Top")
			{
				cmb = tcmbOffsetTop;
			}
			else
			{
				cmb = tcmbOffsetEnd;
			}

			if (cmb.SelectedIndex < cmb.Items.Count - 1)
			{
				cmb.SelectedIndex += 1;
			}
			else
			{
				//cmb.SelectedIndex = 0;
			}
		}

		private void BackY_Event(object sender, EventArgs e)
		{
			ToolStripButton btn = (ToolStripButton)sender;
			ToolStripComboBox cmb = new ToolStripComboBox();

			if (btn.Tag.ToString() == "Top")
			{
				cmb = tcmbOffsetTop;
			}
			else
			{
				cmb = tcmbOffsetEnd;
			}

			if (cmb.SelectedIndex > 0)
			{
				cmb.SelectedIndex -= 1;
			}
			else
			{
				//cmb.SelectedIndex = cmb.Items.Count - 1;
			}
		}

		private void ViewEnable_Click(object sender, EventArgs e)
		{
			ToolStripButton btn = (ToolStripButton)sender;

			int ch = Convert.ToInt32(btn.Tag);

			if (ch > MAX_CH) { return; }

			btn = ViewEnableCtrl[ch];

			string name = string.Empty;

			switch (ch)
			{
				case 0:
					name = CH1_Name;
					break;

				case 1:
					name = CH2_Name;
					break;

				case 2:
					name = CH3_Name;
					break;

				case 3:
					name = CH4_Name;
					break;

				case 4:
					name = CH5_Name;
					break;

				case 5:
					name = CH6_Name;
					break;

				case 6:
					name = CH7_Name;
					break;

				case 7:
					name = CH8_Name;
					break;

				default:
					break;
			}

			if (btn.BackColor == SystemColors.Control)
			{
				btn.BackColor = Color.Gold;
				btn.Text = name + "_ON_";
			}
			else
			{
				btn.BackColor = SystemColors.Control;
				btn.Text = name + "_OFF";
			}

			ControlStateChanged();

		}

		private void ToolStripButtonZoomClick(object sender, EventArgs e)
		{
			ZoomClicked(sender, e);
		}

		private bool ZoomFlag = new bool();
		private bool ZoomPuls = new bool();
		private bool TopFlag = new bool();
		private bool TopPuls = new bool();
		private bool EndFlag = new bool();
		private bool EndPuls = new bool();
		private bool FixedFlag = new bool();
		private bool FixedNext = new bool();

		private void toolStripButtonZoomP_MouseDown(object sender, MouseEventArgs e)
		{
			ToolStripButton btn = (ToolStripButton)sender;

			if (btn.Tag.ToString() == "+")
			{
				ZoomPuls = true;
			}
			else
			{
				ZoomPuls = false;
			}

			ZoomFlag = true;
			timerZoom.Interval = 500;
			timerZoom.Enabled = true;
		}

		private void toolStripButtonZoomP_MouseUp(object sender, MouseEventArgs e)
		{
			ZoomFlag = false;
			timerZoom.Enabled = false;
		}

		private void timerZoom_Tick(object sender, EventArgs e)
		{

			if (ZoomFlag)
			{
				if (timerZoom.Interval == 500)
				{
					timerZoom.Interval = 10;
				}

				if (ZoomPuls)
				{
					ZoomClicked(tbtnZoomP, null);
				}
				else
				{
					ZoomClicked(tbtnZoomM, null);
				}
			}

			if (FixedFlag)
			{
				if (timerZoom.Interval == 500) 
				{
					//DisableCntrolStateChange = true;
					timerZoom.Interval = 100;
				}

				if (FixedNext)
				{
					tbtnFixedNext.PerformClick();
				}
				else
				{
					tbtnFixedBack.PerformClick();
				}
			}

			if (TopFlag)
			{
				if (timerZoom.Interval == 500) { timerZoom.Interval = 100; }

				if (TopPuls)
				{
					NextY_Event(tbtnTopNext, null);
				}
				else
				{
					BackY_Event(tbtnTopBack, null);
				}
			}

			if (EndFlag)
			{
				if (timerZoom.Interval == 500) { timerZoom.Interval = 100; }
				
				if (EndPuls)
				{
					NextY_Event(tbtnEndNext, null);
				}
				else
				{
					BackY_Event(tbtnEndBack, null);
				}
			}
		}

		private void tcmbOffset_TextChanged(object sender, EventArgs e)
		{
			ToolStripComboBox cmb = (ToolStripComboBox)sender;

			if (cmb.Tag.ToString() == "Top")
			{
				if (tcmbOffsetTop.SelectedIndex > tcmbOffsetEnd.SelectedIndex - 1)
				{
					tcmbOffsetTop.SelectedIndex = tcmbOffsetEnd.SelectedIndex - 1;
					return;
				}
			}
			else
			{
				if (tcmbOffsetTop.SelectedIndex + 1 > tcmbOffsetEnd.SelectedIndex)
				{
					tcmbOffsetEnd.SelectedIndex = tcmbOffsetTop.SelectedIndex + 1;
					return;
				}
			}

			ValueOffsetChanged();
		}

		private void tbtnTop_MouseDown(object sender, MouseEventArgs e)
		{
			ToolStripButton btn = (ToolStripButton)sender;

			if (btn.Name == "tbtnTopNext")
			{
				TopPuls = true;
			}
			else
			{
				TopPuls = false;
			}

			TopFlag = true;
			timerZoom.Interval = 500;
			timerZoom.Enabled = true;
		}

		private void tbtnTop_MouseUp(object sender, MouseEventArgs e)
		{
			TopFlag = false;
			timerZoom.Enabled = false;
		}

		private void tbtnEnd_MouseDown(object sender, MouseEventArgs e)
		{
			ToolStripButton btn = (ToolStripButton)sender;

			if (btn.Name == "tbtnEndNext")
			{
				EndPuls = true;
			}
			else
			{
				EndPuls = false;
			}

			EndFlag = true;
			timerZoom.Interval = 500;
			timerZoom.Enabled = true;
		}

		private void tbtnEnd_MouseUp(object sender, MouseEventArgs e)
		{
			EndFlag = false;
			timerZoom.Enabled = false;
		}

		private void tbtnClear_Click(object sender, EventArgs e)
		{
            ViewCleared();

            //↓↓↓ KASHIYAMA Mode 20200214 Kimura update ↓↓↓
            ClearHoldLabelCtrlBackColor();
            //↑↑↑ KASHIYAMA Mode 20200214 Kimura update ↑↑↑
		}

		private void tbtnHold_Click(object sender, EventArgs e)
		{
			ToolStripButton btn = (ToolStripButton)sender;

			if (btn.BackColor == Color.Gold)
			{
				btn.BackColor = SystemColors.Control;
				IsViewHold = false;
			}
			else
			{
				btn.BackColor = Color.Gold;
				IsViewHold = true;
			}
		
			ViewHold(IsViewHold);
		}

		private void tbtnFill_Click(object sender, EventArgs e)
		{
			if (tbtnFill.Tag.ToString() == "MAX")
			{
				tbtnFill.Tag = "MIN";

				tbtnFill.Text = UserText.CtlPlotMenuMaximum;
				tbtnFill.BackColor = Color.Gold;
			}
			else
			{
				tbtnFill.Tag = "MAX";

				tbtnFill.Text = UserText.CtlPlotMenuMinimum;
				tbtnFill.BackColor = Color.Transparent;
			}

			ViewZoomed();
		}

		private void tbtnFixedBack_Click(object sender, EventArgs e)
		{
			if (tcmbFixed.SelectedIndex > 0)
			{
				tcmbFixed.SelectedIndex--;
			}
		}

		private void tbtnFixedNext_Click(object sender, EventArgs e)
		{
			if (tcmbFixed.SelectedIndex < tcmbFixed.Items.Count - 1)
			{
				tcmbFixed.SelectedIndex++;
			}
		}

		private void tcmbFixed_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!IsScaleFixed)
			{
				tbtnFixed.Checked = true;
			}
			else
			{
				//if (DisableCntrolStateChange) { return; }
				ScaleDivisionChanged();
			}
		}

		private void tbtnFixed_CheckedChanged(object sender, EventArgs e)
		{
			ScaleDivisionChanged();
		}

		private void tbtnFixedNext_MouseDown(object sender, MouseEventArgs e)
		{
			FixedFlag = true;
			FixedNext = true;
			timerZoom.Interval = 500;
			timerZoom.Enabled = true;
		}

		private void tbtnFixedNext_MouseUp(object sender, MouseEventArgs e)
		{
			FixedFlag = false;
			timerZoom.Enabled = false;
			//DisableCntrolStateChange = false;
		}

		private void tbtnFixedBack_MouseDown(object sender, MouseEventArgs e)
		{
			FixedFlag = true;
			FixedNext = false;
			timerZoom.Interval = 500;
			timerZoom.Enabled = true;
		}

		private void tbtnFixedBack_MouseUp(object sender, MouseEventArgs e)
		{
			FixedFlag = false;
			timerZoom.Enabled = false;
			//DisableCntrolStateChange = false;
		}

		private void ComboBox_DropDownClosed(object sender, EventArgs e)
		{
			lblDummy.Select();
		}

		private void Control_MouseHover(object sender, EventArgs e)
		{
			BodeGraphForm.ThisForm.Select();
		}

		private void Control_MouseEnter(object sender, EventArgs e)
		{
			BodeGraphForm.ThisForm.Select();
		}

		#region Measure Event

		private bool _MeasMode = new bool();
		private int MeasTextIndex = new int();
		private string[] MeasText;

		public bool MeasMode
		{
			get { return _MeasMode; }
		}

		public int MeasIndex
		{
			set
			{
				if (MeasText != null)
				{
					if (value < MeasText.Length)
					{
						MeasTextIndex = value;
					}
				}
			}

			get { return MeasTextIndex; }
		}

		private void tbtnMeasure_Click(object sender, EventArgs e)
		{
			if (tbtnMeasure.BackColor == Color.Gold)
			{
				tbtnMeasure.BackColor = SystemColors.Control;
				_MeasMode = false;

				tlblMeas.Enabled = false;
				tbtnMeasBack.Enabled = false;
				tbtnMeasNext.Enabled = false;
				tbtnMeasFast.Enabled = false;
				tbtnMeasPrev.Enabled = false; 
			}
			else
			{
				tbtnMeasure.BackColor = Color.Gold;
				_MeasMode = true;

				tlblMeas.Enabled = true;
				tbtnMeasBack.Enabled = true;
				tbtnMeasNext.Enabled = true;
				tbtnMeasFast.Enabled = true;
				tbtnMeasPrev.Enabled = true;
			}

			ControlStateChanged();
		}

		private void InitMeasItem()
		{
			int n = FFT_C.FFT_max / 2;

			MeasText = new string[n];

			double d = 1.0;

			for (int i = 0; i < n; i++)
			{
				MeasText[i] = d.ToString("F2") + " [Hz]";
				d += 1.0 * FFT_C.FFT_ConvertCoeff;
			}

			MeasTextIndex = 100;

			tlblMeas.Text = MeasText[MeasTextIndex];
		}

		private void tbtnMeasBack_Click(object sender, EventArgs e)
		{
			MeasBackEvent();
			ControlStateChanged();
		}

		private void tbtnMeasNext_Click(object sender, EventArgs e)
		{
			MeasNextEvent();
			ControlStateChanged();
		}

		private void tbtnMeasFast_Click(object sender, EventArgs e)
		{
			MeasFastEvent();
			ControlStateChanged();
		}

		private void tbtnMeasPrev_Click(object sender, EventArgs e)
		{
			MeasPrevEvent();
			ControlStateChanged();
		}

		private void MeasBackEvent()
		{
			if (MeasTextIndex > 0)
			{
				MeasTextIndex--;
				tlblMeas.Text = MeasText[MeasTextIndex];
			}
		}

		private void MeasNextEvent()
		{
			if (MeasTextIndex < MeasText.Length - 1)
			{
				MeasTextIndex++;
				tlblMeas.Text = MeasText[MeasTextIndex];
			}
		}

		private void MeasPrevEvent()
		{
			if (MeasTextIndex - 10 > 0)
			{
				MeasTextIndex -= 10;
				tlblMeas.Text = MeasText[MeasTextIndex];
			}
			else
			{
				MeasTextIndex = 0;
				tlblMeas.Text = MeasText[MeasTextIndex];
			}
		}

		private void MeasFastEvent()
		{
			if (MeasTextIndex - 10 < MeasText.Length - 1)
			{
				MeasTextIndex += 10;
				tlblMeas.Text = MeasText[MeasTextIndex];
			}
		}

		private bool MeasNext = new bool();
		private bool MeasBack = new bool();
		private bool MeasFast = new bool();
		private bool MeasPrev = new bool();
		private bool MeasFlag = new bool();

		private int MeasCnt = new int();

		private void tbtnMeas_MouseDown(object sender, MouseEventArgs e)
		{
			ToolStripButton btn = (ToolStripButton)sender;

			MeasNext = false;
			MeasBack = false;
			MeasFast = false;
			MeasPrev = false;

			if (btn.Tag.ToString() == "NEXT") { MeasNext = true; }
			if (btn.Tag.ToString() == "BACK") { MeasBack = true; }
			if (btn.Tag.ToString() == "FAST") { MeasFast = true; }
			if (btn.Tag.ToString() == "PREV") { MeasPrev = true; }
		
			MeasFlag = true;
			timerMeas.Interval = 500;
			timerMeas.Enabled = true;
		}

		private void tbtnMeas_MouseUp(object sender, MouseEventArgs e)
		{
			MeasCnt = 0;
			MeasFlag = false;
			timerMeas.Enabled = false;
		}

		private void timerMeas_Tick(object sender, EventArgs e)
		{
			if (MeasFlag)
			{
				if (timerMeas.Interval == 500)
				{
					timerMeas.Interval = 10;
				}

				if (MeasNext) { MeasNextEvent(); }
				if (MeasBack) { MeasBackEvent(); }
				if (MeasFast) { MeasFastEvent(); }
				if (MeasPrev) { MeasPrevEvent(); }
		
				if (++MeasCnt >= 10)
				{
					MeasCnt = 0;
					ControlStateChanged();
				}
			}

		}

		#endregion

        #region カルチャリソース切り替え

        public void ViewCultureResouceChanged()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CtlPlotMenu));

			tbtnHold.Font = (Font)resources.GetObject("tbtnHold.Font");
            tbtnClear.Font = (Font)resources.GetObject("tbtnClear.Font");
            tbtnZoomM.Font = (Font)resources.GetObject("tbtnZoomM.Font");
            tbtnZoomP.Font = (Font)resources.GetObject("tbtnZoomP.Font");
            tlblGainOffset.Font = (Font)resources.GetObject("tlblGainOffset.Font");
            tlblTime.Font = (Font)resources.GetObject("tlblTime.Font");
            toolStripLabelName.Font = (Font)resources.GetObject("toolStripLabelName.Font");

			tbtnHold.Text = resources.GetString("tbtnHold.Text");
			tbtnClear.Text = resources.GetString("tbtnClear.Text");
			tbtnZoomM.Text = resources.GetString("tbtnZoomM.Text");
            tbtnZoomP.Text = resources.GetString("tbtnZoomP.Text");
            tlblGainOffset.Text = resources.GetString("tlblGainOffset.Text");
            tlblTime.Text = resources.GetString("tlblTime.Text");
            toolStripLabelName.Text = resources.GetString("toolStripLabelName.Text");
        }

        #endregion

        #region KASHIYAMA Mode

        //↓↓↓ KASHIYAMA Mode 20200214 Kimura update ↓↓↓

        private void tbtnFFTHold_Click(object sender, EventArgs e)
        {   
            int count = Convert.ToInt32(tcmbHoldCount.Text) - 1;

            if (HoldCount >= count)
            {
                HoldCount = 0;
            }
            else
            {
                HoldCount++;
            }

            NextHoldLabelCtrlBackColor();

            //FFTｸﾞﾗﾌ表示ﾎｰﾙﾄﾞ
            KashiyamaModeViewHold();
        }

        private void ClearHoldLabelCtrlBackColor()
        {
            HoldCount = 0;
            NextHoldLabelCtrlBackColor();
        }

        private void NextHoldLabelCtrlBackColor()
        {
            for (int i = 0; i < HoldLabelCtrl.Length; i++)
            {
                if (i == HoldCount)
                {
                    HoldLabelCtrl[i].BackColor = Color.Gold;
                }
                else
                {
                    HoldLabelCtrl[i].BackColor = SystemColors.Control;
                }
            }
        }
        private void tcmbSampData_TextChanged(object sender, EventArgs e)
        {
            FFT_C.FFT_count = int.Parse(tcmbSampData.Text);

            ControlStateChanged();
        }

        private void tcmbSampFRQ_TextChanged(object sender, EventArgs e)
        {
            FFT_C.FRQ = int.Parse(tcmbSampFRQ.Text);
            ControlStateChanged();
        }

        private void tbtnFFTHold_MouseDown(object sender, MouseEventArgs e)
        {
            tbtnFFTHold.BackColor = Color.Gold;
        }

        private void tbtnFFTHold_MouseUp(object sender, MouseEventArgs e)
        {
            tbtnFFTHold.BackColor = SystemColors.Control;
        }

        private void tlblFFTHold_Click(object sender, EventArgs e)
        {
            ToolStripLabel lbl = (ToolStripLabel)sender;

            ChildFormControl.SetOpacity(0.0);

            DialogResult ret = ColorDialogBode.ShowDialog();

            ChildFormControl.SetOpacity(1.0);

            if (ret == DialogResult.OK)
            {
                int ch = Convert.ToInt32(lbl.Tag);

                FFTHoldLineColorCtrl[ch].BackColor = ColorDialogBode.Color;
                
                ControlStateChanged();
            }
        }

        private void tbtnFFTHoldBack_Click(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton)sender;
            ToolStripComboBox cmb = new ToolStripComboBox();

            if (btn.Name.Equals("tbtnBackSampData"))
            {
                cmb = tcmbSampData;
            }
            else if (btn.Name.Equals("tbtnBackSampFRQ"))
            {
                cmb = tcmbSampFRQ;
            }
            else if (btn.Name.Equals("tbtnFFTHoldBack"))
            {
                cmb = tcmbFFTHold;
            }
            else if (btn.Name.Equals("tbtnFFTHoldCountBack"))
            {
                cmb = tcmbHoldCount;
            }
            else return;
            
            CheckCmbIndexFFTHoldBack(cmb);
		}

        private void tbtnFFTHoldNext_Click(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton)sender;
            ToolStripComboBox cmb = new ToolStripComboBox();

            if (btn.Name.Equals("tbtnNextSampData"))
            {
                cmb = tcmbSampData;
            }
            else if (btn.Name.Equals("tbtnNextSampFRQ"))
            {
                cmb = tcmbSampFRQ;
            }
            else if (btn.Name.Equals("tbtnFFTHoldNext"))
            {
                cmb = tcmbFFTHold;
            }
            else if (btn.Name.Equals("tbtnFFTHoldCountNext"))
            {
                cmb = tcmbHoldCount;
            }
            else return;
            
            CheckCmbIndexFFTHoldNext(cmb);
        }

        private void CheckCmbIndexFFTHoldBack(ToolStripComboBox cmb)
        {
            if (cmb.SelectedIndex > 0)
            {
                cmb.SelectedIndex -= 1;
            }
            else
            {
                cmb.SelectedIndex = cmb.Items.Count - 1;
            }
        }

        private void CheckCmbIndexFFTHoldNext(ToolStripComboBox cmb)
        {
            if (cmb.SelectedIndex < cmb.Items.Count - 1)
            {
                cmb.SelectedIndex += 1;
            }
            else
            {
                cmb.SelectedIndex = 0;
            }
        }

        public Color GetFFTHoldLineColor(int ch)
        {
            return FFTHoldLineColorCtrl[ch].BackColor;
        }

        public float GetFFTHoldLineWidth()
        {
            return Convert.ToSingle(tcmbFFTHold.Text);
        }

        public float GetFFTHoldCount()
        {
            return Convert.ToInt32(tcmbHoldCount.Text);
        }

        private void tcmbHoldCount_TextChanged(object sender, EventArgs e)
        {
            int idx = Convert.ToInt32(tcmbHoldCount.Text);

            //線色設定有効
            for (int i = 0; i < idx; i++)
            {
                HoldLabelCtrl[i].Enabled = true;
                FFTHoldLineColorCtrl[i].Enabled = true;
            }

            //線色設定無効
            for (int i = idx; i < HoldLabelCtrl.Length; i++)
            {
                HoldLabelCtrl[i].Enabled = false;
                FFTHoldLineColorCtrl[i].Enabled = false;
            }

            for (int i = 0; i < HoldLabelCtrl.Length; i++)
            {
                HoldLabelCtrl[i].BackColor = SystemColors.Control;
            }

            ViewCleared();

            ClearHoldLabelCtrlBackColor();
        }

        //↑↑↑ KASHIYAMA Mode 20200214 Kimura update ↑↑↑

        #endregion
    }
}