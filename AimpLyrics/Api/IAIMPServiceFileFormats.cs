using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-5372-7646-696C-65466D747300")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPServiceFileFormats
    {
        IAIMPString GetFormats(uint flags);
        void IsSupported(IAIMPString fileName, uint flags); // todo: returns value in HRESULT
    }
}