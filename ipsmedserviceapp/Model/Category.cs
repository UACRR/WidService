using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Category
    {
        public Category()
        {
            CategoryTr = new HashSet<CategoryTr>();
            CreativeRoleType = new HashSet<CreativeRoleType>();
            DocumentKind = new HashSet<DocumentKind>();
            EtGenre = new HashSet<EtGenre>();
            EtRole = new HashSet<EtRole>();
            GenreType = new HashSet<GenreType>();
            KindComposition = new HashSet<KindComposition>();
            ModifyMusicType = new HashSet<ModifyMusicType>();
            ModifyTextType = new HashSet<ModifyTextType>();
            ModifyType = new HashSet<ModifyType>();
            MyCategory = new HashSet<MyCategory>();
            ObjectRight = new HashSet<ObjectRight>();
            PopGenre = new HashSet<PopGenre>();
            Request = new HashSet<Request>();
            RequestAim = new HashSet<RequestAim>();
            RequestType = new HashSet<RequestType>();
            UseAreaType = new HashSet<UseAreaType>();
            UseMediaType = new HashSet<UseMediaType>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }
        public int? Status { get; set; }
        public string TableObj { get; set; }
        public int? Utype { get; set; }
        public string Comment { get; set; }

        public CategoryStatusType StatusNavigation { get; set; }
        public ICollection<CategoryTr> CategoryTr { get; set; }
        public ICollection<CreativeRoleType> CreativeRoleType { get; set; }
        public ICollection<DocumentKind> DocumentKind { get; set; }
        public ICollection<EtGenre> EtGenre { get; set; }
        public ICollection<EtRole> EtRole { get; set; }
        public ICollection<GenreType> GenreType { get; set; }
        public ICollection<KindComposition> KindComposition { get; set; }
        public ICollection<ModifyMusicType> ModifyMusicType { get; set; }
        public ICollection<ModifyTextType> ModifyTextType { get; set; }
        public ICollection<ModifyType> ModifyType { get; set; }
        public ICollection<MyCategory> MyCategory { get; set; }
        public ICollection<ObjectRight> ObjectRight { get; set; }
        public ICollection<PopGenre> PopGenre { get; set; }
        public ICollection<Request> Request { get; set; }
        public ICollection<RequestAim> RequestAim { get; set; }
        public ICollection<RequestType> RequestType { get; set; }
        public ICollection<UseAreaType> UseAreaType { get; set; }
        public ICollection<UseMediaType> UseMediaType { get; set; }
    }
}
