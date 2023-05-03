using System;
using System.Collections.Generic;
using System.Text;

namespace Motion_Designer
{
	// 窓関数
	public enum WindowFunc
	{
		Hamming,
		Hanning,
		Blackman,
		Rectangular
	}

	class FFT
	{

		//サンプリング周波数
		private int SampleFrq = 20000;		//20KHz
		
		public FFT(int frq)
		{
			SampleFrq = frq;
		}

		//DFT
		public void CalcDFT(int n, double[] inputRe, out double[] outputRe, out double[] outputIm)
		{
			outputRe = new double[n];
			outputIm = new double[n];

			for (int i = 0; i < n; i++)
			{
				outputRe[i] = 0.0;
				outputIm[i] = 0.0;

				for (int j = 0; j < n; j++)
				{
					outputRe[i] += inputRe[j] * Math.Cos(2 * Math.PI * i * j / SampleFrq);
					outputIm[i] += inputRe[j] * -(Math.Sin(2 * Math.PI * i * j / SampleFrq));
				}
			}
		}

		//FFT
		public void CalcFFT(double[] inputRe, double[] inputIm, out double[] outputRe, out double[] outputIm, int bitSize)
		{
			int dataSize = 1 << bitSize;
			int[] reverseBitArray = BitScrollArray(dataSize);

			outputRe = new double[dataSize];
			outputIm = new double[dataSize];

			// バタフライ演算のための置き換え
			for (int i = 0; i < dataSize; i++)
			{
				outputRe[i] = inputRe[reverseBitArray[i]];
				outputIm[i] = inputIm[reverseBitArray[i]];
			}

			// バタフライ演算
			for (int stage = 1; stage <= bitSize; stage++)
			{
				int butterflyDistance = 1 << stage;
				int numType = butterflyDistance >> 1;
				int butterflySize = butterflyDistance >> 1;

				double wRe = 1.0;
				double wIm = 0.0;
				double uRe = System.Math.Cos(System.Math.PI / butterflySize);
				double uIm = -System.Math.Sin(System.Math.PI / butterflySize);

				for (int type = 0; type < numType; type++)
				{
					for (int j = type; j < dataSize; j += butterflyDistance)
					{
                        int jp = j + butterflySize;
						double tempRe = outputRe[jp] * wRe - outputIm[jp] * wIm;
						double tempIm = outputRe[jp] * wIm + outputIm[jp] * wRe;
						outputRe[jp] = outputRe[j] - tempRe;
						outputIm[jp] = outputIm[j] - tempIm;
						outputRe[j] += tempRe;
						outputIm[j] += tempIm;
					}
					double tempWRe = wRe * uRe - wIm * uIm;
					double tempWIm = wRe * uIm + wIm * uRe;
					wRe = tempWRe;
					wIm = tempWIm;
				}
			}
		}

		// ビットを左右反転した配列を返す
		private static int[] BitScrollArray(int arraySize)
		{
			int[] reBitArray = new int[arraySize];
			int arraySizeHarf = arraySize >> 1;

			reBitArray[0] = 0;
			for (int i = 1; i < arraySize; i <<= 1)
			{
				for (int j = 0; j < i; j++)
					reBitArray[j + i] = reBitArray[j] + arraySizeHarf;
				arraySizeHarf >>= 1;
			}
			return reBitArray;
		}

		//窓関数
		public double[] Windowing(double[] data, WindowFunc windowFunc)
		{
			int size = data.Length;
			double[] windata = new double[size];

			for (int i = 0; i < size; i++)
			{
				double winValue = 0;
				
				//各々の窓関数
				if (WindowFunc.Hamming == windowFunc)
				{
					winValue = 0.54 - 0.46 * Math.Cos(2 * Math.PI * i / (size - 1));
				}
				else if (WindowFunc.Hanning == windowFunc)
				{
					winValue = 0.5 - 0.5 * Math.Cos(2 * Math.PI * i / (size - 1));
				}
				else if (WindowFunc.Blackman == windowFunc)
				{
					winValue = 0.42 - 0.5 * Math.Cos(2 * Math.PI * i / (size - 1))
									+ 0.08 * Math.Cos(4 * Math.PI * i / (size - 1));
				}
				else if (WindowFunc.Rectangular == windowFunc)
				{
					winValue = 1.0;
				}
				else
				{
					winValue = 1.0;
				}
				//窓関数を掛け算
				windata[i] = data[i] * winValue;
			}
			return windata;
		}
	}
}
