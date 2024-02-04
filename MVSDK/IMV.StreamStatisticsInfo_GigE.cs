using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace MVSDK
{
    internal static partial class IMV
    {
        public struct StreamStatisticsInfo_GigE
        {
            [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
            [SuppressMessage("CodeQuality", "IDE0051")]
            private unsafe fixed uint Reserved0[10];
            public uint ImageError;
            public uint LostPacketBlock;
            [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
            [SuppressMessage("CodeQuality", "IDE0051")]
            private unsafe fixed uint Reserved1[4];
            [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
            [SuppressMessage("CodeQuality", "IDE0051")]
            private unsafe fixed uint Reserved2[5];
            public uint ImageReceived;
            public double FramesPerSecond;
            public double Bandwidth;
            [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
            [SuppressMessage("CodeQuality", "IDE0051")]
            private unsafe fixed uint Reserved[4];
        }
    }
}
