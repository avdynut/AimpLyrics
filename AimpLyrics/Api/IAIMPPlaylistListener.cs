using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-506C-734C-7374-6E7200000000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPPlaylistListener
    {
        void Activated();
        void Changed(AIMPPlaylistNotifications notifications);
        void Removed();
    }
}