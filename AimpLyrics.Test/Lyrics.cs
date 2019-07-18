using AIMP.SDK;
using AIMP.SDK.Lyrics;
using System;

namespace AimpLyrics.Test
{
    public class Lyrics : IAimpLyrics
    {
        public string Text { get; set; }
        public string Author { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Album { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Title { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Creator { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Application { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ApplicationVersion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public LyricsType Type { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Offset { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public AimpActionResult Add(int timeStart, int timeFinish, string text)
        {
            throw new NotImplementedException();
        }

        public AimpActionResult Assign(IAimpLyrics source)
        {
            throw new NotImplementedException();
        }

        public AimpActionResult Clone(out IAimpLyrics lyrics)
        {
            throw new NotImplementedException();
        }

        public AimpActionResult Delete(int index)
        {
            throw new NotImplementedException();
        }

        public AimpActionResult Find(int time, int index, out string text)
        {
            throw new NotImplementedException();
        }

        public AimpActionResult Get(int index, int timeStart, int timeFinish, out string text)
        {
            throw new NotImplementedException();
        }

        public AimpActionResult GetCount(ref int value)
        {
            throw new NotImplementedException();
        }

        public AimpActionResult LoadFromFile(string virtualFileName)
        {
            throw new NotImplementedException();
        }

        public AimpActionResult LoadFromStream(IAimpStream stream, LyricsFormat format)
        {
            throw new NotImplementedException();
        }

        public AimpActionResult LoadFromString(string lyrics, LyricsFormat format)
        {
            throw new NotImplementedException();
        }

        public AimpActionResult SaveToFile(string fileUri)
        {
            throw new NotImplementedException();
        }

        public AimpActionResult SaveToStream(IAimpStream stream, LyricsFormat format)
        {
            throw new NotImplementedException();
        }

        public AimpActionResult SaveToString(out string lyrics, LyricsFormat format)
        {
            throw new NotImplementedException();
        }
    }
}
