namespace Motion_Designer
{
	partial class BodeGraphForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BodeGraphForm));
            this.toolStripGraph = new System.Windows.Forms.ToolStrip();
            this.tbtnViewGain = new System.Windows.Forms.ToolStripButton();
            this.tbtnViewPhase = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TimerResize = new System.Windows.Forms.Timer(this.components);
            this.ctlBodeGain = new Motion_Designer.CtlBodePlot();
            this.toolStripGraph.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripGraph
            // 
            this.toolStripGraph.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtnViewGain,
            this.tbtnViewPhase,
            this.toolStripSeparator1});
            resources.ApplyResources(this.toolStripGraph, "toolStripGraph");
            this.toolStripGraph.Name = "toolStripGraph";
            this.toolStripGraph.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // tbtnViewGain
            // 
            this.tbtnViewGain.BackColor = System.Drawing.Color.Gold;
            this.tbtnViewGain.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.tbtnViewGain, "tbtnViewGain");
            this.tbtnViewGain.Name = "tbtnViewGain";
            this.tbtnViewGain.Click += new System.EventHandler(this.tbtnViewGain_Click);
            // 
            // tbtnViewPhase
            // 
            this.tbtnViewPhase.BackColor = System.Drawing.Color.Gold;
            this.tbtnViewPhase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.tbtnViewPhase, "tbtnViewPhase");
            this.tbtnViewPhase.Name = "tbtnViewPhase";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // TimerResize
            // 
            this.TimerResize.Interval = 500;
            this.TimerResize.Tick += new System.EventHandler(this.TimerResize_Tick);
            // 
            // ctlBodeGain
            // 
            this.ctlBodeGain.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.ctlBodeGain, "ctlBodeGain");
            this.ctlBodeGain.BodeType = Motion_Designer.CtlBodePlot.EnumBodeType.GAIN;
            this.ctlBodeGain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctlBodeGain.CH1_Name = "CH1";
            this.ctlBodeGain.CH2_Name = "CH2";
            this.ctlBodeGain.CH3_Name = "CH3";
            this.ctlBodeGain.CH4_Name = "CH4";
            this.ctlBodeGain.CH5_Name = "CH5";
            this.ctlBodeGain.CH6_Name = "CH6";
            this.ctlBodeGain.CH7_Name = "CH7";
            this.ctlBodeGain.CH8_Name = "CH7";
            this.ctlBodeGain.GainEnd = -30;
            this.ctlBodeGain.GainTop = 30;
            this.ctlBodeGain.HoldEnabled = true;
            this.ctlBodeGain.IsSweep = false;
            this.ctlBodeGain.IsViewHold = false;
            this.ctlBodeGain.Name = "ctlBodeGain";
            this.ctlBodeGain.VisibleChannelPuls = false;
            this.ctlBodeGain.VisibleChannelPuls2 = false;
            this.ctlBodeGain.VisibleFixed = false;
            this.ctlBodeGain.Y_Unit = "(db)";
            // 
            // BodeGraphForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctlBodeGain);
            this.Controls.Add(this.toolStripGraph);
            this.Name = "BodeGraphForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.BodeViewForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BodeViewForm_Paint);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BodeViewForm_FormClosing);
            this.Resize += new System.EventHandler(this.BodeGraphForm_Resize);
            this.toolStripGraph.ResumeLayout(false);
            this.toolStripGraph.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStripGraph;
		private System.Windows.Forms.ToolStripButton tbtnViewGain;
		private System.Windows.Forms.ToolStripButton tbtnViewPhase;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		public CtlBodePlot ctlBodeGain;
		private System.Windows.Forms.Timer TimerResize;

	}
}