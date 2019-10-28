using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-506C-7351-7565-75654C737400")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPPlaylistQueueListener
    {
        void ContentChanged();
        void StateChanged();
    }
}