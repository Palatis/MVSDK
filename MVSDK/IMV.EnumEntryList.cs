using System;

namespace MVSDK
{
    internal static partial class IMV
    {
        /// <summary>枚举属性的可设枚举值列表信息</summary>
        public unsafe struct EnumEntryList
        {
            /// <summary>存放枚举值内存大小</summary>
            public uint EntryBufSize;
            /// <summary>存放可设枚举值列表(调用者分配缓存)</summary>
            public IntPtr EntryBuf;
        }
    }
}
