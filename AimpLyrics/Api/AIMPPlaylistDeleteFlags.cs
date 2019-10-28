using System;

namespace Aimp4.Api
{
    [Flags]
    public enum AIMPPlaylistDeleteFlags
    {
        None = 0,
        Physically = 1,
        NoConfirmation = 2,
    }
}