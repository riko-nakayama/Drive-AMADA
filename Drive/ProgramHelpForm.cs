using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
	public partial class ProgramHelpForm : Form
	{
		static private ProgramHelpForm _ThisForm;

		private bool _IsExist = new bool();

		static private Point FormPosition = new Point(0, 0);
		static private Size FormSize = new Size(480, 240);

		public ProgramHelpForm()
		{
			InitializeComponent();

			_ThisForm = this;
			_IsExist = true;
		}

		private void ProgramHelpForm_Load(object sender, EventArgs e)
		{
			if (FormPosition.X != 0 && FormPosition.Y != 0)
			{
				this.Location = FormPosition;
			}

			this.Size = FormSize;
		}

		private void ProgramHelpForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			FormPosition = this.Location;
			FormSize = this.Size;

			_IsExist = false;
		}

		static public ProgramHelpForm ThisForm
		{
			get { return _ThisForm; }
		}

		public bool IsExist
		{
			get { return _IsExist; }
		}

		public string CmdText
		{
			set
			{
				//lblCmd.Text = "Command : " + value;
				lblCmd.Text = value;
			}
		}

		public string HelpText
		{
			set
			{
				rtxtHelp.Text = value;
			}
		}

	}
}