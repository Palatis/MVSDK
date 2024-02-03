using MVSDK.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace MVSDK
{
    public static class DeviceEnumerator
    {
        /// <summary>枚举设备</summary>
        /// <param name="type">[IN] 待枚举的接口类型, 类型可任意组合,如 interfaceTypeGige | interfaceTypeUsb3</param>
        /// <returns>設備資訊清單</returns>
        /// <remarks>
        /// <para>1. 当 type = <see cref="InterfaceType.All"/> 时，枚举所有接口下的在线设备</para>
        /// <para>2. 当 type = <see cref="InterfaceType.GigE"/> 时，枚举所有 GigE 网口下的在线设备</para>
        /// <para>3. 当 type = <see cref="InterfaceType.USB3"/> 时，枚举所有 USB 接口下的在线设备</para>
        /// <para>4. 当 type = <see cref="InterfaceType.CameraLink"/> 时，枚举所有 CameraLink 接口下的在线设备</para>
        /// <para>5. 当 type = <see cref="InterfaceType.PCIe"/> 时，枚举所有 PCIe 接口下的在线设备</para>
        /// <para>该接口下的 type 支持任意接口类型的组合。如，若枚举所有 GigE 网口和 USB3 接口下的在线设备时，可将 type 设置为 <c>InterfaceType.GigE | InterfaceType.USB3</c>，其它接口类型组合以此类推。</para>
        /// </remarks>
        /// <exception cref="HuarayException" />
        public static IEnumerable<DeviceInformation> Enumerate(in InterfaceType type = InterfaceType.All)
        {
            var devices = new IMV.DeviceList();
            IMVApi.IMV_EnumDevices(ref devices, type).ThrowIfError();
            return NativeHelper
                .FromArray<IMV.DeviceInfo>(devices.Devices, devices.Count)
                .Select(NativeHelper.ToManaged);
        }

        /// <summary>以单播形式枚举设备, 仅限 GigE 设备使用</summary>
        /// <param name="address">[IN] 设备的IP地址</param>
        /// <returns>设备列表</returns>
        /// <exception cref="HuarayException" />
        public static IEnumerable<DeviceInformation> Enumerate(in IPAddress address)
        {
            var devices = new IMV.DeviceList();
            IMVApi.IMV_EnumDevicesByUnicast(ref devices, $"{address}").ThrowIfError();
            return NativeHelper
                .FromArray<IMV.DeviceInfo>(devices.Devices, devices.Count)
                .Select(NativeHelper.ToManaged);
        }
    }
}