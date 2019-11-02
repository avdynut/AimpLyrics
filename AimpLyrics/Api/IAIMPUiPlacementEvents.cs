using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756945-766E-7442-6F75-6E6473000000")]
    [ComImport]
    public interface IAIMPUiPlacementEvents
    {
        void OnBoundsChanged([MarshalAs(UnmanagedType.IUnknown)] object sender);
    }
}