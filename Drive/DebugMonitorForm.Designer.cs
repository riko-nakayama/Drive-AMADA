namespace Motion_Designer
{
	partial class DebugMonitorForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DebugMonitorForm));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			this.toolStripDebugMonitor = new System.Windows.Forms.ToolStrip();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tbtnLogRead = new System.Windows.Forms.ToolStripButton();
			this.tcmbDebug = new System.Windows.Forms.ToolStripComboBox();
			this.tbtnVarAdd = new System.Windows.Forms.ToolStripButton();
			this.tbtnAllAdd = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.tbtnFileOpen = new System.Windows.Forms.ToolStripButton();
			this.tbtnFileSave = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.tbtnDel = new System.Windows.Forms.ToolStripButton();
			this.tbtnUp = new System.Windows.Forms.ToolStripButton();
			this.tbtnDown = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tlblDummy = new System.Windows.Forms.ToolStripLabel();
			this.statusStripDebug = new System.Windows.Forms.StatusStrip();
			this.slblBlink = new System.Windows.Forms.ToolStripStatusLabel();
			this.slblWrite = new System.Windows.Forms.ToolStripStatusLabel();
			this.OpenLogDialog = new System.Windows.Forms.OpenFileDialog();
			this.dgvDebug = new System.Windows.Forms.DataGridView();
			this.VarName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ViewType = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.TimerDebug = new System.Windows.Forms.Timer(this.components);
			this.toolStripDebugMonitor.SuspendLayout();
			this.statusStripDebug.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDebug)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStripDebugMonitor
			// 
			this.toolStripDebugMonitor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.tbtnLogRead,
            this.tcmbDebug,
            this.tbtnVarAdd,
            this.tbtnAllAdd,
            this.toolStripSeparator7,
            this.tbtnFileOpen,
            this.tbtnFileSave,
            this.toolStripSeparator5,
            this.tbtnDel,
            this.tbtnUp,
            this.tbtnDown,
            this.toolStripSeparator2,
            this.tlblDummy});
			this.toolStripDebugMonitor.Location = new System.Drawing.Point(0, 0);
			this.toolStripDebugMonitor.Name = "toolStripDebugMonitor";
			this.toolStripDebugMonitor.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
			this.toolStripDebugMonitor.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStripDebugMonitor.Size = new System.Drawing.Size(784, 28);
			this.toolStripDebugMonitor.TabIndex = 7;
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
			// 
			// tbtnLogRead
			// 
			this.tbtnLogRead.Font = new System.Drawing.Font("メイリオ", 9F);
			this.tbtnLogRead.Image = ((System.Drawing.Image)(resources.GetObject("tbtnLogRead.Image")));
			this.tbtnLogRead.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbtnLogRead.Name = "tbtnLogRead";
			this.tbtnLogRead.Size = new System.Drawing.Size(53, 25);
			this.tbtnLogRead.Text = "MAP";
			this.tbtnLogRead.Click += new System.EventHandler(this.tbtnLogRead_Click);
			// 
			// tcmbDebug
			// 
			this.tcmbDebug.AutoSize = false;
			this.tcmbDebug.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.tcmbDebug.Margin = new System.Windows.Forms.Padding(1);
			this.tcmbDebug.Name = "tcmbDebug";
			this.tcmbDebug.Size = new System.Drawing.Size(200, 26);
			this.tcmbDebug.SelectedIndexChanged += new System.EventHandler(this.tcmbDebug_SelectedIndexChanged);
			this.tcmbDebug.DropDown += new System.EventHandler(this.tcmbDebug_DropDown);
			// 
			// tbtnVarAdd
			// 
			this.tbtnVarAdd.Font = new System.Drawing.Font("メイリオ", 9F);
			this.tbtnVarAdd.Image = ((System.Drawing.Image)(resources.GetObject("tbtnVarAdd.Image")));
			this.tbtnVarAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbtnVarAdd.Name = "tbtnVarAdd";
			this.tbtnVarAdd.Size = new System.Drawing.Size(54, 25);
			this.tbtnVarAdd.Text = "ADD";
			this.tbtnVarAdd.Click += new System.EventHandler(this.tbtnVarAdd_Click);
			// 
			// tbtnAllAdd
			// 
			this.tbtnAllAdd.Font = new System.Drawing.Font("メイリオ", 9F);
			this.tbtnAllAdd.Image = ((System.Drawing.Image)(resources.GetObject("tbtnAllAdd.Image")));
			this.tbtnAllAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbtnAllAdd.Name = "tbtnAllAdd";
			this.tbtnAllAdd.Size = new System.Drawing.Size(50, 25);
			this.tbtnAllAdd.Text = "ALL";
			this.tbtnAllAdd.Click += new System.EventHandler(this.tbtnAllAdd_Click);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(6, 28);
			// 
			// tbtnFileOpen
			// 
			this.tbtnFileOpen.Font = new System.Drawing.Font("メイリオ", 9F);
			this.tbtnFileOpen.Image = ((System.Drawing.Image)(resources.GetObject("tbtnFileOpen.Image")));
			this.tbtnFileOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbtnFileOpen.Name = "tbtnFileOpen";
			this.tbtnFileOpen.Size = new System.Drawing.Size(60, 25);
			this.tbtnFileOpen.Text = "OPEN";
			this.tbtnFileOpen.Click += new System.EventHandler(this.tbtnFileOpen_Click);
			// 
			// tbtnFileSave
			// 
			this.tbtnFileSave.Font = new System.Drawing.Font("メイリオ", 9F);
			this.tbtnFileSave.Image = ((System.Drawing.Image)(resources.GetObject("tbtnFileSave.Image")));
			this.tbtnFileSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbtnFileSave.Name = "tbtnFileSave";
			this.tbtnFileSave.Size = new System.Drawing.Size(59, 25);
			this.tbtnFileSave.Text = "SAVE";
			this.tbtnFileSave.Click += new System.EventHandler(this.tbtnFileSave_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 28);
			// 
			// tbtnDel
			// 
			this.tbtnDel.Image = ((System.Drawing.Image)(resources.GetObject("tbtnDel.Image")));
			this.tbtnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbtnDel.Name = "tbtnDel";
			this.tbtnDel.Size = new System.Drawing.Size(51, 25);
			this.tbtnDel.Text = "DEL";
			this.tbtnDel.Click += new System.EventHandler(this.tbtnDel_Click);
			// 
			// tbtnUp
			// 
			this.tbtnUp.Image = ((System.Drawing.Image)(resources.GetObject("tbtnUp.Image")));
			this.tbtnUp.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbtnUp.Name = "tbtnUp";
			this.tbtnUp.Size = new System.Drawing.Size(44, 25);
			this.tbtnUp.Text = "UP";
			this.tbtnUp.Click += new System.EventHandler(this.tbtnUp_Click);
			// 
			// tbtnDown
			// 
			this.tbtnDown.Image = ((System.Drawing.Image)(resources.GetObject("tbtnDown.Image")));
			this.tbtnDown.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbtnDown.Name = "tbtnDown";
			this.tbtnDown.Size = new System.Drawing.Size(46, 25);
			this.tbtnDown.Text = "DN";
			this.tbtnDown.Click += new System.EventHandler(this.tbtnDown_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
			// 
			// tlblDummy
			// 
			this.tlblDummy.Name = "tlblDummy";
			this.tlblDummy.Size = new System.Drawing.Size(53, 25);
			this.tlblDummy.Text = "dummy";
			this.tlblDummy.Visible = false;
			// 
			// statusStripDebug
			// 
			this.statusStripDebug.AutoSize = false;
			this.statusStripDebug.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slblBlink,
            this.slblWrite});
			this.statusStripDebug.Location = new System.Drawing.Point(0, 337);
			this.statusStripDebug.Name = "statusStripDebug";
			this.statusStripDebug.Size = new System.Drawing.Size(784, 25);
			this.statusStripDebug.TabIndex = 0;
			// 
			// slblBlink
			// 
			this.slblBlink.AutoSize = false;
			this.slblBlink.BackColor = System.Drawing.SystemColors.Control;
			this.slblBlink.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
						| System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
						| System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.slblBlink.Name = "slblBlink";
			this.slblBlink.Size = new System.Drawing.Size(20, 20);
			// 
			// slblWrite
			// 
			this.slblWrite.AutoSize = false;
			this.slblWrite.BackColor = System.Drawing.SystemColors.Control;
			this.slblWrite.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
						| System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
						| System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.slblWrite.Name = "slblWrite";
			this.slblWrite.Size = new System.Drawing.Size(20, 20);
			// 
			// dgvDebug
			// 
			this.dgvDebug.AllowUserToAddRows = false;
			this.dgvDebug.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
			this.dgvDebug.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvDebug.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgvDebug.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvDebug.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvDebug.ColumnHeadersHeight = 25;
			this.dgvDebug.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dgvDebug.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VarName,
            this.Value,
            this.Type,
            this.ViewType,
            this.Address,
            this.comment});
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvDebug.DefaultCellStyle = dataGridViewCellStyle8;
			this.dgvDebug.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvDebug.EnableHeadersVisualStyles = false;
			this.dgvDebug.Location = new System.Drawing.Point(0, 28);
			this.dgvDebug.MultiSelect = false;
			this.dgvDebug.Name = "dgvDebug";
			this.dgvDebug.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle9.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvDebug.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
			this.dgvDebug.RowHeadersWidth = 25;
			this.dgvDebug.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvDebug.RowTemplate.Height = 25;
			this.dgvDebug.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvDebug.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dgvDebug.Size = new System.Drawing.Size(784, 309);
			this.dgvDebug.TabIndex = 8;
			this.dgvDebug.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvDebug_CellBeginEdit);
			this.dgvDebug.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvDebug_PreviewKeyDown);
			this.dgvDebug.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDebug_CellEndEdit);
			this.dgvDebug.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvDebug_CurrentCellDirtyStateChanged);
			// 
			// VarName
			// 
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
			this.VarName.DefaultCellStyle = dataGridViewCellStyle3;
			this.VarName.Frozen = true;
			this.VarName.HeaderText = "name";
			this.VarName.Name = "VarName";
			this.VarName.ReadOnly = true;
			this.VarName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.VarName.Width = 200;
			// 
			// Value
			// 
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.Value.DefaultCellStyle = dataGridViewCellStyle4;
			this.Value.HeaderText = "value";
			this.Value.Name = "Value";
			this.Value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Type
			// 
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.Type.DefaultCellStyle = dataGridViewCellStyle5;
			this.Type.HeaderText = "type";
			this.Type.Name = "Type";
			this.Type.ReadOnly = true;
			this.Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Type.Width = 80;
			// 
			// ViewType
			// 
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.ViewType.DefaultCellStyle = dataGridViewCellStyle6;
			this.ViewType.FalseValue = "dec";
			this.ViewType.HeaderText = "hex";
			this.ViewType.Name = "ViewType";
			this.ViewType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.ViewType.TrueValue = "hex";
			this.ViewType.Width = 80;
			// 
			// Address
			// 
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.Address.DefaultCellStyle = dataGridViewCellStyle7;
			this.Address.HeaderText = "address";
			this.Address.Name = "Address";
			this.Address.ReadOnly = true;
			this.Address.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// comment
			// 
			this.comment.HeaderText = "comment";
			this.comment.Name = "comment";
			this.comment.Width = 180;
			// 
			// TimerDebug
			// 
			this.TimerDebug.Enabled = true;
			this.TimerDebug.Interval = 1000;
			this.TimerDebug.Tick += new System.EventHandler(this.TimerDebug_Tick);
			// 
			// DebugMonitorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 362);
			this.Controls.Add(this.dgvDebug);
			this.Controls.Add(this.toolStripDebugMonitor);
			this.Controls.Add(this.statusStripDebug);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "DebugMonitorForm";
			this.Text = "Debug Monitor";
			this.TopMost = true;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DebugMonitorForm_FormClosing);
			this.toolStripDebugMonitor.ResumeLayout(false);
			this.toolStripDebugMonitor.PerformLayout();
			this.statusStripDebug.ResumeLayout(false);
			this.statusStripDebug.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDebug)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStripDebugMonitor;
		private System.Windows.Forms.ToolStripButton tbtnFileOpen;
		private System.Windows.Forms.ToolStripButton tbtnFileSave;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.StatusStrip statusStripDebug;
		private System.Windows.Forms.OpenFileDialog OpenLogDialog;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tbtnLogRead;
		private System.Windows.Forms.ToolStripComboBox tcmbDebug;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripButton tbtnVarAdd;
		private System.Windows.Forms.DataGridView dgvDebug;
		private System.Windows.Forms.ToolStripLabel tlblDummy;
		private System.Windows.Forms.DataGridViewTextBoxColumn VarName;
		private System.Windows.Forms.DataGridViewTextBoxColumn Value;
		private System.Windows.Forms.DataGridViewTextBoxColumn Type;
		private System.Windows.Forms.DataGridViewCheckBoxColumn ViewType;
		private System.Windows.Forms.DataGridViewTextBoxColumn Address;
		private System.Windows.Forms.DataGridViewTextBoxColumn comment;
		private System.Windows.Forms.SaveFileDialog SaveFileDialog;
		private System.Windows.Forms.OpenFileDialog OpenFileDialog;
		private System.Windows.Forms.Timer TimerDebug;
		private System.Windows.Forms.ToolStripStatusLabel slblBlink;
		private System.Windows.Forms.ToolStripStatusLabel slblWrite;
		private System.Windows.Forms.ToolStripButton tbtnDel;
		private System.Windows.Forms.ToolStripButton tbtnUp;
		private System.Windows.Forms.ToolStripButton tbtnDown;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton tbtnAllAdd;

	}
}