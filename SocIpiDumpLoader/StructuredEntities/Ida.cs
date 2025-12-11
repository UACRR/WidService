using SocIpiDumpLoader.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocIpiDumpLoader.StructuredEntities
{
    public class Ida : TransBase
    {
        protected List<RecCcl> RecCclList { get; set; } 
        protected List<RecIri> RecIriList { get; set; }
        protected List<RecIsc> RecIscList { get; set; }
        protected List<RecNmt> RecNmtList { get; set; }
        protected List<RecRcc> RecRccList { get; set; }
        protected List<RecRig> RecRigList { get; set; }
        protected List<RecRis> RecRisList { get; set; }
        protected List<RecRix> RecRixList { get; set; }
        protected List<RecRol> RecRolList { get; set; }
        protected List<RecSoc> RecSocList { get; set; }
        protected List<RecSop> RecSopList { get; set; }
        protected List<RecCsc> RecCscList { get; set; }
        protected List<RecTnr> RecTnrList { get; set; }
        protected List<RecTna> RecTnaList { get; set; }
        protected List<RecHnr> RecHnrList { get; set; }
        protected List<RecHna> RecHnaList { get; set; }

        protected override void UpdateDatabase(SqlCommand cmd)
        {
        }
    }
}
