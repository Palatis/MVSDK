using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace MVSDK
{
    internal static partial class IMV
    {
        public unsafe struct FlipImageParams
        {
            public uint Width;
            public uint Height;
            public PixelType PixelType;
            public FlipType FlipType;
            public IntPtr SrcData;
            public uint SrcDataLen;
            public IntPtr DstBuf;
            public uint DstBufSize;
            public uint DstDataLen;
            [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
            [SuppressMessage("CodeQuality", "IDE0051")]
            private fixed uint nReserved[8];
        }
    }
}
