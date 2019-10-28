namespace Aimp4.Api
{
    public enum AIMPUiImagePropId
    {
        // IAIMPUIControl
        Custom = AIMPUiControlPropId.Custom,
        Enabled = AIMPUiControlPropId.Enabled,
        Hint = AIMPUiControlPropId.Hint,
        Name = AIMPUiControlPropId.Name,
        Parent = AIMPUiControlPropId.Parent,
        PopupMenu = AIMPUiControlPropId.PopupMenu,
        Visible = AIMPUiControlPropId.Visible,

        // IAIMPUIWinControl
        Focused = AIMPUiWinControlPropId.Focused,
        TabOrder = AIMPUiWinControlPropId.TabOrder,

        // IAIMPUIImage
        Image = AIMPUiWinControlPropId.Max + 1,
        ImageStretchMode = AIMPUiWinControlPropId.Max + 2,
        ImageIndex = AIMPUiWinControlPropId.Max + 3,
        ImageList = AIMPUiWinControlPropId.Max + 4,
    }
}