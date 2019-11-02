using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("41494D50-4D65-6E75-4974-656D00000000")]
    [ComImport]
    public interface IAIMPMenuItem
    {
        // IAIMPPropertyList
        void BeginUpdate();
        void EndUpdate();
        void Reset();
        // Read
        double GetValueAsFloat(AIMPMenuItemPropId propertyId);
        int GetValueAsInt32(AIMPMenuItemPropId propertyId);
        long GetValueAsInt64(AIMPMenuItemPropId propertyId);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetValueAsObject(AIMPMenuItemPropId propertyId, ref Guid iid);

        // Write
        void SetValueAsFloat(AIMPMenuItemPropId propertyId, double value);
        void SetValueAsInt32(AIMPMenuItemPropId propertyId, int value);
        void SetValueAsInt64(AIMPMenuItemPropId propertyId, long value);
        void SetValueAsObject(AIMPMenuItemPropId propertyId, [MarshalAs(UnmanagedType.IUnknown)] object value);

        // IAIMPMenuItem
        void DeleteChildren();
    }
}