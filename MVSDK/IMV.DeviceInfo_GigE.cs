using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MVSDK
{
    internal static partial class IMV
    {
        /// <summary>GigE设备信息</summary>
        [StructLayout(LayoutKind.Sequential, Size = 3096)]
        public struct DeviceInfo_GigE
        {
            /// <summary>设备支持的IP配置选项</summary>
            /// <remarks>
            /// <para>value:4 相机只支持 LLA</para>
            /// <para>value:5 相机支持 LLA 和 Persistent IP</para>
            /// <para>value:6 相机支持 LLA 和 DHCP</para>
            /// <para>value:7 相机支持 LLA、DHCP 和 Persistent IP</para>
            /// <para>value:0 获取失败</para>
            /// </remarks>
            public uint LinkConfigOptions;
            /// <summary>设备当前的IP配置选项</summary>
            /// <remarks>
            /// <para>value:4 LLA 处于活动状态</para>
            /// <para>value:5 LLA 和 Persistent IP处于活动状态</para>
            /// <para>value:6 LLA 和 DHCP 处于活动状态</para>
            /// <para>value:7 LLA、DHCP 和 Persistent IP 处于活动状态</para>
            /// <para>value:0 获取失败</para>
            /// </remarks>
            public uint LinkConfigCurrent;
            /// <summary>保留</summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
            private readonly uint[] nReserved;
            /// <summary>设备Mac地址</summary>
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
            /// <summary>网络协议版本</summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string ProtocolVersion;
            /// <summary>Ip配置有效性</summary>
            /// <remarks>
            /// <para>Ip配置有效时字符串值"Valid"</para>
            /// <para>Ip配置无效时字符串值"Invalid On This Interface"</para>
            /// </remarks>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string IsValid;
            /// <summary>保留</summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1536)]
            [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
            private readonly byte[] chReserved;
        }
    }
}
