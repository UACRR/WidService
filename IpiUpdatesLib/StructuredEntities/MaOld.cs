using IpiUpdatesLib.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IpiUpdatesLib.StructuredEntities
{
    public class MaOld
    {
        public RecMao RecMao { get; set; }
        public List<RecTma> RecTmaList { get; set; }
        public MaOld()
        {
            RecTmaList = new List<RecTma>();
        }
        public string GetIpAgreeNr(string ipBaseNr)
        {
            return $"{ipBaseNr}-{RecMao.SocCde}-{RecMao.CreClsCde}-{RecMao.RolCde}-{RecMao.RgtCde}-{RecMao.ValidFromD}{RecMao.ValidFromT}";
        }
    }
}
