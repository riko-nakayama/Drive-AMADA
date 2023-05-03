using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
	//NumInput Control Event
	public delegate void dNumControlClickEvent();
	public delegate void dNumUpDownClickEvent();

	public delegate void dNumInputValueCheange();

	public partial class CtlNumericInputInt : UserControl
	{
		public event dNumInputValueCheange NumInputValueChanged;

		private const int MAX_NUM = 10;

		private int _PlaceNumber = new int();

		private string BackupText =string.Empty;

		private CtlNumericUpDown20_70[] ctlNum = new CtlNumericUpDown20_70[MAX_NUM];

		private bool _UnitVisible = new bool();
		private bool _TitleVisible = new bool();
		private bool _SignedVisible = new bool();
		private bool _SignedEnable = new bool();

		private bool _DigiSwVisible = new bool();

		private Color _NumForeColor = Color.Black;
		private Color _NumBackColor = Color.White;
		private Font _NumFont = AppFont.MeiryoBold12;

		private int _MaxData = 10000;
		private int _MinData = -10000;

		private int _DataId = new int();

		private bool IsMaxOverflow = new bool();
		private bool IsMinOverflow = new bool();

		private int OverflowData = new int();

		public CtlNumericInputInt()
		{
			InitializeComponent();

			ctlNum[0] = num1;
			ctlNum[1] = num2;
			ctlNum[2] = num3;
			ctlNum[3] = num4;
			ctlNum[4] = num5;
			ctlNum[5] = num6;
			ctlNum[6] = num7;
			ctlNum[7] = num8;
			ctlNum[8] = num9;
			ctlNum[9] = num10;

			for (int i = 0; i < MAX_NUM; i++)
			{
				ctlNum[i].NumTextClicked += new dNumControlClickEvent(CtlNumericInputInt_NumTextClicked);
				ctlNum[i].NumUpDownClicked += new dNumUpDownClickEvent(CtlNumericInputInt_NumValueChanged);
			}

			numSigned.NumTextClicked += new dNumControlClickEvent(CtlNumericInputInt_NumTextClicked);
			numSigned.NumUpDownClicked += new dNumUpDownClickEvent(CtlNumericInputInt_NumValueChanged);

			BackupText = StringValue;	
		}

		public Color NumForeColor
		{
			set
			{
				for (int i = 0; i < ctlNum.Length; i++)
				{
					ctlNum[i].NumForeColor = value;
				}

				numSigned.NumForeColor = value;

				txtNum.ForeColor = value;

				_NumForeColor = value;
			}

			get
			{
				return _NumForeColor;
			}

		}

		public Color NumBackColor
		{
			set
			{
				for (int i = 0; i < ctlNum.Length; i++)
				{
					ctlNum[i].NumBackColor = value;
				}

				numSigned.NumBackColor = value;

				txtNum.BackColor = value;

				_NumBackColor = value;
			}

			get
			{
				return _NumBackColor;
			}

		}

		public Font NumFont
		{
			set
			{
				for (int i = 0; i < ctlNum.Length; i++)
				{
					ctlNum[i].NumFont = value;
				}

				numSigned.NumFont = value;

				//txtNum.Font = value;

				_NumFont = value;
			}

			get
			{
				return _NumFont;
			}

		}

		public int PlaceNumber
		{
			set
			{
				if (value <= 0 || value > MAX_NUM) { return; }

				VisibleAllNum(false);
				
				for (int i = 0; i < value; i++)
				{
					ctlNum[i].Visible = true;
				}

				int off = new int();

				if (SignedVisible)
				{
					off = 20;
				}

				fpnlNum.Width = value * 20 + off;
				txtNum.Width = value * 20 + off;
				this.Width = value * 20 + off;

				_PlaceNumber = value;

			}

			get { return _PlaceNumber; }
		}

		public int IntValue
		{
			get
			{
				if (IsMaxOverflow) { return OverflowData; }
				if (IsMinOverflow) { return OverflowData; }

				int d10 = num10.IntValue * 1000000000;
				int d9 = num9.IntValue * 100000000;
				int d8 = num8.IntValue * 10000000;
				int d7 = num7.IntValue * 1000000;
				int d6 = num6.IntValue * 100000;
				int d5 = num5.IntValue * 10000;
				int d4 = num4.IntValue * 1000;
				int d3 = num3.IntValue * 100;
				int d2 = num2.IntValue * 10;
				int d1 = num1.IntValue * 1;

				if (numSigned.SignedValue == "-" && SingedEnable)
				{
					return -(d10 + d9 + d8 + d7 + d6 + d5 + d4 + d3 + d2 + d1);
				}
				else
				{
					return d10 + d9 + d8 + d7 + d6 + d5 + d4 + d3 + d2 + d1;
				}
			}

			set
			{
				try
				{
					int val = (int)value;

					if (!CheckTheValue(val)) { return; }

					IsMaxOverflow = false;
					IsMinOverflow = false;

					if (val < 0 && SingedEnable)
					{
						numSigned.SignedValue = "-";
					}
					else
					{
						numSigned.SignedValue = "+";
					}

					val = Math.Abs(val);

					int val10 = (int)((long)val % 10000000000 / 1000000000);
					int val9 = val % 1000000000 / 100000000;
					int val8 = val % 100000000 / 10000000;
					int val7 = val % 10000000 / 1000000;
					int val6 = val % 1000000 / 100000;
					int val5 = val % 100000 / 10000;
					int val4 = val % 10000 / 1000;
					int val3 = val % 1000 / 100;
					int val2 = val % 100 / 10;
					int val1 = val % 10 / 1;

					num10.IntValue = val10;
					num9.IntValue = val9;
					num8.IntValue = val8;
					num7.IntValue = val7;
					num6.IntValue = val6;
					num5.IntValue = val5;
					num4.IntValue = val4;
					num3.IntValue = val3;
					num2.IntValue = val2;
					num1.IntValue = val1;
				}
				catch (Exception ex)
				{
					UserMessageBox.CommonCatchErrorMessage(ex);
				}
			}
		}

		public string StringValue
		{
			get
			{
				if (IsMaxOverflow) { return OverflowData.ToString(); }
				if (IsMinOverflow) { return OverflowData.ToString(); }

				int d10 = num10.IntValue * 1000000000;
				int d9 = num9.IntValue * 100000000;
				int d8 = num8.IntValue * 10000000;
				int d7 = num7.IntValue * 1000000;
				int d6 = num6.IntValue * 100000;
				int d5 = num5.IntValue * 10000;
				int d4 = num4.IntValue * 1000;
				int d3 = num3.IntValue * 100;
				int d2 = num2.IntValue * 10;
				int d1 = num1.IntValue * 1;

				string sig = "+";

				if (numSigned.SignedValue == "-" && SingedEnable)
				{
					sig = "-";
				}

				return sig + Convert.ToString(d10 + d9 + d8 + d7 + d6 + d5 + d4 + d3 + d2 + d1);
			}

			set
			{
				try
				{
					string sig = value.Trim().Substring(0, 1);

					if (sig == "+" || sig == "-")
					{
						value = value.Trim().Substring(1);

						if (SingedEnable)
						{
							numSigned.SignedValue = sig;
						}
						else
						{
							numSigned.SignedValue = "+";
						}
					}

					double d = Convert.ToDouble(value);

					if (d >= 2147483647.0) { d = 1.0 / 0; }	//強制例外

					int val = (int)(d);

					if (!CheckTheValue(val)) { return; }

					IsMaxOverflow = false;
					IsMinOverflow = false;

					int val10 = (int)((long)val % 10000000000 / 1000000000);
					int val9 = val % 1000000000 / 100000000;
					int val8 = val % 100000000 / 10000000;
					int val7 = val % 10000000 / 1000000;
					int val6 = val % 1000000 / 100000;
					int val5 = val % 100000 / 10000;
					int val4 = val % 10000 / 1000;
					int val3 = val % 1000 / 100;
					int val2 = val % 100 / 10;
					int val1 = val % 10 / 1;

					num10.IntValue = val10;
					num9.IntValue = val9;
					num8.IntValue = val8;
					num7.IntValue = val7;
					num6.IntValue = val6;
					num5.IntValue = val5;
					num4.IntValue = val4;
					num3.IntValue = val3;
					num2.IntValue = val2;
					num1.IntValue = val1;
				}
				catch (Exception ex)
				{
					UserMessageBox.CommonCatchErrorMessage(ex);
				}
			}
		}

		public int MaxData
		{
			set { _MaxData = value; }
			get { return _MaxData; }
		}

		public int MinData
		{
			set { _MinData = value; }
			get { return _MinData; }
		}

		public int DataId
		{
			set { _DataId = value; }
			get { return _DataId; }
		}

		public bool SingedEnable
		{
			set { numSigned.Enabled = value; _SignedEnable = value; }
			get { return _SignedEnable; }
		}

		public bool SignedVisible
		{
			set 
			{
				numSigned.Visible = value;
				_SignedVisible = value;

				PlaceNumber = _PlaceNumber;
			}
			
			get { return _SignedVisible; }
		}

		public bool UnitVisible
		{
			set { txtUnit.Visible = value; _UnitVisible = value; }
			get { return _UnitVisible; }
		}

        [Localizable(true)]
		public string UnitText
		{
			set { txtUnit.Text = value; }
			get { return txtUnit.Text; }
		}

		public DockStyle UnitDock
		{
			set { txtUnit.Dock = value; }
			get { return txtUnit.Dock; }
		}

		public ContentAlignment UnitAlign
		{
			set { txtUnit.TextAlign = value; }
			get { return txtUnit.TextAlign; }
		}

		public int UnitHeight
		{
			set { txtUnit.Height = value; }
			get { return txtUnit.Height; }
		}

		public Font UnitFont
		{
			set { txtUnit.Font = value; }
			get { return txtUnit.Font; }
		}

		public Color UnitForeColor
		{
			set { txtUnit.ForeColor = value; }
			get { return txtUnit.ForeColor; }
		}

		public Color UnitBackColor
		{
			set { txtUnit.BackColor = value; }
			get { return txtUnit.BackColor; }
		}

		public bool TitleVisible
		{
			set { txtTitle.Visible = value; _TitleVisible = value; }
			get { return _TitleVisible; }
		}

        [Localizable(true)]
		public string TitleText
		{
			set { txtTitle.Text = value; }
			get { return txtTitle.Text; }
		}

		public DockStyle TitleDock
		{
			set { txtTitle.Dock = value; }
			get { return txtTitle.Dock; }
		}

		public ContentAlignment TitleAlign
		{
			set { txtTitle.TextAlign = value; }
			get { return txtTitle.TextAlign; }
		}

		public int TitleHeight
		{
			set { txtTitle.Height = value; }
			get { return txtTitle.Height; }
		}

        [Localizable(true)]
		public Font TitleFont
		{
			set { txtTitle.Font = value; }
			get { return txtTitle.Font; }
		}

		public Color TitleForeColor
		{
			set { txtTitle.ForeColor = value; }
			get { return txtTitle.ForeColor; }
		}

		public Color TitleBackColor
		{
			set { txtTitle.BackColor = value; }
			get { return txtTitle.BackColor; }
		}

		public bool DigiSwVisible
		{
			set
			{
				for (int i = 0; i < ctlNum.Length; i++)
				{
					ctlNum[i].VisibleUpDownButton = value;
				}

				_DigiSwVisible = value;
			}

			get
			{
				return _DigiSwVisible;
			}
		}

		private void VisibleAllNum(bool visible)
		{
			for (int i = 0; i < MAX_NUM; i++)
			{
				ctlNum[i].Visible = visible;
			}
		}

		private void CtlNumericInputInt_NumTextClicked()
		{
			int off = new int();

			if (SignedVisible)
			{
				off = 20;
			}

			fpnlNum.Width = PlaceNumber * 20 + off;
			txtNum.Width = PlaceNumber * 20 + off;

			txtNum.Text = StringValue;
			txtNum.Visible = true;

			int y = 18;

			if (TitleVisible)
			{
				y += txtTitle.Height;
			}

			txtNum.Location = new Point(0, y);

			BackupText = StringValue;

			txtNum.Focus();

		}

		private void CtlNumericInputInt_NumValueChanged()
		{
			int val = IntValue;

			if (!CheckTheValue(val))
			{
				//CtlNumericInputInt_NumTextClicked();
				return;
			}

			NumInputValueChanged();
		}

		private void txtNum_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Space)
			{
				txtNum_Leave(null, null);
			}

			if (e.KeyCode == Keys.Escape)
			{
				txtNum.Text = "error";
				txtNum_Leave(null, null);
			}
		}

		private void txtNum_Leave(object sender, EventArgs e)
		{
			try
			{
				string num_txt = txtNum.Text.Trim();
				string sig = num_txt.Substring(0, 1);

				if( sig == "+" || sig == "-" )
				{
					num_txt = num_txt.Substring(1);
				}

				int num = Convert.ToInt32(num_txt);

				int max = new int();

				switch (PlaceNumber)
				{
					case 1:
						max = 9;
						break;
					case 2:
						max = 99;
						break;
					case 3:
						max = 999;
						break;
					case 4:
						max = 9999;
						break;
					case 5:
						max = 99999;
						break;
					case 6:
						max = 999999;
						break;
					case 7:
						max = 9999999;
						break;
					case 8:
						max = 99999999;
						break;
					case 9:
						max = 999999999;
						break;
					case 10:
						max = 2147483647;
						break;
					default:
						max = -1;
						break;
				}

				if (num >= 0 && num <= max)
				{
					if (sig == "-" && SingedEnable)
					{
						IntValue = -num;
					}
					else
					{
						IntValue = num;
					}
				}
				else
				{
					StringValue = BackupText;
				}
			}
			catch
			{
				StringValue = BackupText;
			}

			txtNum.Visible = false;

			NumInputValueChanged();
		}

		private bool CheckTheValue(int val)
		{

			if (val > MaxData)
			{
				num10.StringValue = "+";
				num9.StringValue = "+";
				num8.StringValue = "+";
				num7.StringValue = "+";
				num6.StringValue = "+";
				num5.StringValue = "+";
				num4.StringValue = "+";
				num3.StringValue = "+";
				num2.StringValue = "+";
				num1.StringValue = "+";

				IsMaxOverflow = true;
				OverflowData = val;
				return false;
			}

			if (val < MinData)
			{
				num10.StringValue = "-";
				num9.StringValue = "-";
				num8.StringValue = "-";
				num7.StringValue = "-";
				num6.StringValue = "-";
				num5.StringValue = "-";
				num4.StringValue = "-";
				num3.StringValue = "-";
				num2.StringValue = "-";
				num1.StringValue = "-";

				IsMinOverflow = true;
				OverflowData = val;
				return false;
			}

			return true;
		}


	}
}
