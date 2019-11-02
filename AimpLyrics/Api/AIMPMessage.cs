namespace Aimp4.Api
{
    public enum AIMPMessage
    {
        CommandBase = 0,

        // AParam1: Command ID (see CommandXXX)
        // Result: S_OK, if enabled
        CommandStateGet = CommandBase + 1,

        // Show "Quick File Info" card for now playing file
        // AParam1:
        //    LoWord: DisplayTime (in milliseconds), 0 - default
        //    HiWord: 0 - Popup near system tray,
        //            1 - Popup near mouse cursor
        // AParam2: unused
        CommandQfiPlaybackTrack = CommandBase + 2,

        // Show custom text in display of RunningLine or Text elements
        // AParam1: 0 - Hide text automaticly after 2 seconds
        //          1 - Text will be hidden manually (put nil to AParam2 to hide previous text)
        // AParam2: Pointer to WideChar array
        CommandShowNotification = CommandBase + 3,

        CommandTogglePartRepeat = CommandBase + 5,

        // Show "About" window
        // AParam1, AParam2: unused
        CommandAbout = CommandBase + 6,

        // Show "Options" Dialog
        // AParam1, AParam2: unused
        CommandOptions = CommandBase + 7,

        // Show "Options" Dialog with active "plugins" sheet
        // AParam1, AParam2: unused
        CommandPlugins = CommandBase + 8,

        // Close the program
        // AParam1, AParam2: unused
        CommandQuit = CommandBase + 9,

        // Show Simple Scheduler Options Dialog
        // AParam1, AParam2: unused
        CommandScheduler = CommandBase + 11,

        // Switch to next visualization
        // AParam1, AParam2: unused
        CommandVisualNext = CommandBase + 12,

        // Switch to previous visualization
        // AParam1, AParam2: unused
        CommandVisualPrev = CommandBase + 13,

        // Start / Resume playback
        // AParam1, AParam2: unused
        CommandPlay = CommandBase + 14,

        // Pause / Start playback
        // AParam1, AParam2: unused
        CommandPlayPause = CommandBase + 15,

        // Start playback of previous playlist
        // AParam1, AParam2: unused
        CommandPlayPrevPlaylist = CommandBase + 16,

        // Resume / Pause playback
        // AParam1, AParam2: unused
        CommandPause = CommandBase + 17,

        // Stop playback
        // AParam1, AParam2: unused
        CommandStop = CommandBase + 18,

        // Next Track
        // AParam1, AParam2: unused
        CommandNext = CommandBase + 19,

        // Previous Track
        // AParam1, AParam2: unused
        CommandPrev = CommandBase + 20,

        // Execute "Open Files" dialog
        // AParam1, AParam2: unused
        CommandOpenFiles = CommandBase + 21,

        // Execute "Open Folders" dialog
        // AParam1, AParam2: unused
        CommandOpenFolders = CommandBase + 22,

        // Execute "Open Playlist" dialog
        // AParam1, AParam2: unused
        CommandOpenPlaylists = CommandBase + 23,

        // Execute "Save Playlist" dialog
        // AParam1, AParam2: unused
        CommandSavePlaylists = CommandBase + 24,

        // Execute "Bookmarks" dialog
        // AParam1, AParam2: unused
        CommandBookmarks = CommandBase + 25,

        // Add file to Bookmarks
        // AParam1: 0 - add playing file, 1 - add selected files from active playlist
        // AParam2: unused
        CommandBookmarksAdd = CommandBase + 26,

        // Rescan tags in active playlist
        // AParam1, AParam2: unused
        CommandPlsRescan = CommandBase + 27,

        // Jump focus in playlist to now playing file
        // AParam1, AParam2: unused
        CommandPlsFocusPlayable = CommandBase + 28,

        // Delete all items from active playlist
        // AParam1, AParam2: unused
        CommandPlsDeleteAll = CommandBase + 29,

        // Delete non exists items from active playlist
        // AParam1, AParam2: unused
        CommandPlsDeleteNonExists = CommandBase + 30,

        // Delete non selected items from active playlist
        // AParam1, AParam2: unused
        CommandPlsDeleteNonSelected = CommandBase + 31,

        // Delete Playing Item from playlist and disk
        // AParam1, AParam2: unused
        CommandPlsDeletePlayingFromHdd = CommandBase + 32,

        // Delete selected items from active playlist
        // AParam1, AParam2: unused
        CommandPlsDeleteSelected = CommandBase + 33,

        // Delete selected items from active playlist and disk
        // AParam1, AParam2: unused
        CommandPlsDeleteSelectedFromHdd = CommandBase + 34,

        // Delete switched off items from active playlist
        // AParam1, AParam2: unused
        CommandPlsDeleteSwitchedOff = CommandBase + 35,

        // Delete switched off items from active playlist and disk
        // AParam1, AParam2: unused
        CommandPlsDeleteSwitchedOffFromHdd = CommandBase + 36,

        // Delete duplicates from active playlist
        // AParam1, AParam2: unused
        CommandPlsDeleteDuplicates = CommandBase + 37,

        // AParam1, AParam2: unused
        CommandPlsSortByArtist = CommandBase + 38,

        // AParam1, AParam2: unused
        CommandPlsSortByTitle = CommandBase + 39,

        // AParam1, AParam2: unused
        CommandPlsSortByPath = CommandBase + 40,

        // AParam1, AParam2: unused
        CommandPlsSortByDuration = CommandBase + 41,

        // AParam1, AParam2: unused
        CommandPlsSortRandomize = CommandBase + 42,

        // AParam1, AParam2: unused
        CommandPlsSortInvert = CommandBase + 43,

        // Switch on autoplaying markers for selected items in active playlist
        // AParam1, AParam2: unused
        CommandPlsSwitchOn = CommandBase + 44,

        // Switch on autoplaying markers for selected items in active playlist
        // AParam1, AParam2: unused
        CommandPlsSwitchOff = CommandBase + 45,

        // Execute "Add files" dialog
        // AParam1, AParam2: unused
        CommandAddFiles = CommandBase + 46,

        // Execute "Add folders" dialog
        // AParam1, AParam2: unused
        CommandAddFolders = CommandBase + 47,

        // Execute "Add Playlists" dialog
        // AParam1, AParam2: unused
        CommandAddPlaylists = CommandBase + 48,

        // Execute "Add URL" dialog
        // AParam1, AParam2: unused
        CommandAddUrl = CommandBase + 49,

        // Execute "Quick Tag Editor" for now playing file
        // AParam1, AParam2: unused
        CommandQtePlayableTrack = CommandBase + 51,

        // Show Advanced Search Dialog
        // AParam1, AParam2: unused
        CommandSearch = CommandBase + 52,

        // Show DSP Manager Dialog
        // AParam1: Active tab sheet index [0..3]
        // AParam2: unused
        CommandDspManager = CommandBase + 53,

        // Sync active playlist with preimage
        // AParam1, AParam2: unused
        CommandPlsReloadFromPreimage = CommandBase + 55,

        // Starts first visualization
        // AParam1, AParam2: unused
        CommandVisualStart = CommandBase + 57,

        // Switch off the visualization
        // AParam1, AParam2: unused
        CommandVisualStop = CommandBase + 58,

        // Rescan tags for selected files in active playlist
        // AParam1, AParam2: unused
        CommandPlsRescanSelected = CommandBase + 59,


        PropertyBase = 0x1000,

        // Flags for AParam1
        PropertyValueGet = 0,
        PropertyValueSet = 1,

        // AParam1: AIMP_MSG_PROPVALUE_GET / AIMP_MSG_PROPVALUE_SET
        // AParam2: Pointer to 32-bit floating-point variable, Range [0.0 .. 1.0]
        PropertyVolume = PropertyBase + 1,

        // AParam1: AIMP_MSG_PROPVALUE_GET / AIMP_MSG_PROPVALUE_SET
        // AParam2: Pointer to LongBool (32-bit Boolean) variable
        PropertyMute = PropertyBase + 2,

        // AParam1: AIMP_MSG_PROPVALUE_GET / AIMP_MSG_PROPVALUE_SET
        // AParam2: Pointer to Single (32-bit floating point value) variable
        //          [-1.0 .. +1.0], Default: 0.0
        PropertyBalance = PropertyBase + 3,

        // AParam1: AIMP_MSG_PROPVALUE_GET / AIMP_MSG_PROPVALUE_SET
        // AParam2: Pointer to Single (32-bit floating point value) variable
        //          [0.0 .. 1.0], Default: 0.0 (switched off)
        PropertyChorus = PropertyBase + 4,

        // AParam1: AIMP_MSG_PROPVALUE_GET / AIMP_MSG_PROPVALUE_SET
        // AParam2: Pointer to Single (32-bit floating point value) variable
        //          [0.0 .. 1.0], Default: 0.0 (switched off)
        PropertyEcho = PropertyBase + 5,

        // AParam1: AIMP_MSG_PROPVALUE_GET / AIMP_MSG_PROPVALUE_SET
        // AParam2: Pointer to Single (32-bit floating point value) variable
        //          [1.0 .. 4.0], Default: 1.0 (switched off)
        PropertyEnhancer = PropertyBase + 6,

        // AParam1: AIMP_MSG_PROPVALUE_GET / AIMP_MSG_PROPVALUE_SET
        // AParam2: Pointer to Single (32-bit floating point value) variable
        //          [0.0 .. 1.0], Default: 0.0 (switched off)
        PropertyFlanger = PropertyBase + 7,

        // AParam1: AIMP_MSG_PROPVALUE_GET / AIMP_MSG_PROPVALUE_SET
        // AParam2: Pointer to Single (32-bit floating point value) variable
        //          [0.0 .. 1.0], Default: 0.0 (switched off)
        PropertyReverb = PropertyBase + 8,

        // AParam1: AIMP_MSG_PROPVALUE_GET / AIMP_MSG_PROPVALUE_SET
        // AParam2: Pointer to Single (32-bit floating point value) variable
        //          [-10.0 .. +10.0], Default: 0.0 (switched off)
        PropertyPitch = PropertyBase + 9,

        // AParam1: AIMP_MSG_PROPVALUE_GET / AIMP_MSG_PROPVALUE_SET
        // AParam2: Pointer to Single (32-bit floating point value) variable
        //          [0.5 .. 1.5], Default: 1.0 (switched off)
        PropertySpeed = PropertyBase + 10,

        // AParam1: AIMP_MSG_PROPVALUE_GET / AIMP_MSG_PROPVALUE_SET
        // AParam2: Pointer to Single (32-bit floating point value) variable
        //          [0.8 .. 1.5], Default: 1.0 (switched off)
        PropertyTempo = PropertyBase + 11,

        // AParam1: AIMP_MSG_PROPVALUE_GET / AIMP_MSG_PROPVALUE_SET
        // AParam2: Pointer to Single (32-bit floating point value) variable
        //          [0.0 .. 2.0], Default: 0.0 (switched off)
        PropertyTrueBass = PropertyBase + 12,

        // AParam1: AIMP_MSG_PROPVALUE_GET / AIMP_MSG_PROPVALUE_SET
        // AParam2: Pointer to Single (32-bit floating point value) variable
        //          [0.5 .. 1.5], Default: 1.0 (switched off)
        PropertyPreamp = PropertyBase + 13,

        // AParam1: AIMP_MSG_PROPVALUE_GET / AIMP_MSG_PROPVALUE_SET
        // AParam2: Pointer to LongBool (32-bit boolean value) variable
        //          Default: False (switched off)
        PropertyEqualizer = PropertyBase + 14,

        // AParam1: LoWord: AIMP_MSG_PROPVALUE_GET / AIMP_MSG_PROPVALUE_SET
        //          HiWord: Slider Index [0..17]
        // AParam2: Pointer to Single (32-bit floating point value) variable
        //          [-15.0 .. 15.0] (in db), Default: 0.0 (switched off)
        // !!!NOTE: AParam2 in EventPROPERTY_VALUE will be nil;
        PropertyEqualizerBand = PropertyBase + 15,

        // !!!ReadOnly property
        // AParam1: AIMP_MSG_PROPVALUE_GET
        // AParam2: Pointer to Integer variable
        //          0 = Stopped
        //          1 = Paused
        //          2 = Playing
        // See EventPLAYER_STATE event
        PropertyPlayerState = PropertyBase + 16,

        // AParam1: AIMP_MSG_PROPVALUE_GET / AIMP_MSG_PROPVALUE_SET
        // AParam2: Pointer to Single (32-bit floating point value) variable
        //          New position in Seconds
        // See EventPROPERTY_VALUE and EventPLAYER_UPDATE_POSITION
        PropertyPlayerPosition = PropertyBase + 17,

        // !!!ReadOnly property
        // AParam1: AIMP_MSG_PROPVALUE_GET
        // AParam2: Pointer to Single (32-bit floating point value) variable
        PropertyPlayerDuration = PropertyBase + 18,

        // !!!ReadOnly property
        // AParam1: AIMP_MSG_PROPVALUE_GET
        // AParam2: Pointer to Integer variable
        //    0 = Disabled,
        //    1 = Point A assigned,
        //    2 = Point B assigned, repeat started
        PropertyPartRepeat = PropertyBase + 19,

        // AParam1: AIMP_MSG_PROPVALUE_GET / AIMP_MSG_PROPVALUE_SET
        // AParam2: Pointer to LongBool (32-bit boolean value) variable
        PropertyRepeat = PropertyBase + 20,

        // AParam1: AIMP_MSG_PROPVALUE_GET / AIMP_MSG_PROPVALUE_SET
        // AParam2: Pointer to LongBool (32-bit boolean value) variable
        PropertyShuffle = PropertyBase + 21,

        // !!!ReadOnly property
        // AParam1: One of AIMP_MPH_XXX flags
        // AParam2: Pointer to HWND
        PropertyHwnd = PropertyBase + 22,
        MphMainForm = 0,
        MphApplication = 1,
        MphTrayControl = 2,
        MphPlaylistForm = 3,
        MphEqualizerForm = 4,

        // AParam1: AIMP_MSG_PROPVALUE_GET / AIMP_MSG_PROPVALUE_SET
        // AParam2: Pointer to LongBool (32-bit boolean value) variable
        PropertyStayOnTop = PropertyBase + 23,

        // AParam1: AIMP_MSG_PROPVALUE_GET / AIMP_MSG_PROPVALUE_SET
        // AParam2: Pointer to LongBool (32-bit boolean value) variable
        PropertyReverseTime = PropertyBase + 24,

        // AParam1: AIMP_MSG_PROPVALUE_GET / AIMP_MSG_PROPVALUE_SET
        // AParam2: Pointer to LongBool (32-bit boolean value) variable
        PropertyMinimizedToTray = PropertyBase + 25,

        // AParam1: AIMP_MSG_PROPVALUE_GET / AIMP_MSG_PROPVALUE_SET
        // AParam2: Pointer to LongBool (32-bit boolean value) variable
        PropertyRepeatSingleFilePlaylists = PropertyBase + 26,

        // AParam1: AIMP_MSG_PROPVALUE_GET / AIMP_MSG_PROPVALUE_SET
        // AParam2: Pointer to Integer variable
        //   0 - Jump to next playlist
        //   1 - Repeat playlist
        //   2 - Do nothing
        PropertyActionOnEndOfPlaylist = PropertyBase + 27,

        // AParam1: AIMP_MSG_PROPVALUE_GET / AIMP_MSG_PROPVALUE_SET
        // AParam2: Pointer to LongBool (32-bit boolean value) variable
        PropertyStopAfterTrack = PropertyBase + 28,

        // Start / Stop Internet Radio capture
        // AParam1: AIMP_MSG_PROPVALUE_GET / AIMP_MSG_PROPVALUE_SET
        // AParam2: Pointer to LongBool (32-bit boolean value) variable
        PropertyRadioCap = PropertyBase + 29,

        // See EventLOADED
        // AParam1: AIMP_MSG_PROPVALUE_GET (ReadOnly)
        // AParam2: Pointer to LongBool (32-bit boolean value) variable
        PropertyLoaded = PropertyBase + 30,

        // AParam1: AIMP_MSG_PROPVALUE_GET / AIMP_MSG_PROPVALUE_SET
        // AParam2: Pointer to LongBool (32-bit boolean value) variable
        PropertyVisualFullscreen = PropertyBase + 31,


        EventBase = 0x2000,

        // Called, when Command state changed; AParam1: Command ID (see CommandXXX)
        EventCmdState = EventBase + 1,

        // Called, when Options has been changed
        EventOptions = EventBase + 2,

        // Called, when audio stream starts playing
        EventStreamStart = EventBase + 3,
        // Similar to EventSTREAM_START event, but called when an Internet radio station changes the track
        EventStreamStartSubtrack = EventBase + 4,
        // Called, when audio stream has been finished
        EventStreamEnd = EventBase + 5,
        // AParam1 contains combination of next flags:
        MesEndOfQueue = 1,
        MesEndOfPlaylist = 2,

        // Called, when player state has been changed (Played / Paused / Stopped)
        // AParam1: 0 = Stopped; 1 = Paused; 2 = Playing
        EventPlayerState = EventBase + 6,

        // Called, when property value has been changed
        // AParam1: PropertyID (see PropertyXXX)
        // AParam2: like AParam2 for each PropertyID
        EventPropertyValue = EventBase + 7,

        // Called, when options frame added / removed
        // AParam1, AParam2: unused
        EventOptionsFrameList = EventBase + 8,

        // Called, when options frame content changed
        // AParam1, AParam2: unused
        EventOptionsFrameModified = EventBase + 9,

        // Called, when swithing between visual plugins
        // AParam1, AParam2: unused
        EventVisualPlugin = EventBase + 11,

        // Called, when mark of file has been changed
        // AParam1: New Mark Value (0..5)
        // AParam2: FileName (Pointer to WideChar)
        // !!!WARNING: You must not fire this event manually!
        EventFilemark = EventBase + 12,

        // Called, when statistics of the file changed
        // AParam2: FileName (Pointer to WideChar),
        // !!!Note: If filename is empty or AParam2 is null - statistics for all files has been changed
        // !!!WARNING: You must not fire this event manually!
        EventStatisticsChanged = EventBase + 14,

        // AParam1, AParam2: unused
        EventSkin = EventBase + 15,

        // Called every second by timer
        //    (Unlike EventPROPERTY_VALUE event for PropertyPLAYER_POSITION property,
        //     Which fires only if user change position of the track)
        // AParam1, AParam2: unused
        EventPlayerUpdatePosition = EventBase + 16,

        // Called, when inteface language has been changed
        // AParam1, AParam2: unused
        EventLanguage = EventBase + 17,

        // Called, when player was initialized
        // AParam1, AParam2: unused
        EventLoaded = EventBase + 18,

        // Called, when AIMP is preparing to terminate
        // AParam1, AParam2: unused
        EventTerminating = EventBase + 19,

        // Called, when information about playable file changed (album, title, album art and etc)
        // AParam1, AParam2: unused
        EventPlayableFileInfo = EventBase + 20,

        // High resolution version of the EventPLAYER_UPDATE_POSITION event
        // Called few times per second by a timer (is about 10 fps, real FPS is depended from some internal and external factors)
        // AParam1, AParam2: unused
        EventPlayerUpdatePositionHr = EventBase + 21,

        // Called, when name of equalizer preset has been changed
        // AParam1: Unused
        // AParam2: Pointer to WideChar array, can be = nil (ReadOnly!)
        EventEqualizerPresetName = EventBase + 22,
    }
}