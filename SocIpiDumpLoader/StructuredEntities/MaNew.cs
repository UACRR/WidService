using SocIpiDumpLoader.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocIpiDumpLoader.StructuredEntities
{
    public class MaNew
    {
        public RecMan RecMan { get; set; }
        public List<RecTma> RecTmaList { get; set; }
        public MaNew()
        {
            RecTmaList = new List<RecTma>();
        }
        public string GetIpAgreeNr(string ipBaseNr)
        {
            // {RecMan.ValidFromD}{RecMan.ValidFromT} is timestamp for uniqueness, may differ from ValidFromDt in IpiAgreement
            return $"{ipBaseNr}-{RecMan.SocCde}-{RecMan.CreClsCde}-{RecMan.RolCde}-{RecMan.RgtCde}-{RecMan.ValidFromD}{RecMan.ValidFromT}";
        }
    }
}
