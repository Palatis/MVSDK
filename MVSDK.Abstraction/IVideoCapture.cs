using System;
using System.Collections.Generic;
using System.Net;

namespace MVSDK
{
    public interface IVideoCapture
    {
        string CameraKey { get; }

        DeviceInformation Information { get; }
        StreamStatisticsInfo Statistics { get; }

        CameraAccessPermission AccessPermission { get; }

        uint AnswerTimeout { set; }
        uint BufferCount { set; }
        uint InterPacketTimeout { set; }
        uint MaxLostPacket { set; }
        uint MaxResend { set; }

        bool IsGrabbing { get; }
        bool IsOpen { get; }

        event EventHandler<EventArgs> Connected;
        event EventHandler<EventArgs> Disconnected;
        event EventHandler<IFrame> FrameGrabbed;
        event EventHandler<MessageChannelEventArgs> MessageChannelEvent;
        event EventHandler<ParameterUpdatedEventArgs> ParameterUpdated;
        event EventHandler<StreamEventArgs> StreamEvent;

        void SetUsbTransferParameters(uint num, uint size);

        void DownLoadGenICamXML(string filename);
        void SaveDeviceConfig(string filename);
        void ReadUARTData(IntPtr pBuffer, ref uint pLength);
        void WriteUARTData(IntPtr pBuffer, ref uint pLength);
        void ReadUserPrivateData(IntPtr pBuffer, ref uint pLength);
        void WriteUserPrivateData(IntPtr pBuffer, ref uint pLength);

        void ForceIP(IPAddress address, IPAddress mask, IPAddress gateway);

        void Open(CameraAccessPermission permission = CameraAccessPermission.Control);
        void Close();

        void ClearFrameBuffer();
        void ResetStatisticsInfo();

        void StartGrabbing(ulong frames = 0, StreamingStrategy strategy = StreamingStrategy.Sequential);
        void StopGrabbing();

        void StartRecording(in string filename, in uint width = 0, in uint height = 0, in float framerate = 25, in uint quality = 90, in VideoType type = VideoType.AVI);
        void RecordFrames(params IFrame[] frames);
        void StopRecording();

        bool IsFeatureAvailable(string name);
        bool IsFeatureWriteable(string name);
        bool IsFeatureReadable(string name);
        bool IsFeatureStreamable(string name);
        bool IsFeatureValid(string name);
        FeatureType GetFeatureType(string name);

        double GetFloatFeature(string name);
        void SetFloatFeature(string name, double value);
        double GetFloatFeatureMin(string name);
        double GetFloatFeatureMax(string name);

        long GetIntFeature(string name);
        void SetIntFeature(string name, long value);
        long GetIntFeatureInc(string name);
        long GetIntFeatureMin(string name);
        long GetIntFeatureMax(string name);

        bool GetBoolFeature(string name);
        void SetBoolFeature(string name, bool value);

        string GetStringFeature(string name);
        void SetStringFeature(string name, string value);

        ulong GetEnumFeature(string name);
        string GetEnumFeatureAsSymbol(string name);
        void SetEnumFeature(string name, ulong value);
        void SetEnumFeature(string name, string value);
        IReadOnlyDictionary<string, ulong> GetEnumFeatureValues(string name);

        void ExecuteCommandFeature(string name);

        IFrame ConvertImage(in IFrame frame, in PixelType format, in IntPtr buf, in uint bufSize);
        IFrame FlipImage(in IFrame frame, in FlipType flip, in IntPtr buf, in uint bufSize);
        IFrame RotateImage(in IFrame frame, in RotationAngle angle, in IntPtr buf, in uint bufSize);
    }
}