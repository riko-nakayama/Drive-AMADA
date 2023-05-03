using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Threading;

namespace Motion_Designer
{
    public partial class frmBasicProgramOperation2 : Form
    {
        #region 定数

        private const int MAX_STEP_COUNT = 128; //最大ステップ数 
        private const int MAX_UNDO_COUNT = 50;  // やり直し最大数

        //コマンド
        private const string CmdNOP = "NOP";
        private const string CmdMOVE_END = "MOVE_END";
        private const string CmdMOVE_ST = "MOVE_ST";
        private const string CmdMOVE_V = "MOVE_V";
        private const string CmdMOVE_C = "MOVE_C";
        private const string CmdJMP0 = "JMP0";
        private const string CmdJMP_IN = "JMP_IN";
        private const string CmdJMP_IN_OFF = "JMP_IN_OFF";
        private const string CmdJMP_TRQ = "JMP_TRQ";
        private const string CmdJMP_STS = "JMP_STS";
        private const string CmdWAIT0 = "WAIT0";
        private const string CmdPC_RESET = "PC_RESET";
        private const string CmdPC_RST_SP = "PC_RST_SP";
        private const string CmdOUT0 = "OUT0";
        private const string CmdSV_OFF = "SV_OFF";
        private const string CmdSV_ON = "SV_ON";
        private const string CmdHOME = "HOME";
        private const string CmdP_RESET = "P_RESET";
        private const string CmdAL_RESET = "AL_RESET";
        private const string CmdEND_P = "END_P";
        private const string CmdEND_V = "END_V";
        private const string CmdEND_C = "END_C";
        private const string CmdEND_OFF = "END_OFF";
        private const string CmdPARA_W = "PARA_W";

        private const string ProgramHeaderTitle = "Simplified Control Program File";
        private const string MiddleTitle = "//********** Object List & Mnemonic List **********//";

        #endregion

        #region プロパティ

        public bool IsCollapseLayout
        {
            set
            {
                _IsCollapseLayout = value;

                if (_IsCollapseLayout)
                {
                    //CollapseSimpleControl();
                }
                else
                {
                    //ExpandSimpleControl();
                }
            }

            get { return _IsCollapseLayout; }
        }

        public bool IsExist
        {
            set { _IsExist = value; }
            get { return _IsExist; }
        }

        #endregion

        #region 変数

        /// <summary>
        /// プログラムコード
        /// </summary>
        private class Basic_Program_Code
        {

            public Basic_Program_Code(Int32 _id177, Int32 _id178, Int32 _id179)
            {
                ID177_Data = _id177;
                ID178_Data = _id178;
                ID179_Data = _id179;
            }

            public Int32 ID177_Data;
            public Int32 ID178_Data;
            public Int32 ID179_Data;

        };

        //運転ボタン
        private string PROG_START = "";
        private string PROG_END = "";

        private bool IsCancel = false;      //処理停止
        private bool IsSelected = false;    //選択ＯＫ

        private int ActRowCnt = 0;          //現在のステップグリッド行数

        //プログラムグリッドリスト
        private object[] CommandList = new object[MAX_STEP_COUNT];
        private object[] CopyCommandList = null;

        //Undoリスト
        private bool IsEdit = true;
        private bool IsUndo = false;     //Undo操作なし

        private int BkUndoListCnt = 0;      //
        private int ActUndoPtr = 0;         //現在のUndoステップグリッド行数
        private object[] UndoCommandList = null;
        private List<object> UndoList = new List<object>(MAX_UNDO_COUNT);
        private List<int> CurrentStep = new List<int>(MAX_STEP_COUNT);

        //プログラムデータリスト
        private List<Basic_Program_Code> BasicProgramOp = new List<Basic_Program_Code>(MAX_STEP_COUNT);

        //プログレスダイアログボックス
        private DataProgressDialog pBarForm = new DataProgressDialog();

        private Int32 CurrentStepNo = 0;
        private Int32 PrevStepNo = -1;

        private bool IsSimplified = false;

        static private frmBasicProgramOperation2 _ThisForm;
        private bool _IsCollapseLayout = new bool();
        private bool _IsExist = new bool();
        private MdiClient ThisMdiClient;

		private ProfileMovementTableForm pmoveform;
        
        #endregion

        #region Win32 API

        // Win32 APIのインポート
        [DllImport("USER32.DLL")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, UInt32 bRevert);
        [DllImport("USER32.DLL")]
        private static extern UInt32 RemoveMenu(IntPtr hMenu, UInt32 nPosition, UInt32 wFlags);

        // ［閉じる］ボタンを無効化するための値
        private const UInt32 SC_CLOSE = 0x0000F060;
        private const UInt32 MF_BYCOMMAND = 0x00000000;

        const int WM_SYSCOMMAND = 0x0112;
        const int SC_MOVE = 0xF010;
        const int SC_SIZE = 0xF000;

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        extern static int SendMessageGetTextLength(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, int lParam);

        [DllImport("User32.dll")]
        public static extern bool SetCapture(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        #region リッチテキスト行間変更用API定義

        const int EM_SETPARAFORMAT = 0x0447;
        const uint PFM_LINESPACING = 0x00000100;

        [StructLayout(LayoutKind.Sequential)]
        public struct PARAFORMAT2
        {
            public uint cbSize;
            public uint dwMask;
            public short wNumbering;
            public short wReserved;
            public int dxStartIndent;
            public int dxRightIndent;
            public int dxOffset;
            public short wAlignment;
            public short cTabCount;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public int[] rgxTabs;
            public int dySpaceBefore;
            public int dySpaceAfter;
            public int dyLineSpacing;
            public short sStyle;
            public byte bLineSpacingRule;
            public byte bOutlineLevel;
            public short wShadingWeight;
            public short wShadingStyle;
            public short wNumberingStart;
            public short wNumberingStyle;
            public short wNumberingTab;
            public short wBorderSpace;
            public short wBorderWidth;
            public short wBorders;
        }

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        private extern static int SendMessage(IntPtr hwnd, int msg, IntPtr wparam, ref PARAFORMAT2 pf2);

        #endregion

        #endregion

        static public frmBasicProgramOperation2 ThisForm
        {
            get { return _ThisForm; }
        }

        public void InitFormLayout()
        {
            if (ThisForm == null) { return; }

            //MdiClientの取得
            MdiClient mc = MainForm.ThisForm.GetMdiClient();

            int w = mc.ClientRectangle.Width;
            int h = mc.ClientRectangle.Height;

            ThisForm.Location = new Point(0, 0);
            ThisForm.Size = new Size(w, h);

            ThisForm.WindowState = FormWindowState.Normal;
        }

        #region ロード／アンロード

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmBasicProgramOperation2()
        {
            InitializeComponent();

            _ThisForm = this;
            _IsExist = true;

            //MdiClientの取得
            ThisMdiClient = MainForm.ThisForm.GetMdiClient();

            SetMessageTagLocalize();

			//del 20160907 nakayama
            //このオプションを付けないとRichTextで設定されたフォントが反映されない
            //richHelpText.LanguageOption = RichTextBoxLanguageOptions.DualFont;

            //行間変更
            /*
            int size = Marshal.SizeOf(typeof(PARAFORMAT2));

            PARAFORMAT2 pf = new PARAFORMAT2();
            pf.cbSize = (uint)size;
            pf.dwMask = PFM_LINESPACING;
            pf.bLineSpacingRule = 4;
            pf.dyLineSpacing = 340; // 行間 ( twips )

            SendMessage(richHelpText.Handle, EM_SETPARAFORMAT, IntPtr.Zero, ref pf);
            */
        }

        /// <summary>
        /// 簡易プログラム２フォームロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmBasicProgramOperation2_Load(object sender, EventArgs e)
        {
            ViewCultureResouceChanged();

            int _step = 0;

            //プログラム動作グリッドデータ初期化
            for (int i = 0; i < MAX_STEP_COUNT; i++, _step++)
            {
                GridProgram.Rows.Add(1);
                GridProgram.Rows[i].Cells["Step"].Value = _step.ToString();
                GridProgram.Rows[i].Cells["Command"].Value = "NOP";

                ActRowCnt++;
            }
            
            //プログラムグリッドCellValueChangedイベント追加
            GridProgram.CellValueChanged += new DataGridViewCellEventHandler(GridProgram_CellValueChanged);

            GridProgram.MouseWheel += new MouseEventHandler(GridProgram_MouseWheel);

            //初期状態は全て"NOP"
            for (int i = 0; i < MAX_STEP_COUNT; i++)
            {
                CommandList[i] = new ctlCommandNOP();
            }
          
            ViewCommandHelp(0, "NOP");
            
            AddAUndoList();

			//20170215 add
			if (Properties.Settings.Default.PASSWORD_TRI)
			{
				btnProfileTableset.Visible = true;
			}
        }

        /// <summary>
        /// 簡易プログラム２フォームクロージングイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmBasicProgramOperation2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //簡易プログラム動作中？
            if (IsSimplified)
            {
				//add 20160907 nakayama
				ChildFormControl.SetOpacity(0.0);

                //現在、プログラムが動作中です。
                //プログラムを停止して、簡易コントロールを終了します。
                DialogResult dlgRsult = MessageBox.Show(UserText.ProgramRun_Now_M1 +
                                                        Environment.NewLine +
                                                        UserText.ProgramRun_Now_M2 +
                                                        Environment.NewLine +
                                                        UserText.Program_OK_M,
                                                        UserText.ProgramEND_H,
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question);

				//add 20160907 nakayama
				ChildFormControl.SetOpacity(1.0);

                if (dlgRsult == DialogResult.Yes)
                {
					//add 20161108
					bProgramStop();

					//del 20160908 nakayama
                    //chkPrgStartEnd.PerformClick();
                }
                else
                {
                    e.Cancel = true;    //クローズキャンセル
                    return;
                }
            }

            if (e.CloseReason != CloseReason.MdiFormClosing)
            {
                _IsExist = false;
            }
        }

        /// <summary>
        /// 簡易プログラム２フォームクローズイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmBasicProgramOperation2_FormClosed(object sender, FormClosedEventArgs e)
        {
            GridProgram.CellValueChanged -= new DataGridViewCellEventHandler(GridProgram_CellValueChanged);
        }

        /// <summary>
        /// 簡易プログラムshowイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmBasicProgramOperation2_Shown(object sender, EventArgs e)
        {
			//add 20160907 nakayama
			pnlProgramStep.Height = (this.Height - 100) / 2;

            GridProgram.Focus();    //プログラムグリッドにフォーカス
        }

        #endregion

        #region メニューボタンイベント

        /// <summary>
        /// 運転開始／停止ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkPrgStartEnd_Click(object sender, EventArgs e)
        {
            if (!MainForm.IsUsbConnectBlink) { return; }
            
            if (chkPrgStartEnd.Text.Equals(PROG_START))
            {
				ClearGridBackColor();		//20170125 add nakayama

				chkPrgStartEnd.Text = PROG_END;
                chkPrgStartEnd.Image = Properties.Resources.Stop;
                
				bProgramStart();
            }
            else
            {
                chkPrgStartEnd.Text = PROG_START;
                chkPrgStartEnd.Image = Properties.Resources.Start;
				bProgramStop();
            }
        }

		//20161108 add nakayama
		public void bProgramStart()
		{
			chkPrgStartEnd.Text = PROG_END;
			chkPrgStartEnd.Image = Properties.Resources.Stop;

			//先頭をカレントセルに設定
			GridProgram.CurrentCell = GridProgram[0, 0];
			this.Activate();

			if (!bStartProgram())
			{
				chkPrgStartEnd.Text = PROG_START;
				chkPrgStartEnd.Image = Properties.Resources.Start;
				TimerControlStepStatus.Enabled = false;
			}

			IsSimplified = true;
		}

		//20161108 add nakayama
		public void bProgramStop()
		{
			const UInt16 _svoff = 0x0;

			chkPrgStartEnd.Text = PROG_START;
			chkPrgStartEnd.Image = Properties.Resources.Start;

			TimerControlStepStatus.Enabled = false;

			//20170125 del
			//if (CurrentStepNo >= 0 && CurrentStepNo < GridProgram.Rows.Count)		//20161202 update
			//{
			//    GridProgram.Rows[CurrentStepNo].DefaultCellStyle.BackColor = Color.Empty;
			//}

			//ServoOFF
			CCommandTx.WriteSvNet(CParamID.ServoCommand, _svoff);
			IsSimplified = false;
		}

        /// <summary>
        /// プログラムダウンロードボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDownLoad_Click(object sender, EventArgs e)
        {
            DownLoad(true);
        }

        public bool DownLoad(bool _show)
        {
            if (!MainForm.IsUsbConnectBlink) { return false; }

			//add 20160907 nakayama
			ChildFormControl.SetOpacity(0.0);

			bool bret = false;

           	DialogResult dlgRsult = DialogResult.Yes;

			if (_show)
			{
				//プログラムをダウンロードします
				dlgRsult = MessageBox.Show(UserText.ProgramDownLoad_M1 +
											UserText.Program_OK_M,
											UserText.ProgramDownLoad_H,
											MessageBoxButtons.YesNo,
											MessageBoxIcon.Question);
			}
			
			//add 20160907 nakayama
			ChildFormControl.SetOpacity(1.0);

			if (dlgRsult == DialogResult.Yes) { bret = RunDownLoad(); }

			return bret;
		}

		public bool RunDownLoad()
		{
			bool bret = false;

            this.Cursor = Cursors.WaitCursor;

			ClearGridBackColor();		//20170125 add nakayama

            ProgramAllPanelVisibled(false);

            CheckProgramStartButton();

			if (!bDownLoad())
			{
				this.Cursor = Cursors.Default;
				pBarForm.Close();

				ProgramAllPanelVisibled(true);

				//add 20160907 nakayama
				ChildFormControl.SetOpacity(0.0);

				//プログラムのダウンロードに失敗しました。
				MessageBox.Show(UserText.ProgramDownLoad_NG_M,
								UserText.ProgramDownLoad_H,
								MessageBoxButtons.OK,
								MessageBoxIcon.Warning);

				//add 20160907 nakayama
				ChildFormControl.SetOpacity(1.0);
			}
			else
			{
				bret = true;
			}

            ProgramAllPanelVisibled(true);
            
            this.Cursor = Cursors.Default;

			return bret; 
        }

        /// <summary>
        /// プログラムアップロードボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void btnUpLoad_Click(object sender, EventArgs e)
		{
			UpLoad(true);
		}

		public void UpLoad(bool _show)
		{
	        if (!MainForm.IsUsbConnectBlink) { return; }

			//add 20160907 nakayama
			ChildFormControl.SetOpacity(0.0);

			DialogResult dlgRsult = DialogResult.Yes;

			if (_show)
			{
				//プログラムをアップロードします。
				dlgRsult = MessageBox.Show(UserText.ProgramUpLoad_M1 +
											UserText.Program_OK_M,
											UserText.ProgramUpLoad_H,
											MessageBoxButtons.YesNo,
											MessageBoxIcon.Question);			//20161108 update DownLoad→UpLoad
			}

			 //add 20160907 nakayama
			ChildFormControl.SetOpacity(1.0);
			
			if (dlgRsult == DialogResult.Yes)
            {
				ClearGridBackColor();		//20170125 add nakayama

                this.Cursor = Cursors.WaitCursor;

                ProgramAllPanelVisibled(false);
                CheckProgramStartButton();

                if (!bUpLoad())
                {
                    this.Cursor = Cursors.Default;
                    
                    pBarForm.Close();

                    ProgramAllPanelVisibled(true);

					//add 20160907 nakayama
					ChildFormControl.SetOpacity(0.0);

                    //プログラムのアップロードに失敗しました。
                    MessageBox.Show(UserText.ProgramUpLoad_NG_M,
                                    UserText.ProgramUpLoad_H,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

					//add 20160907 nakayama
					ChildFormControl.SetOpacity(1.0);
				}

                ProgramAllPanelVisibled(true);

                this.Cursor = Cursors.Default;
            }
            
        }

        /// <summary>
        /// プログラムファイル読込みボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrgRead_Click(object sender, EventArgs e)
        {
			DialogResult bresult = FileRead();

			if (bresult == DialogResult.OK)
			{
				ClearGridBackColor();		//20170125 add nakayama

				//プログラムファイルを読込みました。
				MessageBox.Show(UserText.ProgramFileRead_M,
								UserText.ProgramFileRead_H,
								MessageBoxButtons.OK,
								MessageBoxIcon.Information);
			}
			else if (bresult == DialogResult.Abort)
			{
				//プログラムファイル読込み異常です。
				MessageBox.Show(UserText.ProgramFileRead_ERR_M,
								UserText.ProgramFileRead_ERR_H,
								MessageBoxButtons.OK,
								MessageBoxIcon.Warning);
			}
        }

		public DialogResult FileRead()
		{
			DialogResult bresult = DialogResult.OK;

			//add 20160907 nakayama
			ChildFormControl.SetOpacity(0.0);

			bresult = openFileDialog.ShowDialog();

			//ファイルダイアログボックスを開く
			if (bresult == DialogResult.OK)
			{
				//プログラムファイル読込み
				if (!bReadProgramFile())
				{
					bresult = DialogResult.Abort;
				}
			}

			//add 20160907 nakayama
			ChildFormControl.SetOpacity(1.0);

			return bresult;
		}

        /// <summary>
        /// プログラムファイル保存ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void btnPrgSave_Click(object sender, EventArgs e)
		{
			try
			{
				GridProgram.CommitEdit(DataGridViewDataErrorContexts.Commit);		//20171114 add
			}
			catch
			{

			}

			FileSave();
		}

        public void FileSave()
        {
			//add 20160907 nakayama
			ChildFormControl.SetOpacity(0.0);

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
				ClearGridBackColor();		//20170125 add nakayama

                //プログラムファイル書込み
                if (bSaveProgramFile())
                {
                    //プログラムファイルへを保存しました。
                    MessageBox.Show(UserText.ProgramFileSave_M,
                                    UserText.ProgramFileSave_H,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    //プログラムファイル保存に失敗しました。
                    MessageBox.Show(UserText.ProgramFileSave_ERR_M,
                                    UserText.ProgramFileSave_ERR_H,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                }
            }

			//add 20160907 nakayama
			ChildFormControl.SetOpacity(1.0);

		}

        /// <summary>
        /// プログラム保存ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProgramSave_Click(object sender, EventArgs e)
        {
			ProgramSave();
		}

		public void ProgramSave()
		{
			if (!MainForm.IsUsbConnectBlink) { return; }

			//add 20160907 nakayama
			ChildFormControl.SetOpacity(0.0);

            //現在、ダウンロードされているプログラムをフラッシュメモリに保存します。
            DialogResult dlgRsult = MessageBox.Show(UserText.ProgramSave_M1 +
                                                    Environment.NewLine + UserText.Program_OK_M,
                                                    UserText.ProgramSave_H,
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);
            if (dlgRsult == DialogResult.Yes)
            {
				ClearGridBackColor();		//20170125 add nakayama

                if (bSaveProgram())
                {
                    //プログラムをフラッシュメモリに保存にしました。
                    MessageBox.Show(UserText.ProgramFlash_M,
                                    UserText.ProgramSave_H,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    //プログラムのフラッシュメモリへの保存に失敗しました。
                    MessageBox.Show(UserText.ProgramFlash_ERR_M,
                                    UserText.ProgramSave_H,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }

			//add 20160907 nakayama
			ChildFormControl.SetOpacity(1.0);

        }

        /// <summary>
        /// 全プログラムクリアボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProgramClear_Click(object sender, EventArgs e)
        {

            if (!MainForm.IsUsbConnectBlink) { return; }

			//add 20160907 nakayama
			ChildFormControl.SetOpacity(0.0);

            //現在、フラッシュメモリに保存されているプログラムを消去します。
            DialogResult dlgRsult = MessageBox.Show(UserText.ProgramDelete_M1 +
                                                    UserText.Program_OK_M,
                                                    UserText.ProgramDelete_H,
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);
            if (dlgRsult == DialogResult.Yes)
            {
				ClearGridBackColor();		//20170125 add nakayama

                if (bAllProgramClear())
                {
                    //プログラムをフラッシュメモリから消去しました。
                    MessageBox.Show(UserText.ProgramDelete_End_M,
                                    UserText.ProgramDelete_H,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    //フラッシュメモリからのプログラムの消去に失敗しました。
                    MessageBox.Show(UserText.ProgramDelete_NG_M,
                                    UserText.ProgramDelete_H,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }

			//add 20160907 nakayama
			ChildFormControl.SetOpacity(1.0);

		}

        /// <summary>
        /// 各ボタンマウスMouseEnterイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_MouseEnter(object sender, EventArgs e)
        {
            this.Select();
        }

        /// <summary>
        /// 各ボタンマウスMouseHoverイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_MouseHover(object sender, EventArgs e)
        {
            this.Select();
        }

        #endregion

        #region プログラムグリッドイベント

        /// <summary>
        /// プログラムグリッドCellValueChangedイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridProgram_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (GridProgram.CurrentCell == null)
            {
                return;
            }

            int row = GridProgram.CurrentCell.RowIndex;
            int clm = GridProgram.CurrentCell.ColumnIndex;

            //コマンドが変更されたか？
            if (clm == 2)
            {
                string strCmd = GridProgram.Rows[row].Cells["Command"].Value.ToString();

                if (CommandList[row] != null)
                {
                    CommandList[row] = null;
                }

                switch (strCmd)
                {
                    case CmdNOP:
                        CommandList[row] = new ctlCommandNOP();
                        break;

                    case CmdMOVE_END:
                        CommandList[row] = new ctlCommandMOVE_END();
                        break;

                    case CmdMOVE_ST:
                        CommandList[row] = new ctlCommandMOVE_ST();
                        break;

                    case CmdMOVE_V:
                        CommandList[row] = new ctlCommandMOVE_V();
                        break;

                    case CmdMOVE_C:
                        CommandList[row] = new ctlCommandMOVE_C();
                        break;

                    case CmdJMP0:
                        CommandList[row] = new ctlCommandJMP0();
                        break;

                    case CmdJMP_IN:
                        CommandList[row] = new ctlCommandJMP_IN();
                        break;

                    case CmdJMP_IN_OFF:
                        CommandList[row] = new ctlCommandJMP_IN_OFF();
                        break;

                    case CmdJMP_TRQ:
                        CommandList[row] = new ctlCommandJMP_TRQ();
                        break;

                    case CmdJMP_STS:
                        CommandList[row] = new ctlCommandJMP_STS();
                        break;

                    case CmdWAIT0:
                        CommandList[row] = new ctlCommandWAIT0();
                        break;

                    case CmdPC_RESET:
                        CommandList[row] = new ctlCommandPC_RESET();
                        break;

                    case CmdPC_RST_SP:
                        CommandList[row] = new ctlCommandPC_RST_SP();
                        break;

                    case CmdOUT0:
                        CommandList[row] = new ctlCommandOUT0();
                        break;

                    case CmdSV_OFF:
                        CommandList[row] = new ctlCommandSV_OFF();
                        break;

                    case CmdSV_ON:
                        CommandList[row] = new ctlCommandSV_ON();
                        break;

                    case CmdHOME:
                        CommandList[row] = new ctlCommandHOME();
                        break;

                    case CmdP_RESET:
                        CommandList[row] = new ctlCommandP_RESET();
                        break;

                    case CmdAL_RESET:
                        CommandList[row] = new ctlCommandAL_RESET();
                        break;

                    case CmdEND_P:
                        CommandList[row] = new ctlCommandEND_P();
                        break;

                    case CmdEND_V:
                        CommandList[row] = new ctlCommandEND_V();
                        break;

                    case CmdEND_C:
                        CommandList[row] = new ctlCommandEND_C();
                        break;

                    case CmdEND_OFF:
                        CommandList[row] = new ctlCommandEND_OFF();
                        break;

                    case CmdPARA_W:
                        CommandList[row] = new ctlCommandPARA_W();
                        break;
                }

                panelProgData.Controls.Clear();

                Control con = (Control)CommandList[row];
                //con.Dock = DockStyle.Fill;

                ViewCommandHelp(row, GridProgram[2, row].Value.ToString());

                AddAUndoList();
            }
            //else if (clm == 3)			//20171114 update
            //{
                //コメント

                if (GridProgram.Rows[row].Cells["pComment"].Value != null)
                {
                    string strComment = GridProgram.Rows[row].Cells["pComment"].Value.ToString();

                    if (CommandList[row].GetType() == typeof(ctlCommandMOVE_END))
                    {
                        ctlCommandMOVE_END cMOVEEND = (ctlCommandMOVE_END)CommandList[row];
                        cMOVEEND.Comment = strComment;
                    }
                    else if (CommandList[row].GetType() == typeof(ctlCommandMOVE_ST))
                    {
                        ctlCommandMOVE_ST cMOVEST = (ctlCommandMOVE_ST)CommandList[row];
                        cMOVEST.Comment = strComment;
                    }
                    else if (CommandList[row].GetType() == typeof(ctlCommandMOVE_V))
                    {
                        ctlCommandMOVE_V cMOVEV = (ctlCommandMOVE_V)CommandList[row];
                        cMOVEV.Comment = strComment;
                    }
                    else if (CommandList[row].GetType() == typeof(ctlCommandMOVE_C))
                    {
                        ctlCommandMOVE_C cMOVEC = (ctlCommandMOVE_C)CommandList[row];
                        cMOVEC.Comment = strComment;
                    }
                    else if (CommandList[row].GetType() == typeof(ctlCommandJMP0))
                    {
                        ctlCommandJMP0 cJMP0 = (ctlCommandJMP0)CommandList[row];
                        cJMP0.Comment = strComment;
                    }
                    else if (CommandList[row].GetType() == typeof(ctlCommandJMP_IN))
                    {
                        ctlCommandJMP_IN cJMPIN = (ctlCommandJMP_IN)CommandList[row];
                        cJMPIN.Comment = strComment;
                    }
                    else if (CommandList[row].GetType() == typeof(ctlCommandJMP_IN_OFF))
                    {
                        ctlCommandJMP_IN_OFF cJMPINOFF = (ctlCommandJMP_IN_OFF)CommandList[row];
                        cJMPINOFF.Comment = strComment;
                    }
                    else if (CommandList[row].GetType() == typeof(ctlCommandJMP_TRQ))
                    {
                        ctlCommandJMP_TRQ cJMPTRQ = (ctlCommandJMP_TRQ)CommandList[row];
                        cJMPTRQ.Comment = strComment;
                    }
                    else if (CommandList[row].GetType() == typeof(ctlCommandJMP_STS))
                    {
                        ctlCommandJMP_STS cJMPSTS = (ctlCommandJMP_STS)CommandList[row];
                        cJMPSTS.Comment = strComment;
                    }
                    else if (CommandList[row].GetType() == typeof(ctlCommandWAIT0))
                    {
                        ctlCommandWAIT0 cWAIT0 = (ctlCommandWAIT0)CommandList[row];
                        cWAIT0.Comment = strComment;
                    }
                    else if (CommandList[row].GetType() == typeof(ctlCommandOUT0))
                    {
                        ctlCommandOUT0 cOUT0 = (ctlCommandOUT0)CommandList[row];
                        cOUT0.Comment = strComment;
                    }
                    else if (CommandList[row].GetType() == typeof(ctlCommandPARA_W))
                    {
                        ctlCommandPARA_W cPARAW = (ctlCommandPARA_W)CommandList[row];
                        cPARAW.Comment = strComment;
                    }
                    else if (CommandList[row].GetType() == typeof(ctlCommandPC_RST_SP))
                    {
                        ctlCommandPC_RST_SP cPCRSTSP = (ctlCommandPC_RST_SP)CommandList[row];
                        cPCRSTSP.Comment = strComment;
                    }
                    else
                    {
                        //その他の命令（プログラムデータなし）
                        if (CommandList[row].GetType() == typeof(ctlCommandNOP))
                        {
                            ctlCommandNOP cNOP = (ctlCommandNOP)CommandList[row];
                            cNOP.Comment = strComment;
                        }
                        else if (CommandList[row].GetType() == typeof(ctlCommandPC_RESET))
                        {
                            ctlCommandPC_RESET cPCRESET = (ctlCommandPC_RESET)CommandList[row];
                            cPCRESET.Comment = strComment;
                        }
                        else if (CommandList[row].GetType() == typeof(ctlCommandSV_OFF))
                        {
                            ctlCommandSV_OFF cSVOFF = (ctlCommandSV_OFF)CommandList[row];
                            cSVOFF.Comment = strComment;
                        }
                        else if (CommandList[row].GetType() == typeof(ctlCommandSV_ON))
                        {
                            ctlCommandSV_ON cSVON = (ctlCommandSV_ON)CommandList[row];
                            cSVON.Comment = strComment;
                        }
                        else if (CommandList[row].GetType() == typeof(ctlCommandHOME))
                        {
                            ctlCommandHOME cHOME = (ctlCommandHOME)CommandList[row];
                            cHOME.Comment = strComment;
                        }
                        else if (CommandList[row].GetType() == typeof(ctlCommandP_RESET))
                        {
                            ctlCommandP_RESET cPRESET = (ctlCommandP_RESET)CommandList[row];
                            cPRESET.Comment = strComment;
                        }
                        else if (CommandList[row].GetType() == typeof(ctlCommandAL_RESET))
                        {
                            ctlCommandAL_RESET cALRESET = (ctlCommandAL_RESET)CommandList[row];
                            cALRESET.Comment = strComment;
                        }
                        else if (CommandList[row].GetType() == typeof(ctlCommandEND_P))
                        {
                            ctlCommandEND_P cENDP = (ctlCommandEND_P)CommandList[row];
                            cENDP.Comment = strComment;
                        }
                        else if (CommandList[row].GetType() == typeof(ctlCommandEND_V))
                        {
                            ctlCommandEND_V cENDV = (ctlCommandEND_V)CommandList[row];
                            cENDV.Comment = strComment;
                        }
                        else if (CommandList[row].GetType() == typeof(ctlCommandEND_C))
                        {
                            ctlCommandEND_C cENDC = (ctlCommandEND_C)CommandList[row];
                            cENDC.Comment = strComment;
                        }
                        else if (CommandList[row].GetType() == typeof(ctlCommandEND_OFF))
                        {
                            ctlCommandEND_OFF cENDOFF = (ctlCommandEND_OFF)CommandList[row];
                            cENDOFF.Comment = strComment;
                        }
                    }
                //}
            }
        }

        /// <summary>
        /// プログラムグリッドCurrentCellChangedイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridProgram_CurrentCellChanged(object sender, EventArgs e)
        {
            if (GridProgram.CurrentRow == null)
            {
                return;
            }

            int row = GridProgram.CurrentRow.Index;

            //最終行か？
            if (row == ActRowCnt - 1 && MAX_STEP_COUNT > ActRowCnt)
            {
                GridProgram.Rows.Add(1);

                GridProgram.Rows[ActRowCnt].Cells["Step"].Value = ActRowCnt.ToString();
                GridProgram.Rows[ActRowCnt].Cells["Command"].Value = "NOP";

                ActRowCnt++;
            }

            if (GridProgram[2, row].Value == null)
            {
                return;
            }

			if (pmoveform != null)
			{
				pmoveform.UpdateCurrentCellProfileTable(row);
			}

            //選択されたプログラムのヘルプ表示
            ViewCommandHelp(row, GridProgram[2, row].Value.ToString());
        }

        /// <summary>
        /// プログラムグリッドCurrentCellDirtyStateChangedイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridProgram_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (GridProgram.Columns[GridProgram.CurrentCellAddress.X] is DataGridViewComboBoxColumn)
            {
                // CellValueChangedイベントを発生させる
                GridProgram.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private bool IsScroll = false;

        /// <summary>
        /// プログラムグリッドCellEnterイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridProgram_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //一回のクリックでエディットモードにする
            if (GridProgram.Columns[e.ColumnIndex].Name == "Command"
                && GridProgram.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)
            {
                //SendKeys.Send("{F4}");
                IsScroll = true;
            }
        }

        /// <summary>
        /// プログラムグリッドCellClickイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridProgram_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                if (GridProgram.Columns[e.ColumnIndex].Name == "pLabel" ||
                    GridProgram.Columns[e.ColumnIndex].Name == "pComment")
                {
                    //一回のクリックでエディットモードにする
                    //SendKeys.Send("{F2}");
                    IsScroll = false;
                }
            }
        }

        private void GridProgram_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                DataGridView dgv = (DataGridView)sender;

                if (dgv.CurrentCell.OwningColumn.Name == "Command")
                {
                    DataGridViewComboBoxEditingControl dgvcmb = (DataGridViewComboBoxEditingControl)e.Control;
                    dgvcmb.MouseWheel += new MouseEventHandler(dgvcmb_MouseWheel);
                }
            }
        }

        void dgvcmb_MouseWheel(object sender, MouseEventArgs e)
        {
            HandledMouseEventArgs Hme = (HandledMouseEventArgs)e;
            Hme.Handled = IsScroll;
        }

        void GridProgram_MouseWheel(object sender, MouseEventArgs e)
        {
            HandledMouseEventArgs Hme = (HandledMouseEventArgs)e;
            Hme.Handled = IsScroll;
        }

        #endregion

        #region ショートカットメニュー

        /// <summary>
        /// ショートカットメニュ－クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmnuStep_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Tag.ToString())
            {
                //コピー
                case "Copy":
                    cmnuStep.Close();
                    bCopy();
                    break;

                //切取り
                case "Cut":
                    cmnuStep.Close();
                    bCut();
                    break;

                //張付け
                case "Paste":
                    cmnuStep.Close();
                    bPaste();
                    break;

                //行挿入後張付け
                case "Paste2":
                    cmnuStep.Close();
                    bPaste2();
                    break;

                //行挿入
                case "Insert Row":
                    cmnuStep.Close();
                    bInsertRow();
                    break;

                //行クリア
                case "Delete Row":
                    cmnuStep.Close();
                    bDeleteRow();
                    break;

                //元に戻す
                case "Undo":
                    cmnuStep.Close();
                    bUndo();
                    break;

                //やり直し
                case "Redo":
                    cmnuStep.Close();
                    bRedo();
                    break;

                //ダウンロード
                case "DownLoad":
                    cmnuStep.Close();
                    btnDownLoad.PerformClick();
                    break;

                //アップロード
                case "UpLoad":
                    cmnuStep.Close();
                    btnUpLoad.PerformClick();
                    break;

                default:
                    cmnuStep.Close();
                    break;
            }
        }

        /// <summary>
        /// 終了ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region プログラム編集機能

        private int s_CopyRow = 0;      // 編集開始行
        private int e_CopyRow = 0;      // 編集終了行

        /// <summary>
        /// コピー
        /// </summary>
        private void bCopy()
        {
            if (GetSelectedRows(ref s_CopyRow, ref e_CopyRow))
            {
                int cnt = (e_CopyRow - s_CopyRow) + 1;

                if (CopyCommandList != null)
                {
                    CopyCommandList = null;
                }

                CopyCommandList = new object[cnt];
                Array.Copy(CommandList, s_CopyRow, CopyCommandList, 0, cnt);

                IsSelected = true;
            }
            else
            {
                //異常
                IsSelected = false;
            }
        }

        /// <summary>
        /// 切取り
        /// </summary>
        private void bCut()
        {
            if (GetSelectedRows(ref s_CopyRow, ref e_CopyRow))
            {
                int cnt = (e_CopyRow - s_CopyRow) + 1;

                if (CopyCommandList != null)
                {
                    CopyCommandList = null;
                }

                CopyCommandList = new object[cnt];

                int j = 0;
                for (int i = s_CopyRow; i <= e_CopyRow; i++, j++)
                {
                    CopyCommandList[j] = CommandList[i];

                    //切り取ったグリッドはNOPに設定する
                    GridProgram[2, i].Value = CmdNOP;

                    CommandList[i] = null;
                    CommandList[i] = new ctlCommandNOP();
                }

                IsSelected = true;
            }
            else
            {
                //異常
                IsSelected = false;
            }
        }

        /// <summary>
        /// 貼り付け
        /// </summary>
        private void bPaste()
        {
            int s_Row = 0;      // 編集開始行
            int e_Row = 0;      // 編集終了行

            if (IsSelected)
            {
                if (GetSelectedRows(ref s_Row, ref e_Row))
                {
                    //コピーまたは、切り取りされたか？
                    if (CopyCommandList != null)
                    {
                        int j = s_Row;
                        int len = e_CopyRow - s_CopyRow;

                        if ((j + len) >= MAX_STEP_COUNT)
                        {
                            //貼り付けるプログラムが最大ステップ(１２８ステップ)を超えています。
                            MessageBox.Show(UserText.ProgramPaste_NG_M,
                                            UserText.ProgramPaste_NG_H,
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);

                            return;
                        }

                        //コピー先へ選択されたプログラムを貼り付ける
                        for (int i = 0; i <= len; i++, j++)
                        {
                            if (CopyCommandList[i].GetType() == typeof(ctlCommandMOVE_END))
                            {
                                CommandList[j] = new ctlCommandMOVE_END();

                                ctlCommandMOVE_END DestMOVEEND = (ctlCommandMOVE_END)CommandList[j];
                                ctlCommandMOVE_END SrcMOVEEND = (ctlCommandMOVE_END)CopyCommandList[i];

                                DestMOVEEND.FLAG_M1 = SrcMOVEEND.FLAG_M1;
                                DestMOVEEND.TargetVelocity = SrcMOVEEND.TargetVelocity;
                                DestMOVEEND.TargetPosition = SrcMOVEEND.TargetPosition;
                                DestMOVEEND.Acceleration = SrcMOVEEND.Acceleration;
                                DestMOVEEND.Deceleration = SrcMOVEEND.Deceleration;
                                DestMOVEEND.Comment = SrcMOVEEND.Comment;

                            }
                            else if (CopyCommandList[i].GetType() == typeof(ctlCommandMOVE_ST))
                            {
                                CommandList[j] = new ctlCommandMOVE_ST();

                                ctlCommandMOVE_ST DestMOVEST = (ctlCommandMOVE_ST)CommandList[j];
                                ctlCommandMOVE_ST SrcMOVEST = (ctlCommandMOVE_ST)CopyCommandList[i];

                                DestMOVEST.FLAG_M2 = SrcMOVEST.FLAG_M2;
                                DestMOVEST.TargetVelocity = SrcMOVEST.TargetVelocity;
                                DestMOVEST.TargetPostion = SrcMOVEST.TargetPostion;
                                DestMOVEST.Acceleration = SrcMOVEST.Acceleration;
                                DestMOVEST.Deceleration = SrcMOVEST.Deceleration;
                                DestMOVEST.Comment = SrcMOVEST.Comment;
                            }
                            else if (CopyCommandList[i].GetType() == typeof(ctlCommandMOVE_V))
                            {
                                CommandList[j] = new ctlCommandMOVE_V();

                                ctlCommandMOVE_V DestMOVEV = (ctlCommandMOVE_V)CommandList[j];
                                ctlCommandMOVE_V SrcMOVEV = (ctlCommandMOVE_V)CopyCommandList[i];

                                DestMOVEV.FLAG_M3 = SrcMOVEV.FLAG_M3;
                                DestMOVEV.TargetVelocity = SrcMOVEV.TargetVelocity;
                                DestMOVEV.Acceleration = SrcMOVEV.Acceleration;
                                DestMOVEV.Deceleration = SrcMOVEV.Deceleration;
                                DestMOVEV.Comment = SrcMOVEV.Comment;
                            }
                            else if (CopyCommandList[i].GetType() == typeof(ctlCommandMOVE_C))
                            {
                                CommandList[j] = new ctlCommandMOVE_C();

                                ctlCommandMOVE_C DestMOVEC = (ctlCommandMOVE_C)CommandList[j];
                                ctlCommandMOVE_C SrcMOVEC = (ctlCommandMOVE_C)CopyCommandList[i];

                                DestMOVEC.FLAG_M4 = SrcMOVEC.FLAG_M4;
                                DestMOVEC.TargetCurrrent = SrcMOVEC.TargetCurrrent;
                                DestMOVEC.Comment = SrcMOVEC.Comment;
                            }
                            else if (CopyCommandList[i].GetType() == typeof(ctlCommandJMP0))
                            {
                                CommandList[j] = new ctlCommandJMP0();

                                ctlCommandJMP0 DestJMP0 = (ctlCommandJMP0)CommandList[j];
                                ctlCommandJMP0 SrcJMP0 = (ctlCommandJMP0)CopyCommandList[i];

                                DestJMP0.DiveStep = SrcJMP0.DiveStep;
                                DestJMP0.WaitTime = SrcJMP0.WaitTime;
                                DestJMP0.RepeatNumber = SrcJMP0.RepeatNumber;
                                DestJMP0.Comment = SrcJMP0.Comment;
                            }
                            else if (CopyCommandList[i].GetType() == typeof(ctlCommandJMP_IN))
                            {
                                CommandList[j] = new ctlCommandJMP_IN();

                                ctlCommandJMP_IN DestJMPIN = (ctlCommandJMP_IN)CommandList[j];
                                ctlCommandJMP_IN SrcJMPIN = (ctlCommandJMP_IN)CopyCommandList[i];

                                DestJMPIN.MODE_J1 = SrcJMPIN.MODE_J1;
                                DestJMPIN.DiveStep = SrcJMPIN.DiveStep;
                                DestJMPIN.InputNumber = SrcJMPIN.InputNumber;
                                DestJMPIN.WaitTime = SrcJMPIN.WaitTime;
                                DestJMPIN.Comment = SrcJMPIN.Comment;
                            }
                            else if (CopyCommandList[i].GetType() == typeof(ctlCommandJMP_IN_OFF))
                            {
                                CommandList[j] = new ctlCommandJMP_IN_OFF();

                                ctlCommandJMP_IN_OFF DestJMPINOFF = (ctlCommandJMP_IN_OFF)CommandList[j];
                                ctlCommandJMP_IN_OFF SrcJMPINOFF = (ctlCommandJMP_IN_OFF)CopyCommandList[i];

                                DestJMPINOFF.MODE_J2 = SrcJMPINOFF.MODE_J2;
                                DestJMPINOFF.DiveStep = SrcJMPINOFF.DiveStep;
                                DestJMPINOFF.InputNumber = SrcJMPINOFF.InputNumber;
                                DestJMPINOFF.WaitTime = SrcJMPINOFF.WaitTime;
                                DestJMPINOFF.Comment = SrcJMPINOFF.Comment;
                            }
                            else if (CopyCommandList[i].GetType() == typeof(ctlCommandJMP_TRQ))
                            {
                                CommandList[j] = new ctlCommandJMP_TRQ();

                                ctlCommandJMP_TRQ DestJMPINTRQ = (ctlCommandJMP_TRQ)CommandList[j];
                                ctlCommandJMP_TRQ SrcJMPINTRQ = (ctlCommandJMP_TRQ)CopyCommandList[i];

                                DestJMPINTRQ.MODE_J3 = SrcJMPINTRQ.MODE_J3;
                                DestJMPINTRQ.DiveStep = SrcJMPINTRQ.DiveStep;
                                DestJMPINTRQ.CurThreshold = SrcJMPINTRQ.CurThreshold;
                                DestJMPINTRQ.WaitTime = SrcJMPINTRQ.WaitTime;
                                DestJMPINTRQ.DiveLogic = SrcJMPINTRQ.DiveLogic;
                                DestJMPINTRQ.Comment = SrcJMPINTRQ.Comment;
                            }
                            else if (CopyCommandList[i].GetType() == typeof(ctlCommandJMP_STS))
                            {
                                CommandList[j] = new ctlCommandJMP_STS();

                                ctlCommandJMP_STS DestJMPSTS = (ctlCommandJMP_STS)CommandList[j];
                                ctlCommandJMP_STS SrcJMPSTS = (ctlCommandJMP_STS)CopyCommandList[i];

                                DestJMPSTS.MODE_J1 = SrcJMPSTS.MODE_J1;
                                DestJMPSTS.DiveStep = SrcJMPSTS.DiveStep;
                                DestJMPSTS.ServoSTSBit = SrcJMPSTS.ServoSTSBit;
                                DestJMPSTS.WaitTime = SrcJMPSTS.WaitTime;
                                DestJMPSTS.DiveLogic = SrcJMPSTS.DiveLogic;
                                DestJMPSTS.Comment = SrcJMPSTS.Comment;
                            }
                            else if (CopyCommandList[i].GetType() == typeof(ctlCommandWAIT0))
                            {
                                CommandList[j] = new ctlCommandWAIT0();

                                ctlCommandWAIT0 DestWAIT0 = (ctlCommandWAIT0)CommandList[j];
                                ctlCommandWAIT0 SrcWAIT0 = (ctlCommandWAIT0)CopyCommandList[i];

                                DestWAIT0.WaitTime = SrcWAIT0.WaitTime;
                                DestWAIT0.Comment = SrcWAIT0.Comment;
                            }
                            else if (CopyCommandList[i].GetType() == typeof(ctlCommandOUT0))
                            {
                                CommandList[j] = new ctlCommandOUT0();

                                ctlCommandOUT0 DestOUT0 = (ctlCommandOUT0)CommandList[j];
                                ctlCommandOUT0 SrcOUT0 = (ctlCommandOUT0)CopyCommandList[i];

                                DestOUT0.OutNumber = SrcOUT0.OutNumber;
                                DestOUT0.OutputLogic = SrcOUT0.OutputLogic;
                                DestOUT0.Comment = SrcOUT0.Comment;
                            }
                            else if (CopyCommandList[i].GetType() == typeof(ctlCommandPARA_W))
                            {
                                CommandList[j] = new ctlCommandPARA_W();

                                ctlCommandPARA_W DestPARAW = (ctlCommandPARA_W)CommandList[j];
                                ctlCommandPARA_W SrcPARAW = (ctlCommandPARA_W)CopyCommandList[i];

                                DestPARAW.ParameterID = SrcPARAW.ParameterID;
                                DestPARAW.WriteData = SrcPARAW.WriteData;
                                DestPARAW.Comment = SrcPARAW.Comment;
                            }
                            else if (CopyCommandList[i].GetType() == typeof(ctlCommandPC_RST_SP))
                            {
                                CommandList[j] = new ctlCommandPC_RST_SP();

                                ctlCommandPC_RST_SP DestPCRSTSP = (ctlCommandPC_RST_SP)CommandList[j];
                                ctlCommandPC_RST_SP SrcPCRSTS = (ctlCommandPC_RST_SP)CopyCommandList[i];

                                DestPCRSTSP.StepNumber = SrcPCRSTS.StepNumber;
                                DestPCRSTSP.Comment = SrcPCRSTS.Comment;
                            }
                            else
                            {
                                //その他の命令（プログラムデータなし）
                                if (CopyCommandList[i].GetType() == typeof(ctlCommandNOP))
                                {
                                    CommandList[j] = new ctlCommandNOP();

                                    ctlCommandNOP DestNOP = (ctlCommandNOP)CommandList[j];
                                    ctlCommandNOP SrcNOP = (ctlCommandNOP)CopyCommandList[i];

                                    DestNOP.Comment = SrcNOP.Comment;

                                }
                                else if (CopyCommandList[i].GetType() == typeof(ctlCommandPC_RESET))
                                {
                                    CommandList[j] = new ctlCommandPC_RESET();

                                    ctlCommandPC_RESET DestPCRESET = (ctlCommandPC_RESET)CommandList[j];
                                    ctlCommandPC_RESET SrcPCRESET = (ctlCommandPC_RESET)CopyCommandList[i];

                                    DestPCRESET.Comment = SrcPCRESET.Comment;
                                }
                                else if (CopyCommandList[i].GetType() == typeof(ctlCommandSV_OFF))
                                {
                                    CommandList[j] = new ctlCommandSV_OFF();

                                    ctlCommandSV_OFF DestSVOFF = (ctlCommandSV_OFF)CommandList[j];
                                    ctlCommandSV_OFF SrcSVOFF = (ctlCommandSV_OFF)CopyCommandList[i];

                                    DestSVOFF.Comment = SrcSVOFF.Comment;
                                }
                                else if (CopyCommandList[i].GetType() == typeof(ctlCommandSV_ON))
                                {
                                    CommandList[j] = new ctlCommandSV_ON();

                                    ctlCommandSV_ON DestSVON = (ctlCommandSV_ON)CommandList[j];
                                    ctlCommandSV_ON SrcSVON = (ctlCommandSV_ON)CopyCommandList[i];

                                    DestSVON.Comment = SrcSVON.Comment;
                                }
                                else if (CopyCommandList[i].GetType() == typeof(ctlCommandHOME))
                                {
                                    CommandList[j] = new ctlCommandHOME();

                                    ctlCommandHOME DestcHOME = (ctlCommandHOME)CommandList[j];
                                    ctlCommandHOME SrccHOME = (ctlCommandHOME)CopyCommandList[i];

                                    DestcHOME.Comment = SrccHOME.Comment;
                                }
                                else if (CopyCommandList[i].GetType() == typeof(ctlCommandP_RESET))
                                {
                                    CommandList[j] = new ctlCommandP_RESET();

                                    ctlCommandP_RESET DestPRESET = (ctlCommandP_RESET)CommandList[j];
                                    ctlCommandP_RESET SrcPRESET = (ctlCommandP_RESET)CopyCommandList[i];

                                    DestPRESET.Comment = SrcPRESET.Comment;
                                }
                                else if (CopyCommandList[i].GetType() == typeof(ctlCommandAL_RESET))
                                {
                                    CommandList[j] = new ctlCommandAL_RESET();

                                    ctlCommandAL_RESET DestALRESET = (ctlCommandAL_RESET)CommandList[j];
                                    ctlCommandAL_RESET SrcALRESET = (ctlCommandAL_RESET)CopyCommandList[i];

                                    DestALRESET.Comment = SrcALRESET.Comment;
                                }
                                else if (CopyCommandList[i].GetType() == typeof(ctlCommandEND_P))
                                {
                                    CommandList[j] = new ctlCommandEND_P();

                                    ctlCommandEND_P DestENDP = (ctlCommandEND_P)CommandList[j];
                                    ctlCommandEND_P SrcENDP = (ctlCommandEND_P)CopyCommandList[i];

                                    DestENDP.Comment = SrcENDP.Comment;
                                }
                                else if (CopyCommandList[i].GetType() == typeof(ctlCommandEND_V))
                                {
                                    CommandList[j] = new ctlCommandEND_V();

                                    ctlCommandEND_V DestENDV = (ctlCommandEND_V)CommandList[j];
                                    ctlCommandEND_V SrcENDV = (ctlCommandEND_V)CopyCommandList[i];

                                    DestENDV.Comment = SrcENDV.Comment;
                                }
                                else if (CopyCommandList[i].GetType() == typeof(ctlCommandEND_C))
                                {
                                    CommandList[j] = new ctlCommandEND_C();

                                    ctlCommandEND_C DestENDC = (ctlCommandEND_C)CommandList[j];
                                    ctlCommandEND_C SrcENDC = (ctlCommandEND_C)CopyCommandList[i];

                                    DestENDC.Comment = SrcENDC.Comment;
                                }
                                else if (CopyCommandList[i].GetType() == typeof(ctlCommandEND_OFF))
                                {
                                    CommandList[j] = new ctlCommandEND_OFF();

                                    ctlCommandEND_OFF DestENDOFF = (ctlCommandEND_OFF)CommandList[j];
                                    ctlCommandEND_OFF SrcENDOFF = (ctlCommandEND_OFF)CopyCommandList[i];

                                    DestENDOFF.Comment = SrcENDOFF.Comment;
                                }
                            }
                        }

                        //プログラムグリッド再描画
                        ReDrawProgarmGridView(s_Row, len += s_Row);

                        //カレント行をコピー先の先頭行へ変更
                        //GridProgram.CurrentCell = GridProgram[2, s_Row];

                        AddAUndoList();
                    }
                }
            }
        }

        /// <summary>
        /// 行挿入後貼り付け
        /// </summary>
        private void bPaste2()
        {


        }

        /// <summary>
        /// 行挿入
        /// </summary>
        private void bInsertRow()
        {
            int s_Row = 0;      // 編集開始行
            int e_Row = 0;      // 編集終了行

            if (GetSelectedRows(ref s_Row, ref e_Row))
            {
                int len = (e_Row - s_Row) + 1;

                CopyCommandList = null;
                CopyCommandList = new object[MAX_STEP_COUNT];

                int i = 0;

                for (i = 0; i < s_Row; i++)
                {
                    CopyCommandList[i] = CommandList[i];
                }

                for (int j = 0; j < len; j++, i++)
                {
                    CopyCommandList[i] = new ctlCommandNOP();   //NOPで埋める
                }

                for (int k = i - len; i < MAX_STEP_COUNT; i++, k++)
                {
                    CopyCommandList[i] = CommandList[k];
                }

                CopyCommandList.CopyTo(CommandList, 0);

                //プログラムグリッド再描画
                ReDrawProgarmGridView(0, MAX_STEP_COUNT - 1);

                AddAUndoList();
            }
        }

        /// <summary>
        /// 行削除
        /// </summary>
        private void bDeleteRow()
        {
            int s_Row = 0;      // 編集開始行
            int e_Row = 0;      // 編集終了行

            if (GetSelectedRows(ref s_Row, ref e_Row))
            {
                int len = (e_Row - s_Row) + 1;

                CopyCommandList = null;
                CopyCommandList = new object[MAX_STEP_COUNT];

                int i = 0;

                for (; i < s_Row; i++)
                {
                    CopyCommandList[i] = CommandList[i];
                }

                int k = MAX_STEP_COUNT - len;
                for (int j = i + len; i < k; i++, j++)
                {
                    CopyCommandList[i] = CommandList[j];
                }

                //削除した分、NOPで詰める
                for (; i < MAX_STEP_COUNT; i++)
                {
                    CopyCommandList[i] = new ctlCommandNOP();
                }

                CopyCommandList.CopyTo(CommandList, 0);

                //プログラムグリッド再描画
                ReDrawProgarmGridView(0, MAX_STEP_COUNT - 1);

                AddAUndoList();
            }
        }

        /// <summary>
        /// 元に戻す
        /// </summary>
        private void bUndo()
        {
            if (UndoList.Count > 0 && ActUndoPtr > 0)
            {
                CommandList = null;
                CommandList = new object[MAX_STEP_COUNT];

                ActUndoPtr--;

                ((object[])UndoList[ActUndoPtr]).CopyTo(CommandList, 0);

                //元に戻しした状態のグリッドを再描画    
                ReDrawProgarmGridView(0, MAX_STEP_COUNT - 1);

                GridProgram.CurrentCell = GridProgram[2, CurrentStep[ActUndoPtr]];

                IsEdit = false; //UNDO操作あり

                IsUndo = true;
            }
        }

        /// <summary>
        /// やり直し
        /// </summary>
        private void bRedo()
        {
            if (!IsEdit && UndoList.Count > (ActUndoPtr + 1))
            {
                CommandList = null;
                CommandList = new object[MAX_STEP_COUNT];

                ActUndoPtr++;

                ((object[])UndoList[ActUndoPtr]).CopyTo(CommandList, 0);

                //元に戻しした状態のグリッドを再描画    
                ReDrawProgarmGridView(0, MAX_STEP_COUNT - 1);

                GridProgram.CurrentCell = GridProgram[2, CurrentStep[ActUndoPtr]];

                IsUndo = false;
            }
        }

        #endregion

        #region プログラム運転

        /// <summary>
        /// プログラム運転開始
        /// </summary>
        private bool bStartProgram()
        {
            byte controlMode = 14;      // 簡易ｺﾝﾄﾛｰﾙﾓｰﾄﾞ
            UInt16 svon = 0x0001;       // Servo ON
            UInt16 svoff = 0x0000;      // Servo OFF

            //SV-OFF
            if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, svoff)) 
            { 
                return false; 
            }

            //制御ﾓｰﾄﾞ
            if (!CCommandTx.WriteSvNet(CParamID.ControlMode, controlMode))
            {
                return false;
            }

            //Servo ON
            if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, svon))
            {
                return false;
            }

            CurrentStepNo = 0;
            PrevStepNo = -1;

            TimerControlStepStatus.Enabled = true;

            return true;
        }

        #endregion

        #region プログラムステータスタイマー

        /// <summary>
        /// プログラムステータスタイマー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerControlStepStatus_Tick(object sender, EventArgs e)
        {
            //コントロールステップステータス
            if (!CCommandTx.ReadSvNet(CParamID.ControlProgStep, ref CurrentStepNo)) 
            {
                TimerControlStepStatus.Enabled = false;
                return;
            }

            //既に現在のステップに対して処理済みであれば、スキップする
            if (CurrentStepNo == PrevStepNo)
            {
                return;
            }

            //ステップ終了？
            if ((CurrentStepNo & 0x1000) == 0x1000)
            {
                TimerControlStepStatus.Enabled = false;

				if (PrevStepNo >= 0 && PrevStepNo < GridProgram.Rows.Count)		//20161202 update
				{
					GridProgram.Rows[PrevStepNo].DefaultCellStyle.BackColor = Color.Empty;
				}

                chkPrgStartEnd.Text = PROG_START;
                chkPrgStartEnd.Image = Properties.Resources.Start;

                //プログラムが終了しました。
                MessageBox.Show(UserText.ProgramEND_M,
                                UserText.ProgramEND_H,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

			if (CurrentStepNo >= GridProgram.Rows.Count) { return; }	//20161202 add

            // 初回？
            if (PrevStepNo == -1)
            {
                PrevStepNo = CurrentStepNo;
            }

            // 実行中のステップを黄色で表示
            GridProgram.Rows[PrevStepNo].DefaultCellStyle.BackColor = Color.Empty;
            GridProgram.Rows[CurrentStepNo].DefaultCellStyle.BackColor = Color.Yellow;

            //指定ステップ位置表示
            MoveProgramStep(CurrentStepNo);

            PrevStepNo = CurrentStepNo;
        }

        #endregion

        #region プログラムダウンロード

        /// <summary>
        /// プログラムダウンロード
        /// </summary>
        /// <returns></returns>
        private bool bDownLoad()
        {
            Int32 iStep = 0;
            Int32 iValue177 = 0;
            Int32 iValue178 = 0;
            Int32 iValue179 = 0;

            //サーボＯＦＦする
            if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, 0))
            { 
                return false; 
            }

            //ドライバプログラム全クリア
            //if (!bAllProgramClear())
            //{
            //    return false;
            //}

            //既にプログラムコードデータが存在する場合は全消去
            if (BasicProgramOp.Count > 0)
            {
                BasicProgramOp.Clear();
            }

            for (int row = 0; row < CommandList.Length; row++)
            {
                if (CommandList[row].GetType() == typeof(ctlCommandMOVE_END))
                {
                    ctlCommandMOVE_END cMOVEEND = (ctlCommandMOVE_END)CommandList[row];

                    iValue177 = (((Int32)cMOVEEND.ID) << 24) | (((UInt16)cMOVEEND.FLAG_M1) << 16) | ((UInt16)cMOVEEND.TargetVelocity);
                    iValue178 = cMOVEEND.TargetPosition;
                    iValue179 = (((Int32)cMOVEEND.Acceleration) << 16) | ((UInt16)cMOVEEND.Deceleration);
                }
                else if (CommandList[row].GetType() == typeof(ctlCommandMOVE_ST))
                {
                    ctlCommandMOVE_ST cMOVEST = (ctlCommandMOVE_ST)CommandList[row];

                    iValue177 = (((Int32)cMOVEST.ID) << 24) | (((UInt16)cMOVEST.FLAG_M2) << 16) | ((UInt16)cMOVEST.TargetVelocity);
                    iValue178 = cMOVEST.TargetPostion;
                    iValue179 = (((Int32)cMOVEST.Acceleration) << 16) | ((UInt16)cMOVEST.Deceleration);
                }
                else if (CommandList[row].GetType() == typeof(ctlCommandMOVE_V))
                {
                    ctlCommandMOVE_V cMOVEV = (ctlCommandMOVE_V)CommandList[row];

                    iValue177 = (((Int32)cMOVEV.ID) << 24) | (((UInt16)cMOVEV.FLAG_M3) << 16) | ((UInt16)cMOVEV.TargetVelocity);
                    iValue178 = 0;
                    iValue179 = (((Int32)cMOVEV.Acceleration) << 16) | ((UInt16)cMOVEV.Deceleration);
                }
                else if (CommandList[row].GetType() == typeof(ctlCommandMOVE_C))
                {
                    ctlCommandMOVE_C cMOVEC = (ctlCommandMOVE_C)CommandList[row];

                    iValue177 = (((Int32)cMOVEC.ID) << 24) | (((UInt16)cMOVEC.FLAG_M4) << 16) | ((UInt16)cMOVEC.TargetCurrrent);
                    iValue178 = 0;
                    iValue179 = 0;
                }
                else if (CommandList[row].GetType() == typeof(ctlCommandJMP0))
                {
                    ctlCommandJMP0 cJMP0 = (ctlCommandJMP0)CommandList[row];

                    iValue177 = (((Int32)cJMP0.ID) << 24) | ((UInt16)cJMP0.DiveStep);
                    iValue178 = (Int32)cJMP0.WaitTime;
                    iValue179 = (Int32)cJMP0.RepeatNumber;
                }
                else if (CommandList[row].GetType() == typeof(ctlCommandJMP_IN))
                {
                    ctlCommandJMP_IN cJMPIN = (ctlCommandJMP_IN)CommandList[row];

                    iValue177 = (((Int32)cJMPIN.ID) << 24) | (((UInt16)cJMPIN.MODE_J1) << 16) | ((UInt16)cJMPIN.DiveStep);
                    iValue178 = (((Int32)cJMPIN.InputNumber) << 16) | ((UInt16)cJMPIN.WaitTime);
                    iValue179 = 0;
                }
                else if (CommandList[row].GetType() == typeof(ctlCommandJMP_IN_OFF))
                {
                    ctlCommandJMP_IN_OFF cJMPIN_OFF = (ctlCommandJMP_IN_OFF)CommandList[row];

                    iValue177 = (((Int32)cJMPIN_OFF.ID) << 24) | (((UInt16)cJMPIN_OFF.MODE_J2) << 16) | ((UInt16)cJMPIN_OFF.DiveStep);
                    iValue178 = (((Int32)cJMPIN_OFF.InputNumber) << 16) | ((UInt16)cJMPIN_OFF.WaitTime);
                    iValue179 = 0;
                }
                else if (CommandList[row].GetType() == typeof(ctlCommandJMP_TRQ))
                {
                    ctlCommandJMP_TRQ cJMP_TRQ = (ctlCommandJMP_TRQ)CommandList[row];

                    iValue177 = (((Int32)cJMP_TRQ.ID) << 24) | (((UInt16)cJMP_TRQ.MODE_J3) << 16) | ((UInt16)cJMP_TRQ.DiveStep);
                    iValue178 = (((Int32)cJMP_TRQ.CurThreshold) << 16) | ((UInt16)cJMP_TRQ.WaitTime);
                    iValue179 = (((Int32)cJMP_TRQ.DiveLogic) << 24);
                }
                else if (CommandList[row].GetType() == typeof(ctlCommandJMP_STS))
                {
                    ctlCommandJMP_STS cJMP_STS = (ctlCommandJMP_STS)CommandList[row];

                    iValue177 = (((Int32)cJMP_STS.ID) << 24) | (((UInt16)cJMP_STS.MODE_J1) << 16) | ((UInt16)cJMP_STS.DiveStep);
                    iValue178 = (Int32)cJMP_STS.ServoSTSBit;
                    iValue179 = (((Int32)cJMP_STS.DiveLogic) << 24) | ((UInt16)cJMP_STS.WaitTime);
                }
                else if (CommandList[row].GetType() == typeof(ctlCommandWAIT0))
                {
                    ctlCommandWAIT0 cWAIT0 = (ctlCommandWAIT0)CommandList[row];

                    iValue177 = (((Int32)cWAIT0.ID) << 24);
                    iValue178 = (Int32)cWAIT0.WaitTime;
                    iValue179 = 0;
                }
                else if (CommandList[row].GetType() == typeof(ctlCommandOUT0))
                {
                    ctlCommandOUT0 cOUT0 = (ctlCommandOUT0)CommandList[row];

                    iValue177 = (((Int32)cOUT0.ID) << 24) | ((UInt16)cOUT0.OutNumber);
                    iValue178 = (Int32)cOUT0.OutputLogic;
                    iValue179 = 0;
                }
                else if (CommandList[row].GetType() == typeof(ctlCommandPARA_W))
                {
                    ctlCommandPARA_W cPARAW = (ctlCommandPARA_W)CommandList[row];

                    iValue177 = (((Int32)cPARAW.ID) << 24) | ((UInt16)cPARAW.ParameterID);
                    iValue178 = cPARAW.WriteData;
                    iValue179 = 0;
                }
                else
                {
                    //その他の命令（プログラムデータなし）
                    if (CommandList[row].GetType() == typeof(ctlCommandNOP))
                    {
                        ctlCommandNOP cNOP = (ctlCommandNOP)CommandList[row];

                        iValue177 = (((Int32)cNOP.ID) << 24);
                        iValue178 = 0;
                        iValue179 = 0;
                    }
                    else if (CommandList[row].GetType() == typeof(ctlCommandPC_RESET))
                    {
                        ctlCommandPC_RESET cPCRESET = (ctlCommandPC_RESET)CommandList[row];

                        iValue177 = (((Int32)cPCRESET.ID) << 24);
                        iValue178 = 0;
                        iValue179 = 0;
                    }
                    else if (CommandList[row].GetType() == typeof(ctlCommandPC_RST_SP))
                    {
                        ctlCommandPC_RST_SP cPCRSTSP = (ctlCommandPC_RST_SP)CommandList[row];

                        iValue177 = (((Int32)cPCRSTSP.ID) << 24) | ((UInt16)cPCRSTSP.StepNumber);
                        iValue178 = 0;
                        iValue179 = 0;
                    }
                    else if (CommandList[row].GetType() == typeof(ctlCommandSV_OFF))
                    {
                        ctlCommandSV_OFF cSVOFF = (ctlCommandSV_OFF)CommandList[row];

                        iValue177 = (((Int32)cSVOFF.ID) << 24);
                        iValue178 = 0;
                        iValue179 = 0;
                    }
                    else if (CommandList[row].GetType() == typeof(ctlCommandSV_ON))
                    {
                        ctlCommandSV_ON cSVON = (ctlCommandSV_ON)CommandList[row];

                        iValue177 = (((Int32)cSVON.ID) << 24);
                        iValue178 = 0;
                        iValue179 = 0;
                    }
                    else if (CommandList[row].GetType() == typeof(ctlCommandHOME))
                    {
                        ctlCommandHOME cHOME = (ctlCommandHOME)CommandList[row];

                        iValue177 = (((Int32)cHOME.ID) << 24);
                        iValue178 = 0;
                        iValue179 = 0;
                    }
                    else if (CommandList[row].GetType() == typeof(ctlCommandP_RESET))
                    {
                        ctlCommandP_RESET cPRESET = (ctlCommandP_RESET)CommandList[row];

                        iValue177 = (((Int32)cPRESET.ID) << 24);
                        iValue178 = 0;
                        iValue179 = 0;
                    }
                    else if (CommandList[row].GetType() == typeof(ctlCommandAL_RESET))
                    {
                        ctlCommandAL_RESET cALRESET = (ctlCommandAL_RESET)CommandList[row];

                        iValue177 = (((Int32)cALRESET.ID) << 24);
                        iValue178 = 0;
                        iValue179 = 0;
                    }
                    else if (CommandList[row].GetType() == typeof(ctlCommandEND_P))
                    {
                        ctlCommandEND_P cENDP = (ctlCommandEND_P)CommandList[row];

                        iValue177 = (((Int32)cENDP.ID) << 24);
                        iValue178 = 0;
                        iValue179 = 0;
                    }
                    else if (CommandList[row].GetType() == typeof(ctlCommandEND_V))
                    {
                        ctlCommandEND_V cENDV = (ctlCommandEND_V)CommandList[row];

                        iValue177 = (((Int32)cENDV.ID) << 24);
                        iValue178 = 0;
                        iValue179 = 0;
                    }
                    else if (CommandList[row].GetType() == typeof(ctlCommandEND_C))
                    {
                        ctlCommandEND_C cENDC = (ctlCommandEND_C)CommandList[row];

                        iValue177 = (((Int32)cENDC.ID) << 24);
                        iValue178 = 0;
                        iValue179 = 0;
                    }
                    else if (CommandList[row].GetType() == typeof(ctlCommandEND_OFF))
                    {
                        ctlCommandEND_OFF cENDOFF = (ctlCommandEND_OFF)CommandList[row];

                        iValue177 = (((Int32)cENDOFF.ID) << 24);
                        iValue178 = 0;
                        iValue179 = 0;
                    }
                }

                //各ステップのプログラムデータ追加
                BasicProgramOp.Add(new Basic_Program_Code(iValue177, iValue178, iValue179));
            }

            if (pBarForm == null || pBarForm.IsDisposed)
            {
                pBarForm = new DataProgressDialog();
            }

            //プログラムダウンロード中です！！
            pBarForm.Start(UserText.ProgramDown_Now_M, this.Location, this.ClientSize, false);
            pBarForm.Maximum = BasicProgramOp.Count;

            //プログラムをドライバへ書きこむ
            foreach (Basic_Program_Code prog in BasicProgramOp)
            {
                if (IsCancel)
                {
                    break;
                }

                //Program Pointer
                if (!CCommandTx.WriteSvNet(CParamID.ProgramPointer, iStep))
                { 
                    return false; 
                }

                //Program Data0
                if (!CCommandTx.WriteSvNet(CParamID.ProgramData0, prog.ID177_Data))
                {
                    return false;
                }

                //Program Data1
                if (!CCommandTx.WriteSvNet(CParamID.ProgramData1, prog.ID178_Data))
                {
                    return false;
                }

                //Program Data2
                if (!CCommandTx.WriteSvNet(CParamID.ProgramData2, prog.ID179_Data))
                {
                    return false;
                }

                //次のステップ
                iStep++;

                pBarForm.PerformStep();
                //Application.DoEvents();
            }

			//add 20160908 nakayama
			Thread.Sleep(200);

            //プログラムのダウンロードが終了しました。
            pBarForm.Close();

            return true;
        }

        #endregion

        #region プログラムアップロード

        /// <summary>
        /// プログラムアップロード
        /// </summary>
        /// <returns></returns>
        private bool bUpLoad()
        {
            Int32 iValue177 = 0;
            Int32 iValue178 = 0;
            Int32 iValue179 = 0;

            Int32 iProgID = 0;

            //既にプログラムグリッドがある場合、全消去する
            if (GridProgram.Rows.Count > 0)
            {
                GridProgram.Rows.Clear();
            }

            //プログラムアップロード中です！！
            if (pBarForm == null || pBarForm.IsDisposed)
            {
                pBarForm = new DataProgressDialog();
            }

            pBarForm.Start(UserText.ProgramUp_Now_M, this.Location, this.ClientSize, false);
            pBarForm.Maximum = MAX_STEP_COUNT;

            for (Int32 row = 0; row < MAX_STEP_COUNT; row++)
            {
                //Program Pointer設定
                if (!CCommandTx.WriteSvNet(CParamID.ProgramPointer, row)) 
                {
                    return false; 
                }

                //Program Data0取得
                if (!CCommandTx.ReadSvNet(CParamID.ProgramData0, ref iValue177))
                {
                    return false;
                }

                //Program Data1取得
                if (!CCommandTx.ReadSvNet(CParamID.ProgramData1, ref iValue178))
                {
                    return false;
                }

                //Program Data2取得
                if (!CCommandTx.ReadSvNet(CParamID.ProgramData2, ref iValue179))
                {
                    return false;
                }

                //プログラムＩＤ
                iProgID = iValue177 >> 24;

                CommandList[row] = null;
                GridProgram.Rows.Add(1);

                GridProgram[0, row].Value = row.ToString();

                switch (iProgID)
                {
                    case 0x00:  //NOP
                        GridProgram[2, row].Value = CmdNOP;
                        CommandList[row] = new ctlCommandNOP();
                        break;

                    case 0x01:  //MOVE_END
                        GridProgram[2, row].Value = CmdMOVE_END;

                        CommandList[row] = new ctlCommandMOVE_END();
                        ctlCommandMOVE_END cMOVEEND = (ctlCommandMOVE_END)CommandList[row];

                        //FLAG_M1
                        cMOVEEND.FLAG_M1 = (iValue177 & 0x00ff0000) >> 16;

                        //目標速度
                        cMOVEEND.TargetVelocity = (Int16)((iValue177 & 0x0000ffff));

                        //目標位置
                        cMOVEEND.TargetPosition = iValue178;

                        //加速度
                        cMOVEEND.Acceleration = (Int16)((iValue179 & 0xffff0000) >> 16);

                        //減速度
                        cMOVEEND.Deceleration = (Int16)(iValue179 & 0x0000ffff);

                        break;

                    case 0x02:  //MOVE_ST
                        GridProgram[2, row].Value = CmdMOVE_ST;

                        CommandList[row] = new ctlCommandMOVE_ST();
                        ctlCommandMOVE_ST cMOVEST = (ctlCommandMOVE_ST)CommandList[row];

                        //FLAG_M2
                        cMOVEST.FLAG_M2 = (iValue177 & 0x00ff0000) >> 16;

                        //目標速度
                        cMOVEST.TargetVelocity = (Int16)((iValue177 & 0x0000ffff)); ;

                        //目標位置
                        cMOVEST.TargetPostion = iValue178;

                        //加速度
                        cMOVEST.Acceleration = (Int16)((iValue179 & 0xffff0000) >> 16);

                        //減速度
                        cMOVEST.Deceleration = (Int16)(iValue179 & 0x0000ffff);

                        break;

                    case 0x05:  //MOVE_V
                        GridProgram[2, row].Value = CmdMOVE_V;

                        CommandList[row] = new ctlCommandMOVE_V();
                        ctlCommandMOVE_V cMOVEV = (ctlCommandMOVE_V)CommandList[row];

                        //FLAG_M3
                        cMOVEV.FLAG_M3 = (iValue177 & 0x00ff0000) >> 16;

                        //目標速度
                        cMOVEV.TargetVelocity = (Int16)((iValue177 & 0x0000ffff));

                        //加速度
                        cMOVEV.Acceleration = (Int16)((iValue179 & 0xffff0000) >> 16);

                        //減速度
                        cMOVEV.Deceleration = (Int16)(iValue179 & 0x0000ffff);

                        break;

                    case 0x06:  //MOVE_C
                        GridProgram[2, row].Value = CmdMOVE_C;

                        CommandList[row] = new ctlCommandMOVE_C();
                        ctlCommandMOVE_C cMOVEC = (ctlCommandMOVE_C)CommandList[row];

                        //FLAG_M4
                        cMOVEC.FLAG_M4 = (iValue177 & 0x00ff0000) >> 16;

                        //目標電流
                        cMOVEC.TargetCurrrent = (Int16)((iValue177 & 0x0000ffff));

                        break;

                    case 0x0a:  //JMP0
                        GridProgram[2, row].Value = CmdJMP0;

                        CommandList[row] = new ctlCommandJMP0();
                        ctlCommandJMP0 cJMP0 = (ctlCommandJMP0)CommandList[row];

                        //分岐先ステップ
                        cJMP0.DiveStep = (Int16)((iValue177 & 0x0000ffff));

                        //待機時間
                        cJMP0.WaitTime = (Int16)(iValue178 & 0x0000ffff);

                        //繰返し回数
                        cJMP0.RepeatNumber = (Int16)(iValue179 & 0x0000ffff);

                        break;

                    case 0x0b:  //JMP_IN
                        GridProgram[2, row].Value = CmdJMP_IN;

                        CommandList[row] = new ctlCommandJMP_IN();
                        ctlCommandJMP_IN cJMPIN = (ctlCommandJMP_IN)CommandList[row];

                        //MODE_J1
                        cJMPIN.MODE_J1 = (iValue177 & 0x00ff0000) >> 16;

                        //分岐先
                        cJMPIN.DiveStep = (Int16)((iValue177 & 0x0000ffff));

                        //接点入力番号
                        cJMPIN.InputNumber = (Int16)((iValue178 & 0xffff0000) >> 16);

                        //待機時間
                        cJMPIN.WaitTime = (Int16)(iValue178 & 0x0000ffff);

                        break;

                    case 0x0c:  //JMP_IN_OFF
                        GridProgram[2, row].Value = CmdJMP_IN_OFF;

                        CommandList[row] = new ctlCommandJMP_IN_OFF();
                        ctlCommandJMP_IN_OFF cJMPIN_OFF = (ctlCommandJMP_IN_OFF)CommandList[row];

                        //MODE_J1
                        cJMPIN_OFF.MODE_J2 = (iValue177 & 0x00ff0000) >> 16;

                        //分岐先
                        cJMPIN_OFF.DiveStep = (Int16)((iValue177 & 0x0000ffff));

                        //接点入力番号
                        cJMPIN_OFF.InputNumber = (Int16)((iValue178 & 0xffff0000) >> 16);

                        //待機時間
                        cJMPIN_OFF.WaitTime = (Int16)(iValue178 & 0x0000ffff);

                        break;

                    case 0x0d:  //JMP_TRQ
                        GridProgram[2, row].Value = CmdJMP_TRQ;

                        CommandList[row] = new ctlCommandJMP_TRQ();
                        ctlCommandJMP_TRQ cJMP_TRQ = (ctlCommandJMP_TRQ)CommandList[row];

                        //MODE_J1
                        cJMP_TRQ.MODE_J3 = (iValue177 & 0x00ff0000) >> 16;

                        //分岐先
                        cJMP_TRQ.DiveStep = (Int16)((iValue177 & 0x0000ffff));

                        //トルク閾値
                        cJMP_TRQ.CurThreshold = (Int16)((iValue178 & 0xffff0000) >> 16);

                        //待機時間
                        cJMP_TRQ.WaitTime = (Int16)(iValue178 & 0x0000ffff);

                        //分岐論理
                        cJMP_TRQ.DiveLogic = iValue179 >> 24;

                        break;

                    case 0x0e:  //JMP_STS
                        GridProgram[2, row].Value = CmdJMP_STS;

                        CommandList[row] = new ctlCommandJMP_STS();
                        ctlCommandJMP_STS cJMP_STS = (ctlCommandJMP_STS)CommandList[row];

                        //MODE_J1
                        cJMP_STS.MODE_J1 = (iValue177 & 0x00ff0000) >> 16;

                        //分岐先
                        cJMP_STS.DiveStep = (Int16)((iValue177 & 0x0000ffff));

                        //サーボステータスBit
                        cJMP_STS.ServoSTSBit = (UInt32)iValue178;

                        //待機時間
                        cJMP_STS.WaitTime = (Int16)(iValue179 & 0x0000ffff);

                        //分岐論理
                        cJMP_STS.DiveLogic = iValue179 >> 24;

                        break;

                    case 0x14:  //WAIT0
                        GridProgram[2, row].Value = CmdWAIT0;

                        CommandList[row] = new ctlCommandWAIT0();
                        ctlCommandWAIT0 cWAIT0 = (ctlCommandWAIT0)CommandList[row];

                        //待機時間
                        cWAIT0.WaitTime = (Int16)((iValue178 & 0x0000ffff));

                        break;

                    case 0x15:  //PC_RESET
                        GridProgram[2, row].Value = CmdPC_RESET;
                        CommandList[row] = new ctlCommandPC_RESET();
                        break;

                    case 0x16:  //PC_RST_SP
                        GridProgram[2, row].Value = CmdPC_RESET;
                        CommandList[row] = new ctlCommandPC_RST_SP();

                        ctlCommandPC_RST_SP cPC_RST_SP = (ctlCommandPC_RST_SP)CommandList[row];

                        //指定ステップ番号
                        cPC_RST_SP.StepNumber = (Int16)(iValue177 & 0x0000ffff);

                        break;

                    case 0x1e:  //OUT0
                        GridProgram[2, row].Value = CmdOUT0;

                        CommandList[row] = new ctlCommandOUT0();
                        ctlCommandOUT0 cOUT0 = (ctlCommandOUT0)CommandList[row];

                        //接点出力番号
                        cOUT0.OutNumber = (Int16)(iValue177 & 0x0000ffff);

                        //出力論理
                        cOUT0.OutputLogic = (Int16)(iValue178 & 0x0000ffff); ;

                        break;

                    case 0x28:  //SV_OFF
                        GridProgram[2, row].Value = CmdSV_OFF;
                        CommandList[row] = new ctlCommandSV_OFF();
                        break;

                    case 0x29:  //SV_ON
                        GridProgram[2, row].Value = CmdSV_ON;
                        CommandList[row] = new ctlCommandSV_ON();
                        break;

                    case 0x2a:  //HOME
                        GridProgram[2, row].Value = CmdHOME;
                        CommandList[row] = new ctlCommandHOME();
                        break;

                    case 0x2b:  //P_RESET
                        GridProgram[2, row].Value = CmdP_RESET;
                        CommandList[row] = new ctlCommandP_RESET();
                        break;

                    case 0x2c:  //AL_RESET
                        GridProgram[2, row].Value = CmdAL_RESET;
                        CommandList[row] = new ctlCommandAL_RESET();
                        break;

                    case 0x2d:  //END_P
                        GridProgram[2, row].Value = CmdEND_P;
                        CommandList[row] = new ctlCommandEND_P();
                        break;

                    case 0x2e:  //END_V
                        GridProgram[2, row].Value = CmdEND_V;
                        CommandList[row] = new ctlCommandEND_V();
                        break;

                    case 0x2f:  //END_C
                        GridProgram[2, row].Value = CmdEND_C;
                        CommandList[row] = new ctlCommandEND_C();
                        break;

                    case 0x30:  //END_OFF
                        GridProgram[2, row].Value = CmdEND_OFF;
                        CommandList[row] = new ctlCommandEND_OFF();
                        break;

                    case 0x32:  //PARA_W
                        GridProgram[2, row].Value = CmdPARA_W;

                        CommandList[row] = new ctlCommandPARA_W();
                        ctlCommandPARA_W cPARAW = (ctlCommandPARA_W)CommandList[row];

                        //パラメータＩＤ
                        cPARAW.ParameterID = (Int16)(iValue177 & 0x0000ffff);

                        //書込みデータ
                        cPARAW.WriteData = iValue178;

                        break;

                    default: //該当する命令コードがない(NOPとする)
                        GridProgram[2, row].Value = CmdNOP;
                        CommandList[row] = new ctlCommandNOP();
                        break;
                }

                pBarForm.PerformStep();
            }

			//add 20160908 nakayama
			Thread.Sleep(200);

            pBarForm.Close();

            //カレント行を先頭行に変更
            GridProgram.CurrentCell = GridProgram[2, 0];

            AddAUndoList();

            return true;
        }

        #endregion

        #region 共通

        /// <summary>
        /// プログラム運転開始チェック
        /// </summary>
        private void CheckProgramStartButton()
        {
            //開始済みであれば、開始ボタンに戻す
            if (chkPrgStartEnd.Text.Equals(PROG_END))
            {
                chkPrgStartEnd.Text = PROG_START;
                chkPrgStartEnd.Image = Properties.Resources.Start;
            }
        }

        #endregion

        #region プログラム保存

        /// <summary>
        /// プログラム保存
        /// </summary>
        /// <returns></returns>
        private bool bSaveProgram()
        {
            const Int16 ProgramSave = 999; //全プログラム保存

            //サーボＯＦＦする
            if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, 0)) 
            { 
                return false; 
            }

            return CCommandTx.WriteSvNet(CParamID.ProgramPointer, ProgramSave); 

        }

        #endregion

        #region 全プログラムクリア

        /// <summary>
        /// 全プログラムクリア
        /// </summary>
        /// <returns></returns>
        private bool bAllProgramClear()
        {
            const Int32 ProgramClear = 888; //全プログラムクリア設定データ

            return CCommandTx.WriteSvNet(CParamID.ProgramPointer, ProgramClear); 
        }

        #endregion

        #region プログラムファイル読込み

        /// <summary>
        /// プログラムファイル読込み
        /// </summary>
        /// <returns></returns>
        private bool bReadProgramFile()
        {
            StreamReader sr = null;

            Int32 iValue = 0;
            Int16 sValue = 0;

            string[] lines = null;
            string[] cmt_lines = null;

            try
            {
                using (sr = new StreamReader(openFileDialog.FileName, Encoding.GetEncoding("Shift_JIS")))
                {

                    string strBuffer = sr.ReadToEnd();
                    sr.Close();

                    strBuffer = strBuffer.Replace("\r\n", "\n");
                    strBuffer = strBuffer.Replace('\r', '\n');
                    strBuffer = strBuffer.TrimEnd(new char[] { '\n' });

                    string[] w_lines = strBuffer.Split('\n');

                    //保存されているファイルの内容が新仕様か？
                    if (strBuffer.IndexOf(ProgramHeaderTitle) >= 0)
                    {
                        bool bfound = false;
                        int index = 0;

                        foreach (string _title in w_lines)
                        {
                            index++;
                            if (_title == MiddleTitle)
                            {
                                bfound = true;
                                break;
                            }
                        }

                        //ミドルタイトルが見つからない！！
                        if (!bfound)
                        {
                            throw new Exception();
                        }

                        cmt_lines = new string[w_lines.Length - index];
                        lines = new string[cmt_lines.Length];

                        string[] delimiter = { ":", "//", ";" };

                        int idx = 0;
                        for (int i = index; i < w_lines.Length; i++, idx++)
                        {
                            string[] w_temp = w_lines[i].Split(delimiter, StringSplitOptions.None);

                            if (w_temp.Length == 4)
                            {
                                //オブジェクトコード
                                lines[idx] = w_temp[1].Replace("\t", "");

                                //コメント
                                cmt_lines[idx] = w_temp[3];
                            }
                            else
                            {
                                throw new Exception();
                            }

                        }
                    }
                    else
                    {
                        lines = w_lines;
                        cmt_lines = new string[MAX_STEP_COUNT];

                        for (int i = 0; i < cmt_lines.Length; i++)
                        {
                            cmt_lines[i] = string.Empty;
                        }
                    }

                    //128行以上エラー
                    if (lines.Length > MAX_STEP_COUNT)
                    {
                        throw new Exception();
                    }

                    //現在の全グリッド削除
                    GridProgram.Rows.Clear();

                    //読込み処理
                    for (int row = 0; row < lines.Length; row++)
                    {
                        string[] w_line = lines[row].Split(',');

                        //6カラム以下はエラー
                        if (w_line.Length < 6)
                        {
                            throw new Exception();
                        }

                        if (CommandList[row] != null)
                        {
                            CommandList[row] = null;
                        }


                        //読込んだステップ分行を追加する
                        GridProgram.Rows.Add(1);

                        //ステップ番号
                        GridProgram[0, row].Value = row.ToString();

                        switch (w_line[0].Trim())
                        {
                            case "00":  //NOP
                                GridProgram[2, row].Value = CmdNOP;
                                CommandList[row] = new ctlCommandNOP();

                                ctlCommandNOP cNOP = (ctlCommandNOP)CommandList[row];
                                cNOP.Comment = cmt_lines[row];

                                break;

                            case "01":  //MOVE_END
                                GridProgram[2, row].Value = CmdMOVE_END;

                                CommandList[row] = new ctlCommandMOVE_END();
                                ctlCommandMOVE_END cMOVEEND = (ctlCommandMOVE_END)CommandList[row];

                                cMOVEEND.Comment = cmt_lines[row];

                                //FLAG_M1
                                if (Int32.TryParse(w_line[1], out iValue))
                                {
                                    cMOVEEND.FLAG_M1 = iValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                //目標速度
                                if (Int16.TryParse(w_line[2], out sValue))
                                {
                                    cMOVEEND.TargetVelocity = sValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                //目標位置
                                if (Int32.TryParse(w_line[3], out iValue))
                                {
                                    cMOVEEND.TargetPosition = iValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                //加速度
                                if (Int16.TryParse(w_line[4], out sValue))
                                {
                                    cMOVEEND.Acceleration = sValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                //減速度
                                if (Int16.TryParse(w_line[5], out sValue))
                                {
                                    cMOVEEND.Deceleration = sValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                break;

                            case "02":  //MOVE_ST
                                GridProgram[2, row].Value = CmdMOVE_ST;

                                CommandList[row] = new ctlCommandMOVE_ST();
                                ctlCommandMOVE_ST cMOVEST = (ctlCommandMOVE_ST)CommandList[row];

                                cMOVEST.Comment = cmt_lines[row];

                                //FLAG_M2
                                if (Int32.TryParse(w_line[1], out iValue))
                                {
                                    cMOVEST.FLAG_M2 = iValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                //目標速度
                                if (Int16.TryParse(w_line[2], out sValue))
                                {
                                    cMOVEST.TargetVelocity = sValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                //目標位置
                                if (Int32.TryParse(w_line[3], out iValue))
                                {
                                    cMOVEST.TargetPostion = iValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                //加速度
                                if (Int16.TryParse(w_line[4], out sValue))
                                {
                                    cMOVEST.Acceleration = sValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                //減速度
                                if (Int16.TryParse(w_line[5], out sValue))
                                {
                                    cMOVEST.Deceleration = sValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                break;

                            case "05":  //MOVE_V
                                GridProgram[2, row].Value = CmdMOVE_V;

                                CommandList[row] = new ctlCommandMOVE_V();
                                ctlCommandMOVE_V cMOVEV = (ctlCommandMOVE_V)CommandList[row];

                                cMOVEV.Comment = cmt_lines[row];

                                //FLAG_M3
                                if (Int32.TryParse(w_line[1], out iValue))
                                {
                                    cMOVEV.FLAG_M3 = iValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                //目標速度
                                if (Int16.TryParse(w_line[2], out sValue))
                                {
                                    cMOVEV.TargetVelocity = sValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                //加速度
                                if (Int16.TryParse(w_line[3], out sValue))
                                {
                                    cMOVEV.Acceleration = sValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                //減速度
                                if (Int16.TryParse(w_line[4], out sValue))
                                {
                                    cMOVEV.Deceleration = sValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                break;

                            case "06":  //MOVE_C
                                GridProgram[2, row].Value = CmdMOVE_C;

                                CommandList[row] = new ctlCommandMOVE_C();
                                ctlCommandMOVE_C cMOVEC = (ctlCommandMOVE_C)CommandList[row];

                                cMOVEC.Comment = cmt_lines[row];

                                //FLAG_M4
                                if (Int32.TryParse(w_line[1], out iValue))
                                {
                                    cMOVEC.FLAG_M4 = iValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                //目標電流
                                if (Int16.TryParse(w_line[2], out sValue))
                                {
                                    cMOVEC.TargetCurrrent = sValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                break;

                            case "0a":  //JMP0
                                GridProgram[2, row].Value = CmdJMP0;

                                CommandList[row] = new ctlCommandJMP0();
                                ctlCommandJMP0 cJMP0 = (ctlCommandJMP0)CommandList[row];

                                cJMP0.Comment = cmt_lines[row];

                                //分岐先ステップ
                                if (Int16.TryParse(w_line[1], out sValue))
                                {
                                    cJMP0.DiveStep = sValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                //待機時間
                                if (Int16.TryParse(w_line[2], out sValue))
                                {
                                    cJMP0.WaitTime = sValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                //繰返し回数
                                if (Int16.TryParse(w_line[3], out sValue))
                                {
                                    cJMP0.RepeatNumber = sValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                break;

                            case "0b":  //JMP_IN
                                GridProgram[2, row].Value = CmdJMP_IN;

                                CommandList[row] = new ctlCommandJMP_IN();
                                ctlCommandJMP_IN cJMPIN = (ctlCommandJMP_IN)CommandList[row];

                                cJMPIN.Comment = cmt_lines[row];

                                //MODE_J1
                                if (Int32.TryParse(w_line[1], out iValue))
                                {
                                    cJMPIN.MODE_J1 = iValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                //分岐先
                                if (Int16.TryParse(w_line[2], out sValue))
                                {
                                    cJMPIN.DiveStep = sValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                //接点入力番号
                                if (Int16.TryParse(w_line[3], out sValue))
                                {
                                    cJMPIN.InputNumber = sValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                //待機時間
                                if (Int16.TryParse(w_line[4], out sValue))
                                {
                                    cJMPIN.WaitTime = sValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                break;

                            case "0c":  //JMP_IN_OFF
                                GridProgram[2, row].Value = CmdJMP_IN_OFF;

                                CommandList[row] = new ctlCommandJMP_IN_OFF();
                                ctlCommandJMP_IN_OFF cJMPIN_OFF = (ctlCommandJMP_IN_OFF)CommandList[row];

                                cJMPIN_OFF.Comment = cmt_lines[row];

                                //MODE_J1
                                if (Int32.TryParse(w_line[1], out iValue))
                                {
                                    cJMPIN_OFF.MODE_J2 = iValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                //分岐先
                                if (Int16.TryParse(w_line[2], out sValue))
                                {
                                    cJMPIN_OFF.DiveStep = sValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                //接点入力番号
                                if (Int16.TryParse(w_line[3], out sValue))
                                {
                                    cJMPIN_OFF.InputNumber = sValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                //待機時間
                                if (Int16.TryParse(w_line[4], out sValue))
                                {
                                    cJMPIN_OFF.WaitTime = sValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                break;

                            case "0d":  //JMP_TRQ
                                GridProgram[2, row].Value = CmdJMP_TRQ;

                                CommandList[row] = new ctlCommandJMP_TRQ();
                                ctlCommandJMP_TRQ cJMPTRQ = (ctlCommandJMP_TRQ)CommandList[row];

                                cJMPTRQ.Comment = cmt_lines[row];

                                //MODE_J3
                                if (Int32.TryParse(w_line[1], out iValue))
                                {
                                    cJMPTRQ.MODE_J3 = iValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                //分岐先
                                if (Int16.TryParse(w_line[2], out sValue))
                                {
                                    cJMPTRQ.DiveStep = sValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                //トルク閾値
                                if (Int16.TryParse(w_line[3], out sValue))
                                {
                                    cJMPTRQ.CurThreshold = sValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                //待機時間
                                if (Int16.TryParse(w_line[4], out sValue))
                                {
                                    cJMPTRQ.WaitTime = sValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                //分岐論理
                                if (Int32.TryParse(w_line[5], out iValue))
                                {
                                    cJMPTRQ.DiveLogic = iValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                break;

                            case "0e":  //JMP_STS
                                GridProgram[2, row].Value = CmdJMP_STS;

                                CommandList[row] = new ctlCommandJMP_STS();
                                ctlCommandJMP_STS cJMPSTS = (ctlCommandJMP_STS)CommandList[row];

                                cJMPSTS.Comment = cmt_lines[row];

                                //MODE_J1
                                if (Int32.TryParse(w_line[1], out iValue))
                                {
                                    cJMPSTS.MODE_J1 = iValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                //分岐先
                                if (Int16.TryParse(w_line[2], out sValue))
                                {
                                    cJMPSTS.DiveStep = sValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                //サーボステータス判断Bit
                                if (w_line[3].Length == 10)
                                {
                                    if (w_line[3].Substring(0, 2) == "0x")
                                    {
                                        w_line[3] = w_line[3].Substring(2, 8);
                                    }
                                    else
                                    {
                                        //プログラムファイル書式エラー
                                        throw new Exception();
                                    }
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                cJMPSTS.ServoSTSBit = Convert.ToUInt32(w_line[3], 16);


                                //待機時間
                                if (Int16.TryParse(w_line[4], out sValue))
                                {
                                    cJMPSTS.WaitTime = sValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                //分岐論理
                                if (Int32.TryParse(w_line[5], out iValue))
                                {
                                    cJMPSTS.DiveLogic = iValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                break;

                            case "14":  //WAIT0
                                GridProgram[2, row].Value = CmdWAIT0;

                                CommandList[row] = new ctlCommandWAIT0();
                                ctlCommandWAIT0 cWAIT0 = (ctlCommandWAIT0)CommandList[row];

                                cWAIT0.Comment = cmt_lines[row];

                                //待機時間
                                if (Int16.TryParse(w_line[1], out sValue))
                                {
                                    cWAIT0.WaitTime = sValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                break;

                            case "15":  //PC_RESET
                                GridProgram[2, row].Value = CmdPC_RESET;
                                CommandList[row] = new ctlCommandPC_RESET();

                                ctlCommandPC_RESET cPC_RESET = (ctlCommandPC_RESET)CommandList[row];
                                cPC_RESET.Comment = cmt_lines[row];

                                break;

                            case "16":  //PC_RST_SP
                                GridProgram[2, row].Value = CmdPC_RST_SP;
                                CommandList[row] = new ctlCommandPC_RST_SP();

                                ctlCommandPC_RST_SP cPCRSTSP = (ctlCommandPC_RST_SP)CommandList[row];

                                cPCRSTSP.Comment = cmt_lines[row];

                                //指定ステップ
                                if (Int16.TryParse(w_line[1], out sValue))
                                {
                                    cPCRSTSP.StepNumber = sValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                break;

                            case "1e":  //OUT0
                                GridProgram[2, row].Value = CmdOUT0;

                                CommandList[row] = new ctlCommandOUT0();
                                ctlCommandOUT0 cOUT0 = (ctlCommandOUT0)CommandList[row];

                                cOUT0.Comment = cmt_lines[row];

                                //接点出力番号
                                if (Int16.TryParse(w_line[1], out sValue))
                                {
                                    cOUT0.OutNumber = sValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                //出力論理
                                if (Int16.TryParse(w_line[2], out sValue))
                                {
                                    cOUT0.OutputLogic = sValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                break;

                            case "28":  //SV_OFF
                                GridProgram[2, row].Value = CmdSV_OFF;
                                CommandList[row] = new ctlCommandSV_OFF();

                                ctlCommandSV_OFF cSVOFF = (ctlCommandSV_OFF)CommandList[row];
                                cSVOFF.Comment = cmt_lines[row];

                                break;

                            case "29":  //SV_ON
                                GridProgram[2, row].Value = CmdSV_ON;
                                CommandList[row] = new ctlCommandSV_ON();

                                ctlCommandSV_ON cSVON = (ctlCommandSV_ON)CommandList[row];
                                cSVON.Comment = cmt_lines[row];

                                break;

                            case "2a":  //HOME
                                GridProgram[2, row].Value = CmdHOME;
                                CommandList[row] = new ctlCommandHOME();

                                ctlCommandHOME cHOME = (ctlCommandHOME)CommandList[row];
                                cHOME.Comment = cmt_lines[row];

                                break;

                            case "2b":  //P_RESET
                                GridProgram[2, row].Value = CmdP_RESET;
                                CommandList[row] = new ctlCommandP_RESET();

                                ctlCommandP_RESET cP_RESET = (ctlCommandP_RESET)CommandList[row];
                                cP_RESET.Comment = cmt_lines[row];

                                break;

                            case "2c":  //AL_RESET
                                GridProgram[2, row].Value = CmdAL_RESET;
                                CommandList[row] = new ctlCommandAL_RESET();

                                ctlCommandAL_RESET cAL_RESET = (ctlCommandAL_RESET)CommandList[row];
                                cAL_RESET.Comment = cmt_lines[row];

                                break;

                            case "2d":  //END_P
                                GridProgram[2, row].Value = CmdEND_P;
                                CommandList[row] = new ctlCommandEND_P();

                                ctlCommandEND_P cENDP = (ctlCommandEND_P)CommandList[row];
                                cENDP.Comment = cmt_lines[row];

                                break;

                            case "2e":  //END_V
                                GridProgram[2, row].Value = CmdEND_V;
                                CommandList[row] = new ctlCommandEND_V();

                                ctlCommandEND_V cENDV = (ctlCommandEND_V)CommandList[row];
                                cENDV.Comment = cmt_lines[row];

                                break;

                            case "2f":  //END_C
                                GridProgram[2, row].Value = CmdEND_C;
                                CommandList[row] = new ctlCommandEND_C();

                                ctlCommandEND_C cENDC = (ctlCommandEND_C)CommandList[row];
                                cENDC.Comment = cmt_lines[row];

                                break;

                            case "30":  //END_OFF
                                GridProgram[2, row].Value = CmdEND_OFF;
                                CommandList[row] = new ctlCommandEND_OFF();

                                ctlCommandEND_OFF cENDOFF = (ctlCommandEND_OFF)CommandList[row];
                                cENDOFF.Comment = cmt_lines[row];

                                break;

                            case "32":  //PARA_W
                                GridProgram[2, row].Value = CmdPARA_W;

                                CommandList[row] = new ctlCommandPARA_W();
                                ctlCommandPARA_W cPARAW = (ctlCommandPARA_W)CommandList[row];

                                cPARAW.Comment = cmt_lines[row];

                                //パラメータＩＤ
                                if (Int16.TryParse(w_line[1], out sValue))
                                {
                                    cPARAW.ParameterID = sValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }

                                //書込みデータ
                                if (Int32.TryParse(w_line[2], out iValue))
                                {
                                    cPARAW.WriteData = iValue;
                                }
                                else
                                {
                                    //プログラムファイル書式エラー
                                    throw new Exception();
                                }
                                break;

                            default: //該当する命令コードがない(NOPとする)
                                GridProgram[2, row].Value = CmdNOP;
                                CommandList[row] = new ctlCommandNOP();
                                break;
                        }

                        //コメント行
                        GridProgram[3, row].Value = cmt_lines[row];
                    }

                    //カレント行を先頭行に変更
                    GridProgram.CurrentCell = GridProgram[2, 0];

                    AddAUndoList();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region プログラムファイル書込み

        /// <summary>
        /// プログラムファイル書込み
        /// </summary>
        /// <returns></returns>
        private bool bSaveProgramFile()
        {
            int max = 0;

            string objbuff = "";
            string Mnemonicbuff = "";

            StreamWriter sw = null;

            try
            {
                using (sw = new StreamWriter(saveFileDialog.FileName, false, Encoding.GetEncoding("Shift_JIS")))
                {

                    StringBuilder[] arryobjbuff = new StringBuilder[GridProgram.Rows.Count];
                    string[] arryMnemonicbuff = new string[GridProgram.Rows.Count];

                    //プログラムヘッダ作成
                    sw.WriteLine(";***************************************************");
                    sw.WriteLine(";  " + ProgramHeaderTitle);
                    sw.WriteLine(";");
                    sw.WriteLine(";  Filename : " + Path.GetFileName(saveFileDialog.FileName));
                    sw.WriteLine(";  Date     : " + DateTime.Now.ToString());
                    sw.WriteLine(";");
                    sw.WriteLine(";  Copyright (C) 2014 Tamagawa Seiki.Co.,Ltd");
                    sw.WriteLine(";***************************************************");

                    //プログラム及びオブジェクトリスト書込み処理
                    for (int row = 0; row < GridProgram.Rows.Count; row++)
                    {
                        if (CommandList[row].GetType() == typeof(ctlCommandMOVE_END))
                        {
                            ctlCommandMOVE_END cMOVEEND = (ctlCommandMOVE_END)CommandList[row];
                            objbuff = cMOVEEND.ID.ToString("x2") + "," +
                                      cMOVEEND.FLAG_M1.ToString() + "," +
                                      cMOVEEND.TargetVelocity.ToString() + "," +
                                      cMOVEEND.TargetPosition.ToString() + "," +
                                      cMOVEEND.Acceleration.ToString() + "," +
                                      cMOVEEND.Deceleration.ToString();

                            Mnemonicbuff = cMOVEEND.MnemonicCode;
                        }
                        else if (CommandList[row].GetType() == typeof(ctlCommandMOVE_ST))
                        {
                            ctlCommandMOVE_ST cMOVEST = (ctlCommandMOVE_ST)CommandList[row];

                            objbuff = cMOVEST.ID.ToString("x2") + "," +
                                      cMOVEST.FLAG_M2.ToString() + "," +
                                      cMOVEST.TargetVelocity.ToString() + "," +
                                      cMOVEST.TargetPostion.ToString() + "," +
                                      cMOVEST.Acceleration.ToString() + "," +
                                      cMOVEST.Deceleration.ToString();

                            Mnemonicbuff = cMOVEST.MnemonicCode;
                        }
                        else if (CommandList[row].GetType() == typeof(ctlCommandMOVE_V))
                        {
                            ctlCommandMOVE_V cMOVEV = (ctlCommandMOVE_V)CommandList[row];

                            objbuff = cMOVEV.ID.ToString("x2") + "," +
                                      cMOVEV.FLAG_M3.ToString() + "," +
                                      cMOVEV.TargetVelocity.ToString() + "," +
                                      cMOVEV.Acceleration.ToString() + "," +
                                      cMOVEV.Deceleration.ToString() + ",,";

                            Mnemonicbuff = cMOVEV.MnemonicCode;
                        }
                        else if (CommandList[row].GetType() == typeof(ctlCommandMOVE_C))
                        {
                            ctlCommandMOVE_C cMOVEC = (ctlCommandMOVE_C)CommandList[row];

                            objbuff = cMOVEC.ID.ToString("x2") + "," +
                                      cMOVEC.FLAG_M4.ToString() + "," +
                                      cMOVEC.TargetCurrrent.ToString() + ",,,,";

                            Mnemonicbuff = cMOVEC.MnemonicCode;
                        }
                        else if (CommandList[row].GetType() == typeof(ctlCommandJMP0))
                        {
                            ctlCommandJMP0 cJMP0 = (ctlCommandJMP0)CommandList[row];

                            objbuff = cJMP0.ID.ToString("x2") + "," +
                                      cJMP0.DiveStep.ToString() + "," +
                                      cJMP0.WaitTime.ToString() + "," +
                                      cJMP0.RepeatNumber.ToString() + ",,";

                            Mnemonicbuff = cJMP0.MnemonicCode;
                        }
                        else if (CommandList[row].GetType() == typeof(ctlCommandJMP_IN))
                        {
                            ctlCommandJMP_IN cJMPIN = (ctlCommandJMP_IN)CommandList[row];

                            objbuff = cJMPIN.ID.ToString("x2") + "," +
                                      cJMPIN.MODE_J1.ToString() + "," +
                                      cJMPIN.DiveStep.ToString() + "," +
                                      cJMPIN.InputNumber.ToString() + "," +
                                      cJMPIN.WaitTime.ToString() + ",";

                            Mnemonicbuff = cJMPIN.MnemonicCode;
                        }
                        else if (CommandList[row].GetType() == typeof(ctlCommandJMP_IN_OFF))
                        {
                            ctlCommandJMP_IN_OFF cJMPINOFF = (ctlCommandJMP_IN_OFF)CommandList[row];

                            objbuff = cJMPINOFF.ID.ToString("x2") + "," +
                                      cJMPINOFF.MODE_J2.ToString() + "," +
                                      cJMPINOFF.DiveStep.ToString() + "," +
                                      cJMPINOFF.InputNumber.ToString() + "," +
                                      cJMPINOFF.WaitTime.ToString() + ",";

                            Mnemonicbuff = cJMPINOFF.MnemonicCode;
                        }
                        else if (CommandList[row].GetType() == typeof(ctlCommandJMP_TRQ))
                        {
                            ctlCommandJMP_TRQ cJMPTRQ = (ctlCommandJMP_TRQ)CommandList[row];

                            objbuff = cJMPTRQ.ID.ToString("x2") + "," +
                                      cJMPTRQ.MODE_J3.ToString() + "," +
                                      cJMPTRQ.DiveStep.ToString() + "," +
                                      cJMPTRQ.CurThreshold.ToString() + "," +
                                      cJMPTRQ.WaitTime.ToString() + "," +
                                      cJMPTRQ.DiveLogic.ToString();

                            Mnemonicbuff = cJMPTRQ.MnemonicCode;
                        }
                        else if (CommandList[row].GetType() == typeof(ctlCommandJMP_STS))
                        {
                            ctlCommandJMP_STS cJMPSTS = (ctlCommandJMP_STS)CommandList[row];

                            objbuff = cJMPSTS.ID.ToString("x2") + "," +
                                      cJMPSTS.MODE_J1.ToString() + "," +
                                      cJMPSTS.DiveStep.ToString() + "," +
                                      "0x" + cJMPSTS.ServoSTSBit.ToString("X8") + "," +
                                      cJMPSTS.WaitTime.ToString() + "," +
                                      cJMPSTS.DiveLogic.ToString();

                            Mnemonicbuff = cJMPSTS.MnemonicCode;
                        }
                        else if (CommandList[row].GetType() == typeof(ctlCommandWAIT0))
                        {
                            ctlCommandWAIT0 cWAIT0 = (ctlCommandWAIT0)CommandList[row];

                            objbuff = cWAIT0.ID.ToString("x2") + "," +
                                      cWAIT0.WaitTime.ToString() + ",,,,";

                            Mnemonicbuff = cWAIT0.MnemonicCode;
                        }
                        else if (CommandList[row].GetType() == typeof(ctlCommandOUT0))
                        {
                            ctlCommandOUT0 cOUT0 = (ctlCommandOUT0)CommandList[row];

                            objbuff = cOUT0.ID.ToString("x2") + "," +
                                      cOUT0.OutNumber.ToString() + "," +
                                      cOUT0.OutputLogic.ToString() + ",,,";

                            Mnemonicbuff = cOUT0.MnemonicCode;
                        }
                        else if (CommandList[row].GetType() == typeof(ctlCommandPARA_W))
                        {
                            ctlCommandPARA_W cPARAW = (ctlCommandPARA_W)CommandList[row];

                            objbuff = cPARAW.ID.ToString("x2") + "," +
                                      cPARAW.ParameterID.ToString() + "," +
                                      cPARAW.WriteData.ToString() + ",,,";

                            Mnemonicbuff = cPARAW.MnemonicCode;
                        }
                        else if (CommandList[row].GetType() == typeof(ctlCommandPC_RST_SP))
                        {
                            ctlCommandPC_RST_SP cPCRSTSP = (ctlCommandPC_RST_SP)CommandList[row];

                            objbuff = cPCRSTSP.ID.ToString("x2") + "," +
                                      cPCRSTSP.StepNumber.ToString() + ",,,,";

                            Mnemonicbuff = cPCRSTSP.MnemonicCode;
                        }
                        else
                        {
                            //その他の命令（プログラムデータなし）
                            if (CommandList[row].GetType() == typeof(ctlCommandNOP))
                            {
                                ctlCommandNOP cNOP = (ctlCommandNOP)CommandList[row];
                                objbuff = cNOP.ID.ToString("x2") + ",,,,,";

                                Mnemonicbuff = cNOP.MnemonicCode;
                            }
                            else if (CommandList[row].GetType() == typeof(ctlCommandPC_RESET))
                            {
                                ctlCommandPC_RESET cPCRESET = (ctlCommandPC_RESET)CommandList[row];
                                objbuff = cPCRESET.ID.ToString("x2") + ",,,,,";

                                Mnemonicbuff = cPCRESET.MnemonicCode;
                            }
                            else if (CommandList[row].GetType() == typeof(ctlCommandSV_OFF))
                            {
                                ctlCommandSV_OFF cSVOFF = (ctlCommandSV_OFF)CommandList[row];
                                objbuff = cSVOFF.ID.ToString("x2") + ",,,,,";

                                Mnemonicbuff = cSVOFF.MnemonicCode;
                            }
                            else if (CommandList[row].GetType() == typeof(ctlCommandSV_ON))
                            {
                                ctlCommandSV_ON cSVON = (ctlCommandSV_ON)CommandList[row];
                                objbuff = cSVON.ID.ToString("x2") + ",,,,,";

                                Mnemonicbuff = cSVON.MnemonicCode;
                            }
                            else if (CommandList[row].GetType() == typeof(ctlCommandHOME))
                            {
                                ctlCommandHOME cHOME = (ctlCommandHOME)CommandList[row];
                                objbuff = cHOME.ID.ToString("x2") + ",,,,,";

                                Mnemonicbuff = cHOME.MnemonicCode;
                            }
                            else if (CommandList[row].GetType() == typeof(ctlCommandP_RESET))
                            {
                                ctlCommandP_RESET cPRESET = (ctlCommandP_RESET)CommandList[row];
                                objbuff = cPRESET.ID.ToString("x2") + ",,,,,";

                                Mnemonicbuff = cPRESET.MnemonicCode;
                            }
                            else if (CommandList[row].GetType() == typeof(ctlCommandAL_RESET))
                            {
                                ctlCommandAL_RESET cALRESET = (ctlCommandAL_RESET)CommandList[row];
                                objbuff = cALRESET.ID.ToString("x2") + ",,,,,";

                                Mnemonicbuff = cALRESET.MnemonicCode;
                            }
                            else if (CommandList[row].GetType() == typeof(ctlCommandEND_P))
                            {
                                ctlCommandEND_P cENDP = (ctlCommandEND_P)CommandList[row];
                                objbuff = cENDP.ID.ToString("x2") + ",,,,,";

                                Mnemonicbuff = cENDP.MnemonicCode;
                            }
                            else if (CommandList[row].GetType() == typeof(ctlCommandEND_V))
                            {
                                ctlCommandEND_V cENDV = (ctlCommandEND_V)CommandList[row];
                                objbuff = cENDV.ID.ToString("x2") + ",,,,,";

                                Mnemonicbuff = cENDV.MnemonicCode;
                            }
                            else if (CommandList[row].GetType() == typeof(ctlCommandEND_C))
                            {
                                ctlCommandEND_C cENDC = (ctlCommandEND_C)CommandList[row];
                                objbuff = cENDC.ID.ToString("x2") + ",,,,,";

                                Mnemonicbuff = cENDC.MnemonicCode;
                            }
                            else if (CommandList[row].GetType() == typeof(ctlCommandEND_OFF))
                            {
                                ctlCommandEND_OFF cENDOFF = (ctlCommandEND_OFF)CommandList[row];
                                objbuff = cENDOFF.ID.ToString("x2") + ",,,,,";

                                Mnemonicbuff = cENDOFF.MnemonicCode;
                            }
                        }

                        //ステップ番号追加
                        objbuff = row.ToString("0000 : ") + objbuff;

                        if (objbuff.Length > max)
                        {
                            max = objbuff.Length;
                        }

                        arryobjbuff[row] = new StringBuilder(objbuff);
                        arryMnemonicbuff[row] = Mnemonicbuff;
                    }

                    //オブジェクトリスト作成
                    sw.WriteLine("");

                    ////********** Object List & Mnemonic List **********//
                    sw.WriteLine(MiddleTitle);

                    bool bsel = false;

                    double d_line = Math.Round((double)((double)max / 4), MidpointRounding.AwayFromZero);
                    int i_mod = (int)d_line % 4;
                    int max_value = 0;

                    if (i_mod > 0)
                    {
                        max_value = max + i_mod + 8;
                        bsel = true;
                    }
                    else
                    {
                        max_value = max + 8;
                    }

                    for (int step = 0; step < arryobjbuff.Length; step++)
                    {
                        int line = (max_value - arryobjbuff[step].Length) / 4;

                        if (!bsel)
                        {
                            if (line == 2 && (max - arryobjbuff[step].Length) == 0)
                            {
                                line = 1;
                            }
                        }

                        string wrtbuff = arryobjbuff[step].Insert(arryobjbuff[step].Length, "\t", line).ToString() +
                                         "// " + arryMnemonicbuff[step];

                        sw.WriteLine(wrtbuff);
                    }

                    sw.Close();

                    return true;
                }
            }
            catch
            {
                sw.Close();
                return false;
            }
        }

        #endregion

        #region グリッド関連

        /// <summary>
        /// 選択行取得
        /// </summary>
        /// <returns></returns>
        private bool GetSelectedRows(ref int _Start, ref int _End)
        {
            bool bret = false;

            int tmp1 = 0;
            int tmp2 = 0;

            int cnt = GridProgram.SelectedRows.Count;

            if (cnt > 0)
            {
                //選択されて行を取得
                DataGridViewRow s_temp1 = GridProgram.SelectedRows[0];
                tmp1 = s_temp1.Index;

                DataGridViewRow s_temp2 = GridProgram.SelectedRows[cnt - 1];
                tmp2 = s_temp2.Index;

                if (tmp1 >= tmp2)
                {
                    _Start = tmp2;
                    _End = tmp1;
                }
                else
                {
                    _Start = tmp1;
                    _End = tmp2;
                }

                bret = true;
            }

            return bret;
        }

        /// <summary>
        /// 現在ステップ移動
        /// </summary>
        /// <param name="_id"></param>
        private void MoveProgramStep(int _id)
        {
            int row = 0;

            if (GridProgram.CurrentCell != null)
            {
                //指定されたセルにカーソルを設定
                GridProgram.ClearSelection();
                GridProgram.BeginEdit(true);

				//16行目を固定スクロール    
				//row = (_id < 15) ? 0 : (_id - 15);
				//7行目を固定スクロール    
				row = (_id < 7) ? 0 : (_id - 7);

                //現在、指定された行を選択及びスクロール
                GridProgram.FirstDisplayedScrollingRowIndex = row;

                //選択されたプログラムのヘルプ表示
                ViewCommandHelp(_id, GridProgram[2, _id].Value.ToString());
            }
        }

        #endregion

        #region 命令ヘルプ表示

        /// <summary>
        /// 命令ヘルプ表示
        /// </summary>
        /// <param name="_row"></param>
        /// <param name="_cmd"></param>
        private void ViewCommandHelp(int _row, string _cmd)
        {
		    string strHelp = "";

            switch (_cmd)
            {
                case CmdNOP:
                    ctlCommandNOP cNOP = new ctlCommandNOP();
                    strHelp = cNOP.Help;
			        break;

                case CmdMOVE_END:
                    ctlCommandMOVE_END cMOVEEND = new ctlCommandMOVE_END();
                    strHelp = cMOVEEND.Help;
                    break;

                case CmdMOVE_ST:
                    ctlCommandMOVE_ST cMOVEST = new ctlCommandMOVE_ST();
                    strHelp = cMOVEST.Help;
                    break;

                case CmdMOVE_V:
                    ctlCommandMOVE_V cMOVEV = new ctlCommandMOVE_V();
                    strHelp = cMOVEV.Help;
                    break;

                case CmdMOVE_C:
                    ctlCommandMOVE_C cMOVEC = new ctlCommandMOVE_C();
                    strHelp = cMOVEC.Help;
                    break;

                case CmdJMP0:
                    ctlCommandJMP0 cJMP0 = new ctlCommandJMP0();
                    strHelp = cJMP0.Help;
                    break;

                case CmdJMP_IN:
                    ctlCommandJMP_IN cJMPIN = new ctlCommandJMP_IN();
                    strHelp = cJMPIN.Help;
                    break;

                case CmdJMP_IN_OFF:
                    ctlCommandJMP_IN_OFF cJMPINOFF = new ctlCommandJMP_IN_OFF();
                    strHelp = cJMPINOFF.Help;
                    break;

                case CmdJMP_TRQ:
                    ctlCommandJMP_TRQ cJMPTRQ = new ctlCommandJMP_TRQ();
                    strHelp = cJMPTRQ.Help;
                    break;

                case CmdJMP_STS:
                    ctlCommandJMP_STS cJMPSTS = new ctlCommandJMP_STS();
                    strHelp = cJMPSTS.Help;
                    break;

                case CmdPC_RST_SP:
                    ctlCommandPC_RST_SP cPCRSTSP = new ctlCommandPC_RST_SP();
                    strHelp = cPCRSTSP.Help;
                    break;

                case CmdWAIT0:
                    ctlCommandWAIT0 cWAIT0 = new ctlCommandWAIT0();
                    strHelp = cWAIT0.Help;
                    break;

                case CmdPC_RESET:
                    ctlCommandPC_RESET cPCRESET = new ctlCommandPC_RESET();
                    strHelp = cPCRESET.Help;
                    break;

                case CmdOUT0:
                    ctlCommandOUT0 cOUT0 = new ctlCommandOUT0();
                    strHelp = cOUT0.Help;
                    break;

                case CmdSV_OFF:
                    ctlCommandSV_OFF cSVOFF = new ctlCommandSV_OFF();
                    strHelp = cSVOFF.Help;
                    break;

                case CmdSV_ON:
                    ctlCommandSV_ON cSVON = new ctlCommandSV_ON();
                    strHelp = cSVON.Help;
                    break;

                case CmdHOME:
                    ctlCommandHOME cHOME = new ctlCommandHOME();
                    strHelp = cHOME.Help;
                    break;

                case CmdP_RESET:
                    ctlCommandP_RESET cPRESET = new ctlCommandP_RESET();
                    strHelp = cPRESET.Help;
                    break;

                case CmdAL_RESET:
                    ctlCommandAL_RESET cALRESET = new ctlCommandAL_RESET();
                    strHelp = cALRESET.Help;
                    break;

                case CmdEND_P:
                    ctlCommandEND_P cENDP = new ctlCommandEND_P();
                    strHelp = cENDP.Help;
                    break;

                case CmdEND_V:
                    ctlCommandEND_V cENDV = new ctlCommandEND_V();
                    strHelp = cENDV.Help;
                    break;

                case CmdEND_C:
                    ctlCommandEND_C cENDC = new ctlCommandEND_C();
                    strHelp = cENDC.Help;
                    break;

                case CmdEND_OFF:
                    ctlCommandEND_OFF cENDOFF = new ctlCommandEND_OFF();
                    strHelp = cENDOFF.Help;
                    break;

                case CmdPARA_W:
                    ctlCommandPARA_W cPARAW = new ctlCommandPARA_W();
                    strHelp = cPARAW.Help;
                    break;
            }

            //ヘルプ表示
			//del 20160907 nakayama
			//richHelpText.Text = strHelp;

			//add 20160907 nakayama
			if (helpForm != null)
			{
				helpForm.HelpText = strHelp;
				helpForm.CmdText = _cmd;
			}

            panelProgData.Controls.Clear();
            Control con = (Control)CommandList[_row];

			//del 20160907 nakayama
			//foreach (Control _c in CommandList)
			//{
			//    _c.Size = new Size(482, 260);
			//}

            panelProgData.Controls.Add(con);

			con.Dock = DockStyle.Fill;	//add 20160907 nakayama
	
        }

        #endregion

        #region Undoリスト作成

        private void AddAUndoList()
        {
            //やり直し後、途中で追加されたか？
            if (IsUndo && BkUndoListCnt <= UndoList.Count)
            {
                if (UndoList.Count > 0)
                {
                    UndoList.RemoveAt(UndoList.Count - 1);
                    CurrentStep.RemoveAt(CurrentStep.Count - 1);

                    ActUndoPtr = UndoList.Count;

                    IsUndo = false;
                }
            }

            if (UndoList.Count >= MAX_UNDO_COUNT)
            {
                //Undoリストを超えている場合、一番古い情報を削除後追加する
                UndoList.RemoveAt(0);
                CurrentStep.RemoveAt(0);
            }

            if (UndoCommandList != null)
            {
                UndoCommandList = null;
            }

            //編集中のステップ位置を保存
            CurrentStep.Add(GridProgram.CurrentCell.RowIndex);

            UndoCommandList = new object[MAX_STEP_COUNT];
            CommandList.CopyTo(UndoCommandList, 0);

            UndoList.Add(UndoCommandList);

            //まだ、Undo操作がされていない！！
            if (IsEdit)
            {
                ActUndoPtr = UndoList.Count - 1;
            }

            BkUndoListCnt = UndoList.Count;
        }

        #endregion

        #region プログラムグリッド再描画

        /// <summary>
        /// プログラムグリッド再描画
        /// </summary>
        /// <param name="_mix"></param>
        /// <param name="_max"></param>
        private void ReDrawProgarmGridView(int _mix, int _max)
        {
            //一旦、CellValueChangedを外す
            GridProgram.CellValueChanged -= new DataGridViewCellEventHandler(GridProgram_CellValueChanged);

            for (int i = _mix; i <= _max; i++)
            {
                if (CommandList[i].GetType() == typeof(ctlCommandMOVE_END))
                {
                    GridProgram[2, i].Value = CmdMOVE_END;

                    ctlCommandMOVE_END cMOVEEND = (ctlCommandMOVE_END)CommandList[i];
                    GridProgram[3, i].Value = cMOVEEND.Comment;
                }
                else if (CommandList[i].GetType() == typeof(ctlCommandMOVE_ST))
                {
                    GridProgram[2, i].Value = CmdMOVE_ST;

                    ctlCommandMOVE_ST cMOVEST = (ctlCommandMOVE_ST)CommandList[i];
                    GridProgram[3, i].Value = cMOVEST.Comment;
                }
                else if (CommandList[i].GetType() == typeof(ctlCommandMOVE_V))
                {
                    GridProgram[2, i].Value = CmdMOVE_V;

                    ctlCommandMOVE_V cMOVEV = (ctlCommandMOVE_V)CommandList[i];
                    GridProgram[3, i].Value = cMOVEV.Comment;
                }
                else if (CommandList[i].GetType() == typeof(ctlCommandMOVE_C))
                {
                    GridProgram[2, i].Value = CmdMOVE_C;

                    ctlCommandMOVE_C cMOVEC = (ctlCommandMOVE_C)CommandList[i];
                    GridProgram[3, i].Value = cMOVEC.Comment;
                }
                else if (CommandList[i].GetType() == typeof(ctlCommandJMP0))
                {
                    GridProgram[2, i].Value = CmdJMP0;

                    ctlCommandJMP0 cJMP0 = (ctlCommandJMP0)CommandList[i];
                    GridProgram[3, i].Value = cJMP0.Comment;
                }
                else if (CommandList[i].GetType() == typeof(ctlCommandJMP_IN))
                {
                    GridProgram[2, i].Value = CmdJMP_IN;

                    ctlCommandJMP_IN cJMPIN = (ctlCommandJMP_IN)CommandList[i];
                    GridProgram[3, i].Value = cJMPIN.Comment;
                }
                else if (CommandList[i].GetType() == typeof(ctlCommandJMP_IN_OFF))
                {
                    GridProgram[2, i].Value = CmdJMP_IN_OFF;

                    ctlCommandJMP_IN_OFF cJMPIN_OFF = (ctlCommandJMP_IN_OFF)CommandList[i];
                    GridProgram[3, i].Value = cJMPIN_OFF.Comment;
                }
                else if (CommandList[i].GetType() == typeof(ctlCommandJMP_TRQ))
                {
                    GridProgram[2, i].Value = CmdJMP_TRQ;

                    ctlCommandJMP_TRQ cJMP_TRQ = (ctlCommandJMP_TRQ)CommandList[i];
                    GridProgram[3, i].Value = cJMP_TRQ.Comment;
                }
                else if (CommandList[i].GetType() == typeof(ctlCommandJMP_STS))
                {
                    GridProgram[2, i].Value = CmdJMP_STS;

                    ctlCommandJMP_STS cJMP_STS = (ctlCommandJMP_STS)CommandList[i];
                    GridProgram[3, i].Value = cJMP_STS.Comment;
                }
                else if (CommandList[i].GetType() == typeof(ctlCommandWAIT0))
                {
                    GridProgram[2, i].Value = CmdWAIT0;

                    ctlCommandWAIT0 cWAIT0 = (ctlCommandWAIT0)CommandList[i];
                    GridProgram[3, i].Value = cWAIT0.Comment;
                }
                else if (CommandList[i].GetType() == typeof(ctlCommandOUT0))
                {
                    GridProgram[2, i].Value = CmdOUT0;

                    ctlCommandOUT0 cOUT0 = (ctlCommandOUT0)CommandList[i];
                    GridProgram[3, i].Value = cOUT0.Comment;
                }
                else if (CommandList[i].GetType() == typeof(ctlCommandPARA_W))
                {
                    GridProgram[2, i].Value = CmdPARA_W;

                    ctlCommandPARA_W cPARAW = (ctlCommandPARA_W)CommandList[i];
                    GridProgram[3, i].Value = cPARAW.Comment;
                }
                else if (CommandList[i].GetType() == typeof(ctlCommandPC_RST_SP))
                {
                    GridProgram[2, i].Value = CmdPC_RST_SP;

                    ctlCommandPC_RST_SP cPCRSTSP = (ctlCommandPC_RST_SP)CommandList[i];
                    GridProgram[3, i].Value = cPCRSTSP.Comment;
                }
                else
                {
                    //その他の命令（プログラムデータなし）
                    if (CommandList[i].GetType() == typeof(ctlCommandNOP))
                    {
                        GridProgram[2, i].Value = CmdNOP;

                        ctlCommandNOP cNOP = (ctlCommandNOP)CommandList[i];
                        GridProgram[3, i].Value = cNOP.Comment;
                    }
                    else if (CommandList[i].GetType() == typeof(ctlCommandPC_RESET))
                    {
                        GridProgram[2, i].Value = CmdPC_RESET;

                        ctlCommandPC_RESET cPCRESET = (ctlCommandPC_RESET)CommandList[i];
                        GridProgram[3, i].Value = cPCRESET.Comment;
                    }
                    else if (CommandList[i].GetType() == typeof(ctlCommandSV_OFF))
                    {
                        GridProgram[2, i].Value = CmdSV_OFF;

                        ctlCommandSV_OFF cSVOFF = (ctlCommandSV_OFF)CommandList[i];
                        GridProgram[3, i].Value = cSVOFF.Comment;
                    }
                    else if (CommandList[i].GetType() == typeof(ctlCommandSV_ON))
                    {
                        GridProgram[2, i].Value = CmdSV_ON;

                        ctlCommandSV_ON cSVON = (ctlCommandSV_ON)CommandList[i];
                        GridProgram[3, i].Value = cSVON.Comment;
                    }
                    else if (CommandList[i].GetType() == typeof(ctlCommandHOME))
                    {
                        GridProgram[2, i].Value = CmdHOME;

                        ctlCommandHOME cHOME = (ctlCommandHOME)CommandList[i];
                        GridProgram[3, i].Value = cHOME.Comment;
                    }
                    else if (CommandList[i].GetType() == typeof(ctlCommandP_RESET))
                    {
                        GridProgram[2, i].Value = CmdP_RESET;

                        ctlCommandP_RESET cPRESET = (ctlCommandP_RESET)CommandList[i];
                        GridProgram[3, i].Value = cPRESET.Comment;
                    }
                    else if (CommandList[i].GetType() == typeof(ctlCommandAL_RESET))
                    {
                        GridProgram[2, i].Value = CmdAL_RESET;

                        ctlCommandAL_RESET cALRESET = (ctlCommandAL_RESET)CommandList[i];
                        GridProgram[3, i].Value = cALRESET.Comment;
                    }
                    else if (CommandList[i].GetType() == typeof(ctlCommandEND_P))
                    {
                        GridProgram[2, i].Value = CmdEND_P;

                        ctlCommandEND_P cENDP = (ctlCommandEND_P)CommandList[i];
                        GridProgram[3, i].Value = cENDP.Comment;
                    }
                    else if (CommandList[i].GetType() == typeof(ctlCommandEND_V))
                    {
                        GridProgram[2, i].Value = CmdEND_V;

                        ctlCommandEND_V cENDV = (ctlCommandEND_V)CommandList[i];
                        GridProgram[3, i].Value = cENDV.Comment;
                    }
                    else if (CommandList[i].GetType() == typeof(ctlCommandEND_C))
                    {
                        GridProgram[2, i].Value = CmdEND_C;

                        ctlCommandEND_C cENDC = (ctlCommandEND_C)CommandList[i];
                        GridProgram[3, i].Value = cENDC.Comment;
                    }
                    else if (CommandList[i].GetType() == typeof(ctlCommandEND_OFF))
                    {
                        GridProgram[2, i].Value = CmdEND_OFF;

                        ctlCommandEND_OFF cENDOFF = (ctlCommandEND_OFF)CommandList[i];
                        GridProgram[3, i].Value = cENDOFF.Comment;
                    }
                }
            }

            //CellValueChangedを復活
            GridProgram.CellValueChanged += new DataGridViewCellEventHandler(GridProgram_CellValueChanged);
        }

        #endregion

        #region フォームリサイズイベント

        private void frmBasicProgramOperation2_Resize(object sender, EventArgs e)
        {
			//del 20160907 nakayama
			//pnlProgramStep.Width = this.Width - 20;
			//pnlProgramData.Width = this.Width - 20;
			//pnlProgramHelp.Width = this.Width - 20;
        }

        #endregion

        #region ローカライズ

        private void SetMessageTagLocalize()
        {

            switch (Culture.Name)
            {
                case Culture.JP:
                case Culture.US:
                    GridProgram.ColumnHeadersDefaultCellStyle.Font = new Font(Culture.JP_US_Font, 9);

                    Step.DefaultCellStyle.Font = new Font(Culture.JP_US_Font, 9, FontStyle.Bold);
                    Command.DefaultCellStyle.Font = new Font(Culture.JP_US_Font, 9, FontStyle.Bold);

                    pLabel.DefaultCellStyle.Font = new Font(Culture.JP_US_Font, 9, FontStyle.Bold);
                    pComment.DefaultCellStyle.Font = new Font(Culture.JP_US_Font, 9, FontStyle.Bold);

                    break;

                case Culture.CN:
                    GridProgram.ColumnHeadersDefaultCellStyle.Font = new Font(Culture.CN_Font, 9);

                    Step.DefaultCellStyle.Font = new Font(Culture.CN_Font, 10, FontStyle.Regular);
                    Command.DefaultCellStyle.Font = new Font(Culture.CN_Font, 10, FontStyle.Regular);

                    pLabel.DefaultCellStyle.Font = new Font(Culture.CN_Font, 10, FontStyle.Regular);
                    pComment.DefaultCellStyle.Font = new Font(Culture.CN_Font, 10, FontStyle.Regular);

                    break;
            }

            PROG_START = UserText.ProgramOperationStart;    //運転開始
            PROG_END = UserText.ProgramOperationStop;       //運転停止
        }

        #endregion

        #region パネル

        private void pnlProgramData_Resize(object sender, EventArgs e)
        {
			//del nakayama 20160907
			//int width = 478;
			//int height = 260;

			//if (pnlProgramData.Width > 478)
			//{
			//    width = pnlProgramData.Width;
			//}

			//int tmp_height = pnlProgramData.Height - lblPrograData.Height;

			//if (tmp_height > 260)
			//{
			//    height = tmp_height;
			//}

			//panelProgData.Size = new Size(width, height);
        }

        private void pnlProgramHelp_Resize(object sender, EventArgs e)
        {
			//del nakayama 20160907
			//int width = 484;
			//int height = 142;

			//if (pnlProgramHelp.Width > 484)
			//{
			//    width = pnlProgramData.Width;
			//}

			//if (pnlProgramHelp.Height > 142)
			//{
			//    height = pnlProgramHelp.Height;
			//}

			//richHelpText.Size = new Size(width, height);
        }

        private void ProgramAllPanelVisibled(bool _visibled)
        {
			//del 20160907 nakayama
			//pnlProgramStep.Visible = _visibled;
            //pnlProgramData.Visible = _visibled;
			//pnlProgramHelp.Visible = _visibled;
        }

        #endregion

        #region カルチャリソース切り替え

        public void ViewCultureResouceChanged()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmBasicProgramOperation2));

            InitFormLayout();

            SetMessageTagLocalize();

            btnDownLoad.Font = (Font)resources.GetObject("btnDownLoad.Font");
            btnExit.Font = (Font)resources.GetObject("btnExit.Font");
            btnPrgRead.Font = (Font)resources.GetObject("btnPrgRead.Font");
            btnPrgSave.Font = (Font)resources.GetObject("btnPrgSave.Font");
            btnProgramClear.Font = (Font)resources.GetObject("btnProgramClear.Font");
            btnProgramSave.Font = (Font)resources.GetObject("btnProgramSave.Font");
            btnUpLoad.Font = (Font)resources.GetObject("btnUpLoad.Font");
            chkPrgStartEnd.Font = (Font)resources.GetObject("chkPrgStartEnd.Font");
            cmnuStep.Font = (Font)resources.GetObject("cmnuStep.Font");
            lblPrograData.Font = (Font)resources.GetObject("lblPrograData.Font");
            gradientLabel2.Font = (Font)resources.GetObject("gradientLabel2.Font");
            mnuCopy.Font = (Font)resources.GetObject("mnuCopy.Font");
            mnuCut.Font = (Font)resources.GetObject("mnuCut.Font");
            mnuDel.Font = (Font)resources.GetObject("mnuDel.Font");
            mnuDownLoad.Font = (Font)resources.GetObject("mnuDownLoad.Font");
            mnuIns.Font = (Font)resources.GetObject("mnuIns.Font");
            mnuInsertCopy.Font = (Font)resources.GetObject("mnuInsertCopy.Font");
            mnuPaste.Font = (Font)resources.GetObject("mnuPaste.Font");
            mnuRedo.Font = (Font)resources.GetObject("mnuRedo.Font");
            mnuUndo.Font = (Font)resources.GetObject("mnuUndo.Font");
            mnuUpLoad.Font = (Font)resources.GetObject("mnuUpLoad.Font");
			//del 20160907 nakayama
			//richHelpText.Font = (Font)resources.GetObject("richHelpText.Font");

			btnProfileTableset.Font = (Font)resources.GetObject("btnProfileTableset.Font");

            this.Text = resources.GetString("$this.Text");
            btnDownLoad.Text = resources.GetString("btnDownLoad.Text");
            btnExit.Text = resources.GetString("btnExit.Text");
            btnPrgRead.Text = resources.GetString("btnPrgRead.Text");
            btnPrgSave.Text = resources.GetString("btnPrgSave.Text");
            btnProgramClear.Text = resources.GetString("btnProgramClear.Text");
            btnProgramSave.Text = resources.GetString("btnProgramSave.Text");
            btnUpLoad.Text = resources.GetString("btnUpLoad.Text");
            chkPrgStartEnd.Text = resources.GetString("chkPrgStartEnd.Text");
            cmnuStep.Text = resources.GetString("cmnuStep.Text");
            Command.HeaderText = resources.GetString("Command.HeaderText");
            lblPrograData.Text = resources.GetString("lblPrograData.Text");
            gradientLabel2.Text = resources.GetString("gradientLabel2.Text");
            mnuCopy.Text = resources.GetString("mnuCopy.Text");
            mnuCut.Text = resources.GetString("mnuCut.Text");
            mnuDel.Text = resources.GetString("mnuDel.Text");
            mnuDownLoad.Text = resources.GetString("mnuDownLoad.Text");
            mnuIns.Text = resources.GetString("mnuIns.Text");
            mnuInsertCopy.Text = resources.GetString("mnuInsertCopy.Text");
            mnuPaste.Text = resources.GetString("mnuPaste.Text");
            mnuRedo.Text = resources.GetString("mnuRedo.Text");
            mnuUndo.Text = resources.GetString("mnuUndo.Text");
            mnuUpLoad.Text = resources.GetString("mnuUpLoad.Text");
            openFileDialog.Filter = resources.GetString("openFileDialog.Text");
            openFileDialog.Title = resources.GetString("openFileDialog.Text");
            pComment.HeaderText = resources.GetString("pComment.Text");
            pLabel.HeaderText = resources.GetString("pLabel.Text");
			//del 20160907 nakayama
			//richHelpText.Text = resources.GetString("richHelpText.Text");
            saveFileDialog.Title = resources.GetString("saveFileDialog.Title");
            Step.HeaderText = resources.GetString("Step.HeaderText");
            pComment.HeaderText = resources.GetString("pComment.HeaderText");

			btnProfileTableset.Text = resources.GetString("btnProfileTableset.Text");

            //各コマンドコントロール画面のリソース切替え
            for (int i = 0; i < GridProgram.RowCount; i++)
            {
                string strCmd = GridProgram.Rows[i].Cells["Command"].Value.ToString();

                switch (strCmd)
                {
                    case CmdMOVE_END:
                        ctlCommandMOVE_END c_moveend = (ctlCommandMOVE_END)CommandList[i];
                        c_moveend.ViewCultureResouceRefresh();
                        break;

                    case CmdMOVE_ST:
                        ctlCommandMOVE_ST c_movest = (ctlCommandMOVE_ST)CommandList[i];
                        c_movest.ViewCultureResouceRefresh();
                        break;

                    case CmdMOVE_V:
                        ctlCommandMOVE_V c_movev = (ctlCommandMOVE_V)CommandList[i];
                        c_movev.ViewCultureResouceRefresh();
                        break;

                    case CmdMOVE_C:
                        ctlCommandMOVE_C c_movec = (ctlCommandMOVE_C)CommandList[i];
                        c_movec.ViewCultureResouceRefresh();
                        break;

                    case CmdJMP0:
                        ctlCommandJMP0 c_jmp0 = (ctlCommandJMP0)CommandList[i];
                        c_jmp0.ViewCultureResouceRefresh();
                        break;

                    case CmdJMP_IN:
                        ctlCommandJMP_IN c_jmpin = (ctlCommandJMP_IN)CommandList[i];
                        c_jmpin.ViewCultureResouceRefresh();
                        break;

                    case CmdJMP_IN_OFF:
                        ctlCommandJMP_IN_OFF c_jmpinoff = (ctlCommandJMP_IN_OFF)CommandList[i];
                        c_jmpinoff.ViewCultureResouceRefresh();
                        break;

                    case CmdJMP_TRQ:
                        ctlCommandJMP_TRQ c_jmptrq = (ctlCommandJMP_TRQ)CommandList[i];
                        c_jmptrq.ViewCultureResouceRefresh();
                        break;

                    case CmdJMP_STS:
                        ctlCommandJMP_STS c_jmpsts = (ctlCommandJMP_STS)CommandList[i];
                        c_jmpsts.ViewCultureResouceRefresh();
                        break;

                    case CmdWAIT0:
                        ctlCommandWAIT0 c_wait0 = (ctlCommandWAIT0)CommandList[i];
                        c_wait0.ViewCultureResouceRefresh();
                        break;

                    case CmdOUT0:
                        ctlCommandOUT0 c_out0 = (ctlCommandOUT0)CommandList[i];
                        c_out0.ViewCultureResouceRefresh();
                        break;

                    case CmdPARA_W:
                        ctlCommandPARA_W c_paraw = (ctlCommandPARA_W)CommandList[i];
                        c_paraw.ViewCultureResouceRefresh();
                        break;

                    case CmdPC_RST_SP:
                        ctlCommandPC_RST_SP c_pcrstsp = (ctlCommandPC_RST_SP)CommandList[i];
                        c_pcrstsp.ViewCultureResouceRefresh();
                        break;

                    case CmdNOP:
                    case CmdPC_RESET:
                    case CmdSV_OFF:
                    case CmdSV_ON:
                    case CmdHOME:
                    case CmdP_RESET:
                    case CmdAL_RESET:
                    case CmdEND_P:
                    case CmdEND_V:
                    case CmdEND_C:
                    case CmdEND_OFF:
                        break;
                }
            }

            //選択されたプログラムの再ヘルプ表示
            if (GridProgram.CurrentRow != null)
            {
                int row = GridProgram.CurrentRow.Index;
                ViewCommandHelp(row, GridProgram[2, row].Value.ToString());
            }

			if (pmoveform != null && pmoveform.Visible)
			{
				pmoveform.ViewCultureResouceChanged();
			}
        }

        #endregion              

		private ProgramHelpForm helpForm = new ProgramHelpForm();

		private void btnHelp_Click(object sender, EventArgs e)
		{
			if (helpForm == null)
			{
				helpForm = new ProgramHelpForm();
				helpForm.Show();

				if (GridProgram.CurrentRow != null)
				{
					int row = GridProgram.CurrentRow.Index;
					ViewCommandHelp(row, GridProgram[2, row].Value.ToString());
				}
			}

			if (helpForm.Visible == false)
			{
				helpForm = new ProgramHelpForm();
				helpForm.Show();

				if (GridProgram.CurrentRow != null)
				{
					int row = GridProgram.CurrentRow.Index;
					ViewCommandHelp(row, GridProgram[2, row].Value.ToString());
				}
			}
		}

		//add 20160907 nakayama
		private void GridProgram_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			btnHelp.PerformClick();
		}

		//add 20161108 nakayama
		public bool IsProgramExec
		{
			get { return IsSimplified; }
		}

		//add 20170125 nakayama
		private void ClearGridBackColor()
		{
			for (int i = 0; i < GridProgram.Rows.Count; i++)
			{
				GridProgram.Rows[i].DefaultCellStyle.BackColor = Color.Empty;
			}
		}

		//add 20170000 kimura
		private void btnProfileTableset_Click(object sender, EventArgs e)
		{
			if (pmoveform == null)
			{
				pmoveform = new ProfileMovementTableForm(this);

				pmoveform.Show();
			}
			else if (pmoveform.Visible == false)
			{
				if (pmoveform.IsExist == false)
				{
					pmoveform = new ProfileMovementTableForm(this);
				}

				pmoveform.Show();

			}
			else if (pmoveform.WindowState == FormWindowState.Minimized)
			{
				pmoveform.WindowState = FormWindowState.Normal;
			}

			pmoveform.ProfileGridChanged -= new ProfileMovementTableForm.dProfileGridChanged(pmoveform_ProfileGridChanged);
			pmoveform.ProfileTableChanged -= new ProfileMovementTableForm.dProfileTableChanged(pmoveform_ProfileTableChanged);

			pmoveform.ProfileGridChanged += new ProfileMovementTableForm.dProfileGridChanged(pmoveform_ProfileGridChanged);
			pmoveform.ProfileTableChanged += new ProfileMovementTableForm.dProfileTableChanged(pmoveform_ProfileTableChanged);

			this.Enabled = false;

			pmoveform.Activate();
		}

		void pmoveform_ProfileGridChanged(int step)
		{
			//選択行表示
			GridProgram.CurrentCell = GridProgram[0, step];
		}

		void pmoveform_ProfileTableChanged(int step, ctlCommandMOVE_END cMOVEEND)
		{
			if (CommandList[step].GetType() == typeof(ctlCommandMOVE_END))
			{
				ctlCommandMOVE_END DestMOVEEND = (ctlCommandMOVE_END)CommandList[step];

				DestMOVEEND.FLAG_M1 = cMOVEEND.FLAG_M1;
				DestMOVEEND.TargetVelocity = cMOVEEND.TargetVelocity;
				DestMOVEEND.TargetPosition = cMOVEEND.TargetPosition;
				DestMOVEEND.Acceleration = cMOVEEND.Acceleration;
				DestMOVEEND.Deceleration = cMOVEEND.Deceleration;

				if (DestMOVEEND.Comment != cMOVEEND.Comment)
				{
					GridProgram.Rows[step].Cells["pComment"].Value = cMOVEEND.Comment;
					DestMOVEEND.Comment = cMOVEEND.Comment;
				}

				DestMOVEEND.ViewMOVE_END();
			}
		}

		//private void AdddProfileTableValueChangedHandler(ctlCommandMOVE_END _cMOVEEND)
		//{
		//    _cMOVEEND.ProfileTableValueChange -= new ctlCommandMOVE_END.dProfileTableValueChanged(_cMOVEEND_ProfileTableValueChange);
		//    _cMOVEEND.ProfileTableValueChange += new ctlCommandMOVE_END.dProfileTableValueChanged(_cMOVEEND_ProfileTableValueChange);
		//}

		void _cMOVEEND_ProfileTableValueChange(object sender)
		{
			pmoveform.UpdateProfileTableValue(GridProgram.CurrentRow.Index, (ctlCommandMOVE_END)sender);
		}

		public int[] GetMOVECommandStepNumberList()
		{
			int[] list = null;
			ArrayList astep = new ArrayList();

			for (int row = 0; row < MAX_STEP_COUNT; row++)
			{
				if (CommandList[row].GetType() == typeof(ctlCommandMOVE_END))
				{
					astep.Add(row);
				}
			}

			if (astep.Count > 0)
			{
				list = (int[])astep.ToArray(typeof(int));
			}

			return list;
		}

		public ctlCommandMOVE_END[] GetMOVE_ENDCommandList()
		{
			ctlCommandMOVE_END[] list = null;
			ArrayList aMOVEEND = new ArrayList();

			for (int row = 0; row < MAX_STEP_COUNT; row++)
			{
				if (CommandList[row].GetType() == typeof(ctlCommandMOVE_END))
				{
					ctlCommandMOVE_END wMOVEEND = (ctlCommandMOVE_END)CommandList[row];
					aMOVEEND.Add(wMOVEEND);
				}
			}

			if (aMOVEEND.Count > 0)
			{
				list = (ctlCommandMOVE_END[])aMOVEEND.ToArray(typeof(ctlCommandMOVE_END));
			}

			return list;
		}

        // Ver 1.32 add ↓↓↓
        public void ResetProgrameStart()
        {
            if (chkPrgStartEnd.Text == PROG_END)
            {
                chkPrgStartEnd.PerformClick();
            }
        }
        // Ver1.32 add ↑↑↑
	}
}