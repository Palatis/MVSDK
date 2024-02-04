using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace MVSDK
{
    internal static partial class IMV
    {
        [StructLayout(LayoutKind.Sequential, Size = 3096)]
        public struct DeviceInfo_GigE
        {
            public LinkConfiguration LinkConfigOptions;
            public LinkConfiguration LinkConfigCurrent;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
            private readonly uint[] Reserved0;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string MacAddress;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string IPAddress;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string SubnetMask;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string DefaultGateWay;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string ProtocolVersion;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string IsValid;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1536)]
            [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
            private readonly byte[] Reserved1;
        }
    }
}
