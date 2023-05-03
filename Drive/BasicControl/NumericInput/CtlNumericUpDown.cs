using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
	public partial class CtlNumericUpDown20_70 : UserControl
	{
		public event dNumControlClickEvent NumTextClicked;
		public event dNumUpDownClickEvent NumUpDownClicked;

		public CtlNumericUpDown20_70()
		{
			InitializeComponent();

			txtNum.Visible = false;
		}

		public bool VisibleUpDownButton
		{
			set
			{
				btnUp.Visible = value;
				btnDown.Visible = value;
			}

			get
			{
				return btnUp.Visible;
			}
		}

		public Color NumForeColor
		{
			//set { txtNum.ForeColor = value; }
			//get { return txtNum.ForeColor; }
			set { lblNum.ForeColor = value; txtNum.ForeColor = value; }
			get { return lblNum.ForeColor; }
		}

		public Color NumBackColor
		{
			//set { txtNum.BackColor = value; }
			//get { return txtNum.BackColor; }
			set { lblNum.BackColor = value; txtNum.BackColor = value; }
			get { return lblNum.BackColor; }
		}

		public Font NumFont
		{
			//set { txtNum.Font = value; }
			//get { return txtNum.Font; }
			set { lblNum.Font = value; txtNum.Font = value; }
			get { return lblNum.Font; }
		}

		public int IntValue
		{
			//set { txtNum.Text = Convert.ToString(value); }
			//get { return Convert.ToInt32(txtNum.Text); }
			set { lblNum.Text = Convert.ToString(value); txtNum.Text = Convert.ToString(value); }
			get { return Convert.ToInt32(lblNum.Text); }
		}

		public double DoubleValue
		{
			//set { txtNum.Text = Convert.ToString(value); }
			//get { return Convert.ToDouble(txtNum.Text); }
			set { lblNum.Text = Convert.ToString(value); txtNum.Text = Convert.ToString(value); }
			get { return Convert.ToDouble(lblNum.Text); }
		}

		public string StringValue
		{
			//set { txtNum.Text = value; }
			//get { return txtNum.Text; }
			set { lblNum.Text = value; txtNum.Text = value; }
			get { return lblNum.Text; }
		}
		
		private void btnUp_Click(object sender, EventArgs e)
		{
			//int num = new int();

			//try
			//{
			//    num = Convert.ToInt32(txtNum.Text);
			//}
			//catch
			//{
			//    //NumUpDownClicked();
			//    return;
			//}

			//if (num >= 9)
			//{
			//    num = 0;
			//}
			//else
			//{
			//    num++;
			//}

			//txtNum.Text = num.ToString();
			//lblNum.Text = num.ToString();

			//NumUpDownClicked();
		}

		private void btnDown_Click(object sender, EventArgs e)
		{
			//int num = new int();

			//try
			//{
			//    num = Convert.ToInt32(txtNum.Text);
			//}
			//catch
			//{
			//    //NumUpDownClicked();
			//    return;
			//}

			//if (num <= 0)
			//{
			//    num = 9;
			//}
			//else
			//{
			//    num--;
			//}

			//txtNum.Text = num.ToString();
			//lblNum.Text = num.ToString();

			//NumUpDownClicked();
		}

		private void btnUp_MouseClick(object sender, MouseEventArgs e)
		{
			int num = new int();

			try
			{
				num = Convert.ToInt32(txtNum.Text);
			}
			catch
			{
				//NumUpDownClicked();
				return;
			}

			if (num >= 9)
			{
				num = 0;
			}
			else
			{
				num++;
			}

			txtNum.Text = num.ToString();
			lblNum.Text = num.ToString();

			NumUpDownClicked();
		}

		private void btnDown_MouseClick(object sender, MouseEventArgs e)
		{
			int num = new int();

			try
			{
				num = Convert.ToInt32(txtNum.Text);
			}
			catch
			{
				//NumUpDownClicked();
				return;
			}

			if (num <= 0)
			{
				num = 9;
			}
			else
			{
				num--;
			}

			txtNum.Text = num.ToString();
			lblNum.Text = num.ToString();

			NumUpDownClicked();
		}

		private void txtNum_Click(object sender, EventArgs e)
		{
			NumTextClicked();
		}

		private void txtNum_KeyDown(object sender, KeyEventArgs e)
		{
			e.Handled = true;
		}

	}
}
