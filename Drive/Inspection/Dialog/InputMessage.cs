using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Motion_Designer
{
    #pragma warning disable IDE1006

    public partial class InputMessage : Form
    {
        #region プロパティ

        public string Message
        {
            set { lblMessage.Text = value; }
            get { return lblMessage.Text; }
        }

        public string Unit
        {
            set { lblUnit.Text = value; }
            get { return lblUnit.Text; }
        }

        #endregion

        public float Minimum = 0;
        public float Maximum = 0;

        public float Value = 0;

        public InputMessage()
        {
            InitializeComponent();
        }

        private void frmInput_Shown(object sender, EventArgs e)
        {
            txtValue.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (float.TryParse(txtValue.Text, out Value))
            {

                if (MessageBox.Show("測定値：" + Value.ToString("F1") + Unit + Environment.NewLine +
                                    "よろしいですか？",
                                    "測定値入力",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.OK;

                    //if (Minimum <= Value && Maximum >= Value)
                    //{
                    //    //PASS
                    //    this.DialogResult = DialogResult.OK;
                    //}
                    //else
                    //{
                    //    // Fail
                    //    this.DialogResult = DialogResult.Cancel;
                    //}
                }
                else
                {

                    this.DialogResult = DialogResult.Cancel;
                    
                    //txtValue.SelectAll();
                    //txtValue.Focus();
                }
            }
            else
            {
                MessageBox.Show(this,
                          "測定結果の入力が不正です。" + Environment.NewLine +
                          "数値を入力してください。",
                          "入力不正",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Warning);

                txtValue.SelectAll();
                txtValue.Focus();
            }
        }
    }
}