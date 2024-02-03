namespace MVSDK
{
    public partial class DeviceInformation
    {
#if NET5_0_OR_GREATER
        public int CameraIndex { get; init; }
        public CameraType CameraType { get; init; }
        public InterfaceType InterfaceType { get; init; }

        public string CameraKey { get; init; }
        public string UserDefinedName { get; init; }
        public string SerialNumber { get; init; }
        public string VendorName { get; init; }
        public string ModelName { get; init; }
        public string VenderInfo { get; init; }
        public string DeviceVersion { get; init; }
#else
        public int CameraIndex { get; set; }
        public CameraType CameraType { get; set; }
        public InterfaceType InterfaceType { get; set; }

        public string CameraKey { get; set; }
        public string UserDefinedName { get; set; }
        public string SerialNumber { get; set; }
        public string VendorName { get; set; }
        public string ModelName { get; set; }
        public string VenderInfo { get; set; }
        public string DeviceVersion { get; set; }
#endif
    }
}