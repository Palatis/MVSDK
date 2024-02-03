using System;
using System.Collections.Generic;

namespace MVSDK
{
    public class MessageChannelEventArgs : EventArgs
    {
#if NET5_0_OR_GREATER
        public ushort EventId { get; init; }
        public ushort ChannelId { get; init; }
        public ulong BlockId { get; init; }
        public ulong Timestamp { get; init; }
        public IReadOnlyList<string> Parameters { get; init; }
#else
        public ushort EventId { get; set; }
        public ushort ChannelId { get; set; }
        public ulong BlockId { get; set; }
        public ulong Timestamp { get; set; }
        public IReadOnlyList<string> Parameters { get; set; }
#endif
    }
}
