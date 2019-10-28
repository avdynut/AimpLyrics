using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-5372-7641-7474-724578740000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPServiceAttrExtendable
    {
        void RegisterExtension([MarshalAs(UnmanagedType.IUnknown)] object extension);
        void UnregisterExtension([MarshalAs(UnmanagedType.IUnknown)] object extension);
    }
}