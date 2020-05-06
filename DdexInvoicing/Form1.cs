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
    public partial class FormMainOld : Form
    {
        private string CONNECTION_STRING = ConfigurationManager.AppSettings["ConnectionStringDdex"];

        Workflow workflow;

        private int selectedReportingPeriodId = -1;
        private int selectedReportId = -1;

        public FormMainOld()
        {
            InitializeComponent();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            CreatePeriodWorkflowButtons();
            CreateReportWorkflowButtons();
            FillReportingPeriodsCombo();
            FillReportsCombo();
            if (selectedReportId != -1)
            {
                workflow.AllowOverwrite = true;
                UpdateButtonStates();
            }
        }
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(bw.IsBusy || bwAutoRunner.IsBusy)
            {
                if (DialogResult.Yes != MessageBox.Show("Перервати поточну операцію і закрити вікно?", "Попередження", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    e.Cancel = true;
            }
        }

        #region Control Event Handlers
        private void workflow_PreRunAction(object sender, PreRunEventArgs e)
        {

        }

        private void btnRegisterReports_Click(object sender, EventArgs e)
        {
            string filesPath;
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    filesPath = fbd.SelectedPath + "\\";
                }
                else
                {
                    return;
                }
            }

            try
            {
                DdexReport.RegisterReports(CONNECTION_STRING, filesPath);
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
            FillReportingPeriodsCombo();
            FillReportsCombo();
        }

        private void btnWorkflowAction_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (cbReports.SelectedIndex == -1)
                return;

            InvoicingLib.ActionInfo action = Workflow.actions[(int)btn.Tag];
            if (!workflow.CheckActionValid(action))
                return;

            action.runner.Init(CONNECTION_STRING, selectedReportingPeriodId, selectedReportId);
            if (!action.runner.PreRun())
                return;

            btn.ImageIndex = (int)Workflow.StateImage.INPROGRESS_ACTION;

            Logger.bw = bw;
            tbLog.Clear();
            EnableControls(false);
            bw.RunWorkerAsync((int)btn.Tag);
        }
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            //ActionRunner runner = (ActionRunner)e.Argument;
            int actionIndex = (int)e.Argument;
            try
            {
                workflow.RunAction(actionIndex);
                //ActionRunner.RunAction(runner);
            }
            catch(Exception ex)
            {
                ShowException(ex);
            }
            UpdateButtonStates();
        }
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string msgText;
            while (Logger.messages.TryDequeue(out msgText))
                if(!tbLog.IsDisposed)
                    tbLog.AppendText(msgText);
        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            EnableControls(true);
        }

        private void btnAutoRun_Click(object sender, EventArgs e)
        {
            if (selectedReportingPeriodId == -1)
                return;
            if(workflow.IsPeriodProcessingStarted())
            {
                MessageBox.Show("Автоматичну обробку звітів вже було розпочато. Продовження з перерваного місця в автоматичному режимі не реалізовано."
                    , "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            cbReports.SelectedIndex = 0;
            int ddexReportId = (int)cbReports.SelectedItem.GetType().GetProperty("ReportId").GetValue(cbReports.SelectedItem);
            Logger.bw = bwAutoRunner;
            tbLog.Clear();
            EnableControls(false);
            bwAutoRunner.RunWorkerAsync(ddexReportId);
        }
        private void bwAutoRunner_DoWork(object sender, DoWorkEventArgs e)
        {
            int ddexReportId = (int)e.Argument;
            for (int i = 0; i < Workflow.reportActionsCount; i++)
            {
                e.Result = true;
                try
                {
                    workflow.RunAction(i);
                }
                catch (Exception ex)
                {
                    ShowException(ex);
                    e.Result = false;
                    UpdateButtonStates();
                    return;
                }
                UpdateButtonStates();
            }
        }
        private void bwAutoRunner_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string msgText;
            while (Logger.messages.TryDequeue(out msgText))
                if (!tbLog.IsDisposed)
                    tbLog.AppendText(msgText);
        }
        private void bwAutoRunner_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((bool)e.Result == true && cbReports.SelectedIndex < cbReports.Items.Count - 1)
            {
                cbReports.SelectedIndex++;
                int ddexReportId = (int)cbReports.SelectedItem.GetType().GetProperty("ReportId").GetValue(cbReports.SelectedItem);
                bwAutoRunner.RunWorkerAsync(ddexReportId);
            }
            else
            {
                EnableControls(true);
            }
        }

        private void cbReportingPeriods_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedReportingPeriodId = (int)cbReportingPeriods.SelectedItem.GetType().GetProperty("PeriodId").GetValue(cbReportingPeriods.SelectedItem);
            FillReportsCombo();
        }
        private void cbReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedReportId = (int)cbReports.SelectedItem.GetType().GetProperty("ReportId").GetValue(cbReports.SelectedItem);
            workflow = Workflow.CreateInstance(CONNECTION_STRING, selectedReportingPeriodId, selectedReportId);
            workflow.PreRun += workflow_PreRunAction;
            UpdateButtonStates();
        }
        #endregion Control Event Handlers

        private void FillReportingPeriodsCombo()
        {
            DataTable dt = DdexReport.GetReportingPeriods(CONNECTION_STRING);
            List<object> periods = new List<object>();
            foreach (DataRow row in dt.Rows)
            {
                string itemText = $"{row[3]}, квартал {row[4]}";
                periods.Add(new
                {
                    Text = $"{row[3]}, квартал {row[4]}",
                    PeriodId = row[0]
                });
            }

            if (periods.Count > 0)
            {
                cbReportingPeriods.DataSource = periods;
                cbReportingPeriods.DisplayMember = "Text";
                cbReportingPeriods.ValueMember = "PeriodId";
            }
        }
        private void FillReportsCombo()
        {
            if (cbReportingPeriods.SelectedItem == null)
                return;
            int selectedPeriodId = (int)cbReportingPeriods.SelectedItem.GetType().GetProperty("PeriodId").GetValue(cbReportingPeriods.SelectedItem);
            DataTable dt = DdexReport.GetRegisteredReports(CONNECTION_STRING, selectedPeriodId);
            List<object> reports = new List<object>();
            foreach (DataRow row in dt.Rows)
            {
                string itemText = $"{row[6]}";
                reports.Add(new
                {
                    Text = $"{row[6]}",
                    ReportId = row[0]
                });
            }

            if (reports.Count > 0)
            {
                cbReports.DataSource = reports;
                cbReports.DisplayMember = "Text";
                cbReports.ValueMember = "ReportId";
            }
        }

        private void CreatePeriodWorkflowButtons()
        {
            panelPeriodWorkFlowButtons.ColumnCount = Workflow.actions.Length - Workflow.reportActionsCount + 1;
            panelPeriodWorkFlowButtons.ColumnStyles[0] = new ColumnStyle(SizeType.Absolute, 120);
            for (int i = 0; i < panelPeriodWorkFlowButtons.ColumnCount - 1; i++)
            {
                panelPeriodWorkFlowButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
            }

            for (int i = 0; i < panelPeriodWorkFlowButtons.ColumnCount- 1; i++)
            {
                var actionData = Workflow.actions[i + Workflow.reportActionsCount];
                actionData.button = new Button()
                {
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft,
                    ImageList = ilMain,
                    ImageAlign = ContentAlignment.TopRight,
                    Height = 35,
                    Width = 280,
                    Text = actionData.buttonText,
                    Tag = i + (int)Workflow.reportActionsCount
                };
                actionData.button.Click += btnWorkflowAction_Click;
                panelPeriodWorkFlowButtons.Controls.Add(actionData.button, i, 0);
            }
        }
        private void CreateReportWorkflowButtons()
        {
            panelReportWorkFlowButtons.RowCount = Workflow.reportActionsCount;
            panelReportWorkFlowButtons.RowStyles[0] = new RowStyle(SizeType.Absolute, 35);
            for (int i = 0; i < Workflow.reportActionsCount + 1; i++)
            {
                panelReportWorkFlowButtons.RowStyles.Add(new RowStyle(SizeType.Absolute, 35));
            }

            for (int i = 0; i < Workflow.reportActionsCount; i++)
            {
                var actionData = Workflow.actions[i];
                actionData.button = new Button()
                {
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft,
                    ImageList = ilMain,
                    ImageAlign = ContentAlignment.MiddleRight,
                    //Height = 35,
                    //Width = 280,
                    Text = actionData.buttonText,
                    Tag = i
                };
                actionData.button.Click += btnWorkflowAction_Click;
                panelReportWorkFlowButtons.Controls.Add(actionData.button, 0, i);
            }
            panelReportWorkFlowButtons.Controls.Add(new Button() { Width = 0}, 0, Workflow.reportActionsCount);
        }

        private void UpdateButtonStates()
        {
            workflow.UpdateButtonStates();
        }
        private void EnableControls(bool enable)
        {
            btnRegisterReports.Enabled = enable;
            cbReports.Enabled = enable;
            cbReportingPeriods.Enabled = enable;
            btnAutoRun.Enabled = enable;
            for (int i = 0; i < Workflow.actions.Length; i++)
            {
                var actionData = Workflow.actions[i];
                actionData.button.Enabled = enable;
            }
        }

        private void ShowException(Exception ex)
        {
            MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnFillSubscriptionInfo_Click(object sender, EventArgs e)
        {

        }
    }
}
