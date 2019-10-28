using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("4941494D-5053-7276-416C-624172744368")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPServiceAlbumArtCache
    {
        void Flush(IAIMPString artist, IAIMPString album);
        void Flush2(IAIMPString fileUri);
        void FlushAll();
    }
}