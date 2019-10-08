namespace AimpLyrics.Settings
{
    public interface ILyricsPluginSettings
    {
        bool OpenWindowOnInitializing { get; set; }
        bool RestoreWindowHeight { get; set; }
        int WindowHeight { get; set; }
    }
}
