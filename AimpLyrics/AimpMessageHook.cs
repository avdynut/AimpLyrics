using AIMP.SDK;
using AIMP.SDK.MessageDispatcher;
using System;

#nullable enable
namespace AimpLyrics
{
    public class AimpMessageHook : IAimpMessageHook
    {
        public event Action? FileInfoReceived;
        public event Action? PlayerStopped;
        public event Action? PlayerLoaded;

        public AimpActionResult CoreMessage(AimpCoreMessageType message, int param1, int param2)
        {
            switch (message)
            {
                case AimpCoreMessageType.AIMP_MSG_EVENT_PLAYABLE_FILE_INFO:
                    FileInfoReceived?.Invoke();
                    break;
                case AimpCoreMessageType.AIMP_MSG_EVENT_PLAYER_STATE:
                    if (param1 == 0)
                        PlayerStopped?.Invoke();
                    break;
                case AimpCoreMessageType.AIMP_MSG_EVENT_LOADED:
                    PlayerLoaded?.Invoke();
                    break;
            }

            return AimpActionResult.OK;
        }
    }
}
