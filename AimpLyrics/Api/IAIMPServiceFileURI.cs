using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-5372-7646-696C-655552490000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPServiceFileURI
    {
        IAIMPString Build(IAIMPString containerFileName, IAIMPString partName);
        void Parse(IAIMPString fileUri, out IAIMPString containerFileName, out IAIMPString partName);
        void ChangeFileExt(out IAIMPString fileUri, IAIMPString newExt, AIMPServiceFileuriFlags flags);
        void ExtractFileExt(IAIMPString fileUri, out IAIMPString str, AIMPServiceFileuriFlags flags);
        void ExtractFileName(IAIMPString fileUri, IAIMPString str);
        IAIMPString ExtractFileParentDirName(IAIMPString fileUri);
        IAIMPString ExtractFileParentName(IAIMPString fileUri);
        IAIMPString ExtractFilePath(IAIMPString fileUri);
        void IsURL(IAIMPString fileUri); // todo: returns value in HRESULT
    }
}