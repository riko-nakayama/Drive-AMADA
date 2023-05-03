using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace Motion_Designer
{
	public partial class OptionSettingDialog : Form
	{
		static public string CultureName = string.Empty;

		private decimal BackupLogPeriod = new decimal();

		public OptionSettingDialog()
		{
			InitializeComponent();
		}

		private void btnParamPassword_Click(object sender, EventArgs e)
		{
			PasswordDialog f = new PasswordDialog();

			f.TopMost = true;
			DialogResult ret = f.ShowDialog();

			if (ret == DialogResult.OK)
			{
				//20161102 update
				bool release = new bool();

				//一時解除用パスワード
				if (f.PasswordText == "5555")
				{
					Properties.Settings.Default.PASSWORD_TEMP = true;
					UserMessageBox.OptionPasswordReleaseSuccess();
					release = true;
				}
	
				//永久解除用パスワード
				if (f.PasswordText == "55555555")
				{
					Properties.Settings.Default.PASSWORD_LOCK = true;
					UserMessageBox.OptionPasswordReleaseSuccess();
					release = true;
				}

				//簡易プログラムテーブル表示解除パスワード 20170215 add
				if (f.PasswordText.ToUpper() == "TRI")
				{
					Properties.Settings.Default.PASSWORD_TRI = true;
					UserMessageBox.OptionPasswordReleaseSuccess();
					release = true;
				}

				//↓↓↓ ART HIKARI Mode 20170919 Kimura add ↓↓↓
				if (f.PasswordText.ToUpper() == "HIKARI")
				{
					Properties.Settings.Default.PASSWORD_HIKARI = true;

                    //↓↓↓ ART HIKARI Mode 20181210 Kimura update ↓↓↓

                    //中国語でART HIKARI Modeに変更した場合は、強制的に日本語に変更 
                    //Properties.Settings.Default.CultureType = Culture.JP;

                    if (Properties.Settings.Default.CultureType == Culture.CN)
                    {
                        Properties.Settings.Default.CultureType = Culture.JP;
                    }
                    
                    //↑↑↑ ART HIKARI Mode 20181210 Kimura update ↑↑↑

					UserMessageBox.OptionPasswordReleaseSuccess();
					release = true;
				}
				//↑↑↑ ART HIKARI Mode 20170919 Kimura add ↑↑↑

                //↓↓↓ KASHIYAMA Mode 20190624 Kimura add ↓↓↓
                if (f.PasswordText.ToUpper() == "19510110")
                {
                    Properties.Settings.Default.PASSWORD_KASHIYAMA = true;

                    //英語、中国語でKASHIYAMA Modeに変更した場合は、強制的に日本語に変更 
                    if (Properties.Settings.Default.CultureType == Culture.US ||
                        Properties.Settings.Default.CultureType == Culture.CN)
                    {
                        Properties.Settings.Default.CultureType = Culture.JP;
                    }

                    UserMessageBox.OptionPasswordReleaseSuccess();
                    release = true;
                }
                //↑↑↑ KASHIYAMA Mode 20190624 Kimura add ↑↑↑

                //↓↓↓ AMADA Mode 20200601 Kimura add ↓↓↓
                if (f.PasswordText.ToUpper() == "AMADA")
                {
                    Properties.Settings.Default.PASSWORD_AMADA = true;
                    Properties.Settings.Default.PASSWORD_AMADATEST = false; //vER1.33 Add

                    if (Properties.Settings.Default.CultureType == Culture.US ||
                        Properties.Settings.Default.CultureType == Culture.CN)
                    {
                        Properties.Settings.Default.CultureType = Culture.JP;
                    }

                    UserMessageBox.OptionPasswordReleaseSuccess();
                    release = true;
                }
                //↑↑↑ AMADA Mode 20200601 Kimura add ↑↑↑

                //↓↓↓ Ver 1.32 add ↓↓↓
                if (f.PasswordText.ToUpper() == "TAD8821")
                {
                    Properties.Settings.Default.PASSWORD_TAD8821 = true;

                    UserMessageBox.OptionPasswordReleaseSuccess();
                    release = true;
                }
                //↑↑↑ Ver1.32  add ↑↑↑

                //↓↓↓ Ver 1.33 AMADA Test Mode↓↓↓
                if (f.PasswordText.ToUpper() == "AMADATEST")
                {
                    Properties.Settings.Default.PASSWORD_AMADA = false;
                    Properties.Settings.Default.PASSWORD_AMADATEST = true;

                    if (Properties.Settings.Default.CultureType == Culture.US ||
                        Properties.Settings.Default.CultureType == Culture.CN)
                    {
                        Properties.Settings.Default.CultureType = Culture.JP;
                    }

                    UserMessageBox.OptionPasswordReleaseSuccess();
                    release = true;
                }
                else
                {
                    Properties.Settings.Default.PASSWORD_AMADATEST = false;
                }
                //↑↑↑ Ver 1.33 AMADA Test Mode ↑↑↑

				if( !release )
				{
					Properties.Settings.Default.PASSWORD_TEMP = false;
					Properties.Settings.Default.PASSWORD_LOCK = false;
					Properties.Settings.Default.PASSWORD_TRI = false;
					Properties.Settings.Default.PASSWORD_HIKARI = false;		//20170928 add
                    Properties.Settings.Default.PASSWORD_KASHIYAMA = false;     //KASHIYAMA Mode 20190624 Kimura add
                    Properties.Settings.Default.PASSWORD_AMADA = false;         //AMADA Mode 20200601 Kimura add

                    Properties.Settings.Default.PASSWORD_TAD8821 = false;       //Ver1.32 add

                    Properties.Settings.Default.PASSWORD_AMADATEST = false;     //Ver1.33 add

					UserMessageBox.OptionPasswordReleaseFailure();
				}
			}
		}

		private void btnParamInit_Click(object sender, EventArgs e)
		{
			if (UserMessageBox.OptionParameterInit() == DialogResult.Yes)
			{
				Properties.Settings.Default.Reset();

				Properties.Settings.Default.CultureType = CultureName;

				DigitalOsilloForm.ThisForm.InitAppParameter();

			}
		}

		private void chkCloseMsg_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.CLOSE_MSG_DISABLE = !chkCloseMsg.Checked;
		}

		private void OptionSettingForm_Load(object sender, EventArgs e)
		{
			ChildFormControl.SetOpacity(0.0);
			ChildFormControl.PropertyLock = true;

			CultureInfo culture = new CultureInfo(Properties.Settings.Default.CultureType);

			//カルチャー
			CultureInfo[] cultures = new CultureInfo[] { new CultureInfo(Culture.JP), 
                                                         new CultureInfo(Culture.US), 
                                                         new CultureInfo(Culture.CN) };

			// ComboBoxに取得したカルチャ情報を設定する
			cmbCulture.Items.AddRange(cultures);
			cmbCulture.Text = culture.DisplayName;

			chkCloseMsg.Checked = !Properties.Settings.Default.CLOSE_MSG_DISABLE;

			decimal period = Properties.Settings.Default.MainTimerInterval;

			if (period > numUsbPeriod.Maximum) { period = numUsbPeriod.Maximum; }
			if (period < numUsbPeriod.Minimum) { period = numUsbPeriod.Minimum; }

			numUsbPeriod.Value = period;

			CultureName = Properties.Settings.Default.CultureType;
		
			this.DialogResult = DialogResult.None;

			BackupLogPeriod = numLogPeriod.Value;

            GetDriverCalendar(true);

            TimerCalendar.Enabled = true;

			//↓↓↓ ART HIKARI Mode 20170919 Kimura add ↓↓↓
            if (Properties.Settings.Default.PASSWORD_HIKARI)
            {
                //↓↓↓ ART HIKARI Mode 20181210 Kimura del ↓↓↓
                //lblComNo.Enabled = false;
                //cmbCulture.Enabled = false; 
                //↑↑↑ ART HIKARI Mode 20181210 Kimura del ↑↑↑

                //↓↓↓ ART HIKARI Mode 20181210 Kimura add ↓↓↓
                CultureInfo CNCulture = new CultureInfo(Culture.CN);
                cmbCulture.Items.Remove(CNCulture);
                //↑↑↑ ART HIKARI Mode 20181210 Kimura add ↑↑↑

            }
            //↑↑↑ ART HIKARI Mode 20170919 Kimura add ↑↑↑

            //↓↓↓ KASHIYAMA Mode 20190624 Kimura add ↓↓↓
            else if (Properties.Settings.Default.PASSWORD_KASHIYAMA == true)
            {
                CultureInfo USCulture = new CultureInfo(Culture.US);
                cmbCulture.Items.Remove(USCulture);
                
                CultureInfo CNCulture = new CultureInfo(Culture.CN);
                cmbCulture.Items.Remove(CNCulture);
            }
            else if (Properties.Settings.Default.PASSWORD_AMADA == true)
            {
                CultureInfo USCulture = new CultureInfo(Culture.US);
                cmbCulture.Items.Remove(USCulture);

                CultureInfo CNCulture = new CultureInfo(Culture.CN);
                cmbCulture.Items.Remove(CNCulture);
            }
            // Ver 1.33 add
            else if (Properties.Settings.Default.PASSWORD_AMADATEST == true)
            {
                CultureInfo USCulture = new CultureInfo(Culture.US);
                cmbCulture.Items.Remove(USCulture);

                CultureInfo CNCulture = new CultureInfo(Culture.CN);
                cmbCulture.Items.Remove(CNCulture);
            }

            //↑↑↑ KASHIYAMA Mode 20190624 Kimura add ↑↑↑

        }

        private void OptionSettingForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			ChildFormControl.PropertyLock = false;
			ChildFormControl.SetOpacity(1.0);

			CultureName = cmbCulture.SelectedItem.ToString();
		}

        private void OptionSettingDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            TimerCalendar.Enabled = false;
        }

        private void cmbCulture_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlBase.Focus();
        }

        private void cmbCulture_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbCulture_DropDownClosed(object sender, EventArgs e)
        {
            pnlBase.Focus();
        }

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		private void tabOption_SelectedIndexChanged(object sender, EventArgs e)
		{
			int idx = tabOption.SelectedIndex;

			tabOption.TabPages[idx].Controls.Add(btnOk);
			tabOption.TabPages[idx].Controls.Add(btnCancel);
		}

		private bool DisableNumLogEvent = new bool();

		private void numLogPeriod_ValueChanged(object sender, EventArgs e)
		{
			if (DisableNumLogEvent) { return; }

			DisableNumLogEvent = true;

			decimal now = numLogPeriod.Value;

			if (now == 3)
			{
				if (BackupLogPeriod > now)
				{
					numLogPeriod.Value = 2;
				}
				else
				{
					numLogPeriod.Value = 4;
				}
			}

			BackupLogPeriod = numLogPeriod.Value;

			DisableNumLogEvent = false;

			lblLogPeriod.Select();
		}

		private void numUsbPeriod_ValueChanged(object sender, EventArgs e)
		{
			lblUsbPeriod.Select();
        }

        #region カレンダ

        private void btnNow_Click(object sender, EventArgs e)
        {
            if (!MainForm.IsUsbConnectBlink) { return; }

            //ドライバカレンダーを現在のWidnowsカレンダーの情報で設定します。
            if( UserMessageBox.DriverCalendarSetting() == DialogResult.Yes)
            {

                SetDriverCalendar(DateTime.Today, DateTime.Now);

                GetDriverCalendar(true);
            }
        }

        private void btnSetCalendar_Click(object sender, EventArgs e)
        {
            if (!MainForm.IsUsbConnectBlink) { return; }

            SetDriverCalendar(DatePicker.Value, TimePicker.Value);
            GetDriverCalendar(false);
        }

        private void tabPageCalendar_Enter(object sender, EventArgs e)
        {
            TimerCalendar.Enabled = true;
        }

        private void tabPageCalendar_Leave(object sender, EventArgs e)
        {
            TimerCalendar.Enabled = false;
        }

        private void TimerCalendar_Tick(object sender, EventArgs e)
        {
            if (MainForm.IsUsbConnect)
            {
                GetDriverCalendar(false);
            }
        }

        /// <summary>
        /// カレンダー設定
        /// </summary>
        private void SetDriverCalendar(DateTime _date, DateTime _time)
        {
            uint date = 0;
            uint time = 0;

            DateTime dt;

            //ドライバへ日付設定
            dt = _date; //DatePicker.Value;
            date = 0x88000000 | (uint)((Convert.ToInt32(dt.Year.ToString(), 16) - 0x2000) << 16);
            date |= (uint)(Convert.ToInt32(dt.Month.ToString(), 16) << 8);
            date |= (uint)(Convert.ToInt32(dt.Day.ToString(), 16));

            if (!CCommandTx.WriteSvNet(CParamID.CalendarDate, (int)date))
            {
                //ドライバカレンダー(日付)設定が出来ません
                UserMessageBox.DriverCalendarSettingDateError();
            }
            else
            {
                //ドライバへ時刻設定
                dt = _time;//TimePicker.Value;
                time = 0x88000000 | (uint)(Convert.ToInt32(dt.Hour.ToString(), 16) << 16);
                time |= (uint)(Convert.ToInt32(dt.Minute.ToString(), 16) << 8);
                time |= (uint)(Convert.ToInt32(dt.Second.ToString(), 16));

                if (!CCommandTx.WriteSvNet(CParamID.CalendarTime, (int)time))
                {
                    //ドライバカレンダー(時刻)設定が出来ません。
                    UserMessageBox.DriverCalendarSettingTimeError();
                }
            }
        }

        /// <summary>
        /// カレンダ取得
        /// </summary>
        private void GetDriverCalendar(bool _conupdate)
        {
            string _cal = "0000/00/00 00:00:00";

            if (MainForm.IsUsbConnect)
            {

                int date = 0;
                int time = 0;

                if (!CCommandTx.ReadSvNet(CParamID.CalendarDate, ref date))
                {
                    lblNow.Text = _cal;
                    return;
                }

                if (!CCommandTx.ReadSvNet(CParamID.CalendarTime, ref time))
                {
                    lblNow.Text = _cal;
                    return;
                }

                DriverCalendar.Date(date);
                DriverCalendar.Time(time);

                try
                {
                    //時刻
                    DateTime dt = new DateTime(DriverCalendar.year, DriverCalendar.month, DriverCalendar.day,
                                               DriverCalendar.hour, DriverCalendar.minute, DriverCalendar.second);

                    if (_conupdate)
                    {
                        DatePicker.Value = dt;
                        TimePicker.Value = dt;
                    }

                    _cal = dt.ToString("F");
                }
                catch { }
            }

            //現在の日付時刻を表示する
            lblNow.Text = _cal;
        }

        public static class DriverCalendar
        {
            public static int year = 0;
            public static int month = 0;
            public static int day = 0;

            public static int hour = 0;
            public static int minute = 0;
            public static int second = 0;

            public static void Date(int _date)
            {
                int temp = 0;

                //年
                temp = 0x2000 | ((_date & 0x00ff0000) >> 16);
                year = Convert.ToInt32(temp.ToString("X"), 10);

                //月
                temp = (_date & 0x0000ff00) >> 8;
                month = Convert.ToInt32(temp.ToString("X"), 10);

                //日
                temp = (_date & 0x000000ff);
                day = Convert.ToInt32(temp.ToString("X"), 10);
            }

            public static void Time(int _time)
            {
                int temp = 0;

                //時
                temp = (_time & 0x00ff0000) >> 16;
                hour = Convert.ToInt32(temp.ToString("X"), 10);

                //分
                temp = (_time & 0x0000ff00) >> 8;
                minute = Convert.ToInt32(temp.ToString("X"), 10);

                //秒
                temp = (_time & 0x000000ff);
                second = Convert.ToInt32(temp.ToString("X"), 10);
            }
        }


        #endregion

    }
}