using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AIMP.SDK;

namespace AimpLyrics
{
    [AimpPlugin("AimpLyrics", "Andrey Arekhva", "0.0.1", AimpPluginType = AimpPluginType.Addons, Description = "Lyrics Plugin")]
    public class AimpLyricsPlugin : AimpPlugin
    {
        public override void Initialize()
        {
            Console.WriteLine("Initialize");
        }

        public override void Dispose()
        {
            Console.WriteLine("Dispose");
        }
    }
}
