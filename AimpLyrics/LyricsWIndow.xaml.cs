using AIMP.SDK;
using AIMP.SDK.FileManager;
using AIMP.SDK.Player;
using Microsoft.Win32;
using mshtml;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Windows;
using System.Windows.Threading;

namespace AimpLyrics
{
    /// <summary>
    /// Interaction logic for LyricsWindow.xaml
    /// </summary>
    public partial class LyricsWindow : Window
    {
        private readonly IAimpPlayer _player;
        private readonly AimpMessageHook _hook;

        private IAimpFileInfo _fileInfo;
        private string _filePath;
        private LyricsSource _source;

        public LyricsWindow(IAimpPlayer player)
        {
            InitializeComponent();

            _player = player;

            _hook = new AimpMessageHook();
            _hook.FileInfoReceived += UpdateSongInfo;
            _hook.PlayerStopped += ResetFileInfo;
            _player.ServiceMessageDispatcher.Hook(_hook);

            Loaded += (s, e) => UpdateSongInfo();
        }

        private void UpdateSongInfo()
        {
            _fileInfo = _player.CurrentFileInfo;
            if (_fileInfo == null)
                return;

            ClearLyrics();
            Artist.Text = _fileInfo.Artist;
            Title.Text = _fileInfo.Title;

            bool found = GetLyricsFromFile();
            if (!found)
                found = GetLyricsFromTag();
            if (!found)
                SearchLyricsInGoogleOnBackground();
        }

        private void ResetFileInfo()
        {
            _fileInfo = null;
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

        private void SearchLyricsInGoogleOnBackground()
        {
            string artist = Artist.Text;
            string title = Title.Text;
            var thread = new Thread(() => SearchLyricsInGoogle(artist, title));
            thread.Start();
        }

        private void SearchLyricsInGoogle(string artist, string title)
        {
            if (string.IsNullOrEmpty(artist) && string.IsNullOrEmpty(title))
                return;
            string searchTerm = HttpUtility.UrlEncode($"{artist} {title} lyrics");
            string url = "https://www.google.com/search?q=" + searchTerm;
            Trace.WriteLine($"Seaching lyrics by term: {searchTerm}");

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.75 Safari/537.36");
            httpClient.DefaultRequestHeaders.AcceptLanguage.ParseAdd("ru,en");
            var html = httpClient.GetStringAsync(url).Result;

#if DEBUG
            File.WriteAllText("doc.html", html);
#endif

            var doc = new HTMLDocument() as IHTMLDocument2;
            doc.write(html);
            string lyrics = ParseLyrics(doc as HTMLDocument);

            if (string.IsNullOrEmpty(lyrics))
            {
                Dispatcher.BeginInvoke(new Action(() => Source.Text = "Not Found"));
                Trace.WriteLine("Lyrics not found");
            }
            else
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    Lyrics.Text = lyrics;
                    _source = LyricsSource.Google;
                    Source.Text = _source.ToString();
                }));
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
                        var blocks = (element.children as IHTMLElementCollection).Cast<IHTMLElement>().ToList();
                        if (blocks.Count > 2)
                            blocks.RemoveAt(0);
                        var visibleVerses = (blocks[0].children as IHTMLElementCollection).Cast<IHTMLElement>().ToArray();

                        string text = "";
                        string twoNewLines = Environment.NewLine + Environment.NewLine;
                        for (int i = 0; i < visibleVerses.Length - 1; i++)
                            text += visibleVerses[i].innerText + twoNewLines;

                        var hiddenVerses = (blocks[1].children as IHTMLElementCollection).Cast<IHTMLElement>().Select(x => x.innerText);
                        text += string.Join(twoNewLines, hiddenVerses);

                        return text;
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
            var dialog = new SaveFileDialog
            {
                Filter = "Text file (*.txt)|*.txt|Lyrics file (*.lrc)|*.lrc|Subtitles file (*.srt)|*.srt"
            };

            if (_fileInfo == null)
            {
                dialog.FileName = $"{Artist.Text} - {Title.Text}.txt";
            }
            else
            {
                dialog.FileName = Path.GetFileNameWithoutExtension(_fileInfo.FileName) + ".txt";
                dialog.InitialDirectory = Path.GetDirectoryName(_fileInfo.FileName);
            }

            if (dialog.ShowDialog() != true)
                return;

            _filePath = dialog.FileName;
            File.WriteAllText(_filePath, Lyrics.Text);
            Source.Text = Path.GetFileName(_filePath);
            _source = LyricsSource.File;
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
            SaveLyricsToFile();
        }

        private void OnSearchButtonClick(object sender, RoutedEventArgs e)
        {
            ClearLyrics();
            SearchLyricsInGoogleOnBackground();
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            _hook.FileInfoReceived -= UpdateSongInfo;
            _hook.PlayerStopped -= ResetFileInfo;
            _player.ServiceMessageDispatcher.Unhook(_hook);
        }
    }
}
