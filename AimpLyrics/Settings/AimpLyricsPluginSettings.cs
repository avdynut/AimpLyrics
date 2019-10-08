using AIMP.SDK.ConfigurationManager;
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
                string value = _config.GetValueAsString(GetKeyPath());

                if (bool.TryParse(value, out bool result))
                    return result;
                else
                {
                    OpenWindowOnInitializing = _defaultOpenWindowOnInitializing;
                    return _defaultOpenWindowOnInitializing;
                }
            }
            set => _config.SetValueAsString(GetKeyPath(), value.ToString());
        }

        private readonly bool _defaultRestoreWindowHeight = true;
        public bool RestoreWindowHeight
        {
            get
            {
                string value = _config.GetValueAsString(GetKeyPath());

                if (bool.TryParse(value, out bool result))
                    return result;
                else
                {
                    RestoreWindowHeight = _defaultRestoreWindowHeight;
                    return _defaultRestoreWindowHeight;
                }
            }
            set => _config.SetValueAsString(GetKeyPath(), value.ToString());
        }

        private readonly int _defaultWindowHeight = 600;
        public int WindowHeight
        {
            get
            {
                int height = _config.GetValueAsInt32(GetKeyPath());

                if (height < 50 || height > 3000)
                {
                    WindowHeight = height = _defaultWindowHeight;
                }
                return height;
            }
            set => _config.SetValueAsInt32(GetKeyPath(), value);
        }

        private readonly IAimpServiceConfig _config;

        public AimpLyricsPluginSettings(IAimpServiceConfig config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        private string GetKeyPath([CallerMemberName] string key = "")
        {
            return $"AimpLyrics\\{key}";
        }
    }
}
