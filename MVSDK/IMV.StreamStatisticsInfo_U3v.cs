namespace MVSDK
{
    internal static partial class IMV
    {
        /// <summary>U3V设备统计流信息</summary>
        public struct StreamStatisticsInfo_U3v
        {
            /// <summary>图像错误的帧数</summary>
            public uint imageError;
            /// <summary>丢包的帧数</summary>
            public uint lostPacketBlock;
            /// <summary>预留</summary>
            private unsafe fixed uint nReserved0[10];
            /// <summary>正常获取的帧数</summary>
            public uint imageReceived;
            /// <summary>帧率</summary>
            public double fps;
            /// <summary>带宽(Mbps)</summary>
            public double bandwidth;
            /// <summary>预留</summary>
            private unsafe fixed uint nReserved[8];
        }
    }
}
