using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct AIMPUiControlPlacementConstraints
    {
        public int MaxHeight;
        public int MaxWidth;
        public int MinHeight;
        public int MinWidth;
    }
}