using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-4D65-6D53-7472-65616D000000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPMemoryStream
    {
        [PreserveSig]
        long GetSize();

        void SetSize(long value);

        [PreserveSig]
        long GetPosition();

        void Seek(long offset, int mode);

        [PreserveSig]
        int Read(IntPtr buffer, uint count);

        int Write(IntPtr buffer, uint count);

        [PreserveSig]
        IntPtr GetData();
    }
}