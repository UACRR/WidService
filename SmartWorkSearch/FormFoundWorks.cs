using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartWorkSearch
{
    public partial class FormFoundWorks : Form
    {
        private class Found
        {
            public int ParentSeqNr { get; set; }
            public int SourceWorkId { get; set; }
            public int FoundWorkId { get; set; }
            public int MasterObjId { get; set; }
            public string FoundName { get; set; }
            public string FoundAuthors { get; set; }
            public string FoundPerformers { get; set; }
            public string FoundIn { get; set; }
            public int FoundCde { get; set; }
            public DateTime ValidFrom { get; set; }
            public DateTime ValidTo { get; set; }
            public DateTime CreatedAt { get; set; }
        }
        private class SourceAndFound
        {
            public int SeqNr { get; set; }
            public int SourceWorkId { get; set; }
            public string SourceName { get; set; }
            public string SourceAuthors { get; set; }
            public string SourcePerformers { get; set; }

            public List<Found> Found { get; set; }
        }

        private List<SourceAndFound> _sourceAndFound;
        
        public FormFoundWorks()
        {
            InitializeComponent();
        }

        private void FormFoundWorks_Load(object sender, EventArgs e)
        {
            ConfigureGrid();
            ReadData();
            FillGrid();

            /*
            dgvFoundWorks.Rows.Add(1, "Означення", "Name", "Authors", "Performers", "");
            dgvFoundWorks.Rows.Add("", 13221, "Namse", "Authasors", "Perforsssmers", "WID", 211423, "від 1900-01-01 до 1999-12-31");

            dgvFoundWorks.Rows.Add(2, "Означення", "Name", "Authors", "Performers", "");
            dgvFoundWorks.Rows.Add("", 13221, "Namse", "Authasors", "Perforsssmers", "MS", 25542, "від 1900-01-01 до 1999-12-31");
            */
        }

        private void ConfigureGrid()
        {
            AddGridColumn("SeqNrCol",  "№", 50);
            AddGridColumn("ObjIdCol", "Головний Код", 100);
            AddGridColumn("NameCol", "Назва", 200);
            AddGridColumn("AuthorsCol", "Автори", 200);
            AddGridColumn("PerformersCol", "Виконавці", 200);
            AddGridColumn("FoundInCol", "Знайдено в", 100);
            AddGridColumn("FoundCdeCol", "Знайдений код", 100);
            AddGridColumn("ValidFromCol", "Починаючи з", 100);
            AddGridColumn("ValidЕщCol", "Закінчуючи", 100);
        }

        private void AddGridColumn(string name, string headerText, int width)
        {
            dgvFoundWorks.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = headerText,
                Name = name,
                ReadOnly = true,
                Width = width,
                SortMode = DataGridViewColumnSortMode.NotSortable,
            });
        }
    
        private void ReadData()
        {
            _sourceAndFound = new List<SourceAndFound>();
            Helpers.RunSqlSmartWorkSearch(cmd =>
            {
                cmd.CommandText = $@"
                    select top 1000
                          t1.Id as SourceWorkId
                        , t2.Id		as FoundWorkId
                        , t2.objId  as MasterObjId
                        , t1.name	as SourceName
                        , t1.Authors as SourceAuthors
                        , t1.Performers as SourcePerformers
                        , t2.Name as FoundName
                        , t2.Authors as FoundAuthors
                        , t2.Performers as FoundPerformers
                        , t2.FoundIn as FoundIn
                        , t2.FoundCde as FoundCde
                        , t2.ValidFrom as ValidFrom
                        , t2.ValidTo as ValidTo
                        , t2.CreatedAt as CreatedAt
                    from SourceWorks t1
                        join FoundWorks t2 on t1.Id = t2.SourceWorkId
                    order by t1.Id, t2.ValidFrom desc
                ";
                SourceAndFound curSourceAndFound = null;
                var curSourceWorkId = 0;
                var seqNr = 0;
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        seqNr++;
                        curSourceWorkId = r.GetInt32(0);
                        if (curSourceAndFound == null || curSourceAndFound.SourceWorkId != curSourceWorkId)
                        {
                            curSourceAndFound = new SourceAndFound
                            {
                                SeqNr = seqNr,
                                SourceWorkId = curSourceWorkId,
                                SourceName = r.GetString(3),
                                SourceAuthors = r.GetString(4),
                                SourcePerformers = r.GetString(5),
                                Found = new List<Found>(),
                            };
                            _sourceAndFound.Add(curSourceAndFound);
                        }
                        var found = curSourceAndFound.Found;
                        found.Add(new Found {
                             ParentSeqNr             =  seqNr,
                             SourceWorkId             = curSourceAndFound.SourceWorkId,
                             FoundWorkId             = r.GetInt32(1),
                             MasterObjId            = r.IsDBNull(2) ? 0 : r.GetInt32(2),
                             FoundName              = r.GetString(6),
                             FoundAuthors           = r.GetString(7),
                             FoundPerformers        = r.GetString(8),
                             FoundIn                = r.GetString(9),
                             FoundCde               = r.GetInt32(10),
                             ValidFrom              = r.GetDateTime(11),
                             ValidTo                = r.GetDateTime(12),
                             CreatedAt              = r.GetDateTime(13),
                        });
                    }
                }
            });
        }

        private void FillGrid()
        {
            dgvFoundWorks.Rows.Clear();
            var seqNr = 1;
            _sourceAndFound.ForEach(x =>
            {
                var rowIdx = dgvFoundWorks.Rows.Add(seqNr, "", x.SourceName, x.SourceAuthors, x.SourcePerformers);
                dgvFoundWorks.Rows[rowIdx].Tag = x;
                x.Found.ForEach(y =>
                {
                    rowIdx = dgvFoundWorks.Rows.Add("", y.MasterObjId, y.FoundName, y.FoundAuthors, y.FoundPerformers, y.FoundIn, y.FoundCde,
                        y.ValidFrom.ToString("yyyy.MM.dd"), y.ValidTo.ToString("yyyy.MM.dd"));
                    dgvFoundWorks.Rows[rowIdx].Tag = y;
                });
                seqNr++;
            });
        }

        private void dgvFoundWorks_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dgvFoundWorks.Rows[e.RowIndex];
            var tag = row.Tag;
            int workIdx;
            if (tag.GetType() == typeof(SourceAndFound))
            {
                workIdx = (tag as SourceAndFound).SeqNr;
            }
            else
            {
                workIdx = (tag as Found).ParentSeqNr;
            }

            if (dgvFoundWorks.SelectedCells.Count != 0)
            {
                var selectedCell = dgvFoundWorks.SelectedCells[0];
                var selectedRow = dgvFoundWorks.Rows[selectedCell.RowIndex];
                var selectedTag = selectedRow.Tag;
                int selectedWorkIdx;
                if (selectedTag.GetType() == typeof(SourceAndFound))
                {
                    selectedWorkIdx = (selectedTag as SourceAndFound).SeqNr;
                }
                else
                {
                    selectedWorkIdx = (selectedTag as Found).ParentSeqNr;
                }
                if(workIdx == selectedWorkIdx)
                {
                    row.DefaultCellStyle.ForeColor = Color.White;
                    row.DefaultCellStyle.BackColor = Color.FromArgb(0, 134, 139);
                    return;
                }
            }

            if (workIdx % 2 == 0)
            {
                row.DefaultCellStyle.ForeColor = Color.Black;
                row.DefaultCellStyle.BackColor = Color.Beige; 
            }
            else
            {
                row.DefaultCellStyle.ForeColor = Color.Black;
                row.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void mnuItemShowReports_Click(object sender, EventArgs e)
        {
            if(dgvFoundWorks.SelectedCells.Count == 0)
            {
                return;
            }

            var selectedCell = dgvFoundWorks.SelectedCells[0];
            var selectedRow = dgvFoundWorks.Rows[selectedCell.RowIndex];
            var selectedTag = selectedRow.Tag;
            int sourceWorkId;
            if (selectedTag.GetType() == typeof(SourceAndFound))
            {
                sourceWorkId = (selectedTag as SourceAndFound).SourceWorkId;
            }
            else
            {
                sourceWorkId = (selectedTag as Found).SourceWorkId;
            }

            var sourceWork = _sourceAndFound.Single(x => x.SourceWorkId == sourceWorkId);
            var form = new FormSourceWorkReports(sourceWorkId/*I11252*/, sourceWork.SourceName, sourceWork.SourceAuthors, sourceWork.SourcePerformers);
            form.ShowDialog();
        }

        private void dgvFoundWorks_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dgvFoundWorks.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
            }
        }
    }
}
