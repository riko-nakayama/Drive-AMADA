using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
	public partial class FrequencySweepDialog : Form
	{
		static public int SweepVelocity = 100;
		static public int SweepMinFrq = 5;
		static public int SweepMaxFrq = 20;

		public FrequencySweepDialog()
		{
			InitializeComponent();

			ctlNumFrqSweepVelocity.NumInputValueChanged += new dNumInputValueCheange(ctlNum_NumInputValueChanged);
			ctlNumFrqSweepMinFrq.NumInputValueChanged += new dNumInputValueCheange(ctlNum_NumInputValueChanged);
			ctlNumFrqSweepMaxFrq.NumInputValueChanged += new dNumInputValueCheange(ctlNum_NumInputValueChanged);
		
			this.DialogResult = DialogResult.Cancel;
		}

		void ctlNum_NumInputValueChanged()
		{

		}

		private void FreqencySweepForm_Load(object sender, EventArgs e)
		{
			ChildFormControl.SetOpacity(0.0);

			ctlNumFrqSweepVelocity.IntValue = SweepVelocity;
			ctlNumFrqSweepMinFrq.IntValue = SweepMinFrq;
			ctlNumFrqSweepMaxFrq.IntValue = SweepMaxFrq;
		}

		private void FreqencySweepForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			SweepVelocity = ctlNumFrqSweepVelocity.IntValue;
			SweepMinFrq = ctlNumFrqSweepMinFrq.IntValue;
			SweepMaxFrq = ctlNumFrqSweepMaxFrq.IntValue;

			ChildFormControl.SetOpacity(1.0);
		}

		private void btnOk_Click(object sender, EventArgs e)
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