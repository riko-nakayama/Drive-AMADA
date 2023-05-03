namespace Motion_Designer
{
	partial class GainControlForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GainControlForm));
            this.fpnlServoGain = new System.Windows.Forms.FlowLayoutPanel();
            this.grpPosEx = new System.Windows.Forms.GroupBox();
            this.ctlNumExKp = new Motion_Designer.CtlNumericInputEx();
            this.grpVelEx = new System.Windows.Forms.GroupBox();
            this.ctlNumExKi = new Motion_Designer.CtlNumericInputEx();
            this.ctlNumExKv = new Motion_Designer.CtlNumericInputEx();
            this.grpLoadEx = new System.Windows.Forms.GroupBox();
            this.lblInertiaUnit = new System.Windows.Forms.Label();
            this.ctlNumExLoad = new Motion_Designer.CtlNumericInputEx();
            this.lblUnit1 = new System.Windows.Forms.Label();
            this.grpTuningFree = new System.Windows.Forms.GroupBox();
            this.rdoLoadFriction = new System.Windows.Forms.RadioButton();
            this.rdoLoadOnly = new System.Windows.Forms.RadioButton();
            this.ctlNumExTuningFree = new Motion_Designer.CtlNumericInputEx();
            this.chkTuningFree = new System.Windows.Forms.CheckBox();
            this.chkAdaptiveFilter1 = new System.Windows.Forms.CheckBox();
            this.chkAdaptiveFilter2 = new System.Windows.Forms.CheckBox();
            this.toolStripGain = new System.Windows.Forms.ToolStrip();
            this.tbtnSaveGain = new System.Windows.Forms.ToolStripButton();
            this.sep1 = new System.Windows.Forms.ToolStripSeparator();
            this.TimerGain = new System.Windows.Forms.Timer(this.components);
            this.fpnlCurrentFillter = new System.Windows.Forms.FlowLayoutPanel();
            this.grpCurLpfEx = new System.Windows.Forms.GroupBox();
            this.ctlNumExCurLpf = new Motion_Designer.CtlNumericInputEx();
            this.lblCurLPF3 = new System.Windows.Forms.Label();
            this.chkCurLPF1 = new System.Windows.Forms.CheckBox();
            this.grpCurNotchEx1 = new System.Windows.Forms.GroupBox();
            this.ctlNumExCurNotch1_q = new Motion_Designer.CtlNumericInputEx();
            this.ctlNumExCurNotch1_d = new Motion_Designer.CtlNumericInputEx();
            this.ctlNumExCurNotch1_f = new Motion_Designer.CtlNumericInputEx();
            this.grpCurNotchEx2 = new System.Windows.Forms.GroupBox();
            this.ctlNumExCurNotch2_q = new Motion_Designer.CtlNumericInputEx();
            this.ctlNumExCurNotch2_d = new Motion_Designer.CtlNumericInputEx();
            this.ctlNumExCurNotch2_f = new Motion_Designer.CtlNumericInputEx();
            this.grpCurNotchEx3 = new System.Windows.Forms.GroupBox();
            this.ctlNumExCurNotch3_q = new Motion_Designer.CtlNumericInputEx();
            this.ctlNumExCurNotch3_d = new Motion_Designer.CtlNumericInputEx();
            this.ctlNumExCurNotch3_f = new Motion_Designer.CtlNumericInputEx();
            this.grpCurNotchEx4 = new System.Windows.Forms.GroupBox();
            this.ctlNumExCurNotch4_q = new Motion_Designer.CtlNumericInputEx();
            this.ctlNumExCurNotch4_d = new Motion_Designer.CtlNumericInputEx();
            this.ctlNumExCurNotch4_f = new Motion_Designer.CtlNumericInputEx();
            this.grpCurNotchEx5 = new System.Windows.Forms.GroupBox();
            this.ctlNumExCurNotch5_q = new Motion_Designer.CtlNumericInputEx();
            this.ctlNumExCurNotch5_d = new Motion_Designer.CtlNumericInputEx();
            this.ctlNumExCurNotch5_f = new Motion_Designer.CtlNumericInputEx();
            this.tabServoGain = new System.Windows.Forms.TabControl();
            this.tabPageServoGain = new System.Windows.Forms.TabPage();
            this.tabPageCurrentFillter = new System.Windows.Forms.TabPage();
            this.tabPageVelocityFillter = new System.Windows.Forms.TabPage();
            this.fpnlVelocityFillter = new System.Windows.Forms.FlowLayoutPanel();
            this.grpVelLpfEx = new System.Windows.Forms.GroupBox();
            this.ctlNumExVelLpf = new Motion_Designer.CtlNumericInputEx();
            this.lblVelLPF3 = new System.Windows.Forms.Label();
            this.chkVelLPF1 = new System.Windows.Forms.CheckBox();
            this.grpVelNotchEx1 = new System.Windows.Forms.GroupBox();
            this.ctlNumExVelNotch1_q = new Motion_Designer.CtlNumericInputEx();
            this.ctlNumExVelNotch1_d = new Motion_Designer.CtlNumericInputEx();
            this.ctlNumExVelNotch1_f = new Motion_Designer.CtlNumericInputEx();
            this.tabPagePositionFillter = new System.Windows.Forms.TabPage();
            this.fpnlPositionFillter = new System.Windows.Forms.FlowLayoutPanel();
            this.grpPosLpfEx = new System.Windows.Forms.GroupBox();
            this.ctlNumExPosLpf = new Motion_Designer.CtlNumericInputEx();
            this.lblPosLPF3 = new System.Windows.Forms.Label();
            this.chkPosLPF1 = new System.Windows.Forms.CheckBox();
            this.grpPosNotchEx1 = new System.Windows.Forms.GroupBox();
            this.ctlNumExPosNotch1_q = new Motion_Designer.CtlNumericInputEx();
            this.ctlNumExPosNotch1_d = new Motion_Designer.CtlNumericInputEx();
            this.ctlNumExPosNotch1_f = new Motion_Designer.CtlNumericInputEx();
            this.tabPageFriction = new System.Windows.Forms.TabPage();
            this.fpnlFriction = new System.Windows.Forms.FlowLayoutPanel();
            this.grpFriction = new System.Windows.Forms.GroupBox();
            this.ctlNumExGravity = new Motion_Designer.CtlNumericInputEx();
            this.ctlNumExDynamic = new Motion_Designer.CtlNumericInputEx();
            this.ctlNumExCcwTrq = new Motion_Designer.CtlNumericInputEx();
            this.ctlNumExCwTrq = new Motion_Designer.CtlNumericInputEx();
            this.tabPageTorqueObserver = new System.Windows.Forms.TabPage();
            this.fpnlTorqueObserver = new System.Windows.Forms.FlowLayoutPanel();
            this.grpTrqOvsEx = new System.Windows.Forms.GroupBox();
            this.ctlNumExTrqObsFrq = new Motion_Designer.CtlNumericInputEx();
            this.ctlNumExTrqObsGain = new Motion_Designer.CtlNumericInputEx();
            this.chkTorqueObserverEnable1 = new System.Windows.Forms.CheckBox();
            this.tabPageVelocityObserver = new System.Windows.Forms.TabPage();
            this.fpnlVelocityObserver = new System.Windows.Forms.FlowLayoutPanel();
            this.grpVelOvsEx = new System.Windows.Forms.GroupBox();
            this.ctlNumExVelObsTdisComp = new Motion_Designer.CtlNumericInputEx();
            this.ctlNumExVelObsVelComp = new Motion_Designer.CtlNumericInputEx();
            this.chkVelocityObserverTdisEnable1 = new System.Windows.Forms.CheckBox();
            this.ctlNumExVelObsTime = new Motion_Designer.CtlNumericInputEx();
            this.chkVelocityObserverEnable1 = new System.Windows.Forms.CheckBox();
            this.tabPageModel = new System.Windows.Forms.TabPage();
            this.fpnlModel = new System.Windows.Forms.FlowLayoutPanel();
            this.grpModelEx = new System.Windows.Forms.GroupBox();
            this.ctlNumExModelFillter1 = new Motion_Designer.CtlNumericInputEx();
            this.chkModelControlMotorModel1 = new System.Windows.Forms.CheckBox();
            this.ctlNumExModelGain3 = new Motion_Designer.CtlNumericInputEx();
            this.ctlNumExModelGain2 = new Motion_Designer.CtlNumericInputEx();
            this.ctlNumExModelGain1 = new Motion_Designer.CtlNumericInputEx();
            this.chkModelControlEnable1 = new System.Windows.Forms.CheckBox();
            this.tabPageFeedback = new System.Windows.Forms.TabPage();
            this.fpnlFeedbackFillter = new System.Windows.Forms.FlowLayoutPanel();
            this.grpVelFBEx = new System.Windows.Forms.GroupBox();
            this.lblVelFBEx = new System.Windows.Forms.Label();
            this.ctlNumExVelFB = new Motion_Designer.CtlNumericInputEx();
            this.grpPosFBEx = new System.Windows.Forms.GroupBox();
            this.lblPosFBEx = new System.Windows.Forms.Label();
            this.ctlNumExPosFB = new Motion_Designer.CtlNumericInputEx();
            this.grpCurLpfFB = new System.Windows.Forms.GroupBox();
            this.ctlNumExCurLpfFB = new Motion_Designer.CtlNumericInputEx();
            this.grpVelLpfFB = new System.Windows.Forms.GroupBox();
            this.ctlNumExVelLpfFB = new Motion_Designer.CtlNumericInputEx();
            this.tabPageFeedforward = new System.Windows.Forms.TabPage();
            this.fpnlFeedforward = new System.Windows.Forms.FlowLayoutPanel();
            this.grpPosFF = new System.Windows.Forms.GroupBox();
            this.ctlNumExPosFFGain = new Motion_Designer.CtlNumericInputEx();
            this.grpVelFF = new System.Windows.Forms.GroupBox();
            this.lblVelFFFillter = new System.Windows.Forms.Label();
            this.lblVelFFPeriod = new System.Windows.Forms.Label();
            this.ctlNumExVelFFFillter = new Motion_Designer.CtlNumericInputEx();
            this.ctlNumExVelFFPeriod = new Motion_Designer.CtlNumericInputEx();
            this.ctlNumExVelFFGain = new Motion_Designer.CtlNumericInputEx();
            this.TimerResize = new System.Windows.Forms.Timer(this.components);
            this.TimerSave = new System.Windows.Forms.Timer(this.components);
            this.fpnlServoGain.SuspendLayout();
            this.grpPosEx.SuspendLayout();
            this.grpVelEx.SuspendLayout();
            this.grpLoadEx.SuspendLayout();
            this.grpTuningFree.SuspendLayout();
            this.toolStripGain.SuspendLayout();
            this.fpnlCurrentFillter.SuspendLayout();
            this.grpCurLpfEx.SuspendLayout();
            this.grpCurNotchEx1.SuspendLayout();
            this.grpCurNotchEx2.SuspendLayout();
            this.grpCurNotchEx3.SuspendLayout();
            this.grpCurNotchEx4.SuspendLayout();
            this.grpCurNotchEx5.SuspendLayout();
            this.tabServoGain.SuspendLayout();
            this.tabPageServoGain.SuspendLayout();
            this.tabPageCurrentFillter.SuspendLayout();
            this.tabPageVelocityFillter.SuspendLayout();
            this.fpnlVelocityFillter.SuspendLayout();
            this.grpVelLpfEx.SuspendLayout();
            this.grpVelNotchEx1.SuspendLayout();
            this.tabPagePositionFillter.SuspendLayout();
            this.fpnlPositionFillter.SuspendLayout();
            this.grpPosLpfEx.SuspendLayout();
            this.grpPosNotchEx1.SuspendLayout();
            this.tabPageFriction.SuspendLayout();
            this.fpnlFriction.SuspendLayout();
            this.grpFriction.SuspendLayout();
            this.tabPageTorqueObserver.SuspendLayout();
            this.fpnlTorqueObserver.SuspendLayout();
            this.grpTrqOvsEx.SuspendLayout();
            this.tabPageVelocityObserver.SuspendLayout();
            this.fpnlVelocityObserver.SuspendLayout();
            this.grpVelOvsEx.SuspendLayout();
            this.tabPageModel.SuspendLayout();
            this.fpnlModel.SuspendLayout();
            this.grpModelEx.SuspendLayout();
            this.tabPageFeedback.SuspendLayout();
            this.fpnlFeedbackFillter.SuspendLayout();
            this.grpVelFBEx.SuspendLayout();
            this.grpPosFBEx.SuspendLayout();
            this.grpCurLpfFB.SuspendLayout();
            this.grpVelLpfFB.SuspendLayout();
            this.tabPageFeedforward.SuspendLayout();
            this.fpnlFeedforward.SuspendLayout();
            this.grpPosFF.SuspendLayout();
            this.grpVelFF.SuspendLayout();
            this.SuspendLayout();
            // 
            // fpnlServoGain
            // 
            resources.ApplyResources(this.fpnlServoGain, "fpnlServoGain");
            this.fpnlServoGain.BackColor = System.Drawing.SystemColors.Control;
            this.fpnlServoGain.Controls.Add(this.grpPosEx);
            this.fpnlServoGain.Controls.Add(this.grpVelEx);
            this.fpnlServoGain.Controls.Add(this.grpLoadEx);
            this.fpnlServoGain.Controls.Add(this.grpTuningFree);
            this.fpnlServoGain.Name = "fpnlServoGain";
            this.fpnlServoGain.Click += new System.EventHandler(this.fpnlGain_Click);
            // 
            // grpPosEx
            // 
            this.grpPosEx.Controls.Add(this.ctlNumExKp);
            resources.ApplyResources(this.grpPosEx, "grpPosEx");
            this.grpPosEx.Name = "grpPosEx";
            this.grpPosEx.TabStop = false;
            // 
            // ctlNumExKp
            // 
            this.ctlNumExKp.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExKp, "ctlNumExKp");
            this.ctlNumExKp.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExKp.DataId = 0;
            this.ctlNumExKp.IntValue = 0;
            this.ctlNumExKp.Name = "ctlNumExKp";
            this.ctlNumExKp.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExKp.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExKp.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExKp.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExKp.NumMaximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.ctlNumExKp.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExKp.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExKp.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExKp.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExKp.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExKp.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExKp.TitleHeight = 25;
            this.ctlNumExKp.TitleVisible = true;
            this.ctlNumExKp.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExKp.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExKp.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExKp.UnitHeight = 20;
            this.ctlNumExKp.UnitVisible = true;
            this.ctlNumExKp.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExKp.x100Visible = false;
            this.ctlNumExKp.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExKp.x10Visible = true;
            // 
            // grpVelEx
            // 
            this.grpVelEx.Controls.Add(this.ctlNumExKi);
            this.grpVelEx.Controls.Add(this.ctlNumExKv);
            resources.ApplyResources(this.grpVelEx, "grpVelEx");
            this.grpVelEx.Name = "grpVelEx";
            this.grpVelEx.TabStop = false;
            // 
            // ctlNumExKi
            // 
            this.ctlNumExKi.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExKi, "ctlNumExKi");
            this.ctlNumExKi.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExKi.DataId = 0;
            this.ctlNumExKi.IntValue = 0;
            this.ctlNumExKi.Name = "ctlNumExKi";
            this.ctlNumExKi.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExKi.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExKi.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExKi.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExKi.NumMaximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.ctlNumExKi.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExKi.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExKi.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExKi.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExKi.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExKi.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExKi.TitleHeight = 25;
            this.ctlNumExKi.TitleVisible = true;
            this.ctlNumExKi.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExKi.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExKi.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExKi.UnitHeight = 20;
            this.ctlNumExKi.UnitVisible = true;
            this.ctlNumExKi.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExKi.x100Visible = false;
            this.ctlNumExKi.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExKi.x10Visible = true;
            // 
            // ctlNumExKv
            // 
            this.ctlNumExKv.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExKv, "ctlNumExKv");
            this.ctlNumExKv.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExKv.DataId = 0;
            this.ctlNumExKv.IntValue = 0;
            this.ctlNumExKv.Name = "ctlNumExKv";
            this.ctlNumExKv.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExKv.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExKv.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExKv.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExKv.NumMaximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.ctlNumExKv.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExKv.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExKv.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExKv.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExKv.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExKv.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExKv.TitleHeight = 25;
            this.ctlNumExKv.TitleVisible = true;
            this.ctlNumExKv.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExKv.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExKv.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExKv.UnitHeight = 20;
            this.ctlNumExKv.UnitVisible = true;
            this.ctlNumExKv.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExKv.x100Visible = false;
            this.ctlNumExKv.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExKv.x10Visible = true;
            // 
            // grpLoadEx
            // 
            this.grpLoadEx.Controls.Add(this.lblInertiaUnit);
            this.grpLoadEx.Controls.Add(this.ctlNumExLoad);
            this.grpLoadEx.Controls.Add(this.lblUnit1);
            resources.ApplyResources(this.grpLoadEx, "grpLoadEx");
            this.grpLoadEx.Name = "grpLoadEx";
            this.grpLoadEx.TabStop = false;
            // 
            // lblInertiaUnit
            // 
            resources.ApplyResources(this.lblInertiaUnit, "lblInertiaUnit");
            this.lblInertiaUnit.ForeColor = System.Drawing.Color.Navy;
            this.lblInertiaUnit.Name = "lblInertiaUnit";
            // 
            // ctlNumExLoad
            // 
            this.ctlNumExLoad.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExLoad, "ctlNumExLoad");
            this.ctlNumExLoad.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExLoad.DataId = 0;
            this.ctlNumExLoad.IntValue = 0;
            this.ctlNumExLoad.Name = "ctlNumExLoad";
            this.ctlNumExLoad.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExLoad.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExLoad.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExLoad.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExLoad.NumMaximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.ctlNumExLoad.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExLoad.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExLoad.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExLoad.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExLoad.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExLoad.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExLoad.TitleHeight = 25;
            this.ctlNumExLoad.TitleVisible = true;
            this.ctlNumExLoad.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExLoad.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExLoad.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExLoad.UnitHeight = 20;
            this.ctlNumExLoad.UnitVisible = true;
            this.ctlNumExLoad.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExLoad.x100Visible = false;
            this.ctlNumExLoad.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExLoad.x10Visible = true;
            // 
            // lblUnit1
            // 
            resources.ApplyResources(this.lblUnit1, "lblUnit1");
            this.lblUnit1.ForeColor = System.Drawing.Color.Navy;
            this.lblUnit1.Name = "lblUnit1";
            // 
            // grpTuningFree
            // 
            this.grpTuningFree.Controls.Add(this.rdoLoadFriction);
            this.grpTuningFree.Controls.Add(this.rdoLoadOnly);
            this.grpTuningFree.Controls.Add(this.ctlNumExTuningFree);
            this.grpTuningFree.Controls.Add(this.chkTuningFree);
            this.grpTuningFree.Controls.Add(this.chkAdaptiveFilter1);
            this.grpTuningFree.Controls.Add(this.chkAdaptiveFilter2);
            resources.ApplyResources(this.grpTuningFree, "grpTuningFree");
            this.grpTuningFree.Name = "grpTuningFree";
            this.grpTuningFree.TabStop = false;
            // 
            // rdoLoadFriction
            // 
            resources.ApplyResources(this.rdoLoadFriction, "rdoLoadFriction");
            this.rdoLoadFriction.Name = "rdoLoadFriction";
            this.rdoLoadFriction.UseVisualStyleBackColor = true;
            // 
            // rdoLoadOnly
            // 
            resources.ApplyResources(this.rdoLoadOnly, "rdoLoadOnly");
            this.rdoLoadOnly.Checked = true;
            this.rdoLoadOnly.Name = "rdoLoadOnly";
            this.rdoLoadOnly.TabStop = true;
            this.rdoLoadOnly.UseVisualStyleBackColor = true;
            // 
            // ctlNumExTuningFree
            // 
            this.ctlNumExTuningFree.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExTuningFree, "ctlNumExTuningFree");
            this.ctlNumExTuningFree.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExTuningFree.DataId = 0;
            this.ctlNumExTuningFree.IntValue = 0;
            this.ctlNumExTuningFree.Name = "ctlNumExTuningFree";
            this.ctlNumExTuningFree.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExTuningFree.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExTuningFree.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExTuningFree.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExTuningFree.NumMaximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.ctlNumExTuningFree.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExTuningFree.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExTuningFree.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExTuningFree.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExTuningFree.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExTuningFree.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExTuningFree.TitleHeight = 25;
            this.ctlNumExTuningFree.TitleVisible = true;
            this.ctlNumExTuningFree.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExTuningFree.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExTuningFree.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExTuningFree.UnitHeight = 20;
            this.ctlNumExTuningFree.UnitVisible = true;
            this.ctlNumExTuningFree.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExTuningFree.x100Visible = false;
            this.ctlNumExTuningFree.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExTuningFree.x10Visible = true;
            // 
            // chkTuningFree
            // 
            resources.ApplyResources(this.chkTuningFree, "chkTuningFree");
            this.chkTuningFree.Name = "chkTuningFree";
            this.chkTuningFree.UseVisualStyleBackColor = true;
            this.chkTuningFree.CheckedChanged += new System.EventHandler(this.chkTuningFree_CheckedChanged);
            // 
            // chkAdaptiveFilter1
            // 
            resources.ApplyResources(this.chkAdaptiveFilter1, "chkAdaptiveFilter1");
            this.chkAdaptiveFilter1.Name = "chkAdaptiveFilter1";
            this.chkAdaptiveFilter1.UseVisualStyleBackColor = true;
            this.chkAdaptiveFilter1.CheckedChanged += new System.EventHandler(this.chkAdaptiveFilter1_CheckedChanged);
            // 
            // chkAdaptiveFilter2
            // 
            resources.ApplyResources(this.chkAdaptiveFilter2, "chkAdaptiveFilter2");
            this.chkAdaptiveFilter2.Name = "chkAdaptiveFilter2";
            this.chkAdaptiveFilter2.UseVisualStyleBackColor = true;
            this.chkAdaptiveFilter2.CheckedChanged += new System.EventHandler(this.chkAdaptiveFilter2_CheckedChanged);
            // 
            // toolStripGain
            // 
            this.toolStripGain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtnSaveGain,
            this.sep1});
            this.toolStripGain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            resources.ApplyResources(this.toolStripGain, "toolStripGain");
            this.toolStripGain.Name = "toolStripGain";
            this.toolStripGain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // tbtnSaveGain
            // 
            resources.ApplyResources(this.tbtnSaveGain, "tbtnSaveGain");
            this.tbtnSaveGain.BackColor = System.Drawing.SystemColors.Control;
            this.tbtnSaveGain.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tbtnSaveGain.Name = "tbtnSaveGain";
            this.tbtnSaveGain.MouseHover += new System.EventHandler(this.Control_MouseHover);
            this.tbtnSaveGain.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.tbtnSaveGain.Click += new System.EventHandler(this.tbtnSaveGain_Click);
            // 
            // sep1
            // 
            this.sep1.Name = "sep1";
            resources.ApplyResources(this.sep1, "sep1");
            this.sep1.MouseHover += new System.EventHandler(this.Control_MouseHover);
            this.sep1.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            // 
            // TimerGain
            // 
            this.TimerGain.Interval = 1000;
            this.TimerGain.Tick += new System.EventHandler(this.TimerGain_Tick);
            // 
            // fpnlCurrentFillter
            // 
            resources.ApplyResources(this.fpnlCurrentFillter, "fpnlCurrentFillter");
            this.fpnlCurrentFillter.BackColor = System.Drawing.SystemColors.Control;
            this.fpnlCurrentFillter.Controls.Add(this.grpCurLpfEx);
            this.fpnlCurrentFillter.Controls.Add(this.grpCurNotchEx1);
            this.fpnlCurrentFillter.Controls.Add(this.grpCurNotchEx2);
            this.fpnlCurrentFillter.Controls.Add(this.grpCurNotchEx3);
            this.fpnlCurrentFillter.Controls.Add(this.grpCurNotchEx4);
            this.fpnlCurrentFillter.Controls.Add(this.grpCurNotchEx5);
            this.fpnlCurrentFillter.Name = "fpnlCurrentFillter";
            this.fpnlCurrentFillter.Click += new System.EventHandler(this.fpnlGain_Click);
            // 
            // grpCurLpfEx
            // 
            this.grpCurLpfEx.Controls.Add(this.ctlNumExCurLpf);
            this.grpCurLpfEx.Controls.Add(this.lblCurLPF3);
            this.grpCurLpfEx.Controls.Add(this.chkCurLPF1);
            resources.ApplyResources(this.grpCurLpfEx, "grpCurLpfEx");
            this.grpCurLpfEx.Name = "grpCurLpfEx";
            this.grpCurLpfEx.TabStop = false;
            // 
            // ctlNumExCurLpf
            // 
            this.ctlNumExCurLpf.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExCurLpf, "ctlNumExCurLpf");
            this.ctlNumExCurLpf.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurLpf.DataId = 0;
            this.ctlNumExCurLpf.IntValue = 0;
            this.ctlNumExCurLpf.Name = "ctlNumExCurLpf";
            this.ctlNumExCurLpf.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExCurLpf.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExCurLpf.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExCurLpf.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurLpf.NumMaximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.ctlNumExCurLpf.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCurLpf.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCurLpf.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExCurLpf.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExCurLpf.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurLpf.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurLpf.TitleHeight = 25;
            this.ctlNumExCurLpf.TitleVisible = true;
            this.ctlNumExCurLpf.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExCurLpf.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurLpf.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurLpf.UnitHeight = 20;
            this.ctlNumExCurLpf.UnitVisible = true;
            this.ctlNumExCurLpf.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCurLpf.x100Visible = false;
            this.ctlNumExCurLpf.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCurLpf.x10Visible = true;
            // 
            // lblCurLPF3
            // 
            resources.ApplyResources(this.lblCurLPF3, "lblCurLPF3");
            this.lblCurLPF3.ForeColor = System.Drawing.Color.Crimson;
            this.lblCurLPF3.Name = "lblCurLPF3";
            // 
            // chkCurLPF1
            // 
            resources.ApplyResources(this.chkCurLPF1, "chkCurLPF1");
            this.chkCurLPF1.Name = "chkCurLPF1";
            this.chkCurLPF1.UseVisualStyleBackColor = true;
            this.chkCurLPF1.CheckStateChanged += new System.EventHandler(this.chkCurLPF_CheckStateChanged);
            // 
            // grpCurNotchEx1
            // 
            this.grpCurNotchEx1.Controls.Add(this.ctlNumExCurNotch1_q);
            this.grpCurNotchEx1.Controls.Add(this.ctlNumExCurNotch1_d);
            this.grpCurNotchEx1.Controls.Add(this.ctlNumExCurNotch1_f);
            resources.ApplyResources(this.grpCurNotchEx1, "grpCurNotchEx1");
            this.grpCurNotchEx1.Name = "grpCurNotchEx1";
            this.grpCurNotchEx1.TabStop = false;
            // 
            // ctlNumExCurNotch1_q
            // 
            this.ctlNumExCurNotch1_q.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExCurNotch1_q, "ctlNumExCurNotch1_q");
            this.ctlNumExCurNotch1_q.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch1_q.DataId = 0;
            this.ctlNumExCurNotch1_q.IntValue = 0;
            this.ctlNumExCurNotch1_q.Name = "ctlNumExCurNotch1_q";
            this.ctlNumExCurNotch1_q.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExCurNotch1_q.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExCurNotch1_q.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExCurNotch1_q.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch1_q.NumMaximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.ctlNumExCurNotch1_q.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCurNotch1_q.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCurNotch1_q.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExCurNotch1_q.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExCurNotch1_q.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch1_q.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch1_q.TitleHeight = 25;
            this.ctlNumExCurNotch1_q.TitleVisible = true;
            this.ctlNumExCurNotch1_q.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExCurNotch1_q.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch1_q.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch1_q.UnitHeight = 20;
            this.ctlNumExCurNotch1_q.UnitVisible = true;
            this.ctlNumExCurNotch1_q.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCurNotch1_q.x100Visible = false;
            this.ctlNumExCurNotch1_q.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCurNotch1_q.x10Visible = true;
            // 
            // ctlNumExCurNotch1_d
            // 
            this.ctlNumExCurNotch1_d.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExCurNotch1_d, "ctlNumExCurNotch1_d");
            this.ctlNumExCurNotch1_d.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch1_d.DataId = 0;
            this.ctlNumExCurNotch1_d.IntValue = 0;
            this.ctlNumExCurNotch1_d.Name = "ctlNumExCurNotch1_d";
            this.ctlNumExCurNotch1_d.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExCurNotch1_d.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExCurNotch1_d.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExCurNotch1_d.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch1_d.NumMaximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.ctlNumExCurNotch1_d.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCurNotch1_d.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCurNotch1_d.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExCurNotch1_d.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExCurNotch1_d.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch1_d.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch1_d.TitleHeight = 25;
            this.ctlNumExCurNotch1_d.TitleVisible = true;
            this.ctlNumExCurNotch1_d.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExCurNotch1_d.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch1_d.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch1_d.UnitHeight = 20;
            this.ctlNumExCurNotch1_d.UnitVisible = true;
            this.ctlNumExCurNotch1_d.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCurNotch1_d.x100Visible = false;
            this.ctlNumExCurNotch1_d.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCurNotch1_d.x10Visible = true;
            // 
            // ctlNumExCurNotch1_f
            // 
            this.ctlNumExCurNotch1_f.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExCurNotch1_f, "ctlNumExCurNotch1_f");
            this.ctlNumExCurNotch1_f.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch1_f.DataId = 0;
            this.ctlNumExCurNotch1_f.IntValue = 0;
            this.ctlNumExCurNotch1_f.Name = "ctlNumExCurNotch1_f";
            this.ctlNumExCurNotch1_f.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExCurNotch1_f.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExCurNotch1_f.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExCurNotch1_f.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch1_f.NumMaximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.ctlNumExCurNotch1_f.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCurNotch1_f.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCurNotch1_f.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExCurNotch1_f.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExCurNotch1_f.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch1_f.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch1_f.TitleHeight = 25;
            this.ctlNumExCurNotch1_f.TitleVisible = true;
            this.ctlNumExCurNotch1_f.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExCurNotch1_f.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch1_f.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch1_f.UnitHeight = 20;
            this.ctlNumExCurNotch1_f.UnitVisible = true;
            this.ctlNumExCurNotch1_f.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCurNotch1_f.x100Visible = false;
            this.ctlNumExCurNotch1_f.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCurNotch1_f.x10Visible = true;
            // 
            // grpCurNotchEx2
            // 
            this.grpCurNotchEx2.Controls.Add(this.ctlNumExCurNotch2_q);
            this.grpCurNotchEx2.Controls.Add(this.ctlNumExCurNotch2_d);
            this.grpCurNotchEx2.Controls.Add(this.ctlNumExCurNotch2_f);
            resources.ApplyResources(this.grpCurNotchEx2, "grpCurNotchEx2");
            this.grpCurNotchEx2.Name = "grpCurNotchEx2";
            this.grpCurNotchEx2.TabStop = false;
            // 
            // ctlNumExCurNotch2_q
            // 
            this.ctlNumExCurNotch2_q.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExCurNotch2_q, "ctlNumExCurNotch2_q");
            this.ctlNumExCurNotch2_q.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch2_q.DataId = 0;
            this.ctlNumExCurNotch2_q.IntValue = 0;
            this.ctlNumExCurNotch2_q.Name = "ctlNumExCurNotch2_q";
            this.ctlNumExCurNotch2_q.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExCurNotch2_q.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExCurNotch2_q.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExCurNotch2_q.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch2_q.NumMaximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.ctlNumExCurNotch2_q.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCurNotch2_q.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCurNotch2_q.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExCurNotch2_q.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExCurNotch2_q.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch2_q.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch2_q.TitleHeight = 25;
            this.ctlNumExCurNotch2_q.TitleVisible = true;
            this.ctlNumExCurNotch2_q.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExCurNotch2_q.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch2_q.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch2_q.UnitHeight = 20;
            this.ctlNumExCurNotch2_q.UnitVisible = true;
            this.ctlNumExCurNotch2_q.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCurNotch2_q.x100Visible = false;
            this.ctlNumExCurNotch2_q.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCurNotch2_q.x10Visible = true;
            // 
            // ctlNumExCurNotch2_d
            // 
            this.ctlNumExCurNotch2_d.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExCurNotch2_d, "ctlNumExCurNotch2_d");
            this.ctlNumExCurNotch2_d.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch2_d.DataId = 0;
            this.ctlNumExCurNotch2_d.IntValue = 0;
            this.ctlNumExCurNotch2_d.Name = "ctlNumExCurNotch2_d";
            this.ctlNumExCurNotch2_d.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExCurNotch2_d.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExCurNotch2_d.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExCurNotch2_d.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch2_d.NumMaximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.ctlNumExCurNotch2_d.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCurNotch2_d.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCurNotch2_d.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExCurNotch2_d.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExCurNotch2_d.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch2_d.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch2_d.TitleHeight = 25;
            this.ctlNumExCurNotch2_d.TitleVisible = true;
            this.ctlNumExCurNotch2_d.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExCurNotch2_d.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch2_d.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch2_d.UnitHeight = 20;
            this.ctlNumExCurNotch2_d.UnitVisible = true;
            this.ctlNumExCurNotch2_d.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCurNotch2_d.x100Visible = false;
            this.ctlNumExCurNotch2_d.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCurNotch2_d.x10Visible = true;
            // 
            // ctlNumExCurNotch2_f
            // 
            this.ctlNumExCurNotch2_f.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExCurNotch2_f, "ctlNumExCurNotch2_f");
            this.ctlNumExCurNotch2_f.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch2_f.DataId = 0;
            this.ctlNumExCurNotch2_f.IntValue = 0;
            this.ctlNumExCurNotch2_f.Name = "ctlNumExCurNotch2_f";
            this.ctlNumExCurNotch2_f.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExCurNotch2_f.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExCurNotch2_f.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExCurNotch2_f.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch2_f.NumMaximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.ctlNumExCurNotch2_f.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCurNotch2_f.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCurNotch2_f.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExCurNotch2_f.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExCurNotch2_f.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch2_f.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch2_f.TitleHeight = 25;
            this.ctlNumExCurNotch2_f.TitleVisible = true;
            this.ctlNumExCurNotch2_f.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExCurNotch2_f.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch2_f.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch2_f.UnitHeight = 20;
            this.ctlNumExCurNotch2_f.UnitVisible = true;
            this.ctlNumExCurNotch2_f.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCurNotch2_f.x100Visible = false;
            this.ctlNumExCurNotch2_f.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCurNotch2_f.x10Visible = true;
            // 
            // grpCurNotchEx3
            // 
            this.grpCurNotchEx3.Controls.Add(this.ctlNumExCurNotch3_q);
            this.grpCurNotchEx3.Controls.Add(this.ctlNumExCurNotch3_d);
            this.grpCurNotchEx3.Controls.Add(this.ctlNumExCurNotch3_f);
            resources.ApplyResources(this.grpCurNotchEx3, "grpCurNotchEx3");
            this.grpCurNotchEx3.Name = "grpCurNotchEx3";
            this.grpCurNotchEx3.TabStop = false;
            // 
            // ctlNumExCurNotch3_q
            // 
            this.ctlNumExCurNotch3_q.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExCurNotch3_q, "ctlNumExCurNotch3_q");
            this.ctlNumExCurNotch3_q.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch3_q.DataId = 0;
            this.ctlNumExCurNotch3_q.IntValue = 0;
            this.ctlNumExCurNotch3_q.Name = "ctlNumExCurNotch3_q";
            this.ctlNumExCurNotch3_q.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExCurNotch3_q.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExCurNotch3_q.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExCurNotch3_q.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch3_q.NumMaximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.ctlNumExCurNotch3_q.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCurNotch3_q.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCurNotch3_q.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExCurNotch3_q.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExCurNotch3_q.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch3_q.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch3_q.TitleHeight = 25;
            this.ctlNumExCurNotch3_q.TitleVisible = true;
            this.ctlNumExCurNotch3_q.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExCurNotch3_q.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch3_q.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch3_q.UnitHeight = 20;
            this.ctlNumExCurNotch3_q.UnitVisible = true;
            this.ctlNumExCurNotch3_q.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCurNotch3_q.x100Visible = false;
            this.ctlNumExCurNotch3_q.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCurNotch3_q.x10Visible = true;
            // 
            // ctlNumExCurNotch3_d
            // 
            this.ctlNumExCurNotch3_d.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExCurNotch3_d, "ctlNumExCurNotch3_d");
            this.ctlNumExCurNotch3_d.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch3_d.DataId = 0;
            this.ctlNumExCurNotch3_d.IntValue = 0;
            this.ctlNumExCurNotch3_d.Name = "ctlNumExCurNotch3_d";
            this.ctlNumExCurNotch3_d.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExCurNotch3_d.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExCurNotch3_d.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExCurNotch3_d.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch3_d.NumMaximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.ctlNumExCurNotch3_d.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCurNotch3_d.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCurNotch3_d.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExCurNotch3_d.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExCurNotch3_d.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch3_d.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch3_d.TitleHeight = 25;
            this.ctlNumExCurNotch3_d.TitleVisible = true;
            this.ctlNumExCurNotch3_d.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExCurNotch3_d.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch3_d.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch3_d.UnitHeight = 20;
            this.ctlNumExCurNotch3_d.UnitVisible = true;
            this.ctlNumExCurNotch3_d.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCurNotch3_d.x100Visible = false;
            this.ctlNumExCurNotch3_d.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCurNotch3_d.x10Visible = true;
            // 
            // ctlNumExCurNotch3_f
            // 
            this.ctlNumExCurNotch3_f.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExCurNotch3_f, "ctlNumExCurNotch3_f");
            this.ctlNumExCurNotch3_f.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch3_f.DataId = 0;
            this.ctlNumExCurNotch3_f.IntValue = 0;
            this.ctlNumExCurNotch3_f.Name = "ctlNumExCurNotch3_f";
            this.ctlNumExCurNotch3_f.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExCurNotch3_f.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExCurNotch3_f.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExCurNotch3_f.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch3_f.NumMaximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.ctlNumExCurNotch3_f.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCurNotch3_f.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCurNotch3_f.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExCurNotch3_f.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExCurNotch3_f.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch3_f.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch3_f.TitleHeight = 25;
            this.ctlNumExCurNotch3_f.TitleVisible = true;
            this.ctlNumExCurNotch3_f.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExCurNotch3_f.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch3_f.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch3_f.UnitHeight = 20;
            this.ctlNumExCurNotch3_f.UnitVisible = true;
            this.ctlNumExCurNotch3_f.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCurNotch3_f.x100Visible = false;
            this.ctlNumExCurNotch3_f.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCurNotch3_f.x10Visible = true;
            // 
            // grpCurNotchEx4
            // 
            this.grpCurNotchEx4.Controls.Add(this.ctlNumExCurNotch4_q);
            this.grpCurNotchEx4.Controls.Add(this.ctlNumExCurNotch4_d);
            this.grpCurNotchEx4.Controls.Add(this.ctlNumExCurNotch4_f);
            resources.ApplyResources(this.grpCurNotchEx4, "grpCurNotchEx4");
            this.grpCurNotchEx4.Name = "grpCurNotchEx4";
            this.grpCurNotchEx4.TabStop = false;
            // 
            // ctlNumExCurNotch4_q
            // 
            this.ctlNumExCurNotch4_q.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExCurNotch4_q, "ctlNumExCurNotch4_q");
            this.ctlNumExCurNotch4_q.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch4_q.DataId = 0;
            this.ctlNumExCurNotch4_q.IntValue = 0;
            this.ctlNumExCurNotch4_q.Name = "ctlNumExCurNotch4_q";
            this.ctlNumExCurNotch4_q.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExCurNotch4_q.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExCurNotch4_q.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExCurNotch4_q.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch4_q.NumMaximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.ctlNumExCurNotch4_q.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCurNotch4_q.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCurNotch4_q.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExCurNotch4_q.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExCurNotch4_q.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch4_q.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch4_q.TitleHeight = 25;
            this.ctlNumExCurNotch4_q.TitleVisible = true;
            this.ctlNumExCurNotch4_q.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExCurNotch4_q.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch4_q.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch4_q.UnitHeight = 20;
            this.ctlNumExCurNotch4_q.UnitVisible = true;
            this.ctlNumExCurNotch4_q.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCurNotch4_q.x100Visible = false;
            this.ctlNumExCurNotch4_q.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCurNotch4_q.x10Visible = true;
            // 
            // ctlNumExCurNotch4_d
            // 
            this.ctlNumExCurNotch4_d.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExCurNotch4_d, "ctlNumExCurNotch4_d");
            this.ctlNumExCurNotch4_d.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch4_d.DataId = 0;
            this.ctlNumExCurNotch4_d.IntValue = 0;
            this.ctlNumExCurNotch4_d.Name = "ctlNumExCurNotch4_d";
            this.ctlNumExCurNotch4_d.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExCurNotch4_d.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExCurNotch4_d.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExCurNotch4_d.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch4_d.NumMaximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.ctlNumExCurNotch4_d.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCurNotch4_d.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCurNotch4_d.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExCurNotch4_d.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExCurNotch4_d.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch4_d.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch4_d.TitleHeight = 25;
            this.ctlNumExCurNotch4_d.TitleVisible = true;
            this.ctlNumExCurNotch4_d.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExCurNotch4_d.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch4_d.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch4_d.UnitHeight = 20;
            this.ctlNumExCurNotch4_d.UnitVisible = true;
            this.ctlNumExCurNotch4_d.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCurNotch4_d.x100Visible = false;
            this.ctlNumExCurNotch4_d.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCurNotch4_d.x10Visible = true;
            // 
            // ctlNumExCurNotch4_f
            // 
            this.ctlNumExCurNotch4_f.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExCurNotch4_f, "ctlNumExCurNotch4_f");
            this.ctlNumExCurNotch4_f.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch4_f.DataId = 0;
            this.ctlNumExCurNotch4_f.IntValue = 0;
            this.ctlNumExCurNotch4_f.Name = "ctlNumExCurNotch4_f";
            this.ctlNumExCurNotch4_f.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExCurNotch4_f.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExCurNotch4_f.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExCurNotch4_f.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch4_f.NumMaximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.ctlNumExCurNotch4_f.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCurNotch4_f.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCurNotch4_f.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExCurNotch4_f.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExCurNotch4_f.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch4_f.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch4_f.TitleHeight = 25;
            this.ctlNumExCurNotch4_f.TitleVisible = true;
            this.ctlNumExCurNotch4_f.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExCurNotch4_f.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch4_f.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch4_f.UnitHeight = 20;
            this.ctlNumExCurNotch4_f.UnitVisible = true;
            this.ctlNumExCurNotch4_f.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCurNotch4_f.x100Visible = false;
            this.ctlNumExCurNotch4_f.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCurNotch4_f.x10Visible = true;
            // 
            // grpCurNotchEx5
            // 
            this.grpCurNotchEx5.Controls.Add(this.ctlNumExCurNotch5_q);
            this.grpCurNotchEx5.Controls.Add(this.ctlNumExCurNotch5_d);
            this.grpCurNotchEx5.Controls.Add(this.ctlNumExCurNotch5_f);
            resources.ApplyResources(this.grpCurNotchEx5, "grpCurNotchEx5");
            this.grpCurNotchEx5.Name = "grpCurNotchEx5";
            this.grpCurNotchEx5.TabStop = false;
            // 
            // ctlNumExCurNotch5_q
            // 
            this.ctlNumExCurNotch5_q.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExCurNotch5_q, "ctlNumExCurNotch5_q");
            this.ctlNumExCurNotch5_q.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch5_q.DataId = 0;
            this.ctlNumExCurNotch5_q.IntValue = 0;
            this.ctlNumExCurNotch5_q.Name = "ctlNumExCurNotch5_q";
            this.ctlNumExCurNotch5_q.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExCurNotch5_q.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExCurNotch5_q.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExCurNotch5_q.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch5_q.NumMaximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.ctlNumExCurNotch5_q.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCurNotch5_q.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCurNotch5_q.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExCurNotch5_q.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExCurNotch5_q.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch5_q.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch5_q.TitleHeight = 25;
            this.ctlNumExCurNotch5_q.TitleVisible = true;
            this.ctlNumExCurNotch5_q.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExCurNotch5_q.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch5_q.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch5_q.UnitHeight = 20;
            this.ctlNumExCurNotch5_q.UnitVisible = true;
            this.ctlNumExCurNotch5_q.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCurNotch5_q.x100Visible = false;
            this.ctlNumExCurNotch5_q.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCurNotch5_q.x10Visible = true;
            // 
            // ctlNumExCurNotch5_d
            // 
            this.ctlNumExCurNotch5_d.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExCurNotch5_d, "ctlNumExCurNotch5_d");
            this.ctlNumExCurNotch5_d.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch5_d.DataId = 0;
            this.ctlNumExCurNotch5_d.IntValue = 0;
            this.ctlNumExCurNotch5_d.Name = "ctlNumExCurNotch5_d";
            this.ctlNumExCurNotch5_d.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExCurNotch5_d.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExCurNotch5_d.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExCurNotch5_d.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch5_d.NumMaximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.ctlNumExCurNotch5_d.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCurNotch5_d.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCurNotch5_d.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExCurNotch5_d.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExCurNotch5_d.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch5_d.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch5_d.TitleHeight = 25;
            this.ctlNumExCurNotch5_d.TitleVisible = true;
            this.ctlNumExCurNotch5_d.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExCurNotch5_d.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch5_d.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch5_d.UnitHeight = 20;
            this.ctlNumExCurNotch5_d.UnitVisible = true;
            this.ctlNumExCurNotch5_d.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCurNotch5_d.x100Visible = false;
            this.ctlNumExCurNotch5_d.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCurNotch5_d.x10Visible = true;
            // 
            // ctlNumExCurNotch5_f
            // 
            this.ctlNumExCurNotch5_f.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExCurNotch5_f, "ctlNumExCurNotch5_f");
            this.ctlNumExCurNotch5_f.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch5_f.DataId = 0;
            this.ctlNumExCurNotch5_f.IntValue = 0;
            this.ctlNumExCurNotch5_f.Name = "ctlNumExCurNotch5_f";
            this.ctlNumExCurNotch5_f.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExCurNotch5_f.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExCurNotch5_f.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExCurNotch5_f.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch5_f.NumMaximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.ctlNumExCurNotch5_f.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCurNotch5_f.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCurNotch5_f.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExCurNotch5_f.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExCurNotch5_f.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch5_f.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch5_f.TitleHeight = 25;
            this.ctlNumExCurNotch5_f.TitleVisible = true;
            this.ctlNumExCurNotch5_f.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExCurNotch5_f.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurNotch5_f.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurNotch5_f.UnitHeight = 20;
            this.ctlNumExCurNotch5_f.UnitVisible = true;
            this.ctlNumExCurNotch5_f.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCurNotch5_f.x100Visible = false;
            this.ctlNumExCurNotch5_f.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCurNotch5_f.x10Visible = true;
            // 
            // tabServoGain
            // 
            resources.ApplyResources(this.tabServoGain, "tabServoGain");
            this.tabServoGain.Controls.Add(this.tabPageServoGain);
            this.tabServoGain.Controls.Add(this.tabPageCurrentFillter);
            this.tabServoGain.Controls.Add(this.tabPageVelocityFillter);
            this.tabServoGain.Controls.Add(this.tabPagePositionFillter);
            this.tabServoGain.Controls.Add(this.tabPageFriction);
            this.tabServoGain.Controls.Add(this.tabPageTorqueObserver);
            this.tabServoGain.Controls.Add(this.tabPageVelocityObserver);
            this.tabServoGain.Controls.Add(this.tabPageModel);
            this.tabServoGain.Controls.Add(this.tabPageFeedback);
            this.tabServoGain.Controls.Add(this.tabPageFeedforward);
            this.tabServoGain.Multiline = true;
            this.tabServoGain.Name = "tabServoGain";
            this.tabServoGain.SelectedIndex = 0;
            this.tabServoGain.TabStop = false;
            this.tabServoGain.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabServoGain_DrawItem);
            // 
            // tabPageServoGain
            // 
            this.tabPageServoGain.BackColor = System.Drawing.Color.Transparent;
            this.tabPageServoGain.Controls.Add(this.fpnlServoGain);
            resources.ApplyResources(this.tabPageServoGain, "tabPageServoGain");
            this.tabPageServoGain.Name = "tabPageServoGain";
            this.tabPageServoGain.UseVisualStyleBackColor = true;
            // 
            // tabPageCurrentFillter
            // 
            this.tabPageCurrentFillter.BackColor = System.Drawing.Color.Transparent;
            this.tabPageCurrentFillter.Controls.Add(this.fpnlCurrentFillter);
            resources.ApplyResources(this.tabPageCurrentFillter, "tabPageCurrentFillter");
            this.tabPageCurrentFillter.Name = "tabPageCurrentFillter";
            this.tabPageCurrentFillter.UseVisualStyleBackColor = true;
            // 
            // tabPageVelocityFillter
            // 
            this.tabPageVelocityFillter.BackColor = System.Drawing.Color.Transparent;
            this.tabPageVelocityFillter.Controls.Add(this.fpnlVelocityFillter);
            resources.ApplyResources(this.tabPageVelocityFillter, "tabPageVelocityFillter");
            this.tabPageVelocityFillter.Name = "tabPageVelocityFillter";
            this.tabPageVelocityFillter.UseVisualStyleBackColor = true;
            // 
            // fpnlVelocityFillter
            // 
            resources.ApplyResources(this.fpnlVelocityFillter, "fpnlVelocityFillter");
            this.fpnlVelocityFillter.BackColor = System.Drawing.SystemColors.Control;
            this.fpnlVelocityFillter.Controls.Add(this.grpVelLpfEx);
            this.fpnlVelocityFillter.Controls.Add(this.grpVelNotchEx1);
            this.fpnlVelocityFillter.Name = "fpnlVelocityFillter";
            this.fpnlVelocityFillter.Click += new System.EventHandler(this.fpnlGain_Click);
            // 
            // grpVelLpfEx
            // 
            this.grpVelLpfEx.Controls.Add(this.ctlNumExVelLpf);
            this.grpVelLpfEx.Controls.Add(this.lblVelLPF3);
            this.grpVelLpfEx.Controls.Add(this.chkVelLPF1);
            resources.ApplyResources(this.grpVelLpfEx, "grpVelLpfEx");
            this.grpVelLpfEx.Name = "grpVelLpfEx";
            this.grpVelLpfEx.TabStop = false;
            // 
            // ctlNumExVelLpf
            // 
            this.ctlNumExVelLpf.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExVelLpf, "ctlNumExVelLpf");
            this.ctlNumExVelLpf.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExVelLpf.DataId = 0;
            this.ctlNumExVelLpf.IntValue = 0;
            this.ctlNumExVelLpf.Name = "ctlNumExVelLpf";
            this.ctlNumExVelLpf.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExVelLpf.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExVelLpf.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExVelLpf.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExVelLpf.NumMaximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.ctlNumExVelLpf.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExVelLpf.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExVelLpf.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExVelLpf.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExVelLpf.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExVelLpf.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExVelLpf.TitleHeight = 25;
            this.ctlNumExVelLpf.TitleVisible = true;
            this.ctlNumExVelLpf.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExVelLpf.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExVelLpf.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExVelLpf.UnitHeight = 20;
            this.ctlNumExVelLpf.UnitVisible = true;
            this.ctlNumExVelLpf.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExVelLpf.x100Visible = false;
            this.ctlNumExVelLpf.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExVelLpf.x10Visible = true;
            // 
            // lblVelLPF3
            // 
            resources.ApplyResources(this.lblVelLPF3, "lblVelLPF3");
            this.lblVelLPF3.ForeColor = System.Drawing.Color.Crimson;
            this.lblVelLPF3.Name = "lblVelLPF3";
            // 
            // chkVelLPF1
            // 
            resources.ApplyResources(this.chkVelLPF1, "chkVelLPF1");
            this.chkVelLPF1.Name = "chkVelLPF1";
            this.chkVelLPF1.UseVisualStyleBackColor = true;
            this.chkVelLPF1.CheckStateChanged += new System.EventHandler(this.chkVelLPF_CheckStateChanged);
            // 
            // grpVelNotchEx1
            // 
            this.grpVelNotchEx1.Controls.Add(this.ctlNumExVelNotch1_q);
            this.grpVelNotchEx1.Controls.Add(this.ctlNumExVelNotch1_d);
            this.grpVelNotchEx1.Controls.Add(this.ctlNumExVelNotch1_f);
            resources.ApplyResources(this.grpVelNotchEx1, "grpVelNotchEx1");
            this.grpVelNotchEx1.Name = "grpVelNotchEx1";
            this.grpVelNotchEx1.TabStop = false;
            // 
            // ctlNumExVelNotch1_q
            // 
            this.ctlNumExVelNotch1_q.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExVelNotch1_q, "ctlNumExVelNotch1_q");
            this.ctlNumExVelNotch1_q.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExVelNotch1_q.DataId = 0;
            this.ctlNumExVelNotch1_q.IntValue = 0;
            this.ctlNumExVelNotch1_q.Name = "ctlNumExVelNotch1_q";
            this.ctlNumExVelNotch1_q.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExVelNotch1_q.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExVelNotch1_q.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExVelNotch1_q.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExVelNotch1_q.NumMaximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.ctlNumExVelNotch1_q.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExVelNotch1_q.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExVelNotch1_q.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExVelNotch1_q.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExVelNotch1_q.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExVelNotch1_q.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExVelNotch1_q.TitleHeight = 25;
            this.ctlNumExVelNotch1_q.TitleVisible = true;
            this.ctlNumExVelNotch1_q.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExVelNotch1_q.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExVelNotch1_q.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExVelNotch1_q.UnitHeight = 20;
            this.ctlNumExVelNotch1_q.UnitVisible = true;
            this.ctlNumExVelNotch1_q.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExVelNotch1_q.x100Visible = false;
            this.ctlNumExVelNotch1_q.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExVelNotch1_q.x10Visible = true;
            // 
            // ctlNumExVelNotch1_d
            // 
            this.ctlNumExVelNotch1_d.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExVelNotch1_d, "ctlNumExVelNotch1_d");
            this.ctlNumExVelNotch1_d.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExVelNotch1_d.DataId = 0;
            this.ctlNumExVelNotch1_d.IntValue = 0;
            this.ctlNumExVelNotch1_d.Name = "ctlNumExVelNotch1_d";
            this.ctlNumExVelNotch1_d.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExVelNotch1_d.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExVelNotch1_d.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExVelNotch1_d.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExVelNotch1_d.NumMaximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.ctlNumExVelNotch1_d.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExVelNotch1_d.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExVelNotch1_d.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExVelNotch1_d.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExVelNotch1_d.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExVelNotch1_d.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExVelNotch1_d.TitleHeight = 25;
            this.ctlNumExVelNotch1_d.TitleVisible = true;
            this.ctlNumExVelNotch1_d.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExVelNotch1_d.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExVelNotch1_d.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExVelNotch1_d.UnitHeight = 20;
            this.ctlNumExVelNotch1_d.UnitVisible = true;
            this.ctlNumExVelNotch1_d.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExVelNotch1_d.x100Visible = false;
            this.ctlNumExVelNotch1_d.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExVelNotch1_d.x10Visible = true;
            // 
            // ctlNumExVelNotch1_f
            // 
            this.ctlNumExVelNotch1_f.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExVelNotch1_f, "ctlNumExVelNotch1_f");
            this.ctlNumExVelNotch1_f.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExVelNotch1_f.DataId = 0;
            this.ctlNumExVelNotch1_f.IntValue = 0;
            this.ctlNumExVelNotch1_f.Name = "ctlNumExVelNotch1_f";
            this.ctlNumExVelNotch1_f.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExVelNotch1_f.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExVelNotch1_f.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExVelNotch1_f.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExVelNotch1_f.NumMaximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.ctlNumExVelNotch1_f.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExVelNotch1_f.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExVelNotch1_f.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExVelNotch1_f.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExVelNotch1_f.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExVelNotch1_f.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExVelNotch1_f.TitleHeight = 25;
            this.ctlNumExVelNotch1_f.TitleVisible = true;
            this.ctlNumExVelNotch1_f.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExVelNotch1_f.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExVelNotch1_f.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExVelNotch1_f.UnitHeight = 20;
            this.ctlNumExVelNotch1_f.UnitVisible = true;
            this.ctlNumExVelNotch1_f.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExVelNotch1_f.x100Visible = false;
            this.ctlNumExVelNotch1_f.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExVelNotch1_f.x10Visible = true;
            // 
            // tabPagePositionFillter
            // 
            this.tabPagePositionFillter.BackColor = System.Drawing.Color.Transparent;
            this.tabPagePositionFillter.Controls.Add(this.fpnlPositionFillter);
            resources.ApplyResources(this.tabPagePositionFillter, "tabPagePositionFillter");
            this.tabPagePositionFillter.Name = "tabPagePositionFillter";
            this.tabPagePositionFillter.UseVisualStyleBackColor = true;
            // 
            // fpnlPositionFillter
            // 
            resources.ApplyResources(this.fpnlPositionFillter, "fpnlPositionFillter");
            this.fpnlPositionFillter.BackColor = System.Drawing.SystemColors.Control;
            this.fpnlPositionFillter.Controls.Add(this.grpPosLpfEx);
            this.fpnlPositionFillter.Controls.Add(this.grpPosNotchEx1);
            this.fpnlPositionFillter.Name = "fpnlPositionFillter";
            this.fpnlPositionFillter.Click += new System.EventHandler(this.fpnlGain_Click);
            // 
            // grpPosLpfEx
            // 
            this.grpPosLpfEx.Controls.Add(this.ctlNumExPosLpf);
            this.grpPosLpfEx.Controls.Add(this.lblPosLPF3);
            this.grpPosLpfEx.Controls.Add(this.chkPosLPF1);
            resources.ApplyResources(this.grpPosLpfEx, "grpPosLpfEx");
            this.grpPosLpfEx.Name = "grpPosLpfEx";
            this.grpPosLpfEx.TabStop = false;
            // 
            // ctlNumExPosLpf
            // 
            this.ctlNumExPosLpf.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExPosLpf, "ctlNumExPosLpf");
            this.ctlNumExPosLpf.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExPosLpf.DataId = 0;
            this.ctlNumExPosLpf.IntValue = 0;
            this.ctlNumExPosLpf.Name = "ctlNumExPosLpf";
            this.ctlNumExPosLpf.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExPosLpf.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExPosLpf.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExPosLpf.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExPosLpf.NumMaximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.ctlNumExPosLpf.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExPosLpf.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExPosLpf.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExPosLpf.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExPosLpf.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExPosLpf.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExPosLpf.TitleHeight = 25;
            this.ctlNumExPosLpf.TitleVisible = true;
            this.ctlNumExPosLpf.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExPosLpf.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExPosLpf.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExPosLpf.UnitHeight = 20;
            this.ctlNumExPosLpf.UnitVisible = true;
            this.ctlNumExPosLpf.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExPosLpf.x100Visible = false;
            this.ctlNumExPosLpf.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExPosLpf.x10Visible = true;
            // 
            // lblPosLPF3
            // 
            resources.ApplyResources(this.lblPosLPF3, "lblPosLPF3");
            this.lblPosLPF3.ForeColor = System.Drawing.Color.Crimson;
            this.lblPosLPF3.Name = "lblPosLPF3";
            // 
            // chkPosLPF1
            // 
            resources.ApplyResources(this.chkPosLPF1, "chkPosLPF1");
            this.chkPosLPF1.Name = "chkPosLPF1";
            this.chkPosLPF1.UseVisualStyleBackColor = true;
            this.chkPosLPF1.CheckStateChanged += new System.EventHandler(this.chkPosLPF_CheckStateChanged);
            // 
            // grpPosNotchEx1
            // 
            this.grpPosNotchEx1.Controls.Add(this.ctlNumExPosNotch1_q);
            this.grpPosNotchEx1.Controls.Add(this.ctlNumExPosNotch1_d);
            this.grpPosNotchEx1.Controls.Add(this.ctlNumExPosNotch1_f);
            resources.ApplyResources(this.grpPosNotchEx1, "grpPosNotchEx1");
            this.grpPosNotchEx1.Name = "grpPosNotchEx1";
            this.grpPosNotchEx1.TabStop = false;
            // 
            // ctlNumExPosNotch1_q
            // 
            this.ctlNumExPosNotch1_q.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExPosNotch1_q, "ctlNumExPosNotch1_q");
            this.ctlNumExPosNotch1_q.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExPosNotch1_q.DataId = 0;
            this.ctlNumExPosNotch1_q.IntValue = 0;
            this.ctlNumExPosNotch1_q.Name = "ctlNumExPosNotch1_q";
            this.ctlNumExPosNotch1_q.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExPosNotch1_q.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExPosNotch1_q.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExPosNotch1_q.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExPosNotch1_q.NumMaximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.ctlNumExPosNotch1_q.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExPosNotch1_q.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExPosNotch1_q.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExPosNotch1_q.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExPosNotch1_q.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExPosNotch1_q.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExPosNotch1_q.TitleHeight = 25;
            this.ctlNumExPosNotch1_q.TitleVisible = true;
            this.ctlNumExPosNotch1_q.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExPosNotch1_q.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExPosNotch1_q.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExPosNotch1_q.UnitHeight = 20;
            this.ctlNumExPosNotch1_q.UnitVisible = true;
            this.ctlNumExPosNotch1_q.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExPosNotch1_q.x100Visible = false;
            this.ctlNumExPosNotch1_q.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExPosNotch1_q.x10Visible = true;
            // 
            // ctlNumExPosNotch1_d
            // 
            this.ctlNumExPosNotch1_d.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExPosNotch1_d, "ctlNumExPosNotch1_d");
            this.ctlNumExPosNotch1_d.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExPosNotch1_d.DataId = 0;
            this.ctlNumExPosNotch1_d.IntValue = 0;
            this.ctlNumExPosNotch1_d.Name = "ctlNumExPosNotch1_d";
            this.ctlNumExPosNotch1_d.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExPosNotch1_d.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExPosNotch1_d.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExPosNotch1_d.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExPosNotch1_d.NumMaximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.ctlNumExPosNotch1_d.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExPosNotch1_d.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExPosNotch1_d.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExPosNotch1_d.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExPosNotch1_d.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExPosNotch1_d.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExPosNotch1_d.TitleHeight = 25;
            this.ctlNumExPosNotch1_d.TitleVisible = true;
            this.ctlNumExPosNotch1_d.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExPosNotch1_d.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExPosNotch1_d.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExPosNotch1_d.UnitHeight = 20;
            this.ctlNumExPosNotch1_d.UnitVisible = true;
            this.ctlNumExPosNotch1_d.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExPosNotch1_d.x100Visible = false;
            this.ctlNumExPosNotch1_d.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExPosNotch1_d.x10Visible = true;
            // 
            // ctlNumExPosNotch1_f
            // 
            this.ctlNumExPosNotch1_f.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExPosNotch1_f, "ctlNumExPosNotch1_f");
            this.ctlNumExPosNotch1_f.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExPosNotch1_f.DataId = 0;
            this.ctlNumExPosNotch1_f.IntValue = 0;
            this.ctlNumExPosNotch1_f.Name = "ctlNumExPosNotch1_f";
            this.ctlNumExPosNotch1_f.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExPosNotch1_f.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExPosNotch1_f.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExPosNotch1_f.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExPosNotch1_f.NumMaximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.ctlNumExPosNotch1_f.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExPosNotch1_f.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExPosNotch1_f.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExPosNotch1_f.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExPosNotch1_f.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExPosNotch1_f.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExPosNotch1_f.TitleHeight = 25;
            this.ctlNumExPosNotch1_f.TitleVisible = true;
            this.ctlNumExPosNotch1_f.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExPosNotch1_f.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExPosNotch1_f.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExPosNotch1_f.UnitHeight = 20;
            this.ctlNumExPosNotch1_f.UnitVisible = true;
            this.ctlNumExPosNotch1_f.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExPosNotch1_f.x100Visible = false;
            this.ctlNumExPosNotch1_f.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExPosNotch1_f.x10Visible = true;
            // 
            // tabPageFriction
            // 
            this.tabPageFriction.BackColor = System.Drawing.Color.Transparent;
            this.tabPageFriction.Controls.Add(this.fpnlFriction);
            resources.ApplyResources(this.tabPageFriction, "tabPageFriction");
            this.tabPageFriction.Name = "tabPageFriction";
            this.tabPageFriction.UseVisualStyleBackColor = true;
            // 
            // fpnlFriction
            // 
            resources.ApplyResources(this.fpnlFriction, "fpnlFriction");
            this.fpnlFriction.BackColor = System.Drawing.SystemColors.Control;
            this.fpnlFriction.Controls.Add(this.grpFriction);
            this.fpnlFriction.Name = "fpnlFriction";
            this.fpnlFriction.Click += new System.EventHandler(this.fpnlGain_Click);
            // 
            // grpFriction
            // 
            this.grpFriction.Controls.Add(this.ctlNumExGravity);
            this.grpFriction.Controls.Add(this.ctlNumExDynamic);
            this.grpFriction.Controls.Add(this.ctlNumExCcwTrq);
            this.grpFriction.Controls.Add(this.ctlNumExCwTrq);
            resources.ApplyResources(this.grpFriction, "grpFriction");
            this.grpFriction.Name = "grpFriction";
            this.grpFriction.TabStop = false;
            // 
            // ctlNumExGravity
            // 
            this.ctlNumExGravity.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExGravity, "ctlNumExGravity");
            this.ctlNumExGravity.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExGravity.DataId = 0;
            this.ctlNumExGravity.IntValue = 0;
            this.ctlNumExGravity.Name = "ctlNumExGravity";
            this.ctlNumExGravity.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExGravity.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExGravity.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExGravity.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExGravity.NumMaximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ctlNumExGravity.NumMinimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.ctlNumExGravity.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExGravity.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExGravity.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExGravity.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExGravity.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExGravity.TitleHeight = 25;
            this.ctlNumExGravity.TitleVisible = true;
            this.ctlNumExGravity.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExGravity.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExGravity.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExGravity.UnitHeight = 20;
            this.ctlNumExGravity.UnitVisible = true;
            this.ctlNumExGravity.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExGravity.x100Visible = false;
            this.ctlNumExGravity.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExGravity.x10Visible = true;
            // 
            // ctlNumExDynamic
            // 
            this.ctlNumExDynamic.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExDynamic, "ctlNumExDynamic");
            this.ctlNumExDynamic.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExDynamic.DataId = 0;
            this.ctlNumExDynamic.IntValue = 0;
            this.ctlNumExDynamic.Name = "ctlNumExDynamic";
            this.ctlNumExDynamic.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExDynamic.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExDynamic.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExDynamic.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExDynamic.NumMaximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.ctlNumExDynamic.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExDynamic.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExDynamic.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExDynamic.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExDynamic.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExDynamic.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExDynamic.TitleHeight = 25;
            this.ctlNumExDynamic.TitleVisible = true;
            this.ctlNumExDynamic.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExDynamic.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExDynamic.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExDynamic.UnitHeight = 20;
            this.ctlNumExDynamic.UnitVisible = true;
            this.ctlNumExDynamic.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExDynamic.x100Visible = false;
            this.ctlNumExDynamic.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExDynamic.x10Visible = true;
            // 
            // ctlNumExCcwTrq
            // 
            this.ctlNumExCcwTrq.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExCcwTrq, "ctlNumExCcwTrq");
            this.ctlNumExCcwTrq.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCcwTrq.DataId = 0;
            this.ctlNumExCcwTrq.IntValue = 0;
            this.ctlNumExCcwTrq.Name = "ctlNumExCcwTrq";
            this.ctlNumExCcwTrq.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExCcwTrq.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExCcwTrq.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExCcwTrq.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCcwTrq.NumMaximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ctlNumExCcwTrq.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCcwTrq.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCcwTrq.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExCcwTrq.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExCcwTrq.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCcwTrq.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCcwTrq.TitleHeight = 25;
            this.ctlNumExCcwTrq.TitleVisible = true;
            this.ctlNumExCcwTrq.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExCcwTrq.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCcwTrq.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCcwTrq.UnitHeight = 20;
            this.ctlNumExCcwTrq.UnitVisible = true;
            this.ctlNumExCcwTrq.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCcwTrq.x100Visible = false;
            this.ctlNumExCcwTrq.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCcwTrq.x10Visible = true;
            // 
            // ctlNumExCwTrq
            // 
            this.ctlNumExCwTrq.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExCwTrq, "ctlNumExCwTrq");
            this.ctlNumExCwTrq.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCwTrq.DataId = 0;
            this.ctlNumExCwTrq.IntValue = 0;
            this.ctlNumExCwTrq.Name = "ctlNumExCwTrq";
            this.ctlNumExCwTrq.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExCwTrq.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExCwTrq.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExCwTrq.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCwTrq.NumMaximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ctlNumExCwTrq.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCwTrq.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCwTrq.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExCwTrq.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExCwTrq.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCwTrq.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCwTrq.TitleHeight = 25;
            this.ctlNumExCwTrq.TitleVisible = true;
            this.ctlNumExCwTrq.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExCwTrq.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCwTrq.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCwTrq.UnitHeight = 20;
            this.ctlNumExCwTrq.UnitVisible = true;
            this.ctlNumExCwTrq.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCwTrq.x100Visible = false;
            this.ctlNumExCwTrq.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCwTrq.x10Visible = true;
            // 
            // tabPageTorqueObserver
            // 
            this.tabPageTorqueObserver.BackColor = System.Drawing.Color.Transparent;
            this.tabPageTorqueObserver.Controls.Add(this.fpnlTorqueObserver);
            resources.ApplyResources(this.tabPageTorqueObserver, "tabPageTorqueObserver");
            this.tabPageTorqueObserver.Name = "tabPageTorqueObserver";
            this.tabPageTorqueObserver.UseVisualStyleBackColor = true;
            // 
            // fpnlTorqueObserver
            // 
            resources.ApplyResources(this.fpnlTorqueObserver, "fpnlTorqueObserver");
            this.fpnlTorqueObserver.BackColor = System.Drawing.SystemColors.Control;
            this.fpnlTorqueObserver.Controls.Add(this.grpTrqOvsEx);
            this.fpnlTorqueObserver.Name = "fpnlTorqueObserver";
            this.fpnlTorqueObserver.Click += new System.EventHandler(this.fpnlGain_Click);
            // 
            // grpTrqOvsEx
            // 
            this.grpTrqOvsEx.Controls.Add(this.ctlNumExTrqObsFrq);
            this.grpTrqOvsEx.Controls.Add(this.ctlNumExTrqObsGain);
            this.grpTrqOvsEx.Controls.Add(this.chkTorqueObserverEnable1);
            resources.ApplyResources(this.grpTrqOvsEx, "grpTrqOvsEx");
            this.grpTrqOvsEx.Name = "grpTrqOvsEx";
            this.grpTrqOvsEx.TabStop = false;
            // 
            // ctlNumExTrqObsFrq
            // 
            this.ctlNumExTrqObsFrq.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExTrqObsFrq, "ctlNumExTrqObsFrq");
            this.ctlNumExTrqObsFrq.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExTrqObsFrq.DataId = 0;
            this.ctlNumExTrqObsFrq.IntValue = 0;
            this.ctlNumExTrqObsFrq.Name = "ctlNumExTrqObsFrq";
            this.ctlNumExTrqObsFrq.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExTrqObsFrq.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExTrqObsFrq.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExTrqObsFrq.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExTrqObsFrq.NumMaximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.ctlNumExTrqObsFrq.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExTrqObsFrq.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExTrqObsFrq.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExTrqObsFrq.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExTrqObsFrq.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExTrqObsFrq.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExTrqObsFrq.TitleHeight = 25;
            this.ctlNumExTrqObsFrq.TitleVisible = true;
            this.ctlNumExTrqObsFrq.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExTrqObsFrq.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExTrqObsFrq.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExTrqObsFrq.UnitHeight = 20;
            this.ctlNumExTrqObsFrq.UnitVisible = true;
            this.ctlNumExTrqObsFrq.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExTrqObsFrq.x100Visible = false;
            this.ctlNumExTrqObsFrq.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExTrqObsFrq.x10Visible = true;
            // 
            // ctlNumExTrqObsGain
            // 
            this.ctlNumExTrqObsGain.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExTrqObsGain, "ctlNumExTrqObsGain");
            this.ctlNumExTrqObsGain.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExTrqObsGain.DataId = 0;
            this.ctlNumExTrqObsGain.IntValue = 0;
            this.ctlNumExTrqObsGain.Name = "ctlNumExTrqObsGain";
            this.ctlNumExTrqObsGain.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExTrqObsGain.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExTrqObsGain.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExTrqObsGain.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExTrqObsGain.NumMaximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ctlNumExTrqObsGain.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExTrqObsGain.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExTrqObsGain.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExTrqObsGain.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExTrqObsGain.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExTrqObsGain.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExTrqObsGain.TitleHeight = 25;
            this.ctlNumExTrqObsGain.TitleVisible = true;
            this.ctlNumExTrqObsGain.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExTrqObsGain.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExTrqObsGain.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExTrqObsGain.UnitHeight = 20;
            this.ctlNumExTrqObsGain.UnitVisible = true;
            this.ctlNumExTrqObsGain.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExTrqObsGain.x100Visible = false;
            this.ctlNumExTrqObsGain.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExTrqObsGain.x10Visible = true;
            // 
            // chkTorqueObserverEnable1
            // 
            resources.ApplyResources(this.chkTorqueObserverEnable1, "chkTorqueObserverEnable1");
            this.chkTorqueObserverEnable1.Name = "chkTorqueObserverEnable1";
            this.chkTorqueObserverEnable1.UseVisualStyleBackColor = true;
            this.chkTorqueObserverEnable1.CheckStateChanged += new System.EventHandler(this.chkTorqueObserverEnable_CheckStateChanged);
            // 
            // tabPageVelocityObserver
            // 
            this.tabPageVelocityObserver.BackColor = System.Drawing.Color.Transparent;
            this.tabPageVelocityObserver.Controls.Add(this.fpnlVelocityObserver);
            resources.ApplyResources(this.tabPageVelocityObserver, "tabPageVelocityObserver");
            this.tabPageVelocityObserver.Name = "tabPageVelocityObserver";
            this.tabPageVelocityObserver.UseVisualStyleBackColor = true;
            // 
            // fpnlVelocityObserver
            // 
            resources.ApplyResources(this.fpnlVelocityObserver, "fpnlVelocityObserver");
            this.fpnlVelocityObserver.BackColor = System.Drawing.SystemColors.Control;
            this.fpnlVelocityObserver.Controls.Add(this.grpVelOvsEx);
            this.fpnlVelocityObserver.Name = "fpnlVelocityObserver";
            this.fpnlVelocityObserver.Click += new System.EventHandler(this.fpnlGain_Click);
            // 
            // grpVelOvsEx
            // 
            this.grpVelOvsEx.Controls.Add(this.ctlNumExVelObsTdisComp);
            this.grpVelOvsEx.Controls.Add(this.ctlNumExVelObsVelComp);
            this.grpVelOvsEx.Controls.Add(this.chkVelocityObserverTdisEnable1);
            this.grpVelOvsEx.Controls.Add(this.ctlNumExVelObsTime);
            this.grpVelOvsEx.Controls.Add(this.chkVelocityObserverEnable1);
            resources.ApplyResources(this.grpVelOvsEx, "grpVelOvsEx");
            this.grpVelOvsEx.Name = "grpVelOvsEx";
            this.grpVelOvsEx.TabStop = false;
            // 
            // ctlNumExVelObsTdisComp
            // 
            this.ctlNumExVelObsTdisComp.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExVelObsTdisComp, "ctlNumExVelObsTdisComp");
            this.ctlNumExVelObsTdisComp.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExVelObsTdisComp.DataId = 0;
            this.ctlNumExVelObsTdisComp.IntValue = 0;
            this.ctlNumExVelObsTdisComp.Name = "ctlNumExVelObsTdisComp";
            this.ctlNumExVelObsTdisComp.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExVelObsTdisComp.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExVelObsTdisComp.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExVelObsTdisComp.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExVelObsTdisComp.NumMaximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ctlNumExVelObsTdisComp.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExVelObsTdisComp.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExVelObsTdisComp.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExVelObsTdisComp.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExVelObsTdisComp.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExVelObsTdisComp.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExVelObsTdisComp.TitleHeight = 25;
            this.ctlNumExVelObsTdisComp.TitleVisible = true;
            this.ctlNumExVelObsTdisComp.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExVelObsTdisComp.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExVelObsTdisComp.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExVelObsTdisComp.UnitHeight = 20;
            this.ctlNumExVelObsTdisComp.UnitVisible = true;
            this.ctlNumExVelObsTdisComp.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExVelObsTdisComp.x100Visible = false;
            this.ctlNumExVelObsTdisComp.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExVelObsTdisComp.x10Visible = true;
            // 
            // ctlNumExVelObsVelComp
            // 
            this.ctlNumExVelObsVelComp.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExVelObsVelComp, "ctlNumExVelObsVelComp");
            this.ctlNumExVelObsVelComp.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExVelObsVelComp.DataId = 0;
            this.ctlNumExVelObsVelComp.IntValue = 0;
            this.ctlNumExVelObsVelComp.Name = "ctlNumExVelObsVelComp";
            this.ctlNumExVelObsVelComp.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExVelObsVelComp.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExVelObsVelComp.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExVelObsVelComp.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExVelObsVelComp.NumMaximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ctlNumExVelObsVelComp.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExVelObsVelComp.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExVelObsVelComp.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExVelObsVelComp.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExVelObsVelComp.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExVelObsVelComp.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExVelObsVelComp.TitleHeight = 25;
            this.ctlNumExVelObsVelComp.TitleVisible = true;
            this.ctlNumExVelObsVelComp.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExVelObsVelComp.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExVelObsVelComp.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExVelObsVelComp.UnitHeight = 20;
            this.ctlNumExVelObsVelComp.UnitVisible = true;
            this.ctlNumExVelObsVelComp.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExVelObsVelComp.x100Visible = false;
            this.ctlNumExVelObsVelComp.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExVelObsVelComp.x10Visible = true;
            // 
            // chkVelocityObserverTdisEnable1
            // 
            resources.ApplyResources(this.chkVelocityObserverTdisEnable1, "chkVelocityObserverTdisEnable1");
            this.chkVelocityObserverTdisEnable1.Name = "chkVelocityObserverTdisEnable1";
            this.chkVelocityObserverTdisEnable1.UseVisualStyleBackColor = true;
            this.chkVelocityObserverTdisEnable1.CheckStateChanged += new System.EventHandler(this.chkVelocityObserverTdisEnable_CheckStateChanged);
            // 
            // ctlNumExVelObsTime
            // 
            this.ctlNumExVelObsTime.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExVelObsTime, "ctlNumExVelObsTime");
            this.ctlNumExVelObsTime.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExVelObsTime.DataId = 0;
            this.ctlNumExVelObsTime.IntValue = 0;
            this.ctlNumExVelObsTime.Name = "ctlNumExVelObsTime";
            this.ctlNumExVelObsTime.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExVelObsTime.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExVelObsTime.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExVelObsTime.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExVelObsTime.NumMaximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.ctlNumExVelObsTime.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExVelObsTime.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExVelObsTime.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExVelObsTime.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExVelObsTime.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExVelObsTime.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExVelObsTime.TitleHeight = 25;
            this.ctlNumExVelObsTime.TitleVisible = true;
            this.ctlNumExVelObsTime.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExVelObsTime.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExVelObsTime.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExVelObsTime.UnitHeight = 20;
            this.ctlNumExVelObsTime.UnitVisible = true;
            this.ctlNumExVelObsTime.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExVelObsTime.x100Visible = false;
            this.ctlNumExVelObsTime.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExVelObsTime.x10Visible = true;
            // 
            // chkVelocityObserverEnable1
            // 
            resources.ApplyResources(this.chkVelocityObserverEnable1, "chkVelocityObserverEnable1");
            this.chkVelocityObserverEnable1.Name = "chkVelocityObserverEnable1";
            this.chkVelocityObserverEnable1.UseVisualStyleBackColor = true;
            this.chkVelocityObserverEnable1.CheckStateChanged += new System.EventHandler(this.chkVelocityObserverEnable_CheckStateChanged);
            // 
            // tabPageModel
            // 
            this.tabPageModel.BackColor = System.Drawing.Color.Transparent;
            this.tabPageModel.Controls.Add(this.fpnlModel);
            resources.ApplyResources(this.tabPageModel, "tabPageModel");
            this.tabPageModel.Name = "tabPageModel";
            this.tabPageModel.UseVisualStyleBackColor = true;
            // 
            // fpnlModel
            // 
            resources.ApplyResources(this.fpnlModel, "fpnlModel");
            this.fpnlModel.BackColor = System.Drawing.SystemColors.Control;
            this.fpnlModel.Controls.Add(this.grpModelEx);
            this.fpnlModel.Name = "fpnlModel";
            this.fpnlModel.Click += new System.EventHandler(this.fpnlGain_Click);
            // 
            // grpModelEx
            // 
            this.grpModelEx.Controls.Add(this.ctlNumExModelFillter1);
            this.grpModelEx.Controls.Add(this.chkModelControlMotorModel1);
            this.grpModelEx.Controls.Add(this.ctlNumExModelGain3);
            this.grpModelEx.Controls.Add(this.ctlNumExModelGain2);
            this.grpModelEx.Controls.Add(this.ctlNumExModelGain1);
            this.grpModelEx.Controls.Add(this.chkModelControlEnable1);
            resources.ApplyResources(this.grpModelEx, "grpModelEx");
            this.grpModelEx.Name = "grpModelEx";
            this.grpModelEx.TabStop = false;
            // 
            // ctlNumExModelFillter1
            // 
            this.ctlNumExModelFillter1.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExModelFillter1, "ctlNumExModelFillter1");
            this.ctlNumExModelFillter1.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExModelFillter1.DataId = 0;
            this.ctlNumExModelFillter1.IntValue = 0;
            this.ctlNumExModelFillter1.Name = "ctlNumExModelFillter1";
            this.ctlNumExModelFillter1.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExModelFillter1.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExModelFillter1.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExModelFillter1.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExModelFillter1.NumMaximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.ctlNumExModelFillter1.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExModelFillter1.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExModelFillter1.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExModelFillter1.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExModelFillter1.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExModelFillter1.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExModelFillter1.TitleHeight = 25;
            this.ctlNumExModelFillter1.TitleVisible = true;
            this.ctlNumExModelFillter1.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExModelFillter1.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExModelFillter1.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExModelFillter1.UnitHeight = 20;
            this.ctlNumExModelFillter1.UnitVisible = true;
            this.ctlNumExModelFillter1.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExModelFillter1.x100Visible = false;
            this.ctlNumExModelFillter1.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExModelFillter1.x10Visible = true;
            // 
            // chkModelControlMotorModel1
            // 
            resources.ApplyResources(this.chkModelControlMotorModel1, "chkModelControlMotorModel1");
            this.chkModelControlMotorModel1.Name = "chkModelControlMotorModel1";
            this.chkModelControlMotorModel1.UseVisualStyleBackColor = true;
            this.chkModelControlMotorModel1.CheckStateChanged += new System.EventHandler(this.chkModelControlMotorModel_CheckStateChanged);
            // 
            // ctlNumExModelGain3
            // 
            this.ctlNumExModelGain3.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExModelGain3, "ctlNumExModelGain3");
            this.ctlNumExModelGain3.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExModelGain3.DataId = 0;
            this.ctlNumExModelGain3.IntValue = 0;
            this.ctlNumExModelGain3.Name = "ctlNumExModelGain3";
            this.ctlNumExModelGain3.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExModelGain3.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExModelGain3.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExModelGain3.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExModelGain3.NumMaximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.ctlNumExModelGain3.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExModelGain3.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExModelGain3.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExModelGain3.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExModelGain3.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExModelGain3.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExModelGain3.TitleHeight = 25;
            this.ctlNumExModelGain3.TitleVisible = true;
            this.ctlNumExModelGain3.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExModelGain3.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExModelGain3.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExModelGain3.UnitHeight = 20;
            this.ctlNumExModelGain3.UnitVisible = true;
            this.ctlNumExModelGain3.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExModelGain3.x100Visible = false;
            this.ctlNumExModelGain3.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExModelGain3.x10Visible = true;
            // 
            // ctlNumExModelGain2
            // 
            this.ctlNumExModelGain2.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExModelGain2, "ctlNumExModelGain2");
            this.ctlNumExModelGain2.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExModelGain2.DataId = 0;
            this.ctlNumExModelGain2.IntValue = 0;
            this.ctlNumExModelGain2.Name = "ctlNumExModelGain2";
            this.ctlNumExModelGain2.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExModelGain2.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExModelGain2.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExModelGain2.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExModelGain2.NumMaximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.ctlNumExModelGain2.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExModelGain2.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExModelGain2.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExModelGain2.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExModelGain2.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExModelGain2.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExModelGain2.TitleHeight = 25;
            this.ctlNumExModelGain2.TitleVisible = true;
            this.ctlNumExModelGain2.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExModelGain2.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExModelGain2.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExModelGain2.UnitHeight = 20;
            this.ctlNumExModelGain2.UnitVisible = true;
            this.ctlNumExModelGain2.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExModelGain2.x100Visible = false;
            this.ctlNumExModelGain2.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExModelGain2.x10Visible = true;
            // 
            // ctlNumExModelGain1
            // 
            this.ctlNumExModelGain1.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExModelGain1, "ctlNumExModelGain1");
            this.ctlNumExModelGain1.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExModelGain1.DataId = 0;
            this.ctlNumExModelGain1.IntValue = 0;
            this.ctlNumExModelGain1.Name = "ctlNumExModelGain1";
            this.ctlNumExModelGain1.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExModelGain1.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExModelGain1.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExModelGain1.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExModelGain1.NumMaximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.ctlNumExModelGain1.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExModelGain1.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExModelGain1.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExModelGain1.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExModelGain1.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExModelGain1.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExModelGain1.TitleHeight = 25;
            this.ctlNumExModelGain1.TitleVisible = true;
            this.ctlNumExModelGain1.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExModelGain1.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExModelGain1.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExModelGain1.UnitHeight = 20;
            this.ctlNumExModelGain1.UnitVisible = true;
            this.ctlNumExModelGain1.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExModelGain1.x100Visible = false;
            this.ctlNumExModelGain1.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExModelGain1.x10Visible = true;
            // 
            // chkModelControlEnable1
            // 
            resources.ApplyResources(this.chkModelControlEnable1, "chkModelControlEnable1");
            this.chkModelControlEnable1.Name = "chkModelControlEnable1";
            this.chkModelControlEnable1.UseVisualStyleBackColor = true;
            this.chkModelControlEnable1.CheckStateChanged += new System.EventHandler(this.chkModelControlEnable_CheckStateChanged);
            // 
            // tabPageFeedback
            // 
            this.tabPageFeedback.BackColor = System.Drawing.Color.Transparent;
            this.tabPageFeedback.Controls.Add(this.fpnlFeedbackFillter);
            resources.ApplyResources(this.tabPageFeedback, "tabPageFeedback");
            this.tabPageFeedback.Name = "tabPageFeedback";
            this.tabPageFeedback.UseVisualStyleBackColor = true;
            this.tabPageFeedback.Click += new System.EventHandler(this.fpnlGain_Click);
            // 
            // fpnlFeedbackFillter
            // 
            this.fpnlFeedbackFillter.BackColor = System.Drawing.SystemColors.Control;
            this.fpnlFeedbackFillter.Controls.Add(this.grpVelFBEx);
            this.fpnlFeedbackFillter.Controls.Add(this.grpPosFBEx);
            this.fpnlFeedbackFillter.Controls.Add(this.grpCurLpfFB);
            this.fpnlFeedbackFillter.Controls.Add(this.grpVelLpfFB);
            resources.ApplyResources(this.fpnlFeedbackFillter, "fpnlFeedbackFillter");
            this.fpnlFeedbackFillter.Name = "fpnlFeedbackFillter";
            this.fpnlFeedbackFillter.Click += new System.EventHandler(this.fpnlGain_Click);
            // 
            // grpVelFBEx
            // 
            this.grpVelFBEx.Controls.Add(this.lblVelFBEx);
            this.grpVelFBEx.Controls.Add(this.ctlNumExVelFB);
            resources.ApplyResources(this.grpVelFBEx, "grpVelFBEx");
            this.grpVelFBEx.Name = "grpVelFBEx";
            this.grpVelFBEx.TabStop = false;
            // 
            // lblVelFBEx
            // 
            resources.ApplyResources(this.lblVelFBEx, "lblVelFBEx");
            this.lblVelFBEx.ForeColor = System.Drawing.Color.Crimson;
            this.lblVelFBEx.Name = "lblVelFBEx";
            // 
            // ctlNumExVelFB
            // 
            this.ctlNumExVelFB.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExVelFB, "ctlNumExVelFB");
            this.ctlNumExVelFB.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExVelFB.DataId = 0;
            this.ctlNumExVelFB.IntValue = 0;
            this.ctlNumExVelFB.Name = "ctlNumExVelFB";
            this.ctlNumExVelFB.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExVelFB.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExVelFB.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExVelFB.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExVelFB.NumMaximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.ctlNumExVelFB.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExVelFB.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExVelFB.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExVelFB.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExVelFB.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExVelFB.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExVelFB.TitleHeight = 25;
            this.ctlNumExVelFB.TitleVisible = true;
            this.ctlNumExVelFB.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExVelFB.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExVelFB.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExVelFB.UnitHeight = 20;
            this.ctlNumExVelFB.UnitVisible = true;
            this.ctlNumExVelFB.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExVelFB.x100Visible = false;
            this.ctlNumExVelFB.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExVelFB.x10Visible = true;
            // 
            // grpPosFBEx
            // 
            this.grpPosFBEx.Controls.Add(this.lblPosFBEx);
            this.grpPosFBEx.Controls.Add(this.ctlNumExPosFB);
            resources.ApplyResources(this.grpPosFBEx, "grpPosFBEx");
            this.grpPosFBEx.Name = "grpPosFBEx";
            this.grpPosFBEx.TabStop = false;
            // 
            // lblPosFBEx
            // 
            resources.ApplyResources(this.lblPosFBEx, "lblPosFBEx");
            this.lblPosFBEx.ForeColor = System.Drawing.Color.Crimson;
            this.lblPosFBEx.Name = "lblPosFBEx";
            // 
            // ctlNumExPosFB
            // 
            this.ctlNumExPosFB.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExPosFB, "ctlNumExPosFB");
            this.ctlNumExPosFB.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExPosFB.DataId = 0;
            this.ctlNumExPosFB.IntValue = 0;
            this.ctlNumExPosFB.Name = "ctlNumExPosFB";
            this.ctlNumExPosFB.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExPosFB.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExPosFB.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExPosFB.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExPosFB.NumMaximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.ctlNumExPosFB.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExPosFB.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExPosFB.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExPosFB.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExPosFB.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExPosFB.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExPosFB.TitleHeight = 25;
            this.ctlNumExPosFB.TitleVisible = true;
            this.ctlNumExPosFB.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExPosFB.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExPosFB.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExPosFB.UnitHeight = 20;
            this.ctlNumExPosFB.UnitVisible = true;
            this.ctlNumExPosFB.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExPosFB.x100Visible = false;
            this.ctlNumExPosFB.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExPosFB.x10Visible = true;
            // 
            // grpCurLpfFB
            // 
            this.grpCurLpfFB.Controls.Add(this.ctlNumExCurLpfFB);
            resources.ApplyResources(this.grpCurLpfFB, "grpCurLpfFB");
            this.grpCurLpfFB.Name = "grpCurLpfFB";
            this.grpCurLpfFB.TabStop = false;
            // 
            // ctlNumExCurLpfFB
            // 
            this.ctlNumExCurLpfFB.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExCurLpfFB, "ctlNumExCurLpfFB");
            this.ctlNumExCurLpfFB.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurLpfFB.DataId = 0;
            this.ctlNumExCurLpfFB.IntValue = 0;
            this.ctlNumExCurLpfFB.Name = "ctlNumExCurLpfFB";
            this.ctlNumExCurLpfFB.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExCurLpfFB.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExCurLpfFB.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExCurLpfFB.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurLpfFB.NumMaximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.ctlNumExCurLpfFB.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCurLpfFB.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExCurLpfFB.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExCurLpfFB.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExCurLpfFB.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurLpfFB.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurLpfFB.TitleHeight = 25;
            this.ctlNumExCurLpfFB.TitleVisible = true;
            this.ctlNumExCurLpfFB.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExCurLpfFB.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExCurLpfFB.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExCurLpfFB.UnitHeight = 20;
            this.ctlNumExCurLpfFB.UnitVisible = true;
            this.ctlNumExCurLpfFB.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCurLpfFB.x100Visible = false;
            this.ctlNumExCurLpfFB.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExCurLpfFB.x10Visible = true;
            // 
            // grpVelLpfFB
            // 
            this.grpVelLpfFB.Controls.Add(this.ctlNumExVelLpfFB);
            resources.ApplyResources(this.grpVelLpfFB, "grpVelLpfFB");
            this.grpVelLpfFB.Name = "grpVelLpfFB";
            this.grpVelLpfFB.TabStop = false;
            // 
            // ctlNumExVelLpfFB
            // 
            this.ctlNumExVelLpfFB.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExVelLpfFB, "ctlNumExVelLpfFB");
            this.ctlNumExVelLpfFB.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExVelLpfFB.DataId = 0;
            this.ctlNumExVelLpfFB.IntValue = 0;
            this.ctlNumExVelLpfFB.Name = "ctlNumExVelLpfFB";
            this.ctlNumExVelLpfFB.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExVelLpfFB.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExVelLpfFB.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExVelLpfFB.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExVelLpfFB.NumMaximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.ctlNumExVelLpfFB.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExVelLpfFB.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExVelLpfFB.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExVelLpfFB.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExVelLpfFB.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExVelLpfFB.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExVelLpfFB.TitleHeight = 25;
            this.ctlNumExVelLpfFB.TitleVisible = true;
            this.ctlNumExVelLpfFB.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExVelLpfFB.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExVelLpfFB.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExVelLpfFB.UnitHeight = 20;
            this.ctlNumExVelLpfFB.UnitVisible = true;
            this.ctlNumExVelLpfFB.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExVelLpfFB.x100Visible = false;
            this.ctlNumExVelLpfFB.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExVelLpfFB.x10Visible = true;
            // 
            // tabPageFeedforward
            // 
            this.tabPageFeedforward.BackColor = System.Drawing.Color.Transparent;
            this.tabPageFeedforward.Controls.Add(this.fpnlFeedforward);
            resources.ApplyResources(this.tabPageFeedforward, "tabPageFeedforward");
            this.tabPageFeedforward.Name = "tabPageFeedforward";
            this.tabPageFeedforward.UseVisualStyleBackColor = true;
            // 
            // fpnlFeedforward
            // 
            resources.ApplyResources(this.fpnlFeedforward, "fpnlFeedforward");
            this.fpnlFeedforward.BackColor = System.Drawing.SystemColors.Control;
            this.fpnlFeedforward.Controls.Add(this.grpPosFF);
            this.fpnlFeedforward.Controls.Add(this.grpVelFF);
            this.fpnlFeedforward.Name = "fpnlFeedforward";
            this.fpnlFeedforward.Click += new System.EventHandler(this.fpnlGain_Click);
            // 
            // grpPosFF
            // 
            this.grpPosFF.Controls.Add(this.ctlNumExPosFFGain);
            resources.ApplyResources(this.grpPosFF, "grpPosFF");
            this.grpPosFF.Name = "grpPosFF";
            this.grpPosFF.TabStop = false;
            // 
            // ctlNumExPosFFGain
            // 
            this.ctlNumExPosFFGain.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExPosFFGain, "ctlNumExPosFFGain");
            this.ctlNumExPosFFGain.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExPosFFGain.DataId = 0;
            this.ctlNumExPosFFGain.IntValue = 0;
            this.ctlNumExPosFFGain.Name = "ctlNumExPosFFGain";
            this.ctlNumExPosFFGain.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExPosFFGain.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExPosFFGain.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExPosFFGain.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExPosFFGain.NumMaximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.ctlNumExPosFFGain.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExPosFFGain.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExPosFFGain.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExPosFFGain.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExPosFFGain.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExPosFFGain.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExPosFFGain.TitleHeight = 25;
            this.ctlNumExPosFFGain.TitleVisible = true;
            this.ctlNumExPosFFGain.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExPosFFGain.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExPosFFGain.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExPosFFGain.UnitHeight = 20;
            this.ctlNumExPosFFGain.UnitVisible = true;
            this.ctlNumExPosFFGain.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExPosFFGain.x100Visible = false;
            this.ctlNumExPosFFGain.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExPosFFGain.x10Visible = true;
            // 
            // grpVelFF
            // 
            this.grpVelFF.Controls.Add(this.lblVelFFFillter);
            this.grpVelFF.Controls.Add(this.lblVelFFPeriod);
            this.grpVelFF.Controls.Add(this.ctlNumExVelFFFillter);
            this.grpVelFF.Controls.Add(this.ctlNumExVelFFPeriod);
            this.grpVelFF.Controls.Add(this.ctlNumExVelFFGain);
            resources.ApplyResources(this.grpVelFF, "grpVelFF");
            this.grpVelFF.Name = "grpVelFF";
            this.grpVelFF.TabStop = false;
            // 
            // lblVelFFFillter
            // 
            resources.ApplyResources(this.lblVelFFFillter, "lblVelFFFillter");
            this.lblVelFFFillter.ForeColor = System.Drawing.Color.Black;
            this.lblVelFFFillter.Name = "lblVelFFFillter";
            // 
            // lblVelFFPeriod
            // 
            resources.ApplyResources(this.lblVelFFPeriod, "lblVelFFPeriod");
            this.lblVelFFPeriod.ForeColor = System.Drawing.Color.Black;
            this.lblVelFFPeriod.Name = "lblVelFFPeriod";
            // 
            // ctlNumExVelFFFillter
            // 
            this.ctlNumExVelFFFillter.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExVelFFFillter, "ctlNumExVelFFFillter");
            this.ctlNumExVelFFFillter.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExVelFFFillter.DataId = 0;
            this.ctlNumExVelFFFillter.IntValue = 0;
            this.ctlNumExVelFFFillter.Name = "ctlNumExVelFFFillter";
            this.ctlNumExVelFFFillter.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExVelFFFillter.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExVelFFFillter.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExVelFFFillter.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExVelFFFillter.NumMaximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.ctlNumExVelFFFillter.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExVelFFFillter.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExVelFFFillter.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExVelFFFillter.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExVelFFFillter.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExVelFFFillter.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExVelFFFillter.TitleHeight = 25;
            this.ctlNumExVelFFFillter.TitleVisible = true;
            this.ctlNumExVelFFFillter.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExVelFFFillter.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExVelFFFillter.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExVelFFFillter.UnitHeight = 20;
            this.ctlNumExVelFFFillter.UnitVisible = true;
            this.ctlNumExVelFFFillter.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExVelFFFillter.x100Visible = false;
            this.ctlNumExVelFFFillter.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExVelFFFillter.x10Visible = false;
            // 
            // ctlNumExVelFFPeriod
            // 
            this.ctlNumExVelFFPeriod.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExVelFFPeriod, "ctlNumExVelFFPeriod");
            this.ctlNumExVelFFPeriod.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExVelFFPeriod.DataId = 0;
            this.ctlNumExVelFFPeriod.IntValue = 0;
            this.ctlNumExVelFFPeriod.Name = "ctlNumExVelFFPeriod";
            this.ctlNumExVelFFPeriod.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExVelFFPeriod.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExVelFFPeriod.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExVelFFPeriod.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExVelFFPeriod.NumMaximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.ctlNumExVelFFPeriod.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExVelFFPeriod.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExVelFFPeriod.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExVelFFPeriod.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExVelFFPeriod.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExVelFFPeriod.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExVelFFPeriod.TitleHeight = 25;
            this.ctlNumExVelFFPeriod.TitleVisible = true;
            this.ctlNumExVelFFPeriod.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExVelFFPeriod.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExVelFFPeriod.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExVelFFPeriod.UnitHeight = 20;
            this.ctlNumExVelFFPeriod.UnitVisible = true;
            this.ctlNumExVelFFPeriod.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExVelFFPeriod.x100Visible = false;
            this.ctlNumExVelFFPeriod.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExVelFFPeriod.x10Visible = false;
            // 
            // ctlNumExVelFFGain
            // 
            this.ctlNumExVelFFGain.ActiveBackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.ctlNumExVelFFGain, "ctlNumExVelFFGain");
            this.ctlNumExVelFFGain.BackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExVelFFGain.DataId = 0;
            this.ctlNumExVelFFGain.IntValue = 0;
            this.ctlNumExVelFFGain.Name = "ctlNumExVelFFGain";
            this.ctlNumExVelFFGain.NumActiveColor = System.Drawing.Color.DarkRed;
            this.ctlNumExVelFFGain.NumBackColor = System.Drawing.SystemColors.Window;
            this.ctlNumExVelFFGain.NumEditColor = System.Drawing.Color.Red;
            this.ctlNumExVelFFGain.NumForeColor = System.Drawing.Color.Navy;
            this.ctlNumExVelFFGain.NumMaximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.ctlNumExVelFFGain.NumMinimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExVelFFGain.NumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlNumExVelFFGain.NunmFont = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlNumExVelFFGain.TitleAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctlNumExVelFFGain.TitleBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExVelFFGain.TitleForeColor = System.Drawing.Color.Navy;
            this.ctlNumExVelFFGain.TitleHeight = 25;
            this.ctlNumExVelFFGain.TitleVisible = true;
            this.ctlNumExVelFFGain.UnitAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ctlNumExVelFFGain.UnitBackColor = System.Drawing.SystemColors.Control;
            this.ctlNumExVelFFGain.UnitForeColor = System.Drawing.Color.Navy;
            this.ctlNumExVelFFGain.UnitHeight = 20;
            this.ctlNumExVelFFGain.UnitVisible = true;
            this.ctlNumExVelFFGain.x100Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExVelFFGain.x100Visible = false;
            this.ctlNumExVelFFGain.x10Font = new System.Drawing.Font("メイリオ", 7F);
            this.ctlNumExVelFFGain.x10Visible = true;
            // 
            // TimerResize
            // 
            this.TimerResize.Interval = 500;
            this.TimerResize.Tick += new System.EventHandler(this.TimerResize_Tick);
            // 
            // TimerSave
            // 
            this.TimerSave.Interval = 1000;
            this.TimerSave.Tick += new System.EventHandler(this.TimerSave_Tick);
            // 
            // GainControlForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabServoGain);
            this.Controls.Add(this.toolStripGain);
            this.DoubleBuffered = true;
            this.Name = "GainControlForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.GainControlForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GainControlForm_FormClosing);
            this.Resize += new System.EventHandler(this.GainControlForm_Resize);
            this.fpnlServoGain.ResumeLayout(false);
            this.grpPosEx.ResumeLayout(false);
            this.grpPosEx.PerformLayout();
            this.grpVelEx.ResumeLayout(false);
            this.grpVelEx.PerformLayout();
            this.grpLoadEx.ResumeLayout(false);
            this.grpLoadEx.PerformLayout();
            this.grpTuningFree.ResumeLayout(false);
            this.grpTuningFree.PerformLayout();
            this.toolStripGain.ResumeLayout(false);
            this.toolStripGain.PerformLayout();
            this.fpnlCurrentFillter.ResumeLayout(false);
            this.grpCurLpfEx.ResumeLayout(false);
            this.grpCurLpfEx.PerformLayout();
            this.grpCurNotchEx1.ResumeLayout(false);
            this.grpCurNotchEx1.PerformLayout();
            this.grpCurNotchEx2.ResumeLayout(false);
            this.grpCurNotchEx2.PerformLayout();
            this.grpCurNotchEx3.ResumeLayout(false);
            this.grpCurNotchEx3.PerformLayout();
            this.grpCurNotchEx4.ResumeLayout(false);
            this.grpCurNotchEx4.PerformLayout();
            this.grpCurNotchEx5.ResumeLayout(false);
            this.grpCurNotchEx5.PerformLayout();
            this.tabServoGain.ResumeLayout(false);
            this.tabPageServoGain.ResumeLayout(false);
            this.tabPageCurrentFillter.ResumeLayout(false);
            this.tabPageVelocityFillter.ResumeLayout(false);
            this.fpnlVelocityFillter.ResumeLayout(false);
            this.grpVelLpfEx.ResumeLayout(false);
            this.grpVelLpfEx.PerformLayout();
            this.grpVelNotchEx1.ResumeLayout(false);
            this.grpVelNotchEx1.PerformLayout();
            this.tabPagePositionFillter.ResumeLayout(false);
            this.fpnlPositionFillter.ResumeLayout(false);
            this.grpPosLpfEx.ResumeLayout(false);
            this.grpPosLpfEx.PerformLayout();
            this.grpPosNotchEx1.ResumeLayout(false);
            this.grpPosNotchEx1.PerformLayout();
            this.tabPageFriction.ResumeLayout(false);
            this.fpnlFriction.ResumeLayout(false);
            this.grpFriction.ResumeLayout(false);
            this.grpFriction.PerformLayout();
            this.tabPageTorqueObserver.ResumeLayout(false);
            this.fpnlTorqueObserver.ResumeLayout(false);
            this.grpTrqOvsEx.ResumeLayout(false);
            this.grpTrqOvsEx.PerformLayout();
            this.tabPageVelocityObserver.ResumeLayout(false);
            this.fpnlVelocityObserver.ResumeLayout(false);
            this.grpVelOvsEx.ResumeLayout(false);
            this.grpVelOvsEx.PerformLayout();
            this.tabPageModel.ResumeLayout(false);
            this.fpnlModel.ResumeLayout(false);
            this.grpModelEx.ResumeLayout(false);
            this.grpModelEx.PerformLayout();
            this.tabPageFeedback.ResumeLayout(false);
            this.fpnlFeedbackFillter.ResumeLayout(false);
            this.grpVelFBEx.ResumeLayout(false);
            this.grpVelFBEx.PerformLayout();
            this.grpPosFBEx.ResumeLayout(false);
            this.grpPosFBEx.PerformLayout();
            this.grpCurLpfFB.ResumeLayout(false);
            this.grpCurLpfFB.PerformLayout();
            this.grpVelLpfFB.ResumeLayout(false);
            this.grpVelLpfFB.PerformLayout();
            this.tabPageFeedforward.ResumeLayout(false);
            this.fpnlFeedforward.ResumeLayout(false);
            this.grpPosFF.ResumeLayout(false);
            this.grpPosFF.PerformLayout();
            this.grpVelFF.ResumeLayout(false);
            this.grpVelFF.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel fpnlServoGain;
		private System.Windows.Forms.ToolStrip toolStripGain;
		private System.Windows.Forms.ToolStripSeparator sep1;
		private System.Windows.Forms.ToolStripButton tbtnSaveGain;
		private System.Windows.Forms.Timer TimerGain;
		private System.Windows.Forms.FlowLayoutPanel fpnlCurrentFillter;
		private System.Windows.Forms.TabControl tabServoGain;
		private System.Windows.Forms.TabPage tabPageServoGain;
		private System.Windows.Forms.TabPage tabPageCurrentFillter;
		private System.Windows.Forms.TabPage tabPageVelocityFillter;
		private System.Windows.Forms.TabPage tabPagePositionFillter;
		private System.Windows.Forms.FlowLayoutPanel fpnlVelocityFillter;
		private System.Windows.Forms.FlowLayoutPanel fpnlPositionFillter;
		private System.Windows.Forms.TabPage tabPageModel;
		private System.Windows.Forms.FlowLayoutPanel fpnlModel;
		private System.Windows.Forms.TabPage tabPageTorqueObserver;
		private System.Windows.Forms.FlowLayoutPanel fpnlTorqueObserver;
		private System.Windows.Forms.TabPage tabPageVelocityObserver;
		private System.Windows.Forms.FlowLayoutPanel fpnlVelocityObserver;
		private System.Windows.Forms.TabPage tabPageFeedback;
		private System.Windows.Forms.Timer TimerResize;
		private CtlNumericInputEx ctlNumExKp;
		private System.Windows.Forms.GroupBox grpPosEx;
		private System.Windows.Forms.GroupBox grpVelEx;
		private System.Windows.Forms.GroupBox grpLoadEx;
		private CtlNumericInputEx ctlNumExKv;
		private CtlNumericInputEx ctlNumExKi;
		private CtlNumericInputEx ctlNumExLoad;
		private System.Windows.Forms.GroupBox grpCurLpfEx;
		private CtlNumericInputEx ctlNumExCurLpf;
		private System.Windows.Forms.Label lblCurLPF3;
		private System.Windows.Forms.CheckBox chkCurLPF1;
		private System.Windows.Forms.GroupBox grpCurNotchEx1;
		private CtlNumericInputEx ctlNumExCurNotch1_f;
		private CtlNumericInputEx ctlNumExCurNotch1_q;
		private CtlNumericInputEx ctlNumExCurNotch1_d;
		private System.Windows.Forms.GroupBox grpCurNotchEx2;
		private CtlNumericInputEx ctlNumExCurNotch2_q;
		private CtlNumericInputEx ctlNumExCurNotch2_d;
		private CtlNumericInputEx ctlNumExCurNotch2_f;
		private System.Windows.Forms.GroupBox grpCurNotchEx3;
		private CtlNumericInputEx ctlNumExCurNotch3_q;
		private CtlNumericInputEx ctlNumExCurNotch3_d;
		private CtlNumericInputEx ctlNumExCurNotch3_f;
		private System.Windows.Forms.GroupBox grpCurNotchEx4;
		private CtlNumericInputEx ctlNumExCurNotch4_q;
		private CtlNumericInputEx ctlNumExCurNotch4_d;
		private CtlNumericInputEx ctlNumExCurNotch4_f;
		private System.Windows.Forms.GroupBox grpCurNotchEx5;
		private CtlNumericInputEx ctlNumExCurNotch5_q;
		private CtlNumericInputEx ctlNumExCurNotch5_d;
		private CtlNumericInputEx ctlNumExCurNotch5_f;
		private System.Windows.Forms.GroupBox grpVelLpfEx;
		private CtlNumericInputEx ctlNumExVelLpf;
		private System.Windows.Forms.Label lblVelLPF3;
		private System.Windows.Forms.CheckBox chkVelLPF1;
		private System.Windows.Forms.GroupBox grpVelNotchEx1;
		private CtlNumericInputEx ctlNumExVelNotch1_q;
		private CtlNumericInputEx ctlNumExVelNotch1_d;
		private CtlNumericInputEx ctlNumExVelNotch1_f;
		private System.Windows.Forms.GroupBox grpPosLpfEx;
		private CtlNumericInputEx ctlNumExPosLpf;
		private System.Windows.Forms.Label lblPosLPF3;
		private System.Windows.Forms.CheckBox chkPosLPF1;
		private System.Windows.Forms.GroupBox grpPosNotchEx1;
		private CtlNumericInputEx ctlNumExPosNotch1_q;
		private CtlNumericInputEx ctlNumExPosNotch1_d;
		private CtlNumericInputEx ctlNumExPosNotch1_f;
		private System.Windows.Forms.GroupBox grpModelEx;
		private CtlNumericInputEx ctlNumExModelGain1;
		private System.Windows.Forms.CheckBox chkModelControlMotorModel1;
		private System.Windows.Forms.CheckBox chkModelControlEnable1;
		private System.Windows.Forms.GroupBox grpTrqOvsEx;
		private CtlNumericInputEx ctlNumExTrqObsFrq;
		private CtlNumericInputEx ctlNumExTrqObsGain;
		private System.Windows.Forms.CheckBox chkTorqueObserverEnable1;
		private System.Windows.Forms.GroupBox grpVelOvsEx;
		private CtlNumericInputEx ctlNumExVelObsTdisComp;
		private CtlNumericInputEx ctlNumExVelObsVelComp;
		private System.Windows.Forms.CheckBox chkVelocityObserverTdisEnable1;
		private CtlNumericInputEx ctlNumExVelObsTime;
		private System.Windows.Forms.CheckBox chkVelocityObserverEnable1;
		private System.Windows.Forms.FlowLayoutPanel fpnlFeedbackFillter;
		private System.Windows.Forms.GroupBox grpVelFBEx;
		private System.Windows.Forms.Label lblVelFBEx;
		private CtlNumericInputEx ctlNumExVelFB;
		private System.Windows.Forms.GroupBox grpPosFBEx;
		private System.Windows.Forms.Label lblPosFBEx;
		private CtlNumericInputEx ctlNumExPosFB;
		private System.Windows.Forms.TabPage tabPageFeedforward;
		private System.Windows.Forms.TabPage tabPageFriction;
		private System.Windows.Forms.FlowLayoutPanel fpnlFeedforward;
		private System.Windows.Forms.GroupBox grpPosFF;
		private CtlNumericInputEx ctlNumExPosFFGain;
		private System.Windows.Forms.GroupBox grpVelFF;
		private CtlNumericInputEx ctlNumExVelFFPeriod;
		private CtlNumericInputEx ctlNumExVelFFGain;
		private CtlNumericInputEx ctlNumExVelFFFillter;
		private System.Windows.Forms.Label lblVelFFPeriod;
		private System.Windows.Forms.Label lblVelFFFillter;
		private System.Windows.Forms.FlowLayoutPanel fpnlFriction;
		private System.Windows.Forms.GroupBox grpFriction;
		private CtlNumericInputEx ctlNumExGravity;
		private CtlNumericInputEx ctlNumExCwTrq;
		private CtlNumericInputEx ctlNumExCcwTrq;
		private CtlNumericInputEx ctlNumExDynamic;
		private CtlNumericInputEx ctlNumExModelGain2;
		private CtlNumericInputEx ctlNumExModelGain3;
		private CtlNumericInputEx ctlNumExModelFillter1;
		private System.Windows.Forms.GroupBox grpCurLpfFB;
		private CtlNumericInputEx ctlNumExCurLpfFB;
		private System.Windows.Forms.GroupBox grpVelLpfFB;
		private CtlNumericInputEx ctlNumExVelLpfFB;
		private System.Windows.Forms.CheckBox chkAdaptiveFilter1;
		private System.Windows.Forms.CheckBox chkAdaptiveFilter2;
		private System.Windows.Forms.CheckBox chkTuningFree;
		private System.Windows.Forms.GroupBox grpTuningFree;
		private CtlNumericInputEx ctlNumExTuningFree;
		private System.Windows.Forms.Timer TimerSave;
		private System.Windows.Forms.RadioButton rdoLoadOnly;
		private System.Windows.Forms.RadioButton rdoLoadFriction;
        private System.Windows.Forms.Label lblUnit1;
        private System.Windows.Forms.Label lblInertiaUnit;
	}
}