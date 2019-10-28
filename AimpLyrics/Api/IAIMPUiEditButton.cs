using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756945-6469-7442-746E-000000000000")]
    [ComImport]
    public interface IAIMPUiEditButton
    {
        // IAIMPPropertyList
        void BeginUpdate();
        void EndUpdate();
        void Reset();
        // Read
        double GetValueAsFloat(AIMPUiEditButtonPropId propertyId);
        int GetValueAsInt32(AIMPUiEditButtonPropId propertyId);
        long GetValueAsInt64(AIMPUiEditButtonPropId propertyId);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetValueAsObject(AIMPUiEditButtonPropId propertyId, ref Guid iid);

        // Write
        void SetValueAsFloat(AIMPUiEditButtonPropId propertyId, double value);
        void SetValueAsInt32(AIMPUiEditButtonPropId propertyId, int value);
        void SetValueAsInt64(AIMPUiEditButtonPropId propertyId, long value);
        void SetValueAsObject(AIMPUiEditButtonPropId propertyId, [MarshalAs(UnmanagedType.IUnknown)] object value);
    }
}