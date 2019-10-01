using AIMP.SDK;
using AIMP.SDK.ActionManager;
using AIMP.SDK.AlbumArtManager;
using AIMP.SDK.ConfigurationManager;
using AIMP.SDK.FileManager;
using AIMP.SDK.Lyrics;
using AIMP.SDK.MenuManager;
using AIMP.SDK.MessageDispatcher;
using AIMP.SDK.MUIManager;
using AIMP.SDK.MusicLibrary;
using AIMP.SDK.Options;
using AIMP.SDK.Playback;
using AIMP.SDK.Player;
using AIMP.SDK.Playlist;
using AIMP.SDK.TagEditor;
using AIMP.SDK.Threading;
using AIMP.SDK.Win32;
using System;

namespace AimpLyrics.Test
{
    public class Player : IAimpPlayer
    {
        public IAimpCore Core => throw new NotImplementedException();

        public IAimpServiceMenuManager MenuManager => throw new NotImplementedException();

        public IAimpServiceActionManager ActionManager => throw new NotImplementedException();

        public IAimpMUIManager MUIManager => throw new NotImplementedException();

        public IAimpAlbumArtManager AlbumArtManager => throw new NotImplementedException();

        public IAimpServiceConfig ServiceConfig => throw new NotImplementedException();

        public IAimpPlaylistManager2 PlaylistManager => throw new NotImplementedException();

        public IAimpPlaybackQueueService PlaybackQueueManager => throw new NotImplementedException();

        public IAimpServiceOptionsDialog ServiceOptionsDialog => throw new NotImplementedException();

        public IAimpServiceMessageDispatcher ServiceMessageDispatcher => new ServiceMessageDispatcher();

        public bool IsMute { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float Volume { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public double Duration => throw new NotImplementedException();

        public double Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public AimpPlayerState State => throw new NotImplementedException();

        public IAimpFileInfo CurrentFileInfo => new FileInfo();

        public IAimpPlaylistItem CurrentPlaylistItem => throw new NotImplementedException();

        public IWin32Manager Win32Manager => throw new NotImplementedException();

        public IAimpServiceSynchronizer ServiceSynchronizer => throw new NotImplementedException();

        public IAimpServiceThreadPool ServiceThreadPool => throw new NotImplementedException();

        public IAimpServiceMusicLibrary ServiceMusicLibrary => throw new NotImplementedException();

        public IAimpServiceMusicLibraryUI ServiceMusicLibraryUi => throw new NotImplementedException();

        public IAimpServiceFileFormats ServiceFileFormats => throw new NotImplementedException();

        public IAimpServiceFileInfo ServiceFileInfo => throw new NotImplementedException();

        public IAimpServiceFileSystems ServiceFileSystems => throw new NotImplementedException();

        public IAimpServiceFileStreaming ServiceFileStreaming => throw new NotImplementedException();

        public IAimpServiceFileInfoFormatter ServiceFileInfoFormatter => throw new NotImplementedException();

        public IAimpServiceFileTagEditor ServiceFileTagEditor => new ServiceFileTagEditor();

        public IAimpServiceLyrics ServiceLyrics => throw new NotImplementedException();

        public event EventHandler LanguageChanged;
        public event EventHandler TrackChanged;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void GoToNext()
        {
            throw new NotImplementedException();
        }

        public void GoToPrev()
        {
            throw new NotImplementedException();
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void Play(IAimpPlaybackQueueItem queueItem)
        {
            throw new NotImplementedException();
        }

        public void Play(IAimpPlaylistItem playlistItem)
        {
            throw new NotImplementedException();
        }

        public void Play(IAimpPlaylist playList)
        {
            throw new NotImplementedException();
        }

        public void Resume()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void StopAfterTrack()
        {
            throw new NotImplementedException();
        }
    }
}
