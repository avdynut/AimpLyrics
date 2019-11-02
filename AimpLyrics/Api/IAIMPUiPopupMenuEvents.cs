using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756945-766E-7450-6F70-757000000000")]
    [ComImport]
    public interface IAIMPUiPopupMenuEvents
    {
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool OnContextPopup([MarshalAs(UnmanagedType.IUnknown)] object sender, int x, int y);
    }
}