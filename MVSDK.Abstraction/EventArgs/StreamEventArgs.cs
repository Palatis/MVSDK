using System;

namespace MVSDK
{
    /// <summary>流事件信息</summary>
    public class StreamEventArgs : EventArgs
    {
#if NET5_0_OR_GREATER
                /// <summary>流通道号</summary>
    public uint ChannelId { get; init; }
                 /// <summary>流数据 BlockID</summary>
   public ulong BlockId { get; init; }
               /// <summary>时间戳</summary>
     public ulong Timestamp { get; init; }
                 /// <summary>流事件状态码</summary>
   public EventStatus StreamEventStatus { get; init; }
                /// <summary>事件状态错误码</summary>
    public uint Status { get; init; }
#else
        /// <summary>流通道号</summary>
        public uint ChannelId { get; set; }
        /// <summary>流数据 BlockID</summary>
        public ulong BlockId { get; set; }
        /// <summary>时间戳</summary>
        public ulong Timestamp { get; set; }
        /// <summary>流事件状态码</summary>
        public EventStatus StreamEventStatus { get; set; }
        /// <summary>事件状态错误码</summary>
        public uint Status { get; set; }
#endif
    }
}