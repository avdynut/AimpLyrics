using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-4578-7441-7564-696F4465634F")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPExtensionAudioDecoderOld
    {
        IAIMPAudioDecoder CreateDecoder(IAIMPString fileName, AIMPDecoderFlags flags, IAIMPErrorInfo errorInfo);
    }
}