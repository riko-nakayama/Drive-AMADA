namespace Motion_Designer
{
	partial class OpenDriveForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenDriveForm));
			this.lblProject = new System.Windows.Forms.Label();
			this.rdoJog = new System.Windows.Forms.RadioButton();
			this.rdoParameter = new System.Windows.Forms.RadioButton();
			this.rdoAutoTuning = new System.Windows.Forms.RadioButton();
			this.rdoManualTuning = new System.Windows.Forms.RadioButton();
			this.lblJog = new System.Windows.Forms.Label();
			this.grpLayout = new System.Windows.Forms.GroupBox();
			this.lblGain = new System.Windows.Forms.Label();
			this.lblAutoTuning = new System.Windows.Forms.Label();
			this.lblParameter = new System.Windows.Forms.Label();
			this.chkCollapse = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnOk = new System.Windows.Forms.Button();
			this.TimerOpenDrive = new System.Windows.Forms.Timer(this.components);
			this.btnCancel = new System.Windows.Forms.Button();
			this.lblStartView = new System.Windows.Forms.Label();
			this.chkStartView = new System.Windows.Forms.CheckBox();
			this.grpLayout.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblProject
			// 
			resources.ApplyResources(this.lblProject, "lblProject");
			this.lblProject.ForeColor = System.Drawing.Color.MediumBlue;
			this.lblProject.Name = "lblProject";
			// 
			// rdoJog
			// 
			resources.ApplyResources(this.rdoJog, "rdoJog");
			this.rdoJog.Name = "rdoJog";
			this.rdoJog.UseVisualStyleBackColor = true;
			this.rdoJog.CheckedChanged += new System.EventHandler(this.Layout_CheckedChanged);
			// 
			// rdoParameter
			// 
			resources.ApplyResources(this.rdoParameter, "rdoParameter");
			this.rdoParameter.Name = "rdoParameter";
			this.rdoParameter.UseVisualStyleBackColor = true;
			this.rdoParameter.CheckedChanged += new System.EventHandler(this.Layout_CheckedChanged);
			// 
			// rdoAutoTuning
			// 
			resources.ApplyResources(this.rdoAutoTuning, "rdoAutoTuning");
			this.rdoAutoTuning.Name = "rdoAutoTuning";
			this.rdoAutoTuning.UseVisualStyleBackColor = true;
			this.rdoAutoTuning.CheckedChanged += new System.EventHandler(this.Layout_CheckedChanged);
			// 
			// rdoManualTuning
			// 
			resources.ApplyResources(this.rdoManualTuning, "rdoManualTuning");
			this.rdoManualTuning.Name = "rdoManualTuning";
			this.rdoManualTuning.UseVisualStyleBackColor = true;
			this.rdoManualTuning.CheckedChanged += new System.EventHandler(this.Layout_CheckedChanged);
			// 
			// lblJog
			// 
			resources.ApplyResources(this.lblJog, "lblJog");
			this.lblJog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lblJog.Name = "lblJog";
			// 
			// grpLayout
			// 
			this.grpLayout.Controls.Add(this.rdoJog);
			this.grpLayout.Controls.Add(this.lblGain);
			this.grpLayout.Controls.Add(this.lblAutoTuning);
			this.grpLayout.Controls.Add(this.lblParameter);
			this.grpLayout.Controls.Add(this.lblJog);
			this.grpLayout.Controls.Add(this.rdoParameter);
			this.grpLayout.Controls.Add(this.rdoManualTuning);
			this.grpLayout.Controls.Add(this.rdoAutoTuning);
			resources.ApplyResources(this.grpLayout, "grpLayout");
			this.grpLayout.Name = "grpLayout";
			this.grpLayout.TabStop = false;
			// 
			// lblGain
			// 
			resources.ApplyResources(this.lblGain, "lblGain");
			this.lblGain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lblGain.Name = "lblGain";
			// 
			// lblAutoTuning
			// 
			resources.ApplyResources(this.lblAutoTuning, "lblAutoTuning");
			this.lblAutoTuning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lblAutoTuning.Name = "lblAutoTuning";
			// 
			// lblParameter
			// 
			resources.ApplyResources(this.lblParameter, "lblParameter");
			this.lblParameter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lblParameter.Name = "lblParameter";
			// 
			// chkCollapse
			// 
			resources.ApplyResources(this.chkCollapse, "chkCollapse");
			this.chkCollapse.Name = "chkCollapse";
			this.chkCollapse.UseVisualStyleBackColor = true;
			this.chkCollapse.CheckedChanged += new System.EventHandler(this.chkCollapse_CheckedChanged);
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.label1.Name = "label1";
			// 
			// btnOk
			// 
			resources.ApplyResources(this.btnOk, "btnOk");
			this.btnOk.Name = "btnOk";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// TimerOpenDrive
			// 
			this.TimerOpenDrive.Enabled = true;
			this.TimerOpenDrive.Interval = 250;
			this.TimerOpenDrive.Tick += new System.EventHandler(this.TimerOpenDrive_Tick);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// lblStartView
			// 
			resources.ApplyResources(this.lblStartView, "lblStartView");
			this.lblStartView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lblStartView.Name = "lblStartView";
			// 
			// chkStartView
			// 
			resources.ApplyResources(this.chkStartView, "chkStartView");
			this.chkStartView.Name = "chkStartView";
			this.chkStartView.UseVisualStyleBackColor = true;
			// 
			// OpenDriveForm
			// 
			this.AcceptButton = this.btnOk;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.chkStartView);
			this.Controls.Add(this.chkCollapse);
			this.Controls.Add(this.lblStartView);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.grpLayout);
			this.Controls.Add(this.lblProject);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "OpenDriveForm";
			this.TopMost = true;
			this.grpLayout.ResumeLayout(false);
			this.grpLayout.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblProject;
		private System.Windows.Forms.RadioButton rdoJog;
		private System.Windows.Forms.RadioButton rdoParameter;
		private System.Windows.Forms.RadioButton rdoAutoTuning;
		private System.Windows.Forms.RadioButton rdoManualTuning;
		private System.Windows.Forms.Label lblJog;
		private System.Windows.Forms.GroupBox grpLayout;
		private System.Windows.Forms.Label lblGain;
		private System.Windows.Forms.Label lblAutoTuning;
		private System.Windows.Forms.Label lblParameter;
		private System.Windows.Forms.CheckBox chkCollapse;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.CheckBox chkStartView;
		private System.Windows.Forms.Timer TimerOpenDrive;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label lblStartView;
	}
}