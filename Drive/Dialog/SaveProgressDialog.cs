using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Motion_Designer
{
	public partial class SaveProgressDialog : Form
	{
		private const int TIME_OUT = 60;

		public enum SaveItem{  Parameter, Program, Text, Table, Servo };

		public SaveProgressDialog()
		{
			InitializeComponent();
		}

		public SaveProgressDialog(string msg)
		{
			InitializeComponent();

			lblSave.Text = msg;
		}

		private void SaveForm_Load(object sender, EventArgs e)
		{
			ChildFormControl.SetOpacity(0.0);
		}

		private void SaveForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			ChildFormControl.SetOpacity(1.0);
		}

		public void CloseForm()
		{
			this.Close();
		}

		public void SetMessage(string msg)
		{
			lblSave.Text = msg;
		}

		public void StartFlashMemorySave(Point p, Size w, int sec)
		{
			StartMarquee(p, w, sec, UserText.SaveFlashMemory);

			UserMessageBox.SaveFlashMemoryFinish();
		}

		public void StartImageSave(Point p, Size w, int sec)
		{
			StartMarquee(p, w, sec, UserText.SaveImageData);

			UserMessageBox.SaveImageFinish();
		}

		public void StartFrictionCompensation(Point p, Size w, int sec)
		{
			StartMarquee(p, w, sec, UserText.SaveFriction);

			//UserMessageBox.SaveFrictionFinish();
		}

		public void StartMarquee(Point p, Size w, int sec, string msg)
		{
			int wid;
			int hei;

			wid = w.Width / 2;
			hei = w.Height / 2;
			p.X = p.X + wid - this.Width / 2;
			p.Y = p.Y + hei - this.Height / 2;
	
			this.Location = p;

			this.Cursor = Cursors.WaitCursor;

			int old = DateTime.Now.Second;
			int now = new int();
			double op = 1.0;
			bool updown = false;

			this.lblSave.Text = msg;
			this.Show();
			this.Refresh();

			while (true)
			{
				now = DateTime.Now.Second;

				Thread.Sleep(100);
				this.Opacity = op;
				this.Refresh();

				if (updown == true)
				{
					op = op + 0.05;
				}
				else
				{
					op = op - 0.05;
				}

				if (op < 0.5)
				{
					updown = true;
				}
				if (op >= 1.0)
				{
					updown = false;
				}

				if (now < old)
				{
					now += 60;
				}

				if (now - old > sec)
				{
					//タイムアウト
					break;
				}
			}

			this.Cursor = Cursors.Default;
			this.Visible = false;

		}

	}
}