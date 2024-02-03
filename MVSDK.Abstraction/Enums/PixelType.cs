namespace MVSDK
{
    /// <summary>枚举：图像格式</summary>
    public enum PixelType : uint
    {
        /// <summary>Undefined</summary>
        Undefined = 0xFFFFFFFF,

        Mono1p = PixelTypeMasks.MONO | PixelTypeMasks.OCCUPY_1BIT | 0x0037,
        Mono2p = PixelTypeMasks.MONO | PixelTypeMasks.OCCUPY_2BIT | 0x0038,
        Mono4p = PixelTypeMasks.MONO | PixelTypeMasks.OCCUPY_4BIT | 0x0039,
        Mono8 = PixelTypeMasks.MONO | PixelTypeMasks.OCCUPY_8BIT | 0x0001,
        Mono8S = PixelTypeMasks.MONO | PixelTypeMasks.OCCUPY_8BIT | 0x0002,
        Mono10 = PixelTypeMasks.MONO | PixelTypeMasks.OCCUPY_16BIT | 0x0003,
        Mono12 = PixelTypeMasks.MONO | PixelTypeMasks.OCCUPY_16BIT | 0x0005,
        Mono14 = PixelTypeMasks.MONO | PixelTypeMasks.OCCUPY_16BIT | 0x0025,
        Mono16 = PixelTypeMasks.MONO | PixelTypeMasks.OCCUPY_16BIT | 0x0007,
        Mono10Packed = PixelTypeMasks.MONO | PixelTypeMasks.OCCUPY_12BIT | 0x0004,
        Mono12Packed = PixelTypeMasks.MONO | PixelTypeMasks.OCCUPY_12BIT | 0x0006,

        BayerGR8 = PixelTypeMasks.MONO | PixelTypeMasks.OCCUPY_8BIT | 0x0008,
        BayerRG8 = PixelTypeMasks.MONO | PixelTypeMasks.OCCUPY_8BIT | 0x0009,
        BayerGB8 = PixelTypeMasks.MONO | PixelTypeMasks.OCCUPY_8BIT | 0x000A,
        BayerBG8 = PixelTypeMasks.MONO | PixelTypeMasks.OCCUPY_8BIT | 0x000B,
        BayerGR10 = PixelTypeMasks.MONO | PixelTypeMasks.OCCUPY_16BIT | 0x000C,
        BayerRG10 = PixelTypeMasks.MONO | PixelTypeMasks.OCCUPY_16BIT | 0x000D,
        BayerGB10 = PixelTypeMasks.MONO | PixelTypeMasks.OCCUPY_16BIT | 0x000E,
        BayerBG10 = PixelTypeMasks.MONO | PixelTypeMasks.OCCUPY_16BIT | 0x000F,
        BayerGR12 = PixelTypeMasks.MONO | PixelTypeMasks.OCCUPY_16BIT | 0x0010,
        BayerRG12 = PixelTypeMasks.MONO | PixelTypeMasks.OCCUPY_16BIT | 0x0011,
        BayerGB12 = PixelTypeMasks.MONO | PixelTypeMasks.OCCUPY_16BIT | 0x0012,
        BayerBG12 = PixelTypeMasks.MONO | PixelTypeMasks.OCCUPY_16BIT | 0x0013,
        BayerGR16 = PixelTypeMasks.MONO | PixelTypeMasks.OCCUPY_16BIT | 0x002E,
        BayerRG16 = PixelTypeMasks.MONO | PixelTypeMasks.OCCUPY_16BIT | 0x002F,
        BayerGB16 = PixelTypeMasks.MONO | PixelTypeMasks.OCCUPY_16BIT | 0x0030,
        BayerBG16 = PixelTypeMasks.MONO | PixelTypeMasks.OCCUPY_16BIT | 0x0031,
        BayerGR10Packed = PixelTypeMasks.MONO | PixelTypeMasks.OCCUPY_12BIT | 0x0026,
        BayerRG10Packed = PixelTypeMasks.MONO | PixelTypeMasks.OCCUPY_12BIT | 0x0027,
        BayerGB10Packed = PixelTypeMasks.MONO | PixelTypeMasks.OCCUPY_12BIT | 0x0028,
        BayerBG10Packed = PixelTypeMasks.MONO | PixelTypeMasks.OCCUPY_12BIT | 0x0029,
        BayerGR12Packed = PixelTypeMasks.MONO | PixelTypeMasks.OCCUPY_12BIT | 0x002A,
        BayerRG12Packed = PixelTypeMasks.MONO | PixelTypeMasks.OCCUPY_12BIT | 0x002B,
        BayerGB12Packed = PixelTypeMasks.MONO | PixelTypeMasks.OCCUPY_12BIT | 0x002C,
        BayerBG12Packed = PixelTypeMasks.MONO | PixelTypeMasks.OCCUPY_12BIT | 0x002D,

        RGB8 = PixelTypeMasks.COLOR | PixelTypeMasks.OCCUPY_24BIT | 0x0014,
        BGR8 = PixelTypeMasks.COLOR | PixelTypeMasks.OCCUPY_24BIT | 0x0015,
        RGBA8 = PixelTypeMasks.COLOR | PixelTypeMasks.OCCUPY_32BIT | 0x0016,
        BGRA8 = PixelTypeMasks.COLOR | PixelTypeMasks.OCCUPY_32BIT | 0x0017,
        RGB10 = PixelTypeMasks.COLOR | PixelTypeMasks.OCCUPY_48BIT | 0x0018,
        BGR10 = PixelTypeMasks.COLOR | PixelTypeMasks.OCCUPY_48BIT | 0x0019,
        RGB12 = PixelTypeMasks.COLOR | PixelTypeMasks.OCCUPY_48BIT | 0x001A,
        BGR12 = PixelTypeMasks.COLOR | PixelTypeMasks.OCCUPY_48BIT | 0x001B,
        RGB16 = PixelTypeMasks.COLOR | PixelTypeMasks.OCCUPY_48BIT | 0x0033,
        RGB10P32 = PixelTypeMasks.COLOR | PixelTypeMasks.OCCUPY_32BIT | 0x001D,
        RGB565P = PixelTypeMasks.COLOR | PixelTypeMasks.OCCUPY_16BIT | 0x0035,
        BGR565P = PixelTypeMasks.COLOR | PixelTypeMasks.OCCUPY_16BIT | 0X0036,
        RGB10V1Packed = PixelTypeMasks.COLOR | PixelTypeMasks.OCCUPY_32BIT | 0x001C,
        RGB12V1Packed = PixelTypeMasks.COLOR | PixelTypeMasks.OCCUPY_36BIT | 0X0034,

        RGB8Planar = PixelTypeMasks.COLOR | PixelTypeMasks.OCCUPY_24BIT | 0x0021,
        RGB10Planar = PixelTypeMasks.COLOR | PixelTypeMasks.OCCUPY_48BIT | 0x0022,
        RGB12Planar = PixelTypeMasks.COLOR | PixelTypeMasks.OCCUPY_48BIT | 0x0023,
        RGB16Planar = PixelTypeMasks.COLOR | PixelTypeMasks.OCCUPY_48BIT | 0x0024,

        YUV411_8_UYYVYY = PixelTypeMasks.COLOR | PixelTypeMasks.OCCUPY_12BIT | 0x001E,
        YUV422_8_UYVY = PixelTypeMasks.COLOR | PixelTypeMasks.OCCUPY_16BIT | 0x001F,
        YUV422_8 = PixelTypeMasks.COLOR | PixelTypeMasks.OCCUPY_16BIT | 0x0032,
        YUV8_UYV = PixelTypeMasks.COLOR | PixelTypeMasks.OCCUPY_24BIT | 0x0020,
        YCbCr8CbYCr = PixelTypeMasks.COLOR | PixelTypeMasks.OCCUPY_24BIT | 0x003A,
        YCbCr422_8 = PixelTypeMasks.COLOR | PixelTypeMasks.OCCUPY_16BIT | 0x003B,
        YCbCr422_8_CbYCrY = PixelTypeMasks.COLOR | PixelTypeMasks.OCCUPY_16BIT | 0x0043,
        YCbCr411_8_CbYYCrYY = PixelTypeMasks.COLOR | PixelTypeMasks.OCCUPY_12BIT | 0x003C,
        YCbCr601_8_CbYCr = PixelTypeMasks.COLOR | PixelTypeMasks.OCCUPY_24BIT | 0x003D,
        YCbCr601_422_8 = PixelTypeMasks.COLOR | PixelTypeMasks.OCCUPY_16BIT | 0x003E,
        YCbCr601_422_8_CbYCrY = PixelTypeMasks.COLOR | PixelTypeMasks.OCCUPY_16BIT | 0x0044,
        YCbCr601_411_8_CbYYCrYY = PixelTypeMasks.COLOR | PixelTypeMasks.OCCUPY_12BIT | 0x003F,
        YCbCr709_8_CbYCr = PixelTypeMasks.COLOR | PixelTypeMasks.OCCUPY_24BIT | 0x0040,
        YCbCr709_422_8 = PixelTypeMasks.COLOR | PixelTypeMasks.OCCUPY_16BIT | 0x0041,
        YCbCr709_422_8_CbYCrY = PixelTypeMasks.COLOR | PixelTypeMasks.OCCUPY_16BIT | 0x0045,
        YCbCr709_411_8_CbYYCrYY = PixelTypeMasks.COLOR | PixelTypeMasks.OCCUPY_12BIT | 0x0042,

        /// <summary>BayererRG10p, currently used for specific project, please do not use them</summary>
        BayerRG10p = 0x010A0058,
        /// <summary>BayererRG12p, currently used for specific project, please do not use them</summary>
        BayerRG12p = 0x010C0059,
        /// <summary>mono1c, customized image format, used for binary output</summary>
        Mono1c = 0x012000FF,
        /// <summary>mono1e, customized image format, used for displaying connected domain</summary>
        Mono1e = 0x01080FFF,
    }
}