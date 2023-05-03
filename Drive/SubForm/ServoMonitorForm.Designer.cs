namespace Motion_Designer
{
	partial class ServoMonitorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServoMonitorForm));
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblStatusPage = new System.Windows.Forms.Label();
            this.lblDummy = new System.Windows.Forms.Label();
            this.btnPrev = new System.Windows.Forms.Button();
            this.fpnlStatus = new System.Windows.Forms.FlowLayoutPanel();
            this.picBit0 = new System.Windows.Forms.PictureBox();
            this.lblB0 = new System.Windows.Forms.Label();
            this.lblBit0 = new System.Windows.Forms.Label();
            this.picBit1 = new System.Windows.Forms.PictureBox();
            this.lblB1 = new System.Windows.Forms.Label();
            this.lblBit1 = new System.Windows.Forms.Label();
            this.picBit2 = new System.Windows.Forms.PictureBox();
            this.lblB2 = new System.Windows.Forms.Label();
            this.lblBit2 = new System.Windows.Forms.Label();
            this.picBit3 = new System.Windows.Forms.PictureBox();
            this.lblB3 = new System.Windows.Forms.Label();
            this.lblBit3 = new System.Windows.Forms.Label();
            this.picBit4 = new System.Windows.Forms.PictureBox();
            this.lblB4 = new System.Windows.Forms.Label();
            this.lblBit4 = new System.Windows.Forms.Label();
            this.picBit5 = new System.Windows.Forms.PictureBox();
            this.lblB5 = new System.Windows.Forms.Label();
            this.lblBit5 = new System.Windows.Forms.Label();
            this.picBit6 = new System.Windows.Forms.PictureBox();
            this.lblB6 = new System.Windows.Forms.Label();
            this.lblBit6 = new System.Windows.Forms.Label();
            this.picBit7 = new System.Windows.Forms.PictureBox();
            this.lblB7 = new System.Windows.Forms.Label();
            this.lblBit7 = new System.Windows.Forms.Label();
            this.fpnlIo = new System.Windows.Forms.FlowLayoutPanel();
            this.grpServoFeedBack = new System.Windows.Forms.GroupBox();
            this.fpnlKashiyamaMonitor = new System.Windows.Forms.FlowLayoutPanel();
            this.lblOutputPower = new System.Windows.Forms.Label();
            this.txtOutputPower = new System.Windows.Forms.Label();
            this.lblOutputPowerUnit = new System.Windows.Forms.Label();
            this.fpnlFeedback = new System.Windows.Forms.FlowLayoutPanel();
            this.lblPosition = new System.Windows.Forms.Label();
            this.txtPosition = new System.Windows.Forms.Label();
            this.lblPosUnit = new System.Windows.Forms.Label();
            this.lblVelocity = new System.Windows.Forms.Label();
            this.txtVelocity = new System.Windows.Forms.Label();
            this.lblVelUnit = new System.Windows.Forms.Label();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.txtCurrent = new System.Windows.Forms.Label();
            this.lblCurUnit = new System.Windows.Forms.Label();
            this.fpnlFeedback2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblOverLoad = new System.Windows.Forms.Label();
            this.txtOverload = new System.Windows.Forms.Label();
            this.llblOverLoadUnit = new System.Windows.Forms.Label();
            this.lblDriverTemp = new System.Windows.Forms.Label();
            this.txtDriverTemp = new System.Windows.Forms.Label();
            this.lblDriverTempUnit = new System.Windows.Forms.Label();
            this.lblPowerVoltage = new System.Windows.Forms.Label();
            this.txtPowerVoltage = new System.Windows.Forms.Label();
            this.lblPowerVoltageUnit = new System.Windows.Forms.Label();
            this.grpStatus.SuspendLayout();
            this.fpnlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBit0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBit6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBit7)).BeginInit();
            this.fpnlIo.SuspendLayout();
            this.grpServoFeedBack.SuspendLayout();
            this.fpnlKashiyamaMonitor.SuspendLayout();
            this.fpnlFeedback.SuspendLayout();
            this.fpnlFeedback2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpStatus
            // 
            this.grpStatus.BackColor = System.Drawing.Color.Transparent;
            this.grpStatus.Controls.Add(this.btnNext);
            this.grpStatus.Controls.Add(this.lblStatusPage);
            this.grpStatus.Controls.Add(this.lblDummy);
            this.grpStatus.Controls.Add(this.btnPrev);
            this.grpStatus.Controls.Add(this.fpnlStatus);
            resources.ApplyResources(this.grpStatus, "grpStatus");
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.TabStop = false;
            // 
            // btnNext
            // 
            resources.ApplyResources(this.btnNext, "btnNext");
            this.btnNext.Name = "btnNext";
            this.btnNext.Tag = "";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblStatusPage
            // 
            this.lblStatusPage.BackColor = System.Drawing.Color.White;
            this.lblStatusPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lblStatusPage, "lblStatusPage");
            this.lblStatusPage.Name = "lblStatusPage";
            // 
            // lblDummy
            // 
            resources.ApplyResources(this.lblDummy, "lblDummy");
            this.lblDummy.Name = "lblDummy";
            // 
            // btnPrev
            // 
            resources.ApplyResources(this.btnPrev, "btnPrev");
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Tag = "";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // fpnlStatus
            // 
            this.fpnlStatus.BackColor = System.Drawing.Color.DimGray;
            this.fpnlStatus.Controls.Add(this.picBit0);
            this.fpnlStatus.Controls.Add(this.lblB0);
            this.fpnlStatus.Controls.Add(this.lblBit0);
            this.fpnlStatus.Controls.Add(this.picBit1);
            this.fpnlStatus.Controls.Add(this.lblB1);
            this.fpnlStatus.Controls.Add(this.lblBit1);
            this.fpnlStatus.Controls.Add(this.picBit2);
            this.fpnlStatus.Controls.Add(this.lblB2);
            this.fpnlStatus.Controls.Add(this.lblBit2);
            this.fpnlStatus.Controls.Add(this.picBit3);
            this.fpnlStatus.Controls.Add(this.lblB3);
            this.fpnlStatus.Controls.Add(this.lblBit3);
            this.fpnlStatus.Controls.Add(this.picBit4);
            this.fpnlStatus.Controls.Add(this.lblB4);
            this.fpnlStatus.Controls.Add(this.lblBit4);
            this.fpnlStatus.Controls.Add(this.picBit5);
            this.fpnlStatus.Controls.Add(this.lblB5);
            this.fpnlStatus.Controls.Add(this.lblBit5);
            this.fpnlStatus.Controls.Add(this.picBit6);
            this.fpnlStatus.Controls.Add(this.lblB6);
            this.fpnlStatus.Controls.Add(this.lblBit6);
            this.fpnlStatus.Controls.Add(this.picBit7);
            this.fpnlStatus.Controls.Add(this.lblB7);
            this.fpnlStatus.Controls.Add(this.lblBit7);
            resources.ApplyResources(this.fpnlStatus, "fpnlStatus");
            this.fpnlStatus.Name = "fpnlStatus";
            // 
            // picBit0
            // 
            this.picBit0.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.picBit0, "picBit0");
            this.picBit0.Name = "picBit0";
            this.picBit0.TabStop = false;
            // 
            // lblB0
            // 
            this.lblB0.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.lblB0, "lblB0");
            this.lblB0.Name = "lblB0";
            // 
            // lblBit0
            // 
            this.lblBit0.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.lblBit0, "lblBit0");
            this.lblBit0.Name = "lblBit0";
            // 
            // picBit1
            // 
            this.picBit1.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.picBit1, "picBit1");
            this.picBit1.Name = "picBit1";
            this.picBit1.TabStop = false;
            // 
            // lblB1
            // 
            this.lblB1.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.lblB1, "lblB1");
            this.lblB1.Name = "lblB1";
            // 
            // lblBit1
            // 
            this.lblBit1.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.lblBit1, "lblBit1");
            this.lblBit1.Name = "lblBit1";
            // 
            // picBit2
            // 
            this.picBit2.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.picBit2, "picBit2");
            this.picBit2.Name = "picBit2";
            this.picBit2.TabStop = false;
            // 
            // lblB2
            // 
            this.lblB2.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.lblB2, "lblB2");
            this.lblB2.Name = "lblB2";
            // 
            // lblBit2
            // 
            this.lblBit2.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.lblBit2, "lblBit2");
            this.lblBit2.Name = "lblBit2";
            // 
            // picBit3
            // 
            this.picBit3.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.picBit3, "picBit3");
            this.picBit3.Name = "picBit3";
            this.picBit3.TabStop = false;
            // 
            // lblB3
            // 
            this.lblB3.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.lblB3, "lblB3");
            this.lblB3.Name = "lblB3";
            // 
            // lblBit3
            // 
            this.lblBit3.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.lblBit3, "lblBit3");
            this.lblBit3.Name = "lblBit3";
            // 
            // picBit4
            // 
            this.picBit4.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.picBit4, "picBit4");
            this.picBit4.Name = "picBit4";
            this.picBit4.TabStop = false;
            // 
            // lblB4
            // 
            this.lblB4.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.lblB4, "lblB4");
            this.lblB4.Name = "lblB4";
            // 
            // lblBit4
            // 
            this.lblBit4.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.lblBit4, "lblBit4");
            this.lblBit4.Name = "lblBit4";
            // 
            // picBit5
            // 
            this.picBit5.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.picBit5, "picBit5");
            this.picBit5.Name = "picBit5";
            this.picBit5.TabStop = false;
            // 
            // lblB5
            // 
            this.lblB5.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.lblB5, "lblB5");
            this.lblB5.Name = "lblB5";
            // 
            // lblBit5
            // 
            this.lblBit5.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.lblBit5, "lblBit5");
            this.lblBit5.Name = "lblBit5";
            // 
            // picBit6
            // 
            this.picBit6.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.picBit6, "picBit6");
            this.picBit6.Name = "picBit6";
            this.picBit6.TabStop = false;
            // 
            // lblB6
            // 
            this.lblB6.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.lblB6, "lblB6");
            this.lblB6.Name = "lblB6";
            // 
            // lblBit6
            // 
            this.lblBit6.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.lblBit6, "lblBit6");
            this.lblBit6.Name = "lblBit6";
            // 
            // picBit7
            // 
            this.picBit7.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.picBit7, "picBit7");
            this.picBit7.Name = "picBit7";
            this.picBit7.TabStop = false;
            // 
            // lblB7
            // 
            this.lblB7.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.lblB7, "lblB7");
            this.lblB7.Name = "lblB7";
            // 
            // lblBit7
            // 
            this.lblBit7.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.lblBit7, "lblBit7");
            this.lblBit7.Name = "lblBit7";
            // 
            // fpnlIo
            // 
            resources.ApplyResources(this.fpnlIo, "fpnlIo");
            this.fpnlIo.BackColor = System.Drawing.SystemColors.Control;
            this.fpnlIo.Controls.Add(this.grpStatus);
            this.fpnlIo.Controls.Add(this.grpServoFeedBack);
            this.fpnlIo.Name = "fpnlIo";
            // 
            // grpServoFeedBack
            // 
            this.grpServoFeedBack.Controls.Add(this.fpnlKashiyamaMonitor);
            this.grpServoFeedBack.Controls.Add(this.fpnlFeedback);
            this.grpServoFeedBack.Controls.Add(this.fpnlFeedback2);
            resources.ApplyResources(this.grpServoFeedBack, "grpServoFeedBack");
            this.grpServoFeedBack.Name = "grpServoFeedBack";
            this.grpServoFeedBack.TabStop = false;
            // 
            // fpnlKashiyamaMonitor
            // 
            this.fpnlKashiyamaMonitor.BackColor = System.Drawing.Color.DimGray;
            this.fpnlKashiyamaMonitor.Controls.Add(this.lblOutputPower);
            this.fpnlKashiyamaMonitor.Controls.Add(this.txtOutputPower);
            this.fpnlKashiyamaMonitor.Controls.Add(this.lblOutputPowerUnit);
            this.fpnlKashiyamaMonitor.Cursor = System.Windows.Forms.Cursors.Arrow;
            resources.ApplyResources(this.fpnlKashiyamaMonitor, "fpnlKashiyamaMonitor");
            this.fpnlKashiyamaMonitor.Name = "fpnlKashiyamaMonitor";
            // 
            // lblOutputPower
            // 
            this.lblOutputPower.BackColor = System.Drawing.Color.LightGreen;
            resources.ApplyResources(this.lblOutputPower, "lblOutputPower");
            this.lblOutputPower.Name = "lblOutputPower";
            // 
            // txtOutputPower
            // 
            this.txtOutputPower.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtOutputPower, "txtOutputPower");
            this.txtOutputPower.Name = "txtOutputPower";
            // 
            // lblOutputPowerUnit
            // 
            this.lblOutputPowerUnit.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.lblOutputPowerUnit, "lblOutputPowerUnit");
            this.lblOutputPowerUnit.Name = "lblOutputPowerUnit";
            // 
            // fpnlFeedback
            // 
            this.fpnlFeedback.BackColor = System.Drawing.Color.DimGray;
            this.fpnlFeedback.Controls.Add(this.lblPosition);
            this.fpnlFeedback.Controls.Add(this.txtPosition);
            this.fpnlFeedback.Controls.Add(this.lblPosUnit);
            this.fpnlFeedback.Controls.Add(this.lblVelocity);
            this.fpnlFeedback.Controls.Add(this.txtVelocity);
            this.fpnlFeedback.Controls.Add(this.lblVelUnit);
            this.fpnlFeedback.Controls.Add(this.lblCurrent);
            this.fpnlFeedback.Controls.Add(this.txtCurrent);
            this.fpnlFeedback.Controls.Add(this.lblCurUnit);
            resources.ApplyResources(this.fpnlFeedback, "fpnlFeedback");
            this.fpnlFeedback.Name = "fpnlFeedback";
            // 
            // lblPosition
            // 
            this.lblPosition.BackColor = System.Drawing.Color.Yellow;
            resources.ApplyResources(this.lblPosition, "lblPosition");
            this.lblPosition.Name = "lblPosition";
            // 
            // txtPosition
            // 
            this.txtPosition.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtPosition, "txtPosition");
            this.txtPosition.Name = "txtPosition";
            // 
            // lblPosUnit
            // 
            this.lblPosUnit.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.lblPosUnit, "lblPosUnit");
            this.lblPosUnit.Name = "lblPosUnit";
            // 
            // lblVelocity
            // 
            this.lblVelocity.BackColor = System.Drawing.Color.SkyBlue;
            resources.ApplyResources(this.lblVelocity, "lblVelocity");
            this.lblVelocity.Name = "lblVelocity";
            // 
            // txtVelocity
            // 
            this.txtVelocity.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtVelocity, "txtVelocity");
            this.txtVelocity.Name = "txtVelocity";
            // 
            // lblVelUnit
            // 
            this.lblVelUnit.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.lblVelUnit, "lblVelUnit");
            this.lblVelUnit.Name = "lblVelUnit";
            // 
            // lblCurrent
            // 
            this.lblCurrent.BackColor = System.Drawing.Color.Salmon;
            resources.ApplyResources(this.lblCurrent, "lblCurrent");
            this.lblCurrent.Name = "lblCurrent";
            // 
            // txtCurrent
            // 
            this.txtCurrent.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtCurrent, "txtCurrent");
            this.txtCurrent.Name = "txtCurrent";
            // 
            // lblCurUnit
            // 
            this.lblCurUnit.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.lblCurUnit, "lblCurUnit");
            this.lblCurUnit.Name = "lblCurUnit";
            // 
            // fpnlFeedback2
            // 
            this.fpnlFeedback2.BackColor = System.Drawing.Color.DimGray;
            this.fpnlFeedback2.Controls.Add(this.lblOverLoad);
            this.fpnlFeedback2.Controls.Add(this.txtOverload);
            this.fpnlFeedback2.Controls.Add(this.llblOverLoadUnit);
            this.fpnlFeedback2.Controls.Add(this.lblDriverTemp);
            this.fpnlFeedback2.Controls.Add(this.txtDriverTemp);
            this.fpnlFeedback2.Controls.Add(this.lblDriverTempUnit);
            this.fpnlFeedback2.Controls.Add(this.lblPowerVoltage);
            this.fpnlFeedback2.Controls.Add(this.txtPowerVoltage);
            this.fpnlFeedback2.Controls.Add(this.lblPowerVoltageUnit);
            resources.ApplyResources(this.fpnlFeedback2, "fpnlFeedback2");
            this.fpnlFeedback2.Name = "fpnlFeedback2";
            // 
            // lblOverLoad
            // 
            this.lblOverLoad.BackColor = System.Drawing.Color.Orange;
            resources.ApplyResources(this.lblOverLoad, "lblOverLoad");
            this.lblOverLoad.Name = "lblOverLoad";
            // 
            // txtOverload
            // 
            this.txtOverload.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtOverload, "txtOverload");
            this.txtOverload.Name = "txtOverload";
            // 
            // llblOverLoadUnit
            // 
            this.llblOverLoadUnit.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.llblOverLoadUnit, "llblOverLoadUnit");
            this.llblOverLoadUnit.Name = "llblOverLoadUnit";
            // 
            // lblDriverTemp
            // 
            this.lblDriverTemp.BackColor = System.Drawing.Color.Violet;
            resources.ApplyResources(this.lblDriverTemp, "lblDriverTemp");
            this.lblDriverTemp.Name = "lblDriverTemp";
            // 
            // txtDriverTemp
            // 
            this.txtDriverTemp.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtDriverTemp, "txtDriverTemp");
            this.txtDriverTemp.Name = "txtDriverTemp";
            // 
            // lblDriverTempUnit
            // 
            this.lblDriverTempUnit.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.lblDriverTempUnit, "lblDriverTempUnit");
            this.lblDriverTempUnit.Name = "lblDriverTempUnit";
            // 
            // lblPowerVoltage
            // 
            this.lblPowerVoltage.BackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.lblPowerVoltage, "lblPowerVoltage");
            this.lblPowerVoltage.Name = "lblPowerVoltage";
            // 
            // txtPowerVoltage
            // 
            this.txtPowerVoltage.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtPowerVoltage, "txtPowerVoltage");
            this.txtPowerVoltage.Name = "txtPowerVoltage";
            // 
            // lblPowerVoltageUnit
            // 
            this.lblPowerVoltageUnit.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.lblPowerVoltageUnit, "lblPowerVoltageUnit");
            this.lblPowerVoltageUnit.Name = "lblPowerVoltageUnit";
            // 
            // ServoMonitorForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.fpnlIo);
            this.MaximizeBox = false;
            this.Name = "ServoMonitorForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ServoMonitorForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServoMonitorForm_FormClosing);
            this.grpStatus.ResumeLayout(false);
            this.grpStatus.PerformLayout();
            this.fpnlStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBit0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBit6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBit7)).EndInit();
            this.fpnlIo.ResumeLayout(false);
            this.grpServoFeedBack.ResumeLayout(false);
            this.fpnlKashiyamaMonitor.ResumeLayout(false);
            this.fpnlFeedback.ResumeLayout(false);
            this.fpnlFeedback2.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox grpStatus;
		private System.Windows.Forms.FlowLayoutPanel fpnlStatus;
		private System.Windows.Forms.PictureBox picBit0;
		private System.Windows.Forms.Label lblB0;
		private System.Windows.Forms.Label lblBit0;
		private System.Windows.Forms.PictureBox picBit1;
		private System.Windows.Forms.Label lblB1;
		private System.Windows.Forms.Label lblBit1;
		private System.Windows.Forms.PictureBox picBit2;
		private System.Windows.Forms.Label lblB2;
		private System.Windows.Forms.Label lblBit2;
		private System.Windows.Forms.PictureBox picBit3;
		private System.Windows.Forms.Label lblB3;
		private System.Windows.Forms.Label lblBit3;
		private System.Windows.Forms.PictureBox picBit4;
		private System.Windows.Forms.Label lblB4;
		private System.Windows.Forms.Label lblBit4;
		private System.Windows.Forms.PictureBox picBit5;
		private System.Windows.Forms.Label lblB5;
		private System.Windows.Forms.Label lblBit5;
		private System.Windows.Forms.PictureBox picBit6;
		private System.Windows.Forms.Label lblB6;
		private System.Windows.Forms.Label lblBit6;
		private System.Windows.Forms.PictureBox picBit7;
		private System.Windows.Forms.Label lblB7;
		private System.Windows.Forms.Label lblBit7;
		private System.Windows.Forms.FlowLayoutPanel fpnlIo;
		private System.Windows.Forms.GroupBox grpServoFeedBack;
		private System.Windows.Forms.FlowLayoutPanel fpnlFeedback;
		private System.Windows.Forms.Label lblPosition;
		private System.Windows.Forms.Label txtPosition;
		private System.Windows.Forms.Label lblPosUnit;
		private System.Windows.Forms.Label lblVelocity;
		private System.Windows.Forms.Label txtVelocity;
		private System.Windows.Forms.Label lblVelUnit;
		private System.Windows.Forms.Label lblCurrent;
		private System.Windows.Forms.Label txtCurrent;
		private System.Windows.Forms.Label lblCurUnit;
		private System.Windows.Forms.Button btnPrev;
		private System.Windows.Forms.Label lblStatusPage;
		private System.Windows.Forms.FlowLayoutPanel fpnlFeedback2;
		private System.Windows.Forms.Label lblOverLoad;
		private System.Windows.Forms.Label txtOverload;
		private System.Windows.Forms.Label llblOverLoadUnit;
		private System.Windows.Forms.Label lblDriverTemp;
		private System.Windows.Forms.Label txtDriverTemp;
		private System.Windows.Forms.Label lblDriverTempUnit;
		private System.Windows.Forms.Label lblPowerVoltage;
		private System.Windows.Forms.Label txtPowerVoltage;
		private System.Windows.Forms.Label lblPowerVoltageUnit;
		private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblDummy;
        private System.Windows.Forms.FlowLayoutPanel fpnlKashiyamaMonitor;
        private System.Windows.Forms.Label lblOutputPower;
        private System.Windows.Forms.Label txtOutputPower;
        private System.Windows.Forms.Label lblOutputPowerUnit;
	}
}