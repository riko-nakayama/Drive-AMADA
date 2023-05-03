namespace Motion_Designer
{
    partial class InspectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InspectionForm));
            this.toolStripInspection = new System.Windows.Forms.ToolStrip();
            this.btnStart = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnModelSet = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCountClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReset = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmbCOMPort = new System.Windows.Forms.ToolStripComboBox();
            this.cmbMotorDir = new System.Windows.Forms.ToolStripComboBox();
            this.TimerResize = new System.Windows.Forms.Timer(this.components);
            this.TimerLogTimeSpan = new System.Windows.Forms.Timer(this.components);
            this.TimerBlink = new System.Windows.Forms.Timer(this.components);
            this.SerialPort = new System.IO.Ports.SerialPort(this.components);
            this.panel1 = new Motion_Designer.DoubleBufferPanel();
            this.doubleBufferTableLayoutPanel4 = new Motion_Designer.DoubleBufferTableLayoutPanel();
            this.gradientLabel14 = new Motion_Designer.GradientLabel();
            this.gradientLabel15 = new Motion_Designer.GradientLabel();
            this.gradientLabel16 = new Motion_Designer.GradientLabel();
            this.lblTrqClutchSwitchTime = new System.Windows.Forms.Label();
            this.lblTrqSuccessCnt = new System.Windows.Forms.Label();
            this.lblTrqTotalCnt = new System.Windows.Forms.Label();
            this.gradientLabel17 = new Motion_Designer.GradientLabel();
            this.doubleBufferTableLayoutPanel3 = new Motion_Designer.DoubleBufferTableLayoutPanel();
            this.gradientLabel11 = new Motion_Designer.GradientLabel();
            this.gradientLabel12 = new Motion_Designer.GradientLabel();
            this.gradientLabel13 = new Motion_Designer.GradientLabel();
            this.lblHSClutchSwitchTime = new System.Windows.Forms.Label();
            this.lblHSSuccessCnt = new System.Windows.Forms.Label();
            this.lblHSTotalCnt = new System.Windows.Forms.Label();
            this.gradientLabel10 = new Motion_Designer.GradientLabel();
            this.LblStatus = new Motion_Designer.GradientLabel();
            this.gradientLabel2 = new Motion_Designer.GradientLabel();
            this.doubleBufferTableLayoutPanel2 = new Motion_Designer.DoubleBufferTableLayoutPanel();
            this.gradientLabel8 = new Motion_Designer.GradientLabel();
            this.gradientLabel9 = new Motion_Designer.GradientLabel();
            this.LblLogTimeSpan = new System.Windows.Forms.Label();
            this.lblCycle = new System.Windows.Forms.Label();
            this.TxtLogMessage = new System.Windows.Forms.RichTextBox();
            this.gradientLabel1 = new Motion_Designer.GradientLabel();
            this.gradientLabel7 = new Motion_Designer.GradientLabel();
            this.doubleBufferTableLayoutPanel1 = new Motion_Designer.DoubleBufferTableLayoutPanel();
            this.gradientLabel6 = new Motion_Designer.GradientLabel();
            this.gradientLabel5 = new Motion_Designer.GradientLabel();
            this.gradientLabel4 = new Motion_Designer.GradientLabel();
            this.lblDir = new System.Windows.Forms.Label();
            this.lblTemp = new System.Windows.Forms.Label();
            this.lblCur = new System.Windows.Forms.Label();
            this.gradientLabel3 = new Motion_Designer.GradientLabel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label27 = new System.Windows.Forms.Label();
            this.lblHighVelocity = new System.Windows.Forms.Label();
            this.lblLowVelocity = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblLowModeConstantDown = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblLowModeDown = new System.Windows.Forms.Label();
            this.lblLowModeConstantUp = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.LblDummy = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblLowModeUp = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblHighModeConstantDown = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblHighModeDown = new System.Windows.Forms.Label();
            this.lblHighModeConstantUp = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblHighModeUp = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkCurSet2 = new System.Windows.Forms.CheckBox();
            this.chkCurSet1 = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblExcitationCur2 = new System.Windows.Forms.Label();
            this.lblExcitationCur1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblComNo = new System.Windows.Forms.Label();
            this.cmbModel = new System.Windows.Forms.ComboBox();
            this.toolStripInspection.SuspendLayout();
            this.panel1.SuspendLayout();
            this.doubleBufferTableLayoutPanel4.SuspendLayout();
            this.doubleBufferTableLayoutPanel3.SuspendLayout();
            this.doubleBufferTableLayoutPanel2.SuspendLayout();
            this.doubleBufferTableLayoutPanel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripInspection
            // 
            this.toolStripInspection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStart,
            this.toolStripSeparator6,
            this.btnStop,
            this.toolStripSeparator1,
            this.btnModelSet,
            this.toolStripSeparator3,
            this.btnCountClear,
            this.toolStripSeparator4,
            this.btnReset,
            this.toolStripSeparator2,
            this.cmbCOMPort,
            this.cmbMotorDir});
            this.toolStripInspection.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStripInspection.Location = new System.Drawing.Point(0, 0);
            this.toolStripInspection.Name = "toolStripInspection";
            this.toolStripInspection.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.toolStripInspection.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripInspection.Size = new System.Drawing.Size(491, 44);
            this.toolStripInspection.TabIndex = 70;
            // 
            // btnStart
            // 
            this.btnStart.AutoSize = false;
            this.btnStart.Font = new System.Drawing.Font("メイリオ", 9F);
            this.btnStart.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.Image")));
            this.btnStart.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(65, 22);
            this.btnStart.Text = "開 始";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            this.btnStart.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.btnStart.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 23);
            // 
            // btnStop
            // 
            this.btnStop.AutoSize = false;
            this.btnStop.Font = new System.Drawing.Font("メイリオ", 9F);
            this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
            this.btnStop.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(65, 22);
            this.btnStop.Text = "停 止";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            this.btnStop.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.btnStop.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // btnModelSet
            // 
            this.btnModelSet.AutoSize = false;
            this.btnModelSet.Font = new System.Drawing.Font("メイリオ", 9F);
            this.btnModelSet.Image = ((System.Drawing.Image)(resources.GetObject("btnModelSet.Image")));
            this.btnModelSet.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModelSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModelSet.Name = "btnModelSet";
            this.btnModelSet.Size = new System.Drawing.Size(65, 22);
            this.btnModelSet.Text = "設 定";
            this.btnModelSet.ToolTipText = "機種設定";
            this.btnModelSet.Click += new System.EventHandler(this.btnModelSet_Click);
            this.btnModelSet.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.btnModelSet.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            // 
            // btnCountClear
            // 
            this.btnCountClear.AutoSize = false;
            this.btnCountClear.Font = new System.Drawing.Font("メイリオ", 9F);
            this.btnCountClear.Image = ((System.Drawing.Image)(resources.GetObject("btnCountClear.Image")));
            this.btnCountClear.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCountClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCountClear.Name = "btnCountClear";
            this.btnCountClear.Size = new System.Drawing.Size(65, 22);
            this.btnCountClear.Text = "ｶｳﾝﾄｸﾘｱ";
            this.btnCountClear.Click += new System.EventHandler(this.btnCountClear_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // btnReset
            // 
            this.btnReset.AutoSize = false;
            this.btnReset.Font = new System.Drawing.Font("メイリオ", 9F);
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(65, 22);
            this.btnReset.Text = "ﾛｸﾞ消去";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            this.btnReset.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.btnReset.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // cmbCOMPort
            // 
            this.cmbCOMPort.AutoSize = false;
            this.cmbCOMPort.Name = "cmbCOMPort";
            this.cmbCOMPort.Size = new System.Drawing.Size(70, 23);
            this.cmbCOMPort.ToolTipText = "励磁電流設定装置の通信ポート番号を設定します。";
            this.cmbCOMPort.SelectedIndexChanged += new System.EventHandler(this.cmbCOMPort_SelectedIndexChanged);
            this.cmbCOMPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbCOMPort_KeyPress);
            // 
            // cmbMotorDir
            // 
            this.cmbMotorDir.AutoSize = false;
            this.cmbMotorDir.IntegralHeight = false;
            this.cmbMotorDir.Items.AddRange(new object[] {
            "上",
            "下"});
            this.cmbMotorDir.Name = "cmbMotorDir";
            this.cmbMotorDir.Size = new System.Drawing.Size(40, 23);
            this.cmbMotorDir.ToolTipText = "モータの設置方向を設定します。";
            this.cmbMotorDir.SelectedIndexChanged += new System.EventHandler(this.cmbMotorDir_SelectedIndexChanged);
            this.cmbMotorDir.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbCOMPort_KeyPress);
            // 
            // TimerResize
            // 
            this.TimerResize.Interval = 500;
            this.TimerResize.Tick += new System.EventHandler(this.TimerResize_Tick);
            // 
            // TimerLogTimeSpan
            // 
            this.TimerLogTimeSpan.Enabled = true;
            this.TimerLogTimeSpan.Tick += new System.EventHandler(this.TimerLogTimeSpan_Tick);
            // 
            // TimerBlink
            // 
            this.TimerBlink.Interval = 500;
            this.TimerBlink.Tick += new System.EventHandler(this.TimerBlink_Tick);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.doubleBufferTableLayoutPanel4);
            this.panel1.Controls.Add(this.gradientLabel17);
            this.panel1.Controls.Add(this.doubleBufferTableLayoutPanel3);
            this.panel1.Controls.Add(this.gradientLabel10);
            this.panel1.Controls.Add(this.LblStatus);
            this.panel1.Controls.Add(this.gradientLabel2);
            this.panel1.Controls.Add(this.doubleBufferTableLayoutPanel2);
            this.panel1.Controls.Add(this.TxtLogMessage);
            this.panel1.Controls.Add(this.gradientLabel1);
            this.panel1.Controls.Add(this.gradientLabel7);
            this.panel1.Controls.Add(this.doubleBufferTableLayoutPanel1);
            this.panel1.Controls.Add(this.gradientLabel3);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.txtBarcode);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.lblComNo);
            this.panel1.Controls.Add(this.cmbModel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 44);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(491, 705);
            this.panel1.TabIndex = 71;
            // 
            // doubleBufferTableLayoutPanel4
            // 
            this.doubleBufferTableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.doubleBufferTableLayoutPanel4.ColumnCount = 3;
            this.doubleBufferTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.doubleBufferTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.doubleBufferTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.doubleBufferTableLayoutPanel4.Controls.Add(this.gradientLabel14, 0, 0);
            this.doubleBufferTableLayoutPanel4.Controls.Add(this.gradientLabel15, 0, 0);
            this.doubleBufferTableLayoutPanel4.Controls.Add(this.gradientLabel16, 0, 0);
            this.doubleBufferTableLayoutPanel4.Controls.Add(this.lblTrqClutchSwitchTime, 2, 1);
            this.doubleBufferTableLayoutPanel4.Controls.Add(this.lblTrqSuccessCnt, 1, 1);
            this.doubleBufferTableLayoutPanel4.Controls.Add(this.lblTrqTotalCnt, 0, 1);
            this.doubleBufferTableLayoutPanel4.Location = new System.Drawing.Point(242, 233);
            this.doubleBufferTableLayoutPanel4.Name = "doubleBufferTableLayoutPanel4";
            this.doubleBufferTableLayoutPanel4.RowCount = 2;
            this.doubleBufferTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.doubleBufferTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.doubleBufferTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.doubleBufferTableLayoutPanel4.Size = new System.Drawing.Size(230, 45);
            this.doubleBufferTableLayoutPanel4.TabIndex = 103;
            // 
            // gradientLabel14
            // 
            this.gradientLabel14.Angle = 90F;
            this.gradientLabel14.BorderColor = System.Drawing.Color.Transparent;
            this.gradientLabel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientLabel14.EndColor = System.Drawing.Color.LightGray;
            this.gradientLabel14.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gradientLabel14.FormatAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel14.IsSpace = false;
            this.gradientLabel14.LineAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel14.Location = new System.Drawing.Point(153, 1);
            this.gradientLabel14.Margin = new System.Windows.Forms.Padding(0);
            this.gradientLabel14.Name = "gradientLabel14";
            this.gradientLabel14.Size = new System.Drawing.Size(76, 20);
            this.gradientLabel14.StartColor = System.Drawing.Color.White;
            this.gradientLabel14.TabIndex = 95;
            this.gradientLabel14.Text = "切替時間[ms]";
            this.gradientLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabel15
            // 
            this.gradientLabel15.Angle = 90F;
            this.gradientLabel15.BorderColor = System.Drawing.Color.Transparent;
            this.gradientLabel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientLabel15.EndColor = System.Drawing.Color.LightGray;
            this.gradientLabel15.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gradientLabel15.FormatAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel15.IsSpace = false;
            this.gradientLabel15.LineAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel15.Location = new System.Drawing.Point(77, 1);
            this.gradientLabel15.Margin = new System.Windows.Forms.Padding(0);
            this.gradientLabel15.Name = "gradientLabel15";
            this.gradientLabel15.Size = new System.Drawing.Size(75, 20);
            this.gradientLabel15.StartColor = System.Drawing.Color.White;
            this.gradientLabel15.TabIndex = 94;
            this.gradientLabel15.Text = "成功 [回]";
            this.gradientLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabel16
            // 
            this.gradientLabel16.Angle = 90F;
            this.gradientLabel16.BorderColor = System.Drawing.Color.Transparent;
            this.gradientLabel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientLabel16.EndColor = System.Drawing.Color.LightGray;
            this.gradientLabel16.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gradientLabel16.FormatAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel16.IsSpace = false;
            this.gradientLabel16.LineAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel16.Location = new System.Drawing.Point(1, 1);
            this.gradientLabel16.Margin = new System.Windows.Forms.Padding(0);
            this.gradientLabel16.Name = "gradientLabel16";
            this.gradientLabel16.Size = new System.Drawing.Size(75, 20);
            this.gradientLabel16.StartColor = System.Drawing.Color.White;
            this.gradientLabel16.TabIndex = 93;
            this.gradientLabel16.Text = "トータル [回]　";
            this.gradientLabel16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTrqClutchSwitchTime
            // 
            this.lblTrqClutchSwitchTime.BackColor = System.Drawing.Color.Black;
            this.lblTrqClutchSwitchTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrqClutchSwitchTime.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrqClutchSwitchTime.ForeColor = System.Drawing.Color.Gray;
            this.lblTrqClutchSwitchTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTrqClutchSwitchTime.Location = new System.Drawing.Point(153, 22);
            this.lblTrqClutchSwitchTime.Margin = new System.Windows.Forms.Padding(0);
            this.lblTrqClutchSwitchTime.Name = "lblTrqClutchSwitchTime";
            this.lblTrqClutchSwitchTime.Size = new System.Drawing.Size(76, 22);
            this.lblTrqClutchSwitchTime.TabIndex = 98;
            this.lblTrqClutchSwitchTime.Text = "0";
            this.lblTrqClutchSwitchTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTrqSuccessCnt
            // 
            this.lblTrqSuccessCnt.BackColor = System.Drawing.Color.Black;
            this.lblTrqSuccessCnt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrqSuccessCnt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrqSuccessCnt.ForeColor = System.Drawing.Color.Gray;
            this.lblTrqSuccessCnt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTrqSuccessCnt.Location = new System.Drawing.Point(77, 22);
            this.lblTrqSuccessCnt.Margin = new System.Windows.Forms.Padding(0);
            this.lblTrqSuccessCnt.Name = "lblTrqSuccessCnt";
            this.lblTrqSuccessCnt.Size = new System.Drawing.Size(75, 22);
            this.lblTrqSuccessCnt.TabIndex = 96;
            this.lblTrqSuccessCnt.Text = "0";
            this.lblTrqSuccessCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTrqTotalCnt
            // 
            this.lblTrqTotalCnt.BackColor = System.Drawing.Color.Black;
            this.lblTrqTotalCnt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrqTotalCnt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrqTotalCnt.ForeColor = System.Drawing.Color.Gray;
            this.lblTrqTotalCnt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTrqTotalCnt.Location = new System.Drawing.Point(1, 22);
            this.lblTrqTotalCnt.Margin = new System.Windows.Forms.Padding(0);
            this.lblTrqTotalCnt.Name = "lblTrqTotalCnt";
            this.lblTrqTotalCnt.Size = new System.Drawing.Size(75, 22);
            this.lblTrqTotalCnt.TabIndex = 97;
            this.lblTrqTotalCnt.Text = "0";
            this.lblTrqTotalCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabel17
            // 
            this.gradientLabel17.Angle = 90F;
            this.gradientLabel17.BorderColor = System.Drawing.Color.Transparent;
            this.gradientLabel17.EndColor = System.Drawing.Color.DeepSkyBlue;
            this.gradientLabel17.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gradientLabel17.ForeColor = System.Drawing.Color.Navy;
            this.gradientLabel17.FormatAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel17.IsSpace = false;
            this.gradientLabel17.LineAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel17.Location = new System.Drawing.Point(242, 215);
            this.gradientLabel17.Name = "gradientLabel17";
            this.gradientLabel17.Size = new System.Drawing.Size(230, 18);
            this.gradientLabel17.StartColor = System.Drawing.Color.Cyan;
            this.gradientLabel17.TabIndex = 102;
            this.gradientLabel17.Text = "高トルク側クラッチ切替情報";
            this.gradientLabel17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // doubleBufferTableLayoutPanel3
            // 
            this.doubleBufferTableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.doubleBufferTableLayoutPanel3.ColumnCount = 3;
            this.doubleBufferTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.doubleBufferTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.doubleBufferTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.doubleBufferTableLayoutPanel3.Controls.Add(this.gradientLabel11, 0, 0);
            this.doubleBufferTableLayoutPanel3.Controls.Add(this.gradientLabel12, 0, 0);
            this.doubleBufferTableLayoutPanel3.Controls.Add(this.gradientLabel13, 0, 0);
            this.doubleBufferTableLayoutPanel3.Controls.Add(this.lblHSClutchSwitchTime, 2, 1);
            this.doubleBufferTableLayoutPanel3.Controls.Add(this.lblHSSuccessCnt, 1, 1);
            this.doubleBufferTableLayoutPanel3.Controls.Add(this.lblHSTotalCnt, 0, 1);
            this.doubleBufferTableLayoutPanel3.Location = new System.Drawing.Point(10, 233);
            this.doubleBufferTableLayoutPanel3.Name = "doubleBufferTableLayoutPanel3";
            this.doubleBufferTableLayoutPanel3.RowCount = 2;
            this.doubleBufferTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.doubleBufferTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.doubleBufferTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.doubleBufferTableLayoutPanel3.Size = new System.Drawing.Size(230, 45);
            this.doubleBufferTableLayoutPanel3.TabIndex = 101;
            // 
            // gradientLabel11
            // 
            this.gradientLabel11.Angle = 90F;
            this.gradientLabel11.BorderColor = System.Drawing.Color.Transparent;
            this.gradientLabel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientLabel11.EndColor = System.Drawing.Color.LightGray;
            this.gradientLabel11.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gradientLabel11.FormatAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel11.IsSpace = false;
            this.gradientLabel11.LineAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel11.Location = new System.Drawing.Point(153, 1);
            this.gradientLabel11.Margin = new System.Windows.Forms.Padding(0);
            this.gradientLabel11.Name = "gradientLabel11";
            this.gradientLabel11.Size = new System.Drawing.Size(76, 20);
            this.gradientLabel11.StartColor = System.Drawing.Color.White;
            this.gradientLabel11.TabIndex = 95;
            this.gradientLabel11.Text = "切替時間[ms]";
            this.gradientLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabel12
            // 
            this.gradientLabel12.Angle = 90F;
            this.gradientLabel12.BorderColor = System.Drawing.Color.Transparent;
            this.gradientLabel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientLabel12.EndColor = System.Drawing.Color.LightGray;
            this.gradientLabel12.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gradientLabel12.FormatAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel12.IsSpace = false;
            this.gradientLabel12.LineAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel12.Location = new System.Drawing.Point(77, 1);
            this.gradientLabel12.Margin = new System.Windows.Forms.Padding(0);
            this.gradientLabel12.Name = "gradientLabel12";
            this.gradientLabel12.Size = new System.Drawing.Size(75, 20);
            this.gradientLabel12.StartColor = System.Drawing.Color.White;
            this.gradientLabel12.TabIndex = 94;
            this.gradientLabel12.Text = "成功 [回]";
            this.gradientLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabel13
            // 
            this.gradientLabel13.Angle = 90F;
            this.gradientLabel13.BorderColor = System.Drawing.Color.Transparent;
            this.gradientLabel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientLabel13.EndColor = System.Drawing.Color.LightGray;
            this.gradientLabel13.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gradientLabel13.FormatAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel13.IsSpace = false;
            this.gradientLabel13.LineAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel13.Location = new System.Drawing.Point(1, 1);
            this.gradientLabel13.Margin = new System.Windows.Forms.Padding(0);
            this.gradientLabel13.Name = "gradientLabel13";
            this.gradientLabel13.Size = new System.Drawing.Size(75, 20);
            this.gradientLabel13.StartColor = System.Drawing.Color.White;
            this.gradientLabel13.TabIndex = 93;
            this.gradientLabel13.Text = "トータル [回]　　";
            this.gradientLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHSClutchSwitchTime
            // 
            this.lblHSClutchSwitchTime.BackColor = System.Drawing.Color.Black;
            this.lblHSClutchSwitchTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHSClutchSwitchTime.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHSClutchSwitchTime.ForeColor = System.Drawing.Color.Gray;
            this.lblHSClutchSwitchTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblHSClutchSwitchTime.Location = new System.Drawing.Point(153, 22);
            this.lblHSClutchSwitchTime.Margin = new System.Windows.Forms.Padding(0);
            this.lblHSClutchSwitchTime.Name = "lblHSClutchSwitchTime";
            this.lblHSClutchSwitchTime.Size = new System.Drawing.Size(76, 22);
            this.lblHSClutchSwitchTime.TabIndex = 98;
            this.lblHSClutchSwitchTime.Text = "0";
            this.lblHSClutchSwitchTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHSSuccessCnt
            // 
            this.lblHSSuccessCnt.BackColor = System.Drawing.Color.Black;
            this.lblHSSuccessCnt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHSSuccessCnt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHSSuccessCnt.ForeColor = System.Drawing.Color.Gray;
            this.lblHSSuccessCnt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblHSSuccessCnt.Location = new System.Drawing.Point(77, 22);
            this.lblHSSuccessCnt.Margin = new System.Windows.Forms.Padding(0);
            this.lblHSSuccessCnt.Name = "lblHSSuccessCnt";
            this.lblHSSuccessCnt.Size = new System.Drawing.Size(75, 22);
            this.lblHSSuccessCnt.TabIndex = 96;
            this.lblHSSuccessCnt.Text = "0";
            this.lblHSSuccessCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHSTotalCnt
            // 
            this.lblHSTotalCnt.BackColor = System.Drawing.Color.Black;
            this.lblHSTotalCnt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHSTotalCnt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHSTotalCnt.ForeColor = System.Drawing.Color.Gray;
            this.lblHSTotalCnt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblHSTotalCnt.Location = new System.Drawing.Point(1, 22);
            this.lblHSTotalCnt.Margin = new System.Windows.Forms.Padding(0);
            this.lblHSTotalCnt.Name = "lblHSTotalCnt";
            this.lblHSTotalCnt.Size = new System.Drawing.Size(75, 22);
            this.lblHSTotalCnt.TabIndex = 97;
            this.lblHSTotalCnt.Text = "0";
            this.lblHSTotalCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabel10
            // 
            this.gradientLabel10.Angle = 90F;
            this.gradientLabel10.BorderColor = System.Drawing.Color.Transparent;
            this.gradientLabel10.EndColor = System.Drawing.Color.DeepSkyBlue;
            this.gradientLabel10.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gradientLabel10.ForeColor = System.Drawing.Color.Navy;
            this.gradientLabel10.FormatAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel10.IsSpace = false;
            this.gradientLabel10.LineAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel10.Location = new System.Drawing.Point(10, 215);
            this.gradientLabel10.Name = "gradientLabel10";
            this.gradientLabel10.Size = new System.Drawing.Size(230, 18);
            this.gradientLabel10.StartColor = System.Drawing.Color.Cyan;
            this.gradientLabel10.TabIndex = 100;
            this.gradientLabel10.Text = "高速側クラッチ切替情報";
            this.gradientLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblStatus
            // 
            this.LblStatus.Angle = 90F;
            this.LblStatus.BorderColor = System.Drawing.Color.Transparent;
            this.LblStatus.EndColor = System.Drawing.Color.White;
            this.LblStatus.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblStatus.FormatAlignment = System.Drawing.StringAlignment.Center;
            this.LblStatus.IsSpace = false;
            this.LblStatus.LineAlignment = System.Drawing.StringAlignment.Center;
            this.LblStatus.Location = new System.Drawing.Point(10, 369);
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(462, 25);
            this.LblStatus.StartColor = System.Drawing.Color.White;
            this.LblStatus.TabIndex = 99;
            this.LblStatus.Text = "PASS";
            this.LblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabel2
            // 
            this.gradientLabel2.Angle = 90F;
            this.gradientLabel2.BorderColor = System.Drawing.Color.Transparent;
            this.gradientLabel2.EndColor = System.Drawing.Color.DeepSkyBlue;
            this.gradientLabel2.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gradientLabel2.ForeColor = System.Drawing.Color.Navy;
            this.gradientLabel2.FormatAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel2.IsSpace = false;
            this.gradientLabel2.LineAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel2.Location = new System.Drawing.Point(9, 7);
            this.gradientLabel2.Name = "gradientLabel2";
            this.gradientLabel2.Size = new System.Drawing.Size(462, 18);
            this.gradientLabel2.StartColor = System.Drawing.Color.Cyan;
            this.gradientLabel2.TabIndex = 98;
            this.gradientLabel2.Text = "機種情報";
            this.gradientLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // doubleBufferTableLayoutPanel2
            // 
            this.doubleBufferTableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.doubleBufferTableLayoutPanel2.ColumnCount = 2;
            this.doubleBufferTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.doubleBufferTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.doubleBufferTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.doubleBufferTableLayoutPanel2.Controls.Add(this.gradientLabel8, 0, 0);
            this.doubleBufferTableLayoutPanel2.Controls.Add(this.gradientLabel9, 0, 0);
            this.doubleBufferTableLayoutPanel2.Controls.Add(this.LblLogTimeSpan, 1, 1);
            this.doubleBufferTableLayoutPanel2.Controls.Add(this.lblCycle, 0, 1);
            this.doubleBufferTableLayoutPanel2.Location = new System.Drawing.Point(242, 300);
            this.doubleBufferTableLayoutPanel2.Name = "doubleBufferTableLayoutPanel2";
            this.doubleBufferTableLayoutPanel2.RowCount = 2;
            this.doubleBufferTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.doubleBufferTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.doubleBufferTableLayoutPanel2.Size = new System.Drawing.Size(230, 45);
            this.doubleBufferTableLayoutPanel2.TabIndex = 97;
            // 
            // gradientLabel8
            // 
            this.gradientLabel8.Angle = 90F;
            this.gradientLabel8.BorderColor = System.Drawing.Color.Transparent;
            this.gradientLabel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientLabel8.EndColor = System.Drawing.Color.LightGray;
            this.gradientLabel8.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gradientLabel8.FormatAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel8.IsSpace = false;
            this.gradientLabel8.LineAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel8.Location = new System.Drawing.Point(115, 1);
            this.gradientLabel8.Margin = new System.Windows.Forms.Padding(0);
            this.gradientLabel8.Name = "gradientLabel8";
            this.gradientLabel8.Size = new System.Drawing.Size(114, 20);
            this.gradientLabel8.StartColor = System.Drawing.Color.White;
            this.gradientLabel8.TabIndex = 94;
            this.gradientLabel8.Text = "時間";
            this.gradientLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabel9
            // 
            this.gradientLabel9.Angle = 90F;
            this.gradientLabel9.BorderColor = System.Drawing.Color.Transparent;
            this.gradientLabel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientLabel9.EndColor = System.Drawing.Color.LightGray;
            this.gradientLabel9.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gradientLabel9.FormatAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel9.IsSpace = false;
            this.gradientLabel9.LineAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel9.Location = new System.Drawing.Point(1, 1);
            this.gradientLabel9.Margin = new System.Windows.Forms.Padding(0);
            this.gradientLabel9.Name = "gradientLabel9";
            this.gradientLabel9.Size = new System.Drawing.Size(113, 20);
            this.gradientLabel9.StartColor = System.Drawing.Color.White;
            this.gradientLabel9.TabIndex = 93;
            this.gradientLabel9.Text = "サイクル";
            this.gradientLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblLogTimeSpan
            // 
            this.LblLogTimeSpan.BackColor = System.Drawing.Color.Black;
            this.LblLogTimeSpan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblLogTimeSpan.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLogTimeSpan.ForeColor = System.Drawing.Color.Gray;
            this.LblLogTimeSpan.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblLogTimeSpan.Location = new System.Drawing.Point(115, 22);
            this.LblLogTimeSpan.Margin = new System.Windows.Forms.Padding(0);
            this.LblLogTimeSpan.Name = "LblLogTimeSpan";
            this.LblLogTimeSpan.Size = new System.Drawing.Size(114, 22);
            this.LblLogTimeSpan.TabIndex = 96;
            this.LblLogTimeSpan.Text = "00：00：00";
            this.LblLogTimeSpan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCycle
            // 
            this.lblCycle.BackColor = System.Drawing.Color.Black;
            this.lblCycle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCycle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCycle.ForeColor = System.Drawing.Color.Gray;
            this.lblCycle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCycle.Location = new System.Drawing.Point(1, 22);
            this.lblCycle.Margin = new System.Windows.Forms.Padding(0);
            this.lblCycle.Name = "lblCycle";
            this.lblCycle.Size = new System.Drawing.Size(113, 22);
            this.lblCycle.TabIndex = 97;
            this.lblCycle.Text = "000/000";
            this.lblCycle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TxtLogMessage
            // 
            this.TxtLogMessage.BackColor = System.Drawing.Color.White;
            this.TxtLogMessage.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLogMessage.ForeColor = System.Drawing.Color.Black;
            this.TxtLogMessage.Location = new System.Drawing.Point(10, 398);
            this.TxtLogMessage.Margin = new System.Windows.Forms.Padding(0);
            this.TxtLogMessage.Name = "TxtLogMessage";
            this.TxtLogMessage.ReadOnly = true;
            this.TxtLogMessage.Size = new System.Drawing.Size(462, 110);
            this.TxtLogMessage.TabIndex = 96;
            this.TxtLogMessage.Text = "";
            // 
            // gradientLabel1
            // 
            this.gradientLabel1.Angle = 90F;
            this.gradientLabel1.BorderColor = System.Drawing.Color.Transparent;
            this.gradientLabel1.EndColor = System.Drawing.Color.DeepSkyBlue;
            this.gradientLabel1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gradientLabel1.ForeColor = System.Drawing.Color.Navy;
            this.gradientLabel1.FormatAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel1.IsSpace = false;
            this.gradientLabel1.LineAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel1.Location = new System.Drawing.Point(11, 350);
            this.gradientLabel1.Name = "gradientLabel1";
            this.gradientLabel1.Size = new System.Drawing.Size(462, 18);
            this.gradientLabel1.StartColor = System.Drawing.Color.Cyan;
            this.gradientLabel1.TabIndex = 95;
            this.gradientLabel1.Text = "ステータス";
            this.gradientLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabel7
            // 
            this.gradientLabel7.Angle = 90F;
            this.gradientLabel7.BorderColor = System.Drawing.Color.Transparent;
            this.gradientLabel7.EndColor = System.Drawing.Color.DeepSkyBlue;
            this.gradientLabel7.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gradientLabel7.ForeColor = System.Drawing.Color.Navy;
            this.gradientLabel7.FormatAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel7.IsSpace = false;
            this.gradientLabel7.LineAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel7.Location = new System.Drawing.Point(242, 282);
            this.gradientLabel7.Name = "gradientLabel7";
            this.gradientLabel7.Size = new System.Drawing.Size(230, 18);
            this.gradientLabel7.StartColor = System.Drawing.Color.Cyan;
            this.gradientLabel7.TabIndex = 94;
            this.gradientLabel7.Text = "検査情報";
            this.gradientLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // doubleBufferTableLayoutPanel1
            // 
            this.doubleBufferTableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.doubleBufferTableLayoutPanel1.ColumnCount = 3;
            this.doubleBufferTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.doubleBufferTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.doubleBufferTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.doubleBufferTableLayoutPanel1.Controls.Add(this.gradientLabel6, 0, 0);
            this.doubleBufferTableLayoutPanel1.Controls.Add(this.gradientLabel5, 0, 0);
            this.doubleBufferTableLayoutPanel1.Controls.Add(this.gradientLabel4, 0, 0);
            this.doubleBufferTableLayoutPanel1.Controls.Add(this.lblDir, 2, 1);
            this.doubleBufferTableLayoutPanel1.Controls.Add(this.lblTemp, 1, 1);
            this.doubleBufferTableLayoutPanel1.Controls.Add(this.lblCur, 0, 1);
            this.doubleBufferTableLayoutPanel1.Location = new System.Drawing.Point(10, 300);
            this.doubleBufferTableLayoutPanel1.Name = "doubleBufferTableLayoutPanel1";
            this.doubleBufferTableLayoutPanel1.RowCount = 2;
            this.doubleBufferTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.doubleBufferTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.doubleBufferTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.doubleBufferTableLayoutPanel1.Size = new System.Drawing.Size(230, 45);
            this.doubleBufferTableLayoutPanel1.TabIndex = 93;
            // 
            // gradientLabel6
            // 
            this.gradientLabel6.Angle = 90F;
            this.gradientLabel6.BorderColor = System.Drawing.Color.Transparent;
            this.gradientLabel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientLabel6.EndColor = System.Drawing.Color.LightGray;
            this.gradientLabel6.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gradientLabel6.FormatAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel6.IsSpace = false;
            this.gradientLabel6.LineAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel6.Location = new System.Drawing.Point(153, 1);
            this.gradientLabel6.Margin = new System.Windows.Forms.Padding(0);
            this.gradientLabel6.Name = "gradientLabel6";
            this.gradientLabel6.Size = new System.Drawing.Size(76, 20);
            this.gradientLabel6.StartColor = System.Drawing.Color.White;
            this.gradientLabel6.TabIndex = 95;
            this.gradientLabel6.Text = "回転方向";
            this.gradientLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabel5
            // 
            this.gradientLabel5.Angle = 90F;
            this.gradientLabel5.BorderColor = System.Drawing.Color.Transparent;
            this.gradientLabel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientLabel5.EndColor = System.Drawing.Color.LightGray;
            this.gradientLabel5.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gradientLabel5.FormatAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel5.IsSpace = false;
            this.gradientLabel5.LineAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel5.Location = new System.Drawing.Point(77, 1);
            this.gradientLabel5.Margin = new System.Windows.Forms.Padding(0);
            this.gradientLabel5.Name = "gradientLabel5";
            this.gradientLabel5.Size = new System.Drawing.Size(75, 20);
            this.gradientLabel5.StartColor = System.Drawing.Color.White;
            this.gradientLabel5.TabIndex = 94;
            this.gradientLabel5.Text = "温度 [℃]";
            this.gradientLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabel4
            // 
            this.gradientLabel4.Angle = 90F;
            this.gradientLabel4.BorderColor = System.Drawing.Color.Transparent;
            this.gradientLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientLabel4.EndColor = System.Drawing.Color.LightGray;
            this.gradientLabel4.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gradientLabel4.FormatAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel4.IsSpace = false;
            this.gradientLabel4.LineAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel4.Location = new System.Drawing.Point(1, 1);
            this.gradientLabel4.Margin = new System.Windows.Forms.Padding(0);
            this.gradientLabel4.Name = "gradientLabel4";
            this.gradientLabel4.Size = new System.Drawing.Size(75, 20);
            this.gradientLabel4.StartColor = System.Drawing.Color.White;
            this.gradientLabel4.TabIndex = 93;
            this.gradientLabel4.Text = "電流[A]";
            this.gradientLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDir
            // 
            this.lblDir.BackColor = System.Drawing.Color.Black;
            this.lblDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDir.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDir.ForeColor = System.Drawing.Color.Gray;
            this.lblDir.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDir.Location = new System.Drawing.Point(153, 22);
            this.lblDir.Margin = new System.Windows.Forms.Padding(0);
            this.lblDir.Name = "lblDir";
            this.lblDir.Size = new System.Drawing.Size(76, 22);
            this.lblDir.TabIndex = 98;
            this.lblDir.Text = "-";
            this.lblDir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTemp
            // 
            this.lblTemp.BackColor = System.Drawing.Color.Black;
            this.lblTemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTemp.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemp.ForeColor = System.Drawing.Color.Gray;
            this.lblTemp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTemp.Location = new System.Drawing.Point(77, 22);
            this.lblTemp.Margin = new System.Windows.Forms.Padding(0);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(75, 22);
            this.lblTemp.TabIndex = 96;
            this.lblTemp.Text = "0";
            this.lblTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCur
            // 
            this.lblCur.BackColor = System.Drawing.Color.Black;
            this.lblCur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCur.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCur.ForeColor = System.Drawing.Color.Gray;
            this.lblCur.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCur.Location = new System.Drawing.Point(1, 22);
            this.lblCur.Margin = new System.Windows.Forms.Padding(0);
            this.lblCur.Name = "lblCur";
            this.lblCur.Size = new System.Drawing.Size(75, 22);
            this.lblCur.TabIndex = 97;
            this.lblCur.Text = "0";
            this.lblCur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientLabel3
            // 
            this.gradientLabel3.Angle = 90F;
            this.gradientLabel3.BorderColor = System.Drawing.Color.Transparent;
            this.gradientLabel3.EndColor = System.Drawing.Color.DeepSkyBlue;
            this.gradientLabel3.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gradientLabel3.ForeColor = System.Drawing.Color.Navy;
            this.gradientLabel3.FormatAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel3.IsSpace = false;
            this.gradientLabel3.LineAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel3.Location = new System.Drawing.Point(10, 282);
            this.gradientLabel3.Name = "gradientLabel3";
            this.gradientLabel3.Size = new System.Drawing.Size(230, 18);
            this.gradientLabel3.StartColor = System.Drawing.Color.Cyan;
            this.gradientLabel3.TabIndex = 92;
            this.gradientLabel3.Text = "モータ情報";
            this.gradientLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label27);
            this.groupBox4.Controls.Add(this.lblHighVelocity);
            this.groupBox4.Controls.Add(this.lblLowVelocity);
            this.groupBox4.Controls.Add(this.label31);
            this.groupBox4.Controls.Add(this.label33);
            this.groupBox4.Controls.Add(this.label34);
            this.groupBox4.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox4.Location = new System.Drawing.Point(9, 62);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(195, 72);
            this.groupBox4.TabIndex = 86;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "回転速度";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label27.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label27.Location = new System.Drawing.Point(12, 24);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(35, 17);
            this.label27.TabIndex = 74;
            this.label27.Text = "低速:";
            // 
            // lblHighVelocity
            // 
            this.lblHighVelocity.BackColor = System.Drawing.Color.White;
            this.lblHighVelocity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHighVelocity.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighVelocity.ForeColor = System.Drawing.Color.Black;
            this.lblHighVelocity.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblHighVelocity.Location = new System.Drawing.Point(51, 44);
            this.lblHighVelocity.Name = "lblHighVelocity";
            this.lblHighVelocity.Size = new System.Drawing.Size(90, 20);
            this.lblHighVelocity.TabIndex = 76;
            this.lblHighVelocity.Text = "0";
            this.lblHighVelocity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLowVelocity
            // 
            this.lblLowVelocity.BackColor = System.Drawing.Color.White;
            this.lblLowVelocity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLowVelocity.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowVelocity.ForeColor = System.Drawing.Color.Black;
            this.lblLowVelocity.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLowVelocity.Location = new System.Drawing.Point(51, 21);
            this.lblLowVelocity.Name = "lblLowVelocity";
            this.lblLowVelocity.Size = new System.Drawing.Size(90, 20);
            this.lblLowVelocity.TabIndex = 77;
            this.lblLowVelocity.Text = "0";
            this.lblLowVelocity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label31.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label31.Location = new System.Drawing.Point(12, 46);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(35, 17);
            this.label31.TabIndex = 75;
            this.label31.Text = "高速:";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label33.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label33.Location = new System.Drawing.Point(144, 25);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(41, 17);
            this.label33.TabIndex = 78;
            this.label33.Text = "[rpm]";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label34.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label34.Location = new System.Drawing.Point(144, 47);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(41, 17);
            this.label34.TabIndex = 79;
            this.label34.Text = "[rpm]";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblLowModeConstantDown);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.lblLowModeDown);
            this.groupBox3.Controls.Add(this.lblLowModeConstantUp);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.label26);
            this.groupBox3.Controls.Add(this.LblDummy);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.lblLowModeUp);
            this.groupBox3.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox3.Location = new System.Drawing.Point(242, 136);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(230, 73);
            this.groupBox3.TabIndex = 83;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "低速モード監視";
            // 
            // lblLowModeConstantDown
            // 
            this.lblLowModeConstantDown.BackColor = System.Drawing.Color.White;
            this.lblLowModeConstantDown.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLowModeConstantDown.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowModeConstantDown.ForeColor = System.Drawing.Color.Black;
            this.lblLowModeConstantDown.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLowModeConstantDown.Location = new System.Drawing.Point(78, 45);
            this.lblLowModeConstantDown.Name = "lblLowModeConstantDown";
            this.lblLowModeConstantDown.Size = new System.Drawing.Size(116, 20);
            this.lblLowModeConstantDown.TabIndex = 87;
            this.lblLowModeConstantDown.Text = "0";
            this.lblLowModeConstantDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(12, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 17);
            this.label9.TabIndex = 86;
            this.label9.Text = "電流値下限:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(197, 50);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(25, 17);
            this.label16.TabIndex = 88;
            this.label16.Text = "[A]";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(190, 77);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(25, 17);
            this.label18.TabIndex = 82;
            this.label18.Text = "[A]";
            // 
            // lblLowModeDown
            // 
            this.lblLowModeDown.BackColor = System.Drawing.Color.White;
            this.lblLowModeDown.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLowModeDown.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblLowModeDown.ForeColor = System.Drawing.Color.Black;
            this.lblLowModeDown.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLowModeDown.Location = new System.Drawing.Point(123, 78);
            this.lblLowModeDown.Name = "lblLowModeDown";
            this.lblLowModeDown.Size = new System.Drawing.Size(90, 20);
            this.lblLowModeDown.TabIndex = 81;
            this.lblLowModeDown.Text = "0";
            this.lblLowModeDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLowModeConstantUp
            // 
            this.lblLowModeConstantUp.BackColor = System.Drawing.Color.White;
            this.lblLowModeConstantUp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLowModeConstantUp.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowModeConstantUp.ForeColor = System.Drawing.Color.Black;
            this.lblLowModeConstantUp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLowModeConstantUp.Location = new System.Drawing.Point(78, 21);
            this.lblLowModeConstantUp.Name = "lblLowModeConstantUp";
            this.lblLowModeConstantUp.Size = new System.Drawing.Size(116, 20);
            this.lblLowModeConstantUp.TabIndex = 77;
            this.lblLowModeConstantUp.Text = "0";
            this.lblLowModeConstantUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label23.Location = new System.Drawing.Point(12, 24);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(90, 17);
            this.label23.TabIndex = 75;
            this.label23.Text = "電流値上限:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label24.Location = new System.Drawing.Point(38, 80);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(79, 17);
            this.label24.TabIndex = 80;
            this.label24.Text = "立下り電流値:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label26.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label26.Location = new System.Drawing.Point(197, 26);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(25, 17);
            this.label26.TabIndex = 79;
            this.label26.Text = "[A]";
            // 
            // LblDummy
            // 
            this.LblDummy.AutoSize = true;
            this.LblDummy.Location = new System.Drawing.Point(159, -11);
            this.LblDummy.Name = "LblDummy";
            this.LblDummy.Size = new System.Drawing.Size(0, 17);
            this.LblDummy.TabIndex = 83;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label19.Location = new System.Drawing.Point(12, 24);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(79, 17);
            this.label19.TabIndex = 74;
            this.label19.Text = "立上り電流値:";
            // 
            // lblLowModeUp
            // 
            this.lblLowModeUp.BackColor = System.Drawing.Color.White;
            this.lblLowModeUp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLowModeUp.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblLowModeUp.ForeColor = System.Drawing.Color.Black;
            this.lblLowModeUp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLowModeUp.Location = new System.Drawing.Point(120, 77);
            this.lblLowModeUp.Name = "lblLowModeUp";
            this.lblLowModeUp.Size = new System.Drawing.Size(90, 20);
            this.lblLowModeUp.TabIndex = 76;
            this.lblLowModeUp.Text = "0";
            this.lblLowModeUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLowModeUp.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblHighModeConstantDown);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.lblHighModeDown);
            this.groupBox2.Controls.Add(this.lblHighModeConstantUp);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.lblHighModeUp);
            this.groupBox2.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox2.Location = new System.Drawing.Point(9, 137);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(230, 72);
            this.groupBox2.TabIndex = 74;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "高速モード監視";
            // 
            // lblHighModeConstantDown
            // 
            this.lblHighModeConstantDown.BackColor = System.Drawing.Color.White;
            this.lblHighModeConstantDown.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHighModeConstantDown.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighModeConstantDown.ForeColor = System.Drawing.Color.Black;
            this.lblHighModeConstantDown.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblHighModeConstantDown.Location = new System.Drawing.Point(77, 45);
            this.lblHighModeConstantDown.Name = "lblHighModeConstantDown";
            this.lblHighModeConstantDown.Size = new System.Drawing.Size(117, 20);
            this.lblHighModeConstantDown.TabIndex = 84;
            this.lblHighModeConstantDown.Text = "0";
            this.lblHighModeConstantDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 83;
            this.label2.Text = "電流値下限:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(197, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 17);
            this.label8.TabIndex = 85;
            this.label8.Text = "[A]";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(190, 79);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(25, 17);
            this.label15.TabIndex = 82;
            this.label15.Text = "[A]";
            // 
            // lblHighModeDown
            // 
            this.lblHighModeDown.BackColor = System.Drawing.Color.White;
            this.lblHighModeDown.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHighModeDown.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblHighModeDown.ForeColor = System.Drawing.Color.Black;
            this.lblHighModeDown.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblHighModeDown.Location = new System.Drawing.Point(97, 75);
            this.lblHighModeDown.Name = "lblHighModeDown";
            this.lblHighModeDown.Size = new System.Drawing.Size(90, 20);
            this.lblHighModeDown.TabIndex = 81;
            this.lblHighModeDown.Text = "0";
            this.lblHighModeDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHighModeConstantUp
            // 
            this.lblHighModeConstantUp.BackColor = System.Drawing.Color.White;
            this.lblHighModeConstantUp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHighModeConstantUp.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighModeConstantUp.ForeColor = System.Drawing.Color.Black;
            this.lblHighModeConstantUp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblHighModeConstantUp.Location = new System.Drawing.Point(77, 21);
            this.lblHighModeConstantUp.Name = "lblHighModeConstantUp";
            this.lblHighModeConstantUp.Size = new System.Drawing.Size(117, 20);
            this.lblHighModeConstantUp.TabIndex = 77;
            this.lblHighModeConstantUp.Text = "0";
            this.lblHighModeConstantUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(12, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 17);
            this.label13.TabIndex = 75;
            this.label13.Text = "電流値上限:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(12, 77);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(79, 17);
            this.label17.TabIndex = 80;
            this.label17.Text = "立下り電流値:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(197, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 17);
            this.label6.TabIndex = 78;
            this.label6.Text = "[A]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(197, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 17);
            this.label5.TabIndex = 79;
            this.label5.Text = "[A]";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(12, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 17);
            this.label14.TabIndex = 74;
            this.label14.Text = "立上り電流値:";
            // 
            // lblHighModeUp
            // 
            this.lblHighModeUp.BackColor = System.Drawing.Color.White;
            this.lblHighModeUp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHighModeUp.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblHighModeUp.ForeColor = System.Drawing.Color.Black;
            this.lblHighModeUp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblHighModeUp.Location = new System.Drawing.Point(104, 21);
            this.lblHighModeUp.Name = "lblHighModeUp";
            this.lblHighModeUp.Size = new System.Drawing.Size(90, 20);
            this.lblHighModeUp.TabIndex = 76;
            this.lblHighModeUp.Text = "0";
            this.lblHighModeUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtBarcode.ForeColor = System.Drawing.Color.Black;
            this.txtBarcode.Location = new System.Drawing.Point(337, 34);
            this.txtBarcode.MaxLength = 20;
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(134, 25);
            this.txtBarcode.TabIndex = 12;
            this.txtBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBarcode.TextChanged += new System.EventHandler(this.txtBarcode_TextChanged);
            this.txtBarcode.MouseEnter += new System.EventHandler(this.txtBarcode_MouseEnter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(271, 37);
            this.label7.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "バーコード:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkCurSet2);
            this.groupBox1.Controls.Add(this.chkCurSet1);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lblExcitationCur2);
            this.groupBox1.Controls.Add(this.lblExcitationCur1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.Location = new System.Drawing.Point(207, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 72);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "励磁電流";
            // 
            // chkCurSet2
            // 
            this.chkCurSet2.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkCurSet2.BackColor = System.Drawing.Color.Gainsboro;
            this.chkCurSet2.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.chkCurSet2.Location = new System.Drawing.Point(187, 45);
            this.chkCurSet2.Name = "chkCurSet2";
            this.chkCurSet2.Size = new System.Drawing.Size(68, 25);
            this.chkCurSet2.TabIndex = 75;
            this.chkCurSet2.Text = "励磁OFF";
            this.chkCurSet2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCurSet2.UseVisualStyleBackColor = true;
            this.chkCurSet2.CheckedChanged += new System.EventHandler(this.chkCurSet2_CheckedChanged);
            this.chkCurSet2.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.chkCurSet2.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // chkCurSet1
            // 
            this.chkCurSet1.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkCurSet1.BackColor = System.Drawing.Color.Gainsboro;
            this.chkCurSet1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.chkCurSet1.Location = new System.Drawing.Point(187, 18);
            this.chkCurSet1.Name = "chkCurSet1";
            this.chkCurSet1.Size = new System.Drawing.Size(68, 25);
            this.chkCurSet1.TabIndex = 74;
            this.chkCurSet1.Text = "励磁OFF";
            this.chkCurSet1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCurSet1.UseVisualStyleBackColor = true;
            this.chkCurSet1.CheckedChanged += new System.EventHandler(this.chkCurSet1_CheckedChanged);
            this.chkCurSet1.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.chkCurSet1.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(155, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 17);
            this.label11.TabIndex = 73;
            this.label11.Text = "[A]";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(155, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 17);
            this.label10.TabIndex = 72;
            this.label10.Text = "[A]";
            // 
            // lblExcitationCur2
            // 
            this.lblExcitationCur2.BackColor = System.Drawing.Color.White;
            this.lblExcitationCur2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblExcitationCur2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExcitationCur2.ForeColor = System.Drawing.Color.Black;
            this.lblExcitationCur2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblExcitationCur2.Location = new System.Drawing.Point(62, 44);
            this.lblExcitationCur2.Name = "lblExcitationCur2";
            this.lblExcitationCur2.Size = new System.Drawing.Size(90, 20);
            this.lblExcitationCur2.TabIndex = 16;
            this.lblExcitationCur2.Text = "0";
            this.lblExcitationCur2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblExcitationCur1
            // 
            this.lblExcitationCur1.BackColor = System.Drawing.Color.White;
            this.lblExcitationCur1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblExcitationCur1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExcitationCur1.ForeColor = System.Drawing.Color.Black;
            this.lblExcitationCur1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblExcitationCur1.Location = new System.Drawing.Point(62, 21);
            this.lblExcitationCur1.Name = "lblExcitationCur1";
            this.lblExcitationCur1.Size = new System.Drawing.Size(90, 20);
            this.lblExcitationCur1.TabIndex = 15;
            this.lblExcitationCur1.Text = "0";
            this.lblExcitationCur1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(12, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "設定２:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(12, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "設定１:";
            // 
            // lblComNo
            // 
            this.lblComNo.AutoSize = true;
            this.lblComNo.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblComNo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblComNo.Location = new System.Drawing.Point(12, 35);
            this.lblComNo.Name = "lblComNo";
            this.lblComNo.Size = new System.Drawing.Size(74, 17);
            this.lblComNo.TabIndex = 8;
            this.lblComNo.Text = "モータ型式：";
            // 
            // cmbModel
            // 
            this.cmbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModel.DropDownWidth = 180;
            this.cmbModel.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbModel.FormattingEnabled = true;
            this.cmbModel.Location = new System.Drawing.Point(86, 32);
            this.cmbModel.Name = "cmbModel";
            this.cmbModel.Size = new System.Drawing.Size(172, 25);
            this.cmbModel.TabIndex = 7;
            this.cmbModel.TabStop = false;
            this.cmbModel.SelectedIndexChanged += new System.EventHandler(this.cmbModel_SelectedIndexChanged);
            this.cmbModel.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.cmbModel.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // InspectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(491, 749);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStripInspection);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InspectionForm";
            this.Text = "負荷試験";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InspectionForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InspectionForm_FormClosed);
            this.Load += new System.EventHandler(this.InspectionForm_Load);
            this.Shown += new System.EventHandler(this.InspectionForm_Shown);
            this.Resize += new System.EventHandler(this.InspectionForm_Resize);
            this.toolStripInspection.ResumeLayout(false);
            this.toolStripInspection.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.doubleBufferTableLayoutPanel4.ResumeLayout(false);
            this.doubleBufferTableLayoutPanel3.ResumeLayout(false);
            this.doubleBufferTableLayoutPanel2.ResumeLayout(false);
            this.doubleBufferTableLayoutPanel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripInspection;
        private System.Windows.Forms.ToolStripButton btnStart;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private DoubleBufferPanel panel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnModelSet;
        private System.Windows.Forms.Timer TimerResize;
        private System.Windows.Forms.ComboBox cmbModel;
        private System.Windows.Forms.Label lblComNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblExcitationCur2;
        private System.Windows.Forms.Label lblExcitationCur1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblLowModeUp;
        private System.Windows.Forms.Label lblLowModeDown;
        private System.Windows.Forms.Label lblLowModeConstantUp;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblHighModeUp;
        private System.Windows.Forms.Label lblHighModeDown;
        private System.Windows.Forms.Label lblHighModeConstantUp;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label lblHighVelocity;
        private System.Windows.Forms.Label lblLowVelocity;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.CheckBox chkCurSet2;
        private System.Windows.Forms.CheckBox chkCurSet1;
        private DoubleBufferTableLayoutPanel doubleBufferTableLayoutPanel1;
        private GradientLabel gradientLabel6;
        private GradientLabel gradientLabel5;
        private GradientLabel gradientLabel4;
        private GradientLabel gradientLabel3;
        private System.Windows.Forms.ToolStripButton btnReset;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.RichTextBox TxtLogMessage;
        private GradientLabel gradientLabel1;
        private GradientLabel gradientLabel7;
        private System.Windows.Forms.Label lblCur;
        private System.Windows.Forms.Label lblTemp;
        private System.Windows.Forms.Label lblDir;
        private DoubleBufferTableLayoutPanel doubleBufferTableLayoutPanel2;
        private GradientLabel gradientLabel8;
        private GradientLabel gradientLabel9;
        private System.Windows.Forms.Label LblLogTimeSpan;
        private System.Windows.Forms.Label lblCycle;
        private GradientLabel gradientLabel2;
        private System.Windows.Forms.Label LblDummy;
        private System.Windows.Forms.Timer TimerLogTimeSpan;
        private System.Windows.Forms.Timer TimerBlink;
        private GradientLabel LblStatus;
        private System.Windows.Forms.ToolStripComboBox cmbCOMPort;
        private System.IO.Ports.SerialPort SerialPort;
        private System.Windows.Forms.ToolStripComboBox cmbMotorDir;
        private System.Windows.Forms.Label lblHighModeConstantDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblLowModeConstantDown;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label16;
        private DoubleBufferTableLayoutPanel doubleBufferTableLayoutPanel4;
        private GradientLabel gradientLabel14;
        private GradientLabel gradientLabel15;
        private GradientLabel gradientLabel16;
        private System.Windows.Forms.Label lblTrqClutchSwitchTime;
        private System.Windows.Forms.Label lblTrqSuccessCnt;
        private System.Windows.Forms.Label lblTrqTotalCnt;
        private GradientLabel gradientLabel17;
        private DoubleBufferTableLayoutPanel doubleBufferTableLayoutPanel3;
        private GradientLabel gradientLabel11;
        private GradientLabel gradientLabel12;
        private GradientLabel gradientLabel13;
        private System.Windows.Forms.Label lblHSClutchSwitchTime;
        private System.Windows.Forms.Label lblHSSuccessCnt;
        private System.Windows.Forms.Label lblHSTotalCnt;
        private GradientLabel gradientLabel10;
        private System.Windows.Forms.ToolStripButton btnCountClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}