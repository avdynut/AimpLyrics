using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-4F62-6A4C-6973-740000000000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPObjectList
    {
        void Add([MarshalAs(UnmanagedType.IUnknown)] object obj);
        void Clear();
        void Delete(int index);
        void Insert(int index, [MarshalAs(UnmanagedType.IUnknown)] object obj);

        [PreserveSig]
        int GetCount();
        void GetObject(int index, ref Guid iid, [MarshalAs(UnmanagedType.IUnknown)] out object obj);
        void SetObject(int index, [MarshalAs(UnmanagedType.IUnknown)] object obj);
    }
}