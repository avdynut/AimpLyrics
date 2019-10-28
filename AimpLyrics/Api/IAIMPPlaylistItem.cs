using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-506C-7349-7465-6D0000000000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPPlaylistItem
    {
        // IAIMPPropertyList
        void BeginUpdate();
        void EndUpdate();
        void Reset();
        // Read
        double GetValueAsFloat(AIMPPlaylistItemPropId propertyId);
        int GetValueAsInt32(AIMPPlaylistItemPropId propertyId);
        long GetValueAsInt64(AIMPPlaylistItemPropId propertyId);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetValueAsObject(AIMPPlaylistItemPropId propertyId, ref Guid iid);

        // Write
        void SetValueAsFloat(AIMPPlaylistItemPropId propertyId, double value);
        void SetValueAsInt32(AIMPPlaylistItemPropId propertyId, int value);
        void SetValueAsInt64(AIMPPlaylistItemPropId propertyId, long value);
        void SetValueAsObject(AIMPPlaylistItemPropId propertyId, [MarshalAs(UnmanagedType.IUnknown)] object value);

        // IAIMPPlaylistItem
        void ReloadInfo();
    }
}