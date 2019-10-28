using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-4F70-7444-6C67-4672616D6500")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPOptionsDialogFrame
    {
        IAIMPString GetName();

        [PreserveSig]
        IntPtr CreateFrame(IntPtr parentWnd);

        void DestroyFrame();
        void Notification(AIMPOptionsDialogNotification notification);
    }
}