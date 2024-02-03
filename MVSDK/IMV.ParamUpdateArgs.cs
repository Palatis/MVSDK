using System;
using System.Diagnostics;

namespace MVSDK
{
    internal static partial class IMV
    {
        /// <summary>参数更新事件信息</summary>
        public unsafe struct ParamUpdateArgs
        {
            /// <summary>是否是定时更新,true:表示是定时更新，false:表示非定时更新</summary>
            public readonly bool IsPolled;
            /// <summary>预留字段</summary>
            [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
            private fixed uint nReserve[10];
            /// <summary>更新的参数个数</summary>
            public readonly uint ParameterCount;
            /// <summary>更新的参数名称集合(SDK内部缓存)</summary>
            public readonly IntPtr Parameters;
        }
    }
}