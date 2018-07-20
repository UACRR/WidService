using System;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.Utilities
{
    public static class GridViewHelper
    {
        public static void SetTooltipTextForColumnHeader(object sender, ToolTipTextNeededEventArgs e)
        {
            if (sender is GridHeaderCellElement headerCell)
            {
                e.ToolTipText = headerCell.Text;
            }
        }

        public static void SetComboboxColumnDataSource(this RadGridView gridView, string columnName, object dataSource, string valueMember, string displayMember)
        {
            if (!gridView.Columns.Contains(columnName))
                throw new Exception($"There is no column with name '{columnName}'.");

            var column = gridView.Columns[columnName] as GridViewComboBoxColumn;

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
    }
}
