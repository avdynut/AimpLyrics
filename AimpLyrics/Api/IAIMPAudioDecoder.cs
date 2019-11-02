using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-4175-6469-6F44-656300000000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPAudioDecoder
    {
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool GetFileInfo(IAIMPFileInfo fileInfo);

        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool GetStreamInfo(out int sampleRate, out int channels, out AIMPDecoderSampleFormat sampleFormat);

        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool IsSeekable();

        [PreserveSig]
        bool IsRealTimeStream();

        [PreserveSig]
        long GetAvailableData();

        [PreserveSig]
        long GetSize();

        [PreserveSig]
        long GetPosition();

        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool SetPosition(long value);

        [PreserveSig]
        int Read(IntPtr buffer, int count);
    }
}