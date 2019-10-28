using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756942-7261-6E64-426F-780000000000")]
    [ComImport]
    public interface IAIMPUiBrandBox
    {
        // IAIMPPropertyList
        void BeginUpdate();
        void EndUpdate();
        void Reset();
        // Read
        double GetValueAsFloat(AIMPUiBrandBoxPropId propertyId);
        int GetValueAsInt32(AIMPUiBrandBoxPropId propertyId);
        long GetValueAsInt64(AIMPUiBrandBoxPropId propertyId);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetValueAsObject(AIMPUiBrandBoxPropId propertyId, ref Guid iid);

        // Write
        void SetValueAsFloat(AIMPUiBrandBoxPropId propertyId, double value);
        void SetValueAsInt32(AIMPUiBrandBoxPropId propertyId, int value);
        void SetValueAsInt64(AIMPUiBrandBoxPropId propertyId, long value);
        void SetValueAsObject(AIMPUiBrandBoxPropId propertyId, [MarshalAs(UnmanagedType.IUnknown)] object value);

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

        // IAIMPUIWinControl
        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetControl(int index, ref Guid iid);

        [PreserveSig]
        int GetControlCount();

        [PreserveSig]
        IntPtr GetHandle();

        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool HasHandle();

        void SetFocus();
    }
}