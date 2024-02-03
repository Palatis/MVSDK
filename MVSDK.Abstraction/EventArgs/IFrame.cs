using System;

namespace MVSDK
{
    public interface IFrame
    {
        /// <summary>帧图像数据的内存首地址</summary>
        IntPtr Data { get; }
        /// <summary>图像宽度</summary>
        uint Width { get; }
        /// <summary>图像高度</summary>
        uint Height { get; }
        /// <summary>图像paddingX(仅对GigE/Usb/PCIe相机有效)</summary>
        uint PaddingX { get; }
        /// <summary>图像paddingY(仅对GigE/Usb/PCIe相机有效)</summary>
        uint PaddingY { get; }
        /// <summary>图像大小</summary>
        uint Size { get; }
        /// <summary>图像像素格式</summary>
        PixelType PixelType { get; }
    }
}