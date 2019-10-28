using Aimp4.Api;
using AimpLyrics.Settings;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AimpLyrics
{
    public class AimpLyricsPlugin : IAIMPPlugin
    {
        public const string Name = "AimpLyrics";
        public const string Author = "Andrey Arekhva";
        public const string Version = "1.0.4";  // todo: return plugin version
        public const string Description = "Display lyrics for current playing song. Find lyrics in file, tag or Google";

        private LyricsWindow _lyricsWindow;
        private AimpMessageHook _hook;
        private ILyricsPluginSettings _settings;

        public static IAIMPCore Core { get; private set; }

        public string InfoGet(AIMPPluginInfo info) =>
            info switch
            {
                AIMPPluginInfo.Author => Author,
                AIMPPluginInfo.Name => Name,
                AIMPPluginInfo.ShortDescription => Description,
                _ => string.Empty,
            };

        public AIMPPluginCategories InfoGetCategories() => AIMPPluginCategories.Addons;

        public void Initialize(IAIMPCore core)
        {
            Debug.WriteLine("Hello");
            Core = core;

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

            _settings = new AimpLyricsPluginSettings();
            if (_settings.OpenWindowOnInitializing && _hook != null)
                _hook.PlayerLoaded += OnPlayerLoaded;

            _lyricsWindow = new LyricsWindow();
            _hook.FileInfoReceived += _lyricsWindow.UpdateSongInfo;

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
            IAIMPMenuItem menuItem = null;
            IAIMPAction action = null;
            IAIMPString name = null;
            IAIMPString id = null;
            IAIMPString groupName = null;
            IAIMPMenuItem parentMenu = null;

            try
            {
                menuItem = Core.CreateObject<IAIMPMenuItem>();
                action = Core.CreateObject<IAIMPAction>();

                name = Core.CreateString("Open Lyrics");
                action.SetProperty(AIMPActionPropId.Name, name);

                id = Core.CreateString("aimp.lyrics.open.window");
                action.SetProperty(AIMPActionPropId.Id, id);

                groupName = Core.CreateString("Lyrics");
                action.SetProperty(AIMPActionPropId.GroupName, groupName);

                var actionManager = Core.GetService<IAIMPServiceActionManager>();
                // todo: set local hot key doesn't work
                int hotkey = actionManager.MakeHotkey(AIMPActionHotKeyModifiers.Shift, (ushort)Keys.L);
                action.SetValueAsInt32((int)AIMPActionPropId.DefaultLocalHotKey, hotkey);

                int globalHotkey = actionManager.MakeHotkey(AIMPActionHotKeyModifiers.Ctrl | AIMPActionHotKeyModifiers.Alt, (ushort)Keys.L);
                action.SetValueAsInt32((int)AIMPActionPropId.DefaultGlobalHotKey, globalHotkey);

                var actionEvent = new AimpActionEvent();
                actionEvent.Execute += (data) => ShowLyricsWindow();
                action.SetProperty(AIMPActionPropId.Event, actionEvent);

                menuItem.SetValueAsObject(AIMPMenuItemPropId.Action, action);

                var menuManager = Core.GetService< IAIMPServiceMenuManager>();
                parentMenu = menuManager.GetBuiltIn(AIMPBuildInMenu.CommonUtilities);
                menuItem.SetValueAsObject(AIMPMenuItemPropId.Parent, parentMenu);

                menuItem.SetValueAsInt32(AIMPMenuItemPropId.Shortcut, hotkey);

                Core.RegisterExtension< IAIMPServiceActionManager>(action);
                Core.RegisterExtension<IAIMPServiceMenuManager>(menuItem);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"AddMenuItem: {ex}");
                return false;
            }
            finally
            {
                menuItem?.ReleaseComObject();
                action?.ReleaseComObject();
                name?.ReleaseComObject();
                id?.ReleaseComObject();
                groupName?.ReleaseComObject();
                parentMenu?.ReleaseComObject();
            }

            return true;
        }

        private bool RegisterHook()
        {
            try
            {
                var messageDispatcher = Core.GetService<IAIMPServiceMessageDispatcher>();

                var hook = new AimpMessageHook();
                messageDispatcher.Hook(hook);

                _hook = hook;
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"RegisterHook: {ex}");
                return false;
            }
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
            try
            {
                var optionsFrame = new OptionsFrame();
                Core.RegisterExtension< IAIMPServiceOptionsDialog>(optionsFrame);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"RegisterHook: {ex}");
                return false;
            }
        }

        private void SetUpLogger()
        {
            var logFilePath = Path.Combine(Assembly.GetExecutingAssembly().GetName().Name, "log.txt");
            File.Delete(logFilePath);
            Trace.Listeners.Add(new TextWriterTraceListener(logFilePath));
            Trace.AutoFlush = true;
        }

        // remove
        public void SystemNotification(AIMPSystemNotification notification, object data)
        {
            Debug.WriteLine("SystemNotification " + notification + data);
            data?.ReleaseComObject();
        }

        public void FinalizePlugin()
        {
            if (_settings?.RestoreWindowHeight == true && _lyricsWindow != null)
                _settings.WindowHeight = (int)_lyricsWindow.ActualHeight;

            if (_hook != null)
            {
                _hook.FileInfoReceived -= _lyricsWindow.UpdateSongInfo;

                var messageDispatcher = Core.GetService<IAIMPServiceMessageDispatcher>();
                messageDispatcher.Unhook(_hook);
            }

            _lyricsWindow?.Close();

            Trace.Close();

            Marshal.FinalReleaseComObject(Core);
            Debug.WriteLine("Good bye");
        }
    }
}
