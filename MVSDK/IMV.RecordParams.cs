using System;

namespace MVSDK
{
    internal static partial class IMV
    {
        /// <summary>录像结构体</summary>
        public unsafe struct RecordParams
        {
            /// <summary>图像宽</summary>
            public uint Width;
            /// <summary>图像高</summary>
            public uint Height;
            /// <summary>帧率 (大于 0)</summary>
            public float FameRate;
            /// <summary>视频质量 (1 - 100)</summary>
            public uint Quality;
            /// <summary>视频格式</summary>
            public VideoType VideoType;
            /// <summary>保存视频路径</summary>
            public IntPtr FilePath;
            /// <summary>预留</summary>
            private fixed uint nReserved[5];
        }
    }
}
