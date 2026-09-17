using IpiUpdatesLib.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace IpiUpdatesLib.StructuredEntities
{
    public class Ida : TransBase
    {
        protected List<DicCcl> RecCclList { get; set; } 
        protected List<DicIri> RecIriList { get; set; }
        protected List<DicIsc> RecIscList { get; set; }
        protected List<DicNmt> RecNmtList { get; set; }
        protected List<DicRcc> RecRccList { get; set; }
        protected List<DicRig> RecRigList { get; set; }
        protected List<DicRis> RecRisList { get; set; }
        protected List<DicRix> RecRixList { get; set; }
        protected List<DicRol> RecRolList { get; set; }
        protected List<DicSoc> RecSocList { get; set; }
        protected List<DicSop> RecSopList { get; set; }
        protected List<DicCsc> RecCscList { get; set; }
        protected List<DicTnr> RecTnrList { get; set; }
        protected List<DicTna> RecTnaList { get; set; }
        protected List<DicHnr> RecHnrList { get; set; }
        protected List<DicHna> RecHnaList { get; set; }

        protected override void UpdateDatabase(SqlCommand cmd)
        {
        }
    }
}
