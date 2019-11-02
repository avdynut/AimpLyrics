using System;

namespace Aimp4.Api
{
    [Flags]
    public enum AIMPHttpClientFlags
    {
        None = 0,
        WaitFor = 1,
        Utf8 = 2,
        LowPriority = 4,
        HighPriority = 8,
    }
}