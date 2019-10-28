using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-506C-7300-0000-000000000000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPPlaylist
    {
        // Adding
        void Add([MarshalAs(UnmanagedType.IUnknown)] object obj, AIMPPlaylistAddFlags flags, int insertIn);
        void AddList(IAIMPObjectList objList, AIMPPlaylistAddFlags flags, int insertIn);

        // Deleting
        void Delete(IAIMPPlaylistItem item);
        void Delete2(int itemIndex);
        void Delete3(AIMPPlaylistDeleteFlags flags, AIMPPlaylistDeleteCallback callback, IntPtr userData);
        void DeleteAll();

        // Sorting
        void Sort(AIMPPlaylistSortMode mode);
        void Sort2(IAIMPString template);
        void Sort3(AIMPPlaylistCompareCallback callback, IntPtr userData);

        // Locking
        void BeginUpdate();
        void EndUpdate();

        // Other Commands
        void Close(AIMPPlaylistCloseFlags flags);
        IAIMPObjectList GetFiles(AIMPPlaylistGetFilesFlags flags);
        void MergeGroup(IAIMPPlaylistGroup group);
        void ReloadFromPreimage();
        void ReloadInfo(AIMPPlaylistReloadMode mode);

        // Items
        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetItem(int index, ref Guid iid);

        [PreserveSig]
        int GetItemCount();

        // Groups
        [return: MarshalAs(UnmanagedType.IUnknown)]
        void GetGroup(int index, ref Guid iid);

        [PreserveSig]
        int GetGroupCount();

        // Listener
        void ListenerAdd(IAIMPPlaylistListener listener);
        void ListenerRemove(IAIMPPlaylistListener listener);
    }
}