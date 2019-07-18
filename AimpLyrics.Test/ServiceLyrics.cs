using AIMP.SDK;
using AIMP.SDK.FileManager;
using AIMP.SDK.Lyrics;
using System;

namespace AimpLyrics.Test
{
    public class ServiceLyrics : IAimpServiceLyrics
    {
        public event AimpServiceLyricsReceive LyricsReceive;

        public AimpActionResult Get(IAimpFileInfo fileInfo, LyricsFlags flags, object userData, out IntPtr taskId)
        {
            taskId = IntPtr.Zero;
            var lyrics = new Lyrics { Text = fileInfo.Lyrics };
            LyricsReceive?.Invoke(lyrics, userData);
            return AimpActionResult.OK;
        }

        public AimpActionResult Cancel(IntPtr taskId, LyricsFlags flags)
        {
            throw new NotImplementedException();
        }
    }
}
