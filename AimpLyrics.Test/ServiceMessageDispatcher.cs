using AIMP.SDK;
using AIMP.SDK.MessageDispatcher;
using System;

namespace AimpLyrics.Test
{
    public class ServiceMessageDispatcher : IAimpServiceMessageDispatcher
    {
        public AimpActionResult Hook(IAimpMessageHook hook)
        {
            return AimpActionResult.OK;
        }

        public int Register(string message)
        {
            throw new NotImplementedException();
        }

        public AimpActionResult Send(int message, int param1, IntPtr param2)
        {
            throw new NotImplementedException();
        }

        public AimpActionResult Unhook(IAimpMessageHook hook)
        {
            return AimpActionResult.OK;
        }
    }
}
