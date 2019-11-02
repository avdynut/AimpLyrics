using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-4669-6C65-5461-670000000000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPFileTag
    {
        // IAIMPPropertyList
        void BeginUpdate();
        void EndUpdate();
        void Reset();
        // Read
        double GetValueAsFloat(AIMPFileTagPropId propertyId);
        int GetValueAsInt32(AIMPFileTagPropId propertyId);
        long GetValueAsInt64(AIMPFileTagPropId propertyId);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetValueAsObject(AIMPFileTagPropId propertyId, ref Guid iid);

        // Write
        void SetValueAsFloat(AIMPFileTagPropId propertyId, double value);
        void SetValueAsInt32(AIMPFileTagPropId propertyId, int value);
        void SetValueAsInt64(AIMPFileTagPropId propertyId, long value);
        void SetValueAsObject(AIMPFileTagPropId propertyId, [MarshalAs(UnmanagedType.IUnknown)] object value);

        // IAIMPFileInfo
        void Assign(IAIMPFileInfo source);
        IAIMPFileInfo Clone();
    }
}