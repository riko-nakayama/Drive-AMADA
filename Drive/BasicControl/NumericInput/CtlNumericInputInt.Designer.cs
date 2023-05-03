namespace Motion_Designer
{
	partial class CtlNumericInputInt
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
			this.fpnlNum = new System.Windows.Forms.FlowLayoutPanel();
			this.txtNum = new System.Windows.Forms.TextBox();
			this.txtUnit = new System.Windows.Forms.Label();
			this.txtTitle = new System.Windows.Forms.Label();
			this.numSigned = new Motion_Designer.CtlSignedUpDown20_70();
			this.num10 = new Motion_Designer.CtlNumericUpDown20_70();
			this.num9 = new Motion_Designer.CtlNumericUpDown20_70();
			this.num8 = new Motion_Designer.CtlNumericUpDown20_70();
			this.num7 = new Motion_Designer.CtlNumericUpDown20_70();
			this.num6 = new Motion_Designer.CtlNumericUpDown20_70();
			this.num5 = new Motion_Designer.CtlNumericUpDown20_70();
			this.num4 = new Motion_Designer.CtlNumericUpDown20_70();
			this.num3 = new Motion_Designer.CtlNumericUpDown20_70();
			this.num2 = new Motion_Designer.CtlNumericUpDown20_70();
			this.num1 = new Motion_Designer.CtlNumericUpDown20_70();
			this.fpnlNum.SuspendLayout();
			this.SuspendLayout();
			// 
			// fpnlNum
			// 
			this.fpnlNum.Controls.Add(this.numSigned);
			this.fpnlNum.Controls.Add(this.num10);
			this.fpnlNum.Controls.Add(this.num9);
			this.fpnlNum.Controls.Add(this.num8);
			this.fpnlNum.Controls.Add(this.num7);
			this.fpnlNum.Controls.Add(this.num6);
			this.fpnlNum.Controls.Add(this.num5);
			this.fpnlNum.Controls.Add(this.num4);
			this.fpnlNum.Controls.Add(this.num3);
			this.fpnlNum.Controls.Add(this.num2);
			this.fpnlNum.Controls.Add(this.num1);
			this.fpnlNum.Dock = System.Windows.Forms.DockStyle.Fill;
			this.fpnlNum.Location = new System.Drawing.Point(0, 20);
			this.fpnlNum.Margin = new System.Windows.Forms.Padding(0);
			this.fpnlNum.Name = "fpnlNum";
			this.fpnlNum.Size = new System.Drawing.Size(220, 60);
			this.fpnlNum.TabIndex = 7;
			// 
			// txtNum
			// 
			this.txtNum.BackColor = System.Drawing.Color.White;
			this.txtNum.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.txtNum.ForeColor = System.Drawing.Color.Navy;
			this.txtNum.Location = new System.Drawing.Point(0, 37);
			this.txtNum.Margin = new System.Windows.Forms.Padding(0);
			this.txtNum.Name = "txtNum";
			this.txtNum.Size = new System.Drawing.Size(220, 25);
			this.txtNum.TabIndex = 8;
			this.txtNum.Text = "0";
			this.txtNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtNum.Visible = false;
			this.txtNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNum_KeyDown);
			this.txtNum.Leave += new System.EventHandler(this.txtNum_Leave);
			// 
			// txtUnit
			// 
			this.txtUnit.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.txtUnit.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.txtUnit.Location = new System.Drawing.Point(0, 80);
			this.txtUnit.Name = "txtUnit";
			this.txtUnit.Size = new System.Drawing.Size(220, 20);
			this.txtUnit.TabIndex = 9;
			this.txtUnit.Text = "[rpm]";
			// 
			// txtTitle
			// 
			this.txtTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.txtTitle.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.txtTitle.Location = new System.Drawing.Point(0, 0);
			this.txtTitle.Name = "txtTitle";
			this.txtTitle.Size = new System.Drawing.Size(220, 20);
			this.txtTitle.TabIndex = 10;
			this.txtTitle.Text = "目標速度";
			// 
			// numSigned
			// 
			this.numSigned.Location = new System.Drawing.Point(0, 0);
			this.numSigned.Margin = new System.Windows.Forms.Padding(0);
			this.numSigned.Name = "numSigned";
			this.numSigned.NumBackColor = System.Drawing.Color.White;
			this.numSigned.NumFont = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.numSigned.NumForeColor = System.Drawing.Color.Navy;
			this.numSigned.Padding = new System.Windows.Forms.Padding(1);
			this.numSigned.SignedValue = "+";
			this.numSigned.Size = new System.Drawing.Size(20, 60);
			this.numSigned.TabIndex = 1;
			// 
			// num10
			// 
			this.num10.DoubleValue = 0;
			this.num10.IntValue = 0;
			this.num10.Location = new System.Drawing.Point(20, 0);
			this.num10.Margin = new System.Windows.Forms.Padding(0);
			this.num10.Name = "num10";
			this.num10.NumBackColor = System.Drawing.Color.White;
			this.num10.NumFont = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.num10.NumForeColor = System.Drawing.Color.Black;
			this.num10.Padding = new System.Windows.Forms.Padding(1);
			this.num10.Size = new System.Drawing.Size(20, 60);
			this.num10.StringValue = "0";
			this.num10.TabIndex = 0;
			this.num10.VisibleUpDownButton = true;
			// 
			// num9
			// 
			this.num9.DoubleValue = 0;
			this.num9.IntValue = 0;
			this.num9.Location = new System.Drawing.Point(40, 0);
			this.num9.Margin = new System.Windows.Forms.Padding(0);
			this.num9.Name = "num9";
			this.num9.NumBackColor = System.Drawing.Color.White;
			this.num9.NumFont = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.num9.NumForeColor = System.Drawing.Color.Black;
			this.num9.Padding = new System.Windows.Forms.Padding(1);
			this.num9.Size = new System.Drawing.Size(20, 60);
			this.num9.StringValue = "0";
			this.num9.TabIndex = 0;
			this.num9.VisibleUpDownButton = true;
			// 
			// num8
			// 
			this.num8.DoubleValue = 0;
			this.num8.IntValue = 0;
			this.num8.Location = new System.Drawing.Point(60, 0);
			this.num8.Margin = new System.Windows.Forms.Padding(0);
			this.num8.Name = "num8";
			this.num8.NumBackColor = System.Drawing.Color.White;
			this.num8.NumFont = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.num8.NumForeColor = System.Drawing.Color.Black;
			this.num8.Padding = new System.Windows.Forms.Padding(1);
			this.num8.Size = new System.Drawing.Size(20, 60);
			this.num8.StringValue = "0";
			this.num8.TabIndex = 0;
			this.num8.VisibleUpDownButton = true;
			// 
			// num7
			// 
			this.num7.DoubleValue = 0;
			this.num7.IntValue = 0;
			this.num7.Location = new System.Drawing.Point(80, 0);
			this.num7.Margin = new System.Windows.Forms.Padding(0);
			this.num7.Name = "num7";
			this.num7.NumBackColor = System.Drawing.Color.White;
			this.num7.NumFont = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.num7.NumForeColor = System.Drawing.Color.Black;
			this.num7.Padding = new System.Windows.Forms.Padding(1);
			this.num7.Size = new System.Drawing.Size(20, 60);
			this.num7.StringValue = "0";
			this.num7.TabIndex = 0;
			this.num7.VisibleUpDownButton = true;
			// 
			// num6
			// 
			this.num6.DoubleValue = 0;
			this.num6.IntValue = 0;
			this.num6.Location = new System.Drawing.Point(100, 0);
			this.num6.Margin = new System.Windows.Forms.Padding(0);
			this.num6.Name = "num6";
			this.num6.NumBackColor = System.Drawing.Color.White;
			this.num6.NumFont = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.num6.NumForeColor = System.Drawing.Color.Black;
			this.num6.Padding = new System.Windows.Forms.Padding(1);
			this.num6.Size = new System.Drawing.Size(20, 60);
			this.num6.StringValue = "0";
			this.num6.TabIndex = 0;
			this.num6.VisibleUpDownButton = true;
			// 
			// num5
			// 
			this.num5.DoubleValue = 0;
			this.num5.IntValue = 0;
			this.num5.Location = new System.Drawing.Point(120, 0);
			this.num5.Margin = new System.Windows.Forms.Padding(0);
			this.num5.Name = "num5";
			this.num5.NumBackColor = System.Drawing.Color.White;
			this.num5.NumFont = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.num5.NumForeColor = System.Drawing.Color.Black;
			this.num5.Padding = new System.Windows.Forms.Padding(1);
			this.num5.Size = new System.Drawing.Size(20, 60);
			this.num5.StringValue = "0";
			this.num5.TabIndex = 0;
			this.num5.VisibleUpDownButton = true;
			// 
			// num4
			// 
			this.num4.DoubleValue = 0;
			this.num4.IntValue = 0;
			this.num4.Location = new System.Drawing.Point(140, 0);
			this.num4.Margin = new System.Windows.Forms.Padding(0);
			this.num4.Name = "num4";
			this.num4.NumBackColor = System.Drawing.Color.White;
			this.num4.NumFont = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.num4.NumForeColor = System.Drawing.Color.Black;
			this.num4.Padding = new System.Windows.Forms.Padding(1);
			this.num4.Size = new System.Drawing.Size(20, 60);
			this.num4.StringValue = "0";
			this.num4.TabIndex = 0;
			this.num4.VisibleUpDownButton = true;
			// 
			// num3
			// 
			this.num3.DoubleValue = 0;
			this.num3.IntValue = 0;
			this.num3.Location = new System.Drawing.Point(160, 0);
			this.num3.Margin = new System.Windows.Forms.Padding(0);
			this.num3.Name = "num3";
			this.num3.NumBackColor = System.Drawing.Color.White;
			this.num3.NumFont = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.num3.NumForeColor = System.Drawing.Color.Black;
			this.num3.Padding = new System.Windows.Forms.Padding(1);
			this.num3.Size = new System.Drawing.Size(20, 60);
			this.num3.StringValue = "0";
			this.num3.TabIndex = 0;
			this.num3.VisibleUpDownButton = true;
			// 
			// num2
			// 
			this.num2.DoubleValue = 0;
			this.num2.IntValue = 0;
			this.num2.Location = new System.Drawing.Point(180, 0);
			this.num2.Margin = new System.Windows.Forms.Padding(0);
			this.num2.Name = "num2";
			this.num2.NumBackColor = System.Drawing.Color.White;
			this.num2.NumFont = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.num2.NumForeColor = System.Drawing.Color.Black;
			this.num2.Padding = new System.Windows.Forms.Padding(1);
			this.num2.Size = new System.Drawing.Size(20, 60);
			this.num2.StringValue = "0";
			this.num2.TabIndex = 0;
			this.num2.VisibleUpDownButton = true;
			// 
			// num1
			// 
			this.num1.DoubleValue = 0;
			this.num1.IntValue = 0;
			this.num1.Location = new System.Drawing.Point(200, 0);
			this.num1.Margin = new System.Windows.Forms.Padding(0);
			this.num1.Name = "num1";
			this.num1.NumBackColor = System.Drawing.Color.White;
			this.num1.NumFont = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.num1.NumForeColor = System.Drawing.Color.Black;
			this.num1.Padding = new System.Windows.Forms.Padding(1);
			this.num1.Size = new System.Drawing.Size(20, 60);
			this.num1.StringValue = "0";
			this.num1.TabIndex = 0;
			this.num1.VisibleUpDownButton = true;
			// 
			// CtlNumericInputInt
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.txtNum);
			this.Controls.Add(this.fpnlNum);
			this.Controls.Add(this.txtUnit);
			this.Controls.Add(this.txtTitle);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "CtlNumericInputInt";
			this.Size = new System.Drawing.Size(220, 100);
			this.fpnlNum.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private CtlNumericUpDown20_70 num9;
		private CtlNumericUpDown20_70 num2;
		private CtlNumericUpDown20_70 num1;
		private CtlNumericUpDown20_70 num8;
		private CtlNumericUpDown20_70 num7;
		private CtlNumericUpDown20_70 num5;
		private CtlNumericUpDown20_70 num6;
		private CtlNumericUpDown20_70 num4;
		private CtlNumericUpDown20_70 num3;
		private System.Windows.Forms.FlowLayoutPanel fpnlNum;
		private System.Windows.Forms.TextBox txtNum;
		private CtlSignedUpDown20_70 numSigned;
		private CtlNumericUpDown20_70 num10;
		private System.Windows.Forms.Label txtUnit;
		private System.Windows.Forms.Label txtTitle;
	}
}
