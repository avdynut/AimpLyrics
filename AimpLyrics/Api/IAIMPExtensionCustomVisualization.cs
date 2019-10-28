using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-4578-7443-7374-6D5669730000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPExtensionCustomVisualization
    {
        // Common Information
        [PreserveSig]
        AIMPVisualFlags GetFlags();

        // Basic functionality
        void Draw(IntPtr data);
    }
}