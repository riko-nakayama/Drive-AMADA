namespace Motion_Designer
{
	partial class CtlBodePlot
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBodePlot));
			this.colorDialogBode = new System.Windows.Forms.ColorDialog();
			this.picBodePlot = new System.Windows.Forms.PictureBox();
			this.lblQuickView = new System.Windows.Forms.Label();
			this.pnlBodePlot = new System.Windows.Forms.Panel();
			this.ctlPlotMenu = new Motion_Designer.CtlPlotMenu();
			((System.ComponentModel.ISupportInitialize)(this.picBodePlot)).BeginInit();
			this.pnlBodePlot.SuspendLayout();
			this.SuspendLayout();
			// 
			// picBodePlot
			// 
			this.picBodePlot.BackColor = System.Drawing.Color.White;
			resources.ApplyResources(this.picBodePlot, "picBodePlot");
			this.picBodePlot.Name = "picBodePlot";
			this.picBodePlot.TabStop = false;
			this.picBodePlot.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picBodePlot_MouseMove);
			this.picBodePlot.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBodePlot_MouseDown);
			this.picBodePlot.Paint += new System.Windows.Forms.PaintEventHandler(this.picBodePlot_Paint);
			// 
			// lblQuickView
			// 
			resources.ApplyResources(this.lblQuickView, "lblQuickView");
			this.lblQuickView.BackColor = System.Drawing.Color.LemonChiffon;
			this.lblQuickView.Name = "lblQuickView";
			// 
			// pnlBodePlot
			// 
			this.pnlBodePlot.Controls.Add(this.lblQuickView);
			this.pnlBodePlot.Controls.Add(this.picBodePlot);
			resources.ApplyResources(this.pnlBodePlot, "pnlBodePlot");
			this.pnlBodePlot.Name = "pnlBodePlot";
			// 
			// ctlPlotMenu
			// 
			resources.ApplyResources(this.ctlPlotMenu, "ctlPlotMenu");
			this.ctlPlotMenu.CH1_Name = "";
			this.ctlPlotMenu.CH2_Name = "";
			this.ctlPlotMenu.CH3_Name = "";
			this.ctlPlotMenu.CH4_Name = "";
			this.ctlPlotMenu.CH5_Name = "";
			this.ctlPlotMenu.CH6_Name = "";
			this.ctlPlotMenu.CH7_Name = "";
			this.ctlPlotMenu.CH8_Name = "";
			this.ctlPlotMenu.HoldEnabled = true;
			this.ctlPlotMenu.IsViewHold = false;
			this.ctlPlotMenu.MeasIndex = 100;
			this.ctlPlotMenu.Name = "ctlPlotMenu";
			this.ctlPlotMenu.VisibleChannelPuls = true;
			this.ctlPlotMenu.VisibleChannelPuls2 = true;
			this.ctlPlotMenu.VisibleFixed = false;
			this.ctlPlotMenu.Load += new System.EventHandler(this.ctlPlotMenu_Load);
			// 
			// CtlBodePlot
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.Controls.Add(this.pnlBodePlot);
			this.Controls.Add(this.ctlPlotMenu);
			this.Name = "CtlBodePlot";
			this.Load += new System.EventHandler(this.ctlBoadGain_Load);
			((System.ComponentModel.ISupportInitialize)(this.picBodePlot)).EndInit();
			this.pnlBodePlot.ResumeLayout(false);
			this.pnlBodePlot.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox picBodePlot;
		private System.Windows.Forms.ColorDialog colorDialogBode;
		private Motion_Designer.CtlPlotMenu ctlPlotMenu;
		private System.Windows.Forms.Label lblQuickView;
		private System.Windows.Forms.Panel pnlBodePlot;
	}
}
