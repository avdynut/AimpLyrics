using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756945-766E-7444-7261-770000000000")]
    [ComImport]
    public interface IAIMPUiDrawEvents
    {
        void OnDraw([MarshalAs(UnmanagedType.IUnknown)] object sender, IntPtr hDc, RECT rect);
    }
}