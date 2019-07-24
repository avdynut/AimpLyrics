using AIMP.SDK;
using AIMP.SDK.Lyrics;
using AIMP.SDK.Player;
using mshtml;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
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

        private void SetLyrics(string lyrics, string source)
        {
            Lyrics.Text = lyrics;
            LyricsSource.Text = source;
            Trace.WriteLine($"Lyrics received with text length: {lyrics.Length}, from source: {source}");
        }

        private void OnLyricsReceived(IAimpLyrics lyrics, object userData)
        {
            if (!string.IsNullOrEmpty(lyrics.Text?.Trim()))
                SetLyrics(lyrics.Text, "AIMP Lyrics Service");
            else if (!string.IsNullOrEmpty(_player.CurrentFileInfo.Lyrics?.Trim()))
                SetLyrics(_player.CurrentFileInfo.Lyrics, "Lyrics Tag");
            else
                SearchLyricsInGoogle();
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
                    SetLyrics(element.innerText, "Google");
                    found = true;
                    break;
                }
            }

            if (found)
                SaveLyricsToFile();
            else
            {
                LyricsSource.Text = "None";
                Trace.WriteLine("Lyrics not found");
            }
        }

        private void SaveLyricsToFile()
        {
            string path = Path.ChangeExtension(_player.CurrentFileInfo.FileName, "txt");
            File.WriteAllText(path, Lyrics.Text);
        }

        // doesn't save for some reason
        private void SaveLyricsToTag()
        {
            if (_player.ServiceFileTagEditor.EditFile(_player.CurrentFileInfo.FileName, out var tagEditor) == AimpActionResult.OK)
            {
                if (tagEditor.GetMixedInfo(out var fileInfo) == AimpActionResult.OK)
                {
                    fileInfo.Lyrics = Lyrics.Text;
                    if (tagEditor.Save() == AimpActionResult.OK)
                        Trace.WriteLine("Lyrics have been saved to tag");
                }
            }
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
