namespace Motion_Designer
{
    partial class frmBasicProgramOperation2
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBasicProgramOperation2));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GridProgram = new System.Windows.Forms.DataGridView();
            this.Step = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pLabel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Command = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.pComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnuStep = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsertCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.sep1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuIns = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDownLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUpLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.panelProgData = new System.Windows.Forms.Panel();
            this.pnlProgramHelp = new System.Windows.Forms.Panel();
            this.richHelpText = new System.Windows.Forms.RichTextBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnPrgRead = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrgSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDownLoad = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUpLoad = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.btnProfileTableset = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.TimerControlStepStatus = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.chkPrgStartEnd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.btnProgramClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.btnProgramSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.btnHelp = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.pnlProgramStep = new System.Windows.Forms.Panel();
            this.gradientLabel2 = new Motion_Designer.GradientLabel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlProgramData = new System.Windows.Forms.Panel();
            this.lblPrograData = new Motion_Designer.GradientLabel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.GridProgram)).BeginInit();
            this.cmnuStep.SuspendLayout();
            this.panelProgData.SuspendLayout();
            this.pnlProgramHelp.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.pnlProgramStep.SuspendLayout();
            this.pnlProgramData.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridProgram
            // 
            this.GridProgram.AllowUserToAddRows = false;
            this.GridProgram.AllowUserToDeleteRows = false;
            this.GridProgram.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Honeydew;
            this.GridProgram.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GridProgram.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridProgram.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.GridProgram.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridProgram.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GridProgram.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GridProgram.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Step,
            this.pLabel,
            this.Command,
            this.pComment});
            this.GridProgram.ContextMenuStrip = this.cmnuStep;
            resources.ApplyResources(this.GridProgram, "GridProgram");
            this.GridProgram.EnableHeadersVisualStyles = false;
            this.GridProgram.Name = "GridProgram";
            this.GridProgram.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.GridProgram.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.GridProgram.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GridProgram.RowTemplate.Height = 20;
            this.GridProgram.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridProgram.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridProgram_CellClick);
            this.GridProgram.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridProgram_CellContentDoubleClick);
            this.GridProgram.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridProgram_CellEnter);
            this.GridProgram.CurrentCellChanged += new System.EventHandler(this.GridProgram_CurrentCellChanged);
            this.GridProgram.CurrentCellDirtyStateChanged += new System.EventHandler(this.GridProgram_CurrentCellDirtyStateChanged);
            this.GridProgram.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.GridProgram_EditingControlShowing);
            // 
            // Step
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Step.DefaultCellStyle = dataGridViewCellStyle3;
            this.Step.FillWeight = 80F;
            resources.ApplyResources(this.Step, "Step");
            this.Step.MaxInputLength = 3;
            this.Step.Name = "Step";
            this.Step.ReadOnly = true;
            this.Step.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // pLabel
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pLabel.DefaultCellStyle = dataGridViewCellStyle4;
            this.pLabel.FillWeight = 80F;
            resources.ApplyResources(this.pLabel, "pLabel");
            this.pLabel.Name = "pLabel";
            this.pLabel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Command
            // 
            this.Command.AutoComplete = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Command.DefaultCellStyle = dataGridViewCellStyle5;
            this.Command.DisplayStyleForCurrentCellOnly = true;
            this.Command.FillWeight = 80F;
            resources.ApplyResources(this.Command, "Command");
            this.Command.Items.AddRange(new object[] {
            "NOP",
            "MOVE_END",
            "MOVE_ST",
            "MOVE_V",
            "MOVE_C",
            "JMP0",
            "JMP_IN",
            "JMP_IN_OFF",
            "JMP_TRQ",
            "JMP_STS",
            "WAIT0",
            "PC_RESET",
            "PC_RST_SP",
            "OUT0",
            "SV_OFF",
            "SV_ON",
            "HOME",
            "P_RESET",
            "AL_RESET",
            "END_P",
            "END_V",
            "END_C",
            "END_OFF",
            "PARA_W"});
            this.Command.Name = "Command";
            // 
            // pComment
            // 
            dataGridViewCellStyle6.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pComment.DefaultCellStyle = dataGridViewCellStyle6;
            this.pComment.FillWeight = 80F;
            resources.ApplyResources(this.pComment, "pComment");
            this.pComment.Name = "pComment";
            this.pComment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cmnuStep
            // 
            this.cmnuStep.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCopy,
            this.mnuCut,
            this.mnuPaste,
            this.mnuInsertCopy,
            this.sep1,
            this.mnuIns,
            this.mnuDel,
            this.toolStripSeparator12,
            this.mnuUndo,
            this.mnuRedo,
            this.toolStripSeparator13,
            this.mnuDownLoad,
            this.mnuUpLoad});
            this.cmnuStep.Name = "cmnuStep";
            resources.ApplyResources(this.cmnuStep, "cmnuStep");
            this.cmnuStep.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmnuStep_ItemClicked);
            // 
            // mnuCopy
            // 
            resources.ApplyResources(this.mnuCopy, "mnuCopy");
            this.mnuCopy.Name = "mnuCopy";
            this.mnuCopy.Tag = "Copy";
            // 
            // mnuCut
            // 
            resources.ApplyResources(this.mnuCut, "mnuCut");
            this.mnuCut.Name = "mnuCut";
            this.mnuCut.Tag = "Cut";
            // 
            // mnuPaste
            // 
            resources.ApplyResources(this.mnuPaste, "mnuPaste");
            this.mnuPaste.Name = "mnuPaste";
            this.mnuPaste.Tag = "Paste";
            // 
            // mnuInsertCopy
            // 
            resources.ApplyResources(this.mnuInsertCopy, "mnuInsertCopy");
            this.mnuInsertCopy.Name = "mnuInsertCopy";
            this.mnuInsertCopy.Tag = "Paste2";
            // 
            // sep1
            // 
            this.sep1.Name = "sep1";
            resources.ApplyResources(this.sep1, "sep1");
            // 
            // mnuIns
            // 
            resources.ApplyResources(this.mnuIns, "mnuIns");
            this.mnuIns.Name = "mnuIns";
            this.mnuIns.Tag = "Insert Row";
            // 
            // mnuDel
            // 
            resources.ApplyResources(this.mnuDel, "mnuDel");
            this.mnuDel.Name = "mnuDel";
            this.mnuDel.Tag = "Delete Row";
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            resources.ApplyResources(this.toolStripSeparator12, "toolStripSeparator12");
            // 
            // mnuUndo
            // 
            resources.ApplyResources(this.mnuUndo, "mnuUndo");
            this.mnuUndo.Name = "mnuUndo";
            this.mnuUndo.Tag = "Undo";
            // 
            // mnuRedo
            // 
            resources.ApplyResources(this.mnuRedo, "mnuRedo");
            this.mnuRedo.Name = "mnuRedo";
            this.mnuRedo.Tag = "Redo";
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            resources.ApplyResources(this.toolStripSeparator13, "toolStripSeparator13");
            // 
            // mnuDownLoad
            // 
            resources.ApplyResources(this.mnuDownLoad, "mnuDownLoad");
            this.mnuDownLoad.Name = "mnuDownLoad";
            this.mnuDownLoad.Tag = "DownLoad";
            // 
            // mnuUpLoad
            // 
            resources.ApplyResources(this.mnuUpLoad, "mnuUpLoad");
            this.mnuUpLoad.Name = "mnuUpLoad";
            this.mnuUpLoad.Tag = "UpLoad";
            // 
            // panelProgData
            // 
            resources.ApplyResources(this.panelProgData, "panelProgData");
            this.panelProgData.BackColor = System.Drawing.SystemColors.Control;
            this.panelProgData.Controls.Add(this.pnlProgramHelp);
            this.panelProgData.Name = "panelProgData";
            // 
            // pnlProgramHelp
            // 
            this.pnlProgramHelp.Controls.Add(this.richHelpText);
            resources.ApplyResources(this.pnlProgramHelp, "pnlProgramHelp");
            this.pnlProgramHelp.Name = "pnlProgramHelp";
            this.pnlProgramHelp.Resize += new System.EventHandler(this.pnlProgramHelp_Resize);
            // 
            // richHelpText
            // 
            this.richHelpText.BackColor = System.Drawing.Color.White;
            this.richHelpText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.richHelpText, "richHelpText");
            this.richHelpText.Name = "richHelpText";
            this.richHelpText.ReadOnly = true;
            this.richHelpText.ShowSelectionMargin = true;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPrgRead,
            this.toolStripSeparator6,
            this.btnPrgSave,
            this.toolStripSeparator1,
            this.btnDownLoad,
            this.toolStripSeparator7,
            this.btnUpLoad,
            this.toolStripSeparator5,
            this.btnExit,
            this.toolStripSeparator9,
            this.btnProfileTableset});
            this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // btnPrgRead
            // 
            this.btnPrgRead.AutoToolTip = false;
            resources.ApplyResources(this.btnPrgRead, "btnPrgRead");
            this.btnPrgRead.Name = "btnPrgRead";
            this.btnPrgRead.Tag = "ファイルからプログラムを読込みます。";
            this.btnPrgRead.Click += new System.EventHandler(this.btnPrgRead_Click);
            this.btnPrgRead.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnPrgRead.MouseHover += new System.EventHandler(this.btn_MouseHover);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // btnPrgSave
            // 
            this.btnPrgSave.AutoToolTip = false;
            resources.ApplyResources(this.btnPrgSave, "btnPrgSave");
            this.btnPrgSave.Name = "btnPrgSave";
            this.btnPrgSave.Tag = "プログラムをファイルへ保存します。";
            this.btnPrgSave.Click += new System.EventHandler(this.btnPrgSave_Click);
            this.btnPrgSave.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnPrgSave.MouseHover += new System.EventHandler(this.btn_MouseHover);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // btnDownLoad
            // 
            this.btnDownLoad.AutoToolTip = false;
            resources.ApplyResources(this.btnDownLoad, "btnDownLoad");
            this.btnDownLoad.Name = "btnDownLoad";
            this.btnDownLoad.Tag = "プログラムをドライバへダウンロードします。";
            this.btnDownLoad.Click += new System.EventHandler(this.btnDownLoad_Click);
            this.btnDownLoad.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnDownLoad.MouseHover += new System.EventHandler(this.btn_MouseHover);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            // 
            // btnUpLoad
            // 
            this.btnUpLoad.AutoToolTip = false;
            resources.ApplyResources(this.btnUpLoad, "btnUpLoad");
            this.btnUpLoad.Name = "btnUpLoad";
            this.btnUpLoad.Tag = "プログラムをドライバからアップロードします。";
            this.btnUpLoad.Click += new System.EventHandler(this.btnUpLoad_Click);
            this.btnUpLoad.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnUpLoad.MouseHover += new System.EventHandler(this.btn_MouseHover);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // btnExit
            // 
            this.btnExit.AutoToolTip = false;
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.Name = "btnExit";
            this.btnExit.Tag = "プログラムを終了します。";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            resources.ApplyResources(this.toolStripSeparator9, "toolStripSeparator9");
            // 
            // btnProfileTableset
            // 
            this.btnProfileTableset.AutoToolTip = false;
            resources.ApplyResources(this.btnProfileTableset, "btnProfileTableset");
            this.btnProfileTableset.Name = "btnProfileTableset";
            this.btnProfileTableset.Tag = "位置決めテーブルの設定を行います。";
            this.btnProfileTableset.Click += new System.EventHandler(this.btnProfileTableset_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "prg";
            this.openFileDialog.FileName = "*.prg";
            resources.ApplyResources(this.openFileDialog, "openFileDialog");
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "prg";
            resources.ApplyResources(this.saveFileDialog, "saveFileDialog");
            // 
            // TimerControlStepStatus
            // 
            this.TimerControlStepStatus.Interval = 500;
            this.TimerControlStepStatus.Tick += new System.EventHandler(this.TimerControlStepStatus_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chkPrgStartEnd,
            this.toolStripSeparator17,
            this.btnProgramClear,
            this.toolStripSeparator18,
            this.btnProgramSave,
            this.toolStripSeparator19,
            this.btnHelp,
            this.toolStripSeparator2});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // chkPrgStartEnd
            // 
            this.chkPrgStartEnd.AutoToolTip = false;
            resources.ApplyResources(this.chkPrgStartEnd, "chkPrgStartEnd");
            this.chkPrgStartEnd.Image = global::Motion_Designer.Properties.Resources.Start;
            this.chkPrgStartEnd.Name = "chkPrgStartEnd";
            this.chkPrgStartEnd.Tag = "プログラムを本アプリケーションで開始／停止を行います。";
            this.chkPrgStartEnd.Click += new System.EventHandler(this.chkPrgStartEnd_Click);
            this.chkPrgStartEnd.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.chkPrgStartEnd.MouseHover += new System.EventHandler(this.btn_MouseHover);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            resources.ApplyResources(this.toolStripSeparator17, "toolStripSeparator17");
            // 
            // btnProgramClear
            // 
            this.btnProgramClear.AutoToolTip = false;
            resources.ApplyResources(this.btnProgramClear, "btnProgramClear");
            this.btnProgramClear.Name = "btnProgramClear";
            this.btnProgramClear.Tag = "設定したプログラムを全てｸﾘｱします。";
            this.btnProgramClear.Click += new System.EventHandler(this.btnProgramClear_Click);
            this.btnProgramClear.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnProgramClear.MouseHover += new System.EventHandler(this.btn_MouseHover);
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            resources.ApplyResources(this.toolStripSeparator18, "toolStripSeparator18");
            // 
            // btnProgramSave
            // 
            this.btnProgramSave.AutoToolTip = false;
            resources.ApplyResources(this.btnProgramSave, "btnProgramSave");
            this.btnProgramSave.Name = "btnProgramSave";
            this.btnProgramSave.Tag = "プログラムをドライバへメモリ保存します。";
            this.btnProgramSave.Click += new System.EventHandler(this.btnProgramSave_Click);
            this.btnProgramSave.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnProgramSave.MouseHover += new System.EventHandler(this.btn_MouseHover);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            resources.ApplyResources(this.toolStripSeparator19, "toolStripSeparator19");
            // 
            // btnHelp
            // 
            resources.ApplyResources(this.btnHelp, "btnHelp");
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // pnlProgramStep
            // 
            this.pnlProgramStep.Controls.Add(this.GridProgram);
            this.pnlProgramStep.Controls.Add(this.gradientLabel2);
            resources.ApplyResources(this.pnlProgramStep, "pnlProgramStep");
            this.pnlProgramStep.Name = "pnlProgramStep";
            // 
            // gradientLabel2
            // 
            this.gradientLabel2.Angle = 180F;
            this.gradientLabel2.BorderColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.gradientLabel2, "gradientLabel2");
            this.gradientLabel2.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(180)))), ((int)(((byte)(230)))));
            this.gradientLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(50)))), ((int)(((byte)(150)))));
            this.gradientLabel2.FormatAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel2.IsSpace = true;
            this.gradientLabel2.LineAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel2.Name = "gradientLabel2";
            this.gradientLabel2.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(250)))));
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // pnlProgramData
            // 
            this.pnlProgramData.Controls.Add(this.panelProgData);
            this.pnlProgramData.Controls.Add(this.lblPrograData);
            resources.ApplyResources(this.pnlProgramData, "pnlProgramData");
            this.pnlProgramData.Name = "pnlProgramData";
            this.pnlProgramData.Resize += new System.EventHandler(this.pnlProgramData_Resize);
            // 
            // lblPrograData
            // 
            this.lblPrograData.Angle = 180F;
            this.lblPrograData.BorderColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblPrograData, "lblPrograData");
            this.lblPrograData.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(180)))), ((int)(((byte)(230)))));
            this.lblPrograData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(50)))), ((int)(((byte)(150)))));
            this.lblPrograData.FormatAlignment = System.Drawing.StringAlignment.Center;
            this.lblPrograData.IsSpace = true;
            this.lblPrograData.LineAlignment = System.Drawing.StringAlignment.Center;
            this.lblPrograData.Name = "lblPrograData";
            this.lblPrograData.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(250)))));
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.splitter2, "splitter2");
            this.splitter2.Name = "splitter2";
            this.splitter2.TabStop = false;
            // 
            // frmBasicProgramOperation2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.pnlProgramData);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlProgramStep);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.toolStrip);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "frmBasicProgramOperation2";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBasicProgramOperation2_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBasicProgramOperation2_FormClosed);
            this.Load += new System.EventHandler(this.frmBasicProgramOperation2_Load);
            this.Shown += new System.EventHandler(this.frmBasicProgramOperation2_Shown);
            this.Resize += new System.EventHandler(this.frmBasicProgramOperation2_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.GridProgram)).EndInit();
            this.cmnuStep.ResumeLayout(false);
            this.panelProgData.ResumeLayout(false);
            this.pnlProgramHelp.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlProgramStep.ResumeLayout(false);
            this.pnlProgramData.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnPrgRead;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnPrgSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton btnDownLoad;
        private System.Windows.Forms.ContextMenuStrip cmnuStep;
        private System.Windows.Forms.ToolStripMenuItem mnuCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuCut;
        private System.Windows.Forms.ToolStripMenuItem mnuPaste;
        private System.Windows.Forms.ToolStripMenuItem mnuInsertCopy;
        private System.Windows.Forms.ToolStripSeparator sep1;
        private System.Windows.Forms.ToolStripMenuItem mnuIns;
        private System.Windows.Forms.ToolStripMenuItem mnuDel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem mnuUndo;
        private System.Windows.Forms.ToolStripMenuItem mnuRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripMenuItem mnuDownLoad;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripButton btnUpLoad;
        private System.Windows.Forms.ToolStripMenuItem mnuUpLoad;
        private System.Windows.Forms.Timer TimerControlStepStatus;
        private System.Windows.Forms.Panel panelProgData;
        private System.Windows.Forms.DataGridView GridProgram;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton chkPrgStartEnd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripButton btnProgramClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
        private System.Windows.Forms.ToolStripButton btnProgramSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        private GradientLabel lblPrograData;
        private GradientLabel gradientLabel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Step;
        private System.Windows.Forms.DataGridViewTextBoxColumn pLabel;
        private System.Windows.Forms.DataGridViewComboBoxColumn Command;
		private System.Windows.Forms.DataGridViewTextBoxColumn pComment;
        private System.Windows.Forms.Panel pnlProgramStep;
        private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel pnlProgramData;
		private System.Windows.Forms.ToolStripButton btnHelp;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.Panel pnlProgramHelp;
		private System.Windows.Forms.RichTextBox richHelpText;
		private System.Windows.Forms.ToolStripButton btnProfileTableset;
    }
}