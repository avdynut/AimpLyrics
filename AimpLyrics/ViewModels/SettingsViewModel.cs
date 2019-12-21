using AimpLyrics.Settings;
using AimpLyrics.Themes;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;

namespace AimpLyrics.ViewModels
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        private readonly ILyricsPluginSettings _settings;

        //public double WindowHeight
        //{
        //    get => _settings.WindowHeight;
        //    set
        //    {
        //        _settings.WindowHeight = value;
        //        OnPropertyChanged();
        //    }
        //}

        public double LyricsFontSize
        {
            get => _settings.LyricsFontSize;
            set
            {
                _settings.LyricsFontSize = value;
                OnPropertyChanged();
            }
        }

        public Theme Theme
        {
            get
            {
                if (_settings.Theme == Theme.Auto)
                {
                    try
                    {
                        string lightValue = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", "1")?.ToString();
                        _settings.Theme = lightValue == "1" ? Theme.Light : Theme.Dark;
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine($"Cannot get registry value: {ex}");
                        _settings.Theme = Theme.Dark;
                    }
                }

                var uri = new Uri($"pack://application:,,,/AimpLyrics;component/Themes/{_settings.Theme}.xaml");
                Application.Current.MainWindow.Resources.MergedDictionaries[0].Source = uri;
                return _settings.Theme;
            }
            set
            {
                _settings.Theme = value;
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
