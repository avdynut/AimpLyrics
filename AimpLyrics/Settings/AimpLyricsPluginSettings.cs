using Aimp4.Api;
using AimpLyrics.Themes;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

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

        private readonly bool _defaultRestoreWindowLocation = true;
        public bool RestoreWindowLocation
        {
            get
            {
                string value = GetString();

                if (bool.TryParse(value, out bool result))
                    return result;
                else
                {
                    RestoreWindowLocation = _defaultRestoreWindowLocation;
                    return _defaultRestoreWindowLocation;
                }
            }
            set => SetString(Convert.ToString(value));
        }

        public double WindowTop
        {
            get
            {
                double top = GetDouble();

                if (top < 0)
                {
                    WindowTop = top = 0;
                }
                return top;
            }
            set => SetDouble(value);
        }

        public double WindowLeft
        {
            get
            {
                double left = GetDouble();

                if (left < 0)
                {
                    WindowLeft = left = 0;
                }
                return left;
            }
            set => SetDouble(value);
        }

        private readonly double _defaultWindowHeight = 600;
        public double WindowHeight
        {
            get
            {
                double height = GetDouble();

                if (height < 50 || height > 3000)
                {
                    WindowHeight = height = _defaultWindowHeight;
                }
                return height;
            }
            set => SetDouble(value);
        }

        private readonly double _defaultLyricsFontSize = 14;
        public double LyricsFontSize
        {
            get
            {
                double fontSize = GetDouble();
                if (fontSize < 5 || fontSize > 500)
                {
                    LyricsFontSize = fontSize = _defaultLyricsFontSize;
                }
                return fontSize;
            }
            set => SetDouble(value);
        }

        public Theme Theme
        {
            get
            {
                int theme = GetInt32();
                if (theme < 0 || !Enum.IsDefined(typeof(Theme), theme))
                {
                    theme = default;
                }
                return (Theme)theme;
            }
            set => SetInt32((int)value);
        }

        private IAIMPServiceConfig Config => AimpLyricsPlugin.Core.GetService<IAIMPServiceConfig>();

        private IAIMPString GetKeyPath(string key)
        {
            var aimpString = AimpLyricsPlugin.Core.CreateString($"AimpLyrics\\{key}");
            return aimpString;
        }

        private string GetString([CallerMemberName] string key = "")
        {
            string value = null;
            var aimpKeyPath = GetKeyPath(key);

            try
            {
                var aimpValue = Config.GetValueAsString(aimpKeyPath);
                value = aimpValue.GetData();
                aimpValue?.ReleaseComObject();
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"GetString: {ex}");
            }
            finally
            {
                aimpKeyPath?.ReleaseComObject();
            }

            return value;
        }

        private double GetDouble([CallerMemberName] string key = "")
        {
            double value = 0;
            var aimpKeyPath = GetKeyPath(key);

            try
            {
                value = Config.GetValueAsFloat(aimpKeyPath);
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"GetDouble: {ex}");
            }
            finally
            {
                aimpKeyPath?.ReleaseComObject();
            }

            return value;
        }

        private int GetInt32([CallerMemberName] string key = "")
        {
            int value = 0;
            var aimpKeyPath = GetKeyPath(key);

            try
            {
                value = Config.GetValueAsInt32(aimpKeyPath);
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"GetInt32: {ex}");
            }
            finally
            {
                aimpKeyPath?.ReleaseComObject();
            }

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

        private void SetDouble(double value, [CallerMemberName] string key = "")
        {
            var aimpKeyPath = GetKeyPath(key);
            Config.SetValueAsFloat(aimpKeyPath, value);
            aimpKeyPath?.ReleaseComObject();
        }

        private void SetInt32(int value, [CallerMemberName] string key = "")
        {
            var aimpKeyPath = GetKeyPath(key);
            Config.SetValueAsInt32(aimpKeyPath, value);
            aimpKeyPath?.ReleaseComObject();
        }
    }
}
