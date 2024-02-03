using System;
using System.Runtime.InteropServices;

namespace MVSDK
{
    public class DisposableFrame : IFrame, IDisposable
    {
        public IntPtr Data { get; }
        public uint Width { get; }
        public uint Height { get; }
        public uint Size { get; }
        public uint PaddingX { get; }
        public uint PaddingY { get; }
        public PixelType PixelType { get; }

        public DisposableFrame(PixelType type, IntPtr data, uint size, uint width, uint height, uint paddingX, uint paddingY)
        {
            Data = data;
            Size = size;
            PixelType = type;
            Width = width;
            Height = height;
            PaddingX = paddingX;
            PaddingY = paddingY;
        }

        #region IDisposable
        private bool _DisposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!_DisposedValue)
            {
                if (disposing) { }

                Marshal.FreeHGlobal(Data);
                _DisposedValue = true;
            }
        }

        ~DisposableFrame() => Dispose(false);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}