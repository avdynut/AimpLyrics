using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756949-6D67-4C69-7374-000000000000")]
    [ComImport]
    public interface IAIMPUiImageList
    {
        void Add(IAIMPImage image);
        void Clear();
        void Delete(int index);
        void Draw(IntPtr hDc, int index, int x, int y, [MarshalAs(UnmanagedType.Bool)] bool enabled);
        void LoadFromResource(IntPtr hModule, [MarshalAs(UnmanagedType.LPWStr)] string resourceName, [MarshalAs(UnmanagedType.LPWStr)] string resourceType);

        [PreserveSig]
        int GetCount();

        void GetSize(out SIZE size);
        void SetSize(SIZE size);
    }
}