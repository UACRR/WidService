using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DdexInvoicing
{
    public partial class UcMwIdent : UserControl
    {
        public UcMwIdent()
        {
            InitializeComponent();
            ucReportMw.RowChangedEvent += (object sender, UcReportMw.RowChangedEventArgs e) =>
            {
                ucMwSearch.AdviseSearchInfo(e.ResourceTitle, e.Title, e.Authors, e.Performers, e.Iswc);
            };
            ucMwSearch.WicSelectedEvent += (object sender, UcMwSearch.WicSelectedEventArgs e) =>
            {
                ucReportMw.SetWic(e.Wic);
            };
            ucMwSearch.ObjIdSelectedEvent += (object sender, UcMwSearch.ObjIdSelectedEventArgs e) =>
            {
                ucReportMw.SetObjId(e.ObjId);
            };
        }

        public void SetDdexReportId(int ddexReportId)
        {
            ucReportMw.SetDdexReportId(ddexReportId);
        }
    }
}
