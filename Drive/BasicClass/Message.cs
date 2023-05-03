using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
 
namespace Motion_Designer
{
    static public class UserText
    {
        #region CtlJogContorl
        /// <summary>
        /// "正転"
        /// </summary>
        static public string CtlJogControlCw
        {
            get
            {

                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "　正転";

                    case Culture.US:
                        return "　CW";

                    case Culture.CN:
                        return "　 正向运行";
                }
            }
        }

        /// <summary>
        /// "逆転"
        /// </summary>
        static public string CtlJogControlCcw
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "　逆転";

                    case Culture.US:
                        return "　CCW";

                    case Culture.CN:
                        return "　 反向运行";
                }
            }
        }

        /// <summary>
        /// "移動"
        /// </summary>
        static public string CtlJogControlMove
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "　移動";

                    case Culture.US:
                        return "　Move";

                    case Culture.CN:
                        return "　移动";
                }
            }
        }

        /// <summary>
        /// "目標速度 [rpm]"
        /// </summary>
        static public string CtlJogControlTargetVelocity
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "目標速度 [rpm]";

                    case Culture.US:
						//return "Tareget speed [rpm]";
						return "Tareget Speed [rpm]";

                    case Culture.CN:
                        return "目标速度 [rpm]";
                }
            }
        }

        /// <summary>
        /// "指令速度 [rpm]"
        /// </summary>
        static public string CtlJogControlCommandVelocity
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "指令速度 [rpm]";

                    case Culture.US:
						//return "Command speed [rpm]";
						return "Command Speed [rpm]";

                    case Culture.CN:
                        return "指令速度 [rpm]";
                }
            }
        }

        /// <summary>
        /// "指令電流 [0.01A]"
        /// </summary>
        static public string CtlJogControlCommandCurrent
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "指令電流 [0.01A]";

                    case Culture.US:
						//return "Command current [0.01A]";
						return "Command Current [0.01A]";

                    case Culture.CN:
                        return "指令电流 [0.01A]";
                }
            }
        }

        /// <summary>
        /// "サーボオン"
        /// </summary>
        static public string CtlJogControlServoOn
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "サーボオン";

                    case Culture.US:
                        return "Servo ON";

                    case Culture.CN:
                        return "伺服ON";
                }
            }
        }

        /// <summary>
        /// "プロファイル"
        /// </summary>
        static public string CtlJogControlProfile
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:

                        //↓↓↓ KASHIYAMA Mode 20190624 Kimura update ↓↓↓
                        if (Properties.Settings.Default.PASSWORD_KASHIYAMA == false)
                        {
                            return "プロファイル";
                        }
                        else
                        {
                            return "予約";
                        }
                        //↑↑↑ KASHIYAMA Mode 20190624 Kimura update ↑↑↑

                    case Culture.US:
                        return "Profile";

                    case Culture.CN:
                        return "配置文件";
                }
            }
        }

        /// <summary>
        /// "インポジション"
        /// </summary>
        static public string CtlJogControlInposition
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:

                        //↓↓↓ KASHIYAMA Mode 20190624 Kimura update ↓↓↓
                        if (Properties.Settings.Default.PASSWORD_KASHIYAMA == false)
                        {
                            return "インポジション";
                        }
                        else
                        {
                            return "予約";
                        }
                        //↑↑↑ KASHIYAMA Mode 20190624 Kimura update ↑↑↑

                    case Culture.US:
						//return "In-position";
						return "In-Position";

                    case Culture.CN:
                        return "定位";
                }
            }
        }

        /// <summary>
        /// "アラーム検出"
        /// </summary>
        static public string CtlJogControlAlarm
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "アラーム検出";

                    case Culture.US:
					//	return "Alarm detection";
						return "Alarm";

                    case Culture.CN:
                        return "警报检测";
                }
            }
        }

        /// <summary>
        /// "正方向リミット"
        /// </summary>
        static public string CtlJogControlPositiveLimit
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:

                        //↓↓↓ KASHIYAMA Mode 20190624 Kimura update ↓↓↓
                        if (Properties.Settings.Default.PASSWORD_KASHIYAMA == false)
                        {
                            return "正方向リミット";
                        }
                        else
                        {
                            return "予約";
                        }
                        //↑↑↑ KASHIYAMA Mode 20190624 Kimura update ↑↑↑

                    case Culture.US:
						//return "CW direction limit";
						return "CW Limit";

                    case Culture.CN:
                        return "正方向界限";
                }
            }
        }

        /// <summary>
        /// "負方向リミット"
        /// </summary>
        static public string CtlJogControlNegativeLimit
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:

                        //↓↓↓ KASHIYAMA Mode 20190624 Kimura update ↓↓↓
                        if (Properties.Settings.Default.PASSWORD_KASHIYAMA == false)
                        {
                            return "負方向リミット";
                        }
                        else
                        {
                            return "予約";
                        }
                        //↑↑↑ KASHIYAMA Mode 20190624 Kimura update ↑↑↑

                    case Culture.US:
						//return "CCW direction limit";
						return "CCW Limit";

                    case Culture.CN:
                        return "反方向界限";
                }
            }
        }

        /// <summary>
        /// "トルクリミット"
        /// </summary>
        static public string CtlJogControlTorqueLimit
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "トルクリミット";

                    case Culture.US:
						//return "Torque limit";
						return "Torque Limit";

                    case Culture.CN:
                        return "电流界限";
                }
            }
        }

        /// <summary>
        /// "速度リミット"
        /// </summary>
        static public string CtlJogControlVelocityLimit
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "速度リミット";

                    case Culture.US:
						//return "Speed limit";
						return "Speed Limit";

                    case Culture.CN:
                        return "速度界限";
                }
            }
        }

        /// <summary>
        /// "位置偏差過大"
        /// </summary>
        static public string CtlJogControlPositionErrorOver
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:

                        //↓↓↓ KASHIYAMA Mode 20190624 Kimura update ↓↓↓
                        if (Properties.Settings.Default.PASSWORD_KASHIYAMA == false)
                        {
                            return "位置偏差過大";
                        }
                        else
                        {
                            return "予約";
                        }
                        //↑↑↑ KASHIYAMA Mode 20190624 Kimura update ↑↑↑

                    case Culture.US:
						//return "Excessive position error";
						return "Position Error";

                    case Culture.CN:
                        return "位置偏差过大";
                }
            }
        }

        /// <summary>
        /// "サーボレディ"
        /// </summary>
        static public string CtlJogControlServoReady
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "サーボレディ";

                    case Culture.US:
						//return "Servo ready";
						return "Servo Ready";

                    case Culture.CN:
                        return "伺服就绪";
                }
            }
        }

        /// <summary>
        /// "原点復帰中"
        /// </summary>
        static public string CtlJogControlHoming
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        
                        //↓↓↓ KASHIYAMA Mode 20190624 Kimura update ↓↓↓
                        if (Properties.Settings.Default.PASSWORD_KASHIYAMA == false)
                        {
                            return "原点復帰中";
                        }
                        else
                        {
                            return "速度一致";
                        }
                        //↑↑↑ KASHIYAMA Mode 20190624 Kimura update ↑↑↑

                    case Culture.US:
                        return "Homing";

                    case Culture.CN:
                        return "原点复位中";
                }
            }
        }

        /// <summary>
        /// "第2ゲイン選択"
        /// </summary>
        static public string CtlJogControlSecondGain
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "第2ゲイン選択";

                    case Culture.US:
						//return "Select 2nd gain";
						return "Select 2nd Gain";

                    case Culture.CN:
                        return "第2增益选择";
                }
            }
        }

        /// <summary>
        /// "電池電圧低下"
        /// </summary>
        static public string CtlJogControlBattWarning
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:

                        //↓↓↓ KASHIYAMA Mode 20190624 Kimura update ↓↓↓
                        if (Properties.Settings.Default.PASSWORD_KASHIYAMA == false)
                        {
                            return "電池電圧低下";
                        }
                        else
                        {
                            return "予約";
                        }
                        //↑↑↑ KASHIYAMA Mode 20190624 Kimura update ↑↑↑

                    case Culture.US:
						//return "battery voltage drop";
						return "Battery Warning";

                    case Culture.CN:
                        return "电池电压降低";
                }
            }
        }

        /// <summary>
        /// "駆動電源断"
        /// </summary>
        static public string CtlJogControlPowerVoltageError
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "駆動電源断";

                    case Culture.US:
						//return "Shut dowm drive power";
						//return "Power Down";
						return "Voltage Drop";

                    case Culture.CN:
                        return "驱动电源断";
                }
            }
        }

        /// <summary>
        /// "停止速度状態"
        /// </summary>
        static public string CtlJogControlStopVelocity
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:

                        //↓↓↓ KASHIYAMA Mode 20190624 Kimura update ↓↓↓
                        if (Properties.Settings.Default.PASSWORD_KASHIYAMA == false)
                        {
                            return "停止速度状態";
                        }
                        else
                        {
                            return "ゼロ速度状態";
                        }
                        //↑↑↑ KASHIYAMA Mode 20190624 Kimura update ↑↑↑

                    case Culture.US:
						//return "Stop status";
						return "Stop Status";

                    case Culture.CN:
                        return "停止速度状态";
                }
            }
        }

        /// <summary>
        /// "予約"
        /// </summary>
        static public string CtlJogControlReserve
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "予約";

                    case Culture.US:
                        return "Reserve";

                    case Culture.CN:
                        return "预约";
                }
            }
        }

        /// <summary>
        /// "メカブレーキ"
        /// </summary>
        static public string CtlJogControlMechBrake
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        
                        //↓↓↓ KASHIYAMA Mode 20190624 Kimura update ↓↓↓
                        if (Properties.Settings.Default.PASSWORD_KASHIYAMA == false)
                        {
                            return "メカブレーキ";
                        }
                        else
                        {
                            return "予約";
                        }
                        //↑↑↑ KASHIYAMA Mode 20190624 Kimura update ↑↑↑

                    case Culture.US:
						//return "Mechanical brake";
						return "Brake Release";

                    case Culture.CN:
                        return "机械制动";
                }
            }
        }

        /// <summary>
        /// "目標位置到達"
        /// </summary>
        static public string CtlJogControlReachTargetPosition
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        
                        //↓↓↓ KASHIYAMA Mode 20190624 Kimura update ↓↓↓
                        if (Properties.Settings.Default.PASSWORD_KASHIYAMA == false)
                        {
                            return "目標位置到達";
                        }
                        else
                        {
                            return "予約";
                        }
                        //↑↑↑ KASHIYAMA Mode 20190624 Kimura update ↑↑↑

                    case Culture.US:
						//return "Reach to target position";
						//return "Reach to Target";
						return "Target Achieve";
                    case Culture.CN:
                        return "目标位置到达";
                }
            }
        }

        /// <summary>
        /// "主電源オン"
        /// </summary>
        static public string CtlJogControlEcatMainPowerOn
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "主電源オン";

                    case Culture.US:
						//return "Main power ON";
						return "Power ON";

                    case Culture.CN:
                        return "主电源ON";
                }
            }
        }

        /// <summary>
        /// "Qストップ"
        /// </summary>
        static public string CtlJogControlEcatQStop
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "Qストップ";

                    case Culture.US:
						//return "Q-stop";
						return "Q-Stop";

                    case Culture.CN:
                        return "Q停止";
                }
            }
        }

        /// <summary>
        /// "初期化完了"
        /// </summary>
        static public string CtlJogControlEcatInitEnd
        {
            get
            {

                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "初期化完了";

                    case Culture.US:
						//return "Complete initialization";
						return "Complete Init";

                    case Culture.CN:
                        return "初始化完成";
                }
            }
        }

        /// <summary>
        /// "警告"
        /// </summary>
        static public string CtlJogControlEcatWarning
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "警告";

                    case Culture.US:
						//return "Caution";
						return "Warning";

                    case Culture.CN:
                        return "警告";
                }
            }
        }

        /// <summary>
        /// "主電源オフ"
        /// </summary>
        static public string CtlJogControlEcatMainPowerOff
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "主電源オフ";

                    case Culture.US:
						//return "Main power OFF";
						return "Power OFF";

                    case Culture.CN:
                        return "主电源OFF";
                }
            }
        }

        /// <summary>
        /// "サーボオン"
        /// </summary>
        static public string CtlJogControlEcatServoOn
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "サーボオン";

                    case Culture.US:
                        return "Servo ON";

                    case Culture.CN:
                        return "伺服ON";
                }
            }
        }

        /// <summary>
        /// "サーボレディ"
        /// </summary>
        static public string CtlJogControlEcatServoReady
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "サーボレディ";

                    case Culture.US:
						//return "Servo ready";
						return "Servo Ready";

                    case Culture.CN:
                        return "伺服就绪";
                }
            }
        }

        /// <summary>
        /// "アラーム"
        /// </summary>
        static public string CtlJogControlEcatAlarm
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "アラーム";

                    case Culture.US:
                        return "Alarm";

                    case Culture.CN:
                        return "警报";
                }
            }
        }

        /// <summary>
        /// "メーカー予約"
        /// </summary>
        static public string CtlJogControlEcatManufacturerReserve
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "メーカー予約";

                    case Culture.US:
						//return "Reserve by manufacturer";
						return "Reserve";

                    case Culture.CN:
                        return "厂家预约";
                }
            }
        }

        /// <summary>
        /// "リモート"
        /// </summary>
        static public string CtlJogControlEcatRemote
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "リモート";

                    case Culture.US:
                        return "Remote";

                    case Culture.CN:
                        return "远程";
                }
            }
        }

        /// <summary>
        /// "目標値"
        /// </summary>
        static public string CtlJogControlEcatTarget
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "目標値";

                    case Culture.US:
						//return "Target value";
						return "Target Value";

                    case Culture.CN:
                        return "目标值";
                }
            }
        }

        /// <summary>
        /// "目標値内部制限有"
        /// </summary>
        static public string CtlJogControlEcatInternalLimit
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "目標値内部制限有";

                    case Culture.US:
						//return "Target value internal restriction ON";
						return "Target Limit";

                    case Culture.CN:
                        return "有目标值内部限制";
                }
            }
        }

        /// <summary>
        /// "目標値無視"
        /// </summary>
        static public string CtlJogControlEcatIgnoreTarget
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "目標値無視";

                    case Culture.US:
						//return "Ignore target value";
						return "Ignore Target";

                    case Culture.CN:
                        return "忽视目标值";
                }
            }
        }

        /// <summary>
        /// "位置偏差大"
        /// </summary>
        static public string CtlJogControlEcatPositionErrorOver
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "位置偏差大";

                    case Culture.US:
						//return "Large position error";
						return "Position Error";

                    case Culture.CN:
                        return "位置偏差大";
                }
            }
        }

        /// <summary>
        /// "目標位置・目標速度・加減速度　読み込み中"
        /// </summary>
        static public string CtlJogControlTargetReading
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "目標位置・目標速度・加減速度　読み込み中";

                    case Culture.US:
                        return "Reading Target Position, Target Speed, Acc/Dce.";

                    case Culture.CN:
                        return "目标位置・目标速度・加减速度　读取中";
                }
            }
        }

        //↓↓↓ KASHIYAMA Mode 20190624 Kimura add ↓↓↓

        static public string CtlJogControlServoStatusB15
        {
            get
            {
                if (Properties.Settings.Default.PASSWORD_KASHIYAMA == true)
                {
                    return "電力過大";
                }
                else
                {
                    return CtlJogControlReserve;
                }
            }
        }

        static public string CtlJogControlServoStatusB18
        {
            get
            {
                if (Properties.Settings.Default.PASSWORD_KASHIYAMA == true)
                {
                    return "電流振動";
                }
                else
                {
                    return CtlJogControlReserve;
                }
            }
        }

        static public string CtlJogControlServoStatusB19
        {
            get
            {
                if (Properties.Settings.Default.PASSWORD_KASHIYAMA == true)
                {
                    return "通信制御権";
                }
                else
                {
                    return CtlJogControlReserve;
                }
            }
        }

        static public string CtlJogControlServoStatusB20
        {
            get
            {
                if (Properties.Settings.Default.PASSWORD_KASHIYAMA == true)
                {
                    return "アラームビット0";
                }
                else
                {
                    return CtlJogControlReserve;
                }
            }
        }

        static public string CtlJogControlServoStatusB21
        {
            get
            {
                if (Properties.Settings.Default.PASSWORD_KASHIYAMA == true)
                {
                    return "アラームビット1";
                }
                else
                {
                    return CtlJogControlReserve;
                }
            }
        }

        static public string CtlJogControlServoStatusB22
        {
            get
            {
                if (Properties.Settings.Default.PASSWORD_KASHIYAMA == true)
                {
                    return "アラームビット2";
                }
                else
                {
                    return CtlJogControlReserve;
                }
            }
        }

        //↑↑↑ KASHIYAMA Mode 20190624 Kimura add ↑↑↑

        #endregion

        #region CtlBodePlot

        /// <summary>
        /// "周波数[Hz]"
        /// </summary>
        static public string CtlBodePlotFrequency
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "周波数 [Hz]";

                    case Culture.US:
                        return "Frequency [Hz]";

                    case Culture.CN:
                        return "频率 [Hz]";
                }
            }
        }

        /// <summary>
        /// "時間[msec]"
        /// </summary>
        static public string CtlBodePlotTime
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "時間 [msec]";

                    case Culture.US:
                        return "Time [msec]";

                    case Culture.CN:
                        return "时间 [msec]";
                }
            }
        }

        /// <summary>
        /// "振幅"
        /// </summary>
        static public string CtlBodePlotAmplitude
        {
            get
            {

                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "振幅 [db]";

                    case Culture.US:
						return "Amplitude [db]";

                    case Culture.CN:
						return "振幅 [db]";
                }
            }
        }

        #endregion

        #region CtlPlotMenu

        /// <summary>
        /// "最大化"
        /// </summary>
        static public string CtlPlotMenuMaximum
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "最大化";

                    case Culture.US:
                        return "Maximize";

                    case Culture.CN:
                        return "最大化";
                }
            }
        }

        /// <summary>
        /// "最小化"
        /// </summary>
        static public string CtlPlotMenuMinimum
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "最小化";

                    case Culture.US:
                        return "Minimize";

                    case Culture.CN:
                        return "最小化";
                }
            }
        }

		/// <summary>
		/// "停止"
		/// </summary>
		static public string CtlPlotMenuStop
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "停止";

					case Culture.US:
						return "Stop";

					case Culture.CN:
						return "停止";
				}
			}
		}

		/// <summary>
		/// "再開"
		/// </summary>
		static public string CtlPlotMenuRestart
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "再開";

					case Culture.US:
						return "Resume";

					case Culture.CN:
						return "恢复";
				}
			}
		}

        #endregion

        #region AboutBox

        /// <summary>
        /// "バージョン情報"
        /// </summary>
        static public string AboutBoxVersionInformation
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "バージョン情報";

                    case Culture.US:
                        return "Version Information";

                    case Culture.CN:
                        return "版本信息";
                }
            }
        }

        #endregion

        #region DigitalOsilloForm

        /// <summary>
        /// "ログファイルを開く"
        /// </summary>
        static public string DigitalOsilloLogOpenTitle
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "ログファイルを開く";

                    case Culture.US:
                        return "Open Log File";

                    case Culture.CN:
                        return "打开记录表";
                }
            }
        }

        /// <summary>
        /// "ログファイルを保存"
        /// </summary>
        static public string DigitalOsilloLogeSaveTitle
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "ログファイルを保存";

                    case Culture.US:
                        return "Save Log File";

                    case Culture.CN:
                        return "记录表保存";
                }
            }
        }

        /// <summary>
        /// "画像保存"
        /// </summary>
        static public string DigitalOsilloPicSaveTitle
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "画像保存";

                    case Culture.US:
                        return "Save Screen";

                    case Culture.CN:
                        return "图像保存";
                }
            }
        }

        /// <summary>
        /// "ログデータを変換中．．．"
        /// </summary>
        static public string DigitalOsilloLogConvert
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "ログデータを変換中．．．";

                    case Culture.US:
                        return "Converting Log Data...";

                    case Culture.CN:
                        return "日志数据变换中．．．";
                }
            }
        }

        /// <summary>
        /// "ログデータを保存中．．．";
        /// </summary>
        static public string DigitalOsilloLogSave
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "ログデータを保存中．．．";

                    case Culture.US:
                        return "Saving Log Data...";

                    case Culture.CN:
                        return "日志数据保存中．．．";
                }
            }
        }

        /// <summary>
        /// "「偏差」 表示の線種と線サイズを選択します。"
        /// </summary>
        static public string DigitalOsilloLineDialogTitlePerr
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "「偏差」 表示の" + "\n" + "  線種と線サイズを選択します。";

                    case Culture.US:
						return "To indicate Error" + "\n" + "Select graph line style and size.";

                    case Culture.CN:
						return "选择显示「偏差」" + "\n" + "的线型和线粗细 。";
                }
            }
        }

        /// <summary>
        /// "「速度」 表示の線種と線サイズを選択します。"
        /// </summary>
        static public string DigitalOsilloLineDialogTitleVel
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
						return "「速度」 表示の" + "\n" + "  線種と線サイズを選択します。";

                    case Culture.US:
						return "To indicate Speed" + "\n" + "Select graph line style and size.";

                    case Culture.CN:
						return "选择显示「速度」" + "\n" + "的线型和线粗细。";
                }
            }
        }

        /// <summary>
        /// "「電流」 表示の線種と線サイズを選択します。"
        /// </summary>
        static public string DigitalOsilloLineDialogTitleCur
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
						return "「電流」 表示の" + "\n" + "  線種と線サイズを選択します。";

                    case Culture.US:
						return "To indicate Current" + "\n" + "Select graph line style and size.";

                    case Culture.CN:
						return "选择显示「电流」 " + "\n" + "的线型和线粗细。";
                }
            }
        }

        /// <summary>
        /// "「パラメタ1」 表示の線種と線サイズを選択します。"
        /// </summary>
        static public string DigitalOsilloLineDialogTitlePrm1
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
						return "「パラメタ1」 表示の" + "\n" + "  線種と線サイズを選択します。";

                    case Culture.US:
						return "To indicate Parameter 1" + "\n" + "Select graph line style and size.";

                    case Culture.CN:
						return "选择显示「参数1」 " + "\n" + "的线型和线粗细。";
                }
            }
        }

        /// <summary>
        /// "「パラメタ2」 表示の線種と線サイズを選択します。"
        /// </summary>
        static public string DigitalOsilloLineDialogTitlePrm2
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
						return "「パラメタ2」 表示の" + "\n" + "  線種と線サイズを選択します。";

                    case Culture.US:
						return "To indicate Parameter 2" + "\n" + "Select graph line style and size.";

                    case Culture.CN:
						return "选择显示「参数2」" + "\n" + "的线型和线粗细。";
                }
            }
        }

        /// <summary>
        /// "「パラメタ3」 表示の線種と線サイズを選択します。"
        /// </summary>
        static public string DigitalOsilloLineDialogTitlePrm3
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
						return "「パラメタ3」 表示の" + "\n" + "  線種と線サイズを選択します。";

                    case Culture.US:
						return "To indicate Parameter 3" + "\n" + "Select graph line style and size.";

                    case Culture.CN:
						return "选择显示「参数3」 " + "\n" + "的线型和线粗细。";
                }
            }
        }

        /// <summary>
        /// "「コマンドポジション」 表示の線種と線サイズを選択します。"
        /// </summary>
        static public string DigitalOsilloLineDialogTitleCmdPos
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
						return "「コマンドポジション」 表示の" + "\n" + "  線種と線サイズを選択します。";

                    case Culture.US:
						return "To indicate Command Position" + "\n" + "Select graph line style and size.";

                    case Culture.CN:
						return "选择显示「指令位置」" + "\n" + "的线型和线粗细。";
                }
            }
        }

        /// <summary>
        /// "「インポジション」 表示の線種と線サイズを選択します。"
        /// </summary>
        static public string DigitalOsilloLineDialogTitleInPos
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
						return "「インポジション」 表示の" + "\n" + "  線種と線サイズを選択します。";

                    case Culture.US:
						return "To indicate In-position" + "\n" + "Select graph line style and size.";

                    case Culture.CN:
						return "选择显示「定位」 " + "\n" + "的线型和线粗细。";
                }
            }
        }

        /// <summary>
        /// "「時間目盛」 表示の線種と線サイズを選択します。"
        /// </summary>
        static public string DigitalOsilloLineDialogTitleScale
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
						return "「時間目盛」 表示の" + "\n" + "  線種と線サイズを選択します。";

                    case Culture.US:
						return "To indicate Time Scale" + "\n" + "Select graph line style and size.";

                    case Culture.CN:
						return "选择显示「时间刻度」" + "\n" + "的线型和线粗细。";
                }
            }
        }

        /// <summary>
        /// "「時間計測バー」 表示の線種と線サイズを選択します。"
        /// </summary>
        static public string DigitalOsilloLineDialogTitleMeas
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
						return "「時間計測バー」 表示の" + "\n" + "  線種と線サイズを選択します。";

                    case Culture.US:
						return "To indicate Time Measurement Bar" + "\n" + "Select graph line style and size.";

                    case Culture.CN:
						return "选择显示「时间测量杆」" + "\n" + "的线型和线粗细。";
                }
            }
        }

        /// <summary>
        /// "「トリガー」 表示の線種と線サイズを選択します。"
        /// </summary>
        static public string DigitalOsilloLineDialogTitleTrg
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
						return "「トリガー」 表示の" + "\n" + "  線種と線サイズを選択します。";

                    case Culture.US:
						return "To indicate Trigger" + "\n" + "Select graph line style and size.";

                    case Culture.CN:
						return "选择显示「触发器」 " + "\n" + "的线型和线粗细。";
                }
            }
        }

        /// <summary>
        /// "以上"
        /// </summary>
        static public string DigitalOsilloGe
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "以上";

                    case Culture.US:
                        return "Over";

                    case Culture.CN:
                        return "以上";
                }
            }
        }

        /// <summary>
        /// "以下"
        /// </summary>
        static public string DigitalOsilloLe
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "以下";

                    case Culture.US:
                        return "Under";

                    case Culture.CN:
                        return "以下";
                }
            }
        }

        /// <summary>
        /// "整定時間 "
        /// </summary>
        static public string DigitalOsilloInpositionTime
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "整定時間 ";

                    case Culture.US:
                        return "Settling Time ";

                    case Culture.CN:
                        return "整定时间 ";
                }
            }
        }

        /// <summary>
        /// "計測不能"
        /// </summary>
        static public string DigitalOsilloInpositionTimeError
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "計測不能";

                    case Culture.US:
                        return "Unmeasurable";

                    case Culture.CN:
                        return "不能测量";
                }
            }
        }

        /// <summary>
        /// "トリガ条件 "
        /// </summary>
        static public string DigitalOsilloTriggerCondition
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "トリガ条件 ";

                    case Culture.US:
                        return "Trigger Condition ";

                    case Culture.CN:
                        return "触发器条件 ";
                }
            }
        }

        #endregion

        #region TuningParameter

        /// <summary>
        /// "・負荷イナーシャー　"
        /// </summary>
        static public string TuningParameterInertia
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "・負荷イナーシャー　";

                    case Culture.US:
						//return "・Load inertia";
						return "- Load Inertia  ";

                    case Culture.CN:
                        return "・负载惯量　";
                }
            }
        }

        /// <summary>
        /// "・イナーシャー比　"
        /// </summary>
        static public string TuningParameterInertiaRatio
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "・イナーシャー比　";

                    case Culture.US:
						//return "・Inertia proportion";
						return "- Inertia Proportion  ";

                    case Culture.CN:
                        return "・惯量比　";
                }
            }
        }

        /// <summary>
        /// "・機械構成　円盤"
        /// </summary>
        static public string TuningParameterMachineTypeDisk
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "・機械構成　円盤";

                    case Culture.US:
						//return "・Mechanical structure - Turn table";
						return "- Mechanical Structure - Turn Table";

                    case Culture.CN:
                        return "・机械结构　圆盘";
                }
            }
        }

        /// <summary>
        /// "・機械構成　ベルト"
        /// </summary>
        static public string TuningParameterMachineTypeBelt
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "・機械構成　ベルト";

                    case Culture.US:
						//return "・Mechanical structure - Belt driven";
						return "- Mechanical Structure - Belt Driven";

                    case Culture.CN:
                        return "・机械结构　皮带";
                }
            }
        }

        /// <summary>
        /// "・機械構成　ボールねじ"
        /// </summary>
        static public string TuningParameterMachineTypeScrew
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "・機械構成　ボールねじ";

                    case Culture.US:
						//return "・Mechanical structure - Ball screw";
						return "- Mechanical Structure - Ball Screw";

                    case Culture.CN:
                        return "・机械结构　丝杆";
                }
            }
        }

        /// <summary>
        /// "・調整強度　弱"
        /// </summary>
        static public string TuningParameterTuningStrengthLight
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "・調整強度　弱";

                    case Culture.US:
						//return "・Tuning intensity - Low";
						return "- Tuning Intensity - Low";

                    case Culture.CN:
                        return "・调整强度　弱";
                }
            }
        }

        /// <summary>
        /// "・調整強度　中"
        /// </summary>
        static public string TuningParameterTuningStrengthMiddle
        {
            get
            {

                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "・調整強度　中";

                    case Culture.US:
						//return "・Tuning intensity - Middle";
						return "- Tuning Intensity - Middle";

                    case Culture.CN:
                        return "・调整强度　中";
                }
            }
        }

        /// <summary>
        /// "・調整強度　強"
        /// </summary>
        static public string TuningParameterTuningStrengthStrong
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "・調整強度　強";

                    case Culture.US:
						//return "・Tuning intensity - High";
						return "- Tuning Intensity - High";

                    case Culture.CN:
                        return "・调整强度　强";
                }
            }
        }

        /// <summary>
        /// "・調整モード　標準"
        /// </summary>
        static public string TuningParameterTuningPriortyNormal
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "・調整モード　標準";

                    case Culture.US:
						//return "・Tuning mode - Mormal";
						return "- Tuning Mode - Normal";

                    case Culture.CN:
                        return "・调整模式　标准";
                }
            }
        }

        /// <summary>
        /// "・調整モード　位置決め優先"
        /// </summary>
        static public string TuningParameterTuningPriortyPosition
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "・調整モード　位置決め優先";

                    case Culture.US:
						//return "・Tuning mode - Position prioritized";
						return "- Tuning Mode - Position Prioritized";

                    case Culture.CN:
                        return "・调整模式　定位优先";
                }
            }
        }

        /// <summary>
        /// "・調整モード　剛性優先"
        /// </summary>
        static public string TuningParameterTuningPriortyStiffness
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "・調整モード　剛性優先";

                    case Culture.US:
						//return "・Tuning mode - Rigidity prioritized";
						return "- Tuning Mode - Rigidity Prioritized";

                    case Culture.CN:
                        return "・调整模式　刚性优先";
                }
            }
        }

        /// <summary>
        /// "・負荷変動　無し"
        /// </summary>
        static public string TuningParameterLoadStable
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "・負荷変動　無し";

                    case Culture.US:
						//return "・No load fluctuated";
						return "- No Load Fluctuated";

                    case Culture.CN:
                        return "・负载变动　无";
                }
            }
        }

        /// <summary>
        /// "・負荷変動　有り"
        /// </summary>
        static public string TuningParameterLoadUnstable
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "・負荷変動　有り";

                    case Culture.US:
						//return "・Load fluctuated";
						return "- Load Fluctuated";

                    case Culture.CN:
                        return "・负载变动　有";
                }
            }
        }

        /// <summary>
        /// "・ターボ機能　有効"
        /// </summary>
        static public string TuningParameterTurboEnable
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "・ターボ機能　有効";

                    case Culture.US:
						//return "・Turbo function validated";
						return "- Turbo Function Validated";

                    case Culture.CN:
                        return "・涡轮功能　有效";
                }
            }
        }

        /// <summary>
        /// "・ターボ機能　無効"
        /// </summary>
        static public string TuningParameterTurboDisable
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "・ターボ機能　無効";

                    case Culture.US:
						//return "・Turbo function invalidated";
						return "- Turbo Function Invalidated";

                    case Culture.CN:
                        return "・涡轮功能　无效";
                }
            }
        }

        /// <summary>
        /// "・インポジ範囲　"
        /// </summary>
        static public string TuningParameterInpositionRange
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "・インポジ範囲　";

                    case Culture.US:
						//return "・In-position range";
						return "- In-Position Range";

                    case Culture.CN:
                        return "・定位范围　";
                }
            }
        }

        /// <summary>
        /// "・目標整定時間　"
        /// </summary>
        static public string TuningParameterTargetTime
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "・目標整定時間　";

                    case Culture.US:
						//return "・Target settling time";
						return "- Target Settling Time  ";

                    case Culture.CN:
                        return "・目标整定时间　";
                }
            }
        }

        /// <summary>
        /// "・目標速度　"
        /// </summary>
        static public string TuningParameterTargetVelocity
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "・目標速度　";

                    case Culture.US:
						//return "・Target speed";
						return "- Target Speed  ";

                    case Culture.CN:
                        return "・目标速度　";
                }
            }
        }

        /// <summary>
        /// "・加速度　　"
        /// </summary>
        static public string TuningParameterTargetAcceleration
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "・加速度　　";

                    case Culture.US:
						//return "・Acceleration";
						return "- Acceleration  ";

                    case Culture.CN:
                        return "・加速度　　";
                }
            }
        }

        /// <summary>
        /// "・減速度　　"
        /// </summary>
        static public string TuningParameterTargetDeceleration
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "・減速度　　";

                    case Culture.US:
						//return "・Deceleration";
						return "- Deceleration  ";

                    case Culture.CN:
                        return "・减速度　　";
                }
            }
        }

        /// <summary>
        /// "・待ち時間　"
        /// </summary>
        static public string TuningParameterWaitTime
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "・待ち時間　";

                    case Culture.US:
						//return "・Waiting time";
						return "- Waiting Time  ";

                    case Culture.CN:
                        return "・等待时间　";
                }
            }
        }

        /// <summary>
        /// "・開始位置　"
        /// </summary>
        static public string TuningParameterStartPosition
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "・開始位置　";

                    case Culture.US:
						//return "・Start position";
						return "- Start Position  ";

                    case Culture.CN:
                        return "・开始位置　";
                }
            }
        }

        /// <summary>
        /// "・目標位置　"
        /// </summary>
        static public string TuningParameterTargetPosition
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "・目標位置　";

                    case Culture.US:
						//return "・Target position";
						return "- Target Position  ";

                    case Culture.CN:
                        return "・目标位置　";
                }
            }
        }

        #endregion

        #region AutoTuningAdjust

        /// <summary>
        /// "■サーボゲイン調整開始■"
        /// </summary>
        static public string AutoTuningAdjustStartServoGainAdjust
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "■サーボゲイン調整開始■";

                    case Culture.US:
						//return "■Start servo gain tuning■";
						return "<< Start Servo Gain Tuning >>";

                    case Culture.CN:
                        return "■伺服增益调整开始■";
                }
            }
        }

        /// <summary>
        /// "■チューニング設定"
        /// </summary>
        static public string AutoTuningAdjustTuningSetting
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "■チューニング設定";

                    case Culture.US:
						//return "■Tuning setting";
						return "# Tuning Setting";

                    case Culture.CN:
                        return "■调谐设定";
                }
            }
        }

        /// <summary>
        /// "倍"
        /// </summary>
        static public string AutoTuningAdjustDouble
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "倍";

                    case Culture.US:
                        return "Times";

                    case Culture.CN:
                        return "倍";
                }
            }
        }

        /// <summary>
        /// "■初期ゲイン設定"
        /// </summary>
        static public string AutoTuningAdjustInitGainSetting
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "■初期ゲイン設定";

                    case Culture.US:
						//return "■Initial gain setting";
						return "# Initial Gain Setting";

                    case Culture.CN:
                        return "■初始增益设定";
                }
            }
        }

        /// <summary>
        /// "・位置ループ比例ゲイン初期値　"
        /// </summary>
        static public string AutoTuningAdjustInitKpSetting
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "・位置ループ比例ゲイン初期値　";

                    case Culture.US:
						//return "・Initial position loop proportional gain value";
						return "- Initial Kp1  ";

                    case Culture.CN:
                        return "・位置环比例增益初始值　";
                }
            }
        }

        /// <summary>
        /// "・速度ループ比例ゲイン初期値　"
        /// </summary>
        static public string AutoTuningAdjustInitKvSetting
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "・速度ループ比例ゲイン初期値　";

                    case Culture.US:
						//return "・Initial speed loop proportional gain value";
						return "- Initial Kv1  ";

                    case Culture.CN:
                        return "・速度环比例增益初始值　";
                }
            }
        }

        /// <summary>
        /// "・速度ループ積分ゲイン初期値　"
        /// </summary>
        static public string AutoTuningAdjustInitKiSetting
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "・速度ループ積分ゲイン初期値　";

                    case Culture.US:
						//return "・Initial speed loop integral gain value";
						return "- Initial Ki1  ";

                    case Culture.CN:
                        return "・速度环积分增益初始值　";
                }
            }
        }

        /// <summary>
        /// "・位置ループ比例ゲイン上昇率　"
        /// </summary>
        static public string AutoTuningAdjustKpUpRatio
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "・位置ループ比例ゲイン上昇率　";

                    case Culture.US:
						//return "・Increased rate of position loop proportional gain";
						return "- Up to Kp1  ";

                    case Culture.CN:
                        return "・位置环比例增益上升率　";
                }
            }
        }

        /// <summary>
        /// "・速度ループ比例ゲイン上昇率　"
        /// </summary>
        static public string AutoTuningAdjustKvUpRatio
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "・速度ループ比例ゲイン上昇率　";

                    case Culture.US:
						//return "・Increased rate of speed loop proportional gain";
						return "- Up to Kv1  ";

                    case Culture.CN:
                        return "・速度环比例增益上升率　";
                }
            }
        }

        /// <summary>
        /// "・速度ループ積分ゲイン上昇率　"
        /// </summary>
        static public string AutoTuningAdjustKiUpRatio
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "・速度ループ積分ゲイン上昇率　";
                    case Culture.US:
						//return "・Increased rate of speed loop integral gain";
						return "- Up to Ki1  ";

                    case Culture.CN:
                        return "・速度环积分增益上升率　";
                }
            }
        }

        /// <summary>
        /// "■初期ゲイン確認中"
        /// </summary>
        static public string AutoTuningAdjustInitGainChecking
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "■初期ゲイン確認中";

                    case Culture.US:
						//return "■Checking initial gain";
						return "# Checking Initial Gain";

                    case Culture.CN:
                        return "■初始增益确认中";
                }
            }
        }

        /// <summary>
        /// "■ 共振周波数"
        /// </summary>
        static public string AutoTuningAdjustResonanceFrequency
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "■ 共振周波数";

                    case Culture.US:
						//return "■ Resonance frequency";
						return "# Resonance Frequency";

                    case Culture.CN:
                        return "■ 共振频率";
                }
            }
        }

        /// <summary>
        /// "■ 反共振周波数"
        /// </summary>
        static public string AutoTuningAdjustAntiResonanceFrequency
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "■ 反共振周波数";

                    case Culture.US:
						//return "■ Antiresonance frequency";
						return "# Antiresonance Frequency";

                    case Culture.CN:
                        return "■ 反共振频率";
                }
            }
        }

        /// <summary>
        /// "！位置偏差の割れを検出しました！"
        /// </summary>
        static public string AutoTuningAdjustPerrSplitDetect
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "！位置偏差の割れを検出しました！";

                    case Culture.US:
						//return "！Crack of position error detected！";
						return "! Crack of position error detected !";

                    case Culture.CN:
                        return "！没有正确地检测出位置偏差！";
                }
            }
        }

        /// <summary>
        /// "！位置偏差のオーバーシュートを検出しました！"
        /// </summary>
        static public string AutoTuningAdjustPerrOvershootDetect
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "！位置偏差のオーバーシュートを検出しました！";

                    case Culture.US:
						//return "！Overshoot of position error detected！";
						return "! Overshoot of position error detected !";

                    case Culture.CN:
                        return "！检测出位置偏差的过冲！";
                }
            }
        }

        /// <summary>
        /// "！インポジ信号の割れを検出しました！"
        /// </summary>
        static public string AutoTuningAdjustInpositionSplitDetect
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "！インポジ信号の割れを検出しました！";

                    case Culture.US:
						//return "！Crack of In-position signal detected！";
						return "! Crack of In-position signal detected !";

                    case Culture.CN:
                        return "！没有正确地接收定位信号！";
                }
            }
        }

        /// <summary>
        /// "！偏差の振動を検出しました！"
        /// </summary>
        static public string AutoTuningAdjustPerrVibrationDetect
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "！偏差の振動を検出しました！";

                    case Culture.US:
						//return "！Vibration of error detected！";
						return "! Vibration of error detected !";

                    case Culture.CN:
                        return "！检测出偏差的振动！";
                }
            }
        }

        /// <summary>
        /// "・位置決め時間 "
        /// </summary>
        static public string AutoTuningAdjustInpositionTime
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "・位置決め時間 ";

                    case Culture.US:
						//return "・Settling time";
						return "- Settling Time  ";

                    case Culture.CN:
                        return "・定位时间 ";
                }
            }
        }

        /// <summary>
        /// "計測不能"
        /// </summary>
        static public string AutoTuningAdjustInpositionTimeError
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "計測不能！";

                    case Culture.US:
						//return "Unmeasurable！";
						return "Unmeasurable !";

                    case Culture.CN:
                        return "不能测量！";
                }
            }
        }

        /// <summary>
        /// "★初期ゲイン調整完了★"
        /// </summary>
        static public string AutoTuningAdjustInitGainCheckFinish
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "★初期ゲイン調整完了★";

                    case Culture.US:
						//return "★Complete initial gain tuning★";
						return "* Complete initial gain tuning *";

                    case Culture.CN:
                        return "★初始增益调整结束★";
                }
            }
        }

        /// <summary>
        /// "■初期ゲインFFTデータ取得中"
        /// </summary>
        static public string AutoTuningAdjustInitGainFFTdataGetting
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
						return "■初期ゲインFFTデータ取得中";
						
                    case Culture.US:
						//return "■Getting intial gain FFT...";
						return "# Getting intial gain FFT...";

                    case Culture.CN:
                        return "■初始增益FFT数据获取中";
                }
            }
        }

		/// <summary>
		/// "■最適ゲイン調整中"
		/// </summary>
		static public string AutoTuningAdjustBestGainAdjusting
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "■最適ゲイン調整中";

					case Culture.US:
						//return "■Optimum gain tuning...";
						return "# Optimum gain tuning...";

					case Culture.CN:
						return "■最适合增益调整中";
				}
			}
		}

		/// <summary>
		/// "■最適ゲイン調整中（KP,KV,KI粗調整）"
		/// </summary>
		static public string AutoTuningAdjustCoarseGainAdjusting
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "■最適ゲイン調整中（KP,KV,KI 粗調整）";

					case Culture.US:
						//return "■Optimum gain tuning...（KP,KV,KI coarse tuning）";
						return "# Optimum gain tuning...";

					case Culture.CN:
						return "■最适合增益调整中（KP,KV,KI大略调整）";
				}
			}
		}

        /// <summary>
        /// "★偏差の振動を検出しました！　ゲイン限界値です！"
        /// </summary>
        static public string AutoTuningAdjustPerrVibrationDetectGainLimit
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "★偏差の振動を検出しました！　ゲイン限界値です！";

                    case Culture.US:
						//return "★Vibration of error detected！　Gain value is the limit！";
						return "* Vibration of error detected! Gain value is the limit ! *";

                    case Culture.CN:
                        return "★检测出偏差的振动！　增益极限值！";
                }
            }
        }

        /// <summary>
        /// "★Kpp上昇で整定時間に変化がありません！"
        /// </summary>
        static public string AutoTuningAdjustInpositionTimeLimit
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "★Kp上昇で整定時間に変化がありません！";

                    case Culture.US:
						//return "★Kp was increased. Settling time was not changing！";
						return "* Kp was increased. Settling time was not changing !";

                    case Culture.CN:
                        return "★由于Kp上升整定时间没有变化！";
                }
            }
        }

        /// <summary>
        /// "★Kvp上昇でサーボ剛性に変化がありません！"
        /// </summary>
        static public string AutoTuningAdjustServoStiffnessLimit
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "★Kv上昇でサーボ剛性に変化がありません！";

                    case Culture.US:
						//return "★Kv was increased. Settling time was not changing！";
						return "* Kv was increased. Settling time was not changing !";

                    case Culture.CN:
                        return "★由于Kv上升伺服刚性没有变化！";
                }
            }
        }

        /// <summary>
        /// "★整定時間が目標値に到達しました！"
        /// </summary>
        static public string AutoTuningAdjustAchieveInpositionTime
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "★整定時間が目標値に到達しました！";

                    case Culture.US:
						//return "★Settling time was reached to the target！";
						return "* Settling time was reached to the target !";

                    case Culture.CN:
                        return "★整定时间达到目标值！";
                }
            }
        }

        /// <summary>
        /// "★Safe Stop★"
        /// </summary>
        static public string AutoTuningAdjustSafeStop
        {
            get
            {
				switch (Culture.Name)
				{
					default:
						return "★Safe Stop★";
        
					case Culture.US:
						return "* Safe Stop *";
				}
		    }
        }

        /// <summary>
        /// "★KV設定値がリミットに到達しました！"
        /// </summary>
        static public string AutoTuningAdjustAchieveKvLimit
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "★Kv設定値がリミットに到達しました！";

                    case Culture.US:
						//return "★Kv set value was reached to the limit！";
						return "* Kv set value was reached to the limit !";

                    case Culture.CN:
                        return "★Kv设定值达到界限！";
                }
            }
        }

        /// <summary>
        /// "★KI設定値がリミットに到達しました！"
        /// </summary>
        static public string AutoTuningAdjustAchieveKiLimit
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "★Ki設定値がリミットに到達しました！";

                    case Culture.US:
						//return "★Ki set value was reached to the limit！";
						return "* Ki set value was reached to the limit !";

                    case Culture.CN:
                        return "★Ki设定值达到界限！";
                }
            }
        }

        /// <summary>
        /// "■ゲイン最終確認"
        /// </summary>
        static public string AutoTuningAdjustFinalGainCheck
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "■ゲイン最終確認";

                    case Culture.US:
						//return "■Gain final checking";
						return "# Gain Final Checking";

                    case Culture.CN:
                        return "■增益最终确认";
                }
            }
        }

        /// <summary>
        /// "★ゲイン調整が正しく完了しました★"
        /// </summary>
        static public string AutoTuningAdjustGainAdjustSuccessful
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "★ゲイン調整が正しく完了しました★";

                    case Culture.US:
						//return "★Gain tuning was successfully completed★";
						return "* Gain tuning was successfully completed *";

                    case Culture.CN:
                        return "★正确结束增益调整★";
                }
            }
        }

        /// <summary>
        /// "！ゲイン調整に失敗しました！"
        /// </summary>
        static public string AutoTuningAdjustGainAdjustFailed
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "！ゲイン調整に失敗しました！";

                    case Culture.US:
						//return "！Gain tuning was not failed！";
						return "! Gain tuning was not failed !";

                    case Culture.CN:
                        return "！增益调整失败！";
                }
            }
        }

        /// <summary>
        /// "！！！電流の振動を検出しました！！！"
        /// </summary>
        static public string AutoTuningAdjustCurrentVibrationDetect
        {
            get
            {

                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "！！！電流の振動を検出しました！！！";

                    case Culture.US:
						//return "！！！Current vibration was detected！！！";
						return "!!! Current vibration was detected !!!";

                    case Culture.CN:
                        return "！！！检测出电流的振动！！！";
                }
            }
        }

        /// <summary>
        /// "■減速停止"
        /// </summary>
        static public string AutoTuningAdjustSmoothStop
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "■減速停止";

                    case Culture.US:
						//return "■Deceleration stop";
						return "# Deceleration Stop";

                    case Culture.CN:
                        return "■减速停止";
                }
            }
        }

        /// <summary>
        /// "■サーボオフ"
        /// </summary>
        static public string AutoTuningAdjustServoOff
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "■サーボオフ";

                    case Culture.US:
						//return "■Servo OFF";
						return "# Servo OFF";

                    case Culture.CN:
                        return "■伺服OFF";
                }
            }
        }

        /// <summary>
        /// "■初期ゲイン再設定"
        /// </summary>
        static public string AutoTuningAdjustInitGainReset
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "■初期ゲイン再設定";

                    case Culture.US:
						//return "■Initial gain re-setting";
						return "# Initial Gain Re-Setting";

                    case Culture.CN:
                        return "■初始增益再设定";
                }
            }
        }

        /// <summary>
        /// "！初期ゲインの調整に失敗しました！"
        /// </summary>
        static public string AutoTuningAdjustInitGainAdjustFailed
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "！初期ゲインの調整に失敗しました！";

                    case Culture.US:
						//return "！Tuning of initial gain was failed！";
						return "! Tuning of initial gain was failed !";

                    case Culture.CN:
                        return "！初始增益调整失败！";
                }
            }
        }

        /// <summary>
        /// "★速度ループゲイン限界値を検出しました！"
        /// </summary>
        static public string AutoTuningAdjustWaitKvLimit
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "★速度ループゲイン限界値を検出しました！";

                    case Culture.US:
						//return "★Limit of speed loop gain was detected！";
						return "* Limit of speed loop gain was detected! *";

                    case Culture.CN:
                        return "★检测出速度环增益极限值！";
                }
            }
        }

        /// <summary>
        /// "　FFT安定待ち。"
        /// </summary>
        static public string AutoTuningAdjustWaitFFT
        {
            get
            {

                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "　FFT安定待ち。";

                    case Culture.US:
						return "　Wating for FFT stablizing";
						
                    case Culture.CN:
                        return "　FFT稳定等待。";
                }
            }
        }

        /// <summary>
        /// "★振動周波数が速度ループゲイン限界値です！"
        /// </summary>
        static public string AutoTuningAdjustKvLimitCurrentVibration
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "★振動周波数が速度ループゲイン限界値です！";

                    case Culture.US:
						//return "★Vibration frequency reached to the limit of speed loop gain！";
						return "* Vibration frequency reached to the limit of speed loop gain ! *";

                    case Culture.CN:
                        return "★振动频率是速度环增益极限值！";
                }
            }
        }

        /// <summary>
        /// "★ノッチフィルタの設定周波数が速度ループゲイン限界値です！"
        /// </summary>
        static public string AutoTuningAdjustKvLimitNotchFillterFrequecy
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "★ノッチフィルタの設定周波数が速度ループゲイン限界値です！";

                    case Culture.US:
						//return "★Setting frequency of notch filter reached to the limit of speed loop gain！";
						return "* Setting frequency of notch filter reached to the limit of speed loop gain ! *";

                    case Culture.CN:
                        return "★陷波滤波器的设定频率是速度环增益极限值！";
                }
            }
        }

        /// <summary>
        /// "★ノッチフィルタの設定値が限界値です！"
        /// </summary>
        static public string AutoTuningAdjustNotchFillterFrequecyLimit
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "★ノッチフィルタの設定値が限界値です！";

                    case Culture.US:
						//return "★Setting value of notch filter reached to the limit.！";
						return "* Setting value of notch filter reached to the limit ! *";

                    case Culture.CN:
                        return "★陷波滤波器的设定值是极限值！";
                }
            }
        }

        /// <summary>
        /// "★ノッチフィルタの設定個数が限界値です！"
        /// </summary>
        static public string AutoTuningAdjustNotchFillterNumLimit
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "★ノッチフィルタの設定個数が限界値です！";

                    case Culture.US:
						//return "★The numbers of notch filter setting are limited.！";
						return "* The numbers of notch filter setting are limited ! *";

                    case Culture.CN:
                        return "★陷波滤波器的设定数量是极限值！";
                }
            }
        }

        /// <summary>
        /// "★フィルタの設定が出来ませんでした！"
        /// </summary>
        static public string AutoTuningAdjustFillterSetupFailed
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "★フィルタの設定が出来ませんでした！";

                    case Culture.US:
						//return "★Filtter setting was failed！";
						return "* Filtter setting was failed ! *";

                    case Culture.CN:
                        return "★不能设定滤波器！";
                }
            }
        }

        /// <summary>
        /// "★FFTのピークを【検出】しました。"
        /// </summary>
        static public string AutoTuningAdjustFFTpeekDetect
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "★FFTのピークを【検出】しました。";

                    case Culture.US:
						//return "★Peak of FFT was detected.";
						return "* Peak of FFT was detected *";

                    case Culture.CN:
                        return "★【检测】出FFT的顶点。";
                }
            }
        }
	
	    /// <summary>
        /// "★FFTのピークを【抽出】しました。"
        /// </summary>
        static public string AutoTuningAdjustFFTpeekExtract
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "★FFTのピークを【抽出】しました。";

                    case Culture.US:
						//return "★Peak of FFT was extracted.";
						return "* Peak of FFT was extracted *";

                    case Culture.CN:
                        return "★【选出】出FFT的顶点。";
                }
            }
        }

        /// <summary>
        /// "★ノッチフィルタ"
        /// </summary>
        static public string AutoTuningAdjustNotchFillter
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "★ノッチフィルタ";

                    case Culture.US:
						//return "★Notch filter";
						return "# Notch Filter";

                    case Culture.CN:
                        return "★陷波滤波器";
                }
            }
        }

        /// <summary>
        /// "・中心周波数"
        /// </summary>
        static public string AutoTuningAdjustNotchFillterFrequency
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "・中心周波数 ";

                    case Culture.US:
						//return "・Center frequency";
						return "- Center Frequency ";

                    case Culture.CN:
                        return "・中心频率 ";
                }
            }
        }

        /// <summary>
        /// "・深さ"
        /// </summary>
        static public string AutoTuningAdjustNotchFillterDepth
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "・深さ ";

                    case Culture.US:
						//return "・Depth";
						return "- Depth ";

                    case Culture.CN:
                        return "・深度 ";
                }
            }
        }

        /// <summary>
        /// "・幅"
        /// </summary>
        static public string AutoTuningAdjustNotchFillterWidth
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "・幅 ";

                    case Culture.US:
						//return "・Width";
						return "- Width ";

                    case Culture.CN:
                        return "・宽度 ";
                }
            }
        }

        /// <summary>
        /// "を設定しました。"
        /// </summary>
        static public string AutoTuningAdjustEstablish
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "を設定しました。";

                    case Culture.US:
                        return " was set";

                    case Culture.CN:
                        return "设定了。";
                }
            }
        }

        /// <summary>
        /// "■ノッチフィルタ再構成"
        /// </summary>
        static public string AutoTuningAdjustNotchFillterReconstruct
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "■ノッチフィルタ再構成";

                    case Culture.US:
						//return "■Notch filter reconstruction";
						return "# Notch Filter Reconstruction";

                    case Culture.CN:
                        return "■重新构成陷波滤波器";
                }
            }
        }

        /// <summary>
        /// "★ローパスフィルタを設定しました。"
        /// </summary>
        static public string AutoTuningAdjustLowpassFillterSetup
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "★ローパスフィルタを設定しました。";

                    case Culture.US:
						//return "★Low pass filter was set";
						return "# Low pass filter was set";

                    case Culture.CN:
                        return "★设定低通滤波器。";
                }
            }
        }

        /// <summary>
        /// "・周波数"
        /// </summary>
        static public string AutoTuningAdjustLowpassFillterFrequency
        {
            get
            {

                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "・周波数";

                    case Culture.US:
						//return "・Frequency";
						return "- Frequency ";

                    case Culture.CN:
                        return "・频率";
                }
            }
        }

        /// <summary>
        /// "★★★ロールバック開始★★★"
        /// </summary>
        static public string AutoTuningAdjustRollbackStart
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "★★★ロールバック開始★★★";

                    case Culture.US:
						//return "★★★Start rollback★★★";
						return "*** Start Rollback ***";

                    case Culture.CN:
                        return "★★★Roll Back开始★★★";
                }
            }
        }

        /// <summary>
        /// "★★★ロールバック完了★★★"
        /// </summary>
        static public string AutoTuningAdjustRollbackFinish
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "★★★ロールバック完了★★★";

                    case Culture.US:
						//return "★★★Rollback completed★★★";
						return "*** Rollback Completed ***";

                    case Culture.CN:
                        return "★★★Roll Back结束★★★";
                }
            }
        }

        /// <summary>
        /// "個前に戻りました。"
        /// </summary>
        static public string AutoTuningAdjustRollbackNum
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "個前に戻りました。";

                    case Culture.US:
						//return "個前に戻りました。";
						return " Roolback";

                    case Culture.CN:
                        return "回到个前。";
                }
            }
        }

		/// <summary>
		/// "・"
		/// </summary>
		static public string AutoTuningAdjustDot
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "・";

					case Culture.US:
						return "- ";

					case Culture.CN:
						return "・";
				}
			}
		}

		/// <summary>
		/// "・ノッチフィルタ設定最小周波数　"
		/// </summary>
		static public string AutoTuningAdjustMinimumNotchFillter
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "・ノッチフィルタ設定最小周波数　";

					case Culture.US:
						//return "・Increased rate of position loop proportional gain";
						return "- Notch Fillter Minimum  ";

					case Culture.CN:
						return "・陷波滤波器　";
				}
			}
		}

		/// <summary>
		/// "・ノッチフィルタ設定最大周波数　"
		/// </summary>
		static public string AutoTuningAdjustMaximumNotchFillter
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "・ノッチフィルタ設定最大周波数　";

					case Culture.US:
						//return "・Increased rate of position loop proportional gain";
						return "- Notch Fillter Maximum  ";

					case Culture.CN:
						return "・陷波滤波器　";
				}
			}
		}

		#endregion

        #region AutoTuningForm

        /// <summary>
        /// "一時停止"
        /// </summary>
        static public string AutoTuningPause
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "一時停止";

                    case Culture.US:
                        return "Pause";

                    case Culture.CN:
                        return "暂时停止";
                }
            }
        }

        /// <summary>
        /// "調整再開"
        /// </summary>
        static public string AutoTuningResume
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "調整再開";

                    case Culture.US:
						//return "Resume tuning";
						return "Resume";

                    case Culture.CN:
                        return "恢复调整";
                }
            }
        }

        /// <summary>
        /// "繰り返し"
        /// </summary>
        static public string AutoTuningRepeat
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "繰り返し";

                    case Culture.US:
                        return "Repeat";

                    case Culture.CN:
                        return "反复";
                }
            }
        }

        /// <summary>
        /// "動作停止"
        /// </summary>
        static public string AutoTuningRepeatStop
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "動作停止";

                    case Culture.US:
                        return "Stop";

                    case Culture.CN:
						return "运行停止";
                }
            }
        }

        /// <summary>
        /// "★速度ループ比例ゲインを設定しました。"
        /// </summary>
        static public string AutoTuningKvSetup
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "★速度ループ比例ゲインを設定しました。";

                    case Culture.US:
						//return "★Speed loop proportional gain was set.";
						return "# Kv1 gain was set";

                    case Culture.CN:
                        return "★设定速度环比例增益。";
                }
            }
        }

        /// <summary>
        /// "★速度ループ積分ゲインを設定しました。"
        /// </summary>
        static public string AutoTuningKiSetup
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "★速度ループ積分ゲインを設定しました。";

                    case Culture.US:
						//return "★Speed loop integral gain was set.";
						return "# Ki1 gain was set";

                    case Culture.CN:
                        return "★设定速度环积分增益。";
                }
            }
        }

        /// <summary>
        /// "★位置ループ比例ゲインを設定しました。"
        /// </summary>
        static public string AutoTuningKpSetup
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "★位置ループ比例ゲインを設定しました。";

                    case Culture.US:
						//return "★Position loop proportional gain was set.";
						return "# Kp1 gain was set";

                    case Culture.CN:
                        return "★设定位置环比例增益。";
                }
            }
        }

        /// <summary>
        /// "アラーム検出！"
        /// </summary>
        static public string AutoTuningAlarmDetect
        {
            get
            {

                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "アラーム検出！";

                    case Culture.US:
						//return "Alarm detected！";
						return "Alarm Detected !";

                    case Culture.CN:
                        return "检测出警报！";
                }
            }
        }

        /// <summary>
        /// "振動検出！"
        /// </summary>
        static public string AutoTuningVibrationDetect
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "振動検出！";

                    case Culture.US:
						//return "Vibration detected！";
						return "Vibration Detected !";

                    case Culture.CN:
                        return "检测出振动！";
                }
            }
        }

        /// <summary>
        /// "正常動作中"
        /// </summary>
        static public string AutoTuningReady
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "正常動作中";

                    case Culture.US:
						//return "Moving correctly...";
						return "Normal";

                    case Culture.CN:
                        return "正常运行中";
                }
            }
        }

        /// <summary>
        /// "負荷イナーシャ推定値："
        /// </summary>
        static public string AutoTuningInertiaEstimate
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "負荷イナーシャ推定値：";

                    case Culture.US:
						//return "Load inertia estimation value：";
						return "Load Inertia : ";

                    case Culture.CN:
                        return "负载惯量估计值：";

                }
            }
        }

        /// <summary>
        /// "モータイナーシャ："
        /// </summary>
        static public string AutoTuningMotorInertia
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "モータイナーシャ：";

                    case Culture.US:
						//return "Motor inertia：";
						return "Motor Inertia : ";

                    case Culture.CN:
                        return "马达惯量：";
                }
            }
        }

        /// <summary>
        /// "イナーシャ比："
        /// </summary>
        static public string AutoTuningInertiaRatio
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "イナーシャ比：";

                    case Culture.US:
						//return "Inertia ratio：";
						return "Inertia Ratio : ";

                    case Culture.CN:
                        return "惯量比：";
                }
            }
        }

        /// <summary>
        /// "[倍]"
        /// </summary>
        static public string AutoTuningInertiaRatioUnit
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "[倍]";

                    case Culture.US:
                        return "[Times]";

                    case Culture.CN:
                        return "[倍]";
                }
            }
        }

        /// <summary>
        /// "★通信データ更新中"
        /// </summary>
        static public string AutoTuningComunicationDataUpdating
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "★通信データ更新中";

                    case Culture.US:
						//return "★Updating communication data...";
						return "# Updating communication data...";

                    case Culture.CN:
                        return "★通信数据更新中";
                }
            }
        }

        /// <summary>
        /// "■サーボゲイン"
        /// </summary>
        static public string AutoTuningServoGain
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "■サーボゲイン";

                    case Culture.US:
						//return "■Servo gain";
						return "# Servo gain";

                    case Culture.CN:
                        return "■伺服增益";
                }
            }
        }

        /// <summary>
        /// "■位置ループ比例ゲイン"
        /// </summary>
        static public string AutoTuningKp
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "■位置ループ比例ゲイン";

                    case Culture.US:
						//return "■Position loop proportional gain";
						return "# Kp1";

                    case Culture.CN:
                        return "■位置环比例增益";
                }
            }
        }

        /// <summary>
        /// "■速度ループ比例ゲイン"
        /// </summary>
        static public string AutoTuningKv
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "■速度ループ比例ゲイン";

                    case Culture.US:
						//return "■Speed loop proportional gain";
						return "# Kv1";

                    case Culture.CN:
                        return "■速度环比例增益";
                }
            }
        }

        /// <summary>
        /// "■速度ループ積分ゲイン"
        /// </summary>
        static public string AutoTuningKi
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "■速度ループ積分ゲイン";

                    case Culture.US:
						//return "■Speed loop integral gain";
						return "# Ki1";

                    case Culture.CN:
                        return "■速度环积分增益";
                }
            }
        }

        /// <summary>
        /// "■負荷イナーシャ"
        /// </summary>
        static public string AutoTuningLoad
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "■負荷イナーシャ";

                    case Culture.US:
						//return "■Load inertia";
						return "# Load Inertia";

                    case Culture.CN:
                        return "■负载惯量";
                }
            }
        }

        /// <summary>
        /// "■ローパスフィルタ"
        /// </summary>
        static public string AutoTuningLowpassFillter
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "■ローパスフィルタ";

                    case Culture.US:
						//return "■Low pass filter";
						return "# Low Pass Filter";

                    case Culture.CN:
                        return "■低通滤波器";
                }
            }
        }

        /// <summary>
        /// "■ノッチフィルタ１"
        /// </summary>
        static public string AutoTuningNotchFillter1
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "■ノッチフィルタ１";

                    case Culture.US:
						//return "■Notch filter 1";
						return "# Notch Filter 1";

                    case Culture.CN:
                        return "■陷波滤波器１";
                }
            }
        }

        /// <summary>
        /// "■ノッチフィルタ２"
        /// </summary>
        static public string AutoTuningNotchFillter2
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "■ノッチフィルタ２";

                    case Culture.US:
						//return "■Notch filter 2";
						return "# Notch Filter 2";

                    case Culture.CN:
                        return "■陷波滤波器２";
                }
            }
        }

        /// <summary>
        /// "■ノッチフィルタ３"
        /// </summary>
        static public string AutoTuningNotchFillter3
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "■ノッチフィルタ３";

                    case Culture.US:
						//return "■Notch filter 3";
						return "# Notch Filter 3";

                    case Culture.CN:
                        return "■陷波滤波器３";
                }
            }
        }

        /// <summary>
        /// "■ノッチフィルタ４"
        /// </summary>
        static public string AutoTuningNotchFillter4
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "■ノッチフィルタ４";

                    case Culture.US:
						//return "■Notch filter 4";
						return "# Notch Filter 4";

                    case Culture.CN:
                        return "■陷波滤波器４";
                }
            }
        }

        /// <summary>
        /// "■ノッチフィルタ５"
        /// </summary>
        static public string AutoTuningNotchFillter5
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "■ノッチフィルタ５";

                    case Culture.US:
						//return "■Notch filter 5";
						return "# Notch Filter 5";

                    case Culture.CN:
                        return "■陷波滤波器５";
                }
            }
        }

        /// <summary>
        /// "チューニング回数　"
        /// </summary>
        static public string AutoTuningTuningNum
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "チューニング回数　";

                    case Culture.US:
						//return "Times of tuning";
						return "Times of Tuning  ";

                    case Culture.CN:
                        return "调谐次数          ";
                }
            }
        }

        /// <summary>
        /// "ゲイン設定回数　　"
        /// </summary>
        static public string AutoTuningGainSetupNum
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "ゲイン設定回数　　";

                    case Culture.US:
						//return "Times of gain setting";
						return "Times of Setting  ";

                    case Culture.CN:
                        return "增益设定次数    ";
                }
            }
        }

        /// <summary>
        /// "偏差振動回数　　　"
        /// </summary>
        static public string AutoTuningVibrationNum
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "偏差振動回数　　　";

                    case Culture.US:
						//return "Times of error vibration";
						return "Times of Vibration  ";

                    case Culture.CN:
                        return "偏差振动次数    ";
                }
            }
        }

        /// <summary>
        /// " [回]"
        /// </summary>
        static public string AutoTuningNum
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return " [回]";

                    case Culture.US:
                        return " [Times]";

                    case Culture.CN:
                        return " [回]";
                }
            }
        }

        /// <summary>
        /// "ファイル読み込み中．．．"
        /// </summary>
        static public string AutoTuningFileRead
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "ファイル読み込み中．．．";

                    case Culture.US:
                        return "Reading file...";

                    case Culture.CN:
                        return "文件读取中．．．";
                }
            }
        }

        /// <summary>
        /// "ファイル保存中．．．"
        /// </summary>
        static public string AutoTuningFileSave
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "ファイル保存中．．．";

                    case Culture.US:
                        return "Saving file...";

                    case Culture.CN:
                        return "文件保存中．．．";
                }
            }
        }

		/// <summary>
		/// "摩擦補正開始"
		/// </summary>
		static public string AutoTuningFrictionStart
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "■摩擦補正開始";

					case Culture.US:
						//return "■Start friction correction";
						return "# Start Friction Correction";

					case Culture.CN:
						return "■摩擦补正开始";
				}
			}
		}

		/// <summary>
		/// "摩擦補正推定中．．．"
		/// </summary>
		static public string AutoTuningFrictionCalc
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "摩擦補正推定中．．．";

					case Culture.US:
						//return "Estimating friction correction...";
						return "Estimating Friction Correction...";

					case Culture.CN:
						return "摩擦补正估计中．．．";

				}
			}
		}

		/// <summary>
		/// "CW方向摩擦補正値"
		/// </summary>
		static public string AutoTuningCwNowValue
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "正方向摩擦補正値";

					case Culture.US:
						//return "CW direction frinction correction value";
						return "CW Frinction Correction Value";

					case Culture.CN:
						return "正方向摩擦补正值";
				}
			}
		}

		/// <summary>
		/// "CCW方向摩擦補正値"
		/// </summary>
		static public string AutoTuningCcwNowValue
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "負方向摩擦補正値";

					case Culture.US:
						//return "CCW direction frinction correction value";
						return "CCW Frinction Correction Value";

					case Culture.CN:
						return "負方向摩擦补正值";
				}
			}
		}

		/// <summary>
		/// "摩擦補正完了"
		/// </summary>
		static public string AutoTuningFrictionFinish
		{
			get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "■摩擦補正完了";

                    case Culture.US:
						//return "■Friction correction completed";
						return "# Friction Correction Completed";

                    case Culture.CN:
                        return "■摩擦补正完成";
                }
            }
		}

        #endregion

        #region SaveForm

        /// <summary>
        /// "パラメータをフラッシュメモリに保存しています。"
        /// </summary>
        static public string SaveFlashMemory
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "パラメータを本体メモリに保存しています。";

                    case Culture.US:
                        return "Saving parameter into Driver memory...";

                    case Culture.CN:
                        return "参数保存在主机存储器。";
                }
            }
        }

        /// <summary>
        /// "画像データを保存中です．．．"
        /// </summary>
        static public string SaveImageData
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "画像データを保存中です．．．";

                    case Culture.US:
                        return "Saving screen data...";

                    case Culture.CN:
                        return "图像数据保存中．．．";
                }
            }
        }

        /// <summary>
        /// "摩擦補正推定中．．．"
        /// </summary>
        static public string SaveFriction
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "摩擦補正推定中．．．";

                    case Culture.US:
                        return "Estimating friction correction...";

                    case Culture.CN:
                        return "摩擦补正估计中．．．";

                }
            }
        }

        #endregion

        #region UpgradeForm

        /// <summary>
        /// "DFUデバイス接続"
        /// </summary>
        static public string UpgradeDfuAttach
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "DFUデバイス接続";

                    case Culture.US:
						//return "DFU device connected";
						return "DFU Attach";

                    case Culture.CN:
                        return "DFU软元件连接";
                }
            }
        }

        /// <summary>
        /// "USBデバイス接続"
        /// </summary>
        static public string UpgradeUsbAttach
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "USBデバイス接続";

                    case Culture.US:
						//return "USB device connected";
						return "USB Attach";

                    case Culture.CN:
                        return "USB软元件连接";
                }
            }
        }

        /// <summary>
        /// "DFUデバイス切断"
        /// </summary>
        static public string UpgradeDeviceDetach
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "デバイス切断";

                    case Culture.US:
						//return "Device disconnected";
						return "DFU Detach";

                    case Culture.CN:
                        return "软元件切断";
                }
            }
        }

        /// <summary>
        /// "HEXファイルの選択"
        /// </summary>
        static public string UpgradeHexFileSelect
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "HEXファイルの選択";

                    case Culture.US:
						//return "HEX file selection";
						return "HEX File Selection";

                    case Culture.CN:
                        return "HEX文件的选择";
                }
            }
        }

        /// <summary>
        /// "DFUファイルの選択"
        /// </summary>
        static public string UpgradeDFUFileSelect
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "DFUファイルの選択";

                    case Culture.US:
						//return "DFU file selection";
						return "DFU File Selection";

                    case Culture.CN:
                        return "DFU文件的选择";
                }
            }
        }

        /// <summary>
        /// "本体ファームウェア更新中．．．"
        /// </summary>
        static public string UpgradeFirmwareUpdating
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "本体ファームウェア更新中．．．";

                    case Culture.US:
                        return "Ungrading driver firmware...";

                    case Culture.CN:
                        return "主机固件更新中．．．";
                }
            }
        }

        /// <summary>
        /// "本体ファームウェア確認中．．．"
        /// </summary>
        static public string UpgradeFirmwareVerify
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "本体ファームウェア確認中．．．";

                    case Culture.US:
                        return "Verify driver firmware...";

                    case Culture.CN:
                        return "主机固件检查．．．";
                }
            }
        }

        /// <summary>
        /// "USBケーブルを再接続します"
        /// </summary>
        static public string UpgradeCableAttach
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "USBケーブルを再接続します";

                    case Culture.US:
                        return "USB is connected again";

                    case Culture.CN:
                        return "重新连接USB电缆";
                }
            }
        }

        /// <summary>
        /// "USBケーブルを取り外しします"
        /// </summary>
        static public string UpgradeCableDettach
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "USBケーブルを取り外します";

                    case Culture.US:
                        return "USB is disconnected";

                    case Culture.CN:
                        return "拆卸USB电缆";

                }
            }
        }

		/// <summary>
		/// "キャンセル"
		/// </summary>
		static public string UpgradeCancel
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "キャンセル";

					case Culture.US:
						return "Cancel";

					case Culture.CN:
						return "取消";

				}
			}
		}

		/// <summary>
		/// "完了"
		/// </summary>
		static public string UpgradeCompletion
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "完了";

					case Culture.US:
						return "Completion";

					case Culture.CN:
						return "完毕";

				}
			}
		}

        #endregion

        #region MainForm

        /// <summary>
        /// "USB接続"
        /// </summary>
        static public string MainUSBAttach
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "USB接続";

                    case Culture.US:
                        return "USB Attach";

                    case Culture.CN:
                        return "USB连接";
                }
            }
        }

        /// <summary>
        /// "USB切断"
        /// </summary>
        static public string MainUSBDetach
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "USB切断";

                    case Culture.US:
                        return "USB Detach";

                    case Culture.CN:
                        return "USB切断";
                }
            }
        }

        /// <summary>
        /// "正常動作中"
        /// </summary>
        static public string MainReady
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "正常動作中";

                    case Culture.US:
                        return "Ready";

                    case Culture.CN:
                        return "正常运行中";
                }
            }
        }

        /// <summary>
        /// "サーボON"
        /// </summary>
        static public string MainServoOn
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "サーボON";

                    case Culture.US:
                        return "Servo ON";

                    case Culture.CN:
                        return "伺服ON";
                }
            }
        }

        /// <summary>
        /// "サーボOFF"
        /// </summary>
        static public string MainServoOff
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "サーボOFF";

                    case Culture.US:
                        return "Servo OFF";

                    case Culture.CN:
                        return "伺服OFF";
                }
            }
        }

        /// <summary>
        /// "アラーム"
        /// </summary>
        static public string MainAlarm
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "アラーム";

                    case Culture.US:
                        return "Alarm";

                    case Culture.CN:
                        return "警报";
                }
            }
        }

        /// <summary>
        /// "アラーム検出"
        /// </summary>
        static public string MainAlarmDetect
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "アラーム検出";

                    case Culture.US:
                        return "Alarm Detected";

                    case Culture.CN:
                        return "检测出警报";
                }
            }
        }

        /// <summary>
        /// "ログ個数"
        /// </summary>
        static public string MainLogNum
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "ログ個数";

                    case Culture.US:
                        return "Number of log";

                    case Culture.CN:
                        return "日志件数";
                }
            }
        }

        /// <summary>
        /// "正リミット"
        /// </summary>
        static public string MainPositiveLimit
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "正リミット";

                    case Culture.US:
                        return "CW Limit";

                    case Culture.CN:
                        return "正界限";
                }
            }
        }

        /// <summary>
        /// "負リミット"
        /// </summary>
        static public string MainNegativeLimit
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "負リミット";

                    case Culture.US:
                        return "CCW Limit";

                    case Culture.CN:
                        return "负界限";
                }
            }
        }

        /// <summary>
        /// "トルクリミット"
        /// </summary>
        static public string MainTorqueLimit
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "トルクリミット";

                    case Culture.US:
                        return "Torque Limit";

                    case Culture.CN:
                        return "电流界限";
                }
            }
        }

        /// <summary>
        /// "速度リミット"
        /// </summary>
        static public string MainVelocityLimit
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "速度リミット";

                    case Culture.US:
                        return "Speed Limit";

                    case Culture.CN:
                        return "速度界限";
                }
            }
        }

        #endregion

        #region ParameterForm

        /// <summary>
        /// "パラメータファイル読み込み中．．．"
        /// </summary>
        static public string ParameterFileRead
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "パラメータファイル読み込み中．．．";

                    case Culture.US:
                        return "Reading parameter file...";

                    case Culture.CN:
                        return "参数文件读取中．．．";
                }
            }
        }

        /// <summary>
        /// "パラメータファイル保存中．．．"
        /// </summary>
        static public string ParameterFileSave
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "パラメータファイル保存中．．．";

                    case Culture.US:
                        return "Saving parameter file...";

                    case Culture.CN:
                        return "参数文件保存中．．．";
                }
            }
        }

        /// <summary>
        /// "データ読み込み中．．．"
        /// </summary>
        static public string ParameterDataRead
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "データ読み込み中．．．";

                    case Culture.US:
                        return "Reading data...";

                    case Culture.CN:
                        return "数据读取中．．．";
                }
            }
        }

        /// <summary>
        /// "データ書き込み中．．．"
        /// </summary>
        static public string ParameterDataWrite
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "データ書き込み中．．．";

                    case Culture.US:
                        return "Writing data...";

                    case Culture.CN:
                        return "数据记入中．．．";
                }
            }
        }

        /// <summary>
        /// "現在値を変更値にコピー中．．．"
        /// </summary>
        static public string ParameterDataCopy
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "現在値を変更値にコピー中．．．";

                    case Culture.US:
                        return "Copying current value to changed value...";

                    case Culture.CN:
                        return "把现在值复制到变更值中．．．";
                }
            }
        }

        /// <summary>
        /// "パラメータ初期値読み込み中．．．"
        /// </summary>
        static public string ParameterDataInit
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "パラメータ初期値読み込み中．．．";

                    case Culture.US:
                        return "Reading parameter initial value...";

                    case Culture.CN:
                        return "读取参数初始值中．．．";
                }
            }
        }

        /// <summary>
        /// "データ差分比較中．．．"
        /// </summary>
        static public string ParameterDataDiff
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "データ差分比較中．．．";

                    case Culture.US:
                        return "Comparing data difference...";

                    case Culture.CN:
                        return "数据差异比较中．．．";
                }
            }
        }

        /// <summary>
        /// 10進表示
        /// </summary>
        static public string ParameterDataDec
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "10進表示";

                    case Culture.US:
						//return "Decimal indication";
						return "Dec";

                    case Culture.CN:
                        return "10进制显示";
                }
            }
        }

        /// <summary>
        /// 16進表示
        /// </summary>
        static public string ParameterDataHex
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "16進表示";

                    case Culture.US:
						//return "Hex indication";
						return "Hex";

                    case Culture.CN:
                        return "16进制显示";
                }
            }
        }

        /// <summary>
        /// 変更
        /// </summary>
        static public string ParameterDataChange
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "変更";

                    case Culture.US:
						//return "change";
					//return "Change";
						return "Write";

                    case Culture.CN:
                        return "变更";
                }
            }
        }

        /// <summary>
        /// 項目
        /// </summary>
        static public string ParameterDataItem
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "項目";

                    case Culture.US:
                        return "Item";

                    case Culture.CN:
                        return "项目";
                }
            }
        }

        /// <summary>
        /// ．．．他多数の項目のデータが不正です。
        /// </summary>
        static public string ParameterDataInvalidItem
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "．．．他多数の項目のデータが不正です。";

                    case Culture.US:
                        return "．．．Some imtes' data are inccrect";

                    case Culture.CN:
                        return "．．．另外多数项目的数据不正确。";
                }
            }
        }

        #endregion

        #region ParameterHelpForm

        /// <summary>
        /// "ID番号："
        /// </summary>
        static public string ParameterHelpIdNumber
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "ID番号：";

                    case Culture.US:
						//return "ID no.：";
						return "ID No.：";

                    case Culture.CN:
                        return "ID号码：";
                }
            }
        }

        /// <summary>
        /// "番"
        /// </summary>
        static public string ParameterHelpNumber
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "番";

                    case Culture.US:
						//return "no.";
						return "No.";

                    case Culture.CN:
                        return "号";
                }
            }
        }

        #endregion

        #region WizardForm

        /// <summary>
        /// "現在の設定値は"
        /// </summary>
        static public string WizardNowValue
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "現在の設定値は";

                    case Culture.US:
                        return "Current setting value is ";

                    case Culture.CN:
                        return "现在的设定值是";
                }
            }
        }

        /// <summary>
        /// "現在のCW方向摩擦補正値は"
        /// </summary>
        static public string WizardFrictionCwNowValue
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "現在の正方向摩擦補正値は";

                    case Culture.US:
						return "Current CW direction friction correction value is";

                    case Culture.CN:
						return "现在的正方向摩擦补正值是";
                }
            }
        }

        /// <summary>
        /// "現在のCCW方向摩擦補正値は"
        /// </summary>
        static public string WizardFrictionCcwNowValue
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
						return "現在の負方向摩擦補正値は";

                    case Culture.US:
						return "Current CCW direction friction correction value is";

                    case Culture.CN:
						return "现在的負方向摩擦补正值是";
                }
            }
        }

        /// <summary>
        /// "モータ1回転あたり"
        /// </summary>
        static public string WizardRevolution
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "モータ1回転あたり";

                    case Culture.US:
                        return "per motor rotation.";

                    case Culture.CN:
                        return "马达每旋转一圈";
                }
            }
        }

        /// <summary>
        /// "です。"
        /// </summary>
        static public string WizardIs
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "です。";

                    case Culture.US:
                        return " ";

                    case Culture.CN:
                        return "是。";
                }
            }
        }

        /// <summary>
        /// "実行"
        /// </summary>
        static public string WizardExec
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "実行";

                    case Culture.US:
                        return "Go";

                    case Culture.CN:
                        return "实行";
                }
            }
        }

        /// <summary>
        /// "次へ"
        /// </summary>
        static public string WizardNext
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "次へ";

                    case Culture.US:
                        return "Next";

                    case Culture.CN:
                        return "下一个";
                }
            }
        }

        #endregion

		#region IoMonitorForm

		/// <summary>
		/// "IO Inputの設定ラベルを読み込みます"
		/// </summary>
		static public string IoMonitorGetInputName(int io_no, int prm)
		{
			if (prm == 0)
			{
				//既定の設定
				switch (io_no)
				{
					case 0:
						prm = 1;
						break;

					case 1:
						prm = 2;
						break;

					case 2:
						prm = 3;
						break;

					case 3:
						prm = 4;
						break;

					case 4:
						prm = 5;
						break;

					case 5:
						prm = 8;
						break;

					case 6:
						prm = 7;
						break;

					case 7:
						prm = 12;
						break;

					default:
						prm = 99;
						break;
				}
			}

			switch(prm)
			{
				case 1:	
					switch (Culture.Name)
					{
						default:
						case Culture.JP:

                            //↓↓↓ KASHIYAMA Mode 20190624 Kimura update ↓↓↓
                            if (Properties.Settings.Default.PASSWORD_KASHIYAMA == false)
                            {
                                return "サーボオン指令";
                            }
                            else
                            {
                                return "回転指令";
                            }
                            //↑↑↑ KASHIYAMA Mode 20190624 Kimura update ↑↑↑

						case Culture.US:
						//return "Servo ON command";
						return "Servo ON";

						case Culture.CN:
							return "伺服开机指令";
					}

				case 2:
					switch (Culture.Name)
					{
						default:
						case Culture.JP:
                            
                            //↓↓↓ KASHIYAMA Mode 20190624 Kimura update ↓↓↓
                            if (Properties.Settings.Default.PASSWORD_KASHIYAMA == false)
                            {
                                return "正回転駆動禁止指令";
                            }
                            else
                            {
                                return "速度指定L";
                            }
                            //↑↑↑ KASHIYAMA Mode 20190624 Kimura update ↑↑↑
                            
						case Culture.US:
							//return "CW direction movement prohibition command";
							//return "CW Disable";
							return "Forward Rotation Limit";

						case Culture.CN:
							return "正向限位";
					}

				case 3:
					switch (Culture.Name)
					{
						default:
						case Culture.JP:

                            //↓↓↓ KASHIYAMA Mode 20190624 Kimura update ↓↓↓
                            if (Properties.Settings.Default.PASSWORD_KASHIYAMA == false)
                            {
                                return "負回転駆動禁止指令";
                            }
                            else
                            {
                                return "速度指定M";
                            }
                            //↑↑↑ KASHIYAMA Mode 20190624 Kimura update ↑↑↑
                            
						case Culture.US:
							//return "CW direction movement prohibition command";
							//return "CCW Disable";
							return "Reverse Rotation Limit";

						case Culture.CN:
							return "反向限位";
					}

				case 4:
					switch (Culture.Name)
					{
						default:
						case Culture.JP:
							return "アラームリセット指令";

						case Culture.US:
							//return "Alarm reset command";
							return "Alarm Reset";

						case Culture.CN:
							return "警报重置指令";
					}

				case 5:
					switch (Culture.Name)
					{
						default:
						case Culture.JP:

                            //↓↓↓ KASHIYAMA Mode 20190624 Kimura update ↓↓↓
                            if (Properties.Settings.Default.PASSWORD_KASHIYAMA == false)
                            {
                                return "偏差リセット指令";
                            }
                            else
                            {
                                return "外部アラーム入力";
                            }
                            //↑↑↑ KASHIYAMA Mode 20190624 Kimura update ↑↑↑

						case Culture.US:
							//return "Error reset command";
							//return "Position Error Reset";
							return "Counter Error Reset";

						case Culture.CN:
							return "偏差计数器重置指令";
					}

				case 6:
					switch (Culture.Name)
					{
						default:
						case Culture.JP:
							return "プロファイル動作許可指令";

						case Culture.US:
							//return "Profile movement permission command";
							return "Profile Command";

						case Culture.CN:
							return "配置文件动作许可指令";
					}

				case 7:
					switch (Culture.Name)
					{
						default:
						case Culture.JP:
                            return "原点センサ入力";
                            
						case Culture.US:
							//return "Homing sensor input";
							return "Home Sensor";

						case Culture.CN:
							return "原点编码器输入";
					}

				case 8:
					switch (Culture.Name)
					{
						default:
						case Culture.JP:
                            return "外部アラーム入力";
                            
						case Culture.US:
							//return "External alarm input";
							return "External Alarm";

						case Culture.CN:
							return "外部警报输入";
					}

				case 9:
					switch (Culture.Name)
					{
						default:
						case Culture.JP:
							return "ゲイン切り替え指令";

						case Culture.US:
							//return "Gain switch command";
							return "Gain Change";

						case Culture.CN:
							return "外部警报输入";
					}

				case 10:
					switch (Culture.Name)
					{
						default:
						case Culture.JP:
							return "アナログ入力ゼロ点調整";	//"アナログ入力ゼロ点調整指令";

						case Culture.US:
							//return "Analogue input home position tuning";	//"Analogue input home position tuning";
							return "Analog Zero Adjust";

						case Culture.CN:
							return "模拟输入零点调谐指令";
					}

				case 11:
					switch (Culture.Name)
					{
						default:
						case Culture.JP:
							return "第2電流リミット切替指令";	//"第2電流リミット切り替え指令";

						case Culture.US:
							//return "2nd current limit switch command";	//"2nd current limit switch command";
							return "2nd Current Limit";

						case Culture.CN:
							return "第2电流限位切换指令";
					}

				case 12:
					switch (Culture.Name)
					{
						default:
						case Culture.JP:
                            return "パルス入力禁止指令";
                            
						case Culture.US:
							//return "Pulse input prohibition command";
							return "Pulse Input Disable";

						case Culture.CN:
							return "指令脉冲计数禁止指令";
					}

				case 13:
					switch (Culture.Name)
					{
						default:
						case Culture.JP:
							return "原点復帰スタート指令";

						case Culture.US:
							//return "Homing start command";
							return "Home Start";

						case Culture.CN:
							return "原点复位开始指令";
					}

				case 14:
					switch (Culture.Name)
					{
						default:
						case Culture.JP:
							return "アナログ入力強制0指令";

						case Culture.US:
							//return "Analogue input compulsory 0 command";
							return "Analog Zero Command";

						case Culture.CN:
							return "模拟输入指令的强制0指令";
					}

				case 15:
					switch (Culture.Name)
					{
						default:
						case Culture.JP:
							return "簡易プログラム入力" + (io_no + 1).ToString();	//"簡易コントロールモード入力" 

						case Culture.US:
							//return "Simle program input" + (io_no + 1).ToString();	//"Simple program mode input"
							return "Program IN" + (io_no + 1).ToString();

						case Culture.CN:
							return "简易控制模式输入" + (io_no + 1).ToString();
					}

				case 16:
					switch (Culture.Name)
					{
						default:
						case Culture.JP:
							return "制御モード切り替え入力";

						case Culture.US:
							//return "Control Mode switch input";
							return "Control Mode Change";

						case Culture.CN:
							return "控制模式切换输入";
					}

				case 17:
					switch (Culture.Name)
					{
						default:
						case Culture.JP:
							return "ハードストップ";

						case Culture.US:
							//return "Hard stop";
							return "Hard Stop";

						case Culture.CN:
							return "机械停止";
					}

				case 18:
					switch (Culture.Name)
					{
						default:
						case Culture.JP:
							return "スムースストップ";

						case Culture.US:
							//return "Smooth stop";
							return "Smooth Stop";

						case Culture.CN:
							return "平滑停止";
					}

				default:
				case 99:
					switch (Culture.Name)
					{
						default:
						case Culture.JP:
							return "入力無視";

						case Culture.US:
							//return "Input ignorance";
							return "Ignore";

						case Culture.CN:
							return "输入忽略";
					}
			
			}
		}

		/// <summary>
		/// "IO Outputの設定ラベルを読み込みます"
		/// </summary>
		static public string IoMonitorGetOutputName(int io_no, int prm)
		{ 
            if (prm == -1)
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "簡易プログラム出力" + (io_no + 1).ToString();	//"簡易コントロールモード出力"

					case Culture.US:
						//return "Simple program output" + (io_no + 1).ToString();	//"Simple program mode output"
						return "Program OUT" + (io_no + 1).ToString();	//"Simple program mode output"

					case Culture.CN:
						return "简易控制模式输出" + (io_no + 1).ToString();
				}
			}

            //↓↓↓ KASHIYAMA Mode 20190624 Kimura update ↓↓↓
            if (Properties.Settings.Default.PASSWORD_KASHIYAMA == true)
            {
                string strout = CtlJogControlReserve;

                switch (io_no)
                {
                    case 0:
                        strout = "運転中出力";
                        break;

                    case 1:
                        strout = "アラーム出力";
                        break;

                    default:
                        break;

                }

                return strout;
            }
            //↑↑↑ KASHIYAMA Mode 20190624 Kimura update ↑↑↑

			const int MAX_OUT_BIT = 32;

			string[] sts_txt = new string[MAX_OUT_BIT];

			sts_txt[0] = CtlJogControlServoOn;
			sts_txt[1] = CtlJogControlProfile;
			sts_txt[2] = CtlJogControlInposition;
			sts_txt[3] = CtlJogControlAlarm;
			sts_txt[4] = CtlJogControlPositiveLimit;
			sts_txt[5] = CtlJogControlNegativeLimit;
			sts_txt[6] = CtlJogControlTorqueLimit;
			sts_txt[7] = CtlJogControlVelocityLimit;
			sts_txt[8] = CtlJogControlPositionErrorOver;
			sts_txt[9] = CtlJogControlServoReady;
			sts_txt[10] = CtlJogControlHoming;
			sts_txt[11] = CtlJogControlSecondGain;
			sts_txt[12] = CtlJogControlBattWarning;
			sts_txt[13] = CtlJogControlPowerVoltageError;
			sts_txt[14] = CtlJogControlStopVelocity;
			sts_txt[15] = CtlJogControlReserve;
			sts_txt[16] = CtlJogControlMechBrake;
			sts_txt[17] = CtlJogControlReserve;
			sts_txt[18] = CtlJogControlReserve;
			sts_txt[19] = CtlJogControlReserve;
			sts_txt[20] = CtlJogControlReserve;
			sts_txt[21] = CtlJogControlReserve;
			sts_txt[22] = CtlJogControlReserve;
			sts_txt[23] = CtlJogControlReserve;
			sts_txt[24] = CtlJogControlReachTargetPosition;
			sts_txt[25] = CtlJogControlReserve;
			sts_txt[26] = CtlJogControlReserve;
			sts_txt[27] = CtlJogControlReserve;
			sts_txt[28] = CtlJogControlReserve;
			sts_txt[29] = CtlJogControlReserve;
			sts_txt[30] = CtlJogControlReserve;
			sts_txt[31] = CtlJogControlReserve;

			string or_txt = string.Empty;
			string out_txt = string.Empty;

			int or_num = new int();

			for (int i = 0, b = 1; i < MAX_OUT_BIT; i++, b <<= 1)
			{
				if ((prm & b) == b)
				{
					out_txt = sts_txt[i];
					
					if (or_num > 0) { or_txt += "+"; }

					or_num++;

					or_txt += "B" + i.ToString();
				}
			}

			if (or_num == 0)
			{
				return CtlJogControlReserve;
			}
			else if (or_num == 1)
			{
				return out_txt;
			}
			else
			{
				return or_txt;
			}
		}

		#endregion

        //↓↓↓ ART HIKARI Mode 20181210 Kimura add ↓↓↓
        #region IoMonitorHikariForm

        /// <summary>
        /// "チップドレスプログラム"
        /// </summary>
        static public string TipDressingProgram
		{  
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "チップドレスプログラム";

                    case Culture.US:
                        return "Tip Dressing Program";

                    case Culture.CN:
                        return "Tip Dressing Program";
                }
            }        
        }


        /// <summary>
        /// "プログラム"
        /// </summary>
        static public string ProgramName
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:
                        return "プログラム";

                    case Culture.US:
                        return "Program";

                    case Culture.CN:
                        return "Program";
                }
            }
        }


        #endregion
        //↑↑↑ ART HIKARI Mode 20181210 Kimura add ↑↑↑

		#region 簡易コントロール

		/// <summary>
		/// アラームリセット
		/// </summary>
		static public string CtlCommandAL_Reset_HELP1
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "アラームリセット";

					case Culture.US:
						return "Alarm reset";

					case Culture.CN:
						return "删除程序";
				}
			}
		}

		/// <summary>
		/// アラームをリセットします。
		/// </summary>
		static public string CtlCommandAL_Reset_HELP2
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "アラームをリセットします。";

					case Culture.US:
						return "Alarm is reset.";

					case Culture.CN:
                        return "重置报警。";
				}
			}
		}

		/// <summary>
		/// プログラム終了
		/// </summary>
		static public string CtlCommandEND_C_HELP1
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "プログラム終了";

					case Culture.US:
						return "Program closed";

					case Culture.CN:
						return "程序结束";
				}
			}
		}

		/// <summary>
		/// プログラムを終了します。
		/// </summary>
		static public string CtlCommandEND_C_HELP2
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "プログラムを終了します。";

					case Culture.US:
						return "Program is closed.";

					case Culture.CN:
						return "结束程序。";
				}
			}
		}

		/// <summary>
		/// サーボＯＮ／ＯＦＦ状態は継続したまま、ＩＤ３１(制御モード)＝３[電流制御]になります。
		/// </summary>
		static public string CtlCommandEND_C_HELP3
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "サーボON/OFF状態は継続したまま、ID31(制御モード)=3[電流制御]になります。";

					case Culture.US:
						return "Keeping Servo ON/OF, ID31(Control mode) becomes 3[Current control].";

					case Culture.CN:
						return "继续保持伺服ON/OFF状态、参数ID31(控制模式)＝3设为[电流控制]。";
				}
			}
		}

		/// <summary>
		/// プログラム終了
		/// </summary>
		static public string CtlCommandEND_OFF_HELP1
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "プログラム終了";

					case Culture.US:
						return "Program closed";

					case Culture.CN:
						return "程序结束";
				}
			}
		}

		/// <summary>
		/// プログラムを終了し、サーボＯＦＦします。
		/// </summary>
		static public string CtlCommandEND_OFF_HELP2
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "プログラムを終了し、サーボＯＦＦします。";

					case Culture.US:
						return "Program is closed and Servo turns OFF";

					case Culture.CN:
						return "结束程序、伺服OFF。";
				}
			}
		}

		/// <summary>
		/// ＩＤ３１(制御モード)＝０になります。
		/// </summary>
		static public string CtlCommandEND_OFF_HELP3
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "ＩＤ３１(制御モード)＝０になります。";

					case Culture.US:
						return "ID31(Control mode) becomes 0";

					case Culture.CN:
						return "参数ID31(控制模式)=0。";
				}
			}
		}

		/// <summary>
		/// プログラム終了
		/// </summary>
		static public string CtlCommandEND_P_HELP1
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "プログラム終了";

					case Culture.US:
						return "Programa closed";

					case Culture.CN:
						return "程序结束";
				}
			}
		}

		/// <summary>
		/// プログラムを終了します。
		/// </summary>
		static public string CtlCommandEND_P_HELP2
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "プログラムを終了します。";

					case Culture.US:
						return "Program is closed.";

					case Culture.CN:
						return "结束程序";
				}
			}
		}

		/// <summary>
		/// サーボＯＮ／ＯＦＦ状態は継続したまま、ＩＤ３１(制御モード)＝１[位置制御]になります。
		/// </summary>
		static public string CtlCommandEND_P_HELP3
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "サーボOF/OFF状態は継続したまま、ID31(制御モード)=1[位置制御]になります。";

					case Culture.US:
						return "Keeping Servo ON/OF, ID31(Control mode) becomes 1[Position control].";

					case Culture.CN:
						return "继续保持伺服ON/OFF状态、参数ID31(控制模式)=1设为[位置控制]。";
				}
			}
		}

		/// <summary>
		/// ※位置指令は現在位置になります。
		/// </summary>
		static public string CtlCommandEND_P_HELP4
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "※位置指令は現在位置になります。";

					case Culture.US:
						return "※Position command is current position.";

					case Culture.CN:
						return "※位置指令为现在位置。";
				}
			}
		}

		/// <summary>
		/// プログラム終了
		/// </summary>
		static public string CtlCommandEND_V_HELP1
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "プログラム終了";

					case Culture.US:
						return "Program closed";

					case Culture.CN:
						return "程序结束";
				}
			}
		}

		/// <summary>
		/// プログラムを終了します。
		/// </summary>
		static public string CtlCommandEND_V_HELP2
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "プログラムを終了します。";

					case Culture.US:
						return "Program is closed.";

					case Culture.CN:
						return "结束程序";
				}
			}
		}

		/// <summary>
		/// サーボＯＮ／ＯＦＦ状態は継続したまま、ＩＤ３１(制御モード)＝２[速度制御]になります。
		/// </summary>
		static public string CtlCommandEND_V_HELP3
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "サーボON/OFF状態は継続したまま、ID31(制御モード)=2[速度制御]になります。";

					case Culture.US:
						return "Keeping Servo ON/OF, ID31(Control mode) becomes 2[Speed control].";

					case Culture.CN:
						return "继续保持伺服ON/OFF状态、参数ID31(控制模式)＝2设为[速度控制]。";
				}
			}
		}

		/// <summary>
		/// ※速度指令は０になります。
		/// </summary>
		static public string CtlCommandEND_V_HELP4
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "※速度指令は0になります。";

					case Culture.US:
						return "Speed command becomes 0.";

					case Culture.CN:
						return "※速度指令为0。";
				}
			}
		}

		/// <summary>
		/// 原点復帰
		/// </summary>
		static public string CtlCommandHOME_HELP1
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "原点復帰";

					case Culture.US:
						return "Homing";

					case Culture.CN:
						return "原点复归。";
				}
			}
		}

		/// <summary>
		/// ＩＤ９０～９６のパラメータに従い、原点復帰動作を行います。
		/// </summary>
		static public string CtlCommandHOME_HELP2
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "ID90～96のパラメータに従い、原点復帰動作を行います。";

					case Culture.US:
						return "Complying with ID90 to 96, Homing is started.";

					case Culture.CN:
						return "根据参数ID90～96的参数、进行原点复归动作。";
				}
			}
		}

		/// <summary>
		/// 制御モード＝４と同じ動作仕様
		/// </summary>
		static public string CtlCommandHOME_HELP3
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "制御モード=4と同じ動作仕様";

					case Culture.US:
						return "Same as Congrol mode =4.";

					case Culture.CN:
						return "（与控制模式=4为同样的动作形式）";
				}
			}
		}

		/// <summary>
		/// 待機判断＆条件分岐
		/// </summary>
		static public string CtlCommandJMP_IN_HELP1
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "待機判断＆条件分岐";

					case Culture.US:
						return "Wating judgement & Conditional branch.";

					case Culture.CN:
						return "待机判断＆条件分支";
				}
			}
		}

		/// <summary>
		/// ＭＯＤＥ＿Ｊ１の条件完了で次のステップに移行します。
		/// </summary>
		static public string CtlCommandJMP_IN_HELP2
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "MODE_J1の条件完了で次のステップに移行します。";

					case Culture.US:
						return "Move to next step by completion of MODE_J1 condition.";

					case Culture.CN:
						return "MODE_J1的条件完成后向下一个步骤移行。";
				}
			}
		}

		/// <summary>
		/// 条件完了前に指定の接点入力があった場合は分岐先ステップに分岐します。
		/// </summary>
		static public string CtlCommandJMP_IN_HELP3
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "条件完了前に指定の接点入力があった場合は分岐先ステップに分岐します。";

					case Culture.US:
						return "Move to branch destination in case a specific contact input is dome before completion of the condition.";

					case Culture.CN:
						return "条件完成前如有指定的接点输入的话，在分支目标步骤分支。";
				}
			}
		}

		/// <summary>
		/// 待機判断＆条件分岐（ＯＦＦ論理）
		/// </summary>
		static public string CtlCommandJMP_IN_OFF_HELP1
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "待機判断＆条件分岐（OFF論理）";

					case Culture.US:
						return "Wating judgement & Conditional branch.(OFF logic)";

					case Culture.CN:
						return "待机判断＆条件分歧（OFF逻辑）";
				}
			}
		}

		/// <summary>
		/// MODE_J2の条件完了で次のステップに移行します。
		/// </summary>
		static public string CtlCommandJMP_IN_OFF_HELP2
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "MODE_J2の条件完了で次のステップに移行します。";

					case Culture.US:
                        return "Move onto the next step after completing condition of MODE_J2.";

					case Culture.CN:
						return "MODE_J2的条件完成后向下一个步骤移行。";
				}
			}
		}

		/// <summary>
		/// 条件完了前に指定の接点入力がＯＦＦした場合は分岐先STEPに分岐します。
		/// </summary>
		static public string CtlCommandJMP_IN_OFF_HELP3
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "条件完了前に指定の接点入力がOFFした場合は分岐先STEPに分岐します。";

					case Culture.US:
                        return "Branch into Branch STEP in case specified contact input was OFF before condition is completed.";

					case Culture.CN:
						return "条件完成前如有指定的接点输入的话，在分支目标步骤分支。";
				}
			}
		}

		/// <summary>
		/// ステータス判断分岐
		/// </summary>
		static public string CtlCommandJMP_STS_HELP1
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "ステータス判断分岐";

					case Culture.US:
                        return "Status judgement branch";

					case Culture.CN:
						return "状态判断分歧";
				}
			}
		}

		/// <summary>
		/// MODE_J1の条件完了で次のステップに移行します。
		/// </summary>
		static public string CtlCommandJMP_STS_HELP2
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "MODE_J1の条件完了で次のステップに移行します。";

					case Culture.US:
                        return "I shift to the next step by condition completion of MODE_J1.";

					case Culture.CN:
						return "MODE_J1的条件完成后向下一步骤移行";
				}
			}
		}

		/// <summary>
		/// 条件完了前にID20(サーボ状態表示)の指定ビットが[0]または[1]になったら分岐先STEPに分岐します。
		/// [1]か[0]の指定は、分岐論理により設定します。
		/// </summary>
		static public string CtlCommandJMP_STS_HELP3
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "条件完了前にID20(サーボ状態表示)の指定ビットが[0]または[1]になったら分岐先STEPに分岐します。" + Environment.NewLine +
							   "[1]か[0]の指定は、分岐論理により設定します。";

					case Culture.US:
						return "If the designation bit of ID20 (servo status display) will be [0] or [1] before condition completion,it branches in branch destination STEP. " + Environment.NewLine +
                                "Designation of [1] or [0] is established by branch logic.";

					case Culture.CN:
						return "在条件完成前ID20（伺服状态表示）的指定位为[0]或[1]时向分歧目标步骤分歧" + Environment.NewLine +
							   "[0]或[1]的指定是根据分歧逻辑进行设定";
				}
			}
		}

		/// <summary>
		/// トルクモニタ分岐
		/// </summary>
		static public string CtlCommandJMP_TRQ_HELP1
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "トルクモニタ分岐";

					case Culture.US:
                        return "Torque monitor branch";

					case Culture.CN:
						return "扭矩显示分歧";
				}
			}

		}

		/// <summary>
		/// MODE_J3の条件完了で次のステップに移行します。
		/// </summary>
		static public string CtlCommandJMP_TRQ_HELP2
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "MODE_J3の条件完了で次のステップに移行します。";

					case Culture.US:
                        return "Move onto the next step after completing condition of MODE_J3.";

					case Culture.CN:
						return "MODE_J3的条件完成后向下一步骤移行";
				}
			}

		}

		/// <summary>
		/// 条件完了前にトルクモニタ値が指定の閾値を超えた場合は分岐先STEPに分岐します。
		/// 分岐論理の設定により、閾値を上回った場合に分岐か、下回った場合に分岐かを選択できます。
		/// </summary>
		static public string CtlCommandJMP_TRQ_HELP3
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "条件完了前にトルクモニタ値が指定の閾値を超えた場合は分岐先STEPに分岐します。" + Environment.NewLine +
							   "分岐論理の設定により、閾値を上回った場合に分岐か、下回った場合に分岐かを選択できます。";

					case Culture.US:
                        return "Branch into Branch STEP in case torque monitor value is beyond the specified threshold value before condition is completed." + Environment.NewLine +
                               "By setting branch logic, branch timing can be selected between more and less than threshold value.";

					case Culture.CN:
						return "条件完成前，扭矩显示值超过指定阈值时直接进入分歧目的步骤" + Environment.NewLine +
							   "根据分歧逻辑的设定，可以选择超过阈值时进行分歧或低于阈值时进行分歧";
				}
			}

		}

		/// <summary>
		/// 無条件分岐
		/// </summary>
		static public string CtlCommandJMP0_HELP1
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "無条件分岐";

					case Culture.US:
                        return "Unconditional branch";

					case Culture.CN:
						return "无条件分支";
				}
			}

		}

		/// <summary>
		/// 待機時間経過後に繰り返し回数で分岐先ステップに分岐します。
		/// </summary>
		static public string CtlCommandJMP0_HELP2
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "待機時間経過後に繰り返し回数で分岐先ステップに分岐します。";

					case Culture.US:
                        return "It diverges to the step repeatedly after the standby time passes by the frequency the divergence ahead.";

					case Culture.CN:
						return "待机时间经过后，以反复回数决定在分支目标步骤的分支。";
				}
			}

		}

		/// <summary>
		/// ※繰り返し回数を０に設定した場合は無限回となります。
		/// </summary>
		static public string CtlCommandJMP0_HELP3
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "※繰り返し回数を0に設定した場合は無限回となります。";

					case Culture.US:
                        return "* When it repeats and the frequency is set to 0, it becomes infinite times.";

					case Culture.CN:
						return "※反复回数设为0的话为无限回。";
				}
			}

		}

		/// <summary>
		/// 電流制御開始命令
		/// </summary>
		static public string CtlCommandMOVE_C_HELP1
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "電流制御開始命令";

					case Culture.US:
                        return "Current control beginning instruction";

					case Culture.CN:
						return "电流控制开始命令";
				}
			}

		}

		/// <summary>
		/// 目標電流で電流制御開始し次のステップへ移行します
		/// </summary>
		static public string CtlCommandMOVE_C_HELP2
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "目標電流で電流制御開始し次のステップへ移行します";

					case Culture.US:
                        return "It begins to control the current by the current of the target and it shifts to the next step.";

					case Culture.CN:
						return "用目标电流开始电流控制并向下一步骤移行。";
				}
			}

		}

		/// <summary>
		/// FLAG_M4の設定によりアナログ指令での制御も可能です。
		/// </summary>
		static public string CtlCommandMOVE_C_HELP3
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "FLAG_M4の設定によりアナログ指令での制御も可能です。";

					case Culture.US:
                        return "Setting of FLAG_M4 enables control by analog command";

					case Culture.CN:
						return "根据FLAG_M4的设定可以实行模拟指令下的控制。";
				}
			}

		}

		/// <summary>
		/// 通常移動命令（位置制御）
		/// </summary>
		static public string CtlCommandMOVE_END_HELP1
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "通常移動命令（位置制御）";

					case Culture.US:
                        return "March order usually (position control)";

					case Culture.CN:
						return "通常移动命令（位置控制）";
				}
			}

		}

		/// <summary>
		/// 目標位置に目標速度、加速度、減速度で移動します。
		/// </summary>
		static public string CtlCommandMOVE_END_HELP2
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "目標位置に目標速度、加速度、減速度で移動します。";

					case Culture.US:
                        return "It moves to the target position by the speed of the target, the acceleration, and the deceleration.";

					case Culture.CN:
						return "以目标速度，加速度，减速度向目标位置移动。";
				}
			}

		}

		/// <summary>
		/// 移動完了後は移動完了条件後に次のステップへ移動します。
		/// </summary>
		static public string CtlCommandMOVE_END_HELP3
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "移動完了後は移動完了条件後に次のステップへ移動します。";

					case Culture.US:
                        return "After the movement completion condition, it moves to the next step after the movement is completed.";

					case Culture.CN:
						return "移动完了后是移动完了条件后向下一步骤移行。";
				}
			}

		}

		/// <summary>
		/// 移動開始命令（位置制御）
		/// </summary>
		static public string CtlCommandMOVE_ST_HELP1
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "移動開始命令（位置制御）";

					case Culture.US:
                        return "Movement beginning instruction (position control)";

					case Culture.CN:
						return "移动开始命令（位置控制）";
				}
			}

		}

		/// <summary>
		/// 目標位置に目標速度、加速度、減速度で移動し次のステップへ移行します。
		/// </summary>
		static public string CtlCommandMOVE_ST_HELP2
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "目標位置に目標速度、加速度、減速度で移動し次のステップへ移行します。";

					case Culture.US:
                        return "It moves to the target position by the speed of the target, the acceleration, and the deceleration and it shifts to the next step.";

					case Culture.CN:
						return "以目标速度，加速度，减速度向目标位置移动并向下一步骤移行。";
				}
			}

		}

		/// <summary>
		/// 移動中に条件分岐等を入れたい場合に使用します。
		/// </summary>
		static public string CtlCommandMOVE_ST_HELP3
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "移動中に条件分岐等を入れたい場合に使用します。";

					case Culture.US:
                        return "It uses it to put the condition branching etc. while moving.";

					case Culture.CN:
						return "在移动中如想加入条件分支时使用。";
				}
			}

		}

		/// <summary>
		/// 速度制御命令
		/// </summary>
		static public string CtlCommandMOVE_V_HELP1
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "速度制御命令";

					case Culture.US:
                        return "Speed control instruction";

					case Culture.CN:
						return "速度控制命令";
				}
			}

		}

		/// <summary>
		/// 目標速度、加速度、減速度で速度制御開始し次のステップへ移行します。
		/// FLAG_M3の設定によりアナログ指令での制御も可能です。
		/// アナログ指令時は加速度、減速度設定値は無視されます。
		/// </summary>
		static public string CtlCommandMOVE_V_HELP2
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "目標速度、加速度、減速度で速度制御開始し次のステップへ移行します。" + Environment.NewLine +
							   "FLAG_M3の設定によりアナログ指令での制御も可能です。" + Environment.NewLine +
							   "アナログ指令時は加速度、減速度設定値は無視されます。";

					case Culture.US:
                        return "It begins to control the speed by the speed of the target, the acceleration, and the deceleration and it shifts to the next step." + Environment.NewLine +
                               "Setting of FLAG_M3 enables control by analog command." + Environment.NewLine +
                               "Acceleration/deceleration setting values are ignored during analog command.";

					case Culture.CN:
						return "以目标速度，加速度，减速度开始速度控制并向下一步骤移行。" + Environment.NewLine +
							   "可以根据FLAG_M3设定的模拟指令的控制。" + Environment.NewLine +
							   "模拟指令时加速度，减速度的设定值被无视。";

				}
			}

		}

		/// <summary>
		/// 何もせず次のステップへ移行
		/// </summary>
		static public string CtlCommandNOP_HELP1
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "何もせず次のステップへ移行";

					case Culture.US:
                        return "Nothing is done and it shifts to the next step.";

					case Culture.CN:
						return "无任何改动直接向下一步骤移行";
				}
			}

		}

		/// <summary>
		/// 存在しない命令を実行した場合もＮＯＰ扱いとします。
		/// </summary>
		static public string CtlCommandNOP_HELP2
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "存在しない命令を実行した場合もNOP扱いとします。";

					case Culture.US:
                        return "When the instruction that doesn't exist is executed, it is assumed the NOP treatment.";

					case Culture.CN:
						return "实行了不存在的命令的话也属于NOP操纵。";
				}
			}

		}

		/// <summary>
		/// 接点出力
		/// </summary>
		static public string CtlCommandOUT_0_HELP1
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "接点出力";

					case Culture.US:
                        return "Contact output";

					case Culture.CN:
						return "接点输出";
				}
			}

		}

		/// <summary>
		/// 指定した番号の接点出力をＯＮ／ＯＦＦします。
		/// </summary>
		static public string CtlCommandOUT_0_HELP2
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "指定した番号の接点出力をON/OFFします。";

					case Culture.US:
                        return "The contact output of the specified number is turned on and off.";

					case Culture.CN:
						return "ON/OFF指定的编号接点输出。";
				}
			}

		}

		/// <summary>
		/// 現在位置リセット
		/// </summary>
		static public string CtlCommandP_RESET_HELP1
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "現在位置リセット";

					case Culture.US:
                        return "Present Position reset";

					case Culture.CN:
						return "现在位置重置";
				}
			}

		}

		/// <summary>
		/// 現在位置をＩＤ：３９（ポジションリセット値）に初期化します。
		/// </summary>
		static public string CtlCommandP_RESET_HELP2
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "現在位置をID:39（ポジションリセット値）に初期化します。";

					case Culture.US:
                        return "Present Position is initialized ..ID:39 (position reset value).";

					case Culture.CN:
						return "将现在位置按参数ID:39（位置重置值）进行初期化。";
				}
			}

		}

		/// <summary>
		/// 注意：モータ回転中（移動命令実行中）に位置リセットを行わないでください。
		/// </summary>
		static public string CtlCommandP_RESET_HELP3
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "注意：モータ回転中（移動命令実行中）に位置リセットを行わないでください。";

					case Culture.US:
                        return "Attention: Please do not reset the position while the motor is rotating (The movement instruction is being executed)";

					case Culture.CN:
						return "注意：请不要在电机回转中（移动命令实施中）进行位置重置。";
				}
			}

		}

		/// <summary>
		/// 暴走の可能性があります。
		/// </summary>
		static public string CtlCommandP_RESET_HELP4
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "暴走の可能性があります。";

					case Culture.US:
                        return "There is a possibility of reckless driving.";

					case Culture.CN:
						return "有导致暴走的可能性。";
				}
			}

		}

		/// <summary>
		/// ※サーボＯＮ中に現在位置リセットを行うと、一旦０速度制御になり、リセット完了後位置制御に戻ります。
		/// </summary>
		static public string CtlCommandP_RESET_HELP5
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "※サーボON中に現在位置リセットを行うと、一旦0速度制御になり、リセット完了後位置制御に戻ります。";

					case Culture.US:
                        return "* It becomes 0 speed control once if present location is reset in servo ON, and it returns to a positional control after reset is completed.";

					case Culture.CN:
						return "※在伺服ON状态下进行位置重置的话、暂且设为0速度控制、重置完成后再恢复成位置控制。";
				}
			}

		}

		/// <summary>
		/// 指定したパラメータＩＤのパラメータ変更を行います。
		/// </summary>
		static public string CtlCommandPARA_W_HELP1
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "指定したパラメータIDのパラメータ変更を行います。";

					case Culture.US:
                        return "The parameter of specified parameter ID is changed.";

					case Culture.CN:
						return "进行指定的参数ID的参数变更。";
				}
			}

		}

		/// <summary>
		/// 書き込めないパラメータを指定した場合は何も行いません。
		/// </summary>
		static public string CtlCommandPARA_W_HELP2
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "書き込めないパラメータを指定した場合は何も行いません。";

					case Culture.US:
                        return "When the parameter that cannot be written is specified, nothing is done.";

					case Culture.CN:
						return "指定的为无法写入参数的话不会有任何变化。";
				}
			}

		}

		/// <summary>
		/// ※書込データは４バイトですが、２バイト／1バイトのパラメータを変更する場合は上位バイトは無視されます。
		/// </summary>
		static public string CtlCommandPARA_W_HELP3
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "※書込データは４バイトですが、２バイト／1バイトのパラメータを変更する場合は上位バイトは無視されます。";

					case Culture.US:
                        return "* When it writes and the parameter in two bytes/one byte is changed though data is four bytes, a high-ranking byte is disregarded.";

					case Culture.CN:
						return "※写入参数数据为4字节、如想改为2字节／1字节的参数的话高位字节将被忽略。";
				}
			}

		}

		/// <summary>
		/// ジャンプ命令繰り返し回数リセット
		/// </summary>
		static public string CtlCommandPC_RESET_HELP1
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "ジャンプ命令繰り返し回数リセット";

					case Culture.US:
                        return "It resets it the frequency the jump instruction and repeatedly.";

					case Culture.CN:
						return "跳转命令重复回数重置";
				}
			}

		}

		/// <summary>
		/// ＪＭＰ０の繰り返し回数を設定された初期値に設定します。
		/// </summary>
		static public string CtlCommandPC_RESET_HELP2
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "JMP0の繰り返し回数を設定された初期値に設定します。";

					case Culture.US:
                        return "It sets it to an initial value to which the repetition frequency of JMP0 is set.";

					case Culture.CN:
						return "将JMP0的重复回数设定为初期值。";
				}
			}

		}

		/// <summary>
		/// ※必要に応じて、プログラムの最初に本命令を実行する事をお勧めします。
		/// </summary>
		static public string CtlCommandPC_RESET_HELP3
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "※必要に応じて、プログラムの最初に本命令を実行する事をお勧めします。";

					case Culture.US:
                        return "* We will recommend the thing that the program executes this instruction first if necessary.";

					case Culture.CN:
						return "※必要的话、推荐在程序最初进行此设定。";
				}
			}

		}

		/// <summary>
		/// 繰り返し回数指定リセット
		/// </summary>
		static public string CtlCommandPC_RSP_SP_HELP1
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "繰り返し回数指定リセット";

					case Culture.US:
                        return "Repeat count specify reset";

					case Culture.CN:
						return "清除指定的反复回数";
				}
			}

		}

		/// <summary>
		/// 
		/// </summary>
		static public string CtlCommandPC_RSP_SP_HELP2
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "指定したステップのJPM0命令の繰り返し残り回数を初期値にリセットします。" + Environment.NewLine +
							   "指定したステップがJMP0命令でない場合は何もしません。";

					case Culture.US:
						return "Restore remaining repeat count of JPM0 command of specified step to default."+ Environment.NewLine +
                               "No operation is made unless the preset step is JMP0 command.";

					case Culture.CN:
						return "将被指定步骤的JPM0指令的剩余反复回数重置为初始值" + Environment.NewLine +
							   "如被指定步骤不是JMP0指令时，不做任何动作";
				}
			}
		}

		/// <summary>
		/// サーボＯＦＦ
		/// </summary>
		static public string CtlCommandSV_OFF_HELP1
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "サーボOFF";

					case Culture.US:
                        return "Servo OFF";

					case Culture.CN:
						return "伺服OFF";
				}
			}

		}

		/// <summary>
		/// サーボＯＦＦします。
		/// </summary>
		static public string CtlCommandSV_OFF_HELP2
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "サーボOFFします。";

					case Culture.US:
                        return "Servo OFF is done.";

					case Culture.CN:
						return "伺服OFF。";
				}
			}

		}

		/// <summary>
		/// サーボＯＮ
		/// </summary>
		static public string CtlCommandSV_ON_HELP1
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "サーボON";

					case Culture.US:
                        return "Servo ON";

					case Culture.CN:
						return "伺服ON";
				}
			}

		}

		/// <summary>
		/// 現在位置でサーボＯＮします。
		/// </summary>
		static public string CtlCommandSV_ON_HELP2
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "現在位置でサーボONします。";

					case Culture.US:
                        return "Servo ON is done in present location.";

					case Culture.CN:
						return "在现在位置伺服ON。";
				}
			}

		}

		/// <summary>
		/// ※サーボＯＮ後は０．５ｓｅｃの待機時間が入ります。
		/// </summary>
		static public string CtlCommandSV_ON_HELP3
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "※サーボON後は0.5sec待機時間が入ります。";

					case Culture.US:
                        return "* The standby time of 0.5sec enters after servo ON.";

					case Culture.CN:
						return "※伺服ON后有0.5sec的待机时间。";
				}
			}
		}

		/// <summary>
		/// 無条件待機
		/// </summary>
		static public string CtlCommandWAIT_0_HELP1
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "無条件待機";

					case Culture.US:
                        return "Unconditional standby";

					case Culture.CN:
						return "无条件待机";
				}
			}
		}

		/// <summary>
		/// 待機時間経過後に次のステップに移行します。
		/// </summary>
		static public string CtlCommandWAIT_0_HELP2
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "待機時間経過後に次のステップに移行します。";

					case Culture.US:
                        return "After the standby time passes, it shifts to the next step.";

					case Culture.CN:
						return "嗲挤时间经过后向下一步骤移行。";
				}
			}
		}

		/// <summary>
		/// 簡易コントロール
		/// </summary>
		static public string ProgramTitle
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "簡易コントロール";

					case Culture.US:
						return "Simple control";

					case Culture.CN:
						return "简易控制";
				}
			}
		}

		/// <summary>
		/// プログラム操作機能が動作中の為、実行出来ません。
		/// </summary>
		static public string ProgramRunError
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "プログラム操作機能が動作中の為、実行出来ません。";

					case Culture.US:
						return "Can't start because program control function is now activating.";

					case Culture.CN:
						return "因程序操作功能运行中，导致无法实行。";
				}
			}
		}

		/// <summary>
		/// 運転開始
		/// </summary>
		static public string ProgramOperationStart
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "運転開始";

					case Culture.US:
						//return "Moving start";
						return "Program Start";

					case Culture.CN:
						return "开始操作";
				}
			}
		}

		/// <summary>
		/// 運転停止
		/// </summary>
		static public string ProgramOperationStop
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "運転停止";

					case Culture.US:
						//return "Moving stop";
						return "Program Stop";

					case Culture.CN:
						return "停止运转";
				}
			}
		}

		/// <summary>
		/// ダウンロード
		/// </summary>
		static public string ProgramDownLoad_H
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "ダウンロード";

					case Culture.US:
						return "Download";

					case Culture.CN:
						return "下载";
				}
			}
		}

		/// <summary>
		/// プログラムをダウンロードします。
		/// </summary>
		static public string ProgramDownLoad_M1
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "プログラムをダウンロードします。";

					case Culture.US:
						return "Program is downloaded.";

					case Culture.CN:
						return "是否下载程序？";
				}
			}
		}

		/// <summary>
		/// よろしいですか？
		/// </summary>
		static public string Program_OK_M
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "よろしいですか？";

					case Culture.US:
						return "Is it OK?";

					case Culture.CN:
                        return "好吗？";
				}
			}
		}

		/// <summary>
		/// プログラムのダウンロードに失敗しました。
		/// </summary>
		static public string ProgramDownLoad_NG_M
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "プログラムのダウンロードに失敗しました。";

					case Culture.US:
						return "Program download is failed.";

					case Culture.CN:
						return "程序下载失败。";
				}
			}
		}

		/// <summary>
		/// アップロード
		/// </summary>
		static public string ProgramUpLoad_H
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "アップロード";

					case Culture.US:
						return "Upload";

					case Culture.CN:
						return "上载";
				}
			}
		}

		/// <summary>
		/// プログラムをアップロードします。
		/// </summary>
		static public string ProgramUpLoad_M1
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "プログラムをアップロードします。";

					case Culture.US:
						return "Program is uploaded.";

					case Culture.CN:
						return "是否上载程序？";
				}
			}
		}

		/// <summary>
		/// プログラムのアップロードに失敗しました。
		/// </summary>
		static public string ProgramUpLoad_NG_M
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "プログラムのアップロードに失敗しました。";

					case Culture.US:
						return "Program upload is failed.";

					case Culture.CN:
						return "程序上载失败。";
				}
			}
		}

		/// <summary>
		/// プログラムファイル読込み
		/// </summary>
		static public string ProgramFileRead_H
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "プログラムファイル読込み";

					case Culture.US:
						return "Read program file.";

					case Culture.CN:
						return "读取程序文件";
				}
			}
		}

		/// <summary>
		/// プログラムファイルを読込みました。
		/// </summary>
		static public string ProgramFileRead_M
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "プログラムファイルを読込みました。";

					case Culture.US:
						return "Program file was read.";

					case Culture.CN:
						return "已读取程序文件";
				}
			}
		}

		/// <summary>
		/// プログラムファイル読込みエラー
		/// </summary>
		static public string ProgramFileRead_ERR_H
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "プログラムファイル読込みエラー";

					case Culture.US:
						return "Reading error of program file.";

					case Culture.CN:
						return "读取程序文件错误";
				}
			}
		}

		/// <summary>
		/// プログラムファイル読込み異常です
		/// </summary>
		static public string ProgramFileRead_ERR_M
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "プログラムファイル読込み異常です";

					case Culture.US:
						return "Program file reading problem.";

					case Culture.CN:
						return "读取程序文件异常";
				}
			}
		}

		/// <summary>
		/// プログラムファイル保存
		/// </summary>
		static public string ProgramFileSave_H
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "プログラムファイル保存";

					case Culture.US:
						return "Save program file";

					case Culture.CN:
						return "程序文件保存";
				}
			}
		}

		/// <summary>
		/// プログラムファイルへを保存しました。
		/// </summary>
		static public string ProgramFileSave_M
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "プログラムファイルへを保存しました。";

					case Culture.US:
						return "Program file is saved.";

					case Culture.CN:
						return "程序文件保存成功";
				}
			}
		}

		/// <summary>
		/// プログラムファイル保存エラー
		/// </summary>
		static public string ProgramFileSave_ERR_H
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "プログラムファイル保存エラー";

					case Culture.US:
						return "Program file saving error";

					case Culture.CN:
						return "程序文件保存错误";
				}
			}
		}

		/// <summary>
		/// プログラム保存に失敗しました。
		/// </summary>
		static public string ProgramFileSave_ERR_M
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "プログラム保存に失敗しました。";

					case Culture.US:
						return "Program save was failed.";

					case Culture.CN:
						return "程序保存失败";
				}
			}
		}

		/// <summary>
		/// プログラム保存
		/// </summary>
		static public string ProgramSave_H
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "プログラム保存";

					case Culture.US:
						return "Program saving";

					case Culture.CN:
						return "程序保存";
				}
			}
		}

		/// <summary>
		/// 現在、ダウンロードされているプログラムをフラッシュメモリに保存します。
		/// </summary>
		static public string ProgramSave_M1
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "現在、ダウンロードされているプログラムをフラッシュメモリに保存します。";

					case Culture.US:
						return "Saving dowmloaded program to flush memory...";

					case Culture.CN:
						return "是否将程序保存在闪存中？";
				}
			}
		}

		/// <summary>
		/// プログラムをフラッシュメモリに保存にしました。
		/// </summary>
		static public string ProgramFlash_M
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "プログラムをフラッシュメモリに保存にしました。";

					case Culture.US:
						return "Program was saved in flush memory.";

					case Culture.CN:
						return "程序已保存在闪存内。";
				}
			}
		}

		/// <summary>
		/// プログラムのフラッシュメモリへの保存に失敗しました。
		/// </summary>
		static public string ProgramFlash_ERR_M
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "プログラムのフラッシュメモリへの保存に失敗しました。";

					case Culture.US:
						return "Program saving to flush memory was failed.";

					case Culture.CN:
						return "程序在闪存内的保存失败。";
				}
			}
		}

		/// <summary>
		/// プログラム消去
		/// </summary>
		static public string ProgramDelete_H
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "プログラム消去";

					case Culture.US:
						return "Program delete";

					case Culture.CN:
						return "删除程序";
				}
			}
		}

		/// <summary>
		/// 現在、フラッシュメモリに保存されているプログラムを消去します。	
		/// </summary>
		static public string ProgramDelete_M1
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "現在、フラッシュメモリに保存されているプログラムを消去します。";

					case Culture.US:
						return "Deleting program saved in flush memory...";

					case Culture.CN:
						return "是否删除闪存内的程序？";
				}
			}
		}

		/// <summary>
		/// プログラムをフラッシュメモリから消去しました。	
		/// </summary>
		static public string ProgramDelete_End_M
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "プログラムをフラッシュメモリから消去しました。";

					case Culture.US:
						return "Program was deleted from flush memory.";

					case Culture.CN:
						return "程序已从闪存中删除。";
				}
			}
		}

		/// <summary>
		/// フラッシュメモリからのプログラムの消去に失敗しました。	
		/// </summary>
		static public string ProgramDelete_NG_M
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "フラッシュメモリからのプログラムの消去に失敗しました。";

					case Culture.US:
						return "Program delete from flush memory was failed.";

					case Culture.CN:
						return "闪存中的程序删除失败。";
				}
			}
		}

		/// <summary>
		/// プログラム貼り付け
		/// </summary>
		static public string ProgramPaste_NG_H
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "プログラム貼り付け";

					case Culture.US:
						return "Program creation";

					case Culture.CN:
						return "粘贴程序";
				}
			}
		}

		/// <summary>
		/// 貼り付けるプログラムが最大ステップ(１２８ステップ)を超えています。
		/// </summary>
		static public string ProgramPaste_NG_M
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "貼り付けるプログラムが最大ステップ(１２８ステップ)を超えています。";

					case Culture.US:
						return "Total number of steps created in this program is exceeding allowable maximum steps(128 sptes).";

					case Culture.CN:
						return "要粘贴的程序超过最大字节（128字节）。";
				}
			}
		}

		/// <summary>
		/// プログラム終了
		/// </summary>
		static public string ProgramEND_H
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "プログラム終了";

					case Culture.US:
						return "Program finish";

					case Culture.CN:
						return "程序结束了。";
				}
			}
		}

		/// <summary>
		/// プログラムが終了しました。
		/// </summary>
		static public string ProgramEND_M
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "プログラムが終了しました。";

					case Culture.US:
						return "Program was finished.";

					case Culture.CN:
						return "程序结束了。";
				}
			}
		}

		/// <summary>
		/// プログラムアップロード中です！！
		/// </summary>
		static public string ProgramUp_Now_M
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "プログラムアップロード中です！！";

					case Culture.US:
						return "Program uploading...";

					case Culture.CN:
						return "程序上载中！！";
				}
			}
		}

		/// <summary>
		/// プログラムのアップロードが終了しました。
		/// </summary>
		static public string ProgramUp_End_M
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "プログラムのアップロードが終了しました。";

					case Culture.US:
						return "Program upload was completed.";

					case Culture.CN:
						return "程序上载完毕。";
				}
			}
		}

		/// <summary>
		/// プログラムのダウンロードが終了しました。
		/// </summary>
		static public string ProgramDown_End_M
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "プログラムのダウンロードが終了しました。";

					case Culture.US:
						return "Program dowload was completed.";

					case Culture.CN:
						return "程序下载完毕。";
				}
			}
		}

		/// <summary>
		/// プログラムダウンロード中です！！	
		/// </summary>
		static public string ProgramDown_Now_M
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "プログラムダウンロード中です！！	";

					case Culture.US:
						return "Program downloading...";

					case Culture.CN:
						return "程序下载中！！";
				}
			}
		}

		/// <summary>
		/// 現在、プログラムが動作中です。
		/// </summary>
		static public string ProgramRun_Now_M1
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "現在、プログラムが動作中です。";

					case Culture.US:
                        return "Currently, the program is in operation.";

					case Culture.CN:
                        return "现在在程序执行中";
				}
			}
		}

		/// <summary>
		/// プログラムを停止して、簡易コントロールを終了します。
		/// </summary>
		static public string ProgramRun_Now_M2
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "プログラムを停止して、簡易コントロールを終了します。";

					case Culture.US:
						return "stopping program, and Simple control is closed.";

					case Culture.CN:
                        return "停止程序，结束简易控制";
				}
			}
		}

		#endregion

		#region ProfileMovementTableForm

		/// <summary>
		/// 相対値移動
		/// </summary>
		static public string ProfileMovementRelative
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "相対値移動";

					case Culture.US:
						return "Relative";

					case Culture.CN:
						return "相对位置移动";
				}
			}
		}

		/// <summary>
		/// 絶対値移動
		/// </summary>
		static public string ProfileMovementAbsolute
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "絶対値移動";

					case Culture.US:
						return "Absolute";

					case Culture.CN:
						return "绝对值移动";
				}
			}
		}

		/// <summary>
		/// 指令位置到達&インポジ
		/// </summary>
		static public string ProfileMovementPosInpos
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "指令位置到達&インポジ";

					case Culture.US:
						return "Position&InPosition";

					case Culture.CN:
						return "到达指令位置＆定位";
				}
			}
		}

		/// <summary>
		/// 指令位置到達
		/// </summary>
		static public string ProfileMovementPosition
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "指令位置到達";

					case Culture.US:
						return "Position";

					case Culture.CN:
						return "到达指令位置";
				}
			}
		}

		/// <summary>
		/// 取得
		/// </summary>
		static public string ProfileMovementRead
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "取得";

					case Culture.US:
						return "READ";

					case Culture.CN:
						return "取得";
				}
			}
		}

		/// <summary>
		/// 設定
		/// </summary>
		static public string ProfileMovementWrite
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "設定";

					case Culture.US:
						return "WRITE";

					case Culture.CN:
						return "设定";
				}
			}
		}

		#endregion

		#region アラーム履歴

		/// <summary>
		/// ｱﾗｰﾑｺｰﾄﾞ
		/// </summary>
		static public string AlarmHistory_Item_INF0
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
                        //↓↓↓ KASHIYAMA Mode 20190930 Kimura update ↓↓↓
                        return Properties.Settings.Default.PASSWORD_KASHIYAMA == false ? 
                               "ｱﾗｰﾑｺｰﾄﾞ" : "ｱﾗｰﾑ番号";
                        //↓↓↓ KASHIYAMA Mode 20190930 Kimura update ↓↓↓
					case Culture.US:
						return "Alarm Code";

					case Culture.CN:
						return "警报编码";
				}
			}
		}

		/// <summary>
		/// 発生年月日
		/// </summary>
		static public string AlarmHistory_Item_INF1
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
                        //↓↓↓ KASHIYAMA Mode 20190930 Kimura update ↓↓↓
                        return Properties.Settings.Default.PASSWORD_KASHIYAMA == false ? 
                               "発生年月日" : "総ｻｰﾎﾞｵﾝ時間";
                        //↑↑↑ KASHIYAMA Mode 20190930 Kimura update ↑↑↑

					case Culture.US:
						return "Date of generation";

					case Culture.CN:
						return "发生年月日";
				}
			}
		}

		/// <summary>
		/// 発生時分
		/// </summary>
		static public string AlarmHistory_Item_INF2
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
                        //↓↓↓ KASHIYAMA Mode 20190930 Kimura update ↓↓↓
                        return Properties.Settings.Default.PASSWORD_KASHIYAMA == false ? 
                               "発生時分" : "ﾄﾞﾗｲﾊﾞ電源ｵﾝﾄｰﾀﾙ時間";
                        //↑↑↑ KASHIYAMA Mode 20190930 Kimura update ↑↑↑

					case Culture.US:
						return "Generation second of season";

					case Culture.CN:
						return "发生时分";
				}
			}
		}

		/// <summary>
		/// ﾄﾞﾗｲﾊﾞ電源ONﾄｰﾀﾙ時間
		/// </summary>
		static public string AlarmHistory_Item_INF3
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
                        //↓↓↓ KASHIYAMA Mode 20190930 Kimura update ↓↓↓
                        return Properties.Settings.Default.PASSWORD_KASHIYAMA == false ?
                               "ﾄﾞﾗｲﾊﾞ電源ONﾄｰﾀﾙ時間" : "ｻｰﾎﾞ状態表示";
                        //↑↑↑ KASHIYAMA Mode 20190930 Kimura update ↑↑↑

					case Culture.US:
						return "Driver power supply ON total time";

					case Culture.CN:
						return "驱动线路电源ON总数时间";
				}
			}
		}

		/// <summary>
		/// ｻｰﾎﾞｽﾃｰﾀｽ
		/// </summary>
		static public string AlarmHistory_Item_INF4
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
                        //↓↓↓ KASHIYAMA Mode 20190930 Kimura update ↓↓↓
                        return Properties.Settings.Default.PASSWORD_KASHIYAMA == false ?
                              "ｻｰﾎﾞｽﾃｰﾀｽ" : "ﾌｨｰﾄﾞﾊﾞｯｸ電流";
                        //↑↑↑ KASHIYAMA Mode 20190930 Kimura update ↑↑↑

					case Culture.US:
						return "Servo Status";

					case Culture.CN:
						return "伺服状态";
				}
			}
		}

		/// <summary>
		/// ﾌｨｰﾄﾞﾊﾞｯｸ電流
		/// </summary>
		static public string AlarmHistory_Item_INF5
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
                        //↓↓↓ KASHIYAMA Mode 20190930 Kimura update ↓↓↓
                        return Properties.Settings.Default.PASSWORD_KASHIYAMA == false ?
                              "ﾌｨｰﾄﾞﾊﾞｯｸ電流" : "ﾌｨｰﾄﾞﾊﾞｯｸ速度";
                        //↑↑↑ KASHIYAMA Mode 20190930 Kimura update ↑↑↑

					case Culture.US:
						return "Actual Current";

					case Culture.CN:
						return "反馈电流";
				}
			}
		}

		/// <summary>
		/// ﾌｨｰﾄﾞﾊﾞｯｸ速度
		/// </summary>
		static public string AlarmHistory_Item_INF6
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
                        //↓↓↓ KASHIYAMA Mode 20190930 Kimura update ↓↓↓
                        return Properties.Settings.Default.PASSWORD_KASHIYAMA == false ?
                              "ﾌｨｰﾄﾞﾊﾞｯｸ速度" : "電流指令";
                        //↑↑↑ KASHIYAMA Mode 20190930 Kimura update ↑↑↑

					case Culture.US:
						return "Actual Velocity";

					case Culture.CN:
						return "反馈速度";
				}
			}
		}

		/// <summary>
		/// ﾌｨｰﾄﾞﾊﾞｯｸ位置
		/// </summary>
		static public string AlarmHistory_Item_INF7
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
                        //↓↓↓ KASHIYAMA Mode 20190930 Kimura update ↓↓↓
                        return Properties.Settings.Default.PASSWORD_KASHIYAMA == false ?
                              "ﾌｨｰﾄﾞﾊﾞｯｸ位置" : "(予約)";
                        //↑↑↑ KASHIYAMA Mode 20190930 Kimura update ↑↑↑

					case Culture.US:
						return "Actual Position";

					case Culture.CN:
                        return "反馈位置";
				}
			}
		}

		/// <summary>
		/// 駆動電源電圧
		/// </summary>
		static public string AlarmHistory_Item_INF8
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
                        //↓↓↓ KASHIYAMA Mode 20190930 Kimura update ↓↓↓
                        return Properties.Settings.Default.PASSWORD_KASHIYAMA == false ?
                              "駆動電源電圧" : "瞬時駆動電源電圧";
                        //↑↑↑ KASHIYAMA Mode 20190930 Kimura update ↑↑↑

					case Culture.US:
						return "Power Voltage";

					case Culture.CN:
						return "反馈位置";
				}
			}
		}

		/// <summary>
		/// ﾄﾞﾗｲﾊﾞ温度
		/// </summary>
		static public string AlarmHistory_Item_INF9
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "ﾄﾞﾗｲﾊﾞ温度";

					case Culture.US:
						return "Drive Temperature";

					case Culture.CN:
						return "驱动线路温度";
				}
			}
		}

		/// <summary>
		/// 過負荷ﾓﾆﾀ(実電流)
		/// </summary>
		static public string AlarmHistory_Item_INF10
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
                        //↓↓↓ KASHIYAMA Mode 20190930 Kimura update ↓↓↓
                        return Properties.Settings.Default.PASSWORD_KASHIYAMA == false ?
                              "過負荷ﾓﾆﾀ(実電流)" : "出力電力";
                        //↑↑↑ KASHIYAMA Mode 20190930 Kimura update ↑↑↑

					case Culture.US:
						return "Monitor Load Current";

					case Culture.CN:
						return "过载显示器(实在电流)";
				}
			}
		}

		/// <summary>
		/// 過負荷ﾓﾆﾀ(指令)
		/// </summary>
		static public string AlarmHistory_Item_INF11
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
                        return "過負荷ﾓﾆﾀ(指令)";

					case Culture.US:
						return "Monitor Load Command Current";

					case Culture.CN:
						return "过载显示器(指令)";
				}
			}
		}

		/// <summary>
		/// [分]
		/// </summary>
		static public string AlarmHistory_MSG_minutes
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "[分]";

					case Culture.US:
						return "[min]";

					case Culture.CN:
						return "[分]";
				}
			}
		}


		/// <summary>
		/// 最新のアラーム発生時の情報
		/// </summary>
		static public string AlarmHistory_MSG_latest
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "最新のアラーム発生時の情報";

					case Culture.US:
						return "It is information at the latest alarm generation.";

					case Culture.CN:
						return "是最新的警报发生时的信息";
				}
			}
		}


		/// <summary>
		/// 回前のアラーム発生時の情報
		/// </summary>
		static public string AlarmHistory_MSG_times
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "回前のアラーム発生時の情報";

					case Culture.US:
						return "time information when the alarm is generated.";

					case Culture.CN:
						return "次前的警报发生时的信息";
				}
			}
		}

		/// <summary>
		/// 現在、アラーム履歴はありません。
		/// </summary>
		static public string AlarmHistory_MSG_None
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "現在、アラーム履歴はありません。";

					case Culture.US:
						return "Now, It is not alarm history.";

					case Culture.CN:
						return "现在没有警报履历";
				}
			}
		}

		/// <summary>
		/// 過電流異常
		/// </summary>
		static public string AlarmHistory_OverCurrent
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
                       return "過電流異常";
                        
					case Culture.US:
						return "The overcurrent is abnormal";

					case Culture.CN:
						return "過電流異常";
				}
			}
		}

		/// <summary>
		/// 過負荷異常
		/// </summary>
		static public string AlarmHistory_Overload
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "過負荷異常";

					case Culture.US:
						return "The overload is abnormal";

					case Culture.CN:
						return "过载异常";
				}
			}
		}

		/// <summary>
		/// 過速度異常
		/// </summary>
		static public string AlarmHistory_Overspeed
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "過速度異常";

					case Culture.US:
						return "The overspeed is abnormal";

					case Culture.CN:
						return "过速度异常";
				}
			}
		}

		/// <summary>
		/// 多回転異常
		/// </summary>
		static public string AlarmHistory_multi
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "多回転異常";

					case Culture.US:
						return "The multi rotation is abnormal";

					case Culture.CN:
						return "多回转异常";
				}
			}
		}

		/// <summary>
		/// 位置偏差過大
		/// </summary>
		static public string AlarmHistory_Position
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "位置偏差過大";

					case Culture.US:
						return "Positional deflection is excessive";

					case Culture.CN:
						return "位置偏差过大";
				}
			}
		}

		/// <summary>
		/// ドライバ温度異常
		/// </summary>
		static public string AlarmHistory_temp
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "ドライバ温度異常";

					case Culture.US:
						return "The temperature of the driver is abnormal";

					case Culture.CN:
						return "驱动线路温度异常";
				}
			}
		}

		/// <summary>
		/// センサ異常
		/// </summary>
		static public string AlarmHistory_sensor
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "センサ異常";

					case Culture.US:
						return "The sensor is abnormal";

					case Culture.CN:
						return "传感器异常";
				}
			}
		}

		/// <summary>
		/// センサ断線
		/// </summary>
		static public string AlarmHistory_disconnect
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "センサ断線";

					case Culture.US:
						return "Sensor disconnection";

					case Culture.CN:
						return "传感器断线";
				}
			}
		}

		/// <summary>
		/// センサカウンタオーバーフロー異常
		/// </summary>
		static public string AlarmHistory_overflow
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "センサカウンタオーバーフロー異常";

					case Culture.US:
						return "The sensor counter overflow is abnormal";

					case Culture.CN:
						return "传感器计数器溢出异常";
				}
			}
		}

		/// <summary>
		/// センサ1回転カウンタ異常
		/// </summary>
		static public string AlarmHistory_one
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "センサ1回転カウンタ異常";

					case Culture.US:
						return "The counter is abnormal by the sensor one rotation";

					case Culture.CN:
						return "传感器1周计数器异常";
				}
			}
		}

		/// <summary>
		/// センサ過速度異常
		/// </summary>
		static public string AlarmHistory_sensorover
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "センサ過速度異常";

					case Culture.US:
						return "The overspeed of the sensor is abnormal";

					case Culture.CN:
						return "传感器过速度异常";
				}
			}
		}

		/// <summary>
		/// 駆動電圧過大異常
		/// </summary>
		static public string AlarmHistory_drivervoltage
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
                        return "駆動電圧過大異常";

					case Culture.US:
						return "Driving excessive voltage is abnormal";

					case Culture.CN:
						return "驱动电压过大异常";
				}
			}
		}

		/// <summary>
		/// 駆動電圧低下異常
		/// </summary>
		static public string AlarmHistory_drviervoldecrease
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "駆動電圧低下異常";

					case Culture.US:
						return "Driving voltage decrease is abnormal";

					case Culture.CN:
						return "驱动限制用电异常";
				}
			}
		}

		/// <summary>
		/// 回生異常
		/// </summary>
		static public string AlarmHistory_resurrexction
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "回生異常";

					case Culture.US:
						return "The resurrection is abnormal";

					case Culture.CN:
						return "回生异常";
				}
			}
		}

		/// <summary>
		/// 制御電源電圧低下異常
		/// </summary>
		static public string AlarmHistory_control
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "制御電源電圧低下異常";

					case Culture.US:
						return "The control power-supply voltage decrease is abnormal";

					case Culture.CN:
						return "控制电源电压降低异常";
				}
			}
		}

		/// <summary>
		/// 外部異常
		/// </summary>
		static public string AlarmHistory_external
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "外部異常";

					case Culture.US:
						return "The external is abnormal";

					case Culture.CN:
						return "外部异常";
				}
			}
		}

		/// <summary>
		/// 内部通信異常
		/// </summary>
		static public string AlarmHistory_Internal
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "内部通信異常";

					case Culture.US:
						return "Internal communication abnormality";

					case Culture.CN:
						return "内部通信异常";
				}
			}
		}

		/// <summary>
		/// 不揮発性メモリ読み込み異常
		/// </summary>
		static public string AlarmHistory_memoryread
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "不揮発性メモリ読み込み異常";

					case Culture.US:
						return "The nonvolatile memory reading is abnormal";

					case Culture.CN:
						return "包含非易失性存储器念异常";
				}
			}
		}

		/// <summary>
		/// 不揮発性メモリ書き込み異常
		/// </summary>
		static public string AlarmHistory_memorywrite
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "不揮発性メモリ書き込み異常";

					case Culture.US:
						return "The nonvolatile memory writing is abnormal";

					case Culture.CN:
						return "非易失性存储器写入异常";
				}
			}
		}

		/// <summary>
		/// ＣＰＵ異常
		/// </summary>
		static public string AlarmHistory_CPU
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "ＣＰＵ異常";

					case Culture.US:
						return "CPU is abnormal";

					case Culture.CN:
						return "CPU异常";
				}
			}
		}

		/// <summary>
		/// パラメータ異常
		/// </summary>
		static public string AlarmHistory_Parameter
		{
			get
			{
				switch (Culture.Name)
				{
					default:
					case Culture.JP:
						return "パラメータ異常";

					case Culture.US:
						return "The parameter is abnormal";

					case Culture.CN:
						return "参数异常";
				}
			}
		}

		#endregion

        // ↓↓↓ 20210324 Kimura add ↓↓↓

        #region イナーシャ単位

        /// <summary>
        /// [×10^-* kg・m2] 
        /// </summary>
        static public string InertiaUnit
        {
            get
            {
                switch (Culture.Name)
                {
                    default:
                    case Culture.JP:

                        switch (CMonitor.GetParameter(CParamID.InertiaManif))
                        {
                            default:
                            case 0:
                                return " [10⁻⁷ kg･m²] ";

                            case 1:
                                return " [10⁻⁶ kg･m²] ";

                            case 2:
                                return " [10⁻⁵ kg･m²] ";

                            case 3:
                                return " [10⁻⁴ kg･m²] ";
                        }                      

                    case Culture.US:

                        switch (CMonitor.GetParameter(CParamID.InertiaManif))
                        {
                            default:
                            case 0:
                                return " [10^-7 kg･m2] ";

                            case 1:
                                return " [10^-6 kg･m2] ";

                            case 2:
                                return " [10^-5 kg･m2] ";

                            case 3:
                                return " [10^-4 kg･m2] ";
                        }                      

                    case Culture.CN:

                        switch (CMonitor.GetParameter(CParamID.InertiaManif))
                        {
                            default:
                            case 0:
                                return " [10^-7 kg･m2] ";

                            case 1:
                                return " [10^-6 kg･m2] ";

                            case 2:
                                return " [10^-5 kg･m2] ";

                            case 3:
                                return " [10^-4 kg･m2] ";
                        }                      
                }
            
            }
        }

        // ↑↑↑ 20210324 Kimura add ↑↑↑

        #endregion
    }

	static public class UserMessageBox
    {
        #region CtlNumericInputEx

        /// <summary>
        /// "データを更新しますか？"
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        static public DialogResult CtlNumericInputExUpdataGainValue(string name, string value)
        {
			ChildFormControl.SetOpacity(0.0);

            DialogResult ret = DialogResult.Yes;

            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    ret = MessageBox.Show("データを更新しますか？" + "\n" +
                                          "[ " + name + " ]" + "\n" +
                                          "[ " + value + " ]",
                                          "サーボゲイン変更",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Exclamation);
                    break;

                case Culture.US:

                    ret = MessageBox.Show("Do  you update data?" + "\n" +
                                          "[ " + name + " ]" + "\n" +
                                          "[ " + value + " ]",
                                          "Servo gain change",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Exclamation);
                    break;

                case Culture.CN:

                    ret = MessageBox.Show("要更新数据吗？" + "\n" +
                                          "[ " + name + " ]" + "\n" +
                                          "[ " + value + " ]",
                                          "伺服增益变更",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Exclamation);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
			
			return ret;
        }

        #endregion

        #region Common

        /// <summary>
        /// "ERROR"
        /// ex.StackTrace,
        /// </summary>
        /// <param name="ex"></param>
        static public void CommonCatchErrorMessage(Exception ex)
        {
			ChildFormControl.SetOpacity(0.0);

            MessageBox.Show("ERROR" + "\n" + ex.StackTrace,
                            "ERROR",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);

			ChildFormControl.SetOpacity(1.0);
		}

        /// <summary>
        /// "フラッシュメモリにパラメータを保存してよろしいですか？"
        /// </summary>
        /// <returns></returns>
        static public DialogResult CommonSaveFlash()
        {
			ChildFormControl.SetOpacity(0.0);

            DialogResult ret = DialogResult.Yes;

            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    ret = MessageBox.Show("本体メモリにパラメータを保存してよろしいですか？",
                                          "本体メモリ保存",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;

                case Culture.US:

                    ret = MessageBox.Show("May I save parameter to Driver memory?",
                                          "Driver memory save",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;

                case Culture.CN:

                    ret = MessageBox.Show("可以在主机存储器保存参数吗？",
                                          "主机存储器保存",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
			
			return ret;
        }

        /// <summary>
        /// "ファイルの書式に誤りがあります。"
        /// </summary>
        static public void CommonFileFormatError()
        {
			ChildFormControl.SetOpacity(0.0);

            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    MessageBox.Show("ファイルの書式に誤りがあります。",
                                    "ファイル書式エラー",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    break;

                case Culture.US:

                    MessageBox.Show("File format has error.",
                                    "file format error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    break;

                case Culture.CN:

                    MessageBox.Show("文件的格式有错误。",
                                    "文件格式错误",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		}

        /// <summary>
        /// "USB ERROR"
        /// </summary>
        static public void CommonUsbError()
        {
			//ChildFormControl.SetOpacity(0.0);
			//MessageBox.Show("USB ERROR",
            //                "USB ERROR",
            //                MessageBoxButtons.OK,
            //                MessageBoxIcon.Error);
			//ChildFormControl.SetOpacity(1.0);
		}

		/// <summary>
		/// "サーボオフしますか？"
		/// </summary>
		/// <returns></returns>
		static public DialogResult CommonServoOff()
		{
			ChildFormControl.SetOpacity(0.0);

			DialogResult ret = DialogResult.Yes;

			switch (Culture.Name)
			{
				default:
				case Culture.JP:

					ret = MessageBox.Show("サーボオフしますか？",
										  "サーボオフ",
										  MessageBoxButtons.YesNo,
										  MessageBoxIcon.Information);
					break;

				case Culture.US:

					ret = MessageBox.Show("Do you turn Servo OFF?",
										  "Servo OFF",
										  MessageBoxButtons.YesNo,
										  MessageBoxIcon.Information);
					break;

				case Culture.CN:

					ret = MessageBox.Show("是否伺服OFF？",
										  "伺服OFF",
										  MessageBoxButtons.YesNo,
										  MessageBoxIcon.Information);
					break;
			}

			ChildFormControl.SetOpacity(1.0);
			
			return ret;
		}

        #endregion

        #region MainForm

        /// <summary>
        /// "アラームリセットしますか？"
        /// </summary>
        /// <returns></returns>
        static public DialogResult MainAlarmReset()
        {
			ChildFormControl.SetOpacity(0.0);
			
			DialogResult ret = DialogResult.Yes;

            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    ret = MessageBox.Show("アラームリセットしますか？",
                                          "アラームリセット",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;

                case Culture.US:

                    ret = MessageBox.Show("Do you reset alarm?",
                                          "Alarm reset",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;

                case Culture.CN:

                    ret = MessageBox.Show("重置警报吗？",
                                          "警报重置",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
			
			return ret;
        }

        /// <summary>
        /// "サーボオンしますか？"
        /// </summary>
        /// <returns></returns>
        static public DialogResult MainServoOn()
        {
			ChildFormControl.SetOpacity(0.0);
			
			DialogResult ret = DialogResult.Yes;

            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    ret = MessageBox.Show("サーボオンしますか？",
                                          "サーボオン",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;

                case Culture.US:

                    ret = MessageBox.Show("Do you turn Servo ON?",
                                          "Servo ON",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;

                case Culture.CN:

                    ret = MessageBox.Show("是否伺服ON？",
                                          "伺服ON",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
			
			return ret;
        }

        /// <summary>
        /// "サーボオフしますか？"
        /// </summary>
        /// <returns></returns>
        static public DialogResult MainServoOff()
        {
			ChildFormControl.SetOpacity(0.0);
			
			DialogResult ret = DialogResult.Yes;

            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    ret = MessageBox.Show("サーボオフしますか？",
                                          "サーボオフ",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;

                case Culture.US:

                    ret = MessageBox.Show("Do you turn servo OFF?",
                                          "Servo OFF",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;

                case Culture.CN:

                    ret = MessageBox.Show("是否伺服OFF？",
                                          "伺服OFF",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
			
			return ret;
        }

        /// <summary>
        /// "サーボオンしています！"
        /// "ファームウェアアップグレードを実行する場合は、"
        ///	"サーボオフしてから実行してください。"
        /// </summary>
        /// <returns></returns>
        static public void MainServoOnWarning()
        {
			ChildFormControl.SetOpacity(0.0);
			
			switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    MessageBox.Show("サーボオンしています！" + "\n" +
                                    "ファームウェアアップグレードを実行する場合は、" + "\n" +
                                    "サーボオフしてから実行してください。",
                                    "サーボオン実行中",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.US:

                    MessageBox.Show("Turing servo ON...!" + "\n" +
                                    "In case firmware is upgraded," + "\n" +
                                    "Please start after turning servo OFF.",
                                    "Servo ON...",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.CN:

                    MessageBox.Show("伺服ON状态中！" + "\n" +
                                    "进行固件升级时、" + "\n" +
                                    "请设定为伺服OFF后实施。",
                                    "伺服ON进行中",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);

        }

		/// <summary>
		/// "サーボオン状態です！"
		/// "サーボオフしてからDriveを終了しますか？"
		/// </summary>
		/// <returns></returns>
		static public DialogResult MainServoOnWarning2()
		{
			ChildFormControl.SetOpacity(0.0);

			DialogResult ret = DialogResult.Yes;

			switch (Culture.Name)
			{
				default:
				case Culture.JP:

					ret = MessageBox.Show("サーボオン状態です！" + "\n" +
										  "サーボオフしてからDriveを終了しますか？",
										  "サーボオフ",
										  MessageBoxButtons.YesNo,
										  MessageBoxIcon.Information);
					break;

				case Culture.US:

					ret = MessageBox.Show("Servo ON satus now...!" + "\n" +
										  "Do you close this software after turn servo OFF?",
										  "Servo OFF",
										  MessageBoxButtons.YesNo,
										  MessageBoxIcon.Information);
					break;
				case Culture.CN:

					ret = MessageBox.Show("是否伺服OFF？",
										  "伺服OFF",
										  MessageBoxButtons.YesNo,
										  MessageBoxIcon.Information);
					break;
			}

			ChildFormControl.SetOpacity(1.0);

			return ret;
		}

        #endregion

        #region ViewMainForm

        /// <summary>
        /// "Driveを終了しますか？"
        /// </summary>
        /// <returns></returns>
        static public DialogResult ViewMainDriveClose()
        {
			ChildFormControl.SetOpacity(0.0);
			
			DialogResult ret = DialogResult.Yes;

            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    ret = MessageBox.Show("Driveを終了しますか？",
                                          "Drive終了",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;

                case Culture.US:

                    ret = MessageBox.Show("Do you close software?",
                                          "Software closed",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;

                case Culture.CN:

                    ret = MessageBox.Show("是否要退出Drive？",
                                          "Drive退出",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);

            return ret;
        }

        #endregion

        #region JogControlForm

        /// <summary>
        /// "位置指令選択（ID74番）が通信による指令（値=0）以外です！" + "\n" +
        ///	"通信による指令に変更しますか？" + "\n" + "\n" +
        ///	"変更しない場合は本体への指令入力が適切であるか確認してから" + "\n" +
        ///	"制御モードを変更して下さい。" + "\n" +
        ///	"位置指令選択確認",
        /// </summary>
        /// <returns></returns>
        static public DialogResult JogControlPositionInputModeWarning()
        {
			ChildFormControl.SetOpacity(0.0);
			
			DialogResult ret = DialogResult.Yes;

            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    ret = MessageBox.Show("位置指令選択（ID74番）が通信による指令（値=0）以外です！" + "\n" +
                                          "通信による指令に変更しますか？" + "\n" + "\n" +
                                          "変更しない場合は本体への指令入力が適切であるか確認してから" + "\n" +
                                          "制御モードを変更して下さい。",
                                          "位置指令選択確認",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Exclamation);
                    break;

                case Culture.US:

                    ret = MessageBox.Show("Position command selection(ID74) is not set command by communication(value = 0)!" + "\n" +
                                          "Do you change the command by communication?" + "\n" + "\n" +
                                          "If you don't change, Please change control mode after checking command input" + "\n" +
                                          "to driver is correct.",
                                          "Position command selection check",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Exclamation);
                    break;

                case Culture.CN:

                    ret = MessageBox.Show("位置指令选择（ID74号）不由为通信的指令（值=0）！" + "\n" +
                                          "更改为由通信的指令吗？" + "\n" + "\n" +
                                          "不更改时，确认对于主机的指令输入是否妥当后" + "\n" +
                                          "请变更控制模式。",
                                          "位置指令选择确认",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Exclamation);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
			
			return ret;
        }

        /// <summary>
        /// "速度指令選択（ID75番）が通信による指令（値=0）以外です！" + "\n" +
        ///	"通信による指令に変更しますか？" + "\n" + "\n" +
        ///	"変更しない場合は本体への指令入力が適切であるか確認してから" + "\n" +
        ///	"制御モードを変更して下さい。" + "\n" +
        ///	"速度指令選択確認",
        /// </summary>
        /// <returns></returns>
        static public DialogResult JogControlVelocityInputModeWarning()
        {
			ChildFormControl.SetOpacity(0.0);
			
			DialogResult ret = DialogResult.Yes;

            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    ret = MessageBox.Show("速度指令選択（ID75番）が通信による指令（値=0）以外です！" + "\n" +
                                          "通信による指令に変更しますか？" + "\n" + "\n" +
                                          "変更しない場合は本体への指令入力が適切であるか確認してから" + "\n" +
                                          "制御モードを変更して下さい。",
                                          "速度指令選択確認",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Exclamation);
                    break;

                case Culture.US:

                    ret = MessageBox.Show("Speed command selection(ID75) is not set command by communication(value = 0)!" + "\n" +
                                          "Do you change the command by communication?" + "\n" + "\n" +
                                          "If you don't change, Please change control mode after checking command input" + "\n" +
                                          "to driver is correct.",
                                          "Speed command selection check",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Exclamation);
                    break;

                case Culture.CN:

                    ret = MessageBox.Show("速度指令选择（ID75号）不由为通信的指令（值=0）！" + "\n" +
                                          "更改为由通信的指令吗？" + "\n" + "\n" +
                                          "不更改时，确认对于主机的指令输入是否妥当后" + "\n" +
                                          "请变更控制模式。",
                                          "速度指令选择确认",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Exclamation);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
			
			return ret;
        }

        /// <summary>
        /// "電流指令選択（ID76番）が通信による指令（値=0）以外です！" + "\n" +
        ///	"通信による指令に変更しますか？" + "\n" + "\n" +
        ///	"変更しない場合は本体への指令入力が適切であるか確認してから" + "\n" +
        ///	"制御モードを変更して下さい。" + "\n" +
        ///	"電流指令選択確認",
        /// </summary>
        /// <returns></returns>
        static public DialogResult JogControlCurrentInputModeWarning()
        {
			ChildFormControl.SetOpacity(0.0);
			
			DialogResult ret = DialogResult.Yes;

            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    ret = MessageBox.Show("電流指令選択（ID76番）が通信による指令（値=0）以外です！" + "\n" +
                                          "通信による指令に変更しますか？" + "\n" + "\n" +
                                          "変更しない場合は本体への指令入力が適切であるか確認してから" + "\n" +
                                          "制御モードを変更して下さい。",
                                          "電流指令選択確認",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Exclamation);
                    break;

                case Culture.US:

                    ret = MessageBox.Show("Current command selection(ID76) is not set command by communication(value = 0)!" + "\n" +
                                          "Do you change the command by communication?" + "\n" + "\n" +
                                          "If you don't change, Please change control mode after checking command input" + "\n" +
                                          "to driver is correct.",
                                          "Current command selection check",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Exclamation);
                    break;

                case Culture.CN:

                    ret = MessageBox.Show("电流指令选择（ID76号）不由为通信的指令（值=0）！" + "\n" +
                                          "更改为通信的指令吗？" + "\n" + "\n" +
                                          "不更改时，确认对于主机的指令输入是否妥当后" + "\n" +
                                          "请变更控制模式。",
                                          "电流指令选择确认",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Exclamation);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);

            return ret;
        }

		/// <summary>
		/// "速度データに大きな変更がありました！" + "\n" +
		/// "変更してよろしいですか？" ,
		/// "速度データ設定値確認"</summary>
		/// <returns></returns>
		static public DialogResult JogControlVelocityInputValueWarning1(string txt)
		{
			ChildFormControl.SetOpacity(0.0);
			
			DialogResult ret = DialogResult.Yes;

			switch (Culture.Name)
			{
				default:
				case Culture.JP:

					ret = MessageBox.Show("速度データに大きな変更がありました！" + "\n" +
										  "変更してよろしいですか？" + "\n" +
										  txt,
										  "速度データ設定値確認",
										 MessageBoxButtons.YesNo,
										 MessageBoxIcon.Exclamation);
					break;

				case Culture.US:

					ret = MessageBox.Show("Speed data was excessively chagend!" + "\n" +
										  "Is it OK to change?",
										  "Speed data setting value check",
										 MessageBoxButtons.YesNo,
										 MessageBoxIcon.Exclamation);
					break;

				case Culture.CN:

					ret = MessageBox.Show("速度数据有很大的更改！" + "\n" +
										  "是否可以更改？",
										  "速度数据设定值确认",
										 MessageBoxButtons.YesNo,
										 MessageBoxIcon.Exclamation);
					break;
			}

			ChildFormControl.SetOpacity(1.0);
			
			return ret;
		}

		/// <summary>
		/// "本当によろしいですか？" ,
		/// "速度データ設定値確認"</summary>
		/// <returns></returns>
		static public DialogResult JogControlVelocityInputValueWarning2(string txt)
		{
			ChildFormControl.SetOpacity(0.0);
			
			DialogResult ret = DialogResult.Yes;

			switch (Culture.Name)
			{
				default:
				case Culture.JP:

					ret = MessageBox.Show("本当によろしいですか？" + "\n" +
										  txt,
										  "速度データ設定値確認",
										 MessageBoxButtons.YesNo,
										 MessageBoxIcon.Exclamation);
					break;

				case Culture.US:

					ret = MessageBox.Show("Are you sure?" + "\n" +
										  txt,
										  "Speed data setting value check",
										 MessageBoxButtons.YesNo,
										 MessageBoxIcon.Exclamation);
					break;

				case Culture.CN:

					ret = MessageBox.Show("真的可以吗？" + "\n" +
										  txt,
										  "速度数据设定值确认",
										 MessageBoxButtons.YesNo,
										 MessageBoxIcon.Exclamation);
					break;
			}

			ChildFormControl.SetOpacity(1.0);
			
			return ret;
		}

		/// <summary>
		/// "サーボオン状態です！" 
		/// "サーボオン中にポジションリセットは実行出来ません！" 
		/// "ポジションリセット確認"</summary>
		/// <returns></returns>
		static public DialogResult JogControlPositionResetWarning1()
		{
			ChildFormControl.SetOpacity(0.0);

			DialogResult ret = DialogResult.Yes;

			switch (Culture.Name)
			{
				default:
				case Culture.JP:

					ret = MessageBox.Show("サーボオン状態です！" + "\n" +
										  "サーボオン中にポジションリセットは実行出来ません！" ,
										  "ポジションリセット確認",
										 MessageBoxButtons.OK,
										 MessageBoxIcon.Exclamation);
					break;

				case Culture.US:

					ret = MessageBox.Show("Servo ON status now!" + "\n" +
										  "Position reset is not allowed during servo ON!",
										  "Position reset check",
										 MessageBoxButtons.OK,
										 MessageBoxIcon.Exclamation);
					break;

				case Culture.CN:

					ret = MessageBox.Show("伺服ON状态！" + "\n" +
										  "伺服ON中不能进行位置重置！",
										  "位置重置确认",
										 MessageBoxButtons.OK,
										 MessageBoxIcon.Exclamation);
					break;
			}

			ChildFormControl.SetOpacity(1.0);

			return ret;
		}

		/// <summary>
		/// "現在位置を0にリセットします。" 
		/// "本当によろしいですか？" 
		/// "ポジションリセット確認"</summary>
		/// <returns></returns>
		static public DialogResult JogControlPositionResetWarning2()
		{
			ChildFormControl.SetOpacity(0.0);

			DialogResult ret = DialogResult.Yes;

			switch (Culture.Name)
			{
				default:
				case Culture.JP:

					ret = MessageBox.Show("現在位置を0にリセットします。" + "\n" +
										  "本当によろしいですか？",
										  "ポジションリセット確認",
										 MessageBoxButtons.YesNo,
										 MessageBoxIcon.Exclamation);
					break;

				case Culture.US:

					ret = MessageBox.Show("Reset current position 0." + "\n" +
										  "Is it OK?",
										  "Position reset check",
										 MessageBoxButtons.YesNo,
										 MessageBoxIcon.Exclamation);
					break;

				case Culture.CN:

					ret = MessageBox.Show("现在位置重置为0。" + "\n" +
										  "真的可以吗？",
										  "位置重置确认",
										 MessageBoxButtons.YesNo,
										 MessageBoxIcon.Exclamation);
					break;
			}

			ChildFormControl.SetOpacity(1.0);

			return ret;
		}

		/// <summary>
		/// "サーボオン状態です！" 
		/// "サーボオン中にABSエンコーダリセットを実行出来ません！" 
		/// "ABSエンコーダリセット確認"</summary>
		/// <returns></returns>
		static public DialogResult JogControlAbsEncderResetWarning1()
		{
			ChildFormControl.SetOpacity(0.0);

			DialogResult ret = DialogResult.Yes;

			switch (Culture.Name)
			{
				default:
				case Culture.JP:

					ret = MessageBox.Show("サーボオン状態です！" + "\n" +
										  "サーボオン中にABSエンコーダリセットを実行出来ません！",
										  "ABSエンコーダリセット確認",
										 MessageBoxButtons.OK,
										 MessageBoxIcon.Exclamation);
					break;

				case Culture.US:

					ret = MessageBox.Show("Servo ON status now!" + "\n" +
										  "ABS encoder reset is not allowed during servo ON!",
										  "ABS encoder reset check",
										 MessageBoxButtons.OK,
										 MessageBoxIcon.Exclamation);
					break;


				case Culture.CN:

					ret = MessageBox.Show("伺服ON状态！" + "\n" +
										  "伺服ON中不能进行ABS编码器重置！",
										  "ABS编码器重置确认",
										 MessageBoxButtons.OK,
										 MessageBoxIcon.Exclamation);
					break;

			}

			ChildFormControl.SetOpacity(1.0);

			return ret;
		}

		/// <summary>
		/// "ABSエンコーダリセット（多回転情報リセット）を実行します。" 
		/// "本当によろしいですか？" 
		/// "ABSエンコーダリセット確認"</summary>
		/// <returns></returns>
		static public DialogResult JogControlAbsEncderResetWarning2()
		{
			ChildFormControl.SetOpacity(0.0);

			DialogResult ret = DialogResult.Yes;

			switch (Culture.Name)
			{
				default:
				case Culture.JP:

					ret = MessageBox.Show("ABSエンコーダリセット（多回転情報リセット）を実行します。" + "\n" +
										  "本当によろしいですか？",
										  "ABSエンコーダリセット確認",
										 MessageBoxButtons.YesNo,
										 MessageBoxIcon.Exclamation);
					break;

				case Culture.US:

					ret = MessageBox.Show("ABS encoder is reset(Multi turn reset)." + "\n" +
										  "Is it OK?",
										  "ABS encoder reset check",
										 MessageBoxButtons.YesNo,
										 MessageBoxIcon.Exclamation);
					break;

				case Culture.CN:

					ret = MessageBox.Show("进行ABS编码器重置（多旋转信息重置）。" + "\n" +
										  "真的可以吗？",
										  "ABS编码器重置确认",
										 MessageBoxButtons.YesNo,
										 MessageBoxIcon.Exclamation);
					break;
			}

			ChildFormControl.SetOpacity(1.0);

			return ret;
		}

		/// <summary>
		/// "サーボオン状態です！" 
		/// "サーボオン中にアナログ0点調整は実行出来ません！" 
		/// "アナログ0点調整確認"</summary>
		/// <returns></returns>
		static public DialogResult JogControlAnalogZeroAdjustWarning1()
		{
			ChildFormControl.SetOpacity(0.0);

			DialogResult ret = DialogResult.Yes;

			switch (Culture.Name)
			{
				default:
				case Culture.JP:

					ret = MessageBox.Show("サーボオン状態です！" + "\n" +
										  "サーボオン中にアナログ0点調整は実行出来ません！",
										  "アナログ0点調整確認",
										 MessageBoxButtons.OK,
										 MessageBoxIcon.Exclamation);
					break;

				case Culture.US:

					ret = MessageBox.Show("Servo ON status!" + "\n" +
										  "Analogue home tuning is not allowed during servo ON.",
										  "Analogue home position check",
										 MessageBoxButtons.OK,
										 MessageBoxIcon.Exclamation);
					break;


				case Culture.CN:

					ret = MessageBox.Show("伺服ON状态！" + "\n" +
										  "伺服ON中不能进行模拟信号的0点调整！",
										  "模拟信号0点调整确认",
										 MessageBoxButtons.OK,
										 MessageBoxIcon.Exclamation);
					break;

			}

			ChildFormControl.SetOpacity(1.0);

			return ret;
		}

		/// <summary>
		/// "アナログ0点調整を実行します。" ,
		/// "本当によろしいですか？" ,
		/// "アナログ0点調整確認"</summary>
		/// <returns></returns>
		static public DialogResult JogControlAnalogZeroAdjustWarning2()
		{
			ChildFormControl.SetOpacity(0.0);

			DialogResult ret = DialogResult.Yes;

			switch (Culture.Name)
			{
				default:
				case Culture.JP:

					ret = MessageBox.Show("アナログ0点調整を実行します。" + "\n" +
										  "本当によろしいですか？",
										  "アナログ0点調整確認",
										 MessageBoxButtons.YesNo,
										 MessageBoxIcon.Exclamation);
					break;

				case Culture.US:

					ret = MessageBox.Show("Analogue home tuning is done." + "\n" +
										  "Is it OK?",
										  "Analogue home tuning check",
										 MessageBoxButtons.YesNo,
										 MessageBoxIcon.Exclamation);
					break;

				case Culture.CN:

					ret = MessageBox.Show("进行模拟信号0点调整。" + "\n" +
										  "真的可以吗？",
										  "模拟信号0点调整确认",
										 MessageBoxButtons.YesNo,
										 MessageBoxIcon.Exclamation);
					break;
			}

			ChildFormControl.SetOpacity(1.0);

			return ret;
		}

        #endregion

        #region AutoTuningForm AutoTuningAdjust

        /// <summary>
        /// "オートチューニングが実行中です！"
        ///	"オートチューニングを中止しますか？"
        /// </summary>
        /// <returns></returns>
        static public DialogResult AutoTuningExecAutoTuning()
        {
			ChildFormControl.SetOpacity(0.0);
			
			DialogResult ret = DialogResult.Yes;

            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    ret = MessageBox.Show("オートチューニングが実行中です！" + "\n" +
                                          "オートチューニングを中止しますか？",
                                          "オートチューニング実行中",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Exclamation);
                    break;

                case Culture.US:

                    ret = MessageBox.Show("Operating auto tuning!" + "\n" +
                                          "Do you stop auto tuning?",
                                          "Operation auto tuning",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Exclamation);
                    break;

                case Culture.CN:

                    ret = MessageBox.Show("自动增益调谐进行中！" + "\n" +
                                          "终止自动增益调谐吗？",
                                          "自动增益调谐进行中",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Exclamation);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
			
			return ret;
        }

        /// <summary>
        /// "負荷イナーシャ推定中です。"
        /// "周波数スイープ実行中です。"
        /// "オートチューニング実行中です。"
        /// </summary>
        /// <param name="sq"></param>
        static public void AutoTuningExecOther(int sq)
        {
			ChildFormControl.SetOpacity(0.0);
			
			switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    switch (sq)
                    {
                        case 1:
                            MessageBox.Show("負荷イナーシャ推定中です。",
                                            "負荷イナーシャ推定中",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Exclamation);
                            break;

                        case 2:
                            MessageBox.Show("周波数スイープ実行中です。",
                                            "周波数スイープ実行中",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Exclamation);
                            break;

                        case 3:
                            MessageBox.Show("オートチューニング実行中です。",
                                            "オートチューニング実行中",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Exclamation);
                            break;

                        case 100:
                            MessageBox.Show("テスト運転実行中です。",
                                            "テスト運転実行中",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Exclamation);
                            break;
                    }

                    break;

                case Culture.US:

                    switch (sq)
                    {
                        case 1:
                            MessageBox.Show("Estimating load inertia...",
                                            "Estimating load inertia...",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Exclamation);
                            break;

                        case 2:
                            MessageBox.Show("Opearting frequency sweep...",
                                            "Opearting frequency sweep...",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Exclamation);
                            break;

                        case 3:
                            MessageBox.Show("Operating auto tuning...",
                                            "Operating auto tuning...",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Exclamation);
                            break;

                        case 100:
                            MessageBox.Show("Operating test movement...",
                                            "Operating test movement...",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Exclamation);
                            break;
                    }

                    break;

                case Culture.CN:

                    switch (sq)
                    {
                        case 1:
                            MessageBox.Show("负载惯量估计中。",
                                            "负载惯量估计中",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Exclamation);
                            break;

                        case 2:
                            MessageBox.Show("频率扫描进行中。",
                                            "频率扫描进行中",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Exclamation);
                            break;

                        case 3:
                            MessageBox.Show("自动增益调谐进行中。",
                                            "自动增益调谐进行中",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Exclamation);
                            break;

                        case 100:
                            MessageBox.Show("测试运行进行中。",
                                            "测试运行进行中",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Exclamation);
                            break;
                    }

                    break;
            }

			ChildFormControl.SetOpacity(1.0);

        }

		/// <summary>
		/// "軸動作中です。"
		/// </summary>
		/// <param name="sq"></param>
		static public void AutoTuningExecMoving()
		{
			ChildFormControl.SetOpacity(0.0);

			switch (Culture.Name)
			{
				default:
				case Culture.JP:

					MessageBox.Show("軸動作中です。",
									"軸動作中",
									MessageBoxButtons.OK,
									MessageBoxIcon.Exclamation);
					break;

				case Culture.US:

					MessageBox.Show("軸動作中です。",
									"軸動作中",
									MessageBoxButtons.OK,
									MessageBoxIcon.Exclamation);
					break;

				case Culture.CN:

					MessageBox.Show("軸動作中です。",
									"軸動作中",
									MessageBoxButtons.OK,
									MessageBoxIcon.Exclamation);
					break;
			}

			ChildFormControl.SetOpacity(1.0);

		}

        /// <summary>
        /// "verify write error"
        /// </summary>
        static public void AutoTuningVerifyWriteError()
        {
			ChildFormControl.SetOpacity(0.0);
			
			MessageBox.Show("Verify Write Error", "AutoTuning USB Error");
		
			ChildFormControl.SetOpacity(1.0);
		}

        /// <summary>
        /// "verify read error"
        /// </summary>
        static public void AutoTuningVerifyReadError()
        {
			ChildFormControl.SetOpacity(0.0);

			MessageBox.Show("Verify Read Error", "AutoTuning USB Error");

			ChildFormControl.SetOpacity(1.0);
		}

        /// <summary>
        /// "verify time lmit"
        /// </summary>
        static public void AutoTuningVerifyTimeLimit()
        {
			ChildFormControl.SetOpacity(0.0);

			MessageBox.Show("Autotuning Usb Timeout", "USB Timeout");
		
			ChildFormControl.SetOpacity(1.0);
		}

        /// <summary>
        /// "負荷イナーシャの推定を開始します。"
        ///	"モータが現在位置から2回転程度回転し、"
        ///	"往復動作を繰り返します。"
        ///	"機械の安全を確認してから実行してください。"
        /// </summary>
        /// <returns></returns>
        static public DialogResult AutoTuningCalcLoadInertia()
        {
			ChildFormControl.SetOpacity(0.0);
			
			DialogResult ret = DialogResult.OK;

            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    ret = MessageBox.Show("負荷イナーシャの推定を開始します。" + "\n" +
                                          "モータが現在位置から2回転程度回転し、" + "\n" +
                                          "往復動作を繰り返します。" + "\n" +
                                          "機械の安全を確認してから実行してください。",
                                          "負荷イナーシャ推定開始",
                                          MessageBoxButtons.OKCancel,
                                          MessageBoxIcon.Exclamation);
                    break;

                case Culture.US:

                    ret = MessageBox.Show("Load inertia estimation is started." + "\n" +
                                          "Motor start 2 rotations from current position and" + "\n" +
                                          "shuttle run is started." + "\n" +
                                          "Please start after checking safty of the machine.",
                                          "Load inertia estaimation start",
                                          MessageBoxButtons.OKCancel,
                                          MessageBoxIcon.Exclamation);
                    break;

                case Culture.CN:

                    ret = MessageBox.Show("开始估计负载惯量。" + "\n" +
                                          "马达从现在位置旋转2圈程度、" + "\n" +
                                          "反复往返动作。" + "\n" +
                                          "确认好机械的安全后实行。",
                                          "负载惯量估计开始",
                                          MessageBoxButtons.OKCancel,
                                          MessageBoxIcon.Exclamation);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);

            return ret;
        }

        /// <summary>
        /// "摩擦補正値の推定を開始します。"
        ///	"モータが現在位置から1回転程度回転し、"
        ///	"往復動作を繰り返します。"
        ///	"機械の安全を確認してから実行してください。"
        /// </summary>
        /// <returns></returns>
        static public DialogResult AutoTuningFrictionCompensation()
        {
			ChildFormControl.SetOpacity(0.0);
			
			DialogResult ret = DialogResult.OK;

            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    ret = MessageBox.Show("摩擦補正値の推定を開始します。" + "\n" +
                                          "モータが現在位置から1回転程度回転し、" + "\n" +
                                          "往復動作を繰り返します。" + "\n" +
                                          "機械の安全を確認してから実行してください。",
                                          "摩擦補正値推定開始",
                                          MessageBoxButtons.OKCancel,
                                          MessageBoxIcon.Exclamation);
                    break;

                case Culture.US:

                    ret = MessageBox.Show("Friction correnction estimation is started." + "\n" +
                                          "Motor start 1 rotation from current position and" + "\n" +
                                          "shuttle run is started." + "\n" +
                                          "Please start after checking safty of the machine.",
										  "Friction correnction estaimation start",
                                          MessageBoxButtons.OKCancel,
                                          MessageBoxIcon.Exclamation);
                    break;

                case Culture.CN:

                    ret = MessageBox.Show("开始摩擦补正值的估计。" + "\n" +
                                          "马达从现在位置旋转1圈程度、" + "\n" +
                                          "反复往返动作。" + "\n" +
                                          "请确认好机械安全后执行。",
										  "开始摩擦补正值的估计",
                                          MessageBoxButtons.OKCancel,
                                          MessageBoxIcon.Exclamation);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
			
			return ret;
        }

        /// <summary>
        /// "負荷イナーシャの推定に失敗しました。"
        /// </summary>
        static public void AutoTuningCalcLoadInertiaError()
		{
			ChildFormControl.SetOpacity(0.0);

			switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    MessageBox.Show("負荷イナーシャの推定に失敗しました。",
                                    "負荷イナーシャ推定エラー",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.US:

                    MessageBox.Show("Load inertia estiamtion was failed.",
                                    "Load inertia estimation error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.CN:

                    MessageBox.Show("负载惯量估计失败。",
                                    "负载惯量估计错误",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		
        }

        /// <summary>
        /// "オートチューニングを開始します。"
        ///	"モータが設定された目標位置まで移動し、"
        ///	"往復動作を繰り返します。"
        ///	"機械の安全を確認してから実行してください。"
        /// </summary>
        /// <returns></returns>
        static public DialogResult AutoTuningAdjustServoGain()
        {
			ChildFormControl.SetOpacity(0.0);
			
			DialogResult ret = DialogResult.OK;

            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    ret = MessageBox.Show("オートチューニングを開始します。" + "\n" +
                                          "モータが設定された目標位置まで移動し、" + "\n" +
                                          "往復動作を繰り返します。" + "\n" +
                                          "機械の安全を確認してから実行してください。",
                                          "オートチューニング開始",
                                          MessageBoxButtons.OKCancel,
                                          MessageBoxIcon.Exclamation);
                    break;

                case Culture.US:

                    ret = MessageBox.Show("Auto tuming is started" + "\n" +
                                          "Motor start moving to set target position, and" + "\n" +
                                          "shuttle run is started" + "\n" +
                                          "Please start after checking safty of the machine.",
                                          "Auto tuning start",
                                          MessageBoxButtons.OKCancel,
                                          MessageBoxIcon.Exclamation);
                    break;

                case Culture.CN:

                    ret = MessageBox.Show("开始自动增益调谐。" + "\n" +
                                          "马达移动到已设定的目标位置、" + "\n" +
                                          "反复往返动作。" + "\n" +
                                          "请确认好机械的安全后执行。",
                                          "自动增益调谐开始",
                                          MessageBoxButtons.OKCancel,
                                          MessageBoxIcon.Exclamation);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
			
			return ret;
        }

        /// <summary>
        /// "テスト運転を開始します。"
        ///	"モータが設定された目標位置まで移動し、"
        ///	"往復動作を繰り返します。"
        ///	"機械の安全を確認してから実行してください。"
        /// </summary>
        /// <returns></returns>
        static public DialogResult AutoTuningTestTuning()
        {
			ChildFormControl.SetOpacity(0.0);
			
			DialogResult ret = DialogResult.OK;

            switch (Culture.Name)
            {
                default:
                case Culture.JP:

					ret = MessageBox.Show("テスト運転を開始します。" + "\n" +
                                          "モータが設定された目標位置まで移動し、" + "\n" +
                                          "往復動作を繰り返します。" + "\n" +
                                          "機械の安全を確認してから実行してください。",
                                          "テスト運転開始",
                                          MessageBoxButtons.OKCancel,
                                          MessageBoxIcon.Exclamation);
                    break;

                case Culture.US:

                    ret = MessageBox.Show("Test movement is started." + "\n" +
                                          "otor start moving to set target position, and" + "\n" +
                                          "suttle run is started." + "\n" +
                                          "Please start after checking safty of the machine.",
                                          "Test movement start",
                                          MessageBoxButtons.OKCancel,
                                          MessageBoxIcon.Exclamation);
                    break;

                case Culture.CN:

                    ret = MessageBox.Show("开始测试运行。" + "\n" +
                                          "马达移动到已设定的目标位置、" + "\n" +
                                          "反复往返动作。" + "\n" +
                                          "请确认好机械的安全后执行。",
                                          "测试运行开始",
                                          MessageBoxButtons.OKCancel,
                                          MessageBoxIcon.Exclamation);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		
            return ret;
        }

        /// <summary>
        /// "オートチューニング設定ファイルの読み込みに失敗しました！"
        /// </summary>
        static public void AutoTuningConfigFileFormatError()
        {
			ChildFormControl.SetOpacity(0.0);
			
			switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    MessageBox.Show("オートチューニング設定ファイルの読み込みに失敗しました！",
                                    "オートチューニング設定ファイル読み込みエラー",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    break;

                case Culture.US:

                    MessageBox.Show("Auto tuning setting file reading is failed!",
                                    "Auto tuning setting file reading error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    break;

                case Culture.CN:

                    MessageBox.Show("自动增益调谐设定文件读取失败！",
                                    "自动增益调谐设定文件读取错误",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		
        }

        /// <summary>
        /// "オートチューニングが完了しました。"
        /// "ゲインデータを本体メモリに保存しますか？"
        /// </summary>
        /// <returns></returns>
        static public DialogResult AutoTuningSaveGain()
        {
			ChildFormControl.SetOpacity(0.0);
			
			DialogResult ret = DialogResult.Yes;

            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    ret = MessageBox.Show("オートチューニングが完了しました。" + "\n" +
                                          "ゲインデータを本体メモリに保存しますか？",
                                          "ゲインデータ保存",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;

                case Culture.US:

                    ret = MessageBox.Show("Auto tuning is completed." + "\n" +
                                          "Do you save gain data to Driver memory?",
                                          "Gain data save",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;

                case Culture.CN:

                    ret = MessageBox.Show("自动增益调谐结束。" + "\n" +
                                          "增益数据保存到主机存储器吗？",
                                          "增益数据保存",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		
            return ret;
        }

        /// <summary>
        /// "オートチューニングが完了しました。"
        /// "ゲイン調整の結果をファイルに保存しますか？"
        /// </summary>
        /// <returns></returns>
        static public DialogResult AutoTuningSaveResult()
        {
			ChildFormControl.SetOpacity(0.0);

			DialogResult ret = DialogResult.Yes;

            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    ret = MessageBox.Show("オートチューニングが完了しました。" + "\n" +
                                          "ゲイン調整の結果をファイルに保存しますか？",
                                          "オートチューニング調整結果保存",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;

                case Culture.US:

                    ret = MessageBox.Show("Auto tuning is completed." + "\n" +
                                          "Do you save the result of gain tuning to file?",
                                          "Auto tuning result save",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;

                case Culture.CN:

                    ret = MessageBox.Show("自动增益调谐结束。" + "\n" +
                                          "增益调整的结果保存到文件吗？",
                                          "自动增益调谐调整结果保存",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
			
			return ret;
        }

        /// <summary>
        /// "オートチューニングの結果は保存されませんが、"
        /// "よろしいですか？？"
        /// </summary>
        /// <returns></returns>
        static public DialogResult AutoTuningSaveCancel()
        {
			ChildFormControl.SetOpacity(0.0);
			
			DialogResult ret = DialogResult.Yes;

            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    ret = MessageBox.Show("オートチューニングの結果は保存されませんが、" + "\n" +
                                          "よろしいですか？",
                                          "保存設定キャンセル",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;

                case Culture.US:

                    ret = MessageBox.Show("Auto tuning result is not saved." + "\n" +
                                          "Is it OK?",
                                          "Save setting cancel",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;

                case Culture.CN:

                    ret = MessageBox.Show("不能保存自动增益调谐的结果、" + "\n" +
                                          "可以吗？",
                                          "保存设定取消",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
			
			return ret;
        }

        /// <summary>
        /// "サーボドライバがアラームを検出しました。"
        /// </summary>
        static public void AutoTuningAlarmDetect()
        {
			ChildFormControl.SetOpacity(0.0);
			
			switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    MessageBox.Show("サーボドライバがアラームを検出しました。",
                                    "アラーム発生中",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.US:

                    MessageBox.Show("Driver detected alarm.",
                                    "Detecting alarm.",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.CN:

                    MessageBox.Show("伺服驱动器检测出警报。",
                                    "警报发生中",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		
        }

        /// <summary>
        /// "サーボオフの状態です。"
        /// </summary>
        static public void AutoTuningServoOffInformation()
        {
			ChildFormControl.SetOpacity(0.0);
			
			switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    MessageBox.Show("サーボオフの状態です。",
                                    "サーボオフ中",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.US:

                    MessageBox.Show("Servo OFF status.",
                                    "Servo OFF status.",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.CN:

                    MessageBox.Show("伺服OFF的状态。",
                                    "伺服OFF中",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		
        }

        /// <summary>
        /// "入力されたデータが不正です！"
        /// </summary>
        static public void AutoTuningInputDataError()
        {
			ChildFormControl.SetOpacity(0.0);
			
			switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    MessageBox.Show("入力されたデータが不正です！",
                                    "データ入力エラー",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.US:

                    MessageBox.Show("Input data is incorrect!",
                                    "Data input error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.CN:

                    MessageBox.Show("输入的数据不正确！",
                                    "数据输入错误",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		
        }

		/// <summary>
		/// "負荷イナーシャの推定が完了しました。"
		/// "負荷イナーシャ推定値　：　"
		/// </summary>
		static public void AutoTuningLoadInertiaFinish(string txt)
		{
			ChildFormControl.SetOpacity(0.0);

			switch (Culture.Name)
			{
				default:
				case Culture.JP:

					MessageBox.Show("負荷イナーシャの推定が完了しました。" + "\n" +
                                    // ↓↓↓ 20210324 Kimura update ↓↓↓
                                    "負荷イナーシャ推定値　:　" + txt + UserText.InertiaUnit,
                                    //"負荷イナーシャ推定値　:　" + txt + " [g・cm2]",
                                    // ↑↑↑ 20210324 Kimura update ↑↑↑
                                    "負荷イナーシャ推定完了",
									MessageBoxButtons.OK,
									MessageBoxIcon.Information);
					break;

				case Culture.US:

					MessageBox.Show("Load iertia estimation is completed." + "\n" +
                                    // ↓↓↓ 20210324 Kimura update ↓↓↓
                                    "Load inertia estimation value : " + txt + UserText.InertiaUnit,
                                    //"Load inertia estimation value : " + txt + " [g・cm2]",
                                    // ↑↑↑ 20210324 Kimura update ↑↑↑
                                    "Load inertia estimation completed",
									MessageBoxButtons.OK,
									MessageBoxIcon.Information);
					break;

				case Culture.CN:

					MessageBox.Show("完成负载惯量的估计。" + "\n" +
                                    // ↓↓↓ 20210324 Kimura update ↓↓↓
                                    "负载惯量估计值　：　" + txt + UserText.InertiaUnit,
                                    //"负载惯量估计值　：　" + txt + " [g・cm2]",
                                    // ↑↑↑ 20210324 Kimura update ↑↑↑
                                    "完成负载惯量估计",
									MessageBoxButtons.OK,
									MessageBoxIcon.Information);
					break;
			}

			ChildFormControl.SetOpacity(1.0);

		}

		/// <summary>
		/// "周波数スイープが完了しました。"
		/// "周波数スイープ完了"
		/// </summary>
		static public void AutoTuningFrequencySweepFinish()
		{
			ChildFormControl.SetOpacity(0.0);

			switch (Culture.Name)
			{
				default:
				case Culture.JP:

					MessageBox.Show("周波数スイープが完了しました。",
									"周波数スイープ完了",
									MessageBoxButtons.OK,
									MessageBoxIcon.Information);
					break;

				case Culture.US:

					MessageBox.Show("Frequency sweep was completed.",
									"Prequency sweep completion",
									MessageBoxButtons.OK,
									MessageBoxIcon.Information);
					break;

				case Culture.CN:

					MessageBox.Show("已完成频率扫频。",
									"频率扫频完成",
									MessageBoxButtons.OK,
									MessageBoxIcon.Information);
					break;
			}

			ChildFormControl.SetOpacity(1.0);

		}

		/// <summary>
		/// "摩擦補正が完了しました。"
		/// "摩擦補正完了"
		/// </summary>
		static public void AutoTuningFrictionCompensationFinish(string cw_trq, string ccw_trq)
		{
			ChildFormControl.SetOpacity(0.0);

			switch (Culture.Name)
			{
				default:
				case Culture.JP:

					MessageBox.Show("摩擦補正が完了しました。" + "\n" +
									UserText.AutoTuningCwNowValue + "  " + cw_trq.ToString() + " [0.01A] " + "\n" +
									UserText.AutoTuningCcwNowValue + "  " + ccw_trq.ToString() + " [0.01A] ",
									"摩擦補正完了",
									MessageBoxButtons.OK,
									MessageBoxIcon.Information);
					break;

				case Culture.US:

					MessageBox.Show("Frinction correction was completion." + "\n" +
									UserText.AutoTuningCwNowValue + "  " + cw_trq.ToString() + " [0.01A] " + "\n" +
									UserText.AutoTuningCcwNowValue + "  " + ccw_trq.ToString() + " [0.01A] ",
									"Friction correction completed",
									MessageBoxButtons.OK,
									MessageBoxIcon.Information);
					break;

				case Culture.CN:

					MessageBox.Show("已完成摩擦补正。" + "\n" +
									UserText.AutoTuningCwNowValue + "  " + cw_trq.ToString() + " [0.01A] " + "\n" +
									UserText.AutoTuningCcwNowValue + "  " + ccw_trq.ToString() + " [0.01A] ",
									"摩擦补正完成",
									MessageBoxButtons.OK,
									MessageBoxIcon.Information);
					break;
			}

			ChildFormControl.SetOpacity(1.0);
		}

        #endregion

        #region WizardForm

        /// <summary>
        /// "ウィザードを中止しますか？"
        /// </summary>
        /// <returns></returns>
        static public DialogResult WizardClose()
        {
			ChildFormControl.SetOpacity(0.0);
			
			DialogResult ret = DialogResult.Yes;

            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    ret = MessageBox.Show("ウィザードを中止しますか？",
                                          "ウィザード中止",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;

                case Culture.US:

                    ret = MessageBox.Show("Do you cancel Wizard?",
                                        "Wizard cancel",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Information);
                    break;

                case Culture.CN:

                    ret = MessageBox.Show("是否终止向导？",
                                          "向导终止",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		
            return ret;
        }

        /// <summary>
        /// "オートチューニングの設定を確認します。"
        ///	"設定値はよろしいですか？"
        /// </summary>
        /// <returns></returns>
        static public DialogResult WizardVerityTuningSetting()
        {
			ChildFormControl.SetOpacity(0.0);
			
			DialogResult ret = DialogResult.Yes;

            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    ret = MessageBox.Show("オートチューニングの設定を確認します。" + "\n" +
                                          "設定値はよろしいですか？",
                                          "オートチューニング設定確認",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;

                case Culture.US:

                    ret = MessageBox.Show("Auto tuning setting is comfirmed." + "\n" +
                                          "Is setting vaule confirmed?",
                                          "Auto tuning setting confirmation",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;

                case Culture.CN:

                    ret = MessageBox.Show("确认自动增益调谐的设定。" + "\n" +
                                          "设定值可以吗？",
                                          "自动增益调谐设定的确认",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
			
			return ret;
        }

        /// <summary>
        /// "ウィザード画面を閉じますがよろしいですか？"
        ///	"負荷イナーシャの推定が完了したら、"
        ///	"ウィザードを再起動してください。"
        /// </summary>
        /// <returns></returns>
        static public DialogResult WizardRetryInformation()
        {
			ChildFormControl.SetOpacity(0.0);
			
			DialogResult ret = DialogResult.Yes;

            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    ret = MessageBox.Show("ウィザード画面を閉じますがよろしいですか？" + "\n" + "\n" +
                                          "負荷イナーシャの推定が完了したら、" + "\n" +
                                          "ウィザードを再起動してください。",
                                          "負荷イナーシャ推定確認",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;

                case Culture.US:

                    ret = MessageBox.Show("Is it OK to close wizard screen?" + "\n" + "\n" +
                                          "When load inertia estimation is completed," + "\n" +
                                          "Please restart wizard.",
                                          "Load inertia estimation check",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;

                case Culture.CN:

                    ret = MessageBox.Show("可以关闭向导画面吗？" + "\n" + "\n" +
                                          "结束负载惯量的估计后、" + "\n" +
                                          "请重新启动向导。",
                                          "负载惯量估计确认",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
			
			return ret;
        }

        /// <summary>
        /// "負荷イナーシャの設定が0です！"
        ///	"本当によろしいですか？。"
        /// </summary>
        /// <returns></returns>
        static public DialogResult WizardTuningLoadInertiaWarning()
        {
			ChildFormControl.SetOpacity(0.0);
			
			DialogResult ret = DialogResult.Yes;

            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    ret = MessageBox.Show("負荷イナーシャの設定が0です！" + "\n" +
                                          "本当によろしいですか？。",
                                          "負荷イナーシャ設定確認",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Exclamation);
                    break;

                case Culture.US:

                    ret = MessageBox.Show("Load inertia setting is 0." + "\n" +
                                          "Is is OK?",
                                          "Load inertia setting confirmation",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Exclamation);
                    break;

                case Culture.CN:

                    ret = MessageBox.Show("负载惯量的设定为0！" + "\n" +
                                          "真的可以吗？。",
                                          "负载惯量设定确认",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Exclamation);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
			
			return ret;
        }

        /// <summary>
        /// "目標速度の設定が不正です！"
        /// "目標速度の設定を見直してください。"
        /// </summary>
        static public void WizardTuningVelocityWarning()
        {
			ChildFormControl.SetOpacity(0.0);
			
			switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    MessageBox.Show("目標速度の設定が不正です！" + "\n" +
                                    "目標速度の設定を見直してください。",
                                    "目標速度設定不正",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.US:

                    MessageBox.Show("Target speed setting is incorrect!" + "\n" +
                                    "Please review target speed setting.",
                                    "Target speed setting incorrect.",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.CN:

                    MessageBox.Show("目标速度的设定不正确！" + "\n" +
                                    "请修改目标速度的设定。",
                                    "目标速度设定不正确",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		
        }

        /// <summary>
        /// "加速度の設定が不正です！"
        /// "加速度の設定を見直してください。"
        /// </summary>
        static public void WizardTuningAccelerationWarning()
        {
			ChildFormControl.SetOpacity(0.0);
		
            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    MessageBox.Show("加速度の設定が不正です！" + "\n" +
                                    "加速度の設定を見直してください。",
                                    "加速度設定不正",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.US:

                    MessageBox.Show("Acceleration setting is incorrect!" + "\n" +
                                    "Please review acceleration setting.",
                                    "Acceleration setting incorrect.",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.CN:

                    MessageBox.Show("加速度的设定不正确！" + "\n" +
                                    "请修改加速度的设定。",
                                    "加速度设定不正确",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		
        }

        /// <summary>
        /// "減速度の設定が不正です！"
        /// "減速度の設定を見直してください。"
        /// </summary>
        static public void WizardTuningDecelerationWarning()
        {
			ChildFormControl.SetOpacity(0.0);
			
			switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    MessageBox.Show("減速度の設定が不正です！" + "\n" +
                                    "減速度の設定を見直してください。",
                                    "減速度設定不正",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.US:

                    MessageBox.Show("Deceleration setting is incorrect!" + "\n" +
                                    "Please review deceleration setting.",
                                    "Deceleration setting incorrect.",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.CN:

                    MessageBox.Show("减速度的设定不正确！" + "\n" +
                                    "请修改减速度的设定。",
                                    "减速度设定不正确",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		
        }

        /// <summary>
        /// "移動距離の設定が不正です！"
        /// "開始位置と目標位置の設定を見直してください。"
        /// </summary>
        static public void WizardTuningPositionWarning()
        {
			ChildFormControl.SetOpacity(0.0);
			
			switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    MessageBox.Show("移動距離の設定が不正です！" + "\n" +
                                    "開始位置と目標位置の設定を見直してください。",
                                    "移動距離設定不正",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.US:

                    MessageBox.Show("Travel distance setting is incorrect!" + "\n" +
                                   "Please review start position and target position setting.",
                                    "Travel distance setting incorrect.",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.CN:

                    MessageBox.Show("移动距离的设定不正确！" + "\n" +
                                    "请修改开始位置和目标位置的设定。",
                                    "移动距离设定不正确",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		
        }

        /// <summary>
        /// "インポジション範囲の設定が不正です！"
        /// "インポジション範囲の設定を見直してください。"
        /// </summary>
        static public void WizardTuningInPositionWidthWarning()
        {
			ChildFormControl.SetOpacity(0.0);
			
			switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    MessageBox.Show("インポジション範囲の設定が不正です！" + "\n" +
                                    "インポジション範囲の設定を見直してください。",
                                    "インポジション範囲設定不正",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.US:

                    MessageBox.Show("In-position range setting is incorrect!" + "\n" +
                                    "Please review In-position range setting.",
                                    "In-position range setting incorrect.",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.CN:

                    MessageBox.Show("定位范围的设定不正确！" + "\n" +
                                    "请修改定位范围的设定。",
                                    "定位范围设定不正确",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		
        }

        #endregion

        #region TeachingForm

        /// <summary>
        /// "ティーチングを完了してもよろしいですか？"
        /// </summary>
        /// <returns></returns>
        static public DialogResult TeachingFinsh()
        {
			ChildFormControl.SetOpacity(0.0);
			
			DialogResult ret = DialogResult.Yes;

            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    ret = MessageBox.Show("ティーチングを完了してもよろしいですか？",
                                          "ティーチング完了",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;

                case Culture.US:

                    ret = MessageBox.Show("Is it OK to finish teaching?",
                                          "Teaching finish",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;

                case Culture.CN:

                    ret = MessageBox.Show("可以结束演示吗？",
                                          "演示结束",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		
            return ret;
		}

		#endregion

		#region ParameterForm

		/// <summary>
        /// "入力されたデータが不正です！"
        /// </summary>
        static public void ParameterInputDataError()
        {
			ChildFormControl.SetOpacity(0.0);
			
			switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    MessageBox.Show("入力されたデータが不正です！",
                                    "データ入力エラー",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.US:

                    MessageBox.Show("Input data is incorrect!",
                                    "Data input error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.CN:

                    MessageBox.Show("输入的数据不正确！",
                                    "数据输入错误",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		
        }

        /// <summary>
        /// "全てのパラメータを転送します。"
        /// "本当によろしいですか？"
        /// </summary>
        /// <returns></returns>
        static public DialogResult ParameterAllWrite()
        {
			ChildFormControl.SetOpacity(0.0);
			
			DialogResult ret = DialogResult.Yes;

            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    ret = MessageBox.Show("全てのパラメータを転送します。" + "\n" +
                                          "本当によろしいですか？",
                                          "全パラメータ書き込み",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;

                case Culture.US:

                    ret = MessageBox.Show("All parameter is written." + "\n" +
                                          "Is it OK?",
                                          "All parameter writing",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;

                case Culture.CN:

                    ret = MessageBox.Show("传输所有的参数。" + "\n" +
                                          "真的可以吗？",
                                          "所有参数写入",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		
            return ret;
        }

        // Ver1.32 add ↓↓↓
        /// <summary>
        /// "変更値が赤文字で表示されているパラメータを一括転送します。" 
        /// "※ただし、読込専用のパラメータに対しては転送しません。"
        /// "本当によろしいですか？"
        /// </summary>
        /// <returns></returns>
        static public DialogResult ParameterIncludeWrite()
        {
            ChildFormControl.SetOpacity(0.0);

            DialogResult ret = DialogResult.Yes;

            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    ret = MessageBox.Show("変更値が赤文字で表示されているパラメータを一括転送します。" + "\n" +
                                          "※ただし、読込専用のパラメータに対しては転送しません。" + "\n" +　"\n" +
                                          "本当によろしいですか？",
                                          "一括パラメータ書き込み",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;

                case Culture.US:

                    ret = MessageBox.Show("Batch transfer parameters whose changed values are displayed in red." + "\n" +
                                          "Is it OK?",
                                          "Batch parameter writing",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;

                case Culture.CN:

                    ret = MessageBox.Show("更改值的批量传输参数显示为红色。" + "\n" +
                                          "真的可以吗？",
                                          "批量参数写入",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Information);
                    break;
            }

            ChildFormControl.SetOpacity(1.0);

            return ret;
        }

        /// <summary>
        /// "現在、ドライバアラームが発生しています。"
        /// "アラーム時波形停止の指定がされている為、波形表示出来ません。"
        /// "アラームクリアを行うか、アラーム時波形停止の指定を解除してください。"
        /// </summary>
        static public void WaveAlarmAutoStop()
        {
            ChildFormControl.SetOpacity(0.0);

            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                     MessageBox.Show("現在、ドライバアラームが発生しています。" + "\n" +
                                     "アラーム時波形停止の指定がされている為、波形表示出来ません。" + "\n" +
                                     "アラームクリアを行うか、アラーム時波形停止の指定を解除してください。",
                                     "アラーム時波形停止",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Exclamation);
                    break;

                case Culture.US:

                    MessageBox.Show("A driver alarm is currently occurring." + "\n" +
                                    "Waveform cannot be displayed because waveform stop is specified at alarm." + "\n" +
                                    "Clear the alarm or cancel the waveform stop specification at alarm.",
                                    "Waveform stop on alarm",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.CN:

                    MessageBox.Show("当前正在发生驾驶员警报。" + "\n" +
                                    "无法显示波形，因为在报警时指定了波形停止。" + "\n" +
                                    "清除警报或取消警报时的波形停止指定。",
                                    "报警时波形停止",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;
            }

            ChildFormControl.SetOpacity(1.0);
        }

        // Ver1.32 add ↑↑↑

        /// <summary>
        /// "下記項目のデータが不正です！"
        /// "データ変更エラー"
        /// </summary>
        /// <param name="err_msg"></param>
        static public void ParameterAllWriteError(string err_msg)
        {
			ChildFormControl.SetOpacity(0.0);
			
			switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    MessageBox.Show("下記項目のデータが不正です！" + "\n" + "\n" + err_msg,
                                    "データ変更エラー",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.US:

                    MessageBox.Show("Following item's data is incorrect!" + "\n" + "\n" + err_msg,
                                    "Data change error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.CN:

                    MessageBox.Show("下述项目的数据不正确！" + "\n" + "\n" + err_msg,
                                    "数据更改错误",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		
        }

        /// <summary>
        /// "現在値と変更値の値は一致しています。"
        /// "現在値と変更値が一致しません。"
        /// </summary>
        /// <param name="match"></param>
        /// <param name="msg"></param>
        static public void ParameterMatch(bool match, string msg)
        {
			ChildFormControl.SetOpacity(0.0);
			
			switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    if (match)
                    {
                        MessageBox.Show("現在値と変更値の値は一致しています。",
                                        "データ差分比較",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("現在値と変更値が一致しません。" + "\n" + msg,
                                        "データ差分比較",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                    }

                    break;

                case Culture.US:

                    if (match)
                    {
                        MessageBox.Show("Corrent value and changed value are according.",
                                        "Data difference comparison",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Current value and changed value are not according." + "\n" + msg,
                                        "Data difference comparison",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                    }

                    break;

                case Culture.CN:

                    if (match)
                    {
                        MessageBox.Show("现在值和变更值一致。",
                                        "数据差异比较",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("现在值和变更值不一致。" + "\n" + msg,
                                        "数据差异比较",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                    }

                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		
        }

        /// <summary>
        /// "パラメータが読み込まれていません!"
        /// </summary>
        static public void ParameterNoRead()
        {
			ChildFormControl.SetOpacity(0.0);
			
			switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    MessageBox.Show("全てのパラメータが読み込まれていません!",
                                    "パラメータ読み込み未完了",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;

                case Culture.US:

                    MessageBox.Show("Parameter is not read in!",
                                   "Parameter read in incompletion",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;

                case Culture.CN:

                    MessageBox.Show("参数没有被写入!",
                                    "参数写入未完成",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		
        }

        #endregion

        #region SaveForm

        /// <summary>
        /// "フラッシュメモリへの保存が完了しました。"
        /// </summary>
        static public void SaveFlashMemoryFinish()
        {
			ChildFormControl.SetOpacity(0.0);
			
			switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    //保存完了
                    MessageBox.Show("本体メモリへの保存が完了しました。",
                                    "保存完了",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;

                case Culture.US:

                    MessageBox.Show("Saving to Driver memory was completed.",
                                    "Save completed",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;

                case Culture.CN:

                    MessageBox.Show("完成主机存储器上的保存。",
                                    "完成保存",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		
        }

        /// <summary>
        /// "画像データの保存が完了しました。"
        /// </summary>
        static public void SaveImageFinish()
        {
			ChildFormControl.SetOpacity(0.0);
			
			switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    //保存完了
                    MessageBox.Show("画像データの保存が完了しました。",
                                    "保存完了",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;

                case Culture.US:

                    MessageBox.Show("Saving Screen data was completed.",
                                    "Save completed",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;

                case Culture.CN:

                    MessageBox.Show("完成图像数据的保存。",
                                    "完成保存",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		
        }

        /// <summary>
        /// "摩擦補正推定が完了しました。"
        /// </summary>
        static public void SaveFrictionFinish()
        {
			ChildFormControl.SetOpacity(0.0);
			
			switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    //摩擦補正完了
                    MessageBox.Show("摩擦補正推定が完了しました。",
                                    "摩擦補正完了",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;

                case Culture.US:

                    MessageBox.Show("Friction correction was completed.",
                                    "Friction correction completed",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;

                case Culture.CN:

                    MessageBox.Show("完成摩擦补正估计。",
                                    "摩擦补正完成",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		
        }

        #endregion

        #region UpgradeForm

        /// <summary>
        /// "DFUデバイスが接続されました。
        /// "アップグレードを継続します。"
        /// </summary>
        static public DialogResult UpgradeExistDFU()
        {
			ChildFormControl.SetOpacity(0.0);
			
			DialogResult ret = DialogResult.OK;

            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    ret = MessageBox.Show("DFUデバイスが接続されました。" + "\n" +
                                          "アップグレードを継続します。",
                                          "DFUデバイス接続",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Information);
                    break;

                case Culture.US:


                    ret = MessageBox.Show("DFU devise was connected." + "\n" +
                                          "Keep upgrading.",
                                          "DFU device connection",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Information);
                    break;

                case Culture.CN:


                    ret = MessageBox.Show("连接DFU软元件。" + "\n" +
                                          "继续升级。",
                                          "DFU软元件连接",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Information);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		
            return ret;
        }

        //20220106 Ver1.31 add ↓ 
        /// <summary>
        /// "ファームウェアのアップグレードを開始します。" ,
        /// "本当によろしいですか？" ,
        /// "ファームウェアアップグレード"</summary>
        /// <returns></returns>
        static public DialogResult StartFWUpgrade()
        {
            ChildFormControl.SetOpacity(0.0);

            DialogResult ret = DialogResult.Yes;

            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    ret = MessageBox.Show("ファームウェアのアップグレードを開始します。" + "\n" +
                                          "本当によろしいですか？",
                                          "ファームウェアアップグレード",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Exclamation);
                    break;

                case Culture.US:

                    ret = MessageBox.Show("Start firmware upgrade?" + "\n" +
                                    　　　"Is it OK?",
                                           "Firmware Upgrade",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Exclamation);
                    break;

                case Culture.CN:

                    ret = MessageBox.Show("Start firmware upgrade?" + "\n" +
                                          "Is it OK?",
                                          "Firmware Upgrade",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Exclamation);
                    break;
            }

            ChildFormControl.SetOpacity(1.0);

            return ret;
        }
        //20220106 Ver1.31 add ↑ 

        /// <summary>
        /// "アップグレードがキャンセルされました！"
        /// "アップグレードを中止します。"
        /// </summary>
        static public void UpgradeCancelUpgrade()
        {
			ChildFormControl.SetOpacity(0.0);
			
			switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    MessageBox.Show("アップグレードがキャンセルされました！" + "\n" +
                                    "アップグレードを中止します。",
                                    "アップグレード中止",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;

                case Culture.US:

                    MessageBox.Show("Upgrade was cancelled!" + "\n" +
                                    "Upgrade is cancelled.",
                                    "Upgrade cancel",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;

                case Culture.CN:

                    MessageBox.Show("升级被取消！" + "\n" +
                                    "终止升级。",
                                    "升级终止",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		
        }

        /// <summary>
        /// "機器がサーボオンの状態です！"
        /// "サーボオフしてしてから"
        /// "再度アップグレードを実行してください。"
        /// </summary>
        static public void UpgradeRequestServoOff()
        {
			ChildFormControl.SetOpacity(0.0);
			
			switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    MessageBox.Show("機器がサーボオンの状態です！" + "\n" +
                                    "サーボオフしてしてから" + "\n" +
                                    "再度アップグレードを実行してください。",
                                    "サーボオフ確認",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.US:

                    MessageBox.Show("System is servo ON status!" + "\n" +
                                    "Please start upgrade" + "\n" +
                                    "after turn servo OFF.",
                                    "Servo OFF check",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.CN:

                    MessageBox.Show("机器为伺服ON的状态！" + "\n" +
                                    "伺服OFF后" + "\n" +
                                    "请再次进行升级。",
                                    "伺服OFF确认",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		
        }

        /// <summary>
        /// "機器がUSBポートに接続されています！"
        /// "Boot端子をショートし電源を再起動してから"
        /// "再度アップグレードを実行してください。"
        /// </summary>
        static public void UpgradeRequestBootMode()
        {
			ChildFormControl.SetOpacity(0.0);
			
			switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    MessageBox.Show("機器がUSBポートに接続されています！" + "\n" +
                                    "Boot端子をショートし電源を再起動してから" + "\n" +
                                    "再度アップグレードを実行してください。",
                                    "USB接続確認",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.US:

                    MessageBox.Show("System is connected to USB port!" + "\n" +
                                    "Please restart upgrade" + "\n" +
                                    "after getting boot terminal short.",
                                    "USB connection check",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.CN:

                    MessageBox.Show("机器连接到USB端口！" + "\n" +
                                   "短路Boot端子重新启动电源后" + "\n" +
                                    "请再次进行升级。",
                                    "USB连接确认",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		
        }

        /// <summary>
        /// "機器がUSBポートに接続されていません！"
        /// "USBケーブルを接続してから"
        /// "再度アップグレードを実行してください。"
        /// </summary>
        static public void UpgradeRequestUsbAttach()
        {
			ChildFormControl.SetOpacity(0.0);
			
			switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    MessageBox.Show("機器がUSBポートに接続されていません！" + "\n" +
                                    "USBケーブルを接続してから" + "\n" +
                                    "再度アップグレードを実行してください。",
                                    "USB接続確認",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.US:

                    MessageBox.Show("System is not connected to USB port!" + "\n" +
                                    "Please restart upgrade" + "\n" +
                                    "after USB cable is connected.",
                                    "USB connection check",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.CN:

                    MessageBox.Show("机器没有连接到USB端口！" + "\n" +
                                    "连接到USB电缆后" + "\n" +
                                    "请再次进行升级。",
                                    "USB连接确认",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		
        }

        /// <summary>
        /// "機器がUSBポートに接続されています！"
        /// "USBケーブルを取り外して、"
        /// "Boot端子をショートし電源を再起動してから"
        /// "再度アップグレードを実行してください。"
        /// </summary>
        static public void UpgradeRequestUsbDettach()
        {
			ChildFormControl.SetOpacity(0.0);
		
            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    MessageBox.Show("機器がUSBポートに接続されています！" + "\n" +
                                    "USBケーブルを取り外して、" + "\n" +
                                    "Boot端子をショートし電源を再起動してから" + "\n" +
                                    "再度アップグレードを実行してください。",
                                    "USB接続確認",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.US:

                    MessageBox.Show("System is connected to USB port!" + "\n" +
                                    "Please power ON again after disconnecting USB cable, and" + "\n" +
                                    "getting Boot terminal short." + "\n" +
                                    "Please restart upgrad.",
                                    "USB connection check",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.CN:

                    MessageBox.Show("机器连接到USB端口！" + "\n" +
                                    "拆卸USB电缆、" + "\n" +
                                    "短路Boot端子重新启动电源后" + "\n" +
                                    "再次进行升级。",
                                    "USB连接确认",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		
        }

        /// <summary>
        /// "アップグレードの注意事項"
        /// "以下を確認ください。"
        /// "・アップグレード中は"
        /// "　絶対に装置の電源を切断しないでください！"
        /// "　絶対にケーブルの脱着を行わないでください！"
        /// "　絶対にアプリケーションを終了させないでください！"
        /// "上記を確認しアップグレードを実行してください。"
        /// </summary>
        static public void UpgradeExecExclamation()
        {
			ChildFormControl.SetOpacity(0.0);
		
            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    MessageBox.Show("アップグレードの注意事項" + "\n" +
                                    "以下を確認ください。" + "\n" +
                                    "・アップグレード中は" + "\n" +
                                    "　絶対に装置の電源を切断しないでください！" + "\n" +
                                    "　絶対にケーブルの脱着を行わないでください！" + "\n" +
                                    "　絶対にアプリケーションを終了させないでください！" + "\n" +
                                    "上記を確認しアップグレードを実行してください。",
                                    "アップグレードの注意事項",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;

                case Culture.US:

                    MessageBox.Show("Attention for ungrade" + "\n" +
                                    "Please pay attention to following matters." + "\n" +
                                    "- During upgrade" + "\n" +
                                    "  Please don't power Driver OFF!" + "\n" +
                                    "  Please don't disconnect/reconnect cables!" + "\n" +
                                    "  Please don't close this software!" + "\n" +
                                    "Plesae upgrade, observing above matters.",
                                    "Attention for upgrade",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;

                case Culture.CN:

                    MessageBox.Show("升级注意事项" + "\n" +
                                    "请确认以下。" + "\n" +
                                    "・升级中" + "\n" +
                                    "　绝对不要切断装置的电源！" + "\n" +
                                    "　绝对不要插入拔出电缆！" + "\n" +
                                    "　绝对不要终止应用程序！" + "\n" +
                                    "确认上述内容后请进行升级。",
                                    "升级的注意事项",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		
        }

        /// <summary>
        /// "DFUオンラインアップグレードの注意事項"
        /// "以下を確認ください。"
        /// "・オンラインでアップグレードを実行しようとしています！"
        /// "　何らかの要因によりアップグレードに失敗した場合、"
        /// "　次回はBootモード（Bootピンをショート設定）で"
        /// "　アップグレードする必要があります。"
        /// "上記を確認しアップグレードを実行してください。"
        /// </summary>
        static public void UpgradeDFUExclamation()
        {
			ChildFormControl.SetOpacity(0.0);
		
            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    MessageBox.Show("DFUオンラインアップグレードの注意事項" + "\n" +
                                    "以下を確認ください。" + "\n" +
                                    "・オンラインでアップグレードを実行しようとしています！" + "\n" +
                                    "　何らかの要因によりアップグレードに失敗した場合、" + "\n" +
                                    "　次回はBootモード（Bootピンをショート設定）で" + "\n" +
                                    "　アップグレードする必要があります。" + "\n" +
                                    "上記を確認しアップグレードを実行してください。",
                                    "DFUアップグレードの注意事項",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;

                case Culture.US:

                    MessageBox.Show("Attention for DFU on-line upgrade" + "\n" +
                                    "Please pay attention to following matters." + "\n" +
                                    "- You are about to upgrade by on-line!" + "\n" +
                                    "  If you failed upgrade for some reason," + "\n" +
                                    "  Please upgrade by Boot Mode(Boot pin short setting)" + "\n" +
                                    "  next time" + "\n" +
                                    "Plesae upgrade, observing above matters.",
                                    "Attention for DFU upgrade",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;

                case Culture.CN:

                    MessageBox.Show("DFU在线升级的注意事项" + "\n" +
                                    "请确认下述内容。" + "\n" +
                                    "・想在线进行升级！" + "\n" +
                                    "　某些原因造成升级失败时、" + "\n" +
                                    "　下次以Boot模式（BootPIN的短路设定）" + "\n" +
                                    "　有必要进行升级。" + "\n" +
                                    "请确认上述内容进行升级。",
                                    "DFU升级的注意事项",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		
        }

        /// <summary>
        /// "ファームウェアのアップグレードに成功しました。"
        /// </summary>
        static public void UpgradeSuccessful()
        {
			ChildFormControl.SetOpacity(0.0);
			
			switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    MessageBox.Show("ファームウェアのアップグレードに成功しました。",
                                    "アップグレード成功",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;

                case Culture.US:

                    MessageBox.Show("Firmware upgrade was successfully completed.",
                                    "Upgrade completed",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;

                case Culture.CN:

                    MessageBox.Show("固件升级成功。",
                                    "升级成功",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		
        }

        /// <summary>
        /// "ファームウェアのアップグレードに失敗しました！！！"
        /// </summary>
        static public void UpgradeFailed()
        {
			ChildFormControl.SetOpacity(0.0);
			
			switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    MessageBox.Show("ファームウェアのアップグレードに失敗しました！！！",
                                    "アップグレード失敗",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.US:

                    MessageBox.Show("Firmware upgrade was failed!!!",
                                    "Upgrade failed",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.CN:

                    MessageBox.Show("固件升级失败！！！",
                                    "升级失败",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		
        }

        /// <summary>
        /// "機器がDFUデバイスとして認識されていません！"
        /// "以下を確認ください。"
        /// "・USBケーブルが接続されているか？"
        /// "・本体に電源が入っているか？"
        /// "・HUB等を経由して接続されていないか？"
        /// "・Bootモード設定でBoot端子がショートされているか？"
        /// "上記を確認し電源を再投入し再試行してください。"
        /// </summary>
        static public void UpgradeDisableDFUDevice()
        {
			ChildFormControl.SetOpacity(0.0);
			
			switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    MessageBox.Show("機器がDFUデバイスとして認識されていません！" + "\n" +
                                    "以下を確認ください。" + "\n" +
                                    "・USBケーブルが接続されているか？" + "\n" +
                                    "・本体に電源が入っているか？" + "\n" +
                                    "・HUB等を経由して接続されていないか？" + "\n" +
                                    "・Bootモード設定でBoot端子がショートされているか？" + "\n" +
                                    "上記を確認し電源を再投入し再試行してください。",
                                    "DFUデバイス接続不良",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.US:

                    MessageBox.Show("Driver is not acknowledged as DFU device!" + "\n" +
                                    "Please check folloiwng matters." + "\n" +
                                    "- Is USB canble connected?" + "\n" +
                                    "- Does Driver power ON?" + "\n" +
                                    "- Isn't it connected throught HUB etc?" + "\n" +
                                    "- Is Boot pin made short in Boot mode?" + "\n" +
                                    "After checking above, please power on again.",
                                    "DFU device connection failure",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.CN:

                    MessageBox.Show("机器没有作为DFU软元件被识别！" + "\n" +
                                    "请确认下述内容。" + "\n" +
                                    "・USB电缆是否连接？" + "\n" +
                                    "・主机是否接通电源？" + "\n" +
                                    "・是否经由HUB等连接？" + "\n" +
                                    "・以Boot模式设定是否Boot端子被短路？" + "\n" +
                                    "请确认上述内容后再次接通电源并重新试运行。",
                                    "DFU软元件连接不良",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		
        }

        /// <summary>
        /// "Bootモードへ遷移しました。"
        /// "この画面を閉じてから、"
        /// "USBケーブルを取り外してください"
        /// </summary>
        static public DialogResult UpgradeRequestCableDettach()
        {
			ChildFormControl.SetOpacity(0.0);
			
			DialogResult ret = DialogResult.OK;

            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    ret = MessageBox.Show("Bootモードへ遷移しました。" + "\n" +
                                          "この画面を閉じてから、" + "\n" +
                                          "USBケーブルを取り外してしてください。",
                                          "USBケーブル切断要求",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Information);
                    break;

                case Culture.US:

                    ret = MessageBox.Show("Transition to Boot mode." + "\n" +
                                          "After closing this screen," + "\n" +
                                          "Please disconnect USB cable.",
                                          "USB cable disconnect request",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Information);
                    break;

                case Culture.CN:

                    ret = MessageBox.Show("转化到Boot模式。" + "\n" +
                                          "关闭此画面后、" + "\n" +
                                          "请拆卸USB电缆。",
                                          "USB电缆切断要求",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Information);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		
            return ret;
        }

        /// <summary>
        /// "Bootモードへ遷移しました。"
        /// "この画面を閉じてから、"
        /// "USBケーブルを再接続してください"
        /// </summary>
        static public DialogResult UpgradeRequestDFUAttach()
        {
			ChildFormControl.SetOpacity(0.0);
			
			DialogResult ret = DialogResult.OK;

            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    ret = MessageBox.Show("Bootモードへ遷移しました。" + "\n" +
                                          "この画面を閉じてから、" + "\n" +
                                          "USBケーブルを再接続してください。",
                                          "USBケーブル接続要求",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Information);
                    break;

                case Culture.US:

                    ret = MessageBox.Show("Transit to Boot mode." + "\n" +
                                          "After closing this screen," + "\n" +
                                          "Please reconnect USB cable.",
                                          "USB cable connection request",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Information);
                    break;

                case Culture.CN:

                    ret = MessageBox.Show("转化到Boot模式。" + "\n" +
                                          "关闭此画面后、" + "\n" +
                                          "请再次连接USB电缆。",
                                          "USB电缆连接要求",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Information);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		
            return ret;
        }

        /// <summary>
        /// "Bootモードへの状態遷移に失敗しました。"
        /// "もう一度電源を入れ直してから、"
        /// "アップグレードを実行してください。"
        /// </summary>
        static public DialogResult UpgradeBootModeFailed()
        {
			ChildFormControl.SetOpacity(0.0);
			
			DialogResult ret = DialogResult.OK;

            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    ret = MessageBox.Show("Bootモードへの状態遷移に失敗しました。" + "\n" +
                                          "もう一度電源を入れ直してから、" + "\n" +
                                          "アップグレードを実行してください。",
                                          "Bootモード遷移失敗",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Exclamation);
                    break;

                case Culture.US:

                    ret = MessageBox.Show("Transition to Boot mode was failed" + "\n" +
                                          "after power ON again," + "\n" +
                                          "plesse start upgrade",
                                          "Boot mode transition failed",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Exclamation);
                    break;

                case Culture.CN:

                    ret = MessageBox.Show("Boot模式状态转化失败。" + "\n" +
                                          "再次接通电源后、" + "\n" +
                                          "进行升级。",
                                          "Boot模式转化失败",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Exclamation);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
			
			return ret;
        }

        /// <summary>
        /// "USBデバイスが所定の時間内（10秒）に、"
        /// "切断されませんでした。"
        /// "もう一度電源を入れ直してから、"
        /// "アップグレードを実行してください。"
        /// </summary>
        static public DialogResult UpgradeUsbDettachTimeLimit()
        {
			ChildFormControl.SetOpacity(0.0);
			
			DialogResult ret = DialogResult.OK;

            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    ret = MessageBox.Show("USBデバイスが所定の時間内（10秒）に、" + "\n" +
                                          "切断されませんでした。" + "\n" +
                                          "もう一度電源を入れ直してから、" + "\n" +
                                          "アップグレードを実行してください。",
                                          "DFUデバイス接続タイムアウト",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Exclamation);
                    break;

                case Culture.US:

                    ret = MessageBox.Show("USB device was not shut down " + "\n" +
                                          "within predetermined time(10 sec)" + "\n" +
                                          "Please power ON again, and" + "\n" +
                                          "start upgrade",
                                          "DFU device connection time-out",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Exclamation);
                    break;

                case Culture.CN:

                    ret = MessageBox.Show("USB软元件在规定的时间内（10秒）、" + "\n" +
                                          "没有被切断。" + "\n" +
                                          "再次接通电源后、" + "\n" +
                                          "进行升级。",
                                          "DFU软元件连接超时",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Exclamation);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
			
			return ret;
        }

        /// <summary>
        /// "DFUデバイスが所定の時間内（10秒）に、"
        /// "接続されませんでした。"
        /// "もう一度電源を入れ直してから、"
        /// "アップグレードを実行してください。"
        /// </summary>
        static public DialogResult UpgradeDfuAttachTimeLimit()
        {
			ChildFormControl.SetOpacity(0.0);
			
			DialogResult ret = DialogResult.OK;

            switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    ret = MessageBox.Show("DFUデバイスが所定の時間内（10秒）に、" + "\n" +
                                          "接続されませんでした。" + "\n" +
                                          "もう一度電源を入れ直してから、" + "\n" +
                                          "アップグレードを実行してください。",
                                          "DFUデバイス接続タイムアウト",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Exclamation);
                    break;

                case Culture.US:

                    ret = MessageBox.Show("USB device was not shut down" + "\n" +
                                          "within predetermined time(10 sec)" + "\n" +
                                          "Please power ON again" + "\n" +
                                          "Start upgrade",
                                          "DFU device connection time-out",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Exclamation);
                    break;

                case Culture.CN:

                    ret = MessageBox.Show("DFU软元件在规定时间内（10秒）、" + "\n" +
                                          "没有被连接。" + "\n" +
                                          "再次接通电源后、" + "\n" +
                                          "进行升级。",
                                          "DFU软元件连接超时",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Exclamation);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
			
			return ret;
        }

        #endregion

        #region OptionSettingForm

        /// <summary>
        /// "パスワード解除成功"
        /// </summary>
        static public void OptionPasswordReleaseSuccess()
        {
			ChildFormControl.SetOpacity(0.0);
			
			switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    MessageBox.Show("パスワード解除成功",
                                    "パスワード解除成功",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;

                case Culture.US:

                    MessageBox.Show("Password unlock succeeded",
                                    "Password unlock succeeded",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;

                case Culture.CN:

                    MessageBox.Show("密码解除成功",
                                    "密码解除成功",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		
        }

        /// <summary>
        /// "パスワード解除失敗"
        /// </summary>
        static public void OptionPasswordReleaseFailure()
        {
			ChildFormControl.SetOpacity(0.0);
			
			switch (Culture.Name)
            {
                default:
                case Culture.JP:

                    MessageBox.Show("パスワード解除失敗",
                                    "パスワード解除失敗",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.US:

                    MessageBox.Show("Password unlock failed",
                                    "Password unlock failed",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;

                case Culture.CN:

                    MessageBox.Show("密码解除失败",
                                    "密码解除失败",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    break;
            }

			ChildFormControl.SetOpacity(1.0);
		
        }

		/// <summary>
		/// "Driveの設定を初期化します。" ,
		/// "本当によろしいですか？" ,
		/// "Driveパラメータ初期化"</summary>
		/// <returns></returns>
		static public DialogResult OptionParameterInit()
		{
			ChildFormControl.SetOpacity(0.0);

			DialogResult ret = DialogResult.Yes;

			switch (Culture.Name)
			{
				default:
				case Culture.JP:

					ret = MessageBox.Show("Driveの設定を初期化します。" + "\n" +
										  "本当によろしいですか？",
										  "Driveパラメータ初期化",
										 MessageBoxButtons.YesNo,
										 MessageBoxIcon.Exclamation);
					break;

				case Culture.US:

					ret = MessageBox.Show("Is it OK?",
										  "Drive Parameter init",
										 MessageBoxButtons.YesNo,
										 MessageBoxIcon.Exclamation);
					break;

				case Culture.CN:

					ret = MessageBox.Show("真的可以吗？",
										  "Drive设定初始化",
										 MessageBoxButtons.YesNo,
										 MessageBoxIcon.Exclamation);
					break;
			}

			ChildFormControl.SetOpacity(1.0);

			return ret;
		}

        #endregion

		#region 簡易コントロール

		/// <summary>
		/// 入力されたデータが不正です。
		/// </summary>
		static public void SimpleControlInvalidInputError()
		{
			ChildFormControl.SetOpacity(0.0);

			switch (Culture.Name)
			{
				default:
				case Culture.JP:

					MessageBox.Show("入力されたデータが不正です。",
									"データ入力エラー",
									MessageBoxButtons.OK,
									MessageBoxIcon.Warning);
					break;

				case Culture.US:

					MessageBox.Show("Input data is incorrect",
									"Data input error",
									MessageBoxButtons.OK,
									MessageBoxIcon.Information);
					break;

				case Culture.CN:

					MessageBox.Show("输入的数据不正确",
									"数据输入错误",
									MessageBoxButtons.OK,
									MessageBoxIcon.Information);
					break;
			}

			ChildFormControl.SetOpacity(1.0);

		}

		#endregion

		#region ProfileMovementTableForm

		/// <summary>
		/// "ドライバからアップロードして、移動命令テーブルの一覧を作成します。" ,
		/// "よろしいですか？" ,
		/// </summary>
		/// <returns></returns>
		static public DialogResult ProfileMovementUpdaloadTableMaked()
		{
			ChildFormControl.SetOpacity(0.0);

			DialogResult ret = DialogResult.Yes;

			switch (Culture.Name)
			{
				default:
				case Culture.JP:

					ret = MessageBox.Show("ドライバからアップロードして、" + "\n" +
										  "移動命令テーブルの一覧を作成します。" + "\n" + "\n" +
										  "よろしいですか？",
										  "移動命令テーブル作成",
										  MessageBoxButtons.YesNo,
										  MessageBoxIcon.Question);
					break;

				case Culture.US:

					ret = MessageBox.Show("Upload from the driver and create a list of movement command tables." + "\n" + "\n" +
										  "Is it OK?",
										  "Move Command table creation",
										  MessageBoxButtons.YesNo,
										  MessageBoxIcon.Question);
					break;

				case Culture.CN:

					ret = MessageBox.Show("ドライバからアップロードして、" + "\n" +
										 "移動命令テーブルの一覧を作成します。" + "\n" + "\n" +
										 "よろしいですか？",
										 "移動命令テーブル作成",
										 MessageBoxButtons.YesNo,
										 MessageBoxIcon.Question);
					break;
			}

			ChildFormControl.SetOpacity(1.0);

			return ret;
		}

		/// <summary>
		/// 移動命令テーブル一覧の作成が完了しました。
		/// </summary>
		static public void ProfileMovementReadcompleted()
		{
			//ChildFormControl.SetOpacity(0.0);

			switch (Culture.Name)
			{
				default:
				case Culture.JP:

					MessageBox.Show("移動命令テーブル一覧の作成が完了しました。",
									"移動命令テーブル",
									MessageBoxButtons.OK,
									MessageBoxIcon.Information);
					break;

				case Culture.US:

					MessageBox.Show("Creation of the move Command table list is completed.",
									"Move Command Table",
									MessageBoxButtons.OK,
									MessageBoxIcon.Information);

					break;

				case Culture.CN:

					MessageBox.Show("移動命令テーブル一覧の作成が完了しました。",
									"移動命令テーブル",
									MessageBoxButtons.OK,
									MessageBoxIcon.Information);
					break;
			}

			//ChildFormControl.SetOpacity(1.0);
		}

		/// <summary>
		/// 移動命令テーブル一覧の読込みに失敗しました。
		/// </summary>
		static public void ProfileMovementReadFailed()
		{
			ChildFormControl.SetOpacity(0.0);

			switch (Culture.Name)
			{
				default:
				case Culture.JP:

					MessageBox.Show("移動命令テーブル一覧の読込みに失敗しました。",
									"移動命令テーブル読込",
									MessageBoxButtons.OK,
									MessageBoxIcon.Warning);
					break;

				case Culture.US:

					MessageBox.Show("Failed to read the move instruction table list.",
									"Move Command Table READ",
									MessageBoxButtons.OK,
									MessageBoxIcon.Warning);
					break;

				case Culture.CN:

					MessageBox.Show("移動命令テーブル一覧の読込みに失敗しました。",
									"移動命令テーブル読込",
									MessageBoxButtons.OK,
									MessageBoxIcon.Warning);
					break;
			}

			ChildFormControl.SetOpacity(1.0);
		}

		/// <summary>
		/// 移動命令テーブル一覧の書込みに失敗しました。。
		/// </summary>
		static public void ProfileMovementWriteFailed()
		{
			ChildFormControl.SetOpacity(0.0);

			switch (Culture.Name)
			{
				default:
				case Culture.JP:

					MessageBox.Show("移動命令テーブル一覧の書込みに失敗しました。",
									"移動命令テーブル書込",
									MessageBoxButtons.OK,
									MessageBoxIcon.Warning);
					break;

				case Culture.US:

					MessageBox.Show("Failed to write the move instruction table list.",
									"Move Command Table WRITE",
									MessageBoxButtons.OK,
									MessageBoxIcon.Warning);
					break;

				case Culture.CN:

					MessageBox.Show("移動命令テーブル一覧の書込みに失敗しました。",
									"移動命令テーブル書込",
									MessageBoxButtons.OK,
									MessageBoxIcon.Warning);
					break;
			}

			ChildFormControl.SetOpacity(1.0);
		}

		/// <summary>
		/// 簡易プログラム内に位置命令が設定されていません。
		/// </summary>
		static public void ProfileMovementNoCommand()
		{
			ChildFormControl.SetOpacity(0.0);

			switch (Culture.Name)
			{
				default:
				case Culture.JP:

					MessageBox.Show("簡易プログラム内に位置命令が設定されていません。",
									"移動命令テーブル読込",
									MessageBoxButtons.OK,
									MessageBoxIcon.Warning);
					break;

				case Culture.US:

					MessageBox.Show("Position Command is not set in the simple program.",
									"Move Command Table READ",
									MessageBoxButtons.OK,
									MessageBoxIcon.Warning);
					break;

				case Culture.CN:

					MessageBox.Show("簡易プログラム内に位置命令が設定されていません",
									"移動命令テーブル読込",
									MessageBoxButtons.OK,
									MessageBoxIcon.Warning);
					break;
			}

			ChildFormControl.SetOpacity(1.0);
		}

		/// <summary>
		/// 入力された値が無効です。
		/// </summary>
		static public void ProfileMovementinputInputInvalid()
		{
			ChildFormControl.SetOpacity(0.0);

			switch (Culture.Name)
			{
				default:
				case Culture.JP:

					MessageBox.Show("入力された値が無効です。",
									"入力エラー",
									MessageBoxButtons.OK,
									MessageBoxIcon.Warning);
					break;

				case Culture.US:

					MessageBox.Show("The input value is invalid.",
									"Input Error",
									MessageBoxButtons.OK,
									MessageBoxIcon.Warning);
					break;

				case Culture.CN:

					MessageBox.Show("入力された値が無効です。",
									"入力エラー",
									MessageBoxButtons.OK,
									MessageBoxIcon.Warning);
					break;
			}

			ChildFormControl.SetOpacity(1.0);
		}

		#endregion

		#region カレンダ

		/// <summary>
		/// ドライバカレンダを現在のWidnowsカレンダの情報で設定します。
		/// よろしいですか？
		/// </summary>
		static public DialogResult DriverCalendarSetting()
		{
			DialogResult ret = DialogResult.Yes;

			ChildFormControl.SetOpacity(0.0);

			switch (Culture.Name)
			{
				default:
				case Culture.JP:

					ret = MessageBox.Show("ドライバカレンダを現在のWidnowsカレンダの情報で設定します。" + "\n" +
										  "よろしいですか？",
										  "カレンダ設定",
										  MessageBoxButtons.YesNo,
										  MessageBoxIcon.Question);
					break;

				case Culture.US:

					ret = MessageBox.Show("Driver's calender is set based on Windows calender." + "\n" +
										  "Is it OK?",
										  "Calender setting",
										  MessageBoxButtons.YesNo,
										 MessageBoxIcon.Question);
					break;

				case Culture.CN:

					ret = MessageBox.Show("驱动器日历设定为当前窗口日历信息吗" + "\n" +
										  "是否可以？",
										  "日历设定",
										  MessageBoxButtons.YesNo,
										  MessageBoxIcon.Question);
					break;
			}

			ChildFormControl.SetOpacity(1.0);

			return ret;
		}

		/// <summary>
		/// ドライバカレンダー(日付)設定が出来ません。
		/// </summary>
		static public void DriverCalendarSettingDateError()
		{
			ChildFormControl.SetOpacity(0.0);

			switch (Culture.Name)
			{
				default:
				case Culture.JP:

					MessageBox.Show("ドライバカレンダー(日付)設定が出来ません。",
									"カレンダ設定",
									MessageBoxButtons.OK,
									MessageBoxIcon.Warning);
					break;

				case Culture.US:

					MessageBox.Show("Date of Drvier's calender can't be set.",
									"Calender setting",
									MessageBoxButtons.OK,
									MessageBoxIcon.Warning);
					break;

				case Culture.CN:

					MessageBox.Show("无法设定驱动器日历（日期）",
									"日历设定",
									MessageBoxButtons.OK,
									MessageBoxIcon.Warning);
					break;
			}

			ChildFormControl.SetOpacity(1.0);

		}

		/// <summary>
		/// ドライバカレンダー(日付)設定が出来ません。
		/// </summary>
		static public void DriverCalendarSettingTimeError()
		{
			ChildFormControl.SetOpacity(0.0);

			switch (Culture.Name)
			{
				default:
				case Culture.JP:

					MessageBox.Show("ドライバカレンダ(時刻)設定が出来ません。",
									"カレンダ設定",
									MessageBoxButtons.OK,
									MessageBoxIcon.Warning);
					break;

				case Culture.US:

					MessageBox.Show("Time of Drvier's calender can't be set.",
									"Calender setting",
									MessageBoxButtons.OK,
									MessageBoxIcon.Warning);
					break;

				case Culture.CN:

					MessageBox.Show("无法设定驱动器日历（时间）",
									"日历设定",
									MessageBoxButtons.OK,
									MessageBoxIcon.Warning);
					break;
			}

			ChildFormControl.SetOpacity(1.0);

		}

		#endregion

		/// <summary>
		/// "TEST"
		/// </summary>
		static public void TEST()
		{
			ChildFormControl.SetOpacity(0.0);

			switch (Culture.Name)
			{
				default:
				case Culture.JP:

					MessageBox.Show("TEST",
									"TEST",
									MessageBoxButtons.OK,
									MessageBoxIcon.Exclamation);
					break;

				case Culture.US:

					MessageBox.Show("TEST",
									"TEST",
									MessageBoxButtons.OK,
									MessageBoxIcon.Exclamation);
					break;

				case Culture.CN:

					MessageBox.Show("TEST",
									"TEST",
									MessageBoxButtons.OK,
									MessageBoxIcon.Exclamation);
					break;
			}

			ChildFormControl.SetOpacity(1.0);
		}
	}

	static public class ChildFormControl
	{
		static public bool PropertyLock = new bool();

		static public void EnableTopMost(bool top)
		{
			if (PropertyLock) { return; }

			if (IoMonitorForm.ThisForm != null)
			{
				if (IoMonitorForm.ThisForm.IsExist)
				{
					IoMonitorForm.ThisForm.TopMost = top;
				}
			}

			if (ServoMonitorForm.ThisForm != null)
			{
				if (ServoMonitorForm.ThisForm.IsExist)
				{
					ServoMonitorForm.ThisForm.TopMost = top;
				}
			}

			if (ParameterHelpForm.ThisForm != null)
			{
				if (ParameterHelpForm.ThisForm.IsExist)
				{
					ParameterHelpForm.ThisForm.TopMost = top;
				}
			}

			if (ProgramHelpForm.ThisForm != null)
			{
				if (ProgramHelpForm.ThisForm.IsExist)
				{
					ProgramHelpForm.ThisForm.TopMost = top;
				}
			}
		}

		static public void MinimizedToChildForm()
		{
			if (PropertyLock) { return; }

			if (IoMonitorForm.ThisForm != null)
			{
				if (IoMonitorForm.ThisForm.IsExist)
				{
					IoMonitorForm.ThisForm.WindowState = FormWindowState.Minimized;
				}
			}

			if (ServoMonitorForm.ThisForm != null)
			{
				if (ServoMonitorForm.ThisForm.IsExist)
				{
					ServoMonitorForm.ThisForm.WindowState = FormWindowState.Minimized;
				}
			}

			if (ParameterHelpForm.ThisForm != null)
			{
				if (ParameterHelpForm.ThisForm.IsExist)
				{
					ParameterHelpForm.ThisForm.WindowState = FormWindowState.Minimized;
				}
			}

			if (ProgramHelpForm.ThisForm != null)
			{
				if (ProgramHelpForm.ThisForm.IsExist)
				{
					ProgramHelpForm.ThisForm.WindowState = FormWindowState.Minimized;
				}
			}
		}

		static public void NormalizedToChildForm()
		{
			if (PropertyLock) { return; }

			if (IoMonitorForm.ThisForm != null)
			{
				if (IoMonitorForm.ThisForm.IsExist)
				{
					IoMonitorForm.ThisForm.WindowState = FormWindowState.Normal;
				}
			}

			if (ServoMonitorForm.ThisForm != null)
			{
				if (ServoMonitorForm.ThisForm.IsExist)
				{
					ServoMonitorForm.ThisForm.WindowState = FormWindowState.Normal;
				}
			}

			if (ParameterHelpForm.ThisForm != null)
			{
				if (ParameterHelpForm.ThisForm.IsExist)
				{
					ParameterHelpForm.ThisForm.WindowState = FormWindowState.Normal;
				}
			}

			if (ProgramHelpForm.ThisForm != null)
			{
				if (ProgramHelpForm.ThisForm.IsExist)
				{
					ProgramHelpForm.ThisForm.WindowState = FormWindowState.Normal;
				}
			}
		}

		static public void SetOpacity(double op)
		{
			if (PropertyLock) { return; }

			if (IoMonitorForm.ThisForm != null)
			{
				if (IoMonitorForm.ThisForm.IsExist)
				{
					IoMonitorForm.ThisForm.Opacity = op;
				}
			}

			if (ServoMonitorForm.ThisForm != null)
			{
				if (ServoMonitorForm.ThisForm.IsExist)
				{
					ServoMonitorForm.ThisForm.Opacity = op;
				}
			}

			if (ParameterHelpForm.ThisForm != null)
			{
				if (ParameterHelpForm.ThisForm.IsExist)
				{
					ParameterHelpForm.ThisForm.Opacity = op;
				}
			}

			if (ProgramHelpForm.ThisForm != null)
			{
				if (ProgramHelpForm.ThisForm.IsExist)
				{
					ProgramHelpForm.ThisForm.Opacity = op;
				}
			}
		}
	}
}
