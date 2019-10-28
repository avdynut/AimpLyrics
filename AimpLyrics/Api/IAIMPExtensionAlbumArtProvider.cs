using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-4578-7441-6C62-417274507276")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPExtensionAlbumArtProvider
    {
        IAIMPImageContainer Get(IAIMPString fileUri, IAIMPString artist, IAIMPString album, IAIMPPropertyList options);

        [PreserveSig]
        AIMPAlbumArtProviderCategory GetCategory();
    }
}