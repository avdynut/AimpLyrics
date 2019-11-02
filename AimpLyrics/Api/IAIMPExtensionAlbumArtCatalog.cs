using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-4578-7441-6C62-417274436174")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPExtensionAlbumArtCatalog
    {
        IntPtr GetIcon(); // HIcon
        IAIMPString GetName();
        IAIMPImageContainer Show(IAIMPString fileUri, IAIMPString artist, IAIMPString album);
    }
}