using AimpLyrics.Settings;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AimpLyrics.ViewModels
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        private readonly ILyricsPluginSettings _settings;

        public double LyricsFontSize
        {
            get => _settings.LyricsFontSize;
            set
            {
                _settings.LyricsFontSize = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public SettingsViewModel(ILyricsPluginSettings settings)
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
