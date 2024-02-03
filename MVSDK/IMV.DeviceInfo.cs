using System.Runtime.InteropServices;

namespace MVSDK
{
    internal static partial class IMV
    {
        /// <summary>设备通用信息</summary>
        public partial struct DeviceInfo
        {
            /// <summary>设备类别</summary>
            public CameraType CameraType;
            /// <summary>保留</summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            private int[] CameraReserved1;
            /// <summary>厂商:序列号</summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string CameraKey;
            /// <summary>用户自定义名</summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string UserDefinedName;
            /// <summary>设备序列号</summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string SerialNumber;
            /// <summary>厂商</summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string VendorName;
            /// <summary>设备型号</summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string ModelName;
            /// <summary>设备制造信息</summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string VenderInfo;
            /// <summary>设备版本</summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string DeviceVersion;
            /// <summary>保留</summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1280)]
            private byte[] CameraReserved2;
            /// <summary>设备信息</summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3096)]
            public byte[] DeviceSpecificInfo;
            /// <summary>接口类别</summary>
            public InterfaceType InterfaceType;
            /// <summary>保留</summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            private int[] InterfaceReserved1;
            /// <summary>接口名</summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string InterfaceName;
            /// <summary>保留</summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1280)]
            private byte[] InterfaceReserved2;
            /// <summary>接口信息</summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2560)]
            public byte[] InterfaceInfo;
        }
    }
}
