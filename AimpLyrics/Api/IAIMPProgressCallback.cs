using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-5072-6F67-7265-737343420000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface  IAIMPProgressCallback
    {
        [return: MarshalAs(UnmanagedType.Bool)]
        bool Process(float progress);
    }
}