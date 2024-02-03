using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace MVSDK
{
    internal static partial class IMV
    {
        /// <summary>GigE网卡信息</summary>
        public struct InterfaceInfo_GigE
        {
            /// <summary>网卡描述信息</summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string Description;
            /// <summary>网卡Mac地址</summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string MacAddress;
            /// <summary>设备Ip地址</summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string IPAddress;
            /// <summary>子网掩码</summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string SubnetMask;
            /// <summary>默认网关</summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string DefaultGateWay;
            /// <summary>保留</summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1280)]
            [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
            [SuppressMessage("CodeQuality", "IDE0051")]
            private readonly byte[] chReserved;
        }
    }
}