using System;

namespace Aimp4.Api
{
    [Flags]
    public enum AIMPPlaylistCloseFlags
    {
        None = 0,
        ForceRemove = 1,
        ForceUnload = 2,
    }
}