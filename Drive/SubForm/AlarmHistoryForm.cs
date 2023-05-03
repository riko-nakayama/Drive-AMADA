using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Motion_Designer
{
    public partial class AlarmHistoryForm : Form
    {
        static private Point FormPosition = new Point(150, 150);

        private bool _IsExist = new bool();

        static private AlarmHistoryForm _ThisForm;

        private String[,] bk_strAlarmInf;

        public bool IsExist
        {
            get { return _IsExist; }
        }

        static public AlarmHistoryForm ThisForm
        {
            get { return _ThisForm; }
        }

        public bool EnableUpdate
        {
            get
            {
                if (!this.Visible) { return false; }
                if (this.WindowState == FormWindowState.Minimized) { return false; }

                return true;
            }
        }

        public AlarmHistoryForm()
        {
            InitializeComponent();

            _ThisForm = this;
            _IsExist = true;
        }

        private void AlarmHistoryForm_Load(object sender, EventArgs e)
        {
            this.Location = FormPosition;
            btnUpdate.PerformClick();
        }

        private void AlarmHistoryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                FormPosition = this.Location;
            }

            _IsExist = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MainForm.IsUsbConnect)
            {
                this.Cursor = Cursors.WaitCursor;

                SetAlarmHistoryFeedBack();

                this.Cursor = Cursors.Default;
            }
        }

        public void SetAlarmHistoryFeedBack()
        {

            string[] alarminf ={ UserText.AlarmHistory_Item_INF0,       // �װѺ���               
                                 UserText.AlarmHistory_Item_INF1,       // �����N����             
                                 UserText.AlarmHistory_Item_INF2,       // ��������               
                                 UserText.AlarmHistory_Item_INF3,       // ��ײ�ޓd��ONİ�َ���   
                                 UserText.AlarmHistory_Item_INF4,       // ���޽ð��              
                                 UserText.AlarmHistory_Item_INF5,       // ̨����ޯ��d��          
                                 UserText.AlarmHistory_Item_INF6,       // ̨����ޯ����x          
                                 UserText.AlarmHistory_Item_INF7,       // ̨����ޯ��ʒu          
                                 UserText.AlarmHistory_Item_INF8,       // �쓮�d���d��           
                                 UserText.AlarmHistory_Item_INF9,       // ��ײ�މ��x            
                                 UserText.AlarmHistory_Item_INF10,      // �ߕ������(���d��)      
                                 UserText.AlarmHistory_Item_INF11};     // �ߕ������(�w��)

            //������ KASHIYAMA Mode 20190930 Kimura update ������ 
            string[] unit = new string[12];

            if (Properties.Settings.Default.PASSWORD_KASHIYAMA == false)
            {
                unit[0] = "";
                unit[1] = "";
                unit[2] = "";
                unit[3] = UserText.AlarmHistory_MSG_minutes;  // [��]
                unit[4] = "";
                unit[5] = "[0.01Arms]";
                unit[6] = "[rpm]";
                unit[7] = "[pulse]";
                unit[8] = "[0.1V]";
                unit[9] = "[0.1��]";
                unit[10] = "[0.1��]";
                unit[11] = "[0.1��]";
            }
            else
            {
                //KASHIYAMA Mode
                unit[0] = "";
                unit[1] = UserText.AlarmHistory_MSG_minutes;  // [��]
                unit[2] = UserText.AlarmHistory_MSG_minutes;  // [��]
                unit[3] = "";
                unit[4] = "[0.01Arms]";
                unit[5] = "[rpm]";
                unit[6] = "[0.01Arms]";
                unit[7] = "";
                unit[8] = "[0.1V]";
                unit[9] = "[0.1��]";
                unit[10] = "[0.1kW]";
                unit[11] = "[0.1��]";
            }

            //������ KASHIYAMA Mode 20190930 Kimura update ������

            UInt32[] alarm = new UInt32[2];
            string s_alarm = "00000000";

            byte[,] arry_alarm = new byte[2, 4];
           
            int col = 0;
            int row = 0;

            //�A���[���R�[�h����1-2�擾
            alarm[0] = (uint)CMonitor.GetParameter(CParamID.AlarmHistory1);
            alarm[1] = (uint)CMonitor.GetParameter(CParamID.AlarmHistory2);

            //�A���[���R�[�h����ҏW
            for (row = 0; row < 2; row++)
            {
                s_alarm = alarm[row].ToString("X8");

                int idx = 0;
                for (col = 3; col >= 0; col--, idx += 2)
                {
                    arry_alarm[row, col] = Convert.ToByte(s_alarm.Substring(idx, 2), 16);
                }
            }

            int g_idx = 0;
 
            TreeNode[] treeNodeAlarm = new TreeNode[8];
            TreeNode[] treeNodeAlarmSubFolder = new TreeNode[12]; 

            string strnodename = "";
           
            for (row = 0; row < 2; row++)
            {
                for (col = 0; col < 4; col++)
                {
                    byte a_code = arry_alarm[row, col];

                    if (a_code != 0)
                    {
                        if (g_idx == 0)
                        {
                            //�ŐV
                            strnodename = UserText.AlarmHistory_MSG_latest + " : "; //�ŐV�̃A���[��������� : ";
                        }
                        else
                        {
                            //�`��O
                            strnodename = g_idx.ToString() + UserText.AlarmHistory_MSG_times + " : "; //��O�̃A���[��������� : 
                        }

                        //�ڍ׏����擾
                        int idx = 0;
                        string str = "";

                        for (int j = 0; j < 12; j++, idx++, str="")
                        {
                            str = "�E" + alarminf[j] + " : " + GetAlarmInfoContent(g_idx , j) + " " + unit[j];
                            //str = "�E" + alarminf[j] + " : " + "1" + unit[j];
                            treeNodeAlarmSubFolder[j] = new TreeNode(str);
                        }

                        strnodename += AlarmContents(a_code) + "(" + a_code.ToString() + ")";
                        treeNodeAlarm[g_idx] = new TreeNode(strnodename, treeNodeAlarmSubFolder);
                    }

                    g_idx++;
                }
            }

            bool bUpdate = false;

            if (bk_strAlarmInf == null)
            {
                bk_strAlarmInf = new string[8, 12];
                CopyToAlarmInformation(treeNodeAlarm);
                bUpdate = true;
            }
            else
            {
                if (!CheckAlarmInformation(treeNodeAlarm))
                {
                    CopyToAlarmInformation(treeNodeAlarm);
                    bUpdate = true; 
                }
            }

            //�A���[���������̓��e���ύX���ꂽ�ꍇ�́A�X�V
            if (bUpdate)
            {
                treeViewAlarm.Nodes.Clear();
                
                foreach (TreeNode tn in treeNodeAlarm)
                {
                    if (tn != null)
                    {
                        treeViewAlarm.Nodes.Add(tn);
                    }
                }
            }

            if (treeViewAlarm.Nodes.Count == 0)
            {
                //���݁A�A���[�������͂���܂���B
                treeViewAlarm.Nodes.Add(UserText.AlarmHistory_MSG_None);
            }
        }

        private void CopyToAlarmInformation(TreeNode[] _tn)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    if (_tn[i] != null)
                    {
                        bk_strAlarmInf[i, j] = _tn[i].Nodes[j].Text;
                    }
                }
            }
        }

        private bool CheckAlarmInformation(TreeNode[] _tn)
        {
            
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    if (_tn[i] == null)
                    {
                        continue;
                    }

                    if (bk_strAlarmInf[i, j] != _tn[i].Nodes[j].Text)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// �A���[�����擾
        /// </summary>
        /// <param name="_numinf"></param>
        /// <returns></returns>
        private string GetAlarmInfoContent(int _alarmnum, int _numinf)
        {
            string msg = "";
            string tmp_h = "";
            string tmp_l = "";

            int alarminf = (Int16)((_alarmnum << 8) | _numinf);

            Int32 alarmvalue = 0;

            //�A���[�����ݒ�
            if (!CCommandTx.WriteSvNet(CParamID.SelectAlarmHistory, alarminf))
            {
                return "";
            }

            Thread.Sleep(1);
           
            //�A���[�����������擾
            if (!CCommandTx.ReadSvNet(CParamID.AlarmHistoryInf, ref alarmvalue))
            {
                return "";
            }

            msg = alarmvalue.ToString();

            if (_numinf == 1)
            {
				//������ KASHIYAMA Mode 20191010 Nakayama update ������ 
				if (Properties.Settings.Default.PASSWORD_KASHIYAMA == false)
				{
					tmp_h = alarmvalue.ToString("X4").Substring(0, 2);
					tmp_l = alarmvalue.ToString("X4").Substring(2, 2);
					msg = tmp_h + "/" + tmp_l;
				}
				else
				{
					//KASHIYAMA Mode
					msg = alarmvalue.ToString();
				}
				//������ KASHIYAMA Mode 20191010 Nakayama update ������
            }
			else if (_numinf == 2)
			{
				//������ KASHIYAMA Mode 20191010 Nakayama update ������ 
				if (Properties.Settings.Default.PASSWORD_KASHIYAMA == false)
				{
					tmp_h = alarmvalue.ToString("X4").Substring(0, 2);
					tmp_l = alarmvalue.ToString("X4").Substring(2, 2);
					msg = tmp_h + ":" + tmp_l;
				}
				else
				{
					//KASHIYAMA Mode
					msg = alarmvalue.ToString();
				}
				//������ KASHIYAMA Mode 20191010 Nakayama update ������
			}
			else if (_numinf == 3)
			{
				//������ KASHIYAMA Mode 20191010 Nakayama update ������ 
				if (Properties.Settings.Default.PASSWORD_KASHIYAMA == false)
				{
					msg = alarmvalue.ToString();
				}
				else
				{
					//KASHIYAMA Mode
					msg = "0x" + alarmvalue.ToString("X");
				}
				//������ KASHIYAMA Mode 20191010 Nakayama update ������
			}
            else if (_numinf == 4)
            {
                //������ KASHIYAMA Mode 20190930 Kimura update ������ 
                if (Properties.Settings.Default.PASSWORD_KASHIYAMA == false)
                {
                    msg = "0x" + alarmvalue.ToString("X");
                }
                else
                {
                    //KASHIYAMA Mode
                    msg = alarmvalue.ToString();
                }
                //������ KASHIYAMA Mode 20190930 Kimura update ������
            }

            return msg;
        }

        #region �A���[�����e

        /// <summary>
        /// �A���[�����e�擾
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private string AlarmContents(byte _code)
        {
            string strContens = "";

            //������ KASHIYAMA Mode 20190624 Kimura update ������
            if (Properties.Settings.Default.PASSWORD_KASHIYAMA == false)
            {
                switch (_code)
                {
                    case 11:
                        //�ߓd���ُ�
                        strContens = UserText.AlarmHistory_OverCurrent;
                        break;

                    case 21:
                        //�ߕ��׈ُ�
                        strContens = UserText.AlarmHistory_Overload;
                        break;

                    case 31:
                        //�ߑ��x�ُ�
                        strContens = UserText.AlarmHistory_Overspeed;
                        break;

                    case 41:
                        //����]�ُ�
                        strContens = UserText.AlarmHistory_multi;
                        break;

                    case 42:
                        //�ʒu�΍��ߑ�
                        strContens = UserText.AlarmHistory_Position;
                        break;

                    case 51:
                        //�h���C�o���x�ُ�
                        strContens = UserText.AlarmHistory_temp;
                        break;

                    case 61:
                        //�Z���T�ُ�
                        strContens = UserText.AlarmHistory_sensor;
                        break;

                    case 62:
                        //�Z���T�f��
                        strContens = UserText.AlarmHistory_disconnect;
                        break;

                    case 63:
                        //�Z���T�J�E���^�I�[�o�[�t���[�ُ�
                        strContens = UserText.AlarmHistory_overflow;
                        break;

                    case 64:
                        //�Z���T1��]�J�E���^�ُ�
                        strContens = UserText.AlarmHistory_one;
                        break;

                    case 66:
                        //�Z���T�ߑ��x�ُ�
                        strContens = UserText.AlarmHistory_sensorover;
                        break;

                    case 71:
                        //�쓮�d���ߑ�ُ�
                        strContens = UserText.AlarmHistory_drivervoltage;
                        break;

                    case 72:
                        //�쓮�d���ቺ�ُ�
                        strContens = UserText.AlarmHistory_drviervoldecrease;
                        break;

                    case 73:
                        //�񐶈ُ�
                        strContens = UserText.AlarmHistory_resurrexction;
                        break;

                    case 75:
                        //����d���d���ቺ�ُ�
                        strContens = UserText.AlarmHistory_control;
                        break;

                    case 81:
                        //�O���ُ�
                        strContens = UserText.AlarmHistory_external;
                        break;

                    case 83:
                        //�����ʐM�ُ�
                        strContens = UserText.AlarmHistory_Internal;
                        break;

                    case 91:
                        //�s�������������ǂݍ��ُ݈�
                        strContens = UserText.AlarmHistory_memoryread;
                        break;

                    case 92:
                    case 93:
                    case 94:
                        //�s�������������������ُ݈�
                        strContens = UserText.AlarmHistory_memorywrite;
                        break;

                    case 98:
                        //�b�o�t�ُ�
                        strContens = UserText.AlarmHistory_CPU;
                        break;

                    case 99:
                        //�p�����[�^�ُ�
                        strContens = UserText.AlarmHistory_Parameter;
                        break;
                }
            }
            else
            {
                #region KASHIYAMA Mode

                switch (_code)
                {
                    case 11:
                        //�ߓd���ُ�
                        strContens = "�p���[�f�q�ُ�";
                        break;

                    case 22:
                        //�ߕ��׈ُ�
                        strContens = UserText.AlarmHistory_Overload;
                        break;

                    case 23:
                        strContens = "�|���v�ُ�";
                        break;

                    case 24:
                        strContens = "�ᑬ�x�ُ�";
                        break;

                    case 25:
                        strContens = "�����b�N�ُ�";
                        break;

                    case 31:
                        //�ߑ��x�ُ�
                        strContens = UserText.AlarmHistory_Overspeed;
                        break;
                    
                    case 32:
                        strContens = "�t��]�ُ�";
                        break;

                    case 51:
                        //�h���C�o���x�ُ�
                        strContens = UserText.AlarmHistory_temp;
                        break;

                    case 61:
                        //�Z���T�ُ�
                        strContens = UserText.AlarmHistory_sensor;
                        break;

                    case 71:
                        strContens = "�ߓd���ُ�1(���]����)";
                        break;

                    case 72:
                        strContens = "�d���ቺ�ُ�";
                        break;
                    
                    case 74:
                        strContens = "�߉񐶈ُ�";
                        break;

                    //������ KASHIYAMA Mode 20190930 Kimura add ������ 
                    case 75:
                        strContens = "�d���ቺ�ُ�2";
                        break;
                    //������ KASHIYAMA Mode 20190930 Kimura add ������

                    case 76:
                        strContens = "�ߓd���ُ�2(�t�]�N��)";
                        break;

                    case 77:
                        strContens = "�쓮�d���f�ُ�";
                        break;

                    case 78:
                        strContens = "�d�������ُ�";
                        break;

                    case 81:
                        //�O���ُ�
                        strContens = UserText.AlarmHistory_external;
                        break;
                    
                    case 91:
                        strContens = "EEPROM�ǂݍ��ُ݈�";
                        break;

                    case 92:
                        strContens = "EEPROM�������ُ݈�";
                        break;

                    case 94:
                        //�b�o�t�ُ�
                        strContens = UserText.AlarmHistory_CPU;
                        break;

                    case 95:
                        strContens = "��H�ُ�";
                        break;

                    case 96:
                        strContens = "�h���C�o�ُ�";
                        break;

                    case 99:
                        strContens = "�p�����[�^�ُ�";
                        break;

                    //������ KASHIYAMA Mode 20190624 Kimura add ������
                }
                #endregion
            }

            //������ KASHIYAMA Mode 20190624 Kimura update ������

            return strContens;
        }

        #endregion

        #region �J���`�����\�[�X�؂�ւ�

        public void ViewCultureResouceChanged()
        {

            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AlarmHistoryForm));

            if (treeViewAlarm.Nodes.Count > 0)
            {
                treeViewAlarm.Nodes.Clear();
            }

            this.Font = (Font)resources.GetObject("$this.Font");

            btnUpdate.Font = (Font)resources.GetObject("btnUpdate.Font");
            treeViewAlarm.Font = (Font)resources.GetObject("treeViewAlarm.Font");

            this.Text = resources.GetString("$this.Text");
            btnUpdate.Text = resources.GetString("btnUpdate.Text");

            switch (Culture.Name)
            {
                default:
                case Culture.JP:
                case Culture.CN:
                    this.Size = new Size(367, 523);
                    break;

                case Culture.US:
                    this.Size = new Size(576, 523);
                    break;
            }

            btnUpdate.PerformClick();
        }

        #endregion
      
    }
}