namespace Motion_Designer
{
	partial class FirmwareUpgradeDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirmwareUpgradeDialog));
			this.btnCom = new System.Windows.Forms.Button();
			this.btnStartUpgrade = new System.Windows.Forms.Button();
			this.rtxtResult = new System.Windows.Forms.RichTextBox();
			this.TimerDfuStart = new System.Windows.Forms.Timer(this.components);
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.lblMode = new System.Windows.Forms.ToolStripLabel();
			this.cmbMode = new System.Windows.Forms.ToolStripComboBox();
			this.chkBootMode = new System.Windows.Forms.CheckBox();
			this.lblResult = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.lblDfu = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblUsb = new System.Windows.Forms.ToolStripStatusLabel();
			this.TimerUsbDevice = new System.Windows.Forms.Timer(this.components);
			this.toolStrip.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnCom
			// 
			resources.ApplyResources(this.btnCom, "btnCom");
			this.btnCom.Name = "btnCom";
			this.btnCom.UseVisualStyleBackColor = true;
			// 
			// btnStartUpgrade
			// 
			resources.ApplyResources(this.btnStartUpgrade, "btnStartUpgrade");
			this.btnStartUpgrade.Name = "btnStartUpgrade";
			this.btnStartUpgrade.UseVisualStyleBackColor = true;
			this.btnStartUpgrade.Click += new System.EventHandler(this.btnStartUpgrade_Click);
			// 
			// rtxtResult
			// 
			this.rtxtResult.BackColor = System.Drawing.SystemColors.Control;
			resources.ApplyResources(this.rtxtResult, "rtxtResult");
			this.rtxtResult.Name = "rtxtResult";
			// 
			// TimerDfuStart
			// 
			this.TimerDfuStart.Interval = 500;
			this.TimerDfuStart.Tick += new System.EventHandler(this.TimerDfuStart_Tick);
			// 
			// OpenFileDialog
			// 
			this.OpenFileDialog.FileName = "openFileDialog";
			resources.ApplyResources(this.OpenFileDialog, "OpenFileDialog");
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMode,
            this.cmbMode});
			resources.ApplyResources(this.toolStrip, "toolStrip");
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			// 
			// lblMode
			// 
			this.lblMode.Name = "lblMode";
			resources.ApplyResources(this.lblMode, "lblMode");
			// 
			// cmbMode
			// 
			this.cmbMode.Items.AddRange(new object[] {
            resources.GetString("cmbMode.Items"),
            resources.GetString("cmbMode.Items1")});
			this.cmbMode.Name = "cmbMode";
			resources.ApplyResources(this.cmbMode, "cmbMode");
			this.cmbMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMode_KeyDown);
			this.cmbMode.TextChanged += new System.EventHandler(this.cmbMode_TextChanged);
			this.cmbMode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbMode_KeyPress);
			// 
			// chkBootMode
			// 
			resources.ApplyResources(this.chkBootMode, "chkBootMode");
			this.chkBootMode.Name = "chkBootMode";
			this.chkBootMode.UseVisualStyleBackColor = true;
			// 
			// lblResult
			// 
			resources.ApplyResources(this.lblResult, "lblResult");
			this.lblResult.Name = "lblResult";
			// 
			// btnCancel
			// 
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// statusStrip
			// 
			resources.ApplyResources(this.statusStrip, "statusStrip");
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblDfu,
            this.lblUsb});
			this.statusStrip.Name = "statusStrip";
			// 
			// lblDfu
			// 
			this.lblDfu.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
			this.lblDfu.Name = "lblDfu";
			resources.ApplyResources(this.lblDfu, "lblDfu");
			// 
			// lblUsb
			// 
			this.lblUsb.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.lblUsb.Name = "lblUsb";
			resources.ApplyResources(this.lblUsb, "lblUsb");
			// 
			// TimerUsbDevice
			// 
			this.TimerUsbDevice.Interval = 500;
			this.TimerUsbDevice.Tick += new System.EventHandler(this.TimerUsbDevice_Tick);
			// 
			// FirmwareUpgradeDialog
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.lblResult);
			this.Controls.Add(this.chkBootMode);
			this.Controls.Add(this.rtxtResult);
			this.Controls.Add(this.toolStrip);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnStartUpgrade);
			this.Controls.Add(this.btnCom);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FirmwareUpgradeDialog";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.FirmwareUpgradeForm_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FirmwareUpgradeForm_FormClosing);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnCom;
		private System.Windows.Forms.Button btnStartUpgrade;
		private System.Windows.Forms.RichTextBox rtxtResult;
		private System.Windows.Forms.Timer TimerDfuStart;
		private System.Windows.Forms.OpenFileDialog OpenFileDialog;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripLabel lblMode;
		private System.Windows.Forms.ToolStripComboBox cmbMode;
		private System.Windows.Forms.CheckBox chkBootMode;
		private System.Windows.Forms.Label lblResult;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel lblDfu;
		private System.Windows.Forms.ToolStripStatusLabel lblUsb;
		private System.Windows.Forms.Timer TimerUsbDevice;
	}
}