using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadioStationReports
{
    public partial class FormReport : Form
    {
        const int FILTER_INDEX_SMART = 1;
        const int FILTER_INDEX_WID = 2;
        const int FILTER_INDEX_NOT_FOUND = 3;

        private bool _cbFilterIgnoreSelectedIndexChanged;
        private bool _actionsVisible;

        private Report _report;
        private List<ReportLine> _reportLines;

        private RadioPreSearchManager _radioPreSearchManager = new RadioPreSearchManager();
        private bool _importSearchFileInProgress = false;

        public FormReport(Report report)
        {
            InitializeComponent();
            _report = report;
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            _actionsVisible = true;

            ucReportLineWork.Changed += UcReportLineWork_Changed;

            ConfigureLvReportLines();
            ConfigureCbFilter();

            LoadReportLines();
            FillLvReportLines();
            FillLabLinesCnt();

            UpdateControls();
        }

        private void UcReportLineWork_Changed(object sender, EventArgs e)
        {
            _report.UpdatedAt = DateTime.Now;
            UpdateControls();
        }

        private ListViewItem GetSelectedItem()
        {
            return lvReportLines.SelectedItems.Count > 0 ? lvReportLines.SelectedItems[0] : null;
        }

        private void ConfigureLvReportLines()
        {
            lvReportLines.View = View.Details;
            lvReportLines.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvReportLines.FullRowSelect = true;
            lvReportLines.MultiSelect = false;

            lvReportLines.Columns.Add("Номер рядка"       , 90  );
            lvReportLines.Columns.Add("Назва твору"         , 200 );
            lvReportLines.Columns.Add("Виконавці"    , 200 );
            lvReportLines.Columns.Add("Автор(и) Музики"  , 120 );
            lvReportLines.Columns.Add("Автор(и) Тексту"   , 120 );
            lvReportLines.Columns.Add("Тривалість твору"     , 120 );
            lvReportLines.Columns.Add("Кількість прослуховувань"    , 160 );
            lvReportLines.Columns.Add("Загальна тривалість", 140 );

            var formWidth = 44;
            foreach(ColumnHeader col in lvReportLines.Columns)
            {
                formWidth += col.Width;
            }
            this.Width = formWidth;

            this.Text = $"Звіт {_report.FileName}";
        }

        private void ConfigureCbFilter()
        {
            cbFilter.Items.Clear();
            cbFilter.Items.Add("Всі");
            cbFilter.Items.Add("Знайдені в СМАРТ");
            cbFilter.Items.Add("Знайдені в ВІД");
            cbFilter.Items.Add("Не знайдені");

            _cbFilterIgnoreSelectedIndexChanged = true;
            cbFilter.SelectedIndex = 0;
            _cbFilterIgnoreSelectedIndexChanged = false;
        }

        private void UpdateControls()
        {
            labAutoSearch.Text =  "Автоматичний пошук";

            labAutoSearchStatus.Text = "Автоматичний пошук виконаний";
            labAutoSearchStatus.Visible = _report.AutoSearchFinishedAt != null;

            btnAutoSearch.Visible = _report.AutoSearchFinishedAt == null;

            btnCalcRoyalty.Visible = _report.AutoSearchFinishedAt != null
                && (_report.CalcRoyaltyFinishedAt == null || _report.CalcRoyaltyFinishedAt < _report.UpdatedAt);

            labCalcShareStatus.Visible = !btnCalcRoyalty.Visible;
            labCalcShareStatus.Text = _report.AutoSearchFinishedAt == null ?
                "Виконайте сперше автоматичний пошук" : "Розрахунок для поточних даних виконаний";

            tbSearchFileName.Text = _report.SearchFileName;

            btnCreateSearchFile.Enabled = _report.AutoSearchFinishedAt != null
                && (_report.SearchFileCreatedAt == null
                    ||  
                    (      _report.SearchFileUpdatedAt  <  _report.UpdatedAt
                        && _report.SearchFileImportedAt != _report.UpdatedAt
                    )
                );
            btnCreateSearchFile.Text = string.IsNullOrEmpty(_report.SearchFileName) ?
                "Створити файл" : "Оновити файл";

            btnShowSearchFile.Enabled = !string.IsNullOrEmpty(_report.SearchFileName);
            
            btnImportSearchFile.Enabled = !string.IsNullOrEmpty(_report.SearchFileName);

            tbDistrFileName.Text = _report.DistributionFileName;

            btnCreateDistributionFile.Enabled = _report.AutoSearchFinishedAt != null
                && !btnCalcRoyalty.Visible
                && (   _report.DistributionFileCreatedAt == null
                    || _report.DistributionFileUpdatedAt < _report.UpdatedAt
                );

            btnCreateDistributionFile.Enabled = true; // for testing

            btnCreateDistributionFile.Text = string.IsNullOrEmpty(_report.DistributionFileName) ?
                "Створити файл" : "Оновити файл";

            btnShowDistributionFile.Enabled = !string.IsNullOrEmpty(_report.DistributionFileName);

            btnShowHideActions.Text = _actionsVisible ? ">" : "<";
            panelMain.ColumnStyles[1].Width = _actionsVisible ? 380 : 30;

        }

        private void LoadReportLines()
        {
            var filter = "";
            if(cbFilter.SelectedIndex == FILTER_INDEX_SMART)
            {
                filter = " and FoundIn = 'M'";
            }
            else if (cbFilter.SelectedIndex == FILTER_INDEX_WID)
            {
                filter = " and FoundIn = 'W'";
            }
            else if (cbFilter.SelectedIndex == FILTER_INDEX_NOT_FOUND)
            {
                filter = " and FoundIn is null";
            }

            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = $@"
                    select * 
                    from ReportLines t1
                        join Works t2 on t1.WorkId = t2.Id
                    where ReportId = @ReportId {filter}
                    order by t1.LineNr";
                cmd.Parameters.AddWithValue("@ReportId", _report.Id);

                using(var r = cmd.ExecuteReader())
                {
                    _reportLines = new List<ReportLine>();
                    while(r.Read())
                    {
                        var reportLine = new ReportLine();
                        var idx = 2; // Пропускаємо Id і ReportId

                        reportLine.LineNr        = r.GetInt32(idx++);
                        reportLine.Name          = r.GetString(idx++);
                        reportLine.Performer     = r.GetString(idx++);
                        reportLine.MusicAuthor   = r.GetString(idx++);
                        reportLine.TextAuthor    = r.GetString(idx++);
                        reportLine.Duration      = r.GetString(idx++);
                        reportLine.CountUses     = r.GetString(idx++);
                        reportLine.TotalDuration = r.GetString(idx++);

                        idx++;
                        
                        var work = new Work();
                        work.Id = r.GetInt32(idx++);
                        work.Name = r.GetString(idx++);
                        work.Authors = r.GetString(idx++);
                        work.Performers = r.GetString(idx++);
                        work.NameT = r.IsDBNull(idx) ? "" : r.GetString(idx);
                        idx++;
                        work.AuthorsT = r.IsDBNull(idx) ? "" : r.GetString(idx);
                        idx++;
                        work.PerformersT = r.IsDBNull(idx) ? "" : r.GetString(idx);
                        idx++;
                        work.FoundIn = r.IsDBNull(idx) ? "" : r.GetString(idx);
                        idx++;
                        work.FoundCde = r.IsDBNull(idx) ? (int?)null : r.GetInt32(idx);
                        idx++;
                        work.Iswc = r.IsDBNull(idx) ? "" : r.GetString(idx);
                        idx++;
                        work.Share = r.IsDBNull(idx) ? (decimal?)null : r.GetDecimal(idx);

                        reportLine.Work = work;

                        _reportLines.Add(reportLine);
                    }
                }
            });
        }

        private void FillLvReportLines()
        {
            lvReportLines.Items.Clear();
            _reportLines.ForEach(x =>
            {
                var item = lvReportLines.Items.Add(x.LineNr.ToString());
                item.SubItems.Add(x.Name         );
                item.SubItems.Add(x.Performer    );
                item.SubItems.Add(x.MusicAuthor  );
                item.SubItems.Add(x.TextAuthor   );
                item.SubItems.Add(x.Duration     );
                item.SubItems.Add(x.CountUses    );
                item.SubItems.Add(x.TotalDuration);
                item.Tag = x;
            });
        }

        private void FillLabLinesCnt()
        {
            labLinesCnt.Text = $"(кількість рядків {lvReportLines.Items.Count})";
        }

        private void btnAutoSearch_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                var radioPreSearchManager = new RadioPreSearchManager(_report.Id);
                radioPreSearchManager.AutoSearch();

                Helpers.RunSql(cmd =>
                {
                    cmd.CommandText = @"
                        update Reports 
                        set 
                              SearchFileName        = @SearchFileName
                            , UpdatedAt             = getdate()
                            , AutoSearchFinishedAt  = getdate()
                        where Id = @ReportId";
                    cmd.Parameters.AddWithValue("@SearchFileName", _report.SearchFileName);
                    cmd.Parameters.AddWithValue("@ReportId", _report.Id);
                    cmd.ExecuteNonQuery();
                });

                Report.UpdateFromDb(_report);
                LoadReportLines();

                UpdateControls();

                Cursor.Current = Cursors.Default;
            }
            catch(Exception ex)
            {
                Cursor.Current = Cursors.Default;
                Helpers.ShowError(ex.Message);
                return;
            }

            Helpers.ShowSuccess("Автоматичний пошук творів для рядків звіту виконано.");

        }
        
        private void btnCalcRoyalty_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                var radioPreSearchManager = new RadioPreSearchManager(_report.Id);
                radioPreSearchManager.RecalcShares();
                Helpers.RunSql(cmd =>
                {
                    cmd.CommandText = @"
                        update Reports 
                        set 
                            CalcRoyaltyFinishedAt = getdate()
                        where Id = @ReportId";
                    cmd.Parameters.AddWithValue("@ReportId", _report.Id);
                    cmd.ExecuteNonQuery();
                });

                Report.UpdateFromDb(_report);
                LoadReportLines();

                UpdateControls();

                Cursor.Current = Cursors.Default;
            }
            catch(Exception ex)
            {
                Cursor.Current = Cursors.Default;
                Helpers.ShowError(ex.Message);
                return;
            }

            Helpers.ShowSuccess("Розрахунок процентів роялті виконано.");
        }

        private void btnCreateSearchFile_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                RadioPreSearchManager.CreateSearchFile(_report, _reportLines);

                _report.SearchFileName = $"Search_{_report.FileName}";
                Helpers.RunSql(cmd =>
                {
                    cmd.CommandText = @"
                        update Reports 
                        set
                              SearchFileName        = @SearchFileName
                            , SearchFileCreatedAt   = case when SearchFileCreatedAt is null then getdate() else SearchFileCreatedAt end
                            , SearchFileUpdatedAt   = getdate()
                        where Id = @ReportId
                    ";
                    cmd.Parameters.AddWithValue("@SearchFileName", _report.SearchFileName);
                    cmd.Parameters.AddWithValue("@ReportId", _report.Id);
                    cmd.ExecuteNonQuery();
                });

                Report.UpdateFromDb(_report);

                UpdateControls();

                Cursor.Current = Cursors.Default;
            }
            catch(Exception ex)
            {
                Cursor.Current = Cursors.Default;
                Helpers.ShowError($"{ex.Message} Можливо, файл відкритий в додатку Ексель. Закрийте файл і спробуйте ще раз.");
                return;
            }

            Helpers.ShowSuccess($"Файл створено/оновлено - {Path.Combine(_report.FilePath, _report.SearchFileName)}");

        }

        private void btnShowSearchFile_Click(object sender, EventArgs e)
        {
            var fileFullName = Path.Combine(_report.FilePath, _report.SearchFileName);
            if (!File.Exists(fileFullName))
            {
                Helpers.ShowError("Файл не знайдений");
                return;
            }

            var argument = $"/select, \"{fileFullName}\"";
            System.Diagnostics.Process.Start("explorer.exe", argument);
        }

        private void btnImportSearchFile_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _radioPreSearchManager.IsInProgress = true;
            _importSearchFileInProgress = true;
            timerImportSearchFileProgress.Enabled = true;
            panelMain.Enabled = false;
            try
            {
                var thread = new Thread(() => {
                    _radioPreSearchManager.ImportSearchFile(_report);
                    Helpers.RunSql(cmd =>
                    {
                        cmd.CommandText = @"
                            update Reports 
                            set
                                  UpdatedAt             = getdate()
                                , SearchFileImportedAt  = getdate()
                            where Id = @ReportId
                        ";
                        cmd.Parameters.AddWithValue("@ReportId", _report.Id);
                        cmd.ExecuteNonQuery();
                    });

                });
                thread.Start();

            }
            catch(Exception ex)
            {
                Cursor.Current = Cursors.Default;
                Helpers.ShowError(ex.Message);
                return;
            }

            //Helpers.ShowSuccess($"Файл імпортований - {Path.Combine(_report.FilePath, _report.SearchFileName)}");

        }

        private void btnCreateDistributionFile_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                RadioPreSearchManager.CreateDistributionFile(_report);

                _report.DistributionFileName = $"Distribution_{_report.FileName}";
                Helpers.RunSql(cmd =>
                {
                    cmd.CommandText = @"
                        update Reports 
                        set
                              DistributionFileName        = @DistributionFileName
                            , DistributionFileCreatedAt   = case when DistributionFileCreatedAt is null then getdate() else DistributionFileCreatedAt end
                            , DistributionFileUpdatedAt   = getdate()
                        where Id = @ReportId
                    ";
                    cmd.Parameters.AddWithValue("@DistributionFileName", _report.DistributionFileName);
                    cmd.Parameters.AddWithValue("@ReportId", _report.Id);
                    cmd.ExecuteNonQuery();
                });

                Report.UpdateFromDb(_report);

                UpdateControls();

                Cursor.Current = Cursors.Default;
            }
            catch(Exception ex)
            {
                Cursor.Current = Cursors.Default;
                Helpers.ShowError(ex.Message);
                return;
            }

            Helpers.ShowSuccess($"File created - {Path.Combine(_report.FilePath, _report.DistributionFileName)}");

        }
        
        private void btnShowDistributionFile_Click(object sender, EventArgs e)
        {
            var fileFullName = Path.Combine(_report.FilePath, _report.DistributionFileName);
            if (!File.Exists(fileFullName))
            {
                Helpers.ShowError("Файл не знайдений");
                return;
            }

            var argument = $"/select, \"{fileFullName}\"";
            System.Diagnostics.Process.Start("explorer.exe", argument);
        }

        private void btnBallancePercents_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                RadioPreSearchManager.BallancePercents(_report);
                Cursor.Current = Cursors.Default;
            }
            catch(Exception ex)
            {
                Cursor.Current = Cursors.Default;
                Helpers.ShowError(ex.Message);
                return;
            }

            Helpers.ShowSuccess($"Проценти вирівняні, файл {Path.Combine(_report.FilePath, _report.DistributionFileName)}");
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(_cbFilterIgnoreSelectedIndexChanged)
            {
                return;
            }

            ucReportLineWork.Clear();
            LoadReportLines();
            FillLvReportLines();
            FillLabLinesCnt();
        }

        private void lvReportLines_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = GetSelectedItem();
            if(selectedItem == null)
            {
                ucReportLineWork.Clear();
                return;
            }

            var reportLine = (ReportLine)selectedItem.Tag;
            ucReportLineWork.Update(_report.Id, reportLine.LineNr);
        }

        private void btnShowHideActions_Click(object sender, EventArgs e)
        {
            _actionsVisible = !_actionsVisible;
            UpdateControls();
        }

        private void timerImportSearchFileProgress_Tick(object sender, EventArgs e)
        {
            if(!_radioPreSearchManager.IsInProgress)
            {
                timerImportSearchFileProgress.Enabled = false;
                if(_radioPreSearchManager.ErrorText != "")
                {
                    Cursor.Current = Cursors.Default;
                    pbOperationProgress.Visible = false;
                    panelMain.Enabled = true;
                    statusBarLabel.Text = $"ПОМИЛКА: {_radioPreSearchManager.ErrorText}";
                    Helpers.ShowError(statusBarLabel.Text);
                    return;
                }
                try
                {
                    Report.UpdateFromDb(_report);
                    LoadReportLines();
                    UpdateControls();
                    statusBarLabel.Text = "Імпорт файлу пошуку завершено";
                    Helpers.ShowSuccess(statusBarLabel.Text);
                }
                catch(Exception ex)
                {
                    statusBarLabel.Text =$"ПОМИЛКА: {ex.Message}";
                    Helpers.ShowError(statusBarLabel.Text);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                    pbOperationProgress.Visible = false;
                    panelMain.Enabled = true;
                }
            }
            else
            {
                pbOperationProgress.Visible = true;
                statusBarLabel.Text = "Імпорт даних з файлу пошуку";
                pbOperationProgress.Maximum = _radioPreSearchManager.ProgressMax;
                pbOperationProgress.Value = _radioPreSearchManager.Progress;
            }
        }
    }
}

