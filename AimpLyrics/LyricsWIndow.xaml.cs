using Aimp4.Api;
using AimpLyrics.Settings;
using AimpLyrics.Themes;
using Microsoft.Win32;
using mshtml;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
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
        private string _artist;
        private string _title;
        private LyricsSource _source;

        private string ArtistTitle => string.IsNullOrEmpty(_artist) && string.IsNullOrEmpty(_title) ?
            "🎵" : $"{_artist} - {_title}";

        public LyricsWindow()
        {
            InitializeComponent();
        }

        public void UpdateSongInfo()
        {
            ClearLyrics();

            var player = AimpLyricsPlugin.Core.GetService<IAIMPServicePlayer>();
            var aimpFileInfo = player.GetInfo();

            _artist = aimpFileInfo.GetStringValue(AIMPFileInfoPropId.Artist);
            _title = aimpFileInfo.GetStringValue(AIMPFileInfoPropId.Title);
            WindowTitle.Text = $"[Lyrics] {ArtistTitle}";
            SearchTerm.Text = $"{_artist} {_title} lyrics";

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
            string searchTerm = SearchTerm.Text;
            if (string.IsNullOrEmpty(searchTerm))
                return;

            var thread = new Thread(() => SearchLyricsInGoogle(searchTerm));
            thread.Start();
        }

        private void SearchLyricsInGoogle(string searchTerm)
        {
            string encoded = HttpUtility.UrlEncode(searchTerm);
            string url = $"https://www.google.com/search?q={encoded}";
            Trace.WriteLine($"Searching lyrics by term: {encoded}");

            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.75 Safari/537.36");
            httpClient.DefaultRequestHeaders.AcceptLanguage.ParseAdd("ru,en");
            var html = httpClient.GetStringAsync(url).Result;

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
                dialog.FileName = $"{ArtistTitle}.txt";
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
            IAIMPFileTag fileTag = null;
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

        private void OnThemesSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var theme = (Theme)e.AddedItems[0];

            if (theme == Theme.Auto)
            {
                try
                {
                    string lightValue = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", "1")?.ToString();
                    theme = lightValue == "1" ? Theme.Light : Theme.Dark;
                }
                catch (Exception ex)
                {
                    Trace.WriteLine($"Cannot get registry value: {ex}");
                    theme = Theme.Dark;
                }
            }

            var uri = new Uri($"pack://application:,,,/AimpLyrics;component/Themes/{theme}.xaml");
            Resources.MergedDictionaries[0].Source = uri;

            ThemesPopup.IsOpen = false;

            var settings = new AimpLyricsPluginSettings();
            settings.Theme = theme;
        }

        private void OnMinimizeButtonClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        //private void OnMaximizeButtonClick(object sender, RoutedEventArgs e)
        //{
        //    var path = (System.Windows.Shapes.Path)FindName("MaxButtonPath");
        //    if (WindowState == WindowState.Maximized)
        //    {
        //        WindowState = WindowState.Normal;
        //        path.Data = Geometry.Parse("M1,1L1,11 11,11 11,1z M0,0L12,0 12,12 0,12z");
        //    }
        //    else
        //    {
        //        WindowState = WindowState.Maximized;
        //        path.Data = Geometry.Parse("M1,4.56L1,14.56 11,14.56 11,4.56z M4,1L4,3.56 12,3.56 12,11 14,11 14,1z M3,0L15,0 15,12 12,12 12,15.56 0,15.56 0,3.56 3,3.56z");
        //    }
        //}

        private void OnCloseButtonClick(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        private void OnTitleBarMouseDown(object sender, MouseButtonEventArgs e)
        {
            // move window
            SendMessage(new WindowInteropHelper(this).Handle, 0xA1, (IntPtr)0x2, (IntPtr)0);
        }

        private void OnSelectThemeButtonClick(object sender, RoutedEventArgs e)
        {
            ThemesPopup.IsOpen = true;
        }
    }
}
