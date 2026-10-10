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
        private string _resourceTitle;
        private string _title;
        private string _authors;
        private string _performers;
        private string _iswc;
        private int?   _objId;
        private int?   _wic;

        public UcMwIdent()
        {
            InitializeComponent();
            ucReportMw.RowChangedEvent += (object sender, UcReportMw.RowChangedEventArgs e) =>
            {
                _resourceTitle  = e.ResourceTitle ;
                _title          = e.Title         ;
                _authors        = e.Authors       ;
                _performers     = e.Performers    ;
                _iswc           = e.Iswc          ;
                _objId          = e.ObjId         ;
                _wic            = e.Wic           ;

                ucMwSearch.AdviseSearchInfo(e.ResourceTitle, e.Title, e.Authors, e.Performers, e.Iswc);
                ucCisNetImport.ClearControls();
                if (tabControlBottomPanel.SelectedIndex == 2)
                    ucShareCalc.SetWork(e.ObjId, "");
            };
            ucMwSearch.WicSelectedEvent += (object sender, UcMwSearch.WicSelectedEventArgs e) =>
            {
                ucReportMw.SetWic(e.Wic);
            };
            ucMwSearch.ObjIdSelectedEvent += (object sender, UcMwSearch.ObjIdSelectedEventArgs e) =>
            {
                ucReportMw.SetObjId(e.ObjId);
            };
            ucCisNetImport.ObjIdSelectedEvent += (object sender, UcCisNetImport.ObjIdSelectedEventArgs e) =>
            {
                _objId = e.ObjId;
                ucReportMw.SetObjId(e.ObjId);
            };
        }

        public void SetDdexReportId(int ddexReportId)
        {
            ucReportMw.SetDdexReportId(ddexReportId);
        }

        private void ucMwSearch_Load(object sender, EventArgs e)
        {

        }

        private void tabControlBottomPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControlBottomPanel.SelectedIndex == 2)
            {
                ucShareCalc.SetWork(_objId, "");
            }
        }
    }
}
