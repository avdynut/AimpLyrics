using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-5072-6F70-4C69-737400000000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPPropertyList
    {
        void BeginUpdate();
        void EndUpdate();
        void Reset();
        // Read
        double GetValueAsFloat(int propertyId);
        int GetValueAsInt32(int propertyId);
        long GetValueAsInt64(int propertyId);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetValueAsObject(int propertyId, ref Guid iid);

        // Write
        void SetValueAsFloat(int propertyId, double value);
        void SetValueAsInt32(int propertyId, int value);
        void SetValueAsInt64(int propertyId, long value);
        void SetValueAsObject(int propertyId, [MarshalAs(UnmanagedType.IUnknown)] object value);
    }
}