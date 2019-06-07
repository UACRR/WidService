using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.Utilities
{
    public static class DropDownListHelper
    {
        public static void SetDataSource(this RadDropDownList ddl, object dataSource, string valueMember, string displayMemer)
        {
            ddl.ValueMember = valueMember;
            ddl.DisplayMember = displayMemer;
            ddl.DataSource = dataSource;
        }

        public static void SetDataSource(this RadDropDownList ddl, object dataSource)
        {
            SetDataSource(ddl, dataSource, "CodeI", "Name");
        }
    }
}
