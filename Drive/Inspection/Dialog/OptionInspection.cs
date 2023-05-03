using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Motion_Designer
{
    public partial class OptionInspection : Form
    {

        #region 変数

        private ctlInspectionParamter[] ctlinsp;

        #endregion

        public OptionInspection()
        {
            InitializeComponent();
        }

        private void OptionInspection_Load(object sender, EventArgs e)
        {
            //for (int i = 0; i < TblLayoutPnlHigh.ColumnStyles.Count; i++)
            //{
            //    TblLayoutPnlHigh.ColumnStyles[i].Width = 59f;
            //}

            //for (int i = 0; i < TblLayoutPnlLow.RowStyles.Count; i++)
            //{
            //    TblLayoutPnlLow.ColumnStyles[i].Width = 59f;
            //}

            ctlinsp = new ctlInspectionParamter[] { InspPara1, InspPara2, InspPara3, InspPara4, InspPara5, 
                                                    InspPara6, InspPara7, InspPara8, InspPara9, InspPara10 };
            //パラメータロード
            if (!GetAllLoadTest())
            {
                MessageBox.Show("試験パラメータを取得に失敗しました。",
                                "試験パラメータ",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                this.Close();
            }
            else
            {
                for (int i = 0; i < InspectionForm.insppara.Length; i++)
                {
                    SetCtlInspectionParamter(i);
                }
            }

        }

        private void OptionInspection_Shown(object sender, EventArgs e)
        {
            InspPara1.SetFocusMotorType();
        }

        public static bool GetAllLoadTest()
        {
            int no = 1;
            for (int i = 0; i < InspectionForm.insppara.Length; i++ , no++)
            {
                if (!GetInspectionParameters(no)) return false;
            }

            return true;
        }

        /// <summary>
        /// 検査パラメータ取得
        /// </summary>
        private void InspPara_DataGetClick(int inspno)
        {
            if (GetInspectionParameters(inspno))
            {
                SetCtlInspectionParamter(inspno - 1);

                MessageBox.Show("No." + inspno.ToString() + "の試験パラメータを取得しました。",
                                "試験パラメータ",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No." + inspno.ToString() + "の試験パラメータを取得に失敗しました。",
                                "試験パラメータ",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        private void SetCtlInspectionParamter(int idx)
        {
            ctlinsp[idx].InspectionNo = InspectionForm.insppara[idx].InspectionNo.ToString();
            ctlinsp[idx].MotorType = InspectionForm.insppara[idx].MotorType;
            ctlinsp[idx].LowVelocity = InspectionForm.insppara[idx].LowVelocity;
            ctlinsp[idx].HighVelocity = InspectionForm.insppara[idx].HighVelocity;
            ctlinsp[idx].ExcitationCur1 = InspectionForm.insppara[idx].ExcitationCur1;
            ctlinsp[idx].ExcitationCur2 = InspectionForm.insppara[idx].ExcitationCur2;
            ctlinsp[idx].HighModeUp = InspectionForm.insppara[idx].HighModeUp;
            ctlinsp[idx].HighModeConstantUp = InspectionForm.insppara[idx].HighModeConstantUp;
            ctlinsp[idx].HighModeDown = InspectionForm.insppara[idx].HighModeDown;
            ctlinsp[idx].LowModeUp = InspectionForm.insppara[idx].LowModeUp;
            ctlinsp[idx].LowModeConstantUp = InspectionForm.insppara[idx].LowModeConstantUp;
            ctlinsp[idx].LowModeDown = InspectionForm.insppara[idx].LowModeDown;
            ctlinsp[idx].HighModeConstantDown = InspectionForm.insppara[idx].HighModeConstantDown;
            ctlinsp[idx].LowModeConstantDown = InspectionForm.insppara[idx].LowModeConstantDown;
            ctlinsp[idx].Cycle = InspectionForm.insppara[idx].Cycle;
        }

        /// <summary>
        /// 試験パラメータ設定
        /// </summary>
        private void InspPara_DataSetClick(int inspno)
        {
            SetInspectionParameters(inspno);
            
            MessageBox.Show("No." + inspno .ToString() + "の試験パラメータを設定しました。",
                            "試験パラメータ",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);   
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SetInspectionParameters(int inspno)
        {
            int i = inspno - 1;
            
            InspectionForm.insppara[i].MotorType = ctlinsp[i].MotorType;
            InspectionForm.insppara[i].LowVelocity = ctlinsp[i].LowVelocity;
            InspectionForm.insppara[i].HighVelocity = ctlinsp[i].HighVelocity;
            InspectionForm.insppara[i].ExcitationCur1 = ctlinsp[i].ExcitationCur1;
            InspectionForm.insppara[i].ExcitationCur2 = ctlinsp[i].ExcitationCur2;
            InspectionForm.insppara[i].HighModeUp = ctlinsp[i].HighModeUp;
            InspectionForm.insppara[i].HighModeConstantUp = ctlinsp[i].HighModeConstantUp;
            InspectionForm.insppara[i].HighModeDown = ctlinsp[i].HighModeDown;
            InspectionForm.insppara[i].LowModeUp = ctlinsp[i].LowModeUp;
            InspectionForm.insppara[i].LowModeConstantUp = ctlinsp[i].LowModeConstantUp;
            InspectionForm.insppara[i].LowModeDown = ctlinsp[i].LowModeDown;
            InspectionForm.insppara[i].HighModeConstantDown = ctlinsp[i].HighModeConstantDown;
            InspectionForm.insppara[i].LowModeConstantDown = ctlinsp[i].LowModeConstantDown;

            InspectionForm.insppara[i].Cycle = ctlinsp[i].Cycle;

            string strinsp = InspectionForm.insppara[i].MotorType + "," +
                             InspectionForm.insppara[i].LowVelocity.ToString() + "," +
                             InspectionForm.insppara[i].HighVelocity.ToString() + "," +
                             InspectionForm.insppara[i].ExcitationCur1.ToString("F2") + "," +
                             InspectionForm.insppara[i].ExcitationCur2.ToString("F2") + "," +
                             InspectionForm.insppara[i].HighModeUp.ToString("F2") + "," +
                             InspectionForm.insppara[i].HighModeConstantUp.ToString("F2") + "," +
                             InspectionForm.insppara[i].HighModeDown.ToString("F2") + "," +
                             InspectionForm.insppara[i].LowModeUp.ToString("F2") + "," +
                             InspectionForm.insppara[i].LowModeConstantUp.ToString("F2") + "," +
                             InspectionForm.insppara[i].LowModeDown.ToString("F2") + "," +
                             InspectionForm.insppara[i].HighModeConstantDown.ToString("F2") + "," +
                             InspectionForm.insppara[i].LowModeConstantDown.ToString("F2") + "," +
                             InspectionForm.insppara[i].Cycle.ToString();

            switch (inspno)
            {
                case 1:
                    Properties.Settings.Default.Inspection1 = strinsp;
                    break;

                case 2:
                    Properties.Settings.Default.Inspection2 = strinsp;
                    break;

                case 3:
                    Properties.Settings.Default.Inspection3 = strinsp;
                    break;

                case 4:
                    Properties.Settings.Default.Inspection4 = strinsp;
                    break;

                case 5:
                    Properties.Settings.Default.Inspection5 = strinsp;
                    break;
                
                case 6:
                    Properties.Settings.Default.Inspection6 = strinsp;
                    break;
                
                case 7:
                    Properties.Settings.Default.Inspection7 = strinsp;
                    break;

                case 8:
                    Properties.Settings.Default.Inspection8 = strinsp;
                    break;

                case 9:
                    Properties.Settings.Default.Inspection9 = strinsp;
                    break;

                case 10:
                    Properties.Settings.Default.Inspection10 = strinsp;
                    break;
            }
        }

        public static bool GetInspectionParameters(int no)
        {
            string[] LoadTestTable = new string[] { Properties.Settings.Default.Inspection1,
                                                    Properties.Settings.Default.Inspection2,
                                                    Properties.Settings.Default.Inspection3,
                                                    Properties.Settings.Default.Inspection4,
                                                    Properties.Settings.Default.Inspection5,
                                                    Properties.Settings.Default.Inspection6,
                                                    Properties.Settings.Default.Inspection7,
                                                    Properties.Settings.Default.Inspection8,
                                                    Properties.Settings.Default.Inspection9,
                                                    Properties.Settings.Default.Inspection10 };

            string[] strbuf = LoadTestTable[no - 1].Split(',');

            //if (strbuf.Length != 11 && strbuf.Length != 14) return false;

            int i = no - 1;
            InspectionForm.insppara[i] = new InspParamters();

            InspectionForm.insppara[i].InspectionNo = no;
            InspectionForm.insppara[i].MotorType = strbuf[0];

            if (!int.TryParse(strbuf[1], out InspectionForm.insppara[i].LowVelocity)) return false;
            if (!int.TryParse(strbuf[2], out InspectionForm.insppara[i].HighVelocity)) return false;
            if (!float.TryParse(strbuf[3], out InspectionForm.insppara[i].ExcitationCur1)) return false;
            if (!float.TryParse(strbuf[4], out InspectionForm.insppara[i].ExcitationCur2)) return false;
            if (!float.TryParse(strbuf[5], out InspectionForm.insppara[i].HighModeUp)) return false;
            if (!float.TryParse(strbuf[6], out InspectionForm.insppara[i].HighModeConstantUp)) return false;
            if (!float.TryParse(strbuf[7], out InspectionForm.insppara[i].HighModeDown)) return false;
            if (!float.TryParse(strbuf[8], out InspectionForm.insppara[i].LowModeUp)) return false;
            if (!float.TryParse(strbuf[9], out InspectionForm.insppara[i].LowModeConstantUp)) return false;
            if (!float.TryParse(strbuf[10], out InspectionForm.insppara[i].LowModeDown)) return false;
            
            if (strbuf.Length == 14)
            {
                if (!float.TryParse(strbuf[11], out InspectionForm.insppara[i].HighModeConstantDown)) return false;
                if (!float.TryParse(strbuf[12], out InspectionForm.insppara[i].LowModeConstantDown)) return false;
                if (!int.TryParse(strbuf[13], out InspectionForm.insppara[i].Cycle)) return false;
            }
            else
            {
                InspectionForm.insppara[i].HighModeConstantDown = 0f;
                InspectionForm.insppara[i].LowModeConstantDown = 0f;
                InspectionForm.insppara[i].Cycle = 0;
            }

            return true;
        }

        private void BtnDB_Click(object sender, EventArgs e)
        {
            DataBaseDialog dbdlg = new DataBaseDialog();
            dbdlg.ShowDialog();
        }
    }

    public class InspParamters
    {
        public int InspectionNo;
        public string MotorType;
        public int LowVelocity;
        public int HighVelocity;
        public float ExcitationCur1;
        public float ExcitationCur2;
        public float HighModeUp;
        public float HighModeConstantUp;
        public float HighModeDown;
        public float LowModeUp;
        public float LowModeConstantUp;
        public float LowModeDown;
        public float HighModeConstantDown;
        public float LowModeConstantDown;
        public int Cycle;

        public InspParamters() { }
    
    }
}
