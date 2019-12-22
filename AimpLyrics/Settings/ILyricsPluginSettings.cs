using AimpLyrics.Themes;

namespace AimpLyrics.Settings
{
    public interface ILyricsPluginSettings
    {
        bool OpenWindowOnInitializing { get; set; }
        bool RestoreWindowLocation { get; set; }
        double WindowTop { get; set; }
        double WindowLeft { get; set; }
        double WindowHeight { get; set; }
        double LyricsFontSize { get; set; }
        Theme Theme { get; set; }
    }
}
