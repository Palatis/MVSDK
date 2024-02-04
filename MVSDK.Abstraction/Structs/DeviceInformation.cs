namespace MVSDK
{
    /// <summary>設備信息</summary>
    public partial class DeviceInformation
    {
#if NET5_0_OR_GREATER
        public int CameraIndex { get; init; }
        /// <summary>设备类别</summary>
        public CameraType CameraType { get; init; }
        /// <summary>接口类别</summary>
        public InterfaceType InterfaceType { get; init; }
        /// <summary>接口名</summary>
        public string InterfaceName { get; init; }

        /// <summary>厂商:序列号</summary>
        public string CameraKey { get; init; }
        /// <summary>用户自定义名</summary>
        public string UserDefinedName { get; init; }
        /// <summary>设备序列号</summary>
        public string SerialNumber { get; init; }
        /// <summary>厂商</summary>
        public string VendorName { get; init; }
        /// <summary>设备型号</summary>
        public string ModelName { get; init; }
        /// <summary>设备制造信息</summary>
        public string VenderInfo { get; init; }
        /// <summary>设备版本</summary>
        public string DeviceVersion { get; init; }
#else
        public int CameraIndex { get; set; }
        /// <summary>设备类别</summary>
        public CameraType CameraType { get; set; }
        /// <summary>接口类别</summary>
        public InterfaceType InterfaceType { get; set; }
        /// <summary>接口名</summary>
        public string InterfaceName { get; set; }

        /// <summary>厂商:序列号</summary>
        public string CameraKey { get; set; }
        /// <summary>用户自定义名</summary>
        public string UserDefinedName { get; set; }
        /// <summary>设备序列号</summary>
        public string SerialNumber { get; set; }
        /// <summary>厂商</summary>
        public string VendorName { get; set; }
        /// <summary>设备型号</summary>
        public string ModelName { get; set; }
        /// <summary>设备制造信息</summary>
        public string VenderInfo { get; set; }
        /// <summary>设备版本</summary>
        public string DeviceVersion { get; set; }
#endif
    }
}