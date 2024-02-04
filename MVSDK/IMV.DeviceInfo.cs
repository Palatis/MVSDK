using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace MVSDK
{
    internal static partial class IMV
    {
        public partial struct DeviceInfo
        {
            public CameraType CameraType;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            [SuppressMessage("CodeQuality", "IDE0051")]
            private readonly int[] CameraReserved1;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string CameraKey;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string UserDefinedName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string SerialNumber;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string VendorName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string ModelName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string VenderInfo;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string DeviceVersion;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1280)]
            [SuppressMessage("CodeQuality", "IDE0051")]
            private readonly byte[] CameraReserved2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3096)]
            public byte[] DeviceSpecificInfo;
            public InterfaceType InterfaceType;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            [SuppressMessage("CodeQuality", "IDE0051")]
            private readonly int[] InterfaceReserved1;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENTH)]
            public string InterfaceName;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1280)]
            [SuppressMessage("CodeQuality", "IDE0051")]
            private readonly byte[] InterfaceReserved2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2560)]
            public byte[] InterfaceInfo;
        }
    }
}
