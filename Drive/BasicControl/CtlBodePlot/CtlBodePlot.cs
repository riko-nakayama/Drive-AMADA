using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;

namespace Motion_Designer
{
	public partial class CtlBodePlot : UserControl
	{
		public enum EnumBodeType
		{
			GAIN,
			PHASE,
			SIGNAL,
		}

		private Brush BodeBrush = new SolidBrush(Color.Black);

		private Pen BodePen = new Pen(Color.Black, 1.0f);
		private Pen SilverPen = new Pen(Color.Silver, 1.0f);
		private Pen GrayPen = new Pen(Color.Gray, 1.0f);
		private Pen DashPen = new Pen(Color.Silver, 1.0f);
		private Pen GainPen = new Pen(Color.Black, 1.5f);
		private Pen MeasPen = new Pen(Color.DarkGreen, 2.0f);

        //↓↓↓ KASHIYAMA Mode 20200214 Kimura update ↓↓↓
        private Pen FFTHoldPen = new Pen(Color.Black, 1.0f);
        //↑↑↑ KASHIYAMA Mode 20200214 Kimura update ↑↑↑

		private Font BodeFont = AppFont.ArialRegular8;
		private Font ExpFont = AppFont.ArialRegular7;
	
		private float xStartOff = 35.0f;
		private float xEndOff = 10.0f;
		private float yStartOff = 10.0f;
		private float yEndOff = 35.0f;

		//private const int MAX_CH = 3;
		private const int MAX_CH = 2;
		private const int MAX_BUF = 100000;		//バッファー最大数

		private const float LOG_DIV_COE = 1.2F;	//横軸のサイズ調整

		private const int LOG_NUM = 5;			//10^0～10^5まで
		private const int FRQ_NUM = 10000;		//グラフ表示は10^4まで
	
		private int GAIN_OFF  = 55;				//10dB～-40dBまで
		private int GAIN_TOP = 10;				//10dB～-40dBまで
		private int GAIN_END = -40;				//10dB～-40dBまで

		private double SIG_NUM = 200.0;			//100～-100まで
		private double SIG_TOP = 100.0;			//100
		private double SIG_END = -100.0;		//20
		private double SIG_DIV = 20.0;

		private double BK_SIG_TOP = 0.0;
		private double BK_SIG_END = 0.0;
		private double BK_SIG_DIV = 0.0;
	
		private float[][] BodeData = new float[MAX_CH][];
		private float[][] SignalData = new float[MAX_CH][];
		private int[] DrawCount = new int[MAX_CH];

        //↓↓↓ KASHIYAMA Mode 20200214 Kimura update ↓↓↓
        
        private int BKDrawCount = 0;
        private float[][] BKBodeData = new float[5][];
        //↑↑↑ KASHIYAMA Mode 20200214 Kimura update ↑↑↑

		private EnumBodeType _BodeType;

		private bool _IsSweep = new bool();

		private string _Y_Item = string.Empty;
		private string _Y_Unit = string.Empty;

		private bool DisableDrawGraph = new bool();

		private double FFT_ConvertCoeff = new double();

		public CtlBodePlot()
		{
			InitializeComponent();

			for (int i = 0; i < MAX_CH; i++)
			{
				BodeData[i] = new float[MAX_BUF];
				SignalData[i] = new float[MAX_BUF];
				DrawPointX[i] = new float[MAX_BUF];
			}

            //↓↓↓ KASHIYAMA Mode 20200214 Kimura update ↓↓↓
            for (int i = 0; i < BKBodeData.GetLength(0); i++)
            {
                BKBodeData[i] = new float[MAX_BUF];
            }
            //↑↑↑ KASHIYAMA Mode 20200214 Kimura update ↑↑↑

			ctlPlotMenu.ControlStateChanged += new Motion_Designer.CtlPlotMenu.dControlStateChanged(ctlPlotMenu_ControlStateChanged);
			ctlPlotMenu.ValueOffsetChanged += new Motion_Designer.CtlPlotMenu.dValueOffsetChanged(ctlPlotMenu_ValueOffsetChanged);
			ctlPlotMenu.ZoomClicked += new Motion_Designer.CtlPlotMenu.dZoomClicked(ctlPlotMenu_ZoomClicked);
			ctlPlotMenu.ViewCleared += new CtlPlotMenu.dViewCleared(ctlPlotMenu_ViewCleared);
			ctlPlotMenu.ViewHold += new CtlPlotMenu.dViewHold(ctlPlotMenu_ViewHold);
			ctlPlotMenu.ScaleDivisionChanged += new CtlPlotMenu.dScaleDivisionChanged(ctlPlotMenu_ScaleDivisionChanged);

            //↓↓↓ KASHIYAMA Mode 20200214 Kimura update ↓↓↓
            ctlPlotMenu.KashiyamaModeViewHold += new CtlPlotMenu.dKashiyamaModeViewHold(ctlPlotMenu_KashiyamaModeViewHold);
            //↑↑↑ KASHIYAMA Mode 20200214 Kimura update ↑↑↑

			FFT_ConvertCoeff = FFT_C.FFT_ConvertCoeff;
		}

		private void ctlPlotMenu_Load(object sender, EventArgs e)
		{

			List<string> item = new List<string>();
			double x = 0;
			double y = 0;
			
			if (BodeType == EnumBodeType.SIGNAL)
			{
				ctlPlotMenu.EnableZoom = true;
				ctlPlotMenu.EnableOffset = true;

				ctlPlotMenu.ClearOffsetCommbo();

				x = SIG_TOP;
				y = SIG_END;

				AddOffsetCombo(x, y, SIG_DIV, item, "");

				ctlPlotMenu.EndOffsetIndex = (int)(SIG_NUM / SIG_DIV);	// "-100";
				ctlPlotMenu.TopOffsetIndex = 0;							// " 100";
			
			}
			else
			{
				ctlPlotMenu.EnableZoom = false;
				ctlPlotMenu.EnableOffset = true;

				ctlPlotMenu.ClearOffsetCommbo();

                if (BodeType == EnumBodeType.GAIN)
                {
                    x = 200;
                    y = -200;

                    AddOffsetCombo(x, y, 10, item, "[db]");

                    ctlPlotMenu.EndOffsetIndex = 23;		// "-40";
                    ctlPlotMenu.TopOffsetIndex = 17;		// " 40";
                }
                else
                {
                    x = 180;
                    y = -180;

                    AddOffsetCombo(x, y, 10, item, "[deg]");

                    ctlPlotMenu.EndOffsetIndex = 36;		// "-180";
                    ctlPlotMenu.TopOffsetIndex = 0;			// " 180";
                }
			}

			ctlPlotMenu.CH1_Name = ctlPlotMenu.CH1_Name;
			ctlPlotMenu.CH2_Name = ctlPlotMenu.CH2_Name;

		}

		private void AddOffsetCombo(double x, double y, double div, List<string> item, string unit)
		{
			int ix = new int();
			int id = new int();

			do
			{
				item.Add(x.ToString());

				if (div < 1)
				{
					ix = (int)(x * 1000.0);
					id = (int)(div * 1000.0);

					ix -= id;
					x = (double)ix / 1000.0;
				}
				else
				{
					x -= div;
				}
			} while (x >= y);

			ctlPlotMenu.AddTopOffsetCommbo(item, unit);
			ctlPlotMenu.AddEndOffsetCommbo(item, unit);
		}

		public EnumBodeType BodeType
		{
			set { _BodeType = value; }
			get { return _BodeType; }
		}

		public void BodeRefresh()
		{
			this.Refresh();
		}

		[Localizable(true)]
		public string BodeName
		{
			set { ctlPlotMenu.BodeName = value; }
			get { return ctlPlotMenu.BodeName; }
		}

		public string CH1_Name
		{
			set { ctlPlotMenu.CH1_Name = value; }
			get { return ctlPlotMenu.CH1_Name; }
		}

		public string CH2_Name
		{
			set { ctlPlotMenu.CH2_Name = value; }
			get { return ctlPlotMenu.CH2_Name; }
		}

		public string CH3_Name
		{
			set { ctlPlotMenu.CH3_Name = value; }
			get { return ctlPlotMenu.CH3_Name; }
		}

		public string CH4_Name
		{
			set { ctlPlotMenu.CH4_Name = value; }
			get { return ctlPlotMenu.CH4_Name; }
		}

		public string CH5_Name
		{
			set { ctlPlotMenu.CH5_Name = value; }
			get { return ctlPlotMenu.CH5_Name; }
		}

		public string CH6_Name
		{
			set { ctlPlotMenu.CH6_Name = value; }
			get { return ctlPlotMenu.CH6_Name; }
		}
		
		public string CH7_Name
		{
			set { ctlPlotMenu.CH7_Name = value; }
			get { return ctlPlotMenu.CH7_Name; }
		}
		
		public string CH8_Name
		{
			set { ctlPlotMenu.CH8_Name = value; }
			get { return ctlPlotMenu.CH8_Name; }
		}

		public int GainOff
		{
			get { return GAIN_OFF; }
		}

		public int GainTop
		{
			set 
			{
				GAIN_TOP = value;

				int e = GainEnd;
				int s = GainTop;

				GAIN_OFF = Math.Abs(e - s);
			}
			get { return GAIN_TOP; }
		}

		public int GainEnd
		{
			set
			{
				GAIN_END = value;

				int e = GainEnd;
				int s = GainTop;

				GAIN_OFF = Math.Abs(e - s);
			}
			get { return GAIN_END; }
		}

		public int GainTopSelectedIndex
		{
			set
			{
				ctlPlotMenu.TopOffsetIndex = value;
			}
		}

		public int GainEndSelectedIndex
		{
			set
			{
				ctlPlotMenu.EndOffsetIndex = value;
			}
		}

        [Localizable(true)]
		public string Y_Item
		{
			set { _Y_Item = value; }
			get { return _Y_Item; }
		}

		public string Y_Unit
		{
			set { _Y_Unit = value; }
			get { return _Y_Unit; }
		}

		public bool VisibleFixed
		{
			set { ctlPlotMenu.VisibleFixed = value; }
			get { return ctlPlotMenu.VisibleFixed; }
		}

		public bool VisibleChannelPuls
		{
			set
			{
				ctlPlotMenu.VisibleChannelPuls = value;
				UpdateMenuHeight();
			}
			get { return ctlPlotMenu.VisibleChannelPuls; }

		}

		public bool VisibleChannelPuls2
		{
			set
			{
				ctlPlotMenu.VisibleChannelPuls2 = value;
				UpdateMenuHeight();
			}
			get { return ctlPlotMenu.VisibleChannelPuls2; }

		}

        //↓↓↓ KASHIYAMA Mode 20200214 Kimura update ↓↓↓
        public bool VisibleKASHIYAMAMode
        {
            set
            {
                ctlPlotMenu.VisibleKASHIYAMAMode = value;
                UpdateMenuHeight();
            }
            get { return ctlPlotMenu.VisibleKASHIYAMAMode; }

        }
        //↑↑↑ KASHIYAMA Mode 20200214 Kimura update ↑↑↑

		public void UpdateMenuHeight()
		{
			int h = 50;

			if (VisibleChannelPuls) { h += 28; }
			if (VisibleChannelPuls2) { h += 28; }

            //↓↓↓ KASHIYAMA Mode 20200214 Kimura update ↓↓↓
            if (VisibleKASHIYAMAMode) { h += 28; }
            //↑↑↑ KASHIYAMA Mode 20200214 Kimura update ↑↑↑

			ctlPlotMenu.Height = h + 8;
		}

		public bool IsViewHold
		{
			set { ctlPlotMenu.IsViewHold = value; }
			get { return ctlPlotMenu.IsViewHold; }
		}

		public bool HoldEnabled
		{
			set { ctlPlotMenu.HoldEnabled = value; }
			get { return ctlPlotMenu.HoldEnabled; }
		}

		public bool IsSweep
		{
			set { _IsSweep = value; }
			get { return _IsSweep; }
		}

		private void ctlBoadGain_Load(object sender, EventArgs e)
		{
		}

		private void ctlPlotMenu_ValueOffsetChanged()
		{
			double s = ctlPlotMenu.TopOffsetNumber;
			double e = ctlPlotMenu.EndOffsetNumber;

			if (this.BodeType == EnumBodeType.GAIN || this.BodeType == EnumBodeType.PHASE)
			{
				GainTop = (int)s;
				GainEnd = (int)e;
			}
			else
			{
				SIG_TOP = s;
				SIG_END = e;
				SIG_NUM = SIG_TOP - SIG_END;
			}

			picBodePlot.Refresh();

		}

		private void ctlPlotMenu_ZoomClicked(object sender, EventArgs e)
		{
			ToolStripButton btn = (ToolStripButton)sender;

			if (btn.Tag.ToString() == "+")
			{
				ZoomScale++;
				if (ZoomScale > 200) { ZoomScale = 200; }
			}
			else
			{
				ZoomScale--;
				if (ZoomScale < 1) { ZoomScale = 1; }
			}

			SignalLength = SignalOrgLength / ZoomScale;

			picBodePlot.Refresh();

		}

		private void ctlPlotMenu_ControlStateChanged()
		{
			picBodePlot.Refresh();
		}

		private void ctlPlotMenu_ViewCleared()
		{
			for (int i = 0; i < DrawCount.Length; i++)
			{
				DrawCount[i] = 0;
			}

            //↓↓↓ KASHIYAMA Mode 20200214 Kimura update ↓↓↓
            BKDrawCount = 0;
            //↑↑↑ KASHIYAMA Mode 20200214 Kimura update ↑↑↑

			picBodePlot.Refresh();
		}

		private void ctlPlotMenu_ViewHold(bool on)
		{
			IsViewHold = on;
		}
	
		private void ctlPlotMenu_ScaleDivisionChanged()
		{
			SetSignalRange(BK_SIG_TOP, BK_SIG_END);
			picBodePlot.Refresh();
		}

        //↓↓↓ KASHIYAMA Mode 20200214 Kimura update ↓↓↓
        void ctlPlotMenu_KashiyamaModeViewHold()
        {
            if (BKDrawCount >= ctlPlotMenu.GetFFTHoldCount())
            {
                List<float[]> listBodeData = new List<float[]>();
                
                //過去のホールドデータを追加
                for (int i = 0; i < ctlPlotMenu.GetFFTHoldCount(); i++)
                {
                    listBodeData.Add(BKBodeData[i]);
                }
                
                //最新のホールドデータを追加
                listBodeData.Add(BodeData[0]);

                //一番古いホールドデータをクリア
                listBodeData.RemoveAt(0);

                for (int i = 0; i < listBodeData.Count; i++)
                {
                    for (int j = 0; j < BodeData[0].Length; j++)
                    {
                        BKBodeData[i][j] = (float)listBodeData[i].GetValue(j);
                    }
                }
            }
            else
            {
                BodeData[0].CopyTo(BKBodeData[BKDrawCount++], 0);
            }
        }

        //↑↑↑ KASHIYAMA Mode 20200214 Kimura update ↑↑↑

		private void picBodePlot_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				if (DisableDrawGraph) { return; }

				if (this.BodeType == EnumBodeType.GAIN || this.BodeType == EnumBodeType.PHASE)
				{
					DrawBodeGraph(e);
				}
				else
				{
					UpdateMenuHeight();		//MenuVisible Event不正???
					DrawSignalGraph(e);
				}
			}
			catch
			{

			}
		}

		private void DrawBodeGraph(PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			BodePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			SilverPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			DashPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

			float h = (float)picBodePlot.Height;
			float w = (float)picBodePlot.Width;
			float xo1 = xStartOff;
			float xo2 = xEndOff;
			float yo1 = yStartOff;
			float yo2 = yEndOff;

			float w2 = w - xo1 - xo2;
			float h2 = h - yo1 - yo2;

			float h_div = h2 / (GAIN_OFF / 5);
			float p_div = h2 / (GAIN_OFF / 10);

			float x0db_p = 0.0f;
			float y0db_p = 0.0f;

			float log_div = w2 / LOG_NUM * LOG_DIV_COE;	//横軸の幅調整（1.2倍）
			float gain_div = h2 / GAIN_OFF;
			float phase_div = h2 / GAIN_OFF;			// PHASE_NUM;

			float x_st = 0.0f;
			float x_et = 0.0f;
			float y_st = 0.0f;
			float y_et = 0.0f;
			
			g.DrawLine(BodePen, xo1, h - yo2, w - xo2, h - yo2);					//横線基準
			g.DrawLine(BodePen, xo1, h - yo2, xo1 - 5.0f, h - yo2);					//横線補助線

			int num = 0;

			if (BodeType == EnumBodeType.GAIN)
			{
				num = GAIN_END;

				x0db_p = xo1;
				y0db_p = yStartOff + GAIN_TOP / 5 * h_div;

				for (int i = 0; i <= (GAIN_OFF / 5); i++)
				{
					float x = 5.0f;
					float f = h_div * i;

					if (Math.Abs(num % 10) == 5) { x = 3.0f; }

					if (i > 0)
					{
						g.DrawLine(BodePen, xo1, h - yo2 - f, xo1 - x, h - yo2 - f);			//横線補助線
						g.DrawLine(DashPen, xo1, h - yo2 - f, w - xo2, h - yo2 - f);			//横線補助線
					}

					if ((num % 10) == 0)
					{
						string str = num.ToString();

						switch (str.Length)
						{
							case 1:	//0db
								g.DrawString(num.ToString(), BodeFont, BodeBrush, xo1 - 15.0f, h - yo2 - f - 5.0f);
								g.DrawLine(GrayPen, xo1, h - yo2 - f, w - xo2, h - yo2 - f);	//0db横線補助線は実線
								break;
							case 2:
								g.DrawString(num.ToString(), BodeFont, BodeBrush, xo1 - 20.0f, h - yo2 - f - 5.0f);
								break;
							case 3:
								g.DrawString(num.ToString(), BodeFont, BodeBrush, xo1 - 25.0f, h - yo2 - f - 5.0f);
								break;
							case 4:
							default:
								g.DrawString(num.ToString(), BodeFont, BodeBrush, xo1 - 30.0f, h - yo2 - f - 5.0f);
								break;
						}
					}

					num += 5;
				}
			}
			else if (BodeType == EnumBodeType.PHASE)
			{
				num = GAIN_END;

				x0db_p = xo1;
				y0db_p = yStartOff + GAIN_TOP / 10 * p_div;

				for (int i = 0; i <= (GAIN_OFF / 10); i++)
				{
					float x = 5.0f;
					float f = p_div * i;

					if ((num % 30) != 0) { x = 3.0f; }

					if ((num % 30) == 0)
					{
						if (i > 0)
						{
							g.DrawLine(BodePen, xo1, h - yo2 - f, xo1 - x, h - yo2 - f);		//横線補助線
							g.DrawLine(SilverPen, xo1, h - yo2 - f, w - xo2, h - yo2 - f);		//横線補助線
						}

						string str = num.ToString();

						switch (str.Length)
						{
							case 1:	//0deg
								g.DrawString(num.ToString(), BodeFont, BodeBrush, xo1 - 15.0f, h - yo2 - f - 5.0f);
								g.DrawLine(GrayPen, xo1, h - yo2 - f, w - xo2, h - yo2 - f);	//0db横線補助線は実線
								break;
							case 2:
								g.DrawString(num.ToString(), BodeFont, BodeBrush, xo1 - 20.0f, h - yo2 - f - 5.0f);
								break;
							case 3:
								g.DrawString(num.ToString(), BodeFont, BodeBrush, xo1 - 25.0f, h - yo2 - f - 5.0f);
								break;
							case 4:
							default:
								g.DrawString(num.ToString(), BodeFont, BodeBrush, xo1 - 30.0f, h - yo2 - f - 5.0f);
								break;
						}
					}
					else
					{
						g.DrawLine(BodePen, xo1, h - yo2 - f, xo1 - x, h - yo2 - f);		//横線補助線
						g.DrawLine(DashPen, xo1, h - yo2 - f, w - xo2, h - yo2 - f);		//横線補助線
					}

					num += 10;
				}
			}

			num = 0;

			x_st = xo1;
			x_et = 0.0f;
			y_st = h - yo2;
			y_et = 0.0f;

			g.DrawLine(BodePen, x_st, yo1, x_st, h - yo2);							//縦線基準
			g.DrawLine(BodePen, x_st, y_st, x_st, h - yo2 + 5.0f);					//縦線補助線
			g.DrawString("10", BodeFont, BodeBrush, xo1 - 5.0f, h - yo2 + 5.0f);
			g.DrawString(num.ToString(), ExpFont, BodeBrush, xo1 + 7.0f, h - yo2);

			g.DrawString(UserText.CtlBodePlotAmplitude, BodeFont, BodeBrush, 2.0f, h - 15.0f);	//Y軸項目

			for (int i = 0; i < LOG_NUM - 1; i++)
			{
				for (int j = 1; j <= 9; j++)
				{
					if (i == 0 && j == 1) { continue; }
					float x = (float)Math.Log10(j) * log_div;

					if (j == 5)
					{
						g.DrawLine(BodePen, x_st + x, y_st, x_st + x, h - yo2 + 5.0f);	//縦線補助線
					}
					else
					{
						g.DrawLine(BodePen, x_st + x, y_st, x_st + x, h - yo2 + 3.0f);	//縦線補助線
					}
					g.DrawLine(DashPen, x_st + x, y_st, x_st + x, yo1);					//縦線補助線
				}

				num++;
				x_st += log_div;

				g.DrawLine(BodePen, x_st, y_st, x_st, h - yo2 + 5.0f);				//縦線補助線
				g.DrawLine(DashPen, x_st, y_st, x_st, yo1);							//縦線補助線

				g.DrawString("10", BodeFont, BodeBrush, x_st - 5.0f, h - yo2 + 5.0f);
				g.DrawString(num.ToString(), ExpFont, BodeBrush, x_st + 7.0f, h - yo2);

				if (num == 2) { g.DrawString(UserText.CtlBodePlotFrequency, BodeFont, BodeBrush, x_st, h - 15.0f); }
			}

			for (int c = 0; c < MAX_CH; c++)
			{
				GainPen.Color = ctlPlotMenu.GetLineColor(c);
				GainPen.Width = ctlPlotMenu.GetLineWidth(c);

				if (!ctlPlotMenu.GetViewEnable(c)) { continue; }

				x_st = x0db_p;
				x_et = 0.0f;
				y_st = y0db_p;
				y_et = 0.0f;

				double l  = 1.0;
				float scale = 0.0f;
		
				float limit_p = (float)ctlPlotMenu.TopOffsetNumber;
				float limit_m = (float)ctlPlotMenu.EndOffsetNumber;
		
				if (BodeType == EnumBodeType.GAIN)
				{
					scale = gain_div;
				}
				else if (BodeType == EnumBodeType.PHASE)
				{
					scale = phase_div;
				}

				float data = new float();

                //↓↓↓ KASHIYAMA Mode 20200214 Kimura update ↓↓↓

                //FFTｸﾞﾗﾌﾎｰﾙﾄﾞ描画
               
                FFTHoldPen.Width = ctlPlotMenu.GetFFTHoldLineWidth();

                for (int i = 0; i < BKDrawCount; i++)
                {
                    l = 1.0;
                    x_st = x0db_p;
                    x_et = 0.0f;
                    y_st = y0db_p;
                    y_et = 0.0f;

                    FFTHoldPen.Color = ctlPlotMenu.GetFFTHoldLineColor(i);

                    for (int j = 0; j < FRQ_NUM; j++)
                    {
                        if (j >= DrawCount[c]) { break; }

                        data = BKBodeData[i][j];

                        if (data > limit_p) { data = limit_p; }
                        if (data < limit_m) { data = limit_m; }

                        x_et = x0db_p + log_div * (float)Math.Log10(l);
                        y_et = y0db_p - scale * data;
                        g.DrawLine(FFTHoldPen, x_st, y_st, x_et, y_et);
                        x_st = x_et;
                        y_st = y_et;

                        if (IsSweep)
                        {
                            l += 1.0;
                        }
                        else
                        {
                            l += 1.0 * FFT_ConvertCoeff;
                        }
                    }
                }

                l = 1.0;
                x_st = x0db_p;
                x_et = 0.0f;
                y_st = y0db_p;
                y_et = 0.0f;

                //↑↑↑ KASHIYAMA Mode 20200214 Kimura update ↑↑↑

                for (int i = 0; i < FRQ_NUM; i++)
                {
                    if (i >= DrawCount[c]) { break; }

                    data = BodeData[c][i];

                    if (data > limit_p) { data = limit_p; }
                    if (data < limit_m) { data = limit_m; }

                    x_et = x0db_p + log_div * (float)Math.Log10(l);
                    y_et = y0db_p - scale * data;
                    g.DrawLine(GainPen, x_st, y_st, x_et, y_et);
                    x_st = x_et;
                    y_st = y_et;

                    if (IsSweep)
                    {
                        l += 1.0;
                    }
                    else
                    {
                        l += 1.0 * FFT_ConvertCoeff;
                    }

                    DrawPointX[c][i] = x_et;
                }
			}

			if (ctlPlotMenu.MeasMode)
			{
				int x_idx = ctlPlotMenu.MeasIndex;
				int x_pos = (int)DrawPointX[0][x_idx];

				MeasPen.DashStyle = DashStyle.Dot;

				g.DrawLine(MeasPen, x_pos, yo1, x_pos, h - yo2);

				float v = (float)picBodePlot.Height - yStartOff - yEndOff;

				float v_div = v / (GAIN_OFF / 5);
				float g_div = v / GAIN_OFF;

				lblQuickView.Text = "Quick Monitor" + "\n";

				for (int i = 0; i < MAX_CH; i++)
				{
					if (!ctlPlotMenu.GetViewEnable(i)) { continue; }

					float y_dat = BodeData[i][x_idx];

					float y_0db = yStartOff + (float)GAIN_TOP / 5.0F * v_div;

					float y_pos = y_0db - g_div * y_dat;

					Pen arc;

					if (i == 0)		//チャンネル毎に円描画の色を変える（チャンネル増えた時は要調整）
					{
						//Channel = 1
						arc = new Pen(Color.Red, 1);
					}
					else
					{
						//Channel = 2
						arc = new Pen(Color.Blue, 1);
					}

					g.DrawArc(arc, x_pos - 4.0f, y_pos - 4.0f, 8.0f, 8.0f, 0.0f, 360.0f);

					double frq = new float();

					if (IsSweep)
					{
						frq = 1.0 + x_idx;
					}
					else
					{
						frq = 1.0 + x_idx * FFT_ConvertCoeff;
					}

					lblQuickView.Text += "CH_" + (i + 1).ToString() + "\n"
										+ "FRQ" + " ： " + frq.ToString("F2") + " [Hz]" + "\n"
										+ "PWR" + " ： " + y_dat.ToString("F2") + " [dB]" + "\n";
				}

				Point pt = new Point();

				pt.X = picBodePlot.Width - lblQuickView.Width - 10;
				pt.Y = picBodePlot.Height - lblQuickView.Height - 10;

				lblQuickView.Location = pt;
				lblQuickView.Visible = true;
				lblQuickView.Refresh();
			}
			else
			{
				lblQuickView.Visible = false;
			}
		}

		private void DrawSignalGraph(PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			BodePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			GrayPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			SilverPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			DashPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

			float h = (float)picBodePlot.Height;
			float w = (float)picBodePlot.Width;
			float xo1 = xStartOff;
			float xo2 = xEndOff;
			float yo1 = yStartOff;
			float yo2 = yEndOff;

			float w2 = w - xo1 - xo2;
			float h2 = h - yo1 - yo2;

			float s_div = (float)(h2 / (SIG_NUM / SIG_DIV));

			float x0db_p = 0.0f;
			float y0db_p = 0.0f;

			float tim_div = w2 / SignalLength;
			float sig_div = (float)(h2 / SIG_NUM);

			float x_st = 0.0f;
			float x_et = 0.0f;
			float y_st = 0.0f;
			float y_et = 0.0f;

			double num = SIG_END;															//SIG_ENDから描画

			x0db_p = xo1;
			y0db_p = (float)(h - yo2 + SIG_END * sig_div);

			if (Convert.ToInt32(Math.IEEERemainder(num, SIG_DIV)) == 0)
			{
				g.DrawLine(BodePen, xo1, h - yo2, w - xo2, h - yo2);						//横線基準
				g.DrawLine(BodePen, xo1, h - yo2, xo1 - 5.0f, h - yo2);						//横線補助線

				switch (num.ToString().Length)
				{
					case 2:
						g.DrawString(num.ToString(), BodeFont, BodeBrush, xo1 - 18.0f, h - yo2 - 5.0f);
						break;

					case 3:
						g.DrawString(num.ToString(), BodeFont, BodeBrush, xo1 - 22.0f, h - yo2 - 5.0f);
						break;

					case 4:
						g.DrawString(num.ToString(), BodeFont, BodeBrush, xo1 - 25.0f, h - yo2 - 5.0f);
						break;

					case 5:
						g.DrawString(num.ToString(), BodeFont, BodeBrush, xo1 - 30.0f, h - yo2 - 5.0f);
						break;

					case 6:
					case 7:
						g.DrawString(num.ToString(), BodeFont, BodeBrush, xo1 - 35.0f, h - yo2 - 5.0f);
						break;

					default:
						break;
				}
			}
			else
			{
				g.DrawLine(BodePen, xo1, h - yo2, w - xo2, h - yo2);						//横線基準
				g.DrawLine(BodePen, xo1, h - yo2, xo1 - 3.0f, h - yo2);						//横線補助線
			}
			
			num += SIG_DIV;

			for (int i = 0; i < (SIG_NUM / SIG_DIV); i++)
			{
				float x = 5.0f;
				float f = s_div * (i + 1);

				if (Convert.ToInt32(Math.IEEERemainder(num, SIG_DIV)) != 0) { x = 3.0f; }

				if (Convert.ToInt32(Math.IEEERemainder(num, SIG_DIV)) == 0)
				{
					g.DrawLine(BodePen, xo1, h - yo2 - f, xo1 - x, h - yo2 - f);		//横線補助線
					g.DrawLine(SilverPen, xo1, h - yo2 - f, w - xo2, h - yo2 - f);		//横線補助線

					string str = num.ToString();

					switch (str.Length)
					{
						case 1:	//0
							g.DrawLine(BodePen, xo1, h - yo2 - f, xo1 - x, h - yo2 - f);		//横線補助線
							g.DrawLine(GrayPen, xo1, h - yo2 - f, w - xo2, h - yo2 - f);		//横線補助線
							
							g.DrawString(num.ToString(), BodeFont, BodeBrush, xo1 - 13.0f, h - yo2 - f - 5.0f);
							break;
						case 2:
							g.DrawString(num.ToString(), BodeFont, BodeBrush, xo1 - 18.0f, h - yo2 - f - 5.0f);
							break;
						case 3:
							g.DrawString(num.ToString(), BodeFont, BodeBrush, xo1 - 22.0f, h - yo2 - f - 5.0f);
							break;
						case 4:
							g.DrawString(num.ToString(), BodeFont, BodeBrush, xo1 - 25.0f, h - yo2 - f - 5.0f);
							break;
						case 5:
							g.DrawString(num.ToString(), BodeFont, BodeBrush, xo1 - 30.0f, h - yo2 - f - 5.0f);
							break;
						case 6:
						case 7:
							g.DrawString(num.ToString(), BodeFont, BodeBrush, xo1 - 35.0f, h - yo2 - f - 5.0f);
							break;
						default:
							break;
					}
				}
				else
				{
					//g.DrawLine(BodePen, xo1, h - yo2 - f, xo1 - x, h - yo2 - f);	//横線補助線
					//g.DrawLine(DashPen, xo1, h - yo2 - f, w - xo2, h - yo2 - f);	//横線補助線
				}

				num += SIG_DIV;
			}

			num = 0;

			x_st = xo1;
			x_et = 0.0f;
			y_st = h - yo2;
			y_et = 0.0f;

			g.DrawLine(BodePen, x_st, yo1,  x_st, h - yo2);							//縦線基準
			g.DrawLine(BodePen, x_st, y_st, x_st, h - yo2 + 5.0f);					//縦線補助線
			g.DrawString("0", BodeFont, BodeBrush, xo1 - 5.0f, h - yo2 + 5.0f);
			
			g.DrawString(Y_Item + Y_Unit, BodeFont, BodeBrush, 2.0f, h - 15.0f);	//Y軸項目

			int t_scale_div = 10;
			int t_scale_div2 = 1;

			if (SignalLength > 100)    { t_scale_div = 100; }
			if (SignalLength > 1000)   { t_scale_div = 1000; }
			if (SignalLength > 10000)  { t_scale_div = 10000; }
			if (SignalLength > 100000) { t_scale_div = 100000; }

			t_scale_div2 = t_scale_div / 10;
			
			for (int i = 0, j = 0; i < SignalLength; i++)
			{
				float x = i * tim_div;

				if (i == 0) { continue; }

				num += SignalTimeDiv;

				if ((i % t_scale_div) != 0)
				{
					if (i % t_scale_div2 == 0)
					{
						g.DrawLine(BodePen, x_st + x, y_st, x_st + x, h - yo2 + 3.0f);	//縦線補助線
						g.DrawLine(DashPen, x_st + x, y_st, x_st + x, yo1);				//縦線補助線
					}
				}
				else
				{
					double t10 = (double)num / 1000.0;
					j++;

					g.DrawLine(BodePen, x_st + x, y_st, x_st + x, h - yo2 + 5.0f);		//縦線補助線
					g.DrawLine(GrayPen, x_st + x, y_st, x_st + x, yo1);					//縦線補助線

					g.DrawString((t10).ToString("f2"), BodeFont, BodeBrush, x_st + x - 5.0f, h - yo2 + 5.0f);

				}
			
				if (i == SignalLength / 2) { g.DrawString(UserText.CtlBodePlotTime, BodeFont, BodeBrush, x_st + x, h - 15.0f); }
			
			}

			for (int c = 0; c < MAX_CH; c++)
			{

				GainPen.Color = ctlPlotMenu.GetLineColor(c);
				GainPen.Width = ctlPlotMenu.GetLineWidth(c);
				if (!ctlPlotMenu.GetViewEnable(c)) { continue; }

				x_st = x0db_p;
				x_et = 0.0f;
				y_st = y0db_p;
				y_et = 0.0f;

				float scale = sig_div;
				float limit_p = (float)SIG_TOP;
				float limit_m = (float)SIG_END;

				float data = new float();

				for (int i = 0; i < SignalLength; i++)
				{
					if (i >= DrawCount[c]) { break; }

					data = SignalData[c][i];

					if (data > limit_p) { data = limit_p; }
					if (data < limit_m) { data = limit_m; }

					x_et = x_st + tim_div;
					y_et = y0db_p - scale * data;
					g.DrawLine(GainPen, x_st, y_st, x_et, y_et);
					x_st = x_et;
					y_st = y_et;
	
				}
			}
		}

		private int SignalOrgLength = 1000;
		private int SignalLength = 1000;
		private int SignalTimeDiv = 100;
		private int ZoomScale = 5;

		public void SetBodeData(int ch, int num, double[] data)
		{
			if (IsViewHold) { return; }

			if( ch > MAX_CH ) { return; }

			DrawCount[ch] = num;

			for (int i = 0; i < num; i++)
			{
				BodeData[ch][i] = (float)data[i];
			}

			//if (ctlPlotMenu.MathMode)
			//{
			//    if (ch == 1)
			//    {
			//        DrawCount[2] = num;

			//        for (int i = 0; i < num; i++)
			//        {
			//            BodeData[2][i] = BodeData[0][i] - BodeData[1][i];
			//        }
			//    }
			//}

			IsSweep = false;

			picBodePlot.Refresh();
		}

		public void SetSignalData(int ch, int num, int frp, double[] data, bool is_draw)
		{
			if (IsViewHold) { return; }

			if (ch > MAX_CH) { return; }

			DrawCount[ch] = num;

			for (int i = 0; i < num; i++)
			{
				SignalData[ch][i] = (float)data[i];
			}
			
			SignalOrgLength = num;
			SignalLength = num / ZoomScale;
			SignalTimeDiv = 1000000 / frp;		//unit:usec

			if (is_draw) { picBodePlot.Refresh(); }
		}

		public void SetSweepData(int ch, int num, float[] data)
		{
			if (IsViewHold) { return; }

			if (ch > MAX_CH) { return; }

			DrawCount[ch] = num;

			for (int i = 0; i < num; i++)
			{
				BodeData[ch][i] = data[i];
			}

			IsSweep = true;

			picBodePlot.Refresh();
		}

		public void SetSignalDataF(int ch, int num, int frp, float[] data, bool is_draw)
		{
			if (IsViewHold) { return; }

			if (ch > MAX_CH) { return; }

			DrawCount[ch] = num;

			for (int i = 0; i < num; i++)
			{
				SignalData[ch][i] = data[i];
			}

			SignalOrgLength = num;
			SignalLength = num / ZoomScale;
			SignalTimeDiv = 1000000 / frp;		//unit:usec

			if (is_draw) { picBodePlot.Refresh(); }
		}

		public void SetSignalRange(double max, double min)
		{
			double mmax = new int();
			bool div_change = false;

			DisableDrawGraph = true;

			if (Math.Abs(max) > Math.Abs(min))
			{
				mmax = Math.Abs(max);
			}
			else
			{
				mmax = Math.Abs(min);
			}

			if (ctlPlotMenu.IsScaleFixed)
			{
				double n = ctlPlotMenu.ScaleDivision;

				SIG_TOP = n * 5;
				SIG_END = -SIG_TOP;

				if (SIG_DIV != n) { div_change = true; }
				SIG_DIV = n;
				BK_SIG_DIV = SIG_DIV;

			}
			else
			{
				if (mmax <= 20)
				{
					SIG_TOP = 20;
					SIG_END = -20;
					SIG_DIV = 4;
				}
				else if (mmax <= 50)
				{
					SIG_TOP = 50;
					SIG_END = -50;
					SIG_DIV = 10;
				}
				else if (mmax <= 100)
				{
					SIG_TOP = 100;
					SIG_END = -100;
					SIG_DIV = 20;
				}
				else if (mmax <= 200)
				{
					SIG_TOP = 200;
					SIG_END = -200;
					SIG_DIV = 40;
				}
				else if (mmax <= 500)
				{
					SIG_TOP = 500;
					SIG_END = -500;
					SIG_DIV = 100;
				}
				else if (mmax <= 1000)
				{
					SIG_TOP = 1000;
					SIG_END = -1000;
					SIG_DIV = 200;
				}
				else if (mmax <= 2000)
				{
					SIG_TOP = 2000;
					SIG_END = -2000;
					SIG_DIV = 400;
				}
				else if (mmax <= 5000)
				{
					SIG_TOP = 5000;
					SIG_END = -5000;
					SIG_DIV = 1000;
				}
				else
				{
					SIG_TOP = 10000;
					SIG_END = -10000;
					SIG_DIV = 2000;
				}

				BK_SIG_TOP = SIG_TOP;
				BK_SIG_END = SIG_END;

				if (SIG_DIV != BK_SIG_DIV) { div_change = true; }

				BK_SIG_DIV = SIG_DIV;

			}

			SIG_NUM = SIG_TOP - SIG_END;

			if (div_change)
			{
				List<string> item = new List<string>();

				ctlPlotMenu.ClearOffsetCommbo();
				AddOffsetCombo(SIG_TOP, SIG_END, SIG_DIV, item, "");

				ctlPlotMenu.EndOffsetIndex = (int)(SIG_NUM / SIG_DIV);
				ctlPlotMenu.TopOffsetIndex = 0;
			}
			else
			{
				ctlPlotMenu_ValueOffsetChanged();
			}

			DisableDrawGraph = false;

		}

		public void ClearSignalData()
		{
			ctlPlotMenu_ViewCleared();
		}

        public void ViewCultureResouceChanged()
        {
            ctlPlotMenu.ViewCultureResouceChanged();
        }

		private bool  QuickReadFlag = false;
		private Point MousePoint = new Point();
		private float[][] DrawPointX = new float[MAX_CH][];

		private void picBodePlot_MouseMove(object sender, MouseEventArgs e)
		{
			if (ctlPlotMenu.MeasMode) { return; }

			float h = (float)picBodePlot.Height - yStartOff - yEndOff;

			float h_div = h / (GAIN_OFF / 5);
			float g_div = h / GAIN_OFF;

			if (MousePoint.X == e.X && MousePoint.Y == e.Y) { return; }		//連続的に割り込みが入るのを禁止

			MousePoint.X = e.X;
			MousePoint.Y = e.Y;

			for (int i = 0; i < MAX_CH; i++)
			{
				if (!ctlPlotMenu.GetViewEnable(i)) { continue; }

				bool  x_flg = new bool();
				int   x_idx = new int();
				float x_pos = new int();

				for (int j = 0; j < DrawPointX[i].Length; j++)
				{
					if (j >= DrawCount[i]) { break; }

					if (Math.Abs(DrawPointX[i][j] - MousePoint.X) < 5)
					{
						x_flg = true;
						x_idx = j;
						x_pos = (int)DrawPointX[i][j];
						break;
					}
				}

				if (!x_flg) { continue; }

				float y_dat = BodeData[i][x_idx];

				float y_0db = yStartOff + (float)GAIN_TOP / 5.0F * h_div;

				float y_pos = y_0db - g_div * y_dat;

				if (y_pos + 10 >= MousePoint.Y && y_pos - 10 <= MousePoint.Y)
				{
					if (QuickReadFlag == true)
					{
						picBodePlot.Refresh();
					}

					Graphics g = picBodePlot.CreateGraphics();

					Pen arc;

					if (i == 0)		//チャンネル毎に円描画の色を変える（チャンネル増えた時は要調整）
					{
						//Channel = 1
						arc = new Pen(Color.Red, 1);
					}
					else
					{
						//Channel = 2
						arc = new Pen(Color.Blue, 1);
					}

					g.DrawArc(arc, x_pos - 5.0f, y_pos - 5.0f, 10.0f, 10.0f, 0.0f, 360.0f);

					double frq = new float();

					if (IsSweep)
					{
						frq = 1.0 + x_idx;
					}
					else
					{
						frq = 1.0 + x_idx * FFT_ConvertCoeff;
					}

					lblQuickView.Text = "Quick Monitor" + "\n"
										+ "CH_" + (i + 1).ToString() + "\n"
										+ "FRQ" + " ： " + frq.ToString("F2") + " [Hz]" + "\n"
										+ "PWR" + " ： " + y_dat.ToString("F2") + " [dB]";

					Point pt = new Point();

					pt.X = picBodePlot.Width - lblQuickView.Width - 10;
					pt.Y = picBodePlot.Height - lblQuickView.Height - 10;

					lblQuickView.Location = pt;
					lblQuickView.Visible = true;
					lblQuickView.Refresh();

					g.Dispose();
					arc.Dispose();

					QuickReadFlag = true;

					picBodePlot.Cursor = Cursors.Hand;
					return;
				}
			}

			//クイックリファレンス表示無し
			if (QuickReadFlag == true)
			{
				picBodePlot.Refresh();
				QuickReadFlag = false;
				lblQuickView.Visible = false;
			}

			//埋め込まれたカーソルリソースの呼び出し
			picBodePlot.Cursor = Cursors.Arrow;
		}

		private void picBodePlot_MouseDown(object sender, MouseEventArgs e)
		{
			if (ctlPlotMenu.MeasMode)
			{
				int ch_0 = 0;

				for (int j = 0; j < DrawPointX[ch_0].Length; j++)
				{
					if (j >= DrawCount[ch_0]) { break; }

					if (Math.Abs(DrawPointX[ch_0][j] - e.X) < 5)
					{
						ctlPlotMenu.MeasIndex = j;

						this.Refresh();
						return;
					}
				}
			}
		}
	}
}