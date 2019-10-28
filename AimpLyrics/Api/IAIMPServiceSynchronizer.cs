using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-5372-7653-796E-637200000000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPServiceSynchronizer
    {
        void ExecuteInMainThread(IAIMPTask task, [MarshalAs(UnmanagedType.Bool)] bool executeNow);
    }
}