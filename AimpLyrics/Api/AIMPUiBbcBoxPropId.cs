namespace Aimp4.Api
{
    public enum AIMPUiBbcBoxPropId
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

        // IAIMPUIBBCBox
        Borders = AIMPUiWinControlPropId.Max + 1,
        Text = AIMPUiWinControlPropId.Max + 2,
        Transparent = AIMPUiWinControlPropId.Max + 3,
        WordWrap = AIMPUiWinControlPropId.Max + 4,
    }
}