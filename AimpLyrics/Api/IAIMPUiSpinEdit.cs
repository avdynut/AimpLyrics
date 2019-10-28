using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756953-7069-6E45-6469-740000000000")]
    [ComImport]
    public interface IAIMPUiSpinEdit
    {
        // IAIMPPropertyList
        void BeginUpdate();
        void EndUpdate();
        void Reset();
        // Read
        double GetValueAsFloat(AIMPUiSpinEditPropId propertyId);
        int GetValueAsInt32(AIMPUiSpinEditPropId propertyId);
        long GetValueAsInt64(AIMPUiSpinEditPropId propertyId);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetValueAsObject(AIMPUiSpinEditPropId propertyId, ref Guid iid);

        // Write
        void SetValueAsFloat(AIMPUiSpinEditPropId propertyId, double value);
        void SetValueAsInt32(AIMPUiSpinEditPropId propertyId, int value);
        void SetValueAsInt64(AIMPUiSpinEditPropId propertyId, long value);
        void SetValueAsObject(AIMPUiSpinEditPropId propertyId, [MarshalAs(UnmanagedType.IUnknown)] object value);

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