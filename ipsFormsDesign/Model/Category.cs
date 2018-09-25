using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Category : ICategory
    {
        public Category()
        {
            CategoryTr = new ObservableListSource<CategoryTr>();
            CreativeRoleType = new ObservableListSource<CreativeRoleType>();
            EtGenre = new ObservableListSource<EtGenre>();
            EtRole = new ObservableListSource<EtRole>();
            GenreType = new ObservableListSource<GenreType>();
            KindComposition = new ObservableListSource<KindComposition>();
            ModifyMusicType = new ObservableListSource<ModifyMusicType>();
            ModifyTextType = new ObservableListSource<ModifyTextType>();
            ModifyType = new ObservableListSource<ModifyType>();
            MyCategory = new ObservableListSource<MyCategory>();
            ObjectRight = new ObservableListSource<ObjectRight>();
            PopGenre = new ObservableListSource<PopGenre>();
            Request = new ObservableListSource<Request>();
            RequestAim = new ObservableListSource<RequestAim>();
            RequestType = new ObservableListSource<RequestType>();
            UseAreaType = new ObservableListSource<UseAreaType>();
            UseMediaType = new ObservableListSource<UseMediaType>();
        }

        public int codeI { get; set; }
        public string name { get; set; }
        public int? status { get; set; }
        public string TableObj { get; set; }
        public int? utype { get; set; }
        public string comment { get; set; }

        public CategoryStatusType statusNavigation { get; set; }
        public ObservableListSource<CategoryTr> CategoryTr { get; set; }
        public ObservableListSource<CreativeRoleType> CreativeRoleType { get; set; }
        public ObservableListSource<EtGenre> EtGenre { get; set; }
        public ObservableListSource<EtRole> EtRole { get; set; }
        public ObservableListSource<GenreType> GenreType { get; set; }
        public ObservableListSource<KindComposition> KindComposition { get; set; }
        public ObservableListSource<ModifyMusicType> ModifyMusicType { get; set; }
        public ObservableListSource<ModifyTextType> ModifyTextType { get; set; }
        public ObservableListSource<ModifyType> ModifyType { get; set; }
        public ObservableListSource<MyCategory> MyCategory { get; set; }
        public ObservableListSource<ObjectRight> ObjectRight { get; set; }
        public ObservableListSource<PopGenre> PopGenre { get; set; }
        public ObservableListSource<Request> Request { get; set; }
        public ObservableListSource<RequestAim> RequestAim { get; set; }
        public ObservableListSource<RequestType> RequestType { get; set; }
        public ObservableListSource<UseAreaType> UseAreaType { get; set; }
        public ObservableListSource<UseMediaType> UseMediaType { get; set; }
    }
}

