using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
    public partial class ctlCommandMOVE_C : UserControl
    {
        #region 定数

        public const Int32 ProgID = 0x06;

        public const string Command = "MOVE_C";

        public readonly string Help = UserText.CtlCommandMOVE_C_HELP1 + Environment.NewLine +
                                      UserText.CtlCommandMOVE_C_HELP2 + Environment.NewLine +
                                      UserText.CtlCommandMOVE_C_HELP3;
        
        public string Comment = "";

        #endregion

        #region 変数

        private Int32 iFLAG_M4 = 0;                 // FLAG_M4
        private Int16 iTargetCurrrent = 0;          // 目標電流

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
                return Command + " FLAG_M4=" + iFLAG_M4.ToString() + " TargetCurrrent=" + iTargetCurrrent.ToString() +
                                 " ;" + Comment;
            }
        }

        /// <summary>
        /// FLAG_M3の取得／設定します。
        /// </summary>
        public Int32 FLAG_M4
        {
            set { iFLAG_M4 = value; }
            get { return iFLAG_M4; }
        }

        /// <summary>
        /// 目標電流の取得／設定します。
        /// </summary>
        public Int16 TargetCurrrent
        {
            set { iTargetCurrrent = value; }
            get { return iTargetCurrrent; }
        }

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ctlCommandMOVE_C()
        {
            InitializeComponent();
        }

        /// <summary>
        /// MOVE_Cコントロールロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctlCommandMOVE_C_Load(object sender, EventArgs e)
        {
            if ((iFLAG_M4 & 0x01) == 1)
            {
                rdoParameter.Checked = false;
                rdoAnalog.Checked = true;
            }

            txtTargetCur.Text = iTargetCurrrent.ToString();
        }

        /// <summary>
        /// 目標電流入力キープレスイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTargetCur_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputTextBox.CheckText_KeyPress(e, txtTargetCur, ref iTargetCurrrent);
            this.Focus();
        }

        /// <summary>
        /// 目標電流リーブイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTargetCur_Leave(object sender, EventArgs e)
        {
            InputTextBox.CheckText_Leave(txtTargetCur, ref iTargetCurrrent);
        }

        /// <summary>
        /// 電流指令条件チェックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoFLAG_M4_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAnalog.Checked)
            {
                iFLAG_M4 |= 0x01;
            }
            else
            {
                iFLAG_M4 &= ~0x01;
            }
        }

        #region カルチャリソース切り替え

        public void ViewCultureResouceRefresh()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ctlCommandMOVE_C));

            grpFLAG_M4.Font = (Font)resources.GetObject("grpFLAG_M4.Font");
            label2.Font = (Font)resources.GetObject("label2.Font");
            label3.Font = (Font)resources.GetObject("label3.Font");
            rdoAnalog.Font = (Font)resources.GetObject("rdoAnalog.Font");
            rdoParameter.Font = (Font)resources.GetObject("rdoParameter.Font");
            txtTargetCur.Font = (Font)resources.GetObject("txtTargetCur.Font");

            grpFLAG_M4.Text = resources.GetString("grpFLAG_M4.Text");
            label2.Text = resources.GetString("label2.Text");
            label3.Text = resources.GetString("label3.Text");
            rdoAnalog.Text = resources.GetString("rdoAnalog.Text");
            rdoParameter.Text = resources.GetString("rdoParameter.Text");
            txtTargetCur.Text = resources.GetString("txtTargetCur.Text");

        }

        #endregion
    }
}
