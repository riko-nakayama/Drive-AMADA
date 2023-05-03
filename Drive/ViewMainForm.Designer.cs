namespace Motion_Designer
{
	partial class ViewMainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewMainForm));
			this.toolStripViewPallete = new System.Windows.Forms.ToolStrip();
			this.tbtnParameter = new System.Windows.Forms.ToolStripButton();
			this.tbtnServoGain = new System.Windows.Forms.ToolStripButton();
			this.tbtnDigitalOsillo = new System.Windows.Forms.ToolStripButton();
			this.tbtnBodeGraph = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tbtnHorizontal = new System.Windows.Forms.ToolStripButton();
			this.tbtnVertical = new System.Windows.Forms.ToolStripButton();
			this.tbtnCascade = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.statusStripViewPallete = new System.Windows.Forms.StatusStrip();
			this.lblFree = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblOsilloParam = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblOsilloGain = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblOsilloFFT = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblFFTGain = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblParam = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblGain = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblOsillo = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblFFT = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblServoStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblIoStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblWorkspaceInit = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStripMain = new System.Windows.Forms.MenuStrip();
			this.ToolStripMenuItemLayout = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItemInitLayout = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.ToolStripMenuItemFree = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItemParameter = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItemServoGain = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItemAutoTuning = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItemFFTGain = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItemWindow = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItemHorizontal = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItemVertical = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItemCascade = new System.Windows.Forms.ToolStripMenuItem();
			this.TimerResize = new System.Windows.Forms.Timer(this.components);
			this.lblMotionDesigner = new System.Windows.Forms.Label();
			this.pnlMain = new System.Windows.Forms.Panel();
			this.toolStripViewPallete.SuspendLayout();
			this.statusStripViewPallete.SuspendLayout();
			this.menuStripMain.SuspendLayout();
			this.pnlMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStripViewPallete
			// 
			this.toolStripViewPallete.AccessibleDescription = null;
			this.toolStripViewPallete.AccessibleName = null;
			resources.ApplyResources(this.toolStripViewPallete, "toolStripViewPallete");
			this.toolStripViewPallete.BackgroundImage = null;
			this.toolStripViewPallete.Font = null;
			this.toolStripViewPallete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtnParameter,
            this.tbtnServoGain,
            this.tbtnDigitalOsillo,
            this.tbtnBodeGraph,
            this.toolStripSeparator2,
            this.tbtnHorizontal,
            this.tbtnVertical,
            this.tbtnCascade,
            this.toolStripSeparator1});
			this.toolStripViewPallete.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			this.toolStripViewPallete.Name = "toolStripViewPallete";
			this.toolStripViewPallete.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			// 
			// tbtnParameter
			// 
			this.tbtnParameter.AccessibleDescription = null;
			this.tbtnParameter.AccessibleName = null;
			resources.ApplyResources(this.tbtnParameter, "tbtnParameter");
			this.tbtnParameter.BackgroundImage = null;
			this.tbtnParameter.Name = "tbtnParameter";
			this.tbtnParameter.MouseHover += new System.EventHandler(this.Control_MouseHover);
			this.tbtnParameter.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
			this.tbtnParameter.Click += new System.EventHandler(this.tbtnParameter_Click);
			// 
			// tbtnServoGain
			// 
			this.tbtnServoGain.AccessibleDescription = null;
			this.tbtnServoGain.AccessibleName = null;
			resources.ApplyResources(this.tbtnServoGain, "tbtnServoGain");
			this.tbtnServoGain.BackgroundImage = null;
			this.tbtnServoGain.Name = "tbtnServoGain";
			this.tbtnServoGain.MouseHover += new System.EventHandler(this.Control_MouseHover);
			this.tbtnServoGain.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
			this.tbtnServoGain.Click += new System.EventHandler(this.tbtnServoGain_Click);
			// 
			// tbtnDigitalOsillo
			// 
			this.tbtnDigitalOsillo.AccessibleDescription = null;
			this.tbtnDigitalOsillo.AccessibleName = null;
			resources.ApplyResources(this.tbtnDigitalOsillo, "tbtnDigitalOsillo");
			this.tbtnDigitalOsillo.BackgroundImage = null;
			this.tbtnDigitalOsillo.Name = "tbtnDigitalOsillo";
			this.tbtnDigitalOsillo.MouseHover += new System.EventHandler(this.Control_MouseHover);
			this.tbtnDigitalOsillo.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
			this.tbtnDigitalOsillo.Click += new System.EventHandler(this.tbtnDigitalOsillo_Click);
			// 
			// tbtnBodeGraph
			// 
			this.tbtnBodeGraph.AccessibleDescription = null;
			this.tbtnBodeGraph.AccessibleName = null;
			resources.ApplyResources(this.tbtnBodeGraph, "tbtnBodeGraph");
			this.tbtnBodeGraph.BackgroundImage = null;
			this.tbtnBodeGraph.Name = "tbtnBodeGraph";
			this.tbtnBodeGraph.MouseHover += new System.EventHandler(this.Control_MouseHover);
			this.tbtnBodeGraph.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
			this.tbtnBodeGraph.Click += new System.EventHandler(this.tbtnBodeGraph_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.AccessibleDescription = null;
			this.toolStripSeparator2.AccessibleName = null;
			resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.MouseHover += new System.EventHandler(this.Control_MouseHover);
			this.toolStripSeparator2.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
			// 
			// tbtnHorizontal
			// 
			this.tbtnHorizontal.AccessibleDescription = null;
			this.tbtnHorizontal.AccessibleName = null;
			resources.ApplyResources(this.tbtnHorizontal, "tbtnHorizontal");
			this.tbtnHorizontal.BackgroundImage = null;
			this.tbtnHorizontal.Name = "tbtnHorizontal";
			this.tbtnHorizontal.MouseHover += new System.EventHandler(this.Control_MouseHover);
			this.tbtnHorizontal.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
			this.tbtnHorizontal.Click += new System.EventHandler(this.tbtnHorizontal_Click);
			// 
			// tbtnVertical
			// 
			this.tbtnVertical.AccessibleDescription = null;
			this.tbtnVertical.AccessibleName = null;
			resources.ApplyResources(this.tbtnVertical, "tbtnVertical");
			this.tbtnVertical.BackgroundImage = null;
			this.tbtnVertical.Name = "tbtnVertical";
			this.tbtnVertical.MouseHover += new System.EventHandler(this.Control_MouseHover);
			this.tbtnVertical.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
			this.tbtnVertical.Click += new System.EventHandler(this.tbtnVertical_Click);
			// 
			// tbtnCascade
			// 
			this.tbtnCascade.AccessibleDescription = null;
			this.tbtnCascade.AccessibleName = null;
			resources.ApplyResources(this.tbtnCascade, "tbtnCascade");
			this.tbtnCascade.BackgroundImage = null;
			this.tbtnCascade.Name = "tbtnCascade";
			this.tbtnCascade.MouseHover += new System.EventHandler(this.Control_MouseHover);
			this.tbtnCascade.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
			this.tbtnCascade.Click += new System.EventHandler(this.tbtnCascade_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.AccessibleDescription = null;
			this.toolStripSeparator1.AccessibleName = null;
			resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.MouseHover += new System.EventHandler(this.Control_MouseHover);
			this.toolStripSeparator1.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
			// 
			// statusStripViewPallete
			// 
			this.statusStripViewPallete.AccessibleDescription = null;
			this.statusStripViewPallete.AccessibleName = null;
			resources.ApplyResources(this.statusStripViewPallete, "statusStripViewPallete");
			this.statusStripViewPallete.BackgroundImage = null;
			this.statusStripViewPallete.Font = null;
			this.statusStripViewPallete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblFree,
            this.lblOsilloParam,
            this.lblOsilloGain,
            this.lblOsilloFFT,
            this.lblFFTGain,
            this.lblParam,
            this.lblGain,
            this.lblOsillo,
            this.lblFFT,
            this.lblServoStatus,
            this.lblIoStatus,
            this.lblWorkspaceInit});
			this.statusStripViewPallete.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			this.statusStripViewPallete.Name = "statusStripViewPallete";
			// 
			// lblFree
			// 
			this.lblFree.AccessibleDescription = null;
			this.lblFree.AccessibleName = null;
			resources.ApplyResources(this.lblFree, "lblFree");
			this.lblFree.BackColor = System.Drawing.Color.Gold;
			this.lblFree.BackgroundImage = null;
			this.lblFree.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.lblFree.IsLink = true;
			this.lblFree.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lblFree.LinkColor = System.Drawing.Color.Navy;
			this.lblFree.Name = "lblFree";
			this.lblFree.MouseHover += new System.EventHandler(this.Control_MouseHover);
			this.lblFree.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
			this.lblFree.Click += new System.EventHandler(this.lblFree_Click);
			// 
			// lblOsilloParam
			// 
			this.lblOsilloParam.AccessibleDescription = null;
			this.lblOsilloParam.AccessibleName = null;
			resources.ApplyResources(this.lblOsilloParam, "lblOsilloParam");
			this.lblOsilloParam.AutoToolTip = true;
			this.lblOsilloParam.BackgroundImage = null;
			this.lblOsilloParam.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.lblOsilloParam.IsLink = true;
			this.lblOsilloParam.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lblOsilloParam.LinkColor = System.Drawing.Color.Navy;
			this.lblOsilloParam.Name = "lblOsilloParam";
			this.lblOsilloParam.MouseHover += new System.EventHandler(this.Control_MouseHover);
			this.lblOsilloParam.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
			this.lblOsilloParam.Click += new System.EventHandler(this.lblOsilloParam_Click);
			// 
			// lblOsilloGain
			// 
			this.lblOsilloGain.AccessibleDescription = null;
			this.lblOsilloGain.AccessibleName = null;
			resources.ApplyResources(this.lblOsilloGain, "lblOsilloGain");
			this.lblOsilloGain.BackgroundImage = null;
			this.lblOsilloGain.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.lblOsilloGain.ForeColor = System.Drawing.Color.Navy;
			this.lblOsilloGain.IsLink = true;
			this.lblOsilloGain.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lblOsilloGain.LinkColor = System.Drawing.Color.Navy;
			this.lblOsilloGain.Name = "lblOsilloGain";
			this.lblOsilloGain.MouseHover += new System.EventHandler(this.Control_MouseHover);
			this.lblOsilloGain.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
			this.lblOsilloGain.Click += new System.EventHandler(this.lblOsilloGain_Click);
			// 
			// lblOsilloFFT
			// 
			this.lblOsilloFFT.AccessibleDescription = null;
			this.lblOsilloFFT.AccessibleName = null;
			resources.ApplyResources(this.lblOsilloFFT, "lblOsilloFFT");
			this.lblOsilloFFT.BackgroundImage = null;
			this.lblOsilloFFT.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.lblOsilloFFT.IsLink = true;
			this.lblOsilloFFT.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lblOsilloFFT.LinkColor = System.Drawing.Color.Navy;
			this.lblOsilloFFT.Name = "lblOsilloFFT";
			this.lblOsilloFFT.MouseHover += new System.EventHandler(this.Control_MouseHover);
			this.lblOsilloFFT.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
			this.lblOsilloFFT.Click += new System.EventHandler(this.lblOsilloFFT_Click);
			// 
			// lblFFTGain
			// 
			this.lblFFTGain.AccessibleDescription = null;
			this.lblFFTGain.AccessibleName = null;
			resources.ApplyResources(this.lblFFTGain, "lblFFTGain");
			this.lblFFTGain.BackgroundImage = null;
			this.lblFFTGain.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.lblFFTGain.IsLink = true;
			this.lblFFTGain.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lblFFTGain.LinkColor = System.Drawing.Color.Navy;
			this.lblFFTGain.Name = "lblFFTGain";
			this.lblFFTGain.MouseHover += new System.EventHandler(this.Control_MouseHover);
			this.lblFFTGain.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
			this.lblFFTGain.Click += new System.EventHandler(this.lblFFTGain_Click);
			// 
			// lblParam
			// 
			this.lblParam.AccessibleDescription = null;
			this.lblParam.AccessibleName = null;
			resources.ApplyResources(this.lblParam, "lblParam");
			this.lblParam.BackgroundImage = null;
			this.lblParam.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.lblParam.IsLink = true;
			this.lblParam.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lblParam.LinkColor = System.Drawing.Color.Navy;
			this.lblParam.Name = "lblParam";
			this.lblParam.MouseHover += new System.EventHandler(this.Control_MouseHover);
			this.lblParam.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
			this.lblParam.Click += new System.EventHandler(this.lblParam_Click);
			// 
			// lblGain
			// 
			this.lblGain.AccessibleDescription = null;
			this.lblGain.AccessibleName = null;
			resources.ApplyResources(this.lblGain, "lblGain");
			this.lblGain.BackgroundImage = null;
			this.lblGain.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.lblGain.IsLink = true;
			this.lblGain.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lblGain.LinkColor = System.Drawing.Color.Navy;
			this.lblGain.Name = "lblGain";
			this.lblGain.MouseHover += new System.EventHandler(this.Control_MouseHover);
			this.lblGain.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
			this.lblGain.Click += new System.EventHandler(this.lblGain_Click);
			// 
			// lblOsillo
			// 
			this.lblOsillo.AccessibleDescription = null;
			this.lblOsillo.AccessibleName = null;
			resources.ApplyResources(this.lblOsillo, "lblOsillo");
			this.lblOsillo.BackgroundImage = null;
			this.lblOsillo.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.lblOsillo.IsLink = true;
			this.lblOsillo.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lblOsillo.LinkColor = System.Drawing.Color.Navy;
			this.lblOsillo.Name = "lblOsillo";
			this.lblOsillo.MouseHover += new System.EventHandler(this.Control_MouseHover);
			this.lblOsillo.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
			this.lblOsillo.Click += new System.EventHandler(this.lblOsillo_Click);
			// 
			// lblFFT
			// 
			this.lblFFT.AccessibleDescription = null;
			this.lblFFT.AccessibleName = null;
			resources.ApplyResources(this.lblFFT, "lblFFT");
			this.lblFFT.BackgroundImage = null;
			this.lblFFT.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.lblFFT.IsLink = true;
			this.lblFFT.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lblFFT.LinkColor = System.Drawing.Color.Navy;
			this.lblFFT.Name = "lblFFT";
			this.lblFFT.MouseHover += new System.EventHandler(this.Control_MouseHover);
			this.lblFFT.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
			this.lblFFT.Click += new System.EventHandler(this.lblFFT_Click);
			// 
			// lblServoStatus
			// 
			this.lblServoStatus.AccessibleDescription = null;
			this.lblServoStatus.AccessibleName = null;
			resources.ApplyResources(this.lblServoStatus, "lblServoStatus");
			this.lblServoStatus.BackColor = System.Drawing.SystemColors.Control;
			this.lblServoStatus.BackgroundImage = null;
			this.lblServoStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.lblServoStatus.IsLink = true;
			this.lblServoStatus.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lblServoStatus.LinkColor = System.Drawing.Color.Navy;
			this.lblServoStatus.Name = "lblServoStatus";
			this.lblServoStatus.MouseHover += new System.EventHandler(this.Control_MouseHover);
			this.lblServoStatus.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
			this.lblServoStatus.Click += new System.EventHandler(this.lblServoStatus_Click);
			// 
			// lblIoStatus
			// 
			this.lblIoStatus.AccessibleDescription = null;
			this.lblIoStatus.AccessibleName = null;
			resources.ApplyResources(this.lblIoStatus, "lblIoStatus");
			this.lblIoStatus.BackColor = System.Drawing.SystemColors.Control;
			this.lblIoStatus.BackgroundImage = null;
			this.lblIoStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.lblIoStatus.IsLink = true;
			this.lblIoStatus.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lblIoStatus.LinkColor = System.Drawing.Color.Navy;
			this.lblIoStatus.Name = "lblIoStatus";
			this.lblIoStatus.MouseHover += new System.EventHandler(this.Control_MouseHover);
			this.lblIoStatus.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
			this.lblIoStatus.Click += new System.EventHandler(this.lblIoStatus_Click);
			// 
			// lblWorkspaceInit
			// 
			this.lblWorkspaceInit.AccessibleDescription = null;
			this.lblWorkspaceInit.AccessibleName = null;
			resources.ApplyResources(this.lblWorkspaceInit, "lblWorkspaceInit");
			this.lblWorkspaceInit.BackgroundImage = null;
			this.lblWorkspaceInit.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.lblWorkspaceInit.IsLink = true;
			this.lblWorkspaceInit.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lblWorkspaceInit.LinkColor = System.Drawing.Color.Navy;
			this.lblWorkspaceInit.Name = "lblWorkspaceInit";
			this.lblWorkspaceInit.MouseHover += new System.EventHandler(this.Control_MouseHover);
			this.lblWorkspaceInit.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
			this.lblWorkspaceInit.Click += new System.EventHandler(this.lblWorkspaceInit_Click);
			// 
			// menuStripMain
			// 
			this.menuStripMain.AccessibleDescription = null;
			this.menuStripMain.AccessibleName = null;
			resources.ApplyResources(this.menuStripMain, "menuStripMain");
			this.menuStripMain.BackgroundImage = null;
			this.menuStripMain.Font = null;
			this.menuStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
			this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemLayout,
            this.ToolStripMenuItemWindow});
			this.menuStripMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			this.menuStripMain.Name = "menuStripMain";
			this.menuStripMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			// 
			// ToolStripMenuItemLayout
			// 
			this.ToolStripMenuItemLayout.AccessibleDescription = null;
			this.ToolStripMenuItemLayout.AccessibleName = null;
			resources.ApplyResources(this.ToolStripMenuItemLayout, "ToolStripMenuItemLayout");
			this.ToolStripMenuItemLayout.BackgroundImage = null;
			this.ToolStripMenuItemLayout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemInitLayout,
            this.toolStripSeparator3,
            this.ToolStripMenuItemFree,
            this.ToolStripMenuItemParameter,
            this.ToolStripMenuItemServoGain,
            this.ToolStripMenuItemAutoTuning,
            this.ToolStripMenuItemFFTGain});
			this.ToolStripMenuItemLayout.Name = "ToolStripMenuItemLayout";
			this.ToolStripMenuItemLayout.ShortcutKeyDisplayString = null;
			this.ToolStripMenuItemLayout.MouseHover += new System.EventHandler(this.Control_MouseHover);
			this.ToolStripMenuItemLayout.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
			this.ToolStripMenuItemLayout.DropDownOpening += new System.EventHandler(this.ToolStripMenuItemLayout_DropDownOpening);
			// 
			// ToolStripMenuItemInitLayout
			// 
			this.ToolStripMenuItemInitLayout.AccessibleDescription = null;
			this.ToolStripMenuItemInitLayout.AccessibleName = null;
			resources.ApplyResources(this.ToolStripMenuItemInitLayout, "ToolStripMenuItemInitLayout");
			this.ToolStripMenuItemInitLayout.BackgroundImage = null;
			this.ToolStripMenuItemInitLayout.Name = "ToolStripMenuItemInitLayout";
			this.ToolStripMenuItemInitLayout.ShortcutKeyDisplayString = null;
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.AccessibleDescription = null;
			this.toolStripSeparator3.AccessibleName = null;
			resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			// 
			// ToolStripMenuItemFree
			// 
			this.ToolStripMenuItemFree.AccessibleDescription = null;
			this.ToolStripMenuItemFree.AccessibleName = null;
			resources.ApplyResources(this.ToolStripMenuItemFree, "ToolStripMenuItemFree");
			this.ToolStripMenuItemFree.BackgroundImage = null;
			this.ToolStripMenuItemFree.Name = "ToolStripMenuItemFree";
			this.ToolStripMenuItemFree.ShortcutKeyDisplayString = null;
			this.ToolStripMenuItemFree.Click += new System.EventHandler(this.lblFree_Click);
			// 
			// ToolStripMenuItemParameter
			// 
			this.ToolStripMenuItemParameter.AccessibleDescription = null;
			this.ToolStripMenuItemParameter.AccessibleName = null;
			resources.ApplyResources(this.ToolStripMenuItemParameter, "ToolStripMenuItemParameter");
			this.ToolStripMenuItemParameter.BackColor = System.Drawing.SystemColors.Control;
			this.ToolStripMenuItemParameter.BackgroundImage = null;
			this.ToolStripMenuItemParameter.Name = "ToolStripMenuItemParameter";
			this.ToolStripMenuItemParameter.ShortcutKeyDisplayString = null;
			this.ToolStripMenuItemParameter.Click += new System.EventHandler(this.lblOsilloParam_Click);
			// 
			// ToolStripMenuItemServoGain
			// 
			this.ToolStripMenuItemServoGain.AccessibleDescription = null;
			this.ToolStripMenuItemServoGain.AccessibleName = null;
			resources.ApplyResources(this.ToolStripMenuItemServoGain, "ToolStripMenuItemServoGain");
			this.ToolStripMenuItemServoGain.BackColor = System.Drawing.SystemColors.Control;
			this.ToolStripMenuItemServoGain.BackgroundImage = null;
			this.ToolStripMenuItemServoGain.ForeColor = System.Drawing.Color.Black;
			this.ToolStripMenuItemServoGain.Name = "ToolStripMenuItemServoGain";
			this.ToolStripMenuItemServoGain.ShortcutKeyDisplayString = null;
			this.ToolStripMenuItemServoGain.Click += new System.EventHandler(this.lblOsilloGain_Click);
			// 
			// ToolStripMenuItemAutoTuning
			// 
			this.ToolStripMenuItemAutoTuning.AccessibleDescription = null;
			this.ToolStripMenuItemAutoTuning.AccessibleName = null;
			resources.ApplyResources(this.ToolStripMenuItemAutoTuning, "ToolStripMenuItemAutoTuning");
			this.ToolStripMenuItemAutoTuning.BackgroundImage = null;
			this.ToolStripMenuItemAutoTuning.Name = "ToolStripMenuItemAutoTuning";
			this.ToolStripMenuItemAutoTuning.ShortcutKeyDisplayString = null;
			this.ToolStripMenuItemAutoTuning.Click += new System.EventHandler(this.lblOsilloFFT_Click);
			// 
			// ToolStripMenuItemFFTGain
			// 
			this.ToolStripMenuItemFFTGain.AccessibleDescription = null;
			this.ToolStripMenuItemFFTGain.AccessibleName = null;
			resources.ApplyResources(this.ToolStripMenuItemFFTGain, "ToolStripMenuItemFFTGain");
			this.ToolStripMenuItemFFTGain.BackgroundImage = null;
			this.ToolStripMenuItemFFTGain.Name = "ToolStripMenuItemFFTGain";
			this.ToolStripMenuItemFFTGain.ShortcutKeyDisplayString = null;
			this.ToolStripMenuItemFFTGain.Click += new System.EventHandler(this.lblFFTGain_Click);
			// 
			// ToolStripMenuItemWindow
			// 
			this.ToolStripMenuItemWindow.AccessibleDescription = null;
			this.ToolStripMenuItemWindow.AccessibleName = null;
			resources.ApplyResources(this.ToolStripMenuItemWindow, "ToolStripMenuItemWindow");
			this.ToolStripMenuItemWindow.BackgroundImage = null;
			this.ToolStripMenuItemWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemHorizontal,
            this.ToolStripMenuItemVertical,
            this.ToolStripMenuItemCascade});
			this.ToolStripMenuItemWindow.Name = "ToolStripMenuItemWindow";
			this.ToolStripMenuItemWindow.ShortcutKeyDisplayString = null;
			this.ToolStripMenuItemWindow.MouseHover += new System.EventHandler(this.Control_MouseHover);
			this.ToolStripMenuItemWindow.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
			// 
			// ToolStripMenuItemHorizontal
			// 
			this.ToolStripMenuItemHorizontal.AccessibleDescription = null;
			this.ToolStripMenuItemHorizontal.AccessibleName = null;
			resources.ApplyResources(this.ToolStripMenuItemHorizontal, "ToolStripMenuItemHorizontal");
			this.ToolStripMenuItemHorizontal.BackgroundImage = null;
			this.ToolStripMenuItemHorizontal.Name = "ToolStripMenuItemHorizontal";
			this.ToolStripMenuItemHorizontal.ShortcutKeyDisplayString = null;
			this.ToolStripMenuItemHorizontal.Click += new System.EventHandler(this.tbtnHorizontal_Click);
			// 
			// ToolStripMenuItemVertical
			// 
			this.ToolStripMenuItemVertical.AccessibleDescription = null;
			this.ToolStripMenuItemVertical.AccessibleName = null;
			resources.ApplyResources(this.ToolStripMenuItemVertical, "ToolStripMenuItemVertical");
			this.ToolStripMenuItemVertical.BackgroundImage = null;
			this.ToolStripMenuItemVertical.Name = "ToolStripMenuItemVertical";
			this.ToolStripMenuItemVertical.ShortcutKeyDisplayString = null;
			this.ToolStripMenuItemVertical.Click += new System.EventHandler(this.tbtnVertical_Click);
			// 
			// ToolStripMenuItemCascade
			// 
			this.ToolStripMenuItemCascade.AccessibleDescription = null;
			this.ToolStripMenuItemCascade.AccessibleName = null;
			resources.ApplyResources(this.ToolStripMenuItemCascade, "ToolStripMenuItemCascade");
			this.ToolStripMenuItemCascade.BackgroundImage = null;
			this.ToolStripMenuItemCascade.Name = "ToolStripMenuItemCascade";
			this.ToolStripMenuItemCascade.ShortcutKeyDisplayString = null;
			this.ToolStripMenuItemCascade.Click += new System.EventHandler(this.tbtnCascade_Click);
			// 
			// TimerResize
			// 
			this.TimerResize.Interval = 500;
			this.TimerResize.Tick += new System.EventHandler(this.TimerResize_Tick);
			// 
			// lblMotionDesigner
			// 
			this.lblMotionDesigner.AccessibleDescription = null;
			this.lblMotionDesigner.AccessibleName = null;
			resources.ApplyResources(this.lblMotionDesigner, "lblMotionDesigner");
			this.lblMotionDesigner.BackColor = System.Drawing.Color.Transparent;
			this.lblMotionDesigner.ForeColor = System.Drawing.Color.Gainsboro;
			this.lblMotionDesigner.Name = "lblMotionDesigner";
			// 
			// pnlMain
			// 
			this.pnlMain.AccessibleDescription = null;
			this.pnlMain.AccessibleName = null;
			resources.ApplyResources(this.pnlMain, "pnlMain");
			this.pnlMain.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.pnlMain.BackgroundImage = null;
			this.pnlMain.Controls.Add(this.lblMotionDesigner);
			this.pnlMain.Font = null;
			this.pnlMain.Name = "pnlMain";
			// 
			// ViewMainForm
			// 
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = null;
			this.Controls.Add(this.toolStripViewPallete);
			this.Controls.Add(this.menuStripMain);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this.statusStripViewPallete);
			this.DoubleBuffered = true;
			this.Font = null;
			this.IsMdiContainer = true;
			this.Name = "ViewMainForm";
			this.Load += new System.EventHandler(this.ViewMainForm_Load);
			this.SizeChanged += new System.EventHandler(this.ViewMainForm_SizeChanged);
			this.Shown += new System.EventHandler(this.ViewMainForm_Shown);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewMainForm_FormClosing);
			this.MouseHover += new System.EventHandler(this.Control_MouseHover);
			this.ResizeEnd += new System.EventHandler(this.ViewMainForm_ResizeEnd);
			this.toolStripViewPallete.ResumeLayout(false);
			this.toolStripViewPallete.PerformLayout();
			this.statusStripViewPallete.ResumeLayout(false);
			this.statusStripViewPallete.PerformLayout();
			this.menuStripMain.ResumeLayout(false);
			this.menuStripMain.PerformLayout();
			this.pnlMain.ResumeLayout(false);
			this.pnlMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStripViewPallete;
		private System.Windows.Forms.ToolStripButton tbtnDigitalOsillo;
		private System.Windows.Forms.ToolStripButton tbtnBodeGraph;
		private System.Windows.Forms.ToolStripButton tbtnHorizontal;
		private System.Windows.Forms.ToolStripButton tbtnVertical;
		private System.Windows.Forms.ToolStripButton tbtnParameter;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.StatusStrip statusStripViewPallete;
		private System.Windows.Forms.MenuStrip menuStripMain;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemWindow;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemVertical;
		private System.Windows.Forms.ToolStripStatusLabel lblFree;
		private System.Windows.Forms.ToolStripStatusLabel lblOsilloParam;
		private System.Windows.Forms.ToolStripStatusLabel lblOsilloGain;
		private System.Windows.Forms.ToolStripStatusLabel lblOsilloFFT;
		private System.Windows.Forms.ToolStripButton tbtnCascade;
		private System.Windows.Forms.Timer TimerResize;
		private System.Windows.Forms.ToolStripButton tbtnServoGain;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemHorizontal;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCascade;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemLayout;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFree;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemParameter;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemServoGain;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAutoTuning;
		private System.Windows.Forms.ToolStripStatusLabel lblParam;
		private System.Windows.Forms.ToolStripStatusLabel lblGain;
		private System.Windows.Forms.ToolStripStatusLabel lblOsillo;
		private System.Windows.Forms.ToolStripStatusLabel lblFFT;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemInitLayout;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.Label lblMotionDesigner;
		private System.Windows.Forms.Panel pnlMain;
		private System.Windows.Forms.ToolStripStatusLabel lblFFTGain;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFFTGain;
		private System.Windows.Forms.ToolStripStatusLabel lblWorkspaceInit;
		private System.Windows.Forms.ToolStripStatusLabel lblServoStatus;
		private System.Windows.Forms.ToolStripStatusLabel lblIoStatus;
	}
}