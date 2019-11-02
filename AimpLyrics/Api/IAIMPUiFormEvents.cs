using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756946-6F72-6D45-7665-6E7473000000")]
    [ComImport]
    public interface IAIMPUiFormEvents
    {
        void OnActivated(IAIMPUiForm sender);
        void OnDeactivated(IAIMPUiForm sender);
        void OnCreated(IAIMPUiForm sender);
        void OnDestroyed(IAIMPUiForm sender);
        void OnCloseQuery(IAIMPUiForm sender, ref int canClose); // ref bool canClose
        void OnLocalize(IAIMPUiForm sender);
        void OnShortCut(IAIMPUiForm sender, ushort key, AIMPUiKeyModifiers modifiers, ref int handled); // ref bool handled
    }
}