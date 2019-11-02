using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756945-766E-744D-6F75-736500000000")]
    [ComImport]
    public interface IAIMPUiMouseEvents
    {
        void OnMouseDoubleClick([MarshalAs(UnmanagedType.IUnknown)] object sender, AIMPUiMouseButton button, int x, int y, AIMPUiKeyModifiers modifiers);
        void OnMouseDown([MarshalAs(UnmanagedType.IUnknown)] object sender, AIMPUiMouseButton button, int x, int y, AIMPUiKeyModifiers modifiers);
        void OnMouseLeave([MarshalAs(UnmanagedType.IUnknown)] object sender);
        void OnMouseMove([MarshalAs(UnmanagedType.IUnknown)] object sender, int x, int y, AIMPUiKeyModifiers modifiers);
        void OnMouseUp([MarshalAs(UnmanagedType.IUnknown)] object sender, AIMPUiMouseButton button, int x, int y, AIMPUiKeyModifiers modifiers);
    }
}