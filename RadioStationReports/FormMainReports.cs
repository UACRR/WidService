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
            LoadReports();
            FillLvReports(0);
            UpdateControls();
        }
        private void Configure()
        {
            lvReports.Columns.Clear();
            lvReports.Columns.Add("№з/п", 60);
            lvReports.Columns.Add("Код", 60);
            lvReports.Columns.Add("Назва файлу", 300);  
            lvReports.Columns.Add("Розташування файлу", 500);
        }

        private void LoadReports()
        {
            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = "select * from Reports order by FileName";
                using(var r = cmd.ExecuteReader())
                {
                    _reports = new List<Report>();
                    while(r.Read())
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
                if(x.Id == selectedReportId)
                {
                    item.Selected = true;
                    item.EnsureVisible();
                }
            });
        }

        private void UpdateControls()
        {
            btnShowReport.Enabled = lvReports.SelectedItems.Count > 0;
        }
        private void ShowReport()
        {
            var selectedReportItem = lvReports.SelectedItems[0];
            if(selectedReportItem == null)
            {
                return;
            }
            var form = new FormReport((Report)selectedReportItem.Tag);
            form.Show();
        }

        private void lvReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void btnRegisterReport_Click(object sender, EventArgs e)
        {
            if(!Helpers.ConfirmAction(
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
            catch(Exception ex)
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
            ShowReport();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lvReports_DoubleClick(object sender, EventArgs e)
        {
            ShowReport();
        }
    }
}
