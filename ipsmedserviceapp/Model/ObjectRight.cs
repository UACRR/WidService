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

        public int CategoryCode { get; set; }
        public int ObjId { get; set; }
        public int? ReqId { get; set; }
        public int? GenreType { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Performer { get; set; }
        public int? Status { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyLogin { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ObjImg { get; set; }
        public int? Loadid { get; set; }
        public int? SpecType { get; set; }
        public int? ActCode { get; set; }
        public string InnerCode { get; set; }

        public virtual ObjAct ActCodeNavigation { get; set; }
        public virtual Category CategoryCodeNavigation { get; set; }
        public virtual SpecType SpecTypeNavigation { get; set; }
        public virtual ObjectStatus StatusNavigation { get; set; }
        public virtual MediaTrack MediaTrack { get; set; }
        public virtual ICollection<Account> Account { get; set; }
        public virtual ICollection<Authors> Authors { get; set; }
        public virtual ICollection<BrRegItem> BrRegItem { get; set; }
        public virtual ICollection<CopyRight> CopyRight { get; set; }
        public virtual ICollection<DistributionItem> DistributionItem { get; set; }
        public virtual ICollection<LicenseBigR> LicenseBigR { get; set; }
        public virtual ICollection<MusicalDesign> MusicalDesign { get; set; }
        public virtual ICollection<PortalObjectRights> PortalObjectRights { get; set; }
        public virtual ICollection<RegisterItem> RegisterItem { get; set; }
        public virtual ICollection<RelObjPerformer> RelObjPerformer { get; set; }
        public virtual ICollection<RelPopGenre> RelPopGenre { get; set; }
        public virtual ICollection<Request> Request { get; set; }
        public virtual ICollection<SeekObject> SeekObject { get; set; }
    }
}
