using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("41494D50-5372-764D-656E-754D6E677200")]
    [ComImport]
    public interface IAIMPServiceMenuManager
    {
        IAIMPMenuItem GetBuiltIn(AIMPBuildInMenu id);
        IAIMPMenuItem GetById(IAIMPString id);
    }
}