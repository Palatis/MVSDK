using System.Runtime.InteropServices;

namespace MVSDK
{
    internal static partial class IMV
    {
        /// <summary>枚举属性的枚举值信息</summary>
        public readonly struct EnumEntry
        {
            /// <summary>枚举值</summary>
            public readonly ulong Value;
            /// <summary>symbol 名</summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public readonly string Name;
        }
    }
}
