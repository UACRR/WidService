using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InvoicingLib;
using System.Configuration;
using static InvoicingLib.Workflow;
using System.Data.SqlClient;

namespace DdexInvoicing
{
    public partial class UcDdexLoad : UserControl
    {
        public event EventHandler LoadStarted;
        public event EventHandler LoadCompleted;

        private DdexReportInfo ddexReportInfo;
        private int ddexReportingPeriodId;
        private int ddexReportId;
        //private bool isThresholdApplied;

        public UcDdexLoad()
        {
            InitializeComponent();
        }

        public void Init(int ddexReportingPeriodId, int ddexReportId)
        {
            this.ddexReportingPeriodId = ddexReportingPeriodId;
            this.ddexReportId = ddexReportId;
            UpdateReportInfo();
        }

        public DdexReportInfo GetReportInfo() => ddexReportInfo;
        public bool IsBusy() => bw.IsBusy;
        public bool IsLoading() => DdexDownloadActions.IsDownloadState(ddexReportInfo.Status);


        private void RunAction(int reportStatus)
        {
            try
            {
                ActionRunner runner = DdexDownloadActions.actionRunners[Meta.DdexReportStatus.Action(reportStatus)];
                runner.Init(ConfigurationManager.AppSettings["ConnectionStringDdex"], ddexReportingPeriodId, ddexReportId);
 
                Helpers.RunSqlOperationDdex(cmd =>
                {
                    cmd.CommandText = $@"update DdexReport set Status = @status, SubStatus = @subStatus where id = @ddexReportId";
                    cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);
                    cmd.Parameters.AddWithValue("@status", reportStatus);
                    cmd.Parameters.AddWithValue("@subStatus", Meta.DdexReportSubStatus.IN_PROGRESS);
                    cmd.ExecuteNonQuery();
                });

                runner.Run();

                Helpers.RunSqlOperationDdex(cmd =>
                {
                    cmd.CommandText = $@"update DdexReport set Status = @status, SubStatus = @subStatus where id = @ddexReportId";
                    cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);
                    cmd.Parameters.AddWithValue("@status", reportStatus + 1);
                    cmd.Parameters.AddWithValue("@subStatus", Meta.DdexReportSubStatus.IDLE);
                    cmd.ExecuteNonQuery();
                });
            }
            catch (Exception ex)
            {
                Helpers.RunSqlOperationDdex(cmd =>
                {
                    cmd.CommandText = $@"update DdexReport set SubStatus = @subStatus where id = @ddexReportId";
                    cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);
                    cmd.Parameters.AddWithValue("@subStatus", Meta.DdexReportSubStatus.FAILED);
                    cmd.ExecuteNonQuery();
                });
                ShowException(ex);
            }

        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            int reportStatus = (int)e.Argument;
            RunAction(reportStatus);
        }
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string msgText;
            while (Logger.messages.TryDequeue(out msgText))
                if (!tbLog.IsDisposed)
                    tbLog.AppendText(msgText);
        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateReportInfo();
            UpdateDdexUploadProgress();
            int reportStatus = ddexReportInfo.Status;
            int reportSubStatus = ddexReportInfo.SubStatus;
            //if (reportSubStatus != (int)ActionStatus.IDLE)
            if (reportSubStatus != Meta.DdexReportSubStatus.IDLE)
            {
                LoadCompleted(this, new EventArgs());
                //radPageViewMain.Enabled = true;
                return;
            }
            //if (reportStatus < DdexDownloadActions.actions.Length)
            if (DdexDownloadActions.IsDownloadState(reportStatus))
            {
                radLvActions.SelectedItem[1] = Meta.DdexReportSubStatus.IN_PROGRESS_Name;
                radLvActions.SelectedItem.ImageIndex = (int)StateImage.INPROGRESS_ACTION;
                Logger.bw = bw;
                tbLog.Clear();
                bw.RunWorkerAsync(reportStatus);
            }
            else
            {
                Logger.bw = null;
                LoadCompleted(this, new EventArgs());
                //radPageViewMain.Enabled = true;
            }
        }

        private void radBtnLoadReport_Click(object sender, EventArgs e)
        {
            if (radLvActions.SelectedItem == null)
                return;
            /*
            if (!isThresholdApplied)
            {
                if (MessageBox.Show($"Будуть завантажені записи, що задовільняють порогове знначення {radTbThreshold.Text}."
                      + "Це значення не можна буде змінити в подальшому. Завантажити?"
                    , "Попередження"
                    , MessageBoxButtons.YesNo
                    , MessageBoxIcon.Warning) == DialogResult.No)
                    return;
                Helpers.RunSqlOperationDdex(cmd =>
                {
                    cmd.CommandText = $@"update DdexReport set RoyaltyThreshold = @RoyaltyThreshold where id = @ddexReportId";
                    cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);
                    cmd.Parameters.AddWithValue("@RoyaltyThreshold", Formatter.ToDecimal(radTbThreshold.Text));
                    cmd.ExecuteNonQuery();
                    isThresholdApplied = true;
                });
            }
            */

            LoadStarted(this, new EventArgs());
            //radPageViewMain.Enabled = false;
            int reportStatus = ddexReportInfo.Status;
            radLvActions.SelectedItem[1] = Meta.DdexReportSubStatus.IN_PROGRESS_Name;
            radLvActions.SelectedItem.ImageIndex = (int)StateImage.INPROGRESS_ACTION;
            if (DdexDownloadActions.IsDownloadState(ddexReportInfo.Status)) //reportStatus < DdexDownloadActions.actions.Length)
            {
                Logger.bw = bw;
                tbLog.Clear();
                bw.RunWorkerAsync(reportStatus);
            }
        }

        private void UpdateReportInfo()
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandTimeout = 0;

                cmd.CommandText = $@"
                    select t2.year, t2.quarter, t2.month, t1.*
                    from ddexReport t1 join ddexReportingPeriod t2 on t1.ddexReportingPeriodId = t2.Id
                    where t1.Id = @ddexReportId
                    ";
                cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);

                ddexReportInfo = new DdexReportInfo();
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    r.Read();
                    ddexReportInfo.Year = r.GetInt32(0);
                    ddexReportInfo.IsMonthly = r.IsDBNull(1);
                    ddexReportInfo.TimeUnitValue = ddexReportInfo.IsMonthly ? r.GetInt32(2) : r.GetInt32(1);
                    ddexReportInfo.DdexReportId = r.GetInt32(3);
                    ddexReportInfo.Status = r.GetInt32(5);
                    ddexReportInfo.SubStatus = r.GetInt32(6);
                    ddexReportInfo.FileType = r.GetString(9);
                }

                cmd.CommandText = $@"
                    select 
                          royaltyThreshold
                        , musicRate
                        , geRate
                        , mechSplit
                        , perfSplit
                        , musicPSM
                        , gePSM
                        , exchRate
                    from ddexReport
                    where Id = @ddexReportId
                    ";
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    r.Read();
                    int i = 0;
                    ddexReportInfo.RoyaltyThreshold = r.IsDBNull(i) ? (decimal?)null : r.GetDecimal(i); i++;
                    ddexReportInfo.MusicRate = r.IsDBNull(i) ? (decimal?)null : r.GetDecimal(i); i++;
                    ddexReportInfo.GeRate = r.IsDBNull(i) ? (decimal?)null : r.GetDecimal(i); i++;
                    ddexReportInfo.MechSplit = r.IsDBNull(i) ? (decimal?)null : r.GetDecimal(i); i++;
                    ddexReportInfo.PerfSplit = r.IsDBNull(i) ? (decimal?)null : r.GetDecimal(i); i++;
                    ddexReportInfo.MusicPSM = r.IsDBNull(i) ? (decimal?)null : r.GetDecimal(i); i++;
                    ddexReportInfo.GePSM = r.IsDBNull(i) ? (decimal?)null : r.GetDecimal(i); i++;
                    ddexReportInfo.ExchRate = r.IsDBNull(i) ? (decimal?)null : r.GetDecimal(i); i++;
                }

                cmd.CommandText = $@"
                    select DataValue
                    from DdexReportProcessingData
                    where DdexReportId = @ddexReportId and DataName = 'DdexSourceFolder'
                    ";
                ddexReportInfo.FileFolder = (string)cmd.ExecuteScalar();

                cmd.CommandText = $@"
                    select DataValue
                    from DdexReportProcessingData
                    where DdexReportId = @ddexReportId and DataName = 'DdexFile1'
                    ";
                ddexReportInfo.FileName = (string)cmd.ExecuteScalar();

                cmd.CommandText = $@"
                    select MessageId, MessageCreatedDateTime, UsageStartDate, UsageEndDate, SenderName
                    from DdexRecordHead
                    where DdexReportId = @ddexReportId
                    ";

                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    if (r.HasRows)
                    {
                        r.Read();
                        ddexReportInfo.MessageId = r.GetString(0);
                        ddexReportInfo.MessageCreatedDateTime = r.GetDateTime(1).ToString("yyyy-MM-dd hh:mm:ss");
                        ddexReportInfo.UsageStartDate = r.GetDateTime(2).ToString("yyyy-MM-dd");
                        ddexReportInfo.UsageEndDate = r.GetDateTime(3).ToString("yyyy-MM-dd");
                        ddexReportInfo.SenderName = r.GetString(4);
                    }
                }

                //ucReportInfo.Update(ddexReportInfo);
                UpdateDdexUploadProgress();
                //UpdateTabs();
            });
        }

        private void UpdateDdexUploadProgress()
        {
            radLvActions.Items.Clear();
            for (int curStatus = 0; ; curStatus++)
            {
                if (!DdexDownloadActions.IsDownloadState(curStatus))
                    break;
                string statusText = ddexReportInfo.Status < curStatus ? Meta.DdexReportSubStatus.IDLE_Name :
                    ddexReportInfo.Status > curStatus ? Meta.DdexReportSubStatus.SUCCEEDED_Name :
                    Meta.DdexReportSubStatus.Name(ddexReportInfo.SubStatus);
                radLvActions.Items.Add(Meta.DdexReportStatus.Name(curStatus), statusText);
                var newItem = radLvActions.Items[radLvActions.Items.Count - 1];
                newItem.Tag = curStatus;
                newItem.ImageIndex = ddexReportInfo.Status < curStatus ? (int)StatusImage.FUTURE_ACTION :
                    ddexReportInfo.Status > curStatus ? (int)StatusImage.COMPLETED_ACTION :
                    ddexReportInfo.SubStatus == Meta.DdexReportSubStatus.IDLE ? (int)StatusImage.CURRENT_ACTION :
                    ddexReportInfo.SubStatus == Meta.DdexReportSubStatus.IN_PROGRESS ? (int)StatusImage.INPROGRESS_ACTION :
                    ddexReportInfo.SubStatus == Meta.DdexReportSubStatus.FAILED ? (int)StatusImage.FAILED_ACTION :
                    ddexReportInfo.SubStatus == Meta.DdexReportSubStatus.SUCCEEDED ? (int)StatusImage.COMPLETED_ACTION : (int)StatusImage.FUTURE_ACTION;
                if (ddexReportInfo.Status == curStatus)
                    radLvActions.SelectedItem = newItem;
            }

            radTbThreshold.Text = Formatter.ToString(GetReportInfo().RoyaltyThreshold);
        }

        private void ShowException(Exception ex)
        {
            MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void radBtnChangeThreshold_Click(object sender, EventArgs e)
        {
            if (radLvActions.SelectedItem != radLvActions.Items[0])
            {
                return;
            }
        }
    }
}
