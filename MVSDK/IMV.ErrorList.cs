using System.Runtime.InteropServices;

namespace MVSDK
{
    internal static partial class IMV
    {
        /// <summary>加载失败的属性信息</summary>
        public struct ErrorList
        {
            /// <summary>加载失败的属性个数</summary>
            public uint Count;
            /// <summary>加载失败的属性集合，上限128</summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_ERROR_LIST_NUM)]
            public String[] Parameters;
        }
    }
}
