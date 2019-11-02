using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("6175694D-656D-6F00-0000-000000000000")]
    [ComImport]
    public interface IAIMPUiMemo
    {
        // IAIMPPropertyList
        void BeginUpdate();
        void EndUpdate();
        void Reset();
        // Read
        double GetValueAsFloat(AIMPUiMemoPropId propertyId);
        int GetValueAsInt32(AIMPUiMemoPropId propertyId);
        long GetValueAsInt64(AIMPUiMemoPropId propertyId);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetValueAsObject(AIMPUiMemoPropId propertyId, ref Guid iid);

        // Write
        void SetValueAsFloat(AIMPUiMemoPropId propertyId, double value);
        void SetValueAsInt32(AIMPUiMemoPropId propertyId, int value);
        void SetValueAsInt64(AIMPUiMemoPropId propertyId, long value);
        void SetValueAsObject(AIMPUiMemoPropId propertyId, [MarshalAs(UnmanagedType.IUnknown)] object value);

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

        // IAIMPUiMemo
        void AddLine(IAIMPString str);
        void Clear();
        void DeleteLine(int index);
        void InsertLine(int index, IAIMPString str);
        void GetLine(int index, IAIMPString str);

        [PreserveSig]
        int GetLineCount();

        void SetLine(int index, IAIMPString str);
        // I/O
        void LoadFromFile(IAIMPString fileName);
        void LoadFromStream(IAIMPStream stream);
        void SaveToFile(IAIMPString fileName);
        void SaveToStream(IAIMPStream stream);
    }
}