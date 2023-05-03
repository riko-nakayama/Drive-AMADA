namespace Motion_Designer
{
    partial class ctlCommandPC_RST_SP
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlCommandPC_RST_SP));
			this.label2 = new System.Windows.Forms.Label();
			this.txtStepNumber = new System.Windows.Forms.TextBox();
			this.gradientLabel1 = new Motion_Designer.GradientLabel();
			this.SuspendLayout();
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// txtStepNumber
			// 
			resources.ApplyResources(this.txtStepNumber, "txtStepNumber");
			this.txtStepNumber.Name = "txtStepNumber";
			this.txtStepNumber.Leave += new System.EventHandler(this.txtStepNumber_Leave);
			this.txtStepNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStepNumber_KeyPress);
			// 
			// gradientLabel1
			// 
			this.gradientLabel1.Angle = 95F;
			this.gradientLabel1.BorderColor = System.Drawing.Color.LightCoral;
			resources.ApplyResources(this.gradientLabel1, "gradientLabel1");
			this.gradientLabel1.EndColor = System.Drawing.Color.White;
			this.gradientLabel1.FormatAlignment = System.Drawing.StringAlignment.Near;
			this.gradientLabel1.IsSpace = true;
			this.gradientLabel1.LineAlignment = System.Drawing.StringAlignment.Center;
			this.gradientLabel1.Name = "gradientLabel1";
			this.gradientLabel1.StartColor = System.Drawing.Color.LightCoral;
			// 
			// ctlCommandPC_RST_SP
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.gradientLabel1);
			this.Controls.Add(this.txtStepNumber);
			this.Controls.Add(this.label2);
			this.Name = "ctlCommandPC_RST_SP";
			this.Load += new System.EventHandler(this.ctlCommandOUT0_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStepNumber;
        private GradientLabel gradientLabel1;
    }
}
