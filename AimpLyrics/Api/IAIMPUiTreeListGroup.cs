using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756954-4C47-726F-7570-000000000000")]
    [ComImport]
    public interface IAIMPUiTreeListGroup
    {
        // IAIMPPropertyList
        void BeginUpdate();
        void EndUpdate();
        void Reset();
        // Read
        double GetValueAsFloat(AIMPUiTreeListGroupPropId propertyId);
        int GetValueAsInt32(AIMPUiTreeListGroupPropId propertyId);
        long GetValueAsInt64(AIMPUiTreeListGroupPropId propertyId);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetValueAsObject(AIMPUiTreeListGroupPropId propertyId, ref Guid iid);

        // Write
        void SetValueAsFloat(AIMPUiTreeListGroupPropId propertyId, double value);
        void SetValueAsInt32(AIMPUiTreeListGroupPropId propertyId, int value);
        void SetValueAsInt64(AIMPUiTreeListGroupPropId propertyId, long value);
        void SetValueAsObject(AIMPUiTreeListGroupPropId propertyId, [MarshalAs(UnmanagedType.IUnknown)] object value);

        // IAIMPUiTreeListGroup
        [return: MarshalAs(UnmanagedType.IUnknown)]
        object Get(int index, ref Guid iid);

        [PreserveSig]
        int GetCount();
    }
}