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
            LicAuthorBr = new ObservableListSource<LicAuthorBr>();
            RelEtRole = new ObservableListSource<RelEtRole>();
            RelGenreRole = new ObservableListSource<RelGenreRole>();
        }

        public int CodeI { get; set; }
        public int CategoryCode { get; set; }
        public string Name { get; set; }
        public int Crtype { get; set; }

        public Category CategoryCodeNavigation { get; set; }
        public CopyrightType CrtypeNavigation { get; set; }
        public CreativeTranslate CreativeTranslate { get; set; }
        public ObservableListSource<Authors> Authors { get; set; }
        public ObservableListSource<CopyRight> CopyRight { get; set; }
        public ObservableListSource<CreativeRoleTypeTr> CreativeRoleTypeTr { get; set; }
        public ObservableListSource<LicAuthorBr> LicAuthorBr { get; set; }
        public ObservableListSource<RelEtRole> RelEtRole { get; set; }
        public ObservableListSource<RelGenreRole> RelGenreRole { get; set; }
    }
}

