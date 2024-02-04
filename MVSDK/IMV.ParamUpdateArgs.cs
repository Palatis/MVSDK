using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace MVSDK
{
    internal static partial class IMV
    {
        public unsafe struct ParamUpdateArgs
        {
            public readonly bool IsPolled;
            [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
            [SuppressMessage("CodeQuality", "IDE0051")]
            private fixed uint Reserved[10];
            public readonly uint ParameterCount;
            public readonly IntPtr Parameters;
        }
    }
}