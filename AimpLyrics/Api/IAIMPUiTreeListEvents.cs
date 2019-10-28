using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756954-4C45-7665-6E74-730000000000")]
    [ComImport]
    public interface IAIMPUiTreeListEvents
    {
        void OnColumnClick(IAIMPUiTreeList sender, int columnIndex);
        void OnFocusedColumnChanged(IAIMPUiTreeList sender);
        void OnFocusedNodeChanged(IAIMPUiTreeList sender);
        void OnNodeChecked(IAIMPUiTreeList sender, IAIMPUiTreeListNode node);
        void OnNodeDblClicked(IAIMPUiTreeList sender, IAIMPUiTreeListNode node);
        void OnSelectionChanged(IAIMPUiTreeList sender);
        void OnSorted(IAIMPUiTreeList sender);
        void OnStructChanged(IAIMPUiTreeList sender);
    }
}