using System;

namespace Aimp4.Api
{
    [Flags]
    public enum AIMPDecoderFlags
    {
        None = 0,
        ForceCreateInstance = 0x1000,
    }
}