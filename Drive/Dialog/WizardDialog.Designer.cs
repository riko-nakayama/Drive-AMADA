namespace Motion_Designer
{
	partial class WizardDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WizardDialog));
            this.tabWizard = new System.Windows.Forms.TabControl();
            this.tabPageLoad = new System.Windows.Forms.TabPage();
            this.pnlPageLoad = new System.Windows.Forms.Panel();
            this.lblLoadSet = new System.Windows.Forms.Label();
            this.pnlLoad = new System.Windows.Forms.Panel();
            this.lblLoad = new System.Windows.Forms.Label();
            this.ctlNumLoad = new Motion_Designer.CtlNumericInputInt();
            this.lblLoadExclamation = new System.Windows.Forms.Label();
            this.lblLoadNow = new System.Windows.Forms.Label();
            this.lblDmy = new System.Windows.Forms.Label();
            this.lblLoadAdjust = new System.Windows.Forms.Label();
            this.lblLoadExclamation2 = new System.Windows.Forms.Label();
            this.btnLoadTuning = new System.Windows.Forms.Button();
            this.lblLoadAdjust2 = new System.Windows.Forms.Label();
            this.lblLoadSet2 = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            this.tabPageMachine = new System.Windows.Forms.TabPage();
            this.pnlPageMachine = new System.Windows.Forms.Panel();
            this.pnlMachine = new System.Windows.Forms.Panel();
            this.lblMachine = new System.Windows.Forms.Label();
            this.rdoBelt = new System.Windows.Forms.RadioButton();
            this.rdoDisk = new System.Windows.Forms.RadioButton();
            this.rdoScrew = new System.Windows.Forms.RadioButton();
            this.tabPageStrength = new System.Windows.Forms.TabPage();
            this.pnlPageStrength = new System.Windows.Forms.Panel();
            this.pnlStrength = new System.Windows.Forms.Panel();
            this.lblStrength = new System.Windows.Forms.Label();
            this.rdoStrong = new System.Windows.Forms.RadioButton();
            this.rdoLight = new System.Windows.Forms.RadioButton();
            this.rdoMidlle = new System.Windows.Forms.RadioButton();
            this.tabPageMode = new System.Windows.Forms.TabPage();
            this.pnlPageMode = new System.Windows.Forms.Panel();
            this.pnlMode = new System.Windows.Forms.Panel();
            this.lblMode = new System.Windows.Forms.Label();
            this.rdoStiffnessPriorty = new System.Windows.Forms.RadioButton();
            this.rdoNormalPriorty = new System.Windows.Forms.RadioButton();
            this.rdoPositionPriorty = new System.Windows.Forms.RadioButton();
            this.tabPageVelObs = new System.Windows.Forms.TabPage();
            this.pnlPageVelObs = new System.Windows.Forms.Panel();
            this.lblVelObsExclamation3 = new System.Windows.Forms.Label();
            this.lblVelObsExclamation1 = new System.Windows.Forms.Label();
            this.lblVelObsExclamation2 = new System.Windows.Forms.Label();
            this.pnlVelObs = new System.Windows.Forms.Panel();
            this.lblVelObs = new System.Windows.Forms.Label();
            this.rdoVelObsDisable = new System.Windows.Forms.RadioButton();
            this.rdoVelObsEnable = new System.Windows.Forms.RadioButton();
            this.tabPageTurbo = new System.Windows.Forms.TabPage();
            this.pnlPageTurbo = new System.Windows.Forms.Panel();
            this.pnlTurbo = new System.Windows.Forms.Panel();
            this.lblTurbo = new System.Windows.Forms.Label();
            this.lblTurboExclamation2 = new System.Windows.Forms.Label();
            this.rdoTurboEnable = new System.Windows.Forms.RadioButton();
            this.lblTurboExclamation = new System.Windows.Forms.Label();
            this.rdoTurboDisable = new System.Windows.Forms.RadioButton();
            this.tabPageInposition = new System.Windows.Forms.TabPage();
            this.pnlPageInposition = new System.Windows.Forms.Panel();
            this.pnlInposition = new System.Windows.Forms.Panel();
            this.lblInposition = new System.Windows.Forms.Label();
            this.lblInpositionNow = new System.Windows.Forms.Label();
            this.lblEncderPulse = new System.Windows.Forms.Label();
            this.ctlNumInposition = new Motion_Designer.CtlNumericInputInt();
            this.lblEncder = new System.Windows.Forms.Label();
            this.tabPageTargetTime = new System.Windows.Forms.TabPage();
            this.pnlPageTargetTime = new System.Windows.Forms.Panel();
            this.pnlTargetTime = new System.Windows.Forms.Panel();
            this.lblTargetTime = new System.Windows.Forms.Label();
            this.lblTargetTimeNow = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ctlNumTargetTime = new Motion_Designer.CtlNumericInputInt();
            this.tabPageProfileVel = new System.Windows.Forms.TabPage();
            this.pnlPageProfileVel = new System.Windows.Forms.Panel();
            this.lblDccTime = new System.Windows.Forms.Label();
            this.lblAccTime = new System.Windows.Forms.Label();
            this.pnlProfileVelocity = new System.Windows.Forms.Panel();
            this.lblProfileVelocity2 = new System.Windows.Forms.Label();
            this.lblProfileVelocity = new System.Windows.Forms.Label();
            this.ctlNumWaitTime = new Motion_Designer.CtlNumericInputInt();
            this.lblVelAccDcc = new System.Windows.Forms.Label();
            this.ctlNumTargetAcceleration = new Motion_Designer.CtlNumericInputInt();
            this.ctlNumTargetVelocity = new Motion_Designer.CtlNumericInputInt();
            this.ctlNumTargetDeceleration = new Motion_Designer.CtlNumericInputInt();
            this.lblWait = new System.Windows.Forms.Label();
            this.tabPageProfilePos = new System.Windows.Forms.TabPage();
            this.ctlNumTargetPosition = new Motion_Designer.CtlNumericInputInt();
            this.ctlNumStartPosition = new Motion_Designer.CtlNumericInputInt();
            this.btnTeaching = new System.Windows.Forms.Button();
            this.lblProfileSet2 = new System.Windows.Forms.Label();
            this.lblProfileSet = new System.Windows.Forms.Label();
            this.pnlTuningPosition = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTuningPosition = new System.Windows.Forms.Label();
            this.tabPageFriction = new System.Windows.Forms.TabPage();
            this.pnlPageFriction = new System.Windows.Forms.Panel();
            this.pnlFriction = new System.Windows.Forms.Panel();
            this.lblFriction = new System.Windows.Forms.Label();
            this.lblFrictionExclamation5 = new System.Windows.Forms.Label();
            this.lblFrictionCwNow = new System.Windows.Forms.Label();
            this.lblFrictionExclamation4 = new System.Windows.Forms.Label();
            this.lblFrictionCcwNow = new System.Windows.Forms.Label();
            this.lblFrictionExclamation3 = new System.Windows.Forms.Label();
            this.btnFriction = new System.Windows.Forms.Button();
            this.lblFrictionExclamation2 = new System.Windows.Forms.Label();
            this.lblFrictionExclamation = new System.Windows.Forms.Label();
            this.tabPageEnd = new System.Windows.Forms.TabPage();
            this.pnlPageEnd = new System.Windows.Forms.Panel();
            this.rtxtWizard = new System.Windows.Forms.RichTextBox();
            this.pnlTuningSettingEnd = new System.Windows.Forms.Panel();
            this.lblTuningSettingEnd = new System.Windows.Forms.Label();
            this.toolStripWizard = new System.Windows.Forms.ToolStrip();
            this.btnCloseWizard = new System.Windows.Forms.ToolStripButton();
            this.btnAutoTuningStart = new System.Windows.Forms.ToolStripButton();
            this.TimerWizard = new System.Windows.Forms.Timer(this.components);
            this.TimerLoad = new System.Windows.Forms.Timer(this.components);
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnLoadTuningStop = new System.Windows.Forms.Button();
            this.TimerFriction = new System.Windows.Forms.Timer(this.components);
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.tabWizard.SuspendLayout();
            this.tabPageLoad.SuspendLayout();
            this.pnlPageLoad.SuspendLayout();
            this.pnlLoad.SuspendLayout();
            this.tabPageMachine.SuspendLayout();
            this.pnlPageMachine.SuspendLayout();
            this.pnlMachine.SuspendLayout();
            this.tabPageStrength.SuspendLayout();
            this.pnlPageStrength.SuspendLayout();
            this.pnlStrength.SuspendLayout();
            this.tabPageMode.SuspendLayout();
            this.pnlPageMode.SuspendLayout();
            this.pnlMode.SuspendLayout();
            this.tabPageVelObs.SuspendLayout();
            this.pnlPageVelObs.SuspendLayout();
            this.pnlVelObs.SuspendLayout();
            this.tabPageTurbo.SuspendLayout();
            this.pnlPageTurbo.SuspendLayout();
            this.pnlTurbo.SuspendLayout();
            this.tabPageInposition.SuspendLayout();
            this.pnlPageInposition.SuspendLayout();
            this.pnlInposition.SuspendLayout();
            this.tabPageTargetTime.SuspendLayout();
            this.pnlPageTargetTime.SuspendLayout();
            this.pnlTargetTime.SuspendLayout();
            this.tabPageProfileVel.SuspendLayout();
            this.pnlPageProfileVel.SuspendLayout();
            this.pnlProfileVelocity.SuspendLayout();
            this.tabPageProfilePos.SuspendLayout();
            this.pnlTuningPosition.SuspendLayout();
            this.tabPageFriction.SuspendLayout();
            this.pnlPageFriction.SuspendLayout();
            this.pnlFriction.SuspendLayout();
            this.tabPageEnd.SuspendLayout();
            this.pnlPageEnd.SuspendLayout();
            this.pnlTuningSettingEnd.SuspendLayout();
            this.toolStripWizard.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabWizard
            // 
            this.tabWizard.Controls.Add(this.tabPageLoad);
            this.tabWizard.Controls.Add(this.tabPageMachine);
            this.tabWizard.Controls.Add(this.tabPageStrength);
            this.tabWizard.Controls.Add(this.tabPageMode);
            this.tabWizard.Controls.Add(this.tabPageVelObs);
            this.tabWizard.Controls.Add(this.tabPageTurbo);
            this.tabWizard.Controls.Add(this.tabPageInposition);
            this.tabWizard.Controls.Add(this.tabPageTargetTime);
            this.tabWizard.Controls.Add(this.tabPageProfileVel);
            this.tabWizard.Controls.Add(this.tabPageProfilePos);
            this.tabWizard.Controls.Add(this.tabPageFriction);
            this.tabWizard.Controls.Add(this.tabPageEnd);
            resources.ApplyResources(this.tabWizard, "tabWizard");
            this.tabWizard.Name = "tabWizard";
            this.tabWizard.SelectedIndex = 0;
            this.tabWizard.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabWizard.Click += new System.EventHandler(this.TabPage_Click);
            this.tabWizard.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabWizard_DrawItem);
            this.tabWizard.SelectedIndexChanged += new System.EventHandler(this.tabWizard_SelectedIndexChanged);
            // 
            // tabPageLoad
            // 
            this.tabPageLoad.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPageLoad.Controls.Add(this.pnlPageLoad);
            resources.ApplyResources(this.tabPageLoad, "tabPageLoad");
            this.tabPageLoad.Name = "tabPageLoad";
            this.tabPageLoad.Tag = "Load";
            this.tabPageLoad.UseVisualStyleBackColor = true;
            this.tabPageLoad.Click += new System.EventHandler(this.TabPage_Click);
            // 
            // pnlPageLoad
            // 
            this.pnlPageLoad.Controls.Add(this.lblLoadSet);
            this.pnlPageLoad.Controls.Add(this.pnlLoad);
            this.pnlPageLoad.Controls.Add(this.ctlNumLoad);
            this.pnlPageLoad.Controls.Add(this.lblLoadExclamation);
            this.pnlPageLoad.Controls.Add(this.lblLoadNow);
            this.pnlPageLoad.Controls.Add(this.lblDmy);
            this.pnlPageLoad.Controls.Add(this.lblLoadAdjust);
            this.pnlPageLoad.Controls.Add(this.lblLoadExclamation2);
            this.pnlPageLoad.Controls.Add(this.btnLoadTuning);
            this.pnlPageLoad.Controls.Add(this.lblLoadAdjust2);
            this.pnlPageLoad.Controls.Add(this.lblLoadSet2);
            this.pnlPageLoad.Controls.Add(this.lblUnit);
            resources.ApplyResources(this.pnlPageLoad, "pnlPageLoad");
            this.pnlPageLoad.Name = "pnlPageLoad";
            this.pnlPageLoad.Tag = "Load";
            // 
            // lblLoadSet
            // 
            resources.ApplyResources(this.lblLoadSet, "lblLoadSet");
            this.lblLoadSet.Name = "lblLoadSet";
            // 
            // pnlLoad
            // 
            this.pnlLoad.BackColor = System.Drawing.Color.PeachPuff;
            this.pnlLoad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLoad.Controls.Add(this.lblLoad);
            resources.ApplyResources(this.pnlLoad, "pnlLoad");
            this.pnlLoad.Name = "pnlLoad";
            // 
            // lblLoad
            // 
            resources.ApplyResources(this.lblLoad, "lblLoad");
            this.lblLoad.Name = "lblLoad";
            // 
            // ctlNumLoad
            // 
            this.ctlNumLoad.BackColor = System.Drawing.Color.Transparent;
            this.ctlNumLoad.DataId = 0;
            this.ctlNumLoad.DigiSwVisible = true;
            resources.ApplyResources(this.ctlNumLoad, "ctlNumLoad");
            this.ctlNumLoad.IntValue = 0;
            this.ctlNumLoad.MaxData = 999999;
            this.ctlNumLoad.MinData = 0;
            this.ctlNumLoad.Name = "ctlNumLoad";
            this.ctlNumLoad.NumBackColor = System.Drawing.Color.White;
            this.ctlNumLoad.NumFont = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ctlNumLoad.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumLoad.PlaceNumber = 6;
            this.ctlNumLoad.SignedVisible = false;
            this.ctlNumLoad.SingedEnable = false;
            this.ctlNumLoad.StringValue = "+0";
            this.ctlNumLoad.Tag = "";
            this.ctlNumLoad.TitleAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumLoad.TitleBackColor = System.Drawing.Color.Transparent;
            this.ctlNumLoad.TitleDock = System.Windows.Forms.DockStyle.Top;
            this.ctlNumLoad.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumLoad.TitleHeight = 20;
            this.ctlNumLoad.TitleVisible = true;
            this.ctlNumLoad.UnitAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumLoad.UnitBackColor = System.Drawing.Color.Transparent;
            this.ctlNumLoad.UnitDock = System.Windows.Forms.DockStyle.Bottom;
            this.ctlNumLoad.UnitFont = new System.Drawing.Font("メイリオ", 8.25F);
            this.ctlNumLoad.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumLoad.UnitHeight = 20;
            this.ctlNumLoad.UnitVisible = true;
            // 
            // lblLoadExclamation
            // 
            resources.ApplyResources(this.lblLoadExclamation, "lblLoadExclamation");
            this.lblLoadExclamation.ForeColor = System.Drawing.Color.Crimson;
            this.lblLoadExclamation.Name = "lblLoadExclamation";
            // 
            // lblLoadNow
            // 
            resources.ApplyResources(this.lblLoadNow, "lblLoadNow");
            this.lblLoadNow.Name = "lblLoadNow";
            // 
            // lblDmy
            // 
            resources.ApplyResources(this.lblDmy, "lblDmy");
            this.lblDmy.Name = "lblDmy";
            // 
            // lblLoadAdjust
            // 
            resources.ApplyResources(this.lblLoadAdjust, "lblLoadAdjust");
            this.lblLoadAdjust.Name = "lblLoadAdjust";
            // 
            // lblLoadExclamation2
            // 
            resources.ApplyResources(this.lblLoadExclamation2, "lblLoadExclamation2");
            this.lblLoadExclamation2.ForeColor = System.Drawing.Color.Crimson;
            this.lblLoadExclamation2.Name = "lblLoadExclamation2";
            // 
            // btnLoadTuning
            // 
            resources.ApplyResources(this.btnLoadTuning, "btnLoadTuning");
            this.btnLoadTuning.Name = "btnLoadTuning";
            this.btnLoadTuning.UseVisualStyleBackColor = true;
            this.btnLoadTuning.Click += new System.EventHandler(this.btnLoadTuning_Click);
            // 
            // lblLoadAdjust2
            // 
            resources.ApplyResources(this.lblLoadAdjust2, "lblLoadAdjust2");
            this.lblLoadAdjust2.Name = "lblLoadAdjust2";
            // 
            // lblLoadSet2
            // 
            resources.ApplyResources(this.lblLoadSet2, "lblLoadSet2");
            this.lblLoadSet2.Name = "lblLoadSet2";
            // 
            // lblUnit
            // 
            resources.ApplyResources(this.lblUnit, "lblUnit");
            this.lblUnit.Name = "lblUnit";
            // 
            // tabPageMachine
            // 
            this.tabPageMachine.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPageMachine.Controls.Add(this.pnlPageMachine);
            resources.ApplyResources(this.tabPageMachine, "tabPageMachine");
            this.tabPageMachine.Name = "tabPageMachine";
            this.tabPageMachine.Tag = "Machine";
            this.tabPageMachine.UseVisualStyleBackColor = true;
            this.tabPageMachine.Click += new System.EventHandler(this.TabPage_Click);
            // 
            // pnlPageMachine
            // 
            this.pnlPageMachine.Controls.Add(this.pnlMachine);
            this.pnlPageMachine.Controls.Add(this.rdoBelt);
            this.pnlPageMachine.Controls.Add(this.rdoDisk);
            this.pnlPageMachine.Controls.Add(this.rdoScrew);
            resources.ApplyResources(this.pnlPageMachine, "pnlPageMachine");
            this.pnlPageMachine.Name = "pnlPageMachine";
            // 
            // pnlMachine
            // 
            this.pnlMachine.BackColor = System.Drawing.Color.PaleGreen;
            this.pnlMachine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMachine.Controls.Add(this.lblMachine);
            resources.ApplyResources(this.pnlMachine, "pnlMachine");
            this.pnlMachine.Name = "pnlMachine";
            // 
            // lblMachine
            // 
            resources.ApplyResources(this.lblMachine, "lblMachine");
            this.lblMachine.Name = "lblMachine";
            // 
            // rdoBelt
            // 
            resources.ApplyResources(this.rdoBelt, "rdoBelt");
            this.rdoBelt.Name = "rdoBelt";
            this.rdoBelt.UseVisualStyleBackColor = true;
            this.rdoBelt.CheckedChanged += new System.EventHandler(this.rdoMachineType_CheckedChanged);
            // 
            // rdoDisk
            // 
            resources.ApplyResources(this.rdoDisk, "rdoDisk");
            this.rdoDisk.Checked = true;
            this.rdoDisk.ForeColor = System.Drawing.Color.Black;
            this.rdoDisk.Name = "rdoDisk";
            this.rdoDisk.TabStop = true;
            this.rdoDisk.UseVisualStyleBackColor = true;
            this.rdoDisk.CheckedChanged += new System.EventHandler(this.rdoMachineType_CheckedChanged);
            // 
            // rdoScrew
            // 
            resources.ApplyResources(this.rdoScrew, "rdoScrew");
            this.rdoScrew.Name = "rdoScrew";
            this.rdoScrew.UseVisualStyleBackColor = true;
            this.rdoScrew.CheckedChanged += new System.EventHandler(this.rdoMachineType_CheckedChanged);
            // 
            // tabPageStrength
            // 
            this.tabPageStrength.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPageStrength.Controls.Add(this.pnlPageStrength);
            resources.ApplyResources(this.tabPageStrength, "tabPageStrength");
            this.tabPageStrength.Name = "tabPageStrength";
            this.tabPageStrength.Tag = "Strength";
            this.tabPageStrength.UseVisualStyleBackColor = true;
            // 
            // pnlPageStrength
            // 
            this.pnlPageStrength.Controls.Add(this.pnlStrength);
            this.pnlPageStrength.Controls.Add(this.rdoStrong);
            this.pnlPageStrength.Controls.Add(this.rdoLight);
            this.pnlPageStrength.Controls.Add(this.rdoMidlle);
            resources.ApplyResources(this.pnlPageStrength, "pnlPageStrength");
            this.pnlPageStrength.Name = "pnlPageStrength";
            this.pnlPageStrength.Tag = "Strength";
            // 
            // pnlStrength
            // 
            this.pnlStrength.BackColor = System.Drawing.Color.PaleGreen;
            this.pnlStrength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStrength.Controls.Add(this.lblStrength);
            resources.ApplyResources(this.pnlStrength, "pnlStrength");
            this.pnlStrength.Name = "pnlStrength";
            // 
            // lblStrength
            // 
            resources.ApplyResources(this.lblStrength, "lblStrength");
            this.lblStrength.Name = "lblStrength";
            // 
            // rdoStrong
            // 
            resources.ApplyResources(this.rdoStrong, "rdoStrong");
            this.rdoStrong.Name = "rdoStrong";
            this.rdoStrong.UseVisualStyleBackColor = true;
            this.rdoStrong.CheckedChanged += new System.EventHandler(this.rdoTuningStrength_CheckedChanged);
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
            // rdoMidlle
            // 
            resources.ApplyResources(this.rdoMidlle, "rdoMidlle");
            this.rdoMidlle.Name = "rdoMidlle";
            this.rdoMidlle.UseVisualStyleBackColor = true;
            this.rdoMidlle.CheckedChanged += new System.EventHandler(this.rdoTuningStrength_CheckedChanged);
            // 
            // tabPageMode
            // 
            this.tabPageMode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPageMode.Controls.Add(this.pnlPageMode);
            resources.ApplyResources(this.tabPageMode, "tabPageMode");
            this.tabPageMode.Name = "tabPageMode";
            this.tabPageMode.Tag = "Mode";
            this.tabPageMode.UseVisualStyleBackColor = true;
            this.tabPageMode.Click += new System.EventHandler(this.TabPage_Click);
            // 
            // pnlPageMode
            // 
            this.pnlPageMode.Controls.Add(this.pnlMode);
            this.pnlPageMode.Controls.Add(this.rdoStiffnessPriorty);
            this.pnlPageMode.Controls.Add(this.rdoNormalPriorty);
            this.pnlPageMode.Controls.Add(this.rdoPositionPriorty);
            resources.ApplyResources(this.pnlPageMode, "pnlPageMode");
            this.pnlPageMode.Name = "pnlPageMode";
            this.pnlPageMode.Tag = "Mode";
            // 
            // pnlMode
            // 
            this.pnlMode.BackColor = System.Drawing.Color.PaleGreen;
            this.pnlMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMode.Controls.Add(this.lblMode);
            resources.ApplyResources(this.pnlMode, "pnlMode");
            this.pnlMode.Name = "pnlMode";
            // 
            // lblMode
            // 
            resources.ApplyResources(this.lblMode, "lblMode");
            this.lblMode.Name = "lblMode";
            // 
            // rdoStiffnessPriorty
            // 
            resources.ApplyResources(this.rdoStiffnessPriorty, "rdoStiffnessPriorty");
            this.rdoStiffnessPriorty.Name = "rdoStiffnessPriorty";
            this.rdoStiffnessPriorty.UseVisualStyleBackColor = true;
            this.rdoStiffnessPriorty.CheckedChanged += new System.EventHandler(this.rdoTuningMode_CheckedChanged);
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
            // rdoPositionPriorty
            // 
            resources.ApplyResources(this.rdoPositionPriorty, "rdoPositionPriorty");
            this.rdoPositionPriorty.Name = "rdoPositionPriorty";
            this.rdoPositionPriorty.UseVisualStyleBackColor = true;
            this.rdoPositionPriorty.CheckedChanged += new System.EventHandler(this.rdoTuningMode_CheckedChanged);
            // 
            // tabPageVelObs
            // 
            this.tabPageVelObs.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPageVelObs.Controls.Add(this.pnlPageVelObs);
            resources.ApplyResources(this.tabPageVelObs, "tabPageVelObs");
            this.tabPageVelObs.Name = "tabPageVelObs";
            this.tabPageVelObs.Tag = "vELOBS";
            this.tabPageVelObs.UseVisualStyleBackColor = true;
            // 
            // pnlPageVelObs
            // 
            this.pnlPageVelObs.Controls.Add(this.lblVelObsExclamation3);
            this.pnlPageVelObs.Controls.Add(this.lblVelObsExclamation1);
            this.pnlPageVelObs.Controls.Add(this.lblVelObsExclamation2);
            this.pnlPageVelObs.Controls.Add(this.pnlVelObs);
            this.pnlPageVelObs.Controls.Add(this.rdoVelObsDisable);
            this.pnlPageVelObs.Controls.Add(this.rdoVelObsEnable);
            resources.ApplyResources(this.pnlPageVelObs, "pnlPageVelObs");
            this.pnlPageVelObs.Name = "pnlPageVelObs";
            this.pnlPageVelObs.Tag = "vELOBS";
            // 
            // lblVelObsExclamation3
            // 
            resources.ApplyResources(this.lblVelObsExclamation3, "lblVelObsExclamation3");
            this.lblVelObsExclamation3.ForeColor = System.Drawing.Color.Crimson;
            this.lblVelObsExclamation3.Name = "lblVelObsExclamation3";
            // 
            // lblVelObsExclamation1
            // 
            resources.ApplyResources(this.lblVelObsExclamation1, "lblVelObsExclamation1");
            this.lblVelObsExclamation1.ForeColor = System.Drawing.Color.Crimson;
            this.lblVelObsExclamation1.Name = "lblVelObsExclamation1";
            // 
            // lblVelObsExclamation2
            // 
            resources.ApplyResources(this.lblVelObsExclamation2, "lblVelObsExclamation2");
            this.lblVelObsExclamation2.ForeColor = System.Drawing.Color.Crimson;
            this.lblVelObsExclamation2.Name = "lblVelObsExclamation2";
            // 
            // pnlVelObs
            // 
            this.pnlVelObs.BackColor = System.Drawing.Color.PaleGreen;
            this.pnlVelObs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlVelObs.Controls.Add(this.lblVelObs);
            resources.ApplyResources(this.pnlVelObs, "pnlVelObs");
            this.pnlVelObs.Name = "pnlVelObs";
            // 
            // lblVelObs
            // 
            resources.ApplyResources(this.lblVelObs, "lblVelObs");
            this.lblVelObs.Name = "lblVelObs";
            // 
            // rdoVelObsDisable
            // 
            resources.ApplyResources(this.rdoVelObsDisable, "rdoVelObsDisable");
            this.rdoVelObsDisable.Name = "rdoVelObsDisable";
            this.rdoVelObsDisable.UseVisualStyleBackColor = true;
            // 
            // rdoVelObsEnable
            // 
            resources.ApplyResources(this.rdoVelObsEnable, "rdoVelObsEnable");
            this.rdoVelObsEnable.Checked = true;
            this.rdoVelObsEnable.ForeColor = System.Drawing.Color.Black;
            this.rdoVelObsEnable.Name = "rdoVelObsEnable";
            this.rdoVelObsEnable.TabStop = true;
            this.rdoVelObsEnable.UseVisualStyleBackColor = true;
            this.rdoVelObsEnable.CheckedChanged += new System.EventHandler(this.rdoVelObsEnable_CheckedChanged);
            // 
            // tabPageTurbo
            // 
            this.tabPageTurbo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPageTurbo.Controls.Add(this.pnlPageTurbo);
            resources.ApplyResources(this.tabPageTurbo, "tabPageTurbo");
            this.tabPageTurbo.Name = "tabPageTurbo";
            this.tabPageTurbo.Tag = "Turbo";
            this.tabPageTurbo.UseVisualStyleBackColor = true;
            // 
            // pnlPageTurbo
            // 
            this.pnlPageTurbo.Controls.Add(this.pnlTurbo);
            this.pnlPageTurbo.Controls.Add(this.lblTurboExclamation2);
            this.pnlPageTurbo.Controls.Add(this.rdoTurboEnable);
            this.pnlPageTurbo.Controls.Add(this.lblTurboExclamation);
            this.pnlPageTurbo.Controls.Add(this.rdoTurboDisable);
            resources.ApplyResources(this.pnlPageTurbo, "pnlPageTurbo");
            this.pnlPageTurbo.Name = "pnlPageTurbo";
            this.pnlPageTurbo.Tag = "Turbo";
            // 
            // pnlTurbo
            // 
            this.pnlTurbo.BackColor = System.Drawing.Color.PaleGreen;
            this.pnlTurbo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTurbo.Controls.Add(this.lblTurbo);
            resources.ApplyResources(this.pnlTurbo, "pnlTurbo");
            this.pnlTurbo.Name = "pnlTurbo";
            // 
            // lblTurbo
            // 
            resources.ApplyResources(this.lblTurbo, "lblTurbo");
            this.lblTurbo.Name = "lblTurbo";
            // 
            // lblTurboExclamation2
            // 
            resources.ApplyResources(this.lblTurboExclamation2, "lblTurboExclamation2");
            this.lblTurboExclamation2.ForeColor = System.Drawing.Color.Crimson;
            this.lblTurboExclamation2.Name = "lblTurboExclamation2";
            // 
            // rdoTurboEnable
            // 
            resources.ApplyResources(this.rdoTurboEnable, "rdoTurboEnable");
            this.rdoTurboEnable.Checked = true;
            this.rdoTurboEnable.ForeColor = System.Drawing.Color.Black;
            this.rdoTurboEnable.Name = "rdoTurboEnable";
            this.rdoTurboEnable.TabStop = true;
            this.rdoTurboEnable.UseVisualStyleBackColor = true;
            this.rdoTurboEnable.CheckedChanged += new System.EventHandler(this.rdoTurboEnable_CheckedChanged);
            // 
            // lblTurboExclamation
            // 
            resources.ApplyResources(this.lblTurboExclamation, "lblTurboExclamation");
            this.lblTurboExclamation.ForeColor = System.Drawing.Color.Crimson;
            this.lblTurboExclamation.Name = "lblTurboExclamation";
            // 
            // rdoTurboDisable
            // 
            resources.ApplyResources(this.rdoTurboDisable, "rdoTurboDisable");
            this.rdoTurboDisable.Name = "rdoTurboDisable";
            this.rdoTurboDisable.UseVisualStyleBackColor = true;
            this.rdoTurboDisable.CheckedChanged += new System.EventHandler(this.rdoTurboEnable_CheckedChanged);
            // 
            // tabPageInposition
            // 
            this.tabPageInposition.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPageInposition.Controls.Add(this.pnlPageInposition);
            resources.ApplyResources(this.tabPageInposition, "tabPageInposition");
            this.tabPageInposition.Name = "tabPageInposition";
            this.tabPageInposition.Tag = "Inposition";
            this.tabPageInposition.UseVisualStyleBackColor = true;
            this.tabPageInposition.Click += new System.EventHandler(this.TabPage_Click);
            // 
            // pnlPageInposition
            // 
            this.pnlPageInposition.Controls.Add(this.pnlInposition);
            this.pnlPageInposition.Controls.Add(this.lblInpositionNow);
            this.pnlPageInposition.Controls.Add(this.lblEncderPulse);
            this.pnlPageInposition.Controls.Add(this.ctlNumInposition);
            this.pnlPageInposition.Controls.Add(this.lblEncder);
            resources.ApplyResources(this.pnlPageInposition, "pnlPageInposition");
            this.pnlPageInposition.Name = "pnlPageInposition";
            this.pnlPageInposition.Tag = "Inposition";
            // 
            // pnlInposition
            // 
            this.pnlInposition.BackColor = System.Drawing.Color.PaleGreen;
            this.pnlInposition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInposition.Controls.Add(this.lblInposition);
            resources.ApplyResources(this.pnlInposition, "pnlInposition");
            this.pnlInposition.Name = "pnlInposition";
            // 
            // lblInposition
            // 
            resources.ApplyResources(this.lblInposition, "lblInposition");
            this.lblInposition.Name = "lblInposition";
            // 
            // lblInpositionNow
            // 
            resources.ApplyResources(this.lblInpositionNow, "lblInpositionNow");
            this.lblInpositionNow.Name = "lblInpositionNow";
            // 
            // lblEncderPulse
            // 
            resources.ApplyResources(this.lblEncderPulse, "lblEncderPulse");
            this.lblEncderPulse.Name = "lblEncderPulse";
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
            this.ctlNumInposition.Tag = "";
            this.ctlNumInposition.TitleAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumInposition.TitleBackColor = System.Drawing.Color.Transparent;
            this.ctlNumInposition.TitleDock = System.Windows.Forms.DockStyle.Top;
            this.ctlNumInposition.TitleForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumInposition.TitleHeight = 20;
            this.ctlNumInposition.TitleVisible = true;
            this.ctlNumInposition.UnitAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumInposition.UnitBackColor = System.Drawing.Color.Transparent;
            this.ctlNumInposition.UnitDock = System.Windows.Forms.DockStyle.Bottom;
            this.ctlNumInposition.UnitFont = new System.Drawing.Font("メイリオ", 8.25F);
            this.ctlNumInposition.UnitForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumInposition.UnitHeight = 20;
            this.ctlNumInposition.UnitVisible = true;
            // 
            // lblEncder
            // 
            resources.ApplyResources(this.lblEncder, "lblEncder");
            this.lblEncder.Name = "lblEncder";
            // 
            // tabPageTargetTime
            // 
            this.tabPageTargetTime.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPageTargetTime.Controls.Add(this.pnlPageTargetTime);
            resources.ApplyResources(this.tabPageTargetTime, "tabPageTargetTime");
            this.tabPageTargetTime.Name = "tabPageTargetTime";
            this.tabPageTargetTime.Tag = "TargetTime";
            this.tabPageTargetTime.UseVisualStyleBackColor = true;
            this.tabPageTargetTime.Click += new System.EventHandler(this.TabPage_Click);
            // 
            // pnlPageTargetTime
            // 
            this.pnlPageTargetTime.Controls.Add(this.pnlTargetTime);
            this.pnlPageTargetTime.Controls.Add(this.lblTargetTimeNow);
            this.pnlPageTargetTime.Controls.Add(this.label1);
            this.pnlPageTargetTime.Controls.Add(this.ctlNumTargetTime);
            resources.ApplyResources(this.pnlPageTargetTime, "pnlPageTargetTime");
            this.pnlPageTargetTime.Name = "pnlPageTargetTime";
            this.pnlPageTargetTime.Tag = "TargetTime";
            // 
            // pnlTargetTime
            // 
            this.pnlTargetTime.BackColor = System.Drawing.Color.PaleGreen;
            this.pnlTargetTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTargetTime.Controls.Add(this.lblTargetTime);
            resources.ApplyResources(this.pnlTargetTime, "pnlTargetTime");
            this.pnlTargetTime.Name = "pnlTargetTime";
            // 
            // lblTargetTime
            // 
            resources.ApplyResources(this.lblTargetTime, "lblTargetTime");
            this.lblTargetTime.Name = "lblTargetTime";
            // 
            // lblTargetTimeNow
            // 
            resources.ApplyResources(this.lblTargetTimeNow, "lblTargetTimeNow");
            this.lblTargetTimeNow.Name = "lblTargetTimeNow";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Name = "label1";
            // 
            // ctlNumTargetTime
            // 
            this.ctlNumTargetTime.DataId = 0;
            this.ctlNumTargetTime.DigiSwVisible = true;
            resources.ApplyResources(this.ctlNumTargetTime, "ctlNumTargetTime");
            this.ctlNumTargetTime.IntValue = 0;
            this.ctlNumTargetTime.MaxData = 999;
            this.ctlNumTargetTime.MinData = -999;
            this.ctlNumTargetTime.Name = "ctlNumTargetTime";
            this.ctlNumTargetTime.NumBackColor = System.Drawing.Color.White;
            this.ctlNumTargetTime.NumFont = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ctlNumTargetTime.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumTargetTime.PlaceNumber = 3;
            this.ctlNumTargetTime.SignedVisible = true;
            this.ctlNumTargetTime.SingedEnable = true;
            this.ctlNumTargetTime.StringValue = "+0";
            this.ctlNumTargetTime.Tag = "";
            this.ctlNumTargetTime.TitleAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumTargetTime.TitleBackColor = System.Drawing.Color.Transparent;
            this.ctlNumTargetTime.TitleDock = System.Windows.Forms.DockStyle.Top;
            this.ctlNumTargetTime.TitleForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumTargetTime.TitleHeight = 20;
            this.ctlNumTargetTime.TitleVisible = true;
            this.ctlNumTargetTime.UnitAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumTargetTime.UnitBackColor = System.Drawing.Color.Transparent;
            this.ctlNumTargetTime.UnitDock = System.Windows.Forms.DockStyle.Bottom;
            this.ctlNumTargetTime.UnitFont = new System.Drawing.Font("メイリオ", 8.25F);
            this.ctlNumTargetTime.UnitForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumTargetTime.UnitHeight = 20;
            this.ctlNumTargetTime.UnitVisible = true;
            // 
            // tabPageProfileVel
            // 
            resources.ApplyResources(this.tabPageProfileVel, "tabPageProfileVel");
            this.tabPageProfileVel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPageProfileVel.Controls.Add(this.pnlPageProfileVel);
            this.tabPageProfileVel.Name = "tabPageProfileVel";
            this.tabPageProfileVel.Tag = "ProfileVel";
            this.tabPageProfileVel.UseVisualStyleBackColor = true;
            this.tabPageProfileVel.Click += new System.EventHandler(this.TabPage_Click);
            // 
            // pnlPageProfileVel
            // 
            this.pnlPageProfileVel.Controls.Add(this.lblDccTime);
            this.pnlPageProfileVel.Controls.Add(this.lblAccTime);
            this.pnlPageProfileVel.Controls.Add(this.pnlProfileVelocity);
            this.pnlPageProfileVel.Controls.Add(this.ctlNumWaitTime);
            this.pnlPageProfileVel.Controls.Add(this.lblVelAccDcc);
            this.pnlPageProfileVel.Controls.Add(this.ctlNumTargetAcceleration);
            this.pnlPageProfileVel.Controls.Add(this.ctlNumTargetVelocity);
            this.pnlPageProfileVel.Controls.Add(this.ctlNumTargetDeceleration);
            this.pnlPageProfileVel.Controls.Add(this.lblWait);
            resources.ApplyResources(this.pnlPageProfileVel, "pnlPageProfileVel");
            this.pnlPageProfileVel.Name = "pnlPageProfileVel";
            this.pnlPageProfileVel.Tag = "ProfileVel";
            // 
            // lblDccTime
            // 
            resources.ApplyResources(this.lblDccTime, "lblDccTime");
            this.lblDccTime.Name = "lblDccTime";
            // 
            // lblAccTime
            // 
            resources.ApplyResources(this.lblAccTime, "lblAccTime");
            this.lblAccTime.Name = "lblAccTime";
            // 
            // pnlProfileVelocity
            // 
            this.pnlProfileVelocity.BackColor = System.Drawing.Color.PaleGreen;
            this.pnlProfileVelocity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProfileVelocity.Controls.Add(this.lblProfileVelocity2);
            this.pnlProfileVelocity.Controls.Add(this.lblProfileVelocity);
            resources.ApplyResources(this.pnlProfileVelocity, "pnlProfileVelocity");
            this.pnlProfileVelocity.Name = "pnlProfileVelocity";
            // 
            // lblProfileVelocity2
            // 
            resources.ApplyResources(this.lblProfileVelocity2, "lblProfileVelocity2");
            this.lblProfileVelocity2.Name = "lblProfileVelocity2";
            // 
            // lblProfileVelocity
            // 
            resources.ApplyResources(this.lblProfileVelocity, "lblProfileVelocity");
            this.lblProfileVelocity.Name = "lblProfileVelocity";
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
            this.ctlNumWaitTime.TitleBackColor = System.Drawing.Color.Transparent;
            this.ctlNumWaitTime.TitleDock = System.Windows.Forms.DockStyle.Top;
            this.ctlNumWaitTime.TitleForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumWaitTime.TitleHeight = 20;
            this.ctlNumWaitTime.TitleVisible = true;
            this.ctlNumWaitTime.UnitAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumWaitTime.UnitBackColor = System.Drawing.Color.Transparent;
            this.ctlNumWaitTime.UnitDock = System.Windows.Forms.DockStyle.Bottom;
            this.ctlNumWaitTime.UnitFont = new System.Drawing.Font("メイリオ", 8.25F);
            this.ctlNumWaitTime.UnitForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumWaitTime.UnitHeight = 20;
            this.ctlNumWaitTime.UnitVisible = true;
            // 
            // lblVelAccDcc
            // 
            resources.ApplyResources(this.lblVelAccDcc, "lblVelAccDcc");
            this.lblVelAccDcc.Name = "lblVelAccDcc";
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
            this.ctlNumTargetAcceleration.TitleBackColor = System.Drawing.Color.Transparent;
            this.ctlNumTargetAcceleration.TitleDock = System.Windows.Forms.DockStyle.Top;
            this.ctlNumTargetAcceleration.TitleForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumTargetAcceleration.TitleHeight = 20;
            this.ctlNumTargetAcceleration.TitleVisible = true;
            this.ctlNumTargetAcceleration.UnitAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumTargetAcceleration.UnitBackColor = System.Drawing.Color.Transparent;
            this.ctlNumTargetAcceleration.UnitDock = System.Windows.Forms.DockStyle.Bottom;
            this.ctlNumTargetAcceleration.UnitFont = new System.Drawing.Font("メイリオ", 8.25F);
            this.ctlNumTargetAcceleration.UnitForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumTargetAcceleration.UnitHeight = 20;
            this.ctlNumTargetAcceleration.UnitVisible = true;
            // 
            // ctlNumTargetVelocity
            // 
            this.ctlNumTargetVelocity.DataId = 0;
            this.ctlNumTargetVelocity.DigiSwVisible = true;
            resources.ApplyResources(this.ctlNumTargetVelocity, "ctlNumTargetVelocity");
            this.ctlNumTargetVelocity.IntValue = 500;
            this.ctlNumTargetVelocity.MaxData = 9999;
            this.ctlNumTargetVelocity.MinData = 0;
            this.ctlNumTargetVelocity.Name = "ctlNumTargetVelocity";
            this.ctlNumTargetVelocity.NumBackColor = System.Drawing.Color.White;
            this.ctlNumTargetVelocity.NumFont = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ctlNumTargetVelocity.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumTargetVelocity.PlaceNumber = 4;
            this.ctlNumTargetVelocity.SignedVisible = false;
            this.ctlNumTargetVelocity.SingedEnable = true;
            this.ctlNumTargetVelocity.StringValue = "+500";
            this.ctlNumTargetVelocity.Tag = "";
            this.ctlNumTargetVelocity.TitleAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumTargetVelocity.TitleBackColor = System.Drawing.Color.Transparent;
            this.ctlNumTargetVelocity.TitleDock = System.Windows.Forms.DockStyle.Top;
            this.ctlNumTargetVelocity.TitleForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumTargetVelocity.TitleHeight = 20;
            this.ctlNumTargetVelocity.TitleVisible = true;
            this.ctlNumTargetVelocity.UnitAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumTargetVelocity.UnitBackColor = System.Drawing.Color.Transparent;
            this.ctlNumTargetVelocity.UnitDock = System.Windows.Forms.DockStyle.Bottom;
            this.ctlNumTargetVelocity.UnitFont = new System.Drawing.Font("メイリオ", 8.25F);
            this.ctlNumTargetVelocity.UnitForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumTargetVelocity.UnitHeight = 20;
            this.ctlNumTargetVelocity.UnitVisible = true;
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
            this.ctlNumTargetDeceleration.TitleBackColor = System.Drawing.Color.Transparent;
            this.ctlNumTargetDeceleration.TitleDock = System.Windows.Forms.DockStyle.Top;
            this.ctlNumTargetDeceleration.TitleForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumTargetDeceleration.TitleHeight = 20;
            this.ctlNumTargetDeceleration.TitleVisible = true;
            this.ctlNumTargetDeceleration.UnitAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumTargetDeceleration.UnitBackColor = System.Drawing.Color.Transparent;
            this.ctlNumTargetDeceleration.UnitDock = System.Windows.Forms.DockStyle.Bottom;
            this.ctlNumTargetDeceleration.UnitFont = new System.Drawing.Font("メイリオ", 8.25F);
            this.ctlNumTargetDeceleration.UnitForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumTargetDeceleration.UnitHeight = 20;
            this.ctlNumTargetDeceleration.UnitVisible = true;
            // 
            // lblWait
            // 
            resources.ApplyResources(this.lblWait, "lblWait");
            this.lblWait.Name = "lblWait";
            // 
            // tabPageProfilePos
            // 
            this.tabPageProfilePos.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageProfilePos.Controls.Add(this.ctlNumTargetPosition);
            this.tabPageProfilePos.Controls.Add(this.ctlNumStartPosition);
            this.tabPageProfilePos.Controls.Add(this.btnTeaching);
            this.tabPageProfilePos.Controls.Add(this.lblProfileSet2);
            this.tabPageProfilePos.Controls.Add(this.lblProfileSet);
            this.tabPageProfilePos.Controls.Add(this.pnlTuningPosition);
            resources.ApplyResources(this.tabPageProfilePos, "tabPageProfilePos");
            this.tabPageProfilePos.Name = "tabPageProfilePos";
            this.tabPageProfilePos.Tag = "ProfilePos";
            this.tabPageProfilePos.Click += new System.EventHandler(this.TabPage_Click);
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
            this.ctlNumTargetPosition.TitleBackColor = System.Drawing.Color.Transparent;
            this.ctlNumTargetPosition.TitleDock = System.Windows.Forms.DockStyle.Top;
            this.ctlNumTargetPosition.TitleForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumTargetPosition.TitleHeight = 20;
            this.ctlNumTargetPosition.TitleVisible = true;
            this.ctlNumTargetPosition.UnitAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumTargetPosition.UnitBackColor = System.Drawing.Color.Transparent;
            this.ctlNumTargetPosition.UnitDock = System.Windows.Forms.DockStyle.Bottom;
            this.ctlNumTargetPosition.UnitFont = new System.Drawing.Font("メイリオ", 8.25F);
            this.ctlNumTargetPosition.UnitForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumTargetPosition.UnitHeight = 20;
            this.ctlNumTargetPosition.UnitVisible = true;
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
            this.ctlNumStartPosition.TitleBackColor = System.Drawing.Color.Transparent;
            this.ctlNumStartPosition.TitleDock = System.Windows.Forms.DockStyle.Top;
            this.ctlNumStartPosition.TitleForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumStartPosition.TitleHeight = 20;
            this.ctlNumStartPosition.TitleVisible = true;
            this.ctlNumStartPosition.UnitAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ctlNumStartPosition.UnitBackColor = System.Drawing.Color.Transparent;
            this.ctlNumStartPosition.UnitDock = System.Windows.Forms.DockStyle.Bottom;
            this.ctlNumStartPosition.UnitFont = new System.Drawing.Font("メイリオ", 8.25F);
            this.ctlNumStartPosition.UnitForeColor = System.Drawing.Color.MediumBlue;
            this.ctlNumStartPosition.UnitHeight = 20;
            this.ctlNumStartPosition.UnitVisible = true;
            // 
            // btnTeaching
            // 
            resources.ApplyResources(this.btnTeaching, "btnTeaching");
            this.btnTeaching.Name = "btnTeaching";
            this.btnTeaching.UseVisualStyleBackColor = true;
            this.btnTeaching.Click += new System.EventHandler(this.btnTeaching_Click);
            // 
            // lblProfileSet2
            // 
            resources.ApplyResources(this.lblProfileSet2, "lblProfileSet2");
            this.lblProfileSet2.Name = "lblProfileSet2";
            // 
            // lblProfileSet
            // 
            resources.ApplyResources(this.lblProfileSet, "lblProfileSet");
            this.lblProfileSet.Name = "lblProfileSet";
            // 
            // pnlTuningPosition
            // 
            this.pnlTuningPosition.BackColor = System.Drawing.Color.PaleGreen;
            this.pnlTuningPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTuningPosition.Controls.Add(this.label2);
            this.pnlTuningPosition.Controls.Add(this.lblTuningPosition);
            resources.ApplyResources(this.pnlTuningPosition, "pnlTuningPosition");
            this.pnlTuningPosition.Name = "pnlTuningPosition";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lblTuningPosition
            // 
            resources.ApplyResources(this.lblTuningPosition, "lblTuningPosition");
            this.lblTuningPosition.Name = "lblTuningPosition";
            // 
            // tabPageFriction
            // 
            this.tabPageFriction.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPageFriction.Controls.Add(this.pnlPageFriction);
            resources.ApplyResources(this.tabPageFriction, "tabPageFriction");
            this.tabPageFriction.Name = "tabPageFriction";
            this.tabPageFriction.Tag = "Friction";
            this.tabPageFriction.UseVisualStyleBackColor = true;
            // 
            // pnlPageFriction
            // 
            this.pnlPageFriction.Controls.Add(this.pnlFriction);
            this.pnlPageFriction.Controls.Add(this.lblFrictionExclamation5);
            this.pnlPageFriction.Controls.Add(this.lblFrictionCwNow);
            this.pnlPageFriction.Controls.Add(this.lblFrictionExclamation4);
            this.pnlPageFriction.Controls.Add(this.lblFrictionCcwNow);
            this.pnlPageFriction.Controls.Add(this.lblFrictionExclamation3);
            this.pnlPageFriction.Controls.Add(this.btnFriction);
            this.pnlPageFriction.Controls.Add(this.lblFrictionExclamation2);
            this.pnlPageFriction.Controls.Add(this.lblFrictionExclamation);
            resources.ApplyResources(this.pnlPageFriction, "pnlPageFriction");
            this.pnlPageFriction.Name = "pnlPageFriction";
            this.pnlPageFriction.Tag = "Friction";
            // 
            // pnlFriction
            // 
            this.pnlFriction.BackColor = System.Drawing.Color.PeachPuff;
            this.pnlFriction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFriction.Controls.Add(this.lblFriction);
            resources.ApplyResources(this.pnlFriction, "pnlFriction");
            this.pnlFriction.Name = "pnlFriction";
            // 
            // lblFriction
            // 
            resources.ApplyResources(this.lblFriction, "lblFriction");
            this.lblFriction.Name = "lblFriction";
            // 
            // lblFrictionExclamation5
            // 
            resources.ApplyResources(this.lblFrictionExclamation5, "lblFrictionExclamation5");
            this.lblFrictionExclamation5.ForeColor = System.Drawing.Color.Crimson;
            this.lblFrictionExclamation5.Name = "lblFrictionExclamation5";
            // 
            // lblFrictionCwNow
            // 
            resources.ApplyResources(this.lblFrictionCwNow, "lblFrictionCwNow");
            this.lblFrictionCwNow.Name = "lblFrictionCwNow";
            // 
            // lblFrictionExclamation4
            // 
            resources.ApplyResources(this.lblFrictionExclamation4, "lblFrictionExclamation4");
            this.lblFrictionExclamation4.ForeColor = System.Drawing.Color.Crimson;
            this.lblFrictionExclamation4.Name = "lblFrictionExclamation4";
            // 
            // lblFrictionCcwNow
            // 
            resources.ApplyResources(this.lblFrictionCcwNow, "lblFrictionCcwNow");
            this.lblFrictionCcwNow.Name = "lblFrictionCcwNow";
            // 
            // lblFrictionExclamation3
            // 
            resources.ApplyResources(this.lblFrictionExclamation3, "lblFrictionExclamation3");
            this.lblFrictionExclamation3.ForeColor = System.Drawing.Color.Crimson;
            this.lblFrictionExclamation3.Name = "lblFrictionExclamation3";
            // 
            // btnFriction
            // 
            resources.ApplyResources(this.btnFriction, "btnFriction");
            this.btnFriction.Name = "btnFriction";
            this.btnFriction.UseVisualStyleBackColor = true;
            this.btnFriction.Click += new System.EventHandler(this.btnFriction_Click);
            // 
            // lblFrictionExclamation2
            // 
            resources.ApplyResources(this.lblFrictionExclamation2, "lblFrictionExclamation2");
            this.lblFrictionExclamation2.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblFrictionExclamation2.Name = "lblFrictionExclamation2";
            // 
            // lblFrictionExclamation
            // 
            resources.ApplyResources(this.lblFrictionExclamation, "lblFrictionExclamation");
            this.lblFrictionExclamation.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblFrictionExclamation.Name = "lblFrictionExclamation";
            // 
            // tabPageEnd
            // 
            this.tabPageEnd.BackColor = System.Drawing.Color.Transparent;
            this.tabPageEnd.Controls.Add(this.pnlPageEnd);
            resources.ApplyResources(this.tabPageEnd, "tabPageEnd");
            this.tabPageEnd.Name = "tabPageEnd";
            this.tabPageEnd.Tag = "End";
            this.tabPageEnd.UseVisualStyleBackColor = true;
            // 
            // pnlPageEnd
            // 
            this.pnlPageEnd.BackColor = System.Drawing.SystemColors.Control;
            this.pnlPageEnd.Controls.Add(this.rtxtWizard);
            this.pnlPageEnd.Controls.Add(this.pnlTuningSettingEnd);
            resources.ApplyResources(this.pnlPageEnd, "pnlPageEnd");
            this.pnlPageEnd.Name = "pnlPageEnd";
            this.pnlPageEnd.Tag = "End";
            // 
            // rtxtWizard
            // 
            this.rtxtWizard.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rtxtWizard.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.rtxtWizard, "rtxtWizard");
            this.rtxtWizard.Name = "rtxtWizard";
            this.rtxtWizard.ReadOnly = true;
            // 
            // pnlTuningSettingEnd
            // 
            this.pnlTuningSettingEnd.BackColor = System.Drawing.Color.LightPink;
            this.pnlTuningSettingEnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTuningSettingEnd.Controls.Add(this.lblTuningSettingEnd);
            resources.ApplyResources(this.pnlTuningSettingEnd, "pnlTuningSettingEnd");
            this.pnlTuningSettingEnd.Name = "pnlTuningSettingEnd";
            // 
            // lblTuningSettingEnd
            // 
            resources.ApplyResources(this.lblTuningSettingEnd, "lblTuningSettingEnd");
            this.lblTuningSettingEnd.Name = "lblTuningSettingEnd";
            // 
            // toolStripWizard
            // 
            this.toolStripWizard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCloseWizard,
            this.btnAutoTuningStart});
            resources.ApplyResources(this.toolStripWizard, "toolStripWizard");
            this.toolStripWizard.Name = "toolStripWizard";
            // 
            // btnCloseWizard
            // 
            resources.ApplyResources(this.btnCloseWizard, "btnCloseWizard");
            this.btnCloseWizard.Name = "btnCloseWizard";
            this.btnCloseWizard.Click += new System.EventHandler(this.btnStopWizard_Click);
            // 
            // btnAutoTuningStart
            // 
            resources.ApplyResources(this.btnAutoTuningStart, "btnAutoTuningStart");
            this.btnAutoTuningStart.Name = "btnAutoTuningStart";
            this.btnAutoTuningStart.Click += new System.EventHandler(this.btnAutoTuningStart_Click);
            // 
            // TimerWizard
            // 
            this.TimerWizard.Interval = 500;
            this.TimerWizard.Tick += new System.EventHandler(this.TimerWizard_Tick);
            // 
            // TimerLoad
            // 
            this.TimerLoad.Interval = 1000;
            this.TimerLoad.Tick += new System.EventHandler(this.TimerLoad_Tick);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnLoadTuningStop);
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.Name = "pnlBottom";
            // 
            // btnLoadTuningStop
            // 
            resources.ApplyResources(this.btnLoadTuningStop, "btnLoadTuningStop");
            this.btnLoadTuningStop.Name = "btnLoadTuningStop";
            this.btnLoadTuningStop.UseVisualStyleBackColor = true;
            this.btnLoadTuningStop.Click += new System.EventHandler(this.btnLoadTuningStop_Click);
            // 
            // TimerFriction
            // 
            this.TimerFriction.Interval = 1000;
            this.TimerFriction.Tick += new System.EventHandler(this.TimerFriction_Tick);
            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnPrev, "btnPrev");
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnNext, "btnNext");
            this.btnNext.Name = "btnNext";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // WizardDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabWizard);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.toolStripWizard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WizardDialog";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.WizardForm_Load);
            this.Shown += new System.EventHandler(this.WizardForm_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WizardForm_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WizardForm_FormClosing);
            this.tabWizard.ResumeLayout(false);
            this.tabPageLoad.ResumeLayout(false);
            this.pnlPageLoad.ResumeLayout(false);
            this.pnlPageLoad.PerformLayout();
            this.pnlLoad.ResumeLayout(false);
            this.pnlLoad.PerformLayout();
            this.tabPageMachine.ResumeLayout(false);
            this.pnlPageMachine.ResumeLayout(false);
            this.pnlPageMachine.PerformLayout();
            this.pnlMachine.ResumeLayout(false);
            this.pnlMachine.PerformLayout();
            this.tabPageStrength.ResumeLayout(false);
            this.pnlPageStrength.ResumeLayout(false);
            this.pnlPageStrength.PerformLayout();
            this.pnlStrength.ResumeLayout(false);
            this.pnlStrength.PerformLayout();
            this.tabPageMode.ResumeLayout(false);
            this.pnlPageMode.ResumeLayout(false);
            this.pnlPageMode.PerformLayout();
            this.pnlMode.ResumeLayout(false);
            this.pnlMode.PerformLayout();
            this.tabPageVelObs.ResumeLayout(false);
            this.pnlPageVelObs.ResumeLayout(false);
            this.pnlPageVelObs.PerformLayout();
            this.pnlVelObs.ResumeLayout(false);
            this.pnlVelObs.PerformLayout();
            this.tabPageTurbo.ResumeLayout(false);
            this.pnlPageTurbo.ResumeLayout(false);
            this.pnlPageTurbo.PerformLayout();
            this.pnlTurbo.ResumeLayout(false);
            this.pnlTurbo.PerformLayout();
            this.tabPageInposition.ResumeLayout(false);
            this.pnlPageInposition.ResumeLayout(false);
            this.pnlPageInposition.PerformLayout();
            this.pnlInposition.ResumeLayout(false);
            this.pnlInposition.PerformLayout();
            this.tabPageTargetTime.ResumeLayout(false);
            this.pnlPageTargetTime.ResumeLayout(false);
            this.pnlPageTargetTime.PerformLayout();
            this.pnlTargetTime.ResumeLayout(false);
            this.pnlTargetTime.PerformLayout();
            this.tabPageProfileVel.ResumeLayout(false);
            this.pnlPageProfileVel.ResumeLayout(false);
            this.pnlPageProfileVel.PerformLayout();
            this.pnlProfileVelocity.ResumeLayout(false);
            this.pnlProfileVelocity.PerformLayout();
            this.tabPageProfilePos.ResumeLayout(false);
            this.tabPageProfilePos.PerformLayout();
            this.pnlTuningPosition.ResumeLayout(false);
            this.pnlTuningPosition.PerformLayout();
            this.tabPageFriction.ResumeLayout(false);
            this.pnlPageFriction.ResumeLayout(false);
            this.pnlPageFriction.PerformLayout();
            this.pnlFriction.ResumeLayout(false);
            this.pnlFriction.PerformLayout();
            this.tabPageEnd.ResumeLayout(false);
            this.pnlPageEnd.ResumeLayout(false);
            this.pnlTuningSettingEnd.ResumeLayout(false);
            this.pnlTuningSettingEnd.PerformLayout();
            this.toolStripWizard.ResumeLayout(false);
            this.toolStripWizard.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabControl tabWizard;
		private System.Windows.Forms.TabPage tabPageMachine;
		private System.Windows.Forms.TabPage tabPageStrength;
		private System.Windows.Forms.Label lblMachine;
		private System.Windows.Forms.RadioButton rdoBelt;
		private System.Windows.Forms.RadioButton rdoScrew;
		private System.Windows.Forms.RadioButton rdoDisk;
		private System.Windows.Forms.Panel pnlMachine;
		private System.Windows.Forms.Panel pnlStrength;
		private System.Windows.Forms.Label lblStrength;
		private System.Windows.Forms.RadioButton rdoStrong;
		private System.Windows.Forms.RadioButton rdoMidlle;
		private System.Windows.Forms.RadioButton rdoLight;
		private System.Windows.Forms.TabPage tabPageMode;
		private System.Windows.Forms.TabPage tabPageInposition;
		private System.Windows.Forms.TabPage tabPageTargetTime;
		private System.Windows.Forms.TabPage tabPageProfileVel;
		private System.Windows.Forms.TabPage tabPageProfilePos;
		private System.Windows.Forms.TabPage tabPageEnd;
		private System.Windows.Forms.Panel pnlMode;
		private System.Windows.Forms.Label lblMode;
		private System.Windows.Forms.RadioButton rdoStiffnessPriorty;
		private System.Windows.Forms.RadioButton rdoPositionPriorty;
		private System.Windows.Forms.RadioButton rdoNormalPriorty;
		private System.Windows.Forms.Panel pnlInposition;
		private System.Windows.Forms.Label lblInposition;
		private System.Windows.Forms.Label lblEncderPulse;
		private System.Windows.Forms.Label lblEncder;
		private CtlNumericInputInt ctlNumInposition;
		private System.Windows.Forms.Panel pnlTargetTime;
		private System.Windows.Forms.Label lblTargetTime;
		private CtlNumericInputInt ctlNumTargetTime;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel pnlProfileVelocity;
		private System.Windows.Forms.Label lblProfileVelocity;
		private System.Windows.Forms.TabPage tabPageLoad;
		private System.Windows.Forms.Panel pnlLoad;
		private System.Windows.Forms.Label lblLoad;
		private CtlNumericInputInt ctlNumLoad;
		private System.Windows.Forms.Label lblLoadSet2;
		private System.Windows.Forms.Label lblLoadSet;
		private System.Windows.Forms.Label lblLoadNow;
		private System.Windows.Forms.Label lblLoadAdjust;
		private System.Windows.Forms.Button btnLoadTuning;
		private System.Windows.Forms.Label lblLoadAdjust2;
		private System.Windows.Forms.Label lblInpositionNow;
		private System.Windows.Forms.Label lblLoadExclamation;
		private System.Windows.Forms.Label lblLoadExclamation2;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnPrev;
		private System.Windows.Forms.Label lblVelAccDcc;
		private CtlNumericInputInt ctlNumTargetVelocity;
		private CtlNumericInputInt ctlNumTargetAcceleration;
		private CtlNumericInputInt ctlNumTargetDeceleration;
		private System.Windows.Forms.Panel pnlTuningPosition;
		private System.Windows.Forms.Label lblTuningPosition;
		private System.Windows.Forms.Label lblWait;
		private CtlNumericInputInt ctlNumTargetPosition;
		private CtlNumericInputInt ctlNumStartPosition;
		private System.Windows.Forms.Label lblProfileSet;
		private CtlNumericInputInt ctlNumWaitTime;
		private System.Windows.Forms.Button btnTeaching;
		private System.Windows.Forms.Label lblProfileSet2;
		private System.Windows.Forms.Panel pnlTuningSettingEnd;
		private System.Windows.Forms.Label lblTuningSettingEnd;
		private System.Windows.Forms.Label lblProfileVelocity2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblTargetTimeNow;
		private System.Windows.Forms.RichTextBox rtxtWizard;
		private System.Windows.Forms.ToolStrip toolStripWizard;
		private System.Windows.Forms.ToolStripButton btnCloseWizard;
		private System.Windows.Forms.Label lblDmy;
		private System.Windows.Forms.ToolStripButton btnAutoTuningStart;
		private System.Windows.Forms.Timer TimerWizard;
		private System.Windows.Forms.Button btnLoadTuningStop;
		private System.Windows.Forms.Timer TimerLoad;
		private System.Windows.Forms.TabPage tabPageVelObs;
		private System.Windows.Forms.RadioButton rdoVelObsDisable;
		private System.Windows.Forms.RadioButton rdoVelObsEnable;
		private System.Windows.Forms.Panel pnlVelObs;
		private System.Windows.Forms.Label lblVelObs;
		private System.Windows.Forms.Panel pnlBottom;
		private System.Windows.Forms.TabPage tabPageTurbo;
		private System.Windows.Forms.RadioButton rdoTurboDisable;
		private System.Windows.Forms.RadioButton rdoTurboEnable;
		private System.Windows.Forms.Panel pnlTurbo;
		private System.Windows.Forms.Label lblTurbo;
		private System.Windows.Forms.Label lblTurboExclamation;
		private System.Windows.Forms.Label lblTurboExclamation2;
		private System.Windows.Forms.TabPage tabPageFriction;
		private System.Windows.Forms.Label lblFrictionCwNow;
		private System.Windows.Forms.Panel pnlFriction;
		private System.Windows.Forms.Label lblFriction;
		private System.Windows.Forms.Button btnFriction;
		private System.Windows.Forms.Label lblFrictionCcwNow;
		private System.Windows.Forms.Label lblFrictionExclamation3;
		private System.Windows.Forms.Label lblFrictionExclamation2;
		private System.Windows.Forms.Label lblFrictionExclamation;
		private System.Windows.Forms.Timer TimerFriction;
		private System.Windows.Forms.Label lblFrictionExclamation5;
        private System.Windows.Forms.Label lblFrictionExclamation4;
        private System.Windows.Forms.Panel pnlPageLoad;
        private System.Windows.Forms.Panel pnlPageMachine;
        private System.Windows.Forms.Panel pnlPageStrength;
        private System.Windows.Forms.Panel pnlPageVelObs;
        private System.Windows.Forms.Panel pnlPageMode;
        private System.Windows.Forms.Panel pnlPageInposition;
        private System.Windows.Forms.Panel pnlPageTurbo;
        private System.Windows.Forms.Panel pnlPageTargetTime;
        private System.Windows.Forms.Panel pnlPageProfileVel;
        private System.Windows.Forms.Panel pnlPageFriction;
		private System.Windows.Forms.Panel pnlPageEnd;
		private System.Windows.Forms.Label lblDccTime;
		private System.Windows.Forms.Label lblAccTime;
		private System.Windows.Forms.Label lblVelObsExclamation3;
		private System.Windows.Forms.Label lblVelObsExclamation2;
		private System.Windows.Forms.Label lblVelObsExclamation1;
        private System.Windows.Forms.Label lblUnit;

	}
}