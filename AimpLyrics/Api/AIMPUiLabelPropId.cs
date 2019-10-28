namespace Aimp4.Api
{
    public enum AIMPUiLabelPropId
    {
        // IAIMPUIControl
        Custom = AIMPUiControlPropId.Custom,
        Enabled = AIMPUiControlPropId.Enabled,
        Hint = AIMPUiControlPropId.Hint,
        Name = AIMPUiControlPropId.Name,
        Parent = AIMPUiControlPropId.Parent,
        PopupMenu = AIMPUiControlPropId.PopupMenu,
        Visible = AIMPUiControlPropId.Visible,

        // IAIMPUILabel
        AutoSize = AIMPUiControlPropId.Max + 1,
        Line = AIMPUiControlPropId.Max + 2,
        Text = AIMPUiControlPropId.Max + 3,
        TextAlign = AIMPUiControlPropId.Max + 4,
        TextVerticalAlign = AIMPUiControlPropId.Max + 5,
        TextColor = AIMPUiControlPropId.Max + 6,
        TextStyle = AIMPUiControlPropId.Max + 7,
        Transparent = AIMPUiControlPropId.Max + 8,
        Url = AIMPUiControlPropId.Max + 9,
        WordWrap = AIMPUiControlPropId.Max + 10,

        Max = AIMPUiControlPropId.Max + 20,
    }
}