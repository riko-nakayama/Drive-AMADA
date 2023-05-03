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

            string[] alarminf ={ UserText.AlarmHistory_Item_INF0,       // ｱﾗｰﾑｺｰﾄﾞ               
                                 UserText.AlarmHistory_Item_INF1,       // 発生年月日             
                                 UserText.AlarmHistory_Item_INF2,       // 発生時分               
                                 UserText.AlarmHistory_Item_INF3,       // ﾄﾞﾗｲﾊﾞ電源ONﾄｰﾀﾙ時間   
                                 UserText.AlarmHistory_Item_INF4,       // ｻｰﾎﾞｽﾃｰﾀｽ              
                                 UserText.AlarmHistory_Item_INF5,       // ﾌｨｰﾄﾞﾊﾞｯｸ電流          
                                 UserText.AlarmHistory_Item_INF6,       // ﾌｨｰﾄﾞﾊﾞｯｸ速度          
                                 UserText.AlarmHistory_Item_INF7,       // ﾌｨｰﾄﾞﾊﾞｯｸ位置          
                                 UserText.AlarmHistory_Item_INF8,       // 駆動電源電圧           
                                 UserText.AlarmHistory_Item_INF9,       // ﾄﾞﾗｲﾊﾞ温度            
                                 UserText.AlarmHistory_Item_INF10,      // 過負荷ﾓﾆﾀ(実電流)      
                                 UserText.AlarmHistory_Item_INF11};     // 過負荷ﾓﾆﾀ(指令)

            //↓↓↓ KASHIYAMA Mode 20190930 Kimura update ↓↓↓ 
            string[] unit = new string[12];

            if (Properties.Settings.Default.PASSWORD_KASHIYAMA == false)
            {
                unit[0] = "";
                unit[1] = "";
                unit[2] = "";
                unit[3] = UserText.AlarmHistory_MSG_minutes;  // [分]
                unit[4] = "";
                unit[5] = "[0.01Arms]";
                unit[6] = "[rpm]";
                unit[7] = "[pulse]";
                unit[8] = "[0.1V]";
                unit[9] = "[0.1℃]";
                unit[10] = "[0.1％]";
                unit[11] = "[0.1％]";
            }
            else
            {
                //KASHIYAMA Mode
                unit[0] = "";
                unit[1] = UserText.AlarmHistory_MSG_minutes;  // [分]
                unit[2] = UserText.AlarmHistory_MSG_minutes;  // [分]
                unit[3] = "";
                unit[4] = "[0.01Arms]";
                unit[5] = "[rpm]";
                unit[6] = "[0.01Arms]";
                unit[7] = "";
                unit[8] = "[0.1V]";
                unit[9] = "[0.1℃]";
                unit[10] = "[0.1kW]";
                unit[11] = "[0.1％]";
            }

            //↑↑↑ KASHIYAMA Mode 20190930 Kimura update ↑↑↑

            UInt32[] alarm = new UInt32[2];
            string s_alarm = "00000000";

            byte[,] arry_alarm = new byte[2, 4];
           
            int col = 0;
            int row = 0;

            //アラームコード履歴1-2取得
            alarm[0] = (uint)CMonitor.GetParameter(CParamID.AlarmHistory1);
            alarm[1] = (uint)CMonitor.GetParameter(CParamID.AlarmHistory2);

            //アラームコード履歴編集
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
                            //最新
                            strnodename = UserText.AlarmHistory_MSG_latest + " : "; //最新のアラーム発生情報 : ";
                        }
                        else
                        {
                            //～回前
                            strnodename = g_idx.ToString() + UserText.AlarmHistory_MSG_times + " : "; //回前のアラーム発生情報 : 
                        }

                        //詳細情報を取得
                        int idx = 0;
                        string str = "";

                        for (int j = 0; j < 12; j++, idx++, str="")
                        {
                            str = "・" + alarminf[j] + " : " + GetAlarmInfoContent(g_idx , j) + " " + unit[j];
                            //str = "・" + alarminf[j] + " : " + "1" + unit[j];
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

            //アラーム履歴情報の内容が変更された場合は、更新
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
                //現在、アラーム履歴はありません。
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
        /// アラーム情報取得
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

            //アラーム情報設定
            if (!CCommandTx.WriteSvNet(CParamID.SelectAlarmHistory, alarminf))
            {
                return "";
            }

            Thread.Sleep(1);
           
            //アラーム発生時情報取得
            if (!CCommandTx.ReadSvNet(CParamID.AlarmHistoryInf, ref alarmvalue))
            {
                return "";
            }

            msg = alarmvalue.ToString();

            if (_numinf == 1)
            {
				//↓↓↓ KASHIYAMA Mode 20191010 Nakayama update ↓↓↓ 
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
				//↑↑↑ KASHIYAMA Mode 20191010 Nakayama update ↑↑↑
            }
			else if (_numinf == 2)
			{
				//↓↓↓ KASHIYAMA Mode 20191010 Nakayama update ↓↓↓ 
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
				//↑↑↑ KASHIYAMA Mode 20191010 Nakayama update ↑↑↑
			}
			else if (_numinf == 3)
			{
				//↓↓↓ KASHIYAMA Mode 20191010 Nakayama update ↓↓↓ 
				if (Properties.Settings.Default.PASSWORD_KASHIYAMA == false)
				{
					msg = alarmvalue.ToString();
				}
				else
				{
					//KASHIYAMA Mode
					msg = "0x" + alarmvalue.ToString("X");
				}
				//↑↑↑ KASHIYAMA Mode 20191010 Nakayama update ↑↑↑
			}
            else if (_numinf == 4)
            {
                //↓↓↓ KASHIYAMA Mode 20190930 Kimura update ↓↓↓ 
                if (Properties.Settings.Default.PASSWORD_KASHIYAMA == false)
                {
                    msg = "0x" + alarmvalue.ToString("X");
                }
                else
                {
                    //KASHIYAMA Mode
                    msg = alarmvalue.ToString();
                }
                //↑↑↑ KASHIYAMA Mode 20190930 Kimura update ↑↑↑
            }

            return msg;
        }

        #region アラーム内容

        /// <summary>
        /// アラーム内容取得
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private string AlarmContents(byte _code)
        {
            string strContens = "";

            //↓↓↓ KASHIYAMA Mode 20190624 Kimura update ↓↓↓
            if (Properties.Settings.Default.PASSWORD_KASHIYAMA == false)
            {
                switch (_code)
                {
                    case 11:
                        //過電流異常
                        strContens = UserText.AlarmHistory_OverCurrent;
                        break;

                    case 21:
                        //過負荷異常
                        strContens = UserText.AlarmHistory_Overload;
                        break;

                    case 31:
                        //過速度異常
                        strContens = UserText.AlarmHistory_Overspeed;
                        break;

                    case 41:
                        //多回転異常
                        strContens = UserText.AlarmHistory_multi;
                        break;

                    case 42:
                        //位置偏差過大
                        strContens = UserText.AlarmHistory_Position;
                        break;

                    case 51:
                        //ドライバ温度異常
                        strContens = UserText.AlarmHistory_temp;
                        break;

                    case 61:
                        //センサ異常
                        strContens = UserText.AlarmHistory_sensor;
                        break;

                    case 62:
                        //センサ断線
                        strContens = UserText.AlarmHistory_disconnect;
                        break;

                    case 63:
                        //センサカウンタオーバーフロー異常
                        strContens = UserText.AlarmHistory_overflow;
                        break;

                    case 64:
                        //センサ1回転カウンタ異常
                        strContens = UserText.AlarmHistory_one;
                        break;

                    case 66:
                        //センサ過速度異常
                        strContens = UserText.AlarmHistory_sensorover;
                        break;

                    case 71:
                        //駆動電圧過大異常
                        strContens = UserText.AlarmHistory_drivervoltage;
                        break;

                    case 72:
                        //駆動電圧低下異常
                        strContens = UserText.AlarmHistory_drviervoldecrease;
                        break;

                    case 73:
                        //回生異常
                        strContens = UserText.AlarmHistory_resurrexction;
                        break;

                    case 75:
                        //制御電源電圧低下異常
                        strContens = UserText.AlarmHistory_control;
                        break;

                    case 81:
                        //外部異常
                        strContens = UserText.AlarmHistory_external;
                        break;

                    case 83:
                        //内部通信異常
                        strContens = UserText.AlarmHistory_Internal;
                        break;

                    case 91:
                        //不揮発性メモリ読み込み異常
                        strContens = UserText.AlarmHistory_memoryread;
                        break;

                    case 92:
                    case 93:
                    case 94:
                        //不揮発性メモリ書き込み異常
                        strContens = UserText.AlarmHistory_memorywrite;
                        break;

                    case 98:
                        //ＣＰＵ異常
                        strContens = UserText.AlarmHistory_CPU;
                        break;

                    case 99:
                        //パラメータ異常
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
                        //過電流異常
                        strContens = "パワー素子異常";
                        break;

                    case 22:
                        //過負荷異常
                        strContens = UserText.AlarmHistory_Overload;
                        break;

                    case 23:
                        strContens = "ポンプ異常";
                        break;

                    case 24:
                        strContens = "低速度異常";
                        break;

                    case 25:
                        strContens = "軸ロック異常";
                        break;

                    case 31:
                        //過速度異常
                        strContens = UserText.AlarmHistory_Overspeed;
                        break;
                    
                    case 32:
                        strContens = "逆回転異常";
                        break;

                    case 51:
                        //ドライバ温度異常
                        strContens = UserText.AlarmHistory_temp;
                        break;

                    case 61:
                        //センサ異常
                        strContens = UserText.AlarmHistory_sensor;
                        break;

                    case 71:
                        strContens = "過電圧異常1(正転動作)";
                        break;

                    case 72:
                        strContens = "電圧低下異常";
                        break;
                    
                    case 74:
                        strContens = "過回生異常";
                        break;

                    //↓↓↓ KASHIYAMA Mode 20190930 Kimura add ↓↓↓ 
                    case 75:
                        strContens = "電圧低下異常2";
                        break;
                    //↑↑↑ KASHIYAMA Mode 20190930 Kimura add ↑↑↑

                    case 76:
                        strContens = "過電圧異常2(逆転起動)";
                        break;

                    case 77:
                        strContens = "駆動電源断異常";
                        break;

                    case 78:
                        strContens = "電源欠相異常";
                        break;

                    case 81:
                        //外部異常
                        strContens = UserText.AlarmHistory_external;
                        break;
                    
                    case 91:
                        strContens = "EEPROM読み込み異常";
                        break;

                    case 92:
                        strContens = "EEPROM書き込み異常";
                        break;

                    case 94:
                        //ＣＰＵ異常
                        strContens = UserText.AlarmHistory_CPU;
                        break;

                    case 95:
                        strContens = "回路異常";
                        break;

                    case 96:
                        strContens = "ドライバ異常";
                        break;

                    case 99:
                        strContens = "パラメータ異常";
                        break;

                    //↑↑↑ KASHIYAMA Mode 20190624 Kimura add ↑↑↑
                }
                #endregion
            }

            //↑↑↑ KASHIYAMA Mode 20190624 Kimura update ↑↑↑

            return strContens;
        }

        #endregion

        #region カルチャリソース切り替え

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