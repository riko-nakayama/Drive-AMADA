namespace Motion_Designer
{
	partial class OptionSettingDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionSettingDialog));
            this.tabOption = new System.Windows.Forms.TabControl();
            this.tabPageView = new System.Windows.Forms.TabPage();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblComNo = new System.Windows.Forms.Label();
            this.pnlBase = new System.Windows.Forms.Panel();
            this.cmbCulture = new System.Windows.Forms.ComboBox();
            this.tabPageUsb = new System.Windows.Forms.TabPage();
            this.lblUsbPeriodWarning = new System.Windows.Forms.Label();
            this.lblLogPeriodWarnning = new System.Windows.Forms.Label();
            this.lblLogPeriod = new System.Windows.Forms.Label();
            this.lblUsbPeriod = new System.Windows.Forms.Label();
            this.tabPagePassword = new System.Windows.Forms.TabPage();
            this.btnParamInit = new System.Windows.Forms.Button();
            this.btnParamPassword = new System.Windows.Forms.Button();
            this.tabPageCalendar = new System.Windows.Forms.TabPage();
            this.grpCalendar = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSetCalendar = new System.Windows.Forms.Button();
            this.DatePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.TimePicker = new System.Windows.Forms.DateTimePicker();
            this.btnNow = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNow = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TimerCalendar = new System.Windows.Forms.Timer(this.components);
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.chkCloseMsg = new System.Windows.Forms.CheckBox();
            this.chkDevCon = new System.Windows.Forms.CheckBox();
            this.numLogPeriod = new System.Windows.Forms.NumericUpDown();
            this.numUsbPeriod = new System.Windows.Forms.NumericUpDown();
            this.tabOption.SuspendLayout();
            this.tabPageView.SuspendLayout();
            this.pnlBase.SuspendLayout();
            this.tabPageUsb.SuspendLayout();
            this.tabPagePassword.SuspendLayout();
            this.tabPageCalendar.SuspendLayout();
            this.grpCalendar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLogPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUsbPeriod)).BeginInit();
            this.SuspendLayout();
            // 
            // tabOption
            // 
            this.tabOption.Controls.Add(this.tabPageView);
            this.tabOption.Controls.Add(this.tabPageUsb);
            this.tabOption.Controls.Add(this.tabPagePassword);
            this.tabOption.Controls.Add(this.tabPageCalendar);
            resources.ApplyResources(this.tabOption, "tabOption");
            this.tabOption.Name = "tabOption";
            this.tabOption.SelectedIndex = 0;
            this.tabOption.SelectedIndexChanged += new System.EventHandler(this.tabOption_SelectedIndexChanged);
            // 
            // tabPageView
            // 
            this.tabPageView.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageView.Controls.Add(this.btnCancel);
            this.tabPageView.Controls.Add(this.btnOk);
            this.tabPageView.Controls.Add(this.lblComNo);
            this.tabPageView.Controls.Add(this.chkCloseMsg);
            this.tabPageView.Controls.Add(this.pnlBase);
            resources.ApplyResources(this.tabPageView, "tabPageView");
            this.tabPageView.Name = "tabPageView";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblComNo
            // 
            resources.ApplyResources(this.lblComNo, "lblComNo");
            this.lblComNo.Name = "lblComNo";
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.cmbCulture);
            resources.ApplyResources(this.pnlBase, "pnlBase");
            this.pnlBase.Name = "pnlBase";
            // 
            // cmbCulture
            // 
            this.cmbCulture.DropDownWidth = 250;
            resources.ApplyResources(this.cmbCulture, "cmbCulture");
            this.cmbCulture.FormattingEnabled = true;
            this.cmbCulture.Name = "cmbCulture";
            this.cmbCulture.TabStop = false;
            this.cmbCulture.SelectedIndexChanged += new System.EventHandler(this.cmbCulture_SelectedIndexChanged);
            this.cmbCulture.DropDownClosed += new System.EventHandler(this.cmbCulture_DropDownClosed);
            this.cmbCulture.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbCulture_KeyPress);
            // 
            // tabPageUsb
            // 
            this.tabPageUsb.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageUsb.Controls.Add(this.chkDevCon);
            this.tabPageUsb.Controls.Add(this.lblUsbPeriodWarning);
            this.tabPageUsb.Controls.Add(this.lblLogPeriodWarnning);
            this.tabPageUsb.Controls.Add(this.lblLogPeriod);
            this.tabPageUsb.Controls.Add(this.lblUsbPeriod);
            this.tabPageUsb.Controls.Add(this.numLogPeriod);
            this.tabPageUsb.Controls.Add(this.numUsbPeriod);
            resources.ApplyResources(this.tabPageUsb, "tabPageUsb");
            this.tabPageUsb.Name = "tabPageUsb";
            // 
            // lblUsbPeriodWarning
            // 
            resources.ApplyResources(this.lblUsbPeriodWarning, "lblUsbPeriodWarning");
            this.lblUsbPeriodWarning.Name = "lblUsbPeriodWarning";
            // 
            // lblLogPeriodWarnning
            // 
            resources.ApplyResources(this.lblLogPeriodWarnning, "lblLogPeriodWarnning");
            this.lblLogPeriodWarnning.Name = "lblLogPeriodWarnning";
            // 
            // lblLogPeriod
            // 
            resources.ApplyResources(this.lblLogPeriod, "lblLogPeriod");
            this.lblLogPeriod.Name = "lblLogPeriod";
            // 
            // lblUsbPeriod
            // 
            resources.ApplyResources(this.lblUsbPeriod, "lblUsbPeriod");
            this.lblUsbPeriod.Name = "lblUsbPeriod";
            // 
            // tabPagePassword
            // 
            this.tabPagePassword.BackColor = System.Drawing.SystemColors.Control;
            this.tabPagePassword.Controls.Add(this.btnParamInit);
            this.tabPagePassword.Controls.Add(this.btnParamPassword);
            resources.ApplyResources(this.tabPagePassword, "tabPagePassword");
            this.tabPagePassword.Name = "tabPagePassword";
            // 
            // btnParamInit
            // 
            resources.ApplyResources(this.btnParamInit, "btnParamInit");
            this.btnParamInit.Name = "btnParamInit";
            this.btnParamInit.UseVisualStyleBackColor = true;
            this.btnParamInit.Click += new System.EventHandler(this.btnParamInit_Click);
            // 
            // btnParamPassword
            // 
            resources.ApplyResources(this.btnParamPassword, "btnParamPassword");
            this.btnParamPassword.Name = "btnParamPassword";
            this.btnParamPassword.UseVisualStyleBackColor = true;
            this.btnParamPassword.Click += new System.EventHandler(this.btnParamPassword_Click);
            // 
            // tabPageCalendar
            // 
            this.tabPageCalendar.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageCalendar.Controls.Add(this.grpCalendar);
            this.tabPageCalendar.Controls.Add(this.btnNow);
            this.tabPageCalendar.Controls.Add(this.label1);
            this.tabPageCalendar.Controls.Add(this.lblNow);
            resources.ApplyResources(this.tabPageCalendar, "tabPageCalendar");
            this.tabPageCalendar.Name = "tabPageCalendar";
            this.tabPageCalendar.Enter += new System.EventHandler(this.tabPageCalendar_Enter);
            this.tabPageCalendar.Leave += new System.EventHandler(this.tabPageCalendar_Leave);
            // 
            // grpCalendar
            // 
            this.grpCalendar.Controls.Add(this.label2);
            this.grpCalendar.Controls.Add(this.btnSetCalendar);
            this.grpCalendar.Controls.Add(this.DatePicker);
            this.grpCalendar.Controls.Add(this.label4);
            this.grpCalendar.Controls.Add(this.TimePicker);
            resources.ApplyResources(this.grpCalendar, "grpCalendar");
            this.grpCalendar.Name = "grpCalendar";
            this.grpCalendar.TabStop = false;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // btnSetCalendar
            // 
            resources.ApplyResources(this.btnSetCalendar, "btnSetCalendar");
            this.btnSetCalendar.Name = "btnSetCalendar";
            this.btnSetCalendar.UseVisualStyleBackColor = true;
            this.btnSetCalendar.Click += new System.EventHandler(this.btnSetCalendar_Click);
            // 
            // DatePicker
            // 
            resources.ApplyResources(this.DatePicker, "DatePicker");
            this.DatePicker.Name = "DatePicker";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // TimePicker
            // 
            resources.ApplyResources(this.TimePicker, "TimePicker");
            this.TimePicker.CalendarForeColor = System.Drawing.Color.White;
            this.TimePicker.CalendarMonthBackground = System.Drawing.SystemColors.ActiveCaptionText;
            this.TimePicker.CalendarTitleForeColor = System.Drawing.Color.Silver;
            this.TimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.TimePicker.Name = "TimePicker";
            this.TimePicker.ShowUpDown = true;
            // 
            // btnNow
            // 
            resources.ApplyResources(this.btnNow, "btnNow");
            this.btnNow.Name = "btnNow";
            this.btnNow.UseVisualStyleBackColor = true;
            this.btnNow.Click += new System.EventHandler(this.btnNow_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lblNow
            // 
            this.lblNow.BackColor = System.Drawing.SystemColors.Control;
            this.lblNow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.lblNow, "lblNow");
            this.lblNow.Name = "lblNow";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // TimerCalendar
            // 
            this.TimerCalendar.Tick += new System.EventHandler(this.TimerCalendar_Tick);
            // 
            // folderBrowserDialog
            // 
            resources.ApplyResources(this.folderBrowserDialog, "folderBrowserDialog");
            // 
            // chkCloseMsg
            // 
            resources.ApplyResources(this.chkCloseMsg, "chkCloseMsg");
            this.chkCloseMsg.Checked = global::Motion_Designer.Properties.Settings.Default.CLOSE_MSG_DISABLE;
            this.chkCloseMsg.Name = "chkCloseMsg";
            this.chkCloseMsg.UseVisualStyleBackColor = true;
            this.chkCloseMsg.CheckedChanged += new System.EventHandler(this.chkCloseMsg_CheckedChanged);
            // 
            // chkDevCon
            // 
            resources.ApplyResources(this.chkDevCon, "chkDevCon");
            this.chkDevCon.Checked = global::Motion_Designer.Properties.Settings.Default.DEV_CON_ENABLE;
            this.chkDevCon.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Motion_Designer.Properties.Settings.Default, "DEV_CON_ENABLE", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkDevCon.Name = "chkDevCon";
            this.chkDevCon.UseVisualStyleBackColor = true;
            // 
            // numLogPeriod
            // 
            this.numLogPeriod.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Motion_Designer.Properties.Settings.Default, "LogPeriod", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.numLogPeriod, "numLogPeriod");
            this.numLogPeriod.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numLogPeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLogPeriod.Name = "numLogPeriod";
            this.numLogPeriod.Value = global::Motion_Designer.Properties.Settings.Default.LogPeriod;
            this.numLogPeriod.ValueChanged += new System.EventHandler(this.numLogPeriod_ValueChanged);
            // 
            // numUsbPeriod
            // 
            this.numUsbPeriod.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Motion_Designer.Properties.Settings.Default, "MainTimerInterval", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numUsbPeriod.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            resources.ApplyResources(this.numUsbPeriod, "numUsbPeriod");
            this.numUsbPeriod.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numUsbPeriod.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUsbPeriod.Name = "numUsbPeriod";
            this.numUsbPeriod.Value = global::Motion_Designer.Properties.Settings.Default.MainTimerInterval;
            this.numUsbPeriod.ValueChanged += new System.EventHandler(this.numUsbPeriod_ValueChanged);
            // 
            // OptionSettingDialog
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.tabOption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionSettingDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionSettingForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OptionSettingDialog_FormClosed);
            this.Load += new System.EventHandler(this.OptionSettingForm_Load);
            this.tabOption.ResumeLayout(false);
            this.tabPageView.ResumeLayout(false);
            this.tabPageView.PerformLayout();
            this.pnlBase.ResumeLayout(false);
            this.tabPageUsb.ResumeLayout(false);
            this.tabPageUsb.PerformLayout();
            this.tabPagePassword.ResumeLayout(false);
            this.tabPageCalendar.ResumeLayout(false);
            this.grpCalendar.ResumeLayout(false);
            this.grpCalendar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLogPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUsbPeriod)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabOption;
		private System.Windows.Forms.TabPage tabPageUsb;
		private System.Windows.Forms.TabPage tabPagePassword;
		private System.Windows.Forms.Button btnParamPassword;
		private System.Windows.Forms.TabPage tabPageView;
		private System.Windows.Forms.CheckBox chkCloseMsg;
        private System.Windows.Forms.Label lblComNo;
        private System.Windows.Forms.ComboBox cmbCulture;
		private System.Windows.Forms.Panel pnlBase;
		private System.Windows.Forms.NumericUpDown numUsbPeriod;
		private System.Windows.Forms.Label lblUsbPeriod;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.NumericUpDown numLogPeriod;
		private System.Windows.Forms.Label lblLogPeriod;
		private System.Windows.Forms.Label lblLogPeriodWarnning;
		private System.Windows.Forms.Label lblUsbPeriodWarning;
        private System.Windows.Forms.TabPage tabPageCalendar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNow;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Button btnNow;
        private System.Windows.Forms.Timer TimerCalendar;
        internal System.Windows.Forms.GroupBox grpCalendar;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Button btnSetCalendar;
        private System.Windows.Forms.DateTimePicker DatePicker;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker TimePicker;
		private System.Windows.Forms.Button btnParamInit;
		private System.Windows.Forms.CheckBox chkDevCon;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}