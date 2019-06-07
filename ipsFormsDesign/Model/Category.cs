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

        public int CodeI { get; set; }
        public string Name { get; set; }
        public int? Status { get; set; }
        public string TableObj { get; set; }
        public int? Utype { get; set; }
        public string Comment { get; set; }

        public virtual CategoryStatusType StatusNavigation { get; set; }
        public virtual ObservableListSource<CategoryTr> CategoryTr { get; set; }
        public virtual ObservableListSource<CreativeRoleType> CreativeRoleType { get; set; }
        public virtual ObservableListSource<EtGenre> EtGenre { get; set; }
        public virtual ObservableListSource<EtRole> EtRole { get; set; }
        public virtual ObservableListSource<GenreType> GenreType { get; set; }
        public virtual ObservableListSource<KindComposition> KindComposition { get; set; }
        public virtual ObservableListSource<ModifyMusicType> ModifyMusicType { get; set; }
        public virtual ObservableListSource<ModifyTextType> ModifyTextType { get; set; }
        public virtual ObservableListSource<ModifyType> ModifyType { get; set; }
        public virtual ObservableListSource<MyCategory> MyCategory { get; set; }
        public virtual ObservableListSource<ObjectRight> ObjectRight { get; set; }
        public virtual ObservableListSource<PopGenre> PopGenre { get; set; }
        public virtual ObservableListSource<Request> Request { get; set; }
        public virtual ObservableListSource<RequestAim> RequestAim { get; set; }
        public virtual ObservableListSource<RequestType> RequestType { get; set; }
        public virtual ObservableListSource<UseAreaType> UseAreaType { get; set; }
        public virtual ObservableListSource<UseMediaType> UseMediaType { get; set; }
    }
}

