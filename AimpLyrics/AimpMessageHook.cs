using AIMP.SDK;
using AIMP.SDK.MessageDispatcher;
using System;

namespace AimpLyrics
{
    public class AimpMessageHook : IAimpMessageHook
    {
        public event Action TrackChanged;

        public AimpActionResult CoreMessage(AimpMessages.AimpCoreMessageType message, int param1, int param2)
        {
            if (message == AimpMessages.AimpCoreMessageType.AIMP_MSG_EVENT_PLAYABLE_FILE_INFO)
                TrackChanged?.Invoke();
            return AimpActionResult.OK;
        }
    }
}
