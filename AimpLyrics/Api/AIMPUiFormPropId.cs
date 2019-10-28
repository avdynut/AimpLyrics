namespace Aimp4.Api
{
    public enum AIMPUiFormPropId
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

        // IAIMPUIForm
        BorderIcons = AIMPUiWinControlPropId.Max + 1,
        BorderStyle = AIMPUiWinControlPropId.Max + 2,
        Caption = AIMPUiWinControlPropId.Max + 3,
        CloseByEscape = AIMPUiWinControlPropId.Max + 4,
        Icon = AIMPUiWinControlPropId.Max + 5,
        Padding = AIMPUiWinControlPropId.Max + 6,
        ShowOnTaskBar = AIMPUiWinControlPropId.Max + 7,
    }
}