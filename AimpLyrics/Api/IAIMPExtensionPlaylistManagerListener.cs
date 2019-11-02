using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-4578-7450-6C73-4D616E4C7472")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPExtensionPlaylistManagerListener
    {
        void PlaylistActivated(IAIMPPlaylist playlist);
        void PlaylistAdded(IAIMPPlaylist playlist);
        void PlaylistRemoved(IAIMPPlaylist playlist);
    }
}