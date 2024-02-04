using System.Runtime.InteropServices;

namespace MVSDK
{
    internal static partial class IMV
    {
        public readonly struct EnumEntry
        {
            public readonly ulong Value;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public readonly string Name;
        }
    }
}
