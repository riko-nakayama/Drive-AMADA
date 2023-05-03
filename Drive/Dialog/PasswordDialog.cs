using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
	public partial class PasswordDialog : Form
	{
		static string _PasswordText = string.Empty;

		public PasswordDialog()
		{
			InitializeComponent();
			_PasswordText = string.Empty;
		}

		public string CaptionText
		{
			set { this.Text = value; }
			get { return this.Text; }
		}

		public string LabelText
		{
			set { lblPassword.Text = value; }
			get { return lblPassword.Text; }
		}

		public string PasswordText
		{
			set { _PasswordText = value; txtPassword.Text = value; }
			get { return _PasswordText; }
		}

		// Ver 1.35 add Å´Å´Å´
		public FormStartPosition ViewStartPosition
		{
			set { this.StartPosition = value; }
			get { return this.StartPosition; }

		}
		// Ver 1.35 add Å™Å™Å™

		private void btnOk_Click(object sender, EventArgs e)
		{
			_PasswordText = txtPassword.Text;
			this.Close();
		}

		private void PasswordForm_Load(object sender, EventArgs e)
		{
			ChildFormControl.SetOpacity(0.0);
		}

		private void PasswordForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			ChildFormControl.SetOpacity(1.0);
		}

	}
}