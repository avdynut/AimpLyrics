using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-5372-764D-7367-447370720000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPServiceMessageDispatcher
    {
        void Send(AIMPMessage message, int param1, IntPtr param2);
        // Custom Messages
        void Register([MarshalAs(UnmanagedType.LPWStr)] string messageName);
        // Hook
        void Hook(IAIMPMessageHook hook);
        void Unhook(IAIMPMessageHook hook);
    }
}