using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-5372-7653-6368-6564756C6572")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPServiceScheduler
    {
        IAIMPSchedulerEvent GetEvent(AIMPSchedulerEvent eventId);
        IAIMPSchedulerEvent GetNearestEvent();
        double GetRemainingTimeBeforeAction();
    }
}