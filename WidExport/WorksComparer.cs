using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidExport
{
    public class WorksComparer
    {
        public enum ChangeStatus
        {
            Added,
            Updated,
            Deleted,
            Unchanged,
        }

        public class Work
        {
            public int ObjId { get; set; }
            public string OldName { get; set; }
            public string NewName { get; set; }
        }

        public class Share
        {
            public string CopyRightId       { get; set; }
            public string WidSubmGroupId    { get; set; }
            public string ObjId             { get; set; }
            public string WorkChange        { get; set; }
            public string OldCustId         { get; set; }
            public string NewCustId         { get; set; }
            public string OldIpBaseNr       { get; set; }
            public string NewIpBaseNr       { get; set; }
            public string OldIpNameNr       { get; set; }
            public string NewIpNameNr       { get; set; }
            public string OldRhType         { get; set; }
            public string NewRhType         { get; set; }
            public string OldRhRole         { get; set; }
            public string NewRhRole         { get; set; }
            public string OldPerShr         { get; set; }
            public string NewPerShr         { get; set; }
            public string OldMecShr         { get; set; }
            public string NewMecShr         { get; set; }
            public string OldAgrLocal       { get; set; }
            public string NewAgrLocal       { get; set; }
            public string OldAgrIpiPer      { get; set; }
            public string NewAgrIpiPer      { get; set; }
            public string OldAgrIpiMec      { get; set; }
            public string NewAgrIpiMec      { get; set; }
            public string OldCustName       { get; set; }
            public string NewCustName       { get; set; }

            public ChangeStatus ChangeStatus { get; set; }

            public void CalcChangeStatus()
            {
                if(OldCustId == "")
                {
                    ChangeStatus = ChangeStatus.Added;
                }
                else if(NewCustId == "")
                {
                    ChangeStatus = ChangeStatus.Deleted;
                }
                else if(HasNoChanges())
                {
                    ChangeStatus = ChangeStatus.Unchanged;
                }
                else
                {
                    ChangeStatus = ChangeStatus.Updated;
                }
            }

            public bool IsAdded() => ChangeStatus == ChangeStatus.Added;
            public bool IsDeleted() => ChangeStatus == ChangeStatus.Deleted;
            public bool IsUnchanged() => ChangeStatus == ChangeStatus.Unchanged;
            public bool IsUpdated() => ChangeStatus == ChangeStatus.Updated;

            private bool HasNoChanges()
            {
                return
                    OldCustId    == NewCustId     &&
                    OldIpBaseNr  == NewIpBaseNr   &&
                    OldIpNameNr  == NewIpNameNr   &&
                    OldRhType    == NewRhType     &&
                    OldRhRole    == NewRhRole     &&
                    OldPerShr    == NewPerShr     &&
                    OldMecShr    == NewMecShr     &&
                    OldAgrLocal  == NewAgrLocal   &&
                    OldAgrIpiPer == NewAgrIpiPer  &&
                    OldAgrIpiMec == NewAgrIpiMec;
            }
        }

        public class AltName
        {
            public string SeekObjectId       { get; set; }
            public string WidSubmGroupId    { get; set; }
            public string ObjId             { get; set; }
            public string OldName        { get; set; }
            public string NewName         { get; set; }

            public ChangeStatus ChangeStatus { get; set; }

            public void CalcChangeStatus()
            {
                if(OldName == "")
                {
                    ChangeStatus = ChangeStatus.Added;
                }
                else if(NewName == "")
                {
                    ChangeStatus = ChangeStatus.Deleted;
                }
                else if(HasNoChanges())
                {
                    ChangeStatus = ChangeStatus.Unchanged;
                }
                else
                {
                    ChangeStatus = ChangeStatus.Updated;
                }
            }

            public bool IsAdded() => ChangeStatus == ChangeStatus.Added;
            public bool IsDeleted() => ChangeStatus == ChangeStatus.Deleted;
            public bool IsUnchanged() => ChangeStatus == ChangeStatus.Unchanged;
            public bool IsUpdated() => ChangeStatus == ChangeStatus.Updated;

            private bool HasNoChanges()
            {
                return OldName == NewName;
            }
        }

        public class Performer
        {
            public string SeekObjectId       { get; set; }
            public string WidSubmGroupId    { get; set; }
            public string ObjId             { get; set; }
            public string OldName        { get; set; }
            public string NewName         { get; set; }

            public ChangeStatus ChangeStatus { get; set; }

            public void CalcChangeStatus()
            {
                if(OldName == "")
                {
                    ChangeStatus = ChangeStatus.Added;
                }
                else if(NewName == "")
                {
                    ChangeStatus = ChangeStatus.Deleted;
                }
                else if(HasNoChanges())
                {
                    ChangeStatus = ChangeStatus.Unchanged;
                }
                else
                {
                    ChangeStatus = ChangeStatus.Updated;
                }
            }

            public bool IsAdded() => ChangeStatus == ChangeStatus.Added;
            public bool IsDeleted() => ChangeStatus == ChangeStatus.Deleted;
            public bool IsUnchanged() => ChangeStatus == ChangeStatus.Unchanged;
            public bool IsUpdated() => ChangeStatus == ChangeStatus.Updated;

            private bool HasNoChanges()
            {
                return OldName == NewName;
            }
        }

        private Work _selectedWork;

        public List<Work> Works { get; set; }

        public List<Share> Shares { get; set; }

        public List<AltName> AltNames { get; set; }

        public List<Performer> Performers { get; set; }

        public WorksComparer()
        {
        }

        public void LoadWorks()
        {
            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spWidSubmGroupChangedWorksSelect";
                using (var r = cmd.ExecuteReader())
                {
                    Works = new List<Work>();
                    while (r.Read())
                    {
                        Works.Add(new Work
                        {
                            ObjId = r.GetInt32(0),
                            OldName = GetNullableString(r, 1),
                            NewName = GetNullableString(r, 2),
                        });
                    }
                }
            });
        }

        public void LoadWorkDetails(Work work)
        {
            _selectedWork = work;
            LoadShares();
            LoadAltNames();
            LoadPerformers();
        }

        private void LoadShares()
        {
            var work = _selectedWork;
            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spWidSubmGroupChangedSharesSelect";
                cmd.Parameters.AddWithValue("@objId", work.ObjId);
                using (var r = cmd.ExecuteReader())
                {
                    Shares = new List<Share>();
                    while (r.Read())
                    {
                        var idx = 0;
                        var share = new Share();
                        share.CopyRightId    = Convert.ToString(r.GetValue(idx++));
                        share.WidSubmGroupId = Convert.ToString(r.GetValue(idx++));
                        share.ObjId          = Convert.ToString(r.GetValue(idx++));
                        share.WorkChange     = Convert.ToString(r.GetValue(idx++));
                        share.OldCustId      = Convert.ToString(r.GetValue(idx++));
                        share.NewCustId      = Convert.ToString(r.GetValue(idx++));
                        share.OldIpBaseNr    = Convert.ToString(r.GetValue(idx++));
                        share.NewIpBaseNr    = Convert.ToString(r.GetValue(idx++));
                        share.OldIpNameNr    = Convert.ToString(r.GetValue(idx++));
                        share.NewIpNameNr    = Convert.ToString(r.GetValue(idx++));
                        share.OldRhType      = GetRhTypeName(r, idx++);
                        share.NewRhType      = GetRhTypeName(r, idx++);
                        share.OldRhRole      = GetRhRoleName(r, idx++);
                        share.NewRhRole      = GetRhRoleName(r, idx++);
                        share.OldPerShr      = Convert.ToString(r.GetValue(idx++));
                        share.NewPerShr      = Convert.ToString(r.GetValue(idx++));
                        share.OldMecShr      = Convert.ToString(r.GetValue(idx++));
                        share.NewMecShr      = Convert.ToString(r.GetValue(idx++));
                        share.OldAgrLocal    = GetBoolName(r, idx++);
                        share.NewAgrLocal    = GetBoolName(r, idx++);
                        share.OldAgrIpiPer   = GetBoolName(r, idx++);
                        share.NewAgrIpiPer   = GetBoolName(r, idx++);
                        share.OldAgrIpiMec   = GetBoolName(r, idx++);
                        share.NewAgrIpiMec   = GetBoolName(r, idx++);
                        share.OldCustName    = Convert.ToString(r.GetValue(idx++));
                        share.NewCustName    = Convert.ToString(r.GetValue(idx++));
                        share.CalcChangeStatus();
                        Shares.Add(share);
                    }
                }
            });
        }
        
        private void LoadAltNames()
        {
            var work = _selectedWork;
            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spWidSubmGroupChangedAltNamesSelect";
                cmd.Parameters.AddWithValue("@objId", work.ObjId);
                using (var r = cmd.ExecuteReader())
                {
                    AltNames = new List<AltName>();
                    while (r.Read())
                    {
                        var idx = 0;
                        var altName = new AltName
                        {
                           SeekObjectId     = Convert.ToString(r.GetValue(idx++)),
                           WidSubmGroupId   = Convert.ToString(r.GetValue(idx++)),
                           ObjId            = Convert.ToString(r.GetValue(idx++)),
                           OldName          = Convert.ToString(r.GetValue(idx++)),
                           NewName          = Convert.ToString(r.GetValue(idx++)),
                        };
                        altName.CalcChangeStatus();
                        AltNames.Add(altName);
                    }
                }
            });
        }

        private void LoadPerformers()
        {
            var work = _selectedWork;
            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spWidSubmGroupChangedPerformersSelect";
                cmd.Parameters.AddWithValue("@objId", work.ObjId);
                using (var r = cmd.ExecuteReader())
                {
                    Performers = new List<Performer>();
                    while (r.Read())
                    {
                        var idx = 0;
                        var performer = new Performer
                        {
                           SeekObjectId     = Convert.ToString(r.GetValue(idx++)),
                           WidSubmGroupId   = Convert.ToString(r.GetValue(idx++)),
                           ObjId            = Convert.ToString(r.GetValue(idx++)),
                           OldName          = Convert.ToString(r.GetValue(idx++)),
                           NewName          = Convert.ToString(r.GetValue(idx++)),
                        };
                        performer.CalcChangeStatus();
                        Performers.Add(performer);
                    }
                }
            });
        }

        private string GetRhTypeName(SqlDataReader r, int idx)
        {
            return r.IsDBNull(idx) ? null : WidSubmWorkCheckList.RhType[r.GetInt32(idx)];
        }

        private string GetRhRoleName(SqlDataReader r, int idx)
        {
            return r.IsDBNull(idx) ? null : WidSubmWorkCheckList.RhRole[r.GetInt32(idx)];
        }

        private string GetBoolName(SqlDataReader r, int idx)
        {
            var val = r.GetValue(idx);
            return r.IsDBNull(idx) ? null : r.GetBoolean(idx) ? "Так" : "Ні";
        }

        private string GetNullableString(SqlDataReader r, int idx)
        {
            return r.IsDBNull(idx) ? null : r.GetString(idx);
        }
    }
}
