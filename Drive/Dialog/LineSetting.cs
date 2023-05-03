using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
	public partial class LineSetting : UserControl
	{
		private LineStyleDialog LineDlg = new LineStyleDialog();

		public LineSetting()
		{
			InitializeComponent();
		}

		public string Title
		{
			set { grpLineSetting.Text = value; }
			get { return grpLineSetting.Text; }
		}

		public bool EnableLine
		{
			set { chkLineSetting.Checked = value; }
			get { return chkLineSetting.Checked; }
		}

		public Color LineColor
		{
			set { btnColorSetting.BackColor = value; }
			get { return btnColorSetting.BackColor; }
		}

		private void btnNext_Click(object sender, EventArgs e)
		{

		}

	}
}
