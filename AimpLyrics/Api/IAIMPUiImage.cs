using System;
using System.Runtime.InteropServices;

namespace Aimp4.Api
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("61756949-6D61-6765-0000-000000000000")]
    [ComImport]
    public interface IAIMPUiImage
    {
        // IAIMPPropertyList
        void BeginUpdate();
        void EndUpdate();
        void Reset();
        // Read
        double GetValueAsFloat(AIMPUiImagePropId propertyId);
        int GetValueAsInt32(AIMPUiImagePropId propertyId);
        long GetValueAsInt64(AIMPUiImagePropId propertyId);

        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetValueAsObject(AIMPUiImagePropId propertyId, ref Guid iid);

        // Write
        void SetValueAsFloat(AIMPUiImagePropId propertyId, double value);
        void SetValueAsInt32(AIMPUiImagePropId propertyId, int value);
        void SetValueAsInt64(AIMPUiImagePropId propertyId, long value);
        void SetValueAsObject(AIMPUiImagePropId propertyId, [MarshalAs(UnmanagedType.IUnknown)] object value);

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
    }
}