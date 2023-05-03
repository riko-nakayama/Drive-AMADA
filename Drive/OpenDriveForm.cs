using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
	public partial class OpenDriveForm : Form
	{
		static public AppLayout SelectLayout;

		static public bool IsCollapseLayout;

		public OpenDriveForm()
		{
			InitializeComponent();
			chkCollapse.Checked = Properties.Settings.Default.CollapseLayout;
		}

		private int tick_count = new int();

		private void TimerOpenDrive_Tick(object sender, EventArgs e)
		{
			tick_count++;

			if (lblProject.Visible)
			{
				if (tick_count >= 4) { tick_count = 0; lblProject.Visible = false; }
			}
			else
			{
				if (tick_count >= 1) { tick_count = 0; lblProject.Visible = true; }
			}
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
	
			SelectLayout = AppLayout.Free;
			IsCollapseLayout = false;
		
			if (rdoJog.Checked) { SelectLayout = AppLayout.Jog; }
			if (rdoParameter.Checked) { SelectLayout = AppLayout.Parameter; }
			if (rdoAutoTuning.Checked) { SelectLayout = AppLayout.AutoTuning; }
			if( rdoManualTuning.Checked) { SelectLayout = AppLayout.ManualTuning;}

			if( chkCollapse.Checked ){ IsCollapseLayout = true;}

			if (chkStartView.Checked)
			{
				Properties.Settings.Default.ViewOpenDrive = false;
			}
			else
			{
				Properties.Settings.Default.ViewOpenDrive = true;
			}

			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{

			SelectLayout = AppLayout.Free;
			IsCollapseLayout = false;

			MainForm.ThisForm.CancelLayout();

			this.Close();
		}

		private void chkCollapse_CheckedChanged(object sender, EventArgs e)
		{
			MainForm.ThisForm.IsCollapseLayout = chkCollapse.Checked;
			MainForm.ThisForm.CollapseLayout();
		}

		private void Layout_CheckedChanged(object sender, EventArgs e)
		{
			if (rdoJog.Checked)
			{
				MainForm.ThisForm.JogLayout();
			}

			if (rdoParameter.Checked)
			{
				MainForm.ThisForm.ParameterLayout();
			}

			if (rdoAutoTuning.Checked)
			{
				MainForm.ThisForm.AutoTuningLayout();
			}

			if (rdoManualTuning.Checked)
			{
				MainForm.ThisForm.ManualTuningLayout();
			}
	
		}


	}
}