using System;

namespace MVSDK
{
    [Flags]
    public enum UsbSpeed
    {
        None = 0,
        LowSpeed = 1,
        FullSpeed = 2,
        HighSpeed = 4,
        SuperSpeed = 8,
    }
}
