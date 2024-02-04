using System.Diagnostics.CodeAnalysis;
using System.Diagnostics;

namespace MVSDK
{
    internal static partial class IMV
    {
        public unsafe struct StreamArgs
        {
            public readonly uint ChannelId;
            public readonly ulong BlockId;
            public readonly ulong Timestamp;
            public readonly EventStatus StreamEventStatus;
            public readonly uint Status;
            [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
            [SuppressMessage("CodeQuality", "IDE0051")]
            private fixed uint Reserve[9];
        }
    }
}
