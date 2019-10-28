namespace Aimp4.Api
{
    public enum AIMPUiWinControlPropId
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
        Focused = AIMPUiControlPropId.Max + 1,
        TabOrder = AIMPUiControlPropId.Max + 2,

        Max = AIMPUiControlPropId.Max + 10,
    }
}