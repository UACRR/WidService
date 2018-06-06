using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class ObjectRight : IObjectRight
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

        public ObjAct ActCodeNavigation { get; set; }
        public Category CategoryCodeNavigation { get; set; }
        public SpecType SpecTypeNavigation { get; set; }
        public ObjectStatus StatusNavigation { get; set; }
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
        public ICollection<RelPopGenre> RelPopGenre { get; set; }
        public ICollection<Request> Request { get; set; }
        public ICollection<SeekObject> SeekObject { get; set; }
    }
}

