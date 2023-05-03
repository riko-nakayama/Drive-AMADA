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
    public partial class ctlCommandMOVE_END : UserControl
    {
        #region 定数

        public const Int32 ProgID = 0x01;

        public const string Command = "MOVE_END";

        public readonly string Help = UserText.CtlCommandMOVE_END_HELP1 + Environment.NewLine +
                                      UserText.CtlCommandMOVE_END_HELP2 + Environment.NewLine +
                                      UserText.CtlCommandMOVE_END_HELP3;
        public string Comment = "";

        #endregion

        #region 変数

        private Int32 iFLAG_M1 = 0;         // FLAG_M1
        private Int16 iTargetVelocity =  0; // 目標速度
        private Int32 iTargetPostion = 0;   // 目標位置
        private Int16 iAcceleration = 0;    // 加速度
        private Int16 iDeceleration = 0;    // 減速度

        #endregion

        #region イベント

        //public delegate void dProfileTableValueChanged(object sender);
        //public event dProfileTableValueChanged ProfileTableValueChange;

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
                return Command + " FLAG_M1=" + iFLAG_M1.ToString() + " TargetVelocity=" + iTargetVelocity.ToString() +
                                 " TargetPostion=" + iTargetPostion.ToString() + " Acceleration=" + iAcceleration.ToString() +
                                 " Deceleration=" + iDeceleration.ToString() + " ;" + Comment;
            }
        }

        /// <summary>
        /// FLAG_M1の取得／設定します。
        /// </summary>
        public Int32 FLAG_M1
        {
            set { iFLAG_M1 = value; }
            get { return iFLAG_M1;  }
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
        /// 目標位置の取得／設定します。
        /// </summary>
        public Int32 TargetPosition
        {
            set { iTargetPostion = value; }
            get { return iTargetPostion; }
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
        public ctlCommandMOVE_END()
        {
            InitializeComponent();
        }

        /// <summary>
        /// MOVE_ENDコマンドコントロールロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctlCommandMOVE_END_Load(object sender, EventArgs e)
        {
            ViewMOVE_END();
        }

        public void ViewMOVE_END()
        {
            if ((iFLAG_M1 & 0x01) == 1)
            {
                rdoRelMove.Checked = true;
            }
            else
            {
                rdoAbsMove.Checked = true;
            }

            if ((iFLAG_M1 & 0x02) == 2)
            {
                rdoInstructionPosInp.Checked = true;
            }
            else
            {
                rdoInstructionPos.Checked = true;
            }

            txtTargetVel.Text = iTargetVelocity.ToString();
            txtTargetPos.Text = iTargetPostion.ToString();
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
        /// 位置指令条件チェックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoFLAG_M1Bit0_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoRelMove.Checked)
            {
                iFLAG_M1 |= 0x01;
            }
            else
            {
                iFLAG_M1 &= ~0x01;
            }

            //ProfileTableValueChange(this);
        }

        /// <summary>
        /// 移動完了条件チェックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoFLAG_M1Bit1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoInstructionPosInp.Checked)
            {
                iFLAG_M1 |= 0x02;
            }
            else
            {
                iFLAG_M1 &= ~0x02;
            }

            //ProfileTableValueChange(this);
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
                //ProfileTableValueChange(this);
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
        /// 目標位置入力キープレスイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTargetPos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (InputTextBox.CheckText_KeyPress(e, txtTargetPos, ref iTargetPostion))
            {
                txtTargetPos.Focus();
                //ProfileTableValueChange(this);
            }
            else
            {
                this.Focus();
            }
        }

        /// <summary>
        /// 目標位置入力リーブイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTargetPos_Leave(object sender, EventArgs e)
        {
            InputTextBox.CheckText_Leave(txtTargetPos, ref iTargetPostion);
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
                //ProfileTableValueChange(this);
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
        private void txtAcceleration_Leave(object sender, EventArgs e)
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
            if (InputTextBox.CheckText_KeyPress(e, txtDeceleration, ref iDeceleration))
            {
                txtTargetPos.Focus();
                //ProfileTableValueChange(this);
            }
            else
            {
                this.Focus();
            }
        }

        /// <summary>
        /// 減速度入力リーブイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDeceleration_Leave(object sender, EventArgs e)
        {
            InputTextBox.CheckText_Leave(txtDeceleration, ref iDeceleration);
        }

        #region カルチャリソース切り替え

        public void ViewCultureResouceRefresh()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ctlCommandMOVE_END));

            gradientLabel2.Font = (Font)resources.GetObject("gradientLabel2.Font");
            gradientLabel3.Font = (Font)resources.GetObject("gradientLabel3.Font");
            gradientLabel4.Font = (Font)resources.GetObject("gradientLabel4.Font");
            grpFLAG_M1_1.Font = (Font)resources.GetObject("grpFLAG_M1_1.Font");
            grpFLAG_M1_2.Font = (Font)resources.GetObject("grpFLAG_M1_2.Font");
            rdoAbsMove.Font = (Font)resources.GetObject("rdoAbsMove.Font");
            rdoInstructionPos.Font = (Font)resources.GetObject("rdoInstructionPos.Font");
            rdoInstructionPosInp.Font = (Font)resources.GetObject("rdoInstructionPosInp.Font");
            rdoRelMove.Font = (Font)resources.GetObject("rdoRelMove.Font");
            ulblAccel.Font = (Font)resources.GetObject("ulblAccel.Font");
            label3.Font = (Font)resources.GetObject("label3.Font");
            label4.Font = (Font)resources.GetObject("label4.Font");	
            label6.Font = (Font)resources.GetObject("label6.Font");
            label8.Font = (Font)resources.GetObject("label8.Font");
            txtAcceleration.Font = (Font)resources.GetObject("txtAcceleration.Font");
            txtDeceleration.Font = (Font)resources.GetObject("txtDeceleration.Font");
            txtTargetPos.Font = (Font)resources.GetObject("txtTargetPos.Font");
            txtTargetVel.Font = (Font)resources.GetObject("txtTargetVel.Font");

            gradientLabel2.Text = resources.GetString("gradientLabel2.Text");
            gradientLabel3.Text = resources.GetString("gradientLabel3.Text");
            gradientLabel4.Text = resources.GetString("gradientLabel4.Text");
            grpFLAG_M1_1.Text = resources.GetString("grpFLAG_M1_1.Text");
            grpFLAG_M1_2.Text = resources.GetString("grpFLAG_M1_2.Text");
            rdoAbsMove.Text = resources.GetString("rdoAbsMove.Text");
            rdoInstructionPos.Text = resources.GetString("rdoInstructionPos.Text");
            rdoInstructionPosInp.Text = resources.GetString("rdoInstructionPosInp.Text");
            rdoRelMove.Text = resources.GetString("rdoRelMove.Text");
            ulblAccel.Text = resources.GetString("ulblAccel.Text");

            label6.Size = (Size)resources.GetObject("label6.Size");

            grpFLAG_M1_1.Size = (Size)resources.GetObject("grpFLAG_M1_1.Size");
            grpFLAG_M1_2.Size = (Size)resources.GetObject("grpFLAG_M1_2.Size");

            grpFLAG_M1_1.Location = (Point)resources.GetObject("grpFLAG_M1_1.Location");
            grpFLAG_M1_2.Location = (Point)resources.GetObject("grpFLAG_M1_2.Location");

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
