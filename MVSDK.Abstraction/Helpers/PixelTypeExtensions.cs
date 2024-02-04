using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVSDK.Helpers
{
    public static class PixelTypeExtensions
    {
        public static bool IsGrayscale(this PixelType type) =>
            ((uint)type | PixelTypeMasks.COLOR_MASK) == PixelTypeMasks.MONO;

        public static bool IsColored(this PixelType type) =>
            ((uint)type | PixelTypeMasks.COLOR_MASK) == PixelTypeMasks.COLOR;

        public static uint GetBitsPerPixel(this PixelType format) =>
            ((uint)format & PixelTypeMasks.BITS_PER_PIXEL_MASK) >> 16;

        public static uint GetGvspType(this PixelType format) =>
            (uint)format & PixelTypeMasks.GVSP_TYPE_MASK;
    }
}
