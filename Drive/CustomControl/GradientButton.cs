using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Motion_Designer
{
    class GradientButton : Button 
    {

        // members to hold our color settings
        private Color startColor;
        private Color endColor;
        private float angle;

        private Color pushstartColor;
        private Color pushendColor;

        // we'll need this to paint the text
        private static StringFormat format = new StringFormat();

        private bool push = false;

        private int clientrectymargin;

        public delegate void dTouchUp();
        public event dTouchUp TouchUp;

        public delegate void dTouchDown();
        public event dTouchDown TouchDown;

        public delegate void dTouchMove();
        public event dTouchMove TouchMove;

        public GradientButton() : base()
        {
            // initialize our colors 
            startColor = Color.White;
            endColor = Color.Gray;

            pushstartColor = Color.Gold;
            pushendColor = Color.White;

            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            angle = 90f;

            clientrectymargin = 5;

            this.ForeColor = Color.Navy;
        }
        public int ClientRectYMargin
        {
            get
            {
                return this.clientrectymargin;
            }
            set
            {
                this.clientrectymargin = value;
                // cause a repaint if necessary
                if (this.IsHandleCreated && this.Visible)
                {
                    Invalidate();
                }
            }
        }

        public Color EndColor
        {
            get
            {
                return this.endColor;
            }
            set
            {
                this.endColor = value;
                // cause a repaint if necessary
                if (this.IsHandleCreated && this.Visible)
                {
                    Invalidate();
                }
            }
        }

        public Color StartColor
        {
            get
            {
                return this.startColor;
            }
            set
            {
                this.startColor = value;
                // cause a repaint if necessary
                if (this.IsHandleCreated && this.Visible)
                {
                    Invalidate();
                }
            }
        }

        public Color PushEndColor
        {
            get
            {
                return this.pushendColor;
            }
            set
            {
                this.pushendColor = value;
                // cause a repaint if necessary
                if (this.IsHandleCreated && this.Visible)
                {
                    Invalidate();
                }
            }
        }

        public Color PushStartColor
        {
            get
            {
                return this.pushstartColor;
            }
            set
            {
                this.pushstartColor = value;
                // cause a repaint if necessary
                if (this.IsHandleCreated && this.Visible)
                {
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// 角度を変更するためのプロパティ Angle を追加
        /// </summary>
        public float Angle
        {
            get
            {
                return this.angle;
            }
            set
            {
                this.angle = value;
                // cause a repaint if necessary
                if (this.IsHandleCreated && this.Visible)
                {
                    Invalidate();
                }
            }
        }

        protected override void WndProc(ref Message m)  // @
        {
            if (m.Msg == 0x246/*WM_POINTERDOWN*/)
            {
                // タッチパネルでボタンが押された時の処理
                if (TouchDown != null) TouchDown();
            }
            else if (m.Msg == 0x247/*WM_POINTERUP*/)
            {
                // タッチパネルでボタンが離された時の処理
                if (TouchUp != null) TouchUp();
            }
            else if (m.Msg == 0x245/*Touch stationary/Moving*/)
            {
                // タッチパネルで移動
                if (TouchMove != null) TouchMove();
            }

            base.WndProc(ref m);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Brush backgroundBrush;

            base.OnPaint(pe);
            Graphics g = pe.Graphics;
            Rectangle clientRect = this.ClientRectangle;
            clientRect.Inflate(-2, -2);

            if (push)
            {
                backgroundBrush = new LinearGradientBrush(new Rectangle(clientRect.X, clientRect.Y, clientRect.Width, clientRect.Height),
                                                          pushstartColor,
                                                          pushendColor,
                                                          90f);
            }
            else
            {
                backgroundBrush = new LinearGradientBrush(new Rectangle(clientRect.X, clientRect.Y, clientRect.Width, clientRect.Height),
                                                          startColor,
                                                          endColor,
                                                          angle);
            }

            g.FillRectangle(backgroundBrush, clientRect);

            clientRect.Y = clientrectymargin;
           
            g.DrawString(this.Text,
                         this.Font,
                         new SolidBrush(this.ForeColor),
                         clientRect,
                         format);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);

            push = true;
            this.Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);

            push = false;
            this.Invalidate();
        }
    }

}
