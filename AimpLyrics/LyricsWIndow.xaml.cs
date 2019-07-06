using AIMP.SDK.Player;
using System;
using System.Windows;

namespace AimpLyrics
{
    /// <summary>
    /// Interaction logic for LyricsWindow.xaml
    /// </summary>
    public partial class LyricsWindow : Window
    {
        private readonly IAimpPlayer _player;

        public LyricsWindow(IAimpPlayer player)
        {
            InitializeComponent();

            _player = player;
            _player.TrackChanged += OnPlayerTrackChanged;
            UpdateSongInfo();
        }

        private void OnPlayerTrackChanged(object sender, EventArgs e)
        {
            UpdateSongInfo();
        }

        private void UpdateSongInfo()
        {
            var fileInfo = _player.CurrentFileInfo;
            Artist.Text = fileInfo.Artist;
            Title.Text = fileInfo.Title;
            Lyrics.Text = fileInfo.Lyrics;
        }
    }
}
