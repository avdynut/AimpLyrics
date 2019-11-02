using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-4669-6C65-5461-674564697400")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPFileTagEditor
    {
        // Info
        IAIMPFileInfo GetMixedInfo();

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetTag(int index, ref Guid iid);

        [PreserveSig]
        int GetTagCount();

        void SetToAll(IAIMPFileTag info);
        // Save
        void Save();
    }
}