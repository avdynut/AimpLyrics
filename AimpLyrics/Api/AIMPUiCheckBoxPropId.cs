namespace Aimp4.Api
{
    public enum AIMPUiCheckBoxPropId
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

        // IAIMPUICheckBox
        AutoSize = AIMPUiWinControlPropId.Max + 1,
        Caption = AIMPUiWinControlPropId.Max + 2,
        State = AIMPUiWinControlPropId.Max + 3,
        WordWrap = AIMPUiWinControlPropId.Max + 4,
    }
}