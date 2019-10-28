namespace Aimp4.Api
{
    public enum AIMPUiSpinEditPropId
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

        // IAIMPUISpinEdit
        DisplayMask = AIMPUiWinControlPropId.Max + 1,
        Increment = AIMPUiWinControlPropId.Max + 2,
        MaxValue = AIMPUiWinControlPropId.Max + 3,
        MinValue = AIMPUiWinControlPropId.Max + 4,
        Value = AIMPUiWinControlPropId.Max + 5,
        ValueType = AIMPUiWinControlPropId.Max + 6,
    }
}