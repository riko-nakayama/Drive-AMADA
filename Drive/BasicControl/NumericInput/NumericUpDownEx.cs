using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
	public partial class NumericUpDownEx : NumericUpDown
	{
		public NumericUpDownEx()
		{
			InitializeComponent();
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			//base.OnMouseWheel(e);
		}
	}
}
