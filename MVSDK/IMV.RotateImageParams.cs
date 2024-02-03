using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace MVSDK
{
    internal static partial class IMV
    {
        /// <summary>图像旋转结构体</summary>
        public unsafe struct RotateImageParams
        {
            /// <summary>图像宽</summary>
            public uint Width;
            /// <summary>图像高</summary>
            public uint Height;
            /// <summary>像素格式</summary>
            public PixelType PixelType;
            /// <summary>旋转角度</summary>
            public RotationAngle RotationAngle;
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
            [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
            [SuppressMessage("CodeQuality", "IDE0051")]
            private fixed uint nReserved[8];
        }
    }
}
