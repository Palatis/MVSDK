using MVSDK.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;

namespace MVSDK
{
    /// <summary>相机类</summary>
    public class VideoCapture : IVideoCapture, IDisposable
    {
        public string CameraKey { get; }

        /// <summary>判断设备是否已打开</summary>
        public bool IsOpen => IMVApi.IMV_IsOpen(m_DevHandle);

        /// <summary>判断设备是否正在取流</summary>
        public bool IsGrabbing => IMVApi.IMV_IsGrabbing(m_DevHandle);

        /// <summary>获取设备的当前访问权限, 仅限 GigE 设备使用</summary>
        public CameraAccessPermission AccessPermission
        {
            get
            {
                var permission = CameraAccessPermission.Unknown;
                IMVApi.IMV_GIGE_GetAccessPermission(m_DevHandle, ref permission).ThrowIfError();
                return permission;
            }
        }

        /// <summary>设置设备对 SDK 命令的响应超时时间，仅限 GigE 设备使用</summary>
        public uint AnswerTimeout { set => IMVApi.IMV_GIGE_SetAnswerTimeout(m_DevHandle, value).ThrowIfError(); }
        /// <summary>设置驱动包间隔时间 (MS)，仅对 GigE 设备有效</summary>
        /// <remarks>触发模式尾包丢失重传机制</remarks>
        public uint InterPacketTimeout { set => IMVApi.IMV_GIGE_SetInterPacketTimeout(m_DevHandle, value).ThrowIfError(); }
        /// <summary>设置单次重传最大包个数，仅对 GigE 设备有效</summary>
        /// <remarks>为 0 时该功能无效</remarks>
        public uint MaxResend { set => IMVApi.IMV_GIGE_SetSingleResendMaxPacketNum(m_DevHandle, value).ThrowIfError(); }
        /// <summary>设置同一帧最大丢包的数量，仅对 GigE 设备有效</summary>
        /// <remarks>为 0 时该功能无效</remarks>
        public uint MaxLostPacket { set => IMVApi.IMV_GIGE_SetMaxLostPacketNum(m_DevHandle, value).ThrowIfError(); }
        /// <summary>设置帧数据缓存个数</summary>
        /// <remarks>不能在拉流过程中设置</remarks>
        public uint BufferCount { set => IMVApi.IMV_SetBufferCount(m_DevHandle, value).ThrowIfError(); }

        /// <summary>获取设备信息</summary>
        public DeviceInformation Information
        {
            get
            {
                var info = default(IMV.DeviceInfo);
                IMVApi.IMV_GetDeviceInfo(m_DevHandle, ref info).ThrowIfError();
                return info.ToManaged(-1);
            }
        }

        /// <summary>获取流统计信息(IMV_StartGrabbing / IMV_StartGrabbingEx执行后调用)</summary>
        public StreamStatisticsInfo Statistics
        {
            get
            {
                var info = default(IMV.StreamStatisticsInfo);
                IMVApi.IMV_GetStatisticsInfo(m_DevHandle, ref info).ThrowIfError();
                return info.ToManaged();
            }
        }

        public event EventHandler<EventArgs> Connected;
        public event EventHandler<EventArgs> Disconnected;
        public event EventHandler<ParameterUpdatedEventArgs> ParameterUpdated;
        public event EventHandler<StreamEventArgs> StreamEvent;
        public event EventHandler<MessageChannelEventArgs> MessageChannelEvent;
        public event EventHandler<ErrorEventArgs> Error;

        public event EventHandler<IFrame> FrameGrabbed;

        private readonly IntPtr m_DevHandle = IntPtr.Zero;

        private readonly IMV.StreamCallBackFunc _StreamCallback;
        private readonly IMV.ConnectCallBackFunc _ConnectCallback;
        private readonly IMV.MsgChannelCallBackFunc _MessageChannelCallback;
        private readonly IMV.ParamUpdateCallBackFunc _ParamUpdateCallback;

        private VideoCapture()
        {
            // deligate gets GC-ed from time-to-time, cache them here
            _StreamCallback = StreamCallback;
            _ConnectCallback = ConnectCallback;
            _MessageChannelCallback = MessageChannelCallback;
            _ParamUpdateCallback = ParamUpdateCallback;
        }

        /// <summary>通过指定标示符创建设备句柄，如设备键、设备自定义名、IP地址.</summary>
        /// <param name="camera">[IN] 设备键、设备自定义名、IP 地址</param>
        /// <param name="mode">[IN] 创建设备方式</param>
        public VideoCapture(string camera, CreateHandleMode mode) : this()
        {
            switch (mode)
            {
                case CreateHandleMode.ByCameraKey:
                case CreateHandleMode.ByUserDefinedName:
                    DeviceEnumerator.Enumerate(InterfaceType.All);
                    break;
                case CreateHandleMode.ByIPAddress:
                    DeviceEnumerator.Enumerate(IPAddress.Parse(camera));
                    break;
                case CreateHandleMode.ByScanIndex:
                default:
                    break;
            }

            IntPtr ptr = IntPtr.Zero;
            try
            {
                switch (mode)
                {
                    case CreateHandleMode.ByCameraKey:
                    case CreateHandleMode.ByUserDefinedName:
                    case CreateHandleMode.ByIPAddress:
                        ptr = Marshal.StringToHGlobalAnsi(camera ?? string.Empty);
                        break;
                    case CreateHandleMode.ByScanIndex:
                    default:
                        ptr = Marshal.AllocHGlobal(sizeof(int));
                        Marshal.WriteInt32(ptr, int.Parse(camera));
                        break;
                }
                IMVApi.IMV_CreateHandle(ref m_DevHandle, mode, ptr).ThrowIfError();
                CameraKey = Information.CameraKey;
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>通过指定索引创建设备句柄</summary>
        /// <param name="index">[IN] 指定索引</param>
        public VideoCapture(int index) :
            this($"{index}", CreateHandleMode.ByScanIndex)
        {
        }

        /// <summary>通过 IP 地址创建设备</summary>
        /// <param name="address">[IN] IP 地址</param>
        public VideoCapture(IPAddress address) :
            this($"{address}", CreateHandleMode.ByIPAddress)
        {
        }

        /// <summary>打开设备</summary>
        /// <param name="permission">控制通道权限</param>
        public void Open(CameraAccessPermission permission = CameraAccessPermission.Control)
        {
            IMVApi.IMV_OpenEx(m_DevHandle, permission).ThrowIfError();
            IMVApi.IMV_SubscribeConnectArg(m_DevHandle, _ConnectCallback, IntPtr.Zero).ThrowIfError();
            IMVApi.IMV_SubscribeMsgChannelArg(m_DevHandle, _MessageChannelCallback, IntPtr.Zero).ThrowIfError();
            IMVApi.IMV_SubscribeParamUpdateArg(m_DevHandle, _ParamUpdateCallback, IntPtr.Zero).ThrowIfError();
            IMVApi.IMV_SubscribeStreamArg(m_DevHandle, _StreamCallback, IntPtr.Zero).ThrowIfError();
            //IMVApi.IMV_AttachGrabbing(m_DevHandle, FrameGrabbedCallback, IntPtr.Zero).ThrowIfError();
        }

        /// <summary>关闭设备</summary>
        public void Close() => IMVApi.IMV_Close(m_DevHandle).ThrowIfError();

        /// <summary>修改设备IP, 仅限Gige设备使用</summary>
        /// <param name="address">[IN] IP地址</param>
        /// <param name="mask">[IN] 子网掩码</param>
        /// <param name="gateway">[IN] 默认网关</param>
        /// <remarks>
        /// <para>1、调用该函数时如果 mask 和 gateway 都设置了有效值，则以此有效值为准;</para>
        /// <para>2、调用该函数时如果 mask 和 gateway 都设置了 NULL，则内部实现时用它所连接网卡的子网掩码和网关代替</para>
        /// <para>3、调用该函数时如果 mask 和 gateway 两者中其中一个为 NULL，另一个非 NULL，则返回错误</para>
        /// </remarks>
        public void ForceIP(IPAddress address, IPAddress mask, IPAddress gateway) =>
            IMVApi.IMV_GIGE_ForceIpAddress(m_DevHandle, $"{address}", mask != null ? $"{mask}" : null, gateway != null ? $"{gateway}" : null).ThrowIfError();

        #region Callbacks
        private void StreamCallback(ref IMV.StreamArgs args, IntPtr state)
        {
            try { StreamEvent?.Invoke(this, args.ToEventArgs()); }
            catch { /* dont handle exception in event handler */ }
        }

        private void ParamUpdateCallback(ref IMV.ParamUpdateArgs args, IntPtr state)
        {
            try { ParameterUpdated?.Invoke(this, args.ToEventArgs()); }
            catch { /* dont handle exception in event handler */ }
        }

        private void MessageChannelCallback(ref IMV.MessageChannelArgs args, IntPtr state)
        {
            try { MessageChannelEvent?.Invoke(this, args.ToEventArgs()); }
            catch { /* dont handle exception in event handler */ }
        }

        private void ConnectCallback(ref IMV.ConnectArgs args, IntPtr state)
        {
            try
            {
                switch (args.EventType)
                {
                    case IMV.ConnectEventType.Connected: Connected?.Invoke(this, EventArgs.Empty); break;
                    case IMV.ConnectEventType.Disconnected: Disconnected?.Invoke(this, EventArgs.Empty); break;
                    default: break;
                }
            }
            catch { /* dont handle exception in event handler */ }
        }

        //private void FrameGrabbedCallback(ref FrameEventArgs frame, nint state) => 
        //    FrameGrabbed?.Invoke(this, frame);
        #endregion

        /// <summary>设置 U3V 设备的传输数据块的数量和大小，仅对 USB 设备有效</summary>
        /// <param name="num">[IN] 传输数据块的数量 (5 - 256)。高分辨率高帧率时可以适当增加该值；多台相机共同使用时，可以适当减小该值。</param>
        /// <param name="size">[IN] 传输数据块的大小 (8 - 512)，单位:KByte</param>
        public void SetUsbTransferParameters(uint num, uint size) => IMVApi.IMV_USB_SetUrbTransfer(m_DevHandle, num, size).ThrowIfError();

        /// <summary>下载设备描述XML文件，并保存到指定路径，如：D:\\xml.zip</summary>
        /// <param name="filename">[IN] 文件要保存的路径</param>
        public void DownLoadGenICamXML(string filename) => IMVApi.IMV_DownLoadGenICamXML(m_DevHandle, filename).ThrowIfError();

        /// <summary>保存设备配置到指定的位置。同名文件已存在时，覆盖。</summary>
        /// <param name="filename">[IN] 导出的设备配置文件全名(含路径)，如：D:\\config.xml 或 D:\\config.mvcfg</param>
        public void SaveDeviceConfig(string filename) => IMVApi.IMV_SaveDeviceCfg(m_DevHandle, filename).ThrowIfError();

        /// <summary>从文件加载设备xml配置</summary>
        /// <param name="filename">[IN] 设备配置(xml)文件全名(含路径)，如：D:\\config.xml 或 D:\\config.mvcfg</param>
        /// <returns>加载失败的属性名列表</returns>
        public IEnumerable<string> LoadDeviceConfig(string filename)
        {
            var errors = default(IMV.ErrorList);
            IMVApi.IMV_LoadDeviceCfg(m_DevHandle, filename, ref errors).ThrowIfError();
            return errors.Parameters
                .Take((int)errors.Count)
                .Select(str => str.Value)
                .ToImmutableArray();
        }

        /// <summary>
        /// 写用户自定义数据。相机内部保留32768字节用于用户存储自定义数据(此功能针对本品牌相机，其它品牌相机无此功能)
        /// </summary>
        /// <param name="pBuffer">[IN] 数据缓冲的指针</param>
        /// <param name="pLength">[IN] 期望写入的字节数 [OUT] 实际写入的字节数</param>
        /// <returns>成功，返回IMV_OK；错误，返回错误码</returns>
        public void WriteUserPrivateData(IntPtr pBuffer, ref uint pLength) => IMVApi.IMV_WriteUserPrivateData(m_DevHandle, pBuffer, ref pLength).ThrowIfError();

        /// <summary>
        /// 读用户自定义数据。相机内部保留32768字节用于用户存储自定义数据(此功能针对本品牌相机，其它品牌相机无此功能)
        /// </summary>
        /// <param name="pBuffer">[OUT] 数据缓冲的指针</param>
        /// <param name="pLength">[IN] 期望读出的字节数 [OUT] 实际读出的字节数</param>
        /// <returns>成功，返回IMV_OK；错误，返回错误码</returns>
        public void ReadUserPrivateData(IntPtr pBuffer, ref uint pLength) => IMVApi.IMV_ReadUserPrivateData(m_DevHandle, pBuffer, ref pLength).ThrowIfError();

        /// <summary>往相机串口寄存器写数据，每次写会清除掉上次的数据(此功能只支持包含串口功能的本品牌相机)</summary>
        /// <param name="pBuffer">[IN] 数据缓冲的指针</param>
        /// <param name="pLength">[IN] 期望写入的字节数 [OUT] 实际写入的字节数</param>
        /// <returns>成功，返回IMV_OK；错误，返回错误码</returns>
        public void WriteUARTData(IntPtr pBuffer, ref uint pLength) => IMVApi.IMV_WriteUARTData(m_DevHandle, pBuffer, ref pLength).ThrowIfError();

        /// <summary>从相机串口寄存器读取串口数据(此功能只支持包含串口功能的本品牌相机 )</summary>
        /// <param name="pBuffer">[OUT] 数据缓冲的指针</param>
        /// <param name="pLength">[IN] 期望读出的字节数 [OUT] 实际读出的字节数</param>
        /// <returns>成功，返回IMV_OK；错误，返回错误码</returns>
        public void ReadUARTData(IntPtr pBuffer, ref uint pLength) => IMVApi.IMV_ReadUARTData(m_DevHandle, pBuffer, ref pLength).ThrowIfError();

        /// <summary>清除帧数据缓存</summary>
        /// <returns>成功，返回IMV_OK；错误，返回错误码</returns>
        public void ClearFrameBuffer() => IMVApi.IMV_ClearFrameBuffer(m_DevHandle).ThrowIfError();

        #region Grabbing
        private Thread _GrabbingThread = null;

        private void GrabbingThreadStartInternal()
        {
            while (true)
            {
                try
                {
                    if (!(IsOpen && IsGrabbing))
                        break;

                    var frame = GetFrame(1000);
                    try { FrameGrabbed?.Invoke(this, frame); }
                    catch (Exception ex)
                    {
                        try { Error?.Invoke(this, new ErrorEventArgs(ex)); }
                        catch { /* dont handle exception in error event handler */ }
                    }
                    ReleaseFrame(ref frame);
                }
                catch (Exception ex)
                {
                    try { StopGrabbing(); } catch { }
                    try { Error?.Invoke(this, new ErrorEventArgs(ex)); }
                    catch { /* dont handle exception in error event handler */ }
                    break;
                }
            }
            try { ClearFrameBuffer(); } catch { }
            Interlocked.Exchange(ref _GrabbingThread, null);
        }

        /// <summary>开始取流</summary>
        /// <param name="frames">[IN] 允许最多的取帧数，达到指定取帧数后停止取流，如果为 0，表示忽略此参数连续取流 (IMV_StartGrabbing 默认 0)</param>
        /// <param name="strategy">[IN] 取流策略,(IMV_StartGrabbing默认使用 Sequential 策略取流)</param>
        public void StartGrabbing(ulong frames = 0, StreamingStrategy strategy = StreamingStrategy.Sequential)
        {
            IMVApi.IMV_StartGrabbingEx(m_DevHandle, frames, strategy).ThrowIfError();
            if (_GrabbingThread is null)
            {
                Interlocked.Exchange(ref _GrabbingThread, new Thread(GrabbingThreadStartInternal));
                _GrabbingThread.Start();
            }
        }

        /// <summary>停止取流</summary>
        /// <returns>成功，返回IMV_OK；错误，返回错误码</returns>
        public void StopGrabbing() => IMVApi.IMV_StopGrabbing(m_DevHandle).ThrowIfError();

        /// <summary>获取一帧图像(同步获取帧数据机制)</summary>
        /// <param name="frame">[OUT] 帧数据信息</param>
        /// <param name="timeout">[IN] 获取一帧图像的超时时间,INFINITE时表示无限等待,直到收到一帧数据或者停止取流。单位是毫秒</param>
        /// <returns>成功，返回IMV_OK；错误，返回错误码</returns>
        /// <remarks>
        /// <para>该接口不支持多线程调用。</para>
        /// <para>该同步获取帧机制和异步获取帧机制(IMV_AttachGrabbing)互斥,对于同一设备，系统中两者只能选其一。</para>
        /// <para>使用内部缓存获取图像，需要IMV_ReleaseFrame进行释放图像缓存。</para>
        /// </remarks>
        private FrameArgs GetFrame(in int timeout = Timeout.Infinite)
        {
            var frame = default(FrameArgs);
            IMVApi.IMV_GetFrame(m_DevHandle, ref frame, (uint)timeout).ThrowIfError();
            return frame;
        }

        /// <summary>释放图像缓存</summary>
        /// <param name="frame">[IN] 帧数据信息</param>
        /// <returns>成功，返回IMV_OK；错误，返回错误码</returns>
        public void ReleaseFrame(ref FrameArgs frame) => IMVApi.IMV_ReleaseFrame(m_DevHandle, ref frame).ThrowIfError();

        /// <summary>帧数据深拷贝克隆</summary>
        /// <param name="src">[IN] 克隆源帧数据信息</param>
        /// <param name="dst">[OUT] 新的帧数据信息</param>
        /// <remarks>使用IMV_ReleaseFrame进行释放图像缓存。</remarks>
        public void CloneFrame(ref FrameArgs src, ref FrameArgs dst) =>
            IMVApi.IMV_CloneFrame(m_DevHandle, ref src, ref dst).ThrowIfError();

        /// <summary>重置流统计信息 (StartGrabbing 执行后调用)</summary>
        public void ResetStatisticsInfo() => IMVApi.IMV_ResetStatisticsInfo(m_DevHandle).ThrowIfError();

        /// <summary>获取 Chunk 数据 (仅对 GigE / Usb 相机有效)</summary>
        /// <param name="frame">[IN] 帧数据信息</param>
        /// <param name="index">[IN] 索引ID</param>
        /// <returns>Chunk 数据</returns>
        public (uint ChunkId, IReadOnlyList<string> Parameters) GetChunkDataByIndex(ref FrameArgs frame, uint index)
        {
            var info = default(IMV.ChunkDataInfo);
            IMVApi.IMV_GetChunkDataByIndex(m_DevHandle, ref frame, index, ref info).ThrowIfError();
            return (
                info.ChunkId,
                NativeHelper.FromArray<IMV.String>(info.Parameters, info.ParameterCount)
                    .Select(str => str.Value)
                    .ToImmutableArray()
            );
        }
        #endregion

        #region Feature
        public bool IsFeatureAvailable(string name) => IMVApi.IMV_FeatureIsAvailable(m_DevHandle, name);
        public bool IsFeatureReadable(string name) => IMVApi.IMV_FeatureIsReadable(m_DevHandle, name);
        public bool IsFeatureWriteable(string name) => IMVApi.IMV_FeatureIsWriteable(m_DevHandle, name);
        public bool IsFeatureStreamable(string name) => IMVApi.IMV_FeatureIsStreamable(m_DevHandle, name);
        public bool IsFeatureValid(string name) => IMVApi.IMV_FeatureIsValid(m_DevHandle, name);

        /// <summary>获取属性类型</summary>
        /// <param name="pFeatureName">[IN] 属性名</param>
        /// <returns>属性类型false</returns>
        public FeatureType GetFeatureType(string name)
        {
            var type = default(FeatureType);
            if (IMVApi.IMV_GetFeatureType(m_DevHandle, name, ref type))
                return type;
            throw new HuarayException(StatusCode.InvalidParam);
        }

        public double GetFloatFeature(string name)
        {
            var value = default(double);
            IMVApi.IMV_GetDoubleFeatureValue(m_DevHandle, name, ref value).ThrowIfError();
            return value;
        }

        public void SetFloatFeature(string name, double value) => IMVApi.IMV_SetDoubleFeatureValue(m_DevHandle, name, value).ThrowIfError();

        public double GetFloatFeatureMin(string name)
        {
            var value = default(double);
            IMVApi.IMV_GetDoubleFeatureMin(m_DevHandle, name, ref value).ThrowIfError();
            return value;
        }

        public double GetFloatFeatureMax(string name)
        {
            var value = default(double);
            IMVApi.IMV_GetDoubleFeatureMax(m_DevHandle, name, ref value).ThrowIfError();
            return value;
        }

        public long GetIntFeature(string name)
        {
            var value = default(long);
            IMVApi.IMV_GetIntFeatureValue(m_DevHandle, name, ref value).ThrowIfError();
            return value;
        }

        public void SetIntFeature(string name, long value) => IMVApi.IMV_SetIntFeatureValue(m_DevHandle, name, value).ThrowIfError();

        public long GetIntFeatureInc(string name)
        {
            var value = default(long);
            IMVApi.IMV_GetIntFeatureInc(m_DevHandle, name, ref value).ThrowIfError();
            return value;
        }

        public long GetIntFeatureMin(string name)
        {
            var value = default(long);
            IMVApi.IMV_GetIntFeatureMin(m_DevHandle, name, ref value).ThrowIfError();
            return value;
        }

        public long GetIntFeatureMax(string name)
        {
            var value = default(long);
            IMVApi.IMV_GetIntFeatureMax(m_DevHandle, name, ref value).ThrowIfError();
            return value;
        }

        public bool GetBoolFeature(string name)
        {
            var value = default(bool);
            IMVApi.IMV_GetBoolFeatureValue(m_DevHandle, name, ref value).ThrowIfError();
            return value;
        }

        public void SetBoolFeature(string name, bool value) => IMVApi.IMV_SetBoolFeatureValue(m_DevHandle, name, value).ThrowIfError();

        public string GetStringFeature(string name)
        {
            var value = default(IMV.String);
            IMVApi.IMV_GetStringFeatureValue(m_DevHandle, name, ref value).ThrowIfError();
            return value.Value;
        }

        public void SetStringFeature(string name, string value) => IMVApi.IMV_SetStringFeatureValue(m_DevHandle, name, value).ThrowIfError();

        public ulong GetEnumFeature(string name)
        {
            var value = default(ulong);
            IMVApi.IMV_GetEnumFeatureValue(m_DevHandle, name, ref value).ThrowIfError();
            return value;
        }
        public void SetEnumFeature(string name, ulong value) => IMVApi.IMV_SetEnumFeatureValue(m_DevHandle, name, value).ThrowIfError();
        public void SetEnumFeature(string name, string value) => IMVApi.IMV_SetEnumFeatureSymbol(m_DevHandle, name, value).ThrowIfError();
        public string GetEnumFeatureAsSymbol(string name)
        {
            var value = default(IMV.String);
            ; IMVApi.IMV_GetEnumFeatureSymbol(m_DevHandle, name, ref value).ThrowIfError();
            return value.Value;
        }

        public IReadOnlyDictionary<string, ulong> GetEnumFeatureValues(string name)
        {
            var count = default(uint);
            IMVApi.IMV_GetEnumFeatureEntryNum(m_DevHandle, name, ref count).ThrowIfError();
            var values = default(IMV.EnumEntryList);
            values.EntryBufSize = (uint)(Marshal.SizeOf<IMV.EnumEntry>() * count);
            values.EntryBuf = Marshal.AllocHGlobal((int)values.EntryBufSize);
            try
            {
                IMVApi.IMV_GetEnumFeatureEntrys(m_DevHandle, name, ref values).ThrowIfError();
                return NativeHelper.FromArray<IMV.EnumEntry>(values.EntryBuf, count)
                    .ToImmutableDictionary(entry => entry.Name, entry => entry.Value);
            }
            finally
            {
                Marshal.FreeHGlobal(values.EntryBuf);
            }
        }

        /// <summary>执行命令属性</summary>
        /// <param name="name">[IN] 属性名</param>
        public void ExecuteCommandFeature(string name) => IMVApi.IMV_ExecuteCommandFeature(m_DevHandle, name).ThrowIfError();
        #endregion

        #region Recording
        /// <summary>打开录像</summary>
        /// <param name="filename">檔案名稱</param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="framerate"></param>
        /// <param name="quality"></param>
        /// <param name="type"></param>
        public void StartRecording(in string filename, in uint width = 0, in uint height = 0, in float framerate = 25.0f, in uint quality = 90, in VideoType type = VideoType.AVI)
        {
            var filePtr = Marshal.StringToHGlobalAnsi(filename);
            try
            {
                var param = new IMV.RecordParams()
                {
                    Width = width != 0 ? width : (uint)GetIntFeatureMax(StandardFeatures.SensorWidth),
                    Height = height != 0 ? height : (uint)GetIntFeatureMax(StandardFeatures.SensorHeight),
                    FameRate = framerate,
                    Quality = quality,
                    VideoType = type,
                    FilePath = filePtr,
                };
                IMVApi.IMV_OpenRecord(m_DevHandle, ref param).ThrowIfError();
            }
            finally
            {
                Marshal.FreeHGlobal(filePtr);
            }
        }

        /// <summary>录制一帧图像</summary>
        /// <param name="frames">[IN] 影格</param>
        /// <returns>成功，返回IMV_OK；错误，返回错误码</returns>
        public void RecordFrames(params IFrame[] frames)
        {
            var param = default(IMV.RecordFrameInfoParams);
            foreach (var frame in frames)
            {
                param.Data = frame.Data;
                param.DataLen = frame.Size;
                param.PaddingX = frame.PaddingX;
                param.PaddingY = frame.PaddingY;
                param.PixelType = frame.PixelType;
                IMVApi.IMV_InputOneFrame(m_DevHandle, ref param).ThrowIfError();
            }
        }

        /// <summary>关闭录像</summary>
        /// <returns>成功，返回IMV_OK；错误，返回错误码</returns>
        public void StopRecording() => IMVApi.IMV_CloseRecord(m_DevHandle).ThrowIfError();
        #endregion

        /// <summary>像素格式转换</summary>
        /// <param name="frame">[IN] 待转换的圖像</param>
        /// <param name="format">[IN] 目標像素格式</param>
        /// <returns>转换后的图像</returns>
        /// <remarks>
        /// <para>只支持转化成目标像素格式 RGB8 / BGR8 / Mono8 / BGRA8</para>
        /// <para>通过该接口将原始图像数据转换成用户所需的像素格式并存放在调用者指定内存中。</para>
        /// <para>像素格式为 YUV411Packed 的时，图像宽须能被 4 整除</para>
        /// <para>像素格式为 YUV422Packed 的时，图像宽须能被 2 整除</para>
        /// <para>像素格式为 YUYVPacked 的时，图像宽须能被 2 整除</para>
        /// <para>转换后的图像数据存储是从最上面第一行开始的，这个是相机数据的默认存储方向</para>
        /// </remarks>
        public IFrame ConvertImage(in IFrame frame, in PixelType format, in IntPtr buf, in uint bufSize)
        {
            if (frame.PixelType == format)
                return frame;

            switch (format)
            {
                case PixelType.Mono8:
                case PixelType.RGB8:
                case PixelType.BGR8:
                case PixelType.BGRA8:
                    break;
                default:
                    throw new InvalidEnumArgumentException(nameof(format), (int)format, typeof(PixelType));
            }

            var size = (int)(frame.Width * frame.Height * format.GetBitsPerPixel() + 7) / 8;
            var buffer = buf == IntPtr.Zero || size > bufSize
                ? Marshal.ReAllocHGlobal(buf, (IntPtr)size) : buf;
            var param = new IMV.ConvertImageParams()
            {
                Width = frame.Width,
                Height = frame.Height,
                SrcPixelType = frame.PixelType,
                SrcData = frame.Data,
                SrcDataLen = frame.Size,
                PaddingX = frame.PaddingX,
                PaddingY = frame.PaddingY,
                DemosaicAlgorithm = BayerDemosaicAlgorithm.Bilinear,

                DstPixelType = format,
                DstBuf = buffer,
                DstBufSize = (uint)size,
            };
            IMVApi.IMV_PixelConvert(m_DevHandle, ref param).ThrowIfError();
            return new DisposableFrame(
                param.DstPixelType, param.DstBuf, param.DstDataLen,
                frame.Width, frame.Height,
                frame.PaddingX, frame.PaddingY
            );
        }

        /// <summary>图像翻转</summary>
        /// <param name="frame">[IN] 待翻转的圖像</param>
        /// <param name="flip">[IN] 翻转方式</param>
        /// <returns>翻转后的图像</returns>
        /// <remarks>只支持像素格式 RGB8 / BGR8 / Mono8 的图像。</remarks>
        public IFrame FlipImage(in IFrame frame, in FlipType flip, in IntPtr buf, in uint bufSize)
        {
            switch (frame.PixelType)
            {
                case PixelType.RGB8:
                case PixelType.BGR8:
                case PixelType.Mono8:
                    break;
                default:
                    throw new InvalidEnumArgumentException(nameof(frame.PixelType), (int)frame.PixelType, typeof(PixelType));
            }

            var size = (int)(frame.Width * frame.Height * frame.PixelType.GetBitsPerPixel() + 7) / 8;
            var buffer = buf == IntPtr.Zero || size > bufSize
                ? Marshal.ReAllocHGlobal(buf, (IntPtr)size) : buf;
            var param = new IMV.FlipImageParams()
            {
                Width = frame.Width,
                Height = frame.Height,
                PixelType = frame.PixelType,
                FlipType = flip,
                SrcData = frame.Data,
                SrcDataLen = frame.Size,
                DstBuf = buffer,
                DstBufSize = frame.Size,
            };
            IMVApi.IMV_FlipImage(m_DevHandle, ref param).ThrowIfError();
            return new DisposableFrame(
                param.PixelType, param.DstBuf, param.DstDataLen,
                frame.Width, frame.Height,
                frame.PaddingX, frame.PaddingY
            );
        }

        /// <summary>图像顺时针旋转</summary>
        /// <param name="frame">[IN] 待旋转的圖像</param>
        /// <param name="angle">[IN] 旋转角度</param>
        /// <param name="buf"></param>
        /// <param name="bufSize"></param>
        /// <returns>旋转后的图像</returns>
        /// <remarks>只支持像素格式 RGB8 / BGR8 / Mono8 的图像。</remarks>
        public IFrame RotateImage(in IFrame frame, in RotationAngle angle, in IntPtr buf, in uint bufSize)
        {
            switch (frame.PixelType)
            {
                case PixelType.RGB8:
                case PixelType.BGR8:
                case PixelType.Mono8:
                    break;
                default:
                    throw new InvalidEnumArgumentException(nameof(frame.PixelType), (int)frame.PixelType, typeof(PixelType));
            }

            var size = (int)(frame.Width * frame.Height * frame.PixelType.GetBitsPerPixel() + 7) / 8;
            var buffer = buf == IntPtr.Zero || size > bufSize
                ? Marshal.ReAllocHGlobal(buf, (IntPtr)size) : buf;
            var param = new IMV.RotateImageParams()
            {
                Width = frame.Width,
                Height = frame.Height,
                PixelType = frame.PixelType,
                RotationAngle = angle,
                SrcData = frame.Data,
                SrcDataLen = frame.Size,
                DstBuf = buffer,
                DstBufSize = frame.Size,
            };
            IMVApi.IMV_RotateImage(m_DevHandle, ref param).ThrowIfError();
            return new DisposableFrame(
                param.PixelType, param.DstBuf, param.DstDataLen,
                frame.Width, frame.Height,
                frame.PaddingX, frame.PaddingY
            );
        }

        public override string ToString() => CameraKey;

        #region IDisposable
        private bool _DisposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!_DisposedValue)
            {
                if (disposing)
                {
                    try { StopGrabbing(); } catch { }
                    try { StopRecording(); } catch { }
                    try { Close(); } catch { }
                    _ = IMVApi.IMV_DestroyHandle(m_DevHandle);
                }

                _DisposedValue = true;
            }
        }

        // // TODO: 僅有當 'Dispose(bool disposing)' 具有會釋出非受控資源的程式碼時，才覆寫完成項
        //~HuarayCamera() { Dispose(false); }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}