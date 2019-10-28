using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-5372-7650-6C73-4D616E000000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPServicePlaylistManager
    {
        // Creating Playlist
        IAIMPPlaylist CreatePlaylist(IAIMPString name, [MarshalAs(UnmanagedType.Bool)] bool activate);
        IAIMPPlaylist CreatePlaylistFromFile(IAIMPString fileName, [MarshalAs(UnmanagedType.Bool)] bool activate);

        // Active Playlist
        IAIMPPlaylist GetActivePlaylist();
        void SetActivePlaylist(IAIMPPlaylist playlist);

        // Playable Playlist
        IAIMPPlaylist GetPlayablePlaylist();

        // Loaded Playlists
        IAIMPPlaylist GetLoadedPlaylist(int index);
        IAIMPPlaylist GetLoadedPlaylistByName(IAIMPString name);
        int GetLoadedPlaylistCount();
        IAIMPPlaylist GetLoadedPlaylistById(IAIMPString id);
    }
}