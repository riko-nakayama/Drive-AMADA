namespace Motion_Designer
{
    partial class ctlCommandMOVE_ST
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlCommandMOVE_ST));
			this.grpFLAG_M2 = new System.Windows.Forms.GroupBox();
			this.rdoRelMove = new System.Windows.Forms.RadioButton();
			this.rdoAbsMove = new System.Windows.Forms.RadioButton();
			this.txtDeceleration = new System.Windows.Forms.TextBox();
			this.txtAcceleration = new System.Windows.Forms.TextBox();
			this.txtTargetPos = new System.Windows.Forms.TextBox();
			this.txtTargetVel = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.picProg = new System.Windows.Forms.PictureBox();
			this.gradientLabel4 = new Motion_Designer.GradientLabel();
			this.gradientLabel3 = new Motion_Designer.GradientLabel();
			this.gradientLabel2 = new Motion_Designer.GradientLabel();
			this.ulblAccel = new Motion_Designer.GradientLabel();
			this.gradientLabel1 = new Motion_Designer.GradientLabel();
			this.grpFLAG_M2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picProg)).BeginInit();
			this.SuspendLayout();
			// 
			// grpFLAG_M2
			// 
			this.grpFLAG_M2.AccessibleDescription = null;
			this.grpFLAG_M2.AccessibleName = null;
			resources.ApplyResources(this.grpFLAG_M2, "grpFLAG_M2");
			this.grpFLAG_M2.BackgroundImage = null;
			this.grpFLAG_M2.Controls.Add(this.rdoRelMove);
			this.grpFLAG_M2.Controls.Add(this.rdoAbsMove);
			this.grpFLAG_M2.Name = "grpFLAG_M2";
			this.grpFLAG_M2.TabStop = false;
			// 
			// rdoRelMove
			// 
			this.rdoRelMove.AccessibleDescription = null;
			this.rdoRelMove.AccessibleName = null;
			resources.ApplyResources(this.rdoRelMove, "rdoRelMove");
			this.rdoRelMove.BackgroundImage = null;
			this.rdoRelMove.Font = null;
			this.rdoRelMove.Name = "rdoRelMove";
			this.rdoRelMove.UseVisualStyleBackColor = true;
			this.rdoRelMove.CheckedChanged += new System.EventHandler(this.rdoFLAG_M2_CheckedChanged);
			// 
			// rdoAbsMove
			// 
			this.rdoAbsMove.AccessibleDescription = null;
			this.rdoAbsMove.AccessibleName = null;
			resources.ApplyResources(this.rdoAbsMove, "rdoAbsMove");
			this.rdoAbsMove.BackgroundImage = null;
			this.rdoAbsMove.Checked = true;
			this.rdoAbsMove.Font = null;
			this.rdoAbsMove.Name = "rdoAbsMove";
			this.rdoAbsMove.TabStop = true;
			this.rdoAbsMove.UseVisualStyleBackColor = true;
			this.rdoAbsMove.CheckedChanged += new System.EventHandler(this.rdoFLAG_M2_CheckedChanged);
			// 
			// txtDeceleration
			// 
			this.txtDeceleration.AccessibleDescription = null;
			this.txtDeceleration.AccessibleName = null;
			resources.ApplyResources(this.txtDeceleration, "txtDeceleration");
			this.txtDeceleration.BackgroundImage = null;
			this.txtDeceleration.Name = "txtDeceleration";
			this.txtDeceleration.Leave += new System.EventHandler(this.txtDeceleration_Leave);
			this.txtDeceleration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDeceleration_KeyPress);
			// 
			// txtAcceleration
			// 
			this.txtAcceleration.AccessibleDescription = null;
			this.txtAcceleration.AccessibleName = null;
			resources.ApplyResources(this.txtAcceleration, "txtAcceleration");
			this.txtAcceleration.BackgroundImage = null;
			this.txtAcceleration.Name = "txtAcceleration";
			this.txtAcceleration.Leave += new System.EventHandler(this.txtAcceleration_Leave);
			this.txtAcceleration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAcceleration_KeyPress);
			// 
			// txtTargetPos
			// 
			this.txtTargetPos.AccessibleDescription = null;
			this.txtTargetPos.AccessibleName = null;
			resources.ApplyResources(this.txtTargetPos, "txtTargetPos");
			this.txtTargetPos.BackgroundImage = null;
			this.txtTargetPos.Name = "txtTargetPos";
			this.txtTargetPos.Leave += new System.EventHandler(this.txtTargetPos_Leave);
			this.txtTargetPos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTargetPos_KeyPress);
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
			// label8
			// 
			this.label8.AccessibleDescription = null;
			this.label8.AccessibleName = null;
			resources.ApplyResources(this.label8, "label8");
			this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
			this.label8.Name = "label8";
			// 
			// label6
			// 
			this.label6.AccessibleDescription = null;
			this.label6.AccessibleName = null;
			resources.ApplyResources(this.label6, "label6");
			this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
			this.label6.Name = "label6";
			// 
			// label4
			// 
			this.label4.AccessibleDescription = null;
			this.label4.AccessibleName = null;
			resources.ApplyResources(this.label4, "label4");
			this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
			this.label4.Name = "label4";
			// 
			// label3
			// 
			this.label3.AccessibleDescription = null;
			this.label3.AccessibleName = null;
			resources.ApplyResources(this.label3, "label3");
			this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
			this.label3.Name = "label3";
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
			// gradientLabel4
			// 
			this.gradientLabel4.AccessibleDescription = null;
			this.gradientLabel4.AccessibleName = null;
			resources.ApplyResources(this.gradientLabel4, "gradientLabel4");
			this.gradientLabel4.Angle = 95F;
			this.gradientLabel4.BorderColor = System.Drawing.Color.DarkGray;
			this.gradientLabel4.EndColor = System.Drawing.Color.WhiteSmoke;
			this.gradientLabel4.FormatAlignment = System.Drawing.StringAlignment.Center;
			this.gradientLabel4.IsSpace = false;
			this.gradientLabel4.LineAlignment = System.Drawing.StringAlignment.Far;
			this.gradientLabel4.Name = "gradientLabel4";
			this.gradientLabel4.StartColor = System.Drawing.Color.Silver;
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
			// ctlCommandMOVE_ST
			// 
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			resources.ApplyResources(this, "$this");
			this.BackgroundImage = null;
			this.Controls.Add(this.gradientLabel4);
			this.Controls.Add(this.gradientLabel3);
			this.Controls.Add(this.gradientLabel2);
			this.Controls.Add(this.ulblAccel);
			this.Controls.Add(this.gradientLabel1);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.grpFLAG_M2);
			this.Controls.Add(this.txtDeceleration);
			this.Controls.Add(this.txtTargetVel);
			this.Controls.Add(this.txtAcceleration);
			this.Controls.Add(this.txtTargetPos);
			this.Controls.Add(this.picProg);
			this.Font = null;
			this.Name = "ctlCommandMOVE_ST";
			this.Load += new System.EventHandler(this.ctlCommandMOVE_ST_Load);
			this.grpFLAG_M2.ResumeLayout(false);
			this.grpFLAG_M2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picProg)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpFLAG_M2;
        private System.Windows.Forms.RadioButton rdoRelMove;
        private System.Windows.Forms.RadioButton rdoAbsMove;
        private System.Windows.Forms.TextBox txtDeceleration;
        private System.Windows.Forms.TextBox txtAcceleration;
        private System.Windows.Forms.TextBox txtTargetPos;
        private System.Windows.Forms.TextBox txtTargetVel;
        private System.Windows.Forms.PictureBox picProg;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private GradientLabel gradientLabel1;
        private GradientLabel gradientLabel4;
        private GradientLabel gradientLabel3;
        private GradientLabel gradientLabel2;
        private GradientLabel ulblAccel;
    }
}
