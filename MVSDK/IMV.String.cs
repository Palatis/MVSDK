using System.Runtime.InteropServices;

namespace MVSDK
{
    internal static partial class IMV
    {
        /// <summary>字符串信息</summary>
        public struct String
        {
            /// <summary>字符串.长度不超过256</summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string Value;
        }
    }
}
