using System.Diagnostics;

namespace MVSDK
{
    internal static class StatusCodeExtensions
    {
        [DebuggerHidden]
        public static void ThrowIfError(this StatusCode status)
        {
            switch (status)
            {
                case StatusCode.Success: break;
                //case StatusCode.Error:
                //case StatusCode.InvalidHandle:
                //case StatusCode.InvalidParam:
                //case StatusCode.InvalidFrameHandle:
                //case StatusCode.InvalidFrame:
                //case StatusCode.InvalidResources:
                //case StatusCode.InvalidIPAddress:
                //case StatusCode.NoMemory:
                //case StatusCode.InsufficientMemory:
                //case StatusCode.WrongPropertyType:
                //case StatusCode.InvalidAccess:
                //case StatusCode.InvalidRange:
                //case StatusCode.NotSupported:
                default:
                    throw new HuarayException(status);
            }
        }
    }
}