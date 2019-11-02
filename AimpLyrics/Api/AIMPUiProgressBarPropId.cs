namespace Aimp4.Api
{
    public enum AIMPUiProgressBarPropId
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

        // IAIMPUIProgressBar
        Indeterminate = AIMPUiWinControlPropId.Max + 1,
        Max = AIMPUiWinControlPropId.Max + 2,
        Min = AIMPUiWinControlPropId.Max + 3,
        Progress = AIMPUiWinControlPropId.Max + 4,
    }
}