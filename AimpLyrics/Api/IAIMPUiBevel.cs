using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756942-6576-656C-0000-000000000000")]
    [ComImport]
    public interface IAIMPUiBevel
    {
        // IAIMPPropertyList
        void BeginUpdate();
        void EndUpdate();
        void Reset();
        // Read
        double GetValueAsFloat(AIMPUiBevelPropId propertyId);
        int GetValueAsInt32(AIMPUiBevelPropId propertyId);
        long GetValueAsInt64(AIMPUiBevelPropId propertyId);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetValueAsObject(AIMPUiBevelPropId propertyId, ref Guid iid);

        // Write
        void SetValueAsFloat(AIMPUiBevelPropId propertyId, double value);
        void SetValueAsInt32(AIMPUiBevelPropId propertyId, int value);
        void SetValueAsInt64(AIMPUiBevelPropId propertyId, long value);
        void SetValueAsObject(AIMPUiBevelPropId propertyId, [MarshalAs(UnmanagedType.IUnknown)] object value);

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