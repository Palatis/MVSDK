using System;

namespace MVSDK
{
    [Flags]
    public enum LinkConfiguration : uint
    {
        None = 0,
        PersistIP = 1,
        DHCP = 2,
        LLA = 4,
    }
}
