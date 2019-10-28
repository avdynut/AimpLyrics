using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-506C-6179-6261-636B5149746D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPPlaybackQueueItem
    {
        // IAIMPPropertyList
        void BeginUpdate();
        void EndUpdate();
        void Reset();
        // Read
        double GetValueAsFloat(AIMPPlaybackQueueItemPropId propertyId);
        int GetValueAsInt32(AIMPPlaybackQueueItemPropId propertyId);
        long GetValueAsInt64(AIMPPlaybackQueueItemPropId propertyId);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetValueAsObject(AIMPPlaybackQueueItemPropId propertyId, ref Guid iid);

        // Write
        void SetValueAsFloat(AIMPPlaybackQueueItemPropId propertyId, double value);
        void SetValueAsInt32(AIMPPlaybackQueueItemPropId propertyId, int value);
        void SetValueAsInt64(AIMPPlaybackQueueItemPropId propertyId, long value);
        void SetValueAsObject(AIMPPlaybackQueueItemPropId propertyId, [MarshalAs(UnmanagedType.IUnknown)] object value);
    }
}