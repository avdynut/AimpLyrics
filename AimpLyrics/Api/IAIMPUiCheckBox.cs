using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756943-6865-636B-426F-780000000000")]
    [ComImport]
    public interface IAIMPUiCheckBox
    {
        // IAIMPPropertyList
        void BeginUpdate();
        void EndUpdate();
        void Reset();
        // Read
        double GetValueAsFloat(AIMPUiCheckBoxPropId propertyId);
        int GetValueAsInt32(AIMPUiCheckBoxPropId propertyId);
        long GetValueAsInt64(AIMPUiCheckBoxPropId propertyId);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetValueAsObject(AIMPUiCheckBoxPropId propertyId, ref Guid iid);

        // Write
        void SetValueAsFloat(AIMPUiCheckBoxPropId propertyId, double value);
        void SetValueAsInt32(AIMPUiCheckBoxPropId propertyId, int value);
        void SetValueAsInt64(AIMPUiCheckBoxPropId propertyId, long value);
        void SetValueAsObject(AIMPUiCheckBoxPropId propertyId, [MarshalAs(UnmanagedType.IUnknown)] object value);

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