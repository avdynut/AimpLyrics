using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756945-766E-7443-6861-6E6765000000")]
    [ComImport]
    public interface IAIMPUiChangeEvents
    {
        void OnChanged([MarshalAs(UnmanagedType.IUnknown)] object sender);
    }
}