using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756942-7277-7346-6C64-72446C670000")]
    [ComImport]
    public interface IAIMPUiBrowseFolderDialog
    {
        IAIMPObjectList Execute(IntPtr ownerWnd, AIMPUiBrowseFolderFlags flags, IAIMPString defaultPath);
    }
}