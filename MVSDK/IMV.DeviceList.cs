using System;

namespace MVSDK
{
    internal static partial class IMV
    {
        /// <summary>设备信息列表</summary>
        public unsafe readonly struct DeviceList
        {
            /// <summary>设备数量</summary>
            public readonly uint Count;
            /// <summary>设备息列表(SDK内部缓存)，最多100设备</summary>
            public readonly IntPtr Devices;
        }
    }
}
