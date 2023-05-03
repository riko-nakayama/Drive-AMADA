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
	public partial class ParameterHelpForm : Form
	{
        
        #region リッチテキスト行間変更用API定義

        const int EM_SETPARAFORMAT = 0x0447;
        const uint PFM_LINESPACING = 0x00000100;

        [StructLayout(LayoutKind.Sequential)]
        public struct PARAFORMAT2
        {
            public uint cbSize;
            public uint dwMask;
            public short wNumbering;
            public short wReserved;
            public int dxStartIndent;
            public int dxRightIndent;
            public int dxOffset;
            public short wAlignment;
            public short cTabCount;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public int[] rgxTabs;
            public int dySpaceBefore;
            public int dySpaceAfter;
            public int dyLineSpacing;
            public short sStyle;
            public byte bLineSpacingRule;
            public byte bOutlineLevel;
            public short wShadingWeight;
            public short wShadingStyle;
            public short wNumberingStart;
            public short wNumberingStyle;
            public short wNumberingTab;
            public short wBorderSpace;
            public short wBorderWidth;
            public short wBorders;
        }

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        private extern static int SendMessage(IntPtr hwnd, int msg, IntPtr wparam, ref PARAFORMAT2 pf2);

        #endregion

		static private ParameterHelpForm _ThisForm;

		private bool _IsExist = new bool();

		static private Point FormPosition = new Point(0, 0);
		static private Size FormSize = new Size(300, 300);

		public ParameterHelpForm()
		{
			InitializeComponent();

			_ThisForm = this;
			_IsExist = true;
		}

		static public ParameterHelpForm ThisForm
		{
			get { return _ThisForm; }
		}

		public bool IsExist
		{
			get { return _IsExist; }
		}

		public string IdText
		{
			set
			{
				lblId.Text = UserText.ParameterHelpIdNumber + value;
			}
		}

        [Localizable(true)]
		public string ItemText
		{
			set
			{
				lblItem.Text = value;
			}
        }

        [Localizable(true)]
		public string HelpText
		{
			set
			{
				rtxtHelp.Text = value;
                ViewCultureResouceChanged();
			}
		}

		private void ParameterHelpForm_Load(object sender, EventArgs e)
		{
			if( FormPosition.X != 0 && FormPosition.Y != 0 )
			{
				this.Location = FormPosition;
			}

			this.Size = FormSize;

            //行間変更
            int size = Marshal.SizeOf(typeof(PARAFORMAT2));

            PARAFORMAT2 pf = new PARAFORMAT2();
            pf.cbSize = (uint)size;
            pf.dwMask = PFM_LINESPACING;
            pf.bLineSpacingRule = 4;
            pf.dyLineSpacing = 300; // 行間 ( twips )

            SendMessage(rtxtHelp.Handle, EM_SETPARAFORMAT, IntPtr.Zero, ref pf);

            //このオプションを付けないとRichTextで設定されたフォントが反映されない
            rtxtHelp.LanguageOption = RichTextBoxLanguageOptions.DualFont;

		}

		private void ParameterHelpForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			FormPosition = this.Location;
			FormSize = this.Size;

			_IsExist = false;

		}

        #region カルチャリソース切り替え

        public void ViewCultureResouceChanged()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ParameterHelpForm));

            this.Font = (Font)resources.GetObject("$this.Font");
            lblId.Font = (Font)resources.GetObject("lblId.Font");
            lblItem.Font = (Font)resources.GetObject("lblItem.Font");
            rtxtHelp.Font = (Font)resources.GetObject("rtxtHelp.Font");

            this.Text = resources.GetString("$this.Text");
        }

        #endregion

	}
}