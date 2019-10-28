using System;

namespace Aimp4.Api
{
    public delegate int AIMPPlaylistCompareCallback(IAIMPPlaylistItem item1, IAIMPPlaylistItem item2, IntPtr userData);
}