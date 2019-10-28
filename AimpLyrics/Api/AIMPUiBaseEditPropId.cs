namespace Aimp4.Api
{
    public enum AIMPUiBaseEditPropId
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

        // IAIMPUIBaseEdit
        Borders = AIMPUiWinControlPropId.Max + 1,
        MaxLength = AIMPUiWinControlPropId.Max + 2,
        ReadOnly = AIMPUiWinControlPropId.Max + 3,
        SelectionLength = AIMPUiWinControlPropId.Max + 4,
        SelectionStart = AIMPUiWinControlPropId.Max + 5,
        SelectedText = AIMPUiWinControlPropId.Max + 6,
        Text = AIMPUiWinControlPropId.Max + 7,

        Max = AIMPUiWinControlPropId.Max + 10,
    }
}