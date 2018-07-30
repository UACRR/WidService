using System;
using System.Drawing;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.Utilities
{
    public static class GridViewHelper
    {
        public static void SetTooltipText(object sender, ToolTipTextNeededEventArgs e)
        {
            // tooltip for column header
            if (sender is GridHeaderCellElement headerCell)
            {
                e.ToolTipText = headerCell.Text;
            }
            // tooltip for button in command cell
            else if (sender is RadButtonElement buttonElement && buttonElement.Parent is GridCommandCellElement commandCell)
            {
                e.ToolTipText = ((GridViewCommandColumn)commandCell.ColumnInfo).DefaultText;
            }
        }

        public static void SetComboboxColumnDataSource(this RadGridView gridView, string columnName, object dataSource, string valueMember, string displayMember)
        {
            var column = GetColumnByName(gridView, columnName) as GridViewComboBoxColumn;

            if (column == null)
                throw new Exception($"Column '{columnName}' should be of type GridViewComboBoxColumn.");

            column.ValueMember = valueMember;
            column.DisplayMember = displayMember;
            column.DataSource = dataSource;
        }

        public static void SetComboboxColumnDataSource(this RadGridView gridView, string columnName, object dataSource)
        {
            SetComboboxColumnDataSource(gridView, columnName, dataSource, "CodeI", "Name");
        }

        public static void SetColumnVisibility(this RadGridView gridView, string columnName, bool isVisible)
        {
            var column = GetColumnByName(gridView, columnName);

            column.IsVisible = isVisible;
        }

        public static void SetCommandColumnImageAlignment(this RadGridView gridView, string columnName, ContentAlignment alignment)
        {
            var column = GetColumnByName(gridView, columnName) as GridViewCommandColumn;

            if (column == null)
                throw new Exception($"Column '{columnName}' should be of type GridViewCommandColumn.");

            column.ImageAlignment = alignment;
        }

        private static GridViewDataColumn GetColumnByName(this RadGridView gridView, string columnName)
        {
            if (!gridView.Columns.Contains(columnName))
                throw new Exception($"There is no column with name '{columnName}'.");

            return gridView.Columns[columnName];
        }
    }
}
