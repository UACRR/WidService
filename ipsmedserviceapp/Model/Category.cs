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

        public virtual CategoryStatusType StatusNavigation { get; set; }
        public virtual ICollection<CategoryTr> CategoryTr { get; set; }
        public virtual ICollection<CreativeRoleType> CreativeRoleType { get; set; }
        public virtual ICollection<EtGenre> EtGenre { get; set; }
        public virtual ICollection<EtRole> EtRole { get; set; }
        public virtual ICollection<GenreType> GenreType { get; set; }
        public virtual ICollection<KindComposition> KindComposition { get; set; }
        public virtual ICollection<ModifyMusicType> ModifyMusicType { get; set; }
        public virtual ICollection<ModifyTextType> ModifyTextType { get; set; }
        public virtual ICollection<ModifyType> ModifyType { get; set; }
        public virtual ICollection<MyCategory> MyCategory { get; set; }
        public virtual ICollection<ObjectRight> ObjectRight { get; set; }
        public virtual ICollection<PopGenre> PopGenre { get; set; }
        public virtual ICollection<Request> Request { get; set; }
        public virtual ICollection<RequestAim> RequestAim { get; set; }
        public virtual ICollection<RequestType> RequestType { get; set; }
        public virtual ICollection<UseAreaType> UseAreaType { get; set; }
        public virtual ICollection<UseMediaType> UseMediaType { get; set; }
    }
}
