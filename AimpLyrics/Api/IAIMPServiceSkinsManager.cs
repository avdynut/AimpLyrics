using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-5372-7653-6B69-6E734D6E6772")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPServiceSkinsManager
    {
        IAIMPObjectList EnumSkins();
        IAIMPSkinInfo GetSkinInfo(IAIMPString fileName);
        void Select(IAIMPString fileName);
        //
        void Install(IAIMPString fileName, AIMPSkinManagerInstallFlags flags);
        void Uninstall(IAIMPString fileName);
        // Tools
        void HSLToRGB(byte h, byte s, byte l, out byte r, out byte g, out byte b);
        void RGBToHSL(byte r, byte g, byte b, out byte h, out byte s, out byte l);
    }
}