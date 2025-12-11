using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CwrTools.UcProblemWorks;

namespace CwrTools
{
    public partial class UcProblemWorks : UserControl
    {
        public enum ProblemTypeEnum
        {
              ALL
            , RIGHTHOLDER_ROLE_UNDEFINED
            , SHARE_PER_EXCEEDS_100
            , SHARE_MEC_EXCEEDS_100
            , DUPLICATE_PUBLISHERS
            , DUPLICATE_AUTHORS
            , WRONG_ISWC
            , EMPTY_NAME
        }

        public class ProblemType
        {
            public ProblemTypeEnum Code { get; set; }
            public string Name { get; set; }
            public string IndFieldName { get; set; }
        }

        public static readonly List<ProblemType> _problemTypes = new List<ProblemType>()
        {
            new ProblemType { Code = ProblemTypeEnum.ALL                       , Name = "<Всі>"                          , IndFieldName = "" },
            new ProblemType { Code = ProblemTypeEnum.RIGHTHOLDER_ROLE_UNDEFINED, Name = "Не визначена роль правовласника", IndFieldName = "UndefRole" },
            new ProblemType { Code = ProblemTypeEnum.SHARE_PER_EXCEEDS_100     , Name = "Проценти з Пуб Перевищують 100" , IndFieldName = "WrongPerShr" },	
            new ProblemType { Code = ProblemTypeEnum.SHARE_MEC_EXCEEDS_100     , Name = "Проценти з Мех Перевищують 100" , IndFieldName = "WrongMecShr" },
            new ProblemType { Code = ProblemTypeEnum.DUPLICATE_PUBLISHERS      , Name = "Видавці вказані двічі"          , IndFieldName = "DupRightHolder" },
            new ProblemType { Code = ProblemTypeEnum.DUPLICATE_AUTHORS         , Name = "Автори вказані двічі"           , IndFieldName = "DupPublisher" },	
            new ProblemType { Code = ProblemTypeEnum.WRONG_ISWC                , Name = "Невірний код ISWC"              , IndFieldName = "WrongIswc" },		
            new ProblemType { Code = ProblemTypeEnum.EMPTY_NAME                , Name = "Відсутня назва твору"           , IndFieldName = "NoName" },		   
        };

        public class WorkInfo
        {
            public int ObjId { get; set; }
            public string Name { get; set; }
            public int CatCode { get; set; }                
            public string Iswc { get; set; }
            public decimal PerShr { get; set; }
            public decimal MecShr { get; set; }
            public bool UndefRole { get; set; }
            public bool WrongPerShr { get; set; }
            public bool WrongMecShr { get; set; }
            public bool DupRightHolder { get; set; }
            public bool DupPublisher { get; set; }
            public bool WrongIswc { get; set; }
            public bool NoName { get; set; }

            public bool IsValid()
            {
                return
                    !UndefRole &&
                    !WrongPerShr &&
                    !WrongMecShr &&
                    !DupRightHolder &&
                    !DupPublisher &&
                    !WrongIswc &&
                    !NoName;
            }
        };

        public class RightHolderInfo
        {
            public int CopyRightId { get; set; }
            public int ObjId { get; set; }
            public int CustId { get; set; }
            public string Name { get; set; }
            public int Type { get; set; }
            public string TypeName { get; set; }
            public int Role { get; set; }
            public string RoleName { get; set; }
            public decimal PerShr { get; set; }
            public decimal MecShr { get; set; }
        };

        public class RightHolderName
        {
            public int CustId { get; set; }
            public string Name { get; set; }
        }

        public class CopyRightHistory
        {
            public int CopyRightId { get; set; }
            public int SeqNr { get; set; }
            public int CustId { get; set; }
            public string Name { get; set; }
            public int RoleCode { get; set; }
            public DateTime? CreateDate { get; set; }
            public DateTime? BeginDate { get; set; }
            public DateTime? EndDate { get; set; }
            public decimal PerShr { get; set; }
            public decimal MecShr { get; set; }
        }

        public class ValidTypeRole
        {
            public int RightHolderType { get; set; }
            public int RightHolderRole { get; set; }
            public string DisplayText { get; set; }
        }
        
        public static readonly List<ValidTypeRole> _validTypeRoles = new List<ValidTypeRole>()
        {
            new ValidTypeRole { RightHolderType = 1, RightHolderRole = 1,  DisplayText = "1 - Правовласник / 1 - Автор тексту" },
            new ValidTypeRole { RightHolderType = 1, RightHolderRole = 2,  DisplayText = "1 - Правовласник / 2 - Композитор" },
            new ValidTypeRole { RightHolderType = 1, RightHolderRole = 7,  DisplayText = "1 - Правовласник / 7 - Аранжувальник" },
            new ValidTypeRole { RightHolderType = 1, RightHolderRole = 10, DisplayText = "1 - Правовласник / 10 - Композитор/автор тексту" },
            new ValidTypeRole { RightHolderType = 3, RightHolderRole = 8,  DisplayText = "3 - Видавництво / 8 - Правовласник" },
        };

        private delegate void CorrectionBody(ListViewItem workItem, ListViewItem rightHolderItem, 
            WorkInfo WorkInfo, RightHolderInfo rightHolderInfo);

        public delegate void ShowRightHolderProblemWorks(int custId);

        private List<WorkInfo> _workInfoList = new List<WorkInfo>();
        private List<RightHolderName> _filterRightHolders;

        private FormRightHolderRoles _formRightHolderRoles;
        
        public void OnShowRightHolderUnknownRoleWorks(int custId)
        {
            OnCbRightHolderFilterDropDown();

            cbProblemType.SelectedIndex = 1;

            var filterRightHolderIdx = 0;
            for(var idx = 1; idx < _filterRightHolders.Count; idx++)
            {
                var filterRightHolder = _filterRightHolders[idx];
                if(custId == filterRightHolder.CustId)
                {
                    filterRightHolderIdx = idx;
                    break;
                }
            };
            cbRightHolderFilter.SelectedIndex = filterRightHolderIdx;
            OnSelectWorks();
        }

        public UcProblemWorks()
        {
            InitializeComponent();
            Configure();

            FillWorks();
            FillWorkDetails(null);
        }

        private void UcProblemWorks_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.UcProblemWorksSplitterDistance > 0)
            {
                this.panelMiddle.SplitterDistance = Properties.Settings.Default.UcProblemWorksSplitterDistance;
            }
        }

        public int GetSplitterDistance()
        {
            return this.panelMiddle.SplitterDistance;
        }

        private void Configure()
        {
            lvWorks.FullRowSelect = true;
            lvWorks.GridLines = true;
            lvWorks.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvWorks.MultiSelect = false;
            lvWorks.View = View.Details;
            lvWorks.SmallImageList = ilStatuses;

            lvWorks.Columns.Clear();
            lvWorks.Columns.Add("Рядок", 50);
            lvWorks.Columns.Add("Код", 50);
            lvWorks.Columns.Add("Назва", 200);


            lvRightHolders.FullRowSelect = true;
            lvRightHolders.GridLines = true;
            lvRightHolders.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvRightHolders.MultiSelect = false;
            lvRightHolders.View = View.Details;

            lvRightHolders.Columns.Clear();
            lvRightHolders.Columns.Add("Код права", 120);
            lvRightHolders.Columns.Add("Код", 120);
            lvRightHolders.Columns.Add("Назва", 200);
            lvRightHolders.Columns.Add("Тип", 110);
            lvRightHolders.Columns.Add("Роль", 170);
            lvRightHolders.Columns.Add("Пуб%", 60);
            lvRightHolders.Columns.Add("Мех%", 60);

            lvCopyRightHistory.FullRowSelect = true;
            lvCopyRightHistory.GridLines = true;
            lvCopyRightHistory.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvCopyRightHistory.MultiSelect = false;
            lvCopyRightHistory.View = View.Details;

            lvCopyRightHistory.Columns.Clear();
            lvCopyRightHistory.Columns.Add("Код права", 120);
            lvCopyRightHistory.Columns.Add("Код", 120);
            lvCopyRightHistory.Columns.Add("Назва", 200);
            lvCopyRightHistory.Columns.Add("Роль", 120);
            lvCopyRightHistory.Columns.Add("Від", 170);
            lvCopyRightHistory.Columns.Add("До", 170);
            lvCopyRightHistory.Columns.Add("Пуб%", 60);
            lvCopyRightHistory.Columns.Add("Мех%", 60);


            cbProblemType.Items.Clear();
            _problemTypes.ForEach(x =>
            {
                cbProblemType.Items.Add(x.Name);
            });

            cbTypeRoleNew.Items.Clear();
            _validTypeRoles.ForEach(x =>
            {
                cbTypeRoleNew.Items.Add(x.DisplayText);
            });
            cbTypeRoleNew.SelectedIndex = 0;

            btnSelectWorks.Enabled = false;
        }

        private void FillWorks()
        {
            lvWorks.Items.Clear();
            if(cbProblemType.SelectedIndex == -1)
            {
                return;
            }

            var problemType = _problemTypes[cbProblemType.SelectedIndex];
            Helpers.RunSqlCwr(cmd =>
            {
                var filter = problemType.Code == ProblemTypeEnum.ALL ? "" : $"where {problemType.IndFieldName} = 1";
                if (cbRightHolderFilter.SelectedIndex < 1)
                {
                    cmd.CommandText = $@"
                        select t2.*, t1.* 
                        from TmpWrongWorks t1
	                        join vWorkInfo t2 on t1.ObjId = t2.ObjId
                        {filter}
                        order by t2.Name
                    ";
                }
                else
                {
                    var filterEx = filter == "" ? "where CustId = @custId" : $"{filter} and CustId = @custId";
                    // Враховуємо можливість подвоєнь коли правовласник для твору трапляєься двічі з різними ролями
                    cmd.CommandText = $@"
                        select distinct t2.*, t1.* 
                        from TmpWrongWorks t1
	                        join vWorkInfo t2 on t1.ObjId = t2.ObjId
	                        join vWorkRightHoldersCurrent t3 on t2.ObjId = t3.ObjId
                        {filterEx}
	                        and dbo.fnCheckRoleDefined(t3.RightHolderType, t3.RoleCode) = 0
                        order by t2.Name
                    ";
                    cmd.Parameters.AddWithValue("@custId", _filterRightHolders[cbRightHolderFilter.SelectedIndex].CustId);
                }
                using (var r = cmd.ExecuteReader())
                {
                    _workInfoList = new List<WorkInfo>();
                    while (r.Read())
                    {
                        var colIdx = 0;
                        var workInfo = new WorkInfo();
                        workInfo.ObjId              = r.GetInt32    (colIdx++);
                        workInfo.Name               = r.GetString   (colIdx++);
                        workInfo.CatCode            = r.GetInt32    (colIdx++);
                        workInfo.Iswc               = r.GetString   (colIdx++);
                        workInfo.PerShr             = r.GetDecimal  (colIdx++);
                        workInfo.MecShr             = r.GetDecimal  (colIdx++);
                        colIdx++;
                        workInfo.UndefRole          = r.GetBoolean  (colIdx++);
                        workInfo.WrongPerShr        = r.GetBoolean  (colIdx++);
                        workInfo.WrongMecShr        = r.GetBoolean  (colIdx++);
                        workInfo.DupRightHolder     = r.GetBoolean  (colIdx++);
                        workInfo.DupPublisher       = r.GetBoolean  (colIdx++);
                        workInfo.WrongIswc          = r.GetBoolean  (colIdx++);
                        workInfo.NoName             = r.GetBoolean  (colIdx++);
                        _workInfoList.Add(workInfo);
                    }
                 }
            });

            var idx = 1;
            lvWorks.BeginUpdate();
            _workInfoList.ForEach(x =>
            {
                var item = lvWorks.Items.Add(idx.ToString());
                item.SubItems.Add(x.ObjId.ToString());
                item.SubItems.Add(x.Name.ToString());
                item.SubItems.Add(GetCatCodeName(x.CatCode));
                item.SubItems.Add(x.Iswc.ToString());
                item.SubItems.Add(x.PerShr.ToString());
                item.SubItems.Add(x.MecShr.ToString());
                item.Tag = x;
                item.ImageIndex = x.CatCode != 5 ? 1 : x.IsValid() ? 0 : 2;
                idx++;
            });
            lvWorks.EndUpdate();


            FillWorkDetails(null);
        }

        private void RefreshWork(ListViewItem itemWork)
        {
            var workInfo = (WorkInfo)itemWork.Tag;

            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spUpdateTmpWrongWork";
                cmd.Parameters.AddWithValue("@objId", workInfo.ObjId);
                cmd.ExecuteNonQuery();
                
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"
                    select t2.*, t1.* 
                    from TmpWrongWorks t1
	                    join vWorkInfo t2 on t1.ObjId = t2.ObjId
                    where t1.ObjId = @objId
                    order by t2.Name
                ";
                using (var r = cmd.ExecuteReader())
                {
                    r.Read();
                    var colIdx = 0;
                    workInfo.ObjId              = r.GetInt32    (colIdx++);
                    workInfo.Name               = r.GetString   (colIdx++);
                    workInfo.CatCode            = r.GetInt32    (colIdx++);
                    workInfo.Iswc               = r.GetString   (colIdx++);
                    workInfo.PerShr             = r.GetDecimal  (colIdx++);
                    workInfo.MecShr             = r.GetDecimal  (colIdx++);
                    colIdx++;
                    workInfo.UndefRole          = r.GetBoolean  (colIdx++);
                    workInfo.WrongPerShr        = r.GetBoolean  (colIdx++);
                    workInfo.WrongMecShr        = r.GetBoolean  (colIdx++);
                    workInfo.DupRightHolder     = r.GetBoolean  (colIdx++);
                    workInfo.DupPublisher       = r.GetBoolean  (colIdx++);
                    workInfo.WrongIswc          = r.GetBoolean  (colIdx++);
                    workInfo.NoName             = r.GetBoolean  (colIdx++);
                 }
            });

            itemWork.ImageIndex = workInfo.CatCode != 5 ? 1 : workInfo.IsValid() ? 0 : 2;

        }

        private void FillWorkDetails(WorkInfo workInfo)
        {
            if(workInfo == null)
            {
                tbIsDuplicate.Visible = false;           
                return;
            }
            
            tbWorkCode.Text = workInfo.ObjId.ToString();
            picWorkExcluded.Visible =
            labWorkExcluded.Visible = workInfo.CatCode != 5;

            tbWorkName.Text = workInfo.Name;
            picNameErr.Visible = string.IsNullOrEmpty(workInfo.Name);
            

            tbWorkCategory.Text = GetCatCodeName(workInfo.CatCode);
            btnChangeCategory.Text = workInfo.CatCode == 5 ? "Змінити на 6 - Хореографія" : "Змінити на 5 - Музика";

            tbIswc.Text = workInfo.Iswc;

            tbPerShr.Text = workInfo.PerShr.ToString();
            tbMecShr.Text = workInfo.MecShr.ToString();

            FillRightHolders(workInfo.ObjId);

            UpdateErrorIcons(workInfo);

            tbIsDuplicate.Visible = true;

        }

        private void FillRightHolders(int objId)
        {
            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandText = $@"
                    select t1.* 
                    from vRightHolderInfo t1
                        join vWorkRightHoldersCurrent t2 on t1.CopyRightId = t2.CopyRightId
                    where t1.ObjId = @objId
                    order by CustId
                ";
                cmd.Parameters.AddWithValue("@objId", objId);
                using (var r = cmd.ExecuteReader())
                {
                    lvRightHolders.Items.Clear();
                    while (r.Read())
                    {
                        var rightHolderInfo = new RightHolderInfo();
                        var idx = 0;
                        rightHolderInfo.CopyRightId = r.GetInt32    (idx++);
                        rightHolderInfo.ObjId       = r.GetInt32    (idx++);
                        rightHolderInfo.CustId      = r.GetInt32    (idx++);
                        rightHolderInfo.Name        = r.GetString   (idx++);
                        rightHolderInfo.Type        = r.GetInt32    (idx++);
                        rightHolderInfo.TypeName    = r.GetString   (idx++);
                        rightHolderInfo.Role        = r.GetInt32    (idx++);
                        rightHolderInfo.RoleName    = r.GetString   (idx++);
                        rightHolderInfo.PerShr      = r.GetDecimal  (idx++);
                        rightHolderInfo.MecShr      = r.GetDecimal  (idx++);


                        var item = lvRightHolders.Items.Add(rightHolderInfo.CopyRightId.ToString());
                        item.SubItems.Add(rightHolderInfo.CustId.ToString());
                        item.SubItems.Add(rightHolderInfo.Name.ToString());
                        item.SubItems.Add($"{rightHolderInfo.Type} - {rightHolderInfo.TypeName}");
                        item.SubItems.Add($"{rightHolderInfo.Role} - {rightHolderInfo.RoleName}");
                        item.SubItems.Add(rightHolderInfo.PerShr.ToString());
                        item.SubItems.Add(rightHolderInfo.MecShr.ToString());
                        item.Tag = rightHolderInfo;
                        item.ImageIndex = IsRoleDefined(rightHolderInfo) ? 0 : 2;
                    }
                }
            });
            UpdateLvRightHoldersImages();
            UpdateRightHolderControls();

            if(lvRightHolders.Items.Count > 0)
            {
                lvRightHolders.Items[0].Selected = true;
            }
        }

        private void FillFilterRightHolders()
        {
            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandText = $@"
                    select t2.CustId, t2.shortName
                    from TmpRightHolderRoleCorrections t1
                        join MediaService..vCustomerNamesShort t2 on t1.CustId = t2.CustId
                    order by t2.ShortName
                ";
                using (var r = cmd.ExecuteReader())
                {
                    _filterRightHolders = new List<RightHolderName> ();
                    _filterRightHolders.Add(new RightHolderName { CustId = 0, Name = "<ВСІ>" });    
                    while (r.Read())
                    {
                        _filterRightHolders.Add(new RightHolderName { CustId = r.GetInt32(0), Name = r.GetString(1) });
                    }
                }
            });
            UpdateLvRightHoldersImages();
            UpdateRightHolderControls();

            if(lvRightHolders.Items.Count > 0)
            {
                lvRightHolders.Items[0].Selected = true;
            }
        }

        private void FillCopyRightHistory(int copyRightId)
        {
            var chrList = new List<CopyRightHistory> ();
            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spSelectCopyRightHistoryOutline";
                cmd.Parameters.AddWithValue("@copyRightId", copyRightId);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        var crh = new CopyRightHistory();
                        crh.CopyRightId   = r.GetInt32(0);
                        crh.SeqNr         = r.GetInt32(1);  
                        crh.CustId        = r.GetInt32(2);  
                        crh.Name          = r.GetString(3);
                        crh.RoleCode      = r.GetInt32(4);  
                        crh.CreateDate    = r.IsDBNull(5) ? (DateTime?)null : r.GetDateTime(5);
                        crh.BeginDate     = r.IsDBNull(6) ? (DateTime?)null : r.GetDateTime(6);
                        crh.EndDate       = r.IsDBNull(7) ? (DateTime?)null : r.GetDateTime(7);
                        crh.PerShr        = r.GetDecimal(8);
                        crh.MecShr        = r.GetDecimal(9);

                        chrList.Add(crh);
                    }
                }
            });

            chrList = chrList.OrderBy(x => x.SeqNr).ToList();

            lvCopyRightHistory.Items.Clear ();
            chrList.ForEach(x =>
            {
                var item = lvCopyRightHistory.Items.Add(x.CopyRightId.ToString());
                //item.SubItems.Add(x.CopyRightId.ToString());
                //item.SubItems.Add(x.SeqNr      .ToString());
                item.SubItems.Add(x.CustId     .ToString());
                item.SubItems.Add(x.Name       .ToString());
                item.SubItems.Add(x.RoleCode   .ToString());
                //item.SubItems.Add(x.CreateDate .ToString());
                item.SubItems.Add(x.BeginDate == null ? "" : ((DateTime)x.BeginDate).ToString("yyyy-MM-dd"));
                item.SubItems.Add(x.EndDate == null ? "" : ((DateTime)x.EndDate).ToString("yyyy-MM-dd"));
                item.SubItems.Add(x.PerShr     .ToString());
                item.SubItems.Add(x.MecShr     .ToString());
            }); 



        }

        private void UpdateLvRightHoldersImages()
        {
            for (int idx = 0; idx < lvRightHolders.Items.Count; idx++)
            {
                var curItem = lvRightHolders.Items[idx];
                var prevItem = idx == 0                              ? null : lvRightHolders.Items[idx - 1];
                var nextItem = idx == lvRightHolders.Items.Count - 1 ? null : lvRightHolders.Items[idx + 1];

                var curRightHolderInfo = (RightHolderInfo)curItem.Tag;
                var prevRightHolderInfo = prevItem == null ? null : (RightHolderInfo)prevItem.Tag;
                var nextRightHolderInfo = nextItem == null ? null : (RightHolderInfo)nextItem.Tag;

                var isGroupStart = 
                        prevItem == null && 
                        nextItem != null && 
                        curRightHolderInfo.CustId == nextRightHolderInfo.CustId
                    ||
                        prevItem != null &&
                        nextItem != null &&
                        curRightHolderInfo.CustId != prevRightHolderInfo.CustId &&
                        curRightHolderInfo.CustId == nextRightHolderInfo.CustId;

                var isGroupMember = 
                        prevItem != null &&
                        curRightHolderInfo.CustId == prevRightHolderInfo.CustId;

                if(isGroupStart)
                {
                    curItem.ImageIndex = 2;
                    curItem.StateImageIndex = 0;
                }
                else if(isGroupMember)
                {
                    curItem.ImageIndex = 2;
                    curItem.StateImageIndex = 1;
                }
            }
        }

        private void UpdateRightHolderControls()
        {
            if(lvRightHolders.SelectedItems.Count == 0)
            {
                panelSelectedRightHolder.Visible = false;
                panelRightHolderRole.Visible = false;
                panelRightHolderDup.Visible = false;
                panelRightHolderShr.Visible = false;
                return;
            }

            var workInfo = (WorkInfo)lvWorks.SelectedItems[0].Tag;
            var item = lvRightHolders.SelectedItems[0];
            var rightHolderInfo = (RightHolderInfo)item.Tag;

            picTypeRoleErr.Visible = !IsRoleDefined(rightHolderInfo);
            labTypeRoleNew.Visible =
            cbTypeRoleNew.Visible =
            btnTypeRoleApply.Visible = true;

            picDupErr.Visible = item.StateImageIndex == 0 || item.StateImageIndex == 1;
            btnDeleteDup.Visible = true;

            picShrErr.Visible       = workInfo.PerShr > 100 || workInfo.MecShr > 100;
            tbShrCur.Visible =
            labNewShr.Visible =
            labPerShrNew.Visible =
            labMecShrNew.Visible =
            tbPerShrNew.Visible =
            tbMecShrNew.Visible =
            btnShrNewApply.Visible = true;
            tbShrCur.Text = $"{rightHolderInfo.PerShr}/{rightHolderInfo.MecShr}";

            tbTypeRoleCur.Text = MetaData.GetRightHolderTypeRoleText(rightHolderInfo.Type, rightHolderInfo.Role);

            panelSelectedRightHolder.Visible = true;
            panelRightHolderRole.Visible = true;
            panelRightHolderDup.Visible = true;
            panelRightHolderShr.Visible = true;

            FillCopyRightHistory(rightHolderInfo.CopyRightId);
            
        }

        private string GetCatCodeName(int catCode)
        {
            return catCode == 5 ? "5 - Музика" : catCode == 6 ? "6 - Вистава" : "Інше";
        }

        private bool IsValidIswc(string iswc)
        {
            if (iswc.Trim() == "")
            {
                return true;
            }

            if (iswc.Length != 11)
            {
                return false;
            }

            if (iswc[0] != 'T')
            {
                return false;
            }

            for(var idx = 1; idx < iswc.Length; idx++)
            {
                if (!char.IsDigit(iswc[idx]))
                {
                    return false;
                }
            }


            return true;
        }

        private bool IsRoleDefined(RightHolderInfo rightHolderInfo)
        {
            return rightHolderInfo.Type == 1 &&
                (rightHolderInfo.Role == 1 || rightHolderInfo.Role == 2 || rightHolderInfo.Role == 7 || rightHolderInfo.Role == 10)
                ||
                rightHolderInfo.Type == 3 && rightHolderInfo.Role == 8;
        }

        private void UpdateErrorIcons(WorkInfo workInfo)
        {
            picIswcErr.Visible = !IsValidIswc(workInfo.Iswc);
            picPerShrErr.Visible = workInfo.PerShr > 100;
            picMecShrErr.Visible = workInfo.MecShr > 100;
        }

        private void ChangeCategory(int objId, int categoryCode)
        {
            Helpers.RunSqlCwr(cmd =>
            {
                cmd.CommandText = @"
                    update MediaService..ObjectRight set categoryCode = @categoryCode where ObjId = @objId
                ";
                cmd.Parameters.AddWithValue("@objId", objId);
                cmd.Parameters.AddWithValue("@categoryCode", categoryCode);
                cmd.ExecuteNonQuery();
            });
        }
        private void UpdateTypeRole(int objId, int custId, int type, int role)
        {
            Helpers.RunSqlCwrT(cmd =>
            {
                cmd.CommandText = @"
                    update MediaService..RightHolder set rHolderType = @type where CustId = @custId
                    update MediaService..CopyRight set roleCode = @role where ObjId = @objId and CustId = @custId
                    update MediaService..Authors set roleCode = @role where ObjId = @objId and CustId = @custId
                ";
                cmd.Parameters.AddWithValue("@objId", objId);
                cmd.Parameters.AddWithValue("@custId", custId);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@role", role);
                cmd.ExecuteNonQuery();
            });
        }

        private void DeleteWorkRightHolder(int copyRightId)
        {
            Helpers.RunSqlCwrT(cmd =>
            {
                cmd.CommandText = @"
                    delete from MediaService..CopyRightHistory where parentId = @copyRightId
                    delete from MediaService..CopyRightHistory where childId = @copyRightId
                    delete from MediaService..CopyRight where cRightId = @copyRightId
                ";
                cmd.Parameters.AddWithValue("@copyRightId", copyRightId);
                cmd.ExecuteNonQuery();
            });
        }

        private void UpdateShares(int copyRightId, decimal newPerShr, decimal newMecShr)
        {
            Helpers.RunSqlCwrT(cmd =>
            {
                cmd.CommandText = @"
                    update MediaService..CopyRight
                    set rate = @newPerShr, rateMech = @newMecShr
                    where cRightId = @copyRightId
                ";
                cmd.Parameters.AddWithValue("@copyRightId", copyRightId);
                cmd.Parameters.AddWithValue("@newPerShr", newPerShr);
                cmd.Parameters.AddWithValue("@newMecShr", newMecShr);
                cmd.ExecuteNonQuery();
            });
        }

        private void RefreshProblems()
        {
            Helpers.RunSqlCwrT(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spCreateTmpWrongWorks";
                cmd.ExecuteNonQuery();
             });
        }

        private void DoCorrection(CorrectionBody body)
        {
            if(lvRightHolders.SelectedItems.Count == 0)
            {
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;

                var itemWork = lvWorks.SelectedItems[0];
                var workInfo = (WorkInfo)itemWork.Tag;
                var itemRightHolder = lvRightHolders.SelectedItems[0];
                var rightHolderInfo = (RightHolderInfo)itemRightHolder.Tag;

                body(itemWork, itemRightHolder, workInfo, rightHolderInfo);

                RefreshWork(itemWork);
                FillWorkDetails(workInfo);

                Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Обробка проблемних творів", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void OnSelectWorks()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                FillWorks();
                FillWorkDetails(null);
                btnSelectWorks.Enabled = false;
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Обробка проблемних творів", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelectWorks_Click(object sender, EventArgs e)
        {
            OnSelectWorks();
        }

        private void cbProblemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvWorks.Items.Clear();
            FillWorkDetails(null);
            btnSelectWorks.Enabled = true;
        }

        private void lvWorks_SelectedIndexChanged(object sender, EventArgs e)
        {
            WorkInfo workInfo = null;
            if(lvWorks.SelectedItems.Count != 0)
            {
                workInfo = (WorkInfo)lvWorks.SelectedItems[0].Tag;
            }
            FillWorkDetails(workInfo);
        }

        private void lvRightHolders_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRightHolderControls();
        }

        private void btnTypeRoleApply_Click(object sender, EventArgs e)
        {
            DoCorrection((workItem,  rightHolderItem, WorkInfo, rightHolderInfo) =>
            {
                var validTypeRole = _validTypeRoles[cbTypeRoleNew.SelectedIndex];

                UpdateTypeRole(rightHolderInfo.ObjId, rightHolderInfo.CustId, validTypeRole.RightHolderType, validTypeRole.RightHolderRole);
            });
        }

        private void btnDeleteDup_Click(object sender, EventArgs e)
        {
            DoCorrection((workItem,  rightHolderItem, WorkInfo, rightHolderInfo) =>
            {
                DeleteWorkRightHolder(rightHolderInfo.CopyRightId);
            });

        }
        private void btnShrNewApply_Click(object sender, EventArgs e)
        {
            DoCorrection((workItem,  rightHolderItem, WorkInfo, rightHolderInfo) =>
            {
                decimal newPerShr;
                if(!decimal.TryParse(tbPerShrNew.Text, out newPerShr))
                {
                    MessageBox.Show("Невірне значення процентів ПУБ", "Обробка проблемних творів", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal newMecShr;
                if(!decimal.TryParse(tbMecShrNew.Text, out newMecShr))
                {
                    MessageBox.Show("Невірне значення процентів МЕХ", "Обробка проблемних творів", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                UpdateShares(rightHolderInfo.CopyRightId, newPerShr, newMecShr);
            });
            
        }

        private void btnChangeCategory_Click(object sender, EventArgs e)
        {
            DoCorrection((workItem,  rightHolderItem, workInfo, rightHolderInfo) =>
            {
                ChangeCategory(workInfo.ObjId, workInfo.CatCode == 5 ? 6 : 5);
            });
        }

        private void btnRefreshProblems_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                RefreshProblems();
                cbProblemType.SelectedIndex = -1;
                Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Обробка проблемних творів", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshDetails_Click(object sender, EventArgs e)
        {
            var itemWork = lvWorks.SelectedItems[0];
            var workInfo = (WorkInfo)itemWork.Tag;
            try
            {
                Cursor = Cursors.WaitCursor;
                RefreshWork(itemWork);
                FillWorkDetails(workInfo);
                Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Обробка проблемних творів", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShowRightHoderRoleChanges_Click(object sender, EventArgs e)
        {
            if(_formRightHolderRoles == null || _formRightHolderRoles.IsDisposed)
            {
                _formRightHolderRoles = new FormRightHolderRoles(OnShowRightHolderUnknownRoleWorks);
                _formRightHolderRoles.Show(this);
            }
            else
            {
                _formRightHolderRoles.Activate();
            }

       }

        private void OnCbRightHolderFilterDropDown()
        {
            if(_filterRightHolders == null)
            {
                FillFilterRightHolders();
                _filterRightHolders.ForEach(x =>
                {
                    cbRightHolderFilter.Items.Add($"{x.CustId} - {x.Name}");
                }) ;
            }
        }

        private void cbRightHolderFilter_DropDown(object sender, EventArgs e)
        {
            OnCbRightHolderFilterDropDown();
        }

        private void cbRightHolderFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSelectWorks.Enabled = cbProblemType.SelectedIndex != -1;
        }

    }
}
