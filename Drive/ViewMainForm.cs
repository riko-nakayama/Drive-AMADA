using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
	public partial class ViewMainForm : Form
	{
		static private ViewMainForm _ThisForm = new ViewMainForm();

		static private bool _IsForceShutDown = new bool();

		public enum WindowLayout
		{
			Free, OsilloParam, OsilloGain, OsilloFFT, FFTGain, Param, Gain, Osillo, FFT
		}

		private WindowLayout NowLayout = WindowLayout.Free;

		private int ResizeWidth = new int();
		private int ResizeHeight = new int();

		private MdiClient ThisMdiClient;

		private FormWindowState NowWindowState = FormWindowState.Normal;

		public ViewMainForm()
		{
			InitializeComponent();

			_ThisForm = this;

			ThisMdiClient = this.GetMdiClient();
		}

		static public ViewMainForm ThisForm
		{
			get { return _ThisForm; }
		}

		public MdiClient GetMdiClient()
		{
			foreach (System.Windows.Forms.Control c in this.Controls)
			{
				if (c is System.Windows.Forms.MdiClient)
				{
					return (System.Windows.Forms.MdiClient)c;
				}
			}

			return null;
		}

		public WindowLayout ViewLayout
		{
			set
			{
				switch (value)
				{
					case WindowLayout.Free:

						lblFree.PerformClick();
						break;

					case WindowLayout.OsilloParam:

						lblOsilloParam.PerformClick();
						break;

					case WindowLayout.OsilloGain:

						lblOsilloGain.PerformClick();
						break;

					case WindowLayout.OsilloFFT:

						lblOsilloFFT.PerformClick();
						break;

					case WindowLayout.FFTGain:

						lblFFTGain.PerformClick();
						break;

					case WindowLayout.Param:

						lblParam.PerformClick();
						break;

					case WindowLayout.Gain:

						lblGain.PerformClick();
						break;

					case WindowLayout.Osillo:

						lblOsillo.PerformClick();
						break;

					case WindowLayout.FFT:

						lblFFT.PerformClick();
						break;
				}
			}

			get
			{
				return NowLayout;
			}
		}

		public void ShowPrmGain()
		{
			tbtnParameter.PerformClick();
			tbtnServoGain.PerformClick();
		}

		public void ShowWaveBode()
		{
			tbtnBodeGraph.PerformClick();
			tbtnDigitalOsillo.PerformClick();
		}

		public bool VisibleWorkspaceLog
		{
			set { pnlMain.Visible = value; }
			get { return pnlMain.Visible; }
		}

		public bool VisibleServoMonitor
		{
			set
			{
				if (value)
				{
					lblServoStatus.BackColor = Color.LightGreen;
				}
				else
				{
					lblServoStatus.BackColor = SystemColors.Control;
				}
			}
		}

		public bool VisibleIoMonitor
		{
			set
			{
				if (value)
				{
					lblIoStatus.BackColor = Color.LightGreen;
				}
				else
				{
					lblIoStatus.BackColor = SystemColors.Control;
				}
			}
		}

		static public bool IsForceShutDown
		{
			set { _IsForceShutDown = value; }
			get { return _IsForceShutDown; }
		}

        // ↓↓↓ Ver1.33 add AMADA Inspection
        public bool ViewMainFormEnabled
        {
            set
            {
                tbtnParameter.Enabled = value;
                tbtnServoGain.Enabled = value;
                tbtnBodeGraph.Enabled = value;
                ToolStripMenuItemLayout.Enabled = value;
                lblOsilloParam.Enabled = value;
                lblOsilloGain.Enabled = value;
                lblOsilloFFT.Enabled = value;
                lblFFTGain.Enabled = value;
                lblParam.Enabled = value;
                lblGain.Enabled = value;
                lblFFT.Enabled = value;
            }
        }

		// nakayama add amada
		public void ViewDigitalOsilloForm()
		{
			tbtnDigitalOsillo.PerformClick();

			DigitalOsilloForm.ThisForm.ViewSettingInspection();
		}

		// ↑↑↑ Ver1.33 add AMADA Inspection

		#region Form Event

		// TAD8821 Mode 20220921 Kimura add 
		private void ViewMainForm_Load(object sender, EventArgs e)
		{
            if (Properties.Settings.Default.PASSWORD_TAD8821)
            {
                tbtnDigitalOsillo.Enabled = false;
                tbtnBodeGraph.Enabled = false;
                lblOsilloParam.Enabled = false;
                lblOsilloGain.Enabled = false;
                lblOsilloFFT.Enabled = false;
                lblFFTGain.Enabled = false;
                lblOsillo.Enabled = false;
                lblFFT.Enabled = false;
            }
		}
        // TAD8821 Mode 20220921 Kimura add 

		private void ViewMainForm_Shown(object sender, EventArgs e)
		{
			//tbtnParameter.PerformClick();
			//tbtnServoGain.PerformClick();
			//tbtnBodeGraph.PerformClick();
			//tbtnDigitalOsillo.PerformClick();

			//↓↓↓ ART HIKARI Mode 20170919 Kimura add ↓↓↓
			if (Properties.Settings.Default.PASSWORD_HIKARI)
			{
				ToolStripMenuItemServoGain.Visible = false;
				tbtnServoGain.Visible = false;
				lblOsilloGain.Visible = false;
				lblFFTGain.Visible = false;
				lblGain.Visible = false;
				lblServoStatus.Visible = false;
				lblIoStatus.Visible = false;
			}
			//↑↑↑ ART HIKARI Mode 20170919 Kimura add ↑↑↑
		}

		private void ViewMainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (AutoTuningForm.ThisForm != null)
			{
				if (AutoTuningForm.ThisForm.IsTuning)
				{
					DialogResult ret = UserMessageBox.AutoTuningExecAutoTuning();

					if (ret == DialogResult.Yes)
					{
						AutoTuningForm.ThisForm.StopAutoTuning();
					}
					else
					{
						e.Cancel = true;
						return;
					}
				}
			}

			if (!IsForceShutDown)
			{
				this.Opacity = 0.0;
				MainForm.ThisForm.Opacity = 0.0;

				ChildFormControl.SetOpacity(0.0);

				if (Properties.Settings.Default.CLOSE_MSG_DISABLE == false)
				{
					//DialogResult ret = UserMessageBox.ViewMainDriveClose();

					DriveCloseDialog f = new DriveCloseDialog();

					DialogResult ret = f.ShowDialog();

					if (ret == DialogResult.Cancel)
					{
						e.Cancel = true;

						this.Opacity = 1.0;
						MainForm.ThisForm.Opacity = 1.0;

						ChildFormControl.SetOpacity(1.0);

						return;
					}
				}


				MainForm.ThisForm.ViewFormClose();

				MainForm.IsForceShutDown = true;
				MainForm.ThisForm.Close();
			}
			else
			{
				IsForceShutDown = false;

				MainForm.ThisForm.ViewFormClose();
			}
		}

		private void ViewMainForm_ResizeEnd(object sender, EventArgs e)
		{
			ResizeWidth = ThisMdiClient.ClientRectangle.Width;
			ResizeHeight = ThisMdiClient.ClientRectangle.Height;

			switch (NowLayout)
			{
				case WindowLayout.Free:

					break;

				case WindowLayout.OsilloParam:

					lblOsilloParam.PerformClick();
					break;

				case WindowLayout.OsilloGain:

					lblOsilloGain.PerformClick();
					break;

				case WindowLayout.OsilloFFT:

					lblOsilloFFT.PerformClick();
					break;

				case WindowLayout.FFTGain:

					lblFFTGain.PerformClick();
					break;

				case WindowLayout.Param:

					lblParam.PerformClick();
					break;

				case WindowLayout.Gain:

					lblGain.PerformClick();
					break;

				case WindowLayout.Osillo:

					lblOsillo.PerformClick();
					break;

				case WindowLayout.FFT:

					lblFFT.PerformClick();
					break;

			}

			TimerResize.Enabled = true;
		}

		private void ViewMainForm_SizeChanged(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Maximized)
			{
				NowWindowState = FormWindowState.Maximized;

				ViewMainForm_ResizeEnd(null, null);
			}
			else
			{
				if (NowWindowState == FormWindowState.Maximized)
				{
					NowWindowState = FormWindowState.Normal;

					ViewMainForm_ResizeEnd(null, null);
				}
			}
		}

		public void ForceResizeEvent()
		{
			ViewMainForm_ResizeEnd(null, null);
		}

		#endregion

		#region Button Event

		private void tbtnParameter_Click(object sender, EventArgs e)
		{
			if (ParameterForm.ThisForm != null)
			{
				if (ParameterForm.ThisForm.WindowState != FormWindowState.Minimized)
				{
					BackupParamRowIndex = ParameterForm.ThisForm.FirstDisplayRowIndex;
				}
			}

			MainForm.ThisForm.LoadParameterForm();

			int w = ThisMdiClient.ClientRectangle.Width;
			int h = ThisMdiClient.ClientRectangle.Height;

			ParameterForm.ThisForm.WindowState = FormWindowState.Normal;
			ParameterForm.ThisForm.Location = new Point(0, 0);
			ParameterForm.ThisForm.Size = new Size(w, h);

			ParameterForm.ThisForm.FormBorderStyle = FormBorderStyle.Sizable;
			ParameterForm.ThisForm.MaximizeBox = true;
			ParameterForm.ThisForm.MinimizeBox = true;

			ParameterForm.ThisForm.FirstDisplayRowIndex = BackupParamRowIndex;

			SetWindowLayoutLabel(WindowLayout.Free);
		}

		private void tbtnServoGain_Click(object sender, EventArgs e)
		{
			if (ParameterForm.ThisForm != null)
			{
				if (ParameterForm.ThisForm.WindowState != FormWindowState.Minimized)
				{
					BackupParamRowIndex = ParameterForm.ThisForm.FirstDisplayRowIndex;
				}
			}

			MainForm.ThisForm.LoadGainControl();

			int w = ThisMdiClient.ClientRectangle.Width;
			int h = ThisMdiClient.ClientRectangle.Height;

			GainControlForm.ThisForm.WindowState = FormWindowState.Normal;
			GainControlForm.ThisForm.Location = new Point(0, 0);
			GainControlForm.ThisForm.Size = new Size(w, h);

			GainControlForm.ThisForm.FormBorderStyle = FormBorderStyle.Sizable;
			GainControlForm.ThisForm.MaximizeBox = true;
			GainControlForm.ThisForm.MinimizeBox = true;

			SetWindowLayoutLabel(WindowLayout.Free);

			GainControlForm.ThisForm.Activate();		//20161102 add
		}

		private void tbtnDigitalOsillo_Click(object sender, EventArgs e)
		{
			if (ParameterForm.ThisForm != null)
			{
				if (ParameterForm.ThisForm.WindowState != FormWindowState.Minimized)
				{
					BackupParamRowIndex = ParameterForm.ThisForm.FirstDisplayRowIndex;
				}
			}

			MainForm.ThisForm.LoadDigitalOsillo();

			int w = ThisMdiClient.ClientRectangle.Width;
			int h = ThisMdiClient.ClientRectangle.Height;

			DigitalOsilloForm.ThisForm.WindowState = FormWindowState.Normal;
			DigitalOsilloForm.ThisForm.Location = new Point(0, 0);
			DigitalOsilloForm.ThisForm.Size = new Size(w, h);

			DigitalOsilloForm.ThisForm.FormBorderStyle = FormBorderStyle.Sizable;
			DigitalOsilloForm.ThisForm.MaximizeBox = true;
			DigitalOsilloForm.ThisForm.MinimizeBox = true;

			SetWindowLayoutLabel(WindowLayout.Free);
		}

		private void tbtnBodeGraph_Click(object sender, EventArgs e)
		{
			if (ParameterForm.ThisForm != null)
			{
				if (ParameterForm.ThisForm.WindowState != FormWindowState.Minimized)
				{
					BackupParamRowIndex = ParameterForm.ThisForm.FirstDisplayRowIndex;
				}
			}

			MainForm.ThisForm.LoadBodeGraph();

			int w = ThisMdiClient.ClientRectangle.Width;
			int h = ThisMdiClient.ClientRectangle.Height;

			BodeGraphForm.ThisForm.WindowState = FormWindowState.Normal;
			BodeGraphForm.ThisForm.Location = new Point(0, 0);
			BodeGraphForm.ThisForm.Size = new Size(w, h);

			BodeGraphForm.ThisForm.FormBorderStyle = FormBorderStyle.Sizable;
			BodeGraphForm.ThisForm.MaximizeBox = true;
			BodeGraphForm.ThisForm.MinimizeBox = true;

			SetWindowLayoutLabel(WindowLayout.Free);
		}

		#endregion

		#region Winodw Layout

		private int BackupParamRowIndex = new int();

		private void tbtnHorizontal_Click(object sender, EventArgs e)
		{
			this.LayoutMdi(MdiLayout.TileHorizontal);
		}

		private void tbtnVertical_Click(object sender, EventArgs e)
		{
			this.LayoutMdi(MdiLayout.TileVertical);
		}

		private void tbtnCascade_Click(object sender, EventArgs e)
		{
			this.LayoutMdi(MdiLayout.Cascade);
		}

		private void lblFree_Click(object sender, EventArgs e)
		{
			SetWindowLayoutLabel(WindowLayout.Free);
		}

		private void lblOsilloParam_Click(object sender, EventArgs e)
		{
			bool ReDraw = new bool();

			if (NowLayout == WindowLayout.Free)
			{
				ReDraw = true;
			}

			if (DigitalOsilloForm.ThisForm.Visible == false)
			{
				MainForm.ThisForm.LoadDigitalOsillo();
			}

			if (ParameterForm.ThisForm.Visible == false)
			{
				MainForm.ThisForm.LoadParameterForm();
			}
			else
			{
				if (ParameterForm.ThisForm.WindowState != FormWindowState.Minimized)
				{
					BackupParamRowIndex = ParameterForm.ThisForm.FirstDisplayRowIndex;
				}
			}

			BodeGraphForm.ThisForm.WindowState = FormWindowState.Minimized;
			GainControlForm.ThisForm.WindowState = FormWindowState.Minimized;

			int w = ThisMdiClient.ClientRectangle.Width;
			int h = ThisMdiClient.ClientRectangle.Height;

			ResizeWidth = w;
			ResizeHeight = h;

			TimerResize.Enabled = true;

			DigitalOsilloForm.ThisForm.WindowState = FormWindowState.Normal;
			DigitalOsilloForm.ThisForm.FormBorderStyle = FormBorderStyle.Sizable;
			DigitalOsilloForm.ThisForm.MaximizeBox = false;
			DigitalOsilloForm.ThisForm.MinimizeBox = false;
			DigitalOsilloForm.ThisForm.Location = new Point(0, 0);
			DigitalOsilloForm.ThisForm.Size = new Size(w, h / 2);

			ParameterForm.ThisForm.WindowState = FormWindowState.Normal;
			ParameterForm.ThisForm.FormBorderStyle = FormBorderStyle.Sizable;
			ParameterForm.ThisForm.MaximizeBox = false;
			ParameterForm.ThisForm.MinimizeBox = false;
			ParameterForm.ThisForm.Location = new Point(0, h / 2);
			ParameterForm.ThisForm.Size = new Size(w, h / 2);

			ParameterForm.ThisForm.FirstDisplayRowIndex = BackupParamRowIndex;
		
			SetWindowLayoutLabel(WindowLayout.OsilloParam);

			if (ReDraw)
			{
				ThisMdiClient.LayoutMdi(MdiLayout.Cascade);
				lblOsilloParam.PerformClick();
			}

		}

		private void lblOsilloGain_Click(object sender, EventArgs e)
		{
			bool ReDraw = new bool();

			if (NowLayout == WindowLayout.Free)
			{
				ReDraw = true;
			}

			if (DigitalOsilloForm.ThisForm.Visible == false)
			{
				MainForm.ThisForm.LoadDigitalOsillo();
			}

			if (GainControlForm.ThisForm.Visible == false)
			{
				MainForm.ThisForm.LoadGainControl();
			}

			if (ParameterForm.ThisForm.WindowState != FormWindowState.Minimized)
			{
				BackupParamRowIndex = ParameterForm.ThisForm.FirstDisplayRowIndex;
			}

			BodeGraphForm.ThisForm.WindowState = FormWindowState.Minimized;
			ParameterForm.ThisForm.WindowState = FormWindowState.Minimized;

			int w = ThisMdiClient.ClientRectangle.Width;
			int h = ThisMdiClient.ClientRectangle.Height;

			ResizeWidth = w;
			ResizeHeight = h;

			TimerResize.Enabled = true;

			DigitalOsilloForm.ThisForm.WindowState = FormWindowState.Normal;
			DigitalOsilloForm.ThisForm.FormBorderStyle = FormBorderStyle.Sizable;
			DigitalOsilloForm.ThisForm.MaximizeBox = false;
			DigitalOsilloForm.ThisForm.MinimizeBox = false;
			DigitalOsilloForm.ThisForm.Location = new Point(0, 0);
			DigitalOsilloForm.ThisForm.Size = new Size(w, h / 2);

			GainControlForm.ThisForm.WindowState = FormWindowState.Normal;
			GainControlForm.ThisForm.FormBorderStyle = FormBorderStyle.Sizable;
			GainControlForm.ThisForm.MaximizeBox = false;
			GainControlForm.ThisForm.MinimizeBox = false;
			GainControlForm.ThisForm.Location = new Point(0, h / 2);
			GainControlForm.ThisForm.Size = new Size(w, h / 2);

			SetWindowLayoutLabel(WindowLayout.OsilloGain);

			if (ReDraw)
			{
				ThisMdiClient.LayoutMdi(MdiLayout.Cascade);
				lblOsilloGain.PerformClick();
			}

		}

		private void lblOsilloFFT_Click(object sender, EventArgs e)
		{
			bool ReDraw = new bool();

			if (NowLayout == WindowLayout.Free)
			{
				ReDraw = true;
			}

			if (DigitalOsilloForm.ThisForm.Visible == false)
			{
				MainForm.ThisForm.LoadDigitalOsillo();
			}

			if (BodeGraphForm.ThisForm.Visible == false)
			{
				MainForm.ThisForm.LoadBodeGraph();
			}

			if (ParameterForm.ThisForm.WindowState != FormWindowState.Minimized)
			{
				BackupParamRowIndex = ParameterForm.ThisForm.FirstDisplayRowIndex;
			}

			ParameterForm.ThisForm.WindowState = FormWindowState.Minimized;
			GainControlForm.ThisForm.WindowState = FormWindowState.Minimized;
		
			int w = ThisMdiClient.ClientRectangle.Width;
			int h = ThisMdiClient.ClientRectangle.Height;

			ResizeWidth = w;
			ResizeHeight = h;

			TimerResize.Enabled = true;

			DigitalOsilloForm.ThisForm.WindowState = FormWindowState.Normal;
			DigitalOsilloForm.ThisForm.FormBorderStyle = FormBorderStyle.Sizable;
			DigitalOsilloForm.ThisForm.MaximizeBox = false;
			DigitalOsilloForm.ThisForm.MinimizeBox = false;
			DigitalOsilloForm.ThisForm.Location = new Point(0, 0);
			DigitalOsilloForm.ThisForm.Size = new Size(w, h / 2);

			BodeGraphForm.ThisForm.WindowState = FormWindowState.Normal;
			BodeGraphForm.ThisForm.FormBorderStyle = FormBorderStyle.Sizable;
			BodeGraphForm.ThisForm.MaximizeBox = false;
			BodeGraphForm.ThisForm.MinimizeBox = false;
			BodeGraphForm.ThisForm.Location = new Point(0, h / 2);
			BodeGraphForm.ThisForm.Size = new Size(w, h / 2);

			SetWindowLayoutLabel(WindowLayout.OsilloFFT);

			if (ReDraw)
			{
				ThisMdiClient.LayoutMdi(MdiLayout.Cascade);
				lblOsilloFFT.PerformClick();
			}
		}

		private void lblFFTGain_Click(object sender, EventArgs e)
		{
			bool ReDraw = new bool();

			if (NowLayout == WindowLayout.Free)
			{
				ReDraw = true;
			}

			if (BodeGraphForm.ThisForm.Visible == false)
			{
				MainForm.ThisForm.LoadBodeGraph();
			}
			
			if (GainControlForm.ThisForm.Visible == false)
			{
				MainForm.ThisForm.LoadGainControl();
			}

			if (ParameterForm.ThisForm.WindowState != FormWindowState.Minimized)
			{
				BackupParamRowIndex = ParameterForm.ThisForm.FirstDisplayRowIndex;
			}

			DigitalOsilloForm.ThisForm.WindowState = FormWindowState.Minimized;
			ParameterForm.ThisForm.WindowState = FormWindowState.Minimized;

			int w = ThisMdiClient.ClientRectangle.Width;
			int h = ThisMdiClient.ClientRectangle.Height;

			ResizeWidth = w;
			ResizeHeight = h;

			TimerResize.Enabled = true;

			BodeGraphForm.ThisForm.WindowState = FormWindowState.Normal;
			BodeGraphForm.ThisForm.FormBorderStyle = FormBorderStyle.Sizable;
			BodeGraphForm.ThisForm.MaximizeBox = false;
			BodeGraphForm.ThisForm.MinimizeBox = false;
			BodeGraphForm.ThisForm.Location = new Point(0, 0);
			BodeGraphForm.ThisForm.Size = new Size(w, h / 2);

			GainControlForm.ThisForm.WindowState = FormWindowState.Normal;
			GainControlForm.ThisForm.FormBorderStyle = FormBorderStyle.Sizable;
			GainControlForm.ThisForm.MaximizeBox = false;
			GainControlForm.ThisForm.MinimizeBox = false;
			GainControlForm.ThisForm.Location = new Point(0, h / 2);
			GainControlForm.ThisForm.Size = new Size(w, h / 2);

			SetWindowLayoutLabel(WindowLayout.FFTGain);

			if (ReDraw)
			{
				ThisMdiClient.LayoutMdi(MdiLayout.Cascade);
				lblFFTGain.PerformClick();
			}
		}

		private void lblParam_Click(object sender, EventArgs e)
		{
			bool ReDraw = new bool();

			if (NowLayout == WindowLayout.Free)
			{
				ReDraw = true;
			}

			if (ParameterForm.ThisForm.Visible == false)
			{
				MainForm.ThisForm.LoadParameterForm();
			}
			else
			{
				if (ParameterForm.ThisForm.WindowState != FormWindowState.Minimized)
				{
					BackupParamRowIndex = ParameterForm.ThisForm.FirstDisplayRowIndex;
				}
			}

			GainControlForm.ThisForm.WindowState = FormWindowState.Minimized;
			DigitalOsilloForm.ThisForm.WindowState = FormWindowState.Minimized;
			BodeGraphForm.ThisForm.WindowState = FormWindowState.Minimized;
		
			int w = ThisMdiClient.ClientRectangle.Width;
			int h = ThisMdiClient.ClientRectangle.Height;

			ResizeWidth = w;
			ResizeHeight = h;

			TimerResize.Enabled = true;

			ParameterForm.ThisForm.WindowState = FormWindowState.Normal;
			ParameterForm.ThisForm.FormBorderStyle = FormBorderStyle.Sizable;
			ParameterForm.ThisForm.MaximizeBox = false;
			ParameterForm.ThisForm.MinimizeBox = false;
			ParameterForm.ThisForm.Location = new Point(0, 0);
			ParameterForm.ThisForm.Size = new Size(w, h);

			ParameterForm.ThisForm.FirstDisplayRowIndex = BackupParamRowIndex;

			SetWindowLayoutLabel(WindowLayout.Param);

			if (ReDraw)
			{
				ThisMdiClient.LayoutMdi(MdiLayout.Cascade);
				lblParam.PerformClick();
			}
		}

		private void lblGain_Click(object sender, EventArgs e)
		{
			bool ReDraw = new bool();

			if (NowLayout == WindowLayout.Free)
			{
				ReDraw = true;
			}

			if (GainControlForm.ThisForm.Visible == false)
			{
				MainForm.ThisForm.LoadGainControl();
			}

			if (ParameterForm.ThisForm.WindowState != FormWindowState.Minimized)
			{
				BackupParamRowIndex = ParameterForm.ThisForm.FirstDisplayRowIndex;
			}

			ParameterForm.ThisForm.WindowState = FormWindowState.Minimized;
			DigitalOsilloForm.ThisForm.WindowState = FormWindowState.Minimized;
			BodeGraphForm.ThisForm.WindowState = FormWindowState.Minimized;
		
			int w = ThisMdiClient.ClientRectangle.Width;
			int h = ThisMdiClient.ClientRectangle.Height;

			ResizeWidth = w;
			ResizeHeight = h;

			TimerResize.Enabled = true;

			GainControlForm.ThisForm.WindowState = FormWindowState.Normal;
			GainControlForm.ThisForm.FormBorderStyle = FormBorderStyle.Sizable;
			GainControlForm.ThisForm.MaximizeBox = false;
			GainControlForm.ThisForm.MinimizeBox = false;
			GainControlForm.ThisForm.Location = new Point(0, 0);
			GainControlForm.ThisForm.Size = new Size(w, h);

			SetWindowLayoutLabel(WindowLayout.Gain);

			if (ReDraw)
			{
				ThisMdiClient.LayoutMdi(MdiLayout.Cascade);
				lblGain.PerformClick();
			}

		}

		private void lblOsillo_Click(object sender, EventArgs e)
		{
			bool ReDraw = new bool();

			if (NowLayout == WindowLayout.Free)
			{
				ReDraw = true;
			}
	
			if (DigitalOsilloForm.ThisForm.Visible == false)
			{
				MainForm.ThisForm.LoadDigitalOsillo();
			}

			if (ParameterForm.ThisForm.WindowState != FormWindowState.Minimized)
			{
				BackupParamRowIndex = ParameterForm.ThisForm.FirstDisplayRowIndex;
			}

			ParameterForm.ThisForm.WindowState = FormWindowState.Minimized;
			GainControlForm.ThisForm.WindowState = FormWindowState.Minimized;
			BodeGraphForm.ThisForm.WindowState = FormWindowState.Minimized;

			int w = ThisMdiClient.ClientRectangle.Width;
			int h = ThisMdiClient.ClientRectangle.Height;

			ResizeWidth = w;
			ResizeHeight = h;

			TimerResize.Enabled = true;

			DigitalOsilloForm.ThisForm.WindowState = FormWindowState.Normal;
			DigitalOsilloForm.ThisForm.FormBorderStyle = FormBorderStyle.Sizable;
			DigitalOsilloForm.ThisForm.MaximizeBox = false;
			DigitalOsilloForm.ThisForm.MinimizeBox = false;
			DigitalOsilloForm.ThisForm.Location = new Point(0, 0);
			DigitalOsilloForm.ThisForm.Size = new Size(w, h);

			SetWindowLayoutLabel(WindowLayout.Osillo);

			if (ReDraw)
			{
				ThisMdiClient.LayoutMdi(MdiLayout.Cascade);
				lblOsillo.PerformClick();
			}
		}

		private void lblFFT_Click(object sender, EventArgs e)
		{
			bool ReDraw = new bool();

			if (NowLayout == WindowLayout.Free)
			{
				ReDraw = true;
			}

			if (BodeGraphForm.ThisForm.Visible == false)
			{
				MainForm.ThisForm.LoadBodeGraph();
			}

			if (ParameterForm.ThisForm.WindowState != FormWindowState.Minimized)
			{
				BackupParamRowIndex = ParameterForm.ThisForm.FirstDisplayRowIndex;
			}

			ParameterForm.ThisForm.WindowState = FormWindowState.Minimized;
			GainControlForm.ThisForm.WindowState = FormWindowState.Minimized;
			DigitalOsilloForm.ThisForm.WindowState = FormWindowState.Minimized;

			int w = ThisMdiClient.ClientRectangle.Width;
			int h = ThisMdiClient.ClientRectangle.Height;

			ResizeWidth = w;
			ResizeHeight = h;

			TimerResize.Enabled = true;

			BodeGraphForm.ThisForm.WindowState = FormWindowState.Normal;
			BodeGraphForm.ThisForm.FormBorderStyle = FormBorderStyle.Sizable;
			BodeGraphForm.ThisForm.MaximizeBox = false;
			BodeGraphForm.ThisForm.MinimizeBox = false;
			BodeGraphForm.ThisForm.Location = new Point(0, 0);
			BodeGraphForm.ThisForm.Size = new Size(w, h);

			SetWindowLayoutLabel(WindowLayout.FFT);

			if (ReDraw)
			{
				ThisMdiClient.LayoutMdi(MdiLayout.Cascade);
				lblFFT.PerformClick();
			}
		}

		private void lblWorkspaceInit_Click(object sender, EventArgs e)
		{
			MainForm.ThisForm.InitWorkSapce(MainForm.ThisForm);
		}

		private void lblServoStatus_Click(object sender, EventArgs e)
		{
			MainForm.ThisForm.ViewServoMonitor();
		}

		private void lblIoStatus_Click(object sender, EventArgs e)
		{
			MainForm.ThisForm.ViewIoMonitor();
		}

		private void SetWindowLayoutLabel(WindowLayout w)
		{
			NowLayout = w;

			lblFree.BackColor = SystemColors.Control;
			lblOsilloParam.BackColor = SystemColors.Control;
			lblOsilloGain.BackColor = SystemColors.Control;
			lblOsilloFFT.BackColor = SystemColors.Control;
			lblFFTGain.BackColor = SystemColors.Control;
			lblParam.BackColor = SystemColors.Control;
			lblGain.BackColor = SystemColors.Control;
			lblOsillo.BackColor = SystemColors.Control;
			lblFFT.BackColor = SystemColors.Control;

			tbtnHorizontal.Enabled = false;
			tbtnVertical.Enabled = false;
			tbtnCascade.Enabled = false;

			ToolStripMenuItemHorizontal.Enabled = false;
			ToolStripMenuItemVertical.Enabled = false;
			ToolStripMenuItemCascade.Enabled = false;

			switch (w)
			{
				case WindowLayout.Free:

					tbtnHorizontal.Enabled = true;
					tbtnVertical.Enabled = true;
					tbtnCascade.Enabled = true;

					ToolStripMenuItemHorizontal.Enabled = true;
					ToolStripMenuItemVertical.Enabled = true;
					ToolStripMenuItemCascade.Enabled = true;

					lblFree.BackColor = Color.Gold;

					if (DigitalOsilloForm.ThisForm != null)
					{
						DigitalOsilloForm.ThisForm.FormBorderStyle = FormBorderStyle.Sizable;
						DigitalOsilloForm.ThisForm.MaximizeBox = true;
						DigitalOsilloForm.ThisForm.MinimizeBox = true;
					}

					if (BodeGraphForm.ThisForm != null)
					{
						BodeGraphForm.ThisForm.FormBorderStyle = FormBorderStyle.Sizable;
						BodeGraphForm.ThisForm.MaximizeBox = true;
						BodeGraphForm.ThisForm.MinimizeBox = true;
					}

					if (ParameterForm.ThisForm != null)
					{
						ParameterForm.ThisForm.FormBorderStyle = FormBorderStyle.Sizable;
						ParameterForm.ThisForm.MaximizeBox = true;
						ParameterForm.ThisForm.MinimizeBox = true;
					}

					if (GainControlForm.ThisForm != null)
					{
						GainControlForm.ThisForm.FormBorderStyle = FormBorderStyle.Sizable;
						GainControlForm.ThisForm.MaximizeBox = true;
						GainControlForm.ThisForm.MinimizeBox = true;
					}

					break;

				case WindowLayout.OsilloParam:

					lblOsilloParam.BackColor = Color.Gold;
					break;

				case WindowLayout.OsilloGain:

					lblOsilloGain.BackColor = Color.Gold;
					break;

				case WindowLayout.OsilloFFT:

					lblOsilloFFT.BackColor = Color.Gold;
					break;

				case WindowLayout.FFTGain:

					lblFFTGain.BackColor = Color.Gold;
					break;

				case WindowLayout.Param:

					lblParam.BackColor = Color.Gold;
					break;

				case WindowLayout.Gain:

					lblGain.BackColor = Color.Gold;
					break;

				case WindowLayout.Osillo:

					lblOsillo.BackColor = Color.Gold;
					break;

				case WindowLayout.FFT:

					lblFFT.BackColor = Color.Gold;
					break;
			}
		}

		#endregion

		#region Timer Event

		private void TimerResize_Tick(object sender, EventArgs e)
		{
			int w = ThisMdiClient.ClientRectangle.Width;
			int h = ThisMdiClient.ClientRectangle.Height;

			if (ResizeWidth != w || ResizeHeight != h)
			{
				switch (NowLayout)
				{
					case WindowLayout.Free:

						break;

					case WindowLayout.OsilloParam:

						lblOsilloParam.PerformClick();
						break;

					case WindowLayout.OsilloGain:

						lblOsilloGain.PerformClick();
						break;

					case WindowLayout.OsilloFFT:

						lblOsilloFFT.PerformClick();
						break;

					case WindowLayout.FFTGain:

						lblFFTGain.PerformClick();
						break;

					case WindowLayout.Param:

						lblParam.PerformClick();
						break;

					case WindowLayout.Gain:

						lblGain.PerformClick();
						break;

					case WindowLayout.Osillo:

						lblOsillo.PerformClick();
						break;

					case WindowLayout.FFT:

						lblFFT.PerformClick();
						break;

				}
			}

			TimerResize.Enabled = false;
		}

		#endregion

		private void ToolStripMenuItemInitLayout_Click(object sender, EventArgs e)
		{
			MainForm.ThisForm.InitWorkSapce(this);
		}

		private void ToolStripMenuItemLayout_DropDownOpening(object sender, EventArgs e)
		{
			ToolStripMenuItemFree.Checked = false;
			ToolStripMenuItemParameter.Checked = false;
			ToolStripMenuItemServoGain.Checked = false;
			ToolStripMenuItemAutoTuning.Checked = false;
			ToolStripMenuItemFFTGain.Checked = false;

			switch (NowLayout)
			{
				case WindowLayout.Free:

					ToolStripMenuItemFree.Checked = true;
					break;

				case WindowLayout.OsilloParam:

					ToolStripMenuItemParameter.Checked = true;
					break;

				case WindowLayout.OsilloGain:

					ToolStripMenuItemServoGain.Checked = true;
					break;

				case WindowLayout.OsilloFFT:

					ToolStripMenuItemAutoTuning.Checked = true;
					break;

				case WindowLayout.FFTGain:

					ToolStripMenuItemFFTGain.Checked = true;
					break;
			}
		}

		private void Control_MouseHover(object sender, EventArgs e)
		{
			this.Select();
		}

		private void Control_MouseEnter(object sender, EventArgs e)
		{
			this.Select();
		}

        #region カルチャリソース切り替え

        public void ViewCultureResouceChanged()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ViewMainForm));

            lblFFT.Font = (Font)resources.GetObject("lblFFT.Font");
            lblFFTGain.Font = (Font)resources.GetObject("lblFFTGain.Font");
            lblFree.Font = (Font)resources.GetObject("lblFree.Font");
            lblGain.Font = (Font)resources.GetObject("lblGain.Font");
            lblOsillo.Font = (Font)resources.GetObject("lblOsillo.Font");
            lblOsilloFFT.Font = (Font)resources.GetObject("lblOsilloFFT.Font");
            lblOsilloGain.Font = (Font)resources.GetObject("lblOsilloGain.Font");
            lblOsilloParam.Font = (Font)resources.GetObject("lblOsilloParam.Font");
            lblParam.Font = (Font)resources.GetObject("lblParam.Font");
            tbtnDigitalOsillo.Font = (Font)resources.GetObject("tbtnDigitalOsillo.Font");
            tbtnParameter.Font = (Font)resources.GetObject("tbtnParameter.Font");
            tbtnServoGain.Font = (Font)resources.GetObject("tbtnServoGain.Font");
            tbtnBodeGraph.Font = (Font)resources.GetObject("tbtnBodeGraph.Font");
            ToolStripMenuItemAutoTuning.Font = (Font)resources.GetObject("ToolStripMenuItemAutoTuning.Font");
            ToolStripMenuItemCascade.Font = (Font)resources.GetObject("ToolStripMenuItemCascade.Font");
            ToolStripMenuItemFFTGain.Font = (Font)resources.GetObject("ToolStripMenuItemFFTGain.Font");
            ToolStripMenuItemFree.Font = (Font)resources.GetObject("ToolStripMenuItemFree.Font");
            ToolStripMenuItemHorizontal.Font = (Font)resources.GetObject("ToolStripMenuItemHorizontal.Font");
            ToolStripMenuItemInitLayout.Font = (Font)resources.GetObject("ToolStripMenuItemInitLayout.Font");
            ToolStripMenuItemLayout.Font = (Font)resources.GetObject("ToolStripMenuItemLayout.Font");
            ToolStripMenuItemParameter.Font = (Font)resources.GetObject("ToolStripMenuItemParameter.Font");
            ToolStripMenuItemServoGain.Font = (Font)resources.GetObject("ToolStripMenuItemServoGain.Font");
            ToolStripMenuItemVertical.Font = (Font)resources.GetObject("ToolStripMenuItemVertical.Font");
            ToolStripMenuItemWindow.Font = (Font)resources.GetObject("ToolStripMenuItemWindow.Font");

            lblFFT.Text = resources.GetString("lblFFT.Text");
            lblFFTGain.Text = resources.GetString("lblFFTGain.Text");
            lblFree.Text = resources.GetString("lblFree.Text");
            lblGain.Text = resources.GetString("lblGain.Text");
            lblOsillo.Text = resources.GetString("lblOsillo.Text");
            lblOsilloFFT.Text = resources.GetString("lblOsilloFFT.Text");
            lblOsilloGain.Text = resources.GetString("lblOsilloGain.Text");
            lblOsilloParam.Text = resources.GetString("lblOsilloParam.Text");
            lblParam.Text = resources.GetString("lblParam.Text");
            tbtnDigitalOsillo.Text = resources.GetString("tbtnDigitalOsillo.Text");
            tbtnParameter.Text = resources.GetString("tbtnParameter.Text");
            tbtnServoGain.Text = resources.GetString("tbtnServoGain.Text");
            tbtnServoGain.ToolTipText = resources.GetString("tbtnServoGain.ToolTipText");
            tbtnBodeGraph.Text = resources.GetString("tbtnBodeGraph.Text");
            ToolStripMenuItemAutoTuning.Text = resources.GetString("ToolStripMenuItemAutoTuning.Text");
            ToolStripMenuItemCascade.Text = resources.GetString("ToolStripMenuItemCascade.Text");
            ToolStripMenuItemFFTGain.Text = resources.GetString("ToolStripMenuItemFFTGain.Text");
            ToolStripMenuItemFree.Text = resources.GetString("ToolStripMenuItemFree.Text");
            ToolStripMenuItemHorizontal.Text = resources.GetString("ToolStripMenuItemHorizontal.Text");
            ToolStripMenuItemInitLayout.Text = resources.GetString("ToolStripMenuItemInitLayout.Text");
            ToolStripMenuItemLayout.Text = resources.GetString("ToolStripMenuItemLayout.Text");
            ToolStripMenuItemParameter.Text = resources.GetString("ToolStripMenuItemParameter.Text");
            ToolStripMenuItemServoGain.Text = resources.GetString("ToolStripMenuItemServoGain.Text");
            ToolStripMenuItemVertical.Text = resources.GetString("ToolStripMenuItemVertical.Text");
            ToolStripMenuItemWindow.Text = resources.GetString("ToolStripMenuItemWindow.Text");
	
        }

        #endregion



    }
}