using System;

namespace Aimp4.Api
{
    [Flags]
    public enum AIMPVisualFlags
    {
        None = 0,
        RqdDataWave = 1,
        RqdDataSpectrum = 2,
        NotSuspend = 4,
    }
}