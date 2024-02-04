namespace MVSDK
{
#if NET5_0_OR_GREATER
    /// <summary>统计流信息</summary>
    public readonly struct StreamStatisticsInfo
    {
        /// <summary>设备类型</summary>
        public readonly CameraType CameraType { get; init; }
        /// <summary>图像错误的帧数</summary>
        public readonly uint ImageError { get; init; }
        /// <summary>丢包的帧数</summary>
        public readonly uint LostPacketBlock { get; init; }
        /// <summary>正常获取的帧数</summary>
        public readonly uint ImageReceived { get; init; }
        /// <summary>帧率</summary>
        public readonly double FramesPerSecond { get; init; }
        /// <summary>带宽 (Mbps)</summary>
        public readonly double Bandwidthh { get; init; }
    }
#else
    public struct StreamStatisticsInfo
    {
        /// <summary>设备类型</summary>
        public CameraType CameraType { get; set; }
        /// <summary>图像错误的帧数</summary>
        public uint ImageError { get; set; }
        /// <summary>丢包的帧数</summary>
        public uint LostPacketBlock { get; set; }
        /// <summary>正常获取的帧数</summary>
        public uint ImageReceived { get; set; }
        /// <summary>帧率</summary>
        public double FramesPerSecond { get; set; }
        /// <summary>带宽 (Mbps)</summary>
        public double Bandwidthh { get; set; }
    }
#endif
}