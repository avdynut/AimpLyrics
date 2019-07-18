using AIMP.SDK.FileManager;
using System;

namespace AimpLyrics.Test
{
    public class FileInfo : IAimpFileInfo
    {
        public string CustomData { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Album { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string AlbumArtist { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Gain { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Peak { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Artist { get; set; } = "Elevation Worship";
        public int BitRate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int BitDepth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int BPM { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Channels { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Codec { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Comment { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Composer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CopyRight { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CUESheet { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Date { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string DiskNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string DiskTotal { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Duration { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string FileName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public long FileSize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Genre { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Lyrics { get; set; } = "";
        public double Mark { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Publisher { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int SampleRate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Title { get; set; } = "Do It Again";
        public double TrackGain { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string TrackNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double TrackPeak { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string TrackTotal { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string URL { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public double AddedDate => throw new NotImplementedException();

        public double LastPlayedDate => throw new NotImplementedException();

        public double StatMark { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int PlayCount => throw new NotImplementedException();

        public double StateRating => throw new NotImplementedException();

        public System.Drawing.Bitmap AlbumArt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Assign(IAimpFileInfo source)
        {
            throw new NotImplementedException();
        }

        public IAimpFileInfo Clone()
        {
            throw new NotImplementedException();
        }
    }
}
