using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756950-6F70-7570-4D65-6E7500000000")]
    [ComImport]
    public interface IAIMPUiPopupMenu
    {
        IAIMPUiMenuItem Add(IAIMPString id);
        void Delete(int index);
        void DeleteChildren();

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object Get(int index, ref Guid iid);

        [PreserveSig]
        int GetCount();

        void Popup(POINT screenPoint);
        void Popup2(RECT screenRect);
    }
}