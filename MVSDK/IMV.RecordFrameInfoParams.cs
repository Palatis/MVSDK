using System;

namespace MVSDK
{
    internal static partial class IMV
    {
        /// <summary>录像用帧信息结构体</summary>
        public unsafe struct RecordFrameInfoParams
        {
            /// <summary>图像数据</summary>
            public IntPtr Data;
            /// <summary>图像数据长度</summary>
            public uint DataLen;
            /// <summary>图像宽填充</summary>
            public uint PaddingX;
            /// <summary>图像高填充</summary>
            public uint PaddingY;
            /// <summary>像素格式</summary>
            public PixelType PixelType;
            /// <summary>预留</summary>
            private fixed uint nReserved[5];
        }
    }
}
