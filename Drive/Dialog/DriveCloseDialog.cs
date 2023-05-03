using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
	public partial class DriveCloseDialog : Form
	{
		public DriveCloseDialog()
		{
			InitializeComponent();

			this.DialogResult = DialogResult.Cancel;
		}

		private void DriveCloseForm_Load(object sender, EventArgs e)
		{
			btnOk.Select();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void chkCloseMsg_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.CLOSE_MSG_DISABLE = chkCloseMsg.Checked;
		}

	
	}
}