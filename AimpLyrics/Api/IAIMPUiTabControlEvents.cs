using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756954-6162-4374-726C-45766E747300")]
    [ComImport]
    public interface IAIMPUiTabControlEvents
    {
        // IAIMPUiChangeEvents
        void OnChanged([MarshalAs(UnmanagedType.IUnknown)] object sender);
	
        // IAIMPUiTabControlEvents
        void OnActivating(IAIMPUiTabControl sender, int tabIndex, ref int allow); // ref bool allow
        void OnActivated(IAIMPUiTabControl sender, int tabIndex);
    }
}