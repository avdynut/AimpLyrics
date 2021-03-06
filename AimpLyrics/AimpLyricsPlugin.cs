﻿using Aimp4.Api;
using AimpLyrics.Settings;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;

namespace AimpLyrics
{
    public class AimpLyricsPlugin : IAIMPPlugin
    {
        public const string Name = "AimpLyrics";
        public const string Author = "Andrey Arekhva";
        public const string Version = "1.2.0";
        public const string Description = "Display lyrics for current playing song. Find lyrics in file, tag or Google";

        private LyricsWindow _lyricsWindow;
        private AimpMessageHook _hook;

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
            try
            {
                Trace.WriteLine("Start Init");
                Core = core;

                SetUpLogger();
                AddMenuItem();
                RegisterHook();
                InitializeLyricsWindow();
                RegisterOptions();

                Trace.WriteLine($"Initialized AIMP Lyrics Plugin v{Version}");
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Init error: {ex}");
                throw;
            }
        }

        private void AddMenuItem()
        {
            IAIMPMenuItem menuItem = null;
            IAIMPAction action = null;
            IAIMPString actionName = null;
            IAIMPString id = null;
            IAIMPString groupName = null;
            IAIMPMenuItem parentMenu = null;

            try
            {
                menuItem = Core.CreateObject<IAIMPMenuItem>();
                action = Core.CreateObject<IAIMPAction>();

                actionName = Core.CreateString("Lyrics");
                action.SetProperty(AIMPActionPropId.Name, actionName);

                id = Core.CreateString("aimp.lyrics.open.window");
                action.SetProperty(AIMPActionPropId.Id, id);

                groupName = Core.CreateString("Lyrics Plugin");
                action.SetProperty(AIMPActionPropId.GroupName, groupName);

                var actionManager = Core.GetService<IAIMPServiceActionManager>();

                int hotkey = actionManager.MakeHotkey(AIMPActionHotKeyModifiers.Shift, (ushort)Keys.L);
                action.SetValueAsInt32((int)AIMPActionPropId.DefaultLocalHotKey, hotkey);

                int globalHotkey = actionManager.MakeHotkey(AIMPActionHotKeyModifiers.Ctrl | AIMPActionHotKeyModifiers.Alt, (ushort)Keys.L);
                action.SetValueAsInt32((int)AIMPActionPropId.DefaultGlobalHotKey, globalHotkey);

                var actionEvent = new AimpActionEvent();
                actionEvent.Execute += (data) => ShowLyricsWindow();
                action.SetProperty(AIMPActionPropId.Event, actionEvent);

                menuItem.SetValueAsObject(AIMPMenuItemPropId.Action, action);

                var menuManager = Core.GetService<IAIMPServiceMenuManager>();
                parentMenu = menuManager.GetBuiltIn(AIMPBuildInMenu.CommonUtilities);
                menuItem.SetValueAsObject(AIMPMenuItemPropId.Parent, parentMenu);

                menuItem.SetValueAsInt32(AIMPMenuItemPropId.Shortcut, hotkey);

                Core.RegisterExtension<IAIMPServiceActionManager>(action);
                Core.RegisterExtension<IAIMPServiceMenuManager>(menuItem);
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Cannot create menu item: {ex}");
                throw;
            }
            finally
            {
                menuItem?.ReleaseComObject();
                action?.ReleaseComObject();
                actionName?.ReleaseComObject();
                id?.ReleaseComObject();
                groupName?.ReleaseComObject();
                parentMenu?.ReleaseComObject();
            }
        }

        private void RegisterHook()
        {
            try
            {
                var messageDispatcher = Core.GetService<IAIMPServiceMessageDispatcher>();
                var hook = new AimpMessageHook();

                messageDispatcher.Hook(hook);
                _hook = hook;
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Cannot register message hook: {ex}");
                throw;
            }
        }

        private void InitializeLyricsWindow()
        {
            var settings = new AimpLyricsPluginSettings();
            _lyricsWindow = new LyricsWindow(settings);
            _hook.FileInfoReceived += _lyricsWindow.UpdateSongInfo;

            if (settings.OpenWindowOnInitializing)
                _hook.PlayerLoaded += OnPlayerLoaded;

            try
            {
                if (settings.RestoreWindowLocation)
                {
                    _lyricsWindow.Top = settings.WindowTop;
                    _lyricsWindow.Left = settings.WindowLeft;
                }

                _lyricsWindow.Height = settings.WindowHeight;
            }
            catch
            {
                Trace.WriteLine($"Error while setting double values to window");
            }
        }

        private void OnPlayerLoaded()
        {
            ShowLyricsWindow();
            _hook.PlayerLoaded -= OnPlayerLoaded;
        }

        private void ShowLyricsWindow()
        {
            if (_lyricsWindow is null)
                return;

            _lyricsWindow.Show();
            if (_lyricsWindow.WindowState == WindowState.Minimized)
                _lyricsWindow.WindowState = WindowState.Normal;
            _lyricsWindow.Activate();
        }

        private void RegisterOptions()
        {
            try
            {
                var optionsFrame = new OptionsFrame();
                Core.RegisterExtension<IAIMPServiceOptionsDialog>(optionsFrame);
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Cannot register options frame: {ex}");
                throw;
            }
        }

        private void SetUpLogger()
        {
            var aimpString = Core.GetPath(AIMPCorePath.Profile);
            string profilePath = aimpString.GetData();
            aimpString.ReleaseComObject();

            var logFilePath = Path.Combine(profilePath, "AimpLyricsPluginLog.txt");
            File.Delete(logFilePath);
            Trace.Listeners.Add(new TextWriterTraceListener(logFilePath));
            Trace.AutoFlush = true;
        }

        public void SystemNotification(AIMPSystemNotification notification, object data)
        {
            data?.ReleaseComObject();
        }

        public void FinalizePlugin()
        {
            if (_hook != null)
            {
                _hook.FileInfoReceived -= _lyricsWindow.UpdateSongInfo;

                var messageDispatcher = Core.GetService<IAIMPServiceMessageDispatcher>();
                messageDispatcher.Unhook(_hook);
            }

            _lyricsWindow?.Close();
            Marshal.FinalReleaseComObject(Core);

            Trace.WriteLine("Finalized AIMP Lyrics Plugin");
            Trace.Close();
        }
    }
}
