using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("41494D50-5365-7276-6963-655549000000")]
    [ComImport]
    public interface IAIMPServiceUi
    {
        [return: MarshalAs(UnmanagedType.IUnknown)]
        object CreateControl(IAIMPUiForm owner, IAIMPUiWinControl parent, IAIMPString name,
            [MarshalAs(UnmanagedType.IUnknown)] object eventsHandler, ref Guid iid);

        IAIMPUiForm CreateForm(IntPtr ownerWindow, AIMPUiCreateFormFlags flags, IAIMPString name, [MarshalAs(UnmanagedType.IUnknown)] object eventsHandler);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object CreateObject(IAIMPUiForm owner, [MarshalAs(UnmanagedType.IUnknown)] object eventsHandler, ref Guid iid);
    }
}