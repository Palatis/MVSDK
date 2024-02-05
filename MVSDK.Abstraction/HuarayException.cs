using System;

namespace MVSDK
{
    public class HuarayException : Exception
    {
        public StatusCode StatusCode { get; }
        public HuarayException(StatusCode status, Exception inner = null) :
            base(_FormatMessage(status), inner)
        {
            StatusCode = status;
        }

        private static string _FormatMessage(StatusCode status) => $"{status}";
    }
}