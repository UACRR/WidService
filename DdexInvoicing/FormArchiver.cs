using InvoicingLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DdexInvoicing
{
    public partial class FormArchiver : Form
    {
        private bool allowSelChange = true;
        private DdexReportArchiver ddexReportArchiver;

        public FormArchiver(int ddexReportId, string archiveRootFolder, DdexReportArchiver.OperationMode operationMode)
        {
            InitializeComponent();
            Text = operationMode == DdexReportArchiver.OperationMode.Archive ? "Передача звіту в архів" : 
                operationMode == DdexReportArchiver.OperationMode.Restore ? "Відновлення звіту в архіву" : "Видалення відновлених записів";
            ddexReportArchiver = new DdexReportArchiver(ddexReportId, archiveRootFolder, operationMode);
        }

        private void FormArchiver_Load(object sender, EventArgs e)
        {
            string prevStatus = DdexReportArchiver.statCompleted;
            foreach (DataRow row in ddexReportArchiver.dtOperations.Rows)
            {
                string oper = (string)row[2];
                string entity = (string)row[3];
                string status = (string)row[4];
                DdexReportArchiver.StatusInfo statInfo = DdexReportArchiver.statDsc[status];
                radLvOperations.Items.Add(DdexReportArchiver.operDsc[oper].description, entity, statInfo.description);
                var newItem = radLvOperations.Items[radLvOperations.Items.Count - 1];
                newItem.Tag = row;
                if (prevStatus.Equals(DdexReportArchiver.statCompleted, StringComparison.OrdinalIgnoreCase) && status.Equals(DdexReportArchiver.statNotStarted, StringComparison.OrdinalIgnoreCase))
                {
                    newItem.ImageIndex = 1;
                    allowSelChange = true;
                    radLvOperations.SelectedItem = newItem;
                    allowSelChange = false;
                }
                else
                    newItem.ImageIndex = statInfo.imageIndex;
                prevStatus = status;
            }
        }

        private void radLvOperations_SelectedItemChanging(object sender, Telerik.WinControls.UI.ListViewItemCancelEventArgs e)
        {
           e.Cancel = !allowSelChange;
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            using (WaitCursor wc = new WaitCursor())
            {
                ddexReportArchiver.RunOperations(bw);
            }
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var lvItem = radLvOperations.Items[e.ProgressPercentage];
            allowSelChange = true;
            radLvOperations.SelectedItem = lvItem;
            allowSelChange = false;
            lvItem[2] = DdexReportArchiver.statDsc[(string)e.UserState].description;
            lvItem.ImageIndex = DdexReportArchiver.statDsc[(string)e.UserState].imageIndex;
         }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Операцію завершено", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
            radBtnRun.Enabled = true;
        }

        private void radBtnRun_Click(object sender, EventArgs e)
        {
            radBtnRun.Enabled = false;
            bw.RunWorkerAsync();
            //CreateProtocol(14, ARCHIVE_FOLDER);
            //WriteArchivePlan();
            //System.IO.Compression.ZipFile.CreateFromDirectory(ARCHIVE_FOLDER, "D:\\DdexReport14.zip");

            //ArchiveAll("DdexReport", "DdexReport", 14);
            //ClearAll("DdexReport", "DdexReport", 14, true);
            // RestoreAll("DdexReport", true);
            //ArchiveTable("DdexIdentificationBacklog", "DdexReportingPeriod", 7);
            //ClearTable("DdexIdentificationBacklog", "DdexReportingPeriod", 7);
            //RestoreTable("DdexIdentificationBacklog");
        }

        private void radBtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormArchiver_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bw.IsBusy)
            {
                MessageBox.Show("Переривання процесу архівації не підтримується", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
        }
    }
}
