using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-5461-736B-5072-696F72697479")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPTaskPriority
    {
        [PreserveSig]
        AIMPTaskPriority GetPriority();
    }
}