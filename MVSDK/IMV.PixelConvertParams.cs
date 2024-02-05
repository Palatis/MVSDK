using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace MVSDK
{
    internal static partial class IMV
    {
        public unsafe struct ConvertImageParams
        {
            public uint Width;
            public uint Height;
            public PixelType SrcPixelType;
            public IntPtr SrcData;
            public uint SrcDataLen;
            public uint PaddingX;
            public uint PaddingY;
            public BayerDemosaicAlgorithm DemosaicAlgorithm;
            public PixelType DstPixelType;
            public IntPtr DstBuf;
            public uint DstBufSize;
            public uint DstDataLen;
            [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
            [SuppressMessage("CodeQuality", "IDE0051")]
            private fixed uint Reserved[8];
        }
    }
}
