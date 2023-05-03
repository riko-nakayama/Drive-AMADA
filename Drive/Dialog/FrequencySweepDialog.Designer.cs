namespace Motion_Designer
{
	partial class FrequencySweepDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrequencySweepDialog));
			this.grpVelocity = new System.Windows.Forms.GroupBox();
			this.ctlNumFrqSweepVelocity = new Motion_Designer.CtlNumericInputInt();
			this.grpMaxFrq = new System.Windows.Forms.GroupBox();
			this.ctlNumFrqSweepMinFrq = new Motion_Designer.CtlNumericInputInt();
			this.lblTo = new System.Windows.Forms.Label();
			this.ctlNumFrqSweepMaxFrq = new Motion_Designer.CtlNumericInputInt();
			this.lblFrqSweep = new System.Windows.Forms.Label();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.grpVelocity.SuspendLayout();
			this.grpMaxFrq.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpVelocity
			// 
			this.grpVelocity.Controls.Add(this.ctlNumFrqSweepVelocity);
			resources.ApplyResources(this.grpVelocity, "grpVelocity");
			this.grpVelocity.ForeColor = System.Drawing.Color.Black;
			this.grpVelocity.Name = "grpVelocity";
			this.grpVelocity.TabStop = false;
			// 
			// ctlNumFrqSweepVelocity
			// 
			this.ctlNumFrqSweepVelocity.DataId = 0;
			this.ctlNumFrqSweepVelocity.DigiSwVisible = true;
			resources.ApplyResources(this.ctlNumFrqSweepVelocity, "ctlNumFrqSweepVelocity");
			this.ctlNumFrqSweepVelocity.IntValue = 100;
			this.ctlNumFrqSweepVelocity.MaxData = 1000;
			this.ctlNumFrqSweepVelocity.MinData = 50;
			this.ctlNumFrqSweepVelocity.Name = "ctlNumFrqSweepVelocity";
			this.ctlNumFrqSweepVelocity.NumBackColor = System.Drawing.Color.White;
			this.ctlNumFrqSweepVelocity.NumFont = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.ctlNumFrqSweepVelocity.NumForeColor = System.Drawing.Color.Navy;
			this.ctlNumFrqSweepVelocity.PlaceNumber = 3;
			this.ctlNumFrqSweepVelocity.SignedVisible = false;
			this.ctlNumFrqSweepVelocity.SingedEnable = false;
			this.ctlNumFrqSweepVelocity.StringValue = "+100";
			this.ctlNumFrqSweepVelocity.TitleAlign = System.Drawing.ContentAlignment.TopLeft;
			this.ctlNumFrqSweepVelocity.TitleBackColor = System.Drawing.Color.White;
			this.ctlNumFrqSweepVelocity.TitleDock = System.Windows.Forms.DockStyle.Top;
			this.ctlNumFrqSweepVelocity.TitleForeColor = System.Drawing.Color.MediumBlue;
			this.ctlNumFrqSweepVelocity.TitleHeight = 19;
			this.ctlNumFrqSweepVelocity.TitleVisible = false;
			this.ctlNumFrqSweepVelocity.UnitAlign = System.Drawing.ContentAlignment.TopLeft;
			this.ctlNumFrqSweepVelocity.UnitBackColor = System.Drawing.Color.Transparent;
			this.ctlNumFrqSweepVelocity.UnitDock = System.Windows.Forms.DockStyle.Bottom;
			this.ctlNumFrqSweepVelocity.UnitFont = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.ctlNumFrqSweepVelocity.UnitForeColor = System.Drawing.Color.Black;
			this.ctlNumFrqSweepVelocity.UnitHeight = 24;
			this.ctlNumFrqSweepVelocity.UnitVisible = true;
			// 
			// grpMaxFrq
			// 
			this.grpMaxFrq.Controls.Add(this.ctlNumFrqSweepMinFrq);
			this.grpMaxFrq.Controls.Add(this.lblTo);
			this.grpMaxFrq.Controls.Add(this.ctlNumFrqSweepMaxFrq);
			resources.ApplyResources(this.grpMaxFrq, "grpMaxFrq");
			this.grpMaxFrq.ForeColor = System.Drawing.Color.Black;
			this.grpMaxFrq.Name = "grpMaxFrq";
			this.grpMaxFrq.TabStop = false;
			// 
			// ctlNumFrqSweepMinFrq
			// 
			this.ctlNumFrqSweepMinFrq.DataId = 0;
			this.ctlNumFrqSweepMinFrq.DigiSwVisible = true;
			resources.ApplyResources(this.ctlNumFrqSweepMinFrq, "ctlNumFrqSweepMinFrq");
			this.ctlNumFrqSweepMinFrq.IntValue = 5;
			this.ctlNumFrqSweepMinFrq.MaxData = 10;
			this.ctlNumFrqSweepMinFrq.MinData = 1;
			this.ctlNumFrqSweepMinFrq.Name = "ctlNumFrqSweepMinFrq";
			this.ctlNumFrqSweepMinFrq.NumBackColor = System.Drawing.Color.White;
			this.ctlNumFrqSweepMinFrq.NumFont = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.ctlNumFrqSweepMinFrq.NumForeColor = System.Drawing.Color.Navy;
			this.ctlNumFrqSweepMinFrq.PlaceNumber = 3;
			this.ctlNumFrqSweepMinFrq.SignedVisible = false;
			this.ctlNumFrqSweepMinFrq.SingedEnable = false;
			this.ctlNumFrqSweepMinFrq.StringValue = "+5";
			this.ctlNumFrqSweepMinFrq.TitleAlign = System.Drawing.ContentAlignment.TopLeft;
			this.ctlNumFrqSweepMinFrq.TitleBackColor = System.Drawing.Color.White;
			this.ctlNumFrqSweepMinFrq.TitleDock = System.Windows.Forms.DockStyle.Top;
			this.ctlNumFrqSweepMinFrq.TitleForeColor = System.Drawing.Color.MediumBlue;
			this.ctlNumFrqSweepMinFrq.TitleHeight = 19;
			this.ctlNumFrqSweepMinFrq.TitleVisible = false;
			this.ctlNumFrqSweepMinFrq.UnitAlign = System.Drawing.ContentAlignment.TopLeft;
			this.ctlNumFrqSweepMinFrq.UnitBackColor = System.Drawing.Color.Transparent;
			this.ctlNumFrqSweepMinFrq.UnitDock = System.Windows.Forms.DockStyle.Bottom;
			this.ctlNumFrqSweepMinFrq.UnitFont = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.ctlNumFrqSweepMinFrq.UnitForeColor = System.Drawing.Color.Black;
			this.ctlNumFrqSweepMinFrq.UnitHeight = 24;
			this.ctlNumFrqSweepMinFrq.UnitVisible = true;
			// 
			// lblTo
			// 
			resources.ApplyResources(this.lblTo, "lblTo");
			this.lblTo.ForeColor = System.Drawing.Color.Blue;
			this.lblTo.Name = "lblTo";
			// 
			// ctlNumFrqSweepMaxFrq
			// 
			this.ctlNumFrqSweepMaxFrq.DataId = 0;
			this.ctlNumFrqSweepMaxFrq.DigiSwVisible = true;
			resources.ApplyResources(this.ctlNumFrqSweepMaxFrq, "ctlNumFrqSweepMaxFrq");
			this.ctlNumFrqSweepMaxFrq.IntValue = 20;
			this.ctlNumFrqSweepMaxFrq.MaxData = 500;
			this.ctlNumFrqSweepMaxFrq.MinData = 20;
			this.ctlNumFrqSweepMaxFrq.Name = "ctlNumFrqSweepMaxFrq";
			this.ctlNumFrqSweepMaxFrq.NumBackColor = System.Drawing.Color.White;
			this.ctlNumFrqSweepMaxFrq.NumFont = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.ctlNumFrqSweepMaxFrq.NumForeColor = System.Drawing.Color.Navy;
			this.ctlNumFrqSweepMaxFrq.PlaceNumber = 3;
			this.ctlNumFrqSweepMaxFrq.SignedVisible = false;
			this.ctlNumFrqSweepMaxFrq.SingedEnable = false;
			this.ctlNumFrqSweepMaxFrq.StringValue = "+20";
			this.ctlNumFrqSweepMaxFrq.TitleAlign = System.Drawing.ContentAlignment.TopLeft;
			this.ctlNumFrqSweepMaxFrq.TitleBackColor = System.Drawing.Color.White;
			this.ctlNumFrqSweepMaxFrq.TitleDock = System.Windows.Forms.DockStyle.Top;
			this.ctlNumFrqSweepMaxFrq.TitleForeColor = System.Drawing.Color.MediumBlue;
			this.ctlNumFrqSweepMaxFrq.TitleHeight = 19;
			this.ctlNumFrqSweepMaxFrq.TitleVisible = false;
			this.ctlNumFrqSweepMaxFrq.UnitAlign = System.Drawing.ContentAlignment.TopLeft;
			this.ctlNumFrqSweepMaxFrq.UnitBackColor = System.Drawing.Color.Transparent;
			this.ctlNumFrqSweepMaxFrq.UnitDock = System.Windows.Forms.DockStyle.Bottom;
			this.ctlNumFrqSweepMaxFrq.UnitFont = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.ctlNumFrqSweepMaxFrq.UnitForeColor = System.Drawing.Color.Black;
			this.ctlNumFrqSweepMaxFrq.UnitHeight = 24;
			this.ctlNumFrqSweepMaxFrq.UnitVisible = true;
			// 
			// lblFrqSweep
			// 
			resources.ApplyResources(this.lblFrqSweep, "lblFrqSweep");
			this.lblFrqSweep.ForeColor = System.Drawing.Color.Blue;
			this.lblFrqSweep.Name = "lblFrqSweep";
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
			// FrequencySweepDialog
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.lblFrqSweep);
			this.Controls.Add(this.grpMaxFrq);
			this.Controls.Add(this.grpVelocity);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FrequencySweepDialog";
			this.ShowInTaskbar = false;
			this.TopMost = true;
			this.Load += new System.EventHandler(this.FreqencySweepForm_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FreqencySweepForm_FormClosing);
			this.grpVelocity.ResumeLayout(false);
			this.grpMaxFrq.ResumeLayout(false);
			this.grpMaxFrq.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox grpVelocity;
		private CtlNumericInputInt ctlNumFrqSweepVelocity;
		private System.Windows.Forms.GroupBox grpMaxFrq;
		private CtlNumericInputInt ctlNumFrqSweepMaxFrq;
		private System.Windows.Forms.Label lblFrqSweep;
		private CtlNumericInputInt ctlNumFrqSweepMinFrq;
		private System.Windows.Forms.Label lblTo;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
	}
}