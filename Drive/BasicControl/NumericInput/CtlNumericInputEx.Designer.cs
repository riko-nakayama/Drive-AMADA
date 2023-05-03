namespace Motion_Designer
{
	partial class CtlNumericInputEx
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
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlScale = new System.Windows.Forms.Panel();
            this.chkX100 = new System.Windows.Forms.CheckBox();
            this.chkX10 = new System.Windows.Forms.CheckBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.TimerEscape = new System.Windows.Forms.Timer(this.components);
            this.pnlInput = new System.Windows.Forms.Panel();
            this.numInput = new Motion_Designer.NumericUpDownEx();
            this.lblLimit = new System.Windows.Forms.Label();
            this.pnlScale.SuspendLayout();
            this.pnlInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInput)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(100, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "サーボゲイン";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlScale
            // 
            this.pnlScale.Controls.Add(this.chkX100);
            this.pnlScale.Controls.Add(this.chkX10);
            this.pnlScale.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlScale.Location = new System.Drawing.Point(0, 93);
            this.pnlScale.Name = "pnlScale";
            this.pnlScale.Size = new System.Drawing.Size(100, 20);
            this.pnlScale.TabIndex = 2;
            // 
            // chkX100
            // 
            this.chkX100.AutoSize = true;
            this.chkX100.Dock = System.Windows.Forms.DockStyle.Right;
            this.chkX100.Font = new System.Drawing.Font("メイリオ", 7F);
            this.chkX100.Location = new System.Drawing.Point(6, 0);
            this.chkX100.Name = "chkX100";
            this.chkX100.Size = new System.Drawing.Size(50, 20);
            this.chkX100.TabIndex = 0;
            this.chkX100.TabStop = false;
            this.chkX100.Text = "x100";
            this.chkX100.UseVisualStyleBackColor = true;
            this.chkX100.CheckStateChanged += new System.EventHandler(this.chkX100_CheckStateChanged);
            // 
            // chkX10
            // 
            this.chkX10.AutoSize = true;
            this.chkX10.Dock = System.Windows.Forms.DockStyle.Right;
            this.chkX10.Font = new System.Drawing.Font("メイリオ", 7F);
            this.chkX10.Location = new System.Drawing.Point(56, 0);
            this.chkX10.Name = "chkX10";
            this.chkX10.Size = new System.Drawing.Size(44, 20);
            this.chkX10.TabIndex = 0;
            this.chkX10.TabStop = false;
            this.chkX10.Text = "x10";
            this.chkX10.UseVisualStyleBackColor = true;
            this.chkX10.CheckStateChanged += new System.EventHandler(this.chkX10_CheckStateChanged);
            // 
            // lblUnit
            // 
            this.lblUnit.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUnit.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblUnit.ForeColor = System.Drawing.Color.Navy;
            this.lblUnit.Location = new System.Drawing.Point(0, 113);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(100, 20);
            this.lblUnit.TabIndex = 0;
            this.lblUnit.Text = "単位[rad/s]";
            this.lblUnit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // TimerEscape
            // 
            this.TimerEscape.Tick += new System.EventHandler(this.TimerEscape_Tick);
            // 
            // pnlInput
            // 
            this.pnlInput.Controls.Add(this.lblUnit);
            this.pnlInput.Controls.Add(this.pnlScale);
            this.pnlInput.Controls.Add(this.numInput);
            this.pnlInput.Controls.Add(this.lblLimit);
            this.pnlInput.Controls.Add(this.lblTitle);
            this.pnlInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInput.Location = new System.Drawing.Point(0, 0);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(100, 134);
            this.pnlInput.TabIndex = 0;
            // 
            // numInput
            // 
            this.numInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.numInput.Font = new System.Drawing.Font("7barSPBd", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numInput.ForeColor = System.Drawing.Color.Navy;
            this.numInput.Location = new System.Drawing.Point(0, 59);
            this.numInput.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.numInput.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numInput.Name = "numInput";
            this.numInput.Size = new System.Drawing.Size(100, 34);
            this.numInput.TabIndex = 1;
            this.numInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numInput.Value = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numInput.ValueChanged += new System.EventHandler(this.numInput_ValueChanged);
            this.numInput.Leave += new System.EventHandler(this.numInput_Leave);
            this.numInput.Enter += new System.EventHandler(this.numInput_Enter);
            this.numInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numInput_KeyDown);
            // 
            // lblLimit
            // 
            this.lblLimit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLimit.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLimit.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblLimit.Location = new System.Drawing.Point(0, 25);
            this.lblLimit.Name = "lblLimit";
            this.lblLimit.Size = new System.Drawing.Size(100, 34);
            this.lblLimit.TabIndex = 3;
            this.lblLimit.Text = "Max Limit";
            this.lblLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLimit.Visible = false;
            // 
            // CtlNumericInputEx
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.pnlInput);
            this.Name = "CtlNumericInputEx";
            this.Size = new System.Drawing.Size(100, 134);
            this.pnlScale.ResumeLayout(false);
            this.pnlScale.PerformLayout();
            this.pnlInput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numInput)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Panel pnlScale;
		private System.Windows.Forms.CheckBox chkX10;
		private System.Windows.Forms.CheckBox chkX100;
		private System.Windows.Forms.Label lblUnit;
		private Motion_Designer.NumericUpDownEx numInput;
		private System.Windows.Forms.Timer TimerEscape;
		private System.Windows.Forms.Panel pnlInput;
		private System.Windows.Forms.Label lblLimit;
	}
}
