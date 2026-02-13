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

        private int licId = 0;
        private int custId = 0;
        private string licenseeName = null;
        private string licenseDescription = null;

        public UcDdexReports()
        {
            InitializeComponent();
        }

        public void Init()
        {
            radGridViewReports.MasterTemplate.AutoExpandGroups = true;

            GroupDescriptor descriptor = new GroupDescriptor();
           /* descriptor.GroupNames.Add("year", ListSortDirection.Descending);
            radGridViewReports.GroupDescriptors.Add(descriptor);

            descriptor = new GroupDescriptor();
            descriptor.GroupNames.Add("quarter", ListSortDirection.Descending);
            radGridViewReports.GroupDescriptors.Add(descriptor);*/

            radGridAgreements.MasterTemplate.AutoExpandGroups = true;
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
                var isMultiFile = DdexReport.IsMultiFile(agreementReportType);

                var col = radGridViewReports.MasterTemplate.Columns["quarter"];

                if (isMonthlyReport)
                {
                    col.FieldName = "month";
                    col.HeaderText = "Місяць";
                }
                else
                {
                    col.FieldName = "quarter";
                    col.HeaderText = "Квартал";
                }

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@licId", licId);
                cmd.Parameters.AddWithValue("@custId", custId);

                cmd.CommandText = $@"
                    select t2.ddexReportingPeriodId
                        , t2.Id ddexReportId
                        , t4.year
                        , {(isMonthlyReport ? "t4.month" : "t4.quarter")}
                        , t2.status
                        , case when t5.groupName is null then t5.name else t5.groupName end as statusName
                    from DdexReport t2
                        join DdexRecordHead t3 on t3.DdexReportId = t2.id
                        join ddexReportingPeriod t4 on t4.id = t2.ddexReportingPeriodId
                        join DdexReportStatus t5 on t5.codeI = t2.Status
                    where t2.licId = @licId 
                        and t2.custId = @custId
                        and t2.IsMasterReport = 1
                    order by t4.year desc, t4.quarter, t4.month desc
                ";

////                if (isMonthlyReport)
////                {
////                    if (isMultiFile)
//                  {
//                      col.FieldName = "month";
//                      col.HeaderText = "Місяць";
//                      cmd.CommandText = $@"
//                          select t2.ddexReportingPeriodId
//                              , t2.Id ddexReportId
//                              , t4.year
//                              , t4.month
//                              , t2.status
//                              , case when t5.groupName is null then t5.name else t5.groupName end as statusName
//                          from ddexReport t2
//                              join ddexrecordhead t3 on t3.DdexReportId = t2.id
//                              join ddexReportingPeriod t4 on t4.id = t2.ddexReportingPeriodId
//                              join DdexReportStatus t5 on t5.codeI = t2.Status
//                          where t2.licId = @licId and t2.custId = @custId and IsMasterReport = 1
//                          order by t4.year desc, t4.month desc
//                      ";
//                  }
////                    else
//                  {
//                      col.FieldName = "month";
//                      col.HeaderText = "Місяць";
//                      cmd.CommandText = $@"
//                          select t2.ddexReportingPeriodId
//                              , t2.Id ddexReportId
//                              , t4.year
//                              , t4.month
//                              , t2.status
//                              , case when t5.groupName is null then t5.name else t5.groupName end as statusName
//                          from ddexReport t2
//                              join ddexrecordhead t3 on t3.DdexReportId = t2.id
//                              join ddexReportingPeriod t4 on t4.id = t2.ddexReportingPeriodId
//                              join DdexReportStatus t5 on t5.codeI = t2.Status
//                          where t2.licId = @licId and t2.custId = @custId
//                          order by t4.year desc, t4.month desc
//                      ";
//                  }
//                }
//                else
//                {
//                    if(isMultiFile)
//                    {
//                        col.FieldName = "quarter";
//                        col.HeaderText = "Квартал";
//                        cmd.CommandText = $@"
//                            select t2.ddexReportingPeriodId
//                                , t2.Id ddexReportId
//                                , t4.year
//                                , t4.quarter
//                                , t2.status
//                                , case when t5.groupName is null then t5.name else t5.groupName end as statusName
//                            from vMSCustomerUses t1
//                                join ddexReport t2 on t1.licId = t2.licId	and t1.custId = t2.custId
//                                join ddexReportingPeriod t4 on t4.id = t2.ddexReportingPeriodId
//                                join DdexReportStatus t5 on t5.codeI = t2.Status
//                                join DdexRecordHead t6 on t2.id = t6.ddexReportId
//                            where
//                                     t1.licId = @licId 
//                                 and t1.custId = @custId
//                                 and t6.ServiceDescription = @ServiceDescription
//                            order by t4.year desc, t4.quarter desc
//                        ";
//                        cmd.Parameters.AddWithValue("@ServiceDescription", DdexReport.GetServiceNames(agreementReportType)[0]);
//                    }
//                    else
//                    {
//                        col.FieldName = "quarter";
//                        col.HeaderText = "Квартал";
//                        cmd.CommandText = $@"
//                            select t2.ddexReportingPeriodId
//                                , t2.Id ddexReportId
//                                , t4.year
//                                , t4.quarter
//                                , t2.status
//                                , case when t5.groupName is null then t5.name else t5.groupName end as statusName
//                            from vMSCustomerUses t1
//                                join ddexReport t2 on t1.licId = t2.licId	and t1.custId = t2.custId
//                                join ddexrecordhead t3 on t3.DdexReportId = t2.id
//                                join ddexReportingPeriod t4 on t4.id = t2.ddexReportingPeriodId
//                                join DdexReportStatus t5 on t5.codeI = t2.Status
//                            where t1.licId = @licId and t1.custId = @custId
//                            order by t4.year desc, t4.quarter desc
//                        ";
//                    }
//                }

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                radGridViewReports.DataSource = dt;

                if (dt.Rows.Count == 0)
                    radLabelReports.Text = $"Звіти {licenseeName}- {licenseDescription} - договір не має звітів";
                else
                    radLabelReports.Text = $"Звіти {licenseeName}- {licenseDescription}";
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

            if (DdexReport.IsDeezerType(agreementReportType))
            {
                RegisterMultiFileReport(licId, custId, agreementReportType);
            }
            else if (DdexReport.IsTikTokType(agreementReportType))
            {
                RegisterTikTokFileReport(licId, custId, agreementReportType);
            }
            else if (DdexReport.IsMetaType(agreementReportType))
            {
                RegisterMetaFileReport(licId, custId, agreementReportType);
            }
            else
            {
                RegisterSingleFileReport(licId, custId, agreementReportType);
            }
        }

        private void RegisterSingleFileReport(int licId, int custId, string agreementReportType)
        {
            // SELECT VALID REPORT FILE
            var filter = DdexReport.GetFileNameWildcard(agreementReportType);
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = $"Файли звітів від клієнта|{filter}";
            if (DialogResult.OK != dlg.ShowDialog())
                return;
            string fullFileName = dlg.FileName;

            // Because user may change filter, check that finally selected file matches wildcard
            var dir = Path.GetDirectoryName(fullFileName);
            if (!Directory.EnumerateFiles(dir, filter).Any(x => x.Equals(fullFileName, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Файл не відповідає типу звіту", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // MAKE SURE REPORTING PERIOD FOR THE REPORT EXISTS BASED ON REPORT FILE
            var ddexReportingPeriodId = DdexReport.CreateReportingPeriod(agreementReportType, fullFileName);

            // CHECK THAT THE REPORT IS NOT REGISTERED YET
            if (DdexReport.CheckSingleFileReportExists(agreementReportType, ddexReportingPeriodId))
            {
                MessageBox.Show("Вибраний файл вже зарейєстрований в системі", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // CHECK THAT EXHANGE RATE IS SET FOR THE REPORT FILE'S PERIOD
            if (!CheckExchangeRates(licId, custId, agreementReportType, fullFileName))
            {
                MessageBox.Show("Не визначений курс обміну, необхідний для обробки звіту. "
                            + "Зайдіть на форму конфігурації договору і внесіть потрібне значення", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // CONFIRM PARAMETERS FOR REPORT REGISTRATION
            if (!ConfirmParametersForReportRegistration(licId, custId, fullFileName))
            {
                return;
            }

            // CREATE REGISTRATION RECORDS IN THE DATABASE
            try
            {
                DdexReport.RegisterSingleFileReport(licId, custId, agreementReportType, fullFileName);
                FillReports();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void RegisterMultiFileReport(int licId, int custId, string agreementReportType)
        {
            var serviceNames = DdexReport.GetServiceNames(agreementReportType);

            // SELECT VALID REPORT FOLDER
            var dlg = new FolderBrowserDialog();
            dlg.Description = $"Фолдер файлів звіту від клієнта";
            if (DialogResult.OK != dlg.ShowDialog())
                return;
            string fullFolderName = dlg.SelectedPath;

            // Check that folder contains files for all services
            var errorText = "";
            var serviceNamesInFolder = "";
            foreach(var serviceName in serviceNames)
            {
                var filter = DdexReport.GetFileNameWildcardForService(agreementReportType, serviceName);
                var files = Directory.GetFiles(fullFolderName, filter);
                if(files.Length == 1)
                {
                    serviceNamesInFolder += $"{serviceName} ";
                }
                else if (files.Length > 1)
                {
                    errorText = $"Знайдено декілька файлів для сервісу {serviceName}";
                    break;
                }
            }

            if(!string.IsNullOrEmpty(errorText))
            {
                MessageBox.Show(errorText, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(serviceNamesInFolder))
            {
                MessageBox.Show("Фолдер не містить жодного файлу сервісу", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(DialogResult.Yes != MessageBox.Show(
                $"Фолдер містить файли для наступних сервісів - {serviceNamesInFolder.Trim()}. Виконати реєстрацію?", 
                "Реєстрація", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            // MAKE SURE REPORTING PERIOD FOR THE REPORT EXISTS BASED ON REPORT FILE
            var firstFileWildcard = DdexReport.GetFileNameWildcardForService(agreementReportType, serviceNames[0]);
            var firstFileFullName = Directory.GetFiles(fullFolderName, firstFileWildcard)[0];
            var ddexReportingPeriodId = DdexReport.CreateReportingPeriod(agreementReportType, firstFileFullName);

            // CHECK THAT THE REPORT IS NOT REGISTERED YET 
            // CHECK AGAINST THE FIRST FILE IS SUFFICIENT BECAUSE REGISTRATION RECORDS ARE WRITTEN In SINGLE DB TRANSACTIONS
            if (DdexReport.CheckSingleFileReportExists(agreementReportType, ddexReportingPeriodId))
            {
                MessageBox.Show("Вибраний звіт вже зарейєстрований в системі", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // CHECK THAT EXHANGE RATE IS SET FOR THE REPORT FILE'S PERIOD
            if (!CheckExchangeRates(licId, custId, agreementReportType, firstFileFullName))
            {
                MessageBox.Show("Не визначений курс обміну, необхідний для обробки звіту. "
                            + "Зайдіть на форму конфігурації договору і внесіть потрібне значення", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // CONFIRM PARAMETERS FOR REPORT REGISTRATION
            if(!ConfirmParametersForReportRegistration(licId, custId, firstFileFullName))
            {
                return;
            }

            // CREATE REGISTRATION RECORDS IN THE DATABASE
            try
            {
                DdexReport.RegisterMultiFileReport(licId, custId, agreementReportType, firstFileFullName);
                FillReports();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void RegisterTikTokFileReport(int licId, int custId, string agreementReportType)
        {
            MessageBox.Show("Розташуйте файли від TikTok за місяць в окремому фолдері, потім виберіть "
                + "в цьому фолдері файл звіту для території UA.", 
                "Завантаження звітів TikTok", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            // SELECT VALID REPORT FILE
            var filter = DdexReport.GetFileNameWildcard(agreementReportType);
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = $"Файли звітів від клієнта|{filter}";
            if (DialogResult.OK != dlg.ShowDialog())
                return;
            string fullFileName = dlg.FileName;

            // Because user may change filter, check that finally selected file matches wildcard
            var dir = Path.GetDirectoryName(fullFileName);
            if (!Directory.EnumerateFiles(dir, filter).Any(x => x.Equals(fullFileName, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Файл не відповідає типу звіту", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // MAKE SURE REPORTING PERIOD FOR THE REPORT EXISTS BASED ON REPORT FILE
            var ddexReportingPeriodId = DdexReport.CreateReportingPeriod(agreementReportType, fullFileName);

            // CHECK THAT THE REPORT IS NOT REGISTERED YET
            if (DdexReport.CheckSingleFileReportExists(agreementReportType, ddexReportingPeriodId))
            {
                MessageBox.Show("Вибраний файл вже зарейєстрований в системі", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // CONFIRM PARAMETERS FOR REPORT REGISTRATION
            if (!ConfirmParametersForReportRegistration(licId, custId, fullFileName))
            {
                return;
            }

            // CREATE REGISTRATION RECORDS IN THE DATABASE
            try
            {
                DdexReport.RegisterTikTokReport(licId, custId, agreementReportType, fullFileName);
                FillReports();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void RegisterMetaFileReport(int licId, int custId, string agreementReportType)
        {
            MessageBox.Show("Розташуйте файли від META за квартал в окремому фолдері, потім виберіть "
                + "в цьому фолдері файл звіту для території UA.", 
                "Завантаження звітів META", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            // SELECT VALID REPORT FILE
            var filter = DdexReport.GetFileNameWildcard(agreementReportType);
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = $"Файли звітів від клієнта|{filter}";
            if (DialogResult.OK != dlg.ShowDialog())
                return;
            string fullFileName = dlg.FileName;

            // Because user may change filter, check that finally selected file matches wildcard
            var dir = Path.GetDirectoryName(fullFileName);
            if (!Directory.EnumerateFiles(dir, filter).Any(x => x.Equals(fullFileName, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Файл не відповідає типу звіту", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // MAKE SURE REPORTING PERIOD FOR THE REPORT EXISTS BASED ON REPORT FILE
            var ddexReportingPeriodId = DdexReport.CreateReportingPeriod(agreementReportType, fullFileName);

            // CHECK THAT THE REPORT IS NOT REGISTERED YET
            if (DdexReport.CheckSingleFileReportExists(agreementReportType, ddexReportingPeriodId))
            {
                MessageBox.Show("Вибраний файл вже зарейєстрований в системі", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // CONFIRM PARAMETERS FOR REPORT REGISTRATION
            if (!ConfirmParametersForReportRegistration(licId, custId, fullFileName))
            {
                return;
            }

            // CREATE REGISTRATION RECORDS IN THE DATABASE
            try
            {
                DdexReport.RegisterMetaReport(licId, custId, agreementReportType, fullFileName);
                FillReports();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool ConfirmParametersForReportRegistration(int licId, int custId, string fullFileName)
        {
            var paramsText = DdexReport.GetAgreementParametersText(licId, custId, fullFileName);
            return MessageBox.Show("Договір буде зарейєстровано з наступною інформацією для виконаня обчислень.\r\n"
                + paramsText + "\r\nЗарейеструвати?", "Конфігурація договору",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private bool CheckExchangeRates(int licId, int custId, string agreementReportType, string fullFileName)
        {
            if (DdexReport.NeedsExhcnageRate(agreementReportType) && !DdexReport.CheckExchangeRateExists(licId, custId, agreementReportType, fullFileName))
            {
                MessageBox.Show("Не визначений курс обміну, необхідний для обробки звіту. "
                            + "Зайдіть на форму конфігурації договору і внесіть потрібне значення", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
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

                /*
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
                */

               return retVal;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }

        }

        private string DoDistSpotifyRoyalty(int ddexReportId, string fileFullName, string fileType)
        {
            try
            {
                string retVal = "";
                Helpers.RunSqlOperationDdexT(cmd =>
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);
                    cmd.CommandText = $@"spCreateAdjConsolidatedDetailForSpotify";
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

                    if ((int)cmd.Parameters["@RetCode"].Value == 1)
                    {
                        retVal = (string)cmd.Parameters["@result"].Value;
                    }
                }, true);

                return retVal;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }


        private bool DistGoogle(int ddexReportId, int ddexReportingPeriodId, bool loadInitialData)
        {
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
            string fileFullName = "";
            string fileName = "";

            if (loadInitialData)
            {
                OpenFileDialog dlg = new OpenFileDialog();
                //dlg.Filter = "Файли консолідованих звітів від клієнта (*.tsv)|*.tsv";
                dlg.Filter = $"Файли консолідованих звітів від клієнта (*.tsv)|{expectedFileStart}*.tsv";
                if (DialogResult.OK != dlg.ShowDialog())
                    return false;
                fileFullName = dlg.FileName;
                fileName = Path.GetFileNameWithoutExtension(dlg.FileName);
            
                if (!fileName.StartsWith(expectedFileStart, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Файл не відповідає типу звіту", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            

            FormRoyaltyDistribution formRoyaltyDistribution = new FormRoyaltyDistribution(ddexReportId, fileFullName);
            formRoyaltyDistribution.ShowDialog();
            return true;

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

        private bool DistSpotify(int ddexReportId, int ddexReportingPeriodId)
        {
            // Get data for file name validation from db
            string fileType = "";
            int year = 0;
            int month = 0;
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);
                cmd.Parameters.AddWithValue("@ddexReportingPeriodId", ddexReportingPeriodId);

                cmd.CommandText = "select FileType from DdexReport where id = @ddexReportId";
                fileType = (string)cmd.ExecuteScalar();

                cmd.CommandText = "select year from DdexReportingPeriod where id = @ddexReportingPeriodId";
                year = (int)cmd.ExecuteScalar();

                cmd.CommandText = "select month from DdexReportingPeriod where id = @ddexReportingPeriodId";
                month = (int)cmd.ExecuteScalar();
            });

            var confirmResult = MessageBox.Show(
                "Ви плануєте передати до розподілу замовлені роялті для звіту. Сперш переконайтесь, що заявлена сума оплачена. Продовжити?",
                "Розподіл роялті", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult != DialogResult.Yes)
                return false;

            var canDistribute = false;
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = @"select count(*)
                    from CcidInFile t1
                        join CcidInvoice t2 on t1.ccidInvoiceId = t2.Id
                    where t2.ddexReportId = @ddexReportId and t1.Status = 2";
                cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);
                var cnt = (int)cmd.ExecuteScalar();
                canDistribute = cnt > 0;
            });

            if(!canDistribute)
            {
                MessageBox.Show(
                    "Файл інвойсу не було надіслано, розподіл неможливий.",
                    "Розподіл роялті", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            FormRoyaltyDistribution formRoyaltyDistribution = new FormRoyaltyDistribution(ddexReportId, "");
            formRoyaltyDistribution.ShowDialog();
            return true;

            FormLongOperation form = new FormLongOperation("Виконується побудова даних для розподілу. Зачекайте, будь ласка.");
            Form parent = FindForm();
            form.Show(parent);
            var task = new Task<string>(() => { return DoDistSpotifyRoyalty(ddexReportId, "", fileType); });
            task.Start();
            task.Wait();
            form.Hide();

            if (!string.IsNullOrEmpty(task.Result))
            {
                MessageBox.Show(task.Result, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            MessageBox.Show("Дані для розподілу роялті побудовані і передані в БД MediaService", "Операція завершена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        private void radGridViewReports_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            var dr = ((DataRowView)e.Row.DataBoundItem).Row;
            int status = Convert.ToInt32(dr["status"]);

            if (e.Column.FieldName.Equals("Show", StringComparison.OrdinalIgnoreCase))
            {
                RadButtonElement btn = (e.CellElement as GridCommandCellElement).CommandButton;
                btn.Text = "Показати";
                btn.Enabled = !(status == Meta.DdexReportStatus.ARCHIVING
                    || status == Meta.DdexReportStatus.ARCHIVED
                    || status == Meta.DdexReportStatus.RESTORING
                    || status == Meta.DdexReportStatus.CLEANING);
                btn.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            }
            else if (e.Column.FieldName.Equals("AgreementParams", StringComparison.OrdinalIgnoreCase))
            {
                RadButtonElement btn = (e.CellElement as GridCommandCellElement).CommandButton;
                btn.Text = "Параметри договору";
                btn.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            }
            else if (e.Column.FieldName.Equals("Archive", StringComparison.OrdinalIgnoreCase))
            {
                RadButtonElement btn = (e.CellElement as GridCommandCellElement).CommandButton;
                btn.Visibility = Telerik.WinControls.ElementVisibility.Visible;
                if (status == Meta.DdexReportStatus.INVOICING)
                    btn.Text = "Розподілити";
                else if (status == Meta.DdexReportStatus.DISTRIBUTION_STARTED
                        || status == Meta.DdexReportStatus.DISTRIBUTION_DATA_LOADED
                        || status == Meta.DdexReportStatus.DISTRIBUTION_IN_PROGRESS)
                    btn.Text = "Продовжити розподіл";
               else if (status == Meta.DdexReportStatus.DISTIBUTION_COMPLETED)
                    btn.Text = "Повторити розподіл";
                else if (status == Meta.DdexReportStatus.DISTRIBUTION_APPROVED)
                    btn.Text = "До архіву";
                else if (status == Meta.DdexReportStatus.ARCHIVING)
                    btn.Text = "До архіву";
                else if (status == Meta.DdexReportStatus.ARCHIVED)
                    btn.Text = "Відновити з архіву";
                else if (status == Meta.DdexReportStatus.RESTORING)
                    btn.Text = "Відновити з архіву";
                else if (status == Meta.DdexReportStatus.RESTORED)
                    btn.Text = "Видалити відновлені записи";
                else if (status == Meta.DdexReportStatus.CLEANING)
                    btn.Text = "Видалити відновлені записи";
                else
                    btn.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            }

            else if (e.Column.FieldName.Equals("ButtonCol3", StringComparison.OrdinalIgnoreCase))
            {
                RadButtonElement btn = (e.CellElement as GridCommandCellElement).CommandButton;
                btn.Visibility = Telerik.WinControls.ElementVisibility.Visible;
                if (status == Meta.DdexReportStatus.DISTIBUTION_COMPLETED)
                    btn.Text = "Затвердити розподіл";
                else
                    btn.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            }

        }

        private void radGridViewReports_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            int ddexReportId = (int)e.Row.Cells["ddexReportId"].Value;
            int ddexReportingPeriodId = (int)e.Row.Cells["ddexReportingPeriodId"].Value;

            var agreementReportType = DdexReport.GetAgreementReportType(licId, custId);

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
                if (   status == Meta.DdexReportStatus.INVOICING
                    || status == Meta.DdexReportStatus.DISTRIBUTION_STARTED
                    || status == Meta.DdexReportStatus.DISTRIBUTION_DATA_LOADED
                    || status == Meta.DdexReportStatus.DISTRIBUTION_IN_PROGRESS
                    || status == Meta.DdexReportStatus.DISTIBUTION_COMPLETED
                )
                {
                    var res = false;
                    if (DdexReport.IsGooglePreClaimReport(agreementReportType))
                    {
                        res = DistGoogle(ddexReportId, ddexReportingPeriodId, 
                            status == Meta.DdexReportStatus.INVOICING || status == Meta.DdexReportStatus.DISTRIBUTION_STARTED);
                    }
                    else if (DdexReport.IsSpotifyReport(agreementReportType))
                    {
                        res = DistSpotify(ddexReportId, ddexReportingPeriodId);
                    }

                    if (res)
                    {
                        FillReports();
                    }
                    return;
                }
                else if (status == Meta.DdexReportStatus.DISTRIBUTION_APPROVED || status == Meta.DdexReportStatus.ARCHIVING)
                    mode = DdexReportArchiver.OperationMode.Archive;
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
            else if (e.Column.FieldName.Equals("ButtonCol3", StringComparison.OrdinalIgnoreCase))
            {
                if(DialogResult.Yes != MessageBox.Show(
                    "Дану дію рекомендовується виконути після оплати роялті на банківські рахунки правовласників.\r\n" +
                    "Виконати?", 
                    "Підтвердити дію", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question))
                {
                    return;
                }
                Helpers.RunSqlOperationDdex(cmd =>
                {
                    DdexReport.SetReportStatus(ddexReportId, Meta.DdexReportStatus.DISTRIBUTION_APPROVED);
                });
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
            if (e.CurrentRow == null || e.CurrentRow is GridViewGroupRowInfo)
            {
                licId = 0;
                custId = 0;
                licenseeName = null;
                licenseDescription = null;
            }
            else
            {
                var dr = ((DataRowView)e.CurrentRow.DataBoundItem).Row;
                licId = Convert.ToInt32(dr["licId"]);
                custId = Convert.ToInt32(dr["custId"]);
                licenseeName = (string)dr["licenseeName"];
                licenseDescription = (string)dr["licenseDescription"];
            }

            FillReports();
        }

    }
}
