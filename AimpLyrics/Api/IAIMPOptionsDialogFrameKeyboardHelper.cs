using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-4F70-7444-6C67-46726D4B4870")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPOptionsDialogFrameKeyboardHelper
    {

        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool DialogChar(char charCode, int unused);

        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool DialogKey(ushort charCode, int unused);

        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool SelectFirstControl();

        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool SelectNextControl([MarshalAs(UnmanagedType.Bool)] bool findForward, [MarshalAs(UnmanagedType.Bool)] bool checkTabStop);
    }
}