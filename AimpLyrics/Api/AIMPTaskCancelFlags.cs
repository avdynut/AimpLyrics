using System;

namespace Aimp4.Api
{
    [Flags]
    public enum AIMPTaskCancelFlags
    {
        None = 0,
        WaitFor = 0x1,
    }
}