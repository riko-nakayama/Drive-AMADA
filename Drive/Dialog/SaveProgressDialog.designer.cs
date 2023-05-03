namespace Motion_Designer
{
	partial class SaveProgressDialog
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
			this.prgSave = new System.Windows.Forms.ProgressBar();
			this.lblSave = new System.Windows.Forms.Label();
			this.lblPanel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// prgSave
			// 
			this.prgSave.Location = new System.Drawing.Point(50, 35);
			this.prgSave.Name = "prgSave";
			this.prgSave.Size = new System.Drawing.Size(300, 30);
			this.prgSave.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.prgSave.TabIndex = 2;
			// 
			// lblSave
			// 
			this.lblSave.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblSave.ForeColor = System.Drawing.Color.Navy;
			this.lblSave.Location = new System.Drawing.Point(50, 10);
			this.lblSave.Name = "lblSave";
			this.lblSave.Size = new System.Drawing.Size(300, 20);
			this.lblSave.TabIndex = 3;
			this.lblSave.Text = "Parameters are being saved in flash memory.";
			this.lblSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblPanel
			// 
			this.lblPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblPanel.Location = new System.Drawing.Point(0, 0);
			this.lblPanel.Name = "lblPanel";
			this.lblPanel.Size = new System.Drawing.Size(400, 80);
			this.lblPanel.TabIndex = 4;
			// 
			// SaveProgressDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(400, 80);
			this.Controls.Add(this.lblSave);
			this.Controls.Add(this.prgSave);
			this.Controls.Add(this.lblPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "SaveProgressDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SaveForm";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.SaveForm_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SaveForm_FormClosing);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ProgressBar prgSave;
		private System.Windows.Forms.Label lblSave;
		private System.Windows.Forms.Label lblPanel;
	}
}