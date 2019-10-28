using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-5372-7645-5100-000000000000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPServicePlayerEqualizer
    {
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool GetActive();

        void SetActive([MarshalAs(UnmanagedType.Bool)] bool value);

        double GetBandValue(int bandIndex);
        void SetBandValue(int bandIndex, double value);

        IAIMPEqualizerPreset GetPreset();
        void SetPreset(IAIMPEqualizerPreset preset);
    }
}