using System;

namespace Aimp4.Api
{
    [Flags]
    public enum AIMPPlaylistNotifications
    {
        None = 0,
        Name = 1,
        Selection = 2,
        PlaybackCursor = 4,
        ReadOnly = 8,
        FocusIndex = 16,
        Content = 32,
        FileInfo = 64,
        Statistics = 128,
        PlayingSwitchs = 256,
        Preimage = 512,
    }
}