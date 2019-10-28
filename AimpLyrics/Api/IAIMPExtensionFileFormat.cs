using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-4578-7446-696C-65466D740000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPExtensionFileFormat
    {
        IAIMPString GetDescription();
        IAIMPString GetExtList();
        AIMPServiceFileFormatsCategory GetFlags();
    }
}