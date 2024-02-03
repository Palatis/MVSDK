using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace MVSDK
{
    internal static partial class IMV
    {
        /// <summary>Usb设备信息</summary>
        public struct DeviceInfo_Usb
        {
            /// <summary>true 支持，false 不支持，其他值 非法。</summary>
            [MarshalAs(UnmanagedType.I1)]
            public bool IsLowSpeedSupported;
            /// <summary>true 支持，false 不支持，其他值 非法。</summary>
            [MarshalAs(UnmanagedType.I1)]
            public bool IsFullSpeedSupported;
            /// <summary>true 支持，false 不支持，其他值 非法。</summary>
            [MarshalAs(UnmanagedType.I1)]
            public bool IsHighSpeedSupported;
            /// <summary>true 支持，false 不支持，其他值 非法。</summary>
            [MarshalAs(UnmanagedType.I1)]
            public bool IsSuperSpeedSupported;
            /// <summary>true 支持，false 不支持，其他值 非法。</summary>
            [MarshalAs(UnmanagedType.I1)]
            public bool IsDriverInstalled;
            /// <summary>保留</summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            [SuppressMessage("CodeQuality", "IDE0051")]
            private readonly bool[] boolReserved;
            /// <summary>保留</summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
            [SuppressMessage("CodeQuality", "IDE0051")]
            private readonly uint[] Reserved;
            /// <summary>配置有效性</summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string IsConfigurationValid;
            /// <summary>GenCP 版本</summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string GenCPVersion;
            /// <summary>U3V 版本号</summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string Version;
            /// <summary>设备引导号</summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string DeviceGUID;
            /// <summary>设备系列号</summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string FamilyName;
            /// <summary>设备序列号</summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string SerialNumber;
            /// <summary>设备传输速度</summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string Speed;
            /// <summary>设备最大供电量</summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string MaxPower;
            /// <summary>保留</summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
            [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
            [SuppressMessage("CodeQuality", "IDE0051")]
            private readonly byte[] chReserved;
        }
    }
}
