using System;

namespace Aimp4.Api
{
    [Flags]
    public enum AIMPUiKeyModifiers: ushort
    {
        None = 0,
        Alt = 1,
        Ctrl = 2,
        Shift = 4,
    }
}