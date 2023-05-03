using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using System.Management;

namespace Motion_Designer
{
	public partial class FirmwareUpgradeDialog : Form
	{
		private const int DFU_WAIT_10SEC = 10;
		private const int DFU_WAIT_55SEC = 55;
	
		private bool IsComUpgrade = new bool();
		private bool IsBootMode = new bool();
		
		private bool IsUsbConnect = new bool();

		private bool IsDfuConnect = new bool();

		private string UpgradeResult = string.Empty;

		private int DfuWaitCounter = new int();

		private int DfuBlinkSq = new int();

		private Thread ThreadExistDfu;

		public FirmwareUpgradeDialog()
		{
			InitializeComponent();
		}

		private void FirmwareUpgradeForm_Load(object sender, EventArgs e)
		{
			ChildFormControl.SetOpacity(0.0);
			ChildFormControl.PropertyLock = true;

			MainForm.EnableMainTimer = false;

			IsUsbConnect = MainForm.IsUsbConnect;

			if (MainForm.DriverCPU == MainForm.CPU_TYP.RZT1)
			{
				chkBootMode.Visible = false;
				cmbMode.Items.Clear();
				cmbMode.Items.Add("HEX");
				cmbMode.Text = "HEX";
			}

			TimerUsbDevice.Interval = 1000;
			TimerUsbDevice.Enabled = true;

			ThreadExistDfu = new Thread(ExistDfuDevice);

			ThreadExistDfu.Start();
		}

		private void FirmwareUpgradeForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			MainForm.EnableMainTimer = true;

			ThreadExistDfu.Abort();

			this.Dispose();

			ChildFormControl.PropertyLock = false;
			ChildFormControl.SetOpacity(1.0);
		}

		private bool IsDfuExist = new bool();

		private void ExistDfuDevice()
		{
			try
			{
				bool exist = new bool();

				while (true)
				{
					exist = false;

					ArrayList deviceNameList = new ArrayList();

					ManagementClass mcPnPEntity = new ManagementClass("Win32_PnPEntity");
					ManagementObjectCollection manageObjCol = mcPnPEntity.GetInstances();

					//�S�Ă�PnP�f�o�C�X��T�����V���A���ʐM���s����f�o�C�X�𐏎��ǉ�����
					foreach (ManagementObject manageObj in manageObjCol)
					{
						//Name�v���p�e�B���擾
						object namePropertyValue = manageObj.GetPropertyValue("Name");
						if (namePropertyValue == null)
						{
							continue;
						}

						//Name�v���p�e�B������̈ꕔ��"(COM1)�`(COM999)"�ƈ�v����Ƃ����X�g�ɒǉ�
						string name = namePropertyValue.ToString();
						if (name == "STM Device in DFU Mode")
						{
							exist = true;
						}
					}

					IsDfuExist = exist;
				}
			}
			catch (ThreadAbortException)
			{

			}
			finally
			{
				//Mutex���b�N�̊J��
				//ThreadStatusMutex.ReleaseMutex();
			}
		}

		private bool ExistUsbDevice()
		{
			bool exist = new bool();

			ArrayList deviceNameList = new ArrayList();

			ManagementClass mcPnPEntity = new ManagementClass("Win32_PnPEntity");
			ManagementObjectCollection manageObjCol = mcPnPEntity.GetInstances();

			//�S�Ă�PnP�f�o�C�X��T�����V���A���ʐM���s����f�o�C�X�𐏎��ǉ�����
			foreach (ManagementObject manageObj in manageObjCol)
			{
				//Name�v���p�e�B���擾
				object namePropertyValue = manageObj.GetPropertyValue("Name");
				if (namePropertyValue == null)
				{
					continue;
				}

				//Name�v���p�e�B������̈ꕔ��"(COM1)�`(COM999)"�ƈ�v����Ƃ����X�g�ɒǉ�
				string name = namePropertyValue.ToString();
				if (name.Contains("Tamagawa"))
				{
					exist = true;
				}
			}

			return exist;
		}

		private DataProgressDialog DataMsg = new DataProgressDialog();

		private void btnStartUpgrade_Click(object sender, EventArgs e)
		{
			btnCancel.Text = UserText.UpgradeCancel;

            if (MainForm.DriverCPU == MainForm.CPU_TYP.RZT1)
            {
				//RZT1_Upgrade();�@//Ver 1.34 delete  
				RZT1_FirmwareUpgrade(); //20220106 Ver1.31 Update - > Ver 1.34 �����ذ�  
            }
            else
            {
                STM32F_Upgrade();
            }
        }

		private void RZT1_Upgrade()
		{
			try
			{
				if (IsUsbConnect)
				{
					if ((CMonitor.GetParameter(CParamID.ServoStatus) & 0x01) == 0x01)
					{
						//�T�[�{�I�����Ă���
						UserMessageBox.UpgradeRequestServoOff();
						return;
					}
				}
				else
				{
					//USB���ڑ�����Ă��Ȃ�
					UserMessageBox.UpgradeRequestUsbAttach();
					return;
				}

				string dfu_path = string.Empty;

				try
				{
					dfu_path = Path.Combine(Application.StartupPath, "Firmware");
				}
				catch
				{
					//Firmware�t�H���_�����݂��Ȃ�
					dfu_path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
				}

				OpenFileDialog.Title = UserText.UpgradeHexFileSelect;
				OpenFileDialog.Filter = "Dirver Firmware (*.hex)|*.hex";
				OpenFileDialog.InitialDirectory = dfu_path;
				OpenFileDialog.FileName = string.Empty;

				ChildFormControl.SetOpacity(0.0);

				DialogResult ret = OpenFileDialog.ShowDialog();

				ChildFormControl.SetOpacity(1.0);

				if (ret != DialogResult.OK) { return; }

				this.Cursor = Cursors.WaitCursor;

				System.IO.StreamReader file = new System.IO.StreamReader(OpenFileDialog.FileName);

				string[] hex_txt;

				hex_txt = file.ReadToEnd().Split('\n');

				DataMsg = new DataProgressDialog();
				DataMsg.Maximum = hex_txt.Length - 1;
				DataMsg.Start(UserText.ParameterDataRead, this.Location, this.ClientSize, false);

				string hex_num = string.Empty;
				string hex_adr = string.Empty;
				string hex_rec = string.Empty;
				string hex_dat = string.Empty;
				string hex_sum = string.Empty;

				int num = new int();
				int adr = new int();
				int rec = new int();
				int sum = new int();
				int cmp = new int();

				int[] dat;

				bool hex_err = false;

				//HEX�t�@�C���\�����
				for (int i = 0; i < hex_txt.Length - 1; i++)
				{
					hex_txt[i] = hex_txt[i].TrimEnd('\r');

					hex_num = hex_txt[i][1].ToString() + hex_txt[i][2].ToString();

					hex_adr = hex_txt[i][3].ToString() + hex_txt[i][4].ToString() + hex_txt[i][5].ToString() + hex_txt[i][6].ToString();

					hex_rec = hex_txt[i][7].ToString() + hex_txt[i][8].ToString();

					if (hex_txt[i][0] != ':') { hex_err = true; break; }								//�X�^�[�g�R�[�h�@�t�H�[�}�b�g�G���[

					if (!CDataTool.HexStringToInt32(hex_num, ref num)) { hex_err = true; }			//�o�C�g�J�E���g�@�t�H�[�}�b�g�G���[

					if (!CDataTool.HexStringToInt32(hex_adr, ref adr)) { hex_err = true; }			//�A�h���X�@�@�@�@�t�H�[�}�b�g�G���[

					if (!CDataTool.HexStringToInt32(hex_rec, ref rec)) { hex_err = true; }			//���R�[�h�^�C�v�@�t�H�[�}�b�g�G���[

					if (rec < 0 || rec > 5) { hex_err = true; }										//���R�[�h�^�C�v�@�͈̓G���[

					if ((9 + (num * 2) + 2) > hex_txt[i].Length) { hex_err = true; }					//�f�[�^���G���[

					dat = new int[num];
					cmp = 0;

					for (int j = 0, n = 9; j < num; j++, n += 2)
					{
						hex_dat = hex_txt[i][n].ToString() + hex_txt[i][n + 1].ToString();

						if (!CDataTool.HexStringToInt32(hex_dat, ref dat[j])) { hex_err = true; }	//�f�[�^�G���[

						cmp += dat[j];
					}

					hex_sum = hex_txt[i][hex_txt[i].Length - 2].ToString() + hex_txt[i][hex_txt[i].Length - 1].ToString();

					if (!CDataTool.HexStringToInt32(hex_sum, ref sum)) { hex_err = true; }			//SUM�G���[

					cmp = cmp + num + (adr & 0xFF) + ((adr >> 8) & 0xFF) + rec;
					cmp = cmp & 0xFF;
					cmp = 0x100 - cmp;
					cmp = cmp & 0xFF;

					if (sum != cmp) { hex_err = true; }

					if (hex_err) { break; }

					DataMsg.PerformStep();
				}

				file.Close();

				Thread.Sleep(500);

				DataMsg.Close();

				if (hex_err)
				{
					UserMessageBox.CommonFileFormatError();
					this.Cursor = Cursors.Default;
					return;
				}

				DataMsg = new DataProgressDialog();
				DataMsg.Maximum = hex_txt.Length - 1;
				DataMsg.Start(UserText.UpgradeFirmwareUpdating, this.Location, this.ClientSize, false);

				SendDFU(false);

                Thread.Sleep(100);

				byte[] usb_buf = new byte[64];

				bool end_of_file = new bool();

				int exp_adr = new int();
				int act_adr = new int();

				//FLASH��������
				for (int i = 0; i < hex_txt.Length - 1; i++)
				{
					hex_num = hex_txt[i][1].ToString() + hex_txt[i][2].ToString();

					hex_adr = hex_txt[i][3].ToString() + hex_txt[i][4].ToString() + hex_txt[i][5].ToString() + hex_txt[i][6].ToString();

					hex_rec = hex_txt[i][7].ToString() + hex_txt[i][8].ToString();

					CDataTool.HexStringToInt32(hex_num, ref num);

					CDataTool.HexStringToInt32(hex_adr, ref adr);

					CDataTool.HexStringToInt32(hex_rec, ref rec);

					dat = new int[num];

					for (int j = 0, n = 9; j < num; j++, n += 2)
					{
						hex_dat = hex_txt[i][n].ToString() + hex_txt[i][n + 1].ToString();

						CDataTool.HexStringToInt32(hex_dat, ref dat[j]);
					}

					switch (rec)
					{
						//�f�[�^
						case 0x00:

							if ((num % 4) != 0) { hex_err = true; }

							act_adr = exp_adr | adr;

							//Sector Address
							usb_buf[4] = (byte)((act_adr) & 0xFF);
							usb_buf[5] = (byte)((act_adr >> 8) & 0xFF);
							usb_buf[6] = (byte)((act_adr >> 16) & 0xFF);
							usb_buf[7] = (byte)((act_adr >> 24) & 0xFF);

							usb_buf[8] = (byte)(num / 4);

							for (int j = 0; j < num; j++)
							{
								usb_buf[9 + j] = (byte)dat[j];
							}

							//Flash Pragram
							if (!CCommandTx.RequestCommandCode('W', usb_buf))
							{
								hex_err = true;
							}

							break;

						//End of file
						case 0x01:

							end_of_file = true;
							break;

						//�g�����j�A�A�h���X
						case 0x04:

							if (num != 2) { hex_err = true; }

							exp_adr = ((dat[0] - 0x30) << 24) | (dat[1] << 16);		//RZT1 0x30000000�iVirtual)��0x00000000�iPhysical)

							//Sector Address
							usb_buf[4] = (byte)((exp_adr) & 0xFF);
							usb_buf[5] = (byte)((exp_adr >> 8) & 0xFF);
							usb_buf[6] = (byte)((exp_adr >> 16) & 0xFF);
							usb_buf[7] = (byte)((exp_adr >> 24) & 0xFF);

							//Sector Erase
							if (!CCommandTx.RequestCommandCode('E', usb_buf)) { hex_err = true; }

							break;

						//�J�n���j�A�A�h���X
						case 0x05:

							break;

						default:

							break;
					}

					DataMsg.PerformStep();

					if (hex_err) { break; }

					if (end_of_file) { break; }
				}

				Thread.Sleep(500);

				DataMsg.Close();

				if (hex_err || !end_of_file)
				{
					UserMessageBox.UpgradeFailed(); 
					this.Cursor = Cursors.Default;
					return;
				}

				DataMsg = new DataProgressDialog();
				DataMsg.Maximum = hex_txt.Length - 1;
				DataMsg.Start(UserText.ParameterDataInit, this.Location, this.ClientSize, false);

				end_of_file = false;

				//FLASH�x���t�@�C
				for (int i = 0; i < hex_txt.Length - 1; i++)
				{
					hex_num = hex_txt[i][1].ToString() + hex_txt[i][2].ToString();

					hex_adr = hex_txt[i][3].ToString() + hex_txt[i][4].ToString() + hex_txt[i][5].ToString() + hex_txt[i][6].ToString();

					hex_rec = hex_txt[i][7].ToString() + hex_txt[i][8].ToString();

					CDataTool.HexStringToInt32(hex_num, ref num);

					CDataTool.HexStringToInt32(hex_adr, ref adr);

					CDataTool.HexStringToInt32(hex_rec, ref rec);

					dat = new int[num];

					for (int j = 0, n = 9; j < num; j++, n += 2)
					{
						hex_dat = hex_txt[i][n].ToString() + hex_txt[i][n + 1].ToString();

						CDataTool.HexStringToInt32(hex_dat, ref dat[j]);
					}

					switch (rec)
					{
						//�f�[�^
						case 0x00:

							if ((num % 4) != 0) { hex_err = true; }

							act_adr = exp_adr | adr;

							//Flash Verify
							if (!CCommandTx.ReadFlashRZT1(act_adr, num, ref usb_buf))
							{
								hex_err = true;
							}

							for (int j = 0; j < num; j++)
							{
								if (usb_buf[j] != dat[j])
								{
									hex_err = true;
								}
							}

							break;

						//End of file
						case 0x01:

							end_of_file = true;
							break;

						//�g�����j�A�A�h���X
						case 0x04:

							if (num != 2) { hex_err = true; }

							exp_adr = ((dat[0] - 0x30) << 24) | (dat[1] << 16);		//RZT1 0x30000000�iVirtual)��0x00000000�iPhysical)
							
							break;

						//�J�n���j�A�A�h���X
						case 0x05:

							break;

						default:

							break;
					}

					DataMsg.PerformStep();

					if (hex_err) { break; }

					if (end_of_file) { break; }
				}

				Thread.Sleep(500);

				DataMsg.Close();

				this.Cursor = Cursors.Default;

				//if (!CCommandTx.RequestCommandCode('B', usb_buf))
				//{
				//    hex_err = true;
				//}

				if (hex_err || !end_of_file)
				{
					UserMessageBox.UpgradeFailed();
				}
				else
				{
					UserMessageBox.UpgradeSuccessful();
					btnCancel.Text = UserText.UpgradeCompletion;
				}
			}
			catch
			{
				DataMsg.Close();

				this.Cursor = Cursors.Default;

				UserMessageBox.UpgradeFailed();
			}
		}

		private void STM32F_Upgrade()
		{
			if (cmbMode.Text == "COM")
			{
				IsComUpgrade = true;
			}
			else
			{
				IsComUpgrade = false;
			}

			if (chkBootMode.Checked)
			{
				IsBootMode = true;
			}
			else
			{
				IsBootMode = false;
			}

			if (IsUsbConnect)
			{
				if ((CMonitor.GetParameter(CParamID.ServoStatus) & 0x01) == 0x01)
				{
					//�T�[�{�I�����Ă���
					UserMessageBox.UpgradeRequestServoOff();
					return;
				}
			}

			rtxtResult.Clear();

			UpgradeResult = string.Empty;

			if (IsComUpgrade)
			{
				//Process.Start("STMFlashLoader\\STMFlashLoader.exe",
				//                @"-c --pn 4 --br 115200 --db 8 --pr EVEN --sb 1 --ec OFF --to 10000 -i STM32F4_1024K -e --all -d --v --fn ""STMFlashLoader\\ServoDriver.hex""");

				if (IsUsbConnect)
				{
					UserMessageBox.UpgradeRequestUsbDettach();
				}
				else
				{
					StartComUpgrade();
				}
			}
			else
			{
				if (IsBootMode)
				{
					if (IsUsbConnect)
					{
						UserMessageBox.UpgradeRequestBootMode();
					}
					else
					{
						if (IsDfuConnect)
						{
							StartDfuUpgrade();
						}
						else
						{
							UserMessageBox.UpgradeDisableDFUDevice();
						}
					}
				}
				else
				{
					if (!IsUsbConnect)
					{
						UserMessageBox.UpgradeRequestUsbAttach();
					}
					else
					{
						TimerUsbDevice.Enabled = false;
						TimerDfuStart.Enabled = false;

						ThreadExistDfu.Abort();

						while (ThreadExistDfu.ThreadState == System.Threading.ThreadState.Running) { }

						if (!SendDFU(true)) { return; }

						int cnt = new int();

						while (SendDFU(false)) { if (cnt >= 3) { break; } }		//DFU�R�}���h�𕡐���

						DisableInitUsb = true;			//Timer���ł�InitUsb�AUnInitCUsb���d�����֎~

						TimerUsbDevice.Enabled = true;

						DfuBlinkSq = 1;

						lblDfu.Text = UserText.UpgradeDeviceDetach;
						lblDfu.BackColor = SystemColors.Control;

						lblUsb.Visible = true;
						lblUsb.BackColor = Color.Yellow;
						lblUsb.Text = UserText.UpgradeCableDettach;

						UserMessageBox.UpgradeRequestCableDettach();

						CDataTool.SetNow(CDataTool.UPG1_TIME);
						CDataTool.SetNow(CDataTool.UPG2_TIME);

						while (ExistUsbDevice())
						{
							if (CDataTool.IsTimerLimit(CDataTool.UPG1_TIME, DFU_WAIT_10SEC))
							{
								UserMessageBox.UpgradeUsbDettachTimeLimit();

								lblUsb.Visible = false;
								DisableInitUsb = false;			//Timer�ĊJ
								DfuBlinkSq = 0;

								ThreadExistDfu = new Thread(ExistDfuDevice);
								ThreadExistDfu.Start();

								return;
							}

							if (CDataTool.IsTimerLimitMiliSecond(CDataTool.UPG2_TIME, 500))
							{
								CDataTool.SetNow(CDataTool.UPG2_TIME);

								if (lblUsb.BackColor == Color.Yellow)
								{
									lblUsb.BackColor = SystemColors.Control;
								}
								else
								{
									lblUsb.BackColor = Color.Yellow;
								}

								this.Refresh();
							}
						}

						CloseUsb();

						lblUsb.Visible = true;
						lblUsb.BackColor = Color.Cyan;
						lblUsb.Text = UserText.UpgradeCableAttach;

						DfuBlinkSq = 2;

						UserMessageBox.UpgradeRequestDFUAttach();

						DfuWaitCounter = 0;

						ThreadExistDfu = new Thread(ExistDfuDevice);
						ThreadExistDfu.Start();

						TimerDfuStart.Interval = 1000;
						TimerDfuStart.Enabled = true;
					}
				}
			}
		}

		private bool SendDFU(bool msg_on)
		{
			byte[] buf = new byte[64];

			if (!CCommandTx.RequestCommandCode('D', buf))
			{
				if (msg_on)
				{
					UserMessageBox.UpgradeBootModeFailed();
				}
				return false;
			}

			Thread.Sleep(100);

			if (!CCommandTx.RequestCommandCode('F', buf))
			{
				if (msg_on)
				{
					UserMessageBox.UpgradeBootModeFailed();
				}
				return false;
			}

			Thread.Sleep(100);

			if (!CCommandTx.RequestCommandCode('U', buf))
			{
				if (msg_on)
				{
					UserMessageBox.UpgradeBootModeFailed();
				}
		
				return false;
			}

			Thread.Sleep(100);

			return true;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			if (btnCancel.Text == UserText.UpgradeCancel)
			{
				UserMessageBox.UpgradeCancelUpgrade();
			}

			MainForm.EnableMainTimer = true;

			this.Dispose();
		}

		private void StartComUpgrade()
		{
			ComSettingDialog comForm = new ComSettingDialog();

			comForm.ShowDialog();

			string com_n = ComSettingDialog.ComNum.ToString();
			string bps = ComSettingDialog.Baudrate.Replace("bps", "");

			//ProgressForm pBarForm = new ProgressForm();

			Process p = new Process();

			string path = string.Empty;
			string name = string.Empty;

			try
			{
				path = Path.Combine(Application.StartupPath, "Firmware");
			}
			catch
			{
				//Firmware�t�H���_�����݂��Ȃ�
				path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
			}

			OpenFileDialog.Title = UserText.UpgradeHexFileSelect;
			OpenFileDialog.Filter = "Dirver Firmware (*.hex)|*.hex";
			OpenFileDialog.InitialDirectory = path;
			OpenFileDialog.FileName = name;

			ChildFormControl.SetOpacity(0.0);
		
			DialogResult ret = OpenFileDialog.ShowDialog();

			ChildFormControl.SetOpacity(1.0);
		
			if (ret != DialogResult.OK) { return; }

			p.StartInfo.Verb = "RunAs";		//�Ǘ��҂ɏ��i���Ď��s

			//�p�X���擾���āAFileName�v���p�e�B�Ɏw��
			p.StartInfo.FileName = Path.Combine(Application.StartupPath, "STMFlashLoader\\STMFlashLoader.exe");

			p.StartInfo.Arguments = @"-c --pn " + com_n + " --br " + bps + " --db 8 --pr EVEN --sb 1 --ec OFF --to 10000 -i STM32F4_1024K -e --all -d --v --fn " + OpenFileDialog.FileName;

			UserMessageBox.UpgradeExecExclamation();

			//�N��
			p.Start();
		}

		private void StartDfuUpgrade()
		{
			DataProgressDialog DataMsg = new DataProgressDialog();

			Process p = new Process();

			string dfu_path = string.Empty;

			try
			{
				dfu_path = Path.Combine(Application.StartupPath, "Firmware");
			}
			catch
			{
				//Firmware�t�H���_�����݂��Ȃ�
				dfu_path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
			}

			OpenFileDialog.Title = UserText.UpgradeDFUFileSelect;
			OpenFileDialog.Filter = "Dirver Firmware (*.dfu)|*.dfu";
			OpenFileDialog.InitialDirectory = dfu_path;
			OpenFileDialog.FileName = string.Empty;

			ChildFormControl.SetOpacity(0.0);
		
			DialogResult ret = OpenFileDialog.ShowDialog();

			ChildFormControl.SetOpacity(1.0);
		
			if (ret != DialogResult.OK) { return; }

			dfu_path = OpenFileDialog.FileName;

			//C:\\Users\\User\\AppData\\Local\\Drive\DFU
			string local = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Drive"), "DFU");

			string src_dfu_dir = Path.Combine(Application.StartupPath, "DFU");
			string src_dfu_cmd	= Path.Combine(src_dfu_dir, "DfuSeCommand.exe");
			string src_st_dfu	= Path.Combine(src_dfu_dir, "STDFU.dll");
			string src_st_file	= Path.Combine(src_dfu_dir, "STDFUFiles.dll");
			string src_st_prt	= Path.Combine(src_dfu_dir, "STDFUPRT.dll");
			string src_st_tube	= Path.Combine(src_dfu_dir, "STTubeDevice30.dll");

			string dst_dfu_cmd	= Path.Combine(local, "DfuSeCommand.exe");
			string dst_st_dfu	= Path.Combine(local, "STDFU.dll");
			string dst_st_file	= Path.Combine(local, "STDFUFiles.dll");
			string dst_st_prt	= Path.Combine(local, "STDFUPRT.dll");
			string dst_st_tube	= Path.Combine(local, "STTubeDevice30.dll");

			string dfu_file = Path.Combine(local, OpenFileDialog.SafeFileName);

			try
			{
				if (AppConst.UpWinodws7)
				{
					//Winodws 7
					if (!Directory.Exists(local)) { Directory.CreateDirectory(local); }

					if (!File.Exists(dst_dfu_cmd)) { File.Copy(src_dfu_cmd, dst_dfu_cmd, true); }
					if (!File.Exists(dst_st_dfu)) { File.Copy(src_st_dfu, dst_st_dfu, true); }
					if (!File.Exists(dst_st_file)) { File.Copy(src_st_file, dst_st_file, true); }
					if (!File.Exists(dst_st_prt)) { File.Copy(src_st_prt, dst_st_prt, true); }
					if (!File.Exists(dst_st_tube)) { File.Copy(src_st_tube, dst_st_tube, true); }

					File.Copy(dfu_path, dfu_file, true);
				}
				else
				{
					//Winodws Xp
					dst_dfu_cmd = src_dfu_cmd;

					dfu_file = "c:\\" + OpenFileDialog.SafeFileName;
					File.Copy(dfu_path, dfu_file, true);

					Thread.Sleep(1000);
				}
			}
			catch
			{
				dst_dfu_cmd = src_dfu_cmd;
				dfu_file = dfu_path;
			}

			p.StartInfo.Verb = "RunAs";		//�Ǘ��҂ɏ��i���Ď��s

			//�p�X���擾���āAFileName�v���p�e�B�Ɏw��
			p.StartInfo.FileName = dst_dfu_cmd;

			p.StartInfo.Arguments = @"-c --de 0 -d --v --fn " + dfu_file;
			
			UserMessageBox.UpgradeExecExclamation();

			if (!IsBootMode) { UserMessageBox.UpgradeDFUExclamation(); }

			DataMsg.StartMarquee(UserText.UpgradeFirmwareUpdating, this.Location, this.Size, false);
			
			p.OutputDataReceived += p_OutputDataReceived;

			//�o�͂�ǂݎ���悤�ɂ���
			p.StartInfo.UseShellExecute = false;
			p.StartInfo.RedirectStandardOutput = true;
			p.StartInfo.RedirectStandardInput = false;
		
			//�E�B���h�E��\�����Ȃ��悤�ɂ���
			p.StartInfo.CreateNoWindow = true;

			//�N��
			p.Start();

			//�񓯊��ŏo�͂̓ǂݎ����J�n
			p.BeginOutputReadLine();

			//�o�͂�ǂݎ��
			//results = p.StandardOutput.ReadToEnd();
			
			//�v���Z�X�I���܂őҋ@����
			//WaitForExit��ReadToEnd�̌�ł���K�v������
			//(�e�v���Z�X�A�q�v���Z�X�Ńu���b�N�h�~�̂���)
			//p.WaitForExit(30000);

			CDataTool.SetNow(CDataTool.UPG1_TIME);

			while (!p.HasExited)
			{
				DataMsg.Refresh();

				if (CDataTool.IsTimerLimit(CDataTool.UPG1_TIME, DFU_WAIT_55SEC))
				{
					break;
				}

				Thread.Sleep(100);
			}

			p.Close();

			DataMsg.Close();

			//�o�͂��ꂽ���ʂ�\��
			//Console.WriteLine(results);

			rtxtResult.Text = UpgradeResult;

			if (UpgradeResult.Contains("Upgrade successful !") &&
				UpgradeResult.Contains("Verify successful !"))
			{
				UserMessageBox.UpgradeSuccessful();
				btnCancel.Text = UserText.UpgradeCompletion;
			}
			else
			{
				UserMessageBox.UpgradeFailed();
			}

			if (!AppConst.UpWinodws7)
			{
				//Winodws Xp
				try { File.Delete(dfu_file); }
				catch { }
			}
		}

		private void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
		{
			//�o�͂��ꂽ�������\������
			UpgradeResult += e.Data;
		}

		private void TimerDfuStart_Tick(object sender, EventArgs e)
		{	
			if (IsDfuConnect)
			{
				DfuBlinkSq = 0;

				lblUsb.Visible = false;
				lblUsb.BackColor = SystemColors.Control;

				TimerDfuStart.Enabled = false;			//���d���荞�݉��

				DisableInitUsb = false;

                ThreadExistDfu.Abort();

				UserMessageBox.UpgradeExistDFU();

				StartDfuUpgrade();
			}

			DfuWaitCounter++;

			int t = DfuWaitCounter * TimerDfuStart.Interval / 1000;

			if (t > DFU_WAIT_10SEC)
			{
				TimerDfuStart.Enabled = false;

				DisableInitUsb = false;

				UserMessageBox.UpgradeDfuAttachTimeLimit();

				DfuBlinkSq = 0;

			}
		}

		private bool DisableInitUsb = new bool();

		private void TimerUsbDevice_Tick(object sender, EventArgs e)
		{
			if (!DisableInitUsb)
			{
				if (IsUsbConnect)
				{
					int data = new int();

					if (!CCommandTx.ReadSvNet(0, ref data))
					{
						CloseUsb();
						IsUsbConnect = false;
					}
				}
				else
				{
					if (CUsb.InitCUsb())
					{
						IsUsbConnect = true;
						lblUsb.Visible = false;
					}
				}
			}

			if (IsDfuExist)
			{
				lblDfu.Text = UserText.UpgradeDfuAttach;
				lblDfu.BackColor = Color.Crimson;

				IsDfuConnect = true;
				IsUsbConnect = false;
			}
			else if (IsUsbConnect)
			{
				lblDfu.Text = UserText.UpgradeUsbAttach;
				lblDfu.BackColor = Color.LightGreen;

				IsDfuConnect = false;
				IsUsbConnect = true;
			}
			else
			{
				lblDfu.Text = UserText.UpgradeDeviceDetach;
				lblDfu.BackColor = SystemColors.Control;

				IsDfuConnect = false;
				IsUsbConnect = false;
			}

			if (MainForm.DriverCPU == MainForm.CPU_TYP.RZT1)
			{
				chkBootMode.Visible = false;
				cmbMode.Text = "HEX";
			}

			switch (DfuBlinkSq)
			{
				case 1:
					if (lblUsb.BackColor == Color.Yellow)
					{
						lblUsb.BackColor = SystemColors.Control;
					}
					else
					{
						lblUsb.BackColor = Color.Yellow;
					}
					break;

				case 2:
					if (lblUsb.BackColor == Color.Cyan)
					{
						lblUsb.BackColor = SystemColors.Control;
					}
					else
					{
						lblUsb.BackColor = Color.Cyan;
					}
					break;

				default:

					lblUsb.BackColor = SystemColors.Control;
					break;
			}

		}

		private void cmbMode_KeyDown(object sender, KeyEventArgs e)
		{
			e.Handled = true;
		}

		private void cmbMode_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = true;
		}

		private void cmbMode_TextChanged(object sender, EventArgs e)
		{
			string txt = cmbMode.Text;

			if (txt == "DFU")
			{
				chkBootMode.Enabled = true;
			}
			else
			{
				chkBootMode.Enabled = false;
			}
		}

		private void CloseUsb()
		{
			CUsb.UnInitCUsb();
			IsUsbConnect = false;
			Thread.Sleep(500);			//UnInitCUsb�̌�ɕK�v�Ȏ��ԁH
        }

        //20220106 Ver1.31 add �� 
        #region RZT1�t�H�[���E�F�A�A�b�v�O���[�h�i�Z�N�^�P�ʁj

        private int[] sector_rec_num = new int[10];                             // �Z�N�^�[�P�ʂɊe���R�[�h�̃f�[�^�������W        
        private int[,] sector_data_low_addr = new int[10, 4096 + 1];            // �Z�N�^�[�P�ʂɊe���R�[�h�̉��ʃA�h���X�����W        
        private int[,] sector_data_num = new int[10, 4096 + 1];                 // �Z�N�^�[�P�ʂɊe���R�[�h�̃f�[�^�������W        
        private byte[,] sector_send_data_buf = new byte[10, (64 * 1024)];       // �Z�N�^�[�P�ʂɊe���R�[�h�̃f�[�^�����W        
        private byte[,] sector_addr = new byte[10, 2];                          // �Z�N�^�[�P�ʂɊe���R�[�h�̃Z�N�^�[�A�h���X(�ׁ[�X)�����W        
        private int[] sector_data_size = new int[10];                           // �Z�N�^�[���̃f�[�^�������W        
        private byte sector_num = 0;                                            // �S�Z�N�^�[��        
        private int total_data_size = 0;                                        // �S�f�[�^��        
        private byte send_block_size = 48;                                      // �P�x�ő���M����o�C�g��        

        private void RZT1_FirmwareUpgrade()
        {
            try
            {
                string fileContent = string.Empty;
                string filePath = string.Empty;
                string[] hex_txt = null;

                if (IsUsbConnect)
                {
                    if ((CMonitor.GetParameter(CParamID.ServoStatus) & 0x01) == 0x01)
                    {
                        //�T�[�{�I�����Ă���
                        UserMessageBox.UpgradeRequestServoOff();
                        return;
                    }
                }
                else
                {
                    //USB���ڑ�����Ă��Ȃ�
                    UserMessageBox.UpgradeRequestUsbAttach();
                    return;
                }

                string dfu_path = string.Empty;

                try
                {
                    dfu_path = Path.Combine(Application.StartupPath, "Firmware");
                }
                catch
                {
                    //Firmware�t�H���_�����݂��Ȃ�
                    dfu_path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                }

                OpenFileDialog.Title = UserText.UpgradeHexFileSelect;
                OpenFileDialog.Filter = "Dirver Firmware (*.hex)|*.hex";
                OpenFileDialog.InitialDirectory = dfu_path;
                OpenFileDialog.FileName = string.Empty;

                ChildFormControl.SetOpacity(0.0);

                DialogResult ret = OpenFileDialog.ShowDialog();

                ChildFormControl.SetOpacity(1.0);

                if (ret != DialogResult.OK) { return; }

                this.Cursor = Cursors.WaitCursor;

                rtxtResult.Clear();
                UpgradeResult = string.Empty;

                using (StreamReader file = new StreamReader(OpenFileDialog.FileName))
                {
                    hex_txt = file.ReadToEnd().Split('\n');
                    file.Close();
                }

                if (CheckHexFileFormat(hex_txt))
                {
                    ViewResultMessage("Hex File Read Successful !");
                }
                else
                {
                    UserMessageBox.CommonFileFormatError();
                    this.Cursor = Cursors.Default;
                    return;
                }

                // �g�d�w�R�[�h���Z�N�^�P�ʂɕҏW
                GetSectorDataFromHexFile(hex_txt);

                if (DialogResult.Yes == UserMessageBox.StartFWUpgrade())
                {
                    // �e�v�A�b�v�O���[�h�J�n�v��
                    if (WriteDFU())
                    {
                        ViewResultMessage("Upgrade Start Successful !");
                    }
                    else
                    {
                        ViewResultMessage("Upgrade Start Error !");
                        throw new Exception();
                    }

                    // �g�d�w�R�[�h������
                    if (WriteHexFile())
                    {
                        ViewResultMessage("Hex Code Write Successful !");
                    }
                    else
                    {
                        ViewResultMessage("Hex Code Write Error !");
                        throw new Exception();
                    }

                    // �g�d�w�R�[�h�x���t�@�C
                    if (VerifyUpdate())
                    {
                        ViewResultMessage("Hex Code Verify Successful !");
                    }
                    else
                    {
                        ViewResultMessage("Hex Code Verify Error !");
                        throw new Exception();
                    }

                    // �e�v�A�b�v�O���[�h�I���v��
                    if (WriteEnd())
                    {
                        ViewResultMessage("Upgrade End Successful !");
                    }
                    else
                    {
                        ViewResultMessage("Upgrade End Error !");
                        throw new Exception();
                    }

                    // �A�b�v�O���[�h����!!
                    UserMessageBox.UpgradeSuccessful();
                    btnCancel.Text = UserText.UpgradeCompletion;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                }
            }
            catch
            {
                this.Cursor = Cursors.Default;

                DataMsg.Close();
                UserMessageBox.UpgradeFailed();
            }
        }

        /// <summary>
        /// Hex�t�@�C���̃t�H�[�}�b�g�����������m�F���܂��B
        /// </summary>
        private bool CheckHexFileFormat(string[] hex_txt)
        {
            int line_no = 1;

            foreach (string r in hex_txt)
            {
                string recode = r.TrimEnd('\r');

                if (recode.Length == 0) break;

                if (recode[0] != ':') { return false; }

                try
                {
                    string hex_num = recode.Substring(1, 2);
                    int num = HexStringToInt32(hex_num);

                    string hex_adr = recode.Substring(3, 4);
                    int adr = HexStringToInt32(hex_adr);

                    string hex_rec = recode.Substring(7, 2);
                    int rec = HexStringToInt32(hex_rec);

                    byte sum = 0;
                    for (int i = 1; i < recode.Length; i += 2)
                    {
                        sum += (byte)HexStringToInt32(recode.Substring(i, 2));
                    }

                    if (sum != 0) return false;
                    
                    line_no++;
                }
                catch
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// �V���A���|�[�g���f�[�^���󂯎�������ɌĂяo�����n���h���ł��B
        /// </summary>
        private bool WriteDFU()
        {
            byte[] dummy_payload = new byte[CCommandTx.REQ_LEN - 6];

            return CCommandTx.RequestFlashRZT1Command('U', dummy_payload);
        }

        /// <summary>
        /// �I���R�}���h���M
        /// </summary>
        private bool WriteEnd()
        {
            byte[] dummy_payload = new byte[CCommandTx.REQ_LEN - 6];

            return CCommandTx.RequestFlashRZT1Command('B', dummy_payload);
        }

        /// <summary>
        /// Hex�t�@�C���̃f�[�^���Z�N�^�[�P�ʂł܂Ƃ߂܂�
        /// </summary>
        private void GetSectorDataFromHexFile(string[] hex_txt)
        {
            int off = 0;
            int rec_cnt = 0;
            int sct_idx = -1;

            foreach (string r in hex_txt)
            {
                string recode = r.TrimEnd('\r');
                if (recode.Length == 0) { break; }

                string hex_num = recode.Substring(1, 2);
                int num = HexStringToInt32(hex_num);

                string hex_rec = recode.Substring(7, 2);
                int rec = HexStringToInt32(hex_rec);

                switch (rec)
                {

                    // �f�[�^
                    case 0x00:
                        sector_data_low_addr[sct_idx, rec_cnt] = HexStringToInt32(recode.Substring(3, 2)) << 8;
                        sector_data_low_addr[sct_idx, rec_cnt] |= HexStringToInt32(recode.Substring(5, 2));
                        sector_data_num[sct_idx, rec_cnt] = num;
                        sector_rec_num[sct_idx]++;

                        for (int i = 0, j = 9; i < num; i++, j += 2)
                        {
                            sector_send_data_buf[sct_idx, (off + i)] = (byte)HexStringToInt32(recode.Substring(j, 2));
                        }

                        off += num;
                        sector_data_size[sct_idx] += num;
                        rec_cnt++;

                        break;

                    // �g�����j�A�A�h���X 
                    case 4:
                        sct_idx++;
                        off = 0;
                        rec_cnt = 0;
                        sector_addr[sct_idx, 0] = (byte)HexStringToInt32(recode.Substring(9, 2));
                        sector_addr[sct_idx, 1] = (byte)HexStringToInt32(recode.Substring(11, 2));
                        break;
                    default:
                        break;
                }
            }
            sector_num = (byte)(sct_idx + 1);

            for (int i = 0; i < sector_num; i++)
            {
                total_data_size += sector_data_size[i];
            }
        }

        /// <summary>
        /// �g�d�w�R�[�h������
        /// </summary>
        private bool WriteHexFile()
        {
            byte[] payload = new byte[send_block_size + 5];

            DataMsg = new DataProgressDialog();
            DataMsg.Maximum = sector_num;
            DataMsg.Start(UserText.UpgradeFirmwareUpdating, this.Location, this.ClientSize, false);

            for (int idx = 0; idx < sector_num; idx++)
            {
                // �Z�N�^�[�C���[�X�v�� 
                payload[0] = sector_addr[idx, 0];
                payload[1] = sector_addr[idx, 1];
                payload[2] = 0;
                payload[3] = 0;
                payload[4] = 0;

				if (!CCommandTx.RequestFlashRZT1Command('E', payload))
				{
					return false;
				}

                // �f�[�^�������� 
                int data_pos = 0;
                int rec_cnt = 0;
                int off_addr = sector_data_low_addr[idx, 0];
                int send_size = send_block_size;
                int sct_size = sector_data_size[idx];

                while (sct_size != 0)
                {
                    payload[0] = sector_addr[idx, 0];
                    payload[1] = sector_addr[idx, 1];
                    payload[2] = (byte)((off_addr & 0xff00) >> 8);
                    payload[3] = (byte)(off_addr & 0x00ff);

                    // send_block_size���ŘA��������T�C�Y���v�Z����
                    int wrsz = 0;
                    int cnt = 0;
                    for (cnt = rec_cnt; cnt < sector_rec_num[idx]; cnt++)
                    {
                        if (cnt != rec_cnt)
                        {
                            int addr = sector_data_low_addr[idx, (cnt - 1)] + sector_data_num[idx, (cnt - 1)];
                            if (addr != sector_data_low_addr[idx, cnt]) 
                                break;  // �A���f�[�^�ł͖���
                        }

                        if (send_block_size < wrsz + sector_data_num[idx, cnt]) 
                            break; //�A���������݃T�C�Y���z����
                        
                        wrsz += sector_data_num[idx, cnt];
                    }

                    if (rec_cnt == cnt)
                        rec_cnt++;
                    else
                        rec_cnt = cnt;

                    if (sct_size > wrsz)
                    {
                        payload[4] = (byte)wrsz;
                        sct_size -= wrsz;
                    }
                    else
                    {
                        payload[4] = (byte)sct_size;
                        sct_size = 0;
                    }

                    for (int i = 0; i < payload[4]; i++)
                    {
                        payload[5 + i] = sector_send_data_buf[idx, (data_pos + i)];
                    }

                    if (!CCommandTx.RequestFlashRZT1Command('W', payload)) return false;

                    data_pos += payload[4];
                    off_addr = sector_data_low_addr[idx, rec_cnt];
                }

                DataMsg.PerformStep();
            }

            Thread.Sleep(500);
            DataMsg.Close();

            return true;
        }

        /// <summary>
        /// �h���C�o����g�d�w�R�[�h��ǂݍ��݁A���M�o�b�t�@�ƃR���y�A
        /// </summary>
        private bool VerifyUpdate()
        {
            byte[] payload = new byte[send_block_size + 5];

            DataMsg = new DataProgressDialog();
            DataMsg.Maximum = sector_num;
            DataMsg.Start(UserText.UpgradeFirmwareVerify, this.Location, this.ClientSize, false);

            for (int idx = 0; idx < sector_num; idx++)
            {
                // �f�[�^�ǂݍ��� 
                int data_pos = 0;
                int rec_cnt = new int();
                int off_addr = sector_data_low_addr[idx, 0];
                int send_size = send_block_size;
                int sct_size = sector_data_size[idx];

                while (sct_size != 0)
                {
                    payload[0] = sector_addr[idx, 0];
                    payload[1] = sector_addr[idx, 1];
                    payload[2] = (byte)((off_addr & 0xff00) >> 8);
                    payload[3] = (byte)(off_addr & 0x00ff);

                    // send_block_size���ŘA��������T�C�Y���v�Z����
                    int wrsz = 0;
                    int addr = 0;
                    int cnt = 0;
                    for (cnt = rec_cnt; cnt < sector_rec_num[idx]; cnt++)
                    {
                        if (cnt != rec_cnt)
                        {
                            addr = sector_data_low_addr[idx, (cnt - 1)] + sector_data_num[idx, (cnt - 1)];
                            if (addr != sector_data_low_addr[idx, cnt])
                                break;  // �A���f�[�^�ł͖���
                        }

                        if (send_block_size < wrsz + sector_data_num[idx, cnt])
                            break; //�A���������݃T�C�Y���z����

                        wrsz += sector_data_num[idx, cnt];
                    }

                    if (rec_cnt == cnt)
                    {
                        rec_cnt++;
                    }
                    else
                    {
                        rec_cnt = cnt;
                    }

                    if (sct_size > wrsz)
                    {
                        payload[4] = (byte)wrsz;
                        sct_size -= wrsz;
                    }
                    else
                    {
                        payload[4] = (byte)sct_size;
                        sct_size = 0;
                    }

					if (!CCommandTx.RequestFlashRZT1Command('V', payload))
					{
						return false;
					}

                    // ��M�f�[�^���o�b�t�@�֊i�[
                    for (int i = 0; i < payload[4]; i++)
                    {
						if (sector_send_data_buf[idx, (data_pos + i)] != payload[5 + i])
						{
							return false;
						}
                    }

                    data_pos += payload[4];
                    off_addr = sector_data_low_addr[idx, rec_cnt];
                }

                DataMsg.PerformStep();
            }

            Thread.Sleep(500);

            DataMsg.Close();
            this.Cursor = Cursors.Default;

            return true;
        }

        /// <summary>
        /// 16�i���ŋL�q����Ă��镶����𐔒l�ɕϊ�����B
        /// </summary>
        /// <param name="hexString">16�i���ŋL�q����Ă��镶����B</param>
        private int HexStringToInt32(string hexString)
        {
            return Int32.Parse(hexString, System.Globalization.NumberStyles.HexNumber);
        }

        /// <summary>
        /// ���b�Z�[�W�\��
        /// </summary>
        /// <param name="msg"></param>
        private void ViewResultMessage(string msg)
        {
            rtxtResult.AppendText(msg + Environment.NewLine);
            rtxtResult.Refresh();
        }

        #endregion
        //20220106 Ver1.31 add �� 
    }
}