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
    }
}
