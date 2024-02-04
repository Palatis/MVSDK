using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace MVSDK
{
    internal static partial class IMV
    {
        public struct InterfaceInfo_Usb
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string Description;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string VendorID;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string ProductID;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string SubsystemID;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string Revision;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string Speed;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
            [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
            [SuppressMessage("CodeQuality", "IDE0051")]
            private readonly byte[] chReserved;
        }
    }
}
