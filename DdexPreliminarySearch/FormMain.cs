using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace DdexPreSearch
{
    public partial class FormMain : Form
    {
        private const string splitTokens = " ,.;&|/\\";

        private DdexPreSearchManager _ddexPreSearchManager;

        public FormMain()
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
            lvReportWorks.Columns.Add("Альбом", 260);
            lvReportWorks.Columns.Add("Назва", 260);
            lvReportWorks.Columns.Add("Автори", 260);
            lvReportWorks.Columns.Add("Виконавці", 260);

            lvFoundWorks.Columns.Add("№", 60);
            lvFoundWorks.Columns.Add("Mark", 60);
            lvFoundWorks.Columns.Add("Id", 60);
            lvFoundWorks.Columns.Add("Назва", 260);
            lvFoundWorks.Columns.Add("Автори", 260);
            lvFoundWorks.Columns.Add("Виконавці", 260);
            lvFoundWorks.Columns.Add("Як і де знайдено", 100);

            for(int i = 0; i < 50; i++)
            {
                cbBlock.Items.Add($"{i * 1000 + 1}-{(i + 1) * 1000}");
            }
            cbBlock.SelectedIndex = 0;

            cbReportWorksFilter.Items.Add("Всі записи блоку");
            cbReportWorksFilter.Items.Add("Записи із знайденими творами");
            cbReportWorksFilter.Items.Add("Записи із запропонованими творами");
            cbReportWorksFilter.SelectedIndex = 0;

            cbFoundWorksFilter.Items.Add("Всі записи");
            cbFoundWorksFilter.Items.Add("Лише запропоновані");
            cbFoundWorksFilter.SelectedIndex = 0;

            var reps = DdexPreSearchManager.GetReportsList();
            reps.ForEach(x =>
            {
                cbReport.Items.Add(x);
            });
            cbReport.SelectedIndex = 0;
        }

        private void LoadData()
        {
            var ddexReportId = int.Parse(cbReport.Text.Split(',')[0]);
            var block = cbBlock.SelectedIndex + 1;
            _ddexPreSearchManager = new DdexPreSearchManager(ddexReportId, block);
            _ddexPreSearchManager.PrepareData();
        }

        private void FillLvReportWorks()
        {
            lvReportWorks.Items.Clear();
            var seqNr = 1;
            _ddexPreSearchManager.GetReportWorks().ForEach(x =>
            {
                var showlShow = cbReportWorksFilter.SelectedIndex == 0 ||
                    cbReportWorksFilter.SelectedIndex == 1 && x.FoundWorks.Count > 0 ||
                    cbReportWorksFilter.SelectedIndex == 2 && x.HasMatchingWorks;
                if(showlShow)
                {
                    var item = lvReportWorks.Items.Add(seqNr.ToString());
                    item.SubItems.Add(x.MwId.ToString());
                    item.SubItems.Add(x.Album);
                    item.SubItems.Add(x.Name);
                    item.SubItems.Add(x.Authors);
                    item.SubItems.Add(x.Performers);
                    item.Tag = x;
                    seqNr++;
                }
            });
        }

        private void FillLvFoundWorks()
        {
            var selectedReportWork = (ReportWork)lvReportWorks.SelectedItems[0].Tag;
            tbFoundMarches.Text = selectedReportWork.FoundWorks.Count(x => x.IsMatching).ToString();
            lvFoundWorks.Items.Clear();
            var seqNr = 1;
            selectedReportWork.FoundWorks.ForEach(x =>
            {
                var shouldShow = cbFoundWorksFilter.SelectedIndex == 0 ||
                    cbFoundWorksFilter.SelectedIndex == 1 && x.IsMatching;
                if(shouldShow)
                {
                    var item = lvFoundWorks.Items.Add(seqNr.ToString());
                    item.SubItems.Add(x.IsMatching ? "+" : "");
                    item.SubItems.Add(x.FoundId.ToString());
                    item.SubItems.Add(x.Name);
                    item.SubItems.Add(x.Authors);
                    item.SubItems.Add(x.Performers);
                    item.SubItems.Add($"{x.SourceCol}-{x.TargetDb}-{x.TargetTbl}");
                    item.Tag = x;
                    seqNr++;
                }

            });
        }

        private void lvReportWorks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvReportWorks.SelectedItems.Count == 0)
            {
                lvFoundWorks.Items.Clear();
                return;
            }
            var selectedReportWork = (ReportWork)lvReportWorks.SelectedItems[0].Tag;
            FillLvFoundWorks();
        }

        private bool SearchInFoundWork(string[] words, FoundWork foundWork)
        {
            for (int idx = 0; idx < words.Length; idx++)
            {
                var word = words[idx].Trim();
                if(word.Length < 3)
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
        private HashSet<FoundWork> SearchInFoundWorks(ReportWork reportWork)
        {
            var retVal = new HashSet<FoundWork>();
            var authors = reportWork.Authors.Split(splitTokens);
            var performers = reportWork.Performers.Split(splitTokens);
            var authorsT = reportWork.AuthorsT.Split(splitTokens);
            var performersT = reportWork.PerformersT.Split(splitTokens);
            var words = authors
                .Union(performers)
                .Union(authorsT)
                .Union(performersT)
                .ToArray();
            reportWork.FoundWorks.ForEach(x =>
            {
                if(SearchInFoundWork(words, x))
                {
                    retVal.Add(x);
                }
            });

            return retVal;
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadData();
            FillLvReportWorks();
            Cursor.Current = Cursors.Default;
        }

        private void cbReportWorksFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_ddexPreSearchManager != null)
            { 
                FillLvReportWorks(); 
            }
        }

        private void cbFoundWorksFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_ddexPreSearchManager != null)
            {
                FillLvFoundWorks();
            }
        }
    }
}
