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
            relEtRole = new ObservableListSource<relEtRole>();
            relGenreRole = new ObservableListSource<relGenreRole>();
        }

        public int codeI { get; set; }
        public int CategoryCode { get; set; }
        public string name { get; set; }
        public int CRType { get; set; }

        public CopyrightType CRTypeNavigation { get; set; }
        public Category CategoryCodeNavigation { get; set; }
        public CreativeTranslate CreativeTranslate { get; set; }
        public ObservableListSource<Authors> Authors { get; set; }
        public ObservableListSource<CopyRight> CopyRight { get; set; }
        public ObservableListSource<CreativeRoleTypeTr> CreativeRoleTypeTr { get; set; }
        public ObservableListSource<RegisterAuthors> RegisterAuthors { get; set; }
        public ObservableListSource<RegisterExtra> RegisterExtra { get; set; }
        public ObservableListSource<relEtRole> relEtRole { get; set; }
        public ObservableListSource<relGenreRole> relGenreRole { get; set; }
    }
}

