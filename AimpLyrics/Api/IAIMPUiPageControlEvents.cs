using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756950-6167-6543-7472-6C45766E7400")]
    [ComImport]
    public interface IAIMPUiPageControlEvents
    {
        void OnActivating(IAIMPUiPageControl sender, IAIMPUiTabSheet page, ref int allow); // ref bool allow
        void OnActivated(IAIMPUiPageControl sender, IAIMPUiTabSheet page);
    }
}