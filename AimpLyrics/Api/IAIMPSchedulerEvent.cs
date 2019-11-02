using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-5363-6865-6475-6C6572457674")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPSchedulerEvent
    {
        // IAIMPPropertyList
        void BeginUpdate();
        void EndUpdate();
        void Reset();
        // Read
        double GetValueAsFloat(AIMPSchedulerEventPropId propertyId);
        int GetValueAsInt32(AIMPSchedulerEventPropId propertyId);
        long GetValueAsInt64(AIMPSchedulerEventPropId propertyId);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetValueAsObject(AIMPSchedulerEventPropId propertyId, ref Guid iid);

        // Write
        void SetValueAsFloat(AIMPSchedulerEventPropId propertyId, double value);
        void SetValueAsInt32(AIMPSchedulerEventPropId propertyId, int value);
        void SetValueAsInt64(AIMPSchedulerEventPropId propertyId, long value);
        void SetValueAsObject(AIMPSchedulerEventPropId propertyId, [MarshalAs(UnmanagedType.IUnknown)] object value);
    }
}