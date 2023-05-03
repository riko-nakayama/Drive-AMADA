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
    public partial class OptionPhoto : Form
    {

        #region 変数

        private ctlPhotoParamter[] ctlphoto;

        #endregion

        public OptionPhoto()
        {
            InitializeComponent();
        }

        private void OptionInspection_Load(object sender, EventArgs e)
        {

            ctlphoto = new ctlPhotoParamter[] { PhotoPara1, PhotoPara2, PhotoPara3, PhotoPara4, PhotoPara5,
                                                PhotoPara6, PhotoPara7, PhotoPara8, PhotoPara9, PhotoPara10 };
            //パラメータロード
            if (!GetAllLoadTest())
            {
                MessageBox.Show("動作パラメータを取得に失敗しました。",
                                "動作パラメータ",
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
            PhotoPara1.SetFocusMotorType();
        }

        public static bool GetAllLoadTest()
        {
            int no = 1;
            for (int i = 0; i < InspectionDef.pHotoParamters.Length; i++ , no++)
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

                MessageBox.Show("No." + inspno.ToString() + "の動作パラメータを取得しました。",
                                "動作パラメータ",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No." + inspno.ToString() + "の動作パラメータを取得に失敗しました。",
                                "動作パラメータ",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        private void SetCtlInspectionParamter(int idx)
        {
            ctlphoto[idx].InspectionNo = InspectionDef.pHotoParamters[idx].InspectionNo.ToString();
            ctlphoto[idx].MotorType = InspectionDef.pHotoParamters[idx].MotorType;
            ctlphoto[idx].StartupTlqLow = InspectionDef.pHotoParamters[idx].StartupTlqLow;
            ctlphoto[idx].StartupTlqHigh = InspectionDef.pHotoParamters[idx].StartupTlqHigh;
            ctlphoto[idx].StartupHighSpLow = InspectionDef.pHotoParamters[idx].StartupHighSpLow;
            ctlphoto[idx].StartupHighSpHigh = InspectionDef.pHotoParamters[idx].StartupHighSpHigh;
            ctlphoto[idx].ContiRotateTlqHigh = InspectionDef.pHotoParamters[idx].ContiRotateTlqHigh;
            ctlphoto[idx].ContiRotateSpHigh = InspectionDef.pHotoParamters[idx].ContiRotateSpHigh;
            ctlphoto[idx].ContiRotateTlqCur = InspectionDef.pHotoParamters[idx].ContiRotateTlqCur;
            ctlphoto[idx].ContiRotateSpHighCur = InspectionDef.pHotoParamters[idx].ContiRotateSpHighCur;
        }

        /// <summary>
        /// 試験パラメータ設定
        /// </summary>
        private void InspPara_DataSetClick(int inspno)
        {
            SetInspectionParameters(inspno);
            
            MessageBox.Show("No." + inspno .ToString() + "の動作パラメータを設定しました。",
                            "動作パラメータ",
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

        private void SetInspectionParameters(int photono)
        {
            int i = photono - 1;

            InspectionDef.pHotoParamters[i].MotorType = ctlphoto[i].MotorType;
            InspectionDef.pHotoParamters[i].StartupTlqLow = ctlphoto[i].StartupTlqLow;
            InspectionDef.pHotoParamters[i].StartupTlqHigh = ctlphoto[i].StartupTlqHigh;
            InspectionDef.pHotoParamters[i].StartupHighSpLow = ctlphoto[i].StartupHighSpLow;
            InspectionDef.pHotoParamters[i].StartupHighSpHigh = ctlphoto[i].StartupHighSpHigh;
            InspectionDef.pHotoParamters[i].ContiRotateTlqHigh = ctlphoto[i].ContiRotateTlqHigh;
            InspectionDef.pHotoParamters[i].ContiRotateSpHigh = ctlphoto[i].ContiRotateSpHigh;
            InspectionDef.pHotoParamters[i].ContiRotateTlqCur = ctlphoto[i].ContiRotateTlqCur;
            InspectionDef.pHotoParamters[i].ContiRotateSpHighCur = ctlphoto[i].ContiRotateSpHighCur;

            string strphoto = InspectionDef.pHotoParamters[i].MotorType + "," +
                              InspectionDef.pHotoParamters[i].StartupTlqLow.ToString() + "," +
                              InspectionDef.pHotoParamters[i].StartupTlqHigh.ToString() + "," +
                              InspectionDef.pHotoParamters[i].StartupHighSpLow.ToString("") + "," +
                              InspectionDef.pHotoParamters[i].StartupHighSpHigh.ToString("") + "," +
                              InspectionDef.pHotoParamters[i].ContiRotateTlqHigh.ToString("") + "," +
                              InspectionDef.pHotoParamters[i].ContiRotateSpHigh.ToString("") + "," +
                              InspectionDef.pHotoParamters[i].ContiRotateTlqCur.ToString("F2") + "," +
                              InspectionDef.pHotoParamters[i].ContiRotateSpHighCur.ToString("F2");

            switch (photono)
            {
                case 1:
                    Properties.Settings.Default.Photo1 = strphoto;
                    break;

                case 2:
                    Properties.Settings.Default.Photo2 = strphoto;
                    break;

                case 3:
                    Properties.Settings.Default.Photo3 = strphoto;
                    break;

                case 4:
                    Properties.Settings.Default.Photo4 = strphoto;
                    break;

                case 5:
                    Properties.Settings.Default.Photo5 = strphoto;
                    break;
                
                case 6:
                    Properties.Settings.Default.Photo6 = strphoto;
                    break;
                
                case 7:
                    Properties.Settings.Default.Photo7 = strphoto;
                    break;

                case 8:
                    Properties.Settings.Default.Photo8 = strphoto;
                    break;

                case 9:
                    Properties.Settings.Default.Photo9 = strphoto;
                    break;

                case 10:
                    Properties.Settings.Default.Photo10 = strphoto;
                    break;
            }
        }

        public static bool GetInspectionParameters(int no)
        {
            string[] LoadPhotoTable = new string[] { Properties.Settings.Default.Photo1,
                                                     Properties.Settings.Default.Photo2,
                                                     Properties.Settings.Default.Photo3,
                                                     Properties.Settings.Default.Photo4,
                                                     Properties.Settings.Default.Photo5,
                                                     Properties.Settings.Default.Photo6,
                                                     Properties.Settings.Default.Photo7,
                                                     Properties.Settings.Default.Photo8,
                                                     Properties.Settings.Default.Photo9,
                                                     Properties.Settings.Default.Photo10 };

            string[] strbuf = LoadPhotoTable[no - 1].Split(',');

            if (strbuf.Length != 9) return false;

            int i = no - 1;
            InspectionDef.pHotoParamters[i] = new PhotoParamters();

            InspectionDef.pHotoParamters[i].InspectionNo = no;
            InspectionDef.pHotoParamters[i].MotorType = strbuf[0];

            if (!int.TryParse(strbuf[1], out InspectionDef.pHotoParamters[i].StartupTlqLow)) return false;
            if (!int.TryParse(strbuf[2], out InspectionDef.pHotoParamters[i].StartupTlqHigh)) return false;
            if (!int.TryParse(strbuf[3], out InspectionDef.pHotoParamters[i].StartupHighSpLow)) return false;
            if (!int.TryParse(strbuf[4], out InspectionDef.pHotoParamters[i].StartupHighSpHigh)) return false;
            if (!int.TryParse(strbuf[5], out InspectionDef.pHotoParamters[i].ContiRotateTlqHigh)) return false;
            if (!int.TryParse(strbuf[6], out InspectionDef.pHotoParamters[i].ContiRotateSpHigh)) return false;
            if (!float.TryParse(strbuf[7], out InspectionDef.pHotoParamters[i].ContiRotateTlqCur)) return false;
            if (!float.TryParse(strbuf[8], out InspectionDef.pHotoParamters[i].ContiRotateSpHighCur)) return false;
            
            return true;
        }

        private void BtnDB_Click(object sender, EventArgs e)
        {
            DataBaseDialog dbdlg = new DataBaseDialog();
            dbdlg.ShowDialog();
        }

      
    }

    public class PhotoParamters
    {
        public int InspectionNo;
        public string MotorType;
        public int StartupTlqLow;
        public int StartupTlqHigh;
        public int StartupHighSpLow;
        public int StartupHighSpHigh;
        public int ContiRotateTlqHigh;
        public int ContiRotateSpHigh;
        public float ContiRotateTlqCur;
        public float ContiRotateSpHighCur;

        public PhotoParamters() { }
    
    }
}
