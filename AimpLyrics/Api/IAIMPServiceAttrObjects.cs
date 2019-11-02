using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-5372-7641-7474-724F626A7300")]
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAIMPServiceAttrObjects
    {
        [return: MarshalAs(UnmanagedType.IUnknown)]
        object CreateObject(ref Guid iid);
    }
}