using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-536B-696E-496E-666F00000000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPSkinInfo
    {
        // IAIMPPropertyList
        void BeginUpdate();
        void EndUpdate();
        void Reset();
        // Read
        double GetValueAsFloat(AIMPSkinInfoPropId propertyId);
        int GetValueAsInt32(AIMPSkinInfoPropId propertyId);
        long GetValueAsInt64(AIMPSkinInfoPropId propertyId);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetValueAsObject(AIMPSkinInfoPropId propertyId, ref Guid iid);

        // Write
        void SetValueAsFloat(AIMPSkinInfoPropId propertyId, double value);
        void SetValueAsInt32(AIMPSkinInfoPropId propertyId, int value);
        void SetValueAsInt64(AIMPSkinInfoPropId propertyId, long value);
        void SetValueAsObject(AIMPSkinInfoPropId propertyId, [MarshalAs(UnmanagedType.IUnknown)] object value);
    }
}