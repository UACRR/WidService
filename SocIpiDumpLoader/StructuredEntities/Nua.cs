using SocIpiDumpLoader.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocIpiDumpLoader.StructuredEntities
{
    public class Nua : TransBase
    {
        protected List<RecNun> RecNunList { get; set; }
        protected List<RecInn> RecInnList { get; set; }
        protected List<RecMun> RecMunList { get; set; }
        protected List<RecImn> RecImnList { get; set; }
        protected override void UpdateDatabase(SqlCommand cmd)
        {
            cmd.CommandText = SqlQueries.AddIpiNameUsage;

            if (RecNunList != null)
            {
                RecNunList.ForEach(x =>
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
            if (RecInnList != null)
            {
                RecInnList.ForEach(x =>
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
            if (RecMunList != null)
            {
                RecMunList.ForEach(x =>
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
            if (RecImnList != null)
            {
                RecImnList.ForEach(x =>
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
        }
    }
}
