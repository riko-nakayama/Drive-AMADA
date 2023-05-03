namespace Motion_Designer
{
    partial class ProfileMovementTableForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileMovementTableForm));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			this.lblDummy = new System.Windows.Forms.Label();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.TimerMonitor = new System.Windows.Forms.Timer(this.components);
			this.ToolStripProfileTable = new System.Windows.Forms.ToolStrip();
			this.btnTableRead = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.btnPrgRead = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.btnPrgSave = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnDownLoad = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.btnUpLoad = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.chkPrgStartEnd = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
			this.btnProgramSave = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.grdPorfile = new Motion_Designer.ctlProfileGrid();
			this.pSelect = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.pStep = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.pPosCommand = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.pMovement = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.pPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.pVelocity = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.pAcceleration = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.pDeceleration = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.pRead = new System.Windows.Forms.DataGridViewButtonColumn();
			this.pWrite = new System.Windows.Forms.DataGridViewButtonColumn();
			this.pComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ToolStripProfileTable.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdPorfile)).BeginInit();
			this.SuspendLayout();
			// 
			// lblDummy
			// 
			this.lblDummy.AccessibleDescription = null;
			this.lblDummy.AccessibleName = null;
			resources.ApplyResources(this.lblDummy, "lblDummy");
			this.lblDummy.Font = null;
			this.lblDummy.Name = "lblDummy";
			// 
			// openFileDialog
			// 
			this.openFileDialog.DefaultExt = "prg";
			this.openFileDialog.FileName = "*.prg";
			resources.ApplyResources(this.openFileDialog, "openFileDialog");
			// 
			// ToolStripProfileTable
			// 
			this.ToolStripProfileTable.AccessibleDescription = null;
			this.ToolStripProfileTable.AccessibleName = null;
			resources.ApplyResources(this.ToolStripProfileTable, "ToolStripProfileTable");
			this.ToolStripProfileTable.BackgroundImage = null;
			this.ToolStripProfileTable.Font = null;
			this.ToolStripProfileTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTableRead,
            this.toolStripSeparator4,
            this.btnPrgRead,
            this.toolStripSeparator6,
            this.btnPrgSave,
            this.toolStripSeparator1,
            this.btnDownLoad,
            this.toolStripSeparator7,
            this.btnUpLoad,
            this.toolStripSeparator2,
            this.chkPrgStartEnd,
            this.toolStripSeparator18,
            this.btnProgramSave,
            this.toolStripSeparator3});
			this.ToolStripProfileTable.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			this.ToolStripProfileTable.Name = "ToolStripProfileTable";
			this.ToolStripProfileTable.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.ToolStripProfileTable.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
			this.ToolStripProfileTable.MouseHover += new System.EventHandler(this.btn_MouseHover);
			// 
			// btnTableRead
			// 
			this.btnTableRead.AccessibleDescription = null;
			this.btnTableRead.AccessibleName = null;
			resources.ApplyResources(this.btnTableRead, "btnTableRead");
			this.btnTableRead.AutoToolTip = false;
			this.btnTableRead.BackgroundImage = null;
			this.btnTableRead.Name = "btnTableRead";
			this.btnTableRead.Tag = "";
			this.btnTableRead.MouseHover += new System.EventHandler(this.btn_MouseHover);
			this.btnTableRead.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
			this.btnTableRead.Click += new System.EventHandler(this.btnTableRead_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.AccessibleDescription = null;
			this.toolStripSeparator4.AccessibleName = null;
			resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			// 
			// btnPrgRead
			// 
			this.btnPrgRead.AccessibleDescription = null;
			this.btnPrgRead.AccessibleName = null;
			resources.ApplyResources(this.btnPrgRead, "btnPrgRead");
			this.btnPrgRead.AutoToolTip = false;
			this.btnPrgRead.BackgroundImage = null;
			this.btnPrgRead.Name = "btnPrgRead";
			this.btnPrgRead.Tag = "ファイルからプログラムを読込みます。";
			this.btnPrgRead.MouseHover += new System.EventHandler(this.btn_MouseHover);
			this.btnPrgRead.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
			this.btnPrgRead.Click += new System.EventHandler(this.btnPrgRead_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.AccessibleDescription = null;
			this.toolStripSeparator6.AccessibleName = null;
			resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			// 
			// btnPrgSave
			// 
			this.btnPrgSave.AccessibleDescription = null;
			this.btnPrgSave.AccessibleName = null;
			resources.ApplyResources(this.btnPrgSave, "btnPrgSave");
			this.btnPrgSave.AutoToolTip = false;
			this.btnPrgSave.BackgroundImage = null;
			this.btnPrgSave.Name = "btnPrgSave";
			this.btnPrgSave.Tag = "プログラムをファイルへ保存します。";
			this.btnPrgSave.MouseHover += new System.EventHandler(this.btn_MouseHover);
			this.btnPrgSave.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
			this.btnPrgSave.Click += new System.EventHandler(this.btnPrgSave_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.AccessibleDescription = null;
			this.toolStripSeparator1.AccessibleName = null;
			resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			// 
			// btnDownLoad
			// 
			this.btnDownLoad.AccessibleDescription = null;
			this.btnDownLoad.AccessibleName = null;
			resources.ApplyResources(this.btnDownLoad, "btnDownLoad");
			this.btnDownLoad.AutoToolTip = false;
			this.btnDownLoad.BackgroundImage = null;
			this.btnDownLoad.Name = "btnDownLoad";
			this.btnDownLoad.Tag = "プログラムをドライバへダウンロードします。";
			this.btnDownLoad.MouseHover += new System.EventHandler(this.btn_MouseHover);
			this.btnDownLoad.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
			this.btnDownLoad.Click += new System.EventHandler(this.btnDownLoad_Click);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.AccessibleDescription = null;
			this.toolStripSeparator7.AccessibleName = null;
			resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			// 
			// btnUpLoad
			// 
			this.btnUpLoad.AccessibleDescription = null;
			this.btnUpLoad.AccessibleName = null;
			resources.ApplyResources(this.btnUpLoad, "btnUpLoad");
			this.btnUpLoad.AutoToolTip = false;
			this.btnUpLoad.BackgroundImage = null;
			this.btnUpLoad.Name = "btnUpLoad";
			this.btnUpLoad.Tag = "プログラムをドライバからアップロードします。";
			this.btnUpLoad.MouseHover += new System.EventHandler(this.btn_MouseHover);
			this.btnUpLoad.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
			this.btnUpLoad.Click += new System.EventHandler(this.btnUpLoad_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.AccessibleDescription = null;
			this.toolStripSeparator2.AccessibleName = null;
			resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			// 
			// chkPrgStartEnd
			// 
			this.chkPrgStartEnd.AccessibleDescription = null;
			this.chkPrgStartEnd.AccessibleName = null;
			resources.ApplyResources(this.chkPrgStartEnd, "chkPrgStartEnd");
			this.chkPrgStartEnd.AutoToolTip = false;
			this.chkPrgStartEnd.BackgroundImage = null;
			this.chkPrgStartEnd.Image = global::Motion_Designer.Properties.Resources.Start;
			this.chkPrgStartEnd.Name = "chkPrgStartEnd";
			this.chkPrgStartEnd.Tag = "プログラムを本アプリケーションで開始／停止を行います。";
			this.chkPrgStartEnd.MouseHover += new System.EventHandler(this.btn_MouseHover);
			this.chkPrgStartEnd.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
			this.chkPrgStartEnd.Click += new System.EventHandler(this.chkPrgStartEnd_Click);
			// 
			// toolStripSeparator18
			// 
			this.toolStripSeparator18.AccessibleDescription = null;
			this.toolStripSeparator18.AccessibleName = null;
			resources.ApplyResources(this.toolStripSeparator18, "toolStripSeparator18");
			this.toolStripSeparator18.Name = "toolStripSeparator18";
			// 
			// btnProgramSave
			// 
			this.btnProgramSave.AccessibleDescription = null;
			this.btnProgramSave.AccessibleName = null;
			resources.ApplyResources(this.btnProgramSave, "btnProgramSave");
			this.btnProgramSave.AutoToolTip = false;
			this.btnProgramSave.BackgroundImage = null;
			this.btnProgramSave.Name = "btnProgramSave";
			this.btnProgramSave.Tag = "プログラムをドライバへメモリ保存します。";
			this.btnProgramSave.MouseHover += new System.EventHandler(this.btn_MouseHover);
			this.btnProgramSave.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
			this.btnProgramSave.Click += new System.EventHandler(this.btnProgramSave_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.AccessibleDescription = null;
			this.toolStripSeparator3.AccessibleName = null;
			resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			// 
			// grdPorfile
			// 
			this.grdPorfile.AccessibleDescription = null;
			this.grdPorfile.AccessibleName = null;
			this.grdPorfile.AllowUserToAddRows = false;
			this.grdPorfile.AllowUserToDeleteRows = false;
			this.grdPorfile.AllowUserToResizeColumns = false;
			this.grdPorfile.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.MintCream;
			this.grdPorfile.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			resources.ApplyResources(this.grdPorfile, "grdPorfile");
			this.grdPorfile.BackgroundImage = null;
			this.grdPorfile.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.grdPorfile.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
			this.grdPorfile.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.PowderBlue;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grdPorfile.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.grdPorfile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.grdPorfile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pSelect,
            this.pStep,
            this.pPosCommand,
            this.pMovement,
            this.pPosition,
            this.pVelocity,
            this.pAcceleration,
            this.pDeceleration,
            this.pRead,
            this.pWrite,
            this.pComment});
			this.grdPorfile.EnableHeadersVisualStyles = false;
			this.grdPorfile.Font = null;
			this.grdPorfile.Name = "grdPorfile";
			this.grdPorfile.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle11.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grdPorfile.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
			this.grdPorfile.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.grdPorfile.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("メイリオ", 9F);
			this.grdPorfile.RowTemplate.Height = 25;
			this.grdPorfile.ShowCellToolTips = false;
			this.grdPorfile.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPorfile_CellValueChanged);
			this.grdPorfile.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grdPorfile_CellBeginEdit);
			this.grdPorfile.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.grdPorfile_CellValidating);
			this.grdPorfile.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPorfile_CellEndEdit);
			this.grdPorfile.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPorfile_CellClick);
			this.grdPorfile.CurrentCellDirtyStateChanged += new System.EventHandler(this.grdPorfile_CurrentCellDirtyStateChanged);
			this.grdPorfile.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPorfile_CellEnter);
			this.grdPorfile.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdPorfile_RowHeaderMouseClick);
			this.grdPorfile.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPorfile_CellContentClick);
			// 
			// pSelect
			// 
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("メイリオ", 8.25F);
			this.pSelect.DefaultCellStyle = dataGridViewCellStyle3;
			this.pSelect.FillWeight = 50.92593F;
			resources.ApplyResources(this.pSelect, "pSelect");
			this.pSelect.Name = "pSelect";
			this.pSelect.ReadOnly = true;
			this.pSelect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// pStep
			// 
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("メイリオ", 8.25F);
			this.pStep.DefaultCellStyle = dataGridViewCellStyle4;
			this.pStep.FillWeight = 52.94352F;
			resources.ApplyResources(this.pStep, "pStep");
			this.pStep.Name = "pStep";
			this.pStep.ReadOnly = true;
			this.pStep.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// pPosCommand
			// 
			this.pPosCommand.AutoComplete = false;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("メイリオ", 8.25F);
			this.pPosCommand.DefaultCellStyle = dataGridViewCellStyle5;
			this.pPosCommand.DisplayStyleForCurrentCellOnly = true;
			this.pPosCommand.FillWeight = 109.7354F;
			resources.ApplyResources(this.pPosCommand, "pPosCommand");
			this.pPosCommand.Items.AddRange(new object[] {
            "Absolute",
            "Relative"});
			this.pPosCommand.Name = "pPosCommand";
			// 
			// pMovement
			// 
			this.pMovement.AutoComplete = false;
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("メイリオ", 8.25F);
			this.pMovement.DefaultCellStyle = dataGridViewCellStyle6;
			this.pMovement.DisplayStyleForCurrentCellOnly = true;
			this.pMovement.FillWeight = 173.3204F;
			resources.ApplyResources(this.pMovement, "pMovement");
			this.pMovement.Items.AddRange(new object[] {
            "Position",
            "Position&InPosition"});
			this.pMovement.Name = "pMovement";
			// 
			// pPosition
			// 
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("メイリオ", 8.25F);
			this.pPosition.DefaultCellStyle = dataGridViewCellStyle7;
			this.pPosition.FillWeight = 131.336F;
			resources.ApplyResources(this.pPosition, "pPosition");
			this.pPosition.Name = "pPosition";
			this.pPosition.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// pVelocity
			// 
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.pVelocity.DefaultCellStyle = dataGridViewCellStyle8;
			this.pVelocity.FillWeight = 97.61747F;
			resources.ApplyResources(this.pVelocity, "pVelocity");
			this.pVelocity.Name = "pVelocity";
			this.pVelocity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// pAcceleration
			// 
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle9.Font = new System.Drawing.Font("メイリオ", 8.25F);
			this.pAcceleration.DefaultCellStyle = dataGridViewCellStyle9;
			this.pAcceleration.FillWeight = 97.32936F;
			resources.ApplyResources(this.pAcceleration, "pAcceleration");
			this.pAcceleration.Name = "pAcceleration";
			this.pAcceleration.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// pDeceleration
			// 
			dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle10.Font = new System.Drawing.Font("メイリオ", 8.25F);
			this.pDeceleration.DefaultCellStyle = dataGridViewCellStyle10;
			this.pDeceleration.FillWeight = 97.06792F;
			resources.ApplyResources(this.pDeceleration, "pDeceleration");
			this.pDeceleration.Name = "pDeceleration";
			this.pDeceleration.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// pRead
			// 
			this.pRead.FillWeight = 67.78149F;
			resources.ApplyResources(this.pRead, "pRead");
			this.pRead.Name = "pRead";
			this.pRead.Text = "Read";
			// 
			// pWrite
			// 
			this.pWrite.FillWeight = 69.51363F;
			resources.ApplyResources(this.pWrite, "pWrite");
			this.pWrite.Name = "pWrite";
			this.pWrite.Text = "Write";
			// 
			// pComment
			// 
			this.pComment.FillWeight = 152.4289F;
			resources.ApplyResources(this.pComment, "pComment");
			this.pComment.Name = "pComment";
			this.pComment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// ProfileMovementTableForm
			// 
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = null;
			this.Controls.Add(this.ToolStripProfileTable);
			this.Controls.Add(this.lblDummy);
			this.Controls.Add(this.grdPorfile);
			this.Font = null;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "ProfileMovementTableForm";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.ProfileMovementTableForm_Load);
			this.SizeChanged += new System.EventHandler(this.ProfileMovementTableForm_SizeChanged);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProfileMovementTableForm_FormClosing);
			this.ToolStripProfileTable.ResumeLayout(false);
			this.ToolStripProfileTable.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdPorfile)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private ctlProfileGrid grdPorfile;
        private System.Windows.Forms.Label lblDummy;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Timer TimerMonitor;
        private System.Windows.Forms.ToolStrip ToolStripProfileTable;
        private System.Windows.Forms.ToolStripButton btnPrgRead;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnPrgSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnUpLoad;
        private System.Windows.Forms.ToolStripButton chkPrgStartEnd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
        private System.Windows.Forms.ToolStripButton btnProgramSave;
        private System.Windows.Forms.ToolStripButton btnDownLoad;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnTableRead;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.DataGridViewTextBoxColumn pSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn pStep;
        private System.Windows.Forms.DataGridViewComboBoxColumn pPosCommand;
        private System.Windows.Forms.DataGridViewComboBoxColumn pMovement;
        private System.Windows.Forms.DataGridViewTextBoxColumn pPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn pVelocity;
        private System.Windows.Forms.DataGridViewTextBoxColumn pAcceleration;
        private System.Windows.Forms.DataGridViewTextBoxColumn pDeceleration;
        private System.Windows.Forms.DataGridViewButtonColumn pRead;
        private System.Windows.Forms.DataGridViewButtonColumn pWrite;
        private System.Windows.Forms.DataGridViewTextBoxColumn pComment;
    }
}