using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [Guid("41494D50-5374-7269-6E67-000000000000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IAIMPString
    {
        void GetChar(int index, out char c);

        [return: MarshalAs(UnmanagedType.LPWStr)]
        [PreserveSig]
        string GetData();

        [PreserveSig]
        int GetLength();
        [PreserveSig]
        int GetHashCode();
        void SetChar(int index, char c);
        void SetData([MarshalAs(UnmanagedType.LPWStr)] string chars, int charsCount);

        void Add(IAIMPString str);
        void Add2([MarshalAs(UnmanagedType.LPWStr)] string chars, int charsCount);

        void ChangeCase(AIMPStringCase mode);
        IAIMPString Clone();

        void Compare(IAIMPString str, out int compareResult, bool ignoreCase);
        void Compare2([MarshalAs(UnmanagedType.LPWStr)] string chars, int charsCount, out int compareResult, bool ignoreCase);

        void Delete(int index, int count);

        void Find(IAIMPString str, out int index, AIMPStringFindFlags flags, int startFromIndex);
        void Find2([MarshalAs(UnmanagedType.LPWStr)] string chars, int charsCount, out int index, AIMPStringFindFlags flags, int startFromIndex);

        void Insert(int index, IAIMPString str);
        void Insert2(int index, [MarshalAs(UnmanagedType.LPWStr)] string chars, int charsCount);

        void Replace(IAIMPString oldPattern, IAIMPString newPattern, int flags);

        void Replace2([MarshalAs(UnmanagedType.LPWStr)] string oldPatternChars, int oldPatternCharsCount,
            [MarshalAs(UnmanagedType.LPWStr)] string newPatternChars, int newPatternCharsCount, int flags);

        IAIMPString SubString(int index, int count);
    }
}