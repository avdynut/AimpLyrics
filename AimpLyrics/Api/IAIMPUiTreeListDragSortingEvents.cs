using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("6169544C-4472-6167-536F-727445766E74")]
    [ComImport]
    public interface IAIMPUiTreeListDragSortingEvents
    {
        void OnDragSorting(IAIMPUiTreeList sender);
        void OnDragSortingNodeOver(IAIMPUiTreeList sender, IAIMPUiTreeListNode node, uint flags, ref int handled); // ref bool handled
    }
}