using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-5461-736B-4F77-6E6572000000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPTaskOwner
    {
        [return: MarshalAs(UnmanagedType.Bool)]
        [PreserveSig]
        bool IsCanceled();
    }
}