using Aimp4.Api;
using System;
using System.Runtime.InteropServices;

namespace AimpLyrics
{
    public class AimpActionEvent : IAIMPActionEvent
    {
        public event Action<object> Execute;

        public void OnExecute([MarshalAs(UnmanagedType.IUnknown)] object data)
        {
            Execute?.Invoke(data);
            data?.ReleaseComObject();
        }
    }
}
