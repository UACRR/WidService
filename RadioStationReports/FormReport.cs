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
using static System.Net.Mime.MediaTypeNames;

namespace RadioStationReports
{
    public partial class FormReport : Form
    {
        const int FILTER_INDEX_SMART = 1;
        const int FILTER_INDEX_WID = 2;
        const int FILTER_INDEX_NOT_FOUND = 3;

        private bool _cbFilterIgnoreSelectedIndexChanged;
        private bool _actionsVisible;

        private bool _ignoreCodeChangedEvent = false;

        private Report _report;
        private List<ReportLine> _reportLines;

        private RadioPreSearchManager _radioPreSearchManager = new RadioPreSearchManager();
        private bool _importSearchFileInProgress = false;

        private string _textToCopy = "";

        public FormReport(Report report)
        {
            InitializeComponent();
            _report = report;
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            _actionsVisible = false;

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

            lvReportLines.Columns.Add("Номер рядка", 90);
            lvReportLines.Columns.Add("Назва твору", 200);
            lvReportLines.Columns.Add("Виконавці", 200);
            lvReportLines.Columns.Add("Де знайдено", 90);
            lvReportLines.Columns.Add("Знайдений код", 100);
            lvReportLines.Columns.Add("Код ISWC", 80);

            var formWidth = 44;
            foreach (ColumnHeader col in lvReportLines.Columns)
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
            labAutoSearch.Text = "Автоматичний пошук";

            labAutoSearchStatus.Text = "Автоматичний пошук виконаний";
            labAutoSearchStatus.Visible = _report.AutoSearchFinishedAt != null;

            btnAutoSearch.Visible = _report.AutoSearchFinishedAt == null;

            /*
            btnCalcRoyalty.Visible = _report.AutoSearchFinishedAt != null
                && (_report.CalcRoyaltyFinishedAt == null || _report.CalcRoyaltyFinishedAt < _report.UpdatedAt);

            labCalcShareStatus.Visible = !btnCalcRoyalty.Visible;
            labCalcShareStatus.Text = _report.AutoSearchFinishedAt == null ?
                "Виконайте сперше автоматичний пошук" : "Розрахунок для поточних даних виконаний";
            */

            btnCalcRoyalty.Visible = true;
            labCalcShareStatus.Visible = false;

            tbSearchFileName.Text = _report.SearchFileName;

            btnCreateSearchFile.Enabled = _report.AutoSearchFinishedAt != null
                && (_report.SearchFileCreatedAt == null
                    ||
                    (_report.SearchFileUpdatedAt < _report.UpdatedAt
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
                && (_report.DistributionFileCreatedAt == null
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
            if (cbFilter.SelectedIndex == FILTER_INDEX_SMART)
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

                using (var r = cmd.ExecuteReader())
                {
                    _reportLines = new List<ReportLine>();
                    while (r.Read())
                    {
                        var reportLine = new ReportLine();
                        var idx = 2; // Пропускаємо Id і ReportId

                        reportLine.LineNr = r.GetInt32(idx++);
                        reportLine.Name = r.GetString(idx++);
                        reportLine.Performer = r.GetString(idx++);
                        reportLine.MusicAuthor = r.GetString(idx++);
                        reportLine.TextAuthor = r.GetString(idx++);
                        reportLine.Duration = r.GetString(idx++);
                        reportLine.CountUses = r.GetString(idx++);
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
                item.SubItems.Add(x.Name);
                item.SubItems.Add(x.Performer);
                item.SubItems.Add(x.Work.FoundIn);
                item.SubItems.Add(x.Work.FoundCde.ToString());
                item.SubItems.Add(x.Work.Iswc);
                item.Tag = x;

            });

        }

        private void UpdateLvReportLine()
        {
            var item = GetSelectedItem();
            if (item == null)
            {
                return;
            }

            var line = GetSelectedLine();

            item.SubItems[1].Text = line.Name;
            item.SubItems[2].Text = line.Performer;
            item.SubItems[3].Text = line.Work.FoundIn;
            item.SubItems[4].Text = line.Work.FoundCde.ToString();
            item.SubItems[5].Text = line.Work.Iswc;
        }

        private void FillLabLinesCnt()
        {
            labLinesCnt.Text = $"(кількість рядків {lvReportLines.Items.Count})";
        }

        private ReportLine GetSelectedLine()
        {
            var item = GetSelectedItem();
            if (item != null)
            {
                return (ReportLine)item.Tag;
            }
            else
            {
                return null;
            }
        }
        private void UpdateCodeEditControls(string ChangedCodeField)
        {
            _ignoreCodeChangedEvent = true;
            var line = GetSelectedLine();
            if (line == null)
            {
                tbObjId.Text = "";
                tbWic.Text = "";
                tbIswc.Text = "";
                tbObjId.Enabled = false;
                tbWic.Enabled = false;
                tbIswc.Enabled = false;
                btnApplyCode.Enabled = false;
                btnCancelCode.Enabled = false;
            }

            else if (ChangedCodeField == "NONE")
            {
                tbObjId.Text = line.Work.FoundIn == "M" ? line.Work.FoundCde.ToString() : "";
                tbWic.Text = line.Work.FoundIn == "W" ? line.Work.FoundCde.ToString() : "";
                tbIswc.Text = line.Work.Iswc;
                tbObjId.Enabled = true;
                tbWic.Enabled = true;
                tbIswc.Enabled = true;
                btnApplyCode.Enabled = false;
                btnCancelCode.Enabled = false;
            }

            else if (ChangedCodeField == "SMART")
            {
                tbWic.Text = "";
                tbIswc.Text = "";
                btnApplyCode.Enabled = true;
                btnCancelCode.Enabled = true;
            }

            else if (ChangedCodeField == "WID")
            {
                tbObjId.Text = "";
                tbIswc.Text = "";
                btnApplyCode.Enabled = true;
                btnCancelCode.Enabled = true;
            }

            else if (ChangedCodeField == "ISWC")
            {
                tbObjId.Text = "";
                tbWic.Text = "";
                btnApplyCode.Enabled = true;
                btnCancelCode.Enabled = true;
            }

            _ignoreCodeChangedEvent = false;
        }

        private string SetObjId(string objId)
        {
            var line = GetSelectedLine();

            int objIdInt;
            if (!int.TryParse(objId, out objIdInt))
            {
                return "Невірне значення - мусить бути цілим числом.";
            }

            var res = "";
            Helpers.RunSqlT(cmd =>
            {
                cmd.CommandText = "select ObjId from MediaService..ObjectRight where ObjId = @ObjId";
                cmd.Parameters.AddWithValue("@ObjId", objIdInt);
                var foundObjId = Convert.ToInt32(cmd.ExecuteScalar());
                if (foundObjId == 0)
                {
                    res = "Невірне значення - твір з таким кодом не знайдено.";
                    return;
                }

                cmd.CommandText = @"
                    update Works set FoundIn = 'M', FoundCde = @ObjId where Id = @Id
                    update Reports set UpdatedAt = getdate() where Id = @ReportId
                ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ObjId", objIdInt);
                cmd.Parameters.AddWithValue("@Id", line.Work.Id);
                cmd.Parameters.AddWithValue("@ReportId", _report.Id);
                cmd.ExecuteNonQuery();

                cmd.CommandText = "select Iswc from MediaService..MediaTrack where ObjId = @ObjId";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ObjId", objIdInt);
                var iswc = Convert.ToString(cmd.ExecuteScalar());
                if (string.IsNullOrEmpty(iswc))
                {
                    iswc = "";
                }

                cmd.CommandText = "update Works set Iswc = @Iswc where Id = @Id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Iswc", iswc);
                cmd.Parameters.AddWithValue("@Id", line.Work.Id);
                cmd.ExecuteNonQuery();

                line.Work.FoundIn = "M";
                line.Work.FoundCde = foundObjId;
                line.Work.Iswc = iswc;

            });
            return res;
        }

        private string SetWic(string wic)
        {
            var line = GetSelectedLine();

            int wicInt;
            if (!int.TryParse(wic, out wicInt))
            {
                return "Невірне значення - мусить бути цілим числом.";
            }

            var res = "";
            Helpers.RunSqlT(cmd =>
            {
                cmd.CommandText = "select Wic from SocWid..WidTitle where Wic = @Wic";
                cmd.Parameters.AddWithValue("@Wic", wicInt);
                var foundWic = Convert.ToInt32(cmd.ExecuteScalar());
                if (foundWic == 0)
                {
                    res = "Невірне значення - твір з таким кодом не знайдено.";
                    return;
                }

                cmd.CommandText = @"
                    update Works set FoundIn = 'W', FoundCde = @Wic where Id = @Id
                    update Reports set UpdatedAt = getdate() where Id = @ReportId
                ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Wic", wicInt);
                cmd.Parameters.AddWithValue("@Id", line.Work.Id);
                cmd.Parameters.AddWithValue("@ReportId", _report.Id);
                cmd.ExecuteNonQuery();

                cmd.CommandText = "select min(PrefIswc) from SocWid..WidIswc where Wic = @Wic";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Wic", wicInt);
                var iswc = Convert.ToString(cmd.ExecuteScalar());
                if (string.IsNullOrEmpty(iswc))
                {
                    iswc = "";
                }

                cmd.CommandText = "update Works set Iswc = @Iswc where Id = @Id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Iswc", iswc);
                cmd.Parameters.AddWithValue("@Id", line.Work.Id);
                cmd.ExecuteNonQuery();

                line.Work.FoundIn = "W";
                line.Work.FoundCde = foundWic;
                line.Work.Iswc = iswc;

            });
            return res;
        }

        private string SetIswc(string iswc)
        {
            var line = GetSelectedLine();

            var res = "";
            iswc = iswc.Replace("-", "");
            iswc = iswc.Replace(".", "");
            Helpers.RunSqlT(cmd =>
            {
                cmd.CommandText = "select min(Wic) from SocWid..WidIswc where Iswc = @Iswc";
                cmd.Parameters.AddWithValue("@Iswc", iswc);
                var foundWic = Convert.ToInt32(cmd.ExecuteScalar());
                if (foundWic == 0)
                {
                    res = "Невірне значення - твір з таким кодом не знайдено.";
                    return;
                }

                cmd.CommandText = @"
                    update Works set FoundIn = 'W', FoundCde = @Wic where Id = @Id
                    update Reports set UpdatedAt = getdate() where Id = @ReportId
                ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Wic", foundWic);
                cmd.Parameters.AddWithValue("@Id", line.Work.Id);
                cmd.Parameters.AddWithValue("@ReportId", _report.Id);
                cmd.ExecuteNonQuery();

                cmd.CommandText = "update Works set Iswc = @Iswc where Id = @Id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Iswc", iswc);
                cmd.Parameters.AddWithValue("@Id", line.Work.Id);
                cmd.ExecuteNonQuery();

                line.Work.FoundIn = "W";
                line.Work.FoundCde = foundWic;
                line.Work.Iswc = iswc;

            });
            return res;
        }

        private string SetNotFound()
        {
            var line = GetSelectedLine();

            var res = "";
            Helpers.RunSqlT(cmd =>
            {
                cmd.CommandText = @"
                    update Works set FoundIn = null, FoundCde = null, Iswc = null where Id = @Id
                    update Reports set UpdatedAt = getdate() where Id = @ReportId
                ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Id", line.Work.Id);
                cmd.Parameters.AddWithValue("@ReportId", _report.Id);
                cmd.ExecuteNonQuery();

                line.Work.FoundIn = null;
                line.Work.FoundCde = null;
                line.Work.Iswc = null;
            });
            return res;
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
            catch (Exception ex)
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

            var line = GetSelectedLine();
            var lineNr = 0;
            if(line != null)
            {
                lineNr = line.LineNr;
            }

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
                FillLvReportLines();

                foreach(ListViewItem item in lvReportLines.Items)
                {
                    if(((ReportLine)item.Tag).LineNr == lineNr)
                    {
                        item.Selected = true;
                        return;
                    }
                }

                UpdateControls();

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
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
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                Helpers.ShowError($"{ex.Message} Можливо, файл відкритий в додатку Ексель. Закрийте файл і спробуйте ще раз.");
                return;
            }

            Helpers.ShowSuccess($"Файл створено/оновлено - {Path.Combine(_report.WorkFilesPath, _report.SearchFileName)}");

        }

        private void btnShowSearchFile_Click(object sender, EventArgs e)
        {
            var fileFullName = RadioPreSearchManager.GetSearchFileFullName(_report);
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
                var thread = new Thread(() =>
                {
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
            catch (Exception ex)
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
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                Helpers.ShowError(ex.Message);
                return;
            }

            Helpers.ShowSuccess($"File created - {Path.Combine(_report.WorkFilesPath, _report.DistributionFileName)}");

        }

        private void btnShowDistributionFile_Click(object sender, EventArgs e)
        {
            var fileFullName = RadioPreSearchManager.GetDistributionFileFullName(_report);
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
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                Helpers.ShowError(ex.Message);
                return;
            }

            Helpers.ShowSuccess($"Проценти вирівняні, файл {Path.Combine(_report.WorkFilesPath, _report.DistributionFileName)}");
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cbFilterIgnoreSelectedIndexChanged)
            {
                return;
            }

            ucReportLineWork.Clear();
            ucReportLineDistribution.Clear();
            LoadReportLines();
            FillLvReportLines();
            FillLabLinesCnt();
        }

        private void lvReportLines_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = GetSelectedItem();
            if (selectedItem == null)
            {
                ucReportLineWork.Clear();
                ucReportLineDistribution.Clear();
                UpdateCodeEditControls("NONE");
                return;
            }

            UpdateCodeEditControls("NONE");

            var reportLine = (ReportLine)selectedItem.Tag;
            ucReportLineWork.Update(_report.Id, reportLine.LineNr);
            ucReportLineDistribution.Update(_report.Id, reportLine.LineNr);
        }

        private void btnShowHideActions_Click(object sender, EventArgs e)
        {
            _actionsVisible = !_actionsVisible;
            UpdateControls();
        }

        private void timerImportSearchFileProgress_Tick(object sender, EventArgs e)
        {
            if (!_radioPreSearchManager.IsInProgress)
            {
                timerImportSearchFileProgress.Enabled = false;
                if (_radioPreSearchManager.ErrorText != "")
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
                catch (Exception ex)
                {
                    statusBarLabel.Text = $"ПОМИЛКА: {ex.Message}";
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

        private void tbObjId_TextChanged(object sender, EventArgs e)
        {
            if (_ignoreCodeChangedEvent)
            {
                return;
            }

            UpdateCodeEditControls("SMART");
        }

        private void tbWic_TextChanged(object sender, EventArgs e)
        {
            if (_ignoreCodeChangedEvent)
            {
                return;
            }

            UpdateCodeEditControls("WID");
        }

        private void tbIswc_TextChanged(object sender, EventArgs e)
        {
            if (_ignoreCodeChangedEvent)
            {
                return;
            }

            UpdateCodeEditControls("ISWC");
        }

        private void btnApplyCode_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current= Cursors.WaitCursor;
                var res = "";
                if (tbObjId.Text.Trim() != "")
                {
                    res = SetObjId(tbObjId.Text.Trim());
                }
                else if (tbWic.Text.Trim() != "")
                {
                    res = SetWic(tbWic.Text.Trim());
                }
                else if (tbIswc.Text.Trim() != "")
                {
                    res = SetIswc(tbIswc.Text.Trim());
                }
                else
                {
                    res = SetNotFound();
                }

                if (!string.IsNullOrEmpty(res))
                {
                    Helpers.ShowError(res);
                    UpdateCodeEditControls("NONE");
                    return;
                }
                else
                {
                    UpdateLvReportLine();
                }

                var line = GetSelectedLine();

                var radioPreSearchManager = new RadioPreSearchManager(_report.Id);
                radioPreSearchManager.RecalcShares(line.LineNr);

                ucReportLineWork.Update(_report.Id, line.LineNr);
                ucReportLineDistribution.Update(_report.Id, line.LineNr);
                UpdateCodeEditControls("NONE");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Застосування коду твору", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
 

        }

        private void btnCancelCode_Click(object sender, EventArgs e)
        {
            UpdateCodeEditControls("NONE");
        }

        private void lvReportLines_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = lvReportLines.GetItemAt(e.X, e.Y);
                if (item == null)
                {
                    return;
                }
                var text = item.GetSubItemAt(e.X, e.Y).Text;
                _textToCopy = string.IsNullOrEmpty(text) ? "" : text;
                contextMenuStrip.Show(lvReportLines, new Point(e.X, e.Y), ToolStripDropDownDirection.BelowRight);
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
    }
}

