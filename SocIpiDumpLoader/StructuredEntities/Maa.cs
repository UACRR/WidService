using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocIpiDumpLoader.StructuredEntities
{
    public class Maa : TransBase
    {
        protected List<MaNew> ManList { get; set; }

        protected override void UpdateDatabase(SqlCommand cmd)
        {
            cmd.CommandText = SqlQueries.AddIpiAgreement;

            if (ManList != null)
            {
                ManList.ForEach(x =>
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IpAgreeNr", x.GetIpAgreeNr(UpdTrans.IpBaseNr));
                    cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                    cmd.Parameters.AddWithValue("@SocCde", x.RecMan.SocCde);
                    cmd.Parameters.AddWithValue("@CreClsCde", x.RecMan.CreClsCde);
                    cmd.Parameters.AddWithValue("@RolCde", x.RecMan.RolCde);
                    cmd.Parameters.AddWithValue("@RgtCde", x.RecMan.RgtCde);
                    cmd.Parameters.AddWithValue("@FromDt", ParseFromTs(x.RecMan.ValidFromD, x.RecMan.ValidFromT));
                    cmd.Parameters.AddWithValue("@ToDt", ParseToTs(x.RecMan.ValidToD, x.RecMan.ValidToT));
                    cmd.Parameters.AddWithValue("@SignD", ParseFromDate(x.RecMan.SignD));
                    cmd.Parameters.AddWithValue("@Shr", ParseShare(x.RecMan.Shr));
                    cmd.Parameters.AddWithValue("@AmdDt", ParseFromTs(x.RecMan.AmdD, x.RecMan.AmdT));
                    cmd.ExecuteNonQuery();
                });
            }

            cmd.CommandText = SqlQueries.AddIpiTerritory;

            if (ManList != null)
            {
                ManList.ForEach(x =>
                {
                    var recMan = x.RecMan;
                    x.RecTmaList.ForEach(y =>
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@IpAgreeNr", x.GetIpAgreeNr(UpdTrans.IpBaseNr));
                        cmd.Parameters.AddWithValue("@TisNr", y.TisNr);
                        cmd.Parameters.AddWithValue("@TisNrFromD", ParseFromDate(y.TisNrValidFrom));
                        cmd.Parameters.AddWithValue("@Tisan", y.Tisan);
                        cmd.Parameters.AddWithValue("@TisanFromD", ParseFromDate(y.TisanValidFrom));
                        cmd.Parameters.AddWithValue("@IncExcInd", y.IncExcInd);
                        cmd.ExecuteNonQuery();
                    });
                });
            }
        }

    }
}
