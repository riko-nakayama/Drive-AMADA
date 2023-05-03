namespace Motion_Designer
{
	partial class SelectColumnDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectColumnDialog));
			this.btnNow = new System.Windows.Forms.Button();
			this.lblSelect = new System.Windows.Forms.Label();
			this.btnNew = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnNow
			// 
			this.btnNow.AccessibleDescription = null;
			this.btnNow.AccessibleName = null;
			resources.ApplyResources(this.btnNow, "btnNow");
			this.btnNow.BackgroundImage = null;
			this.btnNow.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.btnNow.Name = "btnNow";
			this.btnNow.UseVisualStyleBackColor = true;
			// 
			// lblSelect
			// 
			this.lblSelect.AccessibleDescription = null;
			this.lblSelect.AccessibleName = null;
			resources.ApplyResources(this.lblSelect, "lblSelect");
			this.lblSelect.Name = "lblSelect";
			// 
			// btnNew
			// 
			this.btnNew.AccessibleDescription = null;
			this.btnNew.AccessibleName = null;
			resources.ApplyResources(this.btnNew, "btnNew");
			this.btnNew.BackgroundImage = null;
			this.btnNew.DialogResult = System.Windows.Forms.DialogResult.No;
			this.btnNew.Name = "btnNew";
			this.btnNew.UseVisualStyleBackColor = true;
			// 
			// SelectColumnDialog
			// 
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = null;
			this.Controls.Add(this.lblSelect);
			this.Controls.Add(this.btnNew);
			this.Controls.Add(this.btnNow);
			this.Font = null;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = null;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SelectColumnDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.TopMost = true;
			this.Load += new System.EventHandler(this.SelectColumnForm_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectColumnForm_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnNow;
		private System.Windows.Forms.Label lblSelect;
		private System.Windows.Forms.Button btnNew;
	}
}