using System;

namespace Aimp4.Api
{
    [Flags]
    public enum AIMPServiceFileinfoFlags
    {
        None = 0,
        DontUseAudioDecoders = 1,
    }
}