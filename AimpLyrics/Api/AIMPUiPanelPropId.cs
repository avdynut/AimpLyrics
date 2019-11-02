namespace Aimp4.Api
{
    public enum AIMPUiPanelPropId
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

        // IAIMPUIPanel
        AutoSize = AIMPUiWinControlPropId.Max + 1,
        Borders = AIMPUiWinControlPropId.Max + 2,
        Transparent = AIMPUiWinControlPropId.Max + 3,
        Padding = AIMPUiWinControlPropId.Max + 4,
    }
}