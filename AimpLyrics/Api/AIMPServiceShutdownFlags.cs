using System;

namespace Aimp4.Api
{
    [Flags]
    public enum AIMPServiceShutdownFlags
    {
        None = 0,
        Hibernate = 1,
        PowerOff = 2,
        Sleep = 3,
        Reboot = 4,
        LogOff = 5,
        CloseApplication = 0x10,
        NoConfirm = 0x20
    }
}