using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-436F-7265-0000-000000000000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPCore
    {
        // Creating Simple Objects
        [return: MarshalAs(UnmanagedType.IUnknown)]
        object CreateObject(ref Guid iid);

        // System Paths
        IAIMPString GetPath(AIMPCorePath path);

        // Registration
        void RegisterExtension(ref Guid serviceIid, [MarshalAs(UnmanagedType.IUnknown)] object extension);
        void RegisterService([MarshalAs(UnmanagedType.IUnknown)] object service);
        void UnregisterExtension([MarshalAs(UnmanagedType.IUnknown)] object extension);
    }
}