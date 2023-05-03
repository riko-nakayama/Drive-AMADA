namespace Motion_Designer
{
	partial class CtlNumericUpDown20_70
	{
		/// <summary> 
		/// 必要なデザイナー変数です。
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

		#region コンポーネント デザイナーで生成されたコード

		/// <summary> 
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlNumericUpDown20_70));
			this.txtNum = new System.Windows.Forms.TextBox();
			this.lblNum = new System.Windows.Forms.Label();
			this.btnDown = new System.Windows.Forms.Button();
			this.btnUp = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtNum
			// 
			this.txtNum.BackColor = System.Drawing.Color.White;
			this.txtNum.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.txtNum.ForeColor = System.Drawing.Color.Black;
			this.txtNum.Location = new System.Drawing.Point(0, 12);
			this.txtNum.Name = "txtNum";
			this.txtNum.ReadOnly = true;
			this.txtNum.Size = new System.Drawing.Size(20, 31);
			this.txtNum.TabIndex = 4;
			this.txtNum.TabStop = false;
			this.txtNum.Text = "0";
			this.txtNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtNum.Click += new System.EventHandler(this.txtNum_Click);
			this.txtNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNum_KeyDown);
			// 
			// lblNum
			// 
			this.lblNum.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblNum.Font = new System.Drawing.Font("7barSPBd", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblNum.Location = new System.Drawing.Point(0, 17);
			this.lblNum.Name = "lblNum";
			this.lblNum.Size = new System.Drawing.Size(20, 26);
			this.lblNum.TabIndex = 5;
			this.lblNum.Text = "0";
			this.lblNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblNum.Click += new System.EventHandler(this.txtNum_Click);
			// 
			// btnDown
			// 
			this.btnDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDown.BackgroundImage")));
			this.btnDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnDown.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.btnDown.Location = new System.Drawing.Point(0, 43);
			this.btnDown.Name = "btnDown";
			this.btnDown.Size = new System.Drawing.Size(20, 17);
			this.btnDown.TabIndex = 3;
			this.btnDown.TabStop = false;
			this.btnDown.UseVisualStyleBackColor = true;
			this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
			this.btnDown.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnDown_MouseClick);
			// 
			// btnUp
			// 
			this.btnUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUp.BackgroundImage")));
			this.btnUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnUp.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnUp.Location = new System.Drawing.Point(0, 0);
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size(20, 17);
			this.btnUp.TabIndex = 2;
			this.btnUp.TabStop = false;
			this.btnUp.UseVisualStyleBackColor = true;
			this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
			this.btnUp.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnUp_MouseClick);
			// 
			// CtlNumericUpDown20_70
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lblNum);
			this.Controls.Add(this.btnDown);
			this.Controls.Add(this.btnUp);
			this.Controls.Add(this.txtNum);
			this.Name = "CtlNumericUpDown20_70";
			this.Size = new System.Drawing.Size(20, 60);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnDown;
		private System.Windows.Forms.TextBox txtNum;
		private System.Windows.Forms.Button btnUp;
		private System.Windows.Forms.Label lblNum;
	}
}
