using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-5372-7650-6C61-796572000000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPServicePlayer
    {
        // Start Playback
        void Play(IAIMPPlaybackQueueItem item);
        void Play2(IAIMPPlaylistItem item);
        void Play3(IAIMPPlaylist playlist);
        void Play4(IAIMPString fileUri, AIMPServicePlayerPlayFlags flags);
        // Navigation
        void GoToNext();
        void GoToPrev();
        // Playable File Control
        double GetDuration();
        double GetPosition();
        void SetPosition(double seconds);

        [return: MarshalAs(UnmanagedType.Bool)]
        bool GetMute();

        void SetMute([MarshalAs(UnmanagedType.Bool)] bool value);
        float GetVolume();
        void SetVolume(float level);
        IAIMPFileInfo GetInfo();
        IAIMPPlaylistItem GetPlaylistItem();

        [PreserveSig]
        int GetState();

        void Pause();
        void Resume();
        void Stop();
        void StopAfterTrack();
    }
}