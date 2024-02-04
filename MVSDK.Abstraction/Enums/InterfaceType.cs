using System;

namespace MVSDK
{
    /// <summary>枚举：接口类型</summary>
    [Flags]
    public enum InterfaceType : uint
    {
        /// <summary>忽略接口类型</summary>
        All = 0,
        /// <summary>GigE 接口类型</summary>
        GigE = 1,
        /// <summary>USB3 接口类型</summary>
        USB3 = 2,
        /// <summary>CameraLink 接口类型</summary>
        CameraLink = 4,
        /// <summary>PCIe 接口类型</summary>
        PCIe = 8,
        /// <summary>无效接口类型</summary>
        Invalid = 0xFFFFFFFF,
    }
}