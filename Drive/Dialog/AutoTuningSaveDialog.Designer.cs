namespace Motion_Designer
{
	partial class AutoTuningSaveDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoTuningSaveDialog));
			this.lblSaveSetting1 = new System.Windows.Forms.Label();
			this.lblSaveSetting2 = new System.Windows.Forms.Label();
			this.chkSaveMemory = new System.Windows.Forms.CheckBox();
			this.chkSevaFile = new System.Windows.Forms.CheckBox();
			this.lblSaveSetting3 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblSaveSetting1
			// 
			resources.ApplyResources(this.lblSaveSetting1, "lblSaveSetting1");
			this.lblSaveSetting1.ForeColor = System.Drawing.Color.Blue;
			this.lblSaveSetting1.Name = "lblSaveSetting1";
			// 
			// lblSaveSetting2
			// 
			resources.ApplyResources(this.lblSaveSetting2, "lblSaveSetting2");
			this.lblSaveSetting2.ForeColor = System.Drawing.Color.Crimson;
			this.lblSaveSetting2.Name = "lblSaveSetting2";
			// 
			// chkSaveMemory
			// 
			resources.ApplyResources(this.chkSaveMemory, "chkSaveMemory");
			this.chkSaveMemory.Name = "chkSaveMemory";
			this.chkSaveMemory.UseVisualStyleBackColor = true;
			// 
			// chkSevaFile
			// 
			resources.ApplyResources(this.chkSevaFile, "chkSevaFile");
			this.chkSevaFile.Name = "chkSevaFile";
			this.chkSevaFile.UseVisualStyleBackColor = true;
			// 
			// lblSaveSetting3
			// 
			resources.ApplyResources(this.lblSaveSetting3, "lblSaveSetting3");
			this.lblSaveSetting3.ForeColor = System.Drawing.Color.Crimson;
			this.lblSaveSetting3.Name = "lblSaveSetting3";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.chkSaveMemory);
			this.groupBox1.Controls.Add(this.chkSevaFile);
			resources.ApplyResources(this.groupBox1, "groupBox1");
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.TabStop = false;
			// 
			// btnOk
			// 
			resources.ApplyResources(this.btnOk, "btnOk");
			this.btnOk.Name = "btnOk";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// AutoTuningSaveDialog
			// 
			this.AcceptButton = this.btnOk;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.lblSaveSetting3);
			this.Controls.Add(this.lblSaveSetting2);
			this.Controls.Add(this.lblSaveSetting1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "AutoTuningSaveDialog";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.AutoTuningSaveForm_Load);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AutoTuningSaveDialog_FormClosed);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AutoTuningSaveForm_FormClosing);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblSaveSetting2;
		private System.Windows.Forms.CheckBox chkSaveMemory;
		private System.Windows.Forms.CheckBox chkSevaFile;
		private System.Windows.Forms.Label lblSaveSetting1;
		private System.Windows.Forms.Label lblSaveSetting3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
	}
}