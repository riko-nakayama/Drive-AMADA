using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Motion_Designer
{
    public partial class iPentecEventTimer : Component
    {
        public delegate void OnTimerDelegate();
        
        private OnTimerDelegate onTimer;
        private CRITICAL_SECTION CriticalSection;
        private uint TimerID = 0;

        private TimerEventHandler teHandler;
        private bool _enabled = false;
        
        public uint Resolution { set; get; }
        
        public uint Interval { set; get; }
        
        public bool Enabled
        {
            set
            {
                _enabled = value;
                UpdateTimer();
            }
            get
            {
                return _enabled;
            }
        }

        public iPentecEventTimer()
        {
            InitalizeProperty();
        }

        public iPentecEventTimer(IContainer container)
        {
            container.Add(this);
            InitalizeProperty();
        }

        private void InitalizeProperty()
        {
            Resolution = 100;
            Interval = 1;
            Enabled = false;
            teHandler += TimerProc;
        }

        private void UpdateTimer()
        {
            if (DesignMode == false)
            {
                if (Enabled == true)
                {
                    if (TimerID != 0)
                    {
                        timeKillEvent(TimerID);
                    }
                    if (timeBeginPeriod(Resolution) == TIMERR_NOERROR)
                    {
                        uint userctx = 0;
                        TimerID = timeSetEvent(Interval, Resolution, teHandler, ref userctx, TIME_PERIODIC);
                    }
                }
                else
                {
                    if (TimerID != 0)
                    {
                        timeKillEvent(TimerID);
                        timeEndPeriod(Resolution);
                    }
                }
            }
        }

        private void TimerProc(UInt32 id, UInt32 msg, ref UInt32 userCtx, UInt32 rsv1, UInt32 rsv2)
        {

            InitializeCriticalSection(out CriticalSection);
            EnterCriticalSection(ref CriticalSection);
            try
            {
                if (onTimer != null)
                {
                    onTimer();
                }
            }
            finally
            {
                LeaveCriticalSection(ref CriticalSection);
            }
        }

        //OnTimer Event
        public event OnTimerDelegate OnTimer
        {
            add
            {
                onTimer += value;
            }
            remove
            {
                onTimer -= value;
            }
        }
    }
}
