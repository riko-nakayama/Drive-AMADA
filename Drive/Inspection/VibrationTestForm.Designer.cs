
namespace Motion_Designer
{
	partial class VibrationTestForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VibrationTestForm));
			this.btnServoOn = new System.Windows.Forms.Button();
			this.btnAlaramReset = new System.Windows.Forms.Button();
			this.btnServoOff = new System.Windows.Forms.Button();
			this.grpOperation = new System.Windows.Forms.GroupBox();
			this.btnLs = new System.Windows.Forms.Button();
			this.btnHs = new System.Windows.Forms.Button();
			this.btnStop = new System.Windows.Forms.Button();
			this.grpClutch = new System.Windows.Forms.GroupBox();
			this.rdoLsClutch = new System.Windows.Forms.RadioButton();
			this.rdoHsClutch = new System.Windows.Forms.RadioButton();
			this.grpDirection = new System.Windows.Forms.GroupBox();
			this.rdoCcw = new System.Windows.Forms.RadioButton();
			this.rdoCw = new System.Windows.Forms.RadioButton();
			this.grpSpeed = new System.Windows.Forms.GroupBox();
			this.rdoLow = new System.Windows.Forms.RadioButton();
			this.rdoMiddle = new System.Windows.Forms.RadioButton();
			this.rdoHigh = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.numHigh = new System.Windows.Forms.NumericUpDown();
			this.numMiddle = new System.Windows.Forms.NumericUpDown();
			this.numLow = new System.Windows.Forms.NumericUpDown();
			this.lblHigh = new System.Windows.Forms.Label();
			this.lblMiddle = new System.Windows.Forms.Label();
			this.lblLow = new System.Windows.Forms.Label();
			this.btnStart = new System.Windows.Forms.Button();
			this.TimerResize = new System.Windows.Forms.Timer(this.components);
			this.grpOperation.SuspendLayout();
			this.grpClutch.SuspendLayout();
			this.grpDirection.SuspendLayout();
			this.grpSpeed.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numHigh)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numMiddle)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numLow)).BeginInit();
			this.SuspendLayout();
			// 
			// btnServoOn
			// 
			this.btnServoOn.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnServoOn.Location = new System.Drawing.Point(20, 25);
			this.btnServoOn.Name = "btnServoOn";
			this.btnServoOn.Size = new System.Drawing.Size(110, 30);
			this.btnServoOn.TabIndex = 0;
			this.btnServoOn.TabStop = false;
			this.btnServoOn.Text = "サーボオン";
			this.btnServoOn.UseVisualStyleBackColor = true;
			this.btnServoOn.Click += new System.EventHandler(this.btnServoOn_Click);
			// 
			// btnAlaramReset
			// 
			this.btnAlaramReset.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnAlaramReset.Location = new System.Drawing.Point(270, 25);
			this.btnAlaramReset.Name = "btnAlaramReset";
			this.btnAlaramReset.Size = new System.Drawing.Size(110, 30);
			this.btnAlaramReset.TabIndex = 2;
			this.btnAlaramReset.TabStop = false;
			this.btnAlaramReset.Text = "アラーム解除";
			this.btnAlaramReset.UseVisualStyleBackColor = true;
			this.btnAlaramReset.Click += new System.EventHandler(this.btnAlaramReset_Click);
			// 
			// btnServoOff
			// 
			this.btnServoOff.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnServoOff.Location = new System.Drawing.Point(145, 25);
			this.btnServoOff.Name = "btnServoOff";
			this.btnServoOff.Size = new System.Drawing.Size(110, 30);
			this.btnServoOff.TabIndex = 1;
			this.btnServoOff.TabStop = false;
			this.btnServoOff.Text = "サーボオフ";
			this.btnServoOff.UseVisualStyleBackColor = true;
			this.btnServoOff.Click += new System.EventHandler(this.btnServoOff_Click);
			// 
			// grpOperation
			// 
			this.grpOperation.Controls.Add(this.btnLs);
			this.grpOperation.Controls.Add(this.btnHs);
			this.grpOperation.Controls.Add(this.btnServoOn);
			this.grpOperation.Controls.Add(this.btnAlaramReset);
			this.grpOperation.Controls.Add(this.btnServoOff);
			this.grpOperation.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.grpOperation.Location = new System.Drawing.Point(20, 20);
			this.grpOperation.Name = "grpOperation";
			this.grpOperation.Size = new System.Drawing.Size(460, 105);
			this.grpOperation.TabIndex = 1;
			this.grpOperation.TabStop = false;
			this.grpOperation.Text = "コマンド操作";
			// 
			// btnLs
			// 
			this.btnLs.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnLs.Location = new System.Drawing.Point(145, 65);
			this.btnLs.Name = "btnLs";
			this.btnLs.Size = new System.Drawing.Size(110, 30);
			this.btnLs.TabIndex = 4;
			this.btnLs.TabStop = false;
			this.btnLs.Text = "クラッチ低速";
			this.btnLs.UseVisualStyleBackColor = true;
			this.btnLs.Click += new System.EventHandler(this.btnLs_Click);
			// 
			// btnHs
			// 
			this.btnHs.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnHs.Location = new System.Drawing.Point(20, 65);
			this.btnHs.Name = "btnHs";
			this.btnHs.Size = new System.Drawing.Size(110, 30);
			this.btnHs.TabIndex = 3;
			this.btnHs.TabStop = false;
			this.btnHs.Text = "クラッチ高速";
			this.btnHs.UseVisualStyleBackColor = true;
			this.btnHs.Click += new System.EventHandler(this.btnHs_Click);
			// 
			// btnStop
			// 
			this.btnStop.BackColor = System.Drawing.Color.DarkSalmon;
			this.btnStop.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnStop.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnStop.Location = new System.Drawing.Point(180, 450);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(300, 45);
			this.btnStop.TabIndex = 0;
			this.btnStop.Text = "モータ回転停止";
			this.btnStop.UseVisualStyleBackColor = false;
			this.btnStop.Click += new System.EventHandler(this.btnHsStop_Click);
			// 
			// grpClutch
			// 
			this.grpClutch.Controls.Add(this.rdoLsClutch);
			this.grpClutch.Controls.Add(this.rdoHsClutch);
			this.grpClutch.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.grpClutch.Location = new System.Drawing.Point(20, 130);
			this.grpClutch.Name = "grpClutch";
			this.grpClutch.Size = new System.Drawing.Size(460, 60);
			this.grpClutch.TabIndex = 2;
			this.grpClutch.TabStop = false;
			this.grpClutch.Text = "クラッチ設定";
			// 
			// rdoLsClutch
			// 
			this.rdoLsClutch.AutoSize = true;
			this.rdoLsClutch.Location = new System.Drawing.Point(160, 25);
			this.rdoLsClutch.Name = "rdoLsClutch";
			this.rdoLsClutch.Size = new System.Drawing.Size(110, 22);
			this.rdoLsClutch.TabIndex = 1;
			this.rdoLsClutch.Text = "クラッチ低速側";
			this.rdoLsClutch.UseVisualStyleBackColor = true;
			this.rdoLsClutch.CheckedChanged += new System.EventHandler(this.rdoHsClutch_CheckedChanged);
			// 
			// rdoHsClutch
			// 
			this.rdoHsClutch.AutoSize = true;
			this.rdoHsClutch.BackColor = System.Drawing.Color.Gold;
			this.rdoHsClutch.Checked = true;
			this.rdoHsClutch.Location = new System.Drawing.Point(20, 25);
			this.rdoHsClutch.Name = "rdoHsClutch";
			this.rdoHsClutch.Size = new System.Drawing.Size(110, 22);
			this.rdoHsClutch.TabIndex = 0;
			this.rdoHsClutch.TabStop = true;
			this.rdoHsClutch.Text = "クラッチ高速側";
			this.rdoHsClutch.UseVisualStyleBackColor = false;
			this.rdoHsClutch.CheckedChanged += new System.EventHandler(this.rdoHsClutch_CheckedChanged);
			// 
			// grpDirection
			// 
			this.grpDirection.Controls.Add(this.rdoCcw);
			this.grpDirection.Controls.Add(this.rdoCw);
			this.grpDirection.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.grpDirection.Location = new System.Drawing.Point(20, 200);
			this.grpDirection.Name = "grpDirection";
			this.grpDirection.Size = new System.Drawing.Size(460, 60);
			this.grpDirection.TabIndex = 3;
			this.grpDirection.TabStop = false;
			this.grpDirection.Text = "モータ回転方向設定";
			// 
			// rdoCcw
			// 
			this.rdoCcw.AutoSize = true;
			this.rdoCcw.Location = new System.Drawing.Point(160, 25);
			this.rdoCcw.Name = "rdoCcw";
			this.rdoCcw.Size = new System.Drawing.Size(138, 22);
			this.rdoCcw.TabIndex = 1;
			this.rdoCcw.Text = "負方向回転（CCW）";
			this.rdoCcw.UseVisualStyleBackColor = true;
			// 
			// rdoCw
			// 
			this.rdoCw.AutoSize = true;
			this.rdoCw.BackColor = System.Drawing.Color.Gold;
			this.rdoCw.Checked = true;
			this.rdoCw.Location = new System.Drawing.Point(20, 25);
			this.rdoCw.Name = "rdoCw";
			this.rdoCw.Size = new System.Drawing.Size(130, 22);
			this.rdoCw.TabIndex = 0;
			this.rdoCw.TabStop = true;
			this.rdoCw.Text = "正方向回転（CW）";
			this.rdoCw.UseVisualStyleBackColor = false;
			this.rdoCw.CheckedChanged += new System.EventHandler(this.rdoCw_CheckedChanged);
			// 
			// grpSpeed
			// 
			this.grpSpeed.Controls.Add(this.rdoLow);
			this.grpSpeed.Controls.Add(this.rdoMiddle);
			this.grpSpeed.Controls.Add(this.rdoHigh);
			this.grpSpeed.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.grpSpeed.Location = new System.Drawing.Point(20, 270);
			this.grpSpeed.Name = "grpSpeed";
			this.grpSpeed.Size = new System.Drawing.Size(460, 60);
			this.grpSpeed.TabIndex = 4;
			this.grpSpeed.TabStop = false;
			this.grpSpeed.Text = "モータ回転速度設定";
			// 
			// rdoLow
			// 
			this.rdoLow.AutoSize = true;
			this.rdoLow.BackColor = System.Drawing.Color.Gold;
			this.rdoLow.Checked = true;
			this.rdoLow.Location = new System.Drawing.Point(20, 25);
			this.rdoLow.Name = "rdoLow";
			this.rdoLow.Size = new System.Drawing.Size(74, 22);
			this.rdoLow.TabIndex = 0;
			this.rdoLow.TabStop = true;
			this.rdoLow.Text = "低速回転";
			this.rdoLow.UseVisualStyleBackColor = false;
			this.rdoLow.CheckedChanged += new System.EventHandler(this.rdoLow_CheckedChanged);
			// 
			// rdoMiddle
			// 
			this.rdoMiddle.AutoSize = true;
			this.rdoMiddle.Location = new System.Drawing.Point(160, 25);
			this.rdoMiddle.Name = "rdoMiddle";
			this.rdoMiddle.Size = new System.Drawing.Size(74, 22);
			this.rdoMiddle.TabIndex = 1;
			this.rdoMiddle.Text = "中速回転";
			this.rdoMiddle.UseVisualStyleBackColor = true;
			// 
			// rdoHigh
			// 
			this.rdoHigh.AutoSize = true;
			this.rdoHigh.Location = new System.Drawing.Point(290, 25);
			this.rdoHigh.Name = "rdoHigh";
			this.rdoHigh.Size = new System.Drawing.Size(74, 22);
			this.rdoHigh.TabIndex = 2;
			this.rdoHigh.Text = "高速回転";
			this.rdoHigh.UseVisualStyleBackColor = true;
			this.rdoHigh.CheckedChanged += new System.EventHandler(this.rdoLow_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.numHigh);
			this.groupBox1.Controls.Add(this.numMiddle);
			this.groupBox1.Controls.Add(this.numLow);
			this.groupBox1.Controls.Add(this.lblHigh);
			this.groupBox1.Controls.Add(this.lblMiddle);
			this.groupBox1.Controls.Add(this.lblLow);
			this.groupBox1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.groupBox1.Location = new System.Drawing.Point(20, 340);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(460, 85);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "モータ回転速度設定（管理者）";
			// 
			// numHigh
			// 
			this.numHigh.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Motion_Designer.Properties.Settings.Default, "VibrationHighSpeed", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.numHigh.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.numHigh.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.numHigh.Location = new System.Drawing.Point(295, 45);
			this.numHigh.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this.numHigh.Name = "numHigh";
			this.numHigh.Size = new System.Drawing.Size(110, 27);
			this.numHigh.TabIndex = 2;
			this.numHigh.TabStop = false;
			this.numHigh.Tag = "High";
			this.numHigh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numHigh.Value = global::Motion_Designer.Properties.Settings.Default.VibrationHighSpeed;
			this.numHigh.ValueChanged += new System.EventHandler(this.numSpeed_ValueChanged);
			// 
			// numMiddle
			// 
			this.numMiddle.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Motion_Designer.Properties.Settings.Default, "VibrationMiddleSpeed", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.numMiddle.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.numMiddle.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.numMiddle.Location = new System.Drawing.Point(160, 45);
			this.numMiddle.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this.numMiddle.Name = "numMiddle";
			this.numMiddle.Size = new System.Drawing.Size(110, 27);
			this.numMiddle.TabIndex = 1;
			this.numMiddle.TabStop = false;
			this.numMiddle.Tag = "Middle";
			this.numMiddle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numMiddle.Value = global::Motion_Designer.Properties.Settings.Default.VibrationMiddleSpeed;
			this.numMiddle.ValueChanged += new System.EventHandler(this.numSpeed_ValueChanged);
			// 
			// numLow
			// 
			this.numLow.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Motion_Designer.Properties.Settings.Default, "VibrationLowSpeed", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.numLow.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.numLow.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.numLow.Location = new System.Drawing.Point(20, 45);
			this.numLow.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this.numLow.Name = "numLow";
			this.numLow.Size = new System.Drawing.Size(110, 27);
			this.numLow.TabIndex = 0;
			this.numLow.TabStop = false;
			this.numLow.Tag = "Low";
			this.numLow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numLow.Value = global::Motion_Designer.Properties.Settings.Default.VibrationLowSpeed;
			this.numLow.ValueChanged += new System.EventHandler(this.numSpeed_ValueChanged);
			// 
			// lblHigh
			// 
			this.lblHigh.AutoSize = true;
			this.lblHigh.Font = new System.Drawing.Font("メイリオ", 9F);
			this.lblHigh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lblHigh.Location = new System.Drawing.Point(295, 25);
			this.lblHigh.Name = "lblHigh";
			this.lblHigh.Size = new System.Drawing.Size(118, 18);
			this.lblHigh.TabIndex = 2;
			this.lblHigh.Text = "高速回転速度 [rpm]";
			// 
			// lblMiddle
			// 
			this.lblMiddle.AutoSize = true;
			this.lblMiddle.Font = new System.Drawing.Font("メイリオ", 9F);
			this.lblMiddle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lblMiddle.Location = new System.Drawing.Point(160, 25);
			this.lblMiddle.Name = "lblMiddle";
			this.lblMiddle.Size = new System.Drawing.Size(106, 18);
			this.lblMiddle.TabIndex = 84;
			this.lblMiddle.Text = "中回転速度 [rpm]";
			// 
			// lblLow
			// 
			this.lblLow.AutoSize = true;
			this.lblLow.Font = new System.Drawing.Font("メイリオ", 9F);
			this.lblLow.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lblLow.Location = new System.Drawing.Point(20, 25);
			this.lblLow.Name = "lblLow";
			this.lblLow.Size = new System.Drawing.Size(118, 18);
			this.lblLow.TabIndex = 1;
			this.lblLow.Text = "低速回転速度 [rpm]";
			// 
			// btnStart
			// 
			this.btnStart.BackColor = System.Drawing.SystemColors.Control;
			this.btnStart.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnStart.Location = new System.Drawing.Point(20, 450);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(130, 45);
			this.btnStart.TabIndex = 1;
			this.btnStart.Text = "モータ回転開始";
			this.btnStart.UseVisualStyleBackColor = false;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// TimerResize
			// 
			this.TimerResize.Interval = 500;
			this.TimerResize.Tick += new System.EventHandler(this.TimerResize_Tick);
			// 
			// VibrationTestForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnStop;
			this.ClientSize = new System.Drawing.Size(491, 749);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.grpSpeed);
			this.Controls.Add(this.grpDirection);
			this.Controls.Add(this.grpClutch);
			this.Controls.Add(this.grpOperation);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.btnStop);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "VibrationTestForm";
			this.Text = "振動・騒音テスト";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VibrationTestForm_FormClosing);
			this.Load += new System.EventHandler(this.VibrationTestForm_Load);
			this.Resize += new System.EventHandler(this.VibrationTestForm_Resize);
			this.grpOperation.ResumeLayout(false);
			this.grpClutch.ResumeLayout(false);
			this.grpClutch.PerformLayout();
			this.grpDirection.ResumeLayout(false);
			this.grpDirection.PerformLayout();
			this.grpSpeed.ResumeLayout(false);
			this.grpSpeed.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numHigh)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numMiddle)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numLow)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnServoOn;
		private System.Windows.Forms.Button btnAlaramReset;
		private System.Windows.Forms.Button btnServoOff;
		private System.Windows.Forms.GroupBox grpOperation;
		private System.Windows.Forms.Button btnLs;
		private System.Windows.Forms.Button btnHs;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.GroupBox grpClutch;
		private System.Windows.Forms.RadioButton rdoLsClutch;
		private System.Windows.Forms.RadioButton rdoHsClutch;
		private System.Windows.Forms.GroupBox grpDirection;
		private System.Windows.Forms.RadioButton rdoCcw;
		private System.Windows.Forms.RadioButton rdoCw;
		private System.Windows.Forms.GroupBox grpSpeed;
		private System.Windows.Forms.RadioButton rdoLow;
		private System.Windows.Forms.RadioButton rdoMiddle;
		private System.Windows.Forms.RadioButton rdoHigh;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.NumericUpDown numHigh;
		private System.Windows.Forms.NumericUpDown numMiddle;
		private System.Windows.Forms.NumericUpDown numLow;
		private System.Windows.Forms.Label lblHigh;
		private System.Windows.Forms.Label lblMiddle;
		private System.Windows.Forms.Label lblLow;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Timer TimerResize;
	}
}