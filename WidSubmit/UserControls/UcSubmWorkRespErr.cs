using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;
using static WidSubmit.UcSubmWorkRespErr;

namespace WidSubmit
{
    public partial class UcSubmWorkRespErr : UserControl
    {
        public class DataTableColLayout
        {
            public string HeadText   { get; set; }
            public SizeType SizeType { get; set; }
            public int SizeValue     { get; set; }
        }
        
        public class DataTableLayout
        {
            public List<DataTableColLayout> DataTableColLayouts { get; set; }
        }

        public class DataSectionLayout
        {
            public string Title  { get; set; }
            public DataTableLayout DataTableLayout { get; set; }
        }

        private static readonly List<DataSectionLayout> _dataSections = new List<DataSectionLayout>()
        {
            new DataSectionLayout()
            {
                Title = "Твори",
                DataTableLayout = new DataTableLayout
                {
                    DataTableColLayouts = new List<DataTableColLayout>
                    {
                        new DataTableColLayout
                        {
                            HeadText = "Код СМАРТ",
                            SizeType = SizeType.Absolute,
                            SizeValue = 100,
                        },
                        new DataTableColLayout
                        {
                            HeadText = "Код WID",
                            SizeType = SizeType.Absolute,
                            SizeValue = 100,
                        },
                        new DataTableColLayout
                        {
                            HeadText = "ISWC",
                            SizeType = SizeType.Absolute,
                            SizeValue = 100,
                        },
                        new DataTableColLayout
                        {
                            HeadText = "Назва СМАРТ",
                            SizeType = SizeType.Percent,
                            SizeValue = 50,
                        },
                        new DataTableColLayout
                        {
                            HeadText = "Назва WID",
                            SizeType = SizeType.Percent,
                            SizeValue = 50,
                        },
                    }
                }
            },
            new DataSectionLayout()
            {
                Title = "Проценти правовласників",
                DataTableLayout = new DataTableLayout
                {
                    DataTableColLayouts = new List<DataTableColLayout>
                    {
                        new DataTableColLayout
                        {
                            HeadText = "Код СМАРТ",
                            SizeType = SizeType.Absolute,
                            SizeValue = 100,
                        },
                        new DataTableColLayout
                        {
                            HeadText = "Назва СМАРТ",
                            SizeType = SizeType.Percent,
                            SizeValue = 100,
                        },
                        new DataTableColLayout
                        {
                            HeadText = "Свій",
                            SizeType = SizeType.Absolute,
                            SizeValue = 60,
                        },
                        new DataTableColLayout
                        {
                            HeadText = "Роль WID",
                            SizeType = SizeType.Absolute,
                            SizeValue = 60,
                        },
                        new DataTableColLayout
                        {
                            HeadText = "Пуб %",
                            SizeType = SizeType.Absolute,
                            SizeValue = 50,
                        },
                        new DataTableColLayout
                        {
                            HeadText = "Мех %",
                            SizeType = SizeType.Absolute,
                            SizeValue = 50,
                        },
                    }
                }
            },
            new DataSectionLayout()
            {
                Title = "Альтернативні назви",
                DataTableLayout = new DataTableLayout
                {
                    DataTableColLayouts = new List<DataTableColLayout>
                    {
                        new DataTableColLayout
                        {
                            HeadText = "Назва СМАРТ",
                            SizeType = SizeType.Percent,
                            SizeValue = 50,
                        },
                        new DataTableColLayout
                        {
                            HeadText = "Назва WID",
                            SizeType = SizeType.Percent,
                            SizeValue = 50,
                        },
                    }
                }
            },
            new DataSectionLayout()
            {
                Title = "Виконавці",
                DataTableLayout = new DataTableLayout
                {
                    DataTableColLayouts = new List<DataTableColLayout>
                    {
                        new DataTableColLayout
                        {
                            HeadText = "Назва СМАРТ",
                            SizeType = SizeType.Percent,
                            SizeValue = 50,
                        },
                        new DataTableColLayout
                        {
                            HeadText = "Назва WID",
                            SizeType = SizeType.Percent,
                            SizeValue = 50,
                        },
                    }
                }
            },
        };

        public class SubmWork
        {
	        public int          ObjId               { get; set; }
	        public int?         Wic                 { get; set; }
            public string       Iswc                { get; set; }
	        public string       Name                { get; set; }
	        public string       NameForWid	        { get; set; }
            public int          SubmWorkFailedId	{ get; set; }
            public List<string> ErrorMessages       { get; set; }
        }

        public class Share
        {
            public int          SubmWorkShareId  { get; set; }
            public int          RhCustId         { get; set; }
            public string       RhIpBaseNr       { get; set; }
            public int?         RhIpNameNr       { get; set; }
            public string       RhName           { get; set; }
            public string       RhNameForWid     { get; set; }
            public string       RhRoleForWid     { get; set; }
            public bool         RhIsOwn          { get; set; }
            public decimal      RhShrPer         { get; set; }
            public decimal      RhShrMec         { get; set; }
            public List<string> ErrorMessages    { get; set; }
        }

        public class WorkAltName
        {
           public int    SubmWorkAltNameId     { get; set; }
           public string NameForWid            { get; set; }
           public string OrigNames             { get; set; }
            public List<string> ErrorMessages  { get; set; }
        }

        public class WorkPerformer
        {
           public int    SubmWorkPerformerId  { get; set; }
           public string NameForWid           { get; set; }
           public string OrigNames            { get; set; }
           public List<string> ErrorMessages  { get; set; }
        }

        private SubmWork _work;
        private List<Share> _shares;
        private List<WorkAltName> _altNames;
        private List<WorkPerformer> _performers;

        private Font _fontTitle;
        private Font _fontTableHead;
        private Font _fontErrorMessage;

        private Panel PanelScrollContainer;
        private TableLayoutPanel PanelMain;

        private int _submWorkId;
        private bool _isDirty;


        public UcSubmWorkRespErr()
        {
            InitializeComponent();
            _isDirty = true;
        }

        private void UcSubmWorkRespErr_Load(object sender, EventArgs e)
        {
        }

        public void ClearContent()
        {
            if(PanelScrollContainer != null)
            {
                PanelScrollContainer.Dispose();
            }
            
            Controls.Clear();

            _isDirty = true;
        }

        public void UpdateContent(int submWorkId)
        {
            _submWorkId = submWorkId;

            if(!_isDirty) return;

            ClearContent();

            var hasRespMessages = false;
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandText = "select Status from SubmWork where Id = @submWorkId";
                cmd.Parameters.AddWithValue("@submWorkId", _submWorkId);
                var status = (int)cmd.ExecuteScalar();
                hasRespMessages = status == (int)SubmWorkStatusEnum.ACCEPTED_WARNINGS || status == (int)SubmWorkStatusEnum.REJECTED;
            });

            if(!hasRespMessages) return;

            Configure();

            PanelScrollContainer.SuspendLayout();            
            LoadWork();
            FillWork();
            LoadShares();
            FillShares();
            LoadAltNames();
            FillAltNames();
            LoadPerformers();
            FillPerformers();
            PanelScrollContainer.ResumeLayout();

            _isDirty = false;
        }

        private void LoadWork()
        {
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandText = @"
                    select
	                      ObjId      
	                    , Wic        
	                    , Iswc       
	                    , Name       
	                    , NameForWid
	                    , MsgTxt
                    from vSubmWorkErrors
                    where Id = @submWorkId 
                ";
                cmd.Parameters.AddWithValue("@submWorkId", _submWorkId);
                using(var r = cmd.ExecuteReader())
                {
                    _work = new SubmWork();
                    while (r.Read())
                    {
                        var colIdx = 0;
	                    _work.ObjId         = r.GetInt32(colIdx);                                   colIdx++;
	                    _work.Wic           = r.IsDBNull(colIdx) ? (int?)null : r.GetInt32(colIdx); colIdx++;
                        _work.Iswc          = r.GetString(colIdx);                                  colIdx++;
	                    _work.Name          = r.GetString(colIdx);                                  colIdx++;
	                    _work.NameForWid	= r.GetString(colIdx);                                  colIdx++;

                        if(!r.IsDBNull(colIdx))
                        {
                            if(_work.ErrorMessages == null) _work.ErrorMessages = new List<string>();
                            _work.ErrorMessages.Add(r.GetString(colIdx));
                        }
                    }
                }
            });
        }

        private void FillWork()
        {
            var section = _dataSections[0];
            AddTitleRow(section.Title);
            
            var panel = AddDataTablePanel(section);

            var data = new string[] {
                    _work.ObjId.ToString(),
                    _work.Wic == null ? "" : _work.Wic.ToString(),
                    _work.Iswc,
                    _work.Name,
                    _work.NameForWid,
            };
            AddTableDataRow(panel, data);
            if(_work.ErrorMessages != null)
            {
                _work.ErrorMessages.ForEach(x =>
                {
                    AddTableErrorMessageRow(panel, x);
                });
            }

        }

        private void LoadShares()
        {
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandText = @"
                    select
                          SubmWorkShareId
                        , RhCustId    
                        , RhIpBaseNr  
                        , RhIpNameNr  
                        , RhName      
                        , RhNameForWid
                        , RhRoleForWid
                        , RhIsOwn
                        , RhShrPer    
                        , RhShrMec    
	                    , MsgTxt
                    from vSubmWorkShareErrors
                    where SubmWorkId = @submWorkId
                    order by RhName, SubmWorkShareId
                ";
                cmd.Parameters.AddWithValue("@submWorkId", _submWorkId);
                using(var r = cmd.ExecuteReader())
                {
                    _shares = new List<Share>();
                    Share curShare = null;
                    while (r.Read())
                    {
                        var shareId = r.GetInt32(0);
                        if(curShare == null || curShare.SubmWorkShareId != shareId)
                        {
                            var share = new Share();
                            share.SubmWorkShareId = shareId;
                            var colIdx = 1;
                            share.RhCustId      = r.GetInt32(colIdx)    ; colIdx++;
                            share.RhIpBaseNr    = r.GetString(colIdx)   ; colIdx++;
                            share.RhIpNameNr    = r.GetInt32(colIdx)    ; colIdx++;
                            share.RhName        = r.GetString(colIdx)   ; colIdx++;
                            share.RhNameForWid  = r.GetString(colIdx)   ; colIdx++;
                            share.RhRoleForWid  = r.GetString(colIdx)   ; colIdx++;
                            share.RhIsOwn       = r.GetBoolean(colIdx)  ; colIdx++;
                            share.RhShrPer      = r.GetDecimal(colIdx)  ; colIdx++;
                            share.RhShrMec      = r.GetDecimal(colIdx)  ; colIdx++;
                            
                            if(!r.IsDBNull(colIdx))
                            {
                                if(share.ErrorMessages == null) share.ErrorMessages = new List<string>();
                                share.ErrorMessages.Add(r.GetString(colIdx));
                            }
                            _shares.Add(share);

                            curShare = share;
                        }
                        else
                        {
                            if(!r.IsDBNull(10))
                            {
                                if(curShare.ErrorMessages == null) curShare.ErrorMessages = new List<string>();
                                curShare.ErrorMessages.Add(r.GetString(10));
                            }
                        }
                    }
                }
            });
        }

        private void FillShares()
        {
            var section = _dataSections[1];
            AddTitleRow(section.Title);
            
            var panel = AddDataTablePanel(section);

            _shares.ForEach(share =>
            {
                var data = new string[] {
                    share.RhCustId.ToString(),
                    share.RhName,
                    share.RhIsOwn ? "так" : "ні",
                    share.RhRoleForWid,
                    share.RhShrPer.ToString(),
                    share.RhShrMec.ToString(),
                };
                AddTableDataRow(panel, data);
                if(share.ErrorMessages != null)
                {
                    share.ErrorMessages.ForEach(x =>
                    {
                        AddTableErrorMessageRow(panel, x);
                    });
                }
            });

        }

        private void LoadAltNames()
        {
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandText = @"
                    select
                          SubmWorkAltNameId
                        , NameForWid    
                        , OrigNames  
	                    , MsgTxt
                    from vSubmWorkAltNameErrors
                    where SubmWorkId = @submWorkId 
                ";
                cmd.Parameters.AddWithValue("@submWorkId", _submWorkId);
                using(var r = cmd.ExecuteReader())
                {
                    _altNames = new List<WorkAltName>();
                    WorkAltName curAltName = null;
                    while (r.Read())
                    {
                        var altNameId = r.GetInt32(0);
                        if(curAltName == null || curAltName.SubmWorkAltNameId != altNameId)
                        {
                            var altName = new WorkAltName();
                            var colIdx = 1;
                            altName.NameForWid   = r.GetString(colIdx)   ; colIdx++;
                            altName.OrigNames    = r.GetString(colIdx)   ; colIdx++;
                            
                            if(!r.IsDBNull(colIdx))
                            {
                                if(altName.ErrorMessages == null) altName.ErrorMessages = new List<string>();
                                altName.ErrorMessages.Add(r.GetString(colIdx));
                            }
                            _altNames.Add(altName);

                            curAltName = altName;
                        }
                        else
                        {
                            curAltName.ErrorMessages.Add(r.GetString(3));
                        }
                    }
                }
            });
        }

        private void FillAltNames()
        {
            var section = _dataSections[2];
            AddTitleRow(section.Title);
            
            var panel = AddDataTablePanel(section);

            _altNames.ForEach(altName =>
            {
                var data = new string[] {
                    altName.NameForWid,
                    altName.OrigNames,
                };
                AddTableDataRow(panel, data);
                if(altName.ErrorMessages != null)
                {
                    altName.ErrorMessages.ForEach(x =>
                    {
                        AddTableErrorMessageRow(panel, x);
                    });
                }
            });

        }

        private void LoadPerformers()
        {
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandText = @"
                    select
                          SubmWorkPerformerId
                        , NameForWid    
                        , OrigNames  
	                    , MsgTxt
                    from vSubmWorkPerformerErrors
                    where SubmWorkId = @submWorkId 
                ";
                cmd.Parameters.AddWithValue("@submWorkId", _submWorkId);
                using(var r = cmd.ExecuteReader())
                {
                    _performers = new List<WorkPerformer>();
                    WorkPerformer curPerformer = null;
                    while (r.Read())
                    {
                        var performerId = r.GetInt32(0);
                        if(curPerformer == null || curPerformer.SubmWorkPerformerId != performerId)
                        {
                            var performer = new WorkPerformer();
                            var colIdx = 1;
                            performer.NameForWid   = r.GetString(colIdx)   ; colIdx++;
                            performer.OrigNames    = r.GetString(colIdx)   ; colIdx++;
                            
                            if(!r.IsDBNull(colIdx))
                            {
                                if(performer.ErrorMessages == null) performer.ErrorMessages = new List<string>();
                                performer.ErrorMessages.Add(r.GetString(colIdx));
                            }
                            _performers.Add(performer);

                            curPerformer = performer;
                        }
                        else
                        {
                            curPerformer.ErrorMessages.Add(r.GetString(3));
                        }
                    }
                }
            });
        }

        private void FillPerformers()
        {
            var section = _dataSections[3];
            AddTitleRow(section.Title);
            
            var panel = AddDataTablePanel(section);

            _performers.ForEach(performer =>
            {
                var data = new string[] {
                    performer.NameForWid,
                    performer.OrigNames,
                };
                AddTableDataRow(panel, data);
                if(performer.ErrorMessages != null)
                {
                    performer.ErrorMessages.ForEach(x =>
                    {
                        AddTableErrorMessageRow(panel, x);
                    });
                }
            });

        }


        #region LAUOUT
        private void Configure()
        {
            CreateFonts();
            CreatePanelScrollContainer();
            CreatePanelMain();
            //AddMainPanelRows();
        }

        private void CreateFonts()
        {
            _fontTitle = new Font(Font, FontStyle.Bold);
            _fontTableHead = new Font(Font.Name, 7F, FontStyle.Bold|FontStyle.Italic);
        }

        private void CreatePanelScrollContainer()
        {
            PanelScrollContainer = new Panel();
            PanelScrollContainer.AutoScroll = true;
            PanelScrollContainer.Dock = DockStyle.Fill;
            PanelScrollContainer.BackColor = Color.White;
            this.Controls.Add(PanelScrollContainer);
        }

        private void CreatePanelMain()
        {
            PanelMain = new TableLayoutPanel();
            PanelMain.Dock = DockStyle.Top;
            PanelMain.AutoSize = true;
            PanelMain.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PanelMain.Padding = new Padding(4);
            //PanelMain.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            PanelMain.ColumnCount += 1;
            PanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            PanelScrollContainer.Controls.Add(PanelMain);
        }

        private TableLayoutPanel AddDataTablePanel(DataSectionLayout section)
        {
            var panel = new TableLayoutPanel();
            panel.Dock = DockStyle.Fill;
            panel.AutoSize = true;
            panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            AddTableHeadRow(panel, section);

            PanelMain.RowCount += 1;
            PanelMain.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            PanelMain.Controls.Add(panel, PanelMain.RowCount - 1, 0);

            return panel;
        }

        private void AddTitleRow(string text)
        {
            PanelMain.RowCount += 1;
            PanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 16));
            
            var label = CreateLabelTitle(text);
            PanelMain.Controls.Add(label, PanelMain.RowCount - 1, 0);
        }

        private void AddTableHeadRow(TableLayoutPanel panel, DataSectionLayout section)
        {
            panel.RowCount += 1;
            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 16));
            
            section.DataTableLayout.DataTableColLayouts.ForEach(col =>
            {
                panel.ColumnCount += 1;
                panel.ColumnStyles.Add(new ColumnStyle(col.SizeType, col.SizeValue));
                panel.Controls.Add(CreateLabelTableColHead(col.HeadText)
                    , panel.ColumnCount - 1
                    , panel.RowCount - 1);
            });
        }

        private void AddTableDataRow(TableLayoutPanel panel, string[] values)
        {
            panel.RowCount += 1;
            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 16));

            var colIdx = 0;
            foreach (var value in values)
            {
                var label = CreateLabelTableValue(value);
                panel.Controls.Add(label, colIdx++, panel.RowCount - 1);
            }
        }

        private void AddTableErrorMessageRow(TableLayoutPanel panel, string text)
        {
            panel.RowCount += 1;
            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 16));

            var label = CreateLabelErrorMessage(text);
            panel.Controls.Add(label, 0, panel.RowCount - 1);
            panel.SetColumnSpan(label, panel.ColumnCount);
        }

        private Label CreateLabelTitle(string text)
        {
            var label = new Label();
            label.Text = text;
            label.AutoSize = true;
            label.Dock = DockStyle.Fill;
            label.BackColor = Color.WhiteSmoke;
            label.Padding = new Padding(2);
            label.Font = _fontTitle;

            return label;
        }

        private Label CreateLabelTableColHead(string text)
        {
            var label = new Label();
            label.Text = text;
            label.Padding = new Padding(0);
            label.Font = _fontTableHead;
            return label;
        }

        private Label CreateLabelTableValue(string text)
        {
            var label = new Label();
            label.Text = text;
            label.Dock = DockStyle.Fill;
            label.Padding = new Padding(0);
            return label;
        }

        private Label CreateLabelErrorMessage(string text)
        {
            var label = new Label();
            label.Text = text;
            label.Dock = DockStyle.Fill;
            label.ForeColor = Color.Red;
            label.Padding = new Padding(0);
            return label;
        }

        #endregion
    
        
    }
}
