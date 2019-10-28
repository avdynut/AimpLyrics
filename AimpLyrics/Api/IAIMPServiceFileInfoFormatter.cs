using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-5372-7646-6C49-6E66466D7400")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPServiceFileInfoFormatter
    {
        IAIMPString Format(IAIMPString template, IAIMPFileInfo fileInfo, int reserved, [MarshalAs(UnmanagedType.IUnknown)] object additionalInfo);
    }
}