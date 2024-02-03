using System.Runtime.InteropServices;

namespace MVSDK
{
    internal static partial class IMV
    {
        /// <summary>统计流信息</summary>
        [StructLayout(LayoutKind.Explicit)]
        public struct StreamStatisticsInfo
        {
            /// <summary>设备类型</summary>
            [FieldOffset(0)]
            public CameraType nCameraType;
            /// <summary>PCIE设备统计信息</summary>
            [FieldOffset(8)]
            public StreamStatisticsInfo_PCIe PCIeStatisticsInfo;
            /// <summary>U3V设备统计信息</summary>
            [FieldOffset(8)]
            public StreamStatisticsInfo_U3v USB3StatisticsInfo;
            /// <summary>Gige设备统计信息</summary>
            [FieldOffset(8)]
            public StreamStatisticsInfo_GigE GigEStatisticsInfo;
        }
    }
}
