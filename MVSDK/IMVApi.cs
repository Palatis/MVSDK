using System;
using System.Runtime.InteropServices;

namespace MVSDK
{
    internal static partial class IMVApi
    {
        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr IMV_GetVersion();

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_EnumDevices(ref IMV.DeviceList devices, InterfaceType ifType);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_EnumDevicesByUnicast(ref IMV.DeviceList devices, string ipAddress);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_CreateHandle(ref IntPtr handle, CreateHandleMode mode, IntPtr identifier);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_DestroyHandle(IntPtr handle);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_GetDeviceInfo(IntPtr handle, ref IMV.DeviceInfo info);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_Open(IntPtr handle);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_OpenEx(IntPtr handle, CameraAccessPermission permission);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool IMV_IsOpen(IntPtr handle);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_Close(IntPtr handle);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_GIGE_ForceIpAddress(IntPtr handle, string pIpAddress, string pSubnetMask, string pGateway);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_GIGE_GetAccessPermission(IntPtr handle, ref CameraAccessPermission permission);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_GIGE_SetAnswerTimeout(IntPtr handle, uint timeout);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_DownLoadGenICamXML(IntPtr handle, string pFullFileName);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_SaveDeviceCfg(IntPtr handle, string pFullFileName);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_LoadDeviceCfg(IntPtr handle, string pFullFileName, ref IMV.ErrorList pErrorList);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_WriteUserPrivateData(IntPtr handle, IntPtr pBuffer, ref uint pLength);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_ReadUserPrivateData(IntPtr handle, IntPtr pBuffer, ref uint pLength);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_WriteUARTData(IntPtr handle, IntPtr pBuffer, ref uint pLength);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_ReadUARTData(IntPtr handle, IntPtr pBuffer, ref uint pLength);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_SubscribeConnectArg(IntPtr handle, IMV.ConnectCallBackFunc proc, IntPtr pUser);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_SubscribeParamUpdateArg(IntPtr handle, IMV.ParamUpdateCallBackFunc proc, IntPtr pUser);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_SubscribeStreamArg(IntPtr handle, IMV.StreamCallBackFunc proc, IntPtr pUser);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_SubscribeMsgChannelArg(IntPtr handle, IMV.MsgChannelCallBackFunc proc, IntPtr pUser);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_SetBufferCount(IntPtr handle, uint nSize);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_ClearFrameBuffer(IntPtr handle);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_GIGE_SetInterPacketTimeout(IntPtr handle, uint nTimeout);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_GIGE_SetSingleResendMaxPacketNum(IntPtr handle, uint maxPacketNum);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_GIGE_SetMaxLostPacketNum(IntPtr handle, uint maxLostPacketNum);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_USB_SetUrbTransfer(IntPtr handle, uint nNum, uint nSize);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_StartGrabbing(IntPtr handle);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_StartGrabbingEx(IntPtr handle, ulong numFrames, StreamingStrategy strategy);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool IMV_IsGrabbing(IntPtr handle);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_StopGrabbing(IntPtr handle);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_AttachGrabbing(IntPtr handle, IMV.FrameCallBackFunc proc, IntPtr pUser);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_GetFrame(IntPtr handle, ref FrameArgs frame, uint time);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_ReleaseFrame(IntPtr handle, ref FrameArgs frame);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_CloneFrame(IntPtr handle, ref FrameArgs src, ref FrameArgs dst);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_GetChunkDataByIndex(IntPtr handle, ref FrameArgs frame, uint index, ref IMV.ChunkDataInfo pChunkDataInfo);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_GetStatisticsInfo(IntPtr handle, ref IMV.StreamStatisticsInfo param);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_ResetStatisticsInfo(IntPtr handle);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool IMV_FeatureIsAvailable(IntPtr handle, string pFeatureName);

        [DllImport("MVSDKmd.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern bool IMV_FeatureIsReadable(IntPtr handle, string pFeatureName);

        [DllImport("MVSDKmd.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern bool IMV_FeatureIsWriteable(IntPtr handle, string pFeatureName);

        [DllImport("MVSDKmd.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern bool IMV_FeatureIsStreamable(IntPtr handle, string pFeatureName);

        [DllImport("MVSDKmd.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern bool IMV_FeatureIsValid(IntPtr handle, string pFeatureName);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool IMV_GetFeatureType(IntPtr handle, string pFeatureName, ref FeatureType pPropertyType);

        [DllImport("MVSDKmd.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_GetIntFeatureValue(IntPtr handle, string pFeatureName, ref long value);

        [DllImport("MVSDKmd.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_GetIntFeatureMin(IntPtr handle, string pFeatureName, ref long value);

        [DllImport("MVSDKmd.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_GetIntFeatureMax(IntPtr handle, string pFeatureName, ref long value);

        [DllImport("MVSDKmd.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_GetIntFeatureInc(IntPtr handle, string pFeatureName, ref long value);

        [DllImport("MVSDKmd.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_SetIntFeatureValue(IntPtr handle, string pFeatureName, long value);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_GetDoubleFeatureValue(IntPtr handle, string pFeatureName, ref double value);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_GetDoubleFeatureMin(IntPtr handle, string pFeatureName, ref double value);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_GetDoubleFeatureMax(IntPtr handle, string pFeatureName, ref double value);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_SetDoubleFeatureValue(IntPtr handle, string pFeatureName, double value);

        [DllImport("MVSDKmd.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_GetBoolFeatureValue(IntPtr handle, string pFeatureName, ref bool value);

        [DllImport("MVSDKmd.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_SetBoolFeatureValue(IntPtr handle, string pFeatureName, bool boolValue);

        [DllImport("MVSDKmd.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_GetEnumFeatureValue(IntPtr handle, string pFeatureName, ref ulong pEnumValue);

        [DllImport("MVSDKmd.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_SetEnumFeatureValue(IntPtr handle, string pFeatureName, ulong enumValue);

        [DllImport("MVSDKmd.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_GetEnumFeatureSymbol(IntPtr handle, string pFeatureName, ref IMV.String pEnumSymbol);

        [DllImport("MVSDKmd.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_SetEnumFeatureSymbol(IntPtr handle, string pFeatureName, string pEnumSymbol);

        [DllImport("MVSDKmd.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_GetEnumFeatureEntryNum(IntPtr handle, string pFeatureName, ref uint pEntryNum);

        [DllImport("MVSDKmd.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_GetEnumFeatureEntrys(IntPtr handle, string pFeatureName, ref IMV.EnumEntryList pEnumEntryList);

        [DllImport("MVSDKmd.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_GetStringFeatureValue(IntPtr handle, string pFeatureName, ref IMV.String pStringValue);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_SetStringFeatureValue(IntPtr handle, string pFeatureName, string pStringValue);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_ExecuteCommandFeature(IntPtr handle, string pFullFileName);

        [DllImport("MVSDKmd.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_PixelConvert(IntPtr handle, ref IMV.ConvertImageParams convert);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_OpenRecord(IntPtr handle, ref IMV.RecordParams param);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_InputOneFrame(IntPtr handle, ref IMV.RecordFrameInfoParams record);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_CloseRecord(IntPtr handle);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_FlipImage(IntPtr handle, ref IMV.FlipImageParams pstFlipImageParam);

        [DllImport("MVSDKmd.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern StatusCode IMV_RotateImage(IntPtr handle, ref IMV.RotateImageParams pstRotateImageParam);
    }
}
