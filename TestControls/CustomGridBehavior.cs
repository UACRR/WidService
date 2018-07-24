using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace TestControls
{

    //initiates drag and drop service for clicked rows
    public class RowSelectionGridBehavior : GridDataRowBehavior
    {
        public RadGridView Target { get;  }
        public GridDataRowElement DragDropRow { get; private set; }
        public RowSelectionGridBehavior(RadGridView target) : base()
        {
            Target = target;
        }

        protected override bool OnMouseDownLeft(MouseEventArgs e)
        {
            GridDataRowElement row = this.GetRowAtPoint(e.Location) as GridDataRowElement;
            if (row != null)
            {
                DragDropRow = row;
                RadGridViewDragDropService svc = this.GridViewElement.GetService<RadGridViewDragDropService>();
                svc.AllowAutoScrollColumnsWhileDragging = false;
                svc.AllowAutoScrollRowsWhileDragging = false;
                svc.Start(row);
            }
            return base.OnMouseDownLeft(e);
        }

        public void GetRowAtDropPoint( Point Location )
        {
            DragDropRow = this.GetRowAtPoint(Location) as GridDataRowElement;
        }

        internal void SetTargetRow(GridDataRowElement dropTargetRow)
        {
            DragDropRow = dropTargetRow;
        }
    }
}
