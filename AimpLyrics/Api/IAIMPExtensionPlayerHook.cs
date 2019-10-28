using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-4578-7450-6C72-486F6F6B0000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPExtensionPlayerHook
    {
        void OnCheckUrl(IAIMPString url, ref int handled); // ref bool handled
    }
}