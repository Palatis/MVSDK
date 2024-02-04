using System.Runtime.InteropServices;

namespace MVSDK
{
    internal static partial class IMV
    {
        public struct String
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string Value;
        }
    }
}