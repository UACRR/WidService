using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testing
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnLoadIpiFromDump_Click(object sender, EventArgs e)
        {
            IpiTests.LoadDumpFiles("ftp://ftp.suisa.ch", "UACRR", 
                "S0c-74084lXY-?", 
                "IPI/IPI_Pub/Complete_IPI/20240831",
                @"c:\tmp",
                @"Persist Security Info=False;User=OlegM;Password=111111;Initial Catalog =SocIpiTesting; Server=IPS-TESTS\IPSDATA");
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            using (var conn = new SqlConnection(tbConnectionString.Text))
            {
                conn.Open();
                MessageBox.Show("OK");
            }
        }
    }
}
