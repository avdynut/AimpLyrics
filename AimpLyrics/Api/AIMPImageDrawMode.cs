using System;

namespace Aimp4.Api
{
    [Flags]
    public enum AIMPImageDrawMode
    {
        Stretch = 0,
        Fill = 1,
        Fit = 2,
        Tile = 4,
        DefaultQuality = 0,
        LowQuality = 8,
        HighQuality = 16,
    }
}