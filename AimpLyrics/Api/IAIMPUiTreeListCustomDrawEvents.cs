using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756954-4C44-7261-7745-766E74730000")]
    [ComImport]
    public interface IAIMPUiTreeListCustomDrawEvents
    {
        void OnCustomDrawNode(IAIMPUiTreeList sender, IntPtr hDc, RECT rect, IAIMPUiTreeListNode node, ref int handled); // ref bool handled
        void OnCustomDrawNodeCell(IAIMPUiTreeList sender, IntPtr hDc, RECT rect, IAIMPUiTreeListNode node, IAIMPUiTreeListColumn column, ref int handled); // ref bool handled
        void OnGetNodeBackground(IAIMPUiTreeList sender, IAIMPUiTreeListNode node, ref uint color);
    }
}