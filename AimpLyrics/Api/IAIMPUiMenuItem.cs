using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("6175694D-656E-7549-7465-6D0000000000")]
    [ComImport]
    public interface IAIMPUiMenuItem: IAIMPMenuItem
    {
        IAIMPUiMenuItem Add(IAIMPString id);
        void Delete(int index);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object Get(int index, ref Guid iid);

        [PreserveSig]
        int GetCount();
    }
}