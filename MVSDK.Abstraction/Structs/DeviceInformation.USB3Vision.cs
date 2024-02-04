using System;

namespace MVSDK
{
    /// <summary>USB3 設備信息</summary>
    public partial class DeviceInformation
    {
        public class USB3Vision : DeviceInformation
        {
#if NET5_0_OR_GREATER
            /// <summary>支持的速度</summary>
            public UsbSpeed SpeedSupported { get; init; }
            /// <summary>驅動是否安裝</summary>
            public bool IsDriverInstalled { get; init; }
            /// <summary>配置有效性</summary>
            public bool IsConfigurationValid { get; init; }
            /// <summary>GenCP 版本号</summary>
            public string GenCPVersion { get; init; }
            /// <summary>U3V 版本号</summary>
            public string U3vVersion { get; init; }
            /// <summary>设备引导号</summary>
            public Guid DeviceGuid { get; init; }
            /// <summary>设备序列号</summary>
            public string U3vSerialNumber { get; init; }
            /// <summary>设备系列号</summary>
            public string FamilyName { get; init; }
            /// <summary>设备传输速度</summary>
            public string CurrentSpeed { get; init; }
            /// <summary>设备最大供电量</summary>
            public string MaxPower { get; init; }

            /// <summary>USB 接口描述信息</summary>
            public string Description { get; init; }
            /// <summary>USB 接口製造商 ID</summary>
            public string VendorId { get; init; }
            /// <summary>USB 接口设备 ID</summary>
            public string DeviceId { get; init; }
            /// <summary>USB 接口 Subsystem ID</summary>
            public string SubSystemId { get; init; }
            /// <summary>USB 接口 Revision</summary>
            public string Revision { get; init; }
            /// <summary>USB 接口速度</summary>
            public string InterfaceSpeed { get; init; }
#else
            /// <summary>支持的速度</summary>
            public UsbSpeed SpeedSupported { get; set; }
            /// <summary>驅動是否安裝</summary>
            public bool IsDriverInstalled { get; set; }
            /// <summary>配置有效性</summary>
            public bool IsConfigurationValid { get; set; }
            /// <summary>GenCP 版本号</summary>
            public string GenCPVersion { get; set; }
            /// <summary>U3V 版本号</summary>
            public string U3vVersion { get; set; }
            /// <summary>设备引导号</summary>
            public Guid DeviceGuid { get; set; }
            /// <summary>设备序列号</summary>
            public string U3vSerialNumber { get; set; }
            /// <summary>设备系列号</summary>
            public string FamilyName { get; set; }
            /// <summary>设备传输速度</summary>
            public string CurrentSpeed { get; set; }
            /// <summary>设备最大供电量</summary>
            public string MaxPower { get; set; }

            /// <summary>USB 接口描述信息</summary>
            public string Description { get; set; }
            /// <summary>USB 接口製造商 ID</summary>
            public string VendorId { get; set; }
            /// <summary>USB 接口设备 ID</summary>
            public string DeviceId { get; set; }
            /// <summary>USB 接口 Subsystem ID</summary>
            public string SubSystemId { get; set; }
            /// <summary>USB 接口 Revision</summary>
            public string Revision { get; set; }
            /// <summary>USB 接口速度</summary>
            public string InterfaceSpeed { get; set; }
#endif
        }
    }
}