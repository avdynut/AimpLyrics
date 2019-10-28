using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756953-6372-6F6C-6C42-6F7800000000")]
    [ComImport]
    public interface IAIMPUiScrollBox
    {
        // IAIMPPropertyList
        void BeginUpdate();
        void EndUpdate();
        void Reset();
        // Read
        double GetValueAsFloat(AIMPUiScrollBoxPropId propertyId);
        int GetValueAsInt32(AIMPUiScrollBoxPropId propertyId);
        long GetValueAsInt64(AIMPUiScrollBoxPropId propertyId);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetValueAsObject(AIMPUiScrollBoxPropId propertyId, ref Guid iid);

        // Write
        void SetValueAsFloat(AIMPUiScrollBoxPropId propertyId, double value);
        void SetValueAsInt32(AIMPUiScrollBoxPropId propertyId, int value);
        void SetValueAsInt64(AIMPUiScrollBoxPropId propertyId, long value);
        void SetValueAsObject(AIMPUiScrollBoxPropId propertyId, [MarshalAs(UnmanagedType.IUnknown)] object value);

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

        // IAIMPUiScrollBox
        void MakeVisible(IAIMPUiControl control);
    }
}