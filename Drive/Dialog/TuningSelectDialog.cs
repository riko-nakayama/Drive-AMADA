using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
	public partial class TuningSelectDialog : Form
	{
		public enum TuningType{ None, Load, Adjust, Sweep, Friction }

		static public TuningType TuningRequest = TuningType.None;

		public TuningSelectDialog()
		{
			InitializeComponent();
		}

		private void TuningControlForm_Load(object sender, EventArgs e)
		{
			ChildFormControl.SetOpacity(0.0);

			TuningRequest = TuningType.None;
		}

		private void TuningControlForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			ChildFormControl.SetOpacity(1.0);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void btnLoad_Click(object sender, EventArgs e)
		{
			TuningRequest = TuningType.Load;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btnAdjust_Click(object sender, EventArgs e)
		{
			TuningRequest = TuningType.Adjust;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btnSweep_Click(object sender, EventArgs e)
		{
			TuningRequest = TuningType.Sweep;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btnFriction_Click(object sender, EventArgs e)
		{
			TuningRequest = TuningType.Friction;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

	}
}