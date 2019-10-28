namespace Aimp4.Api
{
    public enum AIMPUiButtonPropId
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

        // IAIMPUIButton
        Caption = AIMPUiWinControlPropId.Max + 1,
        FocusOnClick = AIMPUiWinControlPropId.Max + 2,
        Default = AIMPUiWinControlPropId.Max + 3,
        DropDownMenu = AIMPUiWinControlPropId.Max + 4,
        ImageIndex = AIMPUiWinControlPropId.Max + 5,
        ImageList = AIMPUiWinControlPropId.Max + 6,
        ModalResult = AIMPUiWinControlPropId.Max + 7,
        Style = AIMPUiWinControlPropId.Max + 8,
    }
}