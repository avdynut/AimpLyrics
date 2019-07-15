using AIMP.SDK;
using AIMP.SDK.MenuManager;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace AimpLyrics
{
    [AimpPlugin("AimpLyrics", "Andrey Arekhva", "0.1.0", AimpPluginType = AimpPluginType.Addons, Description = "Lyrics Plugin")]
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
            Trace.Listeners.Add(new TextWriterTraceListener(logFilePath));
            Trace.AutoFlush = true;
        }

        private void AddMenuItem()
        {
            if (Player.MenuManager.CreateMenuItem(out IAimpMenuItem menuItem) == AimpActionResult.OK)
            {
                var action = Player.ActionManager.CreateAction();
                action.Id = "aimp.lyrics.open.window";
                action.Name = "Open Lyrics";
                action.GroupName = "Lyrics";
                action.OnExecute += (sender, args) => _lyricsWindow.Show();

                menuItem.Action = action;
                Player.ActionManager.Register(action);
                Player.MenuManager.Add(ParentMenuType.AIMP_MENUID_COMMON_UTILITIES, menuItem);
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
