using System;

namespace MVSDK
{
    public class StreamEventArgs : EventArgs
    {
#if NET5_0_OR_GREATER
        public uint ChannelId { get; init; }
        public ulong BlockId { get; init; }
        public ulong Timestamp { get; init; }
        public EventStatus StreamEventStatus { get; init; }
        public uint Status { get; init; }
#else
        public uint ChannelId { get; set; }
        public ulong BlockId { get; set; }
        public ulong Timestamp { get; set; }
        public EventStatus StreamEventStatus { get; set; }
        public uint Status { get; set; }
#endif
    }
}