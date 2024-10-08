using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppleSearch
{
    public partial class FormMain : Form
    {
        private List<SuccessSearchParams> _successSearchParams;
        private List<HistAuthor> _histAuthors = new List<HistAuthor>();
        private List<HistAuthorFilter> _histAuthorFilters = new List<HistAuthorFilter>();

        private List<LocalWork> _localWorks = new List<LocalWork>();
        private List<ReportWork> _reportWorks = new List<ReportWork>();
        private List<FoundWork> _foundWorks = new List<FoundWork>();

        private int _custId;
        private string _localAuthorName;

        private bool _ignoreSelectedIndexChanged = false;

        public FormMain()
        {
            InitializeComponent();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            lvLocalWorks.Columns.Add("№", 40);
            lvLocalWorks.Columns.Add("Код", 60);
            lvLocalWorks.Columns.Add("Знайдено", 80);
            lvLocalWorks.Columns.Add("Назва", 100);
            lvLocalWorks.Columns.Add("Автори", 200);
            lvLocalWorks.Columns.Add("Виконавці", 200);

            lvReportWorks.Columns.Add("№", 40);
            lvReportWorks.Columns.Add("Код в звіті", 60);
            lvReportWorks.Columns.Add("Локальний Код", 60);
            lvReportWorks.Columns.Add("Назва", 100);
            lvReportWorks.Columns.Add("Автори", 200);
            lvReportWorks.Columns.Add("Виконавці", 200);
            lvReportWorks.Columns.Add("Назва альбому", 100);
            
            lvFoundWorks.Columns.Add("№", 40);
            lvFoundWorks.Columns.Add("Код в звіті", 80);
            lvFoundWorks.Columns.Add("Локальний код", 100);
            lvFoundWorks.Columns.Add("Локальна назва", 100);
            lvFoundWorks.Columns.Add("Назва в звіті", 100);
            lvFoundWorks.Columns.Add("Автори в звіті", 200);
            lvFoundWorks.Columns.Add("Виконавці в звіті", 200);
            lvFoundWorks.Columns.Add("Назва альбому в звіті", 140);

            //LoadSuccessSearchParams();
            LoadHistAuthors();
            //LoadLocalWorks();
            //LoadReportWorks();
            //LoadFoundWorks();
            ApplyLayout();
        }

        private void LoadHistAuthorFilters()
        {
            _histAuthorFilters = new List<HistAuthorFilter>();
            Helpers.RunSqlApple(cmd =>
            {
                cmd.CommandText = @"
                        select top 30 * 
                        from HistAuthorFilter
                        where CustId = @CustId
                        order by LastUsedAt desc";
                cmd.Parameters.AddWithValue("@CustId", _custId);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        _histAuthorFilters.Add(new HistAuthorFilter
                        {
                            Id = r.GetInt32(0),
                            CustId = r.GetInt32(1),
                            WorkName = r.IsDBNull(2) ? "" : r.GetString(2),
                            WorkAuthor = r.IsDBNull(3) ? "" : r.GetString(3),
                            WorkPerformer = r.IsDBNull(4) ? "" : r.GetString(4),
                            LastUsedAt = r.GetDateTime(5),
                        });
                    }
                }
            });

            menuStripHistAuthorFilter.DropDownItems.Clear();
            var itemIdx = 0;
            _histAuthorFilters.ForEach(x =>
            {
                var menuItem = new ToolStripMenuItem();
                menuItem.Name = $"i{itemIdx}";
                menuItem.Size = new Size(280, 22);
                menuItem.Text = x.GetDisplayText();
                menuItem.Click += new EventHandler(HistAuthorFilterMenuItem_Click);
                menuItem.Tag = x;

                menuStripHistAuthorFilter.DropDownItems.Add(menuItem);
            });
        }

        private void LoadHistAuthors()
        {
            _histAuthors = new List<HistAuthor>();
            Helpers.RunSqlApple(cmd =>
            {
                cmd.CommandText = "select top 30 * from HistAuthor order by LastUsedAt desc";
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        _histAuthors.Add(new HistAuthor
                        {
                            CustId = r.GetInt32(0),
                            Name = r.IsDBNull(1) ? "" : r.GetString(1),
                            LastUsedAt = r.GetDateTime(2),
                        });
                    }
                }
            });

            cbHistAuthors.Items.Clear();
            _histAuthors.ForEach(x =>
            {
                cbHistAuthors.Items.Add(x.Name);
            });

            if (cbHistAuthors.Items.Count > 0)
            {
                cbHistAuthors.SelectedIndex = 0;
                var histAuthor = _histAuthors[0];
                _custId = histAuthor.CustId;
                _localAuthorName = histAuthor.Name;
            }
        }
        private void LoadLocalWorks()
        {
            if (string.IsNullOrEmpty(_localAuthorName))
            {
                return;
            }
            _localWorks = new List<LocalWork>();
            Helpers.RunSqlApple(cmd =>
            {
                cmd.CommandText = @"
                    ; with ObjIds as (
                        select distinct objId
                        from MediaService..Authors
                        where CustId = @custId
                        union
                        select distinct objId
                        from MediaService..CopyRight
                        where CustId = @custId
                    )
                    select 
                         t1.objId
                       , sum(case when t2.ObjId is null then 0 else 1 end) as found
                       , t1.name
                       , t1.author
                       , t1.performer
                   from MediaService..ObjectRight t1
                        left join AppleContentReport t2 on t1.objId = t2.ObjId
                    where t1.objId in (select objId from ObjIds)
                    group by t1.objId, t1.name, t1.author, t1.performer
                    order by name
                ";
                cmd.Parameters.AddWithValue("@custId", _custId);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        _localWorks.Add(new LocalWork
                        {
                            ObjId = r.GetInt32(0),
                            Found = r.GetInt32(1),
                            Name = r.IsDBNull(2) ? "" : r.GetString(2),
                            Author = r.IsDBNull(3) ? "" : r.GetString(3),
                            Performer = r.IsDBNull(4) ? "" : r.GetString(4),
                        });
                    }
                }
            });

            tbLocalSearchLeft.Text = "";
            FillLocalWorks();

            labFoundWorksTitle.Text = $"Знайдені твори - {_localAuthorName}";
        }

        private void FillLocalWorks()
        {
            lvLocalWorks.Items.Clear();
            var seqNr = 1;
            var searchTxt = tbLocalSearchLeft.Text;
            _localWorks.ForEach(x =>
            {
                var shouldAdd = string.IsNullOrEmpty(searchTxt)
                    || x.Name.ToUpper().Contains(searchTxt.ToUpper())
                    || x.Author.ToUpper().Contains(searchTxt.ToUpper())
                    || x.Performer.ToUpper().Contains(searchTxt.ToUpper())
                ;
                if (shouldAdd)
                {
                    var item = lvLocalWorks.Items.Add(seqNr.ToString());
                    item.SubItems.Add(x.ObjId.ToString());
                    item.SubItems.Add(x.Found.ToString());
                    item.SubItems.Add(x.Name);
                    item.SubItems.Add(x.Author);
                    item.SubItems.Add(x.Performer);
                    item.ImageIndex = x.Found == 0 ? 0 : 2;
                    item.Tag = x;
                    seqNr++;
                }
            });

        }

        private void LoadReportWorks()
        {
            var nameFilterTxt = "";
            if (!string.IsNullOrEmpty(tbReportFilterName.Text))
            {
                var oper = tbReportFilterName.Text.Contains('%') ? "like" : "=";
                nameFilterTxt = $"(AlbumTitle {oper} @name or TrackTitle {oper} @name)";
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
                performerFilterTxt = $"TrackPrimaryArtist {oper} @performer";
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
            Helpers.RunSqlApple(cmd =>
            {
                cmd.CommandText = $@"
                    select top 1000 
                          TrackDspId as Id
                        , AlbumTitle as ResourceTitle
                        , TrackTitle as Title
                        , ComposerAuthor as ComposerAuthor
                        , TrackPrimaryArtist as DisplayArtistName
                        , ObjId as ObjId
                    from AppleContentReport 
                    where {totalFilter}
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
                            Id = r.GetString(0),
                            AlbumName = r.IsDBNull(1) ? "" : r.GetString(1),
                            Name = r.IsDBNull(2) ? "" : r.GetString(2),
                            Author = r.IsDBNull(3) ? "" : r.GetString(3),
                            Performer = r.IsDBNull(4) ? "" : r.GetString(4),
                            ObjId = r.IsDBNull(5) ? (int?)null : r.GetInt32(5),
                        });
                    }
                }
            });

            tbLocalSearchRight.Text = "";
            FillReportWorks();
        }

        private void FillReportWorks()
        {
            lvReportWorks.Items.Clear();
            var seqNr = 1;
            var searchTxt = tbLocalSearchRight.Text;
            _reportWorks.ForEach(x =>
            {
                var shouldAdd = string.IsNullOrEmpty(searchTxt) ||
                    x.Name.ToUpper().Contains(searchTxt.ToUpper()) ||
                    x.AlbumName.ToUpper().Contains(searchTxt.ToUpper()) ||
                    x.Author.ToUpper().Contains(searchTxt.ToUpper()) ||
                    x.Performer.ToUpper().Contains(searchTxt.ToUpper());
                if (shouldAdd)
                {
                    var item = lvReportWorks.Items.Add(seqNr.ToString());
                    item.SubItems.Add(x.Id.ToString());
                    item.SubItems.Add(x.ObjId == null ? "" : x.ObjId.ToString());
                    item.SubItems.Add(x.Name);
                    item.SubItems.Add(x.Author);
                    item.SubItems.Add(x.Performer);
                    item.SubItems.Add(x.AlbumName);
                    item.ImageIndex = x.ObjId == null ? 0 : 2;
                    item.Tag = x;
                    seqNr++;
                }
            });

        }

        private void LoadFoundWorks()
        {
            lvFoundWorks.Items.Clear();
            if (_localWorks == null)
            {
                return;
            }
            _foundWorks = new List<FoundWork>();
            Helpers.RunSqlApple(cmd =>
            {
                cmd.CommandText = $@"
                    ; with ObjIds as (
                        select distinct objId
                        from MediaService..Authors
                        where CustId = @custId
                    )
                    select top 1000
                          t2.TrackDspId as Id
                        , t1.objId
                        , t1.name               as name
                        , t2.AlbumTitle         as ResourceTitle
                        , t2.TrackTitle         as Title
                        , t2.ComposerAuthor     as ComposerAuthor
                        , t2.TrackPrimaryArtist as DisplayArtistName
                    from MediaService..ObjectRight t1
                        join AppleContentReport t2 on t1.ObjId = t2.ObjId
                    where t1.ObjId in (select ObjId from ObjIds)
                    order by t1.name
                ";
                cmd.Parameters.AddWithValue("@custId", _custId);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        _foundWorks.Add(new FoundWork
                        {
                            Id = r.GetString(0),
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
                item.SubItems.Add(x.ReportName);
                item.SubItems.Add(x.ReportAuthor);
                item.SubItems.Add(x.ReportPerformer);
                item.SubItems.Add(x.ReportAlbumName);
                item.Tag = x;
                seqNr++;
            });
        }

        private void btnLocalWorksAuthorSearch_Click(object sender, EventArgs e)
        {
            var form = new FormSelectAuthor();
            form.ShowDialog();
            
            if(form.CustId == null)
            {
                return;
            }

            using (var wc = new WaitCursor())
            {
                _localAuthorName = form.AuthorName;
                _custId = (int)form.CustId;
                UpdateHistAuthor();
                LoadLocalWorks();
                LoadFoundWorks();
            }
        }

        private void btnReportWorksSearch_Click(object sender, EventArgs e)
        {
            using(var wc = new WaitCursor())
            {
                LoadReportWorks();
            }
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

            var localWorkItem = lvLocalWorks.SelectedItems[0];
            var reportWorkItem = lvReportWorks.SelectedItems[0];
            JoinWorks(localWorkItem, reportWorkItem);

        }

        private void JoinWorks(ListViewItem localWorkItem, ListViewItem reportWorkItem)
        {
            var localWork = (LocalWork)localWorkItem.Tag;
            var reportWork = (ReportWork)reportWorkItem.Tag;

            if (reportWork.ObjId != null)
            {
                return;
            }

            Helpers.RunSqlApple(cmd =>
            {
                cmd.CommandText = "update AppleContentReport set objId = @objId where cast(TrackDspId as bigint) = @Id";
                cmd.Parameters.AddWithValue("@objId", localWork.ObjId);
                cmd.Parameters.AddWithValue("@Id", reportWork.Id);
                cmd.ExecuteNonQuery();
            });

            reportWorkItem.ImageIndex = 2;
            reportWorkItem.SubItems[2].Text = localWork.ObjId.ToString();
            reportWork.ObjId = localWork.ObjId;

            localWork.Found++;
            localWorkItem.SubItems[2].Text = localWork.Found.ToString();
            localWorkItem.ImageIndex = 2;

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
            item.SubItems.Add(newFoundWork.ReportName);
            item.SubItems.Add(newFoundWork.ReportAuthor);
            item.SubItems.Add(newFoundWork.ReportPerformer);
            item.SubItems.Add(newFoundWork.ReportAlbumName);
            item.Tag = newFoundWork;

            item.Selected = true;
            item.EnsureVisible();

            //UpdateHistAuthor();
            UpdateHistAuthorFilter();

        }

        private void UpdateHistAuthor()
        {
            Helpers.RunSqlApple(cmd =>
            {
                cmd.CommandText = @"
                    if not exists (
                        select null from HistAuthor where CustId = @CustId
                    )
                    begin
                        insert into HistAuthor (CustId, Name, LastUsedAt) 
                        values (@CustId, @LocalAuthor, getdate())

                        select @CustId
                    end
                    else
                    begin
                        update HistAuthor
                        set LastUsedAt  = getdate()
                        where CustId = @CustId

                        select 0
                    end
                ";
                cmd.Parameters.AddWithValue("@CustId", _custId);
                cmd.Parameters.AddWithValue("@LocalAuthor", _localAuthorName == null ? "" : _localAuthorName);
                var res = Convert.ToInt32(cmd.ExecuteScalar());

                var oldHistAuthorIdx = -1;
                for(int i = 0; i < _histAuthors.Count; i++)
                {
                    if(_histAuthors[i].CustId == _custId)
                    {
                        oldHistAuthorIdx = i;
                        break;
                    }
                }
                if(oldHistAuthorIdx != -1)
                {
                    cbHistAuthors.Items.RemoveAt(oldHistAuthorIdx);
                    _histAuthors.RemoveAt(oldHistAuthorIdx);
                }
                
                _histAuthors.Insert(0, new HistAuthor
                {
                    CustId = _custId,
                    Name = _localAuthorName,
                    LastUsedAt = DateTime.Now,
                });
                var histAuthor = _histAuthors[0];
                cbHistAuthors.Items.Insert(0, histAuthor.Name);

                _ignoreSelectedIndexChanged = true;
                cbHistAuthors.SelectedIndex = 0;
                _ignoreSelectedIndexChanged = false;
            });
        }

        private void UpdateHistAuthorFilter()
        {
            Helpers.RunSqlApple(cmd =>
            {
                cmd.CommandText = @"
                    if not exists (
                        select null 
                        from HistAuthorFilter 
                        where
                                CustId         = @CustId
                            and WorkName       = @WorkName
                            and WorkAuthor     = @WorkAuthor
                            and WorkPerformer  = @WorkPerformer
                    )
                    begin
                        insert into HistAuthorFilter (
                              CustId
                            , WorkName
                            , WorkAuthor
                            , WorkPerformer
                            , LastUsedAt
                        ) 
                        values (
                              @CustId
                            , @WorkName
                            , @WorkAuthor
                            , @WorkPerformer
                            , getdate()
                        )

                        select scope_identity()
                    end
                    else
                    begin
                        update HistAuthorFilter
                        set
                            LastUsedAt  = getdate()
                        where
                                CustId          = @CustId
                            and WorkName       = @WorkName
                            and WorkAuthor     = @WorkAuthor
                            and WorkPerformer  = @WorkPerformer

                        select 0
                    end
                ";
                cmd.Parameters.AddWithValue("@CustId", _custId);
                cmd.Parameters.AddWithValue("@WorkName", tbReportFilterName.Text == null ? "" : tbReportFilterName.Text);
                cmd.Parameters.AddWithValue("@WorkAuthor", tbReportFilterAuthor.Text == null ? "" : tbReportFilterAuthor.Text);
                cmd.Parameters.AddWithValue("@WorkPerformer", tbReportFilterPerformer.Text == null ? "" : tbReportFilterPerformer.Text);
                var res = Convert.ToInt32(cmd.ExecuteScalar());
                if (res != 0)
                {
                    _histAuthorFilters.Insert(0, new HistAuthorFilter
                    {
                        Id = res,
                        CustId = _custId,
                        WorkName = tbReportFilterName.Text,
                        WorkAuthor = tbReportFilterAuthor.Text,
                        WorkPerformer = tbReportFilterPerformer.Text,
                        LastUsedAt = DateTime.Now,
                    });
                    var histAuthorFilter = _histAuthorFilters[0];
                    var menuItem = new ToolStripMenuItem();
                    menuItem.Name = $"i{_histAuthorFilters.Count}";
                    menuItem.Size = new Size(280, 22);
                    menuItem.Text = histAuthorFilter.GetDisplayText();
                    menuItem.Click += new EventHandler(HistAuthorFilterMenuItem_Click);
                    menuItem.Tag = histAuthorFilter;

                    menuStripHistAuthorFilter.DropDownItems.Add(menuItem);
                }
            });
        }
        private void btnJoinSelectedReportWorks_Click(object sender, EventArgs e)
        {
            List<ListViewItem> leadItems = new List<ListViewItem>();
            List<ListViewItem> depItems = new List<ListViewItem>();

            foreach(ListViewItem item in lvReportWorks.SelectedItems)
            {
                var reportWork = (ReportWork)item.Tag;
                if(reportWork.ObjId == null)
                {
                    depItems.Add(item);
                }
                else
                {
                    leadItems.Add(item);
                }
            }

            var objIds = leadItems.Select(x => ((ReportWork)x.Tag).ObjId).Distinct().ToList();
            if(objIds.Count != 1)
            {
                return;
            }

            var objId = objIds[0];
            var localName = "";
            Helpers.RunSqlApple(cmd =>
            {
                cmd.CommandText = "select name from MediaService..ObjectRight where objId = @objId";
                cmd.Parameters.AddWithValue("@objId", objId);
                localName = (string)cmd.ExecuteScalar();
            });

            depItems.ForEach(depItem => {
                var reportWork = (ReportWork)depItem.Tag;
                Helpers.RunSqlApple(cmd =>
                {
                    cmd.CommandText = "update AppleContentReport set objId = @objId where cast(TrackDspId as bigint) = @Id";
                    cmd.Parameters.AddWithValue("@objId", objId);
                    cmd.Parameters.AddWithValue("@Id", reportWork.Id);
                    cmd.ExecuteNonQuery();
                });

                depItem.ImageIndex = 2;
                depItem.SubItems[2].Text = objId.ToString();
                reportWork.ObjId = objId;

                foreach(ListViewItem curItem in lvLocalWorks.Items)
                {
                    var curLocalWork = (LocalWork)curItem.Tag;
                    if(curLocalWork.ObjId == objId)
                    {
                        curLocalWork.Found++;
                        curItem.SubItems[2].Text = curLocalWork.Found.ToString();
                        curItem.ImageIndex = 2;
                    }
                }
                

                var newFoundWork = new FoundWork
                {
                    Id = reportWork.Id,
                    ObjId = (int)objId,
                    LocalName = localName,
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
            });
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveLayout();
        }

        private void SaveLayout()
        {
            Helpers.RunSqlApple(cmd =>
            {
                cmd.CommandText = "delete from FormLayout";
                cmd.ExecuteNonQuery();
            });
            SaveLayoutProp("FormTop", Top);
            SaveLayoutProp("FormLeft", Left);
            SaveLayoutProp("FormWidth", Width);
            SaveLayoutProp("FormHeight", Height);
            SaveLayoutProp("FormState", (int)WindowState);

            SaveLayoutProp("MainSplitDist", splitMain.SplitterDistance);
            SaveLayoutProp("TopSplitDist", splitTop.SplitterDistance);

            for (var idx = 0; idx < lvLocalWorks.Columns.Count; idx++)
            {
                var col = lvLocalWorks.Columns[idx];
                SaveLayoutProp($"LocalColW_{idx}", col.Width);
            }

            for (var idx = 0; idx < lvReportWorks.Columns.Count; idx++)
            {
                var col = lvReportWorks.Columns[idx];
                SaveLayoutProp($"ReportColW_{idx}", col.Width);
            }

            for (var idx = 0; idx < lvFoundWorks.Columns.Count; idx++)
            {
                var col = lvFoundWorks.Columns[idx];
                SaveLayoutProp($"FoundColW_{idx}", col.Width);
            }
        }
        private void SaveLayoutProp(string propName, int val)
        {
            Helpers.RunSqlApple(cmd =>
            {
                cmd.CommandText = "insert FormLayout values(@prop, @val)";
                cmd.Parameters.AddWithValue("@prop", propName);
                cmd.Parameters.AddWithValue("@val", val);
                cmd.ExecuteNonQuery();
            });
        }

        private void ApplyLayout()
        {
            try
            {
                var props = new Dictionary<string, int>();
                Helpers.RunSqlApple(cmd =>
                {
                    cmd.CommandText = "select Prop, Val from FormLayout";
                    using(var r = cmd.ExecuteReader())
                    {
                        while(r.Read())
                        {
                            props.Add(r.GetString(0), r.GetInt32(1));
                        }
                    }
                });

                if (props.ContainsKey("FormTop")) Top     = props["FormTop"];
                if (props.ContainsKey("FormLeft")) Left    = props["FormLeft"];
                if (props.ContainsKey("FormWidth")) Width   = props["FormWidth"];
                if (props.ContainsKey("FormHeight")) Height  = props["FormHeight"];
                if (props.ContainsKey("FormState")) WindowState = (FormWindowState)props["FormState"];

                if (props.ContainsKey("MainSplitDist")) splitMain.SplitterDistance = props["MainSplitDist"];
                if (props.ContainsKey("TopSplitDist")) splitTop.SplitterDistance = props["TopSplitDist"];

                for (var idx = 0; idx < lvLocalWorks.Columns.Count; idx++)
                {
                    var col = lvLocalWorks.Columns[idx];
                    var key = $"LocalColW_{idx}";
                    if (props.ContainsKey(key)) col.Width = props[key];
                }

                for (var idx = 0; idx < lvReportWorks.Columns.Count; idx++)
                {
                    var col = lvReportWorks.Columns[idx];
                    var key = $"ReportColW_{idx}";
                    if (props.ContainsKey(key)) col.Width = props[key];
                }

                for (var idx = 0; idx < lvFoundWorks.Columns.Count; idx++)
                {
                    var col = lvFoundWorks.Columns[idx];
                    var key = $"FoundColW_{idx}";
                    if (props.ContainsKey(key)) col.Width = props[key];
                }

            }
            catch(Exception)
            {

            }

        }

        private void btnDisjoin_Click(object sender, EventArgs e)
        {
            if(lvFoundWorks.SelectedItems.Count == 0)
            {
                return;
            }

            var foundWorksItem = lvFoundWorks.SelectedItems[0];
            var foundWork = (FoundWork)foundWorksItem.Tag;

            Helpers.RunSqlApple(cmd =>
            {
                cmd.CommandText = "update AppleContentReport set objId = null where TrackDspId = @Id";
                cmd.Parameters.AddWithValue("@Id", foundWork.Id);
                cmd.ExecuteReader();
            });

            _foundWorks.Remove(foundWork);
            lvFoundWorks.Items.Remove(foundWorksItem);
            LoadLocalWorks();
            LoadReportWorks();
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            if (lvLocalWorks.SelectedItems.Count == 0 || lvReportWorks.SelectedItems.Count == 0)
            {
                return;
            }

            var localWorkItem = lvLocalWorks.SelectedItems[0];
            foreach(ListViewItem reportWorkItem in lvReportWorks.SelectedItems)
            {
                JoinWorks(localWorkItem, reportWorkItem);
            }
        }

        private void btnAutoJoin_Click(object sender, EventArgs e)
        {
            using (var wc = new WaitCursor())
            {
                LoadLocalWorks();
                LoadFoundWorks();
                UpdateHistAuthor();
                var idToObjId = new Dictionary<string, int>();
                var hasFound = false;
                _reportWorks.Where(x => x.ObjId == null).ToList().ForEach(reportWork =>
                {
                    foreach (var localWork in _localWorks)
                    {
                        if (Translit.FromUkr(reportWork.Name).Equals(Translit.FromUkr(localWork.Name), StringComparison.OrdinalIgnoreCase))
                        {
                            idToObjId.Add(reportWork.Id, localWork.ObjId);
                            hasFound = true;
                            break;
                        }
                    }
                });
                Helpers.RunSqlApple(cmd =>
                {
                    cmd.CommandText = "update AppleContentReport set objId = @objId where TrackDspId = @Id";
                    foreach (var pair in idToObjId)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Id", pair.Key);
                        cmd.Parameters.AddWithValue("@objId", pair.Value);
                        cmd.ExecuteNonQuery();
                    }
                });
                LoadLocalWorks();
                LoadReportWorks();
                LoadFoundWorks();
                if(hasFound)
                {
                    UpdateHistAuthorFilter();
                }
            }
        }

        private void btnShowLocalWork_Click(object sender, EventArgs e)
        {
            if (lvReportWorks.SelectedItems.Count == 0)
            {
                return;
            }
            var reportWork = (ReportWork)lvReportWorks.SelectedItems[0].Tag;
            var msgTxt = "";
            Helpers.RunSqlApple(cmd =>
            {
                cmd.CommandText = "select name, author, performer from MediaService..ObjectRight where objId = @objId";
                cmd.Parameters.AddWithValue("@objId", reportWork.ObjId);
                using(var r = cmd.ExecuteReader())
                {
                    r.Read();
                    msgTxt = $"Назва: {r.GetString(0)}\r\n";
                    if(!r.IsDBNull(1)) msgTxt += $"Автор(и): {r.GetString(1)}\r\n";
                    if (!r.IsDBNull(2)) msgTxt += $"Виконавець: {r.GetString(2)}\r\n";
                }
            });
            MessageBox.Show(msgTxt, "Локальний твір");
        }

        private void btnLocalSearchRight_Click(object sender, EventArgs e)
        {
            FillReportWorks();
        }

        private void btnLocalSearchRightCancel_Click(object sender, EventArgs e)
        {
            tbLocalSearchRight.Text = "";
            FillReportWorks();
        }

        private void btnLocalSearchLeft_Click(object sender, EventArgs e)
        {
            FillLocalWorks();
        }

        private void btnLocalSearchLeftCancel_Click(object sender, EventArgs e)
        {
            tbLocalSearchLeft.Text = "";
            FillLocalWorks();
        }

        private void cbHistAuthors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(_ignoreSelectedIndexChanged)
            {
                return;
            }
            var histAuthor = _histAuthors[cbHistAuthors.SelectedIndex];
            _custId = histAuthor.CustId;
            _localAuthorName = histAuthor.Name;
            using (var wc = new WaitCursor())
            {
                LoadLocalWorks();
                LoadFoundWorks();
                UpdateHistAuthor();
                LoadHistAuthorFilters();
            }
        }

        private void HistAuthorFilterMenuItem_Click(object sender, EventArgs e)
        {
            var histAuthorFilter = (HistAuthorFilter)((ToolStripMenuItem)sender).Tag;
            tbReportFilterName.Text = histAuthorFilter.WorkName;
            tbReportFilterAuthor.Text = histAuthorFilter.WorkAuthor;
            tbReportFilterPerformer.Text = histAuthorFilter.WorkPerformer;
            LoadReportWorks();
        }

        private void tbLocalSearchLeft_Enter(object sender, EventArgs e)
        {
            tbLocalSearchLeft.SelectAll();
            tbLocalSearchLeft.Focus();
        }

        private void tbLocalSearchLeft_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                FillLocalWorks();
                if (e.Control)
                {
                    lvLocalWorks.Select();
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void lvReportWorks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control)
            {
                SearchInLocalFromReport();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void lvReportWorks_Click(object sender, EventArgs e)
        {
            if((ModifierKeys & Keys.Alt) != 0)
            {
                SearchInLocalFromReport();
            }
        }

        private void SearchInLocalFromReport()
        {
            if (lvReportWorks.SelectedItems.Count != 1)
            {
                return;
            }
            var reportWork = (ReportWork)lvReportWorks.SelectedItems[0].Tag;
            var searchText = reportWork.Name.Substring(0, Math.Min(4, reportWork.Name.Length));
            tbLocalSearchLeft.Text = searchText;
            FillLocalWorks();
            lvLocalWorks.Select();
            if (lvLocalWorks.Items.Count > 0)
            {
                lvLocalWorks.Items[0].Selected = true;
            }
       }

        private void lvLocalWorks_Click(object sender, EventArgs e)
        {
            if ((ModifierKeys & Keys.Alt) != 0)
            {
                using(var wc = new WaitCursor())
                {
                    SearchInReportFromLocal((ModifierKeys & Keys.Shift) != 0);
                }
            }
        }
        private void SearchInReportFromLocal(bool useLike)
        {
            if (lvLocalWorks.SelectedItems.Count != 1)
            {
                return;
            }
            var localWork = (LocalWork)lvLocalWorks.SelectedItems[0].Tag;
            var searchText = localWork.Name;
            if(useLike)
            {
                tbReportFilterName.Text = $"%{searchText}%";
            }
            else
            {
                tbReportFilterName.Text = searchText;
            }
            tbReportFilterAuthor.Text = "";
            tbReportFilterPerformer.Text = "";
            LoadReportWorks();
        }
    }
}
