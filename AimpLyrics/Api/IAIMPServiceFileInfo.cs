using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-5372-7646-696C-65496E666F00")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPServiceFileInfo
    {
        // File Info
        void GetFileInfoFromFileURI(IAIMPString fileUri, AIMPServiceFileinfoFlags flags, IAIMPFileInfo info);
        void GetFileInfoFromStream(IAIMPStream stream, AIMPServiceFileinfoFlags flags, IAIMPFileInfo info);
        // Files
        IAIMPVirtualFile GetVirtualFile(IAIMPString fileUri, uint flags);
    }
}