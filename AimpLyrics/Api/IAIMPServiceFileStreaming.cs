using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-5372-7646-696C-655374726D00")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPServiceFileStreaming
    {
        IAIMPStream CreateStreamForFile(IAIMPString fileName, AIMPServiceFileStreamingFlags flags, long offset, long size);
        void CreateStreamForFileURI(IAIMPString fileUri, out IAIMPVirtualFile virtualFile, out IAIMPStream stream);
    }
}