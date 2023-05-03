using System;
using System.Collections.Generic;
using System.Text;

namespace Motion_Designer
{
	static public class FFT_C
	{
        //↓↓↓ KASHIYAMA Mode 20200214 Kimura update ↓↓↓
        static private int _FRQ = 20000;
        static private int _FFT_n = 16384;
        static private int _LOG_n = 20;
        //↑↑↑ KASHIYAMA Mode 20200214 Kimura update ↑↑↑

		private const int _FFT_Buf_n = 8;
		private const int _FFT_Ave_n = 4;

		private const int _FFT_Peek_n = 5;

		static public double FFT_mon2real
		{
			get { return (double)FRQ / (double)FFT_n; }
		}

		static public double FFT_real2mon
		{
			get { return (double)FFT_n / (double)FRQ; }
		}

		static public int F2Real(int frq)
		{
			return (int)((double)frq * FFT_mon2real);
		}

		static public int R2FFT(int frq)
		{
			return (int)((double)frq * FFT_real2mon);
		}

		static public int FRQ
		{
			set
			{
                //↓↓↓ KASHIYAMA Mode 20200214 Kimura update ↓↓↓
                if (Properties.Settings.Default.PASSWORD_KASHIYAMA == true)
                {
                    _FRQ = value;
                }
                else
                {
                    switch (value)
                    {
                        case 10000:

                            _FRQ = value;
                            _FFT_n = 8192;
                            break;

                        case 12500:

                            _FRQ = value;
                            _FFT_n = 8192;
                            break;

                        case 13333:

                            _FRQ = value;
                            _FFT_n = 8192;
                            break;

                        case 16000:

                            _FRQ = value;
                            _FFT_n = 16384;
                            break;

                        case 20000:

                            _FRQ = value;
                            _FFT_n = 16384;
                            break;

                        default:

                            _FRQ = 20000;
                            _FFT_n = 16384;
                            break;
                    }
                }
                //↑↑↑ KASHIYAMA Mode 20200214 Kimura update ↑↑↑

                _LOG_n = _FRQ / 1000;				//FFTログ収集周期[Hz]÷1msec周期[Hz]
			}

			get
			{
				switch (LogWork.LogPeriod)
				{
					default:
					case 1:
						return _FRQ;

					case 2:
						return _FRQ / 2;

					case 4:
						return _FRQ / 4;
				}
			}
		}

        //↓↓↓ KASHIYAMA Mode 20200214 Kimura update ↓↓↓
        static public int FFT_count
        {
            set { _FFT_n = value; }
            get { return _FFT_n; }
        }
        //↑↑↑ KASHIYAMA Mode 20200214 Kimura update ↑↑↑

		static public int FFT_max
		{
			get
			{
				return _FFT_n;
			}
		}

		static public int FFT_n
		{
			get
			{
				switch (LogWork.LogPeriod)
				{
					default:
					case 1:
						return _FFT_n;

					case 2:
						return _FFT_n / 2;

					case 4:
						return _FFT_n / 4;
				}
			}
		}

		static public int LOG_n
		{
			get { return _LOG_n; }
		}

		static public int FFT_Buf_max
		{
			get
			{
				return _FFT_Buf_n;
			}
		}

		static public int FFT_Buf_n
		{
			get { return _FFT_Buf_n; }
			//get
			//{
			//    switch (LogWork.LogPeriod)
			//    {
			//        default:
			//        case 1:
			//            return _FFT_Buf_n;

			//        case 2:
			//            return _FFT_Buf_n / 2;

			//        case 4:
			//            return _FFT_Buf_n / 4;
			//    }
			//}
		}

		static public int FFT_Ave_n
		{
			get { return _FFT_Ave_n; }
			//get
			//{
			//    switch (LogWork.LogPeriod)
			//    {
			//        default:
			//        case 1:
			//            return _FFT_Ave_n;

			//        case 2:
			//            return _FFT_Ave_n / 2;

			//        case 4:
			//            return _FFT_Ave_n / 4;
			//    }
			//}
		}

		static public int FFT_Peek_n
		{
			get { return _FFT_Peek_n; }
			//get
			//{
			//    switch (LogWork.LogPeriod)
			//    {
			//        default:
			//        case 1:
			//            return _SMA_n;

			//        case 2:
			//            return (_SMA_n + 1) / 2;

			//        case 4:
			//            return (_SMA_n + 1) / 3;
			//    }
			//}
		}

		static public int Bode_n
		{
			get
			{
				return FFT_n / 2 - 100;
			}
		}

		static public double FFT_ConvertCoeff
		{
			get { return FFT_mon2real; }
		}
	}

	public class FFT_Member
	{
		public int Hz;
		public double dB;
		public double dBsub;

		public FFT_Member()
		{
		}

		public FFT_Member(FFT_Member fft_mem)
		{
			Hz = fft_mem.Hz;
			dB = fft_mem.dB;
			dBsub = fft_mem.dBsub;
		}

		public FFT_Member(int hz, double db)
		{
			Hz = hz;
			dB = db;
		}

		public FFT_Member(int hz, double db, double sub)
		{
			Hz = hz;
			dB = db;
			dBsub = sub;
		}
	}

	class FFT_IF
	{
		public FFT_IF()
		{

		}

		private double[,] dbFFT = new double[FFT_C.FFT_Buf_max, FFT_C.FFT_max];
		private double[,] thFFT = new double[FFT_C.FFT_Buf_max, FFT_C.FFT_max];

		private double[] ar = new double[FFT_C.FFT_max];
		private double[] ai = new double[FFT_C.FFT_max];

		private double[] inputIm = new double[FFT_C.FFT_max];

		private int FFT_BufPtr = new int();

		public List<FFT_Member> GetFFT_PeekMax()
		{
			return listPeekMax;
		}

		public List<FFT_Member> GetFFT_PeekMin()
		{
			return listPeekMin;
		}

		public void ClearFFT_Buffer()
		{
			for (int i = 0; i < FFT_C.FFT_Buf_n; i++)
			{
				for (int j = 0; j < FFT_C.FFT_max; j++)
				{
					dbFFT[i, j] = 0;
					thFFT[i, j] = 0;
				}
			}
		}

		public void CalcFFT_CS(int ch, int buf_n, double[] input, bool is_dft)
		{
			double power_ave = 0.0;

			int fft_n2 = FFT_C.FFT_n / 2;

			FFT fftCs = new FFT(FFT_C.FRQ);

			double[] input_buf;

			if (ch < 0)
			{
				//リングFFT
				ch = FFT_BufPtr;

				FFT_BufPtr++;

				if (FFT_BufPtr >= buf_n)
				{
					FFT_BufPtr = 0;
				}
			}

			input_buf = fftCs.Windowing(input, WindowFunc.Hamming);
			//input_buf = fftCs.Windowing(input, WindowFunc.Hanning);
			//input_buf = fftCs.Windowing(input, WindowFunc.Blackman);
			//input_buf = fftCs.Windowing(input, WindowFunc.Rectangular);

			int x = FFT_C.FFT_n;
			int n = new int();

			while (x >= 2)
			{
				x /= 2;
				n++;
			}

			fftCs.CalcFFT(input_buf, inputIm, out ar, out ai, n);

			double d = new double();

			for (int i = 0; i < fft_n2; i++)				//FFT_N/2 はサンプリングの定理　エイリアシングフィルタ
			{
				d = ar[i] * ar[i] + ai[i] * ai[i];

				//スペクトル取得
				if (d != 0.0)
				{
					dbFFT[ch, i] = Math.Sqrt(d);				//[db]
					//dbFFT[ch, i] = Math.Sqrt(d) / (fft_n2);	//[v]
				}
				else
				{
					dbFFT[ch, i] = 0.0;
				}
			
				power_ave += dbFFT[ch, i];
			}

			power_ave = power_ave / (fft_n2);				//振幅の平均値を取得

			for (int i = 0; i < fft_n2; i++)				//FFT_N/2 はサンプリングの定理　エイリアシングフィルタ
			{
				if (i > 0)
				{
					if (power_ave != 0.0)
					{
						dbFFT[ch, i] = 20.0 * Math.Log10(dbFFT[ch, i] / power_ave);
					}
					else
					{
						dbFFT[ch, i] = 0.0;
					}

					dbFFT[ch, i - 1] = dbFFT[ch, i];								//ボード線図は1Hz～

					//位相データ取得
					if (Math.Abs(ar[i]) < 0.001) { ar[i] = 0.0; }
					if (Math.Abs(ai[i]) < 0.001) { ai[i] = 0.0; }

					thFFT[ch, i] = Math.Atan2(ai[i], ar[i]) * 180.0 / Math.PI;
					thFFT[ch, i - 1] = thFFT[ch, i];								//ボード線図は1Hz～
				}

			}
		}

		public void CalcFFT_AverageAdd(int ave_n, ref double[] aveFFT)
		{
			int n = FFT_C.FFT_n / 2;

			for (int i = 0; i < n; i++)
			{
				aveFFT[i] = 0.0;

				for (int j = 0; j < ave_n; j++)
				{
					aveFFT[i] += dbFFT[j, i];
				}

				aveFFT[i] /= ave_n;
			}
		}

		public void CalcFFT_AverageExp(int ave_n, ref double[] aveFFT, int now_n)
		{
			int n = FFT_C.FFT_n / 2;

			for (int i = 0; i < n; i++)
			{
				aveFFT[i] = 0.0;

				for (int j = 0, k = now_n + 1; j < ave_n; j++, k++)
				{
					if (k >= ave_n) { k = 0; }

					if (j == 0)
					{
						aveFFT[i] = dbFFT[k, i];
					}
					else
					{
						double x = (double)FFT_C.FFT_Buf_n;
						double y = (double)FFT_C.FFT_Buf_n - 1.0;
						aveFFT[i] = aveFFT[i] * y / x + dbFFT[k, i] * 1.0 / x;
					}
				}
			}
		}

		public void CalcFFT_PeekFillter(ref double[] aveFFT, ref double[] smpFFT)
		{
			int n = smpFFT.Length / 2;

			double[] buf = new double[FFT_C.FFT_Peek_n];
			double sum = new double();

			for (int i = 0, j = 0; i < n; i++)
			{
				sum -= buf[j];

				buf[j] = aveFFT[i];

				sum += buf[j];

				if (i >= FFT_C.FFT_Peek_n)
				{
					smpFFT[i] = sum / (double)FFT_C.FFT_Peek_n;
				}
				else
				{
					smpFFT[i] = aveFFT[i];
				}

				if (i >= 10)
				{
					smpFFT[i - FFT_C.FFT_Peek_n] = smpFFT[i];
				}

				j++;

				if (j >= FFT_C.FFT_Peek_n) { j = 0; }

			}
		}

		private List<FFT_Member> listPeekMin = new List<FFT_Member>();
		private List<FFT_Member> listPeekMax = new List<FFT_Member>();

		private const double _PeekDB = 12;
		
		private double PeekDB
		{
			get
			{
				switch (LogWork.LogPeriod)
				{
					default:
					case 1:
						return _PeekDB;

					case 2:
						return _PeekDB - 3;

					case 4:
						return _PeekDB - 6;
				}
			}
		}

		public void SearchFFT_Peek(double[] fft_buf)
		{
			bool min_on = new bool();
			bool max_on = new bool();

			bool min_last = new bool();
			bool max_last = new bool();

			FFT_Member min = new FFT_Member(100, fft_buf[0]);	//100Hz
			FFT_Member max = new FFT_Member(100, fft_buf[0]);	//100Hz

			listPeekMax.Clear();
			listPeekMin.Clear();

			listPeekMax.Add(new FFT_Member(max.Hz, max.dB));
			listPeekMin.Add(new FFT_Member(min.Hz, min.dB));

			int notch_min = FFT_C.R2FFT(300);
			int notch_max = FFT_C.R2FFT(6000);

			for (int i = 0; i < notch_max; i++)
			{
				if (fft_buf[i] < min.dB)
				{
					min.Hz = i;
					min.dB = fft_buf[i];
					min_on = true;
					max_on = false;
				}

				if (fft_buf[i] >= max.dB)
				{
					max.Hz = i;
					max.dB = fft_buf[i];
					max_on = true;
					min_on = false;
				}

				if (max_on)
				{
					if (listPeekMin[listPeekMin.Count - 1].dB <= max.dB - PeekDB)	//前回の谷より10db以上か
					{
						if (max_last)												//前回も山を検出した
						{
							listPeekMax.RemoveAt(listPeekMax.Count - 1);
						}

						max_on = false;
						max_last = true;
						min_last = false;
						listPeekMax.Add(new FFT_Member(max.Hz, max.dB));
						min.dB = max.dB;
					}
				}

				if (min_on)
				{
					if (listPeekMax[listPeekMax.Count - 1].dB >= min.dB + PeekDB)	//前回の山より10db以下か
					{
						if (min_last)												//前回も谷を検出した
						{
							listPeekMin.RemoveAt(listPeekMin.Count - 1);
						}

						min_on = false;
						min_last = true;
						max_last = false;
						listPeekMin.Add(new FFT_Member(min.Hz, min.dB));
						max.dB = min.dB;
					}
				}
			}

			listPeekMax.RemoveAt(0);	//先頭Dummyを削除
			listPeekMin.RemoveAt(0);	//先頭Dummyを削除

		}

	}
}
