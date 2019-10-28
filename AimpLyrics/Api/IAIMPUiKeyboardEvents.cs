using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756945-766E-744B-6579-626F61726400")]
    [ComImport]
    public interface IAIMPUiKeyboardEvents
    {
        void OnEnter([MarshalAs(UnmanagedType.IUnknown)] object sender);
        void OnExit([MarshalAs(UnmanagedType.IUnknown)] object sender);
        void OnKeyDown([MarshalAs(UnmanagedType.IUnknown)] object sender, ref ushort key, AIMPUiKeyModifiers modifiers);
        void OnKeyPress([MarshalAs(UnmanagedType.IUnknown)] object sender, ref char key);
        void OnKeyUp([MarshalAs(UnmanagedType.IUnknown)] object sender, ref ushort key, AIMPUiKeyModifiers modifiers);
    }
}