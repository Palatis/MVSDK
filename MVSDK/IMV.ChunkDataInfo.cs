using System;

namespace MVSDK
{
    internal static partial class IMV
    {
        /// <summary>Chunk数据信息</summary>
        public struct ChunkDataInfo
        {
            /// <summary>ChunkID</summary>
            public uint ChunkId;
            /// <summary>属性名个数</summary>
            public uint nParamCnt;
            /// <summary>Chunk 数据对应的属性名集合 (SDK 内部缓存)</summary>
            public IntPtr pParamNameList;
        }
    }
}
