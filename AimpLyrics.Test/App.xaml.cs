using System.Windows;

namespace AimpLyrics.Test
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var window = new LyricsWindow(new Player(), new AimpMessageHook());
            window.Show();
        }
    }
}
