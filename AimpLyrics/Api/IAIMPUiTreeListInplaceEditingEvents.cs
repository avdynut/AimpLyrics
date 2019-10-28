using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756954-4C45-6474-4576-6E7473000000")]
    [ComImport]
    public interface IAIMPUiTreeListInplaceEditingEvents
    {
        void OnEditing(IAIMPUiTreeList sender, IAIMPUiTreeListNode node, int columnIndex, ref int allow); // ref bool allow
        void OnEdited(IAIMPUiTreeList sender, IAIMPUiTreeListNode node, int columnIndex, IAIMPString value);
    }
}