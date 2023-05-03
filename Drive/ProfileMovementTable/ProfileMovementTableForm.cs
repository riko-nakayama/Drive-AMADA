using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Motion_Designer
{
    //add 20170000 kimura
    public partial class ProfileMovementTableForm : Form
    {
        #region ビットフィールドクラス

        [FlagsAttribute]
        public enum BitField : uint
        {
            B_0 = 0x00000001,
            B_1 = 0x00000002,
            B_2 = 0x00000004,
            B_3 = 0x00000008,
            B_4 = 0x00000010,
            B_5 = 0x00000020,
            B_6 = 0x00000040,
            B_7 = 0x00000080,
            B_8 = 0x00000100,
            B_9 = 0x00000200,
            B_10 = 0x00000400,
            B_11 = 0x00000800,
            B_12 = 0x00001000,
            B_13 = 0x00002000,
            B_14 = 0x00004000,
            B_15 = 0x00008000,
            B_16 = 0x00010000,
            B_17 = 0x00020000,
            B_18 = 0x00040000,
            B_19 = 0x00080000,
            B_20 = 0x00100000,
            B_21 = 0x00200000,
            B_22 = 0x00400000,
            B_23 = 0x00800000,
            B_24 = 0x01000000,
            B_25 = 0x02000000,
            B_26 = 0x04000000,
            B_27 = 0x08000000,
            B_28 = 0x10000000,
            B_29 = 0x20000000,
            B_30 = 0x40000000,
            B_31 = 0x80000000,
        }

        public class WORD
        {
            [StructLayout(LayoutKind.Explicit)]
            private struct WORDField
            {
                [FieldOffset(0)]
                public uint Value;

                [FieldOffset(0)]
                public ushort LoWord;

                [FieldOffset(2)]
                public ushort HighWord;

                [FieldOffset(0)]
                public BitField Bit;

                [FieldOffset(0)]
                public byte LowByte;

                [FieldOffset(1)]
                public byte MiddleByte;

                [FieldOffset(2)]
                public byte HighByte;

                [FieldOffset(3)]
                public byte VeryhighByte;
            }

            private WORDField wd = new WORDField();

            public uint Value
            {
                set { this.wd.Value = value; }
                get { return this.wd.Value; }
            }

            public ushort LoWord
            {
                set { this.wd.LoWord = value; }
                get { return this.wd.LoWord; }
            }

            public ushort HighWord
            {
                set { this.wd.HighWord = value; }
                get { return this.wd.HighWord; }
            }

            public BitField Bit
            {
                set { this.wd.Bit = value; }
                get { return this.wd.Bit; }

            }

            public byte LowByte
            {
                set { this.wd.LowByte = value; }
                get { return this.wd.LowByte; }

            }

            public byte MiddleByte
            {
                set { this.wd.MiddleByte = value; }
                get { return this.wd.MiddleByte; }

            }

            public byte HighByte
            {
                set { this.wd.HighByte = value; }
                get { return this.wd.HighByte; }

            }

            public byte VeryhighByte
            {
                set { this.wd.VeryhighByte = value; }
                get { return this.wd.VeryhighByte; }

            }

            public WORD()
            {

            }

            public bool HasFlag(BitField _bit)
            {
                return (wd.Bit & _bit) == _bit;
            }
        }

        #endregion

        #region プロパティ

        static public ProfileMovementTableForm ThisForm
        {
            get { return _ThisForm; }
        }

        public bool IsExist
        {
            get { return _IsExist; }
        }

        private bool AllControlEnabled
        {
            set
            {
                btnTableRead.Enabled = value;
                btnPrgRead.Enabled = value;
                btnPrgSave.Enabled = value;
                btnDownLoad.Enabled = value;
                btnUpLoad.Enabled = value;
                btnProgramSave.Enabled = value;
                grdPorfile.Enabled = value;
            }
        }

        #endregion

        #region 定数

        private const string ProfileName = @"C:\ProfileMovementTableTemp\SRM test prg 5 Profile 20160318_02(IN7RP) .prg";
        private const int MAX_STEP_COUNT = 200;

        #endregion

        #region イベント

        public delegate void dProfileGridChanged(int step);
        public delegate void dProfileTableChanged(int step, ctlCommandMOVE_END cmd);

        public event dProfileGridChanged ProfileGridChanged;
        public event dProfileTableChanged ProfileTableChanged;

        #endregion

        #region 変数

        static private Point FormPosition = new Point(-1, -1);
        static private Size FormSize = new Size(1140, 500);
        static private ProfileMovementTableForm _ThisForm;        
        
        private bool _IsExist = new bool();

        private string PROG_START = UserText.ProgramOperationStart;    //運転開始
        private string PROG_END = UserText.ProgramOperationStop;       //運転停止

        private ctlCommandMOVE_END[] aMoveEND = new ctlCommandMOVE_END[MAX_STEP_COUNT];

        //プログレスダイアログボックス
        private DataProgressDialog pBarForm = new DataProgressDialog();

        private frmBasicProgramOperation2 fprog;

        #endregion

        #region コンストラクタ

        public ProfileMovementTableForm(frmBasicProgramOperation2 _fprog)
        {
            InitializeComponent();

            fprog = _fprog;

            _ThisForm = this;
            _IsExist = true;
        }

        #endregion

        private void ProfileMovementTableForm_Load(object sender, EventArgs e)
        {
            ViewCultureResouceChanged();

            this.Size = FormSize;

            if (!(FormPosition.X == -1 && FormPosition.Y == -1))
            {
                this.Location = FormPosition;
            }

            this.MinimumSize = new Size(1140, 480);

			//20170216 add nakayama
			AutoTuningForm.ThisForm.Enabled = false;
        }
  
        private void ProfileMovementTableForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                FormPosition = this.Location;
            }

            FormSize = this.Size;

            _IsExist = false;

            fprog.Enabled = true;

            if (chkPrgStartEnd.Text.Equals(PROG_END)) { fprog.bProgramStop(); }

			//20170216 add nakayama
			AutoTuningForm.ThisForm.Enabled = true;
		}

        #region メニュー

        private void btnTableRead_Click(object sender, EventArgs e)
        {
            if (!MainForm.IsUsbConnectBlink) { return; }

            this.TopMost = false;

            // 移動命令テーブルの一覧を作成します。
            // よろしいですか？
            if (DialogResult.Yes == UserMessageBox.ProfileMovementUpdaloadTableMaked()) 
            {
                fprog.UpLoad(false);

                if (bAllStepProfileDataRead())
                {
                    // 移動命令テーブル一覧の作成が完了しました。
                    UserMessageBox.ProfileMovementReadcompleted();
                }
                else
                {
                    // 簡易プログラム内に位置命令が設定されていません。
                    UserMessageBox.ProfileMovementNoCommand();
                }
            }          

            this.TopMost = true;
        }

        private void btnPrgRead_Click(object sender, EventArgs e)
        {
            DialogResult bresult = fprog.FileRead();

            if (bresult == DialogResult.OK)
            {
                if (MainForm.IsUsbConnect)
                {
                    if (!fprog.DownLoad(false)) { return; }
                }

                this.TopMost = false;

                if (bAllStepProfileDataRead())
                {
                    //移動命令テーブル一覧の作成が完了しました。
                    UserMessageBox.ProfileMovementReadcompleted();
                }
                else
                {
                    //簡易プログラム内に位置命令が設定されていません。
                    UserMessageBox.ProfileMovementNoCommand();
                }

                this.TopMost = true;
            }
            else if (bresult == DialogResult.Abort)
            {
                //プログラムファイル読込み異常です。
                MessageBox.Show(UserText.ProgramFileRead_ERR_M,
                                UserText.ProgramFileRead_ERR_H,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }

            this.TopMost = true;
        }

        private void btnPrgSave_Click(object sender, EventArgs e)
        {
            fprog.FileSave();
        }

        private void btnDownLoad_Click(object sender, EventArgs e)
        {
            fprog.DownLoad(true);
        }

        private void btnUpLoad_Click(object sender, EventArgs e)
        {
            fprog.UpLoad(true);
        }

        private void chkPrgStartEnd_Click(object sender, EventArgs e)
        {
            if (!MainForm.IsUsbConnectBlink) { return; }

            if (chkPrgStartEnd.Text.Equals(PROG_START))
            {
                chkPrgStartEnd.Text = PROG_END;
                chkPrgStartEnd.Image = Properties.Resources.Stop;

                AllControlEnabled = false;

                fprog.bProgramStart();
            }
            else
            {
                chkPrgStartEnd.Text = PROG_START;
                chkPrgStartEnd.Image = Properties.Resources.Start;

                AllControlEnabled = true;

                fprog.bProgramStop();
            }
        }

        private void btnProgramSave_Click(object sender, EventArgs e)
        {
            fprog.ProgramSave();
        }

        #endregion

        #region グリッドイベント

        private void grdPorfile_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridView dgv = (DataGridView )sender;

            if (dgv == null) { return; }
            
            //入力項目のみ
            if (e.ColumnIndex >= 4 && e.ColumnIndex <= 7)
            {
                dgv[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.Red;
                dgv[e.ColumnIndex, e.RowIndex].Style.Font = new Font("Meiryo", 9, FontStyle.Bold);
            }
        }

        private void grdPorfile_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (dgv == null) { return; }
            
            //入力項目のみ
            if (e.ColumnIndex >= 4 && e.ColumnIndex <= 7)
            {
                dgv[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.Black;
                dgv[e.ColumnIndex, e.RowIndex].Style.Font = new Font("Meiryo", 9, FontStyle.Regular);
            }
        }

        private void grdPorfile_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (grdPorfile.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn) { SendKeys.Send("{F4}"); }
        }

        private void grdPorfile_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridView _dgv = (DataGridView)sender;

            if (_dgv == null) { return; }

            if (e.ColumnIndex < 4 || e.ColumnIndex > 7 ) { return; }

            if (e.RowIndex == _dgv.NewRowIndex || !_dgv.IsCurrentRowDirty) { return; }
            
            string strvalue = e.FormattedValue.ToString();

            if (strvalue != string.Empty)
            {
                if (!CellValidatingcCheck(e.ColumnIndex, strvalue))
                {
                    //入力された値が無効です。
                    UserMessageBox.ProfileMovementinputInputInvalid();

                    _dgv.CancelEdit();
                    _dgv.ClearSelection();
                    _dgv.BeginEdit(false);

                    e.Cancel = true;
                }
            }
        }

        private void grdPorfile_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView _dgv = (DataGridView)sender;

            if (_dgv != null)
            {
                if (_dgv.CurrentRow == null) { return; }
                
                int _row = _dgv.CurrentRow.Index;
                int _col = _dgv.CurrentCell.ColumnIndex;

                if (e.RowIndex >= 0)
                {
                    int step = (int)_dgv.Rows[e.RowIndex].Cells[1].Value;

                    if (_dgv.CurrentRow != null && e.ColumnIndex > -1)
                    {
                        if (_dgv.Columns[e.ColumnIndex] is DataGridViewTextBoxColumn) { SendKeys.Send("{F2}"); }

                        _dgv.ClearSelection();
                        _dgv.CurrentCell = _dgv[_col, _row];
                        _dgv.BeginEdit(true);

                        ProfileGridChanged(step);
                    }
                }
            }
        }

        private void grdPorfile_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!MainForm.IsUsbConnectBlink) { return; }

            DataGridView _dgv = (DataGridView)sender;

            if (_dgv == null) { return; }

            if (e.ColumnIndex >= 0 && e.ColumnIndex <= 1) { return; }
            
            if (e.RowIndex > -1)
            {
                //Get Step No 
                int step = (int)_dgv.Rows[e.RowIndex].Cells[1].Value;

                // READ Button ?
                if (e.ColumnIndex == 8)
                {
                    this.TopMost = false;

                    if (!bGetProfileData(e.RowIndex, step))
                    {
                        //移動命令テーブル一覧の読込みに失敗しました。
                        UserMessageBox.ProfileMovementReadFailed();
                    }

                    this.TopMost = true;
                }
                // WRITE Button?
                else if (e.ColumnIndex == 9)
                {
                    this.TopMost = false;

                    if (bSetProfileData(e.RowIndex, step))
                    {
                        ProfileTableChanged(step, aMoveEND[e.RowIndex]);
                    }
                    else
                    {
                        //移動命令テーブル一覧の書込みに失敗しました。
                        UserMessageBox.ProfileMovementWriteFailed();
                    }

                    this.TopMost = true;
                }
                else
                {
                    ProfileGridChanged(step);
                }
            }
        }

        private void grdPorfile_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (dgv.Columns[dgv.CurrentCellAddress.X] is DataGridViewComboBoxColumn)
            {
                dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private bool CellValidatingcCheck(int _Column, string _str)
        {
            Int32 iValue = 0;
            Int16 sValue = 0;

            if (_Column == 4)
            {
                if (!Int32.TryParse(_str, out iValue)) { return false; }
            }
            else
            {
                if (!Int16.TryParse(_str, out sValue)) { return false; }
            }

            return true;
        }

        private void grdPorfile_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView _dgv = (DataGridView)sender;

            if (_dgv != null)
            {
                int step = (int)_dgv.Rows[_dgv.CurrentRow.Index].Cells[1].Value;
                ProfileGridChanged(step);
            }
        }
       
        private void grdPorfile_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //コメント行が変更？
            if (e.ColumnIndex == 10)
            {
                if (e.RowIndex >= 0)
                {
                    string strcomment = "";

                    if (grdPorfile.Rows[e.RowIndex].Cells["pComment"].Value != null)
                    {
                        strcomment = grdPorfile.Rows[e.RowIndex].Cells["pComment"].Value.ToString();
                    }

                    if (aMoveEND[e.RowIndex].Comment != strcomment)
                    {
                        aMoveEND[e.RowIndex].Comment = strcomment;

                        //Get Step No 
                        int step = (int)grdPorfile.Rows[e.RowIndex].Cells[1].Value;
                        ProfileTableChanged(step, aMoveEND[e.RowIndex]);
                    }
                }
            }
        }

        #endregion

        #region DataGriedView IO

        /// <summary>
        ///  Get Profiler Data To DataGriedView
        /// </summary>
        /// <param name="_row"></param>
        /// <param name="_step"></param>
        private void GetProfilerDataToDataGriedView(int _row)
        {
            WORD flag = new WORD();

            flag.Value = (uint)aMoveEND[_row].FLAG_M1;

            if(flag.HasFlag(BitField.B_0))
            {
                //相対値移動
                grdPorfile.Rows[_row].Cells["pPosCommand"].Value = UserText.ProfileMovementRelative;
            }
            else
            {
                //絶対値移動
                grdPorfile.Rows[_row].Cells["pPosCommand"].Value = UserText.ProfileMovementAbsolute;
            }

            if (flag.HasFlag(BitField.B_1))
            {
                //指令位置到達&インポジ
                grdPorfile.Rows[_row].Cells["pMovement"].Value = UserText.ProfileMovementPosInpos;
            }
            else
            {
                //指令位置到達
                grdPorfile.Rows[_row].Cells["pMovement"].Value = UserText.ProfileMovementPosition;
            }

            grdPorfile.Rows[_row].Cells["pPosition"].Value = aMoveEND[_row].TargetPosition;
            grdPorfile.Rows[_row].Cells["pVelocity"].Value = aMoveEND[_row].TargetVelocity;
            grdPorfile.Rows[_row].Cells["pAcceleration"].Value = aMoveEND[_row].Acceleration;
            grdPorfile.Rows[_row].Cells["pDeceleration"].Value = aMoveEND[_row].Deceleration;
            grdPorfile.Rows[_row].Cells["pComment"].Value = aMoveEND[_row].Comment;

            grdPorfile.Invalidate();
        }

        /// <summary>
        /// Set Profiler Data To DataGriedView
        /// </summary>
        /// <param name="_row"></param>
        /// <param name="_step"></param>
        /// <returns></returns>
        private bool SetProfilerDataToDataGriedView(int _row)
        {
            int FLAG_M1_bit0 = 0;
            int FLAG_M1_bit1 = 0;

            try
            {
                //相対値移動?
                if (grdPorfile.Rows[_row].Cells["pPosCommand"].Value.ToString() == UserText.ProfileMovementRelative)
                {
                    FLAG_M1_bit0 = 0x01;
                }

                //指令位置到達&インポジ?
                if (grdPorfile.Rows[_row].Cells["pMovement"].Value.ToString() == UserText.ProfileMovementPosInpos)
                {
                    FLAG_M1_bit1 = 0x02;
                }

                aMoveEND[_row].FLAG_M1 = FLAG_M1_bit1 | FLAG_M1_bit0;

                aMoveEND[_row].TargetPosition = Int32.Parse(grdPorfile.Rows[_row].Cells["pPosition"].Value.ToString());
                aMoveEND[_row].TargetVelocity = Int16.Parse(grdPorfile.Rows[_row].Cells["pVelocity"].Value.ToString());
                aMoveEND[_row].Acceleration = Int16.Parse(grdPorfile.Rows[_row].Cells["pAcceleration"].Value.ToString());
                aMoveEND[_row].Deceleration = Int16.Parse(grdPorfile.Rows[_row].Cells["pDeceleration"].Value.ToString());
                aMoveEND[_row].Comment = grdPorfile.Rows[_row].Cells["pComment"].Value.ToString();
            }
            catch
            {
                return false;
            }

            return true;
        }

        #endregion     
  
        #region Set Profile Data

        /// <summary>
        ///  Set Profile Data
        /// </summary>
        /// <returns></returns>
        private bool bSetProfileData(int _row, int _step)
        {
            WORD iData177 = new WORD();
            WORD iData178 = new WORD();
            WORD iData179 = new WORD();

            if (!SetProfilerDataToDataGriedView(_row)) { return false; }
            
            //Servo OFF
            if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, 0)) { return false; }
            
            iData177.VeryhighByte = (byte)aMoveEND[_row].ID;
            iData177.HighByte = (byte)aMoveEND[_row].FLAG_M1;
            iData177.LoWord = (ushort)aMoveEND[_row].TargetVelocity;

            iData178.Value = (uint )aMoveEND[_row].TargetPosition;

            iData179.HighWord = (ushort)aMoveEND[_row].Acceleration;
            iData179.LoWord = (ushort)aMoveEND[_row].Deceleration;

            //Program Pointer
            if (!CCommandTx.WriteSvNet(CParamID.ProgramPointer, _step)) { return false; }
            
            //Program Data0
            if (!CCommandTx.WriteSvNet(CParamID.ProgramData0, (int)iData177.Value)) { return false; }
            
            //Program Data1
            if (!CCommandTx.WriteSvNet(CParamID.ProgramData1, (int)iData178.Value)) { return false; }
            
            //Program Data2
            if (!CCommandTx.WriteSvNet(CParamID.ProgramData2, (int)iData179.Value)) { return false; }
            
            return true;
        }

        #endregion

        #region Get Profile Data

        /// <summary>
        /// Get Profile Data
        /// </summary>
        /// <returns></returns>
        private bool bGetProfileData(int _row, int _step)
        {
            int iValue177 = 0;
            int iValue178 = 0;
            int iValue179 = 0;

            WORD iData177 = new WORD();
            WORD iData178 = new WORD();
            WORD iData179 = new WORD();

            // Set Program Pointer
            if (!CCommandTx.WriteSvNet(CParamID.ProgramPointer, _step)) { return false; }

            // GetProgram Data0
            if (!CCommandTx.ReadSvNet(CParamID.ProgramData0, ref iValue177)) { return false; }

            // Get Program Data1
            if (!CCommandTx.ReadSvNet(CParamID.ProgramData1, ref iValue178)) { return false; }

            // Get Program Data2
            if (!CCommandTx.ReadSvNet(CParamID.ProgramData2, ref iValue179)) { return false; }

            iData177.Value = (uint)iValue177;
            iData178.Value = (uint)iValue178;
            iData179.Value = (uint)iValue179;

            // Program ID = MONE_END ?
            if (iData177.VeryhighByte == 0x01)
            {
                if (aMoveEND[_row] == null) { aMoveEND[_row] = new ctlCommandMOVE_END(); }

                //FLAG_M1
                aMoveEND[_row].FLAG_M1 = iData177.HighByte;

                //TargetVelocity
                aMoveEND[_row].TargetVelocity = (short)iData177.LoWord;

                //TargetPosition
                aMoveEND[_row].TargetPosition = (int)iData178.Value;

                //Acceleration
                aMoveEND[_row].Acceleration = (short)iData179.HighWord;

                //Deceleration
                aMoveEND[_row].Deceleration = (short)iData179.LoWord;

                //Profile DataViewGird ReDraw
                GetProfilerDataToDataGriedView(_row);
            }
            else
            {
                return false;
            }

            return true;
        }

        #endregion

        #region All Step Profile DATA Read

        private bool bAllStepProfileDataRead()
        {

            grdPorfile.Rows.Clear();

            int[] steplist = fprog.GetMOVECommandStepNumberList();
            
            ctlCommandMOVE_END[] cmdlist = fprog.GetMOVE_ENDCommandList();

            if (steplist != null && cmdlist != null )
            {
                if (steplist.Length != cmdlist.Length) { return false; }

                for (int row = 0; row < steplist.Length; row++)
                {
                    grdPorfile.Rows.Add(1);

                    grdPorfile.Rows[row].Cells["pSelect"].Value = row + 1;
                    grdPorfile.Rows[row].Cells["pStep"].Value = steplist[row];

                    grdPorfile.Rows[row].Cells["pRead"].Value = UserText.ProfileMovementRead;
                    grdPorfile.Rows[row].Cells["pWrite"].Value = UserText.ProfileMovementWrite;

                    if (aMoveEND[row] == null) { aMoveEND[row] = new ctlCommandMOVE_END(); }

                    //FLAG_M1
                    aMoveEND[row].FLAG_M1 = cmdlist[row].FLAG_M1;

                    //TargetVelocity
                    aMoveEND[row].TargetVelocity = cmdlist[row].TargetVelocity;

                    //TargetPosition
                    aMoveEND[row].TargetPosition = cmdlist[row].TargetPosition;

                    //Acceleration
                    aMoveEND[row].Acceleration = cmdlist[row].Acceleration;

                    //Deceleration
                    aMoveEND[row].Deceleration = cmdlist[row].Deceleration;

                    //コメント
                    aMoveEND[row].Comment = cmdlist[row].Comment;

                    //Profile DataViewGird ReDraw
                    GetProfilerDataToDataGriedView(row);
                }
            }
            
            if (grdPorfile.Rows.Count == 0 ) { return false; }

            //先頭のMOVE_ENDコマンドへ
            ProfileGridChanged((int)grdPorfile.Rows[0].Cells["pStep"].Value);

            return true;
        }

        #endregion

        public void UpdateCurrentCellProfileTable(int step)
        {

            for (int row = 0; row < grdPorfile.RowCount; row++)
            {
                int value = (int)grdPorfile.Rows[row].Cells[1].Value;

                if (step == value)
                {
                    //選択行表示
                    grdPorfile.CurrentCell = grdPorfile[grdPorfile.CurrentCell.ColumnIndex, row];
                    grdPorfile.CurrentRow.Selected = true;
                    break;
                }
            }
        }

        public void UpdateProfileTableValue(int step, ctlCommandMOVE_END cMOVEEND)
        {
            for (int row = 0; row < grdPorfile.RowCount; row++)
            {
                int value = (int)grdPorfile.Rows[row].Cells[1].Value;

                if (step == value)
                {
                    aMoveEND[row].FLAG_M1 = cMOVEEND.FLAG_M1;
                    aMoveEND[row].TargetVelocity = cMOVEEND.TargetVelocity;
                    aMoveEND[row].TargetPosition = cMOVEEND.TargetPosition;
                    aMoveEND[row].Acceleration = cMOVEEND.Acceleration;
                    aMoveEND[row].Deceleration = cMOVEEND.Deceleration;
                    aMoveEND[row].Comment = cMOVEEND.Comment;
                    
                    GetProfilerDataToDataGriedView(row);
                    break;
                }
            }
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            this.Select();
        }

        private void btn_MouseHover(object sender, EventArgs e)
        {
            this.Select();
        }

        private void ProfileMovementTableForm_SizeChanged(object sender, EventArgs e)
        {
            grdPorfile.Height = (this.Height > 480) ? this.Height - 80 : 400;

            if (this.Width > 1140) { this.Width = 1140; }
        }

        #region カルチャリソース切り替え

        public void ViewCultureResouceChanged()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ProfileMovementTableForm));

            btnTableRead.Font = (Font)resources.GetObject("btnTableRead.Font");
            btnPrgRead.Font = (Font)resources.GetObject("btnPrgRead.Font");
            btnPrgSave.Font = (Font)resources.GetObject("btnPrgSave.Font");
            btnDownLoad.Font = (Font)resources.GetObject("btnDownLoad.Font");
            btnUpLoad.Font = (Font)resources.GetObject("btnUpLoad.Font");
            chkPrgStartEnd.Font = (Font)resources.GetObject("chkPrgStartEnd.Font");
            btnProgramSave.Font = (Font)resources.GetObject("btnProgramSave.Font");

            this.Text = resources.GetString("$this.Text");
            btnTableRead.Text = resources.GetString("btnTableRead.Text");
            btnPrgRead.Text = resources.GetString("btnPrgRead.Text");
            btnPrgSave.Text = resources.GetString("btnPrgSave.Text");
            btnDownLoad.Text = resources.GetString("btnDownLoad.Text");
            btnUpLoad.Text = resources.GetString("btnUpLoad.Text");
            chkPrgStartEnd.Text = resources.GetString("chkPrgStartEnd.Text");
            btnProgramSave.Text = resources.GetString("btnProgramSave.Text");

            pSelect.HeaderText = resources.GetString("pSelect.HeaderText");
            pStep.HeaderText = resources.GetString("pStep.HeaderText");
            pPosCommand.HeaderText = resources.GetString("pPosCommand.HeaderText");
            pMovement.HeaderText = resources.GetString("pMovement.HeaderText");
            pPosition.HeaderText = resources.GetString("pPosition.HeaderText");
            pVelocity.HeaderText = resources.GetString("pVelocity.HeaderText");
            pAcceleration.HeaderText = resources.GetString("pAcceleration.HeaderText");
            pDeceleration.HeaderText = resources.GetString("pDeceleration.HeaderText");
            pRead.HeaderText = resources.GetString("pRead.HeaderText");
            pWrite.HeaderText = resources.GetString("pWrite.HeaderText");
            pComment.HeaderText = resources.GetString("pComment.HeaderText");

            string[] poslist = new string[] { UserText.ProfileMovementAbsolute, UserText.ProfileMovementRelative };
            string[] cmdlist = new string[] { UserText.ProfileMovementPosition, UserText.ProfileMovementPosInpos };

            pPosCommand.Items.Clear();
            pPosCommand.Items.AddRange(poslist);

            pMovement.Items.Clear();
            pMovement.Items.AddRange(cmdlist);

            WORD flag = new WORD();

            for (int row = 0; row < grdPorfile.RowCount; row++)
            {
                flag.Value = (uint)aMoveEND[row].FLAG_M1;

                if (flag.HasFlag(BitField.B_0))
                {
                    //相対値移動
                    grdPorfile.Rows[row].Cells["pPosCommand"].Value = UserText.ProfileMovementRelative;
                }
                else
                {
                    //絶対値移動
                    grdPorfile.Rows[row].Cells["pPosCommand"].Value = UserText.ProfileMovementAbsolute;
                }

                if (flag.HasFlag(BitField.B_1))
                {
                    //指令位置到達&インポジ
                    grdPorfile.Rows[row].Cells["pMovement"].Value = UserText.ProfileMovementPosInpos;
                }
                else
                {
                    //指令位置到達
                    grdPorfile.Rows[row].Cells["pMovement"].Value = UserText.ProfileMovementPosition;
                }

                grdPorfile.Rows[row].Cells["pRead"].Value = UserText.ProfileMovementRead;
                grdPorfile.Rows[row].Cells["pWrite"].Value = UserText.ProfileMovementWrite;
            }

            PROG_START = UserText.ProgramOperationStart;
            PROG_END = UserText.ProgramOperationStop;

            if (grdPorfile.CurrentRow != null)
            {
                DataGridViewComboBoxCell dgvpcmd = (DataGridViewComboBoxCell)grdPorfile.CurrentRow.Cells["pPosCommand"];
                DataGridViewComboBoxCell dgvpmove = (DataGridViewComboBoxCell)grdPorfile.CurrentRow.Cells["pMovement"];

                if (dgvpcmd.IsInEditMode || dgvpmove.IsInEditMode)
                {
                    grdPorfile.CurrentCell = grdPorfile[0, grdPorfile.CurrentRow.Index];
                }
            } 
        }

        #endregion              
    }
}