using System;

namespace Aimp4.Api
{
    [Flags]
    public enum AIMPActionHotKeyModifiers: ushort
    {
        None = 0,
        Ctrl = 1,
        Alt = 2,
        Shift = 4,
        Win = 8,
    }
}