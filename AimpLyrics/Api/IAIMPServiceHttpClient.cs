using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-5372-7648-7474-70436C740000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPServiceHttpClient
    {
        IntPtr Get(IAIMPString url, AIMPHttpClientFlags flags, IAIMPStream answerData, IAIMPHttpClientEvents eventHandler, IAIMPConfig parameters);

        IntPtr Post(IAIMPString url, AIMPHttpClientFlags flags, IAIMPStream answerData, IAIMPStream postData, IAIMPHttpClientEvents eventHandler,
            IAIMPConfig parameters);

        void Cancel(IntPtr taskId, AIMPHttpClientFlags flags);
    }
}