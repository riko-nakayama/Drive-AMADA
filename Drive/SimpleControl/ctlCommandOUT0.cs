using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
    public partial class ctlCommandOUT0 : UserControl
    {
        #region 定数

        public const Int32 ProgID = 0x1e;

        public const string Command = "OUT0";

        public readonly string Help = UserText.CtlCommandOUT_0_HELP1 + Environment.NewLine +
                                      UserText.CtlCommandOUT_0_HELP2;
        public string Comment = "";

        #endregion

        #region 変数

        private Int16 iOutNumber = 0;       // 接点出力番号
        private Int16 iOutputLogic = 0;     // 出力論理

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
                return Command + " OutNumber=" + iOutNumber.ToString() + " OutputLogic=" + iOutputLogic.ToString() +
                                 " ;" + Comment;
            }
        }

        /// <summary>
        /// 接点出力番号の取得／設定します。
        /// </summary>
        public Int16 OutNumber
        {
            set { iOutNumber = value; }
            get { return iOutNumber; }
        }

        /// <summary>
        /// 出力論理の取得／設定します。
        /// </summary>
        public Int16 OutputLogic
        {
            set { iOutputLogic = value; }
            get { return iOutputLogic; }
        }

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ctlCommandOUT0()
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
            txtOutNumber.Text = iOutNumber.ToString();
            txtOutputLogic.Text = iOutputLogic.ToString();
        }

        /// <summary>
        /// 接点出力番号入力キープレスイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOutNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (InputTextBox.CheckText_KeyPress(e, txtOutNumber, ref iOutNumber))
            {
                txtOutputLogic.Focus();
            }
            else
            {
                this.Focus();
            }
        }

        /// <summary>
        /// 接点出力番号リーブイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOutNumber_Leave(object sender, EventArgs e)
        {
            InputTextBox.CheckText_Leave(txtOutNumber, ref iOutNumber);
        }

        /// <summary>
        /// 出力論理入力キープレスイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOutputLogic_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputTextBox.CheckText_KeyPress(e, txtOutputLogic, ref iOutputLogic);
            this.Focus();
        }

        /// <summary>
        /// 出力論理リーブイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOutputLogic_Leave(object sender, EventArgs e)
        {
            InputTextBox.CheckText_Leave(txtOutputLogic, ref iOutputLogic);
        }

        #region カルチャリソース切り替え

        public void ViewCultureResouceRefresh()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ctlCommandOUT0));

            label2.Font = (Font)resources.GetObject("label2.Font");
            label3.Font = (Font)resources.GetObject("label3.Font");
            txtOutNumber.Font = (Font)resources.GetObject("txtOutNumber.Font");
            txtOutputLogic.Font = (Font)resources.GetObject("txtOutputLogic.Font");

            label2.Text = resources.GetString("label2.Text");
            label3.Text = resources.GetString("label3.Text");
            txtOutNumber.Text = resources.GetString("txtOutNumber.Text");
            txtOutputLogic.Text = resources.GetString("txtOutputLogic.Text");

        }

        #endregion
    }
}
