using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
	public delegate void dNumInputExValueCheange(CtlNumericInputEx ctl);

	public partial class CtlNumericInputEx : UserControl
	{
		public event dNumInputExValueCheange NumInputExValueCheange;

		private Color EditColor = Color.Red;
		private Color ActiveColor = Color.DarkRed;

		private Color _ActiveBackColor = Color.Gold;

		private Color BackupNumForeColor = new Color();
		private decimal BackupNumValue = new decimal();

		private bool DisableValueChanged = new bool();
		private bool DisableCheckStateChanged = new bool();

		private int _DataId = new int();

		private bool _UnitVisible = new bool();
		private bool _TitleVisible = new bool();
		private bool _x10Visible = new bool();
		private bool _x100Visible = new bool();

		public CtlNumericInputEx()
		{
			InitializeComponent();

			BackupNumForeColor = numInput.ForeColor;
			NowNumForeColor = numInput.ForeColor;
		}

		public Color ActiveBackColor
		{
			set { _ActiveBackColor = value; }
			get { return _ActiveBackColor; }
		}

		public int DataId
		{
			set { _DataId = value; }
			get { return _DataId; }
		}

		public decimal NumValue
		{
			set
			{
				if (!DisableValueChanged)
				{
					numInput.Value = value;
				}
			}

			get { return numInput.Value; }
		}

		public int IntValue
		{
			set
			{
				if (!DisableValueChanged)
				{
					if (value > numInput.Maximum)
					{
						numInput.Visible = false;
						lblLimit.Visible = true;
						lblLimit.Text = "Max Limit";
					}
					else if (value < numInput.Minimum)
					{
						numInput.Visible = false;
						lblLimit.Visible = true;
						lblLimit.Text = "Min Limit";
					}
					else
					{
						numInput.Visible = true;
						lblLimit.Visible = false;
						numInput.Value = (decimal)value;
					}
				}
			}

			get { return (int)numInput.Value; }
		}

		public decimal NumMaximum
		{
			set { numInput.Maximum = value; }
			get { return numInput.Maximum; }
		}

		public decimal NumMinimum
		{
			set { numInput.Minimum = value; }
			get { return numInput.Minimum; }
		}

		public bool TitleVisible
		{
			set { lblTitle.Visible = value; _TitleVisible = value; }
			get { return _TitleVisible; }
		}

		public int TitleHeight
		{
			set { lblTitle.Height = value; }
			get { return lblTitle.Height; }
		}

        [Localizable(true)]
		public string TitleText
		{
			set { lblTitle.Text = value; }
			get { return lblTitle.Text; }
		}

        [Localizable(true)]
		public Font TitleFont
		{
			set { lblTitle.Font = value; }
			get { return lblTitle.Font; }
		}

		public Color TitleForeColor
		{
			set { lblTitle.ForeColor = value; }
			get { return lblTitle.ForeColor; }
		}

		public Color TitleBackColor
		{
			set { lblTitle.BackColor = value; }
			get { return lblTitle.BackColor; }
		}

		public ContentAlignment TitleAlign
		{
			set { lblTitle.TextAlign = value; }
			get { return lblTitle.TextAlign; }
		}

		public bool UnitVisible
		{
			set { lblUnit.Visible = value; _UnitVisible = value; }
			get { return _UnitVisible; }
		}

		public int UnitHeight
		{
			set { lblUnit.Height = value; }
			get { return lblUnit.Height; }
		}

        [Localizable(true)]
		public string UnitText
		{
			set { lblUnit.Text = value; }
			get { return lblUnit.Text; }
		}

        [Localizable(true)]
		public Font UnitFont
		{
			set { lblUnit.Font = value; }
			get { return lblUnit.Font; }
		}

		public Color UnitForeColor
		{
			set { lblUnit.ForeColor = value; }
			get { return lblUnit.ForeColor; }
		}

		public Color UnitBackColor
		{
			set { lblUnit.BackColor = value; }
			get { return lblUnit.BackColor; }
		}

		public ContentAlignment UnitAlign
		{
			set { lblUnit.TextAlign = value; }
			get { return lblUnit.TextAlign; }
		}

		public Font NunmFont
		{
			set { numInput.Font = value; }
			get { return numInput.Font; }
		}

		public Color NumForeColor
		{
			set { numInput.ForeColor = value; }
			get { return numInput.ForeColor; }
		}

		public Color NumBackColor
		{
			set { numInput.BackColor = value; }
			get { return numInput.BackColor; }
		}

		public Color NumEditColor
		{
			set { EditColor = value; }
			get { return EditColor; }
		}

		public Color NumActiveColor
		{
			set { ActiveColor = value; }
			get { return ActiveColor; }
		}

		public bool x10Visible
		{
			set { chkX10.Visible = value; _x10Visible = value; }
			get { return _x10Visible; }
		}

		public bool x100Visible
		{
			set { chkX100.Visible = value; _x100Visible = value; }
			get { return _x100Visible; }
		}

		public Font x10Font
		{
			set { chkX10.Font = value; }
			get { return chkX10.Font; }
		}

		public Font x100Font
		{
			set { chkX100.Font = value; }
			get { return chkX100.Font; }
		}

		private void chkX10_CheckStateChanged(object sender, EventArgs e)
		{
			if (DisableCheckStateChanged) { return; }

			DisableCheckStateChanged = true;
 
			if (chkX10.Checked)
			{
				chkX10.Font = AppFont.MeiryoBold7;
				chkX100.Font = AppFont.MeiryoRegular7;

				chkX100.Checked = false;
				numInput.Increment = 10;
			}
			else
			{
				chkX10.Font = AppFont.MeiryoRegular7;
				chkX100.Font = AppFont.MeiryoRegular7;

				chkX100.Checked = false;
				numInput.Increment = 1;
			}
		
			DisableCheckStateChanged = false;

			numInput.Select();
	
		}

		private void chkX100_CheckStateChanged(object sender, EventArgs e)
		{
			if (DisableCheckStateChanged) { return; }

			DisableCheckStateChanged = true;

			if (chkX100.Checked)
			{
				chkX10.Font = AppFont.MeiryoRegular7;
				chkX100.Font = AppFont.MeiryoBold7;

				chkX10.Checked = false;
				numInput.Increment = 100;
			}
			else
			{
				chkX10.Font = AppFont.MeiryoRegular7;
				chkX100.Font = AppFont.MeiryoRegular7;
				
				chkX10.Checked = false;
				numInput.Increment = 1;
			}

			DisableCheckStateChanged = false;

			numInput.Select();
	
		}

		private void numInput_ValueChanged(object sender, EventArgs e)
		{
			bNumInputValueChange(true);
		}

		private void bNumInputValueChange(bool tick)
		{
			if (DisableValueChanged) { return; }

			if (BackupNumValue != (int)numInput.Value)
			{
				BackupNumValue = NumValue;
				NumForeColor = EditColor;

				if (NumInputExValueCheange != null)
				{
					NumInputExValueCheange(this);

					TimerEscape.Interval = 2000;
					TimerEscape.Enabled = true;
				}
			}
			else
			{
				NumForeColor = NowNumForeColor;
			}
		}

		private void numInput_KeyDown(object sender, KeyEventArgs e)
		{

			if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back ||
				(e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9))
			{
				NumForeColor = EditColor;
				DisableValueChanged = true;
			}

			if (e.KeyCode == Keys.Enter)
			{
				DisableValueChanged = false;
				bNumInputValueChange(false);
				NumForeColor = NowNumForeColor;
		
			}

			if (e.KeyCode == Keys.Escape)
			{
				pnlScale.Select();
			}
		}

		private void numInput_Enter(object sender, EventArgs e)
		{
			BackupNumValue = NumValue;
			SetActiveCaption();
		}

		private void TimerEscape_Tick(object sender, EventArgs e)
		{
			NumForeColor = NowNumForeColor;
			TimerEscape.Enabled = false;

		}

		private void numInput_Leave(object sender, EventArgs e)
		{
			if (BackupNumValue != (int)numInput.Value)
			{
				string name = TitleText;
				string value = NumValue.ToString();

				DialogResult ret = UserMessageBox.CtlNumericInputExUpdataGainValue(name, value);

				if (ret == DialogResult.Yes)
				{
					DisableValueChanged = false;
					bNumInputValueChange(false);
				}
				else
				{
					numInput.Value = BackupNumValue;
				}
			}
			else
			{
			}

			DisableValueChanged = false;
			SetNormalCaption();
		}

		private Color BackupTitleForeColor;
		private Color BackupUnitForeColor;

		private Color NowNumForeColor;

		private void SetActiveCaption()
		{
			Font now, act;

			BackupTitleForeColor = TitleForeColor;
			BackupUnitForeColor = UnitForeColor;

			now = TitleFont;
			act = new Font(now.FontFamily, now.Size, FontStyle.Bold);

			TitleFont = act;

			now = UnitFont;
			act = new Font(now.FontFamily, now.Size, FontStyle.Bold);

			UnitFont = act;
	
			this.BackColor = ActiveBackColor;
			lblTitle.BackColor = ActiveBackColor;
			lblUnit.BackColor = ActiveBackColor;

			pnlInput.BorderStyle = BorderStyle.FixedSingle;
		}

		private void SetNormalCaption()
		{
			Font now, act;

			now = TitleFont;
			act = new Font(now.FontFamily, now.Size, FontStyle.Regular);

			TitleFont = act;
	
			now = UnitFont;
			act = new Font(now.FontFamily, now.Size, FontStyle.Regular);

			UnitFont = act;
			
			this.BackColor = SystemColors.Control;
			lblTitle.BackColor = SystemColors.Control;
			lblUnit.BackColor = SystemColors.Control;

			pnlInput.BorderStyle = BorderStyle.None;
		}

	}
}
