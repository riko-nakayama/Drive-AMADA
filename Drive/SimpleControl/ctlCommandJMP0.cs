using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
    public partial class ctlCommandJMP0 : UserControl
    {
        #region 定数

        public const Int32 ProgID = 0x0a;

        public const string Command = "JMP0";

        public readonly string Help = UserText.CtlCommandJMP0_HELP1 + Environment.NewLine +
                                      UserText.CtlCommandJMP0_HELP2 + Environment.NewLine +
                                      UserText.CtlCommandJMP0_HELP3;
        public string Comment = "";

        #endregion

        #region 変数

        private Int16 iDiveStep = 0;        // 分岐先ステップ番号
        private Int16 iWaitTime = 0;        // 待機時間
        private Int16 iRepeatNumber = 0;    // 繰り返し回数

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
                return Command + " DiveStep=" + iDiveStep.ToString() + " WaitTime=" + iWaitTime.ToString() +
                                 " RepeatNumber=" + iRepeatNumber.ToString() + " ;" + Comment;
            }
        }

        /// <summary>
        /// 分岐先ステップの取得／設定します。
        /// </summary>
        public Int16 DiveStep
        {
            set { iDiveStep = value; }
            get { return iDiveStep; }
        }

        /// <summary>
        /// 待機時間の取得／設定します。
        /// </summary>
        public Int16 WaitTime
        {
            set { iWaitTime = value; }
            get { return iWaitTime; }
        }

        /// <summary>
        /// 繰り返し番号の取得／設定します。
        /// </summary>
        public Int16 RepeatNumber
        {
            set { iRepeatNumber = value; }
            get { return iRepeatNumber; }
        }

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ctlCommandJMP0()
        {
            InitializeComponent();
        }

        /// <summary>
        /// JMP0コントロールロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctlCommandJMP0_Load(object sender, EventArgs e)
        {
            txtDiveStep.Text = iDiveStep.ToString();
            txtWaitTime.Text = iWaitTime.ToString();
            txtRepeatNumber.Text = iRepeatNumber.ToString();
        }

        /// <summary>
        /// 分岐先ステップ入力キープレスイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDiveStep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (InputTextBox.CheckText_KeyPress(e, txtDiveStep, ref iDiveStep))
            {
                txtWaitTime.Focus();
            }
            else
            {
                this.Focus();
            }
        }

        /// <summary>
        /// 分岐先ステップリーブイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDiveStep_Leave(object sender, EventArgs e)
        {
            InputTextBox.CheckText_Leave(txtDiveStep, ref iDiveStep);
        }

        /// <summary>
        /// 待ち時間入力キープレスイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtWaitTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (InputTextBox.CheckText_KeyPress(e, txtWaitTime, ref iWaitTime))
            {
                txtRepeatNumber.Focus();
            }
            else
            {
                this.Focus();
            }
        }

        /// <summary>
        /// 待ち時間リーブイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtWaitTime_Leave(object sender, EventArgs e)
        {
            InputTextBox.CheckText_Leave(txtWaitTime, ref iWaitTime);
        }

        /// <summary>
        /// 繰り返し番号入力キープレスイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRepeatNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputTextBox.CheckText_KeyPress(e, txtRepeatNumber, ref iRepeatNumber);
            this.Focus();
        }

        /// <summary>
        /// 繰り返し番号リーブイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRepeatNumber_Leave(object sender, EventArgs e)
        {
            InputTextBox.CheckText_Leave(txtRepeatNumber, ref iRepeatNumber);
        }

        #region カルチャリソース切り替え

        public void ViewCultureResouceRefresh()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ctlCommandJMP0));

            label2.Font = (Font)resources.GetObject("label2.Font");
            label3.Font = (Font)resources.GetObject("label3.Font");
            label4.Font = (Font)resources.GetObject("label4.Font");
            label5.Font = (Font)resources.GetObject("label5.Font");
            label6.Font = (Font)resources.GetObject("label6.Font");
            txtDiveStep.Font = (Font)resources.GetObject("txtDiveStep.Font");
            txtRepeatNumber.Font = (Font)resources.GetObject("txtRepeatNumber.Font");
            txtWaitTime.Font = (Font)resources.GetObject("txtWaitTime.Font");

            label2.Text = resources.GetString("label2.Text");
            label3.Text = resources.GetString("label3.Text");
            label4.Text = resources.GetString("label4.Text");
            label5.Text = resources.GetString("label5.Text");
            label6.Text = resources.GetString("label6.Text");
            txtDiveStep.Text = resources.GetString("txtDiveStep.Text");
            txtRepeatNumber.Text = resources.GetString("txtRepeatNumber.Text");
            txtWaitTime.Text = resources.GetString("txtWaitTime.Text");
        }

        #endregion
    }
}
