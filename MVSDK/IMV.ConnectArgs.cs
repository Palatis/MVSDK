using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace MVSDK
{
    internal static partial class IMV
    {
        public unsafe struct ConnectArgs
        {
            public readonly ConnectEventType EventType;
            [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
            [SuppressMessage("CodeQuality", "IDE0051")]
            private fixed uint nReserve[10];
        }
    }
}
