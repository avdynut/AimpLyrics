using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-4578-7446-696C-65496E666F45")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPExtensionFileInfoProviderEx
    {
        void GetFileInfo(IAIMPStream stream, IAIMPFileInfo info);
    }
}