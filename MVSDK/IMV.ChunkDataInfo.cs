using System;

namespace MVSDK
{
    internal static partial class IMV
    {
        public struct ChunkDataInfo
        {
            public uint ChunkId;
            public uint ParameterCount;
            public IntPtr Parameters;
        }
    }
}
