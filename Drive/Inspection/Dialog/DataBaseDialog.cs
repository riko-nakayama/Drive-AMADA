using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
	public partial class DataBaseDialog : Form
	{
		private bool IsClose = true;
		private string Message = string.Empty;

		public DataBaseDialog()
		{
			InitializeComponent();
		}

	
		private void PasswordForm_Load(object sender, EventArgs e)
		{
			if(GetDBParameters())
            {
				txtServer.Text = InspectionDef.dBParamters.Server;
				txtDataBase.Text = InspectionDef.dBParamters.DataBase;
				txtUser.Text = InspectionDef.dBParamters.User;
				txtPassword.Text = InspectionDef.dBParamters.Password;
			}
			else
            {
				MessageBox.Show("�f�[�^�x�[�X���̎擾�Ɏ��s���܂����B",
							    "�f�[�^�x�[�X",
							    MessageBoxButtons.OK,
							    MessageBoxIcon.Warning);
							    this.Close();
			}
		}

		private void DataBaseDialog_FormClosing(object sender, FormClosingEventArgs e)
		{
			if(!IsClose)
            {
				MessageBox.Show(Message,
								"�f�[�^�x�[�X",
								MessageBoxButtons.OK,
								MessageBoxIcon.Warning);
				IsClose = true;
				
				//�t�H�[���N���[�Y�L�����Z��
				e.Cancel = true;
			}
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			if (txtServer.Text == string.Empty)
			{
				Message = "�T�[�o�[�������͂���Ă��܂���B";

				txtServer.Focus();
				IsClose = false;
			}
			else if (txtDataBase.Text == string.Empty)
			{
				Message = "�f�[�^�x�[�X�������͂���Ă��܂���B";

				txtDataBase.Focus();
				IsClose = false;
			}
			else if (txtUser.Text == string.Empty)
			{
				Message = "���[�U�[�������͂���Ă��܂���B";

				txtUser.Focus();
				IsClose = false;
			}
			else if (txtPassword.Text == string.Empty)
			{
				Message = "�p�X���[�h�����͂���Ă��܂���B";

				txtPassword.Focus();
				IsClose = false;
			}
			else
			{
				InspectionDef.dBParamters.Server = txtServer.Text;
				InspectionDef.dBParamters.DataBase = txtDataBase.Text;
				InspectionDef.dBParamters.User = txtUser.Text;
				InspectionDef.dBParamters.Password = txtPassword.Text;

				Properties.Settings.Default.DataBase =
				InspectionDef.dBParamters.Server + "," +
				InspectionDef.dBParamters.DataBase + "," +
				InspectionDef.dBParamters.User + "," +
				InspectionDef.dBParamters.Password;

				this.Close();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		public static bool GetDBParameters()
		{
			try
			{
				string[] strbuf = Properties.Settings.Default.DataBase.Split(',');

				if (strbuf.Length != 4) return false;

				InspectionDef.dBParamters.Server = strbuf[0];
				InspectionDef.dBParamters.DataBase = strbuf[1];
				InspectionDef.dBParamters.User = strbuf[2];
				InspectionDef.dBParamters.Password = strbuf[3];

				return true;
			}
			catch
            {
				return false;
            }
		}

        private void txt_Click(object sender, EventArgs e)
        {
			TextBox txt = (TextBox)sender;
			txt.SelectAll();
			txt.Focus();
		}
    }


    public class DBParamters
	{
		public string Server;
		public string DataBase;
		public string User;
		public string Password;
		
		public DBParamters() { }

	}
}