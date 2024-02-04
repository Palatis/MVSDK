using System.Runtime.InteropServices;

namespace MVSDK
{
    internal static partial class IMV
    {
        [StructLayout(LayoutKind.Explicit)]
        public struct StreamStatisticsInfo
        {
            [FieldOffset(0)]
            public CameraType nCameraType;
            [FieldOffset(8)]
            public StreamStatisticsInfo_PCIe PCIeStatisticsInfo;
            [FieldOffset(8)]
            public StreamStatisticsInfo_U3v USB3StatisticsInfo;
            [FieldOffset(8)]
            public StreamStatisticsInfo_GigE GigEStatisticsInfo;
        }
    }
}
