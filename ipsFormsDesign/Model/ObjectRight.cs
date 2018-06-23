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

        public ObjAct ActCodeNavigation { get; set; }
        public Category CategoryCodeNavigation { get; set; }
        public SpecType SpecTypeNavigation { get; set; }
        public ObjectStatus StatusNavigation { get; set; }
        public MediaTrack MediaTrack { get; set; }
        public ObservableListSource<Account> Account { get; set; }
        public ObservableListSource<Authors> Authors { get; set; }
        public ObservableListSource<BrRegItem> BrRegItem { get; set; }
        public ObservableListSource<CopyRight> CopyRight { get; set; }
        public ObservableListSource<DistributionItem> DistributionItem { get; set; }
        public ObservableListSource<LicenseBigR> LicenseBigR { get; set; }
        public ObservableListSource<MusicalDesign> MusicalDesign { get; set; }
        public ObservableListSource<PortalObjectRights> PortalObjectRights { get; set; }
        public ObservableListSource<RegisterItem> RegisterItem { get; set; }
        public ObservableListSource<RelObjPerformer> RelObjPerformer { get; set; }
        public ObservableListSource<RelPopGenre> RelPopGenre { get; set; }
        public ObservableListSource<Request> Request { get; set; }
        public ObservableListSource<SeekObject> SeekObject { get; set; }
    }
}

