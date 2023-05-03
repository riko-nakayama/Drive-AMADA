using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
    //ART HIKARI Mode 20170919 Kimura add
    public partial class IoMonitorHikariForm : Form
	{
		static private Point FormPosition = new Point(0, 0);
		static private Size FormSize = new Size(420, 256);

        static private IoMonitorHikariForm _ThisForm;

		private bool _IsExist = new bool();

		private int _MaxInput = new int();
		private int _MaxOutput = new int();

        public IoMonitorHikariForm()
		{
			InitializeComponent();

			_ThisForm = this;
			_IsExist = true;

			_MaxInput = 10;
			_MaxOutput = 5;
		}

        static public IoMonitorHikariForm ThisForm
		{
			get { return _ThisForm; }
		}

		public bool IsExist
		{
			get { return _IsExist; }
		}

		public int MaxInput
		{
			set { _MaxInput = value; }
			get { return _MaxInput; }
		}

		public int MaxOutput
		{
			set { _MaxOutput = value; }
			get { return _MaxOutput; }
		}

		public bool EnableUpdate
		{
			get
			{
				if (!this.Visible) { return false; }
				if (this.WindowState == FormWindowState.Minimized) { return false; }

				return true;
			}
		}

        public void InitFormLayout(int locationY)
        {
            if (ThisForm == null) { return; }

            //MdiClientの取得
            MdiClient mc = MainForm.ThisForm.GetMdiClient();

            int w = mc.ClientRectangle.Width;
            //int h = mc.ClientRectangle.Height;

            ThisForm.Location = new Point(0, locationY);
            ThisForm.Size = new Size(w, 330);

            ThisForm.WindowState = FormWindowState.Normal;
            ThisForm.ControlBox = false;
        }

		public void SetIoFeedBack()
		{
			int io_status = CMonitor.GetParameter(CParamID.IoStatus) & 0xFFFF;
			int input = io_status & 0x00FF;

            int inputex = (io_status & 0xC000) >> 6;    //bit15:IN10 bit14:IN9
            input |= inputex;

            int output = (io_status >> 8) & 0x00FF;
            int prgout = (io_status >> 4) & 0x000F;

			PictureBox[] pic_in = new PictureBox[10];
			PictureBox[] pic_out = new PictureBox[8];

			pic_in[0] = picIn1;
			pic_in[1] = picIn2;
			pic_in[2] = picIn3;
			pic_in[3] = picIn4;
			pic_in[4] = picIn5;
			pic_in[5] = picIn6;
			pic_in[6] = picIn7;
			pic_in[7] = picIn8;
            pic_in[8] = picIn9;
            pic_in[9] = picIn10;

			pic_out[0] = picOut1;
			pic_out[1] = picOut2;
			pic_out[2] = picOut3;
			pic_out[3] = picOut4;
			pic_out[4] = picOut5;
			pic_out[5] = picOut6;
			pic_out[6] = picOut7;
			pic_out[7] = picOut8;

			for (int i = 0, b = 1; i < pic_in.Length; i++, b <<= 1)
			{
				if (i >= MaxInput) { break; }

                int in_config = CMonitor.GetParameter(CParamID.InputConfig1 + i);

				Color on = Color.Red;
				Color off = Color.Black;

				if ( (in_config & 0x80) == 0x80 )
				{
					//論理反転
					on = Color.Black;
					off = Color.Red;
				}
	
				if ((input & b) == b)
				{
					pic_in[i].BackColor = on;
				}
				else
				{
					pic_in[i].BackColor = off;
				}
			}

            for (int i = 0, b = 1; i < pic_out.Length; i++, b <<= 1)
            {

                if ((output & b) == b)
                {
                    pic_out[i].BackColor = Color.Red;
                }
                else
                {
                    pic_out[i].BackColor = Color.Black;
                }
            }

            //プログラム名称

            //↓↓↓ ART HIKARI Mode 20181210 Kimura update ↓↓↓
            if (prgout == 0)
            {
                lblProgramName.Text = UserText.TipDressingProgram;
            }
            else
            {
                lblProgramName.Text = UserText.ProgramName + prgout.ToString();
            }
            //↑↑↑ ART HIKARI Mode 20181210 Kimura update ↑↑↑
		}

		private void IoMonitorForm_Load(object sender, EventArgs e)
		{
			if (FormPosition.X > 0)
			{
				this.Size = FormSize;
				this.Location = FormPosition;
			}

            lblProgramName.Text = String.Empty;
		}

		private void IoMonitorForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.WindowState != FormWindowState.Minimized)
			{
				FormPosition = this.Location;
			}

			FormSize = this.Size;

			_IsExist = false;
		}

        #region カルチャリソース切り替え

        //↓↓↓ ART HIKARI Mode 20181210 Kimura add ↓↓↓

        public void ViewCultureResouceChanged()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(IoMonitorHikariForm));

            this.Font = (Font)resources.GetObject("$this.Font");
            grpIn_Hikari.Font = (Font)resources.GetObject("grpIn_Hikari.Font");
            grpOut_Hikari.Font = (Font)resources.GetObject("grpOut_Hikari.Font");
            grpProgram.Font = (Font)resources.GetObject("grpProgram.Font");

            lblIn1.Font = (Font)resources.GetObject("lblIn1.Font");
            lblIn2.Font = (Font)resources.GetObject("lblIn2.Font");
            lblIn3.Font = (Font)resources.GetObject("lblIn3.Font");
            lblIn4.Font = (Font)resources.GetObject("lblIn4.Font");
            lblIn5.Font = (Font)resources.GetObject("lblIn5.Font");
            lblIn6.Font = (Font)resources.GetObject("lblIn6.Font");
            lblIn7.Font = (Font)resources.GetObject("lblIn7.Font");
            lblIn8.Font = (Font)resources.GetObject("lblIn8.Font");
            lblIn9.Font = (Font)resources.GetObject("lblIn9.Font");
            lblIn10.Font = (Font)resources.GetObject("lblIn10.Font");

            lblOut1.Font = (Font)resources.GetObject("lblOut1.Font");
            lblOut2.Font = (Font)resources.GetObject("lblOut2.Font");
            lblOut3.Font = (Font)resources.GetObject("lblOut3.Font");
            lblOut4.Font = (Font)resources.GetObject("lblOut4.Font");
            lblOut5.Font = (Font)resources.GetObject("lblOut5.Font");
            lblOut6.Font = (Font)resources.GetObject("lblOut6.Font");
            lblOut7.Font = (Font)resources.GetObject("lblOut7.Font");
            lblOut8.Font = (Font)resources.GetObject("lblOut8.Font");

            this.Text = resources.GetString("$this.Text");
            grpIn_Hikari.Text = resources.GetString("grpIn_Hikari.Text");
            grpOut_Hikari.Text = resources.GetString("grpOut_Hikari.Text");
            grpProgram.Text = resources.GetString("grpProgram.Text");

            lblIn1.Text = resources.GetString("lblIn1.Text");
            lblIn2.Text = resources.GetString("lblIn2.Text");
            lblIn3.Text = resources.GetString("lblIn3.Text");
            lblIn4.Text = resources.GetString("lblIn4.Text");
            lblIn5.Text = resources.GetString("lblIn5.Text");
            lblIn6.Text = resources.GetString("lblIn6.Text");
            lblIn7.Text = resources.GetString("lblIn7.Text");
            lblIn8.Text = resources.GetString("lblIn8.Text");
            lblIn9.Text = resources.GetString("lblIn9.Text");
            lblIn10.Text = resources.GetString("lblIn10.Text");

            lblOut1.Text = resources.GetString("lblOut1.Text");
            lblOut2.Text = resources.GetString("lblOut2.Text");
            lblOut3.Text = resources.GetString("lblOut3.Text");
            lblOut4.Text = resources.GetString("lblOut4.Text");
            lblOut5.Text = resources.GetString("lblOut5.Text");
            lblOut6.Text = resources.GetString("lblOut6.Text");
            lblOut7.Text = resources.GetString("lblOut7.Text");
            lblOut8.Text = resources.GetString("lblOut8.Text");
        }

        //↑↑↑ ART HIKARI Mode 20181210 Kimura add ↑↑↑

        #endregion
	}
}