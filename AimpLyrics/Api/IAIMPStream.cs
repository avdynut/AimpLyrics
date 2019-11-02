using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-5374-7265-616D-000000000000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPStream
    {
        [PreserveSig]
        long GetSize();

        void SetSize(long value);

        [PreserveSig]
        long GetPosition();

        void Seek(long offset, AIMPStreamSeekMode mode);

        [PreserveSig]
        int Read(IntPtr buffer, uint count);

        int Write(IntPtr buffer, uint count);
    }
}