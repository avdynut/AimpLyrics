namespace Aimp4.Api
{
    public enum AIMPServicePlayerPropId
    {
        StopAfterTrack = 1,
        AutoJumpToNextTrack = 2,
        AutoSwitching = 10,
        AutoSwitchingCrossFade = 11, // msec
        AutoSwitchingFadeIn = 12, // msec
        AutoSwitchingFadeOut = 13, // msec
        AutoSwitchingPauseBetweenTracks = 14, // msec
        ManualSwitching = 20,
        ManualSwitchingCrossfade = 21, // msec
        ManualSwitchingFadein = 22, // msec
        ManualSwitchingFadeout = 23, // msec
    }
}