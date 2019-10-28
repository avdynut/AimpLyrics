using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-4874-7470-436C-744576747332")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPHttpClientEvents2
    {
        void OnAcceptHeaders(IAIMPString header, ref int allow); // ref bool allow
    }
}