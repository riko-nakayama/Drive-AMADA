using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
	public partial class LineStyleDialog : Form
	{
		private Point _FormPosition = new Point();

		private DashStyle _LineType = new DashStyle();

		private float _LineSize = new float();

		public LineStyleDialog()
		{
			InitializeComponent();
		}

		public Point FormPosition
		{
			set { _FormPosition = value; }
		}

		public DashStyle LineType
		{
			set { _LineType = value; }
			get { return _LineType; }
		}

		public float LineSize
		{
			set { _LineSize = value; }
			get { return _LineSize; }
		}

		public string Title
		{
			set { lblTitle.Text = value; }
		}

		private void LineStyleDialog_Load(object sender, EventArgs e)
		{
			ChildFormControl.SetOpacity(0.0);

			switch (_LineType)
			{
				case DashStyle.Solid:

					cmbLine.SelectedIndex = 0;
					break;

				case DashStyle.Dash:

					cmbLine.SelectedIndex = 1;
					break;

				case DashStyle.DashDot:

					cmbLine.SelectedIndex = 2;
					break;

				case DashStyle.DashDotDot:

					cmbLine.SelectedIndex = 3;
					break;

				case DashStyle.Dot:

					cmbLine.SelectedIndex = 4;
					break;

				default:
					cmbLine.SelectedIndex = 0;
					break;
			}

			if (_LineSize < 0.5)
			{
				cmbSize.SelectedIndex = 0;
			}
			else if (_LineSize == 0.5)
			{
				cmbSize.SelectedIndex = 1;
			}
			else if (_LineSize == 1.0)
			{

				cmbSize.SelectedIndex = 2;
			}
			else if (_LineSize == 1.5)
			{
				cmbSize.SelectedIndex = 3;
			}
			else if (_LineSize == 2.0)
			{
				cmbSize.SelectedIndex = 4;
			}
			else if (_LineSize == 2.5)
			{
				cmbSize.SelectedIndex = 5;
			}
			else if (_LineSize == 3.0)
			{
				cmbSize.SelectedIndex = 6;
			}
			else if (_LineSize == 3.5)
			{
				cmbSize.SelectedIndex = 7;
			}
			else if (_LineSize == 4.0)
			{
				cmbSize.SelectedIndex = 8;
			}
			else if (_LineSize == 4.5)
			{
				cmbSize.SelectedIndex = 9;
			}
			else if (_LineSize == 5.0)
			{
				cmbSize.SelectedIndex = 10;
			}
			else
			{
				cmbSize.SelectedIndex = 2;
			}

            ViewCultureResouceChanged();
		}

		private void LineStyleDialog_FormClosing(object sender, FormClosingEventArgs e)
		{
			ChildFormControl.SetOpacity(1.0);
		}

		private void LineStyleDialog_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		}

		private void cmbLine_SelectedIndexChanged(object sender, EventArgs e)
		{

			switch (cmbLine.SelectedIndex)
			{
				case 0:

					_LineType = DashStyle.Solid;
					break;

				case 1:

					_LineType = DashStyle.Dash;
					break;

				case 2:

					_LineType = DashStyle.DashDot;
					break;

				case 3:

					_LineType = DashStyle.DashDotDot;
					break;

				case 4:

					_LineType = DashStyle.Dot;
					break;

				default:

					_LineType = DashStyle.Solid;
					break;

			}

			pnlDummy.Select();
		}

		private void cmbSize_SelectedIndexChanged(object sender, EventArgs e)
		{

			_LineSize = Convert.ToSingle(cmbSize.Text);

			pnlDummy.Select();

		}

		private void btnGo2_Click(object sender, EventArgs e)
		{
			if (cmbSize.SelectedIndex < cmbSize.Items.Count - 1)
			{
				cmbSize.SelectedIndex++;
			}
			else
			{
				cmbSize.SelectedIndex = 0;
			}
		}

		private void btnBack2_Click(object sender, EventArgs e)
		{

			if (cmbSize.SelectedIndex > 0)
			{
				cmbSize.SelectedIndex--;
			}
			else
			{
				cmbSize.SelectedIndex = cmbSize.Items.Count - 1;
			}
		}

        #region カルチャリソース切り替え

        public void ViewCultureResouceChanged()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(LineStyleDialog));

            this.Font = (Font)resources.GetObject("$this.Font");
            cmbLine.Font = (Font)resources.GetObject("cmbLine.Font");
            btnCancel.Font = (Font)resources.GetObject("btnCancel.Font");
            btnOk.Font = (Font)resources.GetObject("btnOk.Font");
            label1.Font = (Font)resources.GetObject("label1.Font");
            label2.Font = (Font)resources.GetObject("label2.Font");
            lblTitle.Font = (Font)resources.GetObject("lblTitle.Font");

            cmbLine.Items.Clear();

            cmbLine.Items.AddRange(new object[] {
            resources.GetString("cmbLine.Items"),
            resources.GetString("cmbLine.Items1"),
            resources.GetString("cmbLine.Items2"),
            resources.GetString("cmbLine.Items3"),
            resources.GetString("cmbLine.Items4")});

            this.Text = resources.GetString("$this.Text");
            cmbLine.Text = resources.GetString("cmbLine.Text");
            btnCancel.Text = resources.GetString("btnCancel.Text");
            btnOk.Text = resources.GetString("btnOk.Text");
            label1.Text = resources.GetString("label1.Text");
            label2.Text = resources.GetString("label2.Text");
            //lblTitle.Text = resources.GetString("lblTitle.Text");

            btnCancel.Size = (Size)resources.GetObject("btnCancel.Size");
            btnOk.Size = (Size)resources.GetObject("btnOk.Size");
        }

        #endregion

	}
}