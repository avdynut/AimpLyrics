namespace Aimp4.Api
{
    public enum AIMPUiTreeListPropId
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

        // IAIMPUiTreeList
        AllowDeleting = AIMPUiWinControlPropId.Max + 1,
        AllowEditing = AIMPUiWinControlPropId.Max + 2,
        AllowFocusCells = AIMPUiWinControlPropId.Max + 3,
        AllowMultiSelect = AIMPUiWinControlPropId.Max + 4,
        AllowReorderColumns = AIMPUiWinControlPropId.Max + 5,
        AllowShowHideColumns = AIMPUiWinControlPropId.Max + 6,
        AutoCheckSubNodes = AIMPUiWinControlPropId.Max + 7,
        Borders = AIMPUiWinControlPropId.Max + 8,
        CellHints = AIMPUiWinControlPropId.Max + 9,
        CheckBoxes = AIMPUiWinControlPropId.Max + 10,
        ColumnAutoWidth = AIMPUiWinControlPropId.Max + 11,
        ColumnHeight = AIMPUiWinControlPropId.Max + 12,
        ColumnImages = AIMPUiWinControlPropId.Max + 13,
        ColumnVisible = AIMPUiWinControlPropId.Max + 14,
        DragSorting = AIMPUiWinControlPropId.Max + 15,
        DragSortingChangeLevel = AIMPUiWinControlPropId.Max + 16,
        GridLines = AIMPUiWinControlPropId.Max + 20,
        GroupHeight = AIMPUiWinControlPropId.Max + 21,
        Groups = AIMPUiWinControlPropId.Max + 22,
        GroupsAllowCollapse = AIMPUiWinControlPropId.Max + 23,
        GroupsFocusOnClick = AIMPUiWinControlPropId.Max + 24,
        HotTrack = AIMPUiWinControlPropId.Max + 25,
        IncSearchColumnIndex = AIMPUiWinControlPropId.Max + 26,
        NodeHeight = AIMPUiWinControlPropId.Max + 27,
        NodeImageAlignment = AIMPUiWinControlPropId.Max + 28,
        NodeImages = AIMPUiWinControlPropId.Max + 29,
        SortingMode = AIMPUiWinControlPropId.Max + 30,
    }
}