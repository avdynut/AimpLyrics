namespace Aimp4.Api
{
    public enum AIMPRemoteAccessNotify
    {
        //==============================================================================
        // Notifications ID for WM_AIMP_NOTIFY message: (Notification ID in WParam)
        //==============================================================================
        AIMP_RA_NOTIFY_BASE = 0,

        AIMP_RA_NOTIFY_TRACK_INFO = AIMP_RA_NOTIFY_BASE + 1,

        // Called, when audio stream starts playing or when an Internet radio station changes the track
        AIMP_RA_NOTIFY_TRACK_START = AIMP_RA_NOTIFY_BASE + 2,

        // Called, when property has been changed
        // LParam: Property ID
        AIMP_RA_NOTIFY_PROPERTY = AIMP_RA_NOTIFY_BASE + 3,
    }
}