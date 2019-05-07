using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class ObjectRight : IObjectRight
    {
        public ObjectRight()
        {
            Account = new ObservableListSource<Account>();
            Authors = new ObservableListSource<Authors>();
            BrRegItem = new ObservableListSource<BrRegItem>();
            CopyRight = new ObservableListSource<CopyRight>();
            DistributionItem = new ObservableListSource<DistributionItem>();
            LicenseBigR = new ObservableListSource<LicenseBigR>();
            MusicalDesign = new ObservableListSource<MusicalDesign>();
            PortalObjectRights = new ObservableListSource<PortalObjectRights>();
            RegisterItem = new ObservableListSource<RegisterItem>();
            RelObjPerformer = new ObservableListSource<RelObjPerformer>();
            RelPopGenre = new ObservableListSource<RelPopGenre>();
            Request = new ObservableListSource<Request>();
            SeekObject = new ObservableListSource<SeekObject>();
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
        public string SourceName { get; set; }

        public virtual ObjAct ActCodeNavigation { get; set; }
        public virtual Category CategoryCodeNavigation { get; set; }
        public virtual SpecType SpecTypeNavigation { get; set; }
        public virtual ObjectStatus StatusNavigation { get; set; }
        public virtual MediaTrack MediaTrack { get; set; }
        public virtual ObservableListSource<Account> Account { get; set; }
        public virtual ObservableListSource<Authors> Authors { get; set; }
        public virtual ObservableListSource<BrRegItem> BrRegItem { get; set; }
        public virtual ObservableListSource<CopyRight> CopyRight { get; set; }
        public virtual ObservableListSource<DistributionItem> DistributionItem { get; set; }
        public virtual ObservableListSource<LicenseBigR> LicenseBigR { get; set; }
        public virtual ObservableListSource<MusicalDesign> MusicalDesign { get; set; }
        public virtual ObservableListSource<PortalObjectRights> PortalObjectRights { get; set; }
        public virtual ObservableListSource<RegisterItem> RegisterItem { get; set; }
        public virtual ObservableListSource<RelObjPerformer> RelObjPerformer { get; set; }
        public virtual ObservableListSource<RelPopGenre> RelPopGenre { get; set; }
        public virtual ObservableListSource<Request> Request { get; set; }
        public virtual ObservableListSource<SeekObject> SeekObject { get; set; }
    }
}

