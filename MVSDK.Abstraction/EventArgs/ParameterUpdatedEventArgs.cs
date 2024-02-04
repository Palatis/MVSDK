using System;
using System.Collections.Generic;

namespace MVSDK
{
    /// <summary>参数更新事件信息</summary>
    public class ParameterUpdatedEventArgs : EventArgs
    {
#if NET5_0_OR_GREATER

        /// <summary>是否是定时更新</summary>
        public bool IsPolled { get; init; }
        /// <summary>更新的参数名称集合</summary>
        public IReadOnlyList<string> Parameters { get; init; }
#else
        /// <summary>是否是定时更新</summary>
        public bool IsPolled { get; set; }
        /// <summary>更新的参数名称集合</summary>
        public IReadOnlyList<string> Parameters { get; set; }
#endif
    }
}