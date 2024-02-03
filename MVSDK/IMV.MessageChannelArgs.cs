using System;
using System.Diagnostics;

namespace MVSDK
{
    internal static partial class IMV
    {
        /// <summary>消息通道事件信息</summary>
        public unsafe struct MessageChannelArgs
        {
            /// <summary>事件Id</summary>
            public readonly ushort EventId;
            /// <summary>消息通道号</summary>
            public readonly ushort ChannelId;
            /// <summary>流数据BlockID</summary>
            public readonly ulong BlockId;
            /// <summary>时间戳</summary>
            public readonly ulong Timestamp;
            /// <summary>预留字段</summary>
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            private fixed uint nReserve[8];
            /// <summary>参数个数</summary>
            public readonly uint ParameterCount;
            /// <summary>事件相关的属性名列集合(SDK内部缓存)</summary>
            public readonly IntPtr Parameters;
        }
    }
}
