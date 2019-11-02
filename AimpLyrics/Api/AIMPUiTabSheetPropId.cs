namespace Aimp4.Api
{
    public enum AIMPUiTabSheetPropId
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

        // IAIMPUITabSheet
        Caption = AIMPUiWinControlPropId.Max + 1,
        Index = AIMPUiWinControlPropId.Max + 2,
        SheetVisible = AIMPUiWinControlPropId.Max + 3,
    }
}