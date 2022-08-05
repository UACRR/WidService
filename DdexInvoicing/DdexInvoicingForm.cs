using InvoicingLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace DdexInvoicing
{
    public partial class DdexInvoicingForm : Form
    {
        public DdexInvoicingForm()
        {
            Meta.Load();
            DdexDownloadActions.Init();
            DdexAgreements.Load();

            InitializeComponent();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            ucDdexReports.Init();
            ucExceptionSets.Init(UcExceptionSets.Mode.Edit);

            Helpers.RunSqlOperationDdex(cmd =>
            {
                Text = $"Обробка електронних звітів (база даних {cmd.Connection.Database} на сервері {cmd.Connection.DataSource})";
            });
        }

        private void radBtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
