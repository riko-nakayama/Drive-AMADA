using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Motion_Designer
{
	public partial class DebugMonitorForm : Form
	{
		private const int VAR_NAME_CLM  = 0;
		private const int VAR_VALUE_CLM = 1;
		private const int VAR_TYPE_CLM  = 2;
		private const int VAR_VIEW_CLM  = 3;
		private const int VAR_ADDR_CLM  = 4;
		private const int VAR_CMMT_CLM = 5;

		static private DebugMonitorForm _ThisForm;

		private bool _IsExist = new bool();

		private List<DebugInfo> listDebug = new List<DebugInfo>();

		private DataProgressDialog DataMsg = new DataProgressDialog();

		private string FileOpenInitialDirectory = string.Empty;
		private string FileSaveInitialDirectory = string.Empty;

		private bool DisabelRamRead = new bool();

		public DebugMonitorForm()
		{
			InitializeComponent();


			_ThisForm = this;
			_IsExist = true;
		}

		static public DebugMonitorForm ThisForm
		{
			get { return _ThisForm; }
		}

		public bool IsExist
		{
			get { return _IsExist; }
		}

		private byte GetVarType(string str)
		{
			byte type = new byte();

			if (str.Contains("char") || str.Contains("byte"))
			{
				type = 0x01;
			}
			else if (str.Contains("short"))
			{
				type = 0x02;
			}
			else if (str.Contains("int64") || str.Contains("long long"))
			{
				type = 0x08;
			}
			else if (str.Contains("long") || str.Contains("int") || str.Contains("bool"))
			{
				type = 0x04;
			}
			else if (str.Contains("float"))
			{
				type = 0x84;
			}
			else if (str.Contains("double"))
			{
				type = 0x88;
			}
			else
			{
				type = 0x00;
			}

			return type;
		}

		public void ReadRam()
		{
			if (DisabelRamRead) { return; }

			int s = dgvDebug.FirstDisplayedScrollingRowIndex;
			int r = dgvDebug.DisplayedRowCount(false);

			int addr = new int();
			byte type = new byte();
			byte[] value = new byte[8];

			if (r > 0)
			{
				if (slblBlink.BackColor == Color.LimeGreen)
				{
					slblBlink.BackColor = SystemColors.Control;
				}
				else
				{
					slblBlink.BackColor = Color.LimeGreen;
				}
			}

			if (s < 0) { s = 0; }

			r = s + r;

			for (int i = s; i < r; i++)
			{
				if (dgvDebug.Rows[i].Cells[VAR_ADDR_CLM].Value == null) { return; }

				if (CDataTool.HexStringToInt32(dgvDebug.Rows[i].Cells[VAR_ADDR_CLM].Value.ToString(), ref addr))
				{
					string str = dgvDebug.Rows[i].Cells[VAR_TYPE_CLM].Value.ToString();

					type = GetVarType(str);

					if (type != 0)
					{
						CCommandTx.ReadRam(addr, type, ref value);

						switch (type)
						{
							case 0x01:
								
								if (dgvDebug.Rows[i].Cells[VAR_VIEW_CLM].Value.ToString() == "dec")
								{
									dgvDebug.Rows[i].Cells[VAR_VALUE_CLM].Value = value[0].ToString();
								}
								else
								{
									dgvDebug.Rows[i].Cells[VAR_VALUE_CLM].Value = "0x" + value[0].ToString("X");
								}
								break;

							case 0x02:
								
								if (dgvDebug.Rows[i].Cells[VAR_VIEW_CLM].Value.ToString() == "dec")
								{
									dgvDebug.Rows[i].Cells[VAR_VALUE_CLM].Value = BitConverter.ToInt16(value, 0);
								}
								else
								{
									dgvDebug.Rows[i].Cells[VAR_VALUE_CLM].Value = "0x" + BitConverter.ToInt16(value, 0).ToString("X");
								}
								break;

							case 0x04:
								if (dgvDebug.Rows[i].Cells[VAR_VIEW_CLM].Value.ToString() == "dec" )
								{
								    dgvDebug.Rows[i].Cells[VAR_VALUE_CLM].Value = BitConverter.ToInt32(value, 0);
								}
								else
								{
								    dgvDebug.Rows[i].Cells[VAR_VALUE_CLM].Value = "0x" + BitConverter.ToInt32(value, 0).ToString("X");
								}
								break;

							case 0x08:
								
								if (dgvDebug.Rows[i].Cells[VAR_VIEW_CLM].Value.ToString() == "dec")
								{
									dgvDebug.Rows[i].Cells[VAR_VALUE_CLM].Value = BitConverter.ToInt64(value, 0);
								}
								else
								{
									dgvDebug.Rows[i].Cells[VAR_VALUE_CLM].Value = "0x" + BitConverter.ToInt64(value, 0).ToString("X");
								}
								break;

							case 0x84:
								
								dgvDebug.Rows[i].Cells[VAR_VALUE_CLM].Value = BitConverter.ToSingle(value, 0);
								break;

							case 0x88:
								
								dgvDebug.Rows[i].Cells[VAR_VALUE_CLM].Value = BitConverter.ToDouble(value, 0);
								break;

							default:
								
								dgvDebug.Rows[i].Cells[VAR_VALUE_CLM].Value = "?";
								break;
						}
					}

					dgvDebug.Rows[i].Cells[VAR_VALUE_CLM].Style.Font = AppFont.MeiryoRegular9;
					dgvDebug.Rows[i].Cells[VAR_VALUE_CLM].Style.ForeColor = Color.Black;

				}
			}
		}

		private void WriteRam(int row, bool hex)
		{
			int    addr = new int();
			byte   type = new byte();
			string str  = string.Empty;
			string val  = string.Empty;
			string view = string.Empty;

			CDataTool.HexStringToInt32(dgvDebug[VAR_ADDR_CLM, row].Value.ToString(), ref addr);
			
			str  = dgvDebug[VAR_TYPE_CLM, row].Value.ToString();
			
			type = GetVarType(str);

			val  = dgvDebug[VAR_VALUE_CLM, row].Value.ToString();

			view = dgvDebug[VAR_VIEW_CLM, row].Value.ToString();


			byte[] value  = new byte[8];
			long   valueL = new long();
			float  valueF = new float();
			double valueD = new double();

			switch (type)
			{
				case 0x01:
				case 0x02:
				case 0x04:
				case 0x08:

					if (view == "hex")
					{
						CDataTool.HexStringToInt64(val, ref valueL);
					}
					else
					{
						valueL = Convert.ToInt64(val);
					}

					value[0] = (byte)((valueL      ) & 0xFF);
					value[1] = (byte)((valueL >>  8) & 0xFF);
					value[2] = (byte)((valueL >> 16) & 0xFF);
					value[3] = (byte)((valueL >> 24) & 0xFF);
					value[4] = (byte)((valueL >> 32) & 0xFF);
					value[5] = (byte)((valueL >> 40) & 0xFF);
					value[6] = (byte)((valueL >> 48) & 0xFF);
					value[7] = (byte)((valueL >> 56) & 0xFF);
					break;

				case 0x84:

					valueF = Convert.ToSingle(val);
					value = BitConverter.GetBytes(valueF);
					break;

				case 0x88:

					valueD = Convert.ToDouble(val);
					value = BitConverter.GetBytes(valueD);
					break;

			}

			slblWrite.BackColor = Color.Orange;

			CCommandTx.WriteRam(addr, type, value, value.Length);

		}

		private void btnLogFileRead_Click(object sender, EventArgs e)
		{
			

		}

		private void InitProgressBar(string msg, int max)
		{
			DataMsg = new DataProgressDialog();
			DataMsg.Maximum = max;
			DataMsg.Start(msg, this.Location, this.ClientSize, false);
		}

		private void tcmbDebug_DropDown(object sender, EventArgs e)
		{
			//for( int i = 0; i < listDebug.Count; i++ )
			//{
			//    tcmbDebug.Items.Add(listDebug[i].name);
			//}
		}

		private void tcmbDebug_SelectedIndexChanged(object sender, EventArgs e)
		{
			dgvDebug.Select();
		}

		private void tbtnLogRead_Click(object sender, EventArgs e)
		{
			try
			{
				OpenLogDialog.Filter = "Driver Debug File (*.log)|*.log";

				//初期フォルダを設定する
				if (FileOpenInitialDirectory == "")
				{
					OpenLogDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
				}
				else
				{
					try
					{
						OpenLogDialog.InitialDirectory = FileOpenInitialDirectory;
					}
					catch
					{
						OpenLogDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
					}
				}

				ChildFormControl.SetOpacity(0.0);

				DialogResult ret = OpenLogDialog.ShowDialog();

				ChildFormControl.SetOpacity(1.0);

				if (ret == DialogResult.OK)
				{
					FileOpenInitialDirectory = System.IO.Path.GetDirectoryName(OpenLogDialog.FileName);

					this.Refresh();

					this.Cursor = Cursors.WaitCursor;

					System.IO.StreamReader file = new System.IO.StreamReader(OpenLogDialog.FileName);

					string[] tmp_lin, tmp_tab;

					//1行空読み（項目）
					file.ReadLine();

					tmp_lin = file.ReadToEnd().Split('\n');

					InitProgressBar(UserText.AutoTuningFileRead, tmp_lin.Length - 1);

					int addr_int = new int();
					int addr_old = new int();
					string st_name1 = string.Empty;
					string st_name2 = string.Empty;
					string arr_name = string.Empty;

					for (int i = 0; i < tmp_lin.Length - 1; i++)
					{
						//キャリッジリターン削除
						if (tmp_lin[i].Contains("\r") == true)
						{
							tmp_lin[i] = tmp_lin[i].TrimEnd('\r');
						}

						tmp_tab = tmp_lin[i].Split('\t');

						if (tmp_tab[1].Contains("struct"))
						{
							if (st_name1 == "")
							{
								st_name1 = tmp_tab[0] + ".";
							}
							else
							{
								st_name2 = "";
								//st_name2 = tmp_tab[0] + ".";
							}

							if (CDataTool.HexStringToInt32(tmp_tab[2], ref addr_int))
							{
								addr_old = addr_int;
							}
						}
						else if (tmp_tab[1].Contains("array"))
						{
							arr_name = tmp_tab[0];
						}
						else
						{
							DebugInfo dbgInfo = new DebugInfo();

							if( tmp_tab[0].Contains("[") && tmp_tab[0].Contains("]") )
							{
								dbgInfo.name = st_name1 + st_name2  +arr_name + tmp_tab[0];
							}
							else
							{
								dbgInfo.name = st_name1 + st_name2 + tmp_tab[0];
							}

							dbgInfo.type = tmp_tab[3];

							if (CDataTool.HexStringToInt32(tmp_tab[2], ref addr_int))
							{
								dbgInfo.addr = tmp_tab[2];

								dbgInfo.addr_int = addr_int;

								if (Math.Abs(addr_int - addr_old) > 8 && i != 0)
								{
									//構造体終了
									dbgInfo.name = tmp_tab[0];
									st_name1 = "";
									st_name2 = "";
								}

								//if (listDebug.Contains(dbgInfo) == false)
								//{
								//    listDebug.Add(dbgInfo);
								//    tcmbDebug.Items.Add(listDebug[listDebug.Count - 1].name);
								//}

								bool exists = false;

								for (int j = 0; j < listDebug.Count; j++)
								{
									if (listDebug[j].name == dbgInfo.name)
									{
										exists = true;
									}
								}

								if (exists == false)
								{
									listDebug.Add(dbgInfo);
									tcmbDebug.Items.Add(listDebug[listDebug.Count - 1].name);
								}

								addr_old = addr_int;
							}
						}

						DataMsg.PerformStep();

					}

					if (tcmbDebug.Text == "")
					{
						tcmbDebug.Text = tcmbDebug.Items[0].ToString();
					}

					file.Close();

					Thread.Sleep(500);

					DataMsg.Close();

					this.Cursor = Cursors.Default;
				}
			}
			catch
			{
				//File format error
				DataMsg.Close();

				this.Cursor = Cursors.Default;

				UserMessageBox.CommonFileFormatError();
			}
		}

		private void tbtnVarAdd_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < listDebug.Count; i++)
			{
				if (tcmbDebug.Text == listDebug[i].name)
				{
					bool exist = false;

					for (int j = 0; j < dgvDebug.Rows.Count; j++)
					{
						if (dgvDebug.Rows[j].Cells[VAR_NAME_CLM].Value.ToString() == listDebug[i].name)
						{
							exist = true;
						}
					}

					if (exist == false)
					{
						dgvDebug.Rows.Add();

						int r = dgvDebug.Rows.Count - 1;

						dgvDebug.Rows[r].Cells[VAR_NAME_CLM].Value  = listDebug[i].name;
						dgvDebug.Rows[r].Cells[VAR_VALUE_CLM].Value = "0";
						dgvDebug.Rows[r].Cells[VAR_TYPE_CLM].Value  = listDebug[i].type;
						dgvDebug.Rows[r].Cells[VAR_VIEW_CLM].Value  = "dec";

						if (listDebug[i].type == "float" || listDebug[i].type == "double")
						{
							dgvDebug.Rows[r].Cells[VAR_VIEW_CLM] = new DataGridViewTextBoxCell();
							dgvDebug.Rows[r].Cells[VAR_VIEW_CLM].Value = "";
							dgvDebug.Rows[r].Cells[VAR_VIEW_CLM].ReadOnly = true;
						}

						dgvDebug.Rows[r].Cells[VAR_ADDR_CLM].Value  = listDebug[i].addr;
					}
				}
			}
		}


		private void tbtnAllAdd_Click(object sender, EventArgs e)
		{
			//listDebug.Clear();
			//dgvDebug.Rows.Clear();

			for (int c = 0; c < tcmbDebug.Items.Count; c++)
			{
				for (int i = 0; i < listDebug.Count; i++)
				{
					if (tcmbDebug.Items[c].ToString() == listDebug[i].name)
					{
						bool exist = false;

						for (int j = 0; j < dgvDebug.Rows.Count; j++)
						{
							if (dgvDebug.Rows[j].Cells[VAR_NAME_CLM].Value.ToString() == listDebug[i].name)
							{
								exist = true;
							}
						}

						if (exist == false)
						{
							dgvDebug.Rows.Add();

							int r = dgvDebug.Rows.Count - 1;

							dgvDebug.Rows[r].Cells[VAR_NAME_CLM].Value = listDebug[i].name;
							dgvDebug.Rows[r].Cells[VAR_VALUE_CLM].Value = "0";
							dgvDebug.Rows[r].Cells[VAR_TYPE_CLM].Value = listDebug[i].type;
							dgvDebug.Rows[r].Cells[VAR_VIEW_CLM].Value = "dec";

							if (listDebug[i].type == "float" || listDebug[i].type == "double")
							{
								dgvDebug.Rows[r].Cells[VAR_VIEW_CLM] = new DataGridViewTextBoxCell();
								dgvDebug.Rows[r].Cells[VAR_VIEW_CLM].Value = "";
								dgvDebug.Rows[r].Cells[VAR_VIEW_CLM].ReadOnly = true;
							}

							dgvDebug.Rows[r].Cells[VAR_ADDR_CLM].Value = listDebug[i].addr;
						}
					}
				}
			}
		}


		private string BackupText = string.Empty;
		private int BackupRowNo = new int();
		private int BackupCulmnNo = new int();

		private DataGridViewCell BackupCell;

		private void dgvDebug_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			DataGridView dg = dgvDebug;

			if (dg.CurrentCell != null)
			{

				if (dg.CurrentCell.ColumnIndex != VAR_VALUE_CLM)
				{
					//変更データ行以外なら何もしない。
					return;
				}

				BackupText = dg.CurrentCell.Value.ToString();
				BackupRowNo = dg.CurrentRow.Index;
				BackupCulmnNo = dg.CurrentCell.ColumnIndex;
				BackupCell = dg.CurrentCell;

				if (dg.CurrentCell is DataGridViewComboBoxCell)
				{
					return;
				}

				dg.CurrentCell.Style.ForeColor = Color.Red;
				dg.CurrentCell.Style.Font = AppFont.MeiryoBold9;
			}
		}

		private void dgvDebug_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView dg = dgvDebug;

			try
			{
				if (dg.CurrentCell.Value != null)
				{
					int row = dg.CurrentCell.RowIndex;
					string val = dg.CurrentCell.Value.ToString();
						
					if (dg.CurrentCell.ColumnIndex == VAR_VIEW_CLM)
					{
						int dec = 0;
						string now_val = dg[VAR_VALUE_CLM, row].Value.ToString();
					
						//データ表示列コンボボックス変更
						if (val == "dec")
						{
							//16進表示から10進表示へ変換
							if (CDataTool.IsHexNumeric32(now_val))
							{
								CDataTool.HexStringToInt32(now_val, ref dec);
								dg[VAR_VALUE_CLM, row].Value = dec.ToString();
							}
						}
						else if (val == "hex")
						{
							//10進表示から16進表示へ変換
							if (CDataTool.IsSignedNumeric32(now_val))
							{
								dg[VAR_VALUE_CLM, row].Value = "0x" + Convert.ToInt32(now_val).ToString("X");
							}
						}

						return;
					}

					if (dg.CurrentCell.ColumnIndex != VAR_VALUE_CLM)
					{
						//変更データ以外の行なら何もしない
						return;
					}

					if (val == BackupText)
					{
						//編集前と同じデータ
						dg.CurrentCell.Value = BackupText;
						dg.CurrentCell.Style.Font = AppFont.MeiryoRegular9;
						dg.CurrentCell.Style.ForeColor = Color.Black;
						return;
					}

					if (dg[VAR_VIEW_CLM, row].Value.ToString() == "dec")
					{
						//10進表示
						if (CDataTool.IsSignedNumeric32(val) == false)
						{
							//変更データ入力エラー
							UserMessageBox.ParameterInputDataError();

							dg.CurrentCell.Value = BackupText;
						}
						else
						{
							//入力データ正常
							WriteRam(row, false);
						}
					}
					else if (dg[VAR_VIEW_CLM, dg.CurrentRow.Index].Value.ToString() == "hex")
					{
						//16進表示
						if (CDataTool.IsHexNumeric32_Head(val) == false)
						{
							//変更データ入力エラー
							UserMessageBox.ParameterInputDataError();

							dg.CurrentCell.Value = BackupText;
						}
						else
						{
							//入力データ正常
							WriteRam(row, false);
						}
					}
					else
					{
						//float, double
						if (CDataTool.IsRealNumeric(val) == false)
						{
							//変更データ入力エラー
							UserMessageBox.ParameterInputDataError();

							dg.CurrentCell.Value = BackupText;
						}
						else
						{
							//入力データ正常
							WriteRam(row, false);
						}
					}

					dg.CurrentCell.Style.Font = AppFont.MeiryoRegular9;
					dg.CurrentCell.Style.ForeColor = Color.Black;
				}
			}
			catch
			{
				UserMessageBox.ParameterInputDataError();

				if (!String.IsNullOrEmpty(BackupText))
				{
					dg.Rows[BackupRowNo].Cells[BackupCulmnNo].Value = BackupText;
				}
				else
				{
					dg.Rows[BackupRowNo].Cells[BackupCulmnNo].Value = "0";
				}
				dg.Rows[BackupRowNo].Cells[BackupCulmnNo].Style.ForeColor = Color.Black;
				dg.Rows[BackupRowNo].Cells[BackupCulmnNo].Style.Font = AppFont.MeiryoRegular9;

				return;
			}
		}

		private void dgvDebug_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{

			DataGridView dg = dgvDebug;

			if (dg.CurrentCell != null)
			{
				DataGridViewDataErrorContexts cntex = new DataGridViewDataErrorContexts();

				if (dg.CurrentCell.ColumnIndex == VAR_VIEW_CLM)
				{
					dg.EndEdit(cntex);
				}

				if (dg.CurrentCell.ColumnIndex == VAR_VALUE_CLM)
				{
					//dg.EndEdit(cntex);
				}
			}
		}

		private void dgvDebug_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			DataGridView dg = dgvDebug;

			if (dg.CurrentCell != null)
			{
				if (e.KeyData == Keys.Delete)
				{
					dg.Rows.RemoveAt(dg.CurrentRow.Index);
				}
			
			}
		}

		private void tbtnFileSave_Click(object sender, EventArgs e)
		{
			try
			{
				SaveFileDialog.FileName = "debug";
				SaveFileDialog.Filter = "Debug File (*.dbg)|*.dbg";

				//初期フォルダを設定する
				if (FileSaveInitialDirectory == "")
				{
					SaveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
				}
				else
				{
					try
					{
						SaveFileDialog.InitialDirectory = FileSaveInitialDirectory;
					}
					catch
					{
						SaveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
					}
				}

				ChildFormControl.SetOpacity(0.0);

				DialogResult ret = SaveFileDialog.ShowDialog();

				ChildFormControl.SetOpacity(1.0);

				//保存ダイアログを設定する
				if (ret == DialogResult.OK)
				{
					FileSaveInitialDirectory = System.IO.Path.GetDirectoryName(SaveFileDialog.FileName);

					this.Cursor = Cursors.WaitCursor;
					System.IO.StreamWriter file;

					file = new System.IO.StreamWriter(SaveFileDialog.FileName, false, System.Text.Encoding.Unicode);

					//保存ダイアログの画面が残るのでメインを再描画
					this.Refresh();

					InitProgressBar(UserText.ParameterFileSave, dgvDebug.Rows.Count);

					for (int i = 0; i < dgvDebug.RowCount; i++)
					{
						for (int j = 0; j < dgvDebug.ColumnCount; j++)
						{
							if (j == VAR_VIEW_CLM)
							{
								if (dgvDebug.Rows[i].Cells[j].Value == null)
								{
									//float, double
									file.Write("real" + "\t");
								}
								else
								{
									if (dgvDebug.Rows[i].Cells[VAR_VIEW_CLM].Value.ToString() == "float" ||
										dgvDebug.Rows[i].Cells[VAR_VIEW_CLM].Value.ToString() == "double")
									{
										//float, double
										file.Write("real" + "\t");
									}
									else
									{
										file.Write(dgvDebug.Rows[i].Cells[j].Value + "\t");
									}
								}
							}
							else
							{
								file.Write(dgvDebug.Rows[i].Cells[j].Value + "\t");
							}
						}

						file.Write("\r" + "\n");

						DataMsg.PerformStep();
					}

					file.Close();

					Thread.Sleep(500);

					DataMsg.Close();

					this.Cursor = Cursors.Default;
				}

			}
			catch
			{
				//File Format Error
				DataMsg.Close();

				this.Cursor = Cursors.Default;

				UserMessageBox.CommonFileFormatError();
			}

		}

		private void tbtnFileOpen_Click(object sender, EventArgs e)
		{
			try
			{
				OpenFileDialog.Filter = "Debug File (*.dbg)|*.dbg";

				//初期フォルダを設定する
				if (FileOpenInitialDirectory == "")
				{
					OpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
				}
				else
				{
					try
					{
						OpenFileDialog.InitialDirectory = FileOpenInitialDirectory;
					}
					catch
					{
						OpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
					}
				}

				ChildFormControl.SetOpacity(0.0);

				DialogResult ret = OpenFileDialog.ShowDialog();

				ChildFormControl.SetOpacity(1.0);

				if (ret == DialogResult.OK)
				{
					DisabelRamRead = true;

					FileOpenInitialDirectory = System.IO.Path.GetDirectoryName(OpenFileDialog.FileName);

					this.Refresh();

					this.Cursor = Cursors.WaitCursor;

					System.IO.StreamReader file = new System.IO.StreamReader(OpenFileDialog.FileName);

					string[] tmp_lin, tmp_tab;

					tmp_lin = file.ReadToEnd().Split('\n');

					dgvDebug.Rows.Clear();

					InitProgressBar(UserText.ParameterFileRead, tmp_lin.Length - 1);

					for (int i = 0, r = 0; i < tmp_lin.Length - 1; i++)
					{
						//キャリッジリターン削除
						if (tmp_lin[i].Contains("\r") == true)
						{
							tmp_lin[i] = tmp_lin[i].TrimEnd('\r');
						}

						tmp_tab = tmp_lin[i].Split('\t');

						if (tmp_tab.Length < VAR_CMMT_CLM) { continue; }

						dgvDebug.Rows.Add();

						dgvDebug.Rows[r].Cells[VAR_NAME_CLM].Value = tmp_tab[0];
						dgvDebug.Rows[r].Cells[VAR_VALUE_CLM].Value = tmp_tab[1];
						dgvDebug.Rows[r].Cells[VAR_TYPE_CLM].Value = tmp_tab[2];

						if (tmp_tab[3] == "hex" || tmp_tab[3] == "dec")
						{
							dgvDebug.Rows[r].Cells[VAR_VIEW_CLM].Value = tmp_tab[3];
						}
						else
						{
							dgvDebug.Rows[r].Cells[VAR_VIEW_CLM] = new DataGridViewTextBoxCell();
							dgvDebug.Rows[r].Cells[VAR_VIEW_CLM].ReadOnly = true;
							dgvDebug.Rows[r].Cells[VAR_VIEW_CLM].Value = "";
						}

						dgvDebug.Rows[r].Cells[VAR_ADDR_CLM].Value = tmp_tab[4];
						dgvDebug.Rows[r].Cells[VAR_CMMT_CLM].Value = tmp_tab[5];

						r++;
						
						DataMsg.PerformStep();

					}

					file.Close();

					Thread.Sleep(500);

					DataMsg.Close();

					this.Cursor = Cursors.Default;

					DisabelRamRead = false;
				}
			}
			catch
			{
				//File format error
				DataMsg.Close();

				this.Cursor = Cursors.Default;

				UserMessageBox.CommonFileFormatError();

				DisabelRamRead = false;
			}
		}

		private void TimerDebug_Tick(object sender, EventArgs e)
		{
			if (!MainForm.IsUsbConnect || dgvDebug.Rows.Count <= 0)
			{
				slblBlink.BackColor = SystemColors.Control;
			}

			if (slblWrite.BackColor == Color.Orange)
			{
				slblWrite.BackColor = SystemColors.Control;
			}
		}

		private void tbtnDel_Click(object sender, EventArgs e)
		{
			if (dgvDebug.CurrentRow == null) { return; }

			int row = dgvDebug.CurrentRow.Index;

			dgvDebug.Rows.RemoveAt(row);
		}

		private void tbtnUp_Click(object sender, EventArgs e)
		{
			if (dgvDebug.CurrentRow == null) { return; }

			int r1 = dgvDebug.CurrentRow.Index;
			int r2 = dgvDebug.CurrentRow.Index;
			int c1 = dgvDebug.CurrentCell.ColumnIndex;

			DataGridViewRow dg_row = (DataGridViewRow)dgvDebug.Rows[r1].Clone();

			if (--r2 < 0) { r2 = 0; }

			dgvDebug.Rows.InsertRange(r2, dg_row);

			if (++r1 >= dgvDebug.Rows.Count) { r1 = dgvDebug.Rows.Count - 1; }

			for (int i = 0; i < dgvDebug.ColumnCount; i++)
			{
				dgvDebug.Rows[r2].Cells[i].Value = dgvDebug.Rows[r1].Cells[i].Value;
			}

			dgvDebug.Rows.RemoveAt(r1);

			dgvDebug[c1, r2].Selected = true;

		}

		private void tbtnDown_Click(object sender, EventArgs e)
		{
			if (dgvDebug.CurrentRow == null) { return; }

			int r1 = dgvDebug.CurrentRow.Index;
			int r2 = dgvDebug.CurrentRow.Index;
			int c1 = dgvDebug.CurrentCell.ColumnIndex;

			DataGridViewRow dg_row = (DataGridViewRow)dgvDebug.Rows[r1].Clone();

			if (++r2 >= dgvDebug.Rows.Count) { r2 = dgvDebug.Rows.Count; }
			if (++r2 >= dgvDebug.Rows.Count) { r2 = dgvDebug.Rows.Count; }
			
			dgvDebug.Rows.InsertRange(r2, dg_row);
			
			for (int i = 0; i < dgvDebug.ColumnCount; i++)
			{
				dgvDebug.Rows[r2].Cells[i].Value = dgvDebug.Rows[r1].Cells[i].Value;
			}

			dgvDebug.Rows.RemoveAt(r1);

			if (--r2 < 0) { r2 = 0; }

			dgvDebug[c1, r2].Selected = true;

		}

		private void DebugMonitorForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			_IsExist = false;
		}
	}

	public class DebugInfo
	{
		public string name;
		public string type;
		public string addr;
		public int addr_int;
	}
}