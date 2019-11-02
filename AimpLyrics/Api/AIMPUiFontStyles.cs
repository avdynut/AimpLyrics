using System;

namespace Aimp4.Api
{
    [Flags]
    public enum AIMPUiFontStyles
    {
        None = 0,
        Bold = 1,
        Italic = 2,
        Underline = 4,
        Strikeout = 8,
    }
}