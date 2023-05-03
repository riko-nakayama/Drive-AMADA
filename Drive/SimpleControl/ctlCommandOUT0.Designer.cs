namespace Motion_Designer
{
    partial class ctlCommandOUT0
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlCommandOUT0));
			this.label2 = new System.Windows.Forms.Label();
			this.txtOutNumber = new System.Windows.Forms.TextBox();
			this.txtOutputLogic = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
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
			// txtOutNumber
			// 
			this.txtOutNumber.AccessibleDescription = null;
			this.txtOutNumber.AccessibleName = null;
			resources.ApplyResources(this.txtOutNumber, "txtOutNumber");
			this.txtOutNumber.BackgroundImage = null;
			this.txtOutNumber.Name = "txtOutNumber";
			this.txtOutNumber.Leave += new System.EventHandler(this.txtOutNumber_Leave);
			this.txtOutNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOutNumber_KeyPress);
			// 
			// txtOutputLogic
			// 
			this.txtOutputLogic.AccessibleDescription = null;
			this.txtOutputLogic.AccessibleName = null;
			resources.ApplyResources(this.txtOutputLogic, "txtOutputLogic");
			this.txtOutputLogic.BackgroundImage = null;
			this.txtOutputLogic.Name = "txtOutputLogic";
			this.txtOutputLogic.Leave += new System.EventHandler(this.txtOutputLogic_Leave);
			this.txtOutputLogic.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOutputLogic_KeyPress);
			// 
			// label3
			// 
			this.label3.AccessibleDescription = null;
			this.label3.AccessibleName = null;
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// gradientLabel1
			// 
			this.gradientLabel1.AccessibleDescription = null;
			this.gradientLabel1.AccessibleName = null;
			resources.ApplyResources(this.gradientLabel1, "gradientLabel1");
			this.gradientLabel1.Angle = 95F;
			this.gradientLabel1.BorderColor = System.Drawing.Color.DodgerBlue;
			this.gradientLabel1.EndColor = System.Drawing.Color.White;
			this.gradientLabel1.FormatAlignment = System.Drawing.StringAlignment.Near;
			this.gradientLabel1.IsSpace = true;
			this.gradientLabel1.LineAlignment = System.Drawing.StringAlignment.Center;
			this.gradientLabel1.Name = "gradientLabel1";
			this.gradientLabel1.StartColor = System.Drawing.Color.DodgerBlue;
			// 
			// ctlCommandOUT0
			// 
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			resources.ApplyResources(this, "$this");
			this.BackgroundImage = null;
			this.Controls.Add(this.gradientLabel1);
			this.Controls.Add(this.txtOutputLogic);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtOutNumber);
			this.Controls.Add(this.label2);
			this.Font = null;
			this.Name = "ctlCommandOUT0";
			this.Load += new System.EventHandler(this.ctlCommandOUT0_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOutNumber;
        private System.Windows.Forms.TextBox txtOutputLogic;
        private System.Windows.Forms.Label label3;
        private GradientLabel gradientLabel1;
    }
}
