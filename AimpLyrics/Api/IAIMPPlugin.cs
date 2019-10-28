using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("6FD9BC64-DB59-4610-B33E-4A2A158DFCDA")]
    [ComImport]
    public interface IAIMPPlugin
    {
        [return: MarshalAs(UnmanagedType.LPWStr)]
        [PreserveSig]
        string InfoGet(AIMPPluginInfo info);

        [PreserveSig]
        AIMPPluginCategories InfoGetCategories();

        void Initialize(IAIMPCore core);
        void FinalizePlugin();

        void SystemNotification(AIMPSystemNotification notification, [MarshalAs(UnmanagedType.IUnknown)] object data);
    }
}