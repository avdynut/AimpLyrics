namespace Aimp4.Api
{
    public enum AIMPUiGroupBoxPropId
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

        // IAIMPUIGroupBox
        AutoSize = AIMPUiWinControlPropId.Max + 1,
        Borders = AIMPUiWinControlPropId.Max + 2,
        Transparent = AIMPUiWinControlPropId.Max + 3,
        CheckMode = AIMPUiWinControlPropId.Max + 4,
        Checked = AIMPUiWinControlPropId.Max + 5,
        Caption = AIMPUiWinControlPropId.Max + 6,
    }
}