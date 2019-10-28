using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756954-6162-4374-726C-000000000000")]
    [ComImport]
    public interface IAIMPUiTabControl
    {
        // IAIMPPropertyList
        void BeginUpdate();
        void EndUpdate();
        void Reset();
        // Read
        double GetValueAsFloat(AIMPUiTabControlPropId propertyId);
        int GetValueAsInt32(AIMPUiTabControlPropId propertyId);
        long GetValueAsInt64(AIMPUiTabControlPropId propertyId);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetValueAsObject(AIMPUiTabControlPropId propertyId, ref Guid iid);

        // Write
        void SetValueAsFloat(AIMPUiTabControlPropId propertyId, double value);
        void SetValueAsInt32(AIMPUiTabControlPropId propertyId, int value);
        void SetValueAsInt64(AIMPUiTabControlPropId propertyId, long value);
        void SetValueAsObject(AIMPUiTabControlPropId propertyId, [MarshalAs(UnmanagedType.IUnknown)] object value);

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

        // IAIMPUiTabControl
        void Add(IAIMPString str);
        void Delete(int index);
        IAIMPString Get(int index);

        [PreserveSig]
        int GetCount();
    }
}