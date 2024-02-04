using System.Runtime.InteropServices;

namespace MVSDK
{
    internal static partial class IMV
    {
        public struct ErrorList
        {
            public uint Count;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_ERROR_LIST_NUM)]
            public String[] Parameters;
        }
    }
}
