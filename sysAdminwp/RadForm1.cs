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
        }
    }
}
