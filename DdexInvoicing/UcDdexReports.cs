using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls.Data;
using System.Configuration;
using InvoicingLib;
using System.Data.SqlClient;

namespace DdexInvoicing
{
    public partial class UcDdexReports : UserControl
    {
        public UcDdexReports()
        {
            InitializeComponent();
        }

        public void Init()
        {
            radGridViewReports.MasterTemplate.AutoExpandGroups = true;

            GroupDescriptor descriptor = new GroupDescriptor();
            descriptor.GroupNames.Add("licenseeName", ListSortDirection.Ascending);
            radGridViewReports.GroupDescriptors.Add(descriptor);

            descriptor = new GroupDescriptor();
            descriptor.GroupNames.Add("year", ListSortDirection.Descending);
            radGridViewReports.GroupDescriptors.Add(descriptor);

            descriptor = new GroupDescriptor();
            descriptor.GroupNames.Add("quarter", ListSortDirection.Descending);
            radGridViewReports.GroupDescriptors.Add(descriptor);

            descriptor = new GroupDescriptor();
            descriptor.GroupNames.Add("licenseeName", ListSortDirection.Descending);
            radGridAgreements.GroupDescriptors.Add(descriptor);

            //descriptor = new GroupDescriptor();
            //descriptor.GroupNames.Add("licenseDescription", ListSortDirection.Descending);
            //radGridViewReports.GroupDescriptors.Add(descriptor);
            FillAgreements();
            radGridAgreements.CurrentRow = null;
            FillReports();
        }

        private void FillAgreements()
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = $@"
                    select licId
                        , custId
                        , Name licenseeName
                        , licCodeName licenseDescription
                    from vMSCustomerUses
                    -- order by t4.[year] desc,  t4.[quarter] desc
                ";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                radGridAgreements.DataSource = dt;

                Text = $"Обробка електронних звітів від клієнтів ({cmd.Connection.DataSource})";
            });
        }

        private void FillReports()
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                if (radGridAgreements.CurrentRow == null
                    || radGridViewReports.CurrentRow is GridViewGroupRowInfo
                    || radGridAgreements.CurrentRow.Cells[0].Value == null)
                {
                    radGridViewReports.DataSource = null;
                    radLabelReports.Text = "Звіти (договір не вібрано)";
                    return;
                }
                int licId = (int)radGridAgreements.CurrentRow.Cells[0].Value;
                int custId = (int)radGridAgreements.CurrentRow.Cells[1].Value;

                cmd.CommandText = $@"
                    select t2.ddexReportingPeriodId
                        , t2.Id ddexReportId
                        , t4.year
                        , t4.quarter
                        , t1.Name licenseeName
                        , t1.licCodeName licenseDescription
                        , t3.serviceDescription
                        , t2.status
                        , case when t5.groupName is null then t5.name else t5.groupName end as statusName
                    from vMSCustomerUses t1
                        join ddexReport t2 on t1.licId = t2.licId	and t1.custId = t2.custId
                        join ddexrecordhead t3 on t3.DdexReportId = t2.id
                        join ddexReportingPeriod t4 on t4.id = t2.ddexReportingPeriodId
                        join DdexReportStatus t5 on t5.codeI = t2.Status
                    where t1.licId = @licId and t1.custId = @custId
                ";
                cmd.Parameters.AddWithValue("@licId", licId);
                //cmd.Parameters.AddWithValue("@licVersion", licVersion);
                cmd.Parameters.AddWithValue("@custId", custId);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                radGridViewReports.DataSource = dt;

                if (dt.Rows.Count == 0)
                    radLabelReports.Text = $"Звіти договору {radGridAgreements.CurrentRow.Cells[4].Value} - договір не має звітів";
                else
                    radLabelReports.Text = $"Звіти договору {radGridAgreements.CurrentRow.Cells[4].Value}";
            });
        }

        private void RegisterReport(string clientName, int licId, int custId)
        {
            object reportType = null;
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = $@"
                    select paramValue paramValue
                    from AgreementParam
                    where paramId = 8 and licId = @licId and custId = @custId
                ";
                cmd.Parameters.AddWithValue("@licId", licId);
                //cmd.Parameters.AddWithValue("@licVersion", licVersion);
                cmd.Parameters.AddWithValue("@custId", custId);

                reportType = cmd.ExecuteScalar();
            });

            if (reportType == null)
            {
                MessageBox.Show("Не прописаний тип звіту, що надходить згідно договору. "
                    + "Зайдіть на форму конфігурації договору і внесіть потрібне значення", "Помилка конфігурації договору", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Get agreement parameters
            decimal? 
                musicRate = null, geRate = null,
                mechSplit = null, perfSplit = null, 
                musicPSM = null, gePSM = null,
                royaltyThreshold = 0;
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = $@"
                    select 
                          paramId
                        , paramValue
                    from AgreementParam
                    where licId = @licId and custId = @custId
                ";
                cmd.Parameters.AddWithValue("@licId", licId);
                cmd.Parameters.AddWithValue("@custId", custId);

                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while(r.Read())
                    {
                        if (r.IsDBNull(1))
                            continue;
                        string val = r.GetString(1);
                        switch (r.GetInt32(0))
                        {
                            case 1:
                                musicRate = Formatter.ToDecimal(val);
                                break;
                            case 2:
                                geRate = Formatter.ToDecimal(val);
                                break;
                            case 3:
                                mechSplit = Formatter.ToDecimal(val);
                                break;
                            case 4:
                                perfSplit = Formatter.ToDecimal(val);
                                break;
                            case 5:
                                musicPSM = Formatter.ToDecimal(val);
                                break;
                            case 6:
                                gePSM = Formatter.ToDecimal(val);
                                break;
                            case 9:
                                royaltyThreshold = Formatter.ToDecimal(val);
                                break;
                        }
                    }
                }
            });
            if(musicRate == null || geRate == null || mechSplit == null || perfSplit == null ||
                !((string)reportType).Equals("AdSupport-Music", StringComparison.OrdinalIgnoreCase) &&
                (musicPSM == null || gePSM == null)
            )
            {
                MessageBox.Show("Не визначені параметри договору, необхідні для обробки звіту. "
                   + "Зайдіть на форму конфігурації договору і внесіть потрібне значення", "Помилка конфігурації договору", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Файли звітів від клієнта (*.tsv)|*.tsv";
            if (DialogResult.OK != dlg.ShowDialog())
                return;
            string fullFileName = dlg.FileName;

            try
            {
                decimal exchRate = DdexReport.PreRegisterReport(licId, custId, clientName, (string)reportType, fullFileName);

                string paramValues = $"Процент за музичний контент: {musicRate}\r\n";
                paramValues += $"Процент за розважальний контент: {geRate}\r\n";
                paramValues += $"Процент правовласності за механічне виконання: {mechSplit}\r\n";
                paramValues += $"Процент правовласності за публічне виконання: {perfSplit}\r\n";
                if (!((string)reportType).Equals("AdSupport-Music", StringComparison.OrdinalIgnoreCase))
                {
                    paramValues += $"Тариф на музичний контент: {musicPSM} грн.\r\n";
                    paramValues += $"Тариф на розважальний контент: {gePSM} грн.\r\n";
                    paramValues += $"Курс обміну (доларів за гривню): {exchRate}\r\n";
                }
                paramValues += $"Мінімум роялті що приймається до розгляду: {royaltyThreshold} USD\r\n";

                if (MessageBox.Show("Договір буде зарейєстровано з наступною інформацією для виконаня обчислень.\r\n"
                    + paramValues + "Зарейеструвати?", "Конфігурація договору", 
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                DdexReport.RegisterReport(licId, custId, clientName, (string)reportType, fullFileName, exchRate);
                FillReports();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                var result = MessageBox.Show("Згенерувати повторно помилку? (програма може аварійно зупинитись)", "#DEBUG MODE",MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (result == DialogResult.Yes)
                    throw;
            }
        }

        private void radGridViewReports_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            if (e.Column.FieldName.Equals("Show", StringComparison.OrdinalIgnoreCase))
            {
                RadButtonElement btn = (e.CellElement as GridCommandCellElement).CommandButton;
                btn.Text = "Показати";
                int status = (int)e.Row.Cells["status"].Value;
                btn.Enabled = !(status == Meta.DdexReportStatus.ARCHIVING
                    || status == Meta.DdexReportStatus.ARCHIVED
                    || status == Meta.DdexReportStatus.RESTORING
                    || status == Meta.DdexReportStatus.CLEANING);
                return;
            }
            else if (e.Column.FieldName.Equals("AgreementParams", StringComparison.OrdinalIgnoreCase))
            {
                RadButtonElement btn = (e.CellElement as GridCommandCellElement).CommandButton;
                btn.Text = "Параметри договору";
            }
            else if (e.Column.FieldName.Equals("Archive", StringComparison.OrdinalIgnoreCase))
            {
                int status = (int)e.Row.Cells["status"].Value;
                if (status == Meta.DdexReportStatus.INVOICING)
                    (e.CellElement as GridCommandCellElement).CommandButton.Text = "Обробку завершено";
                else if (status == Meta.DdexReportStatus.INVOICING_COMPLETED)
                    (e.CellElement as GridCommandCellElement).CommandButton.Text = "До архіву";
                else if (status == Meta.DdexReportStatus.ARCHIVING)
                    (e.CellElement as GridCommandCellElement).CommandButton.Text = "До архіву";
                else if (status == Meta.DdexReportStatus.ARCHIVED)
                    (e.CellElement as GridCommandCellElement).CommandButton.Text = "Відновити з архіву";
                else if (status == Meta.DdexReportStatus.RESTORING)
                    (e.CellElement as GridCommandCellElement).CommandButton.Text = "Відновити з архіву";
                else if (status == Meta.DdexReportStatus.RESTORED)
                    (e.CellElement as GridCommandCellElement).CommandButton.Text = "Видалити відновлені записи";
                else if (status == Meta.DdexReportStatus.CLEANING)
                    (e.CellElement as GridCommandCellElement).CommandButton.Text = "Видалити відновлені записи";
                else
                    (e.CellElement as GridCommandCellElement).CommandButton.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
                return;
            }

        }

        private void radGridViewReports_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            int ddexReportId = (int)e.Row.Cells["ddexReportId"].Value;
            int ddexReportingPeriodId = (int)e.Row.Cells["ddexReportingPeriodId"].Value;

            if (e.Column.FieldName.Equals("Show", StringComparison.OrdinalIgnoreCase))
            {
                FormDdexInvoicing form = new FormDdexInvoicing();
                form.ddexReportId = ddexReportId;
                form.ddexReportingPeriodId = ddexReportingPeriodId;
                form.Show();
            }
            else if (e.Column.FieldName.Equals("Archive", StringComparison.OrdinalIgnoreCase))
            {
                int status = (int)e.Row.Cells["Status"].Value;
                DdexReportArchiver.OperationMode mode;
                if (status == Meta.DdexReportStatus.INVOICING)
                {
                    Helpers.RunSqlOperationDdex(cmd =>
                    {
                        cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);
                        cmd.Parameters.AddWithValue("@status", Meta.DdexReportStatus.INVOICING_COMPLETED);
                        cmd.CommandText = "update DdexReport set status = @status where id = @ddexReportId";
                        cmd.ExecuteNonQuery();
                        FillReports();
                    });
                    return;
                }
                else if (status == Meta.DdexReportStatus.INVOICING_COMPLETED || status == Meta.DdexReportStatus.ARCHIVING)
                    mode = DdexReportArchiver.OperationMode.Archive;
                else if (status == Meta.DdexReportStatus.ARCHIVED || status == Meta.DdexReportStatus.RESTORING)
                    mode = DdexReportArchiver.OperationMode.Restore;
                else if (status == Meta.DdexReportStatus.RESTORED || status == Meta.DdexReportStatus.CLEANING)
                    mode = DdexReportArchiver.OperationMode.CleanRestored;
                else
                    return;

                string archFolder;
                try
                {
                    archFolder = ConfigurationManager.AppSettings["DdexArchiveRootFolder"];
                    if (archFolder == null)
                        throw new Exception("Не задано папку для зберігання архівів");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Помилка конфігурації", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                FormArchiver form = new FormArchiver(ddexReportId, archFolder, mode);
                form.ShowDialog();
                FillReports();
            }
        }

        private void radBtnRegisterReports_Click(object sender, EventArgs e)
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
                DdexReport.RegisterReports(ConfigurationManager.AppSettings["ConnectionStringDdex"], filesPath);
                FillReports();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void radGridAgreements_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            int licId = (int)e.Row.Cells["licId"].Value;
            int custId = (int)e.Row.Cells["custId"].Value;
            string clientName = (string)e.Row.Cells["licenseeName"].Value;

            if (e.Column.FieldName.Equals("RegisterReport", StringComparison.OrdinalIgnoreCase))
            {
                RegisterReport(clientName, licId, custId);
            }
            else if (e.Column.FieldName.Equals("EditParameters", StringComparison.OrdinalIgnoreCase))
            {
                FormAgreementParams form = new FormAgreementParams();
                form.licId = licId;
                form.custId = custId;
                form.ShowDialog();
            }
        }

        private void radGridAgreements_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.Column.FieldName.Equals("RegisterReport", StringComparison.OrdinalIgnoreCase))
            {
                RadButtonElement btn = (e.CellElement as GridCommandCellElement).CommandButton;
                btn.Text = "Прийняти звіт";
            }
            else if (e.Column.FieldName.Equals("EditParameters", StringComparison.OrdinalIgnoreCase))
            {
                RadButtonElement btn = (e.CellElement as GridCommandCellElement).CommandButton;
                btn.Text = "Параметри договору";
            }
        }

        private void radGridAgreements_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            FillReports();
        }

    }
}
