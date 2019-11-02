using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-5372-7653-6875-74646F776E00")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPServiceShutdown
    {
        void Restart(IAIMPString parameters);
        void Shutdown(AIMPServiceShutdownFlags flags);
    }
}