namespace MVSDK
{
    /// <summary>枚举：访问权限</summary>
    public enum CameraAccessPermission
    {
        /// <summary>GigE 相机没有被连接</summary>
        Open = 0,
        /// <summary>独占访问权限</summary>
        Exclusive = 1,
        /// <summary>非独占可读访问权限</summary>
        Control = 2,
        /// <summary>切换控制访问权限</summary>
        ControlWithSwitchOver = 3,
        /// <summary>无法确定</summary>
        Unknown = 0x000000FE,
        /// <summary>未定义访问权限</summary>
        Undefined = 0x000000FF,
    }
}