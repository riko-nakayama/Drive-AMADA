using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Motion_Designer
{
	public partial class SplashForm : Form
	{
		public static SplashForm _sform = null;

		public SplashForm()
		{
			InitializeComponent();
		}

		public static void ShowSplash()
		{
			if (_sform == null)
			{
                //Application.Idle += new EventHandler(Application_Idle);
				_sform = new SplashForm();
				//アプリケーションのバージョン情報をスプラッシュ画面に設定する
				string major = Assembly.GetExecutingAssembly().GetName().Version.Major.ToString();
				string minor = Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString("D2");
				//_sform.lblVersion.Text = String.Format("Version {0}", Assembly.GetExecutingAssembly().GetName().Version.ToString());
				_sform.lblVersion.Text = String.Format("Version {0}", major + "." + minor);
				_sform.Show();
				_sform.Update();

                _sform.label2.Location = new Point(230, 165); // Ver1.33 Add

				if (Properties.Settings.Default.PASSWORD_KASHIYAMA)
				{
					_sform.label2.Visible = true;
					_sform.label2.Text = "for TAD170";
					_sform.Refresh();
				}
                //↓↓↓ AMADA Mode 20200601 Kimura add ↓↓↓
                else if (Properties.Settings.Default.PASSWORD_AMADA)
                {
                    _sform.label2.Visible = true;
                    _sform.label2.Text = "for TAD5048";
                    _sform.Refresh();
                }
                //↑↑↑  AMADA Mode 20200601 Kimura add ↑↑↑
                
                //↓↓↓ TAD8821 Mode 20220921 Kimura add ↓↓↓
                else if (Properties.Settings.Default.PASSWORD_TAD8821)
                {
                    _sform.label2.Visible = true;
                    _sform.label2.Text = "for TAD8821";
                    _sform.Refresh();
                }
                //↑↑↑  TAD8821 Mode 20220921 Kimura add ↑↑↑

                //↓↓↓ Ver 1.33 add ↓↓↓
                else if (Properties.Settings.Default.PASSWORD_AMADATEST)
                {
                    _sform.label2.Visible = true;
                    _sform.label2.Location = new Point(140, 165); 
                    _sform.label2.Text = "for TAD5048 Inspection";
                    _sform.Refresh();
                }
                //↑↑↑ Ver1.33 add ↑↑↑
			}
		}

		public static void AddOpacity(double op)
		{
			_sform.Opacity += op;
		}

		public static double GetOpacity()
		{
			return _sform.Opacity;
		}

		public static void CloseSplash()
		{
			_sform.Close();
		}

		public static void RefreshSplash()
		{
			//_sform.Refresh();

			_sform.lblLoading.Refresh();
		}

		static void Application_Idle(object sender, EventArgs e)
		{
			//throw new Exception("The method or operation is not implemented.");

			if (_sform != null)
			{
				_sform.Close();
			}

			_sform = null;

			Application.Idle -= new EventHandler(Application_Idle);

		}

		static public string NowLoadingText
		{
			set
			{
				_sform.lblLoading.Text = value;
			}

		}
	}
}