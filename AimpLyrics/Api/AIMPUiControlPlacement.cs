using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct AIMPUiControlPlacement
    {
        public AIMPUiControlAlignment Alignment;
        public RECT AlignmentMargins;
        public RECT Anchors;
        public RECT Bounds;
    }
}