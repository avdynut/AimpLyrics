using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-5372-7641-7564-696F44656300")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPServiceAudioDecoders
    {
        IAIMPAudioDecoder CreateDecoderForStream(IAIMPStream stream, AIMPDecoderFlags flags, IAIMPErrorInfo errorInfo);
        IAIMPAudioDecoder CreateDecoderForFileURI(IAIMPString fileUri, AIMPDecoderFlags flags, IAIMPErrorInfo errorInfo);
    }
}