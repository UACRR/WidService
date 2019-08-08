using System;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.Utilities
{
    public static class GridViewHelper
    {
        public static void SubscribeToolTipTextNeeded(this RadGridView gridView)
        {
            gridView.ToolTipTextNeeded += gridView_ToolTipTextNeeded;
        }

        public static void SetTooltipText(object sender, ToolTipTextNeededEventArgs e)
        {
            // tooltip for text which is too big for the cell - works for header cell and data cell
            if (sender is GridDataCellElement || sender is GridHeaderCellElement)
            {
                var cell = sender as GridCellElement;

                TextPart textPart = new TextPart(cell);
                SizeF size = textPart.Measure(new SizeF(float.PositiveInfinity, float.PositiveInfinity));
                SizeF sizeInCell = textPart.Measure(new SizeF(cell.ColumnInfo.Width, float.PositiveInfinity));

                float cellWidth = cell.ColumnInfo.Width - cell.BorderWidth * 2;
                float cellHeight = cell.Size.Height - cell.BorderWidth * 2;

                if (size.Width > cellWidth || cellHeight < sizeInCell.Height)
                {
                    e.ToolTipText = cell.Text;
                }
            }
            // tooltip for button in command cell
            else if (sender is RadButtonElement buttonElement && buttonElement.Parent is GridCommandCellElement commandCell)
            {
                e.ToolTipText = ((GridViewCommandColumn)commandCell.ColumnInfo).DefaultText;
            }
        }

        public static void DisplayErrors(object sender, CellFormattingEventArgs e)
        {
            GridDataCellElement cell = e.CellElement as GridDataCellElement;
            if (cell != null)
            {
                if (cell.ContainsErrors)
                {
                    cell.DrawBorder = true;
                    cell.BorderBoxStyle = BorderBoxStyle.FourBorders;
                    cell.BorderBottomColor = cell.BorderTopColor = cell.BorderRightShadowColor = cell.BorderLeftShadowColor = Color.Transparent;
                    cell.BorderBottomShadowColor = cell.BorderTopShadowColor = cell.BorderRightColor = cell.BorderLeftColor = Color.Red;
                    cell.BorderBottomWidth = cell.BorderTopWidth = cell.BorderRightWidth = cell.BorderLeftWidth = 1;
                    cell.BorderDrawMode = BorderDrawModes.HorizontalOverVertical; cell.ZIndex = 2;
                }
                else
                {
                    cell.ResetValue(LightVisualElement.DrawBorderProperty, ValueResetFlags.Local);
                    cell.ResetValue(LightVisualElement.BorderBoxStyleProperty, ValueResetFlags.Local);
                    cell.ResetValue(LightVisualElement.BorderBottomColorProperty, ValueResetFlags.Local);
                    cell.ResetValue(LightVisualElement.BorderBottomShadowColorProperty, ValueResetFlags.Local);
                    cell.ResetValue(LightVisualElement.BorderBottomWidthProperty, ValueResetFlags.Local);
                    cell.ResetValue(LightVisualElement.BorderTopColorProperty, ValueResetFlags.Local);
                    cell.ResetValue(LightVisualElement.BorderTopShadowColorProperty, ValueResetFlags.Local);
                    cell.ResetValue(LightVisualElement.BorderTopWidthProperty, ValueResetFlags.Local);
                    cell.ResetValue(LightVisualElement.BorderLeftColorProperty, ValueResetFlags.Local);
                    cell.ResetValue(LightVisualElement.BorderLeftShadowColorProperty, ValueResetFlags.Local);
                    cell.ResetValue(LightVisualElement.BorderLeftWidthProperty, ValueResetFlags.Local);
                    cell.ResetValue(LightVisualElement.BorderDrawModeProperty, ValueResetFlags.Local);
                    cell.ResetValue(LightVisualElement.ZIndexProperty, ValueResetFlags.Local);
                }
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

        public static void SetColumnReadOnly(this RadGridView gridView, string columnName, bool isReadOnly)
        {
            var column = GetColumnByName(gridView, columnName);

            column.ReadOnly = isReadOnly;
        }

        public static void SetCommandColumnImageAlignment(this RadGridView gridView, string columnName, ContentAlignment alignment)
        {
            var column = GetColumnByName(gridView, columnName) as GridViewCommandColumn;

            if (column == null)
                throw new Exception($"Column '{columnName}' should be of type GridViewCommandColumn.");

            column.ImageAlignment = alignment;
        }

        public static void SetColumnTimeSpanEditor(this RadGridView gridView, string columnName)
        {
            var column = GetColumnByName(gridView, columnName) as GridViewDateTimeColumn;

            if (column == null)
                throw new Exception($"Column '{columnName}' should be of type GridViewDateTimeColumn.");

            column.DataTypeConverter = new TimeSpanToDateTimeConverter();
            column.Format = DateTimePickerFormat.Custom;
            column.CustomFormat = "HH:mm:ss";
            column.EditorType = GridViewDateTimeEditorType.TimePicker;
        }

        private static GridViewDataColumn GetColumnByName(this RadGridView gridView, string columnName)
        {
            if (!gridView.Columns.Contains(columnName))
                throw new Exception($"There is no column with name '{columnName}'.");

            return gridView.Columns[columnName];
        }

        private static void gridView_ToolTipTextNeeded(object sender, ToolTipTextNeededEventArgs e)
        {
            SetTooltipText(sender, e);
        }
    }
}
