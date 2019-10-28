using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-4163-7469-6F6E-4576656E7400")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPActionEvent
    {
        void OnExecute([MarshalAs(UnmanagedType.IUnknown)] object data);
    }
}