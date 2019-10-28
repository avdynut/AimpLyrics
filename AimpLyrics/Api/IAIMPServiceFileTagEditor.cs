using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-5372-7654-6167-456469740000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPServiceFileTagEditor
    {
        [return: MarshalAs(UnmanagedType.IUnknown)]
        object EditFile([MarshalAs(UnmanagedType.IUnknown)] object source, ref Guid iid);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object EditTag([MarshalAs(UnmanagedType.IUnknown)] object source, AIMPFileTagId tagId, ref Guid iid);
    }
}