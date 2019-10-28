using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756950-6167-6543-7472-6C0000000000")]
    [ComImport]
    public interface IAIMPUiPageControl
    {
        // IAIMPPropertyList
        void BeginUpdate();
        void EndUpdate();
        void Reset();
        // Read
        double GetValueAsFloat(AIMPUiPageControlPropId propertyId);
        int GetValueAsInt32(AIMPUiPageControlPropId propertyId);
        long GetValueAsInt64(AIMPUiPageControlPropId propertyId);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetValueAsObject(AIMPUiPageControlPropId propertyId, ref Guid iid);

        // Write
        void SetValueAsFloat(AIMPUiPageControlPropId propertyId, double value);
        void SetValueAsInt32(AIMPUiPageControlPropId propertyId, int value);
        void SetValueAsInt64(AIMPUiPageControlPropId propertyId, long value);
        void SetValueAsObject(AIMPUiPageControlPropId propertyId, [MarshalAs(UnmanagedType.IUnknown)] object value);

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

        // IAIMPUiPageControl
        IAIMPUiTabSheet Add(IAIMPString name);
        void Delete(int index);
        void Delete2(IAIMPUiTabSheet page);
        IAIMPUiTabSheet Get(int index);

        [PreserveSig]
        int GetCount();
    }
}