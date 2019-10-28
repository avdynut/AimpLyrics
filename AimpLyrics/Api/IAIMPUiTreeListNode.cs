using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756954-4C4E-6F64-6500-000000000000")]
    [ComImport]
    public interface IAIMPUiTreeListNode
    {
        // IAIMPPropertyList
        void BeginUpdate();
        void EndUpdate();
        void Reset();
        // Read
        double GetValueAsFloat(AIMPUiTreeListNodePropId propertyId);
        int GetValueAsInt32(AIMPUiTreeListNodePropId propertyId);
        long GetValueAsInt64(AIMPUiTreeListNodePropId propertyId);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetValueAsObject(AIMPUiTreeListNodePropId propertyId, ref Guid iid);

        // Write
        void SetValueAsFloat(AIMPUiTreeListNodePropId propertyId, double value);
        void SetValueAsInt32(AIMPUiTreeListNodePropId propertyId, int value);
        void SetValueAsInt64(AIMPUiTreeListNodePropId propertyId, long value);
        void SetValueAsObject(AIMPUiTreeListNodePropId propertyId, [MarshalAs(UnmanagedType.IUnknown)] object value);

        // IAIMPUiTreeListNode
        // Nodes
        IAIMPUiTreeListNode Add();
        void ClearChildren();

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object FindByTag(ref uint tag, [MarshalAs(UnmanagedType.Bool)] bool recursive, ref Guid iid);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object FindByValue(int columnIndex, IAIMPString value, [MarshalAs(UnmanagedType.Bool)] bool recursive, ref Guid iid);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object Get(int index, ref Guid iid);

        [PreserveSig]
        int GetCount();

        // Values
        void ClearValues();
        IAIMPString GetValue(int index);
        void SetValue(int index, IAIMPString value);

        // Groups
        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetGroup(ref Guid iid);
    }
}