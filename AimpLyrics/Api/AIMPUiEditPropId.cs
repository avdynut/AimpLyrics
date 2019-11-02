namespace Aimp4.Api
{
    public enum AIMPUiEditPropId
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

        // IAIMPUIBaseEdit
        Borders = AIMPUiBaseEditPropId.Borders,
        MaxLength = AIMPUiBaseEditPropId.MaxLength,
        ReadOnly = AIMPUiBaseEditPropId.ReadOnly,
        SelectionLength = AIMPUiBaseEditPropId.SelectionLength,
        SelectionStart = AIMPUiBaseEditPropId.SelectionStart,
        SelectedText = AIMPUiBaseEditPropId.SelectedText,
        Text = AIMPUiBaseEditPropId.Text,

        // IAIMPUIBaseButtonnedEdit
        ButtonsImages = AIMPUiBaseButtonedEditPropId.ButtonsImages,

        // IAIMPUIEdit
        PasswordChar = AIMPUiBaseButtonedEditPropId.Max + 2,
        TextHint = AIMPUiBaseButtonedEditPropId.Max + 3,
    }
}