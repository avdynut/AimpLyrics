using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-5372-764F-7074-446C67000000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPServiceOptionsDialog
    {
        void FrameModified(IAIMPOptionsDialogFrame frame);
        void FrameShow(IAIMPOptionsDialogFrame frame);
    }
}