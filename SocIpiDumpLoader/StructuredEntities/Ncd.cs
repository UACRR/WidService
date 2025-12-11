using SocIpiDumpLoader.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocIpiDumpLoader.StructuredEntities
{
    public class Ncd : TransBase
    {
        protected RecMco RecMco { get; set; }

        protected override void UpdateDatabase(SqlCommand cmd)
        {
            cmd.CommandText = SqlQueries.DeleteIpiName;

            cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
            cmd.Parameters.AddWithValue("@IpNameNr", RecMco.IpNameNr);
            cmd.ExecuteNonQuery();
        }
    }
}
