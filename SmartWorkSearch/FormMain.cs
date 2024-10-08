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
    public partial class FormMain : Form
    {
        private List<LocalWork> _localWorks;
        private List<ReportWork> _reportWorks;
        private List<FoundWork> _foundWorks;

        public FormMain()
        {
            InitializeComponent();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            lvLocalWorks.Columns.Add("№", 40);
            lvLocalWorks.Columns.Add("Код", 60);
            lvLocalWorks.Columns.Add("Назва", 100);
            lvLocalWorks.Columns.Add("Автори", 200);
            lvLocalWorks.Columns.Add("Виконавці", 200);

            lvReportWorks.Columns.Add("№", 40);
            lvReportWorks.Columns.Add("Код", 60);
            lvReportWorks.Columns.Add("Назва альбому", 100);
            lvReportWorks.Columns.Add("Назва", 100);
            lvReportWorks.Columns.Add("Автори", 200);
            lvReportWorks.Columns.Add("Виконавці", 200);

            lvFoundWorks.Columns.Add("№", 40);
            lvFoundWorks.Columns.Add("Код в звіті", 80);
            lvFoundWorks.Columns.Add("Локальний код", 100);
            lvFoundWorks.Columns.Add("Локальна назва", 100);
            lvFoundWorks.Columns.Add("Назва альбому в звіті", 140);
            lvFoundWorks.Columns.Add("Назва в звіті", 100);
            lvFoundWorks.Columns.Add("Автори в звіті", 200);
            lvFoundWorks.Columns.Add("Виконавці в звіті", 200);

            /*
            Helpers.RunSqlSmartWorkSearch(cmd =>
            {
                cmd.CommandText = "select top 1 * from FilterValues order by Id desc";
                using(var r = cmd.ExecuteReader())
                {
                    r.Read();
                    if(r.HasRows)
                    {
                        tbLocalWorksAuthor.Text = r.GetString(1);
                        tbReportFilterName.Text = r.GetString(2);
                        tbReportFilterAuthor.Text = r.GetString(3);
                        tbReportFilterPerformer.Text = r.GetString(4);
                    }
                }
            });
            */

            LoadLocalWorks();
            LoadReportWorks();
            LoadFoundWorks();
        }

        private void LoadFoundWorks()
        {
            lvFoundWorks.Items.Clear();
            if (_localWorks == null)
            {
                return;
            }
            _foundWorks = new List<FoundWork>();
            var inTxt = "0";
            _localWorks.ForEach(x =>
            {
                inTxt += $", {x.ObjId}";
            });
            Helpers.RunSqlSmartWorkSearch(cmd =>
            {
                cmd.CommandText = $@"
                    select top 1000
                          t2.Id
                        , t1.objId
                        , t1.name
                        , t2.ResourceTitle
                        , t2.Title
                        , t2.ComposerAuthor
                        , t2.DisplayArtistName
                    from ObjectRight t1
                        join IdentMw t2 on t1.ObjId = t2.ObjId
                    where t1.ObjId in ({inTxt})
                    order by t1.name
                ";
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        _foundWorks.Add(new FoundWork
                        {
                            Id = r.GetInt32(0),
                            ObjId = r.GetInt32(1),
                            LocalName = r.IsDBNull(2) ? "" : r.GetString(2),
                            ReportAlbumName = r.IsDBNull(3) ? "" : r.GetString(3),
                            ReportName = r.IsDBNull(4) ? "" : r.GetString(4),
                            ReportAuthor = r.IsDBNull(5) ? "" : r.GetString(5),
                            ReportPerformer = r.IsDBNull(6) ? "" : r.GetString(6),
                        });
                    }
                }
            });

            lvFoundWorks.Items.Clear();
            var seqNr = 1;
            _foundWorks.ForEach(x =>
            {
                var item = lvFoundWorks.Items.Add(seqNr.ToString());
                item.SubItems.Add(x.Id.ToString());
                item.SubItems.Add(x.ObjId.ToString());
                item.SubItems.Add(x.LocalName);
                item.SubItems.Add(x.ReportAlbumName);
                item.SubItems.Add(x.ReportName);
                item.SubItems.Add(x.ReportAuthor);
                item.SubItems.Add(x.ReportPerformer);
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
            Helpers.RunSqlSmartWorkSearch(cmd =>
            {
                cmd.CommandText = "select top 1000 objId, name, author, performer from ObjectRight where author like @author order by name";
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
            LoadLocalWorks();
            LoadFoundWorks();
            AddFilterValues();
        }

        private void LoadReportWorks()
        {
            var nameFilterTxt = "";
            if (!string.IsNullOrEmpty(tbReportFilterName.Text))
            {
                var oper = tbReportFilterName.Text.Contains('%') ? "like" : "=";
                nameFilterTxt = $"(ResourceTitle {oper} @name or Title {oper} @name)";
            }

            var authorFilterTxt = "";
            if (!string.IsNullOrEmpty(tbReportFilterAuthor.Text))
            {
                var oper = tbReportFilterAuthor.Text.Contains('%') ? "like" : "=";
                authorFilterTxt = $"ComposerAuthor {oper} @author";
            }

            var performerFilterTxt = "";
            if (!string.IsNullOrEmpty(tbReportFilterPerformer.Text))
            {
                var oper = tbReportFilterPerformer.Text.Contains('%') ? "like" : "=";
                performerFilterTxt = $"DisplayArtistName {oper} @performer";
            }

            var totalFilter = "";
            if (nameFilterTxt != "")
            {
                totalFilter += nameFilterTxt;
            }

            if (authorFilterTxt != "")
            {
                if (totalFilter != "")
                {
                    totalFilter += " and ";
                }
                totalFilter += authorFilterTxt;
            }

            if (performerFilterTxt != "")
            {
                if (totalFilter != "")
                {
                    totalFilter += " and ";
                }
                totalFilter += performerFilterTxt;
            }

            lvReportWorks.Items.Clear();

            if (totalFilter == "")
            {
                return;
            }

            _reportWorks = new List<ReportWork>();
            Helpers.RunSqlSmartWorkSearch(cmd =>
            {
                cmd.CommandText = $@"
                    select top 1000 
                          Id
                        , ResourceTitle
                        , Title
                        , ComposerAuthor
                        , DisplayArtistName
                    from IdentMw 
                    where status <> 2 and {totalFilter}
                    order by Title, ResourceTitle
                ";
                cmd.Parameters.AddWithValue("@name", tbReportFilterName.Text);
                cmd.Parameters.AddWithValue("@author", tbReportFilterAuthor.Text);
                cmd.Parameters.AddWithValue("@performer", tbReportFilterPerformer.Text);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        _reportWorks.Add(new ReportWork
                        {
                            Id = r.GetInt32(0),
                            AlbumName = r.IsDBNull(1) ? "" : r.GetString(1),
                            Name = r.IsDBNull(2) ? "" : r.GetString(2),
                            Author = r.IsDBNull(3) ? "" : r.GetString(3),
                            Performer = r.IsDBNull(4) ? "" : r.GetString(4),
                        });
                    }
                }
            });

            var seqNr = 1;
            _reportWorks.ForEach(x =>
            {
                var item = lvReportWorks.Items.Add(seqNr.ToString());
                item.SubItems.Add(x.Id.ToString());
                item.SubItems.Add(x.AlbumName);
                item.SubItems.Add(x.Name);
                item.SubItems.Add(x.Author);
                item.SubItems.Add(x.Performer);
                item.Tag = x;
                seqNr++;
            });
        }

        private void btnReportWorksSearch_Click(object sender, EventArgs e)
        {
            LoadReportWorks();
            AddFilterValues();
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
            if(lvLocalWorks.SelectedItems.Count == 0 || lvReportWorks.SelectedItems.Count == 0)
            {
                return;
            }
            var localWork = (LocalWork)lvLocalWorks.SelectedItems[0].Tag;
            var reportWork = (ReportWork)lvReportWorks.SelectedItems[0].Tag;

            Helpers.RunSqlSmartWorkSearch(cmd =>
            {
                cmd.CommandText = "update IdentMw set objId = @objId, status = 2 where Id = @Id";
                cmd.Parameters.AddWithValue("@objId", localWork.ObjId);
                cmd.Parameters.AddWithValue("@Id", reportWork.Id);
                cmd.ExecuteNonQuery();
            });

            var curItemIdx = lvReportWorks.SelectedItems[0].Index;
            lvReportWorks.Items.Remove(lvReportWorks.SelectedItems[0]);
            if(lvReportWorks.Items.Count > 0)
            {
                lvReportWorks.Items[curItemIdx].Selected = true;
            }

            var newFoundWork = new FoundWork
            {
                Id = reportWork.Id,
                ObjId = localWork.ObjId,
                LocalName = localWork.Name,
                ReportAlbumName = reportWork.AlbumName,
                ReportName = reportWork.Name,
                ReportAuthor = reportWork.Author,
                ReportPerformer = reportWork.Performer,
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
        }

        private void AddFilterValues()
        {
            Helpers.RunSqlSmartWorkSearch(cmd =>
            {
                cmd.CommandText = @"
                    insert FilterValues (LocalName, ReportName, ReportAuthor, ReportPerformer) 
                    values (@LocalName, @ReportName, @ReportAuthor, @ReportPerformer)
                ";
                cmd.Parameters.AddWithValue("@LocalName", tbLocalWorksAuthor.Text == null ? "" : tbLocalWorksAuthor.Text);
                cmd.Parameters.AddWithValue("@ReportName", tbReportFilterName.Text == null ? "" : tbReportFilterName.Text);
                cmd.Parameters.AddWithValue("@ReportAuthor", tbReportFilterAuthor.Text == null ? "" : tbReportFilterAuthor.Text);
                cmd.Parameters.AddWithValue("@ReportPerformer", tbReportFilterPerformer.Text == null ? "" : tbReportFilterPerformer.Text);
                cmd.ExecuteNonQuery();
            });
        }
    }
}
