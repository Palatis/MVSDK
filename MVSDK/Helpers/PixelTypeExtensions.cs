namespace MVSDK.Helpers
{
    internal static class PixelTypeExtensions
    {
        public static uint GetEffectiveBpp(this PixelType format) =>
            ((uint)format & 0x00ff0000) >> 16;
    }
}
