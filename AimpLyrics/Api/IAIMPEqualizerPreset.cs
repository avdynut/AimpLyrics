using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-4571-5072-7374-000000000000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPEqualizerPreset
    {

        IAIMPString GetName();
        void SetName(IAIMPString name);
        double GetBandValue(int bandIndex);
        void SetBandValue(int bandIndex, double value);
    }
}