using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-4572-7249-6E66-6F0000000000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPErrorInfo
    {

        void GetInfo(out int errorCode, out IAIMPString message, out IAIMPString details);
        IAIMPString GetInfoFormatted();
        void SetInfo(int errorCode, IAIMPString message, IAIMPString details);
    }
}