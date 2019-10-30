using Aimp4.Api;
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
        private string _filePath;
        private string _lyricsFilePath;
        private string _lyrics;
        private LyricsSource _source;

        private bool _hideOnClosing = true;

        public LyricsWindow()
        {
            InitializeComponent();

            Loaded += (s, e) => UpdateSongInfo();
        }

        public void UpdateSongInfo()
        {
            ClearLyrics();

            var player = AimpLyricsPlugin.Core.GetService<IAIMPServicePlayer>();
            var aimpFileInfo = player.GetInfo();

            Artist.Text = aimpFileInfo.GetStringValue(AIMPFileInfoPropId.Artist);
            Title.Text = aimpFileInfo.GetStringValue(AIMPFileInfoPropId.Title);
            _lyrics = aimpFileInfo.GetStringValue(AIMPFileInfoPropId.Lyrics);
            _filePath = aimpFileInfo.GetStringValue(AIMPFileInfoPropId.FileName);
            aimpFileInfo?.ReleaseComObject();

            bool found = GetLyricsFromFile();
            if (!found)
                found = GetLyricsFromTag();
            if (!found)
                SearchLyricsInGoogleOnBackground();
        }

        private void ClearLyrics()
        {
            Lyrics.Text = "";
            Source.Text = "";
            _source = LyricsSource.None;
        }

        private bool GetLyricsFromFile()
        {
            string directory = Path.GetDirectoryName(_filePath);
            string filePattern = Path.GetFileNameWithoutExtension(_filePath) + ".*";
            _lyricsFilePath = Directory.EnumerateFiles(directory, filePattern)
                .FirstOrDefault(x => x.ToLower().EndsWith(".txt") || x.ToLower().EndsWith(".lrc") || x.ToLower().EndsWith(".srt"));

            if (_lyricsFilePath == null)
                return false;

            Lyrics.Text = File.ReadAllText(_lyricsFilePath);
            _source = LyricsSource.File;
            Source.Text = Path.GetFileName(_lyricsFilePath);
            Trace.WriteLine($"Lyrics received from {_lyricsFilePath}");
            return true;
        }

        private bool GetLyricsFromTag()
        {
            if (string.IsNullOrEmpty(_lyrics))
                return false;

            Lyrics.Text = _lyrics;
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
            try
            {
                File.WriteAllText("doc.html", html);
            }
            catch (IOException ex)
            {
                Debug.WriteLine($"Cannot write to file: {ex}");
            }
#endif

            var doc = (IHTMLDocument2)new HTMLDocument();
            doc.write(html);
            var lyrics = ParseLyrics((HTMLDocument)doc);

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

            if (_filePath == null)
            {
                dialog.FileName = $"{Artist.Text} - {Title.Text}.txt";
            }
            else
            {
                dialog.FileName = Path.GetFileNameWithoutExtension(_filePath) + ".txt";
                dialog.InitialDirectory = Path.GetDirectoryName(_filePath);
            }

            if (dialog.ShowDialog() != true)
                return;

            _lyricsFilePath = dialog.FileName;
            File.WriteAllText(_lyricsFilePath, Lyrics.Text);
            Source.Text = Path.GetFileName(_lyricsFilePath);
            _source = LyricsSource.File;
            Trace.WriteLine($"Lyrics have been saved to {_lyricsFilePath}");
        }

        private void SaveLyricsToTag()
        {
            if (_filePath == null)
                return;

            var tagEditorService = AimpLyricsPlugin.Core.GetService<IAIMPServiceFileTagEditor>();
            var aimpString = AimpLyricsPlugin.Core.CreateString(_filePath);
            var guid = typeof(IAIMPFileTagEditor).GUID;
            var tagEditor = (IAIMPFileTagEditor)tagEditorService.EditFile(aimpString, ref guid);
            var tagCount = tagEditor.GetTagCount();

            guid = typeof(IAIMPFileTag).GUID;
            IAIMPFileTag? fileTag = null;
            for (int i = 0; i < tagCount; i++)
            {

                fileTag = (IAIMPFileTag)tagEditor.GetTag(i, ref guid);
                int tagId = fileTag.GetValueAsInt32(AIMPFileTagPropId.TagId);
                if (tagId == (int)AIMPFileTagId.ID3v2)
                {
                    aimpString = AimpLyricsPlugin.Core.CreateString(Lyrics.Text);
                    fileTag.SetValueAsObject(AIMPFileTagPropId.Lyrics, aimpString);

                    tagEditor.SetToAll(fileTag);
                    tagEditor.Save();
                    Debug.WriteLine("Lyrics have been saved to tag");
                }
            }

            fileTag?.ReleaseComObject();
            aimpString?.ReleaseComObject();
            tagEditor?.ReleaseComObject();
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

        protected override void OnClosing(CancelEventArgs e)
        {
            if (_hideOnClosing)
            {
                Hide();
                e.Cancel = true;
            }
            else
            {
                base.OnClosing(e);
            }
        }

        public new void Close()
        {
            _hideOnClosing = false;
            base.Close();
        }
    }
}
