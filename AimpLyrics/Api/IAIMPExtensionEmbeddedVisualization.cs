using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-4578-7445-6D62-645669730000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPExtensionEmbeddedVisualization
    {
        // Common Information
        [PreserveSig]
        AIMPVisualFlags GetFlags();

        void GetMaxDisplaySize(out int width, out int height);
        IAIMPString GetName();
        // Initialization / Finalization
        void Initialize(int width, int height);
        void FinalizeExt();
        // Basic functionality
        void Click(int X, int Y, AIMPVisualClickButton button);
        void Draw(IntPtr hDc, IntPtr data);
        void Resize(int newWidth, int newHeight);
    }
}