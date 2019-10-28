using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756954-4C43-6F6C-756D-6E0000000000")]
    [ComImport]
    public interface IAIMPUiTreeListColumn
    {
        // IAIMPPropertyList
        void BeginUpdate();
        void EndUpdate();
        void Reset();
        // Read
        double GetValueAsFloat(AIMPUiTreeListColumnPropId propertyId);
        int GetValueAsInt32(AIMPUiTreeListColumnPropId propertyId);
        long GetValueAsInt64(AIMPUiTreeListColumnPropId propertyId);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetValueAsObject(AIMPUiTreeListColumnPropId propertyId, ref Guid iid);

        // Write
        void SetValueAsFloat(AIMPUiTreeListColumnPropId propertyId, double value);
        void SetValueAsInt32(AIMPUiTreeListColumnPropId propertyId, int value);
        void SetValueAsInt64(AIMPUiTreeListColumnPropId propertyId, long value);
        void SetValueAsObject(AIMPUiTreeListColumnPropId propertyId, [MarshalAs(UnmanagedType.IUnknown)] object value);
    }
}