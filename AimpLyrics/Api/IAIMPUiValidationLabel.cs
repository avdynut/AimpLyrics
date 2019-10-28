using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756956-616C-6964-4C61-62656C000000")]
    [ComImport]
    public interface IAIMPUiValidationLabel
    {
        // IAIMPPropertyList
        void BeginUpdate();
        void EndUpdate();
        void Reset();
        // Read
        double GetValueAsFloat(AIMPUiValidationLabelPropId propertyId);
        int GetValueAsInt32(AIMPUiValidationLabelPropId propertyId);
        long GetValueAsInt64(AIMPUiValidationLabelPropId propertyId);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetValueAsObject(AIMPUiValidationLabelPropId propertyId, ref Guid iid);

        // Write
        void SetValueAsFloat(AIMPUiValidationLabelPropId propertyId, double value);
        void SetValueAsInt32(AIMPUiValidationLabelPropId propertyId, int value);
        void SetValueAsInt64(AIMPUiValidationLabelPropId propertyId, long value);
        void SetValueAsObject(AIMPUiValidationLabelPropId propertyId, [MarshalAs(UnmanagedType.IUnknown)] object value);

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