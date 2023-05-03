using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace Motion_Designer
{
	static class Program
	{
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main()
		{
            if (Properties.Settings.Default.CultureType == string.Empty)
            {
                //新規インストールの場合、現在のＯＳカルチャ言語で設定する
                if (CultureInfo.CurrentCulture.Name == Culture.JP || 
                    CultureInfo.CurrentCulture.Name == Culture.US || 
                    CultureInfo.CurrentCulture.Name == Culture.CN)
                {
                    Properties.Settings.Default.CultureType = CultureInfo.CurrentCulture.Name;
                }
                else
                {
                    //それ以外の言語の場合は、強制的に日本語
                    Properties.Settings.Default.CultureType = Culture.JP;
                }
            }

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Properties.Settings.Default.CultureType);
            Culture.Name = Properties.Settings.Default.CultureType;

            Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			SplashForm.ShowSplash();
			Application.Run(new MainForm());
		}
	}
}