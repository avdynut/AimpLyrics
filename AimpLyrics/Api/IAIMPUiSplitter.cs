using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756953-706C-6974-7465-720000000000")]
    [ComImport]
    public interface IAIMPUiSplitter
    {
        // IAIMPPropertyList
        void BeginUpdate();
        void EndUpdate();
        void Reset();
        // Read
        double GetValueAsFloat(AIMPUiSplitterPropId propertyId);
        int GetValueAsInt32(AIMPUiSplitterPropId propertyId);
        long GetValueAsInt64(AIMPUiSplitterPropId propertyId);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetValueAsObject(AIMPUiSplitterPropId propertyId, ref Guid iid);

        // Write
        void SetValueAsFloat(AIMPUiSplitterPropId propertyId, double value);
        void SetValueAsInt32(AIMPUiSplitterPropId propertyId, int value);
        void SetValueAsInt64(AIMPUiSplitterPropId propertyId, long value);
        void SetValueAsObject(AIMPUiSplitterPropId propertyId, [MarshalAs(UnmanagedType.IUnknown)] object value);

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