namespace MVSDK
{
    /// <summary>枚举：图像转换Bayer格式所用的算法</summary>
    public enum BayerDemosaicAlgorithm
    {
        /// <summary>最近邻</summary>
        NearestNeighbor = 0,
        /// <summary>双线性</summary>
        Bilinear = 1,
        /// <summary>边缘检测</summary>
        EdgeSensing = 2,
        /// <summary>不支持</summary>
        NotSupport = 0x000000FF,
    }
}