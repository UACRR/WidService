using IpiUpdatesLib.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace IpiUpdatesLib.StructuredEntities
{
    public class Bdu : TransBase
    {
        protected List<RecBdo> RecBdoList { get; set; }
        protected List<RecBdn> RecBdnList { get; set; }

        protected override void ApplyToIpiBase(SqlCommand cmd)
        {
            cmd.CommandText = SqlQueries.UpdateIpiBase;
            RecBdnList.ForEach(x =>
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                cmd.Parameters.AddWithValue("@IpType", x.IpType);
                cmd.Parameters.AddWithValue("@BirthD", ParseFromDate(x.BirthYy, x.BirthMm, x.BirthDd));
                cmd.Parameters.AddWithValue("@DeathD", ParseToDate(x.DeathYy, x.DeathMm, x.DeathDd));
                cmd.Parameters.AddWithValue("@BirthPlace"   , x.BirthPlace);
                cmd.Parameters.AddWithValue("@BirthState", x.BirthState);
                cmd.Parameters.AddWithValue("@BirthTisNr", x.BirthTisNr);
                cmd.Parameters.AddWithValue("@TisNrFromD", ParseFromDate(x.TisNrValidFrom));
                cmd.Parameters.AddWithValue("@BirthTisan", x.BirthTisan);
                cmd.Parameters.AddWithValue("@TisanFromD", ParseFromDate(x.TisanValidFrom));
                cmd.Parameters.AddWithValue("@Sex", x.Sex);
                cmd.Parameters.AddWithValue("@AmdDt", ParseFromTs(x.AmdD, x.AmdT));
                cmd.ExecuteNonQuery();
            });

        }

    }
}
