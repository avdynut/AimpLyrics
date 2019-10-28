using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756957-6E64-5072-6F63-45766E747300")]
    [ComImport]
    public interface IAIMPUiWndProcEvents
    {
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool OnBeforeWndProc(uint message, IntPtr paramW, IntPtr paramL, ref IntPtr result);

        void OnAfterWndProc(uint message, IntPtr paramW, IntPtr paramL, ref IntPtr result);
    }
}