using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class ObjectRight
    {
        public ObjectRight()
        {
            Account = new HashSet<Account>();
            Authors = new HashSet<Authors>();
            BrRegItem = new HashSet<BrRegItem>();
            CopyRight = new HashSet<CopyRight>();
            DistributionItem = new HashSet<DistributionItem>();
            LicenseBigR = new HashSet<LicenseBigR>();
            MusicalDesign = new HashSet<MusicalDesign>();
            PortalObjectRights = new HashSet<PortalObjectRights>();
            RegisterItem = new HashSet<RegisterItem>();
            RelObjPerformer = new HashSet<RelObjPerformer>();
            RelPopGenre = new HashSet<RelPopGenre>();
            Request = new HashSet<Request>();
            SeekObject = new HashSet<SeekObject>();
        }

        public int categoryCode { get; set; }
        public int objId { get; set; }
        public int? reqId { get; set; }
        public int? genreType { get; set; }
        public string name { get; set; }
        public string author { get; set; }
        public string performer { get; set; }
        public int? status { get; set; }
        public DateTime? modifyDate { get; set; }
        public string modifyLogin { get; set; }
        public DateTime? createDate { get; set; }
        public string ObjImg { get; set; }
        public int? loadid { get; set; }
        public int? specType { get; set; }
        public int? actCode { get; set; }
        public string innerCode { get; set; }

        public ObjAct actCodeNavigation { get; set; }
        public Category categoryCodeNavigation { get; set; }
        public SpecType specTypeNavigation { get; set; }
        public ObjectStatus statusNavigation { get; set; }
        public MediaTrack MediaTrack { get; set; }
        public ICollection<Account> Account { get; set; }
        public ICollection<Authors> Authors { get; set; }
        public ICollection<BrRegItem> BrRegItem { get; set; }
        public ICollection<CopyRight> CopyRight { get; set; }
        public ICollection<DistributionItem> DistributionItem { get; set; }
        public ICollection<LicenseBigR> LicenseBigR { get; set; }
        public ICollection<MusicalDesign> MusicalDesign { get; set; }
        public ICollection<PortalObjectRights> PortalObjectRights { get; set; }
        public ICollection<RegisterItem> RegisterItem { get; set; }
        public ICollection<RelObjPerformer> RelObjPerformer { get; set; }
        public ICollection<RelPopGenre> RelPopGenre { get; set; }
        public ICollection<Request> Request { get; set; }
        public ICollection<SeekObject> SeekObject { get; set; }
    }
}
