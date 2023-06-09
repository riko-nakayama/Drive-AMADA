using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace Motion_Designer
{
	public partial class DigitalOsilloForm : Form
	{
		static private Point FormPosition = new Point(0, 0);
		static private Size FormSize = new Size(480, 480);

		static private DigitalOsilloForm _ThisForm;

		private const int SVON_BIT = 0x01;
		private const int INPOS_BIT = 0x04;

        private const int ALM_BIT = 0x08;   // Ver1.32 add

		private const int CMDPOS_BIT = 0x02;
		private const int CMD_BIT = 0x40000000;

		private const int TRACK_SCALE = 10;
		private const int TRACK_LARGE_CHANGE = 50;

		private int LogPtr = new int();

		private int TrgPtr1 = new int();
		private int TrgPtr2 = new int();
		private int TrgPtr3 = new int();						//20170927 add
		private int TrgCnt = new int();
		private int TrgStone = new int();

		private int PosSettingTime = new int();

		private int BackupLogLength = LogWork.LogLength;		//20170825 add

		private int[,] LogData = new int[LogWork.KindNum, LogWork.LogLength];
		private int[,] TrgData = new int[LogWork.KindNum, LogWork.LogLength];

		static private int[,] ExportLogData = new int[LogWork.KindNum, LogWork.LogLength];
		static private int ExportLogPtr = new int();

		private bool DisableDraw = false;			//波形描画禁止フラグ
		private bool DisableTimeMeasDraw = false;	//時間計測描画禁止フラグ

		private bool _HoldEnabled = false;			//波形描画停止禁止フラグ（オートチューニング時）
	
		//ホイールイベント用変数
		private int OldDelta = new int();
		private bool ScaleX = new bool();
		private bool ScaleY = new bool();

		private float BK_Y_Div = new float();

		private bool[] BK_ChkAxis = new bool[2];
		private bool[] BK_ChkPos = new bool[2];
		private bool[] BK_DioVis = new bool[2];

		private bool IsMeas = new bool();
		private bool IsHold = new bool();
		private bool IsTrg = new bool();

		private DataProgressDialog DataMsg = new DataProgressDialog();
		private int MsgWait = 500;

		private LineStyleDialog LineDlg = new LineStyleDialog();

        private double[] fftIn = new double[FFT_C.FFT_max];
        private double[] fftOut = new double[FFT_C.FFT_max];
        
		private bool _EnableReadFFT = new bool();

		private bool DisableLogKindChange = new bool();
		private bool InitializingLogKind = new bool();		//20170928 add

		private enum TrgItemEnum
		{
			TRG_CMD,
			TRG_INPOS,
			TRG_VEL,
			TRG_CUR,
			TRG_ERR,
		}

        private double[] BackupTrgValue = new double[5];

		private TrgItemEnum TrgItem = new TrgItemEnum();
		private int TrgValue = new int();
		private bool TrgIsGE = new bool();

		private int ResizeHeight = new int();
		private int ResizeWidth = new int();

		private ViewMainForm ThisParentForm;
		private MdiClient ThisMdiClient;

		private bool _IsExist = new bool();

		private string DefaultCulture = Culture.Name;

        private bool bAutoStop = false; // Ver1.32 add

		// Ver1.35 add ↓↓↓
		// ログ分割機能
		private string LogFolder = string.Empty;
		public bool IsSplitLogSave = false;
		
		private string LogFile = string.Empty;
		private string[] bkFileList = null;
		private bool IsOver = false;
		private uint fileno = 0;
		// Ver1.35 add ↑↑↑

		public DigitalOsilloForm()
		{
			InitializeComponent();

			_ThisForm = this;
			_IsExist = true;

			ThisParentForm = ViewMainForm.ThisForm;

			ThisMdiClient = ViewMainForm.ThisForm.GetMdiClient();

			DisableDraw = true;

			try
			{
				this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.DigitalOsilloForm_MouseWheel);
				this.KeyPreview = true;

				InitAppParameter();		//20170125 add
		
			}
			catch (Exception ex)
			{
				UserMessageBox.CommonCatchErrorMessage(ex);
				return;
			}
		}

		public void InitAppParameter()
		{

			//グラフメモリスケール
			X_Div = Properties.Settings.Default.WAVE_XScale;
			Y_Div = Properties.Settings.Default.WAVE_YScale;
			BK_Y_Div = Y_Div;

			P_Div = Properties.Settings.Default.WAVE_P_Div;
			V_Div = Properties.Settings.Default.WAVE_V_Div;
			I_Div = Properties.Settings.Default.WAVE_I_Div;
			T_Div = Properties.Settings.Default.WAVE_T_DIV;

			Prm1_Div = Properties.Settings.Default.WAVE_Prm1_Div;
			Prm2_Div = Properties.Settings.Default.WAVE_Prm2_Div;
			Prm3_Div = Properties.Settings.Default.WAVE_Prm3_Div;

			P_Pos = Properties.Settings.Default.WAVE_P_Pos;
			V_Pos = Properties.Settings.Default.WAVE_V_Pos;
			I_Pos = Properties.Settings.Default.WAVE_I_Pos;
			Prm1_Pos = Properties.Settings.Default.WAVE_Prm1_Pos;
			Prm2_Pos = Properties.Settings.Default.WAVE_Prm2_Pos;
			Prm3_Pos = Properties.Settings.Default.WAVE_Prm3_Pos;

			P_Mul = Properties.Settings.Default.WAVE_P_Mul;
			V_Mul = Properties.Settings.Default.WAVE_V_Mul;
			I_Mul = Properties.Settings.Default.WAVE_I_Mul;
			Prm1_Mul = Properties.Settings.Default.WAVE_Prm1_Mul;
			Prm2_Mul = Properties.Settings.Default.WAVE_Prm2_Mul;
			Prm3_Mul = Properties.Settings.Default.WAVE_Prm3_Mul;

			numLogTime.Value = Properties.Settings.Default.LogTime;

			I_Scale = I_Div / 100.0F;

			InposOff = -Properties.Settings.Default.WAVE_InposOffset;
			CmdposOff = -Properties.Settings.Default.WAVE_CmdposOffset;

			//グラフ設定表示
			if (Properties.Settings.Default.WAVE_ItemY_L_View)
			{
				tbtnItemY_L.BackColor = SystemColors.Control;
			}
			else
			{
				tbtnItemY_L.BackColor = Color.Gold;
			}

			if (Properties.Settings.Default.WAVE_ItemY_R_View)
			{
				tbtnItemY_R.BackColor = SystemColors.Control;
			}
			else
			{
				tbtnItemY_R.BackColor = Color.Gold;
			}

			if (Properties.Settings.Default.WAVE_ViewSetting_View)
			{
				tbtnViewSetting.BackColor = SystemColors.Control;
			}
			else
			{
				tbtnViewSetting.BackColor = Color.Gold;
			}

			if (Properties.Settings.Default.WAVE_TrgEnable)
			{
				tbtnTrigger.BackColor = SystemColors.Control;
			}
			else
			{
				tbtnTrigger.BackColor = Color.Gold;
			}

			tbtnItemY_L.PerformClick();
			tbtnItemY_R.PerformClick();
			tbtnViewSetting.PerformClick();
			tbtnTrigger.PerformClick();

			cmbPerr.Text = P_Div.ToString();
			cmbVel.Text = V_Div.ToString();
			cmbCur.Text = I_Scale.ToString("F1");
			cmbCmdpos.Text = (-CmdposOff).ToString();
			cmbInpos.Text = (-InposOff).ToString();
			cmbScale.Text = T_Div.ToString();

			if (Properties.Settings.Default.WAVE_TrgPosition > 0)		//20170926 update
			{
				cmbTrg.Text = "+" + Properties.Settings.Default.WAVE_TrgPosition.ToString();
			}
			else
			{
				cmbTrg.Text = Properties.Settings.Default.WAVE_TrgPosition.ToString();
			}

			cmbPrm1.Text = Prm1_Div.ToString();
			cmbPrm2.Text = Prm2_Div.ToString();
			cmbPrm3.Text = Prm3_Div.ToString();

			//20170928 add start
			InitializingLogKind = true;

			if (Properties.Settings.Default.WAVE_Pos_Idx >= 0 && Properties.Settings.Default.WAVE_Pos_Idx < cmbLogPos.Items.Count) { cmbLogPos.SelectedIndex = Properties.Settings.Default.WAVE_Pos_Idx; }
			if (Properties.Settings.Default.WAVE_Vel_Idx >= 0 && Properties.Settings.Default.WAVE_Vel_Idx < cmbLogVel.Items.Count) { cmbLogVel.SelectedIndex = Properties.Settings.Default.WAVE_Vel_Idx; }
			if (Properties.Settings.Default.WAVE_Cur_Idx >= 0 && Properties.Settings.Default.WAVE_Cur_Idx < cmbLogCur.Items.Count) { cmbLogCur.SelectedIndex = Properties.Settings.Default.WAVE_Cur_Idx; }

			if (Properties.Settings.Default.WAVE_Prm1_Idx >= 0 && Properties.Settings.Default.WAVE_Prm1_Idx <= numLogPrm1.Maximum) { numLogPrm1.Value = Properties.Settings.Default.WAVE_Prm1_Idx; }
			if (Properties.Settings.Default.WAVE_Prm2_Idx >= 0 && Properties.Settings.Default.WAVE_Prm2_Idx <= numLogPrm2.Maximum) { numLogPrm2.Value = Properties.Settings.Default.WAVE_Prm2_Idx; }
			if (Properties.Settings.Default.WAVE_Prm3_Idx >= 0 && Properties.Settings.Default.WAVE_Prm3_Idx <= numLogPrm3.Maximum) { numLogPrm3.Value = Properties.Settings.Default.WAVE_Prm3_Idx; }

			InitializingLogKind = false;
			//20170928 add end

			//トリガ条件初期化
			cmbTrgCond_SelectedIndexChanged(null, null);

			//スクロールバーDisable
			hSclWave.Enabled = false;		//20170926 add 起動時の見た目改善

		}

		static public DigitalOsilloForm ThisForm
		{
			get { return _ThisForm; }
		}

		public void InitFormLayout()
		{
			if (ThisForm == null) { return; }

			int w = ThisMdiClient.ClientRectangle.Width;
			int h = ThisMdiClient.ClientRectangle.Height;

			ThisForm.Location = new Point(0, 0);
			ThisForm.Size = new Size(w, h);

			ThisForm.WindowState = FormWindowState.Normal;
		}

		public bool HoldEnabled
		{
			set
			{
				_HoldEnabled = value;

				if (!_HoldEnabled && IsHold)
				{
					HoldEvent();
				}

				tbtnHold.Enabled = value;
				tbtnOpen.Enabled = value;
				tbtnSave.Enabled = value;
			}

			get { return _HoldEnabled; }
		}

		public bool IsExist
		{
			set { _IsExist = value; }
			get { return _IsExist; }
		}

		// nakayama add amada
		// ↓↓↓ Ver1.3x add AMADA Inspection
		public void ViewSettingInspection()
		{
			if (IsTrg) { tbtnTrigger.PerformClick(); }  // トリガ有効なら解除

			if (IsHold) { tbtnHold.PerformClick(); }    // 波形描画停止なら解除

			X_Div = 0.1F;                               // 横軸縮小MAX

			chkPerr.Checked = true;                     // 全ての表示を有効
			chkVel.Checked = true;
			chkCur.Checked = true;
			chkPrm1.Checked = true;
			chkPrm2.Checked = true;
			chkPrm3.Checked = true;
			chkCmdpos.Checked = true;
			chkInpos.Checked = true;
			chkScale.Checked = true;

			cmbPerr.SelectedIndex = 11;                 // 10000pls
			cmbVel.SelectedIndex = 9;                   // 1000rpm
			cmbCur.SelectedIndex = 15;                  // 20A
			cmbPrm1.SelectedIndex = 3;                  // 10
			cmbPrm2.SelectedIndex = 3;                  // 10
			cmbPrm3.SelectedIndex = 3;                  // 10
			cmbCmdpos.SelectedIndex = 10;               // -5
			cmbInpos.SelectedIndex = 11;                // -6
			cmbScale.SelectedIndex = 8;                 // 500msec

			cmbLogPos.SelectedIndex = 0;                // 位置偏差
			cmbLogVel.SelectedIndex = 0;                // 現在速度
			cmbLogCur.SelectedIndex = 0;                // 現在電流

			numLogPrm1.Value = 430;                     // パラメタ1 ID
			numLogPrm2.Value = 446;                     // パラメタ2 ID
			numLogPrm3.Value = 496;                     // パラメタ3 ID

			numLogTime.Value = 1800;                    // ログ取得時間 1800秒（30分）

			cmbLogFFT.SelectedIndex = 0;                // FFT瞬時電流


			pnlBase.Focus();
		}

		public void SaveInspectionLogData(string path, string datetime)
		{
			try
			{
				//オシロ停止
				if (tbtnHold.BackColor == SystemColors.Control)
				{
					tbtnHold.PerformClick();
				}

				this.Cursor = Cursors.WaitCursor;

				System.IO.StreamWriter file = new System.IO.StreamWriter(path, false, System.Text.Encoding.Unicode);

				string major = Assembly.GetExecutingAssembly().GetName().Version.Major.ToString();
				string minor = Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString("D2");

				file.WriteLine("[Date]" + datetime);						    //SAVE時間を保存;
				file.WriteLine("[Version]" + major + "." + minor);              //バージョン情報保存
																				//file.WriteLine("[LogSpeed]" + ucmbVelUnit.Text.Trim());		//ログ周期情報保存
				file.WriteLine("[LogWork.LogLengthgth]" + LogWork.LogLength.ToString());                //ログデータ数を保存
				file.WriteLine("[LogData]");

				// Ver 1.33 Update
				//InitProgressBar(UserText.DigitalOsilloLogSave, LogWork.LogLength);
				InitProgressBar(UserText.DigitalOsilloLogSave, 1);

				//画面再描画
				this.Refresh();

				//項目出力
				for (int i = 0; i < LogWork.MonNum; i++)
				{
					string item = string.Empty;
					string sel = string.Empty;

					switch (i)
					{
						case 0:

							item = cmbLogPos.Text;
							sel = "(" + cmbLogPos.SelectedIndex.ToString() + ")";
							file.Write(item + sel + "\t");
							break;

						case 1:

							item = cmbLogVel.Text;
							sel = "(" + cmbLogVel.SelectedIndex.ToString() + ")";
							file.Write(item + sel + "\t");
							break;

						case 2:

							item = cmbLogCur.Text;
							sel = "(" + cmbLogCur.SelectedIndex.ToString() + ")";
							file.Write(item + sel + "\t");
							break;

						case 3:

							switch (Culture.Name)
							{
								default:
								case Culture.JP:
									item = "ステータス";
									break;

								case Culture.US:
									item = "ステータス";
									break;

								case Culture.CN:
									item = "状态";
									break;
							}

							sel = "(-1)";
							file.Write(item + sel + "\t");
							break;

						case 4:

							switch (Culture.Name)
							{
								default:
								case Culture.JP:
									item = "パラメタ1";
									break;

								case Culture.US:
									item = "パラメタ1";
									break;

								case Culture.CN:
									item = "参数1";
									break;
							}

							sel = "(" + numLogPrm1.Text + ")";
							file.Write(item + sel + "\t");
							break;

						case 5:

							switch (Culture.Name)
							{
								default:
								case Culture.JP:
									item = "パラメタ2";
									break;

								case Culture.US:
									item = "パラメタ2";
									break;

								case Culture.CN:
									item = "参数2";
									break;
							}

							item = "パラメタ2";
							sel = "(" + numLogPrm2.Text + ")";
							file.Write(item + sel + "\t");
							break;

						case 6:

							switch (Culture.Name)
							{
								default:
								case Culture.JP:
									item = "パラメタ3";
									break;

								case Culture.US:
									item = "パラメタ3";
									break;

								case Culture.CN:
									item = "参数3";
									break;
							}

							sel = "(" + numLogPrm3.Text + ")";
							file.Write(item + sel + "\t");
							break;

						default:
							break;
					}
				}

				file.Write("\r" + "\n");

				for (int i = 0; i < LogWork.LogLength; i++)
				{
					if (i >= LogWork.LogLength) { i = 0; }

					// Ver1.33 Delete
					//DataMsg.PerformStep();

					for (int j = 0; j < LogWork.MonNum; j++)
					{
						file.Write(LogData[j, i].ToString() + "\t");
					}

					file.Write("\r" + "\n");
				}

				// Ver1.33 Add
				DataMsg.PerformStep();

				file.Close();

				Thread.Sleep(MsgWait);

				DataMsg.Close();

				this.Cursor = Cursors.Default;

			}
			catch
			{
				DataMsg.Close();

				this.Cursor = Cursors.Default;

				UserMessageBox.CommonFileFormatError();
			}
		}

		// ↑↑↑ Ver1.3x add AMADA Inspection

		#region Form Event

		private void DigitalOsilloForm_Load(object sender, EventArgs e)
		{
			this.Location = FormPosition;
			this.Size = FormSize;

			//波形描画用ペン初期化
			InitPen();

			//波形描画PictureBox位置設定
			picWave.Location = new Point(0, 0);
			pnlWave.Dock = DockStyle.Fill;

			if (Culture.Name != DefaultCulture)
			{
				//カルチャー変更時のみ（アプリケーション固有設定が反映されない為）
				DefaultCulture = Culture.Name;
				ViewCultureResouceChanged();
			}

			// Ver 1.34 delete  Properties.Settingsを0->1に変更
			// Ver 1.32 add ↓↓↓
			//cmbLogVel.SelectedIndex = 1;    //速度ログ初期設定：瞬時速度
			//cmbLogCur.SelectedIndex = 1;    //電流ログ初期設定：瞬時電流
			// Ver 1.32 add ↑↑↑

			//ファイル生成数
			numNumberFiles.Value = Properties.Settings.Default.NumberFiles;  //Ver 1.34 add 
		}

		private void DigitalOsilloForm_Shown(object sender, EventArgs e)
		{
			BackupPicWaveHeight = Properties.Settings.Default.WAVE_BackupHeight;

			picWave_Resize(null, null);

			DisableDraw = false;

			HoldEnabled = true;			//20170825 add

			ReDrawWave();
		}

		private void DigitalOsilloForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Properties.Settings.Default.WAVE_XScale = X_Div;
			Properties.Settings.Default.WAVE_YScale = Y_Div;
			//Properties.Settings.Default.WAVE_BackupHeight = picWave.Height;
		
			if (this.WindowState != FormWindowState.Minimized)
			{
				FormPosition = this.Location;
				FormSize = this.Size;
			}

			if (e.CloseReason == CloseReason.MdiFormClosing)
			{
		
			}
			else
			{
				_IsExist = false;
			}
		}

		private void DigitalOsilloForm_Activated(object sender, EventArgs e)
		{
			ReDrawWave();
		}

		private void DigitalOsilloForm_Resize(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Maximized)
			{
				this.WindowState = FormWindowState.Normal;
				InitFormLayout();

				ResizeWidth = ThisMdiClient.ClientRectangle.Width;
				ResizeHeight = ThisMdiClient.ClientRectangle.Height;

				TimerResize.Enabled = true;
			}
		}
	
		private void DigitalOsilloForm_ResizeBegin(object sender, EventArgs e)
		{
			IsResizing = true;
		}

		private void DigitalOsilloForm_ResizeEnd(object sender, EventArgs e)
		{
			IsResizing = false;
		}

		private void DigitalOsilloForm_MouseWheel(object sender, MouseEventArgs e)
		{
			#region 縦軸拡大縮小

			if (e.Delta > OldDelta && ScaleY == true)
			{
				VerticalZoom(false);
				return;
			}

			if (e.Delta < OldDelta && ScaleY == true)
			{
				VerticalZoom(true);
				return;
			}
		
			#endregion

			#region 横軸拡大縮小
			if (e.Delta > OldDelta && ScaleX)
			{
				HorizontalZoom(true);
				return;
			}

			if (e.Delta < OldDelta && ScaleX)
			{
				HorizontalZoom(false);
				return;
			}
			#endregion

			#region 水平スクロール
			if (e.Delta < OldDelta)
			{
				//OffSetX = picWave.Width / 50;

				//SclPos.X = -pnlWave.AutoScrollPosition.X + OffSetX;
				//SclPos.Y = -pnlWave.AutoScrollPosition.Y;

				//pnlWave.AutoScrollPosition = SclPos;

				//SclPos.X = -pnlWave.AutoScrollPosition.X;
				//SclPos.Y = -pnlWave.AutoScrollPosition.Y;

				if (hSclWave.Value + hSclWave.LargeChange <= hSclWave.Maximum)
				{
					hSclWave.Value += hSclWave.LargeChange;
				}
				else
				{
					hSclWave.Value = hSclWave.Maximum;
				}

				//p.X = -ｈSclWave.Value;
				//p.Y = 0;

				//picWave.Location = p;

				ReDrawWave();
				return;
			}

			if (e.Delta > OldDelta)
			{
				//OffSetX = picWave.Width / 50;

				//SclPos.X = -pnlWave.AutoScrollPosition.X - OffSetX;
				//SclPos.Y = -pnlWave.AutoScrollPosition.Y;

				//pnlWave.AutoScrollPosition = SclPos;

				//SclPos.X = -pnlWave.AutoScrollPosition.X;
				//SclPos.Y = -pnlWave.AutoScrollPosition.Y;

				if (hSclWave.Value - hSclWave.LargeChange >= 0)
				{
					hSclWave.Value -= hSclWave.LargeChange;
				}
				else
				{
					hSclWave.Value = 0;
				}

				//p.X = -ｈSclWave.Value;
				//p.Y = 0;

				//picWave.Location = p;

				ReDrawWave();
				return;
			}
			#endregion
		}

		private void DigitalOsilloForm_MouseEnter(object sender, EventArgs e)
		{
			/*
			if (Properties.Settings.Default.CTRL_AUTO_ACTIVE)
			{
				if (IsTabbedMdiGroup)
				{
					MainForm.GetMainForm().Activate();
				}
				else
				{
					this.Activate();
				}
			}
			*/
		}

		private void DigitalOsilloForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control)
			{
				ScaleY = true;
				return;
			}

			if (e.Shift)
			{
				ScaleX = true;
				return;
			}
		}

		private void DigitalOsilloForm_KeyUp(object sender, KeyEventArgs e)
		{
			ScaleX = false;
			ScaleY = false;

			if (e.Control)
			{
				ScaleX = false;
				ScaleY = true;
				return;
			}

			if (e.Shift)
			{
				ScaleX = true;
				ScaleY = false;
				return;
			}
		}

		#endregion

		#region Zoom Event

		private ToolStripButton btnZoomOn = new ToolStripButton();

		private int ZoomWaitCnt = new int();

		private void ZoomWaveOn(ToolStripButton button)
		{
			switch (button.Name)
			{
				case "ubtnHZoomP":

					HorizontalZoom(true);
					break;

				case "ubtnHZoomM":

					HorizontalZoom(false);
					break;

				case "ubtnVZoomP":

					VerticalZoom(true);
					break;

				case "ubtnVZoomM":

					VerticalZoom(false);
					break;

				default:
					break;
			}
		}

		private void VerticalZoom(bool dir)
		{
			if (dir)
			{
				//グラフ表示縦軸拡大
				if (Y_Div <= 1.0F)
				{
					Y_Div = 1.0F;
					Properties.Settings.Default.WAVE_YScale = Y_Div;		//20170809 update
					return;
				}

				Y_Div -= 0.1F;
				Properties.Settings.Default.WAVE_YScale = Y_Div;
			}
			else
			{
				//グラフ表示縦軸縮小
				if (Y_Div >= 6.0F)
				{
					Y_Div = 6.0F;
					picWave.Height = pnlWave.Height;
					Properties.Settings.Default.WAVE_YScale = Y_Div;		//20170809 update
					return;
				}

				Y_Div += 0.1F;
				Properties.Settings.Default.WAVE_YScale = Y_Div;
			}

			ReDrawWave();
			return;
		}

		private void HorizontalZoom(bool dir)
		{
			if (dir)
			{
				//グラフ表示横軸拡大
				if (X_Div < 1.0F)
				{
					X_Div = X_Div + 0.1F;
				}
				else
				{
					X_Div = X_Div + 0.1F;
		
					if (X_Div >= 25.0F) { X_Div = 25.0F; }
				}
			}
			else
			{
				//グラフ表示横軸縮小
				if (X_Div <= 1.0F)
				{
					X_Div = X_Div - 0.1F;

					if( X_Div <= 0.1 ) { X_Div = 0.1F;}
				}
				else
				{
					X_Div = X_Div - 0.1F;
				}
			}

			Properties.Settings.Default.WAVE_XScale = X_Div;

			UpdateHoldView(true);

			UpdateTrackChageValue();
			
			ReDrawWave();

			return;
		}

		private void UpdateTrackChageValue()
		{
			float p = X_Div;
			int k = GetTrackScale(p);

			trackTimeMeas1.SmallChange = (int)(p * TRACK_SCALE);
			trackTimeMeas1.LargeChange = (int)(p * TRACK_SCALE) * k;
			trackTimeMeas2.SmallChange = (int)(p * TRACK_SCALE);
			trackTimeMeas2.LargeChange = (int)(p * TRACK_SCALE) * k;
		}

		private int GetTrackScale(float div)
		{
			float max = trackTimeMeas1.Maximum / TRACK_SCALE;

			float x = max / div / TRACK_LARGE_CHANGE;
			int k = (int)x;

			if (k < 1) { k = 1; } 

			return k;
		}

		private void TimerWave_Tick(object sender, EventArgs e)
		{
			if (TimerWave.Interval != 10) { TimerWave.Interval = 10; }

			ZoomWaitCnt++;

			if (ZoomWaitCnt >= 5)
			{
				ZoomWaveOn(btnZoomOn);
			}
		}

		#endregion

		#region Logdata Function

		static public int[,] GetLogBufPointer(ref int log_ptr, ref int log_max)
		{
			log_ptr = ExportLogPtr;
			log_max = LogWork.LogLength;
			return ExportLogData;
		}

		public double[] GetFFT_InBuf()
		{
            return fftIn;
		}

		public double[] GetFFT_OutBuf()
		{
            return fftOut;
		}
       
		public bool EnableReadFFT
		{
			set { _EnableReadFFT = value; }
			get { return _EnableReadFFT; }
		}

		private bool IsResizing = new bool();

		public bool EnableDrawWave
		{
			get
			{
				bool ret = true;

				if (this.WindowState == FormWindowState.Minimized) { ret = false; }

				if (this.Visible == false) { ret = false; }

				if (TimerWave.Enabled) { ret = false; }

				if (IsMeas) { ret = false; }

				if (IsResizing) { ret = false; }

				if (IsHold) { ret = false; }

				if (ret == false && IsHold == false)
				{
					TrgPtrClear();
				}

				return ret;
			}
		}

		public void UpdateLogData(ref int[] buf, int log_num, bool fft_on)
		{
			int off = new int();

			if (fft_on)
			{
				off = LogWork.KindNum;
			}
			else
			{
				off = LogWork.MonNum;
			}

			for (int i = 0, j = 0; i < log_num; i++, j += off)
			{
				if (!IsHold)										//20160722 update
				{
					LogData[LogWork.POS, LogPtr] = buf[j + 0];		//位置
					LogData[LogWork.VEL, LogPtr] = buf[j + 1];		//速度
					LogData[LogWork.CUR, LogPtr] = buf[j + 2];		//電流
					LogData[LogWork.STS, LogPtr] = buf[j + 3];		//ステータス
					LogData[LogWork.PRM1, LogPtr] = buf[j + 4];		//パラメタ1
					LogData[LogWork.PRM2, LogPtr] = buf[j + 5];		//パラメタ2
					LogData[LogWork.PRM3, LogPtr] = buf[j + 6];		//パラメタ3
				}

				if (fft_on)
				{
					LogData[LogWork.LOG1, LogPtr] = buf[j + 7];		//データ1
					LogData[LogWork.LOG2, LogPtr] = buf[j + 8];		//データ2
					LogData[LogWork.LOG3, LogPtr] = buf[j + 9];		//データ3
					LogData[LogWork.LOG4, LogPtr] = buf[j + 10];	//データ4
					LogData[LogWork.LOG5, LogPtr] = buf[j + 11];	//データ5
					LogData[LogWork.LOG6, LogPtr] = buf[j + 12];	//データ6
					LogData[LogWork.LOG7, LogPtr] = buf[j + 13];	//データ7
					LogData[LogWork.LOG8, LogPtr] = buf[j + 14];	//データ8
					LogData[LogWork.LOG9, LogPtr] = buf[j + 15];	//データ9
					LogData[LogWork.LOG10, LogPtr] = buf[j + 16];	//データ10
					LogData[LogWork.LOG11, LogPtr] = buf[j + 17];	//データ11
					LogData[LogWork.LOG12, LogPtr] = buf[j + 18];	//データ12
					LogData[LogWork.LOG13, LogPtr] = buf[j + 19];	//データ13
					LogData[LogWork.LOG14, LogPtr] = buf[j + 20];	//データ14
					LogData[LogWork.LOG15, LogPtr] = buf[j + 21];	//データ15
					LogData[LogWork.LOG16, LogPtr] = buf[j + 22];	//データ16
					LogData[LogWork.LOG17, LogPtr] = buf[j + 23];	//データ17
					LogData[LogWork.LOG18, LogPtr] = buf[j + 24];	//データ18
					LogData[LogWork.LOG19, LogPtr] = buf[j + 25];	//データ19
					LogData[LogWork.LOG20, LogPtr] = buf[j + 26];	//データ20
				}

				if (!IsHold)											//20160722 update
				{
					ExportLogData[LogWork.POS, LogPtr] = buf[j + 0];	//位置
					ExportLogData[LogWork.VEL, LogPtr] = buf[j + 1];	//速度
					ExportLogData[LogWork.CUR, LogPtr] = buf[j + 2];	//電流
					ExportLogData[LogWork.STS, LogPtr] = buf[j + 3];	//ステータス
					ExportLogData[LogWork.PRM1, LogPtr] = buf[j + 4];	//パラメタ1
					ExportLogData[LogWork.PRM2, LogPtr] = buf[j + 5];	//パラメタ2
					ExportLogData[LogWork.PRM3, LogPtr] = buf[j + 6];	//パラメタ3
				}

				if (fft_on)
				{
					ExportLogData[LogWork.LOG1, LogPtr] = buf[j + 7];	//データ1
					ExportLogData[LogWork.LOG2, LogPtr] = buf[j + 8];	//データ2
					ExportLogData[LogWork.LOG3, LogPtr] = buf[j + 9];	//データ3
					ExportLogData[LogWork.LOG4, LogPtr] = buf[j + 10];	//データ4
					ExportLogData[LogWork.LOG5, LogPtr] = buf[j + 11];	//データ5
					ExportLogData[LogWork.LOG6, LogPtr] = buf[j + 12];	//データ6
					ExportLogData[LogWork.LOG7, LogPtr] = buf[j + 13];	//データ7
					ExportLogData[LogWork.LOG8, LogPtr] = buf[j + 14];	//データ8
					ExportLogData[LogWork.LOG9, LogPtr] = buf[j + 15];	//データ9
					ExportLogData[LogWork.LOG10, LogPtr] = buf[j + 16];	//データ10
					ExportLogData[LogWork.LOG11, LogPtr] = buf[j + 17];	//データ11
					ExportLogData[LogWork.LOG12, LogPtr] = buf[j + 18];	//データ12
					ExportLogData[LogWork.LOG13, LogPtr] = buf[j + 19];	//データ13
					ExportLogData[LogWork.LOG14, LogPtr] = buf[j + 20];	//データ14
					ExportLogData[LogWork.LOG15, LogPtr] = buf[j + 21];	//データ15
					ExportLogData[LogWork.LOG16, LogPtr] = buf[j + 22];	//データ16
					ExportLogData[LogWork.LOG17, LogPtr] = buf[j + 23];	//データ17
					ExportLogData[LogWork.LOG18, LogPtr] = buf[j + 24];	//データ18
					ExportLogData[LogWork.LOG19, LogPtr] = buf[j + 25];	//データ19
					ExportLogData[LogWork.LOG20, LogPtr] = buf[j + 26];	//データ20
				}

				int x = LogPtr - 1;

				if( x < 0){ x = LogWork.LogLength -1;}

				if ((LogData[LogWork.STS, LogPtr] & CMDPOS_BIT) == CMDPOS_BIT)
				{
					//指令値変化有り
					LogData[LogWork.STS, LogPtr] &= ~CMD_BIT;
					ExportLogData[LogWork.STS, LogPtr] &= ~CMD_BIT;

					if ((LogData[LogWork.STS, LogPtr] & SVON_BIT) == SVON_BIT)
					{
						//サーボオンなら
						LogData[LogWork.STS, LogPtr] |= CMD_BIT;
					}

					if ((ExportLogData[LogWork.STS, LogPtr] & SVON_BIT) == SVON_BIT)
					{
						//サーボオンなら
						ExportLogData[LogWork.STS, LogPtr] |= CMD_BIT;
					}
				}
				else
				{
					//指令値変化無し
					LogData[LogWork.STS, LogPtr] &= ~CMD_BIT;
					ExportLogData[LogWork.STS, LogPtr] &= ~CMD_BIT;
				}

				if (TrgPtr1 < 0 && !IsHold)
				{
					int sts_new = new int();
					int sts_old = new int();

					if (TrgItem == TrgItemEnum.TRG_CMD)
					{
						//コマンドポジション
						sts_new = LogData[LogWork.STS, LogPtr];
						sts_old = 0;

						if (LogPtr - 1 >= 0)
						{
							sts_old = LogData[LogWork.STS, LogPtr - 1];
						}
						else
						{
							sts_old = LogData[LogWork.STS, LogWork.LogLength - 1];
						}

						if (TrgIsGE)
						{
							//立ち上り検出
							if (((sts_new & CMD_BIT) == CMD_BIT) && ((sts_old & CMD_BIT) == 0))
							{
								TrgPtr1 = LogPtr;
								TrgCnt = 0;
							}
						}
						else
						{
							//立ち下り検出
							if (((sts_new & CMD_BIT) == 0) && ((sts_old & CMD_BIT) == CMD_BIT))
							{
								TrgPtr1 = LogPtr;
								TrgCnt = 0;
							}
						}
					}
                    else if (TrgItem == TrgItemEnum.TRG_INPOS)
                    {
                        //インポジション						
                        sts_new = LogData[LogWork.STS, LogPtr];
                        sts_old = 0;

                        if (LogPtr - 1 >= 0)
                        {
                            sts_old = LogData[LogWork.STS, LogPtr - 1];
                        }
                        else
                        {
                            sts_old = LogData[LogWork.STS, LogWork.LogLength - 1];
                        }

                        if (TrgIsGE)
                        {
                            //立ち上り検出
                            if (((sts_new & INPOS_BIT) == INPOS_BIT) && ((sts_old & INPOS_BIT) == 0))
                            {
                                TrgPtr1 = LogPtr;
                                TrgCnt = 0;
                            }
                        }
                        else
                        {
                            //立ち下り検出
                            if (((sts_new & INPOS_BIT) == 0) && ((sts_old & INPOS_BIT) == INPOS_BIT))
                            {
                                TrgPtr1 = LogPtr;
                                TrgCnt = 0;
                            }
                        }
                    }
                    else
                    {
                        int y = new int();

                        switch (TrgItem)
                        {
                            case TrgItemEnum.TRG_ERR:
                                y = 0;
                                break;

                            case TrgItemEnum.TRG_VEL:
                                y = 1;
                                break;

                            case TrgItemEnum.TRG_CUR:
                                y = 2;
                                break;
                        }

                        int last_data = new int();
                        int now_data = new int();

                        if (LogPtr - 1 >= 0)
                        {
                            if (y == 0)
                            {
                                last_data = LogData[y, LogPtr - 1] - LogData[y + 1, LogPtr - 1];
                                now_data = LogData[y, LogPtr] - LogData[y + 1, LogPtr];
                            }
                            else
                            {
                                last_data = LogData[y, LogPtr - 1];
                                now_data = LogData[y, LogPtr];
                            }
                        }
                        else
                        {
                            if (y == 0)
                            {
                                last_data = LogData[y, LogWork.LogLength - 1] - LogData[y + 1, LogWork.LogLength - 1];
                                now_data = LogData[y, LogPtr] - LogData[y + 1, LogPtr];
                            }
                            else
                            {
                                last_data = LogData[y, LogWork.LogLength - 1];
                                now_data = LogData[y, LogPtr];
                            }
                        }

                        if (TrgIsGE)
                        {
                            if (now_data >= TrgValue &&
                                last_data < TrgValue)
                            {
                                TrgPtr1 = LogPtr;
                                TrgCnt = 0;
                            }
                        }
                        else
                        {
                            if (now_data <= TrgValue &&
                                last_data > TrgValue)
                            {
                                TrgPtr1 = LogPtr;
                                TrgCnt = 0;
                            }
                        }
                    }
				}

                //Ver 1.32 Add ↓↓↓
                //アラーム検出時自動停止指定？
                if (chkAlarmAutoStop.Checked)
                {
                    //アラーム発生？
                    if (((LogData[LogWork.STS, LogPtr] & ALM_BIT) == ALM_BIT))
                    {
                        //波形停止
                        bAutoStop = true;
                    }
                }
                //Ver 1.32 Add ↑↑↑ 
				
                LogPtr++;
				TrgCnt++;


				if (LogPtr >= LogWork.LogLength) 
				{
					if (IsSplitLogSave) SplitOutputLogDataFile(); // Ver1.35 add
																  
					LogPtr = 0;
				}

				ExportLogPtr = LogPtr;
			}

			int wcnt = (int)(picWave.Width / X_Div);		//画面（トリガ機能で使用）
			int trg_off = GetTrgOffset(wcnt);

			bool trg_draw = new bool();

			int FFT_n = FFT_C.FFT_n / FFT_C.LOG_n;		//16384/20 = 819msec
			int fft_ptr = new int();

			if (IsTrg && !IsHold)
			{
				int wave_end = wcnt - trg_off;

				if (TrgPtr1 >= 0 && TrgCnt >= wave_end)
				{
					TrgPtr2 = TrgPtr1;
					TrgPtr1 = -1;
					TrgCnt = 0;

					if (wave_end >= 450 / LogWork.LogPeriod) { wave_end = 450; }
				
					int ptr = TrgPtr2 + (wave_end / LogWork.LogPeriod);
					int min = TrgPtr2 - (30  / LogWork.LogPeriod);

					int idx = ptr;

					if (idx >= LogWork.LogLength) { idx = idx - LogWork.LogLength; }

					for (int i = ptr, j = 0; i > min; i--, j++)
					{
						if ((LogData[LogWork.STS, idx] & INPOS_BIT) == 0x00)
						{
							if (j > 0)
							{
								PosSettingTime = i - TrgPtr2 + 1;
							}
							else
							{
								PosSettingTime = 9999;
							}
							break;
						}

						idx--;
						if (idx < 0) { idx = LogWork.LogLength - 1; }
					}

					TrgStone++;

					if (TrgStone >= 4) { TrgStone = 0; }

					for (int i = 0; i < LogWork.KindNum; i++)
					{
						for (int j = 0, k = TrgPtr2 - wcnt; j < (wcnt * 2); j++, k++)
						{
							if (k >= LogWork.LogLength) { k = 0; }

							if (k < 0) { k = LogWork.LogLength + k; }

							TrgData[i, k] = LogData[i, k];
						}
					}

					fft_ptr = TrgPtr2 - FFT_n + (100 / LogWork.LogPeriod);

					if (fft_ptr < 0) { fft_ptr = LogWork.LogLength + fft_ptr; }

					trg_draw = true;
				}
				else
				{
					fft_ptr = LogPtr - FFT_n;

					if (fft_ptr < 0) { fft_ptr = LogWork.LogLength + fft_ptr; }
				}
			}
			else
			{
				fft_ptr = LogPtr - FFT_n;

				if (fft_ptr < 0) { fft_ptr = LogWork.LogLength + fft_ptr; }
			}

			if (fft_on)
			{
				for (int i = 0; i < FFT_n; i++)
				{
					int n = i * FFT_C.LOG_n;

					for (int k = 0; k < FFT_C.LOG_n; k++)
					{
						fftOut[n + k] = (double)((short)LogData[LogWork.LOG1 + k, fft_ptr]);
					}

					fft_ptr++;

					if (fft_ptr >= LogWork.LogLength) { fft_ptr = 0; }
				}

				EnableReadFFT = true;
			}
			else
			{
				EnableReadFFT = false;
			}

			IsMeas = true;

			if (IsTrg && !trg_draw)		//20170927 update
			{

			}
			else
			{
				if (!IsHold)			//20170927 update
				{
					ReDrawWave();
				}
			}

			IsMeas = false;

            // アラーム時波形停止指示? Ver 1.32
            if (bAutoStop) HoldEvent();
		}

		public void UpdateLogKind()
		{
			if (DisableLogKindChange) { return; }

			int idx = new int();

			idx = CMonitor.GetParameter(CParamID.LogKind1);
			if (idx >= 0 && idx < cmbLogPos.Items.Count) { cmbLogPos.SelectedIndex = idx; }

			idx = CMonitor.GetParameter(CParamID.LogKind2);
			if (idx >= 0 && idx < cmbLogVel.Items.Count) { cmbLogVel.SelectedIndex = idx; }

			idx = CMonitor.GetParameter(CParamID.LogKind3);
			if (idx >= 0 && idx < cmbLogCur.Items.Count) { cmbLogCur.SelectedIndex = idx; }

			//20170928 update start
			idx = CMonitor.GetParameter(CParamID.LogKind5);

			if (idx == 0)
			{
				if (idx != numLogPrm1.Value) { numLogPrm_ValueChanged(numLogPrm1, null); }
			}
			else
			{
				if (idx >= 0 && idx >= numLogPrm1.Minimum && idx <= numLogPrm1.Maximum) { numLogPrm1.Value = idx; }
			}

			idx = CMonitor.GetParameter(CParamID.LogKind6);

			if (idx == 0)
			{
				if (idx != numLogPrm2.Value) { numLogPrm_ValueChanged(numLogPrm2, null); }
			}
			else
			{
				if (idx >= 0 && idx >= numLogPrm2.Minimum && idx <= numLogPrm2.Maximum) { numLogPrm2.Value = idx; }
			}

			idx = CMonitor.GetParameter(CParamID.LogKind7);

			if (idx == 0)
			{
				if (idx != numLogPrm3.Value) { numLogPrm_ValueChanged(numLogPrm3, null); }
			}
			else
			{
				if (idx >= 0 && idx >= numLogPrm3.Minimum && idx <= numLogPrm3.Maximum) { numLogPrm3.Value = idx; }
			}
			//20170928 update end
			
			idx = CMonitor.GetParameter(CParamID.LogFFT_Kind);
			if (idx >= 0 && idx < cmbLogFFT.Items.Count) { cmbLogFFT.SelectedIndex = idx; }
		}

		private void TrgPtrClear()
		{
			if (IsTrg)
			{
				//トリガやり直し
				TrgPtr1 = -1;
				TrgCnt = 0;
			}
		}

		private void TrgBufClear()		//20170927 add
		{
			if (IsTrg)
			{
				for (int i = 0; i < LogWork.KindNum; i++)
				{
					for (int j = 0; j < LogWork.LogLength; j++)
					{
						TrgData[i, j] = 0;
					}
				}
			}
		}

		public void PauseDraw(bool stop)
		{
			if (stop)
			{
				if (!tbtnHold.Checked)
				{
					IsHold = true;
				}
			}
			else
			{
				if (IsHold)
				{
					IsHold = false;
				}
			}
		}

		#endregion

		#region Wave Draw Event

		static private float X_Div = new float();
		static private float Y_Div = new float();
		static private int I_Div = new int();
		static private int P_Div = new int();

		static private int V_Div = new int();
		static private int T_Div = new int();
		static private int Prm1_Div = new int();
		static private int Prm2_Div = new int();
		static private int Prm3_Div = new int();

		static private float I_Pos = new float();
		static private float P_Pos = new float();
		static private float V_Pos = new float();
		static private float Prm1_Pos = new float();
		static private float Prm2_Pos = new float();
		static private float Prm3_Pos = new float();

		static private float I_Mul = new float();
		static private float P_Mul = new float();
		static private float V_Mul = new float();
		static private float Prm1_Mul = new float();
		static private float Prm2_Mul = new float();
		static private float Prm3_Mul = new float();
		
		static private int InposOff = new int();
		static private int CmdposOff = new int();
		static private float I_Scale = new float();

		private string P_Unit = " [pls] ";			//20170810 update space delete
		private string V_Unit = " [rpm] ";			//20170810 update space delete
		private string A_Unit = " [A] ";			//20170810 update space delete
		private string Prm1_Unit = " [p1] ";		//20170810 update space delete
		private string Prm2_Unit = " [p2] ";		//20170810 update space delete
		private string Prm3_Unit = " [p3] ";		//20170810 update space delete

		private Pen InpPen;
		private Pen CmdPen;
		private Pen PosPen;
		private Pen VelPen;
		private Pen CurPen;
		private Pen[] TimPen = new Pen[2];

		private Pen Prm1Pen;
		private Pen Prm2Pen;
		private Pen Prm3Pen;

		private Pen MeasPen;
		private Pen TrgPen;

		private Font PosFont = AppFont.ArialRegular8;
		private Font VelFont = AppFont.ArialRegular8;
		private Font CurFont = AppFont.ArialRegular8;
		private Font Prm1Font = AppFont.ArialRegular8;
		private Font Prm2Font = AppFont.ArialRegular8;
		private Font Prm3Font = AppFont.ArialRegular8;
		private Font TimeFont = AppFont.ArialRegular8;		//20170810 update (ArialRegular10) -> (ArialRegular8)

		private float WaveStartOffset = new float();
		private float WaveEndOffset = new float();

		private const float WAVE_START_OFFSET = 100.0F;
		private const float WAVE_END_OFFSET = 80.0F;
		private const float WAVE_OFFSET_MIN = 10.0F;
		private const float UNIT_OFFSET = 5.0F;
		private const float WAVE_TOP_OFFSET  = 3.0F;						//20170810 add
		private const float WAVE_HOLD_OFFSET = 8.0F;						//20170810 update (10.0F) -> (7.5F)
		private const float WAVE_HOLD_OFFSET2 = WAVE_HOLD_OFFSET * 2.0F - WAVE_TOP_OFFSET;	//20170810 add
		
		private List<Point> listP_UnitPos = new List<Point>();
		private List<Point> listV_UnitPos = new List<Point>();
		private List<Point> listI_UnitPos = new List<Point>();
		private List<Point> listPrm1_UnitPos = new List<Point>();
		private List<Point> listPrm2_UnitPos = new List<Point>();
		private List<Point> listPrm3_UnitPos = new List<Point>();
	
		private void InitPen()
		{
			pnlTimeMeas1.BackColor = Properties.Settings.Default.WAVE_WindowColor;
			pnlTimeMeas2.BackColor = Properties.Settings.Default.WAVE_WindowColor;
			trackTimeMeas1.BackColor = Properties.Settings.Default.WAVE_WindowColor;
			trackTimeMeas2.BackColor = Properties.Settings.Default.WAVE_WindowColor;
			pnlWave.BackColor = Properties.Settings.Default.WAVE_WindowColor;
			picWave.BackColor = Properties.Settings.Default.WAVE_WindowColor;

			InpPen = new Pen(Properties.Settings.Default.WAVE_InposColor, Properties.Settings.Default.WAVE_InposLineSize);
			InpPen.DashStyle = Properties.Settings.Default.WAVE_InposLineType;

			CmdPen = new Pen(Properties.Settings.Default.WAVE_CmdposColor, Properties.Settings.Default.WAVE_CmdposLineSize);
			CmdPen.DashStyle = Properties.Settings.Default.WAVE_CmdposLineType;

			PosPen = new Pen(Properties.Settings.Default.WAVE_PosColor, Properties.Settings.Default.WAVE_PosLineSize);
			PosPen.DashStyle = Properties.Settings.Default.WAVE_PosLineType;
			
			VelPen = new Pen(Properties.Settings.Default.WAVE_VelColor, Properties.Settings.Default.WAVE_VelLineSize);
			VelPen.DashStyle = Properties.Settings.Default.WAVE_VelLineType;

			CurPen = new Pen(Properties.Settings.Default.WAVE_CurColor, Properties.Settings.Default.WAVE_CurLineSize);
			CurPen.DashStyle = Properties.Settings.Default.WAVE_CurLineType;

			Prm1Pen = new Pen(Properties.Settings.Default.WAVE_Prm1Color, Properties.Settings.Default.WAVE_Prm1LineSize);
			Prm1Pen.DashStyle = Properties.Settings.Default.WAVE_Prm1LineType;

			Prm2Pen = new Pen(Properties.Settings.Default.WAVE_Prm2Color, Properties.Settings.Default.WAVE_Prm2LineSize);
			Prm2Pen.DashStyle = Properties.Settings.Default.WAVE_Prm2LineType;

			Prm3Pen = new Pen(Properties.Settings.Default.WAVE_Prm3Color, Properties.Settings.Default.WAVE_Prm3LineSize);
			Prm3Pen.DashStyle = Properties.Settings.Default.WAVE_Prm3LineType;

			TimPen[0] = new Pen(Properties.Settings.Default.WAVE_TimeScaleColor, Properties.Settings.Default.WAVE_TimeScaleLineSize + 1);
			TimPen[1] = new Pen(Properties.Settings.Default.WAVE_TimeScaleColor, Properties.Settings.Default.WAVE_TimeScaleLineSize);
			TimPen[0].DashStyle = DashStyle.Solid;
			TimPen[1].DashStyle = Properties.Settings.Default.WAVE_TimeScaleLineType;

			MeasPen = new Pen(Properties.Settings.Default.WAVE_TimeMeasColor, Properties.Settings.Default.WAVE_TimeMeasLineSize);
			MeasPen.DashStyle = Properties.Settings.Default.WAVE_TimeMeasLineType;

			TrgPen = new Pen(Properties.Settings.Default.WAVE_TrgColor, Properties.Settings.Default.WAVE_TrgLineSize);
			TrgPen.DashStyle = Properties.Settings.Default.WAVE_TrgLineType;
			
		}

		private void picWave_Paint(object sender, PaintEventArgs e)
		{
			if (DisableDraw)
			{
				TimeMeasDraw(e.Graphics);
				return;
			}
		
			try
			{
				DisableDraw = true;

				if (!IsHold)
				{
					//グラフ表示オシロモード
					DrawWaveOscillo(e.Graphics, false);		//20170927 update
				}
				else
				{
					//グラフ表示ログモード
					DrawWaveOscillo(e.Graphics, true);		//20170927 update
				}

				TimeMeasDraw(e.Graphics);

				DisableDraw = false;
			}
			catch (Exception ex)
			{
				DisableDraw = false;

				UserMessageBox.CommonCatchErrorMessage(ex);
			}

		}

		private void DrawWaveItem(Graphics g, float y_center, float y_scale, float y_max, float y_min)
		{
			Brush posBrush = new SolidBrush(Properties.Settings.Default.WAVE_PosColor);
			Brush velBrush = new SolidBrush(Properties.Settings.Default.WAVE_VelColor);
			Brush curBrush = new SolidBrush(Properties.Settings.Default.WAVE_CurColor);
			Brush trgBrush = new SolidBrush(Properties.Settings.Default.WAVE_TrgColor);
			Brush prm1Brush = new SolidBrush(Properties.Settings.Default.WAVE_Prm1Color);
			Brush prm2Brush = new SolidBrush(Properties.Settings.Default.WAVE_Prm2Color);
			Brush prm3Brush = new SolidBrush(Properties.Settings.Default.WAVE_Prm3Color);
			Brush logBrush = new SolidBrush(Color.White);

			listP_UnitPos.Clear();
			listV_UnitPos.Clear();
			listI_UnitPos.Clear();
			listPrm1_UnitPos.Clear();
			listPrm2_UnitPos.Clear();
			listPrm3_UnitPos.Clear();

			float f1 = new float();
			float f2 = new float();
			float f3 = new float();

			const float max = 50.0F;

			//20170810 add メモリ項目Y方向オフセットを定数化
			const float V_ITEM_OFF = 15.0F;
			const float C_ITEM_OFF =  5.0F;
			const float P_ITEM_OFF = 15.0F;
			const float PRM1_ITEM_OFF = 5.0F;
			const float PRM2_ITEM_OFF = 5.0F;
			const float PRM3_ITEM_OFF = 5.0F;


			//目盛り項目（速度、電流、位置、パラメータ1～3）描画
			for (int i = 0; i < (int)Y_Div; i++)
			{
				if (!Properties.Settings.Default.WAVE_ItemY_L_View) { break; }

				if (Properties.Settings.Default.WAVE_VelView)
				{
					//基準線は0
					if (i == 0)
					{
						f1 = y_center - V_ITEM_OFF + V_Pos;

						g.DrawString("0" + V_Unit, VelFont, velBrush, UNIT_OFFSET, f1);

						listV_UnitPos.Add(new Point((int)UNIT_OFFSET, (int)f1));
					}
					else
					{
						//画像表示エリアが小さい場合、メモリ項目は1個飛ばし
						if ((y_max * V_Mul) < max && (i % 2) != 0)
						{
						}
						else
						{
							f1 = y_center - y_min * i * V_Mul - V_ITEM_OFF + V_Pos;
							f2 = y_center + y_min * i * V_Mul - V_ITEM_OFF + V_Pos;

							g.DrawString(Convert.ToString( V_Div * i) + V_Unit, VelFont, velBrush, UNIT_OFFSET, f1);
							g.DrawString(Convert.ToString(-V_Div * i) + V_Unit, VelFont, velBrush, UNIT_OFFSET, f2);

							listV_UnitPos.Add(new Point((int)UNIT_OFFSET, (int)f1));
							listV_UnitPos.Add(new Point((int)UNIT_OFFSET, (int)f2));
						}
					}
				}

				if (Properties.Settings.Default.WAVE_CurView)
				{
					//基準線は0
					if (i == 0)
					{
						f1 = y_center - C_ITEM_OFF + I_Pos;

						g.DrawString((I_Scale * 0.0F).ToString("F1") + A_Unit, CurFont, curBrush, UNIT_OFFSET, f1);

						listI_UnitPos.Add(new Point((int)UNIT_OFFSET, (int)f1));
					}
					else
					{
						//画像表示エリアが小さい場合、メモリ項目は1個飛ばし
						if ((y_max * I_Mul) < max && (i % 2) != 0)
						{
						}
						else
						{
							f1 = y_center - y_min * i * I_Mul - C_ITEM_OFF + I_Pos;
							f2 = y_center + y_min * i * I_Mul - C_ITEM_OFF + I_Pos;

							g.DrawString(( I_Scale * i).ToString("F1") + A_Unit, CurFont, curBrush, UNIT_OFFSET, f1);
							g.DrawString((-I_Scale * i).ToString("F1") + A_Unit, CurFont, curBrush, UNIT_OFFSET, f2);

							listI_UnitPos.Add(new Point((int)UNIT_OFFSET, (int)f1));
							listI_UnitPos.Add(new Point((int)UNIT_OFFSET, (int)f2));
						}
					}
				}
			}

			for (int i = 0; i < (int)Y_Div; i++)
			{
				if (!Properties.Settings.Default.WAVE_ItemY_R_View) { break; }

				if (Properties.Settings.Default.WAVE_PosView)
				{
					//基準線は0
					if (i == 0)
					{
						f1 = picWave.Width - WaveEndOffset + UNIT_OFFSET;
						f2 = y_center - P_ITEM_OFF + P_Pos;

						g.DrawString("0" + P_Unit, PosFont, posBrush, f1, f2);

						listP_UnitPos.Add(new Point((int)f1, (int)f2));
					}
					else
					{
						//画像表示エリアが小さい場合、メモリ項目は1個飛ばし
						if ((y_max * P_Mul) < max && (i % 2) != 0)
						{
						}
						else
						{
							f1 = picWave.Width - WaveEndOffset + UNIT_OFFSET;
							f2 = y_center - y_min * i * P_Mul - P_ITEM_OFF + P_Pos;
							f3 = y_center + y_min * i * P_Mul - P_ITEM_OFF + P_Pos;

							g.DrawString(Convert.ToString( P_Div * i) + P_Unit, PosFont, posBrush, f1, f2);
							g.DrawString(Convert.ToString(-P_Div * i) + P_Unit, PosFont, posBrush, f1, f3);

							listP_UnitPos.Add(new Point((int)f1, (int)f2));
							listP_UnitPos.Add(new Point((int)f1, (int)f3));
						}
					}
				}

				if (Properties.Settings.Default.WAVE_Prm1View)
				{
					//基準線は0
					if (i == 0)
					{
						f1 = picWave.Width - WaveEndOffset + UNIT_OFFSET;
						f2 = y_center - PRM1_ITEM_OFF + Prm1_Pos;

						g.DrawString("0" + Prm1_Unit, Prm1Font, prm1Brush, f1, f2);

						listPrm1_UnitPos.Add(new Point((int)f1, (int)f2));
					}
					else
					{
						//画像表示エリアが小さい場合、メモリ項目は1個飛ばし
						if ((y_max * Prm1_Mul) < max && (i % 2) != 0)
						{
						}
						else
						{
							f1 = picWave.Width - WaveEndOffset + UNIT_OFFSET;
							f2 = y_center - y_min * i * Prm1_Mul - PRM1_ITEM_OFF + Prm1_Pos;
							f3 = y_center + y_min * i * Prm1_Mul - PRM1_ITEM_OFF + Prm1_Pos;

							g.DrawString(Convert.ToString( Prm1_Div * i) + Prm1_Unit, Prm1Font, prm1Brush, f1, f2);
							g.DrawString(Convert.ToString(-Prm1_Div * i) + Prm1_Unit, Prm1Font, prm1Brush, f1, f3);

							listPrm1_UnitPos.Add(new Point((int)f1, (int)f2));
							listPrm1_UnitPos.Add(new Point((int)f1, (int)f3));
						}
					}
				}

				if (Properties.Settings.Default.WAVE_Prm2View)
				{
					//基準線は0
					if (i == 0)
					{
						f1 = picWave.Width - WaveEndOffset + UNIT_OFFSET;
						f2 = y_center - PRM2_ITEM_OFF + Prm2_Pos;

						g.DrawString("0" + Prm2_Unit, Prm2Font, prm2Brush, f1, f2);

						listPrm2_UnitPos.Add(new Point((int)f1, (int)f2));
					}
					else
					{
						//画像表示エリアが小さい場合、メモリ項目は1個飛ばし
						if ((y_max * Prm2_Mul) < max && (i % 2) != 0)
						{
						}
						else
						{
							f1 = picWave.Width - WaveEndOffset + UNIT_OFFSET;
							f2 = y_center - y_min * i * Prm2_Mul - PRM2_ITEM_OFF + Prm2_Pos;
							f3 = y_center + y_min * i * Prm2_Mul - PRM2_ITEM_OFF + Prm2_Pos;

							g.DrawString(Convert.ToString( Prm2_Div * i) + Prm2_Unit, Prm2Font, prm2Brush, f1, f2);
							g.DrawString(Convert.ToString(-Prm2_Div * i) + Prm2_Unit, Prm2Font, prm2Brush, f1, f3);

							listPrm2_UnitPos.Add(new Point((int)f1, (int)f2));
							listPrm2_UnitPos.Add(new Point((int)f1, (int)f3));
						}
					}
				}

				if (Properties.Settings.Default.WAVE_Prm3View)
				{
					//基準線は0
					if (i == 0)
					{
						f1 = picWave.Width - WaveEndOffset + UNIT_OFFSET;
						f2 = y_center - PRM3_ITEM_OFF + Prm3_Pos;

						g.DrawString("0" + Prm3_Unit, Prm3Font, prm3Brush, f1, f2);

						listPrm3_UnitPos.Add(new Point((int)f1, (int)f2));
					}
					else
					{
						//画像表示エリアが小さい場合、メモリ項目は1個飛ばし
						if ((y_max * Prm3_Mul) < max && (i % 2) != 0)
						{
						}
						else
						{
							f1 = picWave.Width - WaveEndOffset + UNIT_OFFSET;
							f2 = y_center - y_min * i * Prm3_Mul - PRM3_ITEM_OFF + Prm3_Pos;
							f3 = y_center + y_min * i * Prm3_Mul - PRM3_ITEM_OFF + Prm3_Pos;

							g.DrawString(Convert.ToString( Prm3_Div * i) + Prm3_Unit, Prm3Font, prm3Brush, f1, f2);
							g.DrawString(Convert.ToString(-Prm3_Div * i) + Prm3_Unit, Prm3Font, prm3Brush, f1, f3);

							listPrm3_UnitPos.Add(new Point((int)f1, (int)f2));
							listPrm3_UnitPos.Add(new Point((int)f1, (int)f3));
						}
					}
				}
			}

		}

		private void DrawWaveLine(Graphics g, float y_center, float y_min)
		{
			//センター線描画

			//横軸　センター線
			g.DrawLine(TimPen[0], WaveStartOffset, y_center, picWave.Width - WaveEndOffset, y_center);

			//横軸　下線
			g.DrawLine(TimPen[0], WaveStartOffset, y_center + y_min * Y_Div, picWave.Width - WaveEndOffset, y_center + y_min * Y_Div);

			//横軸　上線 20170809 update (+ 0.5F)
			g.DrawLine(TimPen[0], WaveStartOffset, y_center - y_min * Y_Div + 0.5F, picWave.Width - WaveEndOffset, y_center - y_min * Y_Div + 0.5F);
			
			//横軸目盛り線
			for (float h = y_min; y_center + h < y_center + (y_min * Y_Div); h = h + y_min)
			{
				g.DrawLine(TimPen[1], WaveStartOffset, y_center + h, picWave.Width - WaveEndOffset, y_center + h);
			}

			for (float h = y_min; y_center - h > y_center - (y_min * Y_Div); h = h + y_min)
			{
				g.DrawLine(TimPen[1], WaveStartOffset, y_center - h, picWave.Width - WaveEndOffset, y_center - h);
			}

			//縦軸　左線
			g.DrawLine(TimPen[0], WaveStartOffset, y_center + y_min * Y_Div, WaveStartOffset, y_center - y_min * Y_Div);

			//縦軸　右線
			g.DrawLine(TimPen[0], picWave.Width - WaveEndOffset, y_center + y_min * Y_Div, picWave.Width - WaveEndOffset, y_center - y_min * Y_Div);
		
		}

		private void DrawWaveOscillo(Graphics g, bool log)
		{
			//オシロ表示はピクチャーボックスのサイズをパネルサイズに合わせる。
			if( picWave.Width != pnlWave.Width)
			{
				picWave.Width = pnlWave.Width;
				picWave.Height = pnlWave.Height;
			}

			float y_center = new float();
	
			//1画面表示
			y_center = picWave.Height / 2;

			y_center -= WAVE_HOLD_OFFSET;		//20170809 update 連続描画・描画停止最適化 (if (log) {}) 削除
	
			float y_scale = y_center / Y_Div;
			float y_min = y_scale;
			float y_max = y_scale * Y_Div;		//20170809 update (* 6.0F) -> (* Y_Div) 縦軸拡大時に描画範囲からはみ出る件を修正。

			y_center += WAVE_TOP_OFFSET;		//20170809 add

			DrawWaveItem(g, y_center, y_scale, y_max, y_min);

			DrawWaveLine(g, y_center, y_min);

			//横軸表示スケール取得
			int start = 0;
			int wcnt = (int)((picWave.Width - WaveStartOffset - WaveEndOffset) / X_Div);

			if (log)
			{
				int log_idx = (int)(hSclWave.Value / X_Div);
				int log_max = (int)((picWave.Width - WaveStartOffset - WaveEndOffset) / X_Div);

				if (!hSclWave.Visible) { log_idx = 0; }
				if (log_idx < 0) { log_idx = 0; }
				if (log_idx >= LogWork.LogLength) { log_idx -= LogWork.LogLength; }

				if (log_max >= LogWork.LogLength) { log_max = LogWork.LogLength - 1; }

				start = log_idx;
				wcnt = log_max;
			}
			else
			{
				if (IsTrg)
				{
					//トリガON
					if (TrgPtr2 >= 0)
					{
						int trg_off = GetTrgOffset(wcnt);

						if ((TrgPtr2 - trg_off) < 0)					//-1はダミーデータ分
						{
							start = LogWork.LogLength + TrgPtr2 - trg_off;
						}
						else
						{
							start = TrgPtr2 - trg_off;
						}
					}
				}
				else
				{
					//トリガOFF
					if (wcnt >= LogWork.LogLength)
					{
						wcnt = LogWork.LogLength;
					}
	
					if ((LogPtr - wcnt) < 0)
					{
						start = LogWork.LogLength + LogPtr - wcnt;
					}
					else
					{
						start = LogPtr - wcnt;
					}				
				}
			}

			int s1 = new int();
			int s2 = new int();
			float pos = new float();
			float vel = new float();
			float cur = new float();
			float prm1 = new float();
			float prm2 = new float();
			float prm3 = new float();
			float sts1 = new float();
			float sts2 = new float();
			float old_p = new float();
			float old_v = new float();
			float old_c = new float();
			float old_prm1 = new float();
			float old_prm2 = new float();
			float old_prm3 = new float();
			float old_s1 = new float();
			float old_s2 = new float();

			float old_x = WaveStartOffset;
			float old_t = WaveStartOffset;
			float old_l = WaveStartOffset;

			int div_cnt = new int();
			int tim_cnt = new int();

			float trg_x = -1.0F;

			if (X_Div >= 1.0)
			{
				div_cnt = 1;
			}
			else
			{
				if      (X_Div >= 0.8) { div_cnt = 2; }
				else if (X_Div >= 0.6) { div_cnt = 3; }
				else if (X_Div >= 0.4) { div_cnt = 4; }
				else if (X_Div >= 0.2) { div_cnt = 5; }
				else                   { div_cnt = 6; }
			}

			float x_div = X_Div * div_cnt;

			//波形描画
			for (int i = 0, j = start, k = 0; i < wcnt; i++, j++, k++)
			{
				if (j >= LogWork.LogLength) { j = 0; }

				//時間データ描画
				if (Properties.Settings.Default.WAVE_TimeScaleView == true)
				{
					//時間軸目盛線
					if (++tim_cnt == T_Div)
					{
						g.DrawLine(TimPen[1], old_t + X_Div * T_Div, y_center + y_min * Y_Div, old_t + X_Div * T_Div, y_center - y_min * Y_Div);

						tim_cnt = 0;
						old_t += X_Div * T_Div;
					}
				}

				if (Properties.Settings.Default.WAVE_TrgEnable)
				{
					int trg_p = new int();		//20170927 add

					if (IsTrg && !IsHold)
					{
						trg_p = TrgPtr2 + 1;
					}
					else
					{
						trg_p = TrgPtr3 + 1;
					}

					if (j == trg_p)
					{
						//トリガ位置描画
						trg_x = WaveStartOffset + i * X_Div;
						g.DrawLine(TrgPen, trg_x, 0, trg_x, picWave.Height - WAVE_HOLD_OFFSET2);	//20170810 update (pnlWave.Bottom) -> (picWave.Bottom - WAVE_HOLD_OFFSET2)
					}

					if (j == trg_p + PosSettingTime &&
						TrgItem == TrgItemEnum.TRG_CMD && TrgIsGE == false)
					{
						//トリガ位置描画
						trg_x = WaveStartOffset + i * X_Div;
						g.DrawLine(TrgPen, trg_x, 0, trg_x, picWave.Height - WAVE_HOLD_OFFSET2);	//20170810 update (pnlWave.Bottom) -> (picWave.Bottom - WAVE_HOLD_OFFSET2)
					}

				}

				if (log)
				{
					old_l += X_Div;
 
					float now = old_l + X_Div;
					float end = picWave.Width - WaveEndOffset;
					int tim = j * LogWork.LogPeriod;

					if ((tim % 500) == 0 && now < end)
					{
						g.DrawString((tim / 1000.0F).ToString("F1") + " [s]", TimeFont, new SolidBrush(Color.White), now, picWave.Height - WAVE_HOLD_OFFSET2);		//20170810 update (picWave.Height) -> (picWave.Height - WAVE_HOLD_OFFSET2)
					}
				}
			
				#region 整定時間を正確に表示する場合　START
				/*
				if (IsTrg)
				{
					s = TrgData[LogWork.STS, j];
					s2 = TrgData[LogWork.STS, j];
				}
				else
				{
					s = LogData[LogWork.STS, j];
					s2 = LogData[LogWork.STS, j];
				}

				//インポジション描画
				if (Properties.Settings.Default.WAVE_InposView)
				{
					float x1 = WaveStartOffset + i * X_Div;
					float x2 = WaveStartOffset + i * X_Div + X_Div;

					//インポジション信号
					if ((s & 0x04) == 0x04)
					{
						sts = (y_center + (y_scale * InposOff)) - y_scale * 0.8F;

						if (old_s != sts)
						{
							g.DrawLine(InpPen, x1, old_s, x2, old_s);
							g.DrawLine(InpPen, x2, old_s, x2, sts);
						}
						else
						{
							g.DrawLine(InpPen, x1, old_s, x2, sts);
						}
					}
					else
					{
						sts = (y_center + (y_scale * InposOff)) - y_scale * 0.2F;

						if (old_s != sts)
						{
							g.DrawLine(InpPen, x1, old_s, x2, old_s);
							g.DrawLine(InpPen, x2, old_s, x2, sts);
						}
						else
						{
							g.DrawLine(InpPen, x1, old_s, x2, sts);
						}
					}

				}

				//コマンドポジション描画
				if (Properties.Settings.Default.WAVE_CmdposView)
				{
					float x1 = WaveStartOffset + i * X_Div;
					float x2 = WaveStartOffset + i * X_Div + X_Div;
					
					//指令有り信号
					if ((s2 & 0x40000000) == 0x40000000)
					{
						sts2 = (y_center + (y_scale * CmdposOff)) - y_scale * 0.8F;

						if (old_s2 != sts2)
						{
							g.DrawLine(CmdPen, x1, old_s2, x2, old_s2);
							g.DrawLine(CmdPen, x2, old_s2, x2, sts2);

						}
						else
						{
							g.DrawLine(CmdPen, x1, old_s2, x2, sts2);
						}
					}
					else
					{
						sts2 = (y_center + (y_scale * CmdposOff)) - y_scale * 0.2F;

						if (old_s2 != sts2)
						{
							g.DrawLine(CmdPen, x1, old_s2, x2, old_s2);
							g.DrawLine(CmdPen, x2, old_s2, x2, sts2);
						}
						else
						{
							g.DrawLine(CmdPen, x1, old_s2, x2, sts2);
						}
					}
				}
				old_s = sts;
				old_s2 = sts2;
		
				*/
				#endregion 整定時間を正確に表示する場合　END

				//波形描画間引き処理
				if ((i % div_cnt) != 0) { continue; }
				
				//波形データ取得				
				if (IsTrg && !IsHold)		//20170927 update
				{
				    pos = y_center - (float)TrgData[LogWork.POS, j] * P_Mul / (float)P_Div * y_scale + P_Pos;
					vel = y_center - (float)TrgData[LogWork.VEL, j] * V_Mul / (float)V_Div * y_scale + V_Pos;
					cur = y_center - (float)TrgData[LogWork.CUR, j] * I_Mul / (float)I_Div * y_scale + I_Pos;

					prm1 = y_center - (float)TrgData[LogWork.PRM1, j] * Prm1_Mul / (float)Prm1_Div * y_scale + Prm1_Pos;
					prm2 = y_center - (float)TrgData[LogWork.PRM2, j] * Prm2_Mul / (float)Prm2_Div * y_scale + Prm2_Pos;
					prm3 = y_center - (float)TrgData[LogWork.PRM3, j] * Prm3_Mul / (float)Prm3_Div * y_scale + Prm3_Pos;

				    s1 = TrgData[LogWork.STS, j];
				    s2 = TrgData[LogWork.STS, j];
				}
				else
				{
					try
					{
						pos = y_center - (float)LogData[LogWork.POS, j] * P_Mul / (float)P_Div * y_scale + P_Pos;
					}
					catch
					{

					}

					vel = y_center - (float)LogData[LogWork.VEL, j] * V_Mul / (float)V_Div * y_scale + V_Pos;
					cur = y_center - (float)LogData[LogWork.CUR, j] * I_Mul / (float)I_Div * y_scale + I_Pos;

					prm1 = y_center - (float)LogData[LogWork.PRM1, j] * Prm1_Mul / (float)Prm1_Div * y_scale + Prm1_Pos;
					prm2 = y_center - (float)LogData[LogWork.PRM2, j] * Prm2_Mul / (float)Prm2_Div * y_scale + Prm2_Pos;
					prm3 = y_center - (float)LogData[LogWork.PRM3, j] * Prm3_Mul / (float)Prm3_Div * y_scale + Prm3_Pos;

					s1 = LogData[LogWork.STS, j];
					s2 = LogData[LogWork.STS, j];
				}
			
				//描画初期位置の設定。最初のデータに合わせる
				if (i == 0)
				{
					old_p = GetOldData(y_center, y_max, pos);
					old_v = GetOldData(y_center, y_max, vel);
					old_c = GetOldData(y_center, y_max, cur);

					old_prm1 = GetOldData(y_center, y_max, prm1);
					old_prm2 = GetOldData(y_center, y_max, prm2);
					old_prm3 = GetOldData(y_center, y_max, prm3);

					if ((s1 & 0x04) == 0x04)
					{
						old_s1 = (y_center + (y_scale * InposOff)) - y_scale * 0.8F;
					}
					else
					{
						old_s1 = (y_center + (y_scale * InposOff)) - y_scale * 0.2F;
					}

					if ((s2 & 0x40000000) == 0x40000000)
					{
						old_s2 = (y_center + (y_scale * CmdposOff)) - y_scale * 0.8F;
					}
					else
					{
						old_s2 = (y_center + (y_scale * CmdposOff)) - y_scale * 0.2F;
					}

					old_s1 = GetOldData(y_center, y_max, old_s1);		//20170809 add 縦軸拡大時に描画範囲からはみ出る件を修正。
					old_s2 = GetOldData(y_center, y_max, old_s2);		//20170809 add 縦軸拡大時に描画範囲からはみ出る件を修正。
				}

				//インポジション描画
				if (Properties.Settings.Default.WAVE_InposView)
				{
					//インポジション信号
					if ((s1 & 0x04) == 0x04)
					{
						sts1 = (y_center + (y_scale * InposOff)) - y_scale * 0.8F;

						if (Math.Abs(y_center - sts1) <= y_max)			//20170809 update 縦軸拡大時に描画範囲からはみ出る件を修正。
						{
							if (old_s1 != sts1)
							{
								g.DrawLine(InpPen, old_x, old_s1, old_x + x_div, old_s1);
								g.DrawLine(InpPen, old_x + x_div, old_s1, old_x + x_div, sts1);
							}
							else
							{
								g.DrawLine(InpPen, old_x, old_s1, old_x + x_div, sts1);
							}
						}
						else
						{
							if (sts1 < y_center)
							{
								g.DrawLine(InpPen, old_x, old_s1, old_x + x_div, y_center - y_max);
							}
							else
							{
								g.DrawLine(InpPen, old_x, old_s1, old_x + x_div, y_center + y_max);
							}
						}
					}
					else
					{
						sts1 = (y_center + (y_scale * InposOff)) - y_scale * 0.2F;

						if (Math.Abs(y_center - sts1) <= y_max)			//20170809 update 縦軸拡大時に描画範囲からはみ出る件を修正。
						{
							if (old_s1 != sts1)
							{
								g.DrawLine(InpPen, old_x, old_s1, old_x + x_div, old_s1);
								g.DrawLine(InpPen, old_x + x_div, old_s1, old_x + x_div, sts1);
							}
							else
							{
								g.DrawLine(InpPen, old_x, old_s1, old_x + x_div, sts1);
							}
						}
						else
						{
							if (sts1 < y_center)
							{
								g.DrawLine(InpPen, old_x, old_s1, old_x + x_div, y_center - y_max);
							}
							else
							{
								g.DrawLine(InpPen, old_x, old_s1, old_x + x_div, y_center + y_max);
							}
						}
					}
				}

				//コマンドポジション描画
				if (Properties.Settings.Default.WAVE_CmdposView)
				{
					//指令有り信号
					if ((s2 & 0x40000000) == 0x40000000)
					{
						sts2 = (y_center + (y_scale * CmdposOff)) - y_scale * 0.8F;

						if (Math.Abs(y_center - sts2) <= y_max)			//20170809 update 縦軸拡大時に描画範囲からはみ出る件を修正。
						{
							if (old_s2 != sts2)
							{
								g.DrawLine(CmdPen, old_x, old_s2, old_x + x_div, old_s2);
								g.DrawLine(CmdPen, old_x + x_div, old_s2, old_x + x_div, sts2);
							}
							else
							{
								g.DrawLine(CmdPen, old_x, old_s2, old_x + x_div, sts2);
							}
						}
						else
						{
							if (sts1 < y_center)
							{
								g.DrawLine(CmdPen, old_x, old_s2, old_x + x_div, y_center - y_max);
							}
							else
							{
								g.DrawLine(CmdPen, old_x, old_s2, old_x + x_div, y_center + y_max);
							}
						}
					}
					else
					{
						sts2 = (y_center + (y_scale * CmdposOff)) - y_scale * 0.2F;

						if (Math.Abs(y_center - sts2) <= y_max)			//20170809 update 縦軸拡大時に描画範囲からはみ出る件を修正。
						{
							if (old_s2 != sts2)
							{
								g.DrawLine(CmdPen, old_x, old_s2, old_x + x_div, old_s2);
								g.DrawLine(CmdPen, old_x + x_div, old_s2, old_x + x_div, sts2);
							}
							else
							{
								g.DrawLine(CmdPen, old_x, old_s2, old_x + x_div, sts2);
							}
						}
						else
						{
							if (sts1 < y_center)
							{
								g.DrawLine(CmdPen, old_x, old_s2, old_x + x_div, y_center - y_max);
							}
							else
							{
								g.DrawLine(CmdPen, old_x, old_s2, old_x + x_div, y_center + y_max);
							}
						}
					}
				}

				//位置データ描画
				if (Properties.Settings.Default.WAVE_PosView)
				{
					if (Math.Abs(y_center - pos) <= y_max)
					{
						g.DrawLine(PosPen, old_x, old_p, old_x + x_div, pos);
					}
					else
					{
						if (pos < y_center)
						{
							g.DrawLine(PosPen, old_x, old_p, old_x + x_div, y_center - y_max);
						}
						else
						{
							g.DrawLine(PosPen, old_x, old_p, old_x + x_div, y_center + y_max);
						}
					}
				}

				//速度データ描画
				if (Properties.Settings.Default.WAVE_VelView)
				{
					if (Math.Abs(y_center - vel) <= y_max)
					{
						g.DrawLine(VelPen, old_x, old_v, old_x + x_div, vel);
					}
					else
					{
						if (vel < y_center)
						{
							g.DrawLine(VelPen, old_x, old_v, old_x + x_div, y_center - y_max);
						}
						else
						{
							g.DrawLine(VelPen, old_x, old_v, old_x + x_div, y_center + y_max);
						}
					}
				}
				
				//電流データ描画
				if (Properties.Settings.Default.WAVE_CurView)
				{
					if (Math.Abs(y_center - cur) <= y_max)
					{
						g.DrawLine(CurPen, old_x, old_c, old_x + x_div, cur);
					}
					else
					{
						if (cur < y_center)
						{
							g.DrawLine(CurPen, old_x, old_c, old_x + x_div, y_center - y_max);
						}
						else
						{
							g.DrawLine(CurPen, old_x, old_c, old_x + x_div, y_center + y_max);
						}
					}
				}

				//パラメタ1描画
				if (Properties.Settings.Default.WAVE_Prm1View)
				{
					if (Math.Abs(y_center - prm1) <= y_max)
					{
						g.DrawLine(Prm1Pen, old_x, old_prm1, old_x + x_div, prm1);
					}
					else
					{
						if (prm1 < y_center)
						{
							g.DrawLine(Prm1Pen, old_x, old_prm1, old_x + x_div, y_center - y_max);
						}
						else
						{
							g.DrawLine(Prm1Pen, old_x, old_prm1, old_x + x_div, y_center + y_max);
						}
					}
				}

				//パラメタ2描画
				if (Properties.Settings.Default.WAVE_Prm2View)
				{
					if (Math.Abs(y_center - prm2) <= y_max)
					{
						g.DrawLine(Prm2Pen, old_x, old_prm2, old_x + x_div, prm2);
					}
					else
					{
						if (prm2 < y_center)
						{
							g.DrawLine(Prm2Pen, old_x, old_prm2, old_x + x_div, y_center - y_max);
						}
						else
						{
							g.DrawLine(Prm2Pen, old_x, old_prm2, old_x + x_div, y_center + y_max);
						}
					}
				}

				//パラメタ3描画
				if (Properties.Settings.Default.WAVE_Prm3View)
				{
					if (Math.Abs(y_center - prm3) <= y_max)
					{
						g.DrawLine(Prm3Pen, old_x, old_prm3, old_x + x_div, prm3);
					}
					else
					{
						if (prm3 < y_center)
						{
							g.DrawLine(Prm3Pen, old_x, old_prm3, old_x + x_div, y_center - y_max);
						}
						else
						{
							g.DrawLine(Prm3Pen, old_x, old_prm3, old_x + x_div, y_center + y_max);
						}
					}
				}

				//次回描画開始位置設定
				old_p = GetOldData(y_center, y_max, pos);
				old_v = GetOldData(y_center, y_max, vel);
				old_c = GetOldData(y_center, y_max, cur);

				old_prm1 = GetOldData(y_center, y_max, prm1);
				old_prm2 = GetOldData(y_center, y_max, prm2);
				old_prm3 = GetOldData(y_center, y_max, prm3);

				old_s1 = GetOldData(y_center, y_max, sts1);			//20170809 update 縦軸拡大時に描画範囲からはみ出る件を修正。 (old_s = sts)  -> (old_s  = GetOld())
				old_s2 = GetOldData(y_center, y_max, sts2);			//20170809 update 縦軸拡大時に描画範囲からはみ出る件を修正。 (old_s = sts2) -> (old_s2 = GetOld())
				
				old_x += x_div;

			}

			if (trg_x >= 0.0F && IsTrg)
			{
				lblPositionTime.Visible = true;
				lblPositionTime.Location = new Point((int)trg_x + 5, picWave.Location.Y + 5);

				string text = string.Empty;

				if (TrgItem == TrgItemEnum.TRG_CMD && TrgIsGE == false)
				{
					if (PosSettingTime == 9999)
					{
						text = UserText.DigitalOsilloInpositionTime + UserText.DigitalOsilloInpositionTimeError;
					}
					else
					{
						text = UserText.DigitalOsilloInpositionTime + (PosSettingTime * LogWork.LogPeriod).ToString() + " [msec]";
					}
				}
				else
				{
					text = UserText.DigitalOsilloTriggerCondition + cmbTrgCond.Text;
					PosSettingTime = 0;
				}

				switch (TrgStone)
				{
					case 0:
						lblPositionTime.Text = (text + " . ");
						break;
					case 1:
						lblPositionTime.Text = (text + " .. ");
						break;
					case 2:
						lblPositionTime.Text = (text + " ... ");
						break;
					case 3:
						lblPositionTime.Text = (text + " .... ");
						break;
				}

			}
			else
			{
				lblPositionTime.Visible = false;
			}
		}

		private float GetOldData(float center, float max, float act_data)
		{
			if (Math.Abs(center - act_data) <= max)
			{
				return act_data;
			}
			else
			{
				if (act_data < center)
				{
					return center - max;
				}
				else
				{
					return center + max;
				}
			}
		}

		private int GetTrgOffset(int width)
		{
			double trg_div = new double();
			int trg_pos = Properties.Settings.Default.WAVE_TrgPosition;

			if (trg_pos <= 0)
			{
				trg_div = (double)(8 + trg_pos) / 16.0;
			}
			else
			{
				trg_div = (double)(8 + trg_pos) / 16.0;
			}

			return (int)(width * trg_div);
		}

		private void ReDrawWave()
		{
			DisableDraw = false;
			picWave.Refresh();
			//DisableDraw = true;
		}

		#endregion

		#region Panel Event

		private void picWave_Click(object sender, EventArgs e)
		{
			//フォーカスチェンジ　TOOLボタン等にフォーカスがあるとマウスホイールイベント発生しない。
			pnlBase.Focus();
		}

		private void pnlWave_Resize(object sender, EventArgs e)
		{
			if (IsHold) { UpdateHoldView(true); }

			if (pnlWave.Width - WaveStartOffset - 10 > 0)
			{
				trackTimeMeas1.Maximum = (int)(pnlWave.Width - WaveStartOffset - WaveEndOffset) * TRACK_SCALE;
				trackTimeMeas1.Minimum = 0;

				trackTimeMeas2.Maximum = trackTimeMeas1.Maximum;
				trackTimeMeas2.Minimum = trackTimeMeas1.Minimum;

				UpdateTrackChageValue();
				
				ReDrawWave();
			}
		}

		private void picWave_Resize(object sender, EventArgs e)
		{
			if (BackupPicWaveHeight != 0 && picWave.Height >= 1.0F)
			{
				float x = (float)BackupPicWaveHeight;
				float y = (float)picWave.Height;

				P_Pos = Properties.Settings.Default.WAVE_P_Pos / x * y;
				V_Pos = Properties.Settings.Default.WAVE_V_Pos / x * y;
				I_Pos = Properties.Settings.Default.WAVE_I_Pos / x * y;
				Prm1_Pos = Properties.Settings.Default.WAVE_Prm1_Pos / x * y;
				Prm2_Pos = Properties.Settings.Default.WAVE_Prm2_Pos / x * y;
				Prm3_Pos = Properties.Settings.Default.WAVE_Prm3_Pos / x * y;

				Properties.Settings.Default.WAVE_P_Pos = P_Pos;
				Properties.Settings.Default.WAVE_V_Pos = V_Pos;
				Properties.Settings.Default.WAVE_I_Pos = I_Pos;
				Properties.Settings.Default.WAVE_Prm1_Pos = Prm1_Pos;
				Properties.Settings.Default.WAVE_Prm2_Pos = Prm2_Pos;
				Properties.Settings.Default.WAVE_Prm3_Pos = Prm3_Pos;

				BackupPicWaveHeight = picWave.Height;
				Properties.Settings.Default.WAVE_BackupHeight = BackupPicWaveHeight;
			}
		}
		
		private void pnlSetting_Click(object sender, EventArgs e)
		{
			Panel pnl = (Panel)sender;

			pnl.Focus();
		}

		#endregion

		#region Quick Monitor

		private Point MousePointNow = new Point();
		private Point MousePointNew = new Point();

		private bool MouseDownFlag = new bool();
		private bool QuickReadFlag = false;

		private bool IsWaveCatch = new bool();
		private bool EnableWaveOffsetMove = new bool();

		private bool IsWaveScaleUp = new bool();
		private bool IsWaveScaleDn = new bool();
		private bool EnableWaveScaleUp = new bool();
		private bool EnableWaveScaleDn = new bool();

		private int old_mouse_x = new int();
		private int old_mouse_y = new int();

		private int BackupPenIndex = new int();
		private Pen BackupPen;
		private float BackupPenWidth = new float();

		private int BK_Hscl2 = new int();

		private int BackupPicWaveHeight = new int();

		private void picWave_MouseLeave(object sender, EventArgs e)
		{
			CancelQuickMonitor();
		}

		private void picWave_MouseMove(object sender, MouseEventArgs e)
		{
			try
			{
				bool is_play = new bool();

				if (!IsHold && !IsTrg) { is_play = true; }					//連続表示かつトリガOFFなら波形キャッチは項目のみ

				MousePointNew.X = e.X;
				MousePointNew.Y = e.Y;

				if (old_mouse_x == e.X && old_mouse_y == e.Y) { return; }	//連続的に割り込みが入るのを禁止

				if (CheckWaveOffsetMove())
				{
					old_mouse_x = e.X;
					old_mouse_y = e.Y;

					return;
				}

				old_mouse_x = e.X;
				old_mouse_y = e.Y;

				if (CheckWaveItemCatch()) { return; }

				int dlt_x = 0;
				int tmp_x = 0;

				if (MouseDownFlag == true)
				{
					dlt_x = -(MousePointNew.X - MousePointNow.X);

					tmp_x = BK_Hscl2 + dlt_x;

					if (tmp_x > 0 && tmp_x < hSclWave.Maximum) { hSclWave.Value = tmp_x; }

					if (IsTrg && !IsHold)		//20170927 update
					{
						//トリガ表示かつ波形表示中の時は描画しない
					}
					else
					{
						ReDrawWave();
					}

					return;
				}

				int scl_pos = 0;
				int log_idx = 0;

				if (IsTrg && !IsHold)			//20170927 update
				{
					int wcnt = (int)((picWave.Width - WaveStartOffset - WaveEndOffset) / X_Div);

					int trg_off = GetTrgOffset(wcnt);

					if ((TrgPtr2 - trg_off) < 0)					//-1はダミーデータ分
					{
						scl_pos = LogWork.LogLength + TrgPtr2 - trg_off;
					}
					else
					{
						scl_pos = TrgPtr2 - trg_off;
					}

					log_idx = scl_pos + (int)((MousePointNew.X - WaveStartOffset) / X_Div) - 1;

					if (log_idx >= LogWork.LogLength) { log_idx = log_idx - LogWork.LogLength; }
                    
                    if (log_idx < 0) { log_idx = LogWork.LogLength + log_idx; }
				}
				else
				{
					scl_pos = (int)(hSclWave.Value / X_Div);
					log_idx = scl_pos + (int)((MousePointNew.X - WaveStartOffset) / X_Div) - 1;

					if (log_idx >= LogWork.LogLength) { log_idx = log_idx - LogWork.LogLength; }
					
                    if (log_idx < 0) { log_idx = LogWork.LogLength + log_idx; }
				}

                if (log_idx >= LogWork.LogLength) return; //20220106 Ver1.31 add

				float y_center = new float();
				float y_scale = new float();

				y_center = picWave.Height / 2 - WAVE_HOLD_OFFSET;		//20170927 update

				y_scale = y_center / Y_Div;

				float[] log_dat = new float[6];
				float[] y_pos = new float[6];
				float[] l_siz = new float[6];

				bool[] visible = new bool[6];

				Pen[] w_pen = new Pen[6];

				if (IsTrg && !IsHold)		//20170927 update
				{
                    log_dat[0] = (float)TrgData[LogWork.POS, log_idx];
					log_dat[1] = (float)TrgData[LogWork.VEL, log_idx];
					log_dat[2] = (float)TrgData[LogWork.CUR, log_idx];
					log_dat[3] = (float)TrgData[LogWork.PRM1, log_idx];
					log_dat[4] = (float)TrgData[LogWork.PRM2, log_idx];
					log_dat[5] = (float)TrgData[LogWork.PRM3, log_idx];
				}
				else
				{
					log_dat[0] = (float)LogData[LogWork.POS, log_idx];
					log_dat[1] = (float)LogData[LogWork.VEL, log_idx];
					log_dat[2] = (float)LogData[LogWork.CUR, log_idx];
					log_dat[3] = (float)LogData[LogWork.PRM1, log_idx];
					log_dat[4] = (float)LogData[LogWork.PRM2, log_idx];
					log_dat[5] = (float)LogData[LogWork.PRM3, log_idx];
				}

				y_pos[0] = y_center - log_dat[0] * P_Mul / (float)P_Div * y_scale + P_Pos;		//位置
				y_pos[1] = y_center - log_dat[1] * V_Mul / (float)V_Div * y_scale + V_Pos;		//速度
				y_pos[2] = y_center - log_dat[2] * I_Mul / (float)I_Div * y_scale + I_Pos;		//電流
				y_pos[3] = y_center - log_dat[3] * Prm1_Mul / (float)Prm1_Div * y_scale + Prm1_Pos;//パラメタ1
				y_pos[4] = y_center - log_dat[4] * Prm2_Mul / (float)Prm2_Div * y_scale + Prm2_Pos;//パラメタ2
				y_pos[5] = y_center - log_dat[5] * Prm3_Mul / (float)Prm3_Div * y_scale + Prm3_Pos;//パラメタ3

				visible[0] = Properties.Settings.Default.WAVE_PosView;
				visible[1] = Properties.Settings.Default.WAVE_VelView;
				visible[2] = Properties.Settings.Default.WAVE_CurView;
				visible[3] = Properties.Settings.Default.WAVE_Prm1View;
				visible[4] = Properties.Settings.Default.WAVE_Prm2View;
				visible[5] = Properties.Settings.Default.WAVE_Prm3View;

				w_pen[0] = PosPen;
				w_pen[1] = VelPen;
				w_pen[2] = CurPen;
				w_pen[3] = Prm1Pen;
				w_pen[4] = Prm2Pen;
				w_pen[5] = Prm3Pen;

				l_siz[0] = Properties.Settings.Default.WAVE_PosLineSize;
				l_siz[1] = Properties.Settings.Default.WAVE_VelLineSize;
				l_siz[2] = Properties.Settings.Default.WAVE_CurLineSize;
				l_siz[3] = Properties.Settings.Default.WAVE_Prm1LineSize;
				l_siz[4] = Properties.Settings.Default.WAVE_Prm2LineSize;
				l_siz[5] = Properties.Settings.Default.WAVE_Prm3LineSize;

				for (int j = 0; j < y_pos.Length; j++)
				{
					if (y_pos[j] + 10 >= MousePointNew.Y && y_pos[j] - 10 <= MousePointNew.Y && visible[j])
					{
						if (QuickReadFlag == true)
						{
							ReDrawWave();
						}
						else
						{
							IsWaveCatch = true;

							BackupPenIndex = j;
							BackupPenWidth = l_siz[j];
							BackupPen = w_pen[j];
							BackupPen.Width = l_siz[j];
							w_pen[j].Width = l_siz[j] * 2.0F;

							switch (j)
							{
								case 0:
									PosFont = AppFont.ArialBold9;
									break;
								case 1:
									VelFont = AppFont.ArialBold9;
									break;
								case 2:
									CurFont = AppFont.ArialBold9;
									break;
								case 3:
									Prm1Font = AppFont.ArialBold9;
									break;
								case 4:
									Prm2Font = AppFont.ArialBold9;
									break;
								case 5:
									Prm3Font = AppFont.ArialBold9;
									break;
							}
						}

						if (!is_play)
						{
							Graphics g = picWave.CreateGraphics();
							Pen arc = new Pen(Color.White, 1);
							float x_pos = (log_idx - scl_pos + 1) * X_Div + WaveStartOffset;

							g.DrawArc(arc, x_pos - 5.0F, y_pos[j] - 1.0F, 10, 10, 0, 360);		//20170927 update

							string txt_pos = cmbLogPos.Text;

							lblQuickView.Text = "Quick Monitor" + "\n"
												+ cmbLogPos.Text + " ： " + log_dat[0].ToString() + "[pulse]" + "\n"
												+ cmbLogVel.Text + " ： " + log_dat[1].ToString() + "[rpm]" + "\n"
												+ cmbLogCur.Text + " ： " + (log_dat[2] / 100).ToString() + "[A]" + "\n"
												+ "ID No." + numLogPrm1.Value.ToString() + " ： " + log_dat[3].ToString() + "\n"
												+ "ID No." + numLogPrm2.Value.ToString() + " ： " + log_dat[4].ToString() + "\n"
												+ "ID No." + numLogPrm3.Value.ToString() + " ： " + log_dat[5].ToString();

							Point pt = new Point();

							pt.X = pnlWave.Width - lblQuickView.Width - 10;
							pt.Y = pnlWave.Height - lblQuickView.Height - 10;

							lblQuickView.Location = pt;
							lblQuickView.Visible = true;
							lblQuickView.Refresh();

							g.Dispose();
							arc.Dispose();

							QuickReadFlag = true;
						}

						picWave.Cursor = Cursors.Hand;

						return;
					}
				}

				CancelQuickMonitor();

				//埋め込まれたカーソルリソースの呼び出し
				picWave.Cursor = new Cursor(new MemoryStream(Properties.Resources.HandOpen));
			}
			catch (Exception ex)
			{
				UserMessageBox.CommonCatchErrorMessage(ex);
			}
		}

		private void CancelQuickMonitor()
		{
		
			QuickReadFlag = false;
			lblQuickView.Visible = false;
		
			IsWaveCatch = false;
			EnableWaveOffsetMove = false;

			IsWaveScaleUp = false;
			IsWaveScaleDn = false;
			EnableWaveScaleUp = false;
			EnableWaveScaleDn = false;

			PosPen.Width = Properties.Settings.Default.WAVE_PosLineSize;
			VelPen.Width = Properties.Settings.Default.WAVE_VelLineSize;
			CurPen.Width = Properties.Settings.Default.WAVE_CurLineSize;
			Prm1Pen.Width = Properties.Settings.Default.WAVE_Prm1LineSize;
			Prm2Pen.Width = Properties.Settings.Default.WAVE_Prm2LineSize;
			Prm3Pen.Width = Properties.Settings.Default.WAVE_Prm3LineSize;
			
			PosFont = AppFont.ArialRegular8;
			VelFont = AppFont.ArialRegular8;
			CurFont = AppFont.ArialRegular8;
			Prm1Font = AppFont.ArialRegular8;
			Prm2Font = AppFont.ArialRegular8;
			Prm3Font = AppFont.ArialRegular8;

			ReDrawWave();
		}

		private bool CheckWaveOffsetMove()
		{
			if (EnableWaveOffsetMove)
			{
				int off = MousePointNew.Y - old_mouse_y;

				BackupPicWaveHeight = picWave.Height;

				switch (BackupPenIndex)
				{
					case 0:

						P_Pos += off;
						Properties.Settings.Default.WAVE_P_Pos = P_Pos;

						if (P_Pos <= 1.0 && P_Pos >= -1.0) { P_Pos = 0.0F; EnableWaveOffsetMove = false; }

						break;

					case 1:

						V_Pos += off;
						Properties.Settings.Default.WAVE_V_Pos = V_Pos;

						if (V_Pos <= 1.0 && V_Pos >= -1.0) { V_Pos = 0.0F; EnableWaveOffsetMove = false; }

						break;

					case 2:

						I_Pos += off;
						Properties.Settings.Default.WAVE_I_Pos = I_Pos;

						if (I_Pos <= 1.0 && I_Pos >= -1.0) { I_Pos = 0.0F; EnableWaveOffsetMove = false; }

						break;

					case 3:

						Prm1_Pos += off;
						Properties.Settings.Default.WAVE_Prm1_Pos = Prm1_Pos;

						if (Prm1_Pos <= 1.0 && Prm1_Pos >= -1.0) { Prm1_Pos = 0.0F; EnableWaveOffsetMove = false; }

						break;

					case 4:

						Prm2_Pos += off;
						Properties.Settings.Default.WAVE_Prm2_Pos = Prm2_Pos;

						if (Prm2_Pos <= 1.0 && Prm2_Pos >= -1.0) { Prm2_Pos = 0.0F; EnableWaveOffsetMove = false; }

						break;

					case 5:

						Prm3_Pos += off;
						Properties.Settings.Default.WAVE_Prm3_Pos = Prm3_Pos;

						if (Prm3_Pos <= 1.0 && Prm3_Pos >= -1.0) { Prm3_Pos = 0.0F; EnableWaveOffsetMove = false; }

						break;
				}

				ReDrawWave();
	
				return true;
			}

			if (EnableWaveScaleUp || EnableWaveScaleDn)
			{
				float sub = (float)(MousePointNew.Y - old_mouse_y);

				float now = (float)picWave.Height / 2.0F;

				float mul = new float();

				if (EnableWaveScaleUp)
				{
					mul = -sub / now;
				}
				else
				{
					mul = sub / now;
				}

				switch (BackupPenIndex)
				{
					case 0:

						P_Mul += mul;
						if (P_Mul >= 1.0F) { P_Mul = 1.0F; }
						if (P_Mul <= 0.1F) { P_Mul = 0.1F; }
						Properties.Settings.Default.WAVE_P_Mul = P_Mul;					
						break;

					case 1:

						V_Mul += mul;
						if (V_Mul >= 1.0F) { V_Mul = 1.0F; }
						if (V_Mul <= 0.1F) { V_Mul = 0.1F; }
						Properties.Settings.Default.WAVE_V_Mul = V_Mul;
						break;

					case 2:

						I_Mul += mul;
						if (I_Mul >= 1.0F) { I_Mul = 1.0F; }
						if (I_Mul <= 0.1F) { I_Mul = 0.1F; }
						Properties.Settings.Default.WAVE_I_Mul = I_Mul;
						break;

					case 3:

						Prm1_Mul += mul;
						if (Prm1_Mul >= 1.0F) { Prm1_Mul = 1.0F; }
						if (Prm1_Mul <= 0.1F) { Prm1_Mul = 0.1F; }
						Properties.Settings.Default.WAVE_Prm1_Mul = Prm1_Mul;
						break;

					case 4:

						Prm2_Mul += mul;
						if (Prm2_Mul >= 1.0F) { Prm2_Mul = 1.0F; }
						if (Prm2_Mul <= 0.1F) { Prm2_Mul = 0.1F; }
						Properties.Settings.Default.WAVE_Prm2_Mul = Prm2_Mul;
						break;

					case 5:

						Prm3_Mul += mul;
						if (Prm3_Mul >= 1.0F) { Prm3_Mul = 1.0F; }
						if (Prm3_Mul <= 0.1F) { Prm3_Mul = 0.1F; }
						Properties.Settings.Default.WAVE_Prm3_Mul = Prm3_Mul;
						break;
				}

				ReDrawWave();

				return true;
			}

			return false;
		}

		private bool CheckWaveItemCatch()
		{
			//マウスカーソルがグラフ描画範囲外
			if (MousePointNew.X < WaveStartOffset || MousePointNew.X > picWave.Width - WaveEndOffset)
			{
				for (int i = 0; i < listP_UnitPos.Count; i++)
				{
					if (listP_UnitPos[i].Y - 5 <= MousePointNew.Y &&
						listP_UnitPos[i].Y + 10 >= MousePointNew.Y &&
						listP_UnitPos[i].X - 5 <= MousePointNew.X &&
						listP_UnitPos[i].X + WaveStartOffset >= MousePointNew.X
						)
					{
						IsWaveCatch = true;

						BackupPenIndex = 0;
						BackupPenWidth = Properties.Settings.Default.WAVE_PosLineSize;
						BackupPen = PosPen;
						PosPen.Width = BackupPenWidth * 2.0F;

						PosFont = AppFont.ArialBold8;

						if (i == listP_UnitPos.Count - 1 && i != 0)
						{
							IsWaveScaleDn = true;
							picWave.Cursor = Cursors.SizeNS;
						}
						else if (i == listP_UnitPos.Count - 2 && i != 0)
						{
							IsWaveScaleUp = true;
							picWave.Cursor = Cursors.SizeNS;
						}
						else
						{
							IsWaveScaleUp = false;
							IsWaveScaleDn = false;
							picWave.Cursor = Cursors.Hand;
						}

						ReDrawWave();

						return true;
					}
				}
			
				for (int i = 0; i < listV_UnitPos.Count; i++)
				{
					if (listV_UnitPos[i].Y - 5 <= MousePointNew.Y &&
						listV_UnitPos[i].Y + 10 >= MousePointNew.Y &&
						listV_UnitPos[i].X - 5 <= MousePointNew.X &&
						listV_UnitPos[i].X + WaveStartOffset >= MousePointNew.X
						)
					{
						IsWaveCatch = true;

						BackupPenIndex = 1;
						BackupPenWidth = Properties.Settings.Default.WAVE_VelLineSize;
						BackupPen = VelPen;
						VelPen.Width = BackupPenWidth * 2.0F;

						VelFont = AppFont.ArialBold8;

						if (i == listV_UnitPos.Count - 1 && i != 0)
						{
							IsWaveScaleDn = true;
							picWave.Cursor = Cursors.SizeNS;
						}
						else if (i == listV_UnitPos.Count - 2 && i != 0)
						{
							IsWaveScaleUp = true;
							picWave.Cursor = Cursors.SizeNS;
						}
						else
						{
							IsWaveScaleUp = false;
							IsWaveScaleDn = false;
							picWave.Cursor = Cursors.Hand;
						}

						ReDrawWave();

						return true;
					}
				}

				for (int i = 0; i < listI_UnitPos.Count; i++)
				{
					if (listI_UnitPos[i].Y - 5 <= MousePointNew.Y &&
						listI_UnitPos[i].Y + 10 >= MousePointNew.Y &&
						listI_UnitPos[i].X - 5 <= MousePointNew.X &&
						listI_UnitPos[i].X + WaveStartOffset >= MousePointNew.X
						)
					{
						IsWaveCatch = true;

						BackupPenIndex = 2;
						BackupPenWidth = Properties.Settings.Default.WAVE_CurLineSize;
						BackupPen = CurPen;
						CurPen.Width = BackupPenWidth * 2.0F;

						CurFont = AppFont.ArialBold8;

						if (i == listI_UnitPos.Count - 1 && i != 0)
						{
							IsWaveScaleDn = true;
							picWave.Cursor = Cursors.SizeNS;
						}
						else if (i == listI_UnitPos.Count - 2 && i != 0)
						{
							IsWaveScaleUp = true;
							picWave.Cursor = Cursors.SizeNS;
						}
						else
						{
							IsWaveScaleUp = false;
							IsWaveScaleDn = false;
							picWave.Cursor = Cursors.Hand;
						}

						ReDrawWave();

						return true;
					}
				}

				for (int i = 0; i < listPrm1_UnitPos.Count; i++)
				{
					if (listPrm1_UnitPos[i].Y - 5 <= MousePointNew.Y &&
						listPrm1_UnitPos[i].Y + 10 >= MousePointNew.Y &&
						listPrm1_UnitPos[i].X - 5 <= MousePointNew.X &&
						listPrm1_UnitPos[i].X + WaveStartOffset >= MousePointNew.X
						)
					{
						IsWaveCatch = true;

						BackupPenIndex = 3;
						BackupPenWidth = Properties.Settings.Default.WAVE_Prm1LineSize;
						BackupPen = Prm1Pen;
						Prm1Pen.Width = BackupPenWidth * 2.0F;

						Prm1Font = AppFont.ArialBold8;

						if (i == listPrm1_UnitPos.Count - 1 && i != 0)
						{
							IsWaveScaleDn = true;
							picWave.Cursor = Cursors.SizeNS;
						}
						else if (i == listPrm1_UnitPos.Count - 2 && i != 0)
						{
							IsWaveScaleUp = true;
							picWave.Cursor = Cursors.SizeNS;
						}
						else
						{
							IsWaveScaleUp = false;
							IsWaveScaleDn = false;
							picWave.Cursor = Cursors.Hand;
						}

						ReDrawWave();

						return true;
					}
				}

				for (int i = 0; i < listPrm2_UnitPos.Count; i++)
				{
					if (listPrm2_UnitPos[i].Y - 5 <= MousePointNew.Y &&
						listPrm2_UnitPos[i].Y + 10 >= MousePointNew.Y &&
						listPrm2_UnitPos[i].X - 5 <= MousePointNew.X &&
						listPrm2_UnitPos[i].X + WaveStartOffset >= MousePointNew.X
						)
					{
						IsWaveCatch = true;

						BackupPenIndex = 4;
						BackupPenWidth = Properties.Settings.Default.WAVE_Prm2LineSize;
						BackupPen = Prm2Pen;
						Prm2Pen.Width = BackupPenWidth * 2.0F;

						Prm2Font = AppFont.ArialBold8;

						if (i == listPrm2_UnitPos.Count - 1 && i != 0)
						{
							IsWaveScaleDn = true;
							picWave.Cursor = Cursors.SizeNS;
						}
						else if (i == listPrm2_UnitPos.Count - 2 && i != 0)
						{
							IsWaveScaleUp = true;
							picWave.Cursor = Cursors.SizeNS;
						}
						else
						{
							IsWaveScaleUp = false;
							IsWaveScaleDn = false;
							picWave.Cursor = Cursors.Hand;
						}

						ReDrawWave();

						return true;
					}
				}

				for (int i = 0; i < listPrm3_UnitPos.Count; i++)
				{
					if (listPrm3_UnitPos[i].Y - 5 <= MousePointNew.Y &&
						listPrm3_UnitPos[i].Y + 10 >= MousePointNew.Y &&
						listPrm3_UnitPos[i].X - 5 <= MousePointNew.X &&
						listPrm3_UnitPos[i].X + WaveStartOffset >= MousePointNew.X
						)
					{
						IsWaveCatch = true;

						BackupPenIndex = 5;
						BackupPenWidth = Properties.Settings.Default.WAVE_Prm3LineSize;
						BackupPen = Prm3Pen;
						Prm3Pen.Width = BackupPenWidth * 2.0F;

						Prm3Font = AppFont.ArialBold8;

						if (i == listPrm3_UnitPos.Count - 1 && i != 0)
						{
							IsWaveScaleDn = true;
							picWave.Cursor = Cursors.SizeNS;
						}
						else if (i == listPrm3_UnitPos.Count - 2 && i != 0)
						{
							IsWaveScaleUp = true;
							picWave.Cursor = Cursors.SizeNS;
						}
						else
						{
							IsWaveScaleUp = false;
							IsWaveScaleDn = false;
							picWave.Cursor = Cursors.Hand;
						}

						ReDrawWave();

						return true;
					}
				}

				PosPen.Width = Properties.Settings.Default.WAVE_PosLineSize;
				VelPen.Width = Properties.Settings.Default.WAVE_VelLineSize;
				CurPen.Width = Properties.Settings.Default.WAVE_CurLineSize;
				Prm1Pen.Width = Properties.Settings.Default.WAVE_Prm1LineSize;
				Prm2Pen.Width = Properties.Settings.Default.WAVE_Prm2LineSize;
				Prm3Pen.Width = Properties.Settings.Default.WAVE_Prm3LineSize;

				PosFont = AppFont.ArialRegular8;
				VelFont = AppFont.ArialRegular8;
				CurFont = AppFont.ArialRegular8;
				Prm1Font = AppFont.ArialRegular8;
				Prm2Font = AppFont.ArialRegular8;
				Prm3Font = AppFont.ArialRegular8;

				picWave.Cursor = new Cursor(new MemoryStream(Properties.Resources.HandOpen));

				ReDrawWave();

				return true;
			}

			return false;
		}

		private void picWave_MouseDown(object sender, MouseEventArgs e)
		{
			//PVIグラフ表示
			MousePointNow.X = e.X;
			MousePointNow.Y = e.Y;

			BK_Hscl2 = hSclWave.Value;

			lblQuickView.Visible = false;

			MouseDownFlag = true;

			if (IsWaveCatch)
			{
				if (IsWaveScaleUp || IsWaveScaleDn)
				{
					if (IsWaveScaleUp) { EnableWaveScaleUp = true; }
					if (IsWaveScaleDn) { EnableWaveScaleDn = true; }
				}
				else
				{
					EnableWaveOffsetMove = true;
					//埋め込まれたカーソルリソースの呼び出し
					picWave.Cursor = new Cursor(new MemoryStream(Properties.Resources.HandClose));
				}
			}
			else
			{
				if (IsHold)
				{
					//埋め込まれたカーソルリソースの呼び出し
					picWave.Cursor = new Cursor(new MemoryStream(Properties.Resources.HandClose));
				}
				else
				{
					//PVIグラフ表示で波形再生中
					picWave.Cursor = Cursors.Default;
				}
			}
		}

		private void picWave_MouseUp(object sender, MouseEventArgs e)
		{
			MouseDownFlag = false;

			CancelQuickMonitor();

			if (!IsHold)
			{
				//PVIグラフ表示で波形再生中
				picWave.Cursor = Cursors.Default;
			}
			else
			{
				//波形表示停止中
				picWave.Cursor = new Cursor(new MemoryStream(Properties.Resources.HandOpen));
			}

		}

		#endregion

		#region Timer Measure Event

		private Button btnMeasOn = new Button();
		private int MeasWaitCnt = new int();

		private void trackTimeMeas1_ValueChanged(object sender, EventArgs e)
		{				
			try
			{
				if (IsHold) { ReDrawWave(); }

				UpdateTimeMeas();
			}
			catch (Exception ex)
			{
				UserMessageBox.CommonCatchErrorMessage(ex);
			}
		}

		private void trackTimeMeas2_ValueChanged(object sender, EventArgs e)
		{				
			try
			{
				if (IsHold) { ReDrawWave(); }

				UpdateTimeMeas();

			}
			catch (Exception ex)
			{
				UserMessageBox.CommonCatchErrorMessage(ex);
			}
		}

		private void UpdateTimeMeas()
		{
			int val = new int();
			int mod = new int();
			int div = new int();

			val = (int)(X_Div * TRACK_SCALE);
			
			mod = trackTimeMeas1.Value % val;
			div = trackTimeMeas1.Value / val;

			if (mod != 0)
			{
				trackTimeMeas1.Value = val * div;
			}

			mod = trackTimeMeas2.Value % val;
			div = trackTimeMeas2.Value / val;

			if (mod != 0)
			{
				trackTimeMeas2.Value = val * div;
			}
		}

		private void TimeMeasDraw(Graphics g)
		{
			if (!Properties.Settings.Default.WAVE_TimeMeasView) { return; }

			if (DisableTimeMeasDraw) { return; }

			float offset = WaveStartOffset;

			float x1 = (float)trackTimeMeas1.Value / TRACK_SCALE;
			float x2 = (float)trackTimeMeas2.Value / TRACK_SCALE;

			float m1 = x1 % X_Div;
			float m2 = x2 % X_Div;

			x1 = x1 - m1;
			x2 = x2 - m2;

			if (m1 > (X_Div / 2.0F))
			{
				x1 += X_Div;
			}

			if (m2 > (X_Div / 2.0F))
			{
				x2 += X_Div;
			}

			float g1 = x1 + offset;
			float g2 = x2 + offset;

			if (g1 > offset)
			{
				g.DrawLine(MeasPen, g1, 0, g1, picWave.Height - WAVE_HOLD_OFFSET2);		//20170810 update (picWave.Height) -> (picWave.Height - WAVE_HOLD_OFFSET2)
			}

			if (g2 > offset)
			{
				g.DrawLine(MeasPen, g2, 0, g2, picWave.Height - WAVE_HOLD_OFFSET2);		//20170810 update (picWave.Height) -> (picWave.Height - WAVE_HOLD_OFFSET2)
			}

			Point p = lblTimeMeas2.Location;

			if (g1 > g2)
			{
				p.X = (int)(g1 + 5.0F);
				p.Y = 13;
				lblTimeMeas2.Location = p;
			}
			else
			{
				p.X = (int)(g2 + 5.0F);
				p.Y = 13;
				lblTimeMeas2.Location = p;
			}

			int lbl_t1 = (int)(g1 / X_Div + 0.5F);
			int lbl_t2 = (int)(g2 / X_Div + 0.5F);

			lblTimeMeas2.Text = "T1-T2 " + Convert.ToString((lbl_t2 - lbl_t1) * LogWork.LogPeriod) + "msec";
		}

		private void trackTimeMeas_MouseDown(object sender, MouseEventArgs e)
		{
			IsMeas = true;
		}

		private void trackTimeMeas_MouseUp(object sender, MouseEventArgs e)
		{
			System.Windows.Forms.TrackBar tmp_track = (System.Windows.Forms.TrackBar)sender;

			IsMeas = false;
		}

		private void btnMeas_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;

			int val = (int)(X_Div * TRACK_SCALE);

			if (val <= 1) { val = 1; }

			int k = GetTrackScale(X_Div);

			if (btn.Tag.ToString() == "Meas")
			{
				MeasMoveOn((Button)sender, val);
			}
			else if (btn.Tag.ToString() == "Fast")
			{
				MeasMoveOn((Button)sender, val * k);
			}
		}

		private void btnMeas_MouseDown(object sender, MouseEventArgs e)
		{
			btnMeasOn = (Button)sender;
			MeasWaitCnt = 0;
			TimerMeas.Enabled = true;
			IsMeas = true;
		}

		private void btnMeas_MouseUp(object sender, MouseEventArgs e)
		{
			btnMeasOn.BackColor = Color.Transparent;
			TimerMeas.Enabled = false;
			IsMeas = false;
		}

		private void MeasMoveOn(Button btn, int val)
		{
			TrackBar track = new TrackBar();
			bool zoom = new bool();

			if (btn.Name == "btnGoMeas1" || btn.Name == "btnGoFast1")
			{
				track = trackTimeMeas1;
				zoom = true;
			}

			if (btn.Name == "btnBackMeas1" || btn.Name == "btnBackFast1")
			{
				track = trackTimeMeas1;
				zoom = false;
			}

			if (btn.Name == "btnGoMeas2" || btn.Name == "btnGoFast2")
			{
				track = trackTimeMeas2;
				zoom = true;
			}

			if (btn.Name == "btnBackMeas2" || btn.Name == "btnBackFast2")
			{
				track = trackTimeMeas2;
				zoom = false;
			}

			int max = track.Maximum / val * val;

			if (zoom)
			{
				if (track.Value + val <= max)
				{
					track.Value += val;
				}
				else
				{
					track.Value = max;
				}
			}
			else
			{
				if (track.Value - val >= 0)
				{
					track.Value -= val;
				}
				else
				{
					track.Value = 0;
				}
			}
		}

		#endregion

		#region Toolbar Event

		private void btnTabGroup_Click(object sender, EventArgs e)
		{
			//TabGroupEvent(this, IsTabbedMdiGroup);
		}

		private string FileOpenInitialDirectory = string.Empty;
		private string FileSaveInitialDirectory = string.Empty;
		private string ImageSaveInitialDirectory = string.Empty;

		private void tbtnOpen_Click(object sender, EventArgs e)
		{
			try
			{
                OpenFileDialog.Title = UserText.DigitalOsilloLogOpenTitle;

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
		
                //フォルダ指定ダイアログを設定する
				if (ret == DialogResult.OK)
				{
					FileOpenInitialDirectory = System.IO.Path.GetDirectoryName(OpenFileDialog.FileName);

					DisableDraw = true;

					this.Cursor = Cursors.WaitCursor;

					//トリガ停止	20170825 add
					if (tbtnTrigger.BackColor == Color.Gold)
					{
						tbtnTrigger.PerformClick();
					}
			
					//オシロ停止
					if (tbtnHold.BackColor == SystemColors.Control)
					{
						tbtnHold.PerformClick();
					}

					System.IO.StreamReader file = new System.IO.StreamReader(OpenFileDialog.FileName);

					int len;
					string   buf, ver_s;
					string[] buf2;
			
					file.ReadLine();								//保存時間を空読み

					ver_s = file.ReadLine().Trim('\n');				//バージョン情報を読み込み

					//buf = file.ReadLine().Trim('\n');				//ログスピードを取得
					//buf = buf.Replace("[LogSpeed]", "");
					//buf = buf.Replace("msec", "");
					//spd = Convert.ToInt32(buf);

					buf = file.ReadLine().Trim('\n');						//ログデータ長さを取得

					//20170825 add
					len = Convert.ToInt32(buf.Substring(buf.IndexOf("]") + 1));

					if (len != LogWork.LogLength)
					{
						LogTimeValueChanged(len);

						UpdateHoldView(false);
					}
					//20170825 add end

					while (buf != "[LogData]")
					{
						buf = file.ReadLine().Trim('\n');
					}

					buf = file.ReadLine().Trim('\n');						//ラベル情報を空読み
					buf = buf.Trim();

					buf2 = buf.Split('\t');

					if (buf2.Length != LogWork.MonNum) { throw new ArithmeticException(); }

					int[] idx = new int[LogWork.MonNum];
					int s1, s2;

					for (int i = 0; i < LogWork.MonNum; i++)
					{
						s1 = buf2[i].IndexOf("(");
						s2 = buf2[i].IndexOf(")");

						idx[i] = Convert.ToInt32(buf2[i].Substring(s1 + 1, s2 - s1 - 1));
					}

					cmbLogPos.SelectedIndex = idx[0];
					cmbLogVel.SelectedIndex = idx[1];
					cmbLogCur.SelectedIndex = idx[2];
					//idx[3]=Status
					numLogPrm1.Value = idx[4];
					numLogPrm2.Value = idx[5];
					numLogPrm3.Value = idx[6];

                    //Ver1.01 Update
					//InitProgressBar(UserText.DigitalOsilloLogConvert, LogWork.LogLength - 1);
                    InitProgressBar(UserText.DigitalOsilloLogConvert, 1);

					//画面再描画
					this.Refresh();

					for (int i = 0; i < LogWork.LogLength; i++)
					{
						//Ver 1.01 Delete
                        //DataMsg.PerformStep();

						buf = file.ReadLine();
						buf2 = buf.Split('\t');

						for (int j = 0; j < LogWork.MonNum; j++)
						{
							LogData[j, i] = Convert.ToInt32(buf2[j]);
						}
					}

                    //Ver 1.01 Add
                    DataMsg.PerformStep();

					Thread.Sleep(MsgWait);
					
					DataMsg.Close();

					file.Close();

					this.Cursor = Cursors.Default;

					hSclWave.Value = 0;

					LogPtr = 0;

					//画面再描画
					ReDrawWave();
				}
			}
			catch
			{
				DataMsg.Close();

				this.Cursor = Cursors.Default;

				UserMessageBox.CommonFileFormatError();			

			}
		}

		private void tbtnSave_Click(object sender, EventArgs e)
		{
			try
			{
				string time = System.DateTime.Now.ToString();
				string tm = time;

				tm = tm.Replace(":", "_");
				tm = tm.Replace("/", "_");
			
				SaveFileDialog.DefaultExt = "log";
				SaveFileDialog.Filter = "Wave Log data|*.log";
				SaveFileDialog.FileName = "LogData " + tm;

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

                SaveFileDialog.Title = UserText.DigitalOsilloLogeSaveTitle;

				ChildFormControl.SetOpacity(0.0);

				DialogResult ret = SaveFileDialog.ShowDialog();

				ChildFormControl.SetOpacity(1.0);

				if (ret == DialogResult.OK)
				{
					FileSaveInitialDirectory = System.IO.Path.GetDirectoryName(SaveFileDialog.FileName);

					//オシロ停止
					if (tbtnHold.BackColor == SystemColors.Control)
					{
						tbtnHold.PerformClick();
					}

					this.Cursor = Cursors.WaitCursor;

					System.IO.StreamWriter file = new System.IO.StreamWriter(SaveFileDialog.FileName, false, System.Text.Encoding.Unicode);

					string major = Assembly.GetExecutingAssembly().GetName().Version.Major.ToString();
					string minor = Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString("D2");

					file.WriteLine("[Date]" + time);								//SAVE時間を保存;
					file.WriteLine("[Version]" + major + "." + minor);				//バージョン情報保存
					//file.WriteLine("[LogSpeed]" + ucmbVelUnit.Text.Trim());		//ログ周期情報保存
					file.WriteLine("[LogWork.LogLengthgth]" + LogWork.LogLength.ToString());				//ログデータ数を保存
					file.WriteLine("[LogData]");

                    // Ver 1.33 Update
					//InitProgressBar(UserText.DigitalOsilloLogSave, LogWork.LogLength);
                    InitProgressBar(UserText.DigitalOsilloLogSave, 1);
					
                    //画面再描画
					this.Refresh();

					//項目出力
					for (int i = 0; i < LogWork.MonNum; i++)
					{
						string item = string.Empty;
						string sel = string.Empty;
					
						switch (i)
						{
							case 0:

								item = cmbLogPos.Text;
								sel = "(" + cmbLogPos.SelectedIndex.ToString() + ")";
								file.Write(item + sel + "\t");
								break;

							case 1:

								item = cmbLogVel.Text;
								sel = "(" + cmbLogVel.SelectedIndex.ToString() + ")";
								file.Write(item + sel + "\t");
								break;

							case 2:

								item = cmbLogCur.Text;
								sel = "(" + cmbLogCur.SelectedIndex.ToString() + ")";
								file.Write(item + sel + "\t");
								break;

							case 3:

                                switch (Culture.Name)
                                {
                                    default:
                                    case Culture.JP:
                                        item = "ステータス";
                                        break;

                                    case Culture.US:
                                        item = "ステータス";
                                        break;

                                    case Culture.CN:
                                        item = "状态";
                                        break;
                                }

                                sel = "(-1)";
								file.Write(item + sel + "\t");
								break;

							case 4:

                                switch (Culture.Name)
                                {
                                    default:
                                    case Culture.JP:
                                        item = "パラメタ1";
                                        break;

                                    case Culture.US:
                                        item = "パラメタ1";
                                        break;

                                    case Culture.CN:
                                        item = "参数1";
                                        break;
                                }
								
								sel = "(" + numLogPrm1.Text + ")";
								file.Write(item + sel + "\t");
								break;

							case 5:

                                switch (Culture.Name)
                                {
                                    default:
                                    case Culture.JP:
                                        item = "パラメタ2";
                                        break;

                                    case Culture.US:
                                        item = "パラメタ2";
                                        break;

                                    case Culture.CN:
                                        item = "参数2";
                                        break;
                                }

								item = "パラメタ2";
								sel = "(" + numLogPrm2.Text + ")";
								file.Write(item + sel + "\t");
								break;

							case 6:

                                switch (Culture.Name)
                                {
                                    default:
                                    case Culture.JP:
                                        item = "パラメタ3";
                                        break;

                                    case Culture.US:
                                        item = "パラメタ3";
                                        break;

                                    case Culture.CN:
                                        item = "参数3";
                                        break;
                                }

								sel = "(" + numLogPrm3.Text + ")";
								file.Write(item + sel + "\t");
								break;

							default:
								break;
						}		
					}

					file.Write("\r" + "\n");

					for (int i = 0; i < LogWork.LogLength; i++)
					{
						if (i >= LogWork.LogLength) { i = 0; }

						// Ver1.33 Delete
                        //DataMsg.PerformStep();

						for (int j = 0; j < LogWork.MonNum; j++)
						{
							file.Write(LogData[j, i].ToString() + "\t");
						}

						file.Write("\r" + "\n");
					}

                    // Ver1.33 Add
                    DataMsg.PerformStep();

					file.Close();

					Thread.Sleep(MsgWait);
					
					DataMsg.Close();

					this.Cursor = Cursors.Default;
				}

			}
			catch
			{
				DataMsg.Close();

				this.Cursor = Cursors.Default;

				UserMessageBox.CommonFileFormatError();
			}
		}

		private SaveProgressDialog SaveMsg = new SaveProgressDialog();

		private void tbtnImageSave_Click(object sender, EventArgs e)
		{
		
			try
			{
				//オシロ停止
				//tbtnHold.BackColor = SystemColors.Control;
				//tbtnHold.PerformClick();
				
				SaveFileDialog.DefaultExt = "png";
				SaveFileDialog.Filter = "Png|*.png|Jpeg|*.jpg|Bitmap|*.bmp";
				SaveFileDialog.FileName = "ImageData";
				SaveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

				if (ImageSaveInitialDirectory == "")
				{
					SaveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
				}
				else
				{
					try
					{
						SaveFileDialog.InitialDirectory = ImageSaveInitialDirectory;
					}
					catch
					{
						SaveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
					}
				}

                SaveFileDialog.Title = UserText.DigitalOsilloPicSaveTitle;

				ChildFormControl.SetOpacity(0.0);

				DialogResult ret = SaveFileDialog.ShowDialog();

				ChildFormControl.SetOpacity(1.0);

				if (ret == DialogResult.OK)
				{
					ImageSaveInitialDirectory = System.IO.Path.GetDirectoryName(SaveFileDialog.FileName);

					this.Cursor = Cursors.WaitCursor;

					//コントロールの外観を描画するBitmapの作成
					Bitmap bmp = new Bitmap(this.Width, this.Height);
					//キャプチャする
					this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));

					SaveMsg = new SaveProgressDialog();

					SaveMsg.StartImageSave(ThisParentForm.Location, ThisParentForm.Size, 1);

					SaveMsg.Close();

					switch (SaveFileDialog.FilterIndex)
					{
						default:
						case 1:
							bmp.Save(SaveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
							break;

						case 2:
							bmp.Save(SaveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
							break;

						case 3:
							bmp.Save(SaveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
							break;
					}

					bmp.Dispose();

					this.Cursor = Cursors.Default;
				}

			}
			catch
			{
				UserMessageBox.CommonFileFormatError();
				this.Cursor = Cursors.Default;
			
			}
		}

		private void tbtnTrigger_Click(object sender, EventArgs e)
		{
			///20170825 update
			if (BackupLogLength != LogWork.LogLength) { LogTimeValueChanged(BackupLogLength); }

			DisableDraw = true;

			//整定時間クリア
			PosSettingTime = 0;

			if (tbtnTrigger.BackColor == SystemColors.Control )
			{
				tbtnTrigger.BackColor = Color.Gold;
			
				chkTrg.Checked = true;

				if (IsHold) { tbtnHold.PerformClick(); }

				Properties.Settings.Default.WAVE_TrgEnable = true;

				IsTrg = true;

				ReDrawWave();
			}
			else
			{
				tbtnTrigger.BackColor = SystemColors.Control;
				
				chkTrg.Checked = false;

				Properties.Settings.Default.WAVE_TrgEnable = false;

				IsTrg = false;
			}

			for (int i = 0; i < LogWork.KindNum; i++)
			{
				for (int j = 0; j < LogWork.LogLength; j++)
				{
					TrgData[i, j] = 0;
				}
			}

			TrgPtr1 = -1;
			TrgPtr2 = 0;

			DisableDraw = false;
		}

		private void tbtnHold_Click(object sender, EventArgs e)
		{
			if (!HoldEnabled) { return; }

			HoldEvent();
		}

		private void HoldEvent()
		{
			///20170825 update
			if (BackupLogLength != LogWork.LogLength) { LogTimeValueChanged(BackupLogLength); }

			if (tbtnHold.BackColor == SystemColors.Control)
			{
				//オシロ停止
				tbtnHold.BackColor = Color.Gold;
				tbtnHold.Image = Properties.Resources.PlayHS;

				tbtnSplitLogSave.Enabled = false; // Ver1.35 add

				IsHold = true;

				int[,] buf = new int[LogWork.KindNum, LogWork.LogLength];

				if (IsTrg)			//20170927 update
				{
					int w = (int)((picWave.Width - WaveStartOffset - WaveEndOffset) / X_Div);
					int e = w - GetTrgOffset(w);
					int s = TrgPtr2 + e + 1;

					if (s >= LogWork.LogLength) { s = s - LogWork.LogLength; }

					int l = LogPtr;
					if (l < s) { l = l + LogWork.LogLength; }
					l = l - s;

					TrgPtr3 = LogWork.LogLength - e - 1;

					for (int i = 0; i < LogWork.KindNum; i++)
					{
						for (int j = 0, p = s; j < LogWork.LogLength; j++, p++)
						{
							if (p >= LogWork.LogLength) { p = 0; }

							buf[i, j] = LogData[i, p];

							if (j <= l) { buf[i, j] = 0; }
						}
					}

					for (int i = 0; i < LogWork.KindNum; i++)
					{
						for (int j = 0; j < LogWork.LogLength; j++)
						{
							LogData[i, j] = buf[i, j];
						}
					}
				}
				else
				{
					for (int i = 0; i < LogWork.KindNum; i++)
					{
						for (int j = 0, p = LogPtr; j < LogWork.LogLength; j++, p++)
						{
							if (p >= LogWork.LogLength) { p = 0; }

							buf[i, j] = LogData[i, p];
						}
					}

					for (int i = 0; i < LogWork.KindNum; i++)
					{
						for (int j = 0; j < LogWork.LogLength; j++)
						{
							LogData[i, j] = buf[i, j];
						}
					}
				}

				UpdateHoldView(false);
		
				ReDrawWave();
			}
			else
			{
				//オシロ再開

                // Ver1.32 add↓↓↓
                if ((CMonitor.GetParameter(CParamID.ServoStatus) & ALM_BIT) == ALM_BIT)
                {
                    if (chkAlarmAutoStop.Checked)
                    {
                        UserMessageBox.WaveAlarmAutoStop();
                        return;
                    }
                }
                // Ver1.32 add ↑↑↑

				DisableDraw = true;
                bAutoStop = false;

				LogPtr = 0;		//20170802 update

				tbtnHold.BackColor = SystemColors.Control;
				tbtnHold.Image = Properties.Resources.PauseHS;
				tbtnHold.BackColor = SystemColors.Control;

				tbtnSplitLogSave.Enabled = true; // Ver1.35 add

				TrgPtrClear();

				TrgBufClear();

				DisableDraw = false;

				IsHold = false;

				//20170809 update 連続描画・描画停止最適化
				//hSclWave.Visible = false;
				hSclWave.Enabled = false;

				ReDrawWave();
			}
		}

		private void UpdateHoldView(bool scl_lock)
		{
			//描画データが波形描画パネルより大きいか？
			float off = new int();

			//if (Properties.Settings.Default.WAVE_ItemY_L_View) { off += WaveStartOffset; }		//20170927 del
			//if (Properties.Settings.Default.WAVE_ItemY_R_View) { off += WaveEndOffset; }			//20170927 del

			off += WaveStartOffset;																	//20170927 add
			off += WaveEndOffset;																	//20170927 add

			if ((LogWork.LogLength * X_Div + off) > pnlWave.Width)
			{
				float old_max = hSclWave.Maximum;
				float old_val = hSclWave.Value;
		
				hSclWave.Visible = true;
				hSclWave.Maximum = (int)(LogWork.LogLength * X_Div - (picWave.Width - off));

				hSclWave.LargeChange = (int)(X_Div * LogWork.LogLength / 100.0F);
				hSclWave.SmallChange = (int)(X_Div * LogWork.LogLength / 10.0F);

				if (IsTrg)
				{
					if (IsHold)			//20170927 update
					{
						hSclWave.Enabled = true;
					}
					else
					{
						hSclWave.Enabled = false;
					}
				}
				else
				{
					hSclWave.Enabled = true;
				}

				if (scl_lock)
				{
					float new_max = hSclWave.Maximum;

					int new_val = (int)(old_val * new_max / old_max);

					if (new_val <= 0) { new_val = 0; }
					if (new_val >= hSclWave.Maximum) { new_val = hSclWave.Maximum; }

					hSclWave.Value = new_val;
				}
				else
				{
					hSclWave.Value = hSclWave.Maximum; 
				}
			}
			else
			{
				//20170809 update 連続描画・描画停止最適化
				//hSclWave.Visible = false;
			}
		}

		private void tbtnItemY_L_Click(object sender, EventArgs e)
		{
			//Y軸項目（左側）
			if (tbtnItemY_L.BackColor == SystemColors.Control)
			{
				WaveStartOffset = WAVE_START_OFFSET;

				lblT1.Visible = true;
				lblT2.Visible = true;

				btnGoFast1.Visible = true;
				btnGoFast2.Visible = true;
				btnGoMeas1.Visible = true;
				btnGoMeas2.Visible = true;
				btnBackFast1.Visible = true;
				btnBackFast2.Visible = true;
				btnBackMeas1.Visible = true;
				btnBackMeas2.Visible = true;

				Properties.Settings.Default.WAVE_ItemY_L_View = true;

				tbtnItemY_L.BackColor = Color.Gold;
			}
			else
			{
				WaveStartOffset = WAVE_OFFSET_MIN;

				lblT1.Visible = false;
				lblT2.Visible = false;

				btnGoFast1.Visible = false;
				btnGoFast2.Visible = false;
				btnGoMeas1.Visible = false;
				btnGoMeas2.Visible = false;
				btnBackFast1.Visible = false;
				btnBackFast2.Visible = false;
				btnBackMeas1.Visible = false;
				btnBackMeas2.Visible = false;

				Properties.Settings.Default.WAVE_ItemY_L_View = false;

				tbtnItemY_L.BackColor = SystemColors.Control;
			}

			if (Properties.Settings.Default.WAVE_TimeMeasView)
			{
				lblTimeMeas2.Visible = true;
			}
			else
			{
				lblTimeMeas2.Visible = false;
			}

			pnlWave_Resize(null, null);
			
			ReDrawWave();

		}

		private void tbtnItemY_R_Click(object sender, EventArgs e)
		{
			//Y軸項目（右側）
			if (tbtnItemY_R.BackColor == SystemColors.Control)
			{
				WaveEndOffset = WAVE_END_OFFSET;

				pnlTrackLeft1.Visible = true;
				pnlTrackLeft2.Visible = true;

				Properties.Settings.Default.WAVE_ItemY_R_View = true;

				tbtnItemY_R.BackColor = Color.Gold;
			}
			else
			{
				WaveEndOffset = WAVE_OFFSET_MIN;

				pnlTrackLeft1.Visible = false;
				pnlTrackLeft2.Visible = false;

				Properties.Settings.Default.WAVE_ItemY_R_View = false;

				tbtnItemY_R.BackColor = SystemColors.Control;
			}

			pnlWave_Resize(null, null);
		
			ReDrawWave();
		}

		private void tbtnViewSetting_Click(object sender, EventArgs e)
		{
			if (tbtnViewSetting.BackColor == SystemColors.Control)
			{
				pnlColorSettingBase.Visible = true;
				splColorSetting.Visible = true;

				tbtnViewSetting.BackColor = Color.Gold;

				Properties.Settings.Default.WAVE_ViewSetting_View = true;
			}
			else
			{
				pnlColorSettingBase.Visible = false;
				splColorSetting.Visible = false;

				tbtnViewSetting.BackColor = SystemColors.Control;

				Properties.Settings.Default.WAVE_ViewSetting_View = false;
			}

			pnlWave_Resize(null, null);

			ReDrawWave();
		}

		private void ubtnZoom_Click(object sender, EventArgs e)
		{
			ToolStripButton ubtn = (ToolStripButton)sender;
			ZoomWaitCnt = 0;

			switch (ubtn.Name)
			{
				case "ubtnHZoomP":

					HorizontalZoom(true);
					break;

				case "ubtnHZoomM":

					HorizontalZoom(false);
					break;

				case "ubtnVZoomP":

					VerticalZoom(true);
					break;

				case "ubtnVZoomM":

					VerticalZoom(false);
					break;

				default:
					break;
			}

		}

		private void ubtnZoom_MouseUp(object sender, MouseEventArgs e)
		{
			ZoomWaitCnt = 0;
			btnZoomOn.BackColor = SystemColors.Control;
			TimerWave.Enabled = false;
			TimerWave.Interval = 100;

			DisableTimeMeasDraw = false;
		}

		private void ubtnZoom_MouseDown(object sender, MouseEventArgs e)
		{
			btnZoomOn = (ToolStripButton)sender;
			btnZoomOn.BackColor = Color.Gold;
			TimerWave.Enabled = true;
			TimerWave.Interval = 100;

			DisableTimeMeasDraw = true;
		}

		private void tbtnViewReset_Click(object sender, EventArgs e)
		{
			I_Pos = 0.0F;
			P_Pos = 0.0F;
			V_Pos = 0.0F;
			Prm1_Pos = 0.0F;
			Prm2_Pos = 0.0F;
			Prm3_Pos = 0.0F;

			I_Mul = 1.0F;
			P_Mul = 1.0F;
			V_Mul = 1.0F;
			Prm1_Mul = 1.0F;
			Prm2_Mul = 1.0F;
			Prm3_Mul = 1.0F;

			Properties.Settings.Default.WAVE_I_Pos = I_Pos;
			Properties.Settings.Default.WAVE_P_Pos = P_Pos;
			Properties.Settings.Default.WAVE_V_Pos = V_Pos;
			Properties.Settings.Default.WAVE_Prm1_Pos = Prm1_Pos;
			Properties.Settings.Default.WAVE_Prm2_Pos = Prm2_Pos;
			Properties.Settings.Default.WAVE_Prm3_Pos = Prm3_Pos;

			Properties.Settings.Default.WAVE_I_Mul = I_Mul;
			Properties.Settings.Default.WAVE_P_Mul = P_Mul;
			Properties.Settings.Default.WAVE_V_Mul = V_Mul;
			Properties.Settings.Default.WAVE_Prm1_Mul = Prm1_Mul;
			Properties.Settings.Default.WAVE_Prm2_Mul = Prm2_Mul;
			Properties.Settings.Default.WAVE_Prm3_Mul = Prm3_Mul;
		}

		#endregion

		#region View Setting

		private void LineView_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox chk = (CheckBox)sender;

			switch (chk.Tag.ToString())
			{
				case "PERR":

					Properties.Settings.Default.WAVE_PosView = chk.Checked;
					break;

				case "VEL":

					Properties.Settings.Default.WAVE_VelView = chk.Checked;
					break;

				case "CUR":

					Properties.Settings.Default.WAVE_CurView = chk.Checked;
					break;

				case "PRM1":

					Properties.Settings.Default.WAVE_Prm1View = chk.Checked;
					break;

				case "PRM2":

					Properties.Settings.Default.WAVE_Prm2View = chk.Checked;
					break;

				case "PRM3":

					Properties.Settings.Default.WAVE_Prm3View = chk.Checked;
					break;

				case "CMDPOS":

					Properties.Settings.Default.WAVE_CmdposView = chk.Checked;
					break;

				case "INPOS":

					Properties.Settings.Default.WAVE_InposView = chk.Checked;
					break;

				case "SCALE":

					Properties.Settings.Default.WAVE_TimeScaleView = chk.Checked;
					break;

				case "MEAS":

					Properties.Settings.Default.WAVE_TimeMeasView = chk.Checked;

					if (chk.Checked)
					{
						pnlTimeMeas1.Visible = true;
						pnlTimeMeas2.Visible = true;
						lblTimeMeas2.Visible = true;
					}
					else
					{
						pnlTimeMeas1.Visible = false;
						pnlTimeMeas2.Visible = false;
						lblTimeMeas2.Visible = false;
					}

					break;

				case "TRG":

					break;
			}

			ReDrawWave();
		}

		private void LineType_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			string item = btn.Tag.ToString();

			DialogResult ret;

			switch (item)
			{
				case "PERR":

					LineDlg.Title = UserText.DigitalOsilloLineDialogTitlePerr;
					LineDlg.LineSize = Properties.Settings.Default.WAVE_PosLineSize;
					LineDlg.LineType = Properties.Settings.Default.WAVE_PosLineType;

					ret = LineDlg.ShowDialog();

					if (ret == DialogResult.OK)
					{
						Properties.Settings.Default.WAVE_PosLineSize = LineDlg.LineSize;
						Properties.Settings.Default.WAVE_PosLineType = LineDlg.LineType;
					}
					break;

				case "VEL":

					LineDlg.Title = UserText.DigitalOsilloLineDialogTitleVel;
					LineDlg.LineSize = Properties.Settings.Default.WAVE_VelLineSize;
					LineDlg.LineType = Properties.Settings.Default.WAVE_VelLineType;

					ret = LineDlg.ShowDialog();

					if (ret == DialogResult.OK)
					{
						Properties.Settings.Default.WAVE_VelLineSize = LineDlg.LineSize;
						Properties.Settings.Default.WAVE_VelLineType = LineDlg.LineType;
					}
					break;


				case "CUR":

					LineDlg.Title = UserText.DigitalOsilloLineDialogTitleCur;
					LineDlg.LineSize = Properties.Settings.Default.WAVE_CurLineSize;
					LineDlg.LineType = Properties.Settings.Default.WAVE_CurLineType;

					ret = LineDlg.ShowDialog();

					if (ret == DialogResult.OK)
					{
						Properties.Settings.Default.WAVE_CurLineSize = LineDlg.LineSize;
						Properties.Settings.Default.WAVE_CurLineType = LineDlg.LineType;
					}
					break;

				case "PRM1":

					LineDlg.Title = UserText.DigitalOsilloLineDialogTitlePrm1;
					LineDlg.LineSize = Properties.Settings.Default.WAVE_Prm1LineSize;
					LineDlg.LineType = Properties.Settings.Default.WAVE_Prm1LineType;

					ret = LineDlg.ShowDialog();

					if (ret == DialogResult.OK)
					{
						Properties.Settings.Default.WAVE_Prm1LineSize = LineDlg.LineSize;
						Properties.Settings.Default.WAVE_Prm1LineType = LineDlg.LineType;
					}
					break;

				case "PRM2":

					LineDlg.Title = UserText.DigitalOsilloLineDialogTitlePrm2;
					LineDlg.LineSize = Properties.Settings.Default.WAVE_Prm2LineSize;
					LineDlg.LineType = Properties.Settings.Default.WAVE_Prm2LineType;

					ret = LineDlg.ShowDialog();

					if (ret == DialogResult.OK)
					{
						Properties.Settings.Default.WAVE_Prm2LineSize = LineDlg.LineSize;
						Properties.Settings.Default.WAVE_Prm2LineType = LineDlg.LineType;
					}
					break;

				case "PRM3":

					LineDlg.Title = UserText.DigitalOsilloLineDialogTitlePrm3;
					LineDlg.LineSize = Properties.Settings.Default.WAVE_Prm3LineSize;
					LineDlg.LineType = Properties.Settings.Default.WAVE_Prm3LineType;

					ret = LineDlg.ShowDialog();

					if (ret == DialogResult.OK)
					{
						Properties.Settings.Default.WAVE_Prm3LineSize = LineDlg.LineSize;
						Properties.Settings.Default.WAVE_Prm3LineType = LineDlg.LineType;
					}
					break;


				case "CMDPOS":

					LineDlg.Title = UserText.DigitalOsilloLineDialogTitleCmdPos;
					LineDlg.LineSize = Properties.Settings.Default.WAVE_CmdposLineSize;
					LineDlg.LineType = Properties.Settings.Default.WAVE_CmdposLineType;

					ret = LineDlg.ShowDialog();

					if (ret == DialogResult.OK)
					{
						Properties.Settings.Default.WAVE_CmdposLineSize = LineDlg.LineSize;
						Properties.Settings.Default.WAVE_CmdposLineType = LineDlg.LineType;
					}
					break;

				case "INPOS":

					LineDlg.Title = UserText.DigitalOsilloLineDialogTitleInPos;
					LineDlg.LineSize = Properties.Settings.Default.WAVE_InposLineSize;
					LineDlg.LineType = Properties.Settings.Default.WAVE_InposLineType;

					ret = LineDlg.ShowDialog();

					if (ret == DialogResult.OK)
					{
						Properties.Settings.Default.WAVE_InposLineSize = LineDlg.LineSize;
						Properties.Settings.Default.WAVE_InposLineType = LineDlg.LineType;
					}
					break;

				case "SCALE":

					LineDlg.Title = UserText.DigitalOsilloLineDialogTitleScale;
					LineDlg.LineSize = Properties.Settings.Default.WAVE_TimeScaleLineSize;
					LineDlg.LineType = Properties.Settings.Default.WAVE_TimeScaleLineType;

					ret = LineDlg.ShowDialog();

					if (ret == DialogResult.OK)
					{
						Properties.Settings.Default.WAVE_TimeScaleLineSize = LineDlg.LineSize;
						Properties.Settings.Default.WAVE_TimeScaleLineType = LineDlg.LineType;
					}
					break;

				case "MEAS":

					LineDlg.Title = UserText.DigitalOsilloLineDialogTitleMeas;
					LineDlg.LineSize = Properties.Settings.Default.WAVE_TimeMeasLineSize;
					LineDlg.LineType = Properties.Settings.Default.WAVE_TimeMeasLineType;

					ret = LineDlg.ShowDialog();

					if (ret == DialogResult.OK)
					{
						Properties.Settings.Default.WAVE_TimeMeasLineSize = LineDlg.LineSize;
						Properties.Settings.Default.WAVE_TimeMeasLineType = LineDlg.LineType;
					}
					break;

				case "TRG":

					LineDlg.Title = UserText.DigitalOsilloLineDialogTitleTrg;
					LineDlg.LineSize = Properties.Settings.Default.WAVE_TrgLineSize;
					LineDlg.LineType = Properties.Settings.Default.WAVE_TrgLineType;

					ret = LineDlg.ShowDialog();

					if (ret == DialogResult.OK)
					{
						Properties.Settings.Default.WAVE_TrgLineSize = LineDlg.LineSize;
						Properties.Settings.Default.WAVE_TrgLineType = LineDlg.LineType;
					}
					break;

			}

			InitPen();
			ReDrawWave();
		}

		private void LineColor_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;

			ChildFormControl.SetOpacity(0.0);
		
			DialogResult ret = ColorDialogWave.ShowDialog();

			ChildFormControl.SetOpacity(1.0);
		
			if (ret == DialogResult.OK)
			{
				string item = btn.Tag.ToString();

				switch (item)
				{
					case "PERR":

						Properties.Settings.Default.WAVE_PosColor = ColorDialogWave.Color;
						break;

					case "VEL":

						Properties.Settings.Default.WAVE_VelColor = ColorDialogWave.Color;
						break;

					case "CUR":

						Properties.Settings.Default.WAVE_CurColor = ColorDialogWave.Color;
						break;

					case "PRM1":

						Properties.Settings.Default.WAVE_Prm1Color = ColorDialogWave.Color;
						break;

					case "PRM2":

						Properties.Settings.Default.WAVE_Prm2Color = ColorDialogWave.Color;
						break;

					case "PRM3":

						Properties.Settings.Default.WAVE_Prm3Color = ColorDialogWave.Color;
						break;

					case "CMDPOS":

						Properties.Settings.Default.WAVE_CmdposColor = ColorDialogWave.Color;
						break;

					case "INPOS":

						Properties.Settings.Default.WAVE_InposColor = ColorDialogWave.Color;
						break;

					case "MEAS":

						Properties.Settings.Default.WAVE_TimeMeasColor = ColorDialogWave.Color;

						break;

					case "SCALE":

						Properties.Settings.Default.WAVE_TimeScaleColor = ColorDialogWave.Color;
						break;

					case "TRG":

						Properties.Settings.Default.WAVE_TrgColor = ColorDialogWave.Color;
						break;
				}

			}

			InitPen();
			ReDrawWave();
		}

		private void LineBack_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			ComboBox cmb = new ComboBox();

			string item = btn.Tag.ToString();

			switch (item)
			{
				case "PERR":

					cmb = cmbPerr;
					break;

				case "VEL":

					cmb = cmbVel;
					break;

				case "CUR":

					cmb = cmbCur;
					break;

				case "PRM1":

					cmb = cmbPrm1;
					break;

				case "PRM2":

					cmb = cmbPrm2;
					break;

				case "PRM3":

					cmb = cmbPrm3;
					break;

				case "CMDPOS":

					cmb = cmbCmdpos;
					break;

				case "INPOS":

					cmb = cmbInpos;
					break;

				case "SCALE":

					cmb = cmbScale;
					break;

				case "MEAS":

					break;

				case "TRG":

					cmb = cmbTrg;
					break;

				case "COND":

					cmb = cmbTrgCond;
					break;
			}

			if (cmb.SelectedIndex > 0)
			{
				cmb.SelectedIndex--;
			}
			else
			{
				cmb.SelectedIndex = cmb.Items.Count - 1;
			}
		}

		private void LineNext_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			ComboBox cmb = new ComboBox();

			string item = btn.Tag.ToString();

			switch (item)
			{
				case "PERR":

					cmb = cmbPerr;
					break;

				case "VEL":

					cmb = cmbVel;
					break;

				case "CUR":

					cmb = cmbCur;
					break;

				case "PRM1":

					cmb = cmbPrm1;
					break;

				case "PRM2":

					cmb = cmbPrm2;
					break;

				case "PRM3":

					cmb = cmbPrm3;
					break;

				case "CMDPOS":

					cmb = cmbCmdpos;
					break;

				case "INPOS":

					cmb = cmbInpos;
					break;

				case "SCALE":

					cmb = cmbScale;
					break;

				case "MEAS":

					break;

				case "TRG":

					cmb = cmbTrg;
					break;

				case "COND":

					cmb = cmbTrgCond;
					break;
			}

			if (cmb.SelectedIndex < cmb.Items.Count - 1)
			{
				cmb.SelectedIndex++;
			}
			else
			{
				cmb.SelectedIndex = 0;
			}
		}

		private string ComboScaleBackupText = "1";							//20170928 add

		private void ComboScale_Enter(object sender, EventArgs e)			//20170928 add
		{
			ComboBox cmb = (ComboBox)sender;

			ComboScaleBackupText = cmb.Text;
		}

		private void ComboScale_Leave(object sender, EventArgs e)			//20170928 add
		{
			ComboBox cmb = (ComboBox)sender;

			try
			{
				string item = cmb.Tag.ToString();

				int v = new int();
				float d = new float();

				if (item == "CUR")
				{
					if (cmb.Text == ""   ) { cmb.Text = "0.1"; return; }
					if (cmb.Text == "0"  ) { cmb.Text = "0.1"; return; }
					if (cmb.Text == "0." ) { cmb.Text = "0.1"; return; }
					if (cmb.Text == "-"  ) { cmb.Text = "0.1"; return; }
					if (cmb.Text == "-0" ) { cmb.Text = "0.1"; return; }
					if (cmb.Text == "-0.") { cmb.Text = "0.1"; return; }

					d = Convert.ToSingle(cmb.Text);

					if (d >= 0.0 && d <  0.1) { cmb.Text =  "0.1"; }
					if (d <= 0.0 && d > -0.1) { cmb.Text = "-0.1"; }
				}
				else
				{
					if (cmb.Text == ""  ) { cmb.Text = "1"; return; }
					if (cmb.Text == "0" ) { cmb.Text = "1"; return; }
					if (cmb.Text == "-" ) { cmb.Text = "-1"; return; }
					if (cmb.Text == "-0") { cmb.Text = "-1"; return; }
				
					v = Convert.ToInt32(cmb.Text);

					if (v == 0) { cmb.Text = "1"; }
				}
			}
			catch
			{
				cmb.Text = ComboScaleBackupText;
			}
		}
	
		private void ComboScale_TextChanged(object sender, EventArgs e)		//20170928 add
		{
			ComboBox cmb = (ComboBox)sender;

			try
			{
				string item = cmb.Tag.ToString();

				int v = new int();
				float d = new float();

				if (item == "CUR")
				{
					if (cmb.Text == ""   ) { return; }
					if (cmb.Text == "0"  ) { return; }
					if (cmb.Text == "0." ) { return; }
					if (cmb.Text == "-"  ) { return; }
					if (cmb.Text == "-0" ) { return; }
					if (cmb.Text == "-0.") { return; }
 
					d = Convert.ToSingle(cmb.Text);
				}
				else
				{
					if (cmb.Text == "" ) { return; }
					if (cmb.Text == "0") { return; }
					if (cmb.Text == "-") { return; }
				
					v = Convert.ToInt32(cmb.Text);
				}

				switch (item)
				{
					case "PERR":

						Properties.Settings.Default.WAVE_P_Div = v;
						P_Div = v;
						break;

					case "VEL":

						Properties.Settings.Default.WAVE_V_Div = v;
						V_Div = v;
						break;

					case "CUR":

						Properties.Settings.Default.WAVE_I_Div = (int)(d * 100);
						I_Div = (int)(d * 100);
						I_Scale = d;
						break;

					case "PRM1":

						Properties.Settings.Default.WAVE_Prm1_Div = v;
						Prm1_Div = v;
						break;

					case "PRM2":

						Properties.Settings.Default.WAVE_Prm2_Div = v;
						Prm2_Div = v;
						break;

					case "PRM3":

						Properties.Settings.Default.WAVE_Prm3_Div = v;
						Prm3_Div = v;
						break;
				}

				ComboScaleBackupText = cmb.Text;

				ReDrawWave();
			}
			catch
			{
				cmb.Text = ComboScaleBackupText;
				cmb.Select(0, ComboScaleBackupText.Length);
				cmb.Focus();
			}
		}

		private void ComboScale_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox cmb = (ComboBox)sender;

			string item = cmb.Tag.ToString();

			int v = new int();
			float d = new float();

			if (item == "CUR")
			{
				d = Convert.ToSingle(cmb.Text);
			}
			else
			{
				v = Convert.ToInt32(cmb.Text);
			}
	
			switch (item)
			{
				case "PERR":

					Properties.Settings.Default.WAVE_P_Div = v;
					P_Div = v;
					break;

				case "VEL":

					Properties.Settings.Default.WAVE_V_Div = v;
					V_Div = v;
					break;

				case "CUR":

					Properties.Settings.Default.WAVE_I_Div = (int)(d * 100);
					I_Div = (int)(d * 100);
					I_Scale = d;
					break;

				case "PRM1":

					Properties.Settings.Default.WAVE_Prm1_Div = v;
					Prm1_Div = v;
					break;

				case "PRM2":

					Properties.Settings.Default.WAVE_Prm2_Div = v;
					Prm2_Div = v;
					break;

				case "PRM3":

					Properties.Settings.Default.WAVE_Prm3_Div = v;
					Prm3_Div = v;
					break;

				case "CMDPOS":

					Properties.Settings.Default.WAVE_CmdposOffset = v;
					CmdposOff = -v;
					break;

				case "INPOS":

					Properties.Settings.Default.WAVE_InposOffset = v;
					InposOff = -v;
					break;

				case "SCALE":

					Properties.Settings.Default.WAVE_T_DIV = v;
					T_Div = v;
					break;

				case "TRG":

					Properties.Settings.Default.WAVE_TrgPosition = v;
					break;
			}

			ReDrawWave();
			pnlBase.Focus();
		}

		private void ComboScale_KeyDown(object sender, KeyEventArgs e)
		{
			//TABキー,↑、↓以外は受け付けない
			if (e.KeyCode != Keys.Tab && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down)
			{
				e.Handled = true;   //イベント終了
			}
		}

		private void ComboScale_KeyPress(object sender, KeyPressEventArgs e)
		{
			//コンボボックス内に不正文字を入力させない
			e.Handled = true;   //イベント終了
		}

		private void ComboScale_DropDownClosed(object sender, EventArgs e)
		{
			pnlBase.Focus();
		}

		private void cmbTrgCond_SelectedIndexChanged(object sender, EventArgs e)
		{
			string item = cmbTrgCond.Text;

			switch (item)
			{
				case "指令有り":
                case "有指令":
				case "Cmd":
			
					TrgItem = TrgItemEnum.TRG_CMD;

					numTrgCond.Enabled = false;
                    
					rdoCondUp.Text = "↑";
					rdoCondDown.Text = "↓";
					break;

				case "インポジ":
                case "定位":
				case "In-Pos":
			
					TrgItem = TrgItemEnum.TRG_INPOS;

					numTrgCond.Enabled = false;

					rdoCondUp.Text = "↑";
					rdoCondDown.Text = "↓";
					break;


				case "電流":
                case "电流":
				case "Current":
			
					TrgItem = TrgItemEnum.TRG_CUR;

					numTrgCond.Increment = (decimal)0.5;
					numTrgCond.DecimalPlaces = 2;
					numTrgCond.Enabled = true;

					rdoCondUp.Text = UserText.DigitalOsilloGe;
					rdoCondDown.Text = UserText.DigitalOsilloLe;
					break;

				case "偏差":
				case "Error":

					TrgItem = TrgItemEnum.TRG_ERR;

					numTrgCond.DecimalPlaces = 0;
					numTrgCond.Enabled = true;
                    
					rdoCondUp.Text = UserText.DigitalOsilloGe;
					rdoCondDown.Text = UserText.DigitalOsilloLe;
					break;

				case "速度":
				case "Speed":

					TrgItem = TrgItemEnum.TRG_VEL;

					numTrgCond.Increment = 100;
					numTrgCond.DecimalPlaces = 0;
					numTrgCond.Enabled = true;

                    rdoCondUp.Text = UserText.DigitalOsilloGe;
					rdoCondDown.Text = UserText.DigitalOsilloLe;
					break;
			}

			TrgIsGE = false;

			if (rdoCondUp.Checked) { TrgIsGE = true; }

			numTrgCond.Value = (decimal)BackupTrgValue[(int)TrgItem];

			ReDrawWave();
			pnlBase.Focus();

		}

		private void numTrgCond_ValueChanged(object sender, EventArgs e)
		{
			BackupTrgValue[(int)TrgItem] = (double)numTrgCond.Value;

			if (TrgItem == TrgItemEnum.TRG_CUR)
			{
				TrgValue = (int)(BackupTrgValue[(int)TrgItem] * 100.0);
			}
			else
			{
				TrgValue = (int)BackupTrgValue[(int)TrgItem];
			}
		}

		private void rdoCondUp_CheckedChanged(object sender, EventArgs e)
		{
			TrgIsGE = rdoCondUp.Checked;
		}

		private void btnNextLogKind_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			ComboBox cmb = new ComboBox();

			string item = btn.Tag.ToString();

			switch (item)
			{
				case "POS":

					cmb = cmbLogPos;
					break;

				case "VEL":

					cmb = cmbLogVel;
					break;

				case "CUR":

					cmb = cmbLogCur;
					break;

				case "FFT":

					cmb = cmbLogFFT;
					break;

			}

			if (cmb.SelectedIndex < cmb.Items.Count - 1)
			{
				cmb.SelectedIndex++;
			}
			else
			{
				cmb.SelectedIndex = 0;
			}

		}

		private void btnBackLogKind_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			ComboBox cmb = new ComboBox();

			string item = btn.Tag.ToString();

			switch (item)
			{
				case "POS":

					cmb = cmbLogPos;
					break;

				case "VEL":

					cmb = cmbLogVel;
					break;

				case "CUR":

					cmb = cmbLogCur;
					break;

				case "FFT":

					cmb = cmbLogFFT;
					break;

			}

			if (cmb.SelectedIndex > 0)
			{
				cmb.SelectedIndex--;
			}
			else
			{
				cmb.SelectedIndex = cmb.Items.Count - 1;
			}
		}

		private void ComboLogKind_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!MainForm.IsUsbConnectBlink) { return; }

			if (InitializingLogKind) { return; }		//20170928 add

			DisableLogKindChange = true;

			ComboBox cmb = (ComboBox)sender;

			string item = cmb.Tag.ToString();

			int id = new int();
			int idx = new int();

			switch (item)
			{
				case "POS":

					id = CParamID.LogKind1;
					idx = cmb.SelectedIndex;
					Properties.Settings.Default.WAVE_Pos_Idx = idx;		//20170928 add
					break;

				case "VEL":

					id = CParamID.LogKind2;
					idx = cmb.SelectedIndex;
					Properties.Settings.Default.WAVE_Vel_Idx = idx;		//20170928 add
					break;

				case "CUR":

					id = CParamID.LogKind3;
					idx = cmb.SelectedIndex;
					Properties.Settings.Default.WAVE_Cur_Idx = idx;		//20170928 add
					break;

				case "FFT":

					id = CParamID.LogFFT_Kind;
					idx = cmb.SelectedIndex;
					break;

			}

			if (!CCommandTx.WriteSvNet(id, idx)) { return; }

			ReDrawWave();
			pnlBase.Focus();

			DisableLogKindChange = false;

		}

		private void numLogPrm_ValueChanged(object sender, EventArgs e)
		{
			if (!MainForm.IsUsbConnectBlink) { return; }

			if (InitializingLogKind) { return; }		//20170928 add

			DisableLogKindChange = true;

			NumericUpDown num = (NumericUpDown)sender;

			int id = new int();
			int data = new int();

			switch (num.Tag.ToString())
			{
				case "PRM1":

					id = CParamID.LogKind5;
					data = (int)num.Value;
					Properties.Settings.Default.WAVE_Prm1_Idx = data;		//20170928 add
					break;

				case "PRM2":

					id = CParamID.LogKind6;
					data = (int)num.Value;
					Properties.Settings.Default.WAVE_Prm2_Idx = data;		//20170928 add
					break;

				case "PRM3":

					id = CParamID.LogKind7;
					data = (int)num.Value;
					Properties.Settings.Default.WAVE_Prm3_Idx = data;		//20170928 add
					break;
			}

			if (!CCommandTx.WriteSvNet(id, data)) { return; }

			ReDrawWave();

			pnlBase.Focus();

			DisableLogKindChange = false;

		}

		private void numLogTime_ValueChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.LogTime = (int)numLogTime.Value;

			int len = (int)numLogTime.Value * 1000;				//sec * 1000

			LogTimeValueChanged(len);

			BackupLogLength = LogWork.LogLength;				//20170825 add

			pnlBase.Focus();
		}

		private void LogTimeValueChanged(int len)				//20170825 add
		{
			LogWork.LogLength = len;

			LogData = new int[LogWork.KindNum, LogWork.LogLength];
			TrgData = new int[LogWork.KindNum, LogWork.LogLength];

			ExportLogData = new int[LogWork.KindNum, LogWork.LogLength];

			LogPtr = 0;
		}

		private void ComboLogKind_DropDown(object sender, EventArgs e)
		{
			DisableLogKindChange = true;
		}

		private void ComboLogKind_DropDownClosed(object sender, EventArgs e)
		{
			DisableLogKindChange = false;
			pnlBase.Focus();
		}

		#endregion

		#region Timer Event

		private void TimerMeas_Tick(object sender, EventArgs e)
		{
			MeasWaitCnt++;

			if (MeasWaitCnt >= 10)
			{
				btnMeasOn.BackColor = Color.Gold;

				btnMeas_Click(btnMeasOn, null);
			}
		}

		private void TimerResize_Tick(object sender, EventArgs e)
		{
			int w = ThisMdiClient.ClientRectangle.Width;
			int h = ThisMdiClient.ClientRectangle.Height;

			if (ResizeWidth != w || ResizeHeight != h)
			{
				InitFormLayout();
			}

			TimerResize.Enabled = false;
		}

		#endregion

		private void hSclWave_Scroll(object sender, ScrollEventArgs e)
		{
			ReDrawWave();
		}

		private void InitProgressBar(string msg, int max)
		{
			DataMsg = new DataProgressDialog();
			DataMsg.Maximum = max;
			DataMsg.Start(msg, ThisParentForm.Location, ThisParentForm.ClientSize, false);
		}

		private void Control_MouseHover(object sender, EventArgs e)
		{
			this.Select();
		}

		private void Control_MouseEnter(object sender, EventArgs e)
		{
			this.Select();
		}

        #region カルチャリソース切り替え

        public void ViewCultureResouceChanged()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DigitalOsilloForm));

            cmbTrgCond.Items.Clear();
            cmbTrgCond.Items.AddRange(new object[] {
            resources.GetString("cmbTrgCond.Items"),
            resources.GetString("cmbTrgCond.Items1"),
            resources.GetString("cmbTrgCond.Items2"),
            resources.GetString("cmbTrgCond.Items3"),
            resources.GetString("cmbTrgCond.Items4")});

            cmbLogPos.Items.Clear();
            cmbLogPos.Items.AddRange(new object[] {
            resources.GetString("cmbLogPos.Items"),
            resources.GetString("cmbLogPos.Items1"),
            resources.GetString("cmbLogPos.Items2")});

            cmbLogVel.Items.Clear();
            cmbLogVel.Items.AddRange(new object[] {
            resources.GetString("cmbLogVel.Items"),
            resources.GetString("cmbLogVel.Items1"),
            resources.GetString("cmbLogVel.Items2"),
            resources.GetString("cmbLogVel.Items3"),
            resources.GetString("cmbLogVel.Items4"),
            resources.GetString("cmbLogVel.Items5"),
            resources.GetString("cmbLogVel.Items6")});

            cmbLogCur.Items.Clear();
            cmbLogCur.Items.AddRange(new object[] {
            resources.GetString("cmbLogCur.Items"),
            resources.GetString("cmbLogCur.Items1"),
            resources.GetString("cmbLogCur.Items2"),
            resources.GetString("cmbLogCur.Items3")});

            cmbLogFFT.Items.Clear();
            cmbLogFFT.Items.AddRange(new object[] {
            resources.GetString("cmbLogFFT.Items"),
            resources.GetString("cmbLogFFT.Items1"),
            resources.GetString("cmbLogFFT.Items2"),
            resources.GetString("cmbLogFFT.Items3"),
            resources.GetString("cmbLogFFT.Items4"),
            resources.GetString("cmbLogFFT.Items5"),
            resources.GetString("cmbLogFFT.Items6"),
            resources.GetString("cmbLogFFT.Items7")});

            this.Font = (Font)resources.GetObject("$this.Font");
            chkCmdpos.Font = (Font)resources.GetObject("chkCmdpos.Font");
            chkCur.Font = (Font)resources.GetObject("chkCur.Font");
            chkInpos.Font = (Font)resources.GetObject("chkInpos.Font");
            chkMeas.Font = (Font)resources.GetObject("chkMeas.Font");
            chkPerr.Font = (Font)resources.GetObject("chkPerr.Font");
            chkPrm1.Font = (Font)resources.GetObject("chkPrm1.Font");
            chkPrm2.Font = (Font)resources.GetObject(" chkPrm2.Font");
            chkPrm3.Font = (Font)resources.GetObject("chkPrm3.Font");
            chkScale.Font = (Font)resources.GetObject(" chkScale.Font");
            chkTrg.Font = (Font)resources.GetObject(" chkTrg.Font");
			chkVel.Font = (Font)resources.GetObject("chkVel.Font");
			chkTrg.Font = (Font)resources.GetObject("chkTrg.Font");
          
			cmbCmdpos.Font = (Font)resources.GetObject("cmbCmdpos.Font");
            cmbCur.Font = (Font)resources.GetObject("cmbCur.Font");
            cmbInpos.Font = (Font)resources.GetObject("cmbInpos.Font");
            cmbLogCur.Font = (Font)resources.GetObject("cmbLogCur.Font");
            cmbLogFFT.Font = (Font)resources.GetObject("cmbLogFFT.Font");
            cmbLogPos.Font = (Font)resources.GetObject("cmbLogPos.Font");
            cmbLogVel.Font = (Font)resources.GetObject("cmbLogVel.Font");
            cmbPerr.Font = (Font)resources.GetObject("cmbPerr.Font");
            cmbPrm1.Font = (Font)resources.GetObject("cmbPrm1.Font");
            cmbPrm2.Font = (Font)resources.GetObject("cmbPrm2.Font");
            cmbPrm3.Font = (Font)resources.GetObject("cmbPrm3.Font");
            cmbScale.Font = (Font)resources.GetObject("cmbScale.Font");
            cmbTrg.Font = (Font)resources.GetObject("cmbTrg.Font");
            cmbTrgCond.Font = (Font)resources.GetObject("cmbTrgCond.Font");
            cmbVel.Font = (Font)resources.GetObject("cmbVel.Font");
            grpCmdpos.Font = (Font)resources.GetObject("grpCmdpos.Font");
            grpCur.Font = (Font)resources.GetObject("grpCur.Font");
            grpInpos.Font = (Font)resources.GetObject("grpInpos.Font");
            grpLogCur.Font = (Font)resources.GetObject("grpLogCur.Font");
			grpLogKindFFT.Font = (Font)resources.GetObject("grpLogKindFFT.Font");
			grpLogPos.Font = (Font)resources.GetObject("grpLogPos.Font");
            grpLogPrm1.Font = (Font)resources.GetObject("grpLogPrm1.Font");
            grpLogPrm2.Font = (Font)resources.GetObject("grpLogPrm2.Font");
            grpLogPrm3.Font = (Font)resources.GetObject("grpLogPrm3.Font");
			grpLogTime.Font = (Font)resources.GetObject("grpLogTime.Font");
			grpLogVel.Font = (Font)resources.GetObject("grpLogVel.Font");
            grpMeas.Font = (Font)resources.GetObject("grpMeas.Font");
            grpPerr.Font = (Font)resources.GetObject("grpPerr.Font");
            grpPrm1.Font = (Font)resources.GetObject("grpPrm1.Font");
            grpPrm2.Font = (Font)resources.GetObject("grpPrm2.Font");
            grpPrm3.Font = (Font)resources.GetObject("grpPrm3.Font");
            grpScale.Font = (Font)resources.GetObject("grpScale.Font");
            grpTrg.Font = (Font)resources.GetObject("grpTrg.Font");
            grpTrgCond.Font = (Font)resources.GetObject("grpTrgCond.Font");
            grpVel.Font = (Font)resources.GetObject("grpVel.Font");
            lblLogPrm1.Font = (Font)resources.GetObject("lblLogPrm1.Font");
            lblLogPrm2.Font = (Font)resources.GetObject("lblLogPrm2.Font");
			lblLogPrm3.Font = (Font)resources.GetObject("lblLogPrm3.Font");
			lblLogTime.Font = (Font)resources.GetObject("lblLogTime.Font");
			lblPositionTime.Font = (Font)resources.GetObject("lblPositionTime.Font");
            lblQuickView.Font = (Font)resources.GetObject("lblQuickView.Font");
            lblT1.Font = (Font)resources.GetObject("lblT1.Font");
            lblT2.Font = (Font)resources.GetObject("lblT2.Font");
            lblTimeMeas2.Font = (Font)resources.GetObject("lblTimeMeas2.Font");
            rdoCondDown.Font = (Font)resources.GetObject("rdoCondDown.Font");
            rdoCondUp.Font = (Font)resources.GetObject("rdoCondUp.Font");
            tabPageLogKind.Font = (Font)resources.GetObject("tabPageLogKind.Font");
            tabPageSetting.Font = (Font)resources.GetObject("tabPageSetting.Font");
            tabPageTrigger.Font = (Font)resources.GetObject("tabPageTrigger.Font");
            tbtnHold.Font = (Font)resources.GetObject("tbtnHold.Font");
            tbtnImageSave.Font = (Font)resources.GetObject("tbtnImageSave.Font");
            tbtnItemY_L.Font = (Font)resources.GetObject("tbtnItemY_L.Font");
            tbtnItemY_R.Font = (Font)resources.GetObject("tbtnItemY_R.Font");
            tbtnOpen.Font = (Font)resources.GetObject("tbtnOpen.Font");
            tbtnSave.Font = (Font)resources.GetObject("tbtnSave.Font");
            tbtnTrigger.Font = (Font)resources.GetObject("tbtnTrigger.Font");
            tbtnViewSetting.Font = (Font)resources.GetObject("tbtnViewSetting.Font");
            ubtnHZoomM.Font = (Font)resources.GetObject("ubtnHZoomM.Font");
            ubtnHZoomP.Font = (Font)resources.GetObject("ubtnHZoomP.Font");
            ubtnVZoomM.Font = (Font)resources.GetObject("ubtnVZoomM.Font");
            ubtnVZoomP.Font = (Font)resources.GetObject("ubtnVZoomP.Font");
            tabGraphSetting.Font = (Font)resources.GetObject("tabGraphSetting.Font");

            tabGraphSetting.Size = (Size)resources.GetObject("tabGraphSetting.Size");

            this.Text = resources.GetString("$this.Text");
            chkCmdpos.Text = resources.GetString("chkCmdpos.Text");
            chkCur.Text = resources.GetString("chkCur.Text");
            chkInpos.Text = resources.GetString("chkInpos.Text");
            chkMeas.Text = resources.GetString("chkMeas.Text");
            chkPerr.Text = resources.GetString("chkPerr.Text");
            chkPrm1.Text = resources.GetString("chkPrm1.Text");
            chkPrm2.Text = resources.GetString(" chkPrm2.Text");
            chkPrm3.Text = resources.GetString("chkPrm3.Text");
            chkScale.Text= resources.GetString(" chkScale.Text");
            chkTrg.Text= resources.GetString(" chkTrg.Text");
			chkVel.Text = resources.GetString("chkVel.Text");
			chkTrg.Text = resources.GetString("chkTrg.Text");
            
            cmbCmdpos.Text = resources.GetString("cmbCmdpos.Text");
            cmbCur.Text = resources.GetString("cmbCur.Text");
            cmbInpos.Text = resources.GetString("cmbInpos.Text");
            cmbLogCur.Text = resources.GetString("cmbLogCur.Text");
            cmbLogFFT.Text = resources.GetString("cmbLogFFT.Text");
            cmbLogPos.Text = resources.GetString("cmbLogPos.Text");
            cmbLogVel.Text = resources.GetString("cmbLogVel.Text");
            cmbPerr.Text = resources.GetString("cmbPerr.Text");
            cmbPrm1.Text = resources.GetString("cmbPrm1.Text");
            cmbPrm2.Text = resources.GetString("cmbPrm2.Text");
            cmbPrm3.Text = resources.GetString("cmbPrm3.Text");
            cmbScale.Text = resources.GetString("cmbScale.Text");
            cmbTrg.Text = resources.GetString("cmbTrg.Text");
            cmbTrgCond.Text = resources.GetString("cmbTrgCond.Text");
            cmbVel.Text = resources.GetString("cmbVel.Text");
           
            grpCmdpos.Text = resources.GetString("grpCmdpos.Text");
            grpCur.Text = resources.GetString("grpCur.Text");
            grpInpos.Text = resources.GetString("grpInpos.Text");
            grpLogCur.Text= resources.GetString("grpLogCur.Text");
            grpLogKindFFT.Text = resources.GetString("grpLogKindFFT.Text");
            grpLogPos.Text= resources.GetString("grpLogPos.Text");
            grpLogPrm1.Text = resources.GetString("grpLogPrm1.Text");
            grpLogPrm2.Text = resources.GetString("grpLogPrm2.Text");
			grpLogPrm3.Text = resources.GetString("grpLogPrm3.Text");
			grpLogTime.Text = resources.GetString("grpLogTime.Text");
			grpLogVel.Text = resources.GetString("grpLogVel.Text");
            grpMeas.Text = resources.GetString("grpMeas.Text");
            grpPerr.Text = resources.GetString("grpPerr.Text");
            grpPrm1.Text = resources.GetString("grpPrm1.Text");
            grpPrm2.Text = resources.GetString("grpPrm2.Text");
            grpPrm3.Text = resources.GetString("grpPrm3.Text");
            grpScale.Text = resources.GetString("grpScale.Text");
            grpTrg.Text = resources.GetString("grpTrg.Text");
            grpTrgCond.Text = resources.GetString("grpTrgCond.Text");
            grpVel.Text = resources.GetString("grpVel.Text");
            lblLogPrm1.Text = resources.GetString("lblLogPrm1.Text");
            lblLogPrm2.Text = resources.GetString("lblLogPrm2.Text");
			lblLogPrm3.Text = resources.GetString("lblLogPrm3.Text");
			lblLogTime.Text = resources.GetString("lblLogTime.Text");
			lblPositionTime.Text = resources.GetString("lblPositionTime.Text");
            lblQuickView.Text = resources.GetString("lblQuickView.Text");
            lblT1.Text = resources.GetString("lblT1.Text");
            lblT2.Text = resources.GetString("lblT2.Text");
            lblTimeMeas2.Text = resources.GetString("lblTimeMeas2.Text");
            rdoCondDown.Text = resources.GetString("rdoCondDown.Text");
            rdoCondUp.Text = resources.GetString("rdoCondUp.Text");
            tabPageLogKind.Text = resources.GetString("tabPageLogKind.Text");
            tabPageSetting.Text = resources.GetString("tabPageSetting.Text");
            tabPageTrigger.Text = resources.GetString("tabPageTrigger.Text");
            tbtnHold.Text = resources.GetString("tbtnHold.Text");
            tbtnHold.ToolTipText = resources.GetString("tbtnHold.ToolTipText");
            tbtnImageSave.Text = resources.GetString("tbtnImageSave.Text");
            tbtnImageSave.ToolTipText = resources.GetString("tbtnImageSave.ToolTipText");
            tbtnItemY_L.Text = resources.GetString("tbtnItemY_L.Text");
            tbtnItemY_L.ToolTipText = resources.GetString("tbtnItemY_L.ToolTipText");
            tbtnItemY_R.Text = resources.GetString("tbtnItemY_R.Text");
            tbtnItemY_R.ToolTipText = resources.GetString("tbtnItemY_R.ToolTipText");
            tbtnOpen.Text = resources.GetString("tbtnOpen.Text");
            tbtnOpen.ToolTipText = resources.GetString("tbtnOpen.ToolTipText");
            tbtnSave.Text = resources.GetString("tbtnSave.Text");
            tbtnSave.ToolTipText = resources.GetString("tbtnSave.ToolTipText");
            tbtnTrigger.Text = resources.GetString("tbtnTrigger.Text");
            tbtnTrigger.ToolTipText = resources.GetString("tbtnTrigger.ToolTipText");
            tbtnViewSetting.Text = resources.GetString("tbtnViewSetting.Text");
            tbtnViewSetting.ToolTipText = resources.GetString("tbtnViewSetting.ToolTipText");
            ubtnHZoomM.Text = resources.GetString("ubtnHZoomM.Text");
            ubtnHZoomM.ToolTipText = resources.GetString("ubtnHZoomM.ToolTipText");
            ubtnHZoomP.Text = resources.GetString("ubtnHZoomP.Text");
            ubtnHZoomP.ToolTipText = resources.GetString("ubtnHZoomP.ToolTipText");
            ubtnVZoomM.Text = resources.GetString("ubtnVZoomM.Text");
            ubtnVZoomM.ToolTipText = resources.GetString("ubtnVZoomM.ToolTipText");
            ubtnVZoomP.Text = resources.GetString("ubtnVZoomP.Text");
            ubtnVZoomP.ToolTipText = resources.GetString("ubtnVZoomP.ToolTipText");

            //言語リソースを切替えるとコンボボックスが選択状態になるのでここで強制解除
            cmbPerr.SelectionLength = 0;
            cmbVel.SelectionLength = 0;
            cmbCur.SelectionLength = 0;
            cmbPrm1.SelectionLength = 0;
            cmbPrm2.SelectionLength = 0;
            cmbPrm3.SelectionLength = 0;
            cmbCmdpos.SelectionLength = 0;
            cmbInpos.SelectionLength = 0;
            cmbScale.SelectionLength = 0;

        }

        #endregion

        #region タブオーナードロー

        /// <summary>
        /// グラフ設定タブタブオーナードローイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabGraphSetting_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tab = (TabControl)sender;
            string txt = tab.TabPages[e.Index].Text;

            Font font;

            LinearGradientBrush gb = new LinearGradientBrush(e.Bounds,
                                                             Color.Cyan,
                                                             Color.DodgerBlue,
                                                             LinearGradientMode.Vertical);

            //タブのテキストと背景を描画するためのブラシを決定する           
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                //選択されているタブ
                font = new Font(e.Font.FontFamily, e.Font.Size, FontStyle.Bold);
                e.Graphics.FillRectangle(gb, e.Bounds);
            }
            else
            {
                //選択されていないタブ
                font = new Font(e.Font.FontFamily, e.Font.Size, FontStyle.Regular);
                e.Graphics.FillRectangle(Brushes.WhiteSmoke, e.Bounds);
            }

            StringFormat sf = new StringFormat();

            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            e.Graphics.DrawString(txt, font, Brushes.Navy, e.Bounds, sf);

            gb.Dispose();
        }

		#endregion

		#region ログファイル分割保存 Ver 1.43 add

		/// <summary>
		/// ログファイル分割出力開始／停止
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tbtnSplitLogSave_Click(object sender, EventArgs e)
        {
			if(tbtnSplitLogSave.BackColor == SystemColors.Control)
            {
				//ログ分割保存開始
				string time = DateTime.Now.ToString();
				string tm = time;

				tm = tm.Replace(":", "_");
				tm = tm.Replace("/", "_");

				SaveFileDialog.DefaultExt = "log";
				SaveFileDialog.Filter = "Wave Log data|*.log";
				SaveFileDialog.FileName = "LogData " + tm;

				if (LogFolder == string.Empty)
				{
					SaveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
				}
				else
				{
					try
					{
						SaveFileDialog.InitialDirectory = LogFolder;
					}
					catch
					{
						SaveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
					}
				}

				SaveFileDialog.Title = UserText.DigitalOsilloLogeSaveTitle;

				if (SaveFileDialog.ShowDialog() == DialogResult.OK)
				{
					LogFolder = Path.GetDirectoryName(SaveFileDialog.FileName);

					string fileName = Path.ChangeExtension(SaveFileDialog.FileName, null);
					string ext = Path.GetExtension(SaveFileDialog.FileName);

					LogFile = fileName + "_No0000" + ext;

					if (bkFileList != null)
					{
						if (bkFileList.Length != Properties.Settings.Default.NumberFiles)
						{
							bkFileList = null;
							bkFileList = new string[Properties.Settings.Default.NumberFiles];
						}
					}
					else
					{
						bkFileList = new string[Properties.Settings.Default.NumberFiles];
					}

					fileno = 0;

					IsSplitLogSave = true;
					IsOver = false;

					if (!CheckCreateLogFile()) return;

					tbtnSplitLogSave.BackColor = Color.Gold;
					numNumberFiles.Enabled = false;

					//先頭にファイル名を保存
					bkFileList[fileno] = LogFile;
				}
			}
			else
            {
				//ログ分割保存停止
				tbtnSplitLogSave.BackColor = SystemColors.Control;
				numNumberFiles.Enabled = true;
				IsSplitLogSave = false;
			}
		}

		/// <summary>
		/// ログファイル生成チェック
		/// </summary>
		/// <returns></returns>
		private bool CheckCreateLogFile()
		{
			try
			{
				//フォルダが存在するか？
				if (!Directory.Exists(LogFolder))
				{
					if (LogFolder.Length == 0)
					{
						//マイドキュメント
						LogFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
					}

					//フォルダ生成
					Directory.CreateDirectory(LogFolder);
				}

				return true;
			}
			catch
            {
				return false;
            }
		}

		/// <summary>
		/// ログファイル書込み
		/// </summary>
		/// <param name="nodeidx"></param>
		/// <param name="fileno"></param>
		/// <returns></returns>
		private bool SplitOutputLogDataFile()
		{
			try
			{
				using (StreamWriter file = new StreamWriter(LogFile, false, Encoding.Unicode))
				{
					string major = Assembly.GetExecutingAssembly().GetName().Version.Major.ToString();
					string minor = Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString("D2");

					file.WriteLine("[Date]" + DateTime.Now.ToString());             //SAVE時間を保存;
					file.WriteLine("[Version]" + major + "." + minor);              //バージョン情報保存

					file.WriteLine("[LogWork.LogLengthgth]" + LogWork.LogLength.ToString());                //ログデータ数を保存
					file.WriteLine("[LogData]");

					//項目出力
					for (int i = 0; i < LogWork.MonNum; i++)
					{
						string item = string.Empty;
						string sel = string.Empty;

						switch (i)
						{
							case 0:

								item = cmbLogPos.Text;
								sel = "(" + cmbLogPos.SelectedIndex.ToString() + ")";
								file.Write(item + sel + "\t");
								break;

							case 1:

								item = cmbLogVel.Text;
								sel = "(" + cmbLogVel.SelectedIndex.ToString() + ")";
								file.Write(item + sel + "\t");
								break;

							case 2:

								item = cmbLogCur.Text;
								sel = "(" + cmbLogCur.SelectedIndex.ToString() + ")";
								file.Write(item + sel + "\t");
								break;

							case 3:

								switch (Culture.Name)
								{
									default:
									case Culture.JP:
										item = "ステータス";
										break;

									case Culture.US:
										item = "ステータス";
										break;

									case Culture.CN:
										item = "状态";
										break;
								}

								sel = "(-1)";
								file.Write(item + sel + "\t");
								break;

							case 4:

								switch (Culture.Name)
								{
									default:
									case Culture.JP:
										item = "パラメタ1";
										break;

									case Culture.US:
										item = "パラメタ1";
										break;

									case Culture.CN:
										item = "参数1";
										break;
								}

								sel = "(" + numLogPrm1.Text + ")";
								file.Write(item + sel + "\t");
								break;

							case 5:

								switch (Culture.Name)
								{
									default:
									case Culture.JP:
										item = "パラメタ2";
										break;

									case Culture.US:
										item = "パラメタ2";
										break;

									case Culture.CN:
										item = "参数2";
										break;
								}

								item = "パラメタ2";
								sel = "(" + numLogPrm2.Text + ")";
								file.Write(item + sel + "\t");
								break;

							case 6:

								switch (Culture.Name)
								{
									default:
									case Culture.JP:
										item = "パラメタ3";
										break;

									case Culture.US:
										item = "パラメタ3";
										break;

									case Culture.CN:
										item = "参数3";
										break;
								}

								sel = "(" + numLogPrm3.Text + ")";
								file.Write(item + sel + "\t");
								break;

							default:
								break;
						}
					}

					file.Write("\r" + "\n");

					for (int i = 0; i < LogWork.LogLength; i++)
					{
						if (i >= LogWork.LogLength) { i = 0; }

						for (int j = 0; j < LogWork.MonNum; j++)
						{
							file.Write(LogData[j, i].ToString() + "\t");
						}

						file.Write("\r" + "\n");
					}

					GetLogFileName();
				}

				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// ログファイル名取得
		/// </summary>
		private void GetLogFileName()
		{
			if (!IsOver)
			{
				if (fileno < Properties.Settings.Default.NumberFiles - 1)
				{
					string fileName = Path.ChangeExtension(LogFile, null);
					string ext = Path.GetExtension(LogFile);

					fileno++;

					LogFile = fileName.Substring(0, fileName.Length - 6) + "No" + fileno.ToString("0000") + ext;
					bkFileList[fileno] = LogFile;
				}
				else
				{
					fileno = 0;
					IsOver = true;

					LogFile = bkFileList[fileno];
				}
			}
			else
			{
				if (fileno < Properties.Settings.Default.NumberFiles - 1)
				{
					fileno++;
				}
				else
				{
					fileno = 0;
				}

				LogFile = bkFileList[fileno];
			}
		}

		private void ClearLogDataFile()
		{
			LogFile = bkFileList[fileno];

			if (File.Exists(LogFile))
            {
				using (var fileStream = new FileStream(LogFile, FileMode.Open))
				{
					//ファイルの内容をクリア
					fileStream.SetLength(0);
				}
			}
		}

		private void numNumberFiles_ValueChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.NumberFiles = (int)numNumberFiles.Value;
		}

		#endregion
	}
}