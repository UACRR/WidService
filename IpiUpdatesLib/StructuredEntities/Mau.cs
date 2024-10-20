using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace IpiUpdatesLib.StructuredEntities
{
    public class Mau : TransBase
    {
        protected List<MaOld> MaoList { get; set; }
        protected List<MaNew> ManList { get; set; }

        protected override void UpdateDatabase(SqlCommand cmd)
        {
            cmd.CommandText = SqlQueries.DeleteIpiAgreement;

            if (MaoList != null)
            {
                MaoList.ForEach(x =>
                {
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
                });
            }

            cmd.CommandText = $"delete from IpiTerritory where IpAgreeNr = @IpAgreeNr";

            if (MaoList != null)
            {
                MaoList.ForEach(x =>
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IpAgreeNr", x.GetIpAgreeNr(UpdTrans.IpBaseNr));
                    cmd.ExecuteNonQuery();
                });
            }

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
