using System;

namespace MVSDK
{
    public partial class DeviceInformation
    {
        public class USB3Vision : DeviceInformation
        {
#if NET5_0_OR_GREATER
            public UsbSpeed SpeedSupported { get; init; }
            public bool IsDriverInstalled { get; init; }
            public bool IsConfigurationValid { get; init; }
            public string GenCPVersion { get; init; }
            public string U3vVersion { get; init; }
            public Guid DeviceGuid { get; init; }
            public string FamilyName { get; init; }
            public string U3vSerialNumber { get; init; }
            public string CurrentSpeed { get; init; }
            public string MaxPower { get; init; }

            public string Description { get; init; }
            public string VendorId { get; init; }
            public string DeviceId { get; init; }
            public string SubSystemId { get; init; }
            public string Revision { get; init; }
            public string InterfaceSpeed { get; init; }
#else
            public UsbSpeed SpeedSupported { get; set; }
            public bool IsDriverInstalled { get; set; }
            public bool IsConfigurationValid { get; set; }
            public string GenCPVersion { get; set; }
            public string U3vVersion { get; set; }
            public Guid DeviceGuid { get; set; }
            public string FamilyName { get; set; }
            public string U3vSerialNumber { get; set; }
            public string CurrentSpeed { get; set; }
            public string MaxPower { get; set; }

            public string Description { get; set; }
            public string VendorId { get; set; }
            public string DeviceId { get; set; }
            public string SubSystemId { get; set; }
            public string Revision { get; set; }
            public string InterfaceSpeed { get; set; }
#endif
        }
    }
}