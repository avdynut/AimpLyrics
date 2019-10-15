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
    [AimpPlugin(Name, "Andrey Arekhva", Version, AimpPluginType = AimpPluginType.Addons, Description = Description)]
    public class AimpLyricsPlugin : AimpPlugin
    {
        public const string Name = "AimpLyrics";
        public const string Version = "1.0.4";
        public const string Description = "Display lyrics for current playing song. Find lyrics in file, tag or Google";

        private LyricsWindow? _lyricsWindow;
        private AimpMessageHook? _hook;
        private ILyricsPluginSettings? _settings;

        public override void Initialize()
        {
            if (!AddMenuItem())
            {
                Trace.WriteLine("Cannot create menu item");
                return;
            }

            if (!RegisterHook())
            {
                Trace.WriteLine("Cannot register message hook");
                return;
            }

            _settings = new AimpLyricsPluginSettings(Player.ServiceConfig);
            if (_settings.OpenWindowOnInitializing && _hook != null)
                _hook.PlayerLoaded += OnPlayerLoaded;

            _lyricsWindow = new LyricsWindow(Player, _hook!);

            if (_settings.RestoreWindowHeight)
                _lyricsWindow.Height = _settings.WindowHeight;

            if (!RegisterOptions())
            {
                Trace.WriteLine("Cannot register options frame");
                return;
            }

            SetUpLogger();

            Trace.WriteLine($"Initialized AIMP Lyrics Plugin v{Assembly.GetExecutingAssembly().GetName().Version}");
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

        private bool RegisterHook()
        {
            _hook = new AimpMessageHook();
            return Player.ServiceMessageDispatcher.Hook(_hook) == AimpActionResult.OK;
        }

        private void OnPlayerLoaded()
        {
            if (_hook is null)
                return;

            ShowLyricsWindow();
            _hook.PlayerLoaded -= OnPlayerLoaded;
        }

        private void ShowLyricsWindow()
        {
            _lyricsWindow?.Show();
            _lyricsWindow?.Activate();
        }

        private bool RegisterOptions()
        {
            var optionsFrame = new OptionsFrame(Player);
            return Player.Core.RegisterExtension(optionsFrame) == AimpActionResult.OK;
        }

        private void SetUpLogger()
        {
            var logFilePath = Path.Combine(Assembly.GetExecutingAssembly().GetName().Name, "log.txt");
            File.Delete(logFilePath);
            Trace.Listeners.Add(new TextWriterTraceListener(logFilePath));
            Trace.AutoFlush = true;
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
