using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756950-6169-6E74-426F-780000000000")]
    [ComImport]
    public interface IAIMPUiPaintBox
    {
        // IAIMPPropertyList
        void BeginUpdate();
        void EndUpdate();
        void Reset();
        // Read
        double GetValueAsFloat(int propertyId);
        int GetValueAsInt32(int propertyId);
        long GetValueAsInt64(int propertyId);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetValueAsObject(int propertyId, ref Guid iid);

        // Write
        void SetValueAsFloat(int propertyId, double value);
        void SetValueAsInt32(int propertyId, int value);
        void SetValueAsInt64(int propertyId, long value);
        void SetValueAsObject(int propertyId, [MarshalAs(UnmanagedType.IUnknown)] object value);

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