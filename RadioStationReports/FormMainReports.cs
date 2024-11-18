using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadioStationReports
{
    public partial class FormMainReports : Form
    {

        private List<Report> _reports;

        public FormMainReports()
        {
            InitializeComponent();
        }

        private void FormMainReports_Load(object sender, EventArgs e)
        {
            Configure();
            RefreshReports();
        }

        private void Configure()
        {
            lvReports.Columns.Clear();
            lvReports.Columns.Add("№з/п", 60);
            lvReports.Columns.Add("Код", 60);
            lvReports.Columns.Add("Назва файлу", 300);
            lvReports.Columns.Add("Розташування файлу", 500);
        }

        private void RefreshReports()
        {
            LoadReports();
            FillLvReports(0);
            UpdateControls();
        }

        private void LoadReports()
        {
            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = @"
                    select
	                      t1.Id                       
	                    , t1.RadioStationId           
	                    , t2.Name         
	                    , t1.StartYear		         
	                    , t1.StartMonth	             
	                    , t1.EndYear		             
	                    , t1.EndMonth                 
	                    , t1.FileName                 
	                    , t1.FilePath                 
	                    , t1.SearchFileName           
	                    , t1.DistributionFileName     
	                    , t1.IsArchived               
	                    , t1.CreatedAt                
	                    , t1.UpdatedAt                
	                    , t1.AutoSearchFinishedAt     
	                    , t1.CalcRoyaltyFinishedAt    
	                    , t1.SearchFileCreatedAt      
	                    , t1.SearchFileUpdatedAt      
	                    , t1.SearchFileImportedAt     
	                    , t1.DistributionFileCreatedAt
	                    , t1.DistributionFileUpdatedAt
                    from Reports t1
	                    left join RadioStations t2 on t1.RadioStationId = t2.Id 
                    order by t1.FileName
                ";
                using (var r = cmd.ExecuteReader())
                {
                    _reports = new List<Report>();
                    while (r.Read())
                    {
                        _reports.Add(Report.CreateFromDb(r));
                    }
                }
            });
        }

        private void FillLvReports(int selectedReportId)
        {
            lvReports.Items.Clear();
            var seqNr = 1;
            _reports.ForEach(x =>
            {
                var item = lvReports.Items.Add(seqNr.ToString());
                item.SubItems.Add(x.Id.ToString());
                item.SubItems.Add(x.FileName);
                item.SubItems.Add(x.FilePath);
                item.Tag = x;
                if (x.Id == selectedReportId)
                {
                    item.Selected = true;
                    item.EnsureVisible();
                }
            });
        }

        private void UpdateControls()
        {
            var selectedReport = GetSelectedReport();

            btnShowReport.Enabled = selectedReport != null;
            btnDelete.Enabled = selectedReport != null;
            btnArhive.Enabled = selectedReport != null;
            btnParams.Enabled = selectedReport != null;

            btnArhive.Text = selectedReport != null && selectedReport.IsArchived ? "Відновити" : "До архіву";
        }

        private Report GetSelectedReport()
        {
            if (lvReports.SelectedItems.Count == 0)
            {
                return null;
            }
            var selectedReportItem = lvReports.SelectedItems[0];
            return (Report)selectedReportItem.Tag;
        }

        private void ShowReport(Report selectedReport)
        {
            var form = new FormReport(selectedReport);
            form.Show();
        }

        private void DeleteReport(Report selectedReport)
        {
            Helpers.RunSql(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spDeleteReport";
                cmd.Parameters.AddWithValue("@ReportId", selectedReport.Id);
                cmd.ExecuteNonQuery();
            });
        }

        private void SetReportArhived(Report selectedReport, bool setArhived)
        {
            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = "update Reports set IsArchoved = @IsArchived where Id = @ReportId";
                cmd.Parameters.AddWithValue("@ReportId", selectedReport.Id);
                cmd.Parameters.AddWithValue("@IsArchived", setArhived);
                cmd.ExecuteNonQuery();
            });
        }

        private void lvReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void btnRegisterReport_Click(object sender, EventArgs e)
        {
            if (!Helpers.ConfirmAction(
                      "Для реєстрації звіту слід буде вибрати віповідний файл, після чого рядки звіту будуть завантажені в базу даних,"
                    + " а також буде створена додаткова інформація, необхідна для подальшого опрацювання. Це може зайняти тривалий час.\r\n"
                    + "Зареєструвати звіт?"
                )
            )
            {
                return;
            }

            if (openFileDlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            var fileFullName = openFileDlg.FileName;
            var radioPreSearchManager = new RadioPreSearchManager();

            try
            {
                var reportId = radioPreSearchManager.LoadReport(fileFullName);
                Helpers.ShowSuccess("Звіт успішно зареєстровано!");
                LoadReports();
                FillLvReports(reportId);
                UpdateControls();
                lvReports.Focus();
            }
            catch (Exception ex)
            {
                Helpers.ShowError(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.WaitCursor;
            }
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            var selectedReport = GetSelectedReport();
            if (selectedReport == null)
            {
                return;
            }

            ShowReport(selectedReport);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lvReports_DoubleClick(object sender, EventArgs e)
        {
            var selectedReport = GetSelectedReport();
            if (selectedReport == null)
            {
                return;
            }

            ShowReport(selectedReport);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selectedReport = GetSelectedReport();
            if (selectedReport == null)
            {
                return;
            }

            var msgTxt = !selectedReport.IsArchived ?
                "Видаляти звіт слід лише за умови, якщо він зареєстрований помилково. " +
                "В іншому разі після завершення обробки звіту його слід передати в архів.\r\n" +
                "Видалити звіт?"
                :
                "Всі дані звіту будуть втрачені.\r\n" +
                "Видалити звіт?";
            var mbResult = MessageBox.Show(msgTxt, "Видалення звіту", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mbResult == DialogResult.No)
            {
                return;
            }

            DeleteReport(selectedReport);

            RefreshReports();
        }

        private void btnArhive_Click(object sender, EventArgs e)
        {
            var selectedReport = GetSelectedReport();
            if (selectedReport == null)
            {
                return;
            }

            var msgTxt = !selectedReport.IsArchived ?
                "Передати звіт в архів?"
                :
                "Відновити звіт з архіву?";
            var mbResult = MessageBox.Show(msgTxt, "Архівування звіту", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mbResult == DialogResult.No)
            {
                return;
            }

            SetReportArhived(selectedReport, !selectedReport.IsArchived);

            RefreshReports();
        }

        private void btnParams_Click(object sender, EventArgs e)
        {
            var selectedReport = GetSelectedReport();
            if (selectedReport == null)
            {
                return;
            }

            var form = new FormReportParams();
            form.SetReport(selectedReport);
            form.ShowDialog();
        }
    }
}
