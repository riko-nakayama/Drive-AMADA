namespace Motion_Designer
{
	partial class LineStyleDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LineStyleDialog));
			this.cmbLine = new System.Windows.Forms.ComboBox();
			this.cmbSize = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.pnlDummy = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.lblTitle = new System.Windows.Forms.Label();
			this.btnGo2 = new System.Windows.Forms.Button();
			this.btnBack2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cmbLine
			// 
			this.cmbLine.AccessibleDescription = null;
			this.cmbLine.AccessibleName = null;
			resources.ApplyResources(this.cmbLine, "cmbLine");
			this.cmbLine.BackgroundImage = null;
			this.cmbLine.FormattingEnabled = true;
			this.cmbLine.Items.AddRange(new object[] {
            resources.GetString("cmbLine.Items"),
            resources.GetString("cmbLine.Items1"),
            resources.GetString("cmbLine.Items2"),
            resources.GetString("cmbLine.Items3"),
            resources.GetString("cmbLine.Items4")});
			this.cmbLine.Name = "cmbLine";
			this.cmbLine.SelectedIndexChanged += new System.EventHandler(this.cmbLine_SelectedIndexChanged);
			// 
			// cmbSize
			// 
			this.cmbSize.AccessibleDescription = null;
			this.cmbSize.AccessibleName = null;
			resources.ApplyResources(this.cmbSize, "cmbSize");
			this.cmbSize.BackgroundImage = null;
			this.cmbSize.FormattingEnabled = true;
			this.cmbSize.Items.AddRange(new object[] {
            resources.GetString("cmbSize.Items"),
            resources.GetString("cmbSize.Items1"),
            resources.GetString("cmbSize.Items2"),
            resources.GetString("cmbSize.Items3"),
            resources.GetString("cmbSize.Items4"),
            resources.GetString("cmbSize.Items5"),
            resources.GetString("cmbSize.Items6"),
            resources.GetString("cmbSize.Items7"),
            resources.GetString("cmbSize.Items8"),
            resources.GetString("cmbSize.Items9"),
            resources.GetString("cmbSize.Items10")});
			this.cmbSize.Name = "cmbSize";
			this.cmbSize.SelectedIndexChanged += new System.EventHandler(this.cmbSize_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AccessibleDescription = null;
			this.label1.AccessibleName = null;
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// label2
			// 
			this.label2.AccessibleDescription = null;
			this.label2.AccessibleName = null;
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// pnlDummy
			// 
			this.pnlDummy.AccessibleDescription = null;
			this.pnlDummy.AccessibleName = null;
			resources.ApplyResources(this.pnlDummy, "pnlDummy");
			this.pnlDummy.BackgroundImage = null;
			this.pnlDummy.Font = null;
			this.pnlDummy.Name = "pnlDummy";
			// 
			// btnCancel
			// 
			this.btnCancel.AccessibleDescription = null;
			this.btnCancel.AccessibleName = null;
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.BackgroundImage = null;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOk
			// 
			this.btnOk.AccessibleDescription = null;
			this.btnOk.AccessibleName = null;
			resources.ApplyResources(this.btnOk, "btnOk");
			this.btnOk.BackgroundImage = null;
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Name = "btnOk";
			this.btnOk.UseVisualStyleBackColor = true;
			// 
			// lblTitle
			// 
			this.lblTitle.AccessibleDescription = null;
			this.lblTitle.AccessibleName = null;
			resources.ApplyResources(this.lblTitle, "lblTitle");
			this.lblTitle.ForeColor = System.Drawing.Color.Navy;
			this.lblTitle.Name = "lblTitle";
			// 
			// btnGo2
			// 
			this.btnGo2.AccessibleDescription = null;
			this.btnGo2.AccessibleName = null;
			resources.ApplyResources(this.btnGo2, "btnGo2");
			this.btnGo2.BackgroundImage = null;
			this.btnGo2.Font = null;
			this.btnGo2.Name = "btnGo2";
			this.btnGo2.Tag = "";
			this.btnGo2.UseVisualStyleBackColor = true;
			this.btnGo2.Click += new System.EventHandler(this.btnGo2_Click);
			// 
			// btnBack2
			// 
			this.btnBack2.AccessibleDescription = null;
			this.btnBack2.AccessibleName = null;
			resources.ApplyResources(this.btnBack2, "btnBack2");
			this.btnBack2.BackgroundImage = null;
			this.btnBack2.Font = null;
			this.btnBack2.Name = "btnBack2";
			this.btnBack2.Tag = "";
			this.btnBack2.UseVisualStyleBackColor = true;
			this.btnBack2.Click += new System.EventHandler(this.btnBack2_Click);
			// 
			// LineStyleDialog
			// 
			this.AcceptButton = this.btnOk;
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = null;
			this.CancelButton = this.btnCancel;
			this.Controls.Add(this.btnGo2);
			this.Controls.Add(this.btnBack2);
			this.Controls.Add(this.lblTitle);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.pnlDummy);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmbSize);
			this.Controls.Add(this.cmbLine);
			this.Font = null;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = null;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LineStyleDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.TopMost = true;
			this.Load += new System.EventHandler(this.LineStyleDialog_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LineStyleDialog_FormClosing);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LineStyleDialog_KeyDown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cmbLine;
		private System.Windows.Forms.ComboBox cmbSize;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel pnlDummy;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Button btnBack2;
		private System.Windows.Forms.Button btnGo2;
	}
}