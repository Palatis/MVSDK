using System.Net;

namespace MVSDK
{
    /// <summary>GigE 設備信息</summary>
    public partial class DeviceInformation
    {
        public class GigEVision : DeviceInformation
        {
#if NET5_0_OR_GREATER
            /// <summary>设备支持的IP配置选项</summary>
            /// <remarks>
            /// <para>value:4 相机只支持 LLA</para>
            /// <para>value:5 相机支持 LLA 和 Persistent IP</para>
            /// <para>value:6 相机支持 LLA 和 DHCP</para>
            /// <para>value:7 相机支持 LLA、DHCP 和 Persistent IP</para>
            /// <para>value:0 获取失败</para>
            /// </remarks>
            public LinkConfiguration LinkConfigOptions { get; init; }
            /// <summary>设备当前的IP配置选项</summary>
            /// <remarks>
            /// <para>value:4 LLA 处于活动状态</para>
            /// <para>value:5 LLA 和 Persistent IP处于活动状态</para>
            /// <para>value:6 LLA 和 DHCP 处于活动状态</para>
            /// <para>value:7 LLA、DHCP 和 Persistent IP 处于活动状态</para>
            /// <para>value:0 获取失败</para>
            /// </remarks>
            public LinkConfiguration LinkConfigCurrent { get; init; }

            /// <summary>设备 MAC 地址</summary>
            public string DeviceMACAddress { get; init; }
            /// <summary>设备 IP 地址</summary>
            public IPAddress DeviceIPAddress { get; init; }
            /// <summary>子网掩码</summary>
            public IPAddress DeviceSubnetMask { get; init; }
            /// <summary>默认网关</summary>
            public IPAddress DeviceDefaultGateway { get; init; }
            /// <summary>网络协议版本</summary>
            public string DeviceProtocolVersion { get; init; }
            /// <summary>IP 配置有效性</summary>
            public bool IsDeviceAddressValid { get; init; }

            /// <summary>网卡描述信息</summary>
            public string InterfaceDescription { get; init; }
            /// <summary>网卡 MAC 地址</summary>
            public string InterfaceMACAddress { get; init; }
            /// <summary>網卡 IP 地址</summary>
            public IPAddress InterfaceIPAddress { get; init; }
            /// <summary>網卡子网掩码</summary>
            public IPAddress InterfaceSubnetMask { get; init; }
            /// <summary>網卡默认网关</summary>
            public IPAddress InterfaceDefaultGateway { get; init; }
#else
            /// <summary>设备支持的IP配置选项</summary>
            /// <remarks>
            /// <para>value:4 相机只支持 LLA</para>
            /// <para>value:5 相机支持 LLA 和 Persistent IP</para>
            /// <para>value:6 相机支持 LLA 和 DHCP</para>
            /// <para>value:7 相机支持 LLA、DHCP 和 Persistent IP</para>
            /// <para>value:0 获取失败</para>
            /// </remarks>
            public LinkConfiguration LinkConfigOptions { get; set; }
            /// <summary>设备当前的IP配置选项</summary>
            /// <remarks>
            /// <para>value:4 LLA 处于活动状态</para>
            /// <para>value:5 LLA 和 Persistent IP处于活动状态</para>
            /// <para>value:6 LLA 和 DHCP 处于活动状态</para>
            /// <para>value:7 LLA、DHCP 和 Persistent IP 处于活动状态</para>
            /// <para>value:0 获取失败</para>
            /// </remarks>
            public LinkConfiguration LinkConfigCurrent { get; set; }

            /// <summary>设备 MAC 地址</summary>
            public string DeviceMACAddress { get; set; }
            /// <summary>设备 IP 地址</summary>
            public IPAddress DeviceIPAddress { get; set; }
            /// <summary>子网掩码</summary>
            public IPAddress DeviceSubnetMask { get; set; }
            /// <summary>默认网关</summary>
            public IPAddress DeviceDefaultGateway { get; set; }
            /// <summary>网络协议版本</summary>
            public string DeviceProtocolVersion { get; set; }
            /// <summary>IP 配置有效性</summary>
            public bool IsDeviceAddressValid { get; set; }

            /// <summary>网卡描述信息</summary>
            public string InterfaceDescription { get; set; }
            /// <summary>网卡 MAC 地址</summary>
            public string InterfaceMACAddress { get; set; }
            /// <summary>網卡 IP 地址</summary>
            public IPAddress InterfaceIPAddress { get; set; }
            /// <summary>網卡子网掩码</summary>
            public IPAddress InterfaceSubnetMask { get; set; }
            /// <summary>網卡默认网关</summary>
            public IPAddress InterfaceDefaultGateway { get; set; }
#endif
        }
    }
}