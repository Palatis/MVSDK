using System;

namespace MVSDK
{
    internal static partial class IMV
    {
        public unsafe readonly struct DeviceList
        {
            public readonly uint Count;
            public readonly IntPtr Devices;
        }
    }
}
