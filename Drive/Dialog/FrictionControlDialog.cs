using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
	public partial class FrictionControlDialog : Form
	{
		public FrictionControlDialog()
		{
			InitializeComponent();
	
			this.DialogResult = DialogResult.Cancel;
		}

		private void FrictionControlForm_Load(object sender, EventArgs e)
		{
			ChildFormControl.SetOpacity(0.0);

			int cw_trq = CMonitor.GetParameter(CParamID.FrictionCwTrq);
			int ccw_trq = CMonitor.GetParameter(CParamID.FrictionCcwTrq);

			lblFrictionCwNow.Text = UserText.WizardFrictionCwNowValue + "  " + cw_trq.ToString() + " [0.01A] " + UserText.WizardIs;
			lblFrictionCcwNow.Text = UserText.WizardFrictionCcwNowValue + "  " + ccw_trq.ToString() + " [0.01A] " + UserText.WizardIs;
		}

		private void FrictionControlForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			ChildFormControl.SetOpacity(1.0);
		}

		private void btnFriction_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;

			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;

			this.Close();
		}

	}
}