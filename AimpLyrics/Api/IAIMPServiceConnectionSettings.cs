using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("4941494D-5053-7276-436F-6E6E43666700")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPServiceConnectionSettings
    {
        // IAIMPPropertyList
        void BeginUpdate();
        void EndUpdate();
        void Reset();
        // Read
        double GetValueAsFloat(AIMPConnectionSettingsPropId propertyId);
        int GetValueAsInt32(AIMPConnectionSettingsPropId propertyId);
        long GetValueAsInt64(AIMPConnectionSettingsPropId propertyId);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetValueAsObject(AIMPConnectionSettingsPropId propertyId, ref Guid iid);

        // Write
        void SetValueAsFloat(AIMPConnectionSettingsPropId propertyId, double value);
        void SetValueAsInt32(AIMPConnectionSettingsPropId propertyId, int value);
        void SetValueAsInt64(AIMPConnectionSettingsPropId propertyId, long value);
        void SetValueAsObject(AIMPConnectionSettingsPropId propertyId, [MarshalAs(UnmanagedType.IUnknown)] object value);
    }
}