namespace Motion_Designer
{
	partial class ParameterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParameterForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripServoMonitor = new System.Windows.Forms.ToolStrip();
            this.btnTabGroup = new System.Windows.Forms.ToolStripButton();
            this.sep1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRead = new System.Windows.Forms.ToolStripButton();
            this.btnWrite = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBatchWrite = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.dgvSetting = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataType = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Input = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Help = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuParameter = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuIncludeWrite = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripServoMonitor2 = new System.Windows.Forms.ToolStrip();
            this.lblAxis = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBack = new System.Windows.Forms.ToolStripButton();
            this.cmbAxis = new System.Windows.Forms.ToolStripComboBox();
            this.btnNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAutoRefresh = new System.Windows.Forms.ToolStripButton();
            this.sepAuto = new System.Windows.Forms.ToolStripSeparator();
            this.pbarAuto = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnHelp = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFileOpen = new System.Windows.Forms.ToolStripButton();
            this.btnFileSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFill = new System.Windows.Forms.ToolStripButton();
            this.btnDefault = new System.Windows.Forms.ToolStripButton();
            this.btnDifference = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.TimerResize = new System.Windows.Forms.Timer(this.components);
            this.toolStripServoMonitor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSetting)).BeginInit();
            this.menuParameter.SuspendLayout();
            this.toolStripServoMonitor2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripServoMonitor
            // 
            resources.ApplyResources(this.toolStripServoMonitor, "toolStripServoMonitor");
            this.toolStripServoMonitor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTabGroup,
            this.sep1,
            this.btnRead,
            this.btnWrite,
            this.toolStripSeparator9,
            this.btnBatchWrite,
            this.toolStripSeparator3,
            this.btnSave,
            this.toolStripSeparator4});
            this.toolStripServoMonitor.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStripServoMonitor.Name = "toolStripServoMonitor";
            this.toolStripServoMonitor.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // btnTabGroup
            // 
            resources.ApplyResources(this.btnTabGroup, "btnTabGroup");
            this.btnTabGroup.Name = "btnTabGroup";
            this.btnTabGroup.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.btnTabGroup.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // sep1
            // 
            this.sep1.Name = "sep1";
            resources.ApplyResources(this.sep1, "sep1");
            // 
            // btnRead
            // 
            resources.ApplyResources(this.btnRead, "btnRead");
            this.btnRead.Name = "btnRead";
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            this.btnRead.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.btnRead.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // btnWrite
            // 
            resources.ApplyResources(this.btnWrite, "btnWrite");
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            this.btnWrite.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.btnWrite.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            resources.ApplyResources(this.toolStripSeparator9, "toolStripSeparator9");
            // 
            // btnBatchWrite
            // 
            resources.ApplyResources(this.btnBatchWrite, "btnBatchWrite");
            this.btnBatchWrite.Name = "btnBatchWrite";
            this.btnBatchWrite.Click += new System.EventHandler(this.btnBatchWrite_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            this.toolStripSeparator3.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.toolStripSeparator3.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.btnSave.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // dgvSetting
            // 
            this.dgvSetting.AllowUserToAddRows = false;
            this.dgvSetting.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvSetting.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSetting.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSetting.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSetting.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.dgvSetting, "dgvSetting");
            this.dgvSetting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSetting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ClassName,
            this.OldValue,
            this.NewValue,
            this.DataType,
            this.Input,
            this.Help});
            this.dgvSetting.ContextMenuStrip = this.menuParameter;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSetting.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvSetting.EnableHeadersVisualStyles = false;
            this.dgvSetting.Name = "dgvSetting";
            this.dgvSetting.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSetting.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvSetting.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvSetting.RowTemplate.Height = 21;
            this.dgvSetting.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSetting.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvSetting.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvSetting_CellBeginEdit);
            this.dgvSetting.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSetting_CellContentClick);
            this.dgvSetting.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSetting_CellContentDoubleClick);
            this.dgvSetting.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSetting_CellEndEdit);
            this.dgvSetting.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSetting_CellEnter);
            this.dgvSetting.CurrentCellChanged += new System.EventHandler(this.dgvSetting_CurrentCellChanged);
            this.dgvSetting.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvSetting_CurrentCellDirtyStateChanged);
            // 
            // ID
            // 
            this.ID.Frozen = true;
            resources.ApplyResources(this.ID, "ID");
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ClassName
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ClassName.DefaultCellStyle = dataGridViewCellStyle3;
            this.ClassName.Frozen = true;
            resources.ApplyResources(this.ClassName, "ClassName");
            this.ClassName.Name = "ClassName";
            this.ClassName.ReadOnly = true;
            this.ClassName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // OldValue
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.OldValue.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.OldValue, "OldValue");
            this.OldValue.Name = "OldValue";
            this.OldValue.ReadOnly = true;
            this.OldValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NewValue
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NewValue.DefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(this.NewValue, "NewValue");
            this.NewValue.Name = "NewValue";
            this.NewValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DataType
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DataType.DefaultCellStyle = dataGridViewCellStyle6;
            this.DataType.FalseValue = "10進表示";
            resources.ApplyResources(this.DataType, "DataType");
            this.DataType.Name = "DataType";
            this.DataType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DataType.TrueValue = "16進表示";
            // 
            // Input
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(1);
            this.Input.DefaultCellStyle = dataGridViewCellStyle7;
            resources.ApplyResources(this.Input, "Input");
            this.Input.Name = "Input";
            this.Input.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Input.Text = "変更";
            // 
            // Help
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.Help.DefaultCellStyle = dataGridViewCellStyle8;
            resources.ApplyResources(this.Help, "Help");
            this.Help.Name = "Help";
            this.Help.ReadOnly = true;
            this.Help.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // menuParameter
            // 
            this.menuParameter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuIncludeWrite});
            this.menuParameter.Name = "menuParameter";
            resources.ApplyResources(this.menuParameter, "menuParameter");
            // 
            // MenuIncludeWrite
            // 
            resources.ApplyResources(this.MenuIncludeWrite, "MenuIncludeWrite");
            this.MenuIncludeWrite.Name = "MenuIncludeWrite";
            this.MenuIncludeWrite.Click += new System.EventHandler(this.btnBatchWrite_Click);
            // 
            // toolStripServoMonitor2
            // 
            this.toolStripServoMonitor2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblAxis,
            this.toolStripSeparator1,
            this.btnBack,
            this.cmbAxis,
            this.btnNext,
            this.toolStripSeparator2,
            this.btnAutoRefresh,
            this.sepAuto,
            this.pbarAuto,
            this.toolStripSeparator7,
            this.btnHelp,
            this.toolStripSeparator8,
            this.btnFileOpen,
            this.btnFileSave,
            this.toolStripSeparator5,
            this.btnFill,
            this.btnDefault,
            this.btnDifference,
            this.toolStripSeparator6});
            this.toolStripServoMonitor2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            resources.ApplyResources(this.toolStripServoMonitor2, "toolStripServoMonitor2");
            this.toolStripServoMonitor2.Name = "toolStripServoMonitor2";
            this.toolStripServoMonitor2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // lblAxis
            // 
            resources.ApplyResources(this.lblAxis, "lblAxis");
            this.lblAxis.BackColor = System.Drawing.SystemColors.Control;
            this.lblAxis.Name = "lblAxis";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // btnBack
            // 
            this.btnBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.btnBack, "btnBack");
            this.btnBack.Name = "btnBack";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // cmbAxis
            // 
            this.cmbAxis.Name = "cmbAxis";
            resources.ApplyResources(this.cmbAxis, "cmbAxis");
            this.cmbAxis.SelectedIndexChanged += new System.EventHandler(this.cmbSelect_SelectedIndexChanged);
            this.cmbAxis.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSelect_KeyDown);
            this.cmbAxis.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbSelect_KeyPress);
            // 
            // btnNext
            // 
            this.btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.btnNext, "btnNext");
            this.btnNext.Name = "btnNext";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // btnAutoRefresh
            // 
            resources.ApplyResources(this.btnAutoRefresh, "btnAutoRefresh");
            this.btnAutoRefresh.Name = "btnAutoRefresh";
            this.btnAutoRefresh.Click += new System.EventHandler(this.btnAutoRefresh_Click);
            this.btnAutoRefresh.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.btnAutoRefresh.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // sepAuto
            // 
            this.sepAuto.Name = "sepAuto";
            resources.ApplyResources(this.sepAuto, "sepAuto");
            this.sepAuto.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.sepAuto.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // pbarAuto
            // 
            resources.ApplyResources(this.pbarAuto, "pbarAuto");
            this.pbarAuto.BackColor = System.Drawing.SystemColors.Control;
            this.pbarAuto.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pbarAuto.Margin = new System.Windows.Forms.Padding(0, 2, 1, 0);
            this.pbarAuto.MarqueeAnimationSpeed = 50;
            this.pbarAuto.Name = "pbarAuto";
            this.pbarAuto.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbarAuto.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.pbarAuto.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            this.toolStripSeparator7.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.toolStripSeparator7.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // btnHelp
            // 
            resources.ApplyResources(this.btnHelp, "btnHelp");
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            this.btnHelp.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.btnHelp.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            resources.ApplyResources(this.toolStripSeparator8, "toolStripSeparator8");
            this.toolStripSeparator8.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.toolStripSeparator8.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // btnFileOpen
            // 
            resources.ApplyResources(this.btnFileOpen, "btnFileOpen");
            this.btnFileOpen.Name = "btnFileOpen";
            this.btnFileOpen.Click += new System.EventHandler(this.btnFileOpen_Click);
            this.btnFileOpen.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.btnFileOpen.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // btnFileSave
            // 
            resources.ApplyResources(this.btnFileSave, "btnFileSave");
            this.btnFileSave.Name = "btnFileSave";
            this.btnFileSave.Click += new System.EventHandler(this.btnFileSave_Click);
            this.btnFileSave.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.btnFileSave.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            this.toolStripSeparator5.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.toolStripSeparator5.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // btnFill
            // 
            resources.ApplyResources(this.btnFill, "btnFill");
            this.btnFill.Name = "btnFill";
            this.btnFill.Click += new System.EventHandler(this.btnFill_Click);
            this.btnFill.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.btnFill.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // btnDefault
            // 
            resources.ApplyResources(this.btnDefault, "btnDefault");
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // btnDifference
            // 
            resources.ApplyResources(this.btnDifference, "btnDifference");
            this.btnDifference.Name = "btnDifference";
            this.btnDifference.Click += new System.EventHandler(this.btnDifference_Click);
            this.btnDifference.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // TimerResize
            // 
            this.TimerResize.Interval = 500;
            this.TimerResize.Tick += new System.EventHandler(this.TimerResize_Tick);
            // 
            // ParameterForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvSetting);
            this.Controls.Add(this.toolStripServoMonitor2);
            this.Controls.Add(this.toolStripServoMonitor);
            this.DoubleBuffered = true;
            this.Name = "ParameterForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ParameterForm_FormClosing);
            this.Load += new System.EventHandler(this.ParameterForm_Load);
            this.Resize += new System.EventHandler(this.ParameterForm_Resize);
            this.toolStripServoMonitor.ResumeLayout(false);
            this.toolStripServoMonitor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSetting)).EndInit();
            this.menuParameter.ResumeLayout(false);
            this.toolStripServoMonitor2.ResumeLayout(false);
            this.toolStripServoMonitor2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStripServoMonitor;
		private System.Windows.Forms.ToolStripButton btnTabGroup;
		private System.Windows.Forms.ToolStripSeparator sep1;
		private System.Windows.Forms.ToolStripButton btnRead;
		private System.Windows.Forms.ToolStripButton btnWrite;
		private System.Windows.Forms.DataGridView dgvSetting;
		private System.Windows.Forms.ToolStripButton btnSave;
		private System.Windows.Forms.ToolStrip toolStripServoMonitor2;
		private System.Windows.Forms.ToolStripLabel lblAxis;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnBack;
		private System.Windows.Forms.ToolStripComboBox cmbAxis;
		private System.Windows.Forms.ToolStripButton btnNext;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton btnFileOpen;
		private System.Windows.Forms.ToolStripButton btnFileSave;
		private System.Windows.Forms.SaveFileDialog SaveFileDialog;
		private System.Windows.Forms.OpenFileDialog OpenFileDialog;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripButton btnFill;
		private System.Windows.Forms.ToolStripButton btnDefault;
		private System.Windows.Forms.ToolStripButton btnDifference;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.Timer TimerResize;
		private System.Windows.Forms.ToolStripButton btnAutoRefresh;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripProgressBar pbarAuto;
		private System.Windows.Forms.ToolStripButton btnHelp;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		private System.Windows.Forms.DataGridViewTextBoxColumn ID;
		private System.Windows.Forms.DataGridViewTextBoxColumn ClassName;
		private System.Windows.Forms.DataGridViewTextBoxColumn OldValue;
		private System.Windows.Forms.DataGridViewTextBoxColumn NewValue;
		private System.Windows.Forms.DataGridViewCheckBoxColumn DataType;
		private System.Windows.Forms.DataGridViewButtonColumn Input;
		private System.Windows.Forms.DataGridViewTextBoxColumn Help;
		private System.Windows.Forms.ToolStripSeparator sepAuto;
        private System.Windows.Forms.ToolStripButton btnBatchWrite;
        private System.Windows.Forms.ContextMenuStrip menuParameter;
        private System.Windows.Forms.ToolStripMenuItem MenuIncludeWrite;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
	}
}