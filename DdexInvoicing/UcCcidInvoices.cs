using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.Data;
using System.Data.SqlClient;
using InvoicingLib;
using System.IO;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using System.Configuration;

namespace DdexInvoicing
{
    public partial class UcCcidInvoices : UserControl
    {
        public enum CcidFileType
        {
            In, CorrectedIn, Cl
        }
        private static string[] CcidFileTypeText = { "Заявка", "Скорегована заявка", "Відповідь" };

        public int ddexReportId;
        private int setCode;

        public UcCcidInvoices()
        {
            InitializeComponent();
            GroupDescriptor descriptor = new GroupDescriptor();
            descriptor.GroupNames.Add("createdDate", ListSortDirection.Ascending);
            radGridInvoices.GroupDescriptors.Add(descriptor);
        }

        public void SetReport(int ddexReportId)
        {
            this.ddexReportId = ddexReportId;
            ShowExc();
            //ShowStatistics();
            ShowInvoices();
        }

        private void ShowExc()
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = "select isnull(setCode, 0) from ddexReport where id = @ddexReportId";
                cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);
                setCode = Convert.ToInt32(cmd.ExecuteScalar());
                if(setCode == 0)
                {
                    radTbExc.Text = "<не визначений>";
                }
                else
                {
                    cmd.CommandText = "select setName from ExceptionSet where setCode = @setCode";
                    cmd.Parameters.AddWithValue("@setCode", setCode);
                    radTbExc.Text = Convert.ToString(cmd.ExecuteScalar());
                }
            });
        }

        private void ShowInvoices()
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = $@"
                    ;with files as (
                       select case 
                                when InstanceIndex = 1 then 0 
                                else 1 
                              end tp
                            , fileId, ccidInvoiceId, InstanceIndex
                            , IsNull(Status, 0) fileStatus
                            , Name, TargetFolder 
                         from CcidInFile
                        union
                        select 2 tp, fileId, ccidInvoiceId, InstanceIndex
                            , Status fileStatus
                            , Name, TargetFolder 
                       from CcidClFile
                   )
                   select t1.id invoiceId
                        , t2.fileId fileId
                       , 'Номер '
                            + Right('000000' + convert(varchar, t1.id), 6)
                            + ' від ' + cast(cast(t1.createdDate as date) as varchar(100)) createdDate
                       , t1.status invoiceStatus
                       , t2.fileStatus fileStatus
                       , t2.name name
                       , t2.targetFolder folder
                       , t2.tp fileType
                   from CcidInvoice t1
                       join files t2 on t2.ccidInvoiceId = t1.id
                    where t1.ddexReportId = @ddexReportId
                    order by t1.createdDate desc, t2.InstanceIndex, t2.tp
                 ";
                cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                radGridInvoices.DataSource = dt;
            });
        }

        private void ShowStatistics()
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                var dt = new DataTable();
                dt.Columns.Add("CcidNetRevenueExcluded");
                dt.Columns.Add("CcidNetRevenueClaimed");
                dt.Columns.Add("CcidNetRevenueClaimPending");
                dt.Columns.Add("CcidNetRevenueReadyToClaim");
                dt.Columns.Add("CcidNetRevenuePaid");
                dt.Columns.Add("CcidNetRevenueRejected");

                cmd.CommandText = $@"
                    select isnull(CcidNetRevenueExcluded, 0), isnull(CcidNetRevenueClaimed, 0), isnull(CcidNetRevenueClaimPending, 0)
                            , isnull(CcidNetRevenueReadyToClaim, 0), isnull(CcidNetRevenuePaid, 0), isnull(CcidNetRevenueRejected, 0)
                    from DdexReport
                    where Id = @ddexReportId
                 ";
                cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);

                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    r.Read();

                    int i = 0;
                    dt.Rows.Add(r.GetDecimal(i++), r.GetDecimal(i++), r.GetDecimal(i++)
                        , r.GetDecimal(i++), r.GetDecimal(i++), r.GetDecimal(i++));
                }

            });
        }

        private void RefreshStatistics(bool calcMarketShare)
        {
            if(calcMarketShare)
                CalcMarketShare();
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = $@"
                    -- agreement parameters
                    declare @licId int, @custId int;
                    select @licId = licId, @custId = custId
                    from DdexReport 
                    where id = @ddexReportId;

                    declare @musicRate float = (select cast(paramValue as float) * 0.01 from AgreementParam where paramId = 1 and licId = @licId and custId = @custId);
                    declare @geRate float = (select cast(paramValue as float) * 0.01 from AgreementParam where paramId = 2 and licId = @licId and custId = @custId);
                    declare @mechSplit float = (select cast(paramValue as float) * 0.01 from AgreementParam where paramId = 3 and licId = @licId and custId = @custId);
                    declare @perfSplit float = (select cast(paramValue as float) * 0.01 from AgreementParam where paramId = 4 and licId = @licId and custId = @custId);

                    --select @musicRate, @geRate, @mechSplit, @perfSplit

                    if @musicRate is null or @geRate is null or @mechSplit is null or @perfSplit is null
                    begin
                        raiserror('Відсутня інформація із догоіору, необхідна для розрахунків', 0, 0);
                        return;
                    end

                    update DdexReport
                    set CcidNetRevenueReadyToClaim = (
                        select sum(
                                (cast(t1.rateTotalPER as float) * @perfSplit  + cast(t1.rateTotalMEC as float) * @mechSplit)
                                * 0.01 
                                * t1.netrevenue
                                * (case when t1.ContentCategory = 'Music' then @musicRate else @geRate end)
                            ) 
                        from IdentBacklog t1 
                            join IdentMw t2 on t1.mwId = t2.Id
                        where t1.DdexReportId = @ddexReportId 
                            and t2.Status = 2
                            and t1.IncludedInCcid is null
                        )
                    where Id = @ddexReportId

                    declare @CcidNetRevenueExcluded decimal(20, 6)
                        , @CcidNetRevenueClaimed decimal(20, 6)
                        , @CcidNetRevenueClaimPending decimal(20, 6)

                    select
                          @CcidNetRevenueExcluded = sum(case when t4.claim_unmatched_combined = 100 then t4.amount_invoiced_total else 0 end)
                        , @CcidNetRevenueClaimed = sum(case when t3.status >=2 and t4.claim_unmatched_combined = 0 then t4.amount_invoiced_total else 0 end)
                        , @CcidNetRevenueClaimPending = sum(case when t3.status < 2 then t4.amount_invoiced_total else 0 end)
                    from ddexReport t1
                        join CcidInvoice t2 on t2.ddexReportId = t1.id
                        join CcidInFile t3 on t3.ccidInvoiceId = t2.id
                        join CcidInDetail t4 on t4.fileId = t3.fileId
                    where t1.id = @ddexReportId and t3.InstanceIndex = 1

                    update DdexReport
                    set CcidNetRevenueExcluded = @CcidNetRevenueExcluded
                        , CcidNetRevenueClaimed = @CcidNetRevenueClaimed
                        , CcidNetRevenueClaimPending = @CcidNetRevenueClaimPending
                    where id = @ddexReportId
                 ";
                cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);
                cmd.ExecuteNonQuery();
            });
        }

        void UpdateInvoice(int fileId)
        {
            /*if (DialogResult.Yes == MessageBox.Show(
                    "Перерахувати проценти перед виставленням рахунку? Це значно збільшить час очікування і можна не робити, якщо перерахунок вже було виконано під час оновлення статистики,"
                    , "Виставлення рахунку", MessageBoxButtons.YesNo, MessageBoxIcon.Question))*/
            CalcMarketShare();

            Helpers.RunSqlOperationDdex(cmd =>
            {
                int status = -1;

                cmd.CommandText = $@"
                    select isnull(status, 0)
                    from CcidInFile
                    where fileId = @fileId
                 ";
                cmd.Parameters.AddWithValue("@fileId", fileId);
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    r.Read();
                    status = r.GetInt32(0);
                }
                if (status == 2)
                {
                }
                else if (status == 1)
                {
                    var result = MessageBox.Show("Поточний рахунок-фактура вже підготований для відправки клієнту. " +
                                    "Якщо файл рахунку ще надісланий клієнту, є можливість оновити рахунок новими даними. " +
                                    "Оновити?"
                                    , "Обробка рахунків CCID", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                        return;
                }

                switch (DdexReport.GetAgreementReportType(cmd, ddexReportId))
                {
                    case DdexReport.ReportTypeEnum.YOUTUBE_ADSUPPORT_MUSIC:
                        cmd.CommandText = "spCreateInitialInvoice";
                        break;
                    case DdexReport.ReportTypeEnum.YOUTUBE_SUBSCRIPTION_MUSIC:
                    case DdexReport.ReportTypeEnum.YOUTUBE_SUBSCRIPTION_PREMIUM:
                        cmd.CommandText = "spCreateInitialInvoiceSubscr";
                        break;
                    case DdexReport.ReportTypeEnum.YOUTUBE_SRMF:
                        cmd.CommandText = "spCreateInitialInvoiceSrmf";
                        break;
                    case DdexReport.ReportTypeEnum.SPOTIFY_FREE:
                    case DdexReport.ReportTypeEnum.SPOTIFY_FREE_PREMIUM:
                    case DdexReport.ReportTypeEnum.SPOTIFY_PREMIUM:
                    case DdexReport.ReportTypeEnum.SPOTIFY_FAMILYPLAN6:
                        cmd.CommandText = "spCreateInitialInvoiceSpotify";
                        break;
                }

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);
                cmd.Parameters.AddWithValue("@fileId", fileId);
                cmd.ExecuteNonQuery();
            });
        }

        private void SaveInvoice(int fileId)
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

            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = $@"select *
                    from  CcidInHeader
                    where fileId = @fileId
                ";
                cmd.Parameters.AddWithValue("@fileId", fileId);
                var ccidHeaderRecord = new CcidHeaderRecord();
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    r.Read();
                    ccidHeaderRecord.InitFromDataReader(r);
                }
                string fileName = ccidHeaderRecord.BuildFileName();

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filesPath + fileName))
                {
                    ccidHeaderRecord.WriteToFile(file);

                    cmd.CommandText = $@"select *
                        from  CcidInDetail
                        where fileId = @fileId
                    ";

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            var ccidDetailRecord = new CcidDetailRecord();
                            ccidDetailRecord.ReadFromDb(r);
                            ccidDetailRecord.WriteToFile(file);
                        }
                    }

                    cmd.CommandText = $@"select *
                        from  CcidInTrailer
                        where fileId = @fileId
                    ";
                    var ccidTrailerRecord = new CcidTrailerRecord();
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        r.Read();
                        ccidTrailerRecord.ReadFromDataReader(r);
                        ccidTrailerRecord.WriteToFile(file);
                    }
                }

                cmd.CommandText = $@"--update CcidInvoice set status = 1  where id = @invoiceId
                        update CcidInFile set status = 1, Name = @name, TargetFolder = @targetFolder where fileId = @fileId
                 ";
                cmd.Parameters.AddWithValue("@name", fileName);
                cmd.Parameters.AddWithValue("@targetFolder", filesPath);
                cmd.ExecuteNonQuery();
            });
            ShowInvoices();
        }

        private void CalcMarketShare()
        {
            if (setCode == 0)
                return;
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);
                cmd.CommandText = "dbo.pTsk10_DdexIdentMWAuthor";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "dbo.pTsk10_DdexExceptionStatus";
                cmd.Parameters.AddWithValue("@setId", setCode);
                cmd.ExecuteNonQuery();

                cmd.CommandText = "dbo.pTsk10_DDEXFormRate";
                cmd.Parameters.RemoveAt(1);
                cmd.ExecuteNonQuery();
            });
        }

        private void ConfirmFileSent(int fileId)
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = $@"
                    update CcidInFile set Status = 2 where fileId = @fileId
                 ";
                cmd.Parameters.AddWithValue("@fileId", fileId);

                cmd.ExecuteNonQuery();
            });
            ShowInvoices();
        }

        /*
        private void GetReply(int fileId)
        {
            string fileName;
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Файли відповіді клієнта (*.dat)|*.dat";
            if (DialogResult.OK != dlg.ShowDialog())
                return;
            fileName = dlg.FileName;

            Helpers.RunSqlOperationDdex(cmd =>
            {
                string ccidIdCorrectionReference;
                FileStream fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);
                using (var sr = new StreamReader(fs, Encoding.UTF8))
                {
                    if (sr.EndOfStream)
                    {
                        MessageBox.Show($"Невірний формат файлу", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    string line = sr.ReadLine();
                    string[] fields = line.Split('\t');
                    if (fields.Length != 21)
                    {
                        MessageBox.Show($"Невірний формат файлу", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    ccidIdCorrectionReference = fields[13];
                    if (!ccidIdCorrectionReference.Equals(fileId.ToString()))
                    {
                        MessageBox.Show($"Вибраний файл не відповідає надісланому файлу. Виберіть інший файл."
                            , "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                cmd.CommandText = @"select ccid_id_correction_reference 
                        from CcidClHeader 
                        where ccid_id_correction_reference = @ccidIdCorrectionReference";
                cmd.Parameters.AddWithValue("@ccidIdCorrectionReference", ccidIdCorrectionReference);
                if(cmd.ExecuteScalar() == DBNull.Value)
                {
                    MessageBox.Show($"Вибраний файл відповіді вже завантажено в базу даних"
                            , "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                cmd.CommandText = @"select InstanceIndex from CcidInFile where fileId = @fileId";
                cmd.Parameters.AddWithValue("@fileId", fileId);
                int instanceIndex = Convert.ToInt32(cmd.ExecuteScalar());

                cmd.CommandText = @"
                        declare @invoiceId int = (select ccidInvoiceId from CcidInFile where fileId = @fileId);
                        insert into CcidClFile(ccidInvoiceId, InstanceIndex, [status], [Name], TargetFolder)
                        values(@invoiceId, @InstanceIndex, 0, @name, @TargetFolder);
                        select scope_identity();";
                cmd.Parameters.AddWithValue("@instanceIndex", instanceIndex);
                cmd.Parameters.AddWithValue("@name", Path.GetFileName(dlg.FileName));
                cmd.Parameters.AddWithValue("@TargetFolder", Path.GetDirectoryName(dlg.FileName));
                int ccidClFileId = Convert.ToInt32(cmd.ExecuteScalar());
                using (System.IO.StreamReader file = new System.IO.StreamReader(dlg.FileName))
                {
                    string line;
                    BulkUploadToSql bulkUploader = new BulkUploadToSql();
                    bulkUploader.TableName = "CcidClDetail";
                    bulkUploader.conn = cmd.Connection;

                    int lineCount = 0;
                    while ((line = file.ReadLine()) != null)
                    {
                        lineCount++;
                        string[] fields = line.Split('\t');
                        if (fields[0].Equals("HD", StringComparison.OrdinalIgnoreCase))
                        {
                            CcidHeaderRecord record = new CcidHeaderRecord();
                            record.UploadLine(cmd.Connection, ccidClFileId, fields);
                        }
                        else if (fields[0].Equals("ID", StringComparison.OrdinalIgnoreCase))
                        {
                            CcidDetailRecord record = new CcidDetailRecord();
                            record.UploadLine(bulkUploader, ccidClFileId, fields);
                        }
                        else if (fields[0].Equals("TR", StringComparison.OrdinalIgnoreCase))
                        {
                            CcidTrailerRecord record = new CcidTrailerRecord();
                            record.UploadLine(cmd.Connection, ccidClFileId, fields);
                        }
                    }
                    bulkUploader.Flush();
                }

                cmd.CommandText = $@"
                    update CcidInFile set Status = 3 where fileId = @fileId
                ";
                cmd.ExecuteNonQuery();
            });
            ShowInvoices();
        }
        */

        private string GetYouTubeAddSupportReplyFileName(int fileId)
        {
            string fileName;
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Файли відповіді клієнта (*.tsv)|*.tsv";
            if (DialogResult.OK != dlg.ShowDialog())
                return "";
            fileName = dlg.FileName;
            //return fileName;

            Helpers.RunSqlOperationDdex(cmd =>
            {
                int reportedQuarter = 0;
                FileStream fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);
                using (var sr = new StreamReader(fs, Encoding.UTF8))
                {
                    if (sr.EndOfStream)
                    {
                        MessageBox.Show($"Невірний формат файлу", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        fileName = "";
                        return;
                    }
                    string line = sr.ReadLine();
                    string[] fields = line.Split('\t');
                    if (fields.Length != 16 || !fields[0].Equals("HEAD", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show($"Невірний формат файлу", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        fileName = "";
                        return;
                    }
                    reportedQuarter = int.Parse(fields[8].Split('-')[1]) / 3 + 1;
                }

                cmd.CommandText = @"select t3.id
                    from CcidInFile t1
                        inner join  CcidInvoice t2 on t2.Id = t1.ccidInvoiceId
                        inner join DdexReport t3 on t3.id = t2.ddexReportId
                   where t1.fileId = @fileId";
                cmd.Parameters.AddWithValue("@fileId", fileId);
                int ddexReportId = Convert.ToInt32(cmd.ExecuteScalar());

                cmd.CommandText = @"select t4.quarter
                    from DdexReport t3
                        inner join DdexReportingPeriod t4 on t4.Id = t3.ddexReportingPeriodId
                    where t3.id = @ddexReportId";
                cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);
                int quater = Convert.ToInt32(cmd.ExecuteScalar());

                if (reportedQuarter != quater)
                {
                    MessageBox.Show($"Файл не відповідає надісланому файлу", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    fileName = "";
                    return;
                }
            });
            return fileName;
        }

        private string ReadYouTubeAddSupportReply(int fileId, string fileName)
        {
            /*
            DdexReport ddexReport = new DdexReport(ConfigurationManager.AppSettings["ConnectionStringDdex"], ddexReportId);
            var action = new DdexReportActionLoadAdjustmentData(fileId);
            ddexReport.ProcessAdjustment(action, fileName);
            */
            return "";
        }

        private string GetYouTubeSubscriptionReplyFileName(int fileId)
        {
            string fileName;
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Файли відповіді клієнта (*.tsv)|*.tsv";
            if (DialogResult.OK != dlg.ShowDialog())
                return "";
            fileName = dlg.FileName;

            Helpers.RunSqlOperationDdex(cmd =>
            {
                FileStream fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);
                using (var sr = new StreamReader(fs, Encoding.UTF8))
                {
                    if (sr.EndOfStream)
                    {
                        MessageBox.Show($"Невірний формат файлу", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        fileName = "";
                        return;
                    }
                    string line = sr.ReadLine();
                    string[] fields = line.Split('\t');
                    if (fields.Length != 10 || !fields[0].Equals("HEAD", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show($"Невірний формат файлу", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        fileName = "";
                        return;
                    }
                    int respFileId = int.Parse(fields[4]);
                    if (respFileId != fileId)
                    {
                        MessageBox.Show($"Файл не відповідає надісланому файлу", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        fileName = "";
                        return;
                    }
                }
            });
            return fileName;
        }

        /*

        private void ReadYouTubeSubscriptionReply(int fileId, string fileName)
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = "delete from CrfDetail where fileId = @fileId";
                cmd.Parameters.AddWithValue("@fileId", fileId);
                cmd.ExecuteNonQuery();

                using (System.IO.StreamReader file = new System.IO.StreamReader(fileName))
                {
                    string line;
                    BulkUploadToSql bulkUploader = new BulkUploadToSql();
                    bulkUploader.TableName = "CrfDetail";
                    bulkUploader.conn = cmd.Connection;

                    file.ReadLine(); // skip head
                    while ((line = file.ReadLine()) != null)
                    {
                        string[] fields = line.Split('\t');
                        if (fields[0].Equals("FOOT", StringComparison.OrdinalIgnoreCase))
                        {
                            break;
                        }
                        List<object> data = new List<object>();
                        data.Add(fileId);
                        data.Add(fields[2]);
                        data.Add(Meta.CrfDetailStatus.Value(fields[4])); // Mech
                        data.Add(Meta.CrfDetailStatus.Value(fields[3])); // Perf (different order in Db and Crf)
                        bulkUploader.AddData(data);
                    }
                    bulkUploader.Flush();
                }
            }, true);
        }

        */

        private string GetReplyFileName(int fileId, string reportType)
        {
            string fileName = "";
            if (reportType.Equals("AdSupport-Music", StringComparison.OrdinalIgnoreCase))
            {
                fileName = GetYouTubeAddSupportReplyFileName(fileId);
            }
            else if (reportType.Equals("Subscription-Music", StringComparison.OrdinalIgnoreCase))
            {
                fileName = GetYouTubeSubscriptionReplyFileName(fileId);
            }
            else if (reportType.Equals("Subscription-Premium", StringComparison.OrdinalIgnoreCase))
            {
                fileName = GetYouTubeSubscriptionReplyFileName(fileId);
            }
            return fileName;
        }

        private void CreateCorrectedInvoice(int fileId)
        {
            MessageBox.Show("Не реалізовано", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        private void ToDistribution(int fileId)
        {
            if (MessageBox.Show("Дану дїю слід виконувати після отримання коштів згідно рахунку на баланс товариства. Виконати?", "Підтвердіть дію", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = "[dbo].[pTsk10_ExportCcidCLFile]";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CcIdCLfileId", fileId);

                cmd.Parameters.Add("@result", SqlDbType.VarChar);
                cmd.Parameters["@result"].Direction = ParameterDirection.Output;
                cmd.Parameters["@result"].Size = 2000;

                cmd.Parameters.Add("@RetCode", SqlDbType.Int);
                cmd.Parameters["@RetCode"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                int code = Convert.ToInt32(cmd.Parameters["@RetCode"].Value);
                string message = Convert.ToString(cmd.Parameters["@result"].Value);

                cmd.CommandText = "update CcidClFile set status = @status where fileId = @ccidClFileId";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@status", Meta.CcidClFileStatus.Distributed);
                cmd.Parameters.AddWithValue("@ccidClFileId", fileId);
                cmd.ExecuteNonQuery();

                MessageBox.Show($"Кошти згідно рахунку передані до розподілу, результат виконання {code} - {message}"
                    , "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
            ShowInvoices();
        }

        private void radBtnRefreshStatistics_Click(object sender, EventArgs e)
        {
            if(DialogResult.Yes == MessageBox.Show(
                    "Оновити попередньо проценти для отримання більш точної інформації? Ще значно збільшить час очікування відповіді."
                    , "Оновлення статистики", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                RefreshStatistics(true);
            else
                RefreshStatistics(false);

            ShowStatistics();
        }

        private void radGridInvoices_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            /*
            if (e.RowIndex == -1)
                return;
            DataTable dt = radGridInvoices.DataSource as DataTable;
            int fileId = (int)dt.Rows[e.RowIndex].ItemArray[1];
            if (e.ColumnIndex == 5)
            {
                FormInvoiceDetails form = new FormInvoiceDetails();
                form.fileId = fileId;
                form.Show();
                return;
            }
            else if (e.ColumnIndex == 6)
            {
                UpdateInvoice(fileId);
                return;
            }
            else if (e.ColumnIndex == 7)
            {
                SaveInvoice();
            }
            else if (e.ColumnIndex == 8)
            {
                ConfirmFileSent(fileId);
            }
            else if (e.ColumnIndex == 9)
            {
                GetReply(fileId);
            }
            */
        }

        private void radBtnNewInvoice_Click(object sender, EventArgs e)
        {
            if(setCode == 0)
            {
                MessageBox.Show("Не визначені обмеження на виставлення рахунку", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            /*
            FormCreateInvoice form = new FormCreateInvoice();
            form.ddexReportId = ddexReportId;
            if (form.ShowDialog() != DialogResult.OK)
                return;
                */

            /*if (DialogResult.Yes == MessageBox.Show(
                    "Перерахувати проценти перед виставленням рахунку? Це значно збільшить час очікування і можна не робити, якщо перерахунок вже було виконано під час оновлення статистики,"
                    , "Виставлення рахунку", MessageBoxButtons.YesNo, MessageBoxIcon.Question))*/


            CalcMarketShare();

            Helpers.RunSqlOperationDdexT(cmd =>
            {
                switch(DdexReport.GetAgreementReportType(cmd, ddexReportId))
                {
                    case DdexReport.ReportTypeEnum.YOUTUBE_ADSUPPORT_MUSIC:
                        cmd.CommandText = "spCreateInitialInvoice";
                        break;
                    case DdexReport.ReportTypeEnum.YOUTUBE_SUBSCRIPTION_MUSIC:
                    case DdexReport.ReportTypeEnum.YOUTUBE_SUBSCRIPTION_PREMIUM:
                        cmd.CommandText = "spCreateInitialInvoiceSubscr";
                        break;
                    case DdexReport.ReportTypeEnum.YOUTUBE_SRMF:
                        cmd.CommandText = "spCreateInitialInvoiceSrmf";
                        break;
                    case DdexReport.ReportTypeEnum.SPOTIFY_FREE:
                    case DdexReport.ReportTypeEnum.SPOTIFY_FREE_PREMIUM:
                    case DdexReport.ReportTypeEnum.SPOTIFY_PREMIUM:
                    case DdexReport.ReportTypeEnum.SPOTIFY_FAMILYPLAN6:
                        cmd.CommandText = "spCreateInitialInvoiceSpotify";
                        break;
                }

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@fileId", DBNull.Value);
                cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);
                cmd.ExecuteNonQuery();
            });
            ShowInvoices();
        }

        private void radGridInvoices_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            int fileId = (int)e.Row.Cells["fileId"].Value;
            int fileType = (int)e.Row.Cells["fileType"].Value;
            if (fileType == 0 || fileType == 1)
            {
                if (e.Column.FieldName.Equals("ShowDetails", StringComparison.OrdinalIgnoreCase))
                {
                    FormInvoiceDetails form = new FormInvoiceDetails();
                    form.Text = FindForm().Text;
                    form.fileId = fileId;
                    form.fileType = 0;
                    form.Show();
                }
                else if (e.Column.FieldName.Equals("Update", StringComparison.OrdinalIgnoreCase))
                {
                    UpdateInvoice(fileId);
                }
                else if (e.Column.FieldName.Equals("Save", StringComparison.OrdinalIgnoreCase))
                {
                    SaveInvoice(fileId);
                }
                else if (e.Column.FieldName.Equals("Send", StringComparison.OrdinalIgnoreCase))
                {
                    ConfirmFileSent(fileId);
                }
                else if (e.Column.FieldName.Equals("GetReply", StringComparison.OrdinalIgnoreCase))
                {
                    //GetReply(fileId);
                }
            }
            else
            {
                if (e.Column.FieldName.Equals("ShowDetails", StringComparison.OrdinalIgnoreCase))
                {
                    FormInvoiceDetails form = new FormInvoiceDetails();
                    form.fileId = fileId;
                    form.fileType = 1;
                    form.Show();
                }
                else if (e.Column.FieldName.Equals("Update", StringComparison.OrdinalIgnoreCase))
                {
                    CreateCorrectedInvoice(fileId);
                }
                else if (e.Column.FieldName.Equals("Save", StringComparison.OrdinalIgnoreCase))
                {
                    ToDistribution(fileId);
                }
            }
        }

        private void radGridInvoices_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            int fileType = (int)e.Row.Cells["fileType"].Value;
            int fileStatus = (int)e.Row.Cells["fileStatus"].Value;

            if (e.Column.FieldName.Equals("fileStatus", StringComparison.OrdinalIgnoreCase))
            {
                if (fileType == (int)CcidFileType.In || fileType == (int)CcidFileType.CorrectedIn)
                    e.CellElement.Text = Meta.CcidInFileStatus.Name((int)e.CellElement.Value);
                else
                    e.CellElement.Text = Meta.CcidClFileStatus.Name((int)e.CellElement.Value);
                return;
            }

            if (e.Column.FieldName.Equals("fileType", StringComparison.OrdinalIgnoreCase))
            {
                e.CellElement.Text = CcidFileTypeText[(int)e.CellElement.Value];
                return;
            }

            if(fileType == (int)CcidFileType.In || fileType == (int)CcidFileType.CorrectedIn)
            {
                if (e.Column.FieldName.Equals("ShowDetails", StringComparison.OrdinalIgnoreCase))
                {
                    (e.CellElement as GridCommandCellElement).CommandButton.Text = "Показати";
                }
                else if (e.Column.FieldName.Equals("Update", StringComparison.OrdinalIgnoreCase))
                {
                    (e.CellElement as GridCommandCellElement).CommandButton.Text = "Оновити";
                    e.CellElement.Enabled = fileStatus < Meta.CcidInFileStatus.ReadyToSend && fileType != (int)CcidFileType.CorrectedIn;
                }
                else if (e.Column.FieldName.Equals("Save", StringComparison.OrdinalIgnoreCase))
                {
                    (e.CellElement as GridCommandCellElement).CommandButton.Text = "До файлу";
                    e.CellElement.Enabled = fileStatus == Meta.CcidInFileStatus.Created;
                }
                else if (e.Column.FieldName.Equals("Send", StringComparison.OrdinalIgnoreCase))
                {
                    (e.CellElement as GridCommandCellElement).CommandButton.Text = "Надіслати";
                    e.CellElement.Enabled = fileStatus == Meta.CcidInFileStatus.ReadyToSend;
                }
                else if (e.Column.FieldName.Equals("GetReply", StringComparison.OrdinalIgnoreCase))
                {
                    (e.CellElement as GridCommandCellElement).CommandButton.Text = "Отримати відповідь";
                    e.CellElement.Enabled = fileStatus == Meta.CcidInFileStatus.Sent;
                }
            }
            else
            {
                if (e.Column.FieldName.Equals("ShowDetails", StringComparison.OrdinalIgnoreCase))
                {
                    (e.CellElement as GridCommandCellElement).CommandButton.Text = "Показати";
                }
                else if (e.Column.FieldName.Equals("Update", StringComparison.OrdinalIgnoreCase))
                {
                    (e.CellElement as GridCommandCellElement).CommandButton.Text = "Обробити";
                    e.CellElement.Enabled = fileStatus == Meta.CcidClFileStatus.Created;
                }
                else if (e.Column.FieldName.Equals("Save", StringComparison.OrdinalIgnoreCase))
                {
                    (e.CellElement as GridCommandCellElement).CommandButton.Text = "До розподілу";
                    e.CellElement.Enabled = fileStatus == Meta.CcidClFileStatus.Created;
                }
                else if (e.Column.FieldName.Equals("Send", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellElement.Visibility = ElementVisibility.Hidden;
                }
                else if (e.Column.FieldName.Equals("GetReply", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellElement.Visibility = ElementVisibility.Hidden;
                }
            }
            //e.CellElement.Text = "qqqq";
            //e.CellElement.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
        }

        private void radBtnExc_Click(object sender, EventArgs e)
        {
            FormExceptionSets form = new FormExceptionSets();
            if(form.ShowDialog() == DialogResult.Cancel)
                return;
            setCode = form.setCode;
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = @"update DdexReport set setCode = @setCode where id = @ddexReportId;
                    update ExceptionSet set isUsed = 1";
                cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);
                cmd.Parameters.AddWithValue("@setCode", setCode);
                cmd.ExecuteNonQuery();
             });
            ShowExc();
        }

        private void radBtnCalculate_Click(object sender, EventArgs e)
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = @"
                    declare @licId int, @custId int;
                    select @licId = licId, @custId = custId
                    from DdexReport 
                    where id = @ddexReportId;

                    declare @musicRate float = (select cast(paramValue as float) * 0.01 from AgreementParam where paramId = 1 and licId = @licId and custId = @custId);
                    declare @geRate float = (select cast(paramValue as float) * 0.01 from AgreementParam where paramId = 2 and licId = @licId and custId = @custId);
                    declare @mechSplit float = (select cast(paramValue as float) * 0.01 from AgreementParam where paramId = 3 and licId = @licId and custId = @custId);
                    declare @perfSplit float = (select cast(paramValue as float) * 0.01 from AgreementParam where paramId = 4 and licId = @licId and custId = @custId);

                    --select @musicRate, @geRate, @mechSplit, @perfSplit

                    if @musicRate is null or @geRate is null or @mechSplit is null or @perfSplit is null
                    begin
                        raiserror('Відсутня інформація із договору, необхідна для розрахунків', 0, 0);
                        return;
                    end

                    drop table if exists #AdjustedNetRevenue
                    drop table if exists #AdjustedNetRevenueMw

                    select 
                        t1.netrevenue * (case when t1.ContentCategory = 'Music' then @musicRate else @geRate end) as netRevenue,
                        t2.Status stt
                    into #AdjustedNetRevenue
                    from IdentBacklog t1 
                        join IdentMw t2 on t1.mwId = t2.Id
                    where t1.DdexReportId = @ddexReportId 
                        and isnull(t1.IncludedInCcid, 0) = 0

                    declare 
                          @cntTotal int
                        , @cntClaimedNonZero int
                        , @cntClaimedZero int
                        , @cntNonClaimed int
                        , @cntUnprocessed int
                        , @amountTotal decimal(20, 6)
                        , @amountClaimedNonZero decimal(20, 6)
                        , @amountClaimedZero decimal(20, 6)
                        , @amountNonClaimed decimal(20, 6)
                        , @amountUnprocessed decimal(20, 6)
                        , @cntTotal1 int
                        , @cntClaimedNonZero1 int
                        , @cntClaimedZero1 int
                        , @cntNonClaimed1 int
                        , @cntUnprocessed1 int
                        , @amountTotal1 decimal(20, 6)
                        , @amountClaimedNonZero1 decimal(20, 6)
                        , @amountClaimedZero1 decimal(20, 6)
                        , @amountNonClaimed1 decimal(20, 6)
                        , @amountUnprocessed1 decimal(20, 6)

                    -- Pending Sales transactions
                    select 
                          @cntTotal = sum(1) 
                        , @cntClaimedNonZero = sum(case when stt = 2  and netRevenue > 0 then 1 else 0 end) 
                        , @cntClaimedZero = sum(case when stt = 2 and netRevenue <= 0 then 1 else 0 end) 
                        , @cntNonClaimed = sum(case when stt = 1 then 1 else 0 end) 
                        , @cntUnprocessed = sum(case when stt not in (1, 2) then 1 else 0 end) 
                        , @amountTotal = sum(netRevenue) 
                        , @amountClaimedNonZero = sum(case when stt = 2  and netRevenue > 0 then netRevenue else 0 end) 
                        , @amountClaimedZero = sum(case when stt = 2 and netRevenue <= 0 then netRevenue else 0 end) 
                        , @amountNonClaimed = sum(case when stt = 1 then netRevenue else 0 end) 
                        , @amountUnprocessed = sum(case when stt not in (1, 2) then netRevenue else 0 end) 
                    from #AdjustedNetRevenue


                    -- Pending Music Works
                    select 
                        sum(t1.netrevenue * (case when t1.ContentCategory = 'Music' then @musicRate else @geRate end)) as netRevenue,
                        t2.Status stt
                    into #AdjustedNetRevenueMw
                    from IdentBacklog t1 
                        join IdentMw t2 on t1.mwId = t2.Id
                    where t1.DdexReportId = @ddexReportId 
                        and isnull(t1.IncludedInCcid, 0) = 0
                    group by t2.Id, t2.Status
                    select 
                          @cntTotal1 = sum(1) 
                        , @cntClaimedNonZero1 = sum(case when stt = 2  and netRevenue > 0 then 1 else 0 end) 
                        , @cntClaimedZero1 = sum(case when stt = 2 and netRevenue <= 0 then 1 else 0 end) 
                        , @cntNonClaimed1 = sum(case when stt = 1 then 1 else 0 end) 
                        , @cntUnprocessed1 = sum(case when stt not in (1, 2) then 1 else 0 end) 
                        , @amountTotal1 = sum(netRevenue) 
                        , @amountClaimedNonZero1 = sum(case when stt = 2  and netRevenue > 0 then netRevenue else 0 end) 
                        , @amountClaimedZero1 = sum(case when stt = 2 and netRevenue <= 0 then netRevenue else 0 end) 
                        , @amountNonClaimed1 = sum(case when stt = 1 then netRevenue else 0 end) 
                        , @amountUnprocessed1 = sum(case when stt not in (1, 2) then netRevenue else 0 end) 
                    from #AdjustedNetRevenueMw

                    drop table if exists #AdjustedNetRevenue
                    drop table if exists #AdjustedNetRevenueMw

                    select 
                          @cntTotal
                        , @cntClaimedNonZero
                        , @cntClaimedZero
                        , @cntNonClaimed
                        , @cntUnprocessed
                        , @amountTotal
                        , @amountClaimedNonZero
                        , @amountClaimedZero 
                        , @amountNonClaimed
                        , @amountUnprocessed
                        , @cntTotal1
                        , @cntClaimedNonZero1
                        , @cntClaimedZero1
                        , @cntNonClaimed1
                        , @cntUnprocessed1
                        , @amountTotal1
                        , @amountClaimedNonZero1
                        , @amountClaimedZero1
                        , @amountNonClaimed1
                        , @amountUnprocessed1
                    ";
                cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    r.Read();
                    int i = 0;
                    cntTotal.Text = r.GetInt32(i++).ToString();
                    cntClaimedNonZero.Text = r.GetInt32(i++).ToString();
                    cntClaimedZero.Text = r.GetInt32(i++).ToString();
                    cntNonClaimed.Text = r.GetInt32(i++).ToString();
                    cntUnprocessed.Text = r.GetInt32(i++).ToString();

                    amountTotal.Text = r.GetDecimal(i++).ToString();
                    amountClaimedNonZero.Text = r.GetDecimal(i++).ToString();
                    amountClaimedZero.Text = r.GetDecimal(i++).ToString();
                    amountNonClaimed.Text = r.GetDecimal(i++).ToString();
                    amountUnprocessed.Text = r.GetDecimal(i++).ToString();

                    cntTotal1.Text = r.GetInt32(i++).ToString();
                    cntClaimedNonZero1.Text = r.GetInt32(i++).ToString();
                    cntClaimedZero1.Text = r.GetInt32(i++).ToString();
                    cntNonClaimed1.Text = r.GetInt32(i++).ToString();
                    cntUnprocessed1.Text = r.GetInt32(i++).ToString();

                    amountTotal1.Text = r.GetDecimal(i++).ToString();
                    amountClaimedNonZero1.Text = r.GetDecimal(i++).ToString();
                    amountClaimedZero1.Text = r.GetDecimal(i++).ToString();
                    amountNonClaimed1.Text = r.GetDecimal(i++).ToString();
                    amountUnprocessed1.Text = r.GetDecimal(i++).ToString();
                }
            });
        }
    }
}
