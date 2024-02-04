namespace MVSDK
{
    internal static class PixelTypeMasks
    {
        public const uint COLOR_MASK = 0xFF000000;
        public const uint BITS_PER_PIXEL_MASK = 0x00FF0000;
        public const uint GVSP_TYPE_MASK = 0x0000FFFF;

        public const uint MONO = 0x01000000;
        public const uint COLOR = 0x02000000;
        public const uint CUSTOM = 0x80000000;

        public const uint OCCUPY_1BIT = 0x00010000;
        public const uint OCCUPY_2BIT = 0x00020000;
        public const uint OCCUPY_4BIT = 0x00040000;
        public const uint OCCUPY_8BIT = 0x00080000;
        public const uint OCCUPY_12BIT = 0x000C0000;
        public const uint OCCUPY_16BIT = 0x00100000;
        public const uint OCCUPY_24BIT = 0x00180000;
        public const uint OCCUPY_32BIT = 0x00200000;
        public const uint OCCUPY_36BIT = 0x00240000;
        public const uint OCCUPY_48BIT = 0x00300000;
    }
}