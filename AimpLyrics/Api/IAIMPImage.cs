using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-496D-6167-6500-000000000000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPImage
    {
        void LoadFromFile(IAIMPString fileName);
        void LoadFromStream(IAIMPStream stream);
        void SaveToFile(IAIMPString fileName, AIMPImageFormat formatId);
        void SaveToStream(IAIMPStream stream, AIMPImageFormat formatId);
        [PreserveSig]
        AIMPImageFormat GetFormatID();
        void GetSize(ref SIZE size);
        IAIMPImage Clone();
        void Draw(IntPtr hDc, RECT rect, AIMPImageDrawMode flags, [MarshalAs(UnmanagedType.IUnknown)] object attrs);
        void Resize(int width, int height);
    }
}