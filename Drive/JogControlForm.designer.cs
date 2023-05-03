namespace Motion_Designer
{
	partial class JogControlForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JogControlForm));
			this.toolStripJog = new System.Windows.Forms.ToolStrip();
			this.tlblControlMode = new System.Windows.Forms.ToolStripLabel();
			this.sep4 = new System.Windows.Forms.ToolStripSeparator();
			this.btnBackMode = new System.Windows.Forms.ToolStripButton();
			this.cmbControlMode = new System.Windows.Forms.ToolStripComboBox();
			this.btnNextMode = new System.Windows.Forms.ToolStripButton();
			this.sep5 = new System.Windows.Forms.ToolStripSeparator();
			this.lblDummy = new System.Windows.Forms.Label();
			this.TimerResize = new System.Windows.Forms.Timer(this.components);
			this.TimerWait = new System.Windows.Forms.Timer(this.components);
			this.ctlJog = new Motion_Designer.CtlJogControl();
			this.toolStripJog.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStripJog
			// 
			this.toolStripJog.AccessibleDescription = null;
			this.toolStripJog.AccessibleName = null;
			resources.ApplyResources(this.toolStripJog, "toolStripJog");
			this.toolStripJog.BackgroundImage = null;
			this.toolStripJog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlblControlMode,
            this.sep4,
            this.btnBackMode,
            this.cmbControlMode,
            this.btnNextMode,
            this.sep5});
			this.toolStripJog.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			this.toolStripJog.Name = "toolStripJog";
			this.toolStripJog.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			// 
			// tlblControlMode
			// 
			this.tlblControlMode.AccessibleDescription = null;
			this.tlblControlMode.AccessibleName = null;
			resources.ApplyResources(this.tlblControlMode, "tlblControlMode");
			this.tlblControlMode.BackgroundImage = null;
			this.tlblControlMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tlblControlMode.Name = "tlblControlMode";
			this.tlblControlMode.MouseHover += new System.EventHandler(this.Control_MouseHover);
			this.tlblControlMode.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
			// 
			// sep4
			// 
			this.sep4.AccessibleDescription = null;
			this.sep4.AccessibleName = null;
			resources.ApplyResources(this.sep4, "sep4");
			this.sep4.Name = "sep4";
			// 
			// btnBackMode
			// 
			this.btnBackMode.AccessibleDescription = null;
			this.btnBackMode.AccessibleName = null;
			resources.ApplyResources(this.btnBackMode, "btnBackMode");
			this.btnBackMode.BackgroundImage = null;
			this.btnBackMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnBackMode.Name = "btnBackMode";
			this.btnBackMode.MouseHover += new System.EventHandler(this.Control_MouseHover);
			this.btnBackMode.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
			this.btnBackMode.Click += new System.EventHandler(this.btnBackMode_Click);
			// 
			// cmbControlMode
			// 
			this.cmbControlMode.AccessibleDescription = null;
			this.cmbControlMode.AccessibleName = null;
			resources.ApplyResources(this.cmbControlMode, "cmbControlMode");
			this.cmbControlMode.DropDownWidth = 100;
			this.cmbControlMode.Items.AddRange(new object[] {
            resources.GetString("cmbControlMode.Items"),
            resources.GetString("cmbControlMode.Items1"),
            resources.GetString("cmbControlMode.Items2"),
            resources.GetString("cmbControlMode.Items3"),
            resources.GetString("cmbControlMode.Items4")});
			this.cmbControlMode.Name = "cmbControlMode";
			this.cmbControlMode.SelectedIndexChanged += new System.EventHandler(this.cmbMode_SelectedIndexChanged);
			this.cmbControlMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbJog_KeyDown);
			this.cmbControlMode.MouseHover += new System.EventHandler(this.Control_MouseHover);
			this.cmbControlMode.DropDown += new System.EventHandler(this.cmbControlMode_DropDown);
			this.cmbControlMode.DropDownClosed += new System.EventHandler(this.cmbControlMode_DropDownClosed);
			this.cmbControlMode.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
			this.cmbControlMode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbJog_KeyPress);
			// 
			// btnNextMode
			// 
			this.btnNextMode.AccessibleDescription = null;
			this.btnNextMode.AccessibleName = null;
			resources.ApplyResources(this.btnNextMode, "btnNextMode");
			this.btnNextMode.BackgroundImage = null;
			this.btnNextMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnNextMode.Name = "btnNextMode";
			this.btnNextMode.MouseHover += new System.EventHandler(this.Control_MouseHover);
			this.btnNextMode.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
			this.btnNextMode.Click += new System.EventHandler(this.btnNextMode_Click);
			// 
			// sep5
			// 
			this.sep5.AccessibleDescription = null;
			this.sep5.AccessibleName = null;
			resources.ApplyResources(this.sep5, "sep5");
			this.sep5.Name = "sep5";
			// 
			// lblDummy
			// 
			this.lblDummy.AccessibleDescription = null;
			this.lblDummy.AccessibleName = null;
			resources.ApplyResources(this.lblDummy, "lblDummy");
			this.lblDummy.Font = null;
			this.lblDummy.Name = "lblDummy";
			// 
			// TimerResize
			// 
			this.TimerResize.Interval = 500;
			this.TimerResize.Tick += new System.EventHandler(this.TimerResize_Tick);
			// 
			// TimerWait
			// 
			this.TimerWait.Interval = 500;
			this.TimerWait.Tick += new System.EventHandler(this.TimerWait_Tick);
			// 
			// ctlJog
			// 
			this.ctlJog.AccessibleDescription = null;
			this.ctlJog.AccessibleName = null;
			resources.ApplyResources(this.ctlJog, "ctlJog");
			this.ctlJog.BackColor = System.Drawing.SystemColors.Control;
			this.ctlJog.BackgroundImage = null;
			this.ctlJog.FaultBackColor = System.Drawing.Color.Black;
			this.ctlJog.ForwardLimitBackColor = System.Drawing.Color.Black;
			this.ctlJog.InPositionBackColor = System.Drawing.Color.Black;
			this.ctlJog.Name = "ctlJog";
			this.ctlJog.NetType = Motion_Designer.NET_TYPE.SV_NET;
			this.ctlJog.PositionText = "0";
			this.ctlJog.ProfileBackColor = System.Drawing.Color.Black;
			this.ctlJog.ReverseLimitBackColor = System.Drawing.Color.Black;
			this.ctlJog.ServoOnBackColor = System.Drawing.Color.Black;
			this.ctlJog.TargetVelocity = 100;
			this.ctlJog.TorqueLimitBackColor = System.Drawing.Color.Black;
			this.ctlJog.VelocityLimitBackColor = System.Drawing.Color.Black;
			this.ctlJog.Click += new System.EventHandler(this.ctlJog_Click);
			this.ctlJog.MouseHover += new System.EventHandler(this.Control_MouseHover);
			// 
			// JogControlForm
			// 
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = null;
			this.Controls.Add(this.lblDummy);
			this.Controls.Add(this.ctlJog);
			this.Controls.Add(this.toolStripJog);
			this.DoubleBuffered = true;
			this.Name = "JogControlForm";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.JogControlForm_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.JogControlForm_FormClosing);
			this.Resize += new System.EventHandler(this.JogControlForm_Resize);
			this.toolStripJog.ResumeLayout(false);
			this.toolStripJog.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStripJog;
		private CtlJogControl ctlJog;
		private System.Windows.Forms.ToolStripButton btnBackMode;
		private System.Windows.Forms.ToolStripComboBox cmbControlMode;
		private System.Windows.Forms.ToolStripButton btnNextMode;
		private System.Windows.Forms.ToolStripSeparator sep5;
		private System.Windows.Forms.Label lblDummy;
		private System.Windows.Forms.ToolStripSeparator sep4;
		private System.Windows.Forms.ToolStripLabel tlblControlMode;
		private System.Windows.Forms.Timer TimerResize;
		private System.Windows.Forms.Timer TimerWait;

	}
}