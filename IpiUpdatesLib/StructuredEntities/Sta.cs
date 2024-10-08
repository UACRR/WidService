using IpiUpdatesLib.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace IpiUpdatesLib.StructuredEntities
{
    public class Sta : TransBase
    {
        protected List<RecStn> RecStnList { get; set; }

        protected override void ApplyToIpiStatus(SqlCommand cmd)
        {
            cmd.CommandText = SqlQueries.AddIpiStatus;

            if (RecStnList != null)
            {
                RecStnList.ForEach(x =>
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                    cmd.Parameters.AddWithValue("@IpBaseNrRef", x.IpBaseNrRef);
                    cmd.Parameters.AddWithValue("@SttCde", x.SttCde);
                    cmd.Parameters.AddWithValue("@FromDt", ParseFromTs(x.ValidFromD, x.ValidFromT));
                    cmd.Parameters.AddWithValue("@ToDt", ParseToTs(x.ValidToD, x.ValidToT));
                    cmd.Parameters.AddWithValue("@AmdDt", ParseFromTs(x.AmdD, x.AmdT));
                    cmd.ExecuteNonQuery();
                });
            }
        }
    }
}
