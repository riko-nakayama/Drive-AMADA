
namespace Motion_Designer
{
    partial class ResultMessage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TimerBlink = new System.Windows.Forms.Timer(this.components);
            this.LblMessage = new Motion_Designer.GradientLabel();
            this.btnOK = new Motion_Designer.GradientButton();
            this.SuspendLayout();
            // 
            // TimerBlink
            // 
            this.TimerBlink.Interval = 500;
            this.TimerBlink.Tick += new System.EventHandler(this.TimerBlink_Tick);
            // 
            // LblMessage
            // 
            this.LblMessage.Angle = -90F;
            this.LblMessage.BorderColor = System.Drawing.Color.Transparent;
            this.LblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblMessage.EndColor = System.Drawing.Color.White;
            this.LblMessage.Font = new System.Drawing.Font("メイリオ", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblMessage.ForeColor = System.Drawing.Color.Black;
            this.LblMessage.FormatAlignment = System.Drawing.StringAlignment.Center;
            this.LblMessage.IsSpace = false;
            this.LblMessage.LineAlignment = System.Drawing.StringAlignment.Center;
            this.LblMessage.Location = new System.Drawing.Point(0, 0);
            this.LblMessage.Margin = new System.Windows.Forms.Padding(0);
            this.LblMessage.Name = "LblMessage";
            this.LblMessage.Size = new System.Drawing.Size(413, 274);
            this.LblMessage.StartColor = System.Drawing.Color.White;
            this.LblMessage.TabIndex = 0;
            this.LblMessage.Text = "完了";
            this.LblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblMessage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblMessage_MouseDown);
            this.LblMessage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LblMessage_MouseMove);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.Angle = 90F;
            this.btnOK.ClientRectYMargin = 5;
            this.btnOK.EndColor = System.Drawing.Color.LightGray;
            this.btnOK.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnOK.ForeColor = System.Drawing.Color.Navy;
            this.btnOK.Location = new System.Drawing.Point(142, 217);
            this.btnOK.Name = "btnOK";
            this.btnOK.PushEndColor = System.Drawing.Color.White;
            this.btnOK.PushStartColor = System.Drawing.Color.Gold;
            this.btnOK.Size = new System.Drawing.Size(128, 40);
            this.btnOK.StartColor = System.Drawing.Color.White;
            this.btnOK.TabIndex = 113;
            this.btnOK.Text = "ＯＫ";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ResultMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 274);
            this.ControlBox = false;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.LblMessage);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ResultMessage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ResultMessage";
            this.Load += new System.EventHandler(this.ResultMessage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer TimerBlink;
        private GradientLabel LblMessage;
        private GradientButton btnOK;
    }
}