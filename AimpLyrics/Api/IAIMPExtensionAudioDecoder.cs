using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-4578-7441-7564-696F44656300")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPExtensionAudioDecoder
    {
        IAIMPAudioDecoder CreateDecoder(IAIMPStream stream, AIMPDecoderFlags flags, IAIMPErrorInfo errorInfo);
    }
}