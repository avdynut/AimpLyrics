using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-4669-6C65-496E-666F00000000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPFileInfo
    {
        // IAIMPPropertyList
        void BeginUpdate();
        void EndUpdate();
        void Reset();
        // Read
        double GetValueAsFloat(AIMPFileInfoPropId propertyId);
        int GetValueAsInt32(AIMPFileInfoPropId propertyId);
        long GetValueAsInt64(AIMPFileInfoPropId propertyId);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetValueAsObject(AIMPFileInfoPropId propertyId, ref Guid iid);

        // Write
        void SetValueAsFloat(AIMPFileInfoPropId propertyId, double value);
        void SetValueAsInt32(AIMPFileInfoPropId propertyId, int value);
        void SetValueAsInt64(AIMPFileInfoPropId propertyId, long value);
        void SetValueAsObject(AIMPFileInfoPropId propertyId, [MarshalAs(UnmanagedType.IUnknown)] object value);

        // IAIMPFileInfo
        void Assign(IAIMPFileInfo source);
        IAIMPFileInfo Clone();
    }
}