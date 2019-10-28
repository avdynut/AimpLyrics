using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756954-696D-6545-6469-740000000000")]
    [ComImport]
    public interface IAIMPUiTimeEdit
    {
        // IAIMPPropertyList
        void BeginUpdate();
        void EndUpdate();
        void Reset();
        // Read
        double GetValueAsFloat(AIMPUiTimeEditPropId propertyId);
        int GetValueAsInt32(AIMPUiTimeEditPropId propertyId);
        long GetValueAsInt64(AIMPUiTimeEditPropId propertyId);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetValueAsObject(AIMPUiTimeEditPropId propertyId, ref Guid iid);

        // Write
        void SetValueAsFloat(AIMPUiTimeEditPropId propertyId, double value);
        void SetValueAsInt32(AIMPUiTimeEditPropId propertyId, int value);
        void SetValueAsInt64(AIMPUiTimeEditPropId propertyId, long value);
        void SetValueAsObject(AIMPUiTimeEditPropId propertyId, [MarshalAs(UnmanagedType.IUnknown)] object value);

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