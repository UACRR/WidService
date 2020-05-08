using InvoicingLib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouTubeInvoicingConsole
{
    public class ActionRunner
    {
        protected string ConnectionString { get; set; }
        protected int DdexReportingPeriodId { get; set; }
        protected int DdexReportId{ get; set; }

        public void Init(string connectionString, int ddexReportingPeriodId, int ddexReportId)
        {
            connectionString = ConnectionString;
            DdexReportingPeriodId = ddexReportingPeriodId;
            DdexReportId = ddexReportId;
        }

        public virtual bool PreRun() { return true; }
        public virtual void Run() { }
    }

    public class FillRawDataRunner : ActionRunner
    {
        public override void Run()
        {
            new DdexReport(ConnectionString, DdexReportId)
                .ProcessFiles(new DdexReportActionRegisterErrors());
        }
    }

    public class CheckErrorsRunner : ActionRunner
    {
        public override void Run()
        {
            new DdexReport(ConnectionString, DdexReportId)
                .ProcessFiles(new DdexReportActionRegisterErrors());
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
                .ProcessFiles(new DdexReportActionFillRawData(false));
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

    public class CreateInitialInvoiceRunner : ActionRunner
    {
        public override void Run()
        {
            int ddexReportingPeriodId = (int)SqlHelpers.GetSingleValue(ConnectionString
                , "select top(1) ddexReportingPeriodId from DdexReport where id = @p0"
                , DdexReportId);
            DdexReportingPeriod period = new DdexReportingPeriod(ConnectionString, ddexReportingPeriodId);
            period.CreateInitialInvoice();
        }
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
                        MessageBox.Show($"Посилання на рахунок фактуру в файлі не відповідає останньому надісланому рахунку-фактурі. Виберіть інший файл."
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

}
