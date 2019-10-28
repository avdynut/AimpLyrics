using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-5372-7650-6C62-61636B510000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPServicePlaybackQueue
    {
        IAIMPPlaybackQueueItem GetNextTrack();
        IAIMPPlaybackQueueItem GetPrevTrack();
    }
}