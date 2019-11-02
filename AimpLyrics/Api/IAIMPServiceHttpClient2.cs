using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-5372-7648-7474-70436C743200")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPServiceHttpClient2
    {
        IntPtr Post(IAIMPString url, AIMPHttpClientMethod method, AIMPHttpClientFlags flags, IAIMPStream answerData, IAIMPStream postData,
            IAIMPHttpClientEvents eventHandler, IAIMPConfig parameters);

        void Cancel(IntPtr taskId, AIMPHttpClientFlags flags);
    }
}