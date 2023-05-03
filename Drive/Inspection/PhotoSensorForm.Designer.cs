
namespace Motion_Designer
{
    partial class PhotoSensorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhotoSensorForm));
            this.TimerResize = new System.Windows.Forms.Timer(this.components);
            this.TimerBlink = new System.Windows.Forms.Timer(this.components);
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblComNo = new System.Windows.Forms.Label();
            this.txtMotorType = new System.Windows.Forms.TextBox();
            this.toolStripPhoto = new System.Windows.Forms.ToolStrip();
            this.btnOption = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReset = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.doubleBufferPanel3 = new Motion_Designer.DoubleBufferPanel();
            this.btnStartClutch = new Motion_Designer.GradientButton();
            this.gradientLabel4 = new Motion_Designer.GradientLabel();
            this.doubleBufferPanel2 = new Motion_Designer.DoubleBufferPanel();
            this.btnStartMount = new Motion_Designer.GradientButton();
            this.btnStopMount = new Motion_Designer.GradientButton();
            this.doubleBufferPanel1 = new Motion_Designer.DoubleBufferPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.doubleBufferTableLayoutPanel3 = new Motion_Designer.DoubleBufferTableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.doubleBufferTableLayoutPanel4 = new Motion_Designer.DoubleBufferTableLayoutPanel();
            this.lblHighSpeedCCWVel = new System.Windows.Forms.Label();
            this.lblHighSpeedCWVel = new System.Windows.Forms.Label();
            this.lblHighTorqueCCWVel = new System.Windows.Forms.Label();
            this.lblHighTorqueCWVel = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.doubleBufferTableLayoutPanel2 = new Motion_Designer.DoubleBufferTableLayoutPanel();
            this.label55 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.doubleBufferTableLayoutPanel1 = new Motion_Designer.DoubleBufferTableLayoutPanel();
            this.lblRotationHighVel = new System.Windows.Forms.Label();
            this.lblRotationLowVel = new System.Windows.Forms.Label();
            this.lblTrqHighVelStart = new System.Windows.Forms.Label();
            this.lblTrqLowVelStart = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblRotationHighConti = new System.Windows.Forms.Label();
            this.lblTrqHighVelConti = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblDummy = new System.Windows.Forms.Label();
            this.btnStartAction = new Motion_Designer.GradientButton();
            this.btnStopAction = new Motion_Designer.GradientButton();
            this.gradientLabel3 = new Motion_Designer.GradientLabel();
            this.gradientLabel2 = new Motion_Designer.GradientLabel();
            this.LblStatus = new Motion_Designer.GradientLabel();
            this.gradientLabel1 = new Motion_Designer.GradientLabel();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbModel = new System.Windows.Forms.ComboBox();
            this.toolStripPhoto.SuspendLayout();
            this.doubleBufferPanel3.SuspendLayout();
            this.doubleBufferPanel2.SuspendLayout();
            this.doubleBufferPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.doubleBufferTableLayoutPanel3.SuspendLayout();
            this.doubleBufferTableLayoutPanel4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.doubleBufferTableLayoutPanel2.SuspendLayout();
            this.doubleBufferTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TimerResize
            // 
            this.TimerResize.Interval = 500;
            this.TimerResize.Tick += new System.EventHandler(this.TimerResize_Tick);
            // 
            // TimerBlink
            // 
            this.TimerBlink.Interval = 500;
            this.TimerBlink.Tick += new System.EventHandler(this.TimerBlink_Tick);
            // 
            // txtBarcode
            // 
            this.txtBarcode.BackColor = System.Drawing.Color.White;
            this.txtBarcode.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.ForeColor = System.Drawing.Color.Black;
            this.txtBarcode.Location = new System.Drawing.Point(307, 81);
            this.txtBarcode.MaxLength = 11;
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(163, 25);
            this.txtBarcode.TabIndex = 104;
            this.txtBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBarcode.TextChanged += new System.EventHandler(this.txtBarcode_TextChanged);
            this.txtBarcode.MouseEnter += new System.EventHandler(this.txtBarcode_MouseEnter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(241, 85);
            this.label7.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 17);
            this.label7.TabIndex = 103;
            this.label7.Text = "バーコード:";
            // 
            // lblComNo
            // 
            this.lblComNo.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblComNo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblComNo.Location = new System.Drawing.Point(10, 86);
            this.lblComNo.Name = "lblComNo";
            this.lblComNo.Size = new System.Drawing.Size(74, 17);
            this.lblComNo.TabIndex = 102;
            this.lblComNo.Text = "モータ型式：";
            // 
            // txtMotorType
            // 
            this.txtMotorType.BackColor = System.Drawing.Color.White;
            this.txtMotorType.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotorType.ForeColor = System.Drawing.Color.Black;
            this.txtMotorType.Location = new System.Drawing.Point(79, 81);
            this.txtMotorType.MaxLength = 5;
            this.txtMotorType.Name = "txtMotorType";
            this.txtMotorType.ReadOnly = true;
            this.txtMotorType.Size = new System.Drawing.Size(159, 25);
            this.txtMotorType.TabIndex = 105;
            this.txtMotorType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMotorType.TextChanged += new System.EventHandler(this.txtMotorType_TextChanged);
            // 
            // toolStripPhoto
            // 
            this.toolStripPhoto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOption,
            this.toolStripSeparator3,
            this.btnReset,
            this.toolStripSeparator2});
            this.toolStripPhoto.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStripPhoto.Location = new System.Drawing.Point(0, 0);
            this.toolStripPhoto.Name = "toolStripPhoto";
            this.toolStripPhoto.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.toolStripPhoto.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripPhoto.Size = new System.Drawing.Size(491, 25);
            this.toolStripPhoto.TabIndex = 117;
            // 
            // btnOption
            // 
            this.btnOption.AutoSize = false;
            this.btnOption.Font = new System.Drawing.Font("メイリオ", 9F);
            this.btnOption.Image = ((System.Drawing.Image)(resources.GetObject("btnOption.Image")));
            this.btnOption.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOption.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOption.Name = "btnOption";
            this.btnOption.Size = new System.Drawing.Size(90, 22);
            this.btnOption.Text = "設 定";
            this.btnOption.ToolTipText = "動作設定";
            this.btnOption.Click += new System.EventHandler(this.btnOption_Click);
            this.btnOption.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.btnOption.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            // 
            // btnReset
            // 
            this.btnReset.AutoSize = false;
            this.btnReset.Font = new System.Drawing.Font("メイリオ", 9F);
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(90, 22);
            this.btnReset.Text = "結果消去";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            this.btnReset.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.btnReset.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // doubleBufferPanel3
            // 
            this.doubleBufferPanel3.BackColor = System.Drawing.Color.LightYellow;
            this.doubleBufferPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.doubleBufferPanel3.Controls.Add(this.btnStartClutch);
            this.doubleBufferPanel3.Location = new System.Drawing.Point(8, 491);
            this.doubleBufferPanel3.Name = "doubleBufferPanel3";
            this.doubleBufferPanel3.Size = new System.Drawing.Size(462, 46);
            this.doubleBufferPanel3.TabIndex = 116;
            // 
            // btnStartClutch
            // 
            this.btnStartClutch.Angle = 90F;
            this.btnStartClutch.ClientRectYMargin = 5;
            this.btnStartClutch.EndColor = System.Drawing.Color.LightGray;
            this.btnStartClutch.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnStartClutch.ForeColor = System.Drawing.Color.Navy;
            this.btnStartClutch.Location = new System.Drawing.Point(2, 2);
            this.btnStartClutch.Name = "btnStartClutch";
            this.btnStartClutch.PushEndColor = System.Drawing.Color.White;
            this.btnStartClutch.PushStartColor = System.Drawing.Color.Gold;
            this.btnStartClutch.Size = new System.Drawing.Size(456, 40);
            this.btnStartClutch.StartColor = System.Drawing.Color.White;
            this.btnStartClutch.TabIndex = 111;
            this.btnStartClutch.Text = "開始";
            this.btnStartClutch.UseVisualStyleBackColor = true;
            this.btnStartClutch.Click += new System.EventHandler(this.btnStartClutch_Click);
            // 
            // gradientLabel4
            // 
            this.gradientLabel4.Angle = 90F;
            this.gradientLabel4.BorderColor = System.Drawing.Color.Transparent;
            this.gradientLabel4.EndColor = System.Drawing.Color.DeepSkyBlue;
            this.gradientLabel4.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gradientLabel4.ForeColor = System.Drawing.Color.Navy;
            this.gradientLabel4.FormatAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel4.IsSpace = false;
            this.gradientLabel4.LineAlignment = System.Drawing.StringAlignment.Center;
            this.gradientLabel4.Location = new System.Drawing.Point(8, 473);
            this.gradientLabel4.Name = "gradientLabel4";
            this.gradientLabel4.Size = new System.Drawing.Size(462, 18);
            this.gradientLabel4.StartColor = System.Drawing.Color.Cyan;
            this.gradientLabel4.TabIndex = 115;
            this.gradientLabel4.Text = "クラッチ動作";
            this.gradientLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // doubleBufferPanel2
            // 
            this.doubleBufferPanel2.BackColor = System.Drawing.Color.LightYellow;
            this.doubleBufferPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.doubleBufferPanel2.Controls.Add(this.btnStartMount);
            this.doubleBufferPanel2.Controls.Add(this.btnStopMount);
            this.doubleBufferPanel2.Location = new System.Drawing.Point(8, 129);
            this.doubleBufferPanel2.Name = "doubleBufferPanel2";
            this.doubleBufferPanel2.Size = new System.Drawing.Size(462, 46);
            this.doubleBufferPanel2.TabIndex = 114;
            // 
            // btnStartMount
            // 
            this.btnStartMount.Angle = 90F;
            this.btnStartMount.ClientRectYMargin = 5;
            this.btnStartMount.EndColor = System.Drawing.Color.LightGray;
            this.btnStartMount.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnStartMount.ForeColor = System.Drawing.Color.Navy;
            this.btnStartMount.Location = new System.Drawing.Point(2, 2);
            this.btnStartMount.Name = "btnStartMount";
            this.btnStartMount.PushEndColor = System.Drawing.Color.White;
            this.btnStartMount.PushStartColor = System.Drawing.Color.Gold;
            this.btnStartMount.Size = new System.Drawing.Size(227, 40);
            this.btnStartMount.StartColor = System.Drawing.Color.White;
            this.btnStartMount.TabIndex = 111;
            this.btnStartMount.Text = "開始";
            this.btnStartMount.UseVisualStyleBackColor = true;
            this.btnStartMount.Click += new System.EventHandler(this.btnStartMount_Click);
            // 
            // btnStopMount
            // 
            this.btnStopMount.Angle = 90F;
            this.btnStopMount.ClientRectYMargin = 5;
            this.btnStopMount.EndColor = System.Drawing.Color.LightGray;
            this.btnStopMount.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnStopMount.ForeColor = System.Drawing.Color.Navy;
            this.btnStopMount.Location = new System.Drawing.Point(231, 2);
            this.btnStopMount.Name = "btnStopMount";
            this.btnStopMount.PushEndColor = System.Drawing.Color.White;
            this.btnStopMount.PushStartColor = System.Drawing.Color.Gold;
            this.btnStopMount.Size = new System.Drawing.Size(227, 40);
            this.btnStopMount.StartColor = System.Drawing.Color.White;
            this.btnStopMount.TabIndex = 112;
            this.btnStopMount.Text = "停止";
            this.btnStopMount.UseVisualStyleBackColor = true;
            this.btnStopMount.Click += new System.EventHandler(this.btnStopMount_Click);
            // 
            // doubleBufferPanel1
            // 
            this.doubleBufferPanel1.BackColor = System.Drawing.Color.LightYellow;
            this.doubleBufferPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.doubleBufferPanel1.Controls.Add(this.groupBox1);
            this.doubleBufferPanel1.Controls.Add(this.groupBox3);
            this.doubleBufferPanel1.Controls.Add(this.btnStartAction);
            this.doubleBufferPanel1.Controls.Add(this.btnStopAction);
            this.doubleBufferPanel1.Location = new System.Drawing.Point(8, 198);
            this.doubleBufferPanel1.Name = "doubleBufferPanel1";
            this.doubleBufferPanel1.Size = new System.Drawing.Size(462, 270);
            this.doubleBufferPanel1.TabIndex = 113;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.doubleBufferTableLayoutPanel3);
            this.groupBox1.Controls.Add(this.doubleBufferTableLayoutPanel4);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.Location = new System.Drawing.Point(3, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(454, 94);
            this.groupBox1.TabIndex = 117;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "モータ回転結果 [rpm]";
            // 
            // doubleBufferTableLayoutPanel3
            // 
            this.doubleBufferTableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.doubleBufferTableLayoutPanel3.ColumnCount = 4;
            this.doubleBufferTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.doubleBufferTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.doubleBufferTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.doubleBufferTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.doubleBufferTableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.doubleBufferTableLayoutPanel3.Controls.Add(this.label2, 2, 0);
            this.doubleBufferTableLayoutPanel3.Controls.Add(this.label9, 1, 0);
            this.doubleBufferTableLayoutPanel3.Controls.Add(this.label10, 3, 0);
            this.doubleBufferTableLayoutPanel3.Location = new System.Drawing.Point(13, 24);
            this.doubleBufferTableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.doubleBufferTableLayoutPanel3.Name = "doubleBufferTableLayoutPanel3";
            this.doubleBufferTableLayoutPanel3.RowCount = 1;
            this.doubleBufferTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.doubleBufferTableLayoutPanel3.Size = new System.Drawing.Size(430, 36);
            this.doubleBufferTableLayoutPanel3.TabIndex = 115;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 32);
            this.label1.TabIndex = 26;
            this.label1.Text = "高トルク\r\n（CW） ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(216, 2);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 32);
            this.label2.TabIndex = 28;
            this.label2.Text = "高速回転\r\n（CW）";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.SteelBlue;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(109, 2);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 32);
            this.label9.TabIndex = 27;
            this.label9.Text = "高トルク\r\n（CCW）";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.SteelBlue;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(323, 2);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 32);
            this.label10.TabIndex = 29;
            this.label10.Text = "高速回転\r\n（CCW）";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // doubleBufferTableLayoutPanel4
            // 
            this.doubleBufferTableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.doubleBufferTableLayoutPanel4.ColumnCount = 4;
            this.doubleBufferTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.doubleBufferTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.doubleBufferTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.doubleBufferTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.doubleBufferTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.doubleBufferTableLayoutPanel4.Controls.Add(this.lblHighSpeedCCWVel, 3, 0);
            this.doubleBufferTableLayoutPanel4.Controls.Add(this.lblHighSpeedCWVel, 2, 0);
            this.doubleBufferTableLayoutPanel4.Controls.Add(this.lblHighTorqueCCWVel, 1, 0);
            this.doubleBufferTableLayoutPanel4.Controls.Add(this.lblHighTorqueCWVel, 0, 0);
            this.doubleBufferTableLayoutPanel4.Location = new System.Drawing.Point(13, 60);
            this.doubleBufferTableLayoutPanel4.Name = "doubleBufferTableLayoutPanel4";
            this.doubleBufferTableLayoutPanel4.RowCount = 1;
            this.doubleBufferTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.doubleBufferTableLayoutPanel4.Size = new System.Drawing.Size(429, 28);
            this.doubleBufferTableLayoutPanel4.TabIndex = 84;
            // 
            // lblHighSpeedCCWVel
            // 
            this.lblHighSpeedCCWVel.BackColor = System.Drawing.Color.White;
            this.lblHighSpeedCCWVel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHighSpeedCCWVel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighSpeedCCWVel.ForeColor = System.Drawing.Color.White;
            this.lblHighSpeedCCWVel.Location = new System.Drawing.Point(322, 1);
            this.lblHighSpeedCCWVel.Margin = new System.Windows.Forms.Padding(0);
            this.lblHighSpeedCCWVel.Name = "lblHighSpeedCCWVel";
            this.lblHighSpeedCCWVel.Size = new System.Drawing.Size(106, 26);
            this.lblHighSpeedCCWVel.TabIndex = 115;
            this.lblHighSpeedCCWVel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHighSpeedCWVel
            // 
            this.lblHighSpeedCWVel.BackColor = System.Drawing.Color.White;
            this.lblHighSpeedCWVel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHighSpeedCWVel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighSpeedCWVel.ForeColor = System.Drawing.Color.White;
            this.lblHighSpeedCWVel.Location = new System.Drawing.Point(215, 1);
            this.lblHighSpeedCWVel.Margin = new System.Windows.Forms.Padding(0);
            this.lblHighSpeedCWVel.Name = "lblHighSpeedCWVel";
            this.lblHighSpeedCWVel.Size = new System.Drawing.Size(106, 26);
            this.lblHighSpeedCWVel.TabIndex = 116;
            this.lblHighSpeedCWVel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHighTorqueCCWVel
            // 
            this.lblHighTorqueCCWVel.BackColor = System.Drawing.Color.White;
            this.lblHighTorqueCCWVel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHighTorqueCCWVel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighTorqueCCWVel.ForeColor = System.Drawing.Color.White;
            this.lblHighTorqueCCWVel.Location = new System.Drawing.Point(108, 1);
            this.lblHighTorqueCCWVel.Margin = new System.Windows.Forms.Padding(0);
            this.lblHighTorqueCCWVel.Name = "lblHighTorqueCCWVel";
            this.lblHighTorqueCCWVel.Size = new System.Drawing.Size(106, 26);
            this.lblHighTorqueCCWVel.TabIndex = 116;
            this.lblHighTorqueCCWVel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHighTorqueCWVel
            // 
            this.lblHighTorqueCWVel.BackColor = System.Drawing.Color.White;
            this.lblHighTorqueCWVel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHighTorqueCWVel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighTorqueCWVel.ForeColor = System.Drawing.Color.White;
            this.lblHighTorqueCWVel.Location = new System.Drawing.Point(1, 1);
            this.lblHighTorqueCWVel.Margin = new System.Windows.Forms.Padding(0);
            this.lblHighTorqueCWVel.Name = "lblHighTorqueCWVel";
            this.lblHighTorqueCWVel.Size = new System.Drawing.Size(106, 26);
            this.lblHighTorqueCWVel.TabIndex = 116;
            this.lblHighTorqueCWVel.Text = "1000";
            this.lblHighTorqueCWVel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(159, -11);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(0, 18);
            this.label23.TabIndex = 83;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.doubleBufferTableLayoutPanel2);
            this.groupBox3.Controls.Add(this.doubleBufferTableLayoutPanel1);
            this.groupBox3.Controls.Add(this.LblDummy);
            this.groupBox3.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox3.Location = new System.Drawing.Point(3, 143);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(454, 122);
            this.groupBox3.TabIndex = 113;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "モータ電流結果 [A]";
            // 
            // doubleBufferTableLayoutPanel2
            // 
            this.doubleBufferTableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.doubleBufferTableLayoutPanel2.ColumnCount = 4;
            this.doubleBufferTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.doubleBufferTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.4186F));
            this.doubleBufferTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.7093F));
            this.doubleBufferTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.87209F));
            this.doubleBufferTableLayoutPanel2.Controls.Add(this.label55, 0, 0);
            this.doubleBufferTableLayoutPanel2.Controls.Add(this.label4, 2, 0);
            this.doubleBufferTableLayoutPanel2.Controls.Add(this.label6, 1, 0);
            this.doubleBufferTableLayoutPanel2.Controls.Add(this.label5, 3, 0);
            this.doubleBufferTableLayoutPanel2.Location = new System.Drawing.Point(97, 24);
            this.doubleBufferTableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.doubleBufferTableLayoutPanel2.Name = "doubleBufferTableLayoutPanel2";
            this.doubleBufferTableLayoutPanel2.RowCount = 1;
            this.doubleBufferTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.doubleBufferTableLayoutPanel2.Size = new System.Drawing.Size(346, 36);
            this.doubleBufferTableLayoutPanel2.TabIndex = 115;
            // 
            // label55
            // 
            this.label55.BackColor = System.Drawing.Color.SteelBlue;
            this.label55.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label55.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label55.ForeColor = System.Drawing.Color.White;
            this.label55.Location = new System.Drawing.Point(2, 2);
            this.label55.Margin = new System.Windows.Forms.Padding(0);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(84, 32);
            this.label55.TabIndex = 26;
            this.label55.Text = "高トルク\r\n（低速） ";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.SteelBlue;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(172, 2);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 32);
            this.label4.TabIndex = 28;
            this.label4.Text = "高速回転\r\n（低速）";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.SteelBlue;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(88, 2);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 32);
            this.label6.TabIndex = 27;
            this.label6.Text = "高トルク\r\n（高速）";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.SteelBlue;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(257, 2);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 32);
            this.label5.TabIndex = 29;
            this.label5.Text = "高速回転\r\n（高速）";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // doubleBufferTableLayoutPanel1
            // 
            this.doubleBufferTableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.doubleBufferTableLayoutPanel1.ColumnCount = 5;
            this.doubleBufferTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.doubleBufferTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.doubleBufferTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.doubleBufferTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.doubleBufferTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.doubleBufferTableLayoutPanel1.Controls.Add(this.lblRotationHighVel, 4, 0);
            this.doubleBufferTableLayoutPanel1.Controls.Add(this.lblRotationLowVel, 3, 0);
            this.doubleBufferTableLayoutPanel1.Controls.Add(this.lblTrqHighVelStart, 2, 0);
            this.doubleBufferTableLayoutPanel1.Controls.Add(this.lblTrqLowVelStart, 1, 0);
            this.doubleBufferTableLayoutPanel1.Controls.Add(this.label12, 0, 1);
            this.doubleBufferTableLayoutPanel1.Controls.Add(this.label11, 0, 1);
            this.doubleBufferTableLayoutPanel1.Controls.Add(this.lblRotationHighConti, 0, 1);
            this.doubleBufferTableLayoutPanel1.Controls.Add(this.lblTrqHighVelConti, 0, 1);
            this.doubleBufferTableLayoutPanel1.Controls.Add(this.label8, 0, 1);
            this.doubleBufferTableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.doubleBufferTableLayoutPanel1.Location = new System.Drawing.Point(13, 60);
            this.doubleBufferTableLayoutPanel1.Name = "doubleBufferTableLayoutPanel1";
            this.doubleBufferTableLayoutPanel1.RowCount = 2;
            this.doubleBufferTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.doubleBufferTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.doubleBufferTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.doubleBufferTableLayoutPanel1.Size = new System.Drawing.Size(429, 55);
            this.doubleBufferTableLayoutPanel1.TabIndex = 84;
            // 
            // lblRotationHighVel
            // 
            this.lblRotationHighVel.BackColor = System.Drawing.Color.White;
            this.lblRotationHighVel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRotationHighVel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRotationHighVel.ForeColor = System.Drawing.Color.White;
            this.lblRotationHighVel.Location = new System.Drawing.Point(341, 1);
            this.lblRotationHighVel.Margin = new System.Windows.Forms.Padding(0);
            this.lblRotationHighVel.Name = "lblRotationHighVel";
            this.lblRotationHighVel.Size = new System.Drawing.Size(87, 26);
            this.lblRotationHighVel.TabIndex = 115;
            this.lblRotationHighVel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRotationLowVel
            // 
            this.lblRotationLowVel.BackColor = System.Drawing.Color.White;
            this.lblRotationLowVel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRotationLowVel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRotationLowVel.ForeColor = System.Drawing.Color.White;
            this.lblRotationLowVel.Location = new System.Drawing.Point(256, 1);
            this.lblRotationLowVel.Margin = new System.Windows.Forms.Padding(0);
            this.lblRotationLowVel.Name = "lblRotationLowVel";
            this.lblRotationLowVel.Size = new System.Drawing.Size(84, 26);
            this.lblRotationLowVel.TabIndex = 116;
            this.lblRotationLowVel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTrqHighVelStart
            // 
            this.lblTrqHighVelStart.BackColor = System.Drawing.Color.White;
            this.lblTrqHighVelStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrqHighVelStart.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrqHighVelStart.ForeColor = System.Drawing.Color.White;
            this.lblTrqHighVelStart.Location = new System.Drawing.Point(171, 1);
            this.lblTrqHighVelStart.Margin = new System.Windows.Forms.Padding(0);
            this.lblTrqHighVelStart.Name = "lblTrqHighVelStart";
            this.lblTrqHighVelStart.Size = new System.Drawing.Size(84, 26);
            this.lblTrqHighVelStart.TabIndex = 116;
            this.lblTrqHighVelStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTrqLowVelStart
            // 
            this.lblTrqLowVelStart.BackColor = System.Drawing.Color.White;
            this.lblTrqLowVelStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrqLowVelStart.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrqLowVelStart.ForeColor = System.Drawing.Color.White;
            this.lblTrqLowVelStart.Location = new System.Drawing.Point(86, 1);
            this.lblTrqLowVelStart.Margin = new System.Windows.Forms.Padding(0);
            this.lblTrqLowVelStart.Name = "lblTrqLowVelStart";
            this.lblTrqLowVelStart.Size = new System.Drawing.Size(84, 26);
            this.lblTrqLowVelStart.TabIndex = 116;
            this.lblTrqLowVelStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.LightGray;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(86, 28);
            this.label12.Margin = new System.Windows.Forms.Padding(0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 26);
            this.label12.TabIndex = 32;
            this.label12.Text = "―";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.LightGray;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(256, 28);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 26);
            this.label11.TabIndex = 31;
            this.label11.Text = "―";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRotationHighConti
            // 
            this.lblRotationHighConti.BackColor = System.Drawing.Color.White;
            this.lblRotationHighConti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRotationHighConti.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRotationHighConti.ForeColor = System.Drawing.Color.White;
            this.lblRotationHighConti.Location = new System.Drawing.Point(341, 28);
            this.lblRotationHighConti.Margin = new System.Windows.Forms.Padding(0);
            this.lblRotationHighConti.Name = "lblRotationHighConti";
            this.lblRotationHighConti.Size = new System.Drawing.Size(87, 26);
            this.lblRotationHighConti.TabIndex = 30;
            this.lblRotationHighConti.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTrqHighVelConti
            // 
            this.lblTrqHighVelConti.BackColor = System.Drawing.Color.White;
            this.lblTrqHighVelConti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrqHighVelConti.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrqHighVelConti.ForeColor = System.Drawing.Color.White;
            this.lblTrqHighVelConti.Location = new System.Drawing.Point(171, 28);
            this.lblTrqHighVelConti.Margin = new System.Windows.Forms.Padding(0);
            this.lblTrqHighVelConti.Name = "lblTrqHighVelConti";
            this.lblTrqHighVelConti.Size = new System.Drawing.Size(84, 26);
            this.lblTrqHighVelConti.TabIndex = 29;
            this.lblTrqHighVelConti.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.LightCyan;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(1, 28);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 26);
            this.label8.TabIndex = 28;
            this.label8.Text = "連続回転";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.LightCyan;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(1, 1);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 26);
            this.label3.TabIndex = 27;
            this.label3.Text = "起動直後";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblDummy
            // 
            this.LblDummy.AutoSize = true;
            this.LblDummy.Location = new System.Drawing.Point(159, -11);
            this.LblDummy.Name = "LblDummy";
            this.LblDummy.Size = new System.Drawing.Size(0, 18);
            this.LblDummy.TabIndex = 83;
            // 
            // btnStartAction
            // 
            this.btnStartAction.Angle = 90F;
            this.btnStartAction.ClientRectYMargin = 5;
            this.btnStartAction.EndColor = System.Drawing.Color.LightGray;
            this.btnStartAction.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnStartAction.ForeColor = System.Drawing.Color.Navy;
            this.btnStartAction.Location = new System.Drawing.Point(2, 3);
            this.btnStartAction.Name = "btnStartAction";
            this.btnStartAction.PushEndColor = System.Drawing.Color.White;
            this.btnStartAction.PushStartColor = System.Drawing.Color.Gold;
            this.btnStartAction.Size = new System.Drawing.Size(227, 40);
            this.btnStartAction.StartColor = System.Drawing.Color.White;
            this.btnStartAction.TabIndex = 111;
            this.btnStartAction.Text = "開始";
            this.btnStartAction.UseVisualStyleBackColor = true;
            this.btnStartAction.Click += new System.EventHandler(this.btnStartAction_Click);
            // 
            // btnStopAction
            // 
            this.btnStopAction.Angle = 90F;
            this.btnStopAction.ClientRectYMargin = 5;
            this.btnStopAction.EndColor = System.Drawing.Color.LightGray;
            this.btnStopAction.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnStopAction.ForeColor = System.Drawing.Color.Navy;
            this.btnStopAction.Location = new System.Drawing.Point(231, 3);
            this.btnStopAction.Name = "btnStopAction";
            this.btnStopAction.PushEndColor = System.Drawing.Color.White;
            this.btnStopAction.PushStartColor = System.Drawing.Color.Gold;
            this.btnStopAction.Size = new System.Drawing.Size(227, 40);
            this.btnStopAction.StartColor = System.Drawing.Color.White;
            this.btnStopAction.TabIndex = 112;
            this.btnStopAction.Text = "停止";
            this.btnStopAction.UseVisualStyleBackColor = true;
            this.btnStopAction.Click += new System.EventHandler(this.btnStopAction_Click);
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
            this.gradientLabel3.Location = new System.Drawing.Point(8, 180);
            this.gradientLabel3.Name = "gradientLabel3";
            this.gradientLabel3.Size = new System.Drawing.Size(462, 18);
            this.gradientLabel3.StartColor = System.Drawing.Color.Cyan;
            this.gradientLabel3.TabIndex = 110;
            this.gradientLabel3.Text = "動作確認";
            this.gradientLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.gradientLabel2.Location = new System.Drawing.Point(8, 111);
            this.gradientLabel2.Name = "gradientLabel2";
            this.gradientLabel2.Size = new System.Drawing.Size(462, 18);
            this.gradientLabel2.StartColor = System.Drawing.Color.Cyan;
            this.gradientLabel2.TabIndex = 107;
            this.gradientLabel2.Text = "フォトセンサ取付";
            this.gradientLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblStatus
            // 
            this.LblStatus.Angle = 90F;
            this.LblStatus.BorderColor = System.Drawing.Color.Transparent;
            this.LblStatus.EndColor = System.Drawing.Color.White;
            this.LblStatus.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblStatus.FormatAlignment = System.Drawing.StringAlignment.Center;
            this.LblStatus.IsSpace = false;
            this.LblStatus.LineAlignment = System.Drawing.StringAlignment.Center;
            this.LblStatus.Location = new System.Drawing.Point(9, 48);
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(462, 24);
            this.LblStatus.StartColor = System.Drawing.Color.White;
            this.LblStatus.TabIndex = 101;
            this.LblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.gradientLabel1.Location = new System.Drawing.Point(9, 28);
            this.gradientLabel1.Name = "gradientLabel1";
            this.gradientLabel1.Size = new System.Drawing.Size(462, 18);
            this.gradientLabel1.StartColor = System.Drawing.Color.Cyan;
            this.gradientLabel1.TabIndex = 100;
            this.gradientLabel1.Text = "ステータス";
            this.gradientLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label13.Location = new System.Drawing.Point(-2, 75);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(493, 2);
            this.label13.TabIndex = 118;
            // 
            // cmbModel
            // 
            this.cmbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModel.DropDownWidth = 180;
            this.cmbModel.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbModel.FormattingEnabled = true;
            this.cmbModel.Location = new System.Drawing.Point(79, 81);
            this.cmbModel.Name = "cmbModel";
            this.cmbModel.Size = new System.Drawing.Size(160, 25);
            this.cmbModel.TabIndex = 113;
            this.cmbModel.TabStop = false;
            this.cmbModel.SelectedIndexChanged += new System.EventHandler(this.cmbModel_SelectedIndexChanged);
            this.cmbModel.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.cmbModel.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // PhotoSensorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 749);
            this.Controls.Add(this.cmbModel);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.toolStripPhoto);
            this.Controls.Add(this.doubleBufferPanel3);
            this.Controls.Add(this.gradientLabel4);
            this.Controls.Add(this.doubleBufferPanel2);
            this.Controls.Add(this.doubleBufferPanel1);
            this.Controls.Add(this.gradientLabel3);
            this.Controls.Add(this.gradientLabel2);
            this.Controls.Add(this.txtMotorType);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblComNo);
            this.Controls.Add(this.LblStatus);
            this.Controls.Add(this.gradientLabel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PhotoSensorForm";
            this.Text = "フォトセンサ取付/動作確認";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PhotoSensorForm_FormClosing);
            this.Load += new System.EventHandler(this.PhotoSensorForm_Load);
            this.Shown += new System.EventHandler(this.PhotoSensorForm_Shown);
            this.Resize += new System.EventHandler(this.PhotoSensorForm_Resize);
            this.toolStripPhoto.ResumeLayout(false);
            this.toolStripPhoto.PerformLayout();
            this.doubleBufferPanel3.ResumeLayout(false);
            this.doubleBufferPanel2.ResumeLayout(false);
            this.doubleBufferPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.doubleBufferTableLayoutPanel3.ResumeLayout(false);
            this.doubleBufferTableLayoutPanel4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.doubleBufferTableLayoutPanel2.ResumeLayout(false);
            this.doubleBufferTableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer TimerResize;
        private System.Windows.Forms.Timer TimerBlink;
        private GradientLabel LblStatus;
        private GradientLabel gradientLabel1;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblComNo;
        private System.Windows.Forms.TextBox txtMotorType;
        private GradientLabel gradientLabel2;
        private GradientLabel gradientLabel3;
        private GradientButton btnStopAction;
        private GradientButton btnStartAction;
        private DoubleBufferPanel doubleBufferPanel1;
        private DoubleBufferPanel doubleBufferPanel2;
        private GradientButton btnStartMount;
        private GradientButton btnStopMount;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label LblDummy;
        private DoubleBufferTableLayoutPanel doubleBufferTableLayoutPanel1;
        private DoubleBufferTableLayoutPanel doubleBufferTableLayoutPanel2;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblRotationHighVel;
        private System.Windows.Forms.Label lblRotationLowVel;
        private System.Windows.Forms.Label lblTrqHighVelStart;
        private System.Windows.Forms.Label lblTrqLowVelStart;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblRotationHighConti;
        private System.Windows.Forms.Label lblTrqHighVelConti;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private GradientLabel gradientLabel4;
        private DoubleBufferPanel doubleBufferPanel3;
        private GradientButton btnStartClutch;
        private System.Windows.Forms.GroupBox groupBox1;
        private DoubleBufferTableLayoutPanel doubleBufferTableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private DoubleBufferTableLayoutPanel doubleBufferTableLayoutPanel4;
        private System.Windows.Forms.Label lblHighSpeedCCWVel;
        private System.Windows.Forms.Label lblHighSpeedCWVel;
        private System.Windows.Forms.Label lblHighTorqueCCWVel;
        private System.Windows.Forms.Label lblHighTorqueCWVel;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ToolStrip toolStripPhoto;
        private System.Windows.Forms.ToolStripButton btnOption;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnReset;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbModel;
    }
}