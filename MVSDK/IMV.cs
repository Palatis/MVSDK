using System;
using System.Runtime.InteropServices;

namespace MVSDK
{
    /// <summary>数据结构类</summary>
    internal static partial class IMV
    {
        /// <summary>支持设备最大个数</summary>
        public const int MAX_DEVICE_ENUM_NUM = 100;
        /// <summary>字符串最大长度</summary>
        public const int MAX_STRING_LENTH = 256;
        /// <summary>失败属性列表最大长度</summary>
        public const int MAX_ERROR_LIST_NUM = 128;

        /// <summary>ExposureEnd事件ID</summary>
        public const int MSG_EVENT_ID_EXPOSURE_END = 0x9001;
        /// <summary>FrameTrigger事件ID</summary>
        public const int MSG_EVENT_ID_FRAME_TRIGGER = 0x9002;
        /// <summary>FrameStart事件ID</summary>
        public const int MSG_EVENT_ID_FRAME_START = 0x9003;
        /// <summary>AcquisitionStart事件ID</summary>
        public const int MSG_EVENT_ID_ACQ_START = 0x9004;
        /// <summary>AcquisitionTrigger事件ID</summary>
        public const int MSG_EVENT_ID_ACQ_TRIGGER = 0x9005;
        /// <summary>ReadOut事件ID</summary>
        public const int MSG_EVENT_ID_DATA_READ_OUT = 0x9006;

        /// <summary>设备连接状态事件回调函数声明</summary>
        /// <param name="args">[in] 回调时主动推送的设备连接状态事件信息</param>
        /// <param name="state">[in] 用户自定义数据</param>
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        internal delegate void ConnectCallBackFunc(ref ConnectArgs args, IntPtr state);

        /// <summary>参数更新事件回调函数声明</summary>
        /// <param name="pParamUpdateArg">[in] 回调时主动推送的参数更新事件信息</param>
        /// <param name="state">[in] 用户自定义数据</param>
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        internal delegate void ParamUpdateCallBackFunc(ref ParamUpdateArgs pParamUpdateArg, IntPtr state);

        /// <summary>流事件回调函数声明</summary>
        /// <param name="args">[in] 回调时主动推送的流事件信息</param>
        /// <param name="state">[in] 用户自定义数据</param>
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        internal delegate void StreamCallBackFunc(ref StreamArgs args, IntPtr state);

        /// <summary>消息通道事件回调函数声明</summary>
        /// <param name="args">[in] 回调时主动推送的消息通道事件信息</param>
        /// <param name="state">[in] 用户自定义数据</param>
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        internal delegate void MsgChannelCallBackFunc(ref MessageChannelArgs args, IntPtr state);

        /// <summary>帧数据信息回调函数声明</summary>
        /// <param name="frame">[in]回调时主动推送的帧信息</param>
        /// <param name="state">[in] 用户自定义数据</param>
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        internal delegate void FrameCallBackFunc(ref FrameArgs frame, IntPtr state);
    }
}