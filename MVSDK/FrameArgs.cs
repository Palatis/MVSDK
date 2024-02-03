using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MVSDK
{
    /// <summary>帧图像数据信息</summary>
    public unsafe struct FrameArgs : IFrame
    {
        /// <summary>帧图像句柄(SDK内部帧管理用)</summary>
        public IntPtr Handle;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IntPtr _Data;
        /// <summary>帧Id(仅对GigE/Usb/PCIe相机有效)</summary>
        public ulong BlockId;
        /// <summary>数据帧状态(0是正常状态)</summary>
        public uint Status;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private uint _Width;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private uint _Height;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private uint _Size;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private PixelType _PixelType;
        /// <summary>图像时间戳(仅对GigE/Usb/PCIe相机有效)</summary>
        public ulong TimeStamp;
        /// <summary>帧数据中包含的Chunk个数(仅对GigE/Usb相机有效)</summary>
        public uint ChunkCount;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private uint _PaddingX;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private uint _PaddingY;
        /// <summary>图像在网络传输所用的时间(单位:微秒,非 GigE 相机该值为0)</summary>
        public uint ReceiveTime;
        /// <summary>预留字段</summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private fixed uint InfoReserved[19];
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        /// <summary>预留字段</summary>
        private fixed uint FrameReserved[10];

#if NET5_0_OR_GREATER
        public readonly IntPtr Data => _Data;
        public readonly uint Width => _Width;
        public readonly uint Height => _Height;
        public readonly uint Size => _Size;
        public readonly uint PaddingX => _PaddingX;
        public readonly uint PaddingY => _PaddingY;
        public readonly PixelType PixelType => _PixelType;
#else
        public IntPtr Data => _Data;
        public uint Width => _Width;
        public uint Height => _Height;
        public uint Size => _Size;
        public uint PaddingX => _PaddingX;
        public uint PaddingY => _PaddingY;
        public PixelType PixelType => _PixelType;
#endif
    }
}
