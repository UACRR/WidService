using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using InvoicingLib;
using static InvoicingLib.Workflow;

namespace DdexInvoicing
{
    public partial class FormDdexInvoicing : Form
    {
        private string CONNECTION_STRING = ConfigurationManager.AppSettings["ConnectionStringDdex"];

        public int ddexReportingPeriodId;
        public int ddexReportId;

        public FormDdexInvoicing()
        {
            InitializeComponent();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            ucDdexLoad.Init(ddexReportingPeriodId, ddexReportId);
            if(DdexReport.IsSrmf(ddexReportId))
            {
                uсReconcile.SetReport(ddexReportId);
            }
            else
            {
                radPageViewMain.Pages.RemoveAt(2);
            }

            //ucMwIdent.SetDdexReportId(ddexReportId);
            ucCcidInvoices.SetReport(ddexReportId);

            ucDdexLoad.LoadStarted += UcDdexLoad_LoadStarted;
            ucDdexLoad.LoadCompleted += UcDdexLoad_LoadCompleted;

            DdexReportInfo ddexReportInfo = ucDdexLoad.GetReportInfo();
            ucReportInfo.Update(ddexReportInfo);

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionStringDdex"]))
            {
                conn.Open();
                var timeUnitName = ddexReportInfo.IsMonthly ? "місяць" : "квартал";
                Text = $"Звіт від {ddexReportInfo.SenderName}, рік {ddexReportInfo.Year}, {timeUnitName} {ddexReportInfo.TimeUnitValue}, {ddexReportInfo.FileType}";
            }

            UpdateTabs();

        }

        private void UcDdexLoad_LoadCompleted(object sender, EventArgs e)
        {
            radPageViewMain.Enabled = true;
            ucReportInfo.Update(ucDdexLoad.GetReportInfo());
            UpdateTabs();
        }

        private void UcDdexLoad_LoadStarted(object sender, EventArgs e)
        {
            radPageViewMain.Enabled = false;
            UpdateTabs();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(ucDdexLoad.IsBusy())
            {
                if (DialogResult.Yes != MessageBox.Show("Перервати поточну операцію і закрити вікно?", "Попередження", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    e.Cancel = true;
            }
        }

        private void UpdateTabs()
        {
            radPageViewMain.Pages["radPageMwIdent"].Enabled =
            radPageViewMain.Pages["radPageInvoicing"].Enabled =
                !ucDdexLoad.IsLoading();

            //!DdexDownloadActions.IsDownloadState(ddexReportInfo.Status);
        }


    }
}
