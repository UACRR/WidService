using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DciAssessment
{
    public partial class DciSearchInMs : Form
    {
        private string[] _statusName =
        {
            "Необр",
            "Авт",
            "В ручну",
            "Не знайд",
            "Знайд лок",
        };

        private List<LocalWork> _localWorks;
        private List<ReportWork> _reportWorks;
        private List<FoundWork> _foundWorks;

        public DciSearchInMs()
        {
            InitializeComponent();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            lvReportWorks.Columns.Add("№", 40);
            lvReportWorks.Columns.Add("Назва", 300);
            lvReportWorks.Columns.Add("Iswc", 100);
            
            lvLocalWorks.Columns.Add("№", 40);
            lvLocalWorks.Columns.Add("Код", 60);
            lvLocalWorks.Columns.Add("Назва", 100);
            lvLocalWorks.Columns.Add("Автори", 200);
            lvLocalWorks.Columns.Add("Виконавці", 200);

            lvFoundWorks.Columns.Add("№", 40);
            lvFoundWorks.Columns.Add("Назва у звіті", 100);
            lvFoundWorks.Columns.Add("Iswc", 100);
            lvFoundWorks.Columns.Add("Локальна назва", 140);
            lvFoundWorks.Columns.Add("Локальні автори", 100);
            lvFoundWorks.Columns.Add("Локальні виконавці", 200);
            lvFoundWorks.Columns.Add("Статус", 200);


            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandText = $@"
                    select distinct WidAuthor 
                    from DciWorkToObjId
                    where Status = 0
                    order by WidAuthor
                ";
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        cbReportAuthor.Items.Add(r.GetString(0));
                    }
                    cbReportAuthor.SelectedIndex = 0;
                }
            });

            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandText = $@"
                    select distinct WidAuthor 
                    from DciWorkToObjId
                    order by WidAuthor
                ";
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        cbFoundWorkAuthor.Items.Add(r.GetString(0));
                    }
                    cbFoundWorkAuthor.SelectedItem = cbReportAuthor.Text;
                }
            });

            LoadReportWorks();
            //LoadLocalWorks();
            LoadFoundWorks();
        }

        private void LoadCoAuthors()
        {
            cbCoAuthors.Items.Clear();
            var curAuthor = cbFoundWorkAuthor.Text;
            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandText = @"
                    select distinct t1.WidAuthor
                    from DciWorkToObjId t1
                        join SocWid..widIntrPty t2 on t1.Wic = t2.Wic
                        join SocIpi..IpiName t3 on t2.IpNameNr = t3.IpNameNr
                    where concat(t3.Name, ' ', t3.FstName) = @author
                    order by t1.WidAuthor
                ";
                cmd.Parameters.AddWithValue("@author", curAuthor);
                using(var r = cmd.ExecuteReader())
                {
                    while(r.Read())
                    {
                        var coAuthor = r.GetString(0);
                        if (!coAuthor.Equals(curAuthor, StringComparison.OrdinalIgnoreCase))
                        {
                            cbCoAuthors.Items.Add(r.GetString(0));
                        }
                    }
                }
                if(cbCoAuthors.Items.Count > 0)
                {
                    cbCoAuthors.SelectedIndex = 0;
                }
            });
        }
        private void LoadFoundWorks()
        {
            lvFoundWorks.Items.Clear();
            _foundWorks = new List<FoundWork>();
            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandText = $@"
                    select top 1000
                          t1.WorkId                 as WorkId
                        , t1.objId	                as ObjId
                        , t1.WidName                as WidName
                        , t1.WidIswc                as Iswc
                        , t2.Name                   as LocalName
                        , t2.Author                 as LocalAuthor
                        , t2.Performer              as LocalPerformer
                        , t1.Status                 as Status
                    from DciWorkToObjId t1
                        left join MediaService..ObjectRight t2 on t1.ObjId = t2.ObjId
                    where t1.Status <> 0
                        and t1.WidAuthor = @Author
                    order by t1.WidName
                ";
                cmd.Parameters.AddWithValue("@Author", cbFoundWorkAuthor.Text);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        _foundWorks.Add(new FoundWork
                        {
                            WorkId = r.GetInt32(0),
                            ObjId = r.GetInt32(1),
                            WidName = r.IsDBNull(2) ? "" : r.GetString(2),
                            Iswc = r.IsDBNull(3) ? "" : r.GetString(3),
                            LocalName = r.IsDBNull(4) ? "" : r.GetString(4),
                            LocalAuthor = r.IsDBNull(5) ? "" : r.GetString(5),
                            LocalPerformer = r.IsDBNull(6) ? "" : r.GetString(6),
                            Status = r.GetInt32(7),
                        });
                    }
                }
            });

            lvFoundWorks.Items.Clear();
            var seqNr = 1;
            _foundWorks.ForEach(x =>
            {
                var item = lvFoundWorks.Items.Add(seqNr.ToString());
                item.SubItems.Add(x.WidName);
                item.SubItems.Add(x.Iswc);
                item.SubItems.Add(x.LocalName);
                item.SubItems.Add(x.LocalAuthor);
                item.SubItems.Add(x.LocalPerformer);
                item.SubItems.Add(_statusName[x.Status]);
                item.Tag = x;
                seqNr++;
            });
        }

        private void LoadLocalWorks()
        {
            if (string.IsNullOrEmpty(tbLocalWorksAuthor.Text))
            {
                return;
            }
            _localWorks = new List<LocalWork>();
            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandText = @"select top 1000 
                      objId
                    , name
                    , author
                    , performer 
                    from MediaService..ObjectRight
                    where author like @author
                        and ObjId not in (select ObjId from DciWorkToObjId)
                    order by name
                ";
                cmd.Parameters.AddWithValue("@author", $"%{tbLocalWorksAuthor.Text}%");
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        _localWorks.Add(new LocalWork
                        {
                            ObjId = r.GetInt32(0),
                            Name = r.IsDBNull(1) ? "" : r.GetString(1),
                            Author = r.IsDBNull(2) ? "" : r.GetString(2),
                            Performer = r.IsDBNull(3) ? "" : r.GetString(3),
                        });
                    }
                }
            });

            lvLocalWorks.Items.Clear();
            var seqNr = 1;
            _localWorks.ForEach(x =>
            {
                var item = lvLocalWorks.Items.Add(seqNr.ToString());
                item.SubItems.Add(x.ObjId.ToString());
                item.SubItems.Add(x.Name);
                item.SubItems.Add(x.Author);
                item.SubItems.Add(x.Performer);
                item.Tag = x;
                seqNr++;
            });
        }

        private void btnLocalWorksAuthorSearch_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadLocalWorks();
            Cursor.Current = Cursors.Default;
            //LoadFoundWorks();
        }

        private void LoadReportWorks()
        {
            lvReportWorks.Items.Clear();

            _reportWorks = new List<ReportWork>();
            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandText = $@"
                    select top 1000 
                          WorkId
                        , Wic
                        , SocWorkCde
                        , WidName
                        , WidIswc
                        , WidAuthor
                        , ObjId
                        , Status
                    from DciWorkToObjId 
                    where status = 0 
                        and WidAuthor = @WidAuthor
                    order by WidAuthor, WidName
                ";
                cmd.Parameters.AddWithValue("@WidAuthor", cbReportAuthor.Text);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        _reportWorks.Add(new ReportWork
                        {
                            WorkId = r.GetInt32(0),
                            Wic = r.GetInt32(1),
                            SocWorkCde = r.IsDBNull(2) ? "" : r.GetString(2),
                            WidName = r.IsDBNull(3) ? "" : r.GetString(3),
                            WidIswc = r.IsDBNull(4) ? "" : r.GetString(4),
                            WidAuthor = r.IsDBNull(5) ? "" : r.GetString(5),
                            ObjId = r.GetInt32(6),
                            Status = r.GetInt32(7),
                        });
                    }
                }
            });

            var seqNr = 1;
            _reportWorks.ForEach(x =>
            {
                var item = lvReportWorks.Items.Add(seqNr.ToString());
                item.SubItems.Add(x.WidName);
                item.SubItems.Add(x.WidIswc);
                item.Tag = x;
                seqNr++;
            });
        }

        private void btnReportWorksSearch_Click(object sender, EventArgs e)
        {
            LoadReportWorks();
        }

        private void lvReportWorks_DoubleClick(object sender, EventArgs e)
        {
            JoinWorks();
        }

        private void lvLocalWorks_DoubleClick(object sender, EventArgs e)
        {
            JoinWorks();
        }

        private void JoinWorks()
        {
            if (lvReportWorks.SelectedItems.Count == 0 || lvLocalWorks.SelectedItems.Count == 0)
            {
                return;
            }
            var reportWork = (ReportWork)lvReportWorks.SelectedItems[0].Tag;
            var localWork = (LocalWork)lvLocalWorks.SelectedItems[0].Tag;
            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandText = "update DciWorkToObjId set ObjId = @ObjId, status = 2 where WorkId = @WorkId";
                cmd.Parameters.AddWithValue("@WorkId", reportWork.WorkId);
                cmd.Parameters.AddWithValue("@ObjId", localWork.ObjId);
                cmd.ExecuteNonQuery();
            });

            /*
            var curItemIdx = lvReportWorks.SelectedItems[0].Index;
            lvReportWorks.Items.Remove(lvReportWorks.SelectedItems[0]);
            if(lvReportWorks.Items.Count > 0)
            {
                lvReportWorks.Items[curItemIdx].Selected = true;
            }

            var newFoundWork = new FoundWork
            {
                Id = reportWork.WorkId,
                ObjId = localWork.ObjId,
                LocalName = localWork.Name,
                ReportAlbumName = "",
                ReportName = reportWork.WidName,
                ReportAuthor = reportWork.WidAuthor,
                ReportPerformer = "",
            };

            _foundWorks.Add(newFoundWork);

            var item = lvFoundWorks.Items.Add((_foundWorks.Count + 1).ToString());
            item.SubItems.Add(newFoundWork.Id.ToString());
            item.SubItems.Add(newFoundWork.ObjId.ToString());
            item.SubItems.Add(newFoundWork.LocalName);
            item.SubItems.Add(newFoundWork.ReportAlbumName);
            item.SubItems.Add(newFoundWork.ReportName);
            item.SubItems.Add(newFoundWork.ReportAuthor);
            item.SubItems.Add(newFoundWork.ReportPerformer);
            item.Tag = newFoundWork;

            item.Selected = true;
            item.EnsureVisible();
            */


            AfterWorkProcessed();

        }

        private void AddProcessedWork()
        {
            var workId = ((ReportWork)lvReportWorks.SelectedItems[0].Tag).WorkId;
            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandText = $@"
                    select top 1000
                          t1.WorkId                 as WorkId
                        , t1.objId	                as ObjId
                        , t1.WidName                as WidName
                        , t1.WidIswc                as Iswc
                        , t2.Name                   as LocalName
                        , t2.Author                 as LocalAuthor
                        , t2.Performer              as LocalPerformer
                        , t1.Status                 as Status
                    from DciWorkToObjId t1
                        left join MediaService..ObjectRight t2 on t1.ObjId = t2.ObjId
                    where t1.Status <> 0
                        and t1.WorkId = @WorkId
                    order by t1.WidName
                ";
                cmd.Parameters.AddWithValue("@WorkId", workId);
                using (var r = cmd.ExecuteReader())
                {
                    r.Read();
                    _foundWorks.Add(new FoundWork
                    {
                        WorkId = r.GetInt32(0),
                        ObjId = r.GetInt32(1),
                        WidName = r.IsDBNull(2) ? "" : r.GetString(2),
                        Iswc = r.IsDBNull(3) ? "" : r.GetString(3),
                        LocalName = r.IsDBNull(4) ? "" : r.GetString(4),
                        LocalAuthor = r.IsDBNull(5) ? "" : r.GetString(5),
                        LocalPerformer = r.IsDBNull(6) ? "" : r.GetString(6),
                        Status = r.GetInt32(7),
                    });
                }
            });

            var foundWork = _foundWorks.Last();

            var seqNr = _foundWorks.Count;
            var item = lvFoundWorks.Items.Add(seqNr.ToString());
            item.SubItems.Add(foundWork.WidName);
            item.SubItems.Add(foundWork.Iswc);
            item.SubItems.Add(foundWork.LocalName);
            item.SubItems.Add(foundWork.LocalAuthor);
            item.SubItems.Add(foundWork.LocalPerformer);
            item.SubItems.Add(_statusName[foundWork.Status]);
            item.Tag = foundWork;
            item.Selected = true;
            item.EnsureVisible();
        }

        private void cbReportAuthor_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReportWorks();
            tbLocalWorksAuthor.Text = cbReportAuthor.Text;
            lvLocalWorks.Items.Clear();
            tbSearchText.Text = "";
            cbFoundWorkAuthor.SelectedItem = cbReportAuthor.Text;
        }

        private void btnSearchText_Click(object sender, EventArgs e)
        {
            lvLocalWorks.Items.Clear();
            var seqNr = 1;
            var txt = tbSearchText.Text.Trim();
            _localWorks.ForEach(x =>
            {
                if (txt == "" || x.Name.ToUpper().Contains(txt.ToUpper()))
                {
                    var item = lvLocalWorks.Items.Add(seqNr.ToString());
                    item.SubItems.Add(x.ObjId.ToString());
                    item.SubItems.Add(x.Name);
                    item.SubItems.Add(x.Author);
                    item.SubItems.Add(x.Performer);
                    item.Tag = x;
                    seqNr++; 
                }
            });
        }

        private void AfterWorkProcessed(bool keepLocalWork = false)
        {
            AddProcessedWork();
            var itemIdx = lvReportWorks.SelectedItems[0].Index;
            lvReportWorks.Items.RemoveAt(itemIdx);
            if (lvReportWorks.Items.Count != 0)
            {
                if(itemIdx < lvReportWorks.Items.Count)
                {
                    lvReportWorks.Items[itemIdx].Selected = true;
                }
                else
                {
                    lvReportWorks.Items[lvReportWorks.Items.Count - 1].Selected = true;
                }
            }
            else
            {
                var idx = cbReportAuthor.SelectedIndex;
                cbReportAuthor.Items.RemoveAt(idx);
                if (cbReportAuthor.Items.Count > 0)
                {
                    if (itemIdx < cbReportAuthor.Items.Count)
                    {
                        cbReportAuthor.SelectedIndex = idx;
                    }
                    else
                    {
                        cbReportAuthor.SelectedIndex = cbReportAuthor.Items.Count - 1;
                    }
                }
            }

            if(!keepLocalWork && lvLocalWorks.SelectedItems.Count > 0)
            {
                var idx = lvLocalWorks.SelectedItems[0].Index;
                lvLocalWorks.Items.RemoveAt(idx);
                if (lvLocalWorks.Items.Count != 0)
                {
                    if (itemIdx < lvLocalWorks.Items.Count)
                    {
                        lvLocalWorks.Items[idx].Selected = true;
                    }
                    else
                    {
                        lvLocalWorks.Items[lvLocalWorks.Items.Count - 1].Selected = true;
                    }
                }
            }
        }

        private void btnDisregard_Click(object sender, EventArgs e)
        {
            if(lvReportWorks.SelectedItems.Count == 0)
            {
                return;
            }
            var reportWork = (ReportWork)lvReportWorks.SelectedItems[0].Tag;
            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandText = "update DciWorkToObjId set objId = 0, status = 3 where WorkId = @WorkId";
                cmd.Parameters.AddWithValue("@WorkId", reportWork.WorkId);
                cmd.ExecuteNonQuery();
            });

            AfterWorkProcessed(true);
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            JoinWorks();
        }

        private void cbFoundWorkAuthor_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFoundWorks();
            LoadCoAuthors();
        }

        private void btnUnJoin_Click(object sender, EventArgs e)
        {
            if (lvFoundWorks.SelectedItems.Count == 0)
            {
                return;
            }
            var foundWork = (FoundWork)lvFoundWorks.SelectedItems[0].Tag;
            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandText = "update DciWorkToObjId set objId = 0, status = 0 where WorkId = @WorkId";
                cmd.Parameters.AddWithValue("@WorkId", foundWork.WorkId);
                cmd.ExecuteNonQuery();
            });

            var idx = lvFoundWorks.SelectedItems[0].Index;
            lvFoundWorks.Items.RemoveAt(idx);
            if (lvFoundWorks.Items.Count != 0)
            {
                if (idx < lvFoundWorks.Items.Count)
                {
                    lvFoundWorks.Items[idx].Selected = true;
                }
                else
                {
                    lvFoundWorks.Items[lvFoundWorks.Items.Count - 1].Selected = true;
                }
            }

            LoadReportWorks();
        }
    }
}
