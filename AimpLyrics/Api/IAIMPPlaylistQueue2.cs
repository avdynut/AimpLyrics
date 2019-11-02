using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-506C-7351-7565-756532000000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPPlaylistQueue2
    {
        // IAIMPPlaylistQueue
        // Adding
        void Add(IAIMPPlaylistItem item, [MarshalAs(UnmanagedType.Bool)] bool insertAtBeginning);
        void AddList(IAIMPObjectList itemList, [MarshalAs(UnmanagedType.Bool)] bool insertAtBeginning);
        // Deleting
        void Delete(IAIMPPlaylistItem item);
        void Delete2(IAIMPPlaylist playlist);
        // Reorder
        void Move(IAIMPPlaylistItem item, int targetIndex);
        void Move2(int itemIndex, int targetIndex);
        // Items
        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetItem(int index, ref Guid iid);

        [PreserveSig]
        int GetItemCount();

        // IAIMPPlaylistQueue2
        // Listener
        void ListenerAdd(IAIMPPlaylistQueueListener listener);
        void ListenerRemove(IAIMPPlaylistQueueListener listener);
    }
}