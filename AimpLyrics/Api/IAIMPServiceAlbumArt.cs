using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-5372-7641-6C62-417274000000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPServiceAlbumArt
    {
        IntPtr Get(IAIMPString fileUri, IAIMPString artist, IAIMPString album, AIMPServiceAlbumArtFlags flags, 
            AIMPServiceAlbumArtReceiveCallback callbackProc, IntPtr userData);

        IntPtr Get2(IAIMPFileInfo fileInfo, AIMPServiceAlbumArtFlags flags, AIMPServiceAlbumArtReceiveCallback callbackProc, object userData);
        void Cancel(IntPtr taskId, AIMPServiceAlbumArtFlags flags);
    }
}