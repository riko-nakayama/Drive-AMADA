using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Motion_Designer
{
    class GradientLabel : Label 
    {

        private Color backcolor;
        private Color backcolor2;
        private float angle;

        private Color borderColor = Color.Black;
        private StringFormat format = new StringFormat();
        private StringAlignment formatalignment = StringAlignment.Near;
        private StringAlignment linealignment = StringAlignment.Center;

        private bool isspace = true;

        public GradientLabel(): base()
        {
            backcolor = SystemColors.InactiveCaption;
            backcolor2 = Color.White;
            format.Alignment = formatalignment;
            format.LineAlignment = linealignment;
            angle = 95f;
        }

        public bool IsSpace
        {
            get
            {
                return this.isspace;
            }
            set
            {
                this.isspace = value;
            }
        }

        public StringAlignment FormatAlignment
        {
            get
            {
                return this.formatalignment;
            }
            set
            {
                this.formatalignment = value;

                if (this.IsHandleCreated && this.Visible)
                {
                    Invalidate();
                }
            }
        }

        public StringAlignment LineAlignment
        {
            get
            {
                return this.linealignment;
            }
            set
            {
                this.linealignment = value;

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
                return this.backcolor;
            }
            set
            {
                this.backcolor = value;

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
                    return this.backcolor2;
                }
                set 
                {
                    this.backcolor2 = value;

                    if (this.IsHandleCreated && this.Visible)
                    {
                        Invalidate();
                    }
                }
        }

        public float Angle 
        {
                get 
                {
                    return this.angle;
                }
                set 
                {
                    this.angle = value;

                    if (this.IsHandleCreated && this.Visible)
                    {
                        Invalidate();
                    }
                }
        }

        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);
            
            Graphics g = e.Graphics;
            Rectangle clientRect = this.ClientRectangle;
            
            this.TextAlign = ContentAlignment.MiddleCenter;
            format.Alignment = formatalignment;
            format.LineAlignment = linealignment;

            Brush backgroundBrush = new LinearGradientBrush(
                    new Rectangle(clientRect.X, clientRect.Y, clientRect.Width, clientRect.Height),
                    StartColor,
                    EndColor,
                    angle);      
            
            g.FillRectangle(backgroundBrush, clientRect);

            string strspace = "";

            if (isspace)
            {
                strspace = "   ";
            }

            g.DrawString(strspace + this.Text,
                    this.Font,
                    new SolidBrush(this.ForeColor),
                    clientRect,
                    format);

            this.BorderStyle = BorderStyle.None;
            Pen p = new Pen(borderColor, 2);

            Rectangle borderRect = new Rectangle(clientRect.X + 1,
                                                 clientRect.Y + 1,
                                                 clientRect.Width - 2,
                                                 clientRect.Height - 2);

            g.DrawRectangle(p, borderRect);

        }
    
    }

    public static class InputTextBox
    {

        private static Font EditFont = new Font("Arial", 9, FontStyle.Bold);
        private static Font EnterFont = new Font("Arial", 9, FontStyle.Regular);

        /// <summary>
        /// 入力数値チェックKeyPressイベント
        /// </summary>
        /// <param name="e"></param>
        /// <param name="txt"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool CheckText_KeyPress(KeyPressEventArgs e, TextBox txt, ref Int16 s)
        {
            try
            {
                if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == '-' ||
                    e.KeyChar == (char)Keys.Back)
                {
                    txt.ForeColor = Color.Red;
                    txt.Font = EditFont;
                    return false;
                }
                else
                {
                    if (e.KeyChar == (char)Keys.Enter)
                    {
                        s = Convert.ToInt16(txt.Text);
                        txt.ForeColor = Color.Black;
                        txt.Font = EnterFont;

                        //MultiLineの為、改行コードを無視
                        if (e.KeyChar == '\n' || e.KeyChar == '\r')
                        {
                            e.Handled = true;
                        }

                    }
                    else
                    {
                        e.Handled = true;
                        return false;
                    }
                }
            }
            catch
            {
                //入力されたデータが不正です。
                UserMessageBox.SimpleControlInvalidInputError();

                txt.SelectAll();
                txt.Focus();

                return false;
            }

            return true;
        }

        /// <summary>
        /// 入力数値チェックLeaveイベント
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="s"></param>
        public static void CheckText_Leave(TextBox _txt, ref Int16 _s)
        {
            try
            {
                _s = Convert.ToInt16(_txt.Text);
                _txt.ForeColor = Color.Black;
                _txt.Font = EnterFont;

            }
            catch
            {
                //入力されたデータが不正です。
                UserMessageBox.SimpleControlInvalidInputError();
            }
        }

        /// <summary>
        /// 入力数値チェックKeyPressイベント
        /// </summary>
        /// <param name="e"></param>
        /// <param name="txt"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool CheckText_KeyPress(KeyPressEventArgs _e, TextBox _txt, ref Int32 _s)
        {
            try
            {
                if ((_e.KeyChar >= '0' && _e.KeyChar <= '9') || _e.KeyChar == '-' || _e.KeyChar == (char)Keys.Back)
                {
                    _txt.ForeColor = Color.Red;
                    _txt.Font = EditFont;
                    return false;
                }
                else
                {
                    if (_e.KeyChar == (char)Keys.Enter)
                    {
                        _s = Convert.ToInt32(_txt.Text);
                        _txt.ForeColor = Color.Black;
                        _txt.Font = EnterFont;
                    }
                    else
                    {
                        _e.Handled = true;
                        return false;
                    }
                }
            }
            catch
            {
                //入力されたデータが不正です。
                UserMessageBox.SimpleControlInvalidInputError();

                _txt.SelectAll();
                _txt.Focus();

                return false;
            }

            return true;
        }

        /// <summary>
        /// 入力数値チェックKeyPressイベント（１６進入力）
        /// </summary>
        /// <param name="_e"></param>
        /// <param name="_txt"></param>
        /// <param name="_s"></param>
        /// <returns></returns>
        public static bool CheckText_KeyPressHex(KeyPressEventArgs _e, TextBox _txt, ref UInt32 _s)
        {
            try
            {
                if ((_e.KeyChar >= '0' && _e.KeyChar <= '9') || (_e.KeyChar >= 'a' && _e.KeyChar <= 'f') || (_e.KeyChar >= 'A' && _e.KeyChar <= 'F') ||
                    _e.KeyChar == '-' || _e.KeyChar == (char)Keys.Back)
                {
                    _txt.ForeColor = Color.Red;
                    _txt.Font = EditFont;
                    return false;
                }
                else
                {
                    if (_e.KeyChar == (char)Keys.Enter)
                    {
                        _s = Convert.ToUInt32(_txt.Text, 16);
                        _txt.ForeColor = Color.Black;
                        _txt.Font = EnterFont;
                    }
                    else
                    {
                        _e.Handled = true;
                        return false;
                    }
                }
            }
            catch
            {
                //入力されたデータが不正です。
                UserMessageBox.SimpleControlInvalidInputError();

                _txt.SelectAll();
                _txt.Focus();

                return false;
            }

            return true;
        }

        /// <summary>
        /// 入力数値チェックLeaveイベント
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="s"></param>
        public static void CheckText_Leave(TextBox _txt, ref Int32 _s)
        {
            try
            {
                _s = Convert.ToInt32(_txt.Text);
                _txt.ForeColor = Color.Black;
                _txt.Font = EnterFont;
            }
            catch
            {
                //入力されたデータが不正です。
                UserMessageBox.SimpleControlInvalidInputError();
            }

        }


        /// <summary>
        /// 入力数値チェックLeaveイベント（１６進入力）
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="s"></param>
        public static void CheckText_LeaveHex(TextBox _txt, ref UInt32 _s)
        {
            try
            {
                _s = Convert.ToUInt32(_txt.Text, 16);
                _txt.Text = _txt.Text.ToUpper();
                _txt.ForeColor = Color.Black;
                _txt.Font = EnterFont;
            }
            catch
            {
                //入力されたデータが不正です。
                UserMessageBox.SimpleControlInvalidInputError();
            }

        }
    }
}
