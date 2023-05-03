namespace Motion_Designer
{
	partial class CtlJogControl
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

		#region コンポーネント デザイナで生成されたコード

		/// <summary> 
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を 
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlJogControl));
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
            this.lblVelUnit = new System.Windows.Forms.Label();
            this.lblPosUnit = new System.Windows.Forms.Label();
            this.lblCurUnit = new System.Windows.Forms.Label();
            this.grpServoStatus = new System.Windows.Forms.GroupBox();
            this.lblSvdAlarm = new System.Windows.Forms.Label();
            this.grpServoCommand = new System.Windows.Forms.GroupBox();
            this.btnCw = new System.Windows.Forms.Button();
            this.btnServoOn = new System.Windows.Forms.Button();
            this.btnServoOff = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnAlarmReset = new System.Windows.Forms.Button();
            this.btnCcw = new System.Windows.Forms.Button();
            this.btnPositionClear = new System.Windows.Forms.Button();
            this.toolTipJog = new System.Windows.Forms.ToolTip(this.components);
            this.rdoAbs = new System.Windows.Forms.RadioButton();
            this.rdoInc = new System.Windows.Forms.RadioButton();
            this.numContinue = new System.Windows.Forms.NumericUpDown();
            this.lblContinue = new System.Windows.Forms.Label();
            this.chkContinue = new System.Windows.Forms.CheckBox();
            this.chkHardStop = new System.Windows.Forms.CheckBox();
            this.chkButtonLock = new System.Windows.Forms.CheckBox();
            this.chkVelocityLimit = new System.Windows.Forms.CheckBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.grpServoFeedBack = new System.Windows.Forms.GroupBox();
            this.fpnlKashiyamaMonitor = new System.Windows.Forms.FlowLayoutPanel();
            this.lblOutputPower = new System.Windows.Forms.Label();
            this.txtOutputPower = new System.Windows.Forms.Label();
            this.lblOutputPowerUnit = new System.Windows.Forms.Label();
            this.fpnlFeedback = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSep1 = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.txtPosition = new System.Windows.Forms.Label();
            this.lblVelocity = new System.Windows.Forms.Label();
            this.txtVelocity = new System.Windows.Forms.Label();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.txtCurrent = new System.Windows.Forms.Label();
            this.lblSep2 = new System.Windows.Forms.Label();
            this.lblOverLoad = new System.Windows.Forms.Label();
            this.txtOverload = new System.Windows.Forms.Label();
            this.llblOverLoadUnit = new System.Windows.Forms.Label();
            this.lblDriverTemp = new System.Windows.Forms.Label();
            this.txtDriverTemp = new System.Windows.Forms.Label();
            this.lblDriverTempUnit = new System.Windows.Forms.Label();
            this.lblPowerVoltage = new System.Windows.Forms.Label();
            this.txtPowerVoltage = new System.Windows.Forms.Label();
            this.lblPowerVoltageUnit = new System.Windows.Forms.Label();
            this.lblDummy = new System.Windows.Forms.Label();
            this.grpVelocity = new System.Windows.Forms.GroupBox();
            this.ctlNumTargetVelocity = new Motion_Designer.CtlNumericInputInt();
            this.grpAcceleration = new System.Windows.Forms.GroupBox();
            this.lblAccTime = new System.Windows.Forms.Label();
            this.ctlNumTargetAcceleration = new Motion_Designer.CtlNumericInputInt();
            this.grpDeceleration = new System.Windows.Forms.GroupBox();
            this.lblDccTime = new System.Windows.Forms.Label();
            this.ctlNumTargetDeceleration = new Motion_Designer.CtlNumericInputInt();
            this.grpPosition1 = new System.Windows.Forms.GroupBox();
            this.ctlNumTargetPosition1 = new Motion_Designer.CtlNumericInputInt();
            this.lblStatusPage = new System.Windows.Forms.Label();
            this.grpPosition2 = new System.Windows.Forms.GroupBox();
            this.ctlNumTargetPosition2 = new Motion_Designer.CtlNumericInputInt();
            this.tabJogSetting = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnAnalogZeorAdjust = new System.Windows.Forms.Button();
            this.btnAbsReset = new System.Windows.Forms.Button();
            this.lblTarget = new System.Windows.Forms.Label();
            this.pnlCommand = new System.Windows.Forms.Panel();
            this.btnBack2 = new System.Windows.Forms.Button();
            this.btnGo2 = new System.Windows.Forms.Button();
            this.pnlSetting = new System.Windows.Forms.Panel();
            this.tabJogControl = new System.Windows.Forms.TabControl();
            this.tabPageCommand = new System.Windows.Forms.TabPage();
            this.tabPageSetting = new System.Windows.Forms.TabPage();
            this.grpTeaching1 = new System.Windows.Forms.GroupBox();
            this.lblTeaching1 = new System.Windows.Forms.Label();
            this.btnTeaching1 = new System.Windows.Forms.Button();
            this.grpTeaching2 = new System.Windows.Forms.GroupBox();
            this.lblTeaching2 = new System.Windows.Forms.Label();
            this.btnTeaching2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.TimerJog = new System.Windows.Forms.Timer(this.components);
            this.TimerJogStop = new System.Windows.Forms.Timer(this.components);
            this.fpnlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picServoOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picForwardLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picReverseLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTorqueLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFault)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVelocityLimit)).BeginInit();
            this.grpServoStatus.SuspendLayout();
            this.grpServoCommand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numContinue)).BeginInit();
            this.grpServoFeedBack.SuspendLayout();
            this.fpnlKashiyamaMonitor.SuspendLayout();
            this.fpnlFeedback.SuspendLayout();
            this.grpVelocity.SuspendLayout();
            this.grpAcceleration.SuspendLayout();
            this.grpDeceleration.SuspendLayout();
            this.grpPosition1.SuspendLayout();
            this.grpPosition2.SuspendLayout();
            this.tabJogSetting.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.pnlCommand.SuspendLayout();
            this.pnlSetting.SuspendLayout();
            this.tabJogControl.SuspendLayout();
            this.grpTeaching1.SuspendLayout();
            this.grpTeaching2.SuspendLayout();
            this.SuspendLayout();
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
            // lblVelUnit
            // 
            this.lblVelUnit.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.lblVelUnit, "lblVelUnit");
            this.lblVelUnit.Name = "lblVelUnit";
            // 
            // lblPosUnit
            // 
            this.lblPosUnit.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.lblPosUnit, "lblPosUnit");
            this.lblPosUnit.Name = "lblPosUnit";
            // 
            // lblCurUnit
            // 
            this.lblCurUnit.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.lblCurUnit, "lblCurUnit");
            this.lblCurUnit.Name = "lblCurUnit";
            // 
            // grpServoStatus
            // 
            this.grpServoStatus.Controls.Add(this.fpnlStatus);
            resources.ApplyResources(this.grpServoStatus, "grpServoStatus");
            this.grpServoStatus.Name = "grpServoStatus";
            this.grpServoStatus.TabStop = false;
            // 
            // lblSvdAlarm
            // 
            this.lblSvdAlarm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.lblSvdAlarm, "lblSvdAlarm");
            this.lblSvdAlarm.ForeColor = System.Drawing.Color.Red;
            this.lblSvdAlarm.Name = "lblSvdAlarm";
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
            this.btnCw.TabStop = false;
            this.toolTipJog.SetToolTip(this.btnCw, resources.GetString("btnCw.ToolTip"));
            this.btnCw.UseVisualStyleBackColor = true;
            this.btnCw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnCw_MouseDown);
            this.btnCw.MouseHover += new System.EventHandler(this.Control_MouseHover);
            this.btnCw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnCw_MouseUp);
            // 
            // btnServoOn
            // 
            resources.ApplyResources(this.btnServoOn, "btnServoOn");
            this.btnServoOn.Name = "btnServoOn";
            this.btnServoOn.TabStop = false;
            this.toolTipJog.SetToolTip(this.btnServoOn, resources.GetString("btnServoOn.ToolTip"));
            this.btnServoOn.UseVisualStyleBackColor = true;
            this.btnServoOn.Click += new System.EventHandler(this.btnServoOn_Click);
            this.btnServoOn.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // btnServoOff
            // 
            resources.ApplyResources(this.btnServoOff, "btnServoOff");
            this.btnServoOff.Name = "btnServoOff";
            this.btnServoOff.TabStop = false;
            this.toolTipJog.SetToolTip(this.btnServoOff, resources.GetString("btnServoOff.ToolTip"));
            this.btnServoOff.UseVisualStyleBackColor = true;
            this.btnServoOff.Click += new System.EventHandler(this.btnServoOff_Click);
            this.btnServoOff.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // btnStop
            // 
            resources.ApplyResources(this.btnStop, "btnStop");
            this.btnStop.Name = "btnStop";
            this.btnStop.TabStop = false;
            this.toolTipJog.SetToolTip(this.btnStop, resources.GetString("btnStop.ToolTip"));
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnSmoothStop_Click);
            this.btnStop.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // btnAlarmReset
            // 
            resources.ApplyResources(this.btnAlarmReset, "btnAlarmReset");
            this.btnAlarmReset.Name = "btnAlarmReset";
            this.btnAlarmReset.TabStop = false;
            this.toolTipJog.SetToolTip(this.btnAlarmReset, resources.GetString("btnAlarmReset.ToolTip"));
            this.btnAlarmReset.UseVisualStyleBackColor = true;
            this.btnAlarmReset.Click += new System.EventHandler(this.btnAlarmReset_Click);
            this.btnAlarmReset.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // btnCcw
            // 
            resources.ApplyResources(this.btnCcw, "btnCcw");
            this.btnCcw.Name = "btnCcw";
            this.btnCcw.TabStop = false;
            this.toolTipJog.SetToolTip(this.btnCcw, resources.GetString("btnCcw.ToolTip"));
            this.btnCcw.UseVisualStyleBackColor = true;
            this.btnCcw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnCcw_MouseDown);
            this.btnCcw.MouseHover += new System.EventHandler(this.Control_MouseHover);
            this.btnCcw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnCcw_MouseUp);
            // 
            // btnPositionClear
            // 
            resources.ApplyResources(this.btnPositionClear, "btnPositionClear");
            this.btnPositionClear.Name = "btnPositionClear";
            this.btnPositionClear.TabStop = false;
            this.toolTipJog.SetToolTip(this.btnPositionClear, resources.GetString("btnPositionClear.ToolTip"));
            this.btnPositionClear.UseVisualStyleBackColor = true;
            this.btnPositionClear.Click += new System.EventHandler(this.btnPositionClear_Click);
            this.btnPositionClear.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // rdoAbs
            // 
            resources.ApplyResources(this.rdoAbs, "rdoAbs");
            this.rdoAbs.Name = "rdoAbs";
            this.toolTipJog.SetToolTip(this.rdoAbs, resources.GetString("rdoAbs.ToolTip"));
            this.rdoAbs.UseVisualStyleBackColor = true;
            this.rdoAbs.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rdoInc
            // 
            resources.ApplyResources(this.rdoInc, "rdoInc");
            this.rdoInc.Checked = true;
            this.rdoInc.ForeColor = System.Drawing.Color.Black;
            this.rdoInc.Name = "rdoInc";
            this.rdoInc.TabStop = true;
            this.toolTipJog.SetToolTip(this.rdoInc, resources.GetString("rdoInc.ToolTip"));
            this.rdoInc.UseVisualStyleBackColor = true;
            this.rdoInc.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // numContinue
            // 
            resources.ApplyResources(this.numContinue, "numContinue");
            this.numContinue.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numContinue.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numContinue.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numContinue.Name = "numContinue";
            this.numContinue.TabStop = false;
            this.toolTipJog.SetToolTip(this.numContinue, resources.GetString("numContinue.ToolTip"));
            this.numContinue.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // lblContinue
            // 
            resources.ApplyResources(this.lblContinue, "lblContinue");
            this.lblContinue.Name = "lblContinue";
            this.toolTipJog.SetToolTip(this.lblContinue, resources.GetString("lblContinue.ToolTip"));
            // 
            // chkContinue
            // 
            resources.ApplyResources(this.chkContinue, "chkContinue");
            this.chkContinue.Checked = true;
            this.chkContinue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkContinue.ForeColor = System.Drawing.Color.Black;
            this.chkContinue.Name = "chkContinue";
            this.chkContinue.TabStop = false;
            this.toolTipJog.SetToolTip(this.chkContinue, resources.GetString("chkContinue.ToolTip"));
            this.chkContinue.UseVisualStyleBackColor = true;
            this.chkContinue.CheckedChanged += new System.EventHandler(this.chkContinue_CheckedChanged);
            // 
            // chkHardStop
            // 
            resources.ApplyResources(this.chkHardStop, "chkHardStop");
            this.chkHardStop.Name = "chkHardStop";
            this.chkHardStop.TabStop = false;
            this.toolTipJog.SetToolTip(this.chkHardStop, resources.GetString("chkHardStop.ToolTip"));
            this.chkHardStop.UseVisualStyleBackColor = true;
            this.chkHardStop.CheckedChanged += new System.EventHandler(this.chkHardStop_CheckedChanged);
            // 
            // chkButtonLock
            // 
            resources.ApplyResources(this.chkButtonLock, "chkButtonLock");
            this.chkButtonLock.Checked = true;
            this.chkButtonLock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkButtonLock.ForeColor = System.Drawing.Color.Black;
            this.chkButtonLock.Name = "chkButtonLock";
            this.chkButtonLock.TabStop = false;
            this.toolTipJog.SetToolTip(this.chkButtonLock, resources.GetString("chkButtonLock.ToolTip"));
            this.chkButtonLock.UseVisualStyleBackColor = false;
            this.chkButtonLock.CheckedChanged += new System.EventHandler(this.chkButtonLock_CheckedChanged);
            // 
            // chkVelocityLimit
            // 
            resources.ApplyResources(this.chkVelocityLimit, "chkVelocityLimit");
            this.chkVelocityLimit.Checked = true;
            this.chkVelocityLimit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVelocityLimit.ForeColor = System.Drawing.Color.Black;
            this.chkVelocityLimit.Name = "chkVelocityLimit";
            this.chkVelocityLimit.TabStop = false;
            this.toolTipJog.SetToolTip(this.chkVelocityLimit, resources.GetString("chkVelocityLimit.ToolTip"));
            this.chkVelocityLimit.UseVisualStyleBackColor = true;
            this.chkVelocityLimit.CheckedChanged += new System.EventHandler(this.chkVelocityLimit_CheckedChanged);
            // 
            // btnUpdate
            // 
            resources.ApplyResources(this.btnUpdate, "btnUpdate");
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.TabStop = false;
            this.toolTipJog.SetToolTip(this.btnUpdate, resources.GetString("btnUpdate.ToolTip"));
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // grpServoFeedBack
            // 
            this.grpServoFeedBack.Controls.Add(this.fpnlKashiyamaMonitor);
            this.grpServoFeedBack.Controls.Add(this.fpnlFeedback);
            resources.ApplyResources(this.grpServoFeedBack, "grpServoFeedBack");
            this.grpServoFeedBack.Name = "grpServoFeedBack";
            this.grpServoFeedBack.TabStop = false;
            // 
            // fpnlKashiyamaMonitor
            // 
            this.fpnlKashiyamaMonitor.BackColor = System.Drawing.Color.DimGray;
            this.fpnlKashiyamaMonitor.Controls.Add(this.lblOutputPower);
            this.fpnlKashiyamaMonitor.Controls.Add(this.txtOutputPower);
            this.fpnlKashiyamaMonitor.Controls.Add(this.lblOutputPowerUnit);
            this.fpnlKashiyamaMonitor.Cursor = System.Windows.Forms.Cursors.Arrow;
            resources.ApplyResources(this.fpnlKashiyamaMonitor, "fpnlKashiyamaMonitor");
            this.fpnlKashiyamaMonitor.Name = "fpnlKashiyamaMonitor";
            // 
            // lblOutputPower
            // 
            this.lblOutputPower.BackColor = System.Drawing.Color.LightGreen;
            resources.ApplyResources(this.lblOutputPower, "lblOutputPower");
            this.lblOutputPower.Name = "lblOutputPower";
            // 
            // txtOutputPower
            // 
            this.txtOutputPower.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtOutputPower, "txtOutputPower");
            this.txtOutputPower.Name = "txtOutputPower";
            // 
            // lblOutputPowerUnit
            // 
            this.lblOutputPowerUnit.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.lblOutputPowerUnit, "lblOutputPowerUnit");
            this.lblOutputPowerUnit.Name = "lblOutputPowerUnit";
            // 
            // fpnlFeedback
            // 
            this.fpnlFeedback.BackColor = System.Drawing.Color.DimGray;
            this.fpnlFeedback.Controls.Add(this.lblSep1);
            this.fpnlFeedback.Controls.Add(this.lblPosition);
            this.fpnlFeedback.Controls.Add(this.txtPosition);
            this.fpnlFeedback.Controls.Add(this.lblPosUnit);
            this.fpnlFeedback.Controls.Add(this.lblVelocity);
            this.fpnlFeedback.Controls.Add(this.txtVelocity);
            this.fpnlFeedback.Controls.Add(this.lblVelUnit);
            this.fpnlFeedback.Controls.Add(this.lblCurrent);
            this.fpnlFeedback.Controls.Add(this.txtCurrent);
            this.fpnlFeedback.Controls.Add(this.lblCurUnit);
            this.fpnlFeedback.Controls.Add(this.lblSep2);
            this.fpnlFeedback.Controls.Add(this.lblOverLoad);
            this.fpnlFeedback.Controls.Add(this.txtOverload);
            this.fpnlFeedback.Controls.Add(this.llblOverLoadUnit);
            this.fpnlFeedback.Controls.Add(this.lblDriverTemp);
            this.fpnlFeedback.Controls.Add(this.txtDriverTemp);
            this.fpnlFeedback.Controls.Add(this.lblDriverTempUnit);
            this.fpnlFeedback.Controls.Add(this.lblPowerVoltage);
            this.fpnlFeedback.Controls.Add(this.txtPowerVoltage);
            this.fpnlFeedback.Controls.Add(this.lblPowerVoltageUnit);
            resources.ApplyResources(this.fpnlFeedback, "fpnlFeedback");
            this.fpnlFeedback.Name = "fpnlFeedback";
            // 
            // lblSep1
            // 
            this.lblSep1.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.lblSep1, "lblSep1");
            this.lblSep1.Name = "lblSep1";
            // 
            // lblPosition
            // 
            this.lblPosition.BackColor = System.Drawing.Color.Yellow;
            resources.ApplyResources(this.lblPosition, "lblPosition");
            this.lblPosition.Name = "lblPosition";
            // 
            // txtPosition
            // 
            this.txtPosition.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtPosition, "txtPosition");
            this.txtPosition.Name = "txtPosition";
            // 
            // lblVelocity
            // 
            this.lblVelocity.BackColor = System.Drawing.Color.SkyBlue;
            resources.ApplyResources(this.lblVelocity, "lblVelocity");
            this.lblVelocity.Name = "lblVelocity";
            // 
            // txtVelocity
            // 
            this.txtVelocity.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtVelocity, "txtVelocity");
            this.txtVelocity.Name = "txtVelocity";
            // 
            // lblCurrent
            // 
            this.lblCurrent.BackColor = System.Drawing.Color.Salmon;
            resources.ApplyResources(this.lblCurrent, "lblCurrent");
            this.lblCurrent.Name = "lblCurrent";
            // 
            // txtCurrent
            // 
            this.txtCurrent.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtCurrent, "txtCurrent");
            this.txtCurrent.Name = "txtCurrent";
            // 
            // lblSep2
            // 
            this.lblSep2.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.lblSep2, "lblSep2");
            this.lblSep2.Name = "lblSep2";
            // 
            // lblOverLoad
            // 
            this.lblOverLoad.BackColor = System.Drawing.Color.Orange;
            resources.ApplyResources(this.lblOverLoad, "lblOverLoad");
            this.lblOverLoad.Name = "lblOverLoad";
            // 
            // txtOverload
            // 
            this.txtOverload.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtOverload, "txtOverload");
            this.txtOverload.Name = "txtOverload";
            // 
            // llblOverLoadUnit
            // 
            this.llblOverLoadUnit.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.llblOverLoadUnit, "llblOverLoadUnit");
            this.llblOverLoadUnit.Name = "llblOverLoadUnit";
            // 
            // lblDriverTemp
            // 
            this.lblDriverTemp.BackColor = System.Drawing.Color.Violet;
            resources.ApplyResources(this.lblDriverTemp, "lblDriverTemp");
            this.lblDriverTemp.Name = "lblDriverTemp";
            // 
            // txtDriverTemp
            // 
            this.txtDriverTemp.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtDriverTemp, "txtDriverTemp");
            this.txtDriverTemp.Name = "txtDriverTemp";
            // 
            // lblDriverTempUnit
            // 
            this.lblDriverTempUnit.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.lblDriverTempUnit, "lblDriverTempUnit");
            this.lblDriverTempUnit.Name = "lblDriverTempUnit";
            // 
            // lblPowerVoltage
            // 
            this.lblPowerVoltage.BackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.lblPowerVoltage, "lblPowerVoltage");
            this.lblPowerVoltage.Name = "lblPowerVoltage";
            // 
            // txtPowerVoltage
            // 
            this.txtPowerVoltage.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtPowerVoltage, "txtPowerVoltage");
            this.txtPowerVoltage.Name = "txtPowerVoltage";
            // 
            // lblPowerVoltageUnit
            // 
            this.lblPowerVoltageUnit.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.lblPowerVoltageUnit, "lblPowerVoltageUnit");
            this.lblPowerVoltageUnit.Name = "lblPowerVoltageUnit";
            // 
            // lblDummy
            // 
            resources.ApplyResources(this.lblDummy, "lblDummy");
            this.lblDummy.Name = "lblDummy";
            // 
            // grpVelocity
            // 
            this.grpVelocity.Controls.Add(this.ctlNumTargetVelocity);
            resources.ApplyResources(this.grpVelocity, "grpVelocity");
            this.grpVelocity.Name = "grpVelocity";
            this.grpVelocity.TabStop = false;
            // 
            // ctlNumTargetVelocity
            // 
            this.ctlNumTargetVelocity.DataId = 0;
            this.ctlNumTargetVelocity.DigiSwVisible = true;
            resources.ApplyResources(this.ctlNumTargetVelocity, "ctlNumTargetVelocity");
            this.ctlNumTargetVelocity.IntValue = 100;
            this.ctlNumTargetVelocity.MaxData = 99999;
            this.ctlNumTargetVelocity.MinData = -99999;
            this.ctlNumTargetVelocity.Name = "ctlNumTargetVelocity";
            this.ctlNumTargetVelocity.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumTargetVelocity.NumFont = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ctlNumTargetVelocity.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumTargetVelocity.PlaceNumber = 5;
            this.ctlNumTargetVelocity.SignedVisible = true;
            this.ctlNumTargetVelocity.SingedEnable = true;
            this.ctlNumTargetVelocity.StringValue = "+100";
            this.ctlNumTargetVelocity.TabStop = false;
            this.ctlNumTargetVelocity.TitleAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumTargetVelocity.TitleBackColor = System.Drawing.Color.White;
            this.ctlNumTargetVelocity.TitleDock = System.Windows.Forms.DockStyle.Top;
            this.ctlNumTargetVelocity.TitleForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumTargetVelocity.TitleHeight = 19;
            this.ctlNumTargetVelocity.TitleVisible = false;
            this.ctlNumTargetVelocity.UnitAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumTargetVelocity.UnitBackColor = System.Drawing.Color.White;
            this.ctlNumTargetVelocity.UnitDock = System.Windows.Forms.DockStyle.Bottom;
            this.ctlNumTargetVelocity.UnitFont = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ctlNumTargetVelocity.UnitForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumTargetVelocity.UnitHeight = 24;
            this.ctlNumTargetVelocity.UnitVisible = false;
            // 
            // grpAcceleration
            // 
            this.grpAcceleration.Controls.Add(this.lblAccTime);
            this.grpAcceleration.Controls.Add(this.ctlNumTargetAcceleration);
            resources.ApplyResources(this.grpAcceleration, "grpAcceleration");
            this.grpAcceleration.Name = "grpAcceleration";
            this.grpAcceleration.TabStop = false;
            // 
            // lblAccTime
            // 
            resources.ApplyResources(this.lblAccTime, "lblAccTime");
            this.lblAccTime.Name = "lblAccTime";
            // 
            // ctlNumTargetAcceleration
            // 
            this.ctlNumTargetAcceleration.DataId = 0;
            this.ctlNumTargetAcceleration.DigiSwVisible = true;
            resources.ApplyResources(this.ctlNumTargetAcceleration, "ctlNumTargetAcceleration");
            this.ctlNumTargetAcceleration.IntValue = 100;
            this.ctlNumTargetAcceleration.MaxData = 99999;
            this.ctlNumTargetAcceleration.MinData = 0;
            this.ctlNumTargetAcceleration.Name = "ctlNumTargetAcceleration";
            this.ctlNumTargetAcceleration.NumBackColor = System.Drawing.Color.White;
            this.ctlNumTargetAcceleration.NumFont = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ctlNumTargetAcceleration.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumTargetAcceleration.PlaceNumber = 5;
            this.ctlNumTargetAcceleration.SignedVisible = false;
            this.ctlNumTargetAcceleration.SingedEnable = false;
            this.ctlNumTargetAcceleration.StringValue = "+100";
            this.ctlNumTargetAcceleration.TabStop = false;
            this.ctlNumTargetAcceleration.TitleAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumTargetAcceleration.TitleBackColor = System.Drawing.Color.White;
            this.ctlNumTargetAcceleration.TitleDock = System.Windows.Forms.DockStyle.Top;
            this.ctlNumTargetAcceleration.TitleForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumTargetAcceleration.TitleHeight = 19;
            this.ctlNumTargetAcceleration.TitleVisible = false;
            this.ctlNumTargetAcceleration.UnitAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumTargetAcceleration.UnitBackColor = System.Drawing.Color.White;
            this.ctlNumTargetAcceleration.UnitDock = System.Windows.Forms.DockStyle.Bottom;
            this.ctlNumTargetAcceleration.UnitFont = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ctlNumTargetAcceleration.UnitForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumTargetAcceleration.UnitHeight = 24;
            this.ctlNumTargetAcceleration.UnitVisible = false;
            // 
            // grpDeceleration
            // 
            this.grpDeceleration.Controls.Add(this.lblDccTime);
            this.grpDeceleration.Controls.Add(this.ctlNumTargetDeceleration);
            resources.ApplyResources(this.grpDeceleration, "grpDeceleration");
            this.grpDeceleration.Name = "grpDeceleration";
            this.grpDeceleration.TabStop = false;
            // 
            // lblDccTime
            // 
            resources.ApplyResources(this.lblDccTime, "lblDccTime");
            this.lblDccTime.Name = "lblDccTime";
            // 
            // ctlNumTargetDeceleration
            // 
            this.ctlNumTargetDeceleration.DataId = 0;
            this.ctlNumTargetDeceleration.DigiSwVisible = true;
            resources.ApplyResources(this.ctlNumTargetDeceleration, "ctlNumTargetDeceleration");
            this.ctlNumTargetDeceleration.IntValue = 100;
            this.ctlNumTargetDeceleration.MaxData = 99999;
            this.ctlNumTargetDeceleration.MinData = 0;
            this.ctlNumTargetDeceleration.Name = "ctlNumTargetDeceleration";
            this.ctlNumTargetDeceleration.NumBackColor = System.Drawing.Color.White;
            this.ctlNumTargetDeceleration.NumFont = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ctlNumTargetDeceleration.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumTargetDeceleration.PlaceNumber = 5;
            this.ctlNumTargetDeceleration.SignedVisible = false;
            this.ctlNumTargetDeceleration.SingedEnable = false;
            this.ctlNumTargetDeceleration.StringValue = "+100";
            this.ctlNumTargetDeceleration.TabStop = false;
            this.ctlNumTargetDeceleration.TitleAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumTargetDeceleration.TitleBackColor = System.Drawing.Color.White;
            this.ctlNumTargetDeceleration.TitleDock = System.Windows.Forms.DockStyle.Top;
            this.ctlNumTargetDeceleration.TitleForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumTargetDeceleration.TitleHeight = 19;
            this.ctlNumTargetDeceleration.TitleVisible = false;
            this.ctlNumTargetDeceleration.UnitAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumTargetDeceleration.UnitBackColor = System.Drawing.Color.White;
            this.ctlNumTargetDeceleration.UnitDock = System.Windows.Forms.DockStyle.Bottom;
            this.ctlNumTargetDeceleration.UnitFont = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ctlNumTargetDeceleration.UnitForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumTargetDeceleration.UnitHeight = 24;
            this.ctlNumTargetDeceleration.UnitVisible = false;
            // 
            // grpPosition1
            // 
            this.grpPosition1.Controls.Add(this.ctlNumTargetPosition1);
            resources.ApplyResources(this.grpPosition1, "grpPosition1");
            this.grpPosition1.Name = "grpPosition1";
            this.grpPosition1.TabStop = false;
            // 
            // ctlNumTargetPosition1
            // 
            this.ctlNumTargetPosition1.DataId = 0;
            this.ctlNumTargetPosition1.DigiSwVisible = true;
            resources.ApplyResources(this.ctlNumTargetPosition1, "ctlNumTargetPosition1");
            this.ctlNumTargetPosition1.IntValue = 0;
            this.ctlNumTargetPosition1.MaxData = 2000000000;
            this.ctlNumTargetPosition1.MinData = -2000000000;
            this.ctlNumTargetPosition1.Name = "ctlNumTargetPosition1";
            this.ctlNumTargetPosition1.NumBackColor = System.Drawing.Color.White;
            this.ctlNumTargetPosition1.NumFont = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ctlNumTargetPosition1.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumTargetPosition1.PlaceNumber = 10;
            this.ctlNumTargetPosition1.SignedVisible = true;
            this.ctlNumTargetPosition1.SingedEnable = true;
            this.ctlNumTargetPosition1.StringValue = "+0";
            this.ctlNumTargetPosition1.TabStop = false;
            this.ctlNumTargetPosition1.TitleAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumTargetPosition1.TitleBackColor = System.Drawing.Color.White;
            this.ctlNumTargetPosition1.TitleDock = System.Windows.Forms.DockStyle.Top;
            this.ctlNumTargetPosition1.TitleForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumTargetPosition1.TitleHeight = 19;
            this.ctlNumTargetPosition1.TitleVisible = false;
            this.ctlNumTargetPosition1.UnitAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumTargetPosition1.UnitBackColor = System.Drawing.Color.White;
            this.ctlNumTargetPosition1.UnitDock = System.Windows.Forms.DockStyle.Bottom;
            this.ctlNumTargetPosition1.UnitFont = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ctlNumTargetPosition1.UnitForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumTargetPosition1.UnitHeight = 24;
            this.ctlNumTargetPosition1.UnitVisible = false;
            // 
            // lblStatusPage
            // 
            this.lblStatusPage.BackColor = System.Drawing.Color.White;
            this.lblStatusPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lblStatusPage, "lblStatusPage");
            this.lblStatusPage.Name = "lblStatusPage";
            // 
            // grpPosition2
            // 
            this.grpPosition2.Controls.Add(this.ctlNumTargetPosition2);
            resources.ApplyResources(this.grpPosition2, "grpPosition2");
            this.grpPosition2.Name = "grpPosition2";
            this.grpPosition2.TabStop = false;
            // 
            // ctlNumTargetPosition2
            // 
            this.ctlNumTargetPosition2.DataId = 0;
            this.ctlNumTargetPosition2.DigiSwVisible = true;
            resources.ApplyResources(this.ctlNumTargetPosition2, "ctlNumTargetPosition2");
            this.ctlNumTargetPosition2.IntValue = 0;
            this.ctlNumTargetPosition2.MaxData = 2000000000;
            this.ctlNumTargetPosition2.MinData = -2000000000;
            this.ctlNumTargetPosition2.Name = "ctlNumTargetPosition2";
            this.ctlNumTargetPosition2.NumBackColor = System.Drawing.Color.White;
            this.ctlNumTargetPosition2.NumFont = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ctlNumTargetPosition2.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumTargetPosition2.PlaceNumber = 10;
            this.ctlNumTargetPosition2.SignedVisible = true;
            this.ctlNumTargetPosition2.SingedEnable = true;
            this.ctlNumTargetPosition2.StringValue = "+0";
            this.ctlNumTargetPosition2.TabStop = false;
            this.ctlNumTargetPosition2.TitleAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumTargetPosition2.TitleBackColor = System.Drawing.Color.White;
            this.ctlNumTargetPosition2.TitleDock = System.Windows.Forms.DockStyle.Top;
            this.ctlNumTargetPosition2.TitleForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumTargetPosition2.TitleHeight = 19;
            this.ctlNumTargetPosition2.TitleVisible = false;
            this.ctlNumTargetPosition2.UnitAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumTargetPosition2.UnitBackColor = System.Drawing.Color.White;
            this.ctlNumTargetPosition2.UnitDock = System.Windows.Forms.DockStyle.Bottom;
            this.ctlNumTargetPosition2.UnitFont = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ctlNumTargetPosition2.UnitForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumTargetPosition2.UnitHeight = 24;
            this.ctlNumTargetPosition2.UnitVisible = false;
            // 
            // tabJogSetting
            // 
            this.tabJogSetting.Controls.Add(this.tabPage1);
            this.tabJogSetting.Controls.Add(this.tabPage2);
            this.tabJogSetting.Controls.Add(this.tabPage3);
            resources.ApplyResources(this.tabJogSetting, "tabJogSetting");
            this.tabJogSetting.Name = "tabJogSetting";
            this.tabJogSetting.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.rdoAbs);
            this.tabPage1.Controls.Add(this.numContinue);
            this.tabPage1.Controls.Add(this.rdoInc);
            this.tabPage1.Controls.Add(this.lblContinue);
            this.tabPage1.Controls.Add(this.chkContinue);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.chkHardStop);
            this.tabPage2.Controls.Add(this.chkButtonLock);
            this.tabPage2.Controls.Add(this.chkVelocityLimit);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.btnAnalogZeorAdjust);
            this.tabPage3.Controls.Add(this.btnAbsReset);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            // 
            // btnAnalogZeorAdjust
            // 
            resources.ApplyResources(this.btnAnalogZeorAdjust, "btnAnalogZeorAdjust");
            this.btnAnalogZeorAdjust.Name = "btnAnalogZeorAdjust";
            this.btnAnalogZeorAdjust.TabStop = false;
            this.btnAnalogZeorAdjust.UseVisualStyleBackColor = true;
            this.btnAnalogZeorAdjust.Click += new System.EventHandler(this.btnAnalogZeorAdjust_Click);
            this.btnAnalogZeorAdjust.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // btnAbsReset
            // 
            resources.ApplyResources(this.btnAbsReset, "btnAbsReset");
            this.btnAbsReset.Name = "btnAbsReset";
            this.btnAbsReset.TabStop = false;
            this.btnAbsReset.UseVisualStyleBackColor = true;
            this.btnAbsReset.Click += new System.EventHandler(this.btnAbsReset_Click);
            this.btnAbsReset.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // lblTarget
            // 
            resources.ApplyResources(this.lblTarget, "lblTarget");
            this.lblTarget.Name = "lblTarget";
            // 
            // pnlCommand
            // 
            this.pnlCommand.Controls.Add(this.grpServoStatus);
            this.pnlCommand.Controls.Add(this.btnBack2);
            this.pnlCommand.Controls.Add(this.btnGo2);
            this.pnlCommand.Controls.Add(this.grpServoCommand);
            this.pnlCommand.Controls.Add(this.lblStatusPage);
            this.pnlCommand.Controls.Add(this.lblSvdAlarm);
            this.pnlCommand.Controls.Add(this.grpServoFeedBack);
            this.pnlCommand.Controls.Add(this.lblDummy);
            resources.ApplyResources(this.pnlCommand, "pnlCommand");
            this.pnlCommand.Name = "pnlCommand";
            // 
            // btnBack2
            // 
            resources.ApplyResources(this.btnBack2, "btnBack2");
            this.btnBack2.Name = "btnBack2";
            this.btnBack2.Tag = "";
            this.btnBack2.UseVisualStyleBackColor = true;
            this.btnBack2.Click += new System.EventHandler(this.btnBack2_Click);
            // 
            // btnGo2
            // 
            resources.ApplyResources(this.btnGo2, "btnGo2");
            this.btnGo2.Name = "btnGo2";
            this.btnGo2.Tag = "";
            this.btnGo2.UseVisualStyleBackColor = true;
            this.btnGo2.Click += new System.EventHandler(this.btnGo2_Click);
            // 
            // pnlSetting
            // 
            this.pnlSetting.Controls.Add(this.grpVelocity);
            this.pnlSetting.Controls.Add(this.grpAcceleration);
            this.pnlSetting.Controls.Add(this.grpDeceleration);
            this.pnlSetting.Controls.Add(this.lblTarget);
            this.pnlSetting.Controls.Add(this.btnUpdate);
            this.pnlSetting.Controls.Add(this.grpPosition1);
            this.pnlSetting.Controls.Add(this.tabJogSetting);
            this.pnlSetting.Controls.Add(this.grpPosition2);
            resources.ApplyResources(this.pnlSetting, "pnlSetting");
            this.pnlSetting.Name = "pnlSetting";
            // 
            // tabJogControl
            // 
            resources.ApplyResources(this.tabJogControl, "tabJogControl");
            this.tabJogControl.Controls.Add(this.tabPageCommand);
            this.tabJogControl.Controls.Add(this.tabPageSetting);
            this.tabJogControl.Name = "tabJogControl";
            this.tabJogControl.SelectedIndex = 0;
            this.tabJogControl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabJogControl_DrawItem);
            // 
            // tabPageCommand
            // 
            resources.ApplyResources(this.tabPageCommand, "tabPageCommand");
            this.tabPageCommand.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageCommand.Name = "tabPageCommand";
            // 
            // tabPageSetting
            // 
            resources.ApplyResources(this.tabPageSetting, "tabPageSetting");
            this.tabPageSetting.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageSetting.Name = "tabPageSetting";
            // 
            // grpTeaching1
            // 
            this.grpTeaching1.Controls.Add(this.lblTeaching1);
            this.grpTeaching1.Controls.Add(this.btnTeaching1);
            resources.ApplyResources(this.grpTeaching1, "grpTeaching1");
            this.grpTeaching1.Name = "grpTeaching1";
            this.grpTeaching1.TabStop = false;
            // 
            // lblTeaching1
            // 
            this.lblTeaching1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTeaching1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lblTeaching1, "lblTeaching1");
            this.lblTeaching1.Name = "lblTeaching1";
            // 
            // btnTeaching1
            // 
            this.btnTeaching1.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnTeaching1, "btnTeaching1");
            this.btnTeaching1.Name = "btnTeaching1";
            this.btnTeaching1.UseVisualStyleBackColor = false;
            this.btnTeaching1.Click += new System.EventHandler(this.btnTeaching1_Click);
            // 
            // grpTeaching2
            // 
            this.grpTeaching2.Controls.Add(this.lblTeaching2);
            this.grpTeaching2.Controls.Add(this.btnTeaching2);
            resources.ApplyResources(this.grpTeaching2, "grpTeaching2");
            this.grpTeaching2.Name = "grpTeaching2";
            this.grpTeaching2.TabStop = false;
            // 
            // lblTeaching2
            // 
            this.lblTeaching2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTeaching2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lblTeaching2, "lblTeaching2");
            this.lblTeaching2.Name = "lblTeaching2";
            // 
            // btnTeaching2
            // 
            this.btnTeaching2.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnTeaching2, "btnTeaching2");
            this.btnTeaching2.Name = "btnTeaching2";
            this.btnTeaching2.UseVisualStyleBackColor = false;
            this.btnTeaching2.Click += new System.EventHandler(this.btnTeaching2_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.Tag = "";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // TimerJog
            // 
            this.TimerJog.Tick += new System.EventHandler(this.TimerJog_Tick);
            // 
            // TimerJogStop
            // 
            this.TimerJogStop.Interval = 500;
            this.TimerJogStop.Tick += new System.EventHandler(this.TimerJogStop_Tick);
            // 
            // CtlJogControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.grpTeaching2);
            this.Controls.Add(this.tabJogControl);
            this.Controls.Add(this.grpTeaching1);
            this.Controls.Add(this.pnlSetting);
            this.Controls.Add(this.pnlCommand);
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.Name = "CtlJogControl";
            this.Load += new System.EventHandler(this.CtlJogControl_Load);
            this.Click += new System.EventHandler(this.CtlJogControl_Click);
            this.fpnlStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picServoOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picForwardLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picReverseLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTorqueLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFault)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVelocityLimit)).EndInit();
            this.grpServoStatus.ResumeLayout(false);
            this.grpServoCommand.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numContinue)).EndInit();
            this.grpServoFeedBack.ResumeLayout(false);
            this.fpnlKashiyamaMonitor.ResumeLayout(false);
            this.fpnlFeedback.ResumeLayout(false);
            this.grpVelocity.ResumeLayout(false);
            this.grpAcceleration.ResumeLayout(false);
            this.grpAcceleration.PerformLayout();
            this.grpDeceleration.ResumeLayout(false);
            this.grpDeceleration.PerformLayout();
            this.grpPosition1.ResumeLayout(false);
            this.grpPosition2.ResumeLayout(false);
            this.tabJogSetting.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.pnlCommand.ResumeLayout(false);
            this.pnlCommand.PerformLayout();
            this.pnlSetting.ResumeLayout(false);
            this.pnlSetting.PerformLayout();
            this.tabJogControl.ResumeLayout(false);
            this.grpTeaching1.ResumeLayout(false);
            this.grpTeaching2.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblVelUnit;
		private System.Windows.Forms.Label lblPosUnit;
		private System.Windows.Forms.Label lblCurUnit;
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
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button btnGo2;
		private System.Windows.Forms.Button btnBack2;
		private System.Windows.Forms.GroupBox grpServoStatus;
		private System.Windows.Forms.Label lblSvdAlarm;
		private System.Windows.Forms.GroupBox grpServoCommand;
		private System.Windows.Forms.ToolTip toolTipJog;
		private System.Windows.Forms.GroupBox grpServoFeedBack;
		private System.Windows.Forms.FlowLayoutPanel fpnlFeedback;
		private System.Windows.Forms.Label lblPosition;
		private System.Windows.Forms.Label lblVelocity;
		private System.Windows.Forms.Label lblCurrent;
		private System.Windows.Forms.Button btnAlarmReset;
		private System.Windows.Forms.Button btnServoOff;
		private System.Windows.Forms.Button btnServoOn;
		private System.Windows.Forms.Button btnCw;
		private System.Windows.Forms.Button btnCcw;
		private System.Windows.Forms.Button btnPositionClear;
		private System.Windows.Forms.Label lblDummy;
		private Motion_Designer.CtlNumericInputInt ctlNumTargetVelocity;
		private Motion_Designer.CtlNumericInputInt ctlNumTargetPosition1;
		private Motion_Designer.CtlNumericInputInt ctlNumTargetAcceleration;
		private Motion_Designer.CtlNumericInputInt ctlNumTargetDeceleration;
		private System.Windows.Forms.GroupBox grpVelocity;
		private System.Windows.Forms.GroupBox grpAcceleration;
		private System.Windows.Forms.GroupBox grpDeceleration;
		private System.Windows.Forms.GroupBox grpPosition1;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.Label lblSep2;
		private System.Windows.Forms.Label lblOverLoad;
		private System.Windows.Forms.Label llblOverLoadUnit;
		private System.Windows.Forms.Label lblDriverTemp;
		private System.Windows.Forms.Label lblDriverTempUnit;
		private System.Windows.Forms.Label lblSep1;
		private System.Windows.Forms.Label lblPowerVoltage;
		private System.Windows.Forms.Label lblPowerVoltageUnit;
		private System.Windows.Forms.Label lblStatusPage;
		private System.Windows.Forms.Timer TimerJog;
		private System.Windows.Forms.Label lblAccTime;
		private System.Windows.Forms.Label lblDccTime;
		private System.Windows.Forms.Timer TimerJogStop;
		private System.Windows.Forms.GroupBox grpPosition2;
		private CtlNumericInputInt ctlNumTargetPosition2;
		private System.Windows.Forms.TabControl tabJogSetting;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.RadioButton rdoAbs;
		private System.Windows.Forms.NumericUpDown numContinue;
		private System.Windows.Forms.RadioButton rdoInc;
		private System.Windows.Forms.Label lblContinue;
		private System.Windows.Forms.CheckBox chkContinue;
		private System.Windows.Forms.CheckBox chkHardStop;
		private System.Windows.Forms.CheckBox chkButtonLock;
		private System.Windows.Forms.CheckBox chkVelocityLimit;
		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.Label lblTarget;
		private System.Windows.Forms.Label txtPosition;
		private System.Windows.Forms.Label txtVelocity;
		private System.Windows.Forms.Label txtCurrent;
		private System.Windows.Forms.Label txtOverload;
		private System.Windows.Forms.Label txtDriverTemp;
		private System.Windows.Forms.Label txtPowerVoltage;
		private System.Windows.Forms.Panel pnlCommand;
		private System.Windows.Forms.Panel pnlSetting;
		private System.Windows.Forms.TabControl tabJogControl;
		private System.Windows.Forms.TabPage tabPageCommand;
		private System.Windows.Forms.TabPage tabPageSetting;
		private System.Windows.Forms.GroupBox grpTeaching1;
		private System.Windows.Forms.Button btnTeaching1;
		private System.Windows.Forms.Label lblTeaching1;
		private System.Windows.Forms.GroupBox grpTeaching2;
		private System.Windows.Forms.Label lblTeaching2;
		private System.Windows.Forms.Button btnTeaching2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Button btnAbsReset;
        private System.Windows.Forms.Button btnAnalogZeorAdjust;
        private System.Windows.Forms.FlowLayoutPanel fpnlKashiyamaMonitor;
        private System.Windows.Forms.Label lblOutputPower;
        private System.Windows.Forms.Label txtOutputPower;
        private System.Windows.Forms.Label lblOutputPowerUnit;
	}
}
