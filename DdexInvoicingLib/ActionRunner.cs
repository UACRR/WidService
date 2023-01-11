using InvoicingLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoicingLib
{
    public class ActionRunner
    {
        protected string ConnectionString { get; set; }
        protected int DdexReportingPeriodId { get; set; }
        protected int DdexReportId{ get; set; }

        public void Init(string connectionString, int ddexReportingPeriodId, int ddexReportId)
        {
            ConnectionString = connectionString;
            DdexReportingPeriodId = ddexReportingPeriodId;
            DdexReportId = ddexReportId;
        }

        public virtual bool PreRun() { return true; }
        public virtual void Run() { }
    }

    public class DetectErrorsRunner : ActionRunner
    {
        public override void Run()
        {
            if(DdexReport.FileMayHaveErrors(DdexReportId))
            {
                new DdexReport(ConnectionString, DdexReportId)
                    .ProcessFiles(new DdexReportActionRegisterErrorsYouTube());
            }
            else
            {
                new DdexReport(ConnectionString, DdexReportId)
                    .ProcessFiles(new DdexReportActionRegisterErrorsSkip());
            }
        }
    }
    public class LoadIntoDbRunner : ActionRunner
    {
        public override void Run()
        {
            if(DdexReport.IsSrmf(DdexReportId))
            {
                new DdexReport(ConnectionString, DdexReportId)
                    .ProcessFiles(new DdexReportActionLoadIdentDataSrmf());
            }
            else
            {
                switch (DdexReport.GetDigitalServiceProvider(DdexReportId))
                {
                    case DdexReport.DigitalServiceProviderEnum.YOUTUBE:
                        new DdexReport(ConnectionString, DdexReportId)
                            .ProcessFiles(new DdexReportActionLoadIdentDataYouTube());
                        break;
                    case DdexReport.DigitalServiceProviderEnum.SPOTIFY:
                        new DdexReport(ConnectionString, DdexReportId)
                            .ProcessFiles(new DdexReportActionLoadIdentDataSpotify());
                        break;
                    case DdexReport.DigitalServiceProviderEnum.DEEZER:
                        // For multifile reports DdexReportId corresppnds to the first file of group
                        // Need to iterate over all reports starting from the report that is not loaded completely
                        // Process the base file last as its status is used as the status of all group
                        var ddexReportIds = DdexReport.GetAgreementNotLoadedReportIds(DdexReportId);
                        ddexReportIds.Where(x => x != DdexReportId).ToList().ForEach(x =>
                        {
                            new DdexReport(ConnectionString, x)
                                .ProcessFiles(new DdexReportActionLoadIdentDataDeezer());
                            Helpers.RunSqlOperationDdex(cmd =>
                            {
                                cmd.CommandText = $@"
                                    update DdexReport
                                    set Status = @status 
                                    where id = @ddexReportId";
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@ddexReportId", x);
                                cmd.Parameters.AddWithValue("@status", Meta.DdexReportStatus.MERGE_MUSIC_WORKS);
                                cmd.ExecuteNonQuery();
                            });
                        });
                        new DdexReport(ConnectionString, DdexReportId)
                                .ProcessFiles(new DdexReportActionLoadIdentDataDeezer());
                        break;
                }
            }
        }
    }
    public class MergeMusicWorksRunner : ActionRunner
    {
        public override void Run()
        {
            new DdexReport(ConnectionString, DdexReportId).MergeMusicWorks();
        }
    }
    public class CreateIdentBacklogRunner : ActionRunner
    {
        public override void Run()
        {
            new DdexReport(ConnectionString, DdexReportId).CreateIdentBacklog();
        }
    }
    public class CreateIdentBacklogToMwLinkRunner : ActionRunner
    {
        public override void Run()
        {
            new DdexReport(ConnectionString, DdexReportId).CreateIdentBacklogToMwLink();
        }
    }
    public class CreatePseudoNetRevenueRunner : ActionRunner
    {
        public override void Run()
        {
            new DdexReport(ConnectionString, DdexReportId).CreatePseudoNetRevenue();
        }
    }
    public class CalcNetRevenuePerMusicWorkRunner : ActionRunner
    {
        public override void Run()
        {
            new DdexReport(ConnectionString, DdexReportId).CalcNetRevenuePerMusicWork();
        }
    }
    public class AutoIdentByIswcRunner : ActionRunner
    {
        public override void Run()
        {
            new DdexReport(ConnectionString, DdexReportId).AutoIdentByIswc();
        }
    }
    public class CalcMwPrioritiesRunner : ActionRunner
    {
        public override void Run()
        {
            new DdexReport(ConnectionString, DdexReportId).CalcMwPriorities();
        }
    }
    public class CalcBasicReportStatisticsRunner : ActionRunner
    {
        public override void Run()
        {
            new DdexReport(ConnectionString, DdexReportId).CalcBasicReportStatistics();
        }
    }
    public class CalcDetailedReportStatisticsRunner : ActionRunner
    {
        public override void Run()
        {
            new DdexReport(ConnectionString, DdexReportId).CalcDetailedReportStatistics();
        }
    }
    public class CalcPriorityBlocksStatisticsRunner : ActionRunner
    {
        public override void Run()
        {
            new DdexReport(ConnectionString, DdexReportId).CalcPriorityBlocksStatistics();
        }
    }
    public class IdentMwAuthorsRunner : ActionRunner
    {
        public override void Run()
        {
            /*
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ddexReportId", DdexReportId);
                cmd.CommandText = "dbo.pTsk10_DdexIdentMWAuthor";
                cmd.ExecuteNonQuery();
            }, true);
            */
        }
    }
    public class ProcessExclusionsRunner : ActionRunner
    {
        public override void Run()
        {
           /*
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.pTsk10_DdexExceptionStatus";
                cmd.Parameters.AddWithValue("@ddexReportId", DdexReportId);
                cmd.Parameters.AddWithValue("@setId", 1);
                cmd.ExecuteNonQuery();
            }, true);
            */
        }
    }
    public class CalcMarketShareRunner : ActionRunner
    {
        public override void Run()
        {
            /*
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.pTsk10_DDEXFormRate";
                cmd.Parameters.AddWithValue("@ddexReportId", DdexReportId);
                cmd.ExecuteNonQuery();
            }, true);
            */
        }
    }
    /*public class DoPreIdentificationRunner : ActionRunner
    {
        public override void Run()
        {
            System.Threading.Thread.Sleep(2000);
        }
    }*/

    // Legacy code
    #region LEGACY_CODE
    public class FillRawDataRunner : ActionRunner
    {
        public override void Run()
        {
            System.Threading.Thread.Sleep(2000);
        }
    }

    public class CheckErrorsRunner : ActionRunner
    {
        public override void Run()
        {
            new DdexReport(ConnectionString, DdexReportId)
                .ProcessFiles(new DdexReportActionRegisterErrorsYouTube());
        }
    }

    public class CheckFileSizesRunner : ActionRunner
    {
        public override void Run()
        {
            new DdexReport(ConnectionString, DdexReportId)
                .ProcessFiles(new DdexReportActionCheckColSizes());
        }
    }

    public class LoadRawDataRunner : ActionRunner
    {
        public override void Run()
        {
            new DdexReport(ConnectionString, DdexReportId)
                .ProcessFiles(new DdexReportActionFillRawData(true));
        }
    }

    public class LoadSubscriptionDataRunner : ActionRunner
    {
        public override void Run()
        {
            new DdexReport(ConnectionString, DdexReportId)
                .ProcessFiles(new DdexReportActionFillSubscriptionData(true));
        }
    }

    public class LoadIdentDataRunner : ActionRunner
    {
        public override void Run()
        {
            new DdexReport(ConnectionString, DdexReportId)
                .ProcessFiles(new DdexReportActionLoadIdentDataYouTube());
        }
    }

    public class RegisterAuthorsRunner : ActionRunner
    {
        public override void Run()
        {
            new DdexReport(ConnectionString, DdexReportId)
                .SplitAuthors();
        }
    }

    public class PrepareDataForIdentificationRunner : ActionRunner
    {
        public override void Run()
        {
            int ddexReportingPeriodId = (int)SqlHelpers.GetSingleValue(ConnectionString
                , "select top(1) ddexReportingPeriodId from DdexReport where id = @p0"
                , DdexReportId);
            DdexReportingPeriod period = new DdexReportingPeriod(ConnectionString, ddexReportingPeriodId);
            period.PrepareDataForIdentification(DdexReportId);
        }
    }

    public class DoInitialIdentificationRunner : ActionRunner
    {
        public override void Run()
        {
            int ddexReportingPeriodId = (int)SqlHelpers.GetSingleValue(ConnectionString
                , "select top(1) ddexReportingPeriodId from DdexReport where id = @p0"
                , DdexReportId);
            DdexReportingPeriod period = new DdexReportingPeriod(ConnectionString, ddexReportingPeriodId);
            period.DoInitialIdentification(DdexReportId);
        }
    }

    public class IdentifyByIswcRunner : ActionRunner
    {
        public override void Run()
        {
            int ddexReportingPeriodId = (int)SqlHelpers.GetSingleValue(ConnectionString
                , "select top(1) ddexReportingPeriodId from DdexReport where id = @p0"
                , DdexReportId);
            DdexReportingPeriod period = new DdexReportingPeriod(ConnectionString, ddexReportingPeriodId);
            period.IdentifyByIswc(DdexReportId);
        }
    }

    public class CreateInitialInvoiceRunner : ActionRunner
    {
        /*
        RevShare revShare;
        public override bool PreRun()
        {
            int ddexReportingPeriodId = (int)SqlHelpers.GetSingleValue(ConnectionString
                , "select top(1) ddexReportingPeriodId from DdexReport where id = @p0"
                , DdexReportId);
            DdexReportingPeriod period = new DdexReportingPeriod(ConnectionString, ddexReportingPeriodId);
            RevShare revShare = period.GetRevShare();
            bool createNew = revShare == null;
            if (createNew)
                revShare = new RevShare
                {
                    MusicRate = 50
                    , GERate = 50
                    , MechRate = 0
                    , PerfRate = 0
                };
            FormRevShare form = new FormRevShare(revShare);
            if (form.ShowDialog() != DialogResult.OK)
                return false;
            period.ChangeRevShare(revShare, createNew);
            return true;
        }
        
        public override void Run()
        {
            int ddexReportingPeriodId = (int)SqlHelpers.GetSingleValue(ConnectionString
                , "select top(1) ddexReportingPeriodId from DdexReport where id = @p0"
                , DdexReportId);
            DdexReportingPeriod period = new DdexReportingPeriod(ConnectionString, ddexReportingPeriodId);
            period.CreateInitialInvoice();
        }
        */

    }

    public class CreateInitialInvoiceFileRunner : ActionRunner
    {
        string filesPath;
        public override bool PreRun()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    filesPath = fbd.SelectedPath + "\\";
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public override void Run()
        {
            int ddexReportingPeriodId = (int)SqlHelpers.GetSingleValue(ConnectionString
                , "select top(1) ddexReportingPeriodId from DdexReport where id = @p0"
                , DdexReportId);
            DdexReportingPeriod period = new DdexReportingPeriod(ConnectionString, ddexReportingPeriodId);
            period.SaveInvoice(filesPath, false);
        }
    }

    public class SendInitialInvoiceRunner : ActionRunner
    {
        public override bool PreRun()
        {
            DialogResult result = MessageBox.Show(
                     "Автоматичне відсилання файлів в даній версії не підтримується. Виконайте цю дію після того, як файл буде надіслано іншим чином. Файл було надіслано?"
                       , "Попередження", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            return true;
        }

        public override void Run()
        {
        }
    }

    public class UploadResponceRunner : ActionRunner
    {
        string fileName;
        public override bool PreRun()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Файли відповіді клієнта (*.dat)|*.dat";
            if (DialogResult.OK != dlg.ShowDialog())
                return false;
            fileName = dlg.FileName;

            try
            {
                int ddexReportingPeriodId = (int)SqlHelpers.GetSingleValue(ConnectionString
                    , "select top(1) ddexReportingPeriodId from DdexReport where id = @p0"
                    , DdexReportId);
                DdexReportingPeriod period = new DdexReportingPeriod(ConnectionString, ddexReportingPeriodId);
                DdexReportingPeriod.CcidClFileCkeckResult checkResult = period.IsValidClFile(fileName);
                switch (checkResult)
                {
                    case DdexReportingPeriod.CcidClFileCkeckResult.WRONG_FORMAT:
                        MessageBox.Show($"Невірний формат файлу", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    case DdexReportingPeriod.CcidClFileCkeckResult.INVALID_CORRECTION_REFERENCE:
                        MessageBox.Show($"Вибраний файл не відповідає надісланому файлу. Виберіть інший файл."
                            , "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    case DdexReportingPeriod.CcidClFileCkeckResult.VALID:
                        return true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Виникла системна помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public override void Run()
        {
            int ddexReportingPeriodId = (int)SqlHelpers.GetSingleValue(ConnectionString
                , "select top(1) ddexReportingPeriodId from DdexReport where id = @p0"
                , DdexReportId);
            DdexReportingPeriod period = new DdexReportingPeriod(ConnectionString, ddexReportingPeriodId);
            period.LoadClaim(fileName);
        }
    }

    public class CreateFinalInvoiceRunner : ActionRunner
    {
        public override void Run()
        {
            int ddexReportingPeriodId = (int)SqlHelpers.GetSingleValue(ConnectionString
                , "select top(1) ddexReportingPeriodId from DdexReport where id = @p0"
                , DdexReportId);
            DdexReportingPeriod period = new DdexReportingPeriod(ConnectionString, ddexReportingPeriodId);
            period.CreateCorrectedInvoice();
        }
    }

    public class CreateFinalInvoiceFileRunner : ActionRunner
    {
        string filesPath;
        public override bool PreRun()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    filesPath = fbd.SelectedPath + "\\";
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public override void Run()
        {
            int ddexReportingPeriodId = (int)SqlHelpers.GetSingleValue(ConnectionString
                , "select top(1) ddexReportingPeriodId from DdexReport where id = @p0"
                , DdexReportId);
            DdexReportingPeriod period = new DdexReportingPeriod(ConnectionString, ddexReportingPeriodId);
            period.SaveInvoice(filesPath, true);
        }
    }

    public class SendFinalInvoiceRunner : ActionRunner
    {
        public override bool PreRun()
        {
            DialogResult result = MessageBox.Show(
                     "Автоматичне відсилання файлів в даній версії не підтримується. Виконайте цю дію після того, як файл буде надіслано іншим чином. Файл було надіслано?"
                       , "Попередження", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            return true;
        }

        public override void Run()
        {
        }
    }

    public class DistributeAmountsRunner : ActionRunner
    {
        public override bool PreRun()
        {
            DialogResult result = MessageBox.Show(
                     "Дана функціональність ще не реалізована"
                       , "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return false;
        }
        public override void Run()
        {

        }
    }
    #endregion

}
