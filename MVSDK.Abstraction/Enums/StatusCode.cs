namespace MVSDK
{
    public enum StatusCode : int
    {
        /// <summary>成功，无错误</summary>
        Success = 0,
        /// <summary>通用的错误</summary>
        Error = -101,
        /// <summary>错误或无效的句柄</summary>
        InvalidHandle = -102,
        /// <summary>错误的参数</summary>
        InvalidParam = -103,
        /// <summary>错误或无效的帧句柄</summary>
        InvalidFrameHandle = -104,
        /// <summary>无效的帧</summary>
        InvalidFrame = -105,
        /// <summary>相机/事件/流等资源无效</summary>
        InvalidResources = -106,
        /// <summary>设备与主机的IP网段不匹配</summary>
        InvalidIPAddress = -107,
        /// <summary>内存不足</summary>
        NoMemory = -108,
        /// <summary>传入的内存空间不足</summary>
        InsufficientMemory = -109,
        /// <summary>属性类型错误</summary>
        WrongPropertyType = -110,
        /// <summary>属性不可访问、或不能读/写、或读/写失败</summary>
        InvalidAccess = -111,
        /// <summary>属性值超出范围、或者不是步长整数倍</summary>
        InvalidRange = -112,
        /// <summary>设备不支持的功能</summary>
        NotSupported = -113,
        RestoreStream = -114,
        ReconnectDevice = -115,
        Timeout = -116,
    }
}
