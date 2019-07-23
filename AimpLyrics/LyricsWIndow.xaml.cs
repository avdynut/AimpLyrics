using AIMP.SDK.Lyrics;
using AIMP.SDK.Player;
using mshtml;
using System.ComponentModel;
using System.Diagnostics;
using System.Web;
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

            hook.FileInfoReceived += UpdateSongInfo;

#if DEBUG
            BrowserPanel.Visibility = Visibility.Visible;
            UpdateSongInfo();
#endif
        }

        private void UpdateSongInfo()
        {
            ClearLyrics();
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

            var text = Lyrics.Text;
            if (text.Length > 0)
            {
                Trace.WriteLine($"Lyrics received with text length: {text.Length}, from source: {LyricsSource.Text}");
                //_player.CurrentFileInfo.Lyrics = text;
                // todo: save lyrics to tag
            }
            else
                Trace.WriteLine("Lyrics not found");
        }

        private void SearchLyricsInGoogle()
        {
            string searchTerm = HttpUtility.UrlEncode($"{Artist.Text} {Title.Text} lyrics");
            Browser.Navigate("https://www.google.com/search?q=" + searchTerm);
            Trace.WriteLine($"Seaching lyrics by term: {searchTerm}");
        }

        private void OnBrowserLoadCompleted(object sender, NavigationEventArgs e)
        {
            var doc = (HTMLDocument)Browser.Document;
            var divs = doc.getElementsByTagName("div");

            // find Expand button
            foreach (var div in divs)
            {
                var element = (IHTMLElement)div;
                if (element.getAttribute("role") == "button" && element.getAttribute("aria-expanded") == "false")
                {
                    element.click();
                    break;
                }
            }

            bool found = false;
            foreach (var div in divs)
            {
                var element = (IHTMLElement)div;
                if (element.className == "Oh5wg")
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
