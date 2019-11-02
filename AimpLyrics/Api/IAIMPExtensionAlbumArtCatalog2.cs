using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-4578-416C-6241-727443617432")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPExtensionAlbumArtCatalog2
    {
        IntPtr GetIcon(); // HIcon
        IAIMPString GetName();
        IAIMPImageContainer Show(IAIMPString fileUri, IAIMPString artist, IAIMPString album);
        IAIMPImageContainer Show2(IAIMPFileInfo fileInfo);
    }
}