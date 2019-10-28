using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-4163-7469-6F6E-000000000000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPAction: IAIMPPropertyList
    {
    }
}