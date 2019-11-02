using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756942-7574-746F-6E00-000000000000")]
    [ComImport]
    public interface IAIMPUiButton
    {
        // IAIMPPropertyList
        void BeginUpdate();
        void EndUpdate();
        void Reset();
        // Read
        double GetValueAsFloat(AIMPUiButtonPropId propertyId);
        int GetValueAsInt32(AIMPUiButtonPropId propertyId);
        long GetValueAsInt64(int propertyId);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetValueAsObject(AIMPUiButtonPropId propertyId, ref Guid iid);

        // Write
        void SetValueAsFloat(AIMPUiButtonPropId propertyId, double value);
        void SetValueAsInt32(AIMPUiButtonPropId propertyId, int value);
        void SetValueAsInt64(AIMPUiButtonPropId propertyId, long value);
        void SetValueAsObject(AIMPUiButtonPropId propertyId, [MarshalAs(UnmanagedType.IUnknown)] object value);

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

        // IAIMPUiButton
        void ShowDropDownMenu();
    }
}