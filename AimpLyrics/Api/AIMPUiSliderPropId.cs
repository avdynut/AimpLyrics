namespace Aimp4.Api
{
    public enum AIMPUiSliderPropId
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

        // IAIMPUISlider
        Horizontal = AIMPUiWinControlPropId.Max + 1,
        Marks = AIMPUiWinControlPropId.Max + 2,
        PageSize = AIMPUiWinControlPropId.Max + 3,
        Transparent = AIMPUiWinControlPropId.Max + 4,
        Value = AIMPUiWinControlPropId.Max + 5,
        ValueDefault = AIMPUiWinControlPropId.Max + 6,
        ValueMax = AIMPUiWinControlPropId.Max + 7,
        ValueMin = AIMPUiWinControlPropId.Max + 8,
    }
}