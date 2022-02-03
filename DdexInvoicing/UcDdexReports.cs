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
using System.IO;

namespace DdexInvoicing
{
    public partial class UcDdexReports : UserControl
    {
        private bool skipFillReports;
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
            skipFillReports = true;
            FillAgreements();
            radGridAgreements.CurrentRow = null;
            skipFillReports = false;
            FillReports();
        }

        private void FillAgreements()
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                Text = $"Обробка електронних звітів від клієнтів ({cmd.Connection.DataSource})";
            });

            DataTable dt = new DataTable();

            dt.Columns.Add("licId");
            dt.Columns.Add("custId");
            dt.Columns.Add("licenseeName");
            dt.Columns.Add("licenseDescription");

            DdexAgreements.Agreements.ForEach(x =>
            {
                var row = dt.NewRow();
                row["licId"] = x.LicId;
                row["custId"] = x.CustId;
                row["licenseeName"] = x.LicenseeName;
                row["licenseDescription"] = x.LicenseDescription;
                dt.Rows.Add(row);
            });

            radGridAgreements.DataSource = dt;
        }

        private void FillReports()
        {
            if (skipFillReports)
            {
                return;
            }

            radLabelReports.BackColor = Color.Transparent;
            radLabelReports.ForeColor = Color.Black;

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

                int licId = int.Parse((string)radGridAgreements.CurrentRow.Cells[0].Value);
                int custId = int.Parse((string)radGridAgreements.CurrentRow.Cells[1].Value);

                var agreementReportType = DdexReport.GetAgreementReportType(cmd, licId, custId);
                if (agreementReportType == null)
                {
                    radGridViewReports.DataSource = null;
                    radLabelReports.Text = "ПОМИЛКА: в параметрах договору відсутня чи невірна інформація про тип файлу звіту";
                    radLabelReports.BackColor = Color.Red;
                    radLabelReports.ForeColor = Color.White;
                    return;
                }

                var isMonthlyReport = DdexReport.IsMonthlyReport(cmd, licId, custId);

                var col = radGridViewReports.MasterTemplate.Columns["quarter"];
                if(isMonthlyReport)
                {
                    col.FieldName = "month";
                    col.HeaderText = "Місяць";
                    cmd.CommandText = $@"
                        select t2.ddexReportingPeriodId
                            , t2.Id ddexReportId
                            , t4.year
                            , t4.month
                            , 'Spotify' licenseeName
                            , 'Free' licenseDescription
                            , t3.serviceDescription
                            , t2.status
                            , case when t5.groupName is null then t5.name else t5.groupName end as statusName
                        from ddexReport t2
                            join ddexrecordhead t3 on t3.DdexReportId = t2.id
                            join ddexReportingPeriod t4 on t4.id = t2.ddexReportingPeriodId
                            join DdexReportStatus t5 on t5.codeI = t2.Status
                        where t2.licId = @licId and t2.custId = @custId
                    ";
                }
                else
                {
                    col.FieldName = "quarter";
                    col.HeaderText = "Квартал";
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
                }

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@licId", licId);
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

        private void RegisterReport(int licId, int custId)
        {
            // GET REPORT TYPE FROM AGREEMENT PARAMETERS
            var agreementReportType = DdexReport.GetAgreementReportType(licId, custId);
            if (agreementReportType == null)
            {
                MessageBox.Show("Не прописаний або невірний тип звіту, що надходить згідно договору. "
                    + "Зайдіть на форму конфігурації договору і внесіть потрібне значення", "Помилка конфігурації договору", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // CHECK THAT ALL REQUIRED AGREEMENT PARAMETERS ARE PROVIDED
            var checkResult = DdexReport.CheckAgreementParameters(licId, custId);
            if (checkResult != null)
            {
                MessageBox.Show(checkResult
                   + ". Зайдіть на форму конфігурації договору і внесіть потрібне значення", "Помилка конфігурації договору", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // SELECT VALID REPORT FILE
            var filter = DdexReport.GetFileNameWildcard(agreementReportType);
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = $"Файли звітів від клієнта|{filter}";
            if (DialogResult.OK != dlg.ShowDialog())
                return;
            string fullFileName = dlg.FileName;

            // Because user may change filter, check that finally selected file matches wildcard
            var dir = Path.GetDirectoryName(fullFileName);
            if(!Directory.EnumerateFiles(dir, filter).Any(x => x.Equals(fullFileName, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Файл не відповідає типу звіту", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // MAKE SURE REPORTING PERIOD FOR THE REPORT EXISTS BASED ON REPORT FILE
            var ddexReportingPeriodId = DdexReport.CreateReportingPeriod(agreementReportType, fullFileName);

            // CHECK THAT THE REPORT IS NOT REGISTERED YET
            if(DdexReport.CheckReportExists(agreementReportType, ddexReportingPeriodId))
            {
                MessageBox.Show("Вибраний файл вже зарейєстрований в системі", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // CHECK THAT EXHANGE RATE IS SET FOR THE REPORT FILE'S PERIOD
            if (DdexReport.CheckExchangeRateExists(licId, custId, agreementReportType, fullFileName))
            {
                MessageBox.Show("Не визначений курс обміну, необхідний для обробки звіту. "
                            + "Зайдіть на форму конфігурації договору і внесіть потрібне значення", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // CONFIRM PARAMETERS FOR REPORT REGISTRATION
            var paramsText = DdexReport.GetAgreementParametersText(licId, custId, fullFileName);
            if (MessageBox.Show("Договір буде зарейєстровано з наступною інформацією для виконаня обчислень.\r\n"
                + paramsText + "\r\nЗарейеструвати?", "Конфігурація договору",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            // CREATE REGISTRATION RECORDS IN THE DATABASE
            try
            {
                DdexReport.RegisterReport(licId, custId, agreementReportType, fullFileName);
                FillReports();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private string DoLoadDdexAdjConsolidated(int ddexReportId, string fileFullName, string fileType)
        {
            try
            {
                string retVal = "";
                DdexReport ddexReport = new DdexReport(ConfigurationManager.AppSettings["ConnectionStringDdex"], ddexReportId);
                if (fileType.Equals("AdSupport-Music", StringComparison.OrdinalIgnoreCase))
                {
                    ddexReport.ProcessAdjustment(new DdexReportActionLoadAdjAvod(), fileFullName);
                }
                else
                {
                    ddexReport.ProcessAdjustment(new DdexReportActionLoadAdjSvod(), fileFullName);
                }

                Helpers.RunSqlOperationDdexT(cmd =>
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);
                    cmd.CommandText = $@"spDdexAdjConsolidatedCalcRoyalty";
                    cmd.ExecuteNonQuery();
                }, true);

                Helpers.RunSqlOperationDdex(cmd =>
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);

                    cmd.Parameters.Add("@result", SqlDbType.VarChar);
                    cmd.Parameters["@result"].Direction = ParameterDirection.Output;
                    cmd.Parameters["@result"].Size = 100;

                    cmd.Parameters.Add("@RetCode", SqlDbType.Int);
                    cmd.Parameters["@RetCode"].Direction = ParameterDirection.Output;

                    cmd.CommandText = $@"spDdexAdjConsolidatedDistRoyalty";
                    cmd.ExecuteNonQuery();

                    if((int)cmd.Parameters["@RetCode"].Value == 1)
                    {
                        retVal = (string)cmd.Parameters["@result"].Value;
                    }
                }, true);

                return retVal;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }

        }

        private bool LoadDdexAdjConsolidated(int ddexReportId, int ddexReportingPeriodId)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Файли консолідованих звітів від клієнта (*.tsv)|*.tsv";
            if (DialogResult.OK != dlg.ShowDialog())
                return false;
            string fileFullName = dlg.FileName;
            string fileName = Path.GetFileNameWithoutExtension(dlg.FileName);

            // Get data for file name validation from db
            string fileType = "";
            int year = 0;
            int quarter = 0;
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);
                cmd.Parameters.AddWithValue("@ddexReportingPeriodId", ddexReportingPeriodId);

                cmd.CommandText = "select FileType from DdexReport where id = @ddexReportId";
                fileType = (string)cmd.ExecuteScalar();

                cmd.CommandText = "select year from DdexReportingPeriod where id = @ddexReportingPeriodId";
                year = (int)cmd.ExecuteScalar();

                cmd.CommandText = "select quarter from DdexReportingPeriod where id = @ddexReportingPeriodId";
                quarter = (int)cmd.ExecuteScalar();
            });

            // Validate file from its name
            // Example: DSR_UACRR-CS_YouTube_AdjConsolidated-AdSupport-Music-All_2019-Q2_UA_1of1_20201207T204552
            string expectedAdjFileType = 
                fileType.Equals("AdSupport-Music", StringComparison.OrdinalIgnoreCase) ?    "AdSupport" :
                fileType.Equals("Subscription-Music", StringComparison.OrdinalIgnoreCase) ? "SubscriptionMusic" :
                                                                                            "SubscriptionPremium";
            string expectedFileStart = $"DSR_UACRR-CS_YouTube_AdjConsolidated-{expectedAdjFileType}-Music-All_{year}-Q{quarter}_UA_1of1_";

            if (!fileName.StartsWith(expectedFileStart, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Файл не відповідає типу звіту", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            FormLongOperation form = new FormLongOperation("Виконується побудова даних для розподілу. Зачекайте, будь ласка.");
            Form parent = FindForm();
            form.Show(parent);
            var task = new Task<string>(() => { return DoLoadDdexAdjConsolidated(ddexReportId, fileFullName, fileType); });
            task.Start();
            task.Wait();
            form.Hide();

            if(!string.IsNullOrEmpty(task.Result))
            {
                MessageBox.Show(task.Result, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            MessageBox.Show("Дані для розподілу роялті побудовані і передані в БД MediaService", "Операція завершена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
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
                    //(e.CellElement as GridCommandCellElement).CommandButton.Text = "Обробку завершено";
                    (e.CellElement as GridCommandCellElement).CommandButton.Text = "Розподілити";
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
                    /*
                    Helpers.RunSqlOperationDdex(cmd =>
                    {
                        cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);
                        cmd.Parameters.AddWithValue("@status", Meta.DdexReportStatus.INVOICING_COMPLETED);
                        cmd.CommandText = "update DdexReport set status = @status where id = @ddexReportId";
                        cmd.ExecuteNonQuery();
                        FillReports();
                    });
                    */
                    if (LoadDdexAdjConsolidated(ddexReportId, ddexReportingPeriodId))
                    {
                        Helpers.RunSqlOperationDdex(cmd =>
                        {
                            cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);
                            cmd.Parameters.AddWithValue("@status", Meta.DdexReportStatus.INVOICING_COMPLETED);
                            cmd.CommandText = "update DdexReport set status = @status where id = @ddexReportId";
                            cmd.ExecuteNonQuery();
                        });
                        FillReports();
                    }

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

        private void radGridAgreements_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            int licId = int.Parse((string)e.Row.Cells["licId"].Value);
            int custId = int.Parse((string)e.Row.Cells["custId"].Value);
            string clientName = (string)e.Row.Cells["licenseeName"].Value;

            if (e.Column.FieldName.Equals("RegisterReport", StringComparison.OrdinalIgnoreCase))
            {
                RegisterReport(licId, custId);
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
