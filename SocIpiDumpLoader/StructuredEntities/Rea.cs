using SocIpiDumpLoader.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocIpiDumpLoader.StructuredEntities
{
    public class Rea : TransBase
    {
        protected List<RecRen> RecRenList { get; set; }
        protected override void UpdateDatabase(SqlCommand cmd)
        {
            cmd.CommandText = SqlQueries.AddIpiRemark;

            if (RecRenList != null)
            {
                RecRenList.ForEach(x =>
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                    cmd.Parameters.AddWithValue("@SocCde", x.SocCde);
                    cmd.Parameters.AddWithValue("@SeqNr", int.Parse(x.SeqNr));
                    cmd.Parameters.AddWithValue("@Txt", x.Txt);
                    cmd.ExecuteNonQuery();
                });
            }
        }
    }
}
