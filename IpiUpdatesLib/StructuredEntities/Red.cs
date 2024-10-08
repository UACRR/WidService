using IpiUpdatesLib.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace IpiUpdatesLib.StructuredEntities
{
    public class Red : TransBase
    {
        protected List<RecReo> RecReoList { get; set; }
        protected override void UpdateDatabase(SqlCommand cmd)
        {
            cmd.CommandText = SqlQueries.DeleteIpiRemark;

            if (RecReoList != null)
            {
                RecReoList.ForEach(x =>
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
