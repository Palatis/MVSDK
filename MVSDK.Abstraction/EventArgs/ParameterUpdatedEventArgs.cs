using System;
using System.Collections.Generic;

namespace MVSDK
{
    public class ParameterUpdatedEventArgs : EventArgs
    {
#if NET5_0_OR_GREATER

        public bool IsPolled { get; init; }
        public IReadOnlyList<string> Parameters { get; init; }
#else
        public bool IsPolled { get; set; }
        public IReadOnlyList<string> Parameters { get; set; }
#endif
    }
}