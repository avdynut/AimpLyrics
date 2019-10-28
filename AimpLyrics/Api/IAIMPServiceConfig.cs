using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    [Guid("41494D50-5372-7643-6667-000000000000")]
    public interface IAIMPServiceConfig
    {
        // Delete
        void Delete(IAIMPString keyPath);
        // Read
        double GetValueAsFloat(IAIMPString keyPath);
        int GetValueAsInt32(IAIMPString keyPath);
        long GetValueAsInt64(IAIMPString keyPath);
        IAIMPStream GetValueAsStream(IAIMPString keyPath);
        IAIMPString GetValueAsString(IAIMPString keyPath);
        // Write
        void SetValueAsFloat(IAIMPString keyPath, double value);
        void SetValueAsInt32(IAIMPString keyPath, int value);
        void SetValueAsInt64(IAIMPString keyPath, long value);
        void SetValueAsStream(IAIMPString keyPath, IAIMPStream value);
        void SetValueAsString(IAIMPString keyPath, IAIMPString value);

        void FlushCache();
    }
}