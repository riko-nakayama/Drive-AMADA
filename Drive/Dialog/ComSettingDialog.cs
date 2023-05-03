using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
	public partial class ComSettingDialog : Form
	{
		private static int _ComSetting = new int();
		private static int _ComNum = new int();
		private static int _BaudSetting = new int();
		private static string _Baudrate = "115200bps";

		public ComSettingDialog()
		{
			InitializeComponent();
		
			for (int i = 0; i < 32; i++)			//20140516 update 16 ¨ 32
			{
				cmbCom.Items.Add("COM" + (i + 1).ToString());
			}

			cmbBaudrate.Items.Add("9600bps");
			cmbBaudrate.Items.Add("19200bps");
			cmbBaudrate.Items.Add("38400bps");
			cmbBaudrate.Items.Add("57600bps");
			cmbBaudrate.Items.Add("115200bps");

			_BaudSetting = 4;	//default:115200bps

		}

		static public int ComSetting
		{
			get { return _ComSetting; }
		}

		static public int ComNum
		{
			get { return _ComNum; }
		}

		static public string Baudrate
		{
			get { return _Baudrate; }
		}

		private void ComSettingForm_Load(object sender, EventArgs e)
		{
			ChildFormControl.SetOpacity(0.0);

			cmbCom.SelectedIndex = _ComSetting;
			cmbBaudrate.SelectedIndex = _BaudSetting;

			_ComNum = _ComSetting + 1;
		}

		private void ComSettingForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			ChildFormControl.SetOpacity(1.0);
		}

		private void cmbCom_SelectedIndexChanged(object sender, EventArgs e)
		{
			_ComSetting = cmbCom.SelectedIndex;
			_ComNum = _ComSetting + 1;
		}

		private void cmbBaudrate_SelectedIndexChanged(object sender, EventArgs e)
		{
			_BaudSetting = cmbBaudrate.SelectedIndex;
			_Baudrate = cmbBaudrate.Text;
		}
		
		private void btnOk_Click(object sender, EventArgs e)
		{
			this.Close();
		}

	}
}