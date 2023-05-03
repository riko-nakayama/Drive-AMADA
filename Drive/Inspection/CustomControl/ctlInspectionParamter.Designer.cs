namespace Motion_Designer
{
    partial class ctlInspectionParamter
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.numHighModeUp = new System.Windows.Forms.NumericUpDown();
            this.numHighModeDown = new System.Windows.Forms.NumericUpDown();
            this.numLowModeUp = new System.Windows.Forms.NumericUpDown();
            this.numLowModeDown = new System.Windows.Forms.NumericUpDown();
            this.doubleBufferTableLayoutPanel1 = new Motion_Designer.DoubleBufferTableLayoutPanel();
            this.numLowModeConstantDown = new System.Windows.Forms.NumericUpDown();
            this.numHighModeConstantDown = new System.Windows.Forms.NumericUpDown();
            this.numCycle = new System.Windows.Forms.NumericUpDown();
            this.numLowModeConstantUp = new System.Windows.Forms.NumericUpDown();
            this.numHighModeConstantUp = new System.Windows.Forms.NumericUpDown();
            this.numExcitationCur2 = new System.Windows.Forms.NumericUpDown();
            this.numExcitationCur1 = new System.Windows.Forms.NumericUpDown();
            this.numHighVelocity = new System.Windows.Forms.NumericUpDown();
            this.numLowVelocity = new System.Windows.Forms.NumericUpDown();
            this.BtnWrite = new System.Windows.Forms.Button();
            this.txtMotorType = new System.Windows.Forms.TextBox();
            this.txtNo = new System.Windows.Forms.TextBox();
            this.btnRead = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numHighModeUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHighModeDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLowModeUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLowModeDown)).BeginInit();
            this.doubleBufferTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLowModeConstantDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHighModeConstantDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCycle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLowModeConstantUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHighModeConstantUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExcitationCur2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExcitationCur1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHighVelocity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLowVelocity)).BeginInit();
            this.SuspendLayout();
            // 
            // numHighModeUp
            // 
            this.numHighModeUp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numHighModeUp.DecimalPlaces = 2;
            this.numHighModeUp.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numHighModeUp.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numHighModeUp.Location = new System.Drawing.Point(291, 162);
            this.numHighModeUp.Margin = new System.Windows.Forms.Padding(0);
            this.numHighModeUp.Name = "numHighModeUp";
            this.numHighModeUp.Size = new System.Drawing.Size(59, 23);
            this.numHighModeUp.TabIndex = 4;
            this.numHighModeUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numHighModeUp.Visible = false;
            this.numHighModeUp.Enter += new System.EventHandler(this.num_Enter);
            this.numHighModeUp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.num_KeyPress);
            // 
            // numHighModeDown
            // 
            this.numHighModeDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numHighModeDown.DecimalPlaces = 2;
            this.numHighModeDown.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numHighModeDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numHighModeDown.Location = new System.Drawing.Point(443, 162);
            this.numHighModeDown.Margin = new System.Windows.Forms.Padding(0);
            this.numHighModeDown.Name = "numHighModeDown";
            this.numHighModeDown.Size = new System.Drawing.Size(59, 23);
            this.numHighModeDown.TabIndex = 6;
            this.numHighModeDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numHighModeDown.Visible = false;
            this.numHighModeDown.Enter += new System.EventHandler(this.num_Enter);
            this.numHighModeDown.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.num_KeyPress);
            // 
            // numLowModeUp
            // 
            this.numLowModeUp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numLowModeUp.DecimalPlaces = 2;
            this.numLowModeUp.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numLowModeUp.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numLowModeUp.Location = new System.Drawing.Point(564, 162);
            this.numLowModeUp.Margin = new System.Windows.Forms.Padding(0);
            this.numLowModeUp.Name = "numLowModeUp";
            this.numLowModeUp.Size = new System.Drawing.Size(59, 23);
            this.numLowModeUp.TabIndex = 7;
            this.numLowModeUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numLowModeUp.Visible = false;
            this.numLowModeUp.Enter += new System.EventHandler(this.num_Enter);
            this.numLowModeUp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.num_KeyPress);
            // 
            // numLowModeDown
            // 
            this.numLowModeDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numLowModeDown.DecimalPlaces = 2;
            this.numLowModeDown.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numLowModeDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numLowModeDown.Location = new System.Drawing.Point(706, 144);
            this.numLowModeDown.Margin = new System.Windows.Forms.Padding(0);
            this.numLowModeDown.Name = "numLowModeDown";
            this.numLowModeDown.Size = new System.Drawing.Size(59, 23);
            this.numLowModeDown.TabIndex = 9;
            this.numLowModeDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numLowModeDown.Visible = false;
            this.numLowModeDown.Enter += new System.EventHandler(this.num_Enter);
            this.numLowModeDown.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.num_KeyPress);
            // 
            // doubleBufferTableLayoutPanel1
            // 
            this.doubleBufferTableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.doubleBufferTableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.doubleBufferTableLayoutPanel1.ColumnCount = 13;
            this.doubleBufferTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.410514F));
            this.doubleBufferTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.86995F));
            this.doubleBufferTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.156322F));
            this.doubleBufferTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.156322F));
            this.doubleBufferTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.156322F));
            this.doubleBufferTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.156322F));
            this.doubleBufferTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.156322F));
            this.doubleBufferTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.156322F));
            this.doubleBufferTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.156322F));
            this.doubleBufferTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.156322F));
            this.doubleBufferTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.156322F));
            this.doubleBufferTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.156322F));
            this.doubleBufferTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.156322F));
            this.doubleBufferTableLayoutPanel1.Controls.Add(this.numLowModeConstantDown, 9, 0);
            this.doubleBufferTableLayoutPanel1.Controls.Add(this.numHighModeConstantDown, 8, 0);
            this.doubleBufferTableLayoutPanel1.Controls.Add(this.numCycle, 10, 0);
            this.doubleBufferTableLayoutPanel1.Controls.Add(this.numLowModeConstantUp, 7, 0);
            this.doubleBufferTableLayoutPanel1.Controls.Add(this.numHighModeConstantUp, 6, 0);
            this.doubleBufferTableLayoutPanel1.Controls.Add(this.numExcitationCur2, 5, 0);
            this.doubleBufferTableLayoutPanel1.Controls.Add(this.numExcitationCur1, 4, 0);
            this.doubleBufferTableLayoutPanel1.Controls.Add(this.numHighVelocity, 3, 0);
            this.doubleBufferTableLayoutPanel1.Controls.Add(this.numLowVelocity, 2, 0);
            this.doubleBufferTableLayoutPanel1.Controls.Add(this.BtnWrite, 11, 0);
            this.doubleBufferTableLayoutPanel1.Controls.Add(this.txtMotorType, 1, 0);
            this.doubleBufferTableLayoutPanel1.Controls.Add(this.txtNo, 0, 0);
            this.doubleBufferTableLayoutPanel1.Controls.Add(this.btnRead, 12, 0);
            this.doubleBufferTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.doubleBufferTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.doubleBufferTableLayoutPanel1.Name = "doubleBufferTableLayoutPanel1";
            this.doubleBufferTableLayoutPanel1.RowCount = 1;
            this.doubleBufferTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.doubleBufferTableLayoutPanel1.Size = new System.Drawing.Size(894, 28);
            this.doubleBufferTableLayoutPanel1.TabIndex = 0;
            // 
            // numLowModeConstantDown
            // 
            this.numLowModeConstantDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numLowModeConstantDown.DecimalPlaces = 2;
            this.numLowModeConstantDown.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numLowModeConstantDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numLowModeConstantDown.Location = new System.Drawing.Point(630, 2);
            this.numLowModeConstantDown.Margin = new System.Windows.Forms.Padding(0);
            this.numLowModeConstantDown.Name = "numLowModeConstantDown";
            this.numLowModeConstantDown.Size = new System.Drawing.Size(61, 23);
            this.numLowModeConstantDown.TabIndex = 7;
            this.numLowModeConstantDown.Tag = "7";
            this.numLowModeConstantDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numLowModeConstantDown.Enter += new System.EventHandler(this.num_Enter);
            this.numLowModeConstantDown.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.num_KeyPress);
            // 
            // numHighModeConstantDown
            // 
            this.numHighModeConstantDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numHighModeConstantDown.DecimalPlaces = 2;
            this.numHighModeConstantDown.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numHighModeConstantDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numHighModeConstantDown.Location = new System.Drawing.Point(567, 2);
            this.numHighModeConstantDown.Margin = new System.Windows.Forms.Padding(0);
            this.numHighModeConstantDown.Name = "numHighModeConstantDown";
            this.numHighModeConstantDown.Size = new System.Drawing.Size(61, 23);
            this.numHighModeConstantDown.TabIndex = 6;
            this.numHighModeConstantDown.Tag = "6";
            this.numHighModeConstantDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numHighModeConstantDown.Enter += new System.EventHandler(this.num_Enter);
            this.numHighModeConstantDown.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.num_KeyPress);
            // 
            // numCycle
            // 
            this.numCycle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numCycle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numCycle.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numCycle.Location = new System.Drawing.Point(693, 2);
            this.numCycle.Margin = new System.Windows.Forms.Padding(0);
            this.numCycle.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numCycle.Name = "numCycle";
            this.numCycle.Size = new System.Drawing.Size(61, 23);
            this.numCycle.TabIndex = 8;
            this.numCycle.Tag = "8";
            this.numCycle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numCycle.Enter += new System.EventHandler(this.num_Enter);
            this.numCycle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.num_KeyPress);
            // 
            // numLowModeConstantUp
            // 
            this.numLowModeConstantUp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numLowModeConstantUp.DecimalPlaces = 2;
            this.numLowModeConstantUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numLowModeConstantUp.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numLowModeConstantUp.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numLowModeConstantUp.Location = new System.Drawing.Point(504, 2);
            this.numLowModeConstantUp.Margin = new System.Windows.Forms.Padding(0);
            this.numLowModeConstantUp.Name = "numLowModeConstantUp";
            this.numLowModeConstantUp.Size = new System.Drawing.Size(61, 23);
            this.numLowModeConstantUp.TabIndex = 5;
            this.numLowModeConstantUp.Tag = "5";
            this.numLowModeConstantUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numLowModeConstantUp.Enter += new System.EventHandler(this.num_Enter);
            this.numLowModeConstantUp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.num_KeyPress);
            // 
            // numHighModeConstantUp
            // 
            this.numHighModeConstantUp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numHighModeConstantUp.DecimalPlaces = 2;
            this.numHighModeConstantUp.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numHighModeConstantUp.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numHighModeConstantUp.Location = new System.Drawing.Point(441, 2);
            this.numHighModeConstantUp.Margin = new System.Windows.Forms.Padding(0);
            this.numHighModeConstantUp.Name = "numHighModeConstantUp";
            this.numHighModeConstantUp.Size = new System.Drawing.Size(61, 23);
            this.numHighModeConstantUp.TabIndex = 4;
            this.numHighModeConstantUp.Tag = "4";
            this.numHighModeConstantUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numHighModeConstantUp.Enter += new System.EventHandler(this.num_Enter);
            this.numHighModeConstantUp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.num_KeyPress);
            // 
            // numExcitationCur2
            // 
            this.numExcitationCur2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numExcitationCur2.DecimalPlaces = 2;
            this.numExcitationCur2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numExcitationCur2.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numExcitationCur2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numExcitationCur2.Location = new System.Drawing.Point(378, 2);
            this.numExcitationCur2.Margin = new System.Windows.Forms.Padding(0);
            this.numExcitationCur2.Name = "numExcitationCur2";
            this.numExcitationCur2.Size = new System.Drawing.Size(61, 23);
            this.numExcitationCur2.TabIndex = 3;
            this.numExcitationCur2.Tag = "3";
            this.numExcitationCur2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numExcitationCur2.Enter += new System.EventHandler(this.num_Enter);
            this.numExcitationCur2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.num_KeyPress);
            // 
            // numExcitationCur1
            // 
            this.numExcitationCur1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numExcitationCur1.DecimalPlaces = 2;
            this.numExcitationCur1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numExcitationCur1.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numExcitationCur1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numExcitationCur1.Location = new System.Drawing.Point(315, 2);
            this.numExcitationCur1.Margin = new System.Windows.Forms.Padding(0);
            this.numExcitationCur1.Name = "numExcitationCur1";
            this.numExcitationCur1.Size = new System.Drawing.Size(61, 23);
            this.numExcitationCur1.TabIndex = 2;
            this.numExcitationCur1.Tag = "2";
            this.numExcitationCur1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numExcitationCur1.Enter += new System.EventHandler(this.num_Enter);
            this.numExcitationCur1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.num_KeyPress);
            // 
            // numHighVelocity
            // 
            this.numHighVelocity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numHighVelocity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numHighVelocity.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numHighVelocity.Location = new System.Drawing.Point(252, 2);
            this.numHighVelocity.Margin = new System.Windows.Forms.Padding(0);
            this.numHighVelocity.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numHighVelocity.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            -2147483648});
            this.numHighVelocity.Name = "numHighVelocity";
            this.numHighVelocity.Size = new System.Drawing.Size(61, 23);
            this.numHighVelocity.TabIndex = 1;
            this.numHighVelocity.Tag = "1";
            this.numHighVelocity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numHighVelocity.Enter += new System.EventHandler(this.num_Enter);
            this.numHighVelocity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.num_KeyPress);
            // 
            // numLowVelocity
            // 
            this.numLowVelocity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numLowVelocity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numLowVelocity.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numLowVelocity.Location = new System.Drawing.Point(189, 2);
            this.numLowVelocity.Margin = new System.Windows.Forms.Padding(0);
            this.numLowVelocity.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numLowVelocity.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            -2147483648});
            this.numLowVelocity.Name = "numLowVelocity";
            this.numLowVelocity.Size = new System.Drawing.Size(61, 23);
            this.numLowVelocity.TabIndex = 0;
            this.numLowVelocity.Tag = "0";
            this.numLowVelocity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numLowVelocity.Enter += new System.EventHandler(this.num_Enter);
            this.numLowVelocity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.num_KeyPress);
            // 
            // BtnWrite
            // 
            this.BtnWrite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnWrite.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnWrite.Location = new System.Drawing.Point(756, 2);
            this.BtnWrite.Margin = new System.Windows.Forms.Padding(0);
            this.BtnWrite.Name = "BtnWrite";
            this.BtnWrite.Size = new System.Drawing.Size(61, 24);
            this.BtnWrite.TabIndex = 11;
            this.BtnWrite.Tag = "9";
            this.BtnWrite.Text = "設定";
            this.BtnWrite.UseVisualStyleBackColor = true;
            this.BtnWrite.Click += new System.EventHandler(this.BtnWrite_Click);
            // 
            // txtMotorType
            // 
            this.txtMotorType.BackColor = System.Drawing.Color.White;
            this.txtMotorType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMotorType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMotorType.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtMotorType.Location = new System.Drawing.Point(33, 3);
            this.txtMotorType.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.txtMotorType.Name = "txtMotorType";
            this.txtMotorType.Size = new System.Drawing.Size(154, 20);
            this.txtMotorType.TabIndex = 1;
            this.txtMotorType.Tag = "1";
            this.txtMotorType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMotorType_KeyPress);
            // 
            // txtNo
            // 
            this.txtNo.BackColor = System.Drawing.Color.White;
            this.txtNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNo.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtNo.Location = new System.Drawing.Point(2, 3);
            this.txtNo.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.txtNo.Multiline = true;
            this.txtNo.Name = "txtNo";
            this.txtNo.ReadOnly = true;
            this.txtNo.Size = new System.Drawing.Size(29, 23);
            this.txtNo.TabIndex = 0;
            this.txtNo.Tag = "0";
            this.txtNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNo.Enter += new System.EventHandler(this.txtNo_Enter);
            // 
            // btnRead
            // 
            this.btnRead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRead.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnRead.Location = new System.Drawing.Point(819, 2);
            this.btnRead.Margin = new System.Windows.Forms.Padding(0);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(73, 24);
            this.btnRead.TabIndex = 12;
            this.btnRead.Tag = "10";
            this.btnRead.Text = "取得";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // ctlInspectionParamter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numLowModeDown);
            this.Controls.Add(this.doubleBufferTableLayoutPanel1);
            this.Controls.Add(this.numHighModeUp);
            this.Controls.Add(this.numLowModeUp);
            this.Controls.Add(this.numHighModeDown);
            this.DoubleBuffered = true;
            this.Name = "ctlInspectionParamter";
            this.Size = new System.Drawing.Size(894, 28);
            this.Load += new System.EventHandler(this.ctlInspectionParamter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numHighModeUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHighModeDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLowModeUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLowModeDown)).EndInit();
            this.doubleBufferTableLayoutPanel1.ResumeLayout(false);
            this.doubleBufferTableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLowModeConstantDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHighModeConstantDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCycle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLowModeConstantUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHighModeConstantUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExcitationCur2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExcitationCur1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHighVelocity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLowVelocity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DoubleBufferTableLayoutPanel doubleBufferTableLayoutPanel1;
        private System.Windows.Forms.NumericUpDown numLowModeConstantUp;
        private System.Windows.Forms.NumericUpDown numHighModeConstantUp;
        private System.Windows.Forms.NumericUpDown numExcitationCur2;
        private System.Windows.Forms.NumericUpDown numExcitationCur1;
        private System.Windows.Forms.NumericUpDown numHighVelocity;
        private System.Windows.Forms.NumericUpDown numLowVelocity;
        private System.Windows.Forms.Button BtnWrite;
        private System.Windows.Forms.TextBox txtMotorType;
        private System.Windows.Forms.TextBox txtNo;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.NumericUpDown numLowModeDown;
        private System.Windows.Forms.NumericUpDown numLowModeUp;
        private System.Windows.Forms.NumericUpDown numHighModeDown;
        private System.Windows.Forms.NumericUpDown numHighModeUp;
        private System.Windows.Forms.NumericUpDown numCycle;
        private System.Windows.Forms.NumericUpDown numLowModeConstantDown;
        private System.Windows.Forms.NumericUpDown numHighModeConstantDown;
    }
}
