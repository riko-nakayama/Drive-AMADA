using System;
using System.Collections.Generic;
using System.Text;

namespace Motion_Designer
{
	static class CParamID
	{
		public const int MAX_NOTCH_C = 5;
		public const int MAX_LPF_C = 1;

		public const int ModelNo = 2;
		public const int Revision = 3;
		public const int Serial = 4;

		public const int ServoStatus = 20;
		public const int IoStatus = 21;
		public const int AlarmCode = 22;

        #region アラーム履歴

        public const int AlarmHistory1 = 23;
        public const int AlarmHistory2 = 24;
        public const int SelectAlarmHistory = 25;
        public const int AlarmHistoryInf = 26;

        #endregion

		public const int ServoCommand = 30;
		public const int ControlMode = 31;

		public const int TargetPosition = 32;
		public const int TargetVelocity = 33;
		public const int TargetAcceleration = 34;
		public const int TargetDeceleration = 35;

		public const int CommandPosition = 36;
		public const int CommandVelocity = 37;
		public const int CommandCurrent = 38;

		public const int FeedbackPosition = 40;
		public const int FeedbackVelocity = 41;
		public const int FeedbackCurrent = 42;

        public const int Position_Deviation = 49;

		public const int Kp1 = 50;
		public const int Kv1 = 51;
		public const int Ki1 = 52;
		public const int Lpf1_f = 53;
		public const int Nf1_f = 54;
		public const int Nf1_d = 55;
		public const int Kcp1 = 56;
		public const int Kci1 = 57;
		public const int PhaseAdvance = 58;
		public const int Load = 59;	
		public const int Kp2 = 60;
		public const int Kv2 = 61;
		public const int Ki2 = 62;
		public const int Nf2_f = 63;
		public const int Nf2_d = 64;

		public const int KpffGain = 68;
		public const int ControlSwitch = 69;

		public const int PositionInputMode = 74;
		public const int VelocityInputMode = 75;
		public const int CurrentInputMode = 76;
		public const int InpositionWidth = 77;

		public const int InputConfig1 = 100;
		public const int InputConfig2 = 101;
		public const int InputConfig3 = 102;
		public const int InputConfig4 = 103;
		public const int InputConfig5 = 104;
		public const int InputConfig6 = 105;
		public const int InputConfig7 = 106;
		public const int InputConfig8 = 107;

		public const int OutputConfig1 = 110;
		public const int OutputConfig2 = 111;
		public const int OutputConfig3 = 112;
		public const int OutputConfig4 = 113;
		public const int OutputConfig5 = 114;

        public const int ForcedBrakeoff = 149;  //Ver1.34 add

		public const int DynamicBreakCondition = 154;		//20170215 add
		
		public const int OverLoadMonitor = 159;
		public const int DriverTemp = 160;
		public const int PowerVoltage = 161;

        #region 簡易コントロール

        public const int ControlProgStep = 166;

        public const int ProgramPointer = 176;
        public const int ProgramData0 = 177;
        public const int ProgramData1 = 178;
        public const int ProgramData2 = 179;

		#endregion

		// Ver 1.35 ↓↓↓
		public const int HSTotalCnt = 305;		//177;	// 高速側トータル回数カウント
		public const int TrqTotalCnt = 306;		//178;	// 高トルク側トータル回数カウント
		public const int HSSuccessCnt = 307;    //179;	// 高速側成功回数カウント
		public const int TrqSuccessCnt = 308;	//180;	// 高トルク側成功回数カウント
		public const int HSClutchSwitchTime = 183;		// 高速側クラッチ切替時間
		public const int TrqClutchSwitchTime = 184;		// 高トルク側クラッチ切替時間
		// Ver 1.35 ↑↑↑

		public const int ClutchExcitation = 199;    // Ver1.33 add AMADA Inspection

		public const int PositionErrorPulse = 202;

		public const int MotorNo = 210;

		public const int MotorInertia = 216;
		public const int EncderType = 218;
		public const int EncderResolution = 219;

		public const int RDType = 224;

        public const int InertiaManif = 227;    //イナーシャ倍率設定 20210324 Kimura add

        #region カレンダ

        public const int CalendarDate = 240;
        public const int CalendarTime = 241;

        #endregion

		public const int ControlSwitch2 = 256;
		public const int ObserberSwitch = 257;

		public const int C_LPF_f = 260;
		public const int C_LPF_n = 261;
		public const int V_LPF_f = 265;

		public const int C_FB_Lpf = 266;
		public const int V_FB_Lpf = 267;
		public const int V_FB_n = 268;
		//public const int P_FB_n = 269;
		
		public const int C_NF1_f = 270;
		public const int C_NF1_d = 271;
		public const int C_NF1_q = 272;
		public const int C_NF2_f = 273;
		public const int C_NF2_d = 274;
		public const int C_NF2_q = 275;
		public const int C_NF3_f = 276;
		public const int C_NF3_d = 277;
		public const int C_NF3_q = 278;
		public const int C_NF4_f = 279;
		public const int C_NF4_d = 280;
		public const int C_NF4_q = 281;
		public const int C_NF5_f = 282;
		public const int C_NF5_d = 283;
		public const int C_NF5_q = 284;

		public const int KvffGain = 290;
		public const int KvffFillter = 291;

		public const int FrictionCwTrq = 300;
		public const int FrictionCcwTrq = 301;
		public const int FrictionDynamicTrq = 302;
		public const int FrictionGravityTrq = 303;

		public const int CounterClear = 309;		// カウンタクリアフラグ  Ver1.35 add

		public const int TorqueObserverGain = 310;
		public const int TorqueObserverFreq = 311;

		public const int VelocityObserverTime = 320;
		public const int VelocityObserverGain1 = 321;
		public const int VelocityObserverGain2 = 322;

		public const int ModelControlGain1 = 350;
		public const int ModelControlGain2 = 351;
		public const int ModelControlGain3 = 352;
		public const int ModelControlGain4 = 353;
		public const int ModelControlGain5 = 354;
		public const int ModelControlFillter1 = 355;
		public const int ModelControlFillter2 = 356;
		public const int ModelControlFillter3 = 357;
		public const int ModelControlPrm1 = 359;

		public const int TuningFreeEnable = 360;			//20180307 add
		public const int TuningFreeStrength = 361;

		public const int AutoTuningSequence = 400;
		public const int TempLoadInertia = 401;
		public const int SweepMaxFrq = 402;
		public const int SweepMinFrq = 403;
		public const int SweepMeasT = 404;
		public const int CurrentVibrationDiv = 405;
		public const int CurrentVibrationCnt = 406;

		public const int LogPeriod = 419;

        public const int MotorTemp = 421;               // Ver1.33 add AMADA Inspection

		public const int LogKind1 = 500;
		public const int LogKind2 = 501;
		public const int LogKind3 = 502;
		public const int LogKind4 = 503;
		public const int LogKind5 = 504;
		public const int LogKind6 = 505;
		public const int LogKind7 = 506;
		public const int LogFFT_Frq  = 509;
		public const int LogFFT_Kind = 510;

		//↓↓↓ Amada Mode Ver1.34 ↓↓↓
		public const int TestMonitor1 = 430;
		//↑↑↑ Amada Mode Ver1.34 ↑↑↑

		//not use 
		public const int V_LPF_n = 450;
		public const int V_NF1_f = 451;
		public const int V_NF1_d = 452;
		public const int V_NF1_q = 453;

		public const int P_LPF_f = 454;
		public const int P_LPF_n = 455;
		public const int P_NF1_f = 456;
		public const int P_NF1_d = 457;
		public const int P_NF1_q = 458;

		//↓↓↓ ART HIKARI Mode 20170919 Kimura add ↓↓↓
		public const int ProgramNumber = 290;
		//↑↑↑ ART HIKARI Mode 20170919 Kimura add ↑↑↑

        //↓↓↓ KASHIYAMA Mode 20190624 Kimura add ↓↓↓
        public const int OutputPower = 154;
        //↑↑↑ KASHIYAMA Mode 20190624 Kimura add ↑↑↑

	}

	static class CMonitor
	{

		public const int ParameterPageSize = 256;
		public const int ParameterSize = 512;

		static private int[] ParameterBuf = new int[ParameterSize];

		static public int[] GetBufPtr()
		{
			return ParameterBuf;
		}

		static public void SetParameter(int page, int[] buf)
		{
			switch (page)
			{
				case 0:

					for (int i = 0; i < ParameterPageSize; i++)
					{
						ParameterBuf[i] = buf[i];
					}
					break;

				case 1:

					for (int i = 0; i < ParameterPageSize; i++)
					{
						ParameterBuf[i + ParameterPageSize] = buf[i];
					}
					break;
			}
		}

		static public int GetParameter(int id)
		{
			if (id < 512)
			{
				return ParameterBuf[id];
			}

			return 0;
		}

		static public void SetData(int id, int data)
		{
			ParameterBuf[id] = data;
		}

	}
}
