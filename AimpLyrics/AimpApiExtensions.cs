using Aimp4.Api;
using System.Runtime.InteropServices;

namespace AimpLyrics
{
    public static class AimpApiExtensions
    {
        public static void ReleaseComObject(this object obj)
        {
            Marshal.FinalReleaseComObject(obj);
        }

        public static T CreateObject<T>(this IAIMPCore core)
        {
            var guid = typeof(T).GUID;
            return (T)core.CreateObject(ref guid);
        }

        public static IAIMPString CreateString(this IAIMPCore core, string text)
        {
            var aimpString = core.CreateObject<IAIMPString>();
            aimpString.SetData(text, text.Length);

            return aimpString;
        }

        public static T GetService<T>(this IAIMPCore core)
        {
            return (T)core;
        }

        public static void RegisterExtension<T>(this IAIMPCore core, object extension)
        {
            var guid = typeof(T).GUID;
            core.RegisterExtension(ref guid, extension);
        }

        public static void SetProperty(this IAIMPAction action, AIMPActionPropId propId, object value)
        {
            action.SetValueAsObject((int)propId, value);
        }

        public static string GetStringValue(this IAIMPFileInfo fileInfo, AIMPFileInfoPropId propId)
        {
            var stringGuid = typeof(IAIMPString).GUID;
            var aimpString = (IAIMPString)fileInfo.GetValueAsObject(propId, ref stringGuid);
            string data = aimpString.GetData();
            aimpString.ReleaseComObject();
            return data;
        }
    }
}
