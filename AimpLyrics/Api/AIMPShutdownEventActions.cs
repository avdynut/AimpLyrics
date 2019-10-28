using System;

namespace Aimp4.Api
{
    [Flags]
    public enum AIMPShutdownEventActions
    {
        None = 0,
        PausePlayback = 1,
        ShutdownPlayer = 2,
        ShutdownWindows = 4,
        ShutdownWindowsHibernate = 8,
        ShutdownWindowsSleep = 16,
    }
}