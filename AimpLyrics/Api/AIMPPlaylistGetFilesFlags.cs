using System;

namespace Aimp4.Api
{
    [Flags]
    public enum AIMPPlaylistGetFilesFlags
    {
        None = 0,
        SelectedOnly = 0x1,
        VisibleOnly = 0x2,
        CollapseVirtual = 0x4,
    }
}