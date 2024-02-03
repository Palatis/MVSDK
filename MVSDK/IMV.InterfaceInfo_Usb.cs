using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace MVSDK
{
    internal static partial class IMV
    {
        /// <summary>USB接口信息</summary>
        public struct InterfaceInfo_Usb
        {
            /// <summary>USB接口描述信息</summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string Description;
            /// <summary>USB接口Vendor ID</summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string VendorID;
            /// <summary>USB接口设备ID</summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string ProductID;
            /// <summary>USB接口Subsystem ID</summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string SubsystemID;
            /// <summary>USB接口Revision</summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string Revision;
            /// <summary>USB接口speed</summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string Speed;
            /// <summary>保留</summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
            [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
            [SuppressMessage("CodeQuality", "IDE0051")]
            private readonly byte[] chReserved;
        }
    }
}
