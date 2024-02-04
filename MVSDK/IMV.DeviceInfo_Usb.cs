using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace MVSDK
{
    internal static partial class IMV
    {
        public struct DeviceInfo_Usb
        {
            [MarshalAs(UnmanagedType.I1)]
            public bool IsLowSpeedSupported;
            [MarshalAs(UnmanagedType.I1)]
            public bool IsFullSpeedSupported;
            [MarshalAs(UnmanagedType.I1)]
            public bool IsHighSpeedSupported;
            [MarshalAs(UnmanagedType.I1)]
            public bool IsSuperSpeedSupported;
            [MarshalAs(UnmanagedType.I1)]
            public bool IsDriverInstalled;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            [SuppressMessage("CodeQuality", "IDE0051")]
            private readonly bool[] Reserved0;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
            [SuppressMessage("CodeQuality", "IDE0051")]
            private readonly uint[] Reserved1;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string IsConfigurationValid;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string GenCPVersion;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string Version;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string DeviceGUID;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string FamilyName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string SerialNumber;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string Speed;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string MaxPower;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
            [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
            [SuppressMessage("CodeQuality", "IDE0051")]
            private readonly byte[] Reserved2;
        }
    }
}