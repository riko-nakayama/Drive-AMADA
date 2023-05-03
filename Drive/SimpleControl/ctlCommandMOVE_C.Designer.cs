namespace Motion_Designer
{
    partial class ctlCommandMOVE_C
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlCommandMOVE_C));
			this.label2 = new System.Windows.Forms.Label();
			this.txtTargetCur = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.grpFLAG_M4 = new System.Windows.Forms.GroupBox();
			this.rdoAnalog = new System.Windows.Forms.RadioButton();
			this.rdoParameter = new System.Windows.Forms.RadioButton();
			this.gradientLabel1 = new Motion_Designer.GradientLabel();
			this.grpFLAG_M4.SuspendLayout();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AccessibleDescription = null;
			this.label2.AccessibleName = null;
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// txtTargetCur
			// 
			this.txtTargetCur.AccessibleDescription = null;
			this.txtTargetCur.AccessibleName = null;
			resources.ApplyResources(this.txtTargetCur, "txtTargetCur");
			this.txtTargetCur.BackgroundImage = null;
			this.txtTargetCur.Name = "txtTargetCur";
			this.txtTargetCur.Leave += new System.EventHandler(this.txtTargetCur_Leave);
			this.txtTargetCur.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTargetCur_KeyPress);
			// 
			// label3
			// 
			this.label3.AccessibleDescription = null;
			this.label3.AccessibleName = null;
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// grpFLAG_M4
			// 
			this.grpFLAG_M4.AccessibleDescription = null;
			this.grpFLAG_M4.AccessibleName = null;
			resources.ApplyResources(this.grpFLAG_M4, "grpFLAG_M4");
			this.grpFLAG_M4.BackgroundImage = null;
			this.grpFLAG_M4.Controls.Add(this.rdoAnalog);
			this.grpFLAG_M4.Controls.Add(this.rdoParameter);
			this.grpFLAG_M4.Name = "grpFLAG_M4";
			this.grpFLAG_M4.TabStop = false;
			// 
			// rdoAnalog
			// 
			this.rdoAnalog.AccessibleDescription = null;
			this.rdoAnalog.AccessibleName = null;
			resources.ApplyResources(this.rdoAnalog, "rdoAnalog");
			this.rdoAnalog.BackgroundImage = null;
			this.rdoAnalog.Font = null;
			this.rdoAnalog.Name = "rdoAnalog";
			this.rdoAnalog.UseVisualStyleBackColor = true;
			this.rdoAnalog.CheckedChanged += new System.EventHandler(this.rdoFLAG_M4_CheckedChanged);
			// 
			// rdoParameter
			// 
			this.rdoParameter.AccessibleDescription = null;
			this.rdoParameter.AccessibleName = null;
			resources.ApplyResources(this.rdoParameter, "rdoParameter");
			this.rdoParameter.BackgroundImage = null;
			this.rdoParameter.Checked = true;
			this.rdoParameter.Font = null;
			this.rdoParameter.Name = "rdoParameter";
			this.rdoParameter.TabStop = true;
			this.rdoParameter.UseVisualStyleBackColor = true;
			this.rdoParameter.CheckedChanged += new System.EventHandler(this.rdoFLAG_M4_CheckedChanged);
			// 
			// gradientLabel1
			// 
			this.gradientLabel1.AccessibleDescription = null;
			this.gradientLabel1.AccessibleName = null;
			resources.ApplyResources(this.gradientLabel1, "gradientLabel1");
			this.gradientLabel1.Angle = 95F;
			this.gradientLabel1.BorderColor = System.Drawing.Color.RoyalBlue;
			this.gradientLabel1.EndColor = System.Drawing.Color.White;
			this.gradientLabel1.FormatAlignment = System.Drawing.StringAlignment.Near;
			this.gradientLabel1.IsSpace = true;
			this.gradientLabel1.LineAlignment = System.Drawing.StringAlignment.Center;
			this.gradientLabel1.Name = "gradientLabel1";
			this.gradientLabel1.StartColor = System.Drawing.Color.RoyalBlue;
			// 
			// ctlCommandMOVE_C
			// 
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			resources.ApplyResources(this, "$this");
			this.BackgroundImage = null;
			this.Controls.Add(this.gradientLabel1);
			this.Controls.Add(this.grpFLAG_M4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtTargetCur);
			this.Controls.Add(this.label2);
			this.Font = null;
			this.Name = "ctlCommandMOVE_C";
			this.Load += new System.EventHandler(this.ctlCommandMOVE_C_Load);
			this.grpFLAG_M4.ResumeLayout(false);
			this.grpFLAG_M4.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTargetCur;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpFLAG_M4;
        private System.Windows.Forms.RadioButton rdoAnalog;
        private System.Windows.Forms.RadioButton rdoParameter;
        private GradientLabel gradientLabel1;
    }
}
