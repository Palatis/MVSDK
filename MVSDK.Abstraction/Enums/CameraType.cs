namespace MVSDK
{
    /// <summary>设备类型</summary>
    public enum CameraType
    {
        /// <summary>GigE 相机</summary>
        GigEVision = 0,
        /// <summary>USB3 相机</summary>
        USB3Vision = 1,
        /// <summary>CameraLink 相机</summary>
        CameraLink = 2,
        /// <summary>PCIe 相机</summary>
        PCIeVision = 3,
        /// <summary>未知类型</summary>
        Undefined = 0x000000FF,
    }
}