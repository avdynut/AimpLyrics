using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756950-7267-7273-446C-6745766E7400")]
    [ComImport]
    public interface IAIMPUiProgressDialogEvents
    {
        void OnCanceled();
    }
}