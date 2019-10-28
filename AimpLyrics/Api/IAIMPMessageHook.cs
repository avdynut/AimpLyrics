using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("FC6FB524-A959-4089-AA0A-EA40AB7374CD")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPMessageHook
    {
        void CoreMessage(AIMPMessage message, int param1, IntPtr param2, ref IntPtr result);
    }
}