using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
    public class DoubleBufferTableLayoutPanel : TableLayoutPanel
    {
        public DoubleBufferTableLayoutPanel()
        {
            this.DoubleBuffered = true;
            
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint |
             ControlStyles.AllPaintingInWmPaint, true);

            this.UpdateStyles();
        }
    } 
}
