using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadioStationReports
{
    public partial class UcRegisteredReports : UserControl
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

        private bool _ignoreFilterChanged = false;

        private string _textToCopy = "";

        public UcRegisteredReports()
        {
            InitializeComponent();
        }

        private void UcRegisteredReports_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

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

            splitPanelReports.FixedPanel = FixedPanel.Panel1;

            FillFilterControls();
        }

        private void FillFilterRadioStations()
        {
            var selectedRadioStationName = cbFilterRadioStation.Text;
            var selectIndex = 0;
            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = "select Name from RadioStations order by Name";

                using (var r = cmd.ExecuteReader())
                {
                    cbFilterRadioStation.Items.Clear();
                    cbFilterRadioStation.Items.Add("<Всі>");
                    var idx = 1;
                    while (r.Read())
                    {
                        var radioStationName = r.GetString(0);
                        cbFilterRadioStation.Items.Add(r.GetString(0));
                        if (radioStationName == selectedRadioStationName)
                        {
                            selectIndex = idx++;
                        }
                        idx++;
                    }
                }
            });
            _ignoreFilterChanged = true;
            cbFilterRadioStation.SelectedIndex = selectIndex;
            _ignoreFilterChanged = false;
        }

        private void FillFilterControls()
        {
            FillFilterRadioStations();

            _ignoreFilterChanged = true;
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
            _ignoreFilterChanged = false;
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

        private void RefreshReports()
        {
            LoadReports();
            FillLvReports(0);
            UpdateControls();
            FillReportDetails(GetSelectedReport());
        }

        private void LoadReports()
        {
            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = $@"
                    {Report.SelectSql}
                    {GetReportsFilterSql()}
                    order by t2.Name
                ";
                cmd.Parameters.AddWithValue("@IsArchived", radioFilterActive.Checked ? 0 : 1);
                _filter.Where(x => x.FilterControl.SelectedIndex != 0).ToList().ForEach(x =>
                {
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
            _filter.Where(x => x.FilterControl.SelectedIndex != 0).ToList().ForEach(x =>
            {
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
                tbReportWorkFilesPath.Text = "";
                tbReprotSourceFileCopyName.Text = "";
                tbReportSearchFile.Text = "";
                tbReportDistributionFile.Text = "";
                //tbReportCheckFile.Text = "";
            }
            else
            {
                tbReportFileName.Text = report.FileName;
                tbReportFilePath.Text = report.FilePath;
                tbReportWorkFilesPath.Text = report.WorkFilesPath;
                tbReprotSourceFileCopyName.Text = report.SourceFileCopyName;
                tbReportDistributionFile.Text = report.DistributionFileName;
                tbReportSearchFile.Text = report.SearchFileName;
            }
        }

        private void UpdateControls()
        {
            var selectedReport = GetSelectedReport();

            btnShowReport.Enabled = selectedReport != null;
            btnDelete.Enabled = selectedReport != null;
            btnArhive.Enabled = selectedReport != null;

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

            var sourceFileCopyNameFull = Path.Combine(selectedReport.WorkFilesPath, selectedReport.SourceFileCopyName);
            if (File.Exists(sourceFileCopyNameFull))
            {
                File.Delete(sourceFileCopyNameFull);
            }

            var sourceSearchFileNameFull = Path.Combine(selectedReport.WorkFilesPath, selectedReport.SearchFileName);
            if (File.Exists(sourceSearchFileNameFull))
            {
                File.Delete(sourceSearchFileNameFull);
            }

            var sourceDistributionFileNameFull = Path.Combine(selectedReport.WorkFilesPath, selectedReport.DistributionFileName);
            if (File.Exists(sourceDistributionFileNameFull))
            {
                File.Delete(sourceDistributionFileNameFull);
            }

            var sourceCheckFileNameFull = Path.Combine(selectedReport.WorkFilesPath, selectedReport.CheckFileName);
            if (File.Exists(sourceCheckFileNameFull))
            {
                File.Delete(sourceCheckFileNameFull);
            }
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
        }

        private void CancelFilter()
        {
            _filter.ForEach(x =>
            {
                if (x.CurrentValue == "")
                {
                    x.FilterControl.SelectedIndex = 0;
                }
                else
                {
                    x.FilterControl.SelectedItem = x.CurrentValue;
                }
            });
        }

        private void lvReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateControls();

            var selectedReport = GetSelectedReport();
            FillReportDetails(selectedReport);
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

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            splitPanelReports.Panel2Collapsed = !splitPanelReports.Panel2Collapsed;
            btnShowDetails.Text = splitPanelReports.Panel2Collapsed ? "<" : ">";
        }

        private void radioFilterActive_CheckedChanged(object sender, EventArgs e)
        {
            if (_ignoreFilterChanged) return;
            timerApplyFilter.Enabled = true;
        }

        private void radioFilterArchived_CheckedChanged(object sender, EventArgs e)
        {
            if (_ignoreFilterChanged) return;
            timerApplyFilter.Enabled = true;
        }

        private void timerApplyFilter_Tick(object sender, EventArgs e)
        {
            timerApplyFilter.Enabled = false;
            RefreshReports();
        }

        private void cbFilterRadioStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_ignoreFilterChanged) return;
            ApplyFilter();
            //UpdateFilterButtons();
        }

        private void cbFilterStartYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_ignoreFilterChanged) return;
            ApplyFilter();
            //UpdateFilterButtons();
        }

        private void cbFilterStartMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_ignoreFilterChanged) return;
            ApplyFilter();
            //UpdateFilterButtons();
        }

        private void cbFilterEndYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_ignoreFilterChanged) return;
            ApplyFilter();
            //UpdateFilterButtons();
        }

        private void cbFilterEndMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_ignoreFilterChanged) return;
            ApplyFilter();
            //UpdateFilterButtons();
        }

        private void btnFilterApply_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void btnFilterCancel_Click(object sender, EventArgs e)
        {
            CancelFilter();
        }

        private void lvReports_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = lvReports.GetItemAt(e.X, e.Y);
                if (item == null)
                {
                    return;
                }
                var text = item.GetSubItemAt(e.X, e.Y).Text;
                _textToCopy = string.IsNullOrEmpty(text) ? "" : text;
                contextMenuStrip.Show(lvReports, new Point(e.X, e.Y), ToolStripDropDownDirection.BelowRight);
            }
        }

        private void contextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(_textToCopy))
            {
                Clipboard.SetText(_textToCopy);
            }
            else
            {
                Clipboard.Clear();
            }
        }

        private void btnRegisterReportFromFile_Click(object sender, EventArgs e)
        {
            openFileDlg.Title = "Виберіть файл звіту";
            if (openFileDlg.ShowDialog() != DialogResult.OK)
            {
                FillFilterRadioStations(); 
                return;
            }

            var fileFullName = openFileDlg.FileName;

            var form = new FormReportParams();
            form.SetNewReport(fileFullName);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.Cancel)
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            var radioPreSearchManager = new RadioPreSearchManager();

            try
            {
                var reportId = radioPreSearchManager.LoadReport(
                    fileFullName,
                    form.OutputParameters
                );

                var formRegisterReport = new FormRegisterReport(reportId, fileFullName);
                formRegisterReport.ShowDialog();
                //return form.ReportItemStatus;

 //               radioPreSearchManager = new RadioPreSearchManager(reportId);
  //              radioPreSearchManager.AutoSearch();

                Helpers.RunSql(cmd =>
                {
                    cmd.CommandText = @"
                        update Reports 
                        set 
                              UpdatedAt             = getdate()
                            , AutoSearchFinishedAt  = getdate()
                        where Id = @ReportId";
                    cmd.Parameters.AddWithValue("@ReportId", reportId);
                    cmd.ExecuteNonQuery();
                });

                Helpers.ShowSuccess("Звіт успішно зареєстровано!");

                LoadReports();
                FillLvReports(reportId);
                UpdateControls();
                lvReports.Focus();
                FillFilterRadioStations();

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
    }
}
