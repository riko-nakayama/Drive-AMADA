using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
    public partial class ctlCommandPC_RST_SP : UserControl
    {
        #region 定数

        public const Int32 ProgID = 0x16;

        public const string Command = "PC_RST_SP";

        public readonly string Help = UserText.CtlCommandPC_RSP_SP_HELP1 + Environment.NewLine +
                                      UserText.CtlCommandPC_RSP_SP_HELP2;

        public string Comment = "";

        #endregion

        #region 変数

        private Int16 iStepNumber = 0;       // 指定ステップ番号

        #endregion

        #region プロパティ

        /// <summary>
        /// プログラムＩＤを取得します。
        /// </summary>
        public Int32 ID
        {
            get { return ProgID; }
        }

        /// <summary>
        /// ニューメリックコード取得
        /// </summary>
        public string MnemonicCode
        {
            get
            {
                return Command + " StepNumber=" + iStepNumber.ToString() + " ;" + Comment;
            }
        }

        /// <summary>
        /// 指定ステップ番号の取得／設定します。
        /// </summary>
        public Int16 StepNumber
        {
            set { iStepNumber = value; }
            get { return iStepNumber; }
        }

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ctlCommandPC_RST_SP()
        {
            InitializeComponent();
        }

        /// <summary>
        /// OUT0コントロールロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctlCommandOUT0_Load(object sender, EventArgs e)
        {
            txtStepNumber.Text = iStepNumber.ToString();
        }

        /// <summary>
        /// 指定ステップ番号入力キープレスイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtStepNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (InputTextBox.CheckText_KeyPress(e, txtStepNumber, ref iStepNumber))
            {
                txtStepNumber.Focus();
            }
            else
            {
                this.Focus();
            }
        }

        /// <summary>
        /// 指定ステップ番号リーブイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtStepNumber_Leave(object sender, EventArgs e)
        {
            InputTextBox.CheckText_Leave(txtStepNumber, ref iStepNumber);
        }

        #region カルチャリソース切り替え

        public void ViewCultureResouceRefresh()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ctlCommandPC_RST_SP));

            label2.Font = (Font)resources.GetObject("label2.Font");
            txtStepNumber.Font = (Font)resources.GetObject("txtStepNumber.Font");

            label2.Text = resources.GetString("label2.Text");
        }

        #endregion
    }
}
