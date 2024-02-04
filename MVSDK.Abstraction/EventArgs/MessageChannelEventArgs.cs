using System;
using System.Collections.Generic;

namespace MVSDK
{
    /// <summary>消息通道事件信息</summary>
    public class MessageChannelEventArgs : EventArgs
    {
#if NET5_0_OR_GREATER
        /// <summary>事件 Id</summary>
        public ushort EventId { get; init; }
        /// <summary>消息通道号</summary>
        public ushort ChannelId { get; init; }
        /// <summary>流数据 BlockID</summary>
        public ulong BlockId { get; init; }
        /// <summary>时间戳</summary>
        public ulong Timestamp { get; init; }
        public IReadOnlyList<string> Parameters { get; init; }
#else
        /// <summary>事件 Id</summary>
        public ushort EventId { get; set; }
        /// <summary>消息通道号</summary>
        public ushort ChannelId { get; set; }
        /// <summary>流数据 BlockID</summary>
        public ulong BlockId { get; set; }
        /// <summary>时间戳</summary>
        public ulong Timestamp { get; set; }
        /// <summary>事件相关的属性名列集合</summary>
        public IReadOnlyList<string> Parameters { get; set; }
#endif
    }
}
