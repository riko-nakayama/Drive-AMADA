using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
    public partial class InspectionCycle : Form
    {
        public InspectionCycle()
        {
            InitializeComponent();
        }

        private void InspectionCycle_Load(object sender, EventArgs e)
        {
            numCycle.Value = Properties.Settings.Default.Cycle;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Cycle = (int)numCycle.Value;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
