using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-4578-416C-6241-727450727632")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPExtensionAlbumArtProvider2
    {
        IAIMPImageContainer Get(IAIMPString fileUri, IAIMPString artist, IAIMPString album, IAIMPPropertyList options);

        [PreserveSig]
        AIMPAlbumArtProviderCategory GetCategory();

        IAIMPImageContainer Get2(IAIMPFileInfo fileInfo, IAIMPPropertyList options);
    }
}