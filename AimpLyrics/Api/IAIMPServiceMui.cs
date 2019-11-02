using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-5372-764D-5549-000000000000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPServiceMui
    {
        IAIMPString GetName();
        IAIMPString GetValue(IAIMPString keyPath);
        IAIMPString GetValuePart(IAIMPString keyPath, int part);
    }
}