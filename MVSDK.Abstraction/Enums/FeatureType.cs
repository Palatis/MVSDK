namespace MVSDK
{
    /// <summary>枚举：属性类型</summary>
    public enum FeatureType : uint
    {
        /// <summary>寄存器节点</summary>
        Register = 0x80000000,
        /// <summary>未定义</summary>
        Undefined = 0x90000000,
        /// <summary>整型数</summary>
        Integer = 0x10000000,
        /// <summary>浮点数</summary>
        Float = 0x20000000,
        /// <summary>枚举</summary>
        Enumeration = 0x30000000,
        /// <summary>布尔</summary>
        Boolean = 0x40000000,
        /// <summary>字符串</summary>
        String = 0x50000000,
        /// <summary>命令</summary>
        Command = 0x60000000,
        /// <summary>分组节点</summary>
        Group = 0x70000000,
    }
}