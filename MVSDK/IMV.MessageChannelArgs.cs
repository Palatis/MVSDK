using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace MVSDK
{
    internal static partial class IMV
    {
        public unsafe struct MessageChannelArgs
        {
            public readonly ushort EventId;
            public readonly ushort ChannelId;
            public readonly ulong BlockId;
            public readonly ulong Timestamp;
            [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
            [SuppressMessage("CodeQuality", "IDE0051")]
            private fixed uint nReserve[8];
            public readonly uint ParameterCount;
            public readonly IntPtr Parameters;
        }
    }
}