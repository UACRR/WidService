using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class CreativeRoleType : ICreativeRoleType
    {
        public CreativeRoleType()
        {
            Authors = new ObservableListSource<Authors>();
            CopyRight = new ObservableListSource<CopyRight>();
            CreativeRoleTypeTr = new ObservableListSource<CreativeRoleTypeTr>();
            RegisterAuthors = new ObservableListSource<RegisterAuthors>();
            RegisterExtra = new ObservableListSource<RegisterExtra>();
            RelEtRole = new ObservableListSource<RelEtRole>();
            RelGenreRole = new ObservableListSource<RelGenreRole>();
        }

        public int CodeI { get; set; }
        public int CategoryCode { get; set; }
        public string Name { get; set; }
        public int Crtype { get; set; }

        public virtual Category CategoryCodeNavigation { get; set; }
        public virtual CopyrightType CrtypeNavigation { get; set; }
        public virtual ObservableListSource<Authors> Authors { get; set; }
        public virtual ObservableListSource<CopyRight> CopyRight { get; set; }
        public virtual ObservableListSource<CreativeRoleTypeTr> CreativeRoleTypeTr { get; set; }
        public virtual ObservableListSource<RegisterAuthors> RegisterAuthors { get; set; }
        public virtual ObservableListSource<RegisterExtra> RegisterExtra { get; set; }
        public virtual ObservableListSource<RelEtRole> RelEtRole { get; set; }
        public virtual ObservableListSource<RelGenreRole> RelGenreRole { get; set; }
    }
}

