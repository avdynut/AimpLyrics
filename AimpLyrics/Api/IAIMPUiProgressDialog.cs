using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756950-726F-6772-6573-73446C670000")]
    [ComImport]
    public interface IAIMPUiProgressDialog
    {
        // IAIMPPropertyList
        void BeginUpdate();
        void EndUpdate();
        void Reset();
        // Read
        double GetValueAsFloat(AIMPUiProgressDialogPropId propertyId);
        int GetValueAsInt32(AIMPUiProgressDialogPropId propertyId);
        long GetValueAsInt64(AIMPUiProgressDialogPropId propertyId);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetValueAsObject(AIMPUiProgressDialogPropId propertyId, ref Guid iid);

        // Write
        void SetValueAsFloat(AIMPUiProgressDialogPropId propertyId, double value);
        void SetValueAsInt32(AIMPUiProgressDialogPropId propertyId, int value);
        void SetValueAsInt64(AIMPUiProgressDialogPropId propertyId, long value);
        void SetValueAsObject(AIMPUiProgressDialogPropId propertyId, [MarshalAs(UnmanagedType.IUnknown)] object value);

        // IAIMPUIProgressDialog
        void Finished();
        void Progress(long position, long total, IAIMPString text);
        void Started();
    }
}