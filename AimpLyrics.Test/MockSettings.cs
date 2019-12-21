using AimpLyrics.Settings;
using AimpLyrics.Themes;

namespace AimpLyrics.Test
{
    public class MockSettings : ILyricsPluginSettings
    {
        public bool OpenWindowOnInitializing { get; set; }
        public bool RestoreWindowHeight { get; set; }
        public double WindowHeight { get; set; } = 600;
        public double LyricsFontSize { get; set; } = 20;
        public Theme Theme { get; set; } = Theme.Dark;
    }
}
