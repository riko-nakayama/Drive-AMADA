using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
    public partial class ctlCommandWAIT0 : UserControl
    {
        #region 定数

        public const Int32 ProgID = 0x14;

        public const string Command = "WAIT0";

        public readonly string Help = UserText.CtlCommandWAIT_0_HELP1 + Environment.NewLine +
                                      UserText.CtlCommandWAIT_0_HELP2;

        public string Comment = "";

        #endregion

        #region 変数

        private Int16 iWaitTime = 0;        // 待機時間

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
                return Command + " WaitTime=" + iWaitTime.ToString() + " ;" + Comment;
            }
        }

        /// 待機時間の取得／設定します。
        /// </summary>
        public Int16 WaitTime
        {
            set { iWaitTime = value; }
            get { return iWaitTime; }
        }

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ctlCommandWAIT0()
        {
            InitializeComponent();
        }

        /// <summary>
        /// WAIT0コントロールロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctlCommandWAIT0_Load(object sender, EventArgs e)
        {
            txtWaitTime.Text = iWaitTime.ToString();
        }

        /// <summary>
        /// 待機時間キープレスイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtWaitTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputTextBox.CheckText_KeyPress(e, txtWaitTime, ref iWaitTime);
            this.Focus();
        }

        /// <summary>
        /// 待機時間リーブイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtWaitTime_Leave(object sender, EventArgs e)
        {
            InputTextBox.CheckText_Leave(txtWaitTime, ref iWaitTime);
        }

        #region カルチャリソース切り替え

        public void ViewCultureResouceRefresh()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ctlCommandWAIT0));

            label3.Font = (Font)resources.GetObject("label3.Font");
            label4.Font = (Font)resources.GetObject("label4.Font");
            txtWaitTime.Font = (Font)resources.GetObject("txtWaitTime.Font");

            label3.Text = resources.GetString("label3.Text");
            label4.Text = resources.GetString("label4.Text");
            txtWaitTime.Text = resources.GetString("txtWaitTime.Text");
        }

        #endregion

    }
}
