using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
	public partial class CtlSignedUpDown20_70 : UserControl
	{
		public event dNumControlClickEvent NumTextClicked;
		public event dNumUpDownClickEvent NumUpDownClicked;

		public CtlSignedUpDown20_70()
		{
			InitializeComponent();

			txtNum.Visible = false;
		}

		public Color NumForeColor
		{
			//set { txtNum.ForeColor = value; }
			//get { return txtNum.ForeColor; }
			set { lblNum.ForeColor = value; txtNum.ForeColor = value; }
			get { return lblNum.ForeColor; }
		}

		public Font NumFont
		{
			//set { txtNum.Font = value; }
			//get { return txtNum.Font; }
			set { lblNum.Font = value; txtNum.Font = value; }
			get { return lblNum.Font; }
		}

		public Color NumBackColor
		{
			//set { txtNum.BackColor = value; }
			//get { return txtNum.BackColor; }
			set { lblNum.BackColor = value; txtNum.BackColor = value; }
			get { return lblNum.BackColor; }
		}

		public string SignedValue
		{
			//set { txtNum.Text = value; }
			//get { return txtNum.Text; }
			set { lblNum.Text = value; txtNum.Text = value; }
			get { return lblNum.Text; }
		}

		private void btnUp_Click(object sender, EventArgs e)
		{
			txtNum.Text = "+";
			lblNum.Text = "+";
			NumUpDownClicked();
		}

		private void btnDown_Click(object sender, EventArgs e)
		{
			txtNum.Text = "-";
			lblNum.Text = "-";
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
