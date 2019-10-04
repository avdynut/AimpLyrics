﻿using AIMP.SDK;
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
            if (AddMenuItem())
            {
                SetUpLogger();

                _hook = new AimpMessageHook();
                Player.ServiceMessageDispatcher.Hook(_hook);

                _lyricsWindow = new LyricsWindow(Player, _hook);

                Trace.WriteLine($"Initialized AIMP Lyrics Plugin v{Assembly.GetExecutingAssembly().GetName().Version}");
            }
            else
            {
                Trace.WriteLine("Menu item was not added");
            }
        }

        private void SetUpLogger()
        {
            var logFilePath = Path.Combine(Assembly.GetExecutingAssembly().GetName().Name, "log.txt");
            File.Delete(logFilePath);
            Trace.Listeners.Add(new TextWriterTraceListener(logFilePath));
            Trace.AutoFlush = true;
        }

        private bool AddMenuItem()
        {
            if (Player.MenuManager.CreateMenuItem(out IAimpMenuItem menuItem) != AimpActionResult.OK)
                return false;

            var action = Player.ActionManager.CreateAction();
            action.Id = "aimp.lyrics.open.window";
            action.Name = "Open Lyrics";
            action.GroupName = "Lyrics";

            action.OnExecute += (sender, args) =>
            {
                _lyricsWindow.Show();
                _lyricsWindow.Activate();
            };

            menuItem.Action = action;

            if (Player.ActionManager.Register(action) != AimpActionResult.OK)
                return false;

            return Player.MenuManager.Add(ParentMenuType.AIMP_MENUID_COMMON_UTILITIES, menuItem) == AimpActionResult.OK;
        }

        public override void Dispose()
        {
            _lyricsWindow?.Close();
            Player.ServiceMessageDispatcher.Unhook(_hook);
            Trace.Close();
        }
    }
}
