using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756945-766E-744D-6F75-736557686C00")]
    [ComImport]
    public interface IAIMPUiMouseWheelEvents
    {

        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool OnMouseWheel([MarshalAs(UnmanagedType.IUnknown)] object sender, int wheelDelta, int x, int y, AIMPUiKeyModifiers modifiers);
    }
}