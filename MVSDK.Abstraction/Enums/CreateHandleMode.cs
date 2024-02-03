namespace MVSDK
{
    /// <summary>枚举：创建句柄方式</summary>
    public enum CreateHandleMode
    {
        /// <summary>通过已枚举设备的索引(从0开始，比如 0, 1, 2...)</summary>
        ByScanIndex = 0,
        /// <summary>通过设备键"厂商:序列号"</summary>
        ByCameraKey = 1,
        /// <summary>通过设备自定义名</summary>
        ByUserDefinedName = 2,
        /// <summary>通过设备IP地址</summary>
        ByIPAddress = 3,
    }
}