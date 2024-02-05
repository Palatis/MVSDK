using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics;

namespace MVSDK
{
    internal static partial class IMV
    {
        public unsafe struct RecordFrameInfoParams
        {
            public IntPtr Data;
            public uint DataLen;
            public uint PaddingX;
            public uint PaddingY;
            public PixelType PixelType;
            [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
            [SuppressMessage("CodeQuality", "IDE0051")]
            private fixed uint nReserved[5];
        }
    }
}
