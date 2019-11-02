namespace Aimp4.Api
{
    public struct TAIMPRemoteFileInfo
    {
        public uint Deprecated1;
        public int Active; // bool
        public uint BitRate;
        public uint Channels;
        public uint Duration;
        public long FileSize;
        public uint FileMark;
        public uint SampleRate;
        public uint TrackNumber;
        public uint AlbumLength;
        public uint ArtistLength;
        public uint DateLength;
        public uint FileNameLength;
        public uint GenreLength;
        public uint TitleLength;

        public uint Deprecated2Index0;
        public uint Deprecated2Index1;
        public uint Deprecated2Index2;
        public uint Deprecated2Index3;
        public uint Deprecated2Index4;
        public uint Deprecated2Index5;
    }
}