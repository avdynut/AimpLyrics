using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-4578-7450-6C61-796261636B51")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPExtensionPlaybackQueue
    {
        void GetNext([MarshalAs(UnmanagedType.IUnknown)] object current, AIMPPlaybackQueuePosition position, IAIMPPlaybackQueueItem queueItem);
        void GetPrev([MarshalAs(UnmanagedType.IUnknown)] object current, AIMPPlaybackQueuePosition position, IAIMPPlaybackQueueItem queueItem);
        void OnSelect(IAIMPPlaylistItem item, IAIMPPlaybackQueueItem queueItem);
    }
}