namespace Motion_Designer
{
    partial class ctlCommandPARA_W
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlCommandPARA_W));
			this.txtWriteData = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtParameterID = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.gradientLabel1 = new Motion_Designer.GradientLabel();
			this.SuspendLayout();
			// 
			// txtWriteData
			// 
			this.txtWriteData.AccessibleDescription = null;
			this.txtWriteData.AccessibleName = null;
			resources.ApplyResources(this.txtWriteData, "txtWriteData");
			this.txtWriteData.BackgroundImage = null;
			this.txtWriteData.Name = "txtWriteData";
			this.txtWriteData.Leave += new System.EventHandler(this.txtWriteData_Leave);
			this.txtWriteData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWriteData_KeyPress);
			// 
			// label3
			// 
			this.label3.AccessibleDescription = null;
			this.label3.AccessibleName = null;
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// txtParameterID
			// 
			this.txtParameterID.AccessibleDescription = null;
			this.txtParameterID.AccessibleName = null;
			resources.ApplyResources(this.txtParameterID, "txtParameterID");
			this.txtParameterID.BackgroundImage = null;
			this.txtParameterID.Name = "txtParameterID";
			this.txtParameterID.Leave += new System.EventHandler(this.txtParameterID_Leave);
			this.txtParameterID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtParameterID_KeyPress);
			// 
			// label2
			// 
			this.label2.AccessibleDescription = null;
			this.label2.AccessibleName = null;
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// gradientLabel1
			// 
			this.gradientLabel1.AccessibleDescription = null;
			this.gradientLabel1.AccessibleName = null;
			resources.ApplyResources(this.gradientLabel1, "gradientLabel1");
			this.gradientLabel1.Angle = 95F;
			this.gradientLabel1.BorderColor = System.Drawing.Color.DarkOrange;
			this.gradientLabel1.EndColor = System.Drawing.Color.White;
			this.gradientLabel1.FormatAlignment = System.Drawing.StringAlignment.Near;
			this.gradientLabel1.IsSpace = true;
			this.gradientLabel1.LineAlignment = System.Drawing.StringAlignment.Center;
			this.gradientLabel1.Name = "gradientLabel1";
			this.gradientLabel1.StartColor = System.Drawing.Color.DarkOrange;
			// 
			// ctlCommandPARA_W
			// 
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			resources.ApplyResources(this, "$this");
			this.BackgroundImage = null;
			this.Controls.Add(this.gradientLabel1);
			this.Controls.Add(this.txtWriteData);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtParameterID);
			this.Controls.Add(this.label2);
			this.Font = null;
			this.Name = "ctlCommandPARA_W";
			this.Load += new System.EventHandler(this.ctlCommandPARA_W_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtWriteData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtParameterID;
        private System.Windows.Forms.Label label2;
        private GradientLabel gradientLabel1;

    }
}
