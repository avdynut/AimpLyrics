using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-5372-7645-5150-727374730000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPServicePlayerEqualizerPresets
    {

        IAIMPEqualizerPreset Add(IAIMPString name);
        IAIMPEqualizerPreset FindByName(IAIMPString name);
        void Delete(IAIMPEqualizerPreset preset);
        void Delete2(int index);

        IAIMPEqualizerPreset GetPreset(int index);

        [PreserveSig]
        int GetPresetCount();
    }
}