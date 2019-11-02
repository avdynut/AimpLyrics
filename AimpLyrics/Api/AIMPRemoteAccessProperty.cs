namespace Aimp4.Api
{
    public enum AIMPRemoteAccessProperty: uint
    {
        //==============================================================================
        // + How to:
        //     GET:  SendMessage(Handle, WM_AIMP_PROPERTY, PropertyID | AIMP_RA_PROPVALUE_GET, 0);
        //     SET:  SendMessage(Handle, WM_AIMP_PROPERTY, PropertyID | AIMP_RA_PROPVALUE_SET, NewValue);
        //
        //     Receive Change Notification:
        //       1) You should register notification hook using AIMP_RA_CMD_REGISTER_NOTIFY command
        //       2) When property will change you receive WM_AIMP_NOTIFY message with following params:
        //          WParam: AIMP_RA_NOTIFY_PROPERTY (Notification ID)
        //          LParam: Property ID
        //
        // Properties ID:
        //==============================================================================

        AIMP_RA_PROPVALUE_GET = 0,
        AIMP_RA_PROPVALUE_SET = 1,

        AIMP_RA_PROPERTY_MASK = 0xFFFFFFF0,

        // !! ReadOnly
        // Returns player version:
        // HiWord: Version ID (for example: 301 -> v3.01)
        // LoWord: Build Number
        AIMP_RA_PROPERTY_VERSION = 0x10,

        // GET: Returns current position of now playing track (in msec)
        // SET: LParam: position (in msec)
        AIMP_RA_PROPERTY_PLAYER_POSITION = 0x20,

        // !! ReadOnly
        // Returns duration of now playing track (in msec)
        AIMP_RA_PROPERTY_PLAYER_DURATION = 0x30,

        // !! ReadOnly
        // Returns current player state
        //  0 = Stopped
        //  1 = Paused
        //  2 = Playing
        AIMP_RA_PROPERTY_PLAYER_STATE = 0x40,

        // GET: Return current volume [0..100] (%)
        // SET: LParam: volume [0..100] (%)
        //      Returns 0, if fails
        AIMP_RA_PROPERTY_VOLUME = 0x50,

        // GET: Return current mute state [0..1]
        // SET: LParam: Mute state [0..1]
        //      Returns 0, if fails
        AIMP_RA_PROPERTY_MUTE = 0x60,

        // GET: Return track repeat state [0..1]
        // SET: LParam: Track Repeat state [0..1]
        //      Returns 0, if fails
        AIMP_RA_PROPERTY_TRACK_REPEAT = 0x70,

        // GET: Return shuffle state [0..1]
        // SET: LParam: shuffle state [0..1]
        //      Returns 0, if fails
        AIMP_RA_PROPERTY_TRACK_SHUFFLE = 0x80,

        // GET: Return radio capture state [0..1]
        // SET: LParam: radio capture state [0..1]
        //      Returns 0, if fails
        AIMP_RA_PROPERTY_RADIOCAP = 0x90,

        // GET: Return full screen visualization mode [0..1]
        // SET: LParam: full screen visualization mode [0..1]
        //      Returns 0, if fails
        AIMP_RA_PROPERTY_VISUAL_FULLSCREEN = 0xA0,

        //==============================================================================
        // Commands ID for WM_AIMP_COMMAND message: (Command ID must be defined in WParam)
        //==============================================================================

        AIMP_RA_CMD_BASE = 10,

        // LParam: Window Handle, which will receive WM_AIMP_NOTIFY message from AIMP
        // See description for WM_AIMP_NOTIFY message for details
        AIMP_RA_CMD_REGISTER_NOTIFY = AIMP_RA_CMD_BASE + 1,

        // LParam: Window Handle
        AIMP_RA_CMD_UNREGISTER_NOTIFY = AIMP_RA_CMD_BASE + 2,

        // Start / Resume playback
        // See AIMP_RA_PROPERTY_PLAYER_STATE
        AIMP_RA_CMD_PLAY = AIMP_RA_CMD_BASE + 3,

        // Pause / Start playback
        // See AIMP_RA_PROPERTY_PLAYER_STATE
        AIMP_RA_CMD_PLAYPAUSE = AIMP_RA_CMD_BASE + 4,

        // Pause / Resume playback
        // See AIMP_RA_PROPERTY_PLAYER_STATE
        AIMP_RA_CMD_PAUSE = AIMP_RA_CMD_BASE + 5,

        // Stop playback
        // See AIMP_RA_PROPERTY_PLAYER_STATE
        AIMP_RA_CMD_STOP = AIMP_RA_CMD_BASE + 6,

        // Next Track
        AIMP_RA_CMD_NEXT = AIMP_RA_CMD_BASE + 7,

        // Previous Track
        AIMP_RA_CMD_PREV = AIMP_RA_CMD_BASE + 8,

        // Next Visualization
        AIMP_RA_CMD_VISUAL_NEXT = AIMP_RA_CMD_BASE + 9,

        // Previous Visualization
        AIMP_RA_CMD_VISUAL_PREV = AIMP_RA_CMD_BASE + 10,

        // Close the program
        AIMP_RA_CMD_QUIT = AIMP_RA_CMD_BASE + 11,

        // Execute "Add files" dialog
        AIMP_RA_CMD_ADD_FILES = AIMP_RA_CMD_BASE + 12,

        // Execute "Add folders" dialog
        AIMP_RA_CMD_ADD_FOLDERS = AIMP_RA_CMD_BASE + 13,

        // Execute "Add Playlists" dialog
        AIMP_RA_CMD_ADD_PLAYLISTS = AIMP_RA_CMD_BASE + 14,

        // Execute "Add URL" dialog
        AIMP_RA_CMD_ADD_URL = AIMP_RA_CMD_BASE + 15,

        // Execute "Open Files" dialog
        AIMP_RA_CMD_OPEN_FILES = AIMP_RA_CMD_BASE + 16,

        // Execute "Open Folders" dialog
        AIMP_RA_CMD_OPEN_FOLDERS = AIMP_RA_CMD_BASE + 17,

        // Execute "Open Playlist" dialog
        AIMP_RA_CMD_OPEN_PLAYLISTS = AIMP_RA_CMD_BASE + 18,

        // AlbumArt Request
        AIMP_RA_CMD_GET_ALBUMART = AIMP_RA_CMD_BASE + 19,

        // Start First Visualization
        AIMP_RA_CMD_VISUAL_START = AIMP_RA_CMD_BASE + 20,

        // Stop Visualization
        AIMP_RA_CMD_VISUAL_STOP = AIMP_RA_CMD_BASE + 21,
    }
}