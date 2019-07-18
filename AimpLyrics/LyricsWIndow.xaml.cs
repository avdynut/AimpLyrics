using AIMP.SDK.Lyrics;
using AIMP.SDK.Player;
using mshtml;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;

namespace AimpLyrics
{
    /// <summary>
    /// Interaction logic for LyricsWindow.xaml
    /// </summary>
    public partial class LyricsWindow : Window
    {
        private readonly IAimpPlayer _player;

        public LyricsWindow(IAimpPlayer player, AimpMessageHook hook)
        {
            InitializeComponent();

            _player = player;
            _player.ServiceLyrics.LyricsReceive += OnLyricsReceived;

            hook.TrackChanged += () => GetCurrentLyrics();
            GetCurrentLyrics();
        }

        private void GetCurrentLyrics()
        {
            _player.ServiceLyrics.Get(_player.CurrentFileInfo, 0, null, out _);
        }

        private void OnLyricsReceived(IAimpLyrics lyrics, object userData)
        {
            var fileInfo = _player.CurrentFileInfo;
            Artist.Text = fileInfo.Artist;
            Title.Text = fileInfo.Title;
            Lyrics.Text = lyrics.Text.Length > 0 ? lyrics.Text : fileInfo.Lyrics;
            Trace.WriteLine($"Lyrics received with text length: {lyrics.Text.Length}, from tag: {fileInfo.Lyrics.Length}");

            if (string.IsNullOrEmpty(Lyrics.Text))
            {
                string url = $"https://www.google.com/search?q={fileInfo.Artist}+{fileInfo.Title}";
                Browser.Navigate(url);
            }
        }

        private void OnBrowserLoadCompleted(object sender, NavigationEventArgs e)
        {
            var doc = (HTMLDocument)Browser.Document;
            var nodes = doc.getElementsByTagName("g-expandable-content");

            foreach (var node in nodes)
            {
                var element = (IHTMLElement)node;
                if (element.getAttribute("data-lyricid") is string && element.getAttribute("aria-hidden") == "true")
                {
                    Lyrics.Text = element.innerText;
                    break;
                }
            }
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
