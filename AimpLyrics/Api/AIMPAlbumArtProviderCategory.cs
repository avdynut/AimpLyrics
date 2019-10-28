using System;

namespace Aimp4.Api
{
    [Flags]
    public enum AIMPAlbumArtProviderCategory
    {
        Mask = 0xF,
        Tags = 0,
        File = 1,
        Internet = 2,
    }
}