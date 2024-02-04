namespace MVSDK
{
    /// <summary>枚举：抓图策略</summary>
    public enum StreamingStrategy
    {
        /// <summary>按到达顺序处理图片</summary>
        Sequential,
        /// <summary>获取最新的图片</summary>
        LatestImage,
        /// <summary>等待获取下一张图片 (只针对 GigE 相机)</summary>
        UpcomingImage,
        /// <summary>未定义</summary>
        Undefined,
    }
}