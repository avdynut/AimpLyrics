using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-5669-7274-7561-6C46696C6500")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPVirtualFile: IAIMPPropertyList
    {
        IAIMPStream CreateStream();
        void GetFileInfo(IAIMPFileInfo info);
        void IsExists(); // todo: returns value in HRESULT
        void IsInSameStream(IAIMPVirtualFile virtualFile); // todo: returns value in HRESULT
        void Synchronize();
    }
}