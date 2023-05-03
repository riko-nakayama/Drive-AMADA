namespace Motion_Designer
{
    partial class ctlCommandWAIT0
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlCommandWAIT0));
			this.txtWaitTime = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.gradientLabel1 = new Motion_Designer.GradientLabel();
			this.SuspendLayout();
			// 
			// txtWaitTime
			// 
			resources.ApplyResources(this.txtWaitTime, "txtWaitTime");
			this.txtWaitTime.Name = "txtWaitTime";
			this.txtWaitTime.Leave += new System.EventHandler(this.txtWaitTime_Leave);
			this.txtWaitTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWaitTime_KeyPress);
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label3.Name = "label3";
			// 
			// label4
			// 
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			// 
			// gradientLabel1
			// 
			this.gradientLabel1.Angle = 95F;
			this.gradientLabel1.BorderColor = System.Drawing.Color.Salmon;
			resources.ApplyResources(this.gradientLabel1, "gradientLabel1");
			this.gradientLabel1.EndColor = System.Drawing.Color.White;
			this.gradientLabel1.FormatAlignment = System.Drawing.StringAlignment.Near;
			this.gradientLabel1.IsSpace = true;
			this.gradientLabel1.LineAlignment = System.Drawing.StringAlignment.Center;
			this.gradientLabel1.Name = "gradientLabel1";
			this.gradientLabel1.StartColor = System.Drawing.Color.Salmon;
			// 
			// ctlCommandWAIT0
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.gradientLabel1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtWaitTime);
			this.Controls.Add(this.label3);
			this.Name = "ctlCommandWAIT0";
			this.Load += new System.EventHandler(this.ctlCommandWAIT0_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtWaitTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private GradientLabel gradientLabel1;
    }
}
