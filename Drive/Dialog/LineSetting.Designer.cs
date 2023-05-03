namespace Motion_Designer
{
	partial class LineSetting
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LineSetting));
			this.grpLineSetting = new System.Windows.Forms.GroupBox();
			this.fpnlLineSetting = new System.Windows.Forms.FlowLayoutPanel();
			this.cmbLineSetting = new System.Windows.Forms.ComboBox();
			this.btnColorSetting = new System.Windows.Forms.Button();
			this.chkLineSetting = new System.Windows.Forms.CheckBox();
			this.ColorDialog = new System.Windows.Forms.ColorDialog();
			this.btnBack = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnLineSetting = new System.Windows.Forms.Button();
			this.grpLineSetting.SuspendLayout();
			this.fpnlLineSetting.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpLineSetting
			// 
			this.grpLineSetting.Controls.Add(this.fpnlLineSetting);
			this.grpLineSetting.Controls.Add(this.btnColorSetting);
			this.grpLineSetting.Controls.Add(this.btnLineSetting);
			this.grpLineSetting.Controls.Add(this.chkLineSetting);
			this.grpLineSetting.Location = new System.Drawing.Point(0, 0);
			this.grpLineSetting.Name = "grpLineSetting";
			this.grpLineSetting.Size = new System.Drawing.Size(120, 75);
			this.grpLineSetting.TabIndex = 1;
			this.grpLineSetting.TabStop = false;
			this.grpLineSetting.Text = "項目";
			// 
			// fpnlLineSetting
			// 
			this.fpnlLineSetting.Controls.Add(this.btnBack);
			this.fpnlLineSetting.Controls.Add(this.cmbLineSetting);
			this.fpnlLineSetting.Controls.Add(this.btnNext);
			this.fpnlLineSetting.Location = new System.Drawing.Point(5, 45);
			this.fpnlLineSetting.Name = "fpnlLineSetting";
			this.fpnlLineSetting.Size = new System.Drawing.Size(105, 25);
			this.fpnlLineSetting.TabIndex = 3;
			// 
			// cmbLineSetting
			// 
			this.cmbLineSetting.FormattingEnabled = true;
			this.cmbLineSetting.Location = new System.Drawing.Point(25, 2);
			this.cmbLineSetting.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.cmbLineSetting.Name = "cmbLineSetting";
			this.cmbLineSetting.Size = new System.Drawing.Size(55, 20);
			this.cmbLineSetting.TabIndex = 4;
			this.cmbLineSetting.Text = "10000";
			// 
			// btnColorSetting
			// 
			this.btnColorSetting.BackColor = global::Motion_Designer.Properties.Settings.Default.WAVE_PosColor;
			this.btnColorSetting.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::Motion_Designer.Properties.Settings.Default, "WAVE_PosColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.btnColorSetting.Location = new System.Drawing.Point(85, 15);
			this.btnColorSetting.Name = "btnColorSetting";
			this.btnColorSetting.Size = new System.Drawing.Size(25, 25);
			this.btnColorSetting.TabIndex = 2;
			this.btnColorSetting.UseVisualStyleBackColor = false;
			// 
			// chkLineSetting
			// 
			this.chkLineSetting.AutoSize = true;
			this.chkLineSetting.Location = new System.Drawing.Point(5, 20);
			this.chkLineSetting.Name = "chkLineSetting";
			this.chkLineSetting.Size = new System.Drawing.Size(48, 16);
			this.chkLineSetting.TabIndex = 2;
			this.chkLineSetting.Text = "可視";
			this.chkLineSetting.UseVisualStyleBackColor = true;
			// 
			// btnBack
			// 
			this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
			this.btnBack.Location = new System.Drawing.Point(0, 0);
			this.btnBack.Margin = new System.Windows.Forms.Padding(0);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(25, 25);
			this.btnBack.TabIndex = 2;
			this.btnBack.UseVisualStyleBackColor = true;
			// 
			// btnNext
			// 
			this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
			this.btnNext.Location = new System.Drawing.Point(80, 0);
			this.btnNext.Margin = new System.Windows.Forms.Padding(0);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(25, 25);
			this.btnNext.TabIndex = 2;
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnLineSetting
			// 
			this.btnLineSetting.Image = ((System.Drawing.Image)(resources.GetObject("btnLineSetting.Image")));
			this.btnLineSetting.Location = new System.Drawing.Point(55, 15);
			this.btnLineSetting.Name = "btnLineSetting";
			this.btnLineSetting.Size = new System.Drawing.Size(25, 25);
			this.btnLineSetting.TabIndex = 2;
			this.btnLineSetting.UseVisualStyleBackColor = true;
			// 
			// LineSetting
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.grpLineSetting);
			this.Title = "LineSetting";
			this.Size = new System.Drawing.Size(120, 75);
			this.grpLineSetting.ResumeLayout(false);
			this.grpLineSetting.PerformLayout();
			this.fpnlLineSetting.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox grpLineSetting;
		private System.Windows.Forms.FlowLayoutPanel fpnlLineSetting;
		private System.Windows.Forms.Button btnBack;
		private System.Windows.Forms.ComboBox cmbLineSetting;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnColorSetting;
		private System.Windows.Forms.Button btnLineSetting;
		private System.Windows.Forms.CheckBox chkLineSetting;
		private System.Windows.Forms.ColorDialog ColorDialog;
	}
}
