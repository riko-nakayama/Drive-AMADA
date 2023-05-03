namespace Motion_Designer
{
    partial class ctlCommandMOVE_V
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlCommandMOVE_V));
			this.txtDeceleration = new System.Windows.Forms.TextBox();
			this.txtTargetVel = new System.Windows.Forms.TextBox();
			this.txtAcceleration = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.picProg = new System.Windows.Forms.PictureBox();
			this.grpFLAG_M3 = new System.Windows.Forms.GroupBox();
			this.rdoAnalog = new System.Windows.Forms.RadioButton();
			this.rdoParameter = new System.Windows.Forms.RadioButton();
			this.gradientLabel3 = new Motion_Designer.GradientLabel();
			this.gradientLabel2 = new Motion_Designer.GradientLabel();
			this.ulblAccel = new Motion_Designer.GradientLabel();
			this.gradientLabel1 = new Motion_Designer.GradientLabel();
			((System.ComponentModel.ISupportInitialize)(this.picProg)).BeginInit();
			this.grpFLAG_M3.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtDeceleration
			// 
			this.txtDeceleration.AccessibleDescription = null;
			this.txtDeceleration.AccessibleName = null;
			resources.ApplyResources(this.txtDeceleration, "txtDeceleration");
			this.txtDeceleration.BackgroundImage = null;
			this.txtDeceleration.Name = "txtDeceleration";
			this.txtDeceleration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDeceleration_KeyPress);
			this.txtDeceleration.Enter += new System.EventHandler(this.txtDeceleration_Enter);
			// 
			// txtTargetVel
			// 
			this.txtTargetVel.AccessibleDescription = null;
			this.txtTargetVel.AccessibleName = null;
			resources.ApplyResources(this.txtTargetVel, "txtTargetVel");
			this.txtTargetVel.BackgroundImage = null;
			this.txtTargetVel.Name = "txtTargetVel";
			this.txtTargetVel.Leave += new System.EventHandler(this.txtTargetVel_Leave);
			this.txtTargetVel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTargetVel_KeyPress);
			// 
			// txtAcceleration
			// 
			this.txtAcceleration.AccessibleDescription = null;
			this.txtAcceleration.AccessibleName = null;
			resources.ApplyResources(this.txtAcceleration, "txtAcceleration");
			this.txtAcceleration.BackgroundImage = null;
			this.txtAcceleration.Name = "txtAcceleration";
			this.txtAcceleration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAcceleration_KeyPress);
			this.txtAcceleration.DragLeave += new System.EventHandler(this.txtAcceleration_DragLeave);
			// 
			// label1
			// 
			this.label1.AccessibleDescription = null;
			this.label1.AccessibleName = null;
			resources.ApplyResources(this.label1, "label1");
			this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
			this.label1.Name = "label1";
			// 
			// label4
			// 
			this.label4.AccessibleDescription = null;
			this.label4.AccessibleName = null;
			resources.ApplyResources(this.label4, "label4");
			this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
			this.label4.Name = "label4";
			// 
			// label5
			// 
			this.label5.AccessibleDescription = null;
			this.label5.AccessibleName = null;
			resources.ApplyResources(this.label5, "label5");
			this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
			this.label5.Name = "label5";
			// 
			// picProg
			// 
			this.picProg.AccessibleDescription = null;
			this.picProg.AccessibleName = null;
			resources.ApplyResources(this.picProg, "picProg");
			this.picProg.BackgroundImage = null;
			this.picProg.Font = null;
			this.picProg.Image = global::Motion_Designer.Properties.Resources.運転台形;
			this.picProg.ImageLocation = null;
			this.picProg.Name = "picProg";
			this.picProg.TabStop = false;
			// 
			// grpFLAG_M3
			// 
			this.grpFLAG_M3.AccessibleDescription = null;
			this.grpFLAG_M3.AccessibleName = null;
			resources.ApplyResources(this.grpFLAG_M3, "grpFLAG_M3");
			this.grpFLAG_M3.BackgroundImage = null;
			this.grpFLAG_M3.Controls.Add(this.rdoAnalog);
			this.grpFLAG_M3.Controls.Add(this.rdoParameter);
			this.grpFLAG_M3.Name = "grpFLAG_M3";
			this.grpFLAG_M3.TabStop = false;
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
			this.rdoParameter.CheckedChanged += new System.EventHandler(this.rdoFLAG_M3_CheckedChanged);
			// 
			// gradientLabel3
			// 
			this.gradientLabel3.AccessibleDescription = null;
			this.gradientLabel3.AccessibleName = null;
			resources.ApplyResources(this.gradientLabel3, "gradientLabel3");
			this.gradientLabel3.Angle = 95F;
			this.gradientLabel3.BorderColor = System.Drawing.Color.DarkGray;
			this.gradientLabel3.EndColor = System.Drawing.Color.WhiteSmoke;
			this.gradientLabel3.FormatAlignment = System.Drawing.StringAlignment.Center;
			this.gradientLabel3.IsSpace = false;
			this.gradientLabel3.LineAlignment = System.Drawing.StringAlignment.Far;
			this.gradientLabel3.Name = "gradientLabel3";
			this.gradientLabel3.StartColor = System.Drawing.Color.Silver;
			// 
			// gradientLabel2
			// 
			this.gradientLabel2.AccessibleDescription = null;
			this.gradientLabel2.AccessibleName = null;
			resources.ApplyResources(this.gradientLabel2, "gradientLabel2");
			this.gradientLabel2.Angle = 95F;
			this.gradientLabel2.BorderColor = System.Drawing.Color.DarkGray;
			this.gradientLabel2.EndColor = System.Drawing.Color.WhiteSmoke;
			this.gradientLabel2.FormatAlignment = System.Drawing.StringAlignment.Center;
			this.gradientLabel2.IsSpace = false;
			this.gradientLabel2.LineAlignment = System.Drawing.StringAlignment.Far;
			this.gradientLabel2.Name = "gradientLabel2";
			this.gradientLabel2.StartColor = System.Drawing.Color.Silver;
			// 
			// ulblAccel
			// 
			this.ulblAccel.AccessibleDescription = null;
			this.ulblAccel.AccessibleName = null;
			resources.ApplyResources(this.ulblAccel, "ulblAccel");
			this.ulblAccel.Angle = 95F;
			this.ulblAccel.BorderColor = System.Drawing.Color.DarkGray;
			this.ulblAccel.EndColor = System.Drawing.Color.WhiteSmoke;
			this.ulblAccel.FormatAlignment = System.Drawing.StringAlignment.Center;
			this.ulblAccel.IsSpace = false;
			this.ulblAccel.LineAlignment = System.Drawing.StringAlignment.Far;
			this.ulblAccel.Name = "ulblAccel";
			this.ulblAccel.StartColor = System.Drawing.Color.Silver;
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
			// ctlCommandMOVE_V
			// 
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			resources.ApplyResources(this, "$this");
			this.BackgroundImage = null;
			this.Controls.Add(this.gradientLabel3);
			this.Controls.Add(this.gradientLabel2);
			this.Controls.Add(this.ulblAccel);
			this.Controls.Add(this.gradientLabel1);
			this.Controls.Add(this.grpFLAG_M3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtDeceleration);
			this.Controls.Add(this.txtTargetVel);
			this.Controls.Add(this.txtAcceleration);
			this.Controls.Add(this.picProg);
			this.Font = null;
			this.Name = "ctlCommandMOVE_V";
			this.Load += new System.EventHandler(this.ctlCommandMOVE_V_Load);
			((System.ComponentModel.ISupportInitialize)(this.picProg)).EndInit();
			this.grpFLAG_M3.ResumeLayout(false);
			this.grpFLAG_M3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDeceleration;
        private System.Windows.Forms.TextBox txtTargetVel;
        private System.Windows.Forms.TextBox txtAcceleration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox picProg;
        private System.Windows.Forms.GroupBox grpFLAG_M3;
        private System.Windows.Forms.RadioButton rdoAnalog;
        private System.Windows.Forms.RadioButton rdoParameter;
        private GradientLabel gradientLabel1;
        private GradientLabel gradientLabel3;
        private GradientLabel gradientLabel2;
        private GradientLabel ulblAccel;
    }
}
