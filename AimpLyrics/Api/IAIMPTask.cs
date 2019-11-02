using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-5461-736B-0000-000000000000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPTask
    {
        void Execute(IAIMPTaskOwner owner);
    }
}