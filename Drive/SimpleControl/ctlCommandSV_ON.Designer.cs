﻿namespace Motion_Designer
{
    partial class ctlCommandSV_ON
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
			this.gradientLabel1 = new Motion_Designer.GradientLabel();
			this.SuspendLayout();
			// 
			// gradientLabel1
			// 
			this.gradientLabel1.Angle = 95F;
			this.gradientLabel1.BorderColor = System.Drawing.Color.LimeGreen;
			this.gradientLabel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.gradientLabel1.EndColor = System.Drawing.Color.White;
			this.gradientLabel1.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Bold);
			this.gradientLabel1.FormatAlignment = System.Drawing.StringAlignment.Near;
			this.gradientLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.gradientLabel1.IsSpace = true;
			this.gradientLabel1.LineAlignment = System.Drawing.StringAlignment.Center;
			this.gradientLabel1.Location = new System.Drawing.Point(0, 0);
			this.gradientLabel1.Name = "gradientLabel1";
			this.gradientLabel1.Size = new System.Drawing.Size(421, 22);
			this.gradientLabel1.StartColor = System.Drawing.Color.LimeGreen;
			this.gradientLabel1.TabIndex = 139;
			this.gradientLabel1.Text = "SV_ON";
			this.gradientLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ctlCommandSV_ON
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.Controls.Add(this.gradientLabel1);
			this.Name = "ctlCommandSV_ON";
			this.Size = new System.Drawing.Size(421, 260);
			this.ResumeLayout(false);

        }

        #endregion

        private GradientLabel gradientLabel1;

    }
}
