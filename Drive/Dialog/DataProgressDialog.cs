using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Motion_Designer
{
	public partial class DataProgressDialog : Form
	{
		[DllImport("uxtheme.dll")]
		private static extern int SetWindowTheme(IntPtr hwnd, string subAppName, string subIdLis);

		public DataProgressDialog()
		{
			InitializeComponent();
		}

		private void ProgressForm_Load(object sender, EventArgs e)
		{
			ChildFormControl.SetOpacity(0.0);

			OperatingSystem os = Environment.OSVersion;

			if (os.Platform == PlatformID.Win32NT && os.Version.Major >= 6)
			{
				//Windows VISTA à»è„
				SetWindowTheme(ProgressBars.Handle, "", "");
				pnlProgress.BorderStyle = BorderStyle.FixedSingle;
			}

            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DataProgressDialog));
            ProgressBarText.Font = (Font)resources.GetObject("ProgressBarText.Font");
		}

		private void ProgressForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			ChildFormControl.SetOpacity(1.0);
		}

		public string ProgressText
		{
			set { ProgressBarText.Text = value; this.Refresh(); }
		}

		public ProgressBarStyle Style
		{
			set { ProgressBars.Style = value; }
		}

		public int Value
		{
			set { ProgressBars.Value = value; }
			get { return ProgressBars.Value; }
		}

		public int Maximum
		{
			set { ProgressBars.Maximum = value; }
			get { return ProgressBars.Maximum; }
		}

		public void PerformStep()
		{
			ProgressBars.PerformStep();
            this.Refresh();
		}

		public void Start(string text, Point p, Size w, bool tabs)
		{
			this.ProgressText = text;
			this.Visible = true;
			this.SetLocation(p, w, tabs);
			this.Refresh();
			this.Value = 0;
		}

		// Ver1.35 add Å´Å´Å´
		public void Start(string text)
		{
			this.StartPosition = FormStartPosition.CenterScreen;
			this.ProgressText = text;
			this.Visible = true;
			this.Refresh();
			this.Value = 0;
		}
		// Ver1.35 add Å™Å™Å™ 

		public void StartMarquee(string text, Point p, Size w, bool tabs)
		{
			Style = ProgressBarStyle.Marquee;
			this.ProgressText = text;
			this.Visible = true;
			this.SetLocation(p, w, tabs);
			this.Refresh();
			this.Value = 0;

			TimerRefresh.Enabled = true;
		}

		public void SetLocation(Point p, Size w, bool tabs)
		{

			int wid;
			int hei;

			if (tabs)
			{
				if (MainForm.ActiveForm == null)
				{
					wid = w.Width / 2;
					hei = w.Height / 2;
					p.X = p.X + wid - this.Width / 2;
					p.Y = p.Y + hei - this.Height / 2;
				}
				else
				{
					wid = MainForm.ActiveForm.Size.Width / 2;
					hei = MainForm.ActiveForm.Size.Height / 2;
					p.X = MainForm.ActiveForm.Location.X + wid - this.Width / 2;
					p.Y = MainForm.ActiveForm.Location.Y + hei - this.Height / 2;
				}
			}
			else
			{
				wid = w.Width / 2;
				hei = w.Height / 2;
				p.X = p.X + wid - this.Width / 2;
				p.Y = p.Y + hei - this.Height / 2;
			}

			this.Location = p;
		}

		public void SetLocation()
		{
			this.StartPosition = FormStartPosition.CenterScreen;
		}

		private void TimerRefresh_Tick(object sender, EventArgs e)
		{
			this.Refresh();
		}


	}
}