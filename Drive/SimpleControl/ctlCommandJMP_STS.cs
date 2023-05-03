using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
    public partial class ctlCommandJMP_STS : UserControl
    {
        #region 定数

        public const Int32 ProgID = 0x0e;

        public const string Command = "JMP_STS";

        public readonly string Help = UserText.CtlCommandJMP_STS_HELP1 + Environment.NewLine +
                                      UserText.CtlCommandJMP_STS_HELP2 + Environment.NewLine +
                                      UserText.CtlCommandJMP_STS_HELP3;

        public string Comment = "";

        #endregion

        #region 変数

        private Int32 iMODE_J1 = 0;         // 
        private Int16 iDiveStep = 0;        // 分岐先ステップ番号
        private UInt32 iServoSTSBit = 0;     // サーボステータス判断Bit
        private Int16 iWaitTime = 0;        // 待機時間
        private Int32 iDiveLogic = 0;       // 分岐論理

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
                                 " ServoSTSBit=" + "0x" + iServoSTSBit.ToString("X8") + " WaitTime=" + iWaitTime.ToString() +
                                 " DiveLogic=" + iDiveLogic.ToString() + " ;" + Comment;
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
        /// サーボステータス判断Bitの取得／設定します。
        /// </summary>
        public UInt32 ServoSTSBit
        {
            set { iServoSTSBit = value; }
            get { return iServoSTSBit; }
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
        /// 分岐論理の取得／設定します。
        /// </summary>
        public Int32 DiveLogic
        {
            set { iDiveLogic = value; }
            get { return iDiveLogic; }
        }

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ctlCommandJMP_STS()
        {
            InitializeComponent();
        }

        /// <summary>
        /// JMP_STSコントロールロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctlCommandJMP_STS_Load(object sender, EventArgs e)
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
            txtServoSTSBit.Text = iServoSTSBit.ToString("X8");
            txtWaitTime.Text = iWaitTime.ToString();

            if (iDiveLogic == 0)
            {
                rdoZeroJump.Checked = true;
            }
            else
            {
                rdoOneJump.Checked = true;
            }
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
                txtServoSTSBit.Focus();
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
        /// サーボステータス判断Bitキープレスイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtServoSTSBit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (InputTextBox.CheckText_KeyPressHex(e, txtServoSTSBit, ref iServoSTSBit))
            {
                txtWaitTime.Focus();
            }
            else
            {
                this.Focus();
            }
        }

        /// <summary>
        /// サーボステータス判断Bitリーブイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtServoSTSBit_Leave(object sender, EventArgs e)
        {
            InputTextBox.CheckText_LeaveHex(txtServoSTSBit, ref iServoSTSBit);
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

        /// <summary>
        /// 分岐変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoThreshold_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoZeroJump.Checked )
            {
                iDiveLogic = 0;
            }
            else
            {
                iDiveLogic = 1;
            }
        }

        #region カルチャリソース切り替え

        public void ViewCultureResouceRefresh()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ctlCommandJMP_STS));

            groupBox1.Font = (Font)resources.GetObject("groupBox1.Font");
            grpMODE_J3.Font = (Font)resources.GetObject("grpMODE_J3.Font");
            label1.Font = (Font)resources.GetObject("label1.Font");
            label2.Font = (Font)resources.GetObject("label2.Font");
            label3.Font = (Font)resources.GetObject("label3.Font");
            label4.Font = (Font)resources.GetObject("label4.Font");
            label5.Font = (Font)resources.GetObject("label5.Font");
            rdoInstructionPos.Font = (Font)resources.GetObject("rdoInstructionPos.Font");
            rdoInstructionPosInp.Font = (Font)resources.GetObject("rdoInstructionPosInp.Font");
            rdoOneJump.Font = (Font)resources.GetObject("rdoOneJump.Font");
            rdoUNCONDWait.Font = (Font)resources.GetObject("rdoUNCONDWait.Font");
            rdoWaitTime.Font = (Font)resources.GetObject("rdoWaitTime.Font");
            rdoZeroJump.Font = (Font)resources.GetObject("rdoZeroJump.Font");
            txtDiveStep.Font = (Font)resources.GetObject("txtDiveStep.Font");
            txtServoSTSBit.Font = (Font)resources.GetObject("txtServoSTSBit.Font");
            txtWaitTime.Font = (Font)resources.GetObject("txtWaitTime.Font");

            groupBox1.Text = resources.GetString("groupBox1.Text");
            grpMODE_J3.Text = resources.GetString("grpMODE_J3.Text");
            label1.Text = resources.GetString("label1.Text");
            label2.Text = resources.GetString("label2.Text");
            label3.Text = resources.GetString("label3.Text");
            label4.Text = resources.GetString("label4.Text");
            label5.Text = resources.GetString("label5.Text");
            rdoInstructionPos.Text = resources.GetString("rdoInstructionPos.Text");
            rdoInstructionPosInp.Text = resources.GetString("rdoInstructionPosInp.Text");
            rdoOneJump.Text = resources.GetString("rdoOneJump.Text");
            rdoUNCONDWait.Text = resources.GetString("rdoUNCONDWait.Text");
            rdoWaitTime.Text = resources.GetString("rdoWaitTime.Text");
            rdoZeroJump.Text = resources.GetString("rdoZeroJump.Text");
            txtDiveStep.Text = resources.GetString("txtDiveStep.Text");
            txtServoSTSBit.Text = resources.GetString("txtServoSTSBit.Text");
            txtWaitTime.Text = resources.GetString("txtWaitTime.Text");
        }

        #endregion
    }
}
