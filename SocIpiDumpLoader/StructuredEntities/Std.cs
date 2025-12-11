using SocIpiDumpLoader.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocIpiDumpLoader.StructuredEntities
{
    public class Std : TransBase
    {
        protected List<RecSto> RecStoList { get; set; }

        protected override void UpdateDatabase(SqlCommand cmd)
        {
            cmd.CommandText = SqlQueries.DeleteIpiStatus;

            RecStoList.ForEach(x =>
            {
                cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                cmd.Parameters.AddWithValue("@FromDt", ParseFromTs(x.ValidFromD, x.ValidFromT));
                cmd.Parameters.AddWithValue("@ToDt", ParseToTs(x.ValidToD, x.ValidToT));
                cmd.ExecuteNonQuery();
            });
        }
    }
}
