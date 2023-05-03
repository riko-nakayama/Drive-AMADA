namespace Motion_Designer
{
	partial class TuningSelectDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TuningSelectDialog));
			this.lblTuningControl = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnFriction = new System.Windows.Forms.Button();
			this.btnSweep = new System.Windows.Forms.Button();
			this.btnAdjust = new System.Windows.Forms.Button();
			this.btnLoad = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblTuningControl
			// 
			this.lblTuningControl.AccessibleDescription = null;
			this.lblTuningControl.AccessibleName = null;
			resources.ApplyResources(this.lblTuningControl, "lblTuningControl");
			this.lblTuningControl.Name = "lblTuningControl";
			// 
			// btnCancel
			// 
			this.btnCancel.AccessibleDescription = null;
			this.btnCancel.AccessibleName = null;
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.BackgroundImage = null;
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnFriction
			// 
			this.btnFriction.AccessibleDescription = null;
			this.btnFriction.AccessibleName = null;
			resources.ApplyResources(this.btnFriction, "btnFriction");
			this.btnFriction.BackgroundImage = null;
			this.btnFriction.Name = "btnFriction";
			this.btnFriction.UseVisualStyleBackColor = true;
			this.btnFriction.Click += new System.EventHandler(this.btnFriction_Click);
			// 
			// btnSweep
			// 
			this.btnSweep.AccessibleDescription = null;
			this.btnSweep.AccessibleName = null;
			resources.ApplyResources(this.btnSweep, "btnSweep");
			this.btnSweep.BackgroundImage = null;
			this.btnSweep.Name = "btnSweep";
			this.btnSweep.UseVisualStyleBackColor = true;
			this.btnSweep.Click += new System.EventHandler(this.btnSweep_Click);
			// 
			// btnAdjust
			// 
			this.btnAdjust.AccessibleDescription = null;
			this.btnAdjust.AccessibleName = null;
			resources.ApplyResources(this.btnAdjust, "btnAdjust");
			this.btnAdjust.BackgroundImage = null;
			this.btnAdjust.Name = "btnAdjust";
			this.btnAdjust.UseVisualStyleBackColor = true;
			this.btnAdjust.Click += new System.EventHandler(this.btnAdjust_Click);
			// 
			// btnLoad
			// 
			this.btnLoad.AccessibleDescription = null;
			this.btnLoad.AccessibleName = null;
			resources.ApplyResources(this.btnLoad, "btnLoad");
			this.btnLoad.BackgroundImage = null;
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.UseVisualStyleBackColor = true;
			this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// TuningSelectDialog
			// 
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = null;
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.lblTuningControl);
			this.Controls.Add(this.btnFriction);
			this.Controls.Add(this.btnSweep);
			this.Controls.Add(this.btnAdjust);
			this.Controls.Add(this.btnLoad);
			this.Font = null;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TuningSelectDialog";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.TuningControlForm_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TuningControlForm_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnLoad;
		private System.Windows.Forms.Button btnAdjust;
		private System.Windows.Forms.Button btnSweep;
		private System.Windows.Forms.Button btnFriction;
		private System.Windows.Forms.Label lblTuningControl;
		private System.Windows.Forms.Button btnCancel;
	}
}