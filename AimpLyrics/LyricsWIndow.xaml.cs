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

            hook.TrackChanged += () =>
            {
                ClearLyrics();
                UpdateSongInfo();
            };

            UpdateSongInfo();
        }

        private void UpdateSongInfo()
        {
            Artist.Text = _player.CurrentFileInfo.Artist;
            Title.Text = _player.CurrentFileInfo.Title;
            _player.ServiceLyrics.Get(_player.CurrentFileInfo, 0, null, out _);
        }

        private void ClearLyrics()
        {
            Lyrics.Text = "";
            LyricsSource.Text = "";
        }

        private void OnLyricsReceived(IAimpLyrics lyrics, object userData)
        {
            if (!string.IsNullOrEmpty(lyrics.Text?.Trim()))
            {
                Lyrics.Text = lyrics.Text;
                LyricsSource.Text = "AIMP Lyrics Service";
            }
            else if (!string.IsNullOrEmpty(_player.CurrentFileInfo.Lyrics?.Trim()))
            {
                Lyrics.Text = _player.CurrentFileInfo.Lyrics;
                LyricsSource.Text = "Lyrics Tag";
            }
            else
                SearchLyricsInGoogle();

            Trace.WriteLine($"Lyrics received with text length: {Lyrics.Text.Length}, from source: {LyricsSource.Text}");
        }

        private void SearchLyricsInGoogle()
        {
            string url = $"https://www.google.com/search?q={Artist.Text}+{Title.Text}";
            Browser.Navigate(url);
            Trace.WriteLine($"Seaching lyrics by URL: {url}");
        }

        private void OnBrowserLoadCompleted(object sender, NavigationEventArgs e)
        {
            var doc = (HTMLDocument)Browser.Document;
            var nodes = doc.getElementsByTagName("g-expandable-content");

            bool found = false;
            foreach (var node in nodes)
            {
                var element = (IHTMLElement)node;
                if (element.getAttribute("data-lyricid") is string && element.getAttribute("aria-hidden") == "true")
                {
                    Lyrics.Text = element.innerText;
                    found = true;
                    break;
                }
            }
            LyricsSource.Text = found ? "Google" : "None";
        }

        private void OnSearchButtonClick(object sender, RoutedEventArgs e)
        {
            ClearLyrics();
            SearchLyricsInGoogle();
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
