using System.Diagnostics;

namespace MVSDK
{
    internal static partial class IMV
    {
        /// <summary>连接事件信息</summary>
        public unsafe struct ConnectArgs
        {
            /// <summary>事件类型</summary>
            public ConnectEventType EventType;

            /// <summary>预留字段</summary>
            [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
            private fixed uint nReserve[10];
        }
    }
}
