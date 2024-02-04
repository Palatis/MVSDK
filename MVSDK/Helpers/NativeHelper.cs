using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;

namespace MVSDK.Helpers
{
    internal static class NativeHelper
    {
        public static TStruct FromBytes<TStruct>(ref byte[] bytes)
            where TStruct : struct
        {
            var pinned = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            try { return Marshal.PtrToStructure<TStruct>(pinned.AddrOfPinnedObject()); }
            finally { pinned.Free(); }
        }

        public static IEnumerable<TStruct> FromArray<TStruct>(IntPtr ptr, uint count)
            where TStruct : struct
        {
            var size = Marshal.SizeOf<TStruct>();
            for (int i = 0; i < count; ++i)
                yield return Marshal.PtrToStructure<TStruct>(ptr + size * i);
        }

        public static DeviceInformation ToManaged(this IMV.DeviceInfo device, int index)
        {
            switch (device.CameraType)
            {
                case CameraType.GigEVision:
                    {
                        var dinfo = FromBytes<IMV.DeviceInfo_GigE>(ref device.DeviceSpecificInfo);
                        var iinfo = FromBytes<IMV.InterfaceInfo_GigE>(ref device.InterfaceInfo);

                        return new DeviceInformation.GigEVision()
                        {
                            CameraIndex = index,
                            CameraType = device.CameraType,
                            InterfaceType = device.InterfaceType,
                            InterfaceName = device.InterfaceName,

                            CameraKey = device.CameraKey,
                            UserDefinedName = device.UserDefinedName,
                            SerialNumber = device.SerialNumber,
                            VendorName = device.VendorName,
                            ModelName = device.ModelName,
                            VenderInfo = device.VenderInfo,
                            DeviceVersion = device.DeviceVersion,

                            LinkConfigOptions = (LinkConfiguration)dinfo.LinkConfigOptions,
                            LinkConfigCurrent = (LinkConfiguration)dinfo.LinkConfigCurrent,
                            DeviceMACAddress = dinfo.MacAddress,
                            DeviceIPAddress = IPAddress.Parse(dinfo.IPAddress),
                            DeviceSubnetMask = IPAddress.Parse(dinfo.SubnetMask),
                            DeviceDefaultGateway = IPAddress.Parse(dinfo.DefaultGateWay),
                            DeviceProtocolVersion = dinfo.ProtocolVersion,
                            IsDeviceAddressValid = Equals(dinfo.IsValid, "Valid"),

                            InterfaceDescription = iinfo.Description,
                            InterfaceMACAddress = iinfo.MacAddress,
                            InterfaceIPAddress = IPAddress.Parse(iinfo.IPAddress),
                            InterfaceSubnetMask = IPAddress.Parse(iinfo.SubnetMask),
                            InterfaceDefaultGateway = IPAddress.Parse(iinfo.DefaultGateWay),
                        };
                    }
                case CameraType.USB3Vision:
                    {
                        var dinfo = FromBytes<IMV.DeviceInfo_Usb>(ref device.DeviceSpecificInfo);
                        var iinfo = FromBytes<IMV.InterfaceInfo_Usb>(ref device.InterfaceInfo);

                        return new DeviceInformation.USB3Vision()
                        {
                            CameraIndex = index,
                            CameraType = device.CameraType,
                            InterfaceType = device.InterfaceType,
                            InterfaceName = device.InterfaceName,

                            CameraKey = device.CameraKey,
                            UserDefinedName = device.UserDefinedName,
                            SerialNumber = device.SerialNumber,
                            VendorName = device.VendorName,
                            ModelName = device.ModelName,
                            VenderInfo = device.VenderInfo,
                            DeviceVersion = device.DeviceVersion,

                            SpeedSupported =
                                (dinfo.IsLowSpeedSupported ? UsbSpeed.LowSpeed : UsbSpeed.None) |
                                (dinfo.IsFullSpeedSupported ? UsbSpeed.FullSpeed : UsbSpeed.None) |
                                (dinfo.IsHighSpeedSupported ? UsbSpeed.HighSpeed : UsbSpeed.None) |
                                (dinfo.IsSuperSpeedSupported ? UsbSpeed.SuperSpeed : UsbSpeed.None),
                            IsDriverInstalled = dinfo.IsDriverInstalled,
                            IsConfigurationValid = Equals(dinfo.IsConfigurationValid, "Valid"),
                            GenCPVersion = dinfo.GenCPVersion,
                            U3vVersion = dinfo.Version,
                            DeviceGuid = Guid.Parse(dinfo.DeviceGUID),
                            FamilyName = dinfo.FamilyName,
                            U3vSerialNumber = dinfo.SerialNumber,
                            CurrentSpeed = dinfo.Speed,
                            MaxPower = dinfo.MaxPower,

                            Description = iinfo.Description,
                            VendorId = iinfo.VendorID,
                            DeviceId = iinfo.ProductID,
                            SubSystemId = iinfo.SubsystemID,
                            Revision = iinfo.Revision,
                            InterfaceSpeed = iinfo.Speed,
                        };
                    }
                case CameraType.CameraLink:
                case CameraType.PCIeVision:
                case CameraType.Undefined:
                default:
                    return new DeviceInformation()
                    {
                        CameraIndex = index,
                        CameraType = device.CameraType,
                        InterfaceType = device.InterfaceType,
                        InterfaceName = device.InterfaceName,

                        CameraKey = device.CameraKey,
                        UserDefinedName = device.UserDefinedName,
                        SerialNumber = device.SerialNumber,
                        VendorName = device.VendorName,
                        ModelName = device.ModelName,
                        VenderInfo = device.VenderInfo,
                        DeviceVersion = device.DeviceVersion,
                    };
            }
        }

        public static ParameterUpdatedEventArgs ToEventArgs(this IMV.ParamUpdateArgs args) => new ParameterUpdatedEventArgs()
        {
            IsPolled = args.IsPolled,
            Parameters = FromArray<IMV.String>(args.Parameters, args.ParameterCount)
                .Select(str => str.Value)
                .ToImmutableArray(),
        };

        public static MessageChannelEventArgs ToEventArgs(this IMV.MessageChannelArgs args) => new MessageChannelEventArgs()
        {
            EventId = args.EventId,
            ChannelId = args.ChannelId,
            BlockId = args.BlockId,
            Timestamp = args.Timestamp,
            Parameters = FromArray<IMV.String>(args.Parameters, args.ParameterCount)
                .Select(str => str.Value)
                .ToImmutableArray(),
        };

        public static StreamEventArgs ToEventArgs(this IMV.StreamArgs args) => new StreamEventArgs()
        {
            ChannelId = args.ChannelId,
            BlockId = args.BlockId,
            Timestamp = args.Timestamp,
            StreamEventStatus = args.StreamEventStatus,
            Status = args.Status,
        };

        public static StreamStatisticsInfo ToManaged(this IMV.StreamStatisticsInfo info)
        {
            switch (info.nCameraType)
            {
                case CameraType.GigEVision:
                    return new StreamStatisticsInfo()
                    {
                        CameraType = info.nCameraType,
                        ImageError = info.GigEStatisticsInfo.ImageError,
                        LostPacketBlock = info.GigEStatisticsInfo.LostPacketBlock,
                        ImageReceived = info.GigEStatisticsInfo.ImageReceived,
                        FramesPerSecond = info.GigEStatisticsInfo.FramesPerSecond,
                        Bandwidthh = info.GigEStatisticsInfo.Bandwidth,
                    };
                case CameraType.USB3Vision:
                    return new StreamStatisticsInfo()
                    {
                        CameraType = info.nCameraType,
                        ImageError = info.USB3StatisticsInfo.ImageError,
                        LostPacketBlock = info.USB3StatisticsInfo.LostPacketBlock,
                        ImageReceived = info.USB3StatisticsInfo.ImageReceived,
                        FramesPerSecond = info.USB3StatisticsInfo.FramesPerSecond,
                        Bandwidthh = info.USB3StatisticsInfo.Bandwidth,
                    };
                case CameraType.PCIeVision:
                    return new StreamStatisticsInfo()
                    {
                        CameraType = info.nCameraType,
                        ImageError = info.PCIeStatisticsInfo.ImageError,
                        LostPacketBlock = info.PCIeStatisticsInfo.LostPacketBlock,
                        ImageReceived = info.PCIeStatisticsInfo.ImageReceived,
                        FramesPerSecond = info.PCIeStatisticsInfo.FramesPerSecond,
                        Bandwidthh = info.PCIeStatisticsInfo.Bandwidth,
                    };
                case CameraType.CameraLink:
                case CameraType.Undefined:
                default:
                    return new StreamStatisticsInfo()
                    {
                        CameraType = info.nCameraType,
                    };
            }
        }
    }
}