using AIMP.SDK;
using AIMP.SDK.MenuManager;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace AimpLyrics
{
    [AimpPlugin("AimpLyrics", "Andrey Arekhva", "0.0.1", AimpPluginType = AimpPluginType.Addons, Description = "Lyrics Plugin")]
    public class AimpLyricsPlugin : AimpPlugin
    {
        private LyricsWindow lyricsWindow;

        public override void Initialize()
        {
            SetUpLogger();
            lyricsWindow = new LyricsWindow(Player);
            AddMenuItem();
        }

        private void SetUpLogger()
        {
            var logFilePath = Path.Combine(Assembly.GetExecutingAssembly().GetName().Name, "log.txt");
            Trace.Listeners.Add(new TextWriterTraceListener(logFilePath));
            Trace.AutoFlush = true;
        }

        private void AddMenuItem()
        {
            if (Player.MenuManager.CreateMenuItem(out IAimpMenuItem menuItem) == AimpActionResult.OK)
            {
                menuItem.Id = menuItem.Name = "Lyrics";
                menuItem.Style = AimpMenuItemStyle.CheckBox;

                menuItem.OnExecute += (sender, args) =>
                {
                    if (lyricsWindow.IsVisible)
                        lyricsWindow.Hide();
                    else
                        lyricsWindow.Show();
                };

                Player.MenuManager.Add(ParentMenuType.AIMP_MENUID_PLAYER_MAIN_FUNCTIONS, menuItem);
            }
        }

        public override void Dispose()
        {
            lyricsWindow.Close();
            Trace.Close();
        }
    }
}
