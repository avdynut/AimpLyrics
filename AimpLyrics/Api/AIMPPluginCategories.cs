using System;

namespace Aimp4.Api
{
    [Flags]
    public enum AIMPPluginCategories
    {
        None = 0,
        Addons = 1,
        Decoders = 2,
        Visuals = 4,
        Dsp = 8,
    }
}