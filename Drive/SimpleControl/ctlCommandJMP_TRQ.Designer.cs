﻿namespace Motion_Designer
{
    partial class ctlCommandJMP_TRQ
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlCommandJMP_TRQ));
			this.label2 = new System.Windows.Forms.Label();
			this.txtDiveStep = new System.Windows.Forms.TextBox();
			this.txtCurThreshold = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.grpMODE_J3 = new System.Windows.Forms.GroupBox();
			this.rdoWaitTime = new System.Windows.Forms.RadioButton();
			this.rdoInstructionPosInp = new System.Windows.Forms.RadioButton();
			this.rdoInstructionPos = new System.Windows.Forms.RadioButton();
			this.rdoUNCONDWait = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rdoThresholdLess = new System.Windows.Forms.RadioButton();
			this.rdoThresholdNotLess = new System.Windows.Forms.RadioButton();
			this.label4 = new System.Windows.Forms.Label();
			this.txtWaitTime = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.gradientLabel1 = new Motion_Designer.GradientLabel();
			this.grpMODE_J3.SuspendLayout();
			this.groupBox1.SuspendLayout();
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
			// txtCurThreshold
			// 
			this.txtCurThreshold.AccessibleDescription = null;
			this.txtCurThreshold.AccessibleName = null;
			resources.ApplyResources(this.txtCurThreshold, "txtCurThreshold");
			this.txtCurThreshold.BackgroundImage = null;
			this.txtCurThreshold.Name = "txtCurThreshold";
			this.txtCurThreshold.Leave += new System.EventHandler(this.txtCurThreshold_Leave);
			this.txtCurThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCurThreshold_KeyPress);
			// 
			// label3
			// 
			this.label3.AccessibleDescription = null;
			this.label3.AccessibleName = null;
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// grpMODE_J3
			// 
			this.grpMODE_J3.AccessibleDescription = null;
			this.grpMODE_J3.AccessibleName = null;
			resources.ApplyResources(this.grpMODE_J3, "grpMODE_J3");
			this.grpMODE_J3.BackgroundImage = null;
			this.grpMODE_J3.Controls.Add(this.rdoWaitTime);
			this.grpMODE_J3.Controls.Add(this.rdoInstructionPosInp);
			this.grpMODE_J3.Controls.Add(this.rdoInstructionPos);
			this.grpMODE_J3.Controls.Add(this.rdoUNCONDWait);
			this.grpMODE_J3.Name = "grpMODE_J3";
			this.grpMODE_J3.TabStop = false;
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
			this.rdoWaitTime.CheckedChanged += new System.EventHandler(this.rdoMODE_J3_CheckedChanged);
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
			this.rdoInstructionPosInp.CheckedChanged += new System.EventHandler(this.rdoMODE_J3_CheckedChanged);
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
			this.rdoInstructionPos.CheckedChanged += new System.EventHandler(this.rdoMODE_J3_CheckedChanged);
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
			this.rdoUNCONDWait.CheckedChanged += new System.EventHandler(this.rdoMODE_J3_CheckedChanged);
			// 
			// label1
			// 
			this.label1.AccessibleDescription = null;
			this.label1.AccessibleName = null;
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// groupBox1
			// 
			this.groupBox1.AccessibleDescription = null;
			this.groupBox1.AccessibleName = null;
			resources.ApplyResources(this.groupBox1, "groupBox1");
			this.groupBox1.BackgroundImage = null;
			this.groupBox1.Controls.Add(this.rdoThresholdLess);
			this.groupBox1.Controls.Add(this.rdoThresholdNotLess);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.TabStop = false;
			// 
			// rdoThresholdLess
			// 
			this.rdoThresholdLess.AccessibleDescription = null;
			this.rdoThresholdLess.AccessibleName = null;
			resources.ApplyResources(this.rdoThresholdLess, "rdoThresholdLess");
			this.rdoThresholdLess.BackgroundImage = null;
			this.rdoThresholdLess.Font = null;
			this.rdoThresholdLess.Name = "rdoThresholdLess";
			this.rdoThresholdLess.UseVisualStyleBackColor = true;
			this.rdoThresholdLess.CheckedChanged += new System.EventHandler(this.rdoThreshold_CheckedChanged);
			// 
			// rdoThresholdNotLess
			// 
			this.rdoThresholdNotLess.AccessibleDescription = null;
			this.rdoThresholdNotLess.AccessibleName = null;
			resources.ApplyResources(this.rdoThresholdNotLess, "rdoThresholdNotLess");
			this.rdoThresholdNotLess.BackgroundImage = null;
			this.rdoThresholdNotLess.Checked = true;
			this.rdoThresholdNotLess.Font = null;
			this.rdoThresholdNotLess.Name = "rdoThresholdNotLess";
			this.rdoThresholdNotLess.TabStop = true;
			this.rdoThresholdNotLess.UseVisualStyleBackColor = true;
			this.rdoThresholdNotLess.CheckedChanged += new System.EventHandler(this.rdoThreshold_CheckedChanged);
			// 
			// label4
			// 
			this.label4.AccessibleDescription = null;
			this.label4.AccessibleName = null;
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
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
			// ctlCommandJMP_TRQ
			// 
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			resources.ApplyResources(this, "$this");
			this.BackgroundImage = null;
			this.Controls.Add(this.gradientLabel1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtWaitTime);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.grpMODE_J3);
			this.Controls.Add(this.txtCurThreshold);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtDiveStep);
			this.Controls.Add(this.label2);
			this.Font = null;
			this.Name = "ctlCommandJMP_TRQ";
			this.Load += new System.EventHandler(this.ctlCommandJMP_IN_Load);
			this.grpMODE_J3.ResumeLayout(false);
			this.grpMODE_J3.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDiveStep;
        private System.Windows.Forms.TextBox txtCurThreshold;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpMODE_J3;
        private System.Windows.Forms.RadioButton rdoInstructionPos;
        private System.Windows.Forms.RadioButton rdoUNCONDWait;
        private System.Windows.Forms.RadioButton rdoWaitTime;
        private System.Windows.Forms.RadioButton rdoInstructionPosInp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoThresholdLess;
        private System.Windows.Forms.RadioButton rdoThresholdNotLess;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtWaitTime;
        private System.Windows.Forms.Label label5;
        private GradientLabel gradientLabel1;
    }
}