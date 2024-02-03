namespace MVSDK
{
    /// <summary>枚举：流事件状态</summary>
    public enum EventStatus
    {
        /// <summary>正常流事件</summary>
        Normal = 1,
        /// <summary>丢帧事件</summary>
        LostFrame = 2,
        /// <summary>丢包事件</summary>
        LostPacket = 3,
        /// <summary>图像错误事件</summary>
        ImageError = 4,
        /// <summary>取流错误事件</summary>
        StreamChannelError = 5,
        /// <summary>太多连续重传</summary>
        TooManyConsecutiveResends = 6,
        /// <summary>太多丢包</summary>
        TooManyLostPacket = 7,
    }
}