using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756949-6E70-7574-446C-6745766E7400")]
    [ComImport]
    public interface IAIMPUiInputDialogEvents
    {
        void OnValidate(object value, int valueIndex); // TODO: value is COM VARIANT
    }
}