using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756954-4C00-0000-0000-000000000000")]
    [ComImport]
    public interface IAIMPUiTreeList
    {
        // IAIMPPropertyList
        void BeginUpdate();
        void EndUpdate();
        void Reset();
        // Read
        double GetValueAsFloat(AIMPUiTreeListPropId propertyId);
        int GetValueAsInt32(AIMPUiTreeListPropId propertyId);
        long GetValueAsInt64(AIMPUiTreeListPropId propertyId);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetValueAsObject(AIMPUiTreeListPropId propertyId, ref Guid iid);

        // Write
        void SetValueAsFloat(AIMPUiTreeListPropId propertyId, double value);
        void SetValueAsInt32(AIMPUiTreeListPropId propertyId, int value);
        void SetValueAsInt64(AIMPUiTreeListPropId propertyId, long value);
        void SetValueAsObject(AIMPUiTreeListPropId propertyId, [MarshalAs(UnmanagedType.IUnknown)] object value);

        // IAIMPUIControl
        void GetPlacement(IntPtr placement); // AIMPUiControlPlacement**
        void GetPlacementConstraints(IntPtr constraints); // AIMPUiControlPlacementConstraints**
        void SetPlacement(ref AIMPUiControlPlacement placement);
        void SetPlacementConstraints(ref AIMPUiControlPlacementConstraints constraints);

        // Coords Translation
        void ClientToScreen(ref POINT point);
        void ScreenToClient(ref POINT point);

        // Drawing
        void PaintTo(IntPtr hDc, int x, int y);
        void Invalidate();

        // IAIMPUIWinControl
        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetControl(int index, ref Guid iid);

        [PreserveSig]
        int GetControlCount();

        [PreserveSig]
        IntPtr GetHandle();

        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool HasHandle();

        void SetFocus();

        // IAIMPUITreeList
        // Columns
        [return: MarshalAs(UnmanagedType.IUnknown)]
        object AddColumn(ref Guid iid);

        void ClearColumns();
        void DeleteColumn(int index);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetColumn(int index, ref Guid iid);

        [PreserveSig]
        int GetColumnCount();

        // Nodes
        void Clear();
        void Delete(IAIMPUiTreeListNode node);
        IAIMPString GetPath(IAIMPUiTreeListNode node);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetRootNode(ref Guid iid);

        void MakeTop(IAIMPUiTreeListNode node);
        void MakeVisible(IAIMPUiTreeListNode node);
        void SetPath(IAIMPString path);

        // Nodes - Absolute List
        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetAbsoluteVisibleNode(int index, ref Guid iid);

        [PreserveSig]
        int GetAbsoluteVisibleNodeCount();

        // Nodes - Selection
        void DeleteSelected();
        void SelectAll();
        void SelectNone();

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetFocused(ref Guid iid);

        void SetFocused([MarshalAs(UnmanagedType.IUnknown)] object obj);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetSelected(int index, ref Guid iid);

        [PreserveSig]
        int GetSelectedCount();

        // Inplace Editing
        void GetEditingCell(out int columnIndex, out int rowIndex);
        void StartEditing(IAIMPUiTreeListColumn column);
        void StopEditing();

        // Grouping
        void GroupBy(IAIMPUiTreeListColumn column, [MarshalAs(UnmanagedType.Bool)] bool resetPrevGroupingParams);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetGroup(int index, ref Guid iid);

        [PreserveSig]
        int GetGroupCount();

        void Regroup();
        void ResetGrouppingParams();

        // Sorting
        void ResetSortingParams();
        void Resort();
        void SortBy(IAIMPUiTreeListColumn column, AIMPUiTreeListSorting sorting, [MarshalAs(UnmanagedType.Bool)] bool resetPrevSortingParams);

        // Customized Settings
        void ConfigLoad(IAIMPConfig config, IAIMPString key);
        void ConfigSave(IAIMPConfig config, IAIMPString key);
    }
}