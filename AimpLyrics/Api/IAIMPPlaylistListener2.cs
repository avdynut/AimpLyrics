using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-506C-734C-7374-6E7232000000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPPlaylistListener2
    {
        void ScanningBegin();
        void ScanningProgress(double progress);
        void ScanningEnd([MarshalAs(UnmanagedType.Bool)] bool hasChanges, [MarshalAs(UnmanagedType.Bool)] bool canceled);
    }
}