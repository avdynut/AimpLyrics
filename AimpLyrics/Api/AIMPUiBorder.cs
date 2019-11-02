using System;

namespace Aimp4.Api
{
    [Flags]
    public enum AIMPUiBorder
    {
        None = 0,
        Left = 1,
        Top = 2,
        Right = 4,
        Bottom = 8,
    }
}