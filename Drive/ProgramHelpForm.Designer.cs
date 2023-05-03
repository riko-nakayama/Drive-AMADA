namespace Motion_Designer
{
	partial class ProgramHelpForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgramHelpForm));
			this.rtxtHelp = new System.Windows.Forms.RichTextBox();
			this.pnlId = new System.Windows.Forms.Panel();
			this.lblCmd = new System.Windows.Forms.Label();
			this.pnlId.SuspendLayout();
			this.SuspendLayout();
			// 
			// rtxtHelp
			// 
			this.rtxtHelp.BackColor = System.Drawing.Color.WhiteSmoke;
			this.rtxtHelp.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtxtHelp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtxtHelp.Font = new System.Drawing.Font("メイリオ", 9F);
			this.rtxtHelp.Location = new System.Drawing.Point(0, 45);
			this.rtxtHelp.Name = "rtxtHelp";
			this.rtxtHelp.ReadOnly = true;
			this.rtxtHelp.ShowSelectionMargin = true;
			this.rtxtHelp.Size = new System.Drawing.Size(464, 157);
			this.rtxtHelp.TabIndex = 2;
			this.rtxtHelp.Text = "";
			// 
			// pnlId
			// 
			this.pnlId.Controls.Add(this.lblCmd);
			this.pnlId.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlId.Location = new System.Drawing.Point(0, 0);
			this.pnlId.Name = "pnlId";
			this.pnlId.Size = new System.Drawing.Size(464, 45);
			this.pnlId.TabIndex = 3;
			// 
			// lblCmd
			// 
			this.lblCmd.AutoSize = true;
			this.lblCmd.Font = new System.Drawing.Font("メイリオ", 9F);
			this.lblCmd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lblCmd.Location = new System.Drawing.Point(10, 15);
			this.lblCmd.Name = "lblCmd";
			this.lblCmd.Size = new System.Drawing.Size(68, 18);
			this.lblCmd.TabIndex = 0;
			this.lblCmd.Text = "Command";
			// 
			// ProgramHelpForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(464, 202);
			this.Controls.Add(this.rtxtHelp);
			this.Controls.Add(this.pnlId);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ProgramHelpForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Program Help";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.ProgramHelpForm_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProgramHelpForm_FormClosing);
			this.pnlId.ResumeLayout(false);
			this.pnlId.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RichTextBox rtxtHelp;
		private System.Windows.Forms.Panel pnlId;
		private System.Windows.Forms.Label lblCmd;
	}
}