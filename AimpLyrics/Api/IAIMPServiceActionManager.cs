using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-5372-7641-6374-696F6E4D616E")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPServiceActionManager
    {
        IAIMPAction GetByID(IAIMPString id);

        [PreserveSig]
        int MakeHotkey(AIMPActionHotKeyModifiers modifiers, ushort key);
    }
}