using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756942-6173-6545-6469-740000000000")]
    [ComImport]
    public interface IAIMPUiBaseEdit
    {
        // IAIMPPropertyList
        void BeginUpdate();
        void EndUpdate();
        void Reset();
        // Read
        double GetValueAsFloat(AIMPUiBaseEditPropId propertyId);
        int GetValueAsInt32(AIMPUiBaseEditPropId propertyId);
        long GetValueAsInt64(AIMPUiBaseEditPropId propertyId);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetValueAsObject(AIMPUiBaseEditPropId propertyId, ref Guid iid);

        // Write
        void SetValueAsFloat(AIMPUiBaseEditPropId propertyId, double value);
        void SetValueAsInt32(AIMPUiBaseEditPropId propertyId, int value);
        void SetValueAsInt64(AIMPUiBaseEditPropId propertyId, long value);
        void SetValueAsObject(AIMPUiBaseEditPropId propertyId, [MarshalAs(UnmanagedType.IUnknown)] object value);

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

        // IAIMPUIBaseEdit
        void CopyToClipboard();
        void CutToClipboard();
        void PasteFromClipboard();
        void SelectAll();
        void SelectNone();
    }
}