using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
    public partial class ctlCommandPARA_W : UserControl
    {
        #region 定数

        public const Int32 ProgID = 0x32;

        public const string Command = "PARA_W";

        public readonly string Help = UserText.CtlCommandPARA_W_HELP1 + Environment.NewLine +
                                      UserText.CtlCommandPARA_W_HELP2 + Environment.NewLine +
                                      UserText.CtlCommandPARA_W_HELP3;
        public string Comment = "";

        #endregion

        #region 変数

        private Int16 iParameterID = 0; // パラメータＩＤ
        private Int32 iWriteData = 0;   // 書込みデータ

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
                return Command + " ParameterID=" + iParameterID.ToString() + " WriteData=" + iWriteData.ToString() +
                                 " ;" + Comment;
            }
        }

        /// <summary>
        /// パラメータＩＤの取得／設定します。
        /// </summary>
        public Int16 ParameterID
        {
            set { iParameterID = value; }
            get { return iParameterID; }
        }

        /// <summary>
        /// 書込みデータの取得／設定します。
        /// </summary>
        public Int32 WriteData
        {
            set { iWriteData = value; }
            get { return iWriteData; }
        }


        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ctlCommandPARA_W()
        {
            InitializeComponent();
        }

        /// <summary>
        /// PARA_Wコントロールイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctlCommandPARA_W_Load(object sender, EventArgs e)
        {
            txtParameterID.Text = iParameterID.ToString();
            txtWriteData.Text = iWriteData.ToString();
        }

        /// <summary>
        /// パラメータＩＤ入力値キープレスイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtParameterID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (InputTextBox.CheckText_KeyPress(e, txtParameterID, ref iParameterID))
            {
                txtWriteData.Focus();
            }
            else
            {
                this.Focus();
            }
        }

        /// <summary>
        /// パラメータＩＤリーブイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtParameterID_Leave(object sender, EventArgs e)
        {
            InputTextBox.CheckText_Leave(txtParameterID, ref iParameterID);
        }

        /// <summary>
        /// 書込みデータ入力キープレスイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtWriteData_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputTextBox.CheckText_KeyPress(e, txtWriteData, ref iWriteData);
            this.Focus();
        }

        /// <summary>
        /// 書込みデータリーブイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtWriteData_Leave(object sender, EventArgs e)
        {
            InputTextBox.CheckText_Leave(txtWriteData, ref iWriteData);
        }

        #region カルチャリソース切り替え

        public void ViewCultureResouceRefresh()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ctlCommandPARA_W));

            label2.Font = (Font)resources.GetObject("label2.Font");
            label3.Font = (Font)resources.GetObject("label3.Font");
            txtParameterID.Font = (Font)resources.GetObject("txtParameterID.Font");
            txtWriteData.Font = (Font)resources.GetObject("txtWriteData.Font");

            label2.Text = resources.GetString("label2.Text");
            label3.Text = resources.GetString("label3.Text");
            txtParameterID.Text = resources.GetString("txtParameterID.Text");
            txtWriteData.Text = resources.GetString("txtWriteData.Text");
        }

        #endregion
    }
}
