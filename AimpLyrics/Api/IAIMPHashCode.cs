using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-4861-7368-436F-646500000000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPHashCode
    {
        [PreserveSig]
        int GetHashCode();
        void Recalculate();
    }
}