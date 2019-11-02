using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-4874-7470-436C-744576747300")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPHttpClientEvents
    {
        void OnAccept(IAIMPString contentType, long contentSize, ref int allow); // ref bool allow
        void OnComplete(IAIMPErrorInfo errorInfo, [MarshalAs(UnmanagedType.Bool)] bool canceled);
        void OnProgress(long downloaded, long total);
    }
}