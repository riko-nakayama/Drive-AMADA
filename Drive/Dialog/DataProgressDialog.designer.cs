namespace Motion_Designer
{
	partial class DataProgressDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataProgressDialog));
			this.ProgressBars = new System.Windows.Forms.ProgressBar();
			this.ProgressBarText = new System.Windows.Forms.Label();
			this.pnlProgress = new System.Windows.Forms.Panel();
			this.TimerRefresh = new System.Windows.Forms.Timer(this.components);
			this.lblPanel = new System.Windows.Forms.Label();
			this.pnlProgress.SuspendLayout();
			this.SuspendLayout();
			// 
			// ProgressBars
			// 
			this.ProgressBars.AccessibleDescription = null;
			this.ProgressBars.AccessibleName = null;
			resources.ApplyResources(this.ProgressBars, "ProgressBars");
			this.ProgressBars.BackgroundImage = null;
			this.ProgressBars.Font = null;
			this.ProgressBars.MarqueeAnimationSpeed = 1000;
			this.ProgressBars.Name = "ProgressBars";
			this.ProgressBars.Step = 1;
			// 
			// ProgressBarText
			// 
			this.ProgressBarText.AccessibleDescription = null;
			this.ProgressBarText.AccessibleName = null;
			resources.ApplyResources(this.ProgressBarText, "ProgressBarText");
			this.ProgressBarText.AutoEllipsis = true;
			this.ProgressBarText.ForeColor = System.Drawing.Color.Navy;
			this.ProgressBarText.Name = "ProgressBarText";
			// 
			// pnlProgress
			// 
			this.pnlProgress.AccessibleDescription = null;
			this.pnlProgress.AccessibleName = null;
			resources.ApplyResources(this.pnlProgress, "pnlProgress");
			this.pnlProgress.BackgroundImage = null;
			this.pnlProgress.Controls.Add(this.ProgressBars);
			this.pnlProgress.Font = null;
			this.pnlProgress.Name = "pnlProgress";
			// 
			// TimerRefresh
			// 
			this.TimerRefresh.Interval = 500;
			this.TimerRefresh.Tick += new System.EventHandler(this.TimerRefresh_Tick);
			// 
			// lblPanel
			// 
			this.lblPanel.AccessibleDescription = null;
			this.lblPanel.AccessibleName = null;
			resources.ApplyResources(this.lblPanel, "lblPanel");
			this.lblPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblPanel.Font = null;
			this.lblPanel.Name = "lblPanel";
			// 
			// DataProgressDialog
			// 
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.BackgroundImage = null;
			this.Controls.Add(this.pnlProgress);
			this.Controls.Add(this.ProgressBarText);
			this.Controls.Add(this.lblPanel);
			this.Font = null;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = null;
			this.Name = "DataProgressDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.TopMost = true;
			this.Load += new System.EventHandler(this.ProgressForm_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProgressForm_FormClosing);
			this.pnlProgress.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ProgressBar ProgressBars;
		private System.Windows.Forms.Label ProgressBarText;
		private System.Windows.Forms.Panel pnlProgress;
		private System.Windows.Forms.Timer TimerRefresh;
		private System.Windows.Forms.Label lblPanel;
	}
}