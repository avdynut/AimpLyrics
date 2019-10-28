using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756950-726F-6772-6573-734261720000")]
    [ComImport]
    public interface IAIMPUiProgressBar
    {
        // IAIMPPropertyList
        void BeginUpdate();
        void EndUpdate();
        void Reset();
        // Read
        double GetValueAsFloat(AIMPUiProgressBarPropId propertyId);
        int GetValueAsInt32(AIMPUiProgressBarPropId propertyId);
        long GetValueAsInt64(AIMPUiProgressBarPropId propertyId);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetValueAsObject(AIMPUiProgressBarPropId propertyId, ref Guid iid);

        // Write
        void SetValueAsFloat(AIMPUiProgressBarPropId propertyId, double value);
        void SetValueAsInt32(AIMPUiProgressBarPropId propertyId, int value);
        void SetValueAsInt64(AIMPUiProgressBarPropId propertyId, long value);
        void SetValueAsObject(AIMPUiProgressBarPropId propertyId, [MarshalAs(UnmanagedType.IUnknown)] object value);

        // IAIMPUIControl
        void GetPlacement(IntPtr placement); // AIMPUiControlPlacement**
        void GetPlacementConstraints(IntPtr constraints); // AIMPUiControlPlacementConstraints**
        void SetPlacement(ref AIMPUiControlPlacement placement);
        void SetPlacementConstraints(ref AIMPUiControlPlacementConstraints constraints);

        // Coords Translation
        void ClientToScreen(ref POINT point);
        void ScreenToClient(ref POINT point);

        // Drawing
        void PaintTo(IntPtr hDc, int x, int y);
        void Invalidate();
    }
}