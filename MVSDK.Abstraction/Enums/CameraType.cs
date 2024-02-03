namespace MVSDK
{
    /// <summary>设备类型</summary>
    public enum CameraType
    {
        /// <summary>GIGE相机</summary>
        GigEVision = 0,
        /// <summary>USB3.0相机</summary>
        USB3Vision = 1,
        /// <summary>CAMERALINK 相机</summary>
        CameraLink = 2,
        /// <summary>PCIe相机</summary>
        PCIeVision = 3,
        /// <summary>未知类型</summary>
        Undefined = 0x000000FF,
    }
}