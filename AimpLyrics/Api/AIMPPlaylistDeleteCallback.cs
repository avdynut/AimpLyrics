using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [return: MarshalAs(UnmanagedType.Bool)]
    public delegate bool AIMPPlaylistDeleteCallback(IAIMPPlaylistItem item, IntPtr userData);
}