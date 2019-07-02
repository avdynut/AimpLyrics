using AIMP.SDK;
using AIMP.SDK.MenuManager;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace AimpLyrics
{
    [AimpPlugin("AimpLyrics", "Andrey Arekhva", "0.0.1", AimpPluginType = AimpPluginType.Addons, Description = "Lyrics Plugin")]
    public class AimpLyricsPlugin : AimpPlugin
    {
        public override void Initialize()
        {
            var logFilePath = Path.Combine(Assembly.GetExecutingAssembly().GetName().Name, "log.txt");
            Trace.Listeners.Add(new TextWriterTraceListener(logFilePath));
            Trace.AutoFlush = true;
            Trace.WriteLine("Initializing plugin");

            if (Player.MenuManager.CreateMenuItem(out IAimpMenuItem menuItem) == AimpActionResult.OK)
            {
                menuItem.Name = "AimpLyrics";
                menuItem.Id = "demo_form";
                menuItem.Style = AimpMenuItemStyle.Normal;

                menuItem.OnShow += (sender, args) =>
                {
                    var item = sender as IAimpMenuItem;
                    Debug.WriteLine($"OnShow Menu Item: {item.Id}");
                };

                Player.MenuManager.Add(ParentMenuType.AIMP_MENUID_COMMON_UTILITIES, menuItem);
            }

            Player.MenuManager.Add(ParentMenuType.AIMP_MENUID_COMMON_UTILITIES, menuItem);
        }

        public override void Dispose()
        {
            Trace.WriteLine("Disposing plugin");
            Trace.Close();
        }
    }
}
