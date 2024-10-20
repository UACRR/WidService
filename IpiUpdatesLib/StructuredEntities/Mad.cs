using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace IpiUpdatesLib.StructuredEntities
{
    public class Mad : TransBase
    {
        protected List<MaOld> MaoList { get; set; }

        protected override void UpdateDatabase(SqlCommand cmd)
        {
            if (MaoList != null)
            {
                MaoList.ForEach(x =>
                {
                    cmd.CommandText = SqlQueries.DeleteIpiAgreement;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                    cmd.Parameters.AddWithValue("@SocCde", x.RecMao.SocCde);
                    cmd.Parameters.AddWithValue("@CreClsCde", x.RecMao.CreClsCde);
                    cmd.Parameters.AddWithValue("@RolCde", x.RecMao.RolCde);
                    cmd.Parameters.AddWithValue("@RgtCde", x.RecMao.RgtCde);
                    cmd.Parameters.AddWithValue("@FromDt", ParseFromTs(x.RecMao.ValidFromD, x.RecMao.ValidFromT));
                    cmd.Parameters.AddWithValue("@ToDt", ParseToTs(x.RecMao.ValidToD, x.RecMao.ValidToT));
                    cmd.Parameters.AddWithValue("@SignD", ParseFromDate(x.RecMao.SignD));
                    cmd.Parameters.AddWithValue("@Shr", ParseShare(x.RecMao.Shr));
                    cmd.Parameters.AddWithValue("@AmdDt", ParseFromTs(x.RecMao.AmdD, x.RecMao.AmdT));
                    cmd.ExecuteNonQuery();

                    if (x.RecTmaList != null)
                    {
                        cmd.CommandText = SqlQueries.DeleteIpiTerritory;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@IpAgreeNr", x.GetIpAgreeNr(UpdTrans.IpBaseNr));
                        cmd.ExecuteNonQuery();
                    }
                });

            }
        }
    }
}
