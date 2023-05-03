using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace Motion_Designer
{
	public enum TuningEncder
	{
		Resolver, Resolver2X, Resolver4X, Resolver5X, Resolver8X, Enc2000, Enc2048, Enc2500, Enc17B, Enc20B, Enc23B
	}

	public enum TuningMachine
	{
		Disk, Screw, Belt
	}

	public enum TuningStrength
	{
		Light, Middle, Strong
	}

	public enum TuningPriorty
	{
		Normal, Position, Stiffness
	}

	public enum TuningAction
	{
		KppUp,
		KvpUp,
		KviUp,
		KppDown,
		KvpDown,
		KviDown,
		LpfNew,
		Nf1New,
		Nf2New,
		Nf3New,
		Nf4New,
		Nf5New,
		LpfUpdate,
		Nf1Update,
		Nf2Update,
		Nf3Update,
		Nf4Update,
		Nf5Update,
		Nf1Del,
		Nf2Del,
		Nf3Del,
		Nf4Del,
		Nf5Del,
	}

	public partial class AutoTuningForm : Form
	{

		public class GainMember
		{
			public int Kpp = new int();
			public int Kvp = new int();
			public int Kvi = new int();

			public int PositiveInposTime = new int();
			public int NegativeInposTime = new int();

			public GainMember()
			{
			}

			public GainMember(GainMember gain)
			{
				Kpp = gain.Kpp;
				Kvp = gain.Kvp;
				Kvi = gain.Kvi;

				PositiveInposTime = gain.PositiveInposTime;
				NegativeInposTime = gain.NegativeInposTime;
			}

		}

		public class NotchMember
		{
			public int Hz;
			public int Depth;
			public int Width;

			public int Index;

			public int Count;

			public FFT_Member fftResult = new FFT_Member();
		
			public NotchMember(NotchMember notch)
			{
				Hz = notch.Hz;
				Depth = notch.Depth;
				Width = notch.Width;
				Index = notch.Index;
				Count = notch.Count;
			}

			public NotchMember(int f, int d, int w, int idx, int cnt, FFT_Member fft)
			{
				Hz = f;
				Depth = d;
				Width = w;
				Index = idx;
				Count = cnt;

				fftResult.dB = fft.dB;
				fftResult.dBsub = fft.dBsub;
			}

		}

		public class LpfMember
		{
			public int Hz;

			public int Index;

			public LpfMember(LpfMember lpf)
			{
				Hz = lpf.Hz;
				Index = lpf.Index;
			}

			public LpfMember(int f, int idx)
			{
				Hz = f;
				Index = idx;
			}

		}

	}
}
