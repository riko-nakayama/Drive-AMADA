using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
	public partial class IoMonitorForm : Form
	{
		static private Point FormPosition = new Point(0, 0);
		static private Size FormSize = new Size(420, 240);

		static private IoMonitorForm _ThisForm;

		private bool _IsExist = new bool();

		private int _MaxInput = new int();
		private int _MaxOutput = new int();

		public IoMonitorForm()
		{
			InitializeComponent();

			_ThisForm = this;
			_IsExist = true;

            //↓↓↓ KASHIYAMA Mode 20190624 Kimura update ↓↓↓
            if (Properties.Settings.Default.PASSWORD_KASHIYAMA == false)
            {
                _MaxInput = 8;
                _MaxOutput = 5;
            }
            else
            {
                _MaxInput = 5;
                _MaxOutput = 2;
            }
            //↑↑↑ KASHIYAMA Mode 20190624 Kimura update ↑↑↑
		}

		static public IoMonitorForm ThisForm
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

		public void SetIoFeedBack()
		{
			int io_status = CMonitor.GetParameter(CParamID.IoStatus) & 0xFFFF;
			int input = io_status & 0x00FF;
			int output = (io_status >> 8) & 0x00FF;

			Label[] lbl_in = new Label[8];
			Label[] lbl_out = new Label[8];

			lbl_in[0] = lblIn1;
			lbl_in[1] = lblIn2;
			lbl_in[2] = lblIn3;
			lbl_in[3] = lblIn4;
			lbl_in[4] = lblIn5;
			lbl_in[5] = lblIn6;
			lbl_in[6] = lblIn7;
			lbl_in[7] = lblIn8;

			lbl_out[0] = lblOut1;
			lbl_out[1] = lblOut2;
			lbl_out[2] = lblOut3;
			lbl_out[3] = lblOut4;
			lbl_out[4] = lblOut5;
			lbl_out[5] = lblOut6;
			lbl_out[6] = lblOut7;
			lbl_out[7] = lblOut8;

			PictureBox[] pic_in = new PictureBox[8];
			PictureBox[] pic_out = new PictureBox[8];

			pic_in[0] = picIn1;
			pic_in[1] = picIn2;
			pic_in[2] = picIn3;
			pic_in[3] = picIn4;
			pic_in[4] = picIn5;
			pic_in[5] = picIn6;
			pic_in[6] = picIn7;
			pic_in[7] = picIn8;

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

                //↓↓↓ KASHIYAMA Mode 20190624 Kimura update ↓↓↓
                if (Properties.Settings.Default.PASSWORD_KASHIYAMA == false)
                {
                    lbl_in[i].Text = UserText.IoMonitorGetInputName(i, in_config & 0x7F);
                }
                //↑↑↑ KASHIYAMA Mode 20190624 Kimura update ↑↑↑

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
				if (i < MaxOutput)
				{
					int out_config = CMonitor.GetParameter(CParamID.OutputConfig1 + i);

                    //↓↓↓ KASHIYAMA Mode 20190624 Kimura update ↓↓↓
                    if (Properties.Settings.Default.PASSWORD_KASHIYAMA == false)
                    {
                        lbl_out[i].Text = UserText.IoMonitorGetOutputName(i, out_config);
                    }
                    //↑↑↑ KASHIYAMA Mode 20190624 Kimura update ↑↑↑

					if ((output & b) == b)
					{
						pic_out[i].BackColor = Color.Red;
					}
					else
					{
						pic_out[i].BackColor = Color.Black;
					}
				}
				else
				{
					lbl_out[i].Text = UserText.CtlJogControlReserve;
				}
			}
		}

		private void InitIoLabel()
		{
			Label[] lbl_in = new Label[8];
			Label[] lbl_out = new Label[8];

			lbl_in[0] = lblIn1;
			lbl_in[1] = lblIn2;
			lbl_in[2] = lblIn3;
			lbl_in[3] = lblIn4;
			lbl_in[4] = lblIn5;
			lbl_in[5] = lblIn6;
			lbl_in[6] = lblIn7;
			lbl_in[7] = lblIn8;

			lbl_out[0] = lblOut1;
			lbl_out[1] = lblOut2;
			lbl_out[2] = lblOut3;
			lbl_out[3] = lblOut4;
			lbl_out[4] = lblOut5;
			lbl_out[5] = lblOut6;
			lbl_out[6] = lblOut7;
			lbl_out[7] = lblOut8;

			for (int i = 0; i < lbl_in.Length; i++)
			{
				if (i < MaxInput)
				{
					lbl_in[i].Text = UserText.IoMonitorGetInputName(i, 0);
				}
				else
				{
					lbl_in[i].Text = UserText.CtlJogControlReserve;
				}
			}

			for (int i = 0; i < lbl_out.Length; i++)
			{
				if (i < MaxOutput)
				{
					lbl_out[i].Text = UserText.IoMonitorGetOutputName(i, 0);
				}
				else
				{
					lbl_out[i].Text = UserText.CtlJogControlReserve;
				}
			}
		}

		private void IoMonitorForm_Load(object sender, EventArgs e)
		{
			if (FormPosition.X > 0)
			{
				this.Size = FormSize;
				this.Location = FormPosition;
			}

			InitIoLabel();
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(IoMonitorForm));

            this.Font = (Font)resources.GetObject("$this.Font");
            grpIn.Font = (Font)resources.GetObject("grpIn.Font");
            grpOut.Font = (Font)resources.GetObject("grpOut.Font");

            this.Text = resources.GetString("$this.Text");
            grpIn.Text = resources.GetString("grpIn.Text");
            grpOut.Text = resources.GetString("grpOut.Text"); 
        }

        //↑↑↑ ART HIKARI Mode 20181210 Kimura add ↑↑↑

        #endregion
	
	}
}