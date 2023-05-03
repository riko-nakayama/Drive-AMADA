namespace Motion_Designer
{
	partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TimerMain = new System.Windows.Forms.Timer(this.components);
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.lblUsb = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblModel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRevision = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSerial = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblAlarm = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblServoOn = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripControl = new System.Windows.Forms.ToolStrip();
            this.tbtnJogControl = new System.Windows.Forms.ToolStripButton();
            this.tbtnAutoTuning = new System.Windows.Forms.ToolStripButton();
            this.tbtnProgram = new System.Windows.Forms.ToolStripButton();
            this.tbtnInspection = new System.Windows.Forms.ToolStripButton();
            this.tbtnResolverMount = new System.Windows.Forms.ToolStripButton();
            this.tbtnPhotoSensor = new System.Windows.Forms.ToolStripButton();
            this.tlblDummy = new System.Windows.Forms.ToolStripLabel();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemEnd = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemTool = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemMonitor = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemServoMonitor = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemIoMonitor = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemAlarmHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDebug = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDebugMonitor1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDebugMonitor2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDebugMonitor3 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDebugMonitor4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemUpgrade = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemOption = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemView = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemViewWorkspace = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemLayout = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemInitLayout = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemCollapseLayout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemFree = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemJog = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemGain = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemParameter = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemAutoTuning = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemViewWorkspace2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemStart = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemManualNavi = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemCascade = new System.Windows.Forms.ToolStripMenuItem();
            this.TimerResize = new System.Windows.Forms.Timer(this.components);
            this.TimerInit = new System.Windows.Forms.Timer(this.components);
            this.TimerWarning = new System.Windows.Forms.Timer(this.components);
            this.TimerBlink = new System.Windows.Forms.Timer(this.components);
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblMotionDesigner = new System.Windows.Forms.Label();
            this.statusStripMain.SuspendLayout();
            this.toolStripControl.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // TimerMain
            // 
            this.TimerMain.Tick += new System.EventHandler(this.TimerMain_Tick);
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUsb,
            this.lblModel,
            this.lblRevision,
            this.lblSerial,
            this.lblAlarm,
            this.lblServoOn});
            this.statusStripMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            resources.ApplyResources(this.statusStripMain, "statusStripMain");
            this.statusStripMain.Name = "statusStripMain";
            // 
            // lblUsb
            // 
            resources.ApplyResources(this.lblUsb, "lblUsb");
            this.lblUsb.BackColor = System.Drawing.SystemColors.Control;
            this.lblUsb.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.lblUsb.Name = "lblUsb";
            this.lblUsb.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.lblUsb.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // lblModel
            // 
            this.lblModel.BackColor = System.Drawing.SystemColors.Control;
            this.lblModel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            resources.ApplyResources(this.lblModel, "lblModel");
            this.lblModel.Name = "lblModel";
            this.lblModel.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.lblModel.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // lblRevision
            // 
            this.lblRevision.BackColor = System.Drawing.SystemColors.Control;
            this.lblRevision.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            resources.ApplyResources(this.lblRevision, "lblRevision");
            this.lblRevision.Name = "lblRevision";
            this.lblRevision.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.lblRevision.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // lblSerial
            // 
            this.lblSerial.BackColor = System.Drawing.SystemColors.Control;
            this.lblSerial.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            resources.ApplyResources(this.lblSerial, "lblSerial");
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.lblSerial.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // lblAlarm
            // 
            this.lblAlarm.BackColor = System.Drawing.SystemColors.Control;
            this.lblAlarm.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblAlarm.DoubleClickEnabled = true;
            resources.ApplyResources(this.lblAlarm, "lblAlarm");
            this.lblAlarm.Name = "lblAlarm";
            this.lblAlarm.DoubleClick += new System.EventHandler(this.lblAlarm_DoubleClick);
            this.lblAlarm.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.lblAlarm.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // lblServoOn
            // 
            this.lblServoOn.BackColor = System.Drawing.SystemColors.Control;
            this.lblServoOn.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblServoOn.DoubleClickEnabled = true;
            resources.ApplyResources(this.lblServoOn, "lblServoOn");
            this.lblServoOn.Name = "lblServoOn";
            this.lblServoOn.DoubleClick += new System.EventHandler(this.lblServoOn_DoubleClick);
            this.lblServoOn.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.lblServoOn.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // toolStripControl
            // 
            this.toolStripControl.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtnJogControl,
            this.tbtnAutoTuning,
            this.tbtnProgram,
            this.tbtnInspection,
            this.tbtnResolverMount,
            this.tbtnPhotoSensor,
            this.tlblDummy});
            this.toolStripControl.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            resources.ApplyResources(this.toolStripControl, "toolStripControl");
            this.toolStripControl.Name = "toolStripControl";
            this.toolStripControl.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // tbtnJogControl
            // 
            resources.ApplyResources(this.tbtnJogControl, "tbtnJogControl");
            this.tbtnJogControl.Name = "tbtnJogControl";
            this.tbtnJogControl.Click += new System.EventHandler(this.btnJogControl_Click);
            this.tbtnJogControl.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.tbtnJogControl.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // tbtnAutoTuning
            // 
            resources.ApplyResources(this.tbtnAutoTuning, "tbtnAutoTuning");
            this.tbtnAutoTuning.Name = "tbtnAutoTuning";
            this.tbtnAutoTuning.Click += new System.EventHandler(this.btnAutoTuning_Click);
            this.tbtnAutoTuning.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.tbtnAutoTuning.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // tbtnProgram
            // 
            resources.ApplyResources(this.tbtnProgram, "tbtnProgram");
            this.tbtnProgram.Name = "tbtnProgram";
            this.tbtnProgram.Click += new System.EventHandler(this.tbtnProgram_Click);
            this.tbtnProgram.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.tbtnProgram.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // tbtnInspection
            // 
            resources.ApplyResources(this.tbtnInspection, "tbtnInspection");
            this.tbtnInspection.Name = "tbtnInspection";
            this.tbtnInspection.Click += new System.EventHandler(this.tbtnInspection_Click);
            this.tbtnInspection.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.tbtnInspection.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // tbtnResolverMount
            // 
            resources.ApplyResources(this.tbtnResolverMount, "tbtnResolverMount");
            this.tbtnResolverMount.Name = "tbtnResolverMount";
            this.tbtnResolverMount.Click += new System.EventHandler(this.tbtnResolverMount_Click);
            this.tbtnResolverMount.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.tbtnResolverMount.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // tbtnPhotoSensor
            // 
            resources.ApplyResources(this.tbtnPhotoSensor, "tbtnPhotoSensor");
            this.tbtnPhotoSensor.Name = "tbtnPhotoSensor";
            this.tbtnPhotoSensor.Click += new System.EventHandler(this.tbtnPhotoSensor_Click);
            this.tbtnPhotoSensor.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.tbtnPhotoSensor.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // tlblDummy
            // 
            resources.ApplyResources(this.tlblDummy, "tlblDummy");
            this.tlblDummy.Name = "tlblDummy";
            // 
            // menuStripMain
            // 
            this.menuStripMain.BackColor = System.Drawing.SystemColors.Control;
            this.menuStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemFile,
            this.ToolStripMenuItemTool,
            this.ToolStripMenuItemView,
            this.ToolStripMenuItemLayout,
            this.ToolStripMenuItemHelp,
            this.ToolStripMenuItemWindow});
            this.menuStripMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            resources.ApplyResources(this.menuStripMain, "menuStripMain");
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // ToolStripMenuItemFile
            // 
            this.ToolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemEnd});
            resources.ApplyResources(this.ToolStripMenuItemFile, "ToolStripMenuItemFile");
            this.ToolStripMenuItemFile.Name = "ToolStripMenuItemFile";
            this.ToolStripMenuItemFile.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.ToolStripMenuItemFile.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // ToolStripMenuItemEnd
            // 
            resources.ApplyResources(this.ToolStripMenuItemEnd, "ToolStripMenuItemEnd");
            this.ToolStripMenuItemEnd.Name = "ToolStripMenuItemEnd";
            this.ToolStripMenuItemEnd.Click += new System.EventHandler(this.ToolStripMenuItemEnd_Click);
            // 
            // ToolStripMenuItemTool
            // 
            this.ToolStripMenuItemTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemMonitor,
            this.toolStripSeparator1,
            this.ToolStripMenuItemUpgrade,
            this.toolStripSeparator6,
            this.ToolStripMenuItemOption});
            resources.ApplyResources(this.ToolStripMenuItemTool, "ToolStripMenuItemTool");
            this.ToolStripMenuItemTool.Name = "ToolStripMenuItemTool";
            this.ToolStripMenuItemTool.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.ToolStripMenuItemTool.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // ToolStripMenuItemMonitor
            // 
            this.ToolStripMenuItemMonitor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemServoMonitor,
            this.ToolStripMenuItemIoMonitor,
            this.ToolStripMenuItemAlarmHistory,
            this.ToolStripMenuItemDebug});
            this.ToolStripMenuItemMonitor.Name = "ToolStripMenuItemMonitor";
            resources.ApplyResources(this.ToolStripMenuItemMonitor, "ToolStripMenuItemMonitor");
            // 
            // ToolStripMenuItemServoMonitor
            // 
            resources.ApplyResources(this.ToolStripMenuItemServoMonitor, "ToolStripMenuItemServoMonitor");
            this.ToolStripMenuItemServoMonitor.Name = "ToolStripMenuItemServoMonitor";
            this.ToolStripMenuItemServoMonitor.Click += new System.EventHandler(this.ToolStripMenuItemServoMonitor_Click);
            // 
            // ToolStripMenuItemIoMonitor
            // 
            resources.ApplyResources(this.ToolStripMenuItemIoMonitor, "ToolStripMenuItemIoMonitor");
            this.ToolStripMenuItemIoMonitor.Name = "ToolStripMenuItemIoMonitor";
            this.ToolStripMenuItemIoMonitor.Click += new System.EventHandler(this.ToolStripMenuItemIoMonitor_Click);
            // 
            // ToolStripMenuItemAlarmHistory
            // 
            resources.ApplyResources(this.ToolStripMenuItemAlarmHistory, "ToolStripMenuItemAlarmHistory");
            this.ToolStripMenuItemAlarmHistory.Name = "ToolStripMenuItemAlarmHistory";
            this.ToolStripMenuItemAlarmHistory.Click += new System.EventHandler(this.ToolStripMenuItemAlarmHistory_Click);
            // 
            // ToolStripMenuItemDebug
            // 
            this.ToolStripMenuItemDebug.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemDebugMonitor1,
            this.ToolStripMenuItemDebugMonitor2,
            this.ToolStripMenuItemDebugMonitor3,
            this.ToolStripMenuItemDebugMonitor4});
            resources.ApplyResources(this.ToolStripMenuItemDebug, "ToolStripMenuItemDebug");
            this.ToolStripMenuItemDebug.Name = "ToolStripMenuItemDebug";
            // 
            // ToolStripMenuItemDebugMonitor1
            // 
            resources.ApplyResources(this.ToolStripMenuItemDebugMonitor1, "ToolStripMenuItemDebugMonitor1");
            this.ToolStripMenuItemDebugMonitor1.Name = "ToolStripMenuItemDebugMonitor1";
            this.ToolStripMenuItemDebugMonitor1.Tag = "0";
            this.ToolStripMenuItemDebugMonitor1.Click += new System.EventHandler(this.ToolStripMenuItemDebugMonitor_Click);
            // 
            // ToolStripMenuItemDebugMonitor2
            // 
            resources.ApplyResources(this.ToolStripMenuItemDebugMonitor2, "ToolStripMenuItemDebugMonitor2");
            this.ToolStripMenuItemDebugMonitor2.Name = "ToolStripMenuItemDebugMonitor2";
            this.ToolStripMenuItemDebugMonitor2.Tag = "1";
            this.ToolStripMenuItemDebugMonitor2.Click += new System.EventHandler(this.ToolStripMenuItemDebugMonitor_Click);
            // 
            // ToolStripMenuItemDebugMonitor3
            // 
            resources.ApplyResources(this.ToolStripMenuItemDebugMonitor3, "ToolStripMenuItemDebugMonitor3");
            this.ToolStripMenuItemDebugMonitor3.Name = "ToolStripMenuItemDebugMonitor3";
            this.ToolStripMenuItemDebugMonitor3.Tag = "2";
            this.ToolStripMenuItemDebugMonitor3.Click += new System.EventHandler(this.ToolStripMenuItemDebugMonitor_Click);
            // 
            // ToolStripMenuItemDebugMonitor4
            // 
            resources.ApplyResources(this.ToolStripMenuItemDebugMonitor4, "ToolStripMenuItemDebugMonitor4");
            this.ToolStripMenuItemDebugMonitor4.Name = "ToolStripMenuItemDebugMonitor4";
            this.ToolStripMenuItemDebugMonitor4.Tag = "3";
            this.ToolStripMenuItemDebugMonitor4.Click += new System.EventHandler(this.ToolStripMenuItemDebugMonitor_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // ToolStripMenuItemUpgrade
            // 
            resources.ApplyResources(this.ToolStripMenuItemUpgrade, "ToolStripMenuItemUpgrade");
            this.ToolStripMenuItemUpgrade.Name = "ToolStripMenuItemUpgrade";
            this.ToolStripMenuItemUpgrade.Click += new System.EventHandler(this.ToolStripMenuItemUpgrade_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // ToolStripMenuItemOption
            // 
            resources.ApplyResources(this.ToolStripMenuItemOption, "ToolStripMenuItemOption");
            this.ToolStripMenuItemOption.Name = "ToolStripMenuItemOption";
            this.ToolStripMenuItemOption.Click += new System.EventHandler(this.ToolStripMenuItemOption_Click);
            // 
            // ToolStripMenuItemView
            // 
            this.ToolStripMenuItemView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemViewWorkspace});
            resources.ApplyResources(this.ToolStripMenuItemView, "ToolStripMenuItemView");
            this.ToolStripMenuItemView.Name = "ToolStripMenuItemView";
            this.ToolStripMenuItemView.DropDownOpening += new System.EventHandler(this.ToolStripMenuItemView_DropDownOpening);
            this.ToolStripMenuItemView.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.ToolStripMenuItemView.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // ToolStripMenuItemViewWorkspace
            // 
            resources.ApplyResources(this.ToolStripMenuItemViewWorkspace, "ToolStripMenuItemViewWorkspace");
            this.ToolStripMenuItemViewWorkspace.Name = "ToolStripMenuItemViewWorkspace";
            this.ToolStripMenuItemViewWorkspace.Click += new System.EventHandler(this.ToolStripMenuItemViewWorkspace_Click);
            // 
            // ToolStripMenuItemLayout
            // 
            this.ToolStripMenuItemLayout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemInitLayout,
            this.ToolStripMenuItemCollapseLayout,
            this.toolStripSeparator2,
            this.ToolStripMenuItemFree,
            this.ToolStripMenuItemJog,
            this.ToolStripMenuItemGain,
            this.ToolStripMenuItemParameter,
            this.ToolStripMenuItemAutoTuning,
            this.toolStripSeparator3,
            this.ToolStripMenuItemViewWorkspace2,
            this.toolStripSeparator4,
            this.ToolStripMenuItemStart});
            resources.ApplyResources(this.ToolStripMenuItemLayout, "ToolStripMenuItemLayout");
            this.ToolStripMenuItemLayout.Name = "ToolStripMenuItemLayout";
            this.ToolStripMenuItemLayout.DropDownOpening += new System.EventHandler(this.ToolStripMenuItemLayout_DropDownOpening);
            this.ToolStripMenuItemLayout.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.ToolStripMenuItemLayout.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // ToolStripMenuItemInitLayout
            // 
            resources.ApplyResources(this.ToolStripMenuItemInitLayout, "ToolStripMenuItemInitLayout");
            this.ToolStripMenuItemInitLayout.Name = "ToolStripMenuItemInitLayout";
            this.ToolStripMenuItemInitLayout.Click += new System.EventHandler(this.ToolStripMenuItemInitLayout_Click);
            // 
            // ToolStripMenuItemCollapseLayout
            // 
            this.ToolStripMenuItemCollapseLayout.CheckOnClick = true;
            resources.ApplyResources(this.ToolStripMenuItemCollapseLayout, "ToolStripMenuItemCollapseLayout");
            this.ToolStripMenuItemCollapseLayout.Name = "ToolStripMenuItemCollapseLayout";
            this.ToolStripMenuItemCollapseLayout.Click += new System.EventHandler(this.ToolStripMenuItemCollapseLayout_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // ToolStripMenuItemFree
            // 
            resources.ApplyResources(this.ToolStripMenuItemFree, "ToolStripMenuItemFree");
            this.ToolStripMenuItemFree.Name = "ToolStripMenuItemFree";
            this.ToolStripMenuItemFree.Click += new System.EventHandler(this.ToolStripMenuItemFree_Click);
            // 
            // ToolStripMenuItemJog
            // 
            resources.ApplyResources(this.ToolStripMenuItemJog, "ToolStripMenuItemJog");
            this.ToolStripMenuItemJog.Name = "ToolStripMenuItemJog";
            this.ToolStripMenuItemJog.Click += new System.EventHandler(this.ToolStripMenuItemJog_Click);
            // 
            // ToolStripMenuItemGain
            // 
            resources.ApplyResources(this.ToolStripMenuItemGain, "ToolStripMenuItemGain");
            this.ToolStripMenuItemGain.Name = "ToolStripMenuItemGain";
            this.ToolStripMenuItemGain.Click += new System.EventHandler(this.ToolStripMenuItemGain_Click);
            // 
            // ToolStripMenuItemParameter
            // 
            resources.ApplyResources(this.ToolStripMenuItemParameter, "ToolStripMenuItemParameter");
            this.ToolStripMenuItemParameter.Name = "ToolStripMenuItemParameter";
            this.ToolStripMenuItemParameter.Click += new System.EventHandler(this.ToolStripMenuItemParameter_Click);
            // 
            // ToolStripMenuItemAutoTuning
            // 
            resources.ApplyResources(this.ToolStripMenuItemAutoTuning, "ToolStripMenuItemAutoTuning");
            this.ToolStripMenuItemAutoTuning.Name = "ToolStripMenuItemAutoTuning";
            this.ToolStripMenuItemAutoTuning.Click += new System.EventHandler(this.ToolStripMenuItemAutoTuning_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // ToolStripMenuItemViewWorkspace2
            // 
            resources.ApplyResources(this.ToolStripMenuItemViewWorkspace2, "ToolStripMenuItemViewWorkspace2");
            this.ToolStripMenuItemViewWorkspace2.Name = "ToolStripMenuItemViewWorkspace2";
            this.ToolStripMenuItemViewWorkspace2.Click += new System.EventHandler(this.ToolStripMenuItemViewWorkspace_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // ToolStripMenuItemStart
            // 
            resources.ApplyResources(this.ToolStripMenuItemStart, "ToolStripMenuItemStart");
            this.ToolStripMenuItemStart.Name = "ToolStripMenuItemStart";
            this.ToolStripMenuItemStart.Click += new System.EventHandler(this.ToolStripMenuItemStart_Click);
            // 
            // ToolStripMenuItemHelp
            // 
            this.ToolStripMenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemManualNavi,
            this.toolStripSeparator5,
            this.ToolStripMenuItemVersion});
            resources.ApplyResources(this.ToolStripMenuItemHelp, "ToolStripMenuItemHelp");
            this.ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            this.ToolStripMenuItemHelp.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.ToolStripMenuItemHelp.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // ToolStripMenuItemManualNavi
            // 
            resources.ApplyResources(this.ToolStripMenuItemManualNavi, "ToolStripMenuItemManualNavi");
            this.ToolStripMenuItemManualNavi.Name = "ToolStripMenuItemManualNavi";
            this.ToolStripMenuItemManualNavi.Click += new System.EventHandler(this.ToolStripMenuItemManualNavi_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // ToolStripMenuItemVersion
            // 
            resources.ApplyResources(this.ToolStripMenuItemVersion, "ToolStripMenuItemVersion");
            this.ToolStripMenuItemVersion.Name = "ToolStripMenuItemVersion";
            this.ToolStripMenuItemVersion.Click += new System.EventHandler(this.ToolStripMenuItemVersion_Click);
            // 
            // ToolStripMenuItemWindow
            // 
            this.ToolStripMenuItemWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemHorizontal,
            this.ToolStripMenuItemVertical,
            this.ToolStripMenuItemCascade});
            resources.ApplyResources(this.ToolStripMenuItemWindow, "ToolStripMenuItemWindow");
            this.ToolStripMenuItemWindow.Name = "ToolStripMenuItemWindow";
            this.ToolStripMenuItemWindow.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.ToolStripMenuItemWindow.MouseHover += new System.EventHandler(this.Control_MouseHover);
            // 
            // ToolStripMenuItemHorizontal
            // 
            resources.ApplyResources(this.ToolStripMenuItemHorizontal, "ToolStripMenuItemHorizontal");
            this.ToolStripMenuItemHorizontal.Name = "ToolStripMenuItemHorizontal";
            this.ToolStripMenuItemHorizontal.Click += new System.EventHandler(this.ToolStripMenuItemHorizontal_Click);
            // 
            // ToolStripMenuItemVertical
            // 
            resources.ApplyResources(this.ToolStripMenuItemVertical, "ToolStripMenuItemVertical");
            this.ToolStripMenuItemVertical.Name = "ToolStripMenuItemVertical";
            this.ToolStripMenuItemVertical.Click += new System.EventHandler(this.ToolStripMenuItemVertical_Click);
            // 
            // ToolStripMenuItemCascade
            // 
            resources.ApplyResources(this.ToolStripMenuItemCascade, "ToolStripMenuItemCascade");
            this.ToolStripMenuItemCascade.Name = "ToolStripMenuItemCascade";
            this.ToolStripMenuItemCascade.Click += new System.EventHandler(this.ToolStripMenuItemCascade_Click);
            // 
            // TimerResize
            // 
            this.TimerResize.Interval = 500;
            this.TimerResize.Tick += new System.EventHandler(this.TimerResize_Tick);
            // 
            // TimerInit
            // 
            this.TimerInit.Tick += new System.EventHandler(this.TimerInit_Tick);
            // 
            // TimerWarning
            // 
            this.TimerWarning.Tick += new System.EventHandler(this.TimerWarning_Tick);
            // 
            // TimerBlink
            // 
            this.TimerBlink.Interval = 200;
            this.TimerBlink.Tick += new System.EventHandler(this.TimerBlink_Tick);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pnlMain.Controls.Add(this.lblMotionDesigner);
            resources.ApplyResources(this.pnlMain, "pnlMain");
            this.pnlMain.Name = "pnlMain";
            // 
            // lblMotionDesigner
            // 
            resources.ApplyResources(this.lblMotionDesigner, "lblMotionDesigner");
            this.lblMotionDesigner.BackColor = System.Drawing.Color.Transparent;
            this.lblMotionDesigner.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblMotionDesigner.Name = "lblMotionDesigner";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Controls.Add(this.toolStripControl);
            this.Controls.Add(this.menuStripMain);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.statusStripMain);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.toolStripControl.ResumeLayout(false);
            this.toolStripControl.PerformLayout();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Timer TimerMain;
		private System.Windows.Forms.StatusStrip statusStripMain;
		private System.Windows.Forms.ToolStripStatusLabel lblUsb;
		private System.Windows.Forms.ToolStripButton tbtnAutoTuning;
		private System.Windows.Forms.ToolStrip toolStripControl;
		private System.Windows.Forms.MenuStrip menuStripMain;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFile;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemEnd;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemView;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemViewWorkspace;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemTool;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemOption;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemWindow;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemHorizontal;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemVertical;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemHelp;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemVersion;
		private System.Windows.Forms.Timer TimerResize;
		private System.Windows.Forms.Timer TimerInit;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCascade;
		private System.Windows.Forms.ToolStripStatusLabel lblModel;
		private System.Windows.Forms.ToolStripStatusLabel lblRevision;
		private System.Windows.Forms.ToolStripStatusLabel lblSerial;
		private System.Windows.Forms.ToolStripStatusLabel lblAlarm;
		private System.Windows.Forms.ToolStripStatusLabel lblServoOn;
		private System.Windows.Forms.Timer TimerWarning;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemUpgrade;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemLayout;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemInitLayout;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemJog;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemParameter;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAutoTuning;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemGain;
		private System.Windows.Forms.Timer TimerBlink;
		private System.Windows.Forms.ToolStripButton tbtnJogControl;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCollapseLayout;
		private System.Windows.Forms.Panel pnlMain;
		private System.Windows.Forms.Label lblMotionDesigner;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemStart;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFree;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemViewWorkspace2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemManualNavi;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemMonitor;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemServoMonitor;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemIoMonitor;
        private System.Windows.Forms.ToolStripButton tbtnProgram;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAlarmHistory;
		private System.Windows.Forms.ToolStripLabel tlblDummy;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDebug;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDebugMonitor1;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDebugMonitor2;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDebugMonitor3;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDebugMonitor4;
        private System.Windows.Forms.ToolStripButton tbtnInspection;
        private System.Windows.Forms.ToolStripButton tbtnResolverMount;
        private System.Windows.Forms.ToolStripButton tbtnPhotoSensor;
    }
}

