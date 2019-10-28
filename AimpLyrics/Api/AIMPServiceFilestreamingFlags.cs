using System;

namespace Aimp4.Api
{
    [Flags]
    public enum AIMPServiceFileStreamingFlags
    {
        None = 0,
        CreateNew = 1,
        ReadWrite = 2,
        MapToMemory = 4,
    }
}