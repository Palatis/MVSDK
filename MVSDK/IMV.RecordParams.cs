using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics;

namespace MVSDK
{
    internal static partial class IMV
    {
        public unsafe struct RecordParams
        {
            public uint Width;
            public uint Height;
            public float FameRate;
            public uint Quality;
            public VideoType VideoType;
            public IntPtr FilePath;
            [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
            [SuppressMessage("CodeQuality", "IDE0051")]
            private fixed uint nReserved[5];
        }
    }
}
