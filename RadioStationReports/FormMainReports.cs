using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadioStationReports
{
    public partial class FormMainReports : Form
    {

        private class Filter
        {
            public string CurrentValue { get; set; }
            public ComboBox FilterControl { get; set; }
            public string ColumnName { get; set; }
            public string ColumnParamName { get; set; }
        }

        private List<Report> _reports;
        private List<Filter> _filter;

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
            lvReports.Columns.Add("Радіостанція", 120);
            lvReports.Columns.Add("Період", 120);
            lvReports.Columns.Add("Назва файлу", 300);

            btnShowDetails.Text = "<";
            splitPanelReports.Panel2Collapsed = true;

            _filter = new List<Filter>()
            {
               new Filter {CurrentValue = "", FilterControl = cbFilterRadioStation, ColumnName = "t2.Name       " , ColumnParamName = "@RadioStationName"},
               new Filter {CurrentValue = "", FilterControl = cbFilterStartYear   , ColumnName = "t1.StartYear	" , ColumnParamName = "@StartYear"       },
               new Filter {CurrentValue = "", FilterControl = cbFilterStartMonth  , ColumnName = "t1.StartMonth " , ColumnParamName = "@StartMonth"      },
               new Filter {CurrentValue = "", FilterControl = cbFilterEndYear     , ColumnName = "t1.EndYear	" , ColumnParamName = "@EndYear"         },
               new Filter {CurrentValue = "", FilterControl = cbFilterEndMonth    , ColumnName = "t1.EndMonth   " , ColumnParamName = "@EndMonth"        }                     
            };
            radioFilterActive.Checked = true;
            radioFilterArchived.Checked = false;

            FillFilterControls();
            UpdateFilterButtons();
        }

        private void FillFilterControls()
        {
            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = "select Name from RadioStations";

                using (var r = cmd.ExecuteReader())
                {
                    cbFilterRadioStation.Items.Add("<Всі>");
                    while (r.Read())
                    {
                        cbFilterRadioStation.Items.Add(r.GetString(0));
                    }
                }
                cbFilterRadioStation.SelectedIndex = 0;
            });

            cbFilterStartYear.Items.Add("<Всі>");
            cbFilterEndYear.Items.Add("<Всі>");
            for (var year = Configuration.StartYear; year <= Configuration.EndYear; year++)
            {
                cbFilterStartYear.Items.Add(year.ToString());
                cbFilterEndYear.Items.Add(year.ToString());
            }
            cbFilterStartYear.SelectedIndex = 0;
            cbFilterEndYear.SelectedIndex = 0;

            cbFilterStartMonth.Items.Add("<Всі>");
            cbFilterEndMonth.Items.Add("<Всі>");
            for (var Month = 1; Month <= 12; Month++)
            {
                cbFilterStartMonth.Items.Add(Month.ToString());
                cbFilterEndMonth.Items.Add(Month.ToString());
            }
            cbFilterStartMonth.SelectedIndex = 0;
            cbFilterEndMonth.SelectedIndex = 0;
        }

        private bool IsFilterChanged()
        {
            foreach (var filterItem in _filter)
            {
                if (filterItem.FilterControl.SelectedIndex == 0)
                {
                    if (filterItem.CurrentValue != "") return true;
                }
                else
                {
                    if (filterItem.FilterControl.Text != filterItem.CurrentValue) return true;
                }
            }
            return false;
        }

        private void UpdateFilterButtons()
        {
            btnFilterApply.Visible = btnFilterCancel.Visible = IsFilterChanged();
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
                cmd.CommandText = $@"
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
                    {GetReportsFilterSql()}
                    order by t2.Name
                ";
                cmd.Parameters.AddWithValue("@IsArchived", radioFilterActive.Checked ? 0 : 1);
                _filter.Where(x => x.FilterControl.SelectedIndex != 0).ToList().ForEach(x => {
                    cmd.Parameters.AddWithValue(x.ColumnParamName, x.FilterControl.Text);
                });

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

        private string FormatPeriod(Report report)
        {
            try
            {
                var dateStart = new DateTime((int)report.StartYear, (int)report.StartMonth, 1);
                var dateEnd = new DateTime((int)report.EndYear, (int)report.EndMonth, 1);
                return $"{dateStart.ToString("yyyy-MM")} : {dateEnd.ToString("yyyy-MM")}";
            }
            catch
            {
                return "";
            }
        }

        private string GetReportsFilterSql()
        {
            var retVal = $"where IsArchived = @IsArchived";
            _filter.Where(x => x.FilterControl.SelectedIndex != 0).ToList().ForEach(x => {
                retVal += $"\r\n  and {x.ColumnName} = {x.ColumnParamName}";
            });

            return retVal;
        }

        private void FillLvReports(int selectedReportId)
        {
            lvReports.Visible = false;
            lvReports.Items.Clear();
            var seqNr = 1;
            _reports.ForEach(x =>
            {
                var item = lvReports.Items.Add(seqNr.ToString());
                item.SubItems.Add(x.Id.ToString());
                item.SubItems.Add(x.RadioStationName);
                item.SubItems.Add(FormatPeriod(x));
                item.SubItems.Add(x.FileName);
                item.Tag = x;
                if (x.Id == selectedReportId)
                {
                    item.Selected = true;
                    item.EnsureVisible();
                }
                seqNr++;
            });
            lvReports.Visible = true;
        }

        private void FillReportDetails(Report report)
        {
            if (report == null)
            {
                tbReportFileName.Text = "";
                tbReportFilePath.Text = "";
                tbReportSearchFile.Text = "";
                tbReportDistributionFile.Text = "";
            }
            else
            {
                tbReportFileName.Text = report.FileName;
                tbReportFilePath.Text = report.FilePath;
                tbReportSearchFile.Text = report.SearchFileName;
                tbReportDistributionFile.Text = report.DistributionFileName;
            }
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
                cmd.CommandText = "update Reports set IsArchived = @IsArchived where Id = @ReportId";
                cmd.Parameters.AddWithValue("@ReportId", selectedReport.Id);
                cmd.Parameters.AddWithValue("@IsArchived", setArhived);
                cmd.ExecuteNonQuery();
            });
        }

        private void ApplyFilter()
        {
            RefreshReports();
            _filter.ForEach(x =>
            {
                if (x.FilterControl.SelectedIndex == 0)
                {
                    x.CurrentValue = "";
                }
                else
                {
                    x.CurrentValue = x.FilterControl.Text;
                }
            });
            UpdateFilterButtons();
        }

        private void CancelFilter()
        {
            _filter.ForEach(x =>
            {
                if(x.CurrentValue == "")
                {
                    x.FilterControl.SelectedIndex = 0;
                }
                else
                {
                    x.FilterControl.SelectedItem = x.CurrentValue;
                }
            });
            UpdateFilterButtons();
        }

        private void lvReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateControls();

            var selectedReport = GetSelectedReport();
            if (selectedReport == null)
            {
                return;
            }

            FillReportDetails(selectedReport);
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
            form.SetExistingReport(selectedReport);
            form.ShowDialog();

            var item = lvReports.SelectedItems[0];
            item.SubItems[2].Text = selectedReport.RadioStationName;
            item.SubItems[3].Text = FormatPeriod(selectedReport);
        }

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            splitPanelReports.Panel2Collapsed = !splitPanelReports.Panel2Collapsed;
            btnShowDetails.Text = splitPanelReports.Panel2Collapsed ? "<" : ">";
        }

        private void radioFilterActive_CheckedChanged(object sender, EventArgs e)
        {
            timerApplyFilter.Enabled = true;
        }

        private void radioFilterArchived_CheckedChanged(object sender, EventArgs e)
        {
            timerApplyFilter.Enabled = true;
        }

        private void timerApplyFilter_Tick(object sender, EventArgs e)
        {
            timerApplyFilter.Enabled = false;
            RefreshReports();
        }

        private void cbFilterRadioStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFilterButtons();
        }

        private void cbFilterStartYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFilterButtons();
        }

        private void cbFilterStartMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFilterButtons();
        }

        private void cbFilterEndYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFilterButtons();
        }

        private void cbFilterEndMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFilterButtons();
        }

        private void btnFilterApply_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void btnFilterCancel_Click(object sender, EventArgs e)
        {
            CancelFilter();
        }
    }
}
