using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756946-6F72-6D00-0000-000000000000")]
    [ComImport]
    public interface IAIMPUiForm
    {
        // IAIMPPropertyList
        void BeginUpdate();
        void EndUpdate();
        void Reset();
        // Read
        double GetValueAsFloat(AIMPUiFormPropId propertyId);
        int GetValueAsInt32(AIMPUiFormPropId propertyId);
        long GetValueAsInt64(AIMPUiFormPropId propertyId);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetValueAsObject(AIMPUiFormPropId propertyId, ref Guid iid);

        // Write
        void SetValueAsFloat(AIMPUiFormPropId propertyId, double value);
        void SetValueAsInt32(AIMPUiFormPropId propertyId, int value);
        void SetValueAsInt64(AIMPUiFormPropId propertyId, long value);
        void SetValueAsObject(AIMPUiFormPropId propertyId, [MarshalAs(UnmanagedType.IUnknown)] object value);

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

        // IAIMPUiForm
        void Close();
        IAIMPUiWinControl GetFocusedControl();
        void Localize();
        void Release([MarshalAs(UnmanagedType.Bool)]bool postponed);

        [PreserveSig]
        int ShowModal();
    }
}