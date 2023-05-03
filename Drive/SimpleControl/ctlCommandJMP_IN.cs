using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
    public partial class ctlCommandJMP_IN : UserControl
    {
        #region 定数

        public const Int32 ProgID = 0x0b;

        public const string Command = "JMP_IN";

        public readonly string Help = UserText.CtlCommandJMP_IN_HELP1 + Environment.NewLine +
                                      UserText.CtlCommandJMP_IN_HELP2 + Environment.NewLine +
                                      UserText.CtlCommandJMP_IN_HELP3;

        public string Comment = "";

        #endregion

        #region 変数

        private Int32 iMODE_J1 = 0;         // FLAG_M1
        private Int16 iDiveStep = 0;        // 分岐先ステップ番号
        private Int16 iInputNumber = 0;     // 接点入力番号
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
                return Command + " MODE_J1=" + iMODE_J1.ToString() + " DiveStep=" + iDiveStep.ToString() +
                                 " InputNumber=" + iInputNumber.ToString() + " WaitTime=" + iWaitTime.ToString() +
                                 " ;" + Comment; 
            }
        }

        /// <summary>
        /// MODE_J1の取得／設定します。
        /// </summary>
        public Int32 MODE_J1
        {
            set { iMODE_J1 = value; }
            get { return iMODE_J1; }
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
        /// 接点入力番号の取得／設定します。
        /// </summary>
        public Int16 InputNumber
        {
            set { iInputNumber = value; }
            get { return iInputNumber; }
        }

        /// <summary>
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
        public ctlCommandJMP_IN()
        {
            InitializeComponent();
        }

        /// <summary>
        /// JMP_INコントロールロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctlCommandJMP_IN_Load(object sender, EventArgs e)
        {
            switch (iMODE_J1)
            {
                case 0:
                    rdoUNCONDWait.Checked = true;
                    break;

                case 1:
                    rdoInstructionPos.Checked = true;
                    break;

                case 2:
                    rdoInstructionPosInp.Checked = true; 
                    break;

                case 3:
                    rdoWaitTime.Checked = true;
                    break;
            }

            txtDiveStep.Text = iDiveStep.ToString();
            txtInputNumber.Text = iInputNumber.ToString();
            txtWaitTime.Text = iWaitTime.ToString();

        }

        /// <summary>
        /// MODE_J1変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoMODE_J1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoUNCONDWait.Checked)
            {
                iMODE_J1 = 0;
            }
            else if (rdoInstructionPos.Checked)
            {
                iMODE_J1 = 1;
            }
            else if (rdoInstructionPosInp.Checked)
            {
                iMODE_J1 = 2;
            }
            else if (rdoWaitTime.Checked)
            {
                iMODE_J1 = 3;
            }
        }

        /// <summary>
        /// 分岐先ステップキープレスイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDiveStep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (InputTextBox.CheckText_KeyPress(e, txtDiveStep, ref iDiveStep))
            {
                txtInputNumber.Focus();
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
        /// 接点入力番号キープレスイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInputNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (InputTextBox.CheckText_KeyPress(e, txtInputNumber, ref iInputNumber))
            {
                txtWaitTime.Focus();
            }
            else
            {
                this.Focus();
            }
        }

        /// <summary>
        /// 接点入力番号リーブイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInputNumber_Leave(object sender, EventArgs e)
        {
            InputTextBox.CheckText_Leave(txtInputNumber, ref iInputNumber);
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ctlCommandJMP_IN));

            grpMODE_J1.Font = (Font)resources.GetObject("grpMODE_J1.Font");
            label2.Font = (Font)resources.GetObject("label2.Font");
            label3.Font = (Font)resources.GetObject("label3.Font");
            label4.Font = (Font)resources.GetObject("label4.Font");
            label5.Font = (Font)resources.GetObject("label5.Font");
            rdoInstructionPos.Font = (Font)resources.GetObject("rdoInstructionPos.Font");
            rdoInstructionPosInp.Font = (Font)resources.GetObject("rdoInstructionPosInp.Font");
            rdoUNCONDWait.Font = (Font)resources.GetObject("rdoUNCONDWait.Font");
            rdoWaitTime.Font = (Font)resources.GetObject("rdoWaitTime.Font");
            txtDiveStep.Font = (Font)resources.GetObject("txtDiveStep.Font");
            txtInputNumber.Font = (Font)resources.GetObject("txtInputNumber.Font");
            txtWaitTime.Font = (Font)resources.GetObject("txtWaitTime.Font");	

            grpMODE_J1.Text = resources.GetString("grpMODE_J1.Text");
            label2.Text = resources.GetString("label2.Text");
            label3.Text = resources.GetString("label3.Text");
            label4.Text = resources.GetString("label4.Text");
            label5.Text = resources.GetString("label5.Text");
            rdoInstructionPos.Text = resources.GetString("rdoInstructionPos.Text");
            rdoInstructionPosInp.Text = resources.GetString("rdoInstructionPosInp.Text");
            rdoUNCONDWait.Text = resources.GetString("rdoUNCONDWait.Text");
            rdoWaitTime.Text = resources.GetString("rdoWaitTime.Text");

        }

        #endregion
    }
}
