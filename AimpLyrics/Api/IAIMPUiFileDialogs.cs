using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756946-696C-6544-6C67-730000000000")]
    [ComImport]
    public interface IAIMPUiFileDialogs
    {
        IAIMPString ExecuteOpenDialog(IntPtr ownerWnd, IAIMPString caption, IAIMPString filter);
        IAIMPObjectList ExecuteOpenDialog2(IntPtr ownerWnd, IAIMPString caption, IAIMPString filter);
        void ExecuteSaveDialog(IntPtr ownerWnd, IAIMPString caption, IAIMPString filter, out IAIMPString fileName, out int filterIndex);
    }
}