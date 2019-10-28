using Aimp4.Api;
using System;
using System.Runtime.CompilerServices;

#nullable enable
namespace AimpLyrics.Settings
{
    public class AimpLyricsPluginSettings : ILyricsPluginSettings
    {
        private readonly bool _defaultOpenWindowOnInitializing = true;
        public bool OpenWindowOnInitializing
        {
            get
            {
                string value = GetString();

                if (bool.TryParse(value, out bool result))
                    return result;
                else
                {
                    OpenWindowOnInitializing = _defaultOpenWindowOnInitializing;
                    return _defaultOpenWindowOnInitializing;
                }
            }
            set => SetString(Convert.ToString(value));
        }

        private readonly bool _defaultRestoreWindowHeight = true;
        public bool RestoreWindowHeight
        {
            get
            {
                string value = GetString();

                if (bool.TryParse(value, out bool result))
                    return result;
                else
                {
                    RestoreWindowHeight = _defaultRestoreWindowHeight;
                    return _defaultRestoreWindowHeight;
                }
            }
            set => SetString(Convert.ToString(value));
        }

        private readonly int _defaultWindowHeight = 600;
        public int WindowHeight
        {
            get
            {
                int height = GetInt32();

                if (height < 50 || height > 3000)
                {
                    WindowHeight = height = _defaultWindowHeight;
                }
                return height;
            }
            set => SetInt32(value);
        }

        private IAIMPServiceConfig Config => AimpLyricsPlugin.Core.GetService<IAIMPServiceConfig>();

        private IAIMPString GetKeyPath(string key)
        {
            var aimpString = AimpLyricsPlugin.Core.CreateString($"AimpLyrics\\{key}");
            return aimpString;
        }

        private string GetString([CallerMemberName] string key = "")
        {
            var aimpKeyPath = GetKeyPath(key);
            var aimpValue = Config.GetValueAsString(aimpKeyPath);
            string value = aimpValue.GetData();

            aimpKeyPath?.ReleaseComObject();
            aimpValue?.ReleaseComObject();

            return value;
        }

        private int GetInt32([CallerMemberName] string key = "")
        {
            var aimpKeyPath = GetKeyPath(key);
            int value = Config.GetValueAsInt32(aimpKeyPath);
            aimpKeyPath?.ReleaseComObject();
            return value;
        }

        private void SetString(string value, [CallerMemberName] string key = "")
        {
            var aimpKeyPath = GetKeyPath(key);
            var aimpValue = AimpLyricsPlugin.Core.CreateString(value);

            Config.SetValueAsString(aimpKeyPath, aimpValue);

            aimpKeyPath?.ReleaseComObject();
            aimpValue?.ReleaseComObject();
        }

        private void SetInt32(int value, [CallerMemberName] string key = "")
        {
            var aimpKeyPath = GetKeyPath(key);
            Config.SetValueAsInt32(aimpKeyPath, value);
            aimpKeyPath?.ReleaseComObject();
        }
    }
}
