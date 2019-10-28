using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-5372-7656-6572-496E666F0000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPServiceVersionInfo
    {
        IAIMPString FormatInfo();

        [PreserveSig]
        int GetBuildDate();

        [PreserveSig]
        AIMPBuildState GetBuildState();

        [PreserveSig]
        int GetBuildNumber();

        [PreserveSig]
        int GetVersionID();
    }
}