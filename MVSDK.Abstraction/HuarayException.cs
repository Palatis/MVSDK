using System;

namespace MVSDK
{
    public class HuarayException : Exception
    {
        public StatusCode StatusCode { get; }
        public HuarayException(StatusCode status) :
            base(_FormatMessage(status))
        {
            StatusCode = status;
        }

        private static string _FormatMessage(StatusCode status) => $"{status}";
    }
}