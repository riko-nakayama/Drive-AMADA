using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
	public partial class AutoTuningSaveDialog : Form
	{
		static public bool SaveMemory = new bool();
		static public bool SaveFile = new bool();

		private bool SaveOk = new bool();

		public AutoTuningSaveDialog()
		{
			InitializeComponent();
		}

		private void AutoTuningSaveForm_Load(object sender, EventArgs e)
		{
			ChildFormControl.SetOpacity(0.0);

			SaveMemory = false;
			SaveFile = false;
		}

		private void AutoTuningSaveForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!SaveOk)
			{
				DialogResult ret = UserMessageBox.AutoTuningSaveCancel();

				if (ret == DialogResult.No)
				{
					e.Cancel = true;
				}
				else
				{
					SaveMemory = false;
					SaveFile = false;
				}
			}
		}

		private void AutoTuningSaveDialog_FormClosed(object sender, FormClosedEventArgs e)
		{
			ChildFormControl.SetOpacity(1.0);
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			SaveMemory = chkSaveMemory.Checked;
			SaveFile = chkSevaFile.Checked;

			SaveOk = true;

			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			SaveMemory = false;
			SaveFile = false;

			SaveOk = true;

			this.Close();
		}

	}
}