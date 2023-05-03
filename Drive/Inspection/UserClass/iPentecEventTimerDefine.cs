using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Motion_Designer
{
    public partial class iPentecEventTimer : Component
    {
        [DllImport("winmm.dll", SetLastError = true)]
        static extern UInt32 timeSetEvent(UInt32 msDelay, UInt32 msResolution, TimerEventHandler handler, ref UInt32 userCtx, UInt32 eventType);
        [DllImport("winmm.dll", SetLastError = true)]
        static extern UInt32 timeKillEvent(UInt32 timerEventId);
        [DllImport("winmm.dll")]
        public static extern uint timeBeginPeriod(uint uMilliseconds);
        [DllImport("winmm.dll")]
        public static extern uint timeEndPeriod(uint uMilliseconds);
        [DllImport("kernel32.dll")]
        static extern void InitializeCriticalSection(out CRITICAL_SECTION lpCriticalSection);
        //[DllImport("kernel32.dll")]
        //static extern void InitializeCriticalSection(IntPtr lpCriticalSection);
        [DllImport("kernel32.dll")]
        static extern void EnterCriticalSection(ref CRITICAL_SECTION lpCriticalSection);
        //[DllImport("kernel32.dll")]
        //static extern void EnterCriticalSection(IntPtr lpCriticalSection);
        [DllImport("kernel32.dll")]
        static extern void LeaveCriticalSection(ref CRITICAL_SECTION lpCriticalSection);
        //[DllImport("kernel32.dll")]
        //static extern void LeaveCriticalSection(IntPtr lpCriticalSection);
        [StructLayout(LayoutKind.Sequential)]
        public struct CRITICAL_SECTION
        {
            public IntPtr DebugInfo;
            public long LockCount;
            public long RecursionCount;
            public uint OwningThread;
            public uint LockSemaphore;
            public int Reserved;
        }
        const int TIMERR_BASE = 96;
        const int TIMERR_NOERROR = 0;
        const int TIMERR_NOCANDO = TIMERR_BASE + 1;
        const int TIMERR_STRUCT = TIMERR_BASE + 33;
        const uint TIME_ONESHOT = 0;
        const uint TIME_PERIODIC = 1;
        const uint TIME_CALLBACK_FUNCTION = 0x0000;
        const uint TIME_CALLBACK_EVENT_SET = 0x0010;
        const uint TIME_CALLBACK_EVENT_PULSE = 0x0020;
        private delegate void TimerEventHandler(UInt32 id, UInt32 msg, ref UInt32 userCtx, UInt32 rsv1, UInt32 rsv2);
    }
}
