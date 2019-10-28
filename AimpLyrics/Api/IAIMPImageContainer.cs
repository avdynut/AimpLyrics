using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-496D-6167-6543-6F6E746E7200")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface  IAIMPImageContainer
    {
	
        IAIMPImage CreateImage();
        void GetInfo(out SIZE size, out AIMPImageFormat formatId);
        [PreserveSig]
        IntPtr GetData();
        [PreserveSig]
        uint GetDataSize();
        void SetDataSize(uint value);
    }
}