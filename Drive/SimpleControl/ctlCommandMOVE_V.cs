using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace Motion_Designer
{
    public partial class ctlCommandMOVE_V : UserControl
    {
        #region 定数

        public const Int32 ProgID = 0x05;

        public const string Command = "MOVE_V";

        public readonly string Help = UserText.CtlCommandMOVE_V_HELP1 + Environment.NewLine +
                                      UserText.CtlCommandMOVE_V_HELP2;
        public string Comment = "";

        #endregion

        #region 変数

        private Int32 iFLAG_M3 = 0;         // FLAG_M3
        private Int16 iTargetVelocity = 0;  // 目標速度
        private Int16 iAcceleration = 0;    // 加速度
        private Int16 iDeceleration = 0;    // 減速度

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
                return Command + " FLAG_M3=" + iFLAG_M3.ToString() + " TargetVelocity=" + iTargetVelocity.ToString() +
                                 " Acceleration=" + iAcceleration.ToString() + " Deceleration=" + iDeceleration.ToString() + 
                                 " ;" + Comment;
            }
        }

        /// <summary>
        /// FLAG_M3の取得／設定します。
        /// </summary>
        public Int32 FLAG_M3
        {
            set { iFLAG_M3 = value; }
            get { return iFLAG_M3; }
        }

        /// <summary>
        /// 目標速度の取得／設定します。
        /// </summary>
        public Int16 TargetVelocity
        {
            set { iTargetVelocity = value; }
            get { return iTargetVelocity; }
        }

        /// <summary>
        /// 加速度の取得／設定します。
        /// </summary>
        public Int16 Acceleration
        {
            set { iAcceleration = value; }
            get { return iAcceleration; }
        }

        /// <summary>
        /// 減速度の取得／設定します。
        /// </summary>
        public Int16 Deceleration
        {
            set { iDeceleration = value; }
            get { return iDeceleration; }
        }

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ctlCommandMOVE_V()
        {
            InitializeComponent();
        }

        /// <summary>
        /// MOVE_Vコントロールロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctlCommandMOVE_V_Load(object sender, EventArgs e)
        {
            if ((iFLAG_M3 & 0x01) == 1)
            {
                rdoParameter.Checked = false;
                rdoAnalog.Checked = true;
            }

            txtTargetVel.Text = iTargetVelocity.ToString();
            txtAcceleration.Text = iAcceleration.ToString();
            txtDeceleration.Text = iDeceleration.ToString();

            //画像選択
            switch (Culture.Name)
            {
                default:
                case Culture.JP:
                    picProg.Image = Properties.Resources.運転台形;
                    break;

                case Culture.US:
                    picProg.Image = Properties.Resources.運転台形_US;
                    break;

                case Culture.CN:
                    picProg.Image = Properties.Resources.運転台形_CN;
                    break;
            }
        }

        /// <summary>
        /// 目標速度入力キープレスイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTargetVel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (InputTextBox.CheckText_KeyPress(e, txtTargetVel, ref iTargetVelocity))
            {
                txtAcceleration.Focus();
            }
            else
            {
                this.Focus();
            }
        }

        /// <summary>
        /// 目標速度入力リーブイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTargetVel_Leave(object sender, EventArgs e)
        {
            InputTextBox.CheckText_Leave(txtTargetVel, ref iTargetVelocity);
        }

        /// <summary>
        /// 加速度入力キープレスイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAcceleration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (InputTextBox.CheckText_KeyPress(e, txtAcceleration, ref iAcceleration))
            {
                txtDeceleration.Focus();
            }
            else
            {
                this.Focus();
            }
        }

        /// <summary>
        /// 加速度入力リーブイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAcceleration_DragLeave(object sender, EventArgs e)
        {
            InputTextBox.CheckText_Leave(txtAcceleration, ref iAcceleration);
        }

        /// <summary>
        /// 減速度入力キープレスイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDeceleration_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputTextBox.CheckText_KeyPress(e, txtDeceleration, ref iDeceleration);
            this.Focus();
        }

        /// <summary>
        /// 減速度入力リーブイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDeceleration_Enter(object sender, EventArgs e)
        {
            InputTextBox.CheckText_Leave(txtDeceleration, ref iDeceleration);
        }

        /// <summary>
        /// 速度指令条件チェックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoFLAG_M3_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAnalog.Checked)
            {
                iFLAG_M3 |= 0x01;
            }
            else
            {
                iFLAG_M3 &= ~0x01;
            }
        }

        #region カルチャリソース切り替え

        public void ViewCultureResouceRefresh()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ctlCommandMOVE_V));

            gradientLabel2.Font = (Font)resources.GetObject("gradientLabel2.Font");
            gradientLabel3.Font = (Font)resources.GetObject("gradientLabel3.Font");
            grpFLAG_M3.Font = (Font)resources.GetObject("grpFLAG_M3.Font");
            label1.Font = (Font)resources.GetObject("label1.Font");
            label4.Font = (Font)resources.GetObject("label4.Font");
            label5.Font = (Font)resources.GetObject("label5.Font");
            rdoAnalog.Font = (Font)resources.GetObject("rdoAnalog.Font");
            rdoParameter.Font = (Font)resources.GetObject("rdoParameter.Font");
            txtAcceleration.Font = (Font)resources.GetObject("txtAcceleration.Font");
            txtDeceleration.Font = (Font)resources.GetObject("txtDeceleration.Font");
            txtTargetVel.Font = (Font)resources.GetObject("txtTargetVel.Font");
            ulblAccel.Font = (Font)resources.GetObject("ulblAccel.Font");

            gradientLabel2.Text = resources.GetString("gradientLabel2.Text");
            gradientLabel3.Text = resources.GetString("gradientLabel3.Text");
            grpFLAG_M3.Text = resources.GetString("grpFLAG_M3.Text");
            label1.Text = resources.GetString("label1.Text");
            label4.Text = resources.GetString("label4.Text");
            label5.Text = resources.GetString("label5.Text");
            rdoAnalog.Text = resources.GetString("rdoAnalog.Text");
            rdoParameter.Text = resources.GetString("rdoParameter.Text");
            txtAcceleration.Text = resources.GetString("txtAcceleration.Text");
            txtDeceleration.Text = resources.GetString("txtDeceleration.Text");
            txtTargetVel.Text = resources.GetString("txtTargetVel.Text");
            ulblAccel.Text = resources.GetString("ulblAccel.Text");

            switch (Culture.Name)
            {
                default:
                case Culture.JP:
                    picProg.Image = Properties.Resources.運転台形;
                    break;

                case Culture.US:
                    picProg.Image = Properties.Resources.運転台形_US;
                    break;

                case Culture.CN:
                    picProg.Image = Properties.Resources.運転台形_CN;
                    break;
            }
        }

        #endregion
    }
}
