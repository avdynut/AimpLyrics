using AIMP.SDK;
using AIMP.SDK.MenuManager;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace AimpLyrics
{
    [AimpPlugin("AimpLyrics", "Andrey Arekhva", "1.0.3", AimpPluginType = AimpPluginType.Addons, Description = "Display lyrics for current playing song. Find lyrics in file, tag or Google")]
    public class AimpLyricsPlugin : AimpPlugin
    {
        private LyricsWindow _lyricsWindow;
        private AimpMessageHook _hook;

        public override void Initialize()
        {
            SetUpLogger();

            _hook = new AimpMessageHook();
            Player.ServiceMessageDispatcher.Hook(_hook);
            _lyricsWindow = new LyricsWindow(Player, _hook);

            AddMenuItem();
        }

        private void SetUpLogger()
        {
            var logFilePath = Path.Combine(Assembly.GetExecutingAssembly().GetName().Name, "log.txt");
            File.Delete(logFilePath);
            Trace.Listeners.Add(new TextWriterTraceListener(logFilePath));
            Trace.AutoFlush = true;
        }

        private void AddMenuItem()
        {
            if (Player.MenuManager.CreateMenuItem(out IAimpMenuItem menuItem) == AimpActionResult.OK)
            {
                menuItem.Id = "aimp.lyrics.open.window";
                menuItem.Name = "Lyrics";

                menuItem.OnExecute += (sender, args) =>
                {
                    _lyricsWindow.Show();
                    _lyricsWindow.Activate();
                };

                var result = Player.MenuManager.Add(ParentMenuType.AIMP_MENUID_COMMON_UTILITIES, menuItem);
                if (result != AimpActionResult.OK)
                {
                    Trace.WriteLine("Menu item is not added");
                }
            }
        }

        public override void Dispose()
        {
            _lyricsWindow?.Close();
            Player.ServiceMessageDispatcher.Unhook(_hook);
            Trace.Close();
        }
    }
}
