using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756949-6E70-7574-446C-670000000000")]
    [ComImport]
    public interface IAIMPUiInputDialog
    {
        void Execute(IntPtr ownerWnd, IAIMPString caption, [MarshalAs(UnmanagedType.IUnknown)] object eventsHandler, IAIMPString text, 
            IntPtr value); // TODO: value is VARIANT*
        void Execute2(IntPtr ownerWnd, IAIMPString caption, [MarshalAs(UnmanagedType.IUnknown)] object eventsHandler, IAIMPObjectList textForValues,
            IntPtr values, int valueCount); // TODO: returns array of variants: values is VARIANT*
    }
}