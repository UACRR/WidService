using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace TestControls
{
    public class CustomGridBehavior : BaseGridBehavior
    {
        List<GridViewRowInfo> selectedRows = new List<GridViewRowInfo>();
        public Type GridType { get; }
        public List<GridViewRowInfo> SelectedRows
        {
            get { return this.selectedRows; }
        }

        public CustomGridBehavior(Type gridType) : base()
        {
            GridType = gridType;
        }
        public override bool OnMouseDown(MouseEventArgs e)
        {
            selectedRows.Clear();
            bool result = base.OnMouseDown(e);


            selectedRows.Add(this.GridControl.CurrentRow);
            if (!this.GridViewElement.IsInEditMode && this.GridViewElement.CurrentRow == this.RowAtPoint.RowInfo && this.RowAtPoint != null)
            {
                RadGridViewDragDropService service = this.GridViewElement.GetService<RadGridViewDragDropService>();
                service.Start(this.RowAtPoint);
            }

            return result;
        }

    }

    //initiates drag and drop service for clicked rows
    public class RowSelectionGridBehavior : GridDataRowBehavior
    {
        protected override bool OnMouseDownLeft(MouseEventArgs e)
        {
            GridDataRowElement row = this.GetRowAtPoint(e.Location) as GridDataRowElement;
            if (row != null)
            {
                RadGridViewDragDropService svc = this.GridViewElement.GetService<RadGridViewDragDropService>();
                svc.AllowAutoScrollColumnsWhileDragging = false;
                svc.AllowAutoScrollRowsWhileDragging = false;
                svc.Start(row);
            }
            return base.OnMouseDownLeft(e);
        }
    }
}
