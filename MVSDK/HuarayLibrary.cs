using System.Runtime.InteropServices;

namespace MVSDK
{
    public static class HuarayLibrary
    {
        /// <summary>获取版本信息</summary>
        public static string Version => Marshal.PtrToStringAnsi(IMVApi.IMV_GetVersion()) ?? string.Empty;
    }
}