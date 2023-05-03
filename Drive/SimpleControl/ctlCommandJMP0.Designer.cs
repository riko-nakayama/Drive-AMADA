namespace Motion_Designer
{
    partial class ctlCommandJMP0
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlCommandJMP0));
			this.label2 = new System.Windows.Forms.Label();
			this.txtDiveStep = new System.Windows.Forms.TextBox();
			this.txtWaitTime = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtRepeatNumber = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.gradientLabel1 = new Motion_Designer.GradientLabel();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AccessibleDescription = null;
			this.label2.AccessibleName = null;
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// txtDiveStep
			// 
			this.txtDiveStep.AccessibleDescription = null;
			this.txtDiveStep.AccessibleName = null;
			resources.ApplyResources(this.txtDiveStep, "txtDiveStep");
			this.txtDiveStep.BackgroundImage = null;
			this.txtDiveStep.Name = "txtDiveStep";
			this.txtDiveStep.Leave += new System.EventHandler(this.txtDiveStep_Leave);
			this.txtDiveStep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiveStep_KeyPress);
			// 
			// txtWaitTime
			// 
			this.txtWaitTime.AccessibleDescription = null;
			this.txtWaitTime.AccessibleName = null;
			resources.ApplyResources(this.txtWaitTime, "txtWaitTime");
			this.txtWaitTime.BackgroundImage = null;
			this.txtWaitTime.Name = "txtWaitTime";
			this.txtWaitTime.Leave += new System.EventHandler(this.txtWaitTime_Leave);
			this.txtWaitTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWaitTime_KeyPress);
			// 
			// label3
			// 
			this.label3.AccessibleDescription = null;
			this.label3.AccessibleName = null;
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// label4
			// 
			this.label4.AccessibleDescription = null;
			this.label4.AccessibleName = null;
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			// 
			// label5
			// 
			this.label5.AccessibleDescription = null;
			this.label5.AccessibleName = null;
			resources.ApplyResources(this.label5, "label5");
			this.label5.Name = "label5";
			// 
			// txtRepeatNumber
			// 
			this.txtRepeatNumber.AccessibleDescription = null;
			this.txtRepeatNumber.AccessibleName = null;
			resources.ApplyResources(this.txtRepeatNumber, "txtRepeatNumber");
			this.txtRepeatNumber.BackgroundImage = null;
			this.txtRepeatNumber.Name = "txtRepeatNumber";
			this.txtRepeatNumber.Leave += new System.EventHandler(this.txtRepeatNumber_Leave);
			this.txtRepeatNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRepeatNumber_KeyPress);
			// 
			// label6
			// 
			this.label6.AccessibleDescription = null;
			this.label6.AccessibleName = null;
			resources.ApplyResources(this.label6, "label6");
			this.label6.Name = "label6";
			// 
			// gradientLabel1
			// 
			this.gradientLabel1.AccessibleDescription = null;
			this.gradientLabel1.AccessibleName = null;
			resources.ApplyResources(this.gradientLabel1, "gradientLabel1");
			this.gradientLabel1.Angle = 95F;
			this.gradientLabel1.BorderColor = System.Drawing.Color.Plum;
			this.gradientLabel1.EndColor = System.Drawing.Color.White;
			this.gradientLabel1.FormatAlignment = System.Drawing.StringAlignment.Near;
			this.gradientLabel1.IsSpace = true;
			this.gradientLabel1.LineAlignment = System.Drawing.StringAlignment.Center;
			this.gradientLabel1.Name = "gradientLabel1";
			this.gradientLabel1.StartColor = System.Drawing.Color.Plum;
			// 
			// ctlCommandJMP0
			// 
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			resources.ApplyResources(this, "$this");
			this.BackgroundImage = null;
			this.Controls.Add(this.gradientLabel1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtRepeatNumber);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtWaitTime);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtDiveStep);
			this.Controls.Add(this.label2);
			this.Font = null;
			this.Name = "ctlCommandJMP0";
			this.Load += new System.EventHandler(this.ctlCommandJMP0_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDiveStep;
        private System.Windows.Forms.TextBox txtWaitTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRepeatNumber;
        private System.Windows.Forms.Label label6;
        private GradientLabel gradientLabel1;
    }
}
