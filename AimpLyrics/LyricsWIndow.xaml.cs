using AIMP.SDK.Player;
using System.ComponentModel;
using System.Windows;

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
            hook.TrackChanged += () => UpdateSongInfo();

            UpdateSongInfo();
        }

        private void UpdateSongInfo()
        {
            var fileInfo = _player.CurrentFileInfo;
            Artist.Text = fileInfo.Artist;
            Title.Text = fileInfo.Title;
            Lyrics.Text = fileInfo.Lyrics;
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
