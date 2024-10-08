using IpiUpdatesLib.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace IpiUpdatesLib.StructuredEntities
{
    public class Ntd : TransBase
    {
        protected List<RecNto> RecNtoList { get; set; }
        protected override void UpdateDatabase(SqlCommand cmd)
        {
            cmd.CommandText = SqlQueries.DeleteIpiNationality;

            if (RecNtoList != null)
            {
                RecNtoList.ForEach(x =>
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                    cmd.Parameters.AddWithValue("@TisNr", x.TisNr);
                    cmd.Parameters.AddWithValue("@TisNrFromD", ParseFromDate(x.TisNrValidFrom));
                    cmd.Parameters.AddWithValue("@Tisan", x.Tisan);
                    cmd.Parameters.AddWithValue("@TisanFromD", ParseFromDate(x.TisanValidFrom));
                    cmd.ExecuteNonQuery();
                });
            }
        }
    }
}
