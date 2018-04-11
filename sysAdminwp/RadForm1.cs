using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using sysAdminwp.model;
using ipsmedserviceapp.Model;
using Telerik.WinControls.UI;
using System.IO;
using WebAPIConnector;

namespace sysAdminwp
{
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm
    {

        private ApiConnector connector = new ApiConnector("http://localhost:54867/");
        private List<Category> list;

        public RadForm1()
        {
            list = connector.GetList<Category>("api/dictionary/category");
            InitializeComponent();

            radGridView1.DataSource = list;
            radGridView1.CurrentRowChanged += RadGridView1_CurrentRowChanged;
        }

        private void RadGridView1_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            radTBNameUa.Text = e.CurrentRow.Cells[1].Value.ToString();
        }

        private void radBtnAdd_Click(object sender, EventArgs e)
        {
            radGridView1.AllowAddNewRow = !radGridView1.AllowAddNewRow;
        }

        private void radBtnRemove_Click(object sender, EventArgs e)
        {
            using (GridViewDataRowInfo gvdri = radGridView1.CurrentRow as GridViewDataRowInfo)
            {
                if (gvdri!=null)
                {
                    radGridView1.Rows.Remove(gvdri);
                    
                    //this.UpdatePanelInfo(radGridView1.CurrentRow);
                }
            }

            //GridViewDataRowInfo gvdri = this.radGridView1.CurrentRow as GridViewDataRowInfo;
            
        }
    }
}
