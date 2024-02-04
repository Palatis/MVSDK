using System;

namespace MVSDK
{
    internal static partial class IMV
    {
        public unsafe struct EnumEntryList
        {
            public uint EntryBufSize;
            public IntPtr EntryBuf;
        }
    }
}
