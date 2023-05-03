using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
    public partial class ctlPhotoParamter : UserControl
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

        public int StartupTlqLow
        {
            set { numStartupTlqLow.Value = value; }
            get { return (int)numStartupTlqLow.Value; }
        }

        public int StartupTlqHigh
        {
            set { numStartupTlqHigh.Value = value; }
            get { return (int)numStartupTlqHigh.Value; }
        }

        public int StartupHighSpLow
        {
            set { numStartupHighSpLow.Value = (decimal)value; }
            get { return (int)numStartupHighSpLow.Value; }
        }

        public int StartupHighSpHigh
        {
            set { numStartupHighSpHigh.Value = (decimal)value; }
            get { return (int)numStartupHighSpHigh.Value; }
        }

        public int ContiRotateTlqHigh
        {
            set { numContiRotateTlqHigh.Value = (decimal)value; }
            get { return (int)numContiRotateTlqHigh.Value; }
        }     

        public int ContiRotateSpHigh
        {
            set { numContiRotateSpHigh.Value = (decimal)value; }
            get { return (int)numContiRotateSpHigh.Value; }
        }

        public float ContiRotateTlqCur
        {
            set { numContiRotateTlqCur.Value = (decimal)value; }
            get { return (float)numContiRotateTlqCur.Value; }
        }

        public float ContiRotateSpHighCur
        {
            set { numContiRotateSpHighCur.Value = (decimal)value; }
            get { return (float)numContiRotateSpHighCur.Value; }
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

        public ctlPhotoParamter()
        {
            InitializeComponent();
        }

        private void ctlInspectionParamter_Load(object sender, EventArgs e)
        {
            numData = new NumericUpDown[] { numStartupTlqLow, numStartupTlqHigh, numStartupHighSpLow, numStartupHighSpHigh, 
                                            numContiRotateTlqHigh, numContiRotateSpHigh, numContiRotateTlqCur , numContiRotateSpHighCur};
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
            CurrentIndex = int.Parse(num.Tag.ToString());  
        }

        private void txtMotorType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                numStartupTlqLow.Focus();
            }
        }

        private void num_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (CurrentIndex == 7)
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
