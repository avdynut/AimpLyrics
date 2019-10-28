using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-5372-7654-6872-64506F6F6C00")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPServiceThreadPool
    {
        void Cancel(IntPtr taskHandle, AIMPTaskCancelFlags flags); // ref uint?
        void Execute(IAIMPTask task, IntPtr taskHandle); // ref uint?
        void WaitFor(IntPtr taskHandle); // ref uint?
    }
}