using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("41494D50-4578-7472-6E4F-7074446C6700")]
    [ComImport]
    public interface IAIMPExternalSettingsDialog
    {
        void Show(IntPtr parentWindowHandle);
    }
}