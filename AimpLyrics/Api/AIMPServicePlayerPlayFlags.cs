using System;

namespace Aimp4.Api
{
    [Flags]
    public enum AIMPServicePlayerPlayFlags
    {
        None = 0,
        FromPlaylist = 1,
        FromPlaylistCanAdd = 2,
        WithoutAddingToPlaylist = 4,
    }
}