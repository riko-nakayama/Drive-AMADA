using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
    public partial class ResultMessage : Form
    {
        private Point mousePoint;

        public ResultMessage()
        {
            InitializeComponent();
        }

        private void ResultMessage_Load(object sender, EventArgs e)
        {
            TimerBlink.Enabled = true;
        }

        private void TimerBlink_Tick(object sender, EventArgs e)
        {
            if (LblMessage.EndColor == Color.Blue)
            {
                LblMessage.ForeColor = Color.Black;

                LblMessage.StartColor = Color.White;
                LblMessage.EndColor = Color.White;
            }
            else
            {
                LblMessage.ForeColor = Color.White;

                LblMessage.StartColor = Color.Navy;
                LblMessage.EndColor = Color.Blue;
            }

            LblMessage.Refresh();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            TimerBlink.Enabled = false;
            this.Close();
        }

        private void LblMessage_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                //位置を記憶する
                mousePoint = new Point(e.X, e.Y);
            }
        }

        private void LblMessage_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mousePoint.X,
                                          this.Location.Y + e.Y - mousePoint.Y);
            }
        }
    }
}
