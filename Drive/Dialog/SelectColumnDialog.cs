using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
	public partial class SelectColumnDialog : Form
	{
		public SelectColumnDialog()
		{
			InitializeComponent();
		}

		private void SelectColumnForm_Load(object sender, EventArgs e)
		{
			ChildFormControl.SetOpacity(0.0);
		}

		private void SelectColumnForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			ChildFormControl.SetOpacity(1.0);
		}
	}
}