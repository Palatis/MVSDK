namespace MVSDK
{
#if NET5_0_OR_GREATER
    public readonly struct StreamStatisticsInfo
    {
        public readonly CameraType CameraType { get; init; }
        public readonly uint ImageError { get; init; }
        public readonly uint LostPacketBlock { get; init; }
        public readonly uint ImageReceived { get; init; }
        public readonly double FPS { get; init; }
        public readonly double Bandwidthh { get; init; }
    }
#else
    public struct StreamStatisticsInfo
    {
        public CameraType CameraType { get; set; }
        public uint ImageError { get; set; }
        public uint LostPacketBlock { get; set; }
        public uint ImageReceived { get; set; }
        public double FPS { get; set; }
        public double Bandwidthh { get; set; }
    }
#endif
}