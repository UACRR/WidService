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

