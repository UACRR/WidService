using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using WidUpdatesLib.Entities;

namespace WidUpdatesLib.UpdRecs
{
    public class UpdRecDetail : UpdRec
    {
        private UpdRecTran ownerTran;

        public UpdRecDetail(UpdRecTran ownerTran)
        {
            this.ownerTran = ownerTran;
            cmd = ownerTran.Cmd;
        }

        public void PropagateFromTran(int? updWic, string updIswc, DateTime fileTime)
        {
            this.updWic = updWic;
            this.updIswc = updIswc;
            this.fileTime = fileTime;
        }

        public override void Apply()
        {
            base.Apply();
        }

        /*
        public void ApplyIsw()
        {
            cmd.CommandText = "select Id from SocWid..WidIswc where Wic = @wic and Iswc = @iswc";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@wic", updWic);
            cmd.Parameters.AddWithValue("@iswc", int.Parse((((RecIsw)base.recEntity).ArchIswc)));
            var r = cmd.ExecuteReader();
            if (r.HasRows)
            {
                throw new Exception("Archived iswc already exists in the database");
            }
            r.Close();

            // Insert new iswc
            cmd.CommandText = "insert SocWid..WidIswc (Wic, Iswc, PrefIswc) values(@wic, @iswc, @PrefIswc)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@wic", updWic);
            cmd.Parameters.AddWithValue("@iswc", int.Parse((((RecIsw)base.recEntity).ArchIswc)));
            cmd.Parameters.AddWithValue("@prefIswc", updIswc);
            cmd.ExecuteNonQuery();
        }

        public void ApplySip()
        {
            var rec = (RecSip)base.recEntity;
            cmd.CommandText = "select Id from SocWid..WidIntrPty where Wic = @wic and IpNr = @IpNr";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@wic", updWic);
            cmd.Parameters.AddWithValue("@IpNr", rec.IpNr);
            var r = cmd.ExecuteReader();
            if (r.HasRows)
            {
                throw new Exception($"Party with code {rec.IpNr} does not exist in the database");
            }
            r.Close();

        }
        */

    }
}
