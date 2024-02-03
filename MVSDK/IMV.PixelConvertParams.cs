using System;
using System.Runtime.InteropServices;

namespace MVSDK
{
    internal static partial class IMV
    {
        /// <summary>像素转换结构体</summary>
        public struct ConvertImageParams
        {
            /// <summary>图像宽</summary>
            public uint Width;
            /// <summary>图像高</summary>
            public uint Height;
            /// <summary>像素格式</summary>
            public PixelType SrcPixelType;
            /// <summary>输入图像数据</summary>
            public IntPtr SrcData;
            /// <summary>输入图像长度</summary>
            public uint SrcDataLen;
            /// <summary>图像宽填充</summary>
            public uint PaddingX;
            /// <summary>图像高填充</summary>
            public uint PaddingY;
            /// <summary>转换Bayer格式算法</summary>
            public BayerDemosaicAlgorithm DemosaicAlgorithm;
            /// <summary>目标像素格式</summary>
            public PixelType DstPixelType;
            /// <summary>输出数据缓存(调用者分配缓存)</summary>
            public IntPtr DstBuf;
            /// <summary>提供的输出缓冲区大小</summary>
            public uint DstBufSize;
            /// <summary>输出数据长度</summary>
            public uint DstDataLen;

            /// <summary>预留</summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            private uint[] Reserved;
        }
    }
}
