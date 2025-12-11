using SocIpiDumpLoader.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocIpiDumpLoader.StructuredEntities
{
    public class Npa : TransBase
    {
        protected RecNco RecNco { get; set; }
        protected List<RecNcn> RecNcnList { get; set; }
        protected List<RecNun> RecNunList { get; set; }

        protected override void UpdateDatabase(SqlCommand cmd)
        {
            cmd.CommandText = SqlQueries.DeleteIpiName;

            if(RecNco != null)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                cmd.Parameters.AddWithValue("@IpNameNr", int.Parse(RecNco.IpNameNr));
                cmd.ExecuteNonQuery();
            }

            cmd.CommandText = SqlQueries.AddIpiName;

            if (RecNcnList != null)
            {
                RecNcnList.ForEach(x =>
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                    cmd.Parameters.AddWithValue("@IpNameNr", int.Parse(x.IpNameNr));
                    cmd.Parameters.AddWithValue("@IpBaseNrRef", DBNull.Value);
                    cmd.Parameters.AddWithValue("@IpNameNrRef", DBNull.Value);
                    cmd.Parameters.AddWithValue("@FstName", x.FstName);
                    cmd.Parameters.AddWithValue("@Name", x.Name);
                    cmd.Parameters.AddWithValue("@NameType", x.NameType);
                    cmd.Parameters.AddWithValue("@CreDt", ParseFromTs(x.CreD, x.CreT));
                    cmd.Parameters.AddWithValue("@AmdDt", ParseFromTs(x.AmdD, x.AmdT));
                    cmd.Parameters.AddWithValue("@IsDeleted", 0);
                    cmd.ExecuteNonQuery();
                });
            }


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
        }
    }
}
