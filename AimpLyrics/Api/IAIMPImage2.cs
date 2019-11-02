using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-496D-6167-6532-000000000000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface  IAIMPImage2
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
	
        void LoadFromResource(IntPtr hModule, [MarshalAs(UnmanagedType.LPWStr)] string resourceName, [MarshalAs(UnmanagedType.LPWStr)] string resourceType);
        void LoadFromBitmap(IntPtr hBitmap);
        void LoadFromBits(ref RGBQUAD bits, int width, int height);
        void CopyToClipboard();
        void CanPasteFromClipboard();
        void PasteFromClipboard();
    }
}