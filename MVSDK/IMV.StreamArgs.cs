namespace MVSDK
{
    internal static partial class IMV
    {
        /// <summary>流事件信息</summary>
        public unsafe struct StreamArgs
        {
            /// <summary>流通道号</summary>
            public readonly uint ChannelId;
            /// <summary>流数据BlockID</summary>
            public readonly ulong BlockId;
            /// <summary>时间戳</summary>
            public readonly ulong Timestamp;
            /// <summary>流事件状态码</summary>
            public readonly EventStatus StreamEventStatus;
            /// <summary>事件状态错误码</summary>
            public readonly uint Status;
            /// <summary>预留字段</summary>
            private fixed uint nReserve[9];
        }
    }
}
