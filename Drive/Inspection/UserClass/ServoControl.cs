using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace Motion_Designer
{
    static public class ServoDef
    {
        /// <summary>
        /// 強制的に高速側へシーケンススタート　高速回転モード　(旧：クラッチ強制励磁ON指示 : 1 )
        /// </summary>
        static public readonly int ON = 50;

        /// <summary>
        /// 強制的に低速側へシーケンススタート 高トルクモード   (旧：クラッチ強制励磁OFF指示 : 99)
        /// </summary>
        static public readonly int OFF = 40;                                   

        static public readonly int WAIT_100ms = 100;
    }

    static public class ServoControl
    {
       
        #region 制御モード設定

        static public bool ControlMode(int mode, bool balmreset)
        {
            int sts = 0;
            int contorlmode = 0;

            if (!CCommandTx.ReadSvNet(CParamID.ServoStatus, ref sts)) return false;

            if (!CCommandTx.ReadSvNet(CParamID.ControlMode, ref contorlmode)) return false;

            if (contorlmode != mode)
            {
                if (!CCommandTx.WriteSvNet(CParamID.ControlMode, mode)) return false;
            }

            if (balmreset)
            {
                if (!AlarmReset()) return false;
            }

            return true;
        }

        #endregion

        #region サーボON

        static public bool ServoON(int wait)
        {
            int cmd = 0;

            if (!CCommandTx.ReadSvNet(CParamID.ServoCommand, ref cmd)) return false;

            cmd &= ~0x0030;     //Hard Stop & Smooth Stop Clear
            if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) return false;

            cmd |= 0x0001;

            if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) return false;

            Thread.Sleep(wait);

            return true;
        }

        #endregion

        #region サーボOFF

        static public bool ServoOFF()
        {
            int cmd = 0;

            if (!CCommandTx.ReadSvNet(CParamID.ServoCommand, ref cmd)) return false;

            cmd |= 0x0020;      //Smooth Stop bit Set
            if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) return false;

            Thread.Sleep(100);

            cmd &= ~0x0033;     //Servo On & Profile Start bit Clear & Smooth Stop & Hard Stop bit Clear

            if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) return false;

            return true;
        }

        #endregion

        #region プロファイル動作

        /// <summary>
        /// <summary>
        /// プロファイル動作
        /// </summary>
        /// <param name="axis"></param>
        /// <returns></returns>
        static public bool ProfileOperation(bool bposreset , int pos , int acc , int dec ,int vel)
        {
            int cmd = 0;
            int ctrl = 0;

            //位置リセット
            if (bposreset)
            {
                if (!PositionReset()) return false;
            }

            // 加速度
            if (!CCommandTx.WriteSvNet(CParamID.TargetAcceleration, acc)) return false;

            // 減速度
            if (!CCommandTx.WriteSvNet(CParamID.TargetDeceleration, dec)) return false;

            // 目標位置
            if (!CCommandTx.WriteSvNet(CParamID.TargetPosition, pos)) return false;

            // 目標速度
            if (!CCommandTx.WriteSvNet(CParamID.TargetVelocity, vel)) return false;

            if (!CCommandTx.ReadSvNet(CParamID.ServoCommand, ref cmd)) return false;
            if (!CCommandTx.ReadSvNet(CParamID.ControlSwitch, ref ctrl)) return false;

            ctrl |= 0x0002;     //Profile bit auto Clear
            if (!CCommandTx.WriteSvNet(CParamID.ControlSwitch, ctrl)) return false;

            cmd |= 0x0002;      //Profile Start bit Set
            cmd |= 0x0080;		//Smoothing On

            if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) return false;

            return true;
        }

        #endregion

        #region 位置情報リセット

        static public bool PositionReset()
        {
            int cmd = 0;

            if (!CCommandTx.ReadSvNet(CParamID.ServoCommand, ref cmd)) return false;

            cmd |= 0x4000;
            if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) return false;

            Thread.Sleep(100);

            cmd &= ~0x4000;
            if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) return false;

            return true;
        }

        #endregion

        #region アラームリセット

        static public bool AlarmReset()
        {
            int cmd = CMonitor.GetParameter(CParamID.ServoCommand);

            cmd |= 0x0008;

            if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) return false;

            Thread.Sleep(500);

            cmd &= ~0x0008;

            if (!CCommandTx.WriteSvNet(CParamID.ServoCommand, cmd)) return false;

            Thread.Sleep(100);

            return true;
        }

        #endregion

        #region ブレーキ

        static public bool BreakRelease(int rel)
        {
            //ブレーキ強制解放過
            return CCommandTx.WriteSvNet(CParamID.ForcedBrakeoff, rel);
        }

        #endregion

        #region クラッチ励磁

        static public bool ClutchExcitation(int data)
        {
            bool bret = CCommandTx.WriteSvNet(CParamID.ClutchExcitation, data);

            //Thread.Sleep(1000);

            return bret; 
        }

        #endregion

    }
}
