namespace Motion_Designer
{
	partial class ComSettingDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComSettingDialog));
			this.cmbCom = new System.Windows.Forms.ComboBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.lblComNo = new System.Windows.Forms.Label();
			this.lblBaudrate = new System.Windows.Forms.Label();
			this.cmbBaudrate = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// cmbCom
			// 
			this.cmbCom.AccessibleDescription = null;
			this.cmbCom.AccessibleName = null;
			resources.ApplyResources(this.cmbCom, "cmbCom");
			this.cmbCom.BackgroundImage = null;
			this.cmbCom.FormattingEnabled = true;
			this.cmbCom.Name = "cmbCom";
			this.cmbCom.TabStop = false;
			this.cmbCom.SelectedIndexChanged += new System.EventHandler(this.cmbCom_SelectedIndexChanged);
			// 
			// btnOk
			// 
			this.btnOk.AccessibleDescription = null;
			this.btnOk.AccessibleName = null;
			resources.ApplyResources(this.btnOk, "btnOk");
			this.btnOk.BackgroundImage = null;
			this.btnOk.Name = "btnOk";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// lblComNo
			// 
			this.lblComNo.AccessibleDescription = null;
			this.lblComNo.AccessibleName = null;
			resources.ApplyResources(this.lblComNo, "lblComNo");
			this.lblComNo.Name = "lblComNo";
			// 
			// lblBaudrate
			// 
			this.lblBaudrate.AccessibleDescription = null;
			this.lblBaudrate.AccessibleName = null;
			resources.ApplyResources(this.lblBaudrate, "lblBaudrate");
			this.lblBaudrate.Name = "lblBaudrate";
			// 
			// cmbBaudrate
			// 
			this.cmbBaudrate.AccessibleDescription = null;
			this.cmbBaudrate.AccessibleName = null;
			resources.ApplyResources(this.cmbBaudrate, "cmbBaudrate");
			this.cmbBaudrate.BackgroundImage = null;
			this.cmbBaudrate.FormattingEnabled = true;
			this.cmbBaudrate.Name = "cmbBaudrate";
			this.cmbBaudrate.TabStop = false;
			this.cmbBaudrate.SelectedIndexChanged += new System.EventHandler(this.cmbBaudrate_SelectedIndexChanged);
			// 
			// ComSettingDialog
			// 
			this.AcceptButton = this.btnOk;
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = null;
			this.Controls.Add(this.lblBaudrate);
			this.Controls.Add(this.lblComNo);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.cmbBaudrate);
			this.Controls.Add(this.cmbCom);
			this.Font = null;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = null;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ComSettingDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.TopMost = true;
			this.Load += new System.EventHandler(this.ComSettingForm_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ComSettingForm_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cmbCom;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label lblComNo;
		private System.Windows.Forms.Label lblBaudrate;
		private System.Windows.Forms.ComboBox cmbBaudrate;
	}
}