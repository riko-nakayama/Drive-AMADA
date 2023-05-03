namespace Motion_Designer
{
	partial class ParameterHelpForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParameterHelpForm));
			this.lblId = new System.Windows.Forms.Label();
			this.lblItem = new System.Windows.Forms.Label();
			this.rtxtHelp = new System.Windows.Forms.RichTextBox();
			this.pnlId = new System.Windows.Forms.Panel();
			this.pnlId.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblId
			// 
			this.lblId.AccessibleDescription = null;
			this.lblId.AccessibleName = null;
			resources.ApplyResources(this.lblId, "lblId");
			this.lblId.Name = "lblId";
			// 
			// lblItem
			// 
			this.lblItem.AccessibleDescription = null;
			this.lblItem.AccessibleName = null;
			resources.ApplyResources(this.lblItem, "lblItem");
			this.lblItem.Name = "lblItem";
			// 
			// rtxtHelp
			// 
			this.rtxtHelp.AccessibleDescription = null;
			this.rtxtHelp.AccessibleName = null;
			resources.ApplyResources(this.rtxtHelp, "rtxtHelp");
			this.rtxtHelp.BackColor = System.Drawing.Color.WhiteSmoke;
			this.rtxtHelp.BackgroundImage = null;
			this.rtxtHelp.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtxtHelp.Name = "rtxtHelp";
			this.rtxtHelp.ReadOnly = true;
			this.rtxtHelp.ShowSelectionMargin = true;
			// 
			// pnlId
			// 
			this.pnlId.AccessibleDescription = null;
			this.pnlId.AccessibleName = null;
			resources.ApplyResources(this.pnlId, "pnlId");
			this.pnlId.BackgroundImage = null;
			this.pnlId.Controls.Add(this.lblId);
			this.pnlId.Controls.Add(this.lblItem);
			this.pnlId.Font = null;
			this.pnlId.Name = "pnlId";
			// 
			// ParameterHelpForm
			// 
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = null;
			this.Controls.Add(this.rtxtHelp);
			this.Controls.Add(this.pnlId);
			this.Font = null;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ParameterHelpForm";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.ParameterHelpForm_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ParameterHelpForm_FormClosing);
			this.pnlId.ResumeLayout(false);
			this.pnlId.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblId;
		private System.Windows.Forms.Label lblItem;
		private System.Windows.Forms.RichTextBox rtxtHelp;
		private System.Windows.Forms.Panel pnlId;
	}
}