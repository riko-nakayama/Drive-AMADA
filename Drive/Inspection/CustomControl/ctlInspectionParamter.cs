using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
    public partial class ctlInspectionParamter : UserControl
    {
        #region プロパティ

        public string InspectionNo
        {
            set { txtNo.Text = value; }
            get { return txtNo.Text; }
        }

        public string MotorType
        {
            set { txtMotorType.Text = value; }
            get { return txtMotorType.Text; }
        }

        public int LowVelocity
        {
            set { numLowVelocity.Value = value; }
            get { return (int)numLowVelocity.Value; }
        }

        public int HighVelocity
        {
            set { numHighVelocity.Value = value; }
            get { return (int)numHighVelocity.Value; }
        }

        public float ExcitationCur1
        {
            set { numExcitationCur1.Value = (decimal)value; }
            get { return (float)numExcitationCur1.Value; }
        }

        public float ExcitationCur2
        {
            set { numExcitationCur2.Value = (decimal)value; }
            get { return (float)numExcitationCur2.Value; }
        }

        public float HighModeUp
        {
            set { numHighModeUp.Value = (decimal)value; }
            get { return (float)numHighModeUp.Value; }
        }

        public float HighModeConstantUp
        {
            set { numHighModeConstantUp.Value = (decimal)value; }
            get { return (float)numHighModeConstantUp.Value; }
        }

        public float HighModeDown
        {
            set { numHighModeDown.Value = (decimal)value; }
            get { return (float)numHighModeDown.Value; }
        }

        public float LowModeUp
        {
            set { numLowModeUp.Value = (decimal)value; }
            get { return (float)numLowModeUp.Value; }
        }

        public float LowModeConstantUp
        {
            set { numLowModeConstantUp.Value = (decimal)value; }
            get { return (float)numLowModeConstantUp.Value; }
        }

        public float LowModeDown
        {
            set { numLowModeDown.Value = (decimal)value; }
            get { return (float)numLowModeDown.Value; }
        }

        public int Cycle
        {
            set { numCycle.Value = value; }
            get { return (int)numCycle.Value; }
        }

        public float HighModeConstantDown
        {
            set { numHighModeConstantDown.Value = (decimal)value; }
            get { return (float)numHighModeConstantDown.Value; }
        }

        public float LowModeConstantDown
        {
            set { numLowModeConstantDown.Value = (decimal)value; }
            get { return (float)numLowModeConstantDown.Value; }
        }

        #endregion

        #region 変数

        private NumericUpDown[] numData;

        private int CurrentIndex = 0;

        #endregion

        #region event

        //取得ｲﾍﾞﾝﾄ
        public delegate void INSPParaDataGetClick(int inspno);
        public event INSPParaDataGetClick DataGetClick;

        //設定ｲﾍﾞﾝﾄ
        public delegate void INSPParaDataSetClick(int inspno);
        public event INSPParaDataSetClick DataSetClick;

        #endregion

        public ctlInspectionParamter()
        {
            InitializeComponent();
        }

        private void ctlInspectionParamter_Load(object sender, EventArgs e)
        {
            numData = new NumericUpDown[] { numLowVelocity, numHighVelocity, numExcitationCur1, numExcitationCur2, 
                                            numHighModeConstantUp, numLowModeConstantUp,
                                            numHighModeConstantDown , numLowModeConstantDown ,numCycle};
        }

        /// <summary>
        /// 設定ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnWrite_Click(object sender, EventArgs e)
        {
            if (DataSetClick != null)
            {
                int no = int.Parse(this.Tag.ToString());
                DataSetClick(no);
            }
        }

        /// <summary>
        /// 取得ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRead_Click(object sender, EventArgs e)
        {
            if (DataGetClick != null)
            {
                int no = int.Parse(this.Tag.ToString());
                DataGetClick(no);
            }
        }

        private void txtNo_Enter(object sender, EventArgs e)
        {
            txtMotorType.Focus();
        }

        private void num_Enter(object sender, EventArgs e)
        {
            NumericUpDown num = (NumericUpDown)sender;
            CurrentIndex = int.Parse(num.Tag.ToString());   //num.TabIndex;
        }

        private void txtMotorType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                numLowVelocity.Focus();
            }
        }

        private void num_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (CurrentIndex == 8)
                {
                    //送信ボタンへフォーカス
                    BtnWrite.Focus();
                }
                else
                {
                    //次の入力へフォーカス
                    numData[++CurrentIndex].Focus();
                }
            }
        }

        public void SetFocusMotorType()
        {
            txtMotorType.Focus();
        }
    }
}
