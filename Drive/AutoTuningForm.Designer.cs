namespace Motion_Designer
{
	partial class AutoTuningForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoTuningForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splOutput = new System.Windows.Forms.SplitContainer();
            this.tabAutoTuning = new System.Windows.Forms.TabControl();
            this.tabPageOutput1 = new System.Windows.Forms.TabPage();
            this.rtxtResult = new System.Windows.Forms.RichTextBox();
            this.tabPageOutput2 = new System.Windows.Forms.TabPage();
            this.rtxtFFT_Peek = new System.Windows.Forms.RichTextBox();
            this.tabGainNow = new System.Windows.Forms.TabControl();
            this.tabPageGainNow = new System.Windows.Forms.TabPage();
            this.rtxtGainNow = new System.Windows.Forms.RichTextBox();
            this.TimerAutoTuing = new System.Windows.Forms.Timer(this.components);
            this.grpTargetPosition = new System.Windows.Forms.GroupBox();
            this.ctlNumTargetPosition = new Motion_Designer.CtlNumericInputInt();
            this.grpDeceleration = new System.Windows.Forms.GroupBox();
            this.lblDccTime = new System.Windows.Forms.Label();
            this.ctlNumTargetDeceleration = new Motion_Designer.CtlNumericInputInt();
            this.grpAcceleration = new System.Windows.Forms.GroupBox();
            this.lblAccTime = new System.Windows.Forms.Label();
            this.ctlNumTargetAcceleration = new Motion_Designer.CtlNumericInputInt();
            this.grpVelocity = new System.Windows.Forms.GroupBox();
            this.ctlNumTargetVelocity = new Motion_Designer.CtlNumericInputInt();
            this.lblSelect = new System.Windows.Forms.Label();
            this.grpGainStrength = new System.Windows.Forms.GroupBox();
            this.rdoStrong = new System.Windows.Forms.RadioButton();
            this.rdoMiddle = new System.Windows.Forms.RadioButton();
            this.rdoLight = new System.Windows.Forms.RadioButton();
            this.pnlVibration = new System.Windows.Forms.Panel();
            this.lblVibration = new System.Windows.Forms.Label();
            this.grpMachineType = new System.Windows.Forms.GroupBox();
            this.rdoBelt = new System.Windows.Forms.RadioButton();
            this.rdoScrew = new System.Windows.Forms.RadioButton();
            this.rdoDisk = new System.Windows.Forms.RadioButton();
            this.grpTargetTime = new System.Windows.Forms.GroupBox();
            this.lblTargetTimeUnit = new System.Windows.Forms.Label();
            this.ctlNumTargetTime = new Motion_Designer.CtlNumericInputInt();
            this.grpInposition = new System.Windows.Forms.GroupBox();
            this.lblInposWidthUnit = new System.Windows.Forms.Label();
            this.ctlNumInposition = new Motion_Designer.CtlNumericInputInt();
            this.grpTuningMode = new System.Windows.Forms.GroupBox();
            this.rdoStiffnessPriorty = new System.Windows.Forms.RadioButton();
            this.rdoPositionPriorty = new System.Windows.Forms.RadioButton();
            this.rdoNormalPriorty = new System.Windows.Forms.RadioButton();
            this.tabTuning = new System.Windows.Forms.TabControl();
            this.tabPageTuningMode = new System.Windows.Forms.TabPage();
            this.grpLoadTuningSetting = new System.Windows.Forms.GroupBox();
            this.numTempTuningCnt = new Motion_Designer.NumericUpDownEx();
            this.numLoadTuningAcc = new Motion_Designer.NumericUpDownEx();
            this.numLoadTuningVel = new Motion_Designer.NumericUpDownEx();
            this.numLoadTuningRev = new Motion_Designer.NumericUpDownEx();
            this.numLoadTuningCnt = new Motion_Designer.NumericUpDownEx();
            this.lblTempTuningCnt = new System.Windows.Forms.Label();
            this.lblLoadTuningAcc = new System.Windows.Forms.Label();
            this.lblLoadTuningVel = new System.Windows.Forms.Label();
            this.lblLoadTuningRev = new System.Windows.Forms.Label();
            this.lblLoadTuningCnt = new System.Windows.Forms.Label();
            this.lblTempTuningCoeff = new System.Windows.Forms.Label();
            this.numTempTuningCoeff = new Motion_Designer.NumericUpDownEx();
            this.grpLoadTuningGain = new System.Windows.Forms.GroupBox();
            this.grpLoadTuningKi = new System.Windows.Forms.GroupBox();
            this.lblLoadTuningKi = new System.Windows.Forms.Label();
            this.ctlNumLoadTuningKi = new Motion_Designer.CtlNumericInputInt();
            this.grpLoadTuningKv = new System.Windows.Forms.GroupBox();
            this.lblLoadTuningKv = new System.Windows.Forms.Label();
            this.ctlNumLoadTuningKv = new Motion_Designer.CtlNumericInputInt();
            this.ctlNumericInputInt1 = new Motion_Designer.CtlNumericInputInt();
            this.grpLoadTuningKp = new System.Windows.Forms.GroupBox();
            this.lblLoadTuningKp = new System.Windows.Forms.Label();
            this.ctlNumLoadTuningKp = new Motion_Designer.CtlNumericInputInt();
            this.chkLoadTuning = new System.Windows.Forms.CheckBox();
            this.grpVelocityObserver = new System.Windows.Forms.GroupBox();
            this.rdoVelObsDisable = new System.Windows.Forms.RadioButton();
            this.rdoVelObsEnable = new System.Windows.Forms.RadioButton();
            this.grpTuningTurbo = new System.Windows.Forms.GroupBox();
            this.rdoTurboDisable = new System.Windows.Forms.RadioButton();
            this.rdoTurboEnable = new System.Windows.Forms.RadioButton();
            this.tabPageTuningTarget = new System.Windows.Forms.TabPage();
            this.lblInc = new System.Windows.Forms.Label();
            this.chkInc = new System.Windows.Forms.CheckBox();
            this.grpWait = new System.Windows.Forms.GroupBox();
            this.ctlNumWaitTime = new Motion_Designer.CtlNumericInputInt();
            this.grpStartPosition = new System.Windows.Forms.GroupBox();
            this.ctlNumStartPosition = new Motion_Designer.CtlNumericInputInt();
            this.tabPageTuningOutput = new System.Windows.Forms.TabPage();
            this.tabPageTuningParameter = new System.Windows.Forms.TabPage();
            this.dgvSetting = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripTuningSetting = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.btnConfigOutput = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnConfigRead = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.pnlWatch = new System.Windows.Forms.Panel();
            this.lblStopWatch = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.TimerResize = new System.Windows.Forms.Timer(this.components);
            this.toolStripAutoTuning = new System.Windows.Forms.ToolStrip();
            this.btnAutoTuningWizard = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTuningControl = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripAutoTuning2 = new System.Windows.Forms.ToolStrip();
            this.btnPause = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRepeat = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnStop2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.splOutput.Panel1.SuspendLayout();
            this.splOutput.Panel2.SuspendLayout();
            this.splOutput.SuspendLayout();
            this.tabAutoTuning.SuspendLayout();
            this.tabPageOutput1.SuspendLayout();
            this.tabPageOutput2.SuspendLayout();
            this.tabGainNow.SuspendLayout();
            this.tabPageGainNow.SuspendLayout();
            this.grpTargetPosition.SuspendLayout();
            this.grpDeceleration.SuspendLayout();
            this.grpAcceleration.SuspendLayout();
            this.grpVelocity.SuspendLayout();
            this.grpGainStrength.SuspendLayout();
            this.pnlVibration.SuspendLayout();
            this.grpMachineType.SuspendLayout();
            this.grpTargetTime.SuspendLayout();
            this.grpInposition.SuspendLayout();
            this.grpTuningMode.SuspendLayout();
            this.tabTuning.SuspendLayout();
            this.tabPageTuningMode.SuspendLayout();
            this.grpLoadTuningSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTempTuningCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLoadTuningAcc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLoadTuningVel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLoadTuningRev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLoadTuningCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTempTuningCoeff)).BeginInit();
            this.grpLoadTuningGain.SuspendLayout();
            this.grpLoadTuningKi.SuspendLayout();
            this.grpLoadTuningKv.SuspendLayout();
            this.grpLoadTuningKp.SuspendLayout();
            this.grpVelocityObserver.SuspendLayout();
            this.grpTuningTurbo.SuspendLayout();
            this.tabPageTuningTarget.SuspendLayout();
            this.grpWait.SuspendLayout();
            this.grpStartPosition.SuspendLayout();
            this.tabPageTuningOutput.SuspendLayout();
            this.tabPageTuningParameter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSetting)).BeginInit();
            this.toolStripTuningSetting.SuspendLayout();
            this.pnlWatch.SuspendLayout();
            this.toolStripAutoTuning.SuspendLayout();
            this.toolStripAutoTuning2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splOutput
            // 
            this.splOutput.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.splOutput, "splOutput");
            this.splOutput.Name = "splOutput";
            // 
            // splOutput.Panel1
            // 
            this.splOutput.Panel1.Controls.Add(this.tabAutoTuning);
            // 
            // splOutput.Panel2
            // 
            this.splOutput.Panel2.Controls.Add(this.tabGainNow);
            // 
            // tabAutoTuning
            // 
            this.tabAutoTuning.Controls.Add(this.tabPageOutput1);
            this.tabAutoTuning.Controls.Add(this.tabPageOutput2);
            resources.ApplyResources(this.tabAutoTuning, "tabAutoTuning");
            this.tabAutoTuning.Name = "tabAutoTuning";
            this.tabAutoTuning.SelectedIndex = 0;
            this.tabAutoTuning.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            // 
            // tabPageOutput1
            // 
            this.tabPageOutput1.BackColor = System.Drawing.Color.Transparent;
            this.tabPageOutput1.Controls.Add(this.rtxtResult);
            resources.ApplyResources(this.tabPageOutput1, "tabPageOutput1");
            this.tabPageOutput1.Name = "tabPageOutput1";
            this.tabPageOutput1.UseVisualStyleBackColor = true;
            // 
            // rtxtResult
            // 
            this.rtxtResult.BackColor = System.Drawing.SystemColors.Control;
            this.rtxtResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.rtxtResult, "rtxtResult");
            this.rtxtResult.Name = "rtxtResult";
            this.rtxtResult.ReadOnly = true;
            this.rtxtResult.Enter += new System.EventHandler(this.rtxtResult_Enter);
            this.rtxtResult.Leave += new System.EventHandler(this.rtxtResult_Leave);
            this.rtxtResult.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rtxtResult_MouseDown);
            this.rtxtResult.MouseLeave += new System.EventHandler(this.rtxtResult_MouseLeave);
            // 
            // tabPageOutput2
            // 
            this.tabPageOutput2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageOutput2.Controls.Add(this.rtxtFFT_Peek);
            resources.ApplyResources(this.tabPageOutput2, "tabPageOutput2");
            this.tabPageOutput2.Name = "tabPageOutput2";
            // 
            // rtxtFFT_Peek
            // 
            this.rtxtFFT_Peek.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.rtxtFFT_Peek, "rtxtFFT_Peek");
            this.rtxtFFT_Peek.Name = "rtxtFFT_Peek";
            // 
            // tabGainNow
            // 
            this.tabGainNow.Controls.Add(this.tabPageGainNow);
            resources.ApplyResources(this.tabGainNow, "tabGainNow");
            this.tabGainNow.Name = "tabGainNow";
            this.tabGainNow.SelectedIndex = 0;
            this.tabGainNow.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            // 
            // tabPageGainNow
            // 
            this.tabPageGainNow.BackColor = System.Drawing.Color.Transparent;
            this.tabPageGainNow.Controls.Add(this.rtxtGainNow);
            resources.ApplyResources(this.tabPageGainNow, "tabPageGainNow");
            this.tabPageGainNow.Name = "tabPageGainNow";
            this.tabPageGainNow.UseVisualStyleBackColor = true;
            // 
            // rtxtGainNow
            // 
            this.rtxtGainNow.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.rtxtGainNow, "rtxtGainNow");
            this.rtxtGainNow.Name = "rtxtGainNow";
            this.rtxtGainNow.ReadOnly = true;
            this.rtxtGainNow.Enter += new System.EventHandler(this.rtxtGainNow_Enter);
            this.rtxtGainNow.Leave += new System.EventHandler(this.rtxtGainNow_Leave);
            this.rtxtGainNow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rtxtGainNow_MouseDown);
            this.rtxtGainNow.MouseLeave += new System.EventHandler(this.rtxtGainNow_MouseLeave);
            // 
            // TimerAutoTuing
            // 
            this.TimerAutoTuing.Tick += new System.EventHandler(this.TimerAutoTuing_Tick);
            // 
            // grpTargetPosition
            // 
            this.grpTargetPosition.Controls.Add(this.ctlNumTargetPosition);
            resources.ApplyResources(this.grpTargetPosition, "grpTargetPosition");
            this.grpTargetPosition.Name = "grpTargetPosition";
            this.grpTargetPosition.TabStop = false;
            // 
            // ctlNumTargetPosition
            // 
            this.ctlNumTargetPosition.DataId = 0;
            this.ctlNumTargetPosition.DigiSwVisible = true;
            resources.ApplyResources(this.ctlNumTargetPosition, "ctlNumTargetPosition");
            this.ctlNumTargetPosition.IntValue = 0;
            this.ctlNumTargetPosition.MaxData = 2000000000;
            this.ctlNumTargetPosition.MinData = -2000000000;
            this.ctlNumTargetPosition.Name = "ctlNumTargetPosition";
            this.ctlNumTargetPosition.NumBackColor = System.Drawing.Color.White;
            this.ctlNumTargetPosition.NumFont = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ctlNumTargetPosition.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumTargetPosition.PlaceNumber = 10;
            this.ctlNumTargetPosition.SignedVisible = true;
            this.ctlNumTargetPosition.SingedEnable = true;
            this.ctlNumTargetPosition.StringValue = "+0";
            this.ctlNumTargetPosition.TitleAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumTargetPosition.TitleBackColor = System.Drawing.Color.White;
            this.ctlNumTargetPosition.TitleDock = System.Windows.Forms.DockStyle.Top;
            this.ctlNumTargetPosition.TitleForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumTargetPosition.TitleHeight = 28;
            this.ctlNumTargetPosition.TitleVisible = false;
            this.ctlNumTargetPosition.UnitAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumTargetPosition.UnitBackColor = System.Drawing.Color.White;
            this.ctlNumTargetPosition.UnitDock = System.Windows.Forms.DockStyle.Bottom;
            this.ctlNumTargetPosition.UnitFont = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ctlNumTargetPosition.UnitForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumTargetPosition.UnitHeight = 36;
            this.ctlNumTargetPosition.UnitVisible = false;
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
            this.ctlNumTargetDeceleration.IntValue = 500;
            this.ctlNumTargetDeceleration.MaxData = 99999;
            this.ctlNumTargetDeceleration.MinData = 0;
            this.ctlNumTargetDeceleration.Name = "ctlNumTargetDeceleration";
            this.ctlNumTargetDeceleration.NumBackColor = System.Drawing.Color.White;
            this.ctlNumTargetDeceleration.NumFont = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ctlNumTargetDeceleration.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumTargetDeceleration.PlaceNumber = 5;
            this.ctlNumTargetDeceleration.SignedVisible = false;
            this.ctlNumTargetDeceleration.SingedEnable = false;
            this.ctlNumTargetDeceleration.StringValue = "+500";
            this.ctlNumTargetDeceleration.TitleAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumTargetDeceleration.TitleBackColor = System.Drawing.Color.White;
            this.ctlNumTargetDeceleration.TitleDock = System.Windows.Forms.DockStyle.Top;
            this.ctlNumTargetDeceleration.TitleForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumTargetDeceleration.TitleHeight = 28;
            this.ctlNumTargetDeceleration.TitleVisible = false;
            this.ctlNumTargetDeceleration.UnitAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumTargetDeceleration.UnitBackColor = System.Drawing.Color.White;
            this.ctlNumTargetDeceleration.UnitDock = System.Windows.Forms.DockStyle.Bottom;
            this.ctlNumTargetDeceleration.UnitFont = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ctlNumTargetDeceleration.UnitForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumTargetDeceleration.UnitHeight = 36;
            this.ctlNumTargetDeceleration.UnitVisible = false;
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
            this.ctlNumTargetAcceleration.IntValue = 500;
            this.ctlNumTargetAcceleration.MaxData = 99999;
            this.ctlNumTargetAcceleration.MinData = 0;
            this.ctlNumTargetAcceleration.Name = "ctlNumTargetAcceleration";
            this.ctlNumTargetAcceleration.NumBackColor = System.Drawing.Color.White;
            this.ctlNumTargetAcceleration.NumFont = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ctlNumTargetAcceleration.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumTargetAcceleration.PlaceNumber = 5;
            this.ctlNumTargetAcceleration.SignedVisible = false;
            this.ctlNumTargetAcceleration.SingedEnable = false;
            this.ctlNumTargetAcceleration.StringValue = "+500";
            this.ctlNumTargetAcceleration.TitleAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumTargetAcceleration.TitleBackColor = System.Drawing.Color.White;
            this.ctlNumTargetAcceleration.TitleDock = System.Windows.Forms.DockStyle.Top;
            this.ctlNumTargetAcceleration.TitleForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumTargetAcceleration.TitleHeight = 28;
            this.ctlNumTargetAcceleration.TitleVisible = false;
            this.ctlNumTargetAcceleration.UnitAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumTargetAcceleration.UnitBackColor = System.Drawing.Color.White;
            this.ctlNumTargetAcceleration.UnitDock = System.Windows.Forms.DockStyle.Bottom;
            this.ctlNumTargetAcceleration.UnitFont = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ctlNumTargetAcceleration.UnitForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumTargetAcceleration.UnitHeight = 36;
            this.ctlNumTargetAcceleration.UnitVisible = false;
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
            this.ctlNumTargetVelocity.IntValue = 500;
            this.ctlNumTargetVelocity.MaxData = 99999;
            this.ctlNumTargetVelocity.MinData = 0;
            this.ctlNumTargetVelocity.Name = "ctlNumTargetVelocity";
            this.ctlNumTargetVelocity.NumBackColor = System.Drawing.Color.White;
            this.ctlNumTargetVelocity.NumFont = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ctlNumTargetVelocity.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumTargetVelocity.PlaceNumber = 5;
            this.ctlNumTargetVelocity.SignedVisible = false;
            this.ctlNumTargetVelocity.SingedEnable = true;
            this.ctlNumTargetVelocity.StringValue = "+500";
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
            // lblSelect
            // 
            resources.ApplyResources(this.lblSelect, "lblSelect");
            this.lblSelect.Name = "lblSelect";
            // 
            // grpGainStrength
            // 
            this.grpGainStrength.Controls.Add(this.rdoStrong);
            this.grpGainStrength.Controls.Add(this.rdoMiddle);
            this.grpGainStrength.Controls.Add(this.rdoLight);
            resources.ApplyResources(this.grpGainStrength, "grpGainStrength");
            this.grpGainStrength.Name = "grpGainStrength";
            this.grpGainStrength.TabStop = false;
            // 
            // rdoStrong
            // 
            resources.ApplyResources(this.rdoStrong, "rdoStrong");
            this.rdoStrong.Name = "rdoStrong";
            this.rdoStrong.UseVisualStyleBackColor = true;
            this.rdoStrong.CheckedChanged += new System.EventHandler(this.rdoTuningStrength_CheckedChanged);
            // 
            // rdoMiddle
            // 
            resources.ApplyResources(this.rdoMiddle, "rdoMiddle");
            this.rdoMiddle.Name = "rdoMiddle";
            this.rdoMiddle.UseVisualStyleBackColor = true;
            this.rdoMiddle.CheckedChanged += new System.EventHandler(this.rdoTuningStrength_CheckedChanged);
            // 
            // rdoLight
            // 
            resources.ApplyResources(this.rdoLight, "rdoLight");
            this.rdoLight.Checked = true;
            this.rdoLight.ForeColor = System.Drawing.Color.Black;
            this.rdoLight.Name = "rdoLight";
            this.rdoLight.TabStop = true;
            this.rdoLight.UseVisualStyleBackColor = true;
            this.rdoLight.CheckedChanged += new System.EventHandler(this.rdoTuningStrength_CheckedChanged);
            // 
            // pnlVibration
            // 
            this.pnlVibration.BackColor = System.Drawing.Color.Blue;
            this.pnlVibration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlVibration.Controls.Add(this.lblVibration);
            resources.ApplyResources(this.pnlVibration, "pnlVibration");
            this.pnlVibration.Name = "pnlVibration";
            // 
            // lblVibration
            // 
            this.lblVibration.BackColor = System.Drawing.Color.LightCyan;
            resources.ApplyResources(this.lblVibration, "lblVibration");
            this.lblVibration.Name = "lblVibration";
            // 
            // grpMachineType
            // 
            this.grpMachineType.Controls.Add(this.rdoBelt);
            this.grpMachineType.Controls.Add(this.rdoScrew);
            this.grpMachineType.Controls.Add(this.rdoDisk);
            resources.ApplyResources(this.grpMachineType, "grpMachineType");
            this.grpMachineType.Name = "grpMachineType";
            this.grpMachineType.TabStop = false;
            // 
            // rdoBelt
            // 
            resources.ApplyResources(this.rdoBelt, "rdoBelt");
            this.rdoBelt.Checked = true;
            this.rdoBelt.Name = "rdoBelt";
            this.rdoBelt.TabStop = true;
            this.rdoBelt.UseVisualStyleBackColor = true;
            this.rdoBelt.CheckedChanged += new System.EventHandler(this.rdoMachineType_CheckedChanged);
            // 
            // rdoScrew
            // 
            resources.ApplyResources(this.rdoScrew, "rdoScrew");
            this.rdoScrew.Name = "rdoScrew";
            this.rdoScrew.UseVisualStyleBackColor = true;
            this.rdoScrew.CheckedChanged += new System.EventHandler(this.rdoMachineType_CheckedChanged);
            // 
            // rdoDisk
            // 
            resources.ApplyResources(this.rdoDisk, "rdoDisk");
            this.rdoDisk.BackColor = System.Drawing.SystemColors.Control;
            this.rdoDisk.ForeColor = System.Drawing.Color.Black;
            this.rdoDisk.Name = "rdoDisk";
            this.rdoDisk.UseVisualStyleBackColor = false;
            this.rdoDisk.CheckedChanged += new System.EventHandler(this.rdoMachineType_CheckedChanged);
            // 
            // grpTargetTime
            // 
            resources.ApplyResources(this.grpTargetTime, "grpTargetTime");
            this.grpTargetTime.Controls.Add(this.lblTargetTimeUnit);
            this.grpTargetTime.Controls.Add(this.ctlNumTargetTime);
            this.grpTargetTime.ForeColor = System.Drawing.Color.Black;
            this.grpTargetTime.Name = "grpTargetTime";
            this.grpTargetTime.TabStop = false;
            // 
            // lblTargetTimeUnit
            // 
            resources.ApplyResources(this.lblTargetTimeUnit, "lblTargetTimeUnit");
            this.lblTargetTimeUnit.ForeColor = System.Drawing.Color.Black;
            this.lblTargetTimeUnit.Name = "lblTargetTimeUnit";
            // 
            // ctlNumTargetTime
            // 
            this.ctlNumTargetTime.DataId = 0;
            this.ctlNumTargetTime.DigiSwVisible = true;
            resources.ApplyResources(this.ctlNumTargetTime, "ctlNumTargetTime");
            this.ctlNumTargetTime.IntValue = -100;
            this.ctlNumTargetTime.MaxData = 999;
            this.ctlNumTargetTime.MinData = -999;
            this.ctlNumTargetTime.Name = "ctlNumTargetTime";
            this.ctlNumTargetTime.NumBackColor = System.Drawing.Color.White;
            this.ctlNumTargetTime.NumFont = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ctlNumTargetTime.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumTargetTime.PlaceNumber = 3;
            this.ctlNumTargetTime.SignedVisible = true;
            this.ctlNumTargetTime.SingedEnable = true;
            this.ctlNumTargetTime.StringValue = "-100";
            this.ctlNumTargetTime.TitleAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumTargetTime.TitleBackColor = System.Drawing.Color.White;
            this.ctlNumTargetTime.TitleDock = System.Windows.Forms.DockStyle.Top;
            this.ctlNumTargetTime.TitleForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumTargetTime.TitleHeight = 19;
            this.ctlNumTargetTime.TitleVisible = false;
            this.ctlNumTargetTime.UnitAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumTargetTime.UnitBackColor = System.Drawing.Color.White;
            this.ctlNumTargetTime.UnitDock = System.Windows.Forms.DockStyle.Bottom;
            this.ctlNumTargetTime.UnitFont = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ctlNumTargetTime.UnitForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumTargetTime.UnitHeight = 24;
            this.ctlNumTargetTime.UnitVisible = false;
            // 
            // grpInposition
            // 
            resources.ApplyResources(this.grpInposition, "grpInposition");
            this.grpInposition.Controls.Add(this.lblInposWidthUnit);
            this.grpInposition.Controls.Add(this.ctlNumInposition);
            this.grpInposition.ForeColor = System.Drawing.Color.Black;
            this.grpInposition.Name = "grpInposition";
            this.grpInposition.TabStop = false;
            // 
            // lblInposWidthUnit
            // 
            resources.ApplyResources(this.lblInposWidthUnit, "lblInposWidthUnit");
            this.lblInposWidthUnit.ForeColor = System.Drawing.Color.Black;
            this.lblInposWidthUnit.Name = "lblInposWidthUnit";
            // 
            // ctlNumInposition
            // 
            this.ctlNumInposition.DataId = 0;
            this.ctlNumInposition.DigiSwVisible = true;
            resources.ApplyResources(this.ctlNumInposition, "ctlNumInposition");
            this.ctlNumInposition.IntValue = 64;
            this.ctlNumInposition.MaxData = 99999;
            this.ctlNumInposition.MinData = 1;
            this.ctlNumInposition.Name = "ctlNumInposition";
            this.ctlNumInposition.NumBackColor = System.Drawing.Color.White;
            this.ctlNumInposition.NumFont = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ctlNumInposition.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumInposition.PlaceNumber = 5;
            this.ctlNumInposition.SignedVisible = false;
            this.ctlNumInposition.SingedEnable = false;
            this.ctlNumInposition.StringValue = "+64";
            this.ctlNumInposition.TitleAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumInposition.TitleBackColor = System.Drawing.Color.White;
            this.ctlNumInposition.TitleDock = System.Windows.Forms.DockStyle.Top;
            this.ctlNumInposition.TitleForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumInposition.TitleHeight = 19;
            this.ctlNumInposition.TitleVisible = false;
            this.ctlNumInposition.UnitAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumInposition.UnitBackColor = System.Drawing.Color.White;
            this.ctlNumInposition.UnitDock = System.Windows.Forms.DockStyle.Bottom;
            this.ctlNumInposition.UnitFont = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ctlNumInposition.UnitForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumInposition.UnitHeight = 24;
            this.ctlNumInposition.UnitVisible = false;
            // 
            // grpTuningMode
            // 
            this.grpTuningMode.Controls.Add(this.rdoStiffnessPriorty);
            this.grpTuningMode.Controls.Add(this.rdoPositionPriorty);
            this.grpTuningMode.Controls.Add(this.rdoNormalPriorty);
            resources.ApplyResources(this.grpTuningMode, "grpTuningMode");
            this.grpTuningMode.Name = "grpTuningMode";
            this.grpTuningMode.TabStop = false;
            // 
            // rdoStiffnessPriorty
            // 
            resources.ApplyResources(this.rdoStiffnessPriorty, "rdoStiffnessPriorty");
            this.rdoStiffnessPriorty.Name = "rdoStiffnessPriorty";
            this.rdoStiffnessPriorty.UseVisualStyleBackColor = true;
            this.rdoStiffnessPriorty.CheckedChanged += new System.EventHandler(this.rdoTuningMode_CheckedChanged);
            // 
            // rdoPositionPriorty
            // 
            resources.ApplyResources(this.rdoPositionPriorty, "rdoPositionPriorty");
            this.rdoPositionPriorty.Name = "rdoPositionPriorty";
            this.rdoPositionPriorty.UseVisualStyleBackColor = true;
            this.rdoPositionPriorty.CheckedChanged += new System.EventHandler(this.rdoTuningMode_CheckedChanged);
            // 
            // rdoNormalPriorty
            // 
            resources.ApplyResources(this.rdoNormalPriorty, "rdoNormalPriorty");
            this.rdoNormalPriorty.Checked = true;
            this.rdoNormalPriorty.ForeColor = System.Drawing.Color.Black;
            this.rdoNormalPriorty.Name = "rdoNormalPriorty";
            this.rdoNormalPriorty.TabStop = true;
            this.rdoNormalPriorty.UseVisualStyleBackColor = true;
            this.rdoNormalPriorty.CheckedChanged += new System.EventHandler(this.rdoTuningMode_CheckedChanged);
            // 
            // tabTuning
            // 
            resources.ApplyResources(this.tabTuning, "tabTuning");
            this.tabTuning.Controls.Add(this.tabPageTuningMode);
            this.tabTuning.Controls.Add(this.tabPageTuningTarget);
            this.tabTuning.Controls.Add(this.tabPageTuningOutput);
            this.tabTuning.Controls.Add(this.tabPageTuningParameter);
            this.tabTuning.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabTuning.Name = "tabTuning";
            this.tabTuning.SelectedIndex = 0;
            this.tabTuning.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabTuning.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabTuning_DrawItem);
            // 
            // tabPageTuningMode
            // 
            resources.ApplyResources(this.tabPageTuningMode, "tabPageTuningMode");
            this.tabPageTuningMode.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageTuningMode.Controls.Add(this.grpMachineType);
            this.tabPageTuningMode.Controls.Add(this.grpLoadTuningSetting);
            this.tabPageTuningMode.Controls.Add(this.grpLoadTuningGain);
            this.tabPageTuningMode.Controls.Add(this.chkLoadTuning);
            this.tabPageTuningMode.Controls.Add(this.grpTargetTime);
            this.tabPageTuningMode.Controls.Add(this.grpVelocityObserver);
            this.tabPageTuningMode.Controls.Add(this.grpGainStrength);
            this.tabPageTuningMode.Controls.Add(this.grpTuningTurbo);
            this.tabPageTuningMode.Controls.Add(this.grpTuningMode);
            this.tabPageTuningMode.Controls.Add(this.grpInposition);
            this.tabPageTuningMode.Name = "tabPageTuningMode";
            this.tabPageTuningMode.Tag = "MODE";
            this.tabPageTuningMode.Click += new System.EventHandler(this.tabPageTuningMode_Click);
            // 
            // grpLoadTuningSetting
            // 
            this.grpLoadTuningSetting.BackColor = System.Drawing.SystemColors.Control;
            this.grpLoadTuningSetting.Controls.Add(this.numTempTuningCnt);
            this.grpLoadTuningSetting.Controls.Add(this.numLoadTuningAcc);
            this.grpLoadTuningSetting.Controls.Add(this.numLoadTuningVel);
            this.grpLoadTuningSetting.Controls.Add(this.numLoadTuningRev);
            this.grpLoadTuningSetting.Controls.Add(this.numLoadTuningCnt);
            this.grpLoadTuningSetting.Controls.Add(this.lblTempTuningCnt);
            this.grpLoadTuningSetting.Controls.Add(this.lblLoadTuningAcc);
            this.grpLoadTuningSetting.Controls.Add(this.lblLoadTuningVel);
            this.grpLoadTuningSetting.Controls.Add(this.lblLoadTuningRev);
            this.grpLoadTuningSetting.Controls.Add(this.lblLoadTuningCnt);
            this.grpLoadTuningSetting.Controls.Add(this.lblTempTuningCoeff);
            this.grpLoadTuningSetting.Controls.Add(this.numTempTuningCoeff);
            resources.ApplyResources(this.grpLoadTuningSetting, "grpLoadTuningSetting");
            this.grpLoadTuningSetting.Name = "grpLoadTuningSetting";
            this.grpLoadTuningSetting.TabStop = false;
            // 
            // numTempTuningCnt
            // 
            resources.ApplyResources(this.numTempTuningCnt, "numTempTuningCnt");
            this.numTempTuningCnt.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numTempTuningCnt.Name = "numTempTuningCnt";
            this.numTempTuningCnt.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numLoadTuningAcc
            // 
            this.numLoadTuningAcc.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            resources.ApplyResources(this.numLoadTuningAcc, "numLoadTuningAcc");
            this.numLoadTuningAcc.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numLoadTuningAcc.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numLoadTuningAcc.Name = "numLoadTuningAcc";
            this.numLoadTuningAcc.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // numLoadTuningVel
            // 
            this.numLoadTuningVel.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            resources.ApplyResources(this.numLoadTuningVel, "numLoadTuningVel");
            this.numLoadTuningVel.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numLoadTuningVel.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numLoadTuningVel.Name = "numLoadTuningVel";
            this.numLoadTuningVel.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // numLoadTuningRev
            // 
            resources.ApplyResources(this.numLoadTuningRev, "numLoadTuningRev");
            this.numLoadTuningRev.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numLoadTuningRev.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLoadTuningRev.Name = "numLoadTuningRev";
            this.numLoadTuningRev.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numLoadTuningCnt
            // 
            resources.ApplyResources(this.numLoadTuningCnt, "numLoadTuningCnt");
            this.numLoadTuningCnt.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numLoadTuningCnt.Name = "numLoadTuningCnt";
            this.numLoadTuningCnt.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lblTempTuningCnt
            // 
            resources.ApplyResources(this.lblTempTuningCnt, "lblTempTuningCnt");
            this.lblTempTuningCnt.Name = "lblTempTuningCnt";
            // 
            // lblLoadTuningAcc
            // 
            resources.ApplyResources(this.lblLoadTuningAcc, "lblLoadTuningAcc");
            this.lblLoadTuningAcc.Name = "lblLoadTuningAcc";
            // 
            // lblLoadTuningVel
            // 
            resources.ApplyResources(this.lblLoadTuningVel, "lblLoadTuningVel");
            this.lblLoadTuningVel.Name = "lblLoadTuningVel";
            // 
            // lblLoadTuningRev
            // 
            resources.ApplyResources(this.lblLoadTuningRev, "lblLoadTuningRev");
            this.lblLoadTuningRev.Name = "lblLoadTuningRev";
            // 
            // lblLoadTuningCnt
            // 
            resources.ApplyResources(this.lblLoadTuningCnt, "lblLoadTuningCnt");
            this.lblLoadTuningCnt.Name = "lblLoadTuningCnt";
            // 
            // lblTempTuningCoeff
            // 
            resources.ApplyResources(this.lblTempTuningCoeff, "lblTempTuningCoeff");
            this.lblTempTuningCoeff.Name = "lblTempTuningCoeff";
            // 
            // numTempTuningCoeff
            // 
            resources.ApplyResources(this.numTempTuningCoeff, "numTempTuningCoeff");
            this.numTempTuningCoeff.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTempTuningCoeff.Name = "numTempTuningCoeff";
            this.numTempTuningCoeff.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // grpLoadTuningGain
            // 
            this.grpLoadTuningGain.Controls.Add(this.grpLoadTuningKi);
            this.grpLoadTuningGain.Controls.Add(this.grpLoadTuningKv);
            this.grpLoadTuningGain.Controls.Add(this.ctlNumericInputInt1);
            this.grpLoadTuningGain.Controls.Add(this.grpLoadTuningKp);
            resources.ApplyResources(this.grpLoadTuningGain, "grpLoadTuningGain");
            this.grpLoadTuningGain.Name = "grpLoadTuningGain";
            this.grpLoadTuningGain.TabStop = false;
            // 
            // grpLoadTuningKi
            // 
            resources.ApplyResources(this.grpLoadTuningKi, "grpLoadTuningKi");
            this.grpLoadTuningKi.Controls.Add(this.lblLoadTuningKi);
            this.grpLoadTuningKi.Controls.Add(this.ctlNumLoadTuningKi);
            this.grpLoadTuningKi.ForeColor = System.Drawing.Color.Black;
            this.grpLoadTuningKi.Name = "grpLoadTuningKi";
            this.grpLoadTuningKi.TabStop = false;
            // 
            // lblLoadTuningKi
            // 
            resources.ApplyResources(this.lblLoadTuningKi, "lblLoadTuningKi");
            this.lblLoadTuningKi.ForeColor = System.Drawing.Color.Black;
            this.lblLoadTuningKi.Name = "lblLoadTuningKi";
            // 
            // ctlNumLoadTuningKi
            // 
            this.ctlNumLoadTuningKi.DataId = 0;
            this.ctlNumLoadTuningKi.DigiSwVisible = true;
            resources.ApplyResources(this.ctlNumLoadTuningKi, "ctlNumLoadTuningKi");
            this.ctlNumLoadTuningKi.IntValue = 5;
            this.ctlNumLoadTuningKi.MaxData = 999;
            this.ctlNumLoadTuningKi.MinData = -999;
            this.ctlNumLoadTuningKi.Name = "ctlNumLoadTuningKi";
            this.ctlNumLoadTuningKi.NumBackColor = System.Drawing.Color.White;
            this.ctlNumLoadTuningKi.NumFont = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ctlNumLoadTuningKi.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumLoadTuningKi.PlaceNumber = 3;
            this.ctlNumLoadTuningKi.SignedVisible = false;
            this.ctlNumLoadTuningKi.SingedEnable = false;
            this.ctlNumLoadTuningKi.StringValue = "+5";
            this.ctlNumLoadTuningKi.TitleAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumLoadTuningKi.TitleBackColor = System.Drawing.Color.White;
            this.ctlNumLoadTuningKi.TitleDock = System.Windows.Forms.DockStyle.Top;
            this.ctlNumLoadTuningKi.TitleForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumLoadTuningKi.TitleHeight = 19;
            this.ctlNumLoadTuningKi.TitleVisible = false;
            this.ctlNumLoadTuningKi.UnitAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumLoadTuningKi.UnitBackColor = System.Drawing.Color.White;
            this.ctlNumLoadTuningKi.UnitDock = System.Windows.Forms.DockStyle.Bottom;
            this.ctlNumLoadTuningKi.UnitFont = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ctlNumLoadTuningKi.UnitForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumLoadTuningKi.UnitHeight = 24;
            this.ctlNumLoadTuningKi.UnitVisible = false;
            // 
            // grpLoadTuningKv
            // 
            resources.ApplyResources(this.grpLoadTuningKv, "grpLoadTuningKv");
            this.grpLoadTuningKv.Controls.Add(this.lblLoadTuningKv);
            this.grpLoadTuningKv.Controls.Add(this.ctlNumLoadTuningKv);
            this.grpLoadTuningKv.ForeColor = System.Drawing.Color.Black;
            this.grpLoadTuningKv.Name = "grpLoadTuningKv";
            this.grpLoadTuningKv.TabStop = false;
            // 
            // lblLoadTuningKv
            // 
            resources.ApplyResources(this.lblLoadTuningKv, "lblLoadTuningKv");
            this.lblLoadTuningKv.ForeColor = System.Drawing.Color.Black;
            this.lblLoadTuningKv.Name = "lblLoadTuningKv";
            // 
            // ctlNumLoadTuningKv
            // 
            this.ctlNumLoadTuningKv.DataId = 0;
            this.ctlNumLoadTuningKv.DigiSwVisible = true;
            resources.ApplyResources(this.ctlNumLoadTuningKv, "ctlNumLoadTuningKv");
            this.ctlNumLoadTuningKv.IntValue = 314;
            this.ctlNumLoadTuningKv.MaxData = 999;
            this.ctlNumLoadTuningKv.MinData = -999;
            this.ctlNumLoadTuningKv.Name = "ctlNumLoadTuningKv";
            this.ctlNumLoadTuningKv.NumBackColor = System.Drawing.Color.White;
            this.ctlNumLoadTuningKv.NumFont = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ctlNumLoadTuningKv.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumLoadTuningKv.PlaceNumber = 3;
            this.ctlNumLoadTuningKv.SignedVisible = false;
            this.ctlNumLoadTuningKv.SingedEnable = false;
            this.ctlNumLoadTuningKv.StringValue = "+314";
            this.ctlNumLoadTuningKv.TitleAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumLoadTuningKv.TitleBackColor = System.Drawing.Color.White;
            this.ctlNumLoadTuningKv.TitleDock = System.Windows.Forms.DockStyle.Top;
            this.ctlNumLoadTuningKv.TitleForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumLoadTuningKv.TitleHeight = 19;
            this.ctlNumLoadTuningKv.TitleVisible = false;
            this.ctlNumLoadTuningKv.UnitAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumLoadTuningKv.UnitBackColor = System.Drawing.Color.White;
            this.ctlNumLoadTuningKv.UnitDock = System.Windows.Forms.DockStyle.Bottom;
            this.ctlNumLoadTuningKv.UnitFont = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ctlNumLoadTuningKv.UnitForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumLoadTuningKv.UnitHeight = 24;
            this.ctlNumLoadTuningKv.UnitVisible = false;
            // 
            // ctlNumericInputInt1
            // 
            this.ctlNumericInputInt1.DataId = 0;
            this.ctlNumericInputInt1.DigiSwVisible = true;
            resources.ApplyResources(this.ctlNumericInputInt1, "ctlNumericInputInt1");
            this.ctlNumericInputInt1.IntValue = 0;
            this.ctlNumericInputInt1.MaxData = 10000;
            this.ctlNumericInputInt1.MinData = -10000;
            this.ctlNumericInputInt1.Name = "ctlNumericInputInt1";
            this.ctlNumericInputInt1.NumBackColor = System.Drawing.Color.White;
            this.ctlNumericInputInt1.NumFont = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ctlNumericInputInt1.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumericInputInt1.PlaceNumber = 3;
            this.ctlNumericInputInt1.SignedVisible = false;
            this.ctlNumericInputInt1.SingedEnable = true;
            this.ctlNumericInputInt1.StringValue = "+0";
            this.ctlNumericInputInt1.TitleAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumericInputInt1.TitleBackColor = System.Drawing.Color.White;
            this.ctlNumericInputInt1.TitleDock = System.Windows.Forms.DockStyle.Top;
            this.ctlNumericInputInt1.TitleForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumericInputInt1.TitleHeight = 19;
            this.ctlNumericInputInt1.TitleVisible = false;
            this.ctlNumericInputInt1.UnitAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumericInputInt1.UnitBackColor = System.Drawing.Color.White;
            this.ctlNumericInputInt1.UnitDock = System.Windows.Forms.DockStyle.Bottom;
            this.ctlNumericInputInt1.UnitFont = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ctlNumericInputInt1.UnitForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumericInputInt1.UnitHeight = 24;
            this.ctlNumericInputInt1.UnitVisible = false;
            // 
            // grpLoadTuningKp
            // 
            resources.ApplyResources(this.grpLoadTuningKp, "grpLoadTuningKp");
            this.grpLoadTuningKp.Controls.Add(this.lblLoadTuningKp);
            this.grpLoadTuningKp.Controls.Add(this.ctlNumLoadTuningKp);
            this.grpLoadTuningKp.ForeColor = System.Drawing.Color.Black;
            this.grpLoadTuningKp.Name = "grpLoadTuningKp";
            this.grpLoadTuningKp.TabStop = false;
            // 
            // lblLoadTuningKp
            // 
            resources.ApplyResources(this.lblLoadTuningKp, "lblLoadTuningKp");
            this.lblLoadTuningKp.ForeColor = System.Drawing.Color.Black;
            this.lblLoadTuningKp.Name = "lblLoadTuningKp";
            // 
            // ctlNumLoadTuningKp
            // 
            this.ctlNumLoadTuningKp.DataId = 0;
            this.ctlNumLoadTuningKp.DigiSwVisible = true;
            resources.ApplyResources(this.ctlNumLoadTuningKp, "ctlNumLoadTuningKp");
            this.ctlNumLoadTuningKp.IntValue = 20;
            this.ctlNumLoadTuningKp.MaxData = 999;
            this.ctlNumLoadTuningKp.MinData = -999;
            this.ctlNumLoadTuningKp.Name = "ctlNumLoadTuningKp";
            this.ctlNumLoadTuningKp.NumBackColor = System.Drawing.Color.White;
            this.ctlNumLoadTuningKp.NumFont = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ctlNumLoadTuningKp.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumLoadTuningKp.PlaceNumber = 3;
            this.ctlNumLoadTuningKp.SignedVisible = false;
            this.ctlNumLoadTuningKp.SingedEnable = false;
            this.ctlNumLoadTuningKp.StringValue = "+20";
            this.ctlNumLoadTuningKp.TitleAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumLoadTuningKp.TitleBackColor = System.Drawing.Color.White;
            this.ctlNumLoadTuningKp.TitleDock = System.Windows.Forms.DockStyle.Top;
            this.ctlNumLoadTuningKp.TitleForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumLoadTuningKp.TitleHeight = 19;
            this.ctlNumLoadTuningKp.TitleVisible = false;
            this.ctlNumLoadTuningKp.UnitAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumLoadTuningKp.UnitBackColor = System.Drawing.Color.White;
            this.ctlNumLoadTuningKp.UnitDock = System.Windows.Forms.DockStyle.Bottom;
            this.ctlNumLoadTuningKp.UnitFont = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ctlNumLoadTuningKp.UnitForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumLoadTuningKp.UnitHeight = 24;
            this.ctlNumLoadTuningKp.UnitVisible = false;
            // 
            // chkLoadTuning
            // 
            resources.ApplyResources(this.chkLoadTuning, "chkLoadTuning");
            this.chkLoadTuning.ForeColor = System.Drawing.Color.Black;
            this.chkLoadTuning.Name = "chkLoadTuning";
            this.chkLoadTuning.UseVisualStyleBackColor = false;
            this.chkLoadTuning.CheckedChanged += new System.EventHandler(this.chkLoadTuning_CheckedChanged);
            // 
            // grpVelocityObserver
            // 
            this.grpVelocityObserver.Controls.Add(this.rdoVelObsDisable);
            this.grpVelocityObserver.Controls.Add(this.rdoVelObsEnable);
            resources.ApplyResources(this.grpVelocityObserver, "grpVelocityObserver");
            this.grpVelocityObserver.Name = "grpVelocityObserver";
            this.grpVelocityObserver.TabStop = false;
            // 
            // rdoVelObsDisable
            // 
            resources.ApplyResources(this.rdoVelObsDisable, "rdoVelObsDisable");
            this.rdoVelObsDisable.Checked = true;
            this.rdoVelObsDisable.Name = "rdoVelObsDisable";
            this.rdoVelObsDisable.TabStop = true;
            this.rdoVelObsDisable.UseVisualStyleBackColor = true;
            this.rdoVelObsDisable.CheckedChanged += new System.EventHandler(this.rdoVelObsEnable_CheckedChanged);
            // 
            // rdoVelObsEnable
            // 
            resources.ApplyResources(this.rdoVelObsEnable, "rdoVelObsEnable");
            this.rdoVelObsEnable.ForeColor = System.Drawing.Color.Black;
            this.rdoVelObsEnable.Name = "rdoVelObsEnable";
            this.rdoVelObsEnable.UseVisualStyleBackColor = true;
            this.rdoVelObsEnable.CheckedChanged += new System.EventHandler(this.rdoVelObsEnable_CheckedChanged);
            // 
            // grpTuningTurbo
            // 
            this.grpTuningTurbo.Controls.Add(this.rdoTurboDisable);
            this.grpTuningTurbo.Controls.Add(this.rdoTurboEnable);
            resources.ApplyResources(this.grpTuningTurbo, "grpTuningTurbo");
            this.grpTuningTurbo.Name = "grpTuningTurbo";
            this.grpTuningTurbo.TabStop = false;
            // 
            // rdoTurboDisable
            // 
            resources.ApplyResources(this.rdoTurboDisable, "rdoTurboDisable");
            this.rdoTurboDisable.Checked = true;
            this.rdoTurboDisable.Name = "rdoTurboDisable";
            this.rdoTurboDisable.TabStop = true;
            this.rdoTurboDisable.UseVisualStyleBackColor = true;
            this.rdoTurboDisable.CheckedChanged += new System.EventHandler(this.rdoTurboEnable_CheckedChanged);
            // 
            // rdoTurboEnable
            // 
            resources.ApplyResources(this.rdoTurboEnable, "rdoTurboEnable");
            this.rdoTurboEnable.ForeColor = System.Drawing.Color.Black;
            this.rdoTurboEnable.Name = "rdoTurboEnable";
            this.rdoTurboEnable.UseVisualStyleBackColor = true;
            this.rdoTurboEnable.CheckedChanged += new System.EventHandler(this.rdoTurboEnable_CheckedChanged);
            // 
            // tabPageTuningTarget
            // 
            resources.ApplyResources(this.tabPageTuningTarget, "tabPageTuningTarget");
            this.tabPageTuningTarget.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageTuningTarget.Controls.Add(this.lblSelect);
            this.tabPageTuningTarget.Controls.Add(this.lblInc);
            this.tabPageTuningTarget.Controls.Add(this.chkInc);
            this.tabPageTuningTarget.Controls.Add(this.grpWait);
            this.tabPageTuningTarget.Controls.Add(this.grpVelocity);
            this.tabPageTuningTarget.Controls.Add(this.grpAcceleration);
            this.tabPageTuningTarget.Controls.Add(this.grpDeceleration);
            this.tabPageTuningTarget.Controls.Add(this.grpStartPosition);
            this.tabPageTuningTarget.Controls.Add(this.grpTargetPosition);
            this.tabPageTuningTarget.Name = "tabPageTuningTarget";
            this.tabPageTuningTarget.Tag = "TGT";
            this.tabPageTuningTarget.Click += new System.EventHandler(this.tabPageTuningTarget_Click);
            // 
            // lblInc
            // 
            resources.ApplyResources(this.lblInc, "lblInc");
            this.lblInc.ForeColor = System.Drawing.Color.Crimson;
            this.lblInc.Name = "lblInc";
            // 
            // chkInc
            // 
            resources.ApplyResources(this.chkInc, "chkInc");
            this.chkInc.Checked = true;
            this.chkInc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInc.ForeColor = System.Drawing.Color.Black;
            this.chkInc.Name = "chkInc";
            this.chkInc.Tag = "INC";
            this.chkInc.UseVisualStyleBackColor = true;
            this.chkInc.CheckStateChanged += new System.EventHandler(this.chkInc_CheckStateChanged);
            // 
            // grpWait
            // 
            this.grpWait.Controls.Add(this.ctlNumWaitTime);
            resources.ApplyResources(this.grpWait, "grpWait");
            this.grpWait.ForeColor = System.Drawing.Color.Black;
            this.grpWait.Name = "grpWait";
            this.grpWait.TabStop = false;
            // 
            // ctlNumWaitTime
            // 
            this.ctlNumWaitTime.DataId = 0;
            this.ctlNumWaitTime.DigiSwVisible = true;
            resources.ApplyResources(this.ctlNumWaitTime, "ctlNumWaitTime");
            this.ctlNumWaitTime.IntValue = 500;
            this.ctlNumWaitTime.MaxData = 9999;
            this.ctlNumWaitTime.MinData = 500;
            this.ctlNumWaitTime.Name = "ctlNumWaitTime";
            this.ctlNumWaitTime.NumBackColor = System.Drawing.Color.White;
            this.ctlNumWaitTime.NumFont = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ctlNumWaitTime.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumWaitTime.PlaceNumber = 4;
            this.ctlNumWaitTime.SignedVisible = false;
            this.ctlNumWaitTime.SingedEnable = false;
            this.ctlNumWaitTime.StringValue = "+500";
            this.ctlNumWaitTime.TitleAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumWaitTime.TitleBackColor = System.Drawing.Color.White;
            this.ctlNumWaitTime.TitleDock = System.Windows.Forms.DockStyle.Top;
            this.ctlNumWaitTime.TitleForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumWaitTime.TitleHeight = 19;
            this.ctlNumWaitTime.TitleVisible = false;
            this.ctlNumWaitTime.UnitAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumWaitTime.UnitBackColor = System.Drawing.Color.White;
            this.ctlNumWaitTime.UnitDock = System.Windows.Forms.DockStyle.Bottom;
            this.ctlNumWaitTime.UnitFont = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ctlNumWaitTime.UnitForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumWaitTime.UnitHeight = 24;
            this.ctlNumWaitTime.UnitVisible = false;
            // 
            // grpStartPosition
            // 
            this.grpStartPosition.Controls.Add(this.ctlNumStartPosition);
            resources.ApplyResources(this.grpStartPosition, "grpStartPosition");
            this.grpStartPosition.Name = "grpStartPosition";
            this.grpStartPosition.TabStop = false;
            // 
            // ctlNumStartPosition
            // 
            this.ctlNumStartPosition.DataId = 0;
            this.ctlNumStartPosition.DigiSwVisible = true;
            resources.ApplyResources(this.ctlNumStartPosition, "ctlNumStartPosition");
            this.ctlNumStartPosition.IntValue = 0;
            this.ctlNumStartPosition.MaxData = 2000000000;
            this.ctlNumStartPosition.MinData = -2000000000;
            this.ctlNumStartPosition.Name = "ctlNumStartPosition";
            this.ctlNumStartPosition.NumBackColor = System.Drawing.Color.White;
            this.ctlNumStartPosition.NumFont = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ctlNumStartPosition.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumStartPosition.PlaceNumber = 10;
            this.ctlNumStartPosition.SignedVisible = true;
            this.ctlNumStartPosition.SingedEnable = true;
            this.ctlNumStartPosition.StringValue = "+0";
            this.ctlNumStartPosition.TitleAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumStartPosition.TitleBackColor = System.Drawing.Color.White;
            this.ctlNumStartPosition.TitleDock = System.Windows.Forms.DockStyle.Top;
            this.ctlNumStartPosition.TitleForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumStartPosition.TitleHeight = 28;
            this.ctlNumStartPosition.TitleVisible = false;
            this.ctlNumStartPosition.UnitAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumStartPosition.UnitBackColor = System.Drawing.Color.White;
            this.ctlNumStartPosition.UnitDock = System.Windows.Forms.DockStyle.Bottom;
            this.ctlNumStartPosition.UnitFont = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ctlNumStartPosition.UnitForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumStartPosition.UnitHeight = 36;
            this.ctlNumStartPosition.UnitVisible = false;
            // 
            // tabPageTuningOutput
            // 
            resources.ApplyResources(this.tabPageTuningOutput, "tabPageTuningOutput");
            this.tabPageTuningOutput.BackColor = System.Drawing.Color.Transparent;
            this.tabPageTuningOutput.Controls.Add(this.splOutput);
            this.tabPageTuningOutput.Name = "tabPageTuningOutput";
            this.tabPageTuningOutput.Tag = "OUT";
            this.tabPageTuningOutput.UseVisualStyleBackColor = true;
            // 
            // tabPageTuningParameter
            // 
            resources.ApplyResources(this.tabPageTuningParameter, "tabPageTuningParameter");
            this.tabPageTuningParameter.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageTuningParameter.Controls.Add(this.dgvSetting);
            this.tabPageTuningParameter.Controls.Add(this.toolStripTuningSetting);
            this.tabPageTuningParameter.Name = "tabPageTuningParameter";
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
            dataGridViewCellStyle2.Font = new System.Drawing.Font("メイリオ", 9F);
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
            this.OldValue});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("メイリオ", 9F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSetting.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSetting.EnableHeadersVisualStyles = false;
            this.dgvSetting.MultiSelect = false;
            this.dgvSetting.Name = "dgvSetting";
            this.dgvSetting.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvSetting.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvSetting.RowTemplate.Height = 21;
            this.dgvSetting.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSetting.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvSetting.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvSetting_CellBeginEdit);
            this.dgvSetting.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSetting_CellEndEdit);
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
            this.ClassName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.ClassName.DefaultCellStyle = dataGridViewCellStyle3;
            this.ClassName.FillWeight = 131.9728F;
            resources.ApplyResources(this.ClassName, "ClassName");
            this.ClassName.Name = "ClassName";
            this.ClassName.ReadOnly = true;
            this.ClassName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // OldValue
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.OldValue.DefaultCellStyle = dataGridViewCellStyle4;
            this.OldValue.FillWeight = 68.02721F;
            resources.ApplyResources(this.OldValue, "OldValue");
            this.OldValue.Name = "OldValue";
            this.OldValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // toolStripTuningSetting
            // 
            resources.ApplyResources(this.toolStripTuningSetting, "toolStripTuningSetting");
            this.toolStripTuningSetting.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripTuningSetting.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator9,
            this.btnConfigOutput,
            this.toolStripSeparator5,
            this.btnConfigRead,
            this.toolStripSeparator2});
            this.toolStripTuningSetting.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStripTuningSetting.Name = "toolStripTuningSetting";
            this.toolStripTuningSetting.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            resources.ApplyResources(this.toolStripSeparator9, "toolStripSeparator9");
            // 
            // btnConfigOutput
            // 
            this.btnConfigOutput.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnConfigOutput, "btnConfigOutput");
            this.btnConfigOutput.Name = "btnConfigOutput";
            this.btnConfigOutput.Click += new System.EventHandler(this.btnConfigOutput_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // btnConfigRead
            // 
            this.btnConfigRead.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.btnConfigRead, "btnConfigRead");
            this.btnConfigRead.Name = "btnConfigRead";
            this.btnConfigRead.Click += new System.EventHandler(this.btnConfigRead_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // pnlWatch
            // 
            this.pnlWatch.BackColor = System.Drawing.SystemColors.Control;
            this.pnlWatch.Controls.Add(this.lblStopWatch);
            this.pnlWatch.Controls.Add(this.pnlVibration);
            this.pnlWatch.Controls.Add(this.btnStop);
            resources.ApplyResources(this.pnlWatch, "pnlWatch");
            this.pnlWatch.Name = "pnlWatch";
            // 
            // lblStopWatch
            // 
            this.lblStopWatch.BackColor = System.Drawing.Color.LightCyan;
            this.lblStopWatch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lblStopWatch, "lblStopWatch");
            this.lblStopWatch.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblStopWatch.Name = "lblStopWatch";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnStop, "btnStop");
            this.btnStop.Name = "btnStop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // TimerResize
            // 
            this.TimerResize.Interval = 500;
            this.TimerResize.Tick += new System.EventHandler(this.TimerResize_Tick);
            // 
            // toolStripAutoTuning
            // 
            this.toolStripAutoTuning.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAutoTuningWizard,
            this.toolStripSeparator1,
            this.btnTuningControl,
            this.toolStripSeparator7});
            this.toolStripAutoTuning.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            resources.ApplyResources(this.toolStripAutoTuning, "toolStripAutoTuning");
            this.toolStripAutoTuning.Name = "toolStripAutoTuning";
            this.toolStripAutoTuning.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // btnAutoTuningWizard
            // 
            resources.ApplyResources(this.btnAutoTuningWizard, "btnAutoTuningWizard");
            this.btnAutoTuningWizard.Name = "btnAutoTuningWizard";
            this.btnAutoTuningWizard.Click += new System.EventHandler(this.btnWizard_Click);
            this.btnAutoTuningWizard.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.btnAutoTuningWizard.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.toolStripSeparator1.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // btnTuningControl
            // 
            resources.ApplyResources(this.btnTuningControl, "btnTuningControl");
            this.btnTuningControl.Name = "btnTuningControl";
            this.btnTuningControl.Click += new System.EventHandler(this.btnTuningControl_Click);
            this.btnTuningControl.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.btnTuningControl.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            // 
            // toolStripAutoTuning2
            // 
            this.toolStripAutoTuning2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPause,
            this.toolStripSeparator6,
            this.btnRepeat,
            this.toolStripSeparator4,
            this.btnStop2,
            this.toolStripSeparator3});
            this.toolStripAutoTuning2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            resources.ApplyResources(this.toolStripAutoTuning2, "toolStripAutoTuning2");
            this.toolStripAutoTuning2.Name = "toolStripAutoTuning2";
            this.toolStripAutoTuning2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // btnPause
            // 
            resources.ApplyResources(this.btnPause, "btnPause");
            this.btnPause.Name = "btnPause";
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            this.btnPause.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.btnPause.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            this.toolStripSeparator6.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.toolStripSeparator6.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // btnRepeat
            // 
            resources.ApplyResources(this.btnRepeat, "btnRepeat");
            this.btnRepeat.Name = "btnRepeat";
            this.btnRepeat.Click += new System.EventHandler(this.btnRepeat_Click);
            this.btnRepeat.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.btnRepeat.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            this.toolStripSeparator4.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.toolStripSeparator4.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // btnStop2
            // 
            resources.ApplyResources(this.btnStop2, "btnStop2");
            this.btnStop2.Name = "btnStop2";
            this.btnStop2.Click += new System.EventHandler(this.btnStop_Click);
            this.btnStop2.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.btnStop2.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            this.toolStripSeparator3.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.toolStripSeparator3.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // AutoTuningForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabTuning);
            this.Controls.Add(this.toolStripAutoTuning2);
            this.Controls.Add(this.toolStripAutoTuning);
            this.Controls.Add(this.pnlWatch);
            this.Name = "AutoTuningForm";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AutoTuningForm_FormClosing);
            this.Load += new System.EventHandler(this.AutoTuningForm_Load);
            this.Resize += new System.EventHandler(this.AutoTuningForm_Resize);
            this.splOutput.Panel1.ResumeLayout(false);
            this.splOutput.Panel2.ResumeLayout(false);
            this.splOutput.ResumeLayout(false);
            this.tabAutoTuning.ResumeLayout(false);
            this.tabPageOutput1.ResumeLayout(false);
            this.tabPageOutput2.ResumeLayout(false);
            this.tabGainNow.ResumeLayout(false);
            this.tabPageGainNow.ResumeLayout(false);
            this.grpTargetPosition.ResumeLayout(false);
            this.grpDeceleration.ResumeLayout(false);
            this.grpDeceleration.PerformLayout();
            this.grpAcceleration.ResumeLayout(false);
            this.grpAcceleration.PerformLayout();
            this.grpVelocity.ResumeLayout(false);
            this.grpGainStrength.ResumeLayout(false);
            this.grpGainStrength.PerformLayout();
            this.pnlVibration.ResumeLayout(false);
            this.grpMachineType.ResumeLayout(false);
            this.grpMachineType.PerformLayout();
            this.grpTargetTime.ResumeLayout(false);
            this.grpTargetTime.PerformLayout();
            this.grpInposition.ResumeLayout(false);
            this.grpInposition.PerformLayout();
            this.grpTuningMode.ResumeLayout(false);
            this.grpTuningMode.PerformLayout();
            this.tabTuning.ResumeLayout(false);
            this.tabPageTuningMode.ResumeLayout(false);
            this.tabPageTuningMode.PerformLayout();
            this.grpLoadTuningSetting.ResumeLayout(false);
            this.grpLoadTuningSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTempTuningCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLoadTuningAcc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLoadTuningVel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLoadTuningRev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLoadTuningCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTempTuningCoeff)).EndInit();
            this.grpLoadTuningGain.ResumeLayout(false);
            this.grpLoadTuningKi.ResumeLayout(false);
            this.grpLoadTuningKi.PerformLayout();
            this.grpLoadTuningKv.ResumeLayout(false);
            this.grpLoadTuningKv.PerformLayout();
            this.grpLoadTuningKp.ResumeLayout(false);
            this.grpLoadTuningKp.PerformLayout();
            this.grpVelocityObserver.ResumeLayout(false);
            this.grpVelocityObserver.PerformLayout();
            this.grpTuningTurbo.ResumeLayout(false);
            this.grpTuningTurbo.PerformLayout();
            this.tabPageTuningTarget.ResumeLayout(false);
            this.tabPageTuningTarget.PerformLayout();
            this.grpWait.ResumeLayout(false);
            this.grpStartPosition.ResumeLayout(false);
            this.tabPageTuningOutput.ResumeLayout(false);
            this.tabPageTuningParameter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSetting)).EndInit();
            this.toolStripTuningSetting.ResumeLayout(false);
            this.toolStripTuningSetting.PerformLayout();
            this.pnlWatch.ResumeLayout(false);
            this.toolStripAutoTuning.ResumeLayout(false);
            this.toolStripAutoTuning.PerformLayout();
            this.toolStripAutoTuning2.ResumeLayout(false);
            this.toolStripAutoTuning2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Timer TimerAutoTuing;
		private System.Windows.Forms.RichTextBox rtxtResult;
		private System.Windows.Forms.GroupBox grpTargetPosition;
		private Motion_Designer.CtlNumericInputInt ctlNumTargetPosition;
		private System.Windows.Forms.GroupBox grpDeceleration;
		private Motion_Designer.CtlNumericInputInt ctlNumTargetDeceleration;
		private System.Windows.Forms.GroupBox grpAcceleration;
		private Motion_Designer.CtlNumericInputInt ctlNumTargetAcceleration;
		private System.Windows.Forms.GroupBox grpVelocity;
		private Motion_Designer.CtlNumericInputInt ctlNumTargetVelocity;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.Label lblAccTime;
		private System.Windows.Forms.Label lblDccTime;
		private System.Windows.Forms.GroupBox grpGainStrength;
		private System.Windows.Forms.RadioButton rdoStrong;
		private System.Windows.Forms.RadioButton rdoMiddle;
		private System.Windows.Forms.RadioButton rdoLight;
		private System.Windows.Forms.Panel pnlVibration;
		private System.Windows.Forms.GroupBox grpMachineType;
		private System.Windows.Forms.RadioButton rdoBelt;
		private System.Windows.Forms.RadioButton rdoScrew;
		private System.Windows.Forms.RadioButton rdoDisk;
		private System.Windows.Forms.GroupBox grpTargetTime;
		private CtlNumericInputInt ctlNumTargetTime;
		private System.Windows.Forms.Label lblVibration;
		private System.Windows.Forms.Label lblTargetTimeUnit;
		private System.Windows.Forms.GroupBox grpInposition;
		private System.Windows.Forms.Label lblInposWidthUnit;
		private CtlNumericInputInt ctlNumInposition;
		private System.Windows.Forms.RichTextBox rtxtFFT_Peek;
		private System.Windows.Forms.TabControl tabAutoTuning;
		private System.Windows.Forms.TabPage tabPageOutput1;
		private System.Windows.Forms.TabPage tabPageOutput2;
		private System.Windows.Forms.GroupBox grpTuningMode;
		private System.Windows.Forms.RadioButton rdoStiffnessPriorty;
		private System.Windows.Forms.RadioButton rdoPositionPriorty;
		private System.Windows.Forms.RadioButton rdoNormalPriorty;
		private System.Windows.Forms.TabControl tabTuning;
		private System.Windows.Forms.TabPage tabPageTuningTarget;
		private System.Windows.Forms.TabPage tabPageTuningMode;
		private System.Windows.Forms.TabPage tabPageTuningOutput;
		private System.Windows.Forms.Panel pnlWatch;
		private System.Windows.Forms.TabControl tabGainNow;
		private System.Windows.Forms.TabPage tabPageGainNow;
		private System.Windows.Forms.RichTextBox rtxtGainNow;
		private System.Windows.Forms.Timer TimerResize;
		private System.Windows.Forms.Label lblStopWatch;
		private System.Windows.Forms.GroupBox grpWait;
		private CtlNumericInputInt ctlNumWaitTime;
		private CtlNumericInputInt ctlNumericInputInt1;
		private System.Windows.Forms.Label lblSelect;
		private System.Windows.Forms.ToolStrip toolStripAutoTuning;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStrip toolStripAutoTuning2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton btnPause;
		private System.Windows.Forms.ToolStripButton btnRepeat;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton btnStop2;
		private System.Windows.Forms.ToolStripButton btnAutoTuningWizard;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.GroupBox grpStartPosition;
		private CtlNumericInputInt ctlNumStartPosition;
		private System.Windows.Forms.CheckBox chkInc;
		private System.Windows.Forms.Label lblInc;
		private System.Windows.Forms.SaveFileDialog SaveFileDialog;
		private System.Windows.Forms.OpenFileDialog OpenFileDialog;
		private System.Windows.Forms.GroupBox grpVelocityObserver;
		private System.Windows.Forms.RadioButton rdoVelObsDisable;
		private System.Windows.Forms.RadioButton rdoVelObsEnable;
		private System.Windows.Forms.GroupBox grpLoadTuningGain;
		private System.Windows.Forms.GroupBox grpLoadTuningKp;
		private System.Windows.Forms.Label lblLoadTuningKp;
		private CtlNumericInputInt ctlNumLoadTuningKp;
		private System.Windows.Forms.GroupBox grpLoadTuningKi;
		private System.Windows.Forms.Label lblLoadTuningKi;
		private CtlNumericInputInt ctlNumLoadTuningKi;
		private System.Windows.Forms.GroupBox grpLoadTuningKv;
		private System.Windows.Forms.Label lblLoadTuningKv;
		private CtlNumericInputInt ctlNumLoadTuningKv;
		private System.Windows.Forms.CheckBox chkLoadTuning;
		private System.Windows.Forms.TabPage tabPageTuningParameter;
		private System.Windows.Forms.ToolStrip toolStripTuningSetting;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
		private System.Windows.Forms.ToolStripButton btnConfigOutput;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripButton btnConfigRead;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.SplitContainer splOutput;
		private System.Windows.Forms.Label lblTempTuningCoeff;
		private System.Windows.Forms.GroupBox grpLoadTuningSetting;
		private NumericUpDownEx numTempTuningCoeff;
		private NumericUpDownEx numTempTuningCnt;
		private NumericUpDownEx numLoadTuningCnt;
		private System.Windows.Forms.Label lblTempTuningCnt;
		public System.Windows.Forms.Label lblLoadTuningCnt;
		private System.Windows.Forms.DataGridView dgvSetting;
		private System.Windows.Forms.DataGridViewTextBoxColumn ID;
		private System.Windows.Forms.DataGridViewTextBoxColumn ClassName;
		private System.Windows.Forms.DataGridViewTextBoxColumn OldValue;
		private System.Windows.Forms.GroupBox grpTuningTurbo;
		private System.Windows.Forms.RadioButton rdoTurboDisable;
		private System.Windows.Forms.RadioButton rdoTurboEnable;
		private NumericUpDownEx numLoadTuningRev;
		public System.Windows.Forms.Label lblLoadTuningVel;
		public System.Windows.Forms.Label lblLoadTuningRev;
		private NumericUpDownEx numLoadTuningAcc;
		private NumericUpDownEx numLoadTuningVel;
		public System.Windows.Forms.Label lblLoadTuningAcc;
		private System.Windows.Forms.ToolStripButton btnTuningControl;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
	}
}