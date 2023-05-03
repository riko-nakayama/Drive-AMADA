namespace Motion_Designer
{
	partial class TeachingDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeachingDialog));
			this.grpServoCommand = new System.Windows.Forms.GroupBox();
			this.btnCw = new System.Windows.Forms.Button();
			this.btnServoOn = new System.Windows.Forms.Button();
			this.btnServoOff = new System.Windows.Forms.Button();
			this.btnStop = new System.Windows.Forms.Button();
			this.btnAlarmReset = new System.Windows.Forms.Button();
			this.btnCcw = new System.Windows.Forms.Button();
			this.btnPositionClear = new System.Windows.Forms.Button();
			this.grpVel = new System.Windows.Forms.GroupBox();
			this.rdo100 = new System.Windows.Forms.RadioButton();
			this.rdo50 = new System.Windows.Forms.RadioButton();
			this.rdo10 = new System.Windows.Forms.RadioButton();
			this.grpTeaching = new System.Windows.Forms.GroupBox();
			this.lblPos = new System.Windows.Forms.Label();
			this.lblTargetPosition = new System.Windows.Forms.Label();
			this.lblNowPosition = new System.Windows.Forms.Label();
			this.lblStartPosition = new System.Windows.Forms.Label();
			this.btnTeachTarget = new System.Windows.Forms.Button();
			this.btnClearTarget = new System.Windows.Forms.Button();
			this.btnFinish = new System.Windows.Forms.Button();
			this.btnClearStart = new System.Windows.Forms.Button();
			this.btnTeachStart = new System.Windows.Forms.Button();
			this.TimerMain = new System.Windows.Forms.Timer(this.components);
			this.pnlProfileVelocity = new System.Windows.Forms.Panel();
			this.lblProfileVelocity = new System.Windows.Forms.Label();
			this.grpServoStatus = new System.Windows.Forms.GroupBox();
			this.fpnlStatus = new System.Windows.Forms.FlowLayoutPanel();
			this.picServoOn = new System.Windows.Forms.PictureBox();
			this.lblServoOn = new System.Windows.Forms.Label();
			this.picForwardLimit = new System.Windows.Forms.PictureBox();
			this.lblForwardLimit = new System.Windows.Forms.Label();
			this.picProfile = new System.Windows.Forms.PictureBox();
			this.lblProfile = new System.Windows.Forms.Label();
			this.picReverseLimit = new System.Windows.Forms.PictureBox();
			this.lblReverseLimit = new System.Windows.Forms.Label();
			this.picInPosition = new System.Windows.Forms.PictureBox();
			this.lblInPosition = new System.Windows.Forms.Label();
			this.picTorqueLimit = new System.Windows.Forms.PictureBox();
			this.lblTorqueLimit = new System.Windows.Forms.Label();
			this.picFault = new System.Windows.Forms.PictureBox();
			this.lblFault = new System.Windows.Forms.Label();
			this.picVelocityLimit = new System.Windows.Forms.PictureBox();
			this.lblVelocityLimit = new System.Windows.Forms.Label();
			this.grpServoCommand.SuspendLayout();
			this.grpVel.SuspendLayout();
			this.grpTeaching.SuspendLayout();
			this.pnlProfileVelocity.SuspendLayout();
			this.grpServoStatus.SuspendLayout();
			this.fpnlStatus.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picServoOn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picForwardLimit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picProfile)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picReverseLimit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picInPosition)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picTorqueLimit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picFault)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picVelocityLimit)).BeginInit();
			this.SuspendLayout();
			// 
			// grpServoCommand
			// 
			this.grpServoCommand.Controls.Add(this.btnCw);
			this.grpServoCommand.Controls.Add(this.btnServoOn);
			this.grpServoCommand.Controls.Add(this.btnServoOff);
			this.grpServoCommand.Controls.Add(this.btnStop);
			this.grpServoCommand.Controls.Add(this.btnAlarmReset);
			this.grpServoCommand.Controls.Add(this.btnCcw);
			this.grpServoCommand.Controls.Add(this.btnPositionClear);
			resources.ApplyResources(this.grpServoCommand, "grpServoCommand");
			this.grpServoCommand.Name = "grpServoCommand";
			this.grpServoCommand.TabStop = false;
			// 
			// btnCw
			// 
			resources.ApplyResources(this.btnCw, "btnCw");
			this.btnCw.Name = "btnCw";
			this.btnCw.UseVisualStyleBackColor = true;
			this.btnCw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnCw_MouseDown);
			this.btnCw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnCw_MouseUp);
			// 
			// btnServoOn
			// 
			resources.ApplyResources(this.btnServoOn, "btnServoOn");
			this.btnServoOn.Name = "btnServoOn";
			this.btnServoOn.UseVisualStyleBackColor = true;
			this.btnServoOn.Click += new System.EventHandler(this.btnServoOn_Click);
			// 
			// btnServoOff
			// 
			resources.ApplyResources(this.btnServoOff, "btnServoOff");
			this.btnServoOff.Name = "btnServoOff";
			this.btnServoOff.UseVisualStyleBackColor = true;
			this.btnServoOff.Click += new System.EventHandler(this.btnServoOff_Click);
			// 
			// btnStop
			// 
			resources.ApplyResources(this.btnStop, "btnStop");
			this.btnStop.Name = "btnStop";
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new System.EventHandler(this.btnSmoothStop_Click);
			// 
			// btnAlarmReset
			// 
			resources.ApplyResources(this.btnAlarmReset, "btnAlarmReset");
			this.btnAlarmReset.Name = "btnAlarmReset";
			this.btnAlarmReset.UseVisualStyleBackColor = true;
			this.btnAlarmReset.Click += new System.EventHandler(this.btnAlarmReset_Click);
			// 
			// btnCcw
			// 
			resources.ApplyResources(this.btnCcw, "btnCcw");
			this.btnCcw.Name = "btnCcw";
			this.btnCcw.UseVisualStyleBackColor = true;
			this.btnCcw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnCcw_MouseDown);
			this.btnCcw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnCcw_MouseUp);
			// 
			// btnPositionClear
			// 
			resources.ApplyResources(this.btnPositionClear, "btnPositionClear");
			this.btnPositionClear.Name = "btnPositionClear";
			this.btnPositionClear.UseVisualStyleBackColor = true;
			this.btnPositionClear.Click += new System.EventHandler(this.btnPositionClear_Click);
			// 
			// grpVel
			// 
			this.grpVel.Controls.Add(this.rdo100);
			this.grpVel.Controls.Add(this.rdo50);
			this.grpVel.Controls.Add(this.rdo10);
			resources.ApplyResources(this.grpVel, "grpVel");
			this.grpVel.Name = "grpVel";
			this.grpVel.TabStop = false;
			// 
			// rdo100
			// 
			resources.ApplyResources(this.rdo100, "rdo100");
			this.rdo100.Name = "rdo100";
			this.rdo100.UseVisualStyleBackColor = true;
			this.rdo100.CheckedChanged += new System.EventHandler(this.rdoVel_CheckedChanged);
			// 
			// rdo50
			// 
			resources.ApplyResources(this.rdo50, "rdo50");
			this.rdo50.Name = "rdo50";
			this.rdo50.UseVisualStyleBackColor = true;
			this.rdo50.CheckedChanged += new System.EventHandler(this.rdoVel_CheckedChanged);
			// 
			// rdo10
			// 
			resources.ApplyResources(this.rdo10, "rdo10");
			this.rdo10.Checked = true;
			this.rdo10.Name = "rdo10";
			this.rdo10.TabStop = true;
			this.rdo10.UseVisualStyleBackColor = true;
			this.rdo10.CheckedChanged += new System.EventHandler(this.rdoVel_CheckedChanged);
			// 
			// grpTeaching
			// 
			this.grpTeaching.Controls.Add(this.lblPos);
			this.grpTeaching.Controls.Add(this.lblTargetPosition);
			this.grpTeaching.Controls.Add(this.lblNowPosition);
			this.grpTeaching.Controls.Add(this.lblStartPosition);
			this.grpTeaching.Controls.Add(this.btnTeachTarget);
			this.grpTeaching.Controls.Add(this.btnClearTarget);
			this.grpTeaching.Controls.Add(this.btnFinish);
			this.grpTeaching.Controls.Add(this.btnClearStart);
			this.grpTeaching.Controls.Add(this.btnTeachStart);
			resources.ApplyResources(this.grpTeaching, "grpTeaching");
			this.grpTeaching.Name = "grpTeaching";
			this.grpTeaching.TabStop = false;
			// 
			// lblPos
			// 
			this.lblPos.BackColor = System.Drawing.Color.LightCyan;
			this.lblPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			resources.ApplyResources(this.lblPos, "lblPos");
			this.lblPos.Name = "lblPos";
			// 
			// lblTargetPosition
			// 
			this.lblTargetPosition.BackColor = System.Drawing.Color.Gainsboro;
			this.lblTargetPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			resources.ApplyResources(this.lblTargetPosition, "lblTargetPosition");
			this.lblTargetPosition.Name = "lblTargetPosition";
			// 
			// lblNowPosition
			// 
			this.lblNowPosition.BackColor = System.Drawing.Color.White;
			this.lblNowPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			resources.ApplyResources(this.lblNowPosition, "lblNowPosition");
			this.lblNowPosition.Name = "lblNowPosition";
			// 
			// lblStartPosition
			// 
			this.lblStartPosition.BackColor = System.Drawing.Color.Gainsboro;
			this.lblStartPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			resources.ApplyResources(this.lblStartPosition, "lblStartPosition");
			this.lblStartPosition.Name = "lblStartPosition";
			// 
			// btnTeachTarget
			// 
			resources.ApplyResources(this.btnTeachTarget, "btnTeachTarget");
			this.btnTeachTarget.Name = "btnTeachTarget";
			this.btnTeachTarget.UseVisualStyleBackColor = true;
			this.btnTeachTarget.Click += new System.EventHandler(this.btnTeachTarget_Click);
			// 
			// btnClearTarget
			// 
			resources.ApplyResources(this.btnClearTarget, "btnClearTarget");
			this.btnClearTarget.Name = "btnClearTarget";
			this.btnClearTarget.UseVisualStyleBackColor = true;
			this.btnClearTarget.Click += new System.EventHandler(this.btnClearTarget_Click);
			// 
			// btnFinish
			// 
			resources.ApplyResources(this.btnFinish, "btnFinish");
			this.btnFinish.Name = "btnFinish";
			this.btnFinish.UseVisualStyleBackColor = true;
			this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
			// 
			// btnClearStart
			// 
			resources.ApplyResources(this.btnClearStart, "btnClearStart");
			this.btnClearStart.Name = "btnClearStart";
			this.btnClearStart.UseVisualStyleBackColor = true;
			this.btnClearStart.Click += new System.EventHandler(this.btnClearStart_Click);
			// 
			// btnTeachStart
			// 
			resources.ApplyResources(this.btnTeachStart, "btnTeachStart");
			this.btnTeachStart.Name = "btnTeachStart";
			this.btnTeachStart.UseVisualStyleBackColor = true;
			this.btnTeachStart.Click += new System.EventHandler(this.btnTeachStart_Click);
			// 
			// TimerMain
			// 
			this.TimerMain.Interval = 500;
			this.TimerMain.Tick += new System.EventHandler(this.TimerMain_Tick);
			// 
			// pnlProfileVelocity
			// 
			this.pnlProfileVelocity.BackColor = System.Drawing.Color.Pink;
			this.pnlProfileVelocity.Controls.Add(this.lblProfileVelocity);
			resources.ApplyResources(this.pnlProfileVelocity, "pnlProfileVelocity");
			this.pnlProfileVelocity.Name = "pnlProfileVelocity";
			// 
			// lblProfileVelocity
			// 
			resources.ApplyResources(this.lblProfileVelocity, "lblProfileVelocity");
			this.lblProfileVelocity.Name = "lblProfileVelocity";
			// 
			// grpServoStatus
			// 
			this.grpServoStatus.Controls.Add(this.fpnlStatus);
			resources.ApplyResources(this.grpServoStatus, "grpServoStatus");
			this.grpServoStatus.Name = "grpServoStatus";
			this.grpServoStatus.TabStop = false;
			// 
			// fpnlStatus
			// 
			this.fpnlStatus.BackColor = System.Drawing.Color.DimGray;
			this.fpnlStatus.Controls.Add(this.picServoOn);
			this.fpnlStatus.Controls.Add(this.lblServoOn);
			this.fpnlStatus.Controls.Add(this.picForwardLimit);
			this.fpnlStatus.Controls.Add(this.lblForwardLimit);
			this.fpnlStatus.Controls.Add(this.picProfile);
			this.fpnlStatus.Controls.Add(this.lblProfile);
			this.fpnlStatus.Controls.Add(this.picReverseLimit);
			this.fpnlStatus.Controls.Add(this.lblReverseLimit);
			this.fpnlStatus.Controls.Add(this.picInPosition);
			this.fpnlStatus.Controls.Add(this.lblInPosition);
			this.fpnlStatus.Controls.Add(this.picTorqueLimit);
			this.fpnlStatus.Controls.Add(this.lblTorqueLimit);
			this.fpnlStatus.Controls.Add(this.picFault);
			this.fpnlStatus.Controls.Add(this.lblFault);
			this.fpnlStatus.Controls.Add(this.picVelocityLimit);
			this.fpnlStatus.Controls.Add(this.lblVelocityLimit);
			resources.ApplyResources(this.fpnlStatus, "fpnlStatus");
			this.fpnlStatus.Name = "fpnlStatus";
			// 
			// picServoOn
			// 
			this.picServoOn.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(this.picServoOn, "picServoOn");
			this.picServoOn.Name = "picServoOn";
			this.picServoOn.TabStop = false;
			// 
			// lblServoOn
			// 
			this.lblServoOn.BackColor = System.Drawing.SystemColors.Control;
			resources.ApplyResources(this.lblServoOn, "lblServoOn");
			this.lblServoOn.Name = "lblServoOn";
			// 
			// picForwardLimit
			// 
			this.picForwardLimit.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(this.picForwardLimit, "picForwardLimit");
			this.picForwardLimit.Name = "picForwardLimit";
			this.picForwardLimit.TabStop = false;
			// 
			// lblForwardLimit
			// 
			this.lblForwardLimit.BackColor = System.Drawing.SystemColors.Control;
			resources.ApplyResources(this.lblForwardLimit, "lblForwardLimit");
			this.lblForwardLimit.Name = "lblForwardLimit";
			// 
			// picProfile
			// 
			this.picProfile.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(this.picProfile, "picProfile");
			this.picProfile.Name = "picProfile";
			this.picProfile.TabStop = false;
			// 
			// lblProfile
			// 
			this.lblProfile.BackColor = System.Drawing.SystemColors.Control;
			resources.ApplyResources(this.lblProfile, "lblProfile");
			this.lblProfile.Name = "lblProfile";
			// 
			// picReverseLimit
			// 
			this.picReverseLimit.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(this.picReverseLimit, "picReverseLimit");
			this.picReverseLimit.Name = "picReverseLimit";
			this.picReverseLimit.TabStop = false;
			// 
			// lblReverseLimit
			// 
			this.lblReverseLimit.BackColor = System.Drawing.SystemColors.Control;
			resources.ApplyResources(this.lblReverseLimit, "lblReverseLimit");
			this.lblReverseLimit.Name = "lblReverseLimit";
			// 
			// picInPosition
			// 
			this.picInPosition.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(this.picInPosition, "picInPosition");
			this.picInPosition.Name = "picInPosition";
			this.picInPosition.TabStop = false;
			// 
			// lblInPosition
			// 
			this.lblInPosition.BackColor = System.Drawing.SystemColors.Control;
			resources.ApplyResources(this.lblInPosition, "lblInPosition");
			this.lblInPosition.Name = "lblInPosition";
			// 
			// picTorqueLimit
			// 
			this.picTorqueLimit.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(this.picTorqueLimit, "picTorqueLimit");
			this.picTorqueLimit.Name = "picTorqueLimit";
			this.picTorqueLimit.TabStop = false;
			// 
			// lblTorqueLimit
			// 
			this.lblTorqueLimit.BackColor = System.Drawing.SystemColors.Control;
			resources.ApplyResources(this.lblTorqueLimit, "lblTorqueLimit");
			this.lblTorqueLimit.Name = "lblTorqueLimit";
			// 
			// picFault
			// 
			this.picFault.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(this.picFault, "picFault");
			this.picFault.Name = "picFault";
			this.picFault.TabStop = false;
			// 
			// lblFault
			// 
			this.lblFault.BackColor = System.Drawing.SystemColors.Control;
			resources.ApplyResources(this.lblFault, "lblFault");
			this.lblFault.Name = "lblFault";
			// 
			// picVelocityLimit
			// 
			this.picVelocityLimit.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(this.picVelocityLimit, "picVelocityLimit");
			this.picVelocityLimit.Name = "picVelocityLimit";
			this.picVelocityLimit.TabStop = false;
			// 
			// lblVelocityLimit
			// 
			this.lblVelocityLimit.BackColor = System.Drawing.SystemColors.Control;
			resources.ApplyResources(this.lblVelocityLimit, "lblVelocityLimit");
			this.lblVelocityLimit.Name = "lblVelocityLimit";
			// 
			// TeachingDialog
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.grpServoStatus);
			this.Controls.Add(this.pnlProfileVelocity);
			this.Controls.Add(this.grpTeaching);
			this.Controls.Add(this.grpVel);
			this.Controls.Add(this.grpServoCommand);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "TeachingDialog";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.TeachingForm_Load);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TeachingForm_FormClosed);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TeachingForm_FormClosing);
			this.grpServoCommand.ResumeLayout(false);
			this.grpVel.ResumeLayout(false);
			this.grpVel.PerformLayout();
			this.grpTeaching.ResumeLayout(false);
			this.pnlProfileVelocity.ResumeLayout(false);
			this.pnlProfileVelocity.PerformLayout();
			this.grpServoStatus.ResumeLayout(false);
			this.fpnlStatus.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picServoOn)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picForwardLimit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picProfile)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picReverseLimit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picInPosition)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picTorqueLimit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picFault)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picVelocityLimit)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox grpServoCommand;
		private System.Windows.Forms.Button btnCw;
		private System.Windows.Forms.Button btnServoOn;
		private System.Windows.Forms.Button btnServoOff;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.Button btnAlarmReset;
		private System.Windows.Forms.Button btnCcw;
		private System.Windows.Forms.Button btnPositionClear;
		private System.Windows.Forms.GroupBox grpVel;
		private System.Windows.Forms.RadioButton rdo100;
		private System.Windows.Forms.RadioButton rdo50;
		private System.Windows.Forms.RadioButton rdo10;
		private System.Windows.Forms.GroupBox grpTeaching;
		private System.Windows.Forms.Button btnTeachStart;
		private System.Windows.Forms.Timer TimerMain;
		private System.Windows.Forms.Label lblStartPosition;
		private System.Windows.Forms.Panel pnlProfileVelocity;
		private System.Windows.Forms.Label lblProfileVelocity;
		private System.Windows.Forms.Label lblNowPosition;
		private System.Windows.Forms.Button btnTeachTarget;
		private System.Windows.Forms.Label lblPos;
		private System.Windows.Forms.Label lblTargetPosition;
		private System.Windows.Forms.GroupBox grpServoStatus;
		private System.Windows.Forms.FlowLayoutPanel fpnlStatus;
		private System.Windows.Forms.PictureBox picServoOn;
		private System.Windows.Forms.Label lblServoOn;
		private System.Windows.Forms.PictureBox picForwardLimit;
		private System.Windows.Forms.Label lblForwardLimit;
		private System.Windows.Forms.PictureBox picProfile;
		private System.Windows.Forms.Label lblProfile;
		private System.Windows.Forms.PictureBox picReverseLimit;
		private System.Windows.Forms.Label lblReverseLimit;
		private System.Windows.Forms.PictureBox picInPosition;
		private System.Windows.Forms.Label lblInPosition;
		private System.Windows.Forms.PictureBox picTorqueLimit;
		private System.Windows.Forms.Label lblTorqueLimit;
		private System.Windows.Forms.PictureBox picFault;
		private System.Windows.Forms.Label lblFault;
		private System.Windows.Forms.PictureBox picVelocityLimit;
		private System.Windows.Forms.Label lblVelocityLimit;
		private System.Windows.Forms.Button btnClearStart;
		private System.Windows.Forms.Button btnClearTarget;
		private System.Windows.Forms.Button btnFinish;
	}
}