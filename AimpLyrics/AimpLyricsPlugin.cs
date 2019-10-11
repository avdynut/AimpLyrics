using AIMP.SDK;
using AIMP.SDK.MenuManager;
using AimpLyrics.Settings;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Input;

#nullable enable
namespace AimpLyrics
{
    [AimpPlugin("AimpLyrics", "Andrey Arekhva", "1.0.3", AimpPluginType = AimpPluginType.Addons, Description = "Display lyrics for current playing song. Find lyrics in file, tag or Google")]
    public class AimpLyricsPlugin : AimpPlugin
    {
        private LyricsWindow? _lyricsWindow;
        private AimpMessageHook? _hook;
        private ILyricsPluginSettings? _settings;

        public override void Initialize()
        {
            if (!AddMenuItem())
                return;

            _hook = new AimpMessageHook();
            Player.ServiceMessageDispatcher.Hook(_hook);

            _settings = new AimpLyricsPluginSettings(Player.ServiceConfig);

            if (_settings.OpenWindowOnInitializing)
                _hook.PlayerLoaded += OnPlayerLoaded;

            _lyricsWindow = new LyricsWindow(Player, _hook);

            if (_settings.RestoreWindowHeight)
                _lyricsWindow.Height = _settings.WindowHeight;

            SetUpLogger();
            RegisterOptions();

            Trace.WriteLine($"Initialized AIMP Lyrics Plugin v{Assembly.GetExecutingAssembly().GetName().Version}");
        }

        private void OnPlayerLoaded()
        {
            ShowLyricsWindow();
            _hook.PlayerLoaded -= OnPlayerLoaded;
        }

        private void ShowLyricsWindow()
        {
            _lyricsWindow?.Show();
            _lyricsWindow?.Activate();
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
            action.DefaultLocalHotKey = Player.ActionManager.MakeHotkey(ModifierKeys.Shift, (uint)Keys.L);
            action.DefaultGlobalHotKey = Player.ActionManager.MakeHotkey(ModifierKeys.Control | ModifierKeys.Alt, (uint)Keys.L);
            action.OnExecute += (sender, args) => ShowLyricsWindow();

            menuItem.Action = action;

            if (Player.ActionManager.Register(action) != AimpActionResult.OK)
                return false;

            return Player.MenuManager.Add(ParentMenuType.AIMP_MENUID_COMMON_UTILITIES, menuItem) == AimpActionResult.OK;
        }

        private void RegisterOptions()
        {
            var optionsFrame = new OptionsFrame(Player);
            Player.Core.RegisterExtension(optionsFrame);
        }

        public override void Dispose()
        {
            if (_settings?.RestoreWindowHeight == true && _lyricsWindow != null)
                _settings.WindowHeight = (int)_lyricsWindow.ActualHeight;

            _lyricsWindow?.Close();
            Player.ServiceMessageDispatcher.Unhook(_hook);
            Trace.Close();
        }
    }
}
