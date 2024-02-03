using System.Net;

namespace MVSDK
{
    public partial class DeviceInformation
    {
        public class GigEVision : DeviceInformation
        {
#if NET5_0_OR_GREATER
            public LinkConfiguration LinkConfigOptions { get; init; }
            public LinkConfiguration LinkConfigCurrent { get; init; }

            public string DeviceMACAddress { get; init; }
            public IPAddress DeviceIPAddress { get; init; }
            public IPAddress DeviceSubnetMask { get; init; }
            public IPAddress DeviceDefaultGateway { get; init; }
            public string DeviceProtocolVersion { get; init; }
            public bool IsDeviceAddressValid { get; init; }

            public string InterfaceDescription { get; init; }
            public string InterfaceMACAddress { get; init; }
            public IPAddress InterfaceIPAddress { get; init; }
            public IPAddress InterfaceSubnetMask { get; init; }
            public IPAddress InterfaceDefaultGateway { get; init; }
#else
            public LinkConfiguration LinkConfigOptions { get; set; }
            public LinkConfiguration LinkConfigCurrent { get; set; }

            public string DeviceMACAddress { get; set; }
            public IPAddress DeviceIPAddress { get; set; }
            public IPAddress DeviceSubnetMask { get; set; }
            public IPAddress DeviceDefaultGateway { get; set; }
            public string DeviceProtocolVersion { get; set; }
            public bool IsDeviceAddressValid { get; set; }

            public string InterfaceDescription { get; set; }
            public string InterfaceMACAddress { get; set; }
            public IPAddress InterfaceIPAddress { get; set; }
            public IPAddress InterfaceSubnetMask { get; set; }
            public IPAddress InterfaceDefaultGateway { get; set; }
#endif
        }
    }
}