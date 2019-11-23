using AimpLyrics.Themes;

namespace AimpLyrics.Settings
{
    public interface ILyricsPluginSettings
    {
        bool OpenWindowOnInitializing { get; set; }
        bool RestoreWindowHeight { get; set; }
        double WindowHeight { get; set; }
        Theme Theme { get; set; }
    }
}
