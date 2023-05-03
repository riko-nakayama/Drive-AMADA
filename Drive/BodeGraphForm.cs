using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
	public partial class BodeGraphForm : Form
	{
		static private Point FormPosition = new Point(0, 0);
		static private Size FormSize = new Size(480, 480);

		static private BodeGraphForm _ThisForm;

		private int ResizeHeight = new int();
		private int ResizeWidth = new int();

		private ViewMainForm ThisParentForm;
		private MdiClient ThisMdiClient;

		private bool _IsExist = new bool();
	
		public BodeGraphForm()
		{
			InitializeComponent();

			_ThisForm = this;
			_IsExist = true;

			ThisParentForm = ViewMainForm.ThisForm;
			
			ThisMdiClient = ViewMainForm.ThisForm.GetMdiClient();

		}

		static public BodeGraphForm ThisForm
		{
			get { return _ThisForm; }
		}

		public void InitFormLayout()
		{
			if (ThisForm == null) { return; }

			int w = ThisMdiClient.ClientRectangle.Width;
			int h = ThisMdiClient.ClientRectangle.Height;

			ThisForm.Location = new Point(0, 0);
			ThisForm.Size = new Size(w, h);

			ThisForm.WindowState = FormWindowState.Normal;
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

		public bool IsExist
		{
			set { _IsExist = value; }
			get { return _IsExist; }
		}

		public bool HoldEnabled
		{
			set { ctlBodeGain.HoldEnabled = value; }
			get { return ctlBodeGain.HoldEnabled; }
		}

		public bool IsViewHold
		{
			set { ctlBodeGain.IsViewHold = value; }
			get { return ctlBodeGain.IsViewHold; }
		}

		#region Form Event

		private void BodeViewForm_Load(object sender, EventArgs e)
		{
			this.Location = FormPosition;
			this.Size = FormSize;
                      
            //↓↓↓ KASHIYAMA Mode 20200214 Kimura update ↓↓↓
            ctlBodeGain.VisibleKASHIYAMAMode = Properties.Settings.Default.PASSWORD_KASHIYAMA;
            //↑↑↑ KASHIYAMA Mode 20200214 Kimura update ↑↑↑

            ViewCultureResouceChanged();
		}

		private void BodeViewForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.WindowState != FormWindowState.Minimized)
			{
				FormPosition = this.Location;
				FormSize = this.Size;
			}

			if (e.CloseReason == CloseReason.MdiFormClosing)
			{
		
			}
			else
			{
				_IsExist = false;
			}

            ViewCultureResouceChanged();
		}

		private void BodeGraphForm_Resize(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Maximized)
			{
				this.WindowState = FormWindowState.Normal;
				InitFormLayout();

				ResizeWidth = ThisMdiClient.ClientRectangle.Width;
				ResizeHeight = ThisMdiClient.ClientRectangle.Height;

				TimerResize.Enabled = true;
			}
		}

		private void BodeViewForm_Paint(object sender, PaintEventArgs e)
		{
			ctlBodeGain.Refresh();
		}

		#endregion

		#region Button Event

		private void tbtnViewGain_Click(object sender, EventArgs e)
		{
			if (tbtnViewGain.BackColor == Color.Gold)
			{
				tbtnViewGain.BackColor = SystemColors.Control;
			
				if (tbtnViewPhase.BackColor == SystemColors.Control)
				{
					tbtnViewPhase.PerformClick();
				}
			}
			else
			{
				tbtnViewGain.BackColor = Color.Gold;
			}

			ctlBodeGain.Refresh();
		}

		#endregion

		#region Timer Event

		private void TimerResize_Tick(object sender, EventArgs e)
		{
			int w = ThisMdiClient.ClientRectangle.Width;
			int h = ThisMdiClient.ClientRectangle.Height;

			if (ResizeWidth != w || ResizeHeight != h)
			{
				InitFormLayout();
			}

			TimerResize.Enabled = false;
		}

		#endregion

        #region カルチャリソース切り替え

        public void ViewCultureResouceChanged()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(BodeGraphForm));

            this.Font = (Font)resources.GetObject("$this.Font");
            ctlBodeGain.Font = (Font)resources.GetObject("ctlBodeGain.Font");
            tbtnViewGain.Font = (Font)resources.GetObject("tbtnViewGain.Font");
            tbtnViewPhase.Font = (Font)resources.GetObject("tbtnViewPhase.Font");
            toolStripGraph.Font = (Font)resources.GetObject("toolStripGraph.Font");

            this.Text = resources.GetString("$this.Text");
            ctlBodeGain.Y_Item = resources.GetString("ctlBodeGain.Y_Item");
            tbtnViewGain.Text = resources.GetString("tbtnViewGain.Text");
            tbtnViewPhase.Text = resources.GetString("tbtnViewPhase.Text");
            toolStripGraph.Text = resources.GetString("toolStripGraph.Text");

            ctlBodeGain.ViewCultureResouceChanged();
        }

        #endregion

	}
}