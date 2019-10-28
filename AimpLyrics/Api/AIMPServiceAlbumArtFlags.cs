using System;

namespace Aimp4.Api
{
    [Flags]
    public enum AIMPServiceAlbumArtFlags
    {
        None = 0,
        IgnoreCache = 1,
        Original = 2,
        WaitFor = 4,
    }
}