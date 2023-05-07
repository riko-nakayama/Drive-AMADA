namespace Motion_Designer
{
    partial class ResolverMountForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResolverMountForm));
			this.TimerResize = new System.Windows.Forms.Timer(this.components);
			this.TimerMotorAction = new System.Windows.Forms.Timer(this.components);
			this.panel1 = new Motion_Designer.DoubleBufferPanel();
			this.BtnRotate = new Motion_Designer.GradientButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.BtnServoON = new Motion_Designer.GradientButton();
			this.BtnCCW = new Motion_Designer.GradientButton();
			this.BtnBreakON = new Motion_Designer.GradientButton();
			this.BtnCW = new Motion_Designer.GradientButton();
			this.BtnServoOFF = new Motion_Designer.GradientButton();
			this.BtnAlarmReset = new Motion_Designer.GradientButton();
			this.BtnZeroLock = new Motion_Designer.GradientButton();
			this.BtnBreakOFF = new Motion_Designer.GradientButton();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.LblBreak = new Motion_Designer.GradientLabel();
			this.LblServo = new Motion_Designer.GradientLabel();
			this.LblDummy = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.NumRotationTime = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.NumDeceleration = new System.Windows.Forms.NumericUpDown();
			this.NumAcceleration = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.NumTargetVelocity = new System.Windows.Forms.NumericUpDown();
			this.label15 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.NumRotationTime)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NumDeceleration)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NumAcceleration)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NumTargetVelocity)).BeginInit();
			this.SuspendLayout();
			// 
			// TimerResize
			// 
			this.TimerResize.Interval = 500;
			this.TimerResize.Tick += new System.EventHandler(this.TimerResize_Tick);
			// 
			// TimerMotorAction
			// 
			this.TimerMotorAction.Interval = 10;
			this.TimerMotorAction.Tick += new System.EventHandler(this.TimerMotorAction_Tick);
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.BtnRotate);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.BtnAlarmReset);
			this.panel1.Controls.Add(this.BtnZeroLock);
			this.panel1.Controls.Add(this.BtnBreakOFF);
			this.panel1.Controls.Add(this.groupBox3);
			this.panel1.Controls.Add(this.groupBox2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(491, 749);
			this.panel1.TabIndex = 71;
			// 
			// BtnRotate
			// 
			this.BtnRotate.Angle = 90F;
			this.BtnRotate.ClientRectYMargin = 5;
			this.BtnRotate.EndColor = System.Drawing.Color.LightGray;
			this.BtnRotate.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnRotate.ForeColor = System.Drawing.Color.Navy;
			this.BtnRotate.Location = new System.Drawing.Point(12, 154);
			this.BtnRotate.Name = "BtnRotate";
			this.BtnRotate.PushEndColor = System.Drawing.Color.White;
			this.BtnRotate.PushStartColor = System.Drawing.Color.Gold;
			this.BtnRotate.Size = new System.Drawing.Size(200, 55);
			this.BtnRotate.StartColor = System.Drawing.Color.White;
			this.BtnRotate.TabIndex = 93;
			this.BtnRotate.Text = "CW/CCW回転";
			this.BtnRotate.UseVisualStyleBackColor = true;
			this.BtnRotate.Click += new System.EventHandler(this.BtnRotate_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.BtnServoON);
			this.groupBox1.Controls.Add(this.BtnCCW);
			this.groupBox1.Controls.Add(this.BtnBreakON);
			this.groupBox1.Controls.Add(this.BtnCW);
			this.groupBox1.Controls.Add(this.BtnServoOFF);
			this.groupBox1.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.groupBox1.Location = new System.Drawing.Point(12, 666);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(467, 71);
			this.groupBox1.TabIndex = 92;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "他操作";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(159, -11);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(0, 20);
			this.label3.TabIndex = 83;
			// 
			// BtnServoON
			// 
			this.BtnServoON.Angle = 90F;
			this.BtnServoON.ClientRectYMargin = 5;
			this.BtnServoON.EndColor = System.Drawing.Color.LightGray;
			this.BtnServoON.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnServoON.ForeColor = System.Drawing.Color.Navy;
			this.BtnServoON.Location = new System.Drawing.Point(10, 22);
			this.BtnServoON.Name = "BtnServoON";
			this.BtnServoON.PushEndColor = System.Drawing.Color.White;
			this.BtnServoON.PushStartColor = System.Drawing.Color.Gold;
			this.BtnServoON.Size = new System.Drawing.Size(85, 40);
			this.BtnServoON.StartColor = System.Drawing.Color.White;
			this.BtnServoON.TabIndex = 84;
			this.BtnServoON.Text = "サーボON";
			this.BtnServoON.UseVisualStyleBackColor = true;
			this.BtnServoON.Click += new System.EventHandler(this.BtnServoON_Click);
			// 
			// BtnCCW
			// 
			this.BtnCCW.Angle = 90F;
			this.BtnCCW.ClientRectYMargin = 5;
			this.BtnCCW.EndColor = System.Drawing.Color.LightGray;
			this.BtnCCW.Font = new System.Drawing.Font("メイリオ", 9.75F);
			this.BtnCCW.ForeColor = System.Drawing.Color.Navy;
			this.BtnCCW.Location = new System.Drawing.Point(378, 22);
			this.BtnCCW.Name = "BtnCCW";
			this.BtnCCW.PushEndColor = System.Drawing.Color.White;
			this.BtnCCW.PushStartColor = System.Drawing.Color.Gold;
			this.BtnCCW.Size = new System.Drawing.Size(85, 40);
			this.BtnCCW.StartColor = System.Drawing.Color.White;
			this.BtnCCW.TabIndex = 90;
			this.BtnCCW.Text = "CCW回転";
			this.BtnCCW.UseVisualStyleBackColor = true;
			this.BtnCCW.Click += new System.EventHandler(this.BtnCCW_Click);
			// 
			// BtnBreakON
			// 
			this.BtnBreakON.Angle = 90F;
			this.BtnBreakON.ClientRectYMargin = 5;
			this.BtnBreakON.EndColor = System.Drawing.Color.LightGray;
			this.BtnBreakON.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnBreakON.ForeColor = System.Drawing.Color.Navy;
			this.BtnBreakON.Location = new System.Drawing.Point(192, 22);
			this.BtnBreakON.Name = "BtnBreakON";
			this.BtnBreakON.PushEndColor = System.Drawing.Color.White;
			this.BtnBreakON.PushStartColor = System.Drawing.Color.Gold;
			this.BtnBreakON.Size = new System.Drawing.Size(85, 40);
			this.BtnBreakON.StartColor = System.Drawing.Color.White;
			this.BtnBreakON.TabIndex = 86;
			this.BtnBreakON.Text = "ブレーキON";
			this.BtnBreakON.UseVisualStyleBackColor = true;
			this.BtnBreakON.Click += new System.EventHandler(this.BtnBreakON_Click);
			// 
			// BtnCW
			// 
			this.BtnCW.Angle = 90F;
			this.BtnCW.ClientRectYMargin = 5;
			this.BtnCW.EndColor = System.Drawing.Color.LightGray;
			this.BtnCW.Font = new System.Drawing.Font("メイリオ", 9.75F);
			this.BtnCW.ForeColor = System.Drawing.Color.Navy;
			this.BtnCW.Location = new System.Drawing.Point(289, 22);
			this.BtnCW.Name = "BtnCW";
			this.BtnCW.PushEndColor = System.Drawing.Color.White;
			this.BtnCW.PushStartColor = System.Drawing.Color.Gold;
			this.BtnCW.Size = new System.Drawing.Size(85, 40);
			this.BtnCW.StartColor = System.Drawing.Color.White;
			this.BtnCW.TabIndex = 89;
			this.BtnCW.Text = "CW回転";
			this.BtnCW.UseVisualStyleBackColor = true;
			this.BtnCW.Click += new System.EventHandler(this.BtnCW_Click);
			// 
			// BtnServoOFF
			// 
			this.BtnServoOFF.Angle = 90F;
			this.BtnServoOFF.ClientRectYMargin = 5;
			this.BtnServoOFF.EndColor = System.Drawing.Color.LightGray;
			this.BtnServoOFF.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnServoOFF.ForeColor = System.Drawing.Color.Navy;
			this.BtnServoOFF.Location = new System.Drawing.Point(100, 22);
			this.BtnServoOFF.Name = "BtnServoOFF";
			this.BtnServoOFF.PushEndColor = System.Drawing.Color.White;
			this.BtnServoOFF.PushStartColor = System.Drawing.Color.Gold;
			this.BtnServoOFF.Size = new System.Drawing.Size(85, 40);
			this.BtnServoOFF.StartColor = System.Drawing.Color.White;
			this.BtnServoOFF.TabIndex = 85;
			this.BtnServoOFF.Text = "サーボOFF";
			this.BtnServoOFF.UseVisualStyleBackColor = true;
			this.BtnServoOFF.Click += new System.EventHandler(this.BtnServoOFF_Click);
			// 
			// BtnAlarmReset
			// 
			this.BtnAlarmReset.Angle = 90F;
			this.BtnAlarmReset.ClientRectYMargin = 5;
			this.BtnAlarmReset.EndColor = System.Drawing.Color.LightGray;
			this.BtnAlarmReset.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnAlarmReset.ForeColor = System.Drawing.Color.Navy;
			this.BtnAlarmReset.Location = new System.Drawing.Point(12, 320);
			this.BtnAlarmReset.Name = "BtnAlarmReset";
			this.BtnAlarmReset.PushEndColor = System.Drawing.Color.White;
			this.BtnAlarmReset.PushStartColor = System.Drawing.Color.Gold;
			this.BtnAlarmReset.Size = new System.Drawing.Size(200, 55);
			this.BtnAlarmReset.StartColor = System.Drawing.Color.White;
			this.BtnAlarmReset.TabIndex = 91;
			this.BtnAlarmReset.Text = "アラームリセット";
			this.BtnAlarmReset.UseVisualStyleBackColor = true;
			this.BtnAlarmReset.Click += new System.EventHandler(this.BtnAlarmReset_Click);
			// 
			// BtnZeroLock
			// 
			this.BtnZeroLock.Angle = 90F;
			this.BtnZeroLock.ClientRectYMargin = 5;
			this.BtnZeroLock.EndColor = System.Drawing.Color.LightGray;
			this.BtnZeroLock.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnZeroLock.ForeColor = System.Drawing.Color.Navy;
			this.BtnZeroLock.Location = new System.Drawing.Point(12, 32);
			this.BtnZeroLock.Name = "BtnZeroLock";
			this.BtnZeroLock.PushEndColor = System.Drawing.Color.White;
			this.BtnZeroLock.PushStartColor = System.Drawing.Color.Gold;
			this.BtnZeroLock.Size = new System.Drawing.Size(200, 55);
			this.BtnZeroLock.StartColor = System.Drawing.Color.White;
			this.BtnZeroLock.TabIndex = 88;
			this.BtnZeroLock.Text = "零点ロック";
			this.BtnZeroLock.UseVisualStyleBackColor = true;
			this.BtnZeroLock.Click += new System.EventHandler(this.BtnZeroLock_Click);
			// 
			// BtnBreakOFF
			// 
			this.BtnBreakOFF.Angle = 90F;
			this.BtnBreakOFF.ClientRectYMargin = 5;
			this.BtnBreakOFF.EndColor = System.Drawing.Color.LightGray;
			this.BtnBreakOFF.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnBreakOFF.ForeColor = System.Drawing.Color.Navy;
			this.BtnBreakOFF.Location = new System.Drawing.Point(12, 93);
			this.BtnBreakOFF.Name = "BtnBreakOFF";
			this.BtnBreakOFF.PushEndColor = System.Drawing.Color.White;
			this.BtnBreakOFF.PushStartColor = System.Drawing.Color.Gold;
			this.BtnBreakOFF.Size = new System.Drawing.Size(200, 55);
			this.BtnBreakOFF.StartColor = System.Drawing.Color.White;
			this.BtnBreakOFF.TabIndex = 87;
			this.BtnBreakOFF.Text = "ブレーキOFF";
			this.BtnBreakOFF.UseVisualStyleBackColor = true;
			this.BtnBreakOFF.Click += new System.EventHandler(this.BtnBreakOFF_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.LblBreak);
			this.groupBox3.Controls.Add(this.LblServo);
			this.groupBox3.Controls.Add(this.LblDummy);
			this.groupBox3.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.groupBox3.Location = new System.Drawing.Point(219, 22);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(244, 170);
			this.groupBox3.TabIndex = 83;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "モータステータス";
			// 
			// LblBreak
			// 
			this.LblBreak.Angle = 90F;
			this.LblBreak.BorderColor = System.Drawing.Color.Black;
			this.LblBreak.EndColor = System.Drawing.Color.White;
			this.LblBreak.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.LblBreak.ForeColor = System.Drawing.Color.Navy;
			this.LblBreak.FormatAlignment = System.Drawing.StringAlignment.Center;
			this.LblBreak.IsSpace = false;
			this.LblBreak.LineAlignment = System.Drawing.StringAlignment.Center;
			this.LblBreak.Location = new System.Drawing.Point(16, 98);
			this.LblBreak.Name = "LblBreak";
			this.LblBreak.Size = new System.Drawing.Size(212, 50);
			this.LblBreak.StartColor = System.Drawing.Color.White;
			this.LblBreak.TabIndex = 94;
			this.LblBreak.Text = "ブレーキOFF";
			this.LblBreak.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// LblServo
			// 
			this.LblServo.Angle = 90F;
			this.LblServo.BorderColor = System.Drawing.Color.Black;
			this.LblServo.EndColor = System.Drawing.Color.White;
			this.LblServo.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.LblServo.ForeColor = System.Drawing.Color.Navy;
			this.LblServo.FormatAlignment = System.Drawing.StringAlignment.Center;
			this.LblServo.IsSpace = false;
			this.LblServo.LineAlignment = System.Drawing.StringAlignment.Center;
			this.LblServo.Location = new System.Drawing.Point(16, 29);
			this.LblServo.Name = "LblServo";
			this.LblServo.Size = new System.Drawing.Size(212, 50);
			this.LblServo.StartColor = System.Drawing.Color.White;
			this.LblServo.TabIndex = 93;
			this.LblServo.Text = "サーボOFF";
			this.LblServo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// LblDummy
			// 
			this.LblDummy.AutoSize = true;
			this.LblDummy.Location = new System.Drawing.Point(159, -11);
			this.LblDummy.Name = "LblDummy";
			this.LblDummy.Size = new System.Drawing.Size(0, 20);
			this.LblDummy.TabIndex = 83;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.NumRotationTime);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.NumDeceleration);
			this.groupBox2.Controls.Add(this.NumAcceleration);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.NumTargetVelocity);
			this.groupBox2.Controls.Add(this.label15);
			this.groupBox2.Controls.Add(this.label14);
			this.groupBox2.Controls.Add(this.label13);
			this.groupBox2.Controls.Add(this.label17);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.groupBox2.Location = new System.Drawing.Point(219, 205);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(244, 175);
			this.groupBox2.TabIndex = 74;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "回転設定";
			// 
			// NumRotationTime
			// 
			this.NumRotationTime.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.NumRotationTime.Location = new System.Drawing.Point(79, 133);
			this.NumRotationTime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.NumRotationTime.Name = "NumRotationTime";
			this.NumRotationTime.Size = new System.Drawing.Size(93, 27);
			this.NumRotationTime.TabIndex = 88;
			this.NumRotationTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.NumRotationTime.ValueChanged += new System.EventHandler(this.NumRotationTime_ValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("メイリオ", 9F);
			this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label2.Location = new System.Drawing.Point(172, 107);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(68, 18);
			this.label2.TabIndex = 87;
			this.label2.Text = "[10rpm/s]";
			// 
			// NumDeceleration
			// 
			this.NumDeceleration.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.NumDeceleration.Location = new System.Drawing.Point(79, 98);
			this.NumDeceleration.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.NumDeceleration.Name = "NumDeceleration";
			this.NumDeceleration.Size = new System.Drawing.Size(93, 27);
			this.NumDeceleration.TabIndex = 86;
			this.NumDeceleration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.NumDeceleration.ValueChanged += new System.EventHandler(this.NumDeceleration_ValueChanged);
			// 
			// NumAcceleration
			// 
			this.NumAcceleration.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.NumAcceleration.Location = new System.Drawing.Point(79, 63);
			this.NumAcceleration.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.NumAcceleration.Name = "NumAcceleration";
			this.NumAcceleration.Size = new System.Drawing.Size(93, 27);
			this.NumAcceleration.TabIndex = 85;
			this.NumAcceleration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.NumAcceleration.ValueChanged += new System.EventHandler(this.NumAcceleration_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("メイリオ", 9F);
			this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label1.Location = new System.Drawing.Point(12, 136);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 18);
			this.label1.TabIndex = 84;
			this.label1.Text = "回転時間:";
			// 
			// NumTargetVelocity
			// 
			this.NumTargetVelocity.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.NumTargetVelocity.Location = new System.Drawing.Point(79, 28);
			this.NumTargetVelocity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.NumTargetVelocity.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
			this.NumTargetVelocity.Name = "NumTargetVelocity";
			this.NumTargetVelocity.Size = new System.Drawing.Size(93, 27);
			this.NumTargetVelocity.TabIndex = 83;
			this.NumTargetVelocity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.NumTargetVelocity.ValueChanged += new System.EventHandler(this.NumTargetVelocity_ValueChanged);
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("メイリオ", 9F);
			this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label15.Location = new System.Drawing.Point(175, 142);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(37, 18);
			this.label15.TabIndex = 82;
			this.label15.Text = "[sec]";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("メイリオ", 9F);
			this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label14.Location = new System.Drawing.Point(12, 33);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(61, 18);
			this.label14.TabIndex = 74;
			this.label14.Text = "目標速度:";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("メイリオ", 9F);
			this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label13.Location = new System.Drawing.Point(12, 66);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(49, 18);
			this.label13.TabIndex = 75;
			this.label13.Text = "加速度:";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Font = new System.Drawing.Font("メイリオ", 9F);
			this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label17.Location = new System.Drawing.Point(12, 101);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(49, 18);
			this.label17.TabIndex = 80;
			this.label17.Text = "減速度:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("メイリオ", 9F);
			this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label6.Location = new System.Drawing.Point(172, 37);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(42, 18);
			this.label6.TabIndex = 78;
			this.label6.Text = "[rpm]";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("メイリオ", 9F);
			this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label5.Location = new System.Drawing.Point(172, 72);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(68, 18);
			this.label5.TabIndex = 79;
			this.label5.Text = "[10rpm/s]";
			// 
			// ResolverMountForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(491, 749);
			this.Controls.Add(this.panel1);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ResolverMountForm";
			this.Text = "レゾルバ取付";
			this.TopMost = true;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InspectionForm_FormClosing);
			this.Load += new System.EventHandler(this.InspectionForm_Load);
			this.Shown += new System.EventHandler(this.InspectionForm_Shown);
			this.Resize += new System.EventHandler(this.InspectionForm_Resize);
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.NumRotationTime)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NumDeceleration)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NumAcceleration)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NumTargetVelocity)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private DoubleBufferPanel panel1;
        private System.Windows.Forms.Timer TimerResize;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LblDummy;
        private System.Windows.Forms.NumericUpDown NumRotationTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown NumDeceleration;
        private System.Windows.Forms.NumericUpDown NumAcceleration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NumTargetVelocity;
        private GradientButton BtnCCW;
        private GradientButton BtnCW;
        private GradientButton BtnZeroLock;
        private GradientButton BtnBreakOFF;
        private GradientButton BtnBreakON;
        private GradientButton BtnServoOFF;
        private GradientButton BtnServoON;
        private GradientLabel LblBreak;
        private GradientLabel LblServo;
        private System.Windows.Forms.Timer TimerMotorAction;
        private GradientButton BtnAlarmReset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private GradientButton BtnRotate;
    }
}