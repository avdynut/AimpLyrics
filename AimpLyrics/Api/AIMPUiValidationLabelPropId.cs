namespace Aimp4.Api
{
    public enum AIMPUiValidationLabelPropId
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
        AutoSize = AIMPUiLabelPropId.AutoSize,
        Line = AIMPUiLabelPropId.Line,
        Text = AIMPUiLabelPropId.Text,
        TextAlign = AIMPUiLabelPropId.TextAlign,
        TextVerticalAlign = AIMPUiLabelPropId.TextVerticalAlign,
        TextColor = AIMPUiLabelPropId.TextColor,
        TextStyle = AIMPUiLabelPropId.TextStyle,
        Transparent = AIMPUiLabelPropId.Transparent,
        Url = AIMPUiLabelPropId.Url,
        WordWrap = AIMPUiLabelPropId.WordWrap,

        // IAIMPUIValidationLabel
        Glyph = AIMPUiLabelPropId.Max + 1,
    }
}