using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-4669-6C65-5374-7265616D0000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPFileStream
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

        void GetClipping(long offset, long size);
        IAIMPString GetFileName();
    }
}