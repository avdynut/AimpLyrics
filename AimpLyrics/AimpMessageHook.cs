using AIMP.SDK;
using AIMP.SDK.MessageDispatcher;
using System;

namespace AimpLyrics
{
    public class AimpMessageHook : IAimpMessageHook
    {
        public event Action FileInfoReceived;

        public AimpActionResult CoreMessage(AimpCoreMessageType message, int param1, int param2)
        {
            if (message == AimpCoreMessageType.AIMP_MSG_EVENT_PLAYABLE_FILE_INFO)
                FileInfoReceived?.Invoke();
            return AimpActionResult.OK;
        }
    }
}
