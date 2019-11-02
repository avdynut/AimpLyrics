using System;

namespace Aimp4.Api
{
    [Flags]
    public enum AIMPPlaylistAddFlags
    {
        None = 0,
        NoCheckFormat = 1,
        NoExpand = 2,
        NoThreading = 4,
        FileInfo = 8,
    }
}