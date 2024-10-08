using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RadioStationReports
{
    public partial class FormMainRadio : Form
    {
        private const string splitTokens = " ,.;&|/\\";

        private RadioPreSearchManager _radioPreSearchManager;

        public FormMainRadio()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Configure();
        }

        private void Configure()
        {
            lvReportWorks.Columns.Clear();
            lvReportWorks.Columns.Add("№", 60);
            lvReportWorks.Columns.Add("Id", 60);
            lvReportWorks.Columns.Add("Назва", 260);
            lvReportWorks.Columns.Add("Автори", 260);
            lvReportWorks.Columns.Add("Виконавці", 260);
            lvReportWorks.Columns.Add("БД", 60);
            lvReportWorks.Columns.Add("Код", 60);
            lvReportWorks.Columns.Add("Проценти", 120);

            lvFoundWorks.Columns.Add("№", 60);
            lvFoundWorks.Columns.Add("Mark", 60);
            lvFoundWorks.Columns.Add("Id", 60);
            lvFoundWorks.Columns.Add("Назва", 260);
            lvFoundWorks.Columns.Add("Автори", 260);
            lvFoundWorks.Columns.Add("Виконавці", 260);
            lvFoundWorks.Columns.Add("Як і де знайдено", 100);

            cbReportWorksFilter.Items.Add("Всі записи звіту");
            cbReportWorksFilter.Items.Add("Записи із знайденими творами");
            cbReportWorksFilter.Items.Add("Записи із НЕ знайденими творами");
            cbReportWorksFilter.Items.Add("Записи визначені за автором-виконавцем");
            cbReportWorksFilter.SelectedIndex = 0;

            cbFoundWorksFilter.Items.Add("Всі записи");
            cbFoundWorksFilter.Items.Add("Лише визначені за автором-виконавцем");
            cbFoundWorksFilter.SelectedIndex = 0;

            var reps = RadioPreSearchManager.GetReportsList();
            reps.ForEach(x =>
            {
                cbReport.Items.Add(x);
            });
            if (cbReport.Items.Count > 0)
            {
                cbReport.SelectedIndex = 0;
            }
        }

        private void FillLvReportWorks()
        {
            lvReportWorks.Items.Clear();
            if(cbReport.SelectedIndex == -1)
            {
                return;
            }

            var reportId = int.Parse(cbReport.Text.Split(',')[0]);
            _radioPreSearchManager = new RadioPreSearchManager(reportId);
            var filter = RadioPreSearchManager.WorksFilter.all;
            switch (cbReportWorksFilter.SelectedIndex)
            {
                case 1: filter = RadioPreSearchManager.WorksFilter.hasMatches; break;
                case 2: filter = RadioPreSearchManager.WorksFilter.hasNoMatches; break;
                case 3: filter = RadioPreSearchManager.WorksFilter.hasStrongMatches; break;
            }

            var seqNr = 1;
            Helpers.RunSql(cmd =>
            {
                _radioPreSearchManager.LoadReportWorks(cmd, filter);
                _radioPreSearchManager.GetReportWorks().ForEach(x =>
                {
                    var item = lvReportWorks.Items.Add(seqNr.ToString());
                    item.SubItems.Add(x.Id.ToString());
                    item.SubItems.Add(x.Name);
                    item.SubItems.Add(x.Authors);
                    item.SubItems.Add(x.Performers);
                    item.SubItems.Add(x.FoundIn == null ? "" : x.FoundIn);
                    item.SubItems.Add(x.FoundCde == null ? "" : x.FoundCde.ToString());
                    item.SubItems.Add(x.Share == null ? "" : x.Share.ToString());
                    item.Tag = x;
                    seqNr++;
                });
            });
        }

        private void FillLvFoundWorks()
        {
            lvFoundWorks.Items.Clear();
            
            if(lvReportWorks.SelectedItems.Count == 0)
            {
                return;
            }

            var selectedReportWork = (Work)lvReportWorks.SelectedItems[0].Tag;
            Helpers.RunSql(cmd =>
            {
                _radioPreSearchManager.LoadMatchingWorks(cmd, selectedReportWork);
            });
            var seqNr = 1;
            selectedReportWork.MatchingWorks.ForEach(x =>
            {
                var shouldShow = cbFoundWorksFilter.SelectedIndex == 0 ||
                    cbFoundWorksFilter.SelectedIndex == 1 && x.IsMatchingAuthorPerformer;
                if (shouldShow)
                {
                    var item = lvFoundWorks.Items.Add(seqNr.ToString());
                    item.SubItems.Add(x.IsMatchingAuthorPerformer ? "+" : "");
                    item.SubItems.Add(x.FoundId.ToString());
                    item.SubItems.Add(x.Name);
                    item.SubItems.Add(x.Authors);
                    item.SubItems.Add(x.Performers);
                    item.SubItems.Add($"{x.FoundInDb}-{x.MainOrAlt}");
                    item.Tag = x;
                    seqNr++;
                }

            });
        }

        private void lvReportWorks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvReportWorks.SelectedItems.Count == 0)
            {
                lvFoundWorks.Items.Clear();
                return;
            }
            FillLvFoundWorks();
        }

        private bool SearchInFoundWork(string[] words, MatchingWork foundWork)
        {
            for (int idx = 0; idx < words.Length; idx++)
            {
                var word = words[idx].Trim();
                if (word.Length < 3)
                {
                    continue;
                }

                var foundAuthorsT = Translit.FromUkr(foundWork.Authors);
                var foundPerformersT = Translit.FromUkr(foundWork.Performers);

                if (foundWork.Authors.Contains(word) || foundWork.Performers.Contains(word)
                     || foundAuthorsT.Contains(word) || foundPerformersT.Contains(word))
                {
                    return true;
                }
            }
            return false;
        }
        private HashSet<MatchingWork> SearchInFoundWorks(Work reportWork)
        {
            var retVal = new HashSet<MatchingWork>();
            var authors = reportWork.Authors.Split(splitTokens);
            var performers = reportWork.Performers.Split(splitTokens);
            var authorsT = reportWork.AuthorsT.Split(splitTokens);
            var performersT = reportWork.PerformersT.Split(splitTokens);
            var words = authors
                .Union(performers)
                .Union(authorsT)
                .Union(performersT)
                .ToArray();
            reportWork.MatchingWorks.ForEach(x =>
            {
                if (SearchInFoundWork(words, x))
                {
                    retVal.Add(x);
                }
            });

            return retVal;
        }

        private void cbReportWorksFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillLvReportWorks();
        }

        private void cbFoundWorksFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_radioPreSearchManager != null)
            {
                FillLvFoundWorks();
            }
        }

        private void btnLoadFromFile_Click(object sender, EventArgs e)
        {
            if (openFileDlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            var fileFullName = openFileDlg.FileName;
            _radioPreSearchManager = new RadioPreSearchManager();

            try
            {
                _radioPreSearchManager.LoadReport(fileFullName);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Звіти Радіостанцій", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var reps = RadioPreSearchManager.GetReportsList();
            cbReport.Items.Clear();
            var selectedIndex = 0;
            var curIndex = 0;
            var fileName = Path.GetFileName(fileFullName);
            reps.ForEach(x =>
            {
                cbReport.Items.Add(x);
                if (x.Contains(fileName, StringComparison.OrdinalIgnoreCase))
                {
                    selectedIndex = curIndex;
                }
                curIndex++;
            });

            cbReport.SelectedIndex = selectedIndex;

            FillLvReportWorks();

            Cursor.Current = Cursors.Default;
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Створити вихідний файл?", "Звіти Радіостанцій", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            if (cbReport.SelectedIndex == -1)
            {
                MessageBox.Show("Не вибраний звіт", "Звіти Радіостанцій", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var reportId = int.Parse(cbReport.Text.Split(',')[0]);
            var inputFileName = "";
            var inputFilePath = "";

            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = "select FileName, FilePath from RadioStationReports..Reports where Id = @reportId";
                cmd.Parameters.AddWithValue("@reportId", reportId);
                using (var r = cmd.ExecuteReader())
                {
                    r.Read();
                    inputFileName = r.GetString(0);
                    inputFilePath = r.GetString(1);
                }
            });

            var inputFileFullName = Path.Combine(inputFilePath, inputFileName);
            if(!File.Exists(inputFileFullName))
            {
                MessageBox.Show($"Для створення вихідного файлу використовується завантажений вхідний файл {inputFileFullName}. Файл не знайдено!", "Звіти Радіостанцій", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var dlg = new SaveFileDialog();
            if(dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var outputFileFullName = dlg.FileName;

            if(inputFileFullName.Equals(outputFileFullName, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show($"Вибраний файл відповідає вхідному файлу звіту. Виберіть інший файл.", "Звіти Радіостанцій", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var excelConnector = new ExcelConnector();
            Cursor.Current = Cursors.WaitCursor;
            excelConnector.SaveReport(inputFileFullName, outputFileFullName, _radioPreSearchManager.GetReportId());
            Cursor.Current = Cursors.Default;

        }

        private void cbReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbReport.SelectedIndex == -1)
            {
                return;
            }
            FillLvReportWorks();
        }
    }
}
