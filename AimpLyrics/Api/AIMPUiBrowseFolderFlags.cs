using System;

namespace Aimp4.Api
{
    [Flags]
    public enum AIMPUiBrowseFolderFlags
    {
        None = 0,
        CustomPaths = 1,
        MultiSelect = 2,
    }
}