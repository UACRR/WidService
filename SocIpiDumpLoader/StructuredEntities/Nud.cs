using SocIpiDumpLoader.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocIpiDumpLoader.StructuredEntities
{
    public class Nud : TransBase
    {
        protected List<RecNuo> RecNuoList { get; set; }
        protected List<RecIno> RecInoList { get; set; }
        protected List<RecMuo> RecMuoList { get; set; }
        protected List<RecImo> RecImoList { get; set; }
        protected override void UpdateDatabase(SqlCommand cmd)
        {
            cmd.CommandText = SqlQueries.DeleteIpiNameUsage;

            if (RecNuoList != null)
            {
                RecNuoList.ForEach(x =>
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                    cmd.Parameters.AddWithValue("@IpNameNr", int.Parse(x.IpNameNr));
                    cmd.Parameters.AddWithValue("@CreClsCde", x.CreClsCde);
                    cmd.Parameters.AddWithValue("@RolCde", x.RolCde);
                    cmd.Parameters.AddWithValue("@IsDeleted", 0);
                    cmd.ExecuteNonQuery();
                });
            }
            if (RecInoList != null)
            {
                RecInoList.ForEach(x =>
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                    cmd.Parameters.AddWithValue("@IpNameNr", int.Parse(x.IpNameNr));
                    cmd.Parameters.AddWithValue("@CreClsCde", x.CreClsCde);
                    cmd.Parameters.AddWithValue("@RolCde", x.RolCde);
                    cmd.ExecuteNonQuery();
                });
            }
            if (RecMuoList != null)
            {
                RecMuoList.ForEach(x =>
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                    cmd.Parameters.AddWithValue("@IpNameNr", int.Parse(x.IpNameNr));
                    cmd.Parameters.AddWithValue("@CreClsCde", x.CreClsCde);
                    cmd.Parameters.AddWithValue("@RolCde", x.RolCde);
                    cmd.ExecuteNonQuery();
                });
            }
            if (RecImoList != null)
            {
                RecImoList.ForEach(x =>
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                    cmd.Parameters.AddWithValue("@IpNameNr", int.Parse(x.IpNameNr));
                    cmd.Parameters.AddWithValue("@CreClsCde", x.CreClsCde);
                    cmd.Parameters.AddWithValue("@RolCde", x.RolCde);
                    cmd.ExecuteNonQuery();
                });
            }
        }
    }
}
