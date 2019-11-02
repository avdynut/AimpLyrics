using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RGBQUAD 
    {
        public byte rgbBlue; 
        public byte rgbGreen; 
        public byte rgbRed; 
        public byte rgbReserved; 
    }
}