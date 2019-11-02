using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-4578-7446-696C-65496E666F00")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPExtensionFileInfoProvider
    {
        void GetFileInfo(IAIMPString fileUri, IAIMPFileInfo info);
    }
}