using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756949-6D61-6765-436F-6D626F000000")]
    [ComImport]
    public interface IAIMPUiImageComboBox
    {
        // IAIMPPropertyList
        void BeginUpdate();
        void EndUpdate();
        void Reset();
        // Read
        double GetValueAsFloat(AIMPUiImageComboBoxPropId propertyId);
        int GetValueAsInt32(AIMPUiImageComboBoxPropId propertyId);
        long GetValueAsInt64(AIMPUiImageComboBoxPropId propertyId);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetValueAsObject(AIMPUiImageComboBoxPropId propertyId, ref Guid iid);

        // Write
        void SetValueAsFloat(AIMPUiImageComboBoxPropId propertyId, double value);
        void SetValueAsInt32(AIMPUiImageComboBoxPropId propertyId, int value);
        void SetValueAsInt64(AIMPUiImageComboBoxPropId propertyId, long value);
        void SetValueAsObject(AIMPUiImageComboBoxPropId propertyId, [MarshalAs(UnmanagedType.IUnknown)] object value);

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

        // IAIMPUIBaseButtonnedEdit
        IAIMPUiEditButton AddButton([MarshalAs(UnmanagedType.IUnknown)] object eventsHandler);
        void DeleteButton(int index);
        void DeleteButton2(IAIMPUiEditButton button);
        IAIMPUiEditButton GetButton(int index);

        [PreserveSig]
        int GetButtonCount();

        // IAIMPUiBaseComboBox
        void Add([MarshalAs(UnmanagedType.IUnknown)] object obj, int extraData);
        void Add2(IAIMPObjectList list);
        void Clear();
        void Delete(int index);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetItem(int index, ref Guid iid);

        int GetItemCount();
        void SetItem(int index, [MarshalAs(UnmanagedType.IUnknown)] object obj);

        // IAIMPUiImageComboBox
        [PreserveSig]
        int GetImageIndex(int index);

        void SetImageIndex(int index, int value);
    }
}