using System;
using System.Runtime.InteropServices;

namespace MVSDK
{
    internal static partial class IMV
    {
        /// <summary>图像翻转结构体</summary>
        public unsafe struct FlipImageParams
        {
            /// <summary>图像宽</summary>
            public uint Width;
            /// <summary>图像高</summary>
            public uint Height;
            /// <summary>像素格式</summary>
            public PixelType PixelType;
            /// <summary>翻转类型</summary>
            public FlipType FlipType;
            /// <summary>输入图像数据</summary>
            public IntPtr SrcData;
            /// <summary>输入图像长度</summary>
            public uint SrcDataLen;
            /// <summary>输出数据缓存(调用者分配缓存)</summary>
            public IntPtr DstBuf;
            /// <summary>提供的输出缓冲区大小</summary>
            public uint DstBufSize;
            /// <summary>输出数据长度</summary>
            public uint DstDataLen;
            /// <summary>预留</summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            private fixed uint nReserved[8];
        }
    }
}
