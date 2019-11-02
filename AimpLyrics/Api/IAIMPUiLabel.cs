using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("6175694C-6162-656C-0000-000000000000")]
    [ComImport]
    public interface IAIMPUiLabel
    {
        // IAIMPPropertyList
        void BeginUpdate();
        void EndUpdate();
        void Reset();
        // Read
        double GetValueAsFloat(AIMPUiLabelPropId propertyId);
        int GetValueAsInt32(AIMPUiLabelPropId propertyId);
        long GetValueAsInt64(AIMPUiLabelPropId propertyId);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetValueAsObject(AIMPUiLabelPropId propertyId, ref Guid iid);

        // Write
        void SetValueAsFloat(AIMPUiLabelPropId propertyId, double value);
        void SetValueAsInt32(AIMPUiLabelPropId propertyId, int value);
        void SetValueAsInt64(AIMPUiLabelPropId propertyId, long value);
        void SetValueAsObject(AIMPUiLabelPropId propertyId, [MarshalAs(UnmanagedType.IUnknown)] object value);

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