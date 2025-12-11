using SocIpiDumpLoader.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocIpiDumpLoader.StructuredEntities
{
    public class Ntu : TransBase
    {
        protected List<RecNto> RecNtoList { get; set; }
        protected List<RecNtn> RecNtnList { get; set; }
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

            cmd.CommandText = SqlQueries.AddIpiNationality;
            if (RecNtnList != null)
            {
                RecNtnList.ForEach(x =>
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
