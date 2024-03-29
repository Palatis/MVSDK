﻿namespace MVSDK
{
    public static class StandardFeatures
    {
        // enum
        public const string PixelFormat = nameof(PixelFormat);
        public const string ExposureAuto = nameof(ExposureAuto);
        public const string ExposureMode = nameof(ExposureMode);
        public const string DeviceScanType = nameof(DeviceScanType);

        // double
        public const string ExposureTime = nameof(ExposureTime);
        public const string GainRaw = nameof(GainRaw);

        // integer
        public const string SensorWidth = nameof(SensorWidth);
        public const string SensorHeight = nameof(SensorHeight);

        // bool
        public const string AcquisitionStart = nameof(AcquisitionStart);
        public const string AcquisitionStop = nameof(AcquisitionStop);
    }
}