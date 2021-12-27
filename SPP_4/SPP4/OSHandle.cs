using System;
using System.IO;
using System.Runtime.InteropServices;

namespace SPP4
{
    class OSHandle : IDisposable
    {
        [DllImport("Kernel32.dll")]
        private static extern bool CloseHandle(IntPtr handle);

        private IntPtr _handle;
        private bool _disposed;

        public OSHandle(IntPtr handle)
        {
            _handle = handle;
        }

        ~OSHandle()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (_disposed || _handle == IntPtr.Zero) return;
            lock (this)
            {
                CloseHandle(_handle);
                _handle = IntPtr.Zero;
                _disposed = true;
            }

            GC.SuppressFinalize(this);
        }
    }
}