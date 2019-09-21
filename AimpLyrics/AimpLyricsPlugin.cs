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
        public override void Initialize()
        {
            SetUpLogger();
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
            var menuItemCreated = Player.MenuManager.CreateMenuItem(out IAimpMenuItem menuItem);
            if (menuItemCreated != AimpActionResult.OK)
                return;

            var action = Player.ActionManager.CreateAction();
            action.Id = "aimp.lyrics.open.window";
            action.Name = "Open Lyrics";
            action.GroupName = "Lyrics";

            action.OnExecute += (sender, args) =>
            {
                var lyricsWindow = new LyricsWindow(Player);
                lyricsWindow.Show();
                lyricsWindow.Activate();
            };

            menuItem.Action = action;
            if (Player.ActionManager.Register(action) == AimpActionResult.OK)
                Player.MenuManager.Add(ParentMenuType.AIMP_MENUID_COMMON_UTILITIES, menuItem);
        }

        public override void Dispose()
        {
            Trace.Close();
        }
    }
}
