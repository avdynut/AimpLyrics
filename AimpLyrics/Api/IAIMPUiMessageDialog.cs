using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("6175694D-7367-446C-6700-000000000000")]
    [ComImport]
    public interface IAIMPUiMessageDialog
    {
        void Execute(IntPtr ownerWnd, IAIMPString caption, IAIMPString text, uint flags);
    }
}