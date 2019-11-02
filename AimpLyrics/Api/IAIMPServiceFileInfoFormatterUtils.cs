using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-5372-7646-6C49-6E66466D7455")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPServiceFileInfoFormatterUtils
    {
        void ShowMacrosLegend(RECT screenTarget, int reserved, [MarshalAs(UnmanagedType.IUnknown)] object eventsHandler);
    }
}