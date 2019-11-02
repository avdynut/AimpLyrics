using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-506C-7347-726F-757000000000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPPlaylistGroup
    {
        // IAIMPPropertyList
        void BeginUpdate();
        void EndUpdate();
        void Reset();
        // Read
        double GetValueAsFloat(AIMPPlaylistGroupPropId propertyId);
        int GetValueAsInt32(AIMPPlaylistGroupPropId propertyId);
        long GetValueAsInt64(AIMPPlaylistGroupPropId propertyId);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetValueAsObject(AIMPPlaylistGroupPropId propertyId, ref Guid iid);

        // Write
        void SetValueAsFloat(AIMPPlaylistGroupPropId propertyId, double value);
        void SetValueAsInt32(AIMPPlaylistGroupPropId propertyId, int value);
        void SetValueAsInt64(AIMPPlaylistGroupPropId propertyId, long value);
        void SetValueAsObject(AIMPPlaylistGroupPropId propertyId, [MarshalAs(UnmanagedType.IUnknown)] object value);

        // IAIMPPlaylistGroup
        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetItem(int index, ref Guid iid);

        int GetItemCount();
    }
}