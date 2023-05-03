namespace Motion_Designer
{
    partial class ctlCommandJMP_IN
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlCommandJMP_IN));
			this.label2 = new System.Windows.Forms.Label();
			this.txtDiveStep = new System.Windows.Forms.TextBox();
			this.txtWaitTime = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtInputNumber = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.grpMODE_J1 = new System.Windows.Forms.GroupBox();
			this.rdoWaitTime = new System.Windows.Forms.RadioButton();
			this.rdoInstructionPosInp = new System.Windows.Forms.RadioButton();
			this.rdoInstructionPos = new System.Windows.Forms.RadioButton();
			this.rdoUNCONDWait = new System.Windows.Forms.RadioButton();
			this.gradientLabel1 = new Motion_Designer.GradientLabel();
			this.grpMODE_J1.SuspendLayout();
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
			// label5
			// 
			this.label5.AccessibleDescription = null;
			this.label5.AccessibleName = null;
			resources.ApplyResources(this.label5, "label5");
			this.label5.Name = "label5";
			// 
			// label4
			// 
			this.label4.AccessibleDescription = null;
			this.label4.AccessibleName = null;
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			// 
			// txtInputNumber
			// 
			this.txtInputNumber.AccessibleDescription = null;
			this.txtInputNumber.AccessibleName = null;
			resources.ApplyResources(this.txtInputNumber, "txtInputNumber");
			this.txtInputNumber.BackgroundImage = null;
			this.txtInputNumber.Name = "txtInputNumber";
			this.txtInputNumber.Leave += new System.EventHandler(this.txtInputNumber_Leave);
			this.txtInputNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInputNumber_KeyPress);
			// 
			// label3
			// 
			this.label3.AccessibleDescription = null;
			this.label3.AccessibleName = null;
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// grpMODE_J1
			// 
			this.grpMODE_J1.AccessibleDescription = null;
			this.grpMODE_J1.AccessibleName = null;
			resources.ApplyResources(this.grpMODE_J1, "grpMODE_J1");
			this.grpMODE_J1.BackgroundImage = null;
			this.grpMODE_J1.Controls.Add(this.rdoWaitTime);
			this.grpMODE_J1.Controls.Add(this.rdoInstructionPosInp);
			this.grpMODE_J1.Controls.Add(this.rdoInstructionPos);
			this.grpMODE_J1.Controls.Add(this.rdoUNCONDWait);
			this.grpMODE_J1.Name = "grpMODE_J1";
			this.grpMODE_J1.TabStop = false;
			// 
			// rdoWaitTime
			// 
			this.rdoWaitTime.AccessibleDescription = null;
			this.rdoWaitTime.AccessibleName = null;
			resources.ApplyResources(this.rdoWaitTime, "rdoWaitTime");
			this.rdoWaitTime.BackgroundImage = null;
			this.rdoWaitTime.Font = null;
			this.rdoWaitTime.Name = "rdoWaitTime";
			this.rdoWaitTime.UseVisualStyleBackColor = true;
			this.rdoWaitTime.CheckedChanged += new System.EventHandler(this.rdoMODE_J1_CheckedChanged);
			// 
			// rdoInstructionPosInp
			// 
			this.rdoInstructionPosInp.AccessibleDescription = null;
			this.rdoInstructionPosInp.AccessibleName = null;
			resources.ApplyResources(this.rdoInstructionPosInp, "rdoInstructionPosInp");
			this.rdoInstructionPosInp.BackgroundImage = null;
			this.rdoInstructionPosInp.Font = null;
			this.rdoInstructionPosInp.Name = "rdoInstructionPosInp";
			this.rdoInstructionPosInp.UseVisualStyleBackColor = true;
			this.rdoInstructionPosInp.CheckedChanged += new System.EventHandler(this.rdoMODE_J1_CheckedChanged);
			// 
			// rdoInstructionPos
			// 
			this.rdoInstructionPos.AccessibleDescription = null;
			this.rdoInstructionPos.AccessibleName = null;
			resources.ApplyResources(this.rdoInstructionPos, "rdoInstructionPos");
			this.rdoInstructionPos.BackgroundImage = null;
			this.rdoInstructionPos.Font = null;
			this.rdoInstructionPos.Name = "rdoInstructionPos";
			this.rdoInstructionPos.UseVisualStyleBackColor = true;
			this.rdoInstructionPos.CheckedChanged += new System.EventHandler(this.rdoMODE_J1_CheckedChanged);
			// 
			// rdoUNCONDWait
			// 
			this.rdoUNCONDWait.AccessibleDescription = null;
			this.rdoUNCONDWait.AccessibleName = null;
			resources.ApplyResources(this.rdoUNCONDWait, "rdoUNCONDWait");
			this.rdoUNCONDWait.BackgroundImage = null;
			this.rdoUNCONDWait.Checked = true;
			this.rdoUNCONDWait.Font = null;
			this.rdoUNCONDWait.Name = "rdoUNCONDWait";
			this.rdoUNCONDWait.TabStop = true;
			this.rdoUNCONDWait.UseVisualStyleBackColor = true;
			this.rdoUNCONDWait.CheckedChanged += new System.EventHandler(this.rdoMODE_J1_CheckedChanged);
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
			// ctlCommandJMP_IN
			// 
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			resources.ApplyResources(this, "$this");
			this.BackgroundImage = null;
			this.Controls.Add(this.gradientLabel1);
			this.Controls.Add(this.grpMODE_J1);
			this.Controls.Add(this.txtInputNumber);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtWaitTime);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtDiveStep);
			this.Controls.Add(this.label2);
			this.Font = null;
			this.Name = "ctlCommandJMP_IN";
			this.Load += new System.EventHandler(this.ctlCommandJMP_IN_Load);
			this.grpMODE_J1.ResumeLayout(false);
			this.grpMODE_J1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDiveStep;
        private System.Windows.Forms.TextBox txtWaitTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtInputNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpMODE_J1;
        private System.Windows.Forms.RadioButton rdoInstructionPos;
        private System.Windows.Forms.RadioButton rdoUNCONDWait;
        private System.Windows.Forms.RadioButton rdoWaitTime;
        private System.Windows.Forms.RadioButton rdoInstructionPosInp;
        private GradientLabel gradientLabel1;
    }
}
