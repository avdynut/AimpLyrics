using AIMP.SDK;
using AIMP.SDK.FileManager;
using AIMP.SDK.Player;
using mshtml;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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

        private IAimpFileInfo _fileInfo;
        private string _filePath;
        private LyricsSource _source;

        public LyricsWindow(IAimpPlayer player, AimpMessageHook hook)
        {
            InitializeComponent();

            _player = player;
            hook.FileInfoReceived += UpdateSongInfo;

#if DEBUG
            BrowserPanel.Visibility = Visibility.Visible;
#endif
            Loaded += (s, e) => UpdateSongInfo();
        }

        private void UpdateSongInfo()
        {
            ClearLyrics();
            _fileInfo = _player.CurrentFileInfo;
            Artist.Text = _fileInfo.Artist;
            Title.Text = _fileInfo.Title;

            bool found = GetLyricsFromFile();
            if (!found)
                found = GetLyricsFromTag();
            if (!found)
                SearchLyricsInGoogle();
        }

        private void ClearLyrics()
        {
            Lyrics.Text = "";
            Source.Text = "";
            _source = LyricsSource.None;
        }

        private bool GetLyricsFromFile()
        {
            string directory = Path.GetDirectoryName(_fileInfo.FileName);
            string filePattern = Path.GetFileNameWithoutExtension(_fileInfo.FileName) + ".*";
            _filePath = Directory.EnumerateFiles(directory, filePattern)
                .FirstOrDefault(x => x.ToLower().EndsWith(".txt") || x.ToLower().EndsWith(".lrc") || x.ToLower().EndsWith(".srt"));

            if (_filePath == null)
                return false;

            Lyrics.Text = File.ReadAllText(_filePath);
            _source = LyricsSource.File;
            Source.Text = Path.GetFileName(_filePath);
            Trace.WriteLine($"Lyrics received from {_filePath}");
            return true;
        }

        private bool GetLyricsFromTag()
        {
            if (string.IsNullOrEmpty(_fileInfo.Lyrics))
                return false;

            Lyrics.Text = _fileInfo.Lyrics;
            _source = LyricsSource.Tag;
            Source.Text = _source.ToString();
            Trace.WriteLine("Lyrics received from lyrics tag");
            return true;
        }

        private void SearchLyricsInGoogle()
        {
            string searchTerm = HttpUtility.UrlEncode($"{Artist.Text} {Title.Text} lyrics");
            Browser.Navigate("https://www.google.com/search?q=" + searchTerm);
            Trace.WriteLine($"Seaching lyrics by term: {searchTerm}");
        }

        private async void OnBrowserLoadCompleted(object sender, NavigationEventArgs e)
        {
            var doc = (HTMLDocument)Browser.Document;
            string lyrics = await Task.Run(() => ParseLyrics(doc));

            if (lyrics == null)
            {
                Trace.WriteLine("Lyrics not found");
                Source.Text = "Not Found";
            }
            else
            {
                Lyrics.Text = lyrics;
                _source = LyricsSource.Google;
                Source.Text = _source.ToString();
                Trace.WriteLine("Lyrics received from Google");
            }
        }

        private string ParseLyrics(HTMLDocument doc)
        {
            try
            {
                var divs = doc.getElementsByTagName("div");

                foreach (var div in divs)
                {
                    var element = (IHTMLElement)div;
                    if (element.className == "Oh5wg")
                    {
                        var text = (element.children as IHTMLElementCollection).Cast<IHTMLElement>()
                            .Select(x => x.innerText?.Trim()).Where(x => !string.IsNullOrEmpty(x)).ToArray();
                        string lyrics = text[0];
                        int cutIndex = lyrics.LastIndexOf("\r\n\r\n") + 1;
                        lyrics = lyrics.Remove(cutIndex);
                        lyrics += text[1];
                        return lyrics;
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }
            return null;
        }

        private void SaveLyricsToFile()
        {
            File.WriteAllText(_filePath, Lyrics.Text);
            Trace.WriteLine($"Lyrics have been saved to {_filePath}");
        }

        // doesn't save for some reason
        private void SaveLyricsToTag()
        {
            if (_player.ServiceFileTagEditor.EditFile(_fileInfo.FileName, out var tagEditor) == AimpActionResult.OK)
            {
                if (tagEditor.GetMixedInfo(out var fileInfo) == AimpActionResult.OK)
                {
                    fileInfo.Lyrics = Lyrics.Text;
                    if (tagEditor.Save() == AimpActionResult.OK)
                        Trace.WriteLine("Lyrics have been saved to tag");
                }
            }
        }

        private void SaveLyrics(object sender, RoutedEventArgs e)
        {
            switch (_source)
            {
                case LyricsSource.None:
                    return;
                case LyricsSource.Tag:
                    SaveLyricsToTag();
                    break;
                case LyricsSource.File:
                    SaveLyricsToFile();
                    break;
                case LyricsSource.Google:
                    _filePath = Path.ChangeExtension(_fileInfo.FileName, "txt");
                    _source = LyricsSource.File;
                    Source.Text = Path.GetFileName(_filePath);
                    SaveLyricsToFile();
                    break;
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
