using SocIpiDumpLoader.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocIpiDumpLoader.StructuredEntities
{
    public class Nca : TransBase
    {
        protected RecNcn RecNcn { get; set; }
        protected List<RecRen> RecRenList { get; set; }
        protected List<RecNun> RecNunList { get; set; }
        protected RecMcn RecMcn { get; set; }
        protected List<RecMun> RecMunList { get; set; }
        protected RecOnn RecOnn { get; set; }
        protected List<RecInn> RecInnList { get; set; }
        protected List<RecImn> RecImnList { get; set; }

        protected override void UpdateDatabase(SqlCommand cmd)
        {
            cmd.CommandText = SqlQueries.AddIpiName;
            if (RecNcn != null)
            {
                var x = RecNcn;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                cmd.Parameters.AddWithValue("@IpNameNr", int.Parse(x.IpNameNr));
                cmd.Parameters.AddWithValue("@IpBaseNrRef", DBNull.Value);
                cmd.Parameters.AddWithValue("@IpNameNrRef", DBNull.Value);
                cmd.Parameters.AddWithValue("@FstName", x.FstName);
                cmd.Parameters.AddWithValue("@Name", x.Name);
                cmd.Parameters.AddWithValue("@NameType", x.NameType);
                cmd.Parameters.AddWithValue("@CreDt", ParseFromTs(x.CreD, x.CreT));
                cmd.Parameters.AddWithValue("@AmdDt", ParseFromTs(x.AmdD, x.AmdT));
                cmd.Parameters.AddWithValue("@IsDeleted", 0);
                cmd.ExecuteNonQuery();
            }

            cmd.CommandText = SqlQueries.AddIpiRemark;
            if (RecRenList != null)
            {
                RecRenList.ForEach(x =>
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                    cmd.Parameters.AddWithValue("@SocCde", int.Parse(x.IpNameNr));
                    cmd.Parameters.AddWithValue("@SeqNr", int.Parse(x.SeqNr));
                    cmd.Parameters.AddWithValue("@Txt", x.Txt);
                    cmd.ExecuteNonQuery();
                });
            }

            cmd.CommandText = SqlQueries.AddIpiNameUsage;
            if (RecNunList != null)
            {
                RecNunList.ForEach(x =>
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                    cmd.Parameters.AddWithValue("@IpNameNr", int.Parse(x.IpNameNr));
                    cmd.Parameters.AddWithValue("@CreClsCde", x.CreClsCde);
                    cmd.Parameters.AddWithValue("@RolCde", x.RolCde);
                    cmd.Parameters.AddWithValue("@IsDeleted", 0);
                    cmd.ExecuteNonQuery();
                });
            }

            cmd.CommandText = SqlQueries.AddIpiName;
            if (RecMcn != null)
            {
                var x = RecMcn;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                cmd.Parameters.AddWithValue("@IpNameNr", int.Parse(x.IpNameNr));
                cmd.Parameters.AddWithValue("@IpBaseNrRef", x.IpBaseNr);
                cmd.Parameters.AddWithValue("@IpNameNrRef", DBNull.Value);
                cmd.Parameters.AddWithValue("@FstName", "");
                cmd.Parameters.AddWithValue("@Name", x.Name);
                cmd.Parameters.AddWithValue("@NameType", x.NameType);
                cmd.Parameters.AddWithValue("@CreDt", ParseFromTs(x.CreD, x.CreT));
                cmd.Parameters.AddWithValue("@AmdDt", ParseFromTs(x.AmdD, x.AmdT));
                cmd.Parameters.AddWithValue("@IsDeleted", 0);
                cmd.ExecuteNonQuery();
            }

            cmd.CommandText = SqlQueries.AddIpiNameUsage;
            if (RecMunList != null)
            {
                RecMunList.ForEach(x =>
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                    cmd.Parameters.AddWithValue("@IpNameNr", int.Parse(x.IpNameNr));
                    cmd.Parameters.AddWithValue("@CreClsCde", x.CreClsCde);
                    cmd.Parameters.AddWithValue("@RolCde", x.RolCde);
                    cmd.Parameters.AddWithValue("@IsDeleted", 0);
                    cmd.ExecuteNonQuery();
                });
            }

            cmd.CommandText = SqlQueries.AddIpiName;
            if (RecOnn != null)
            {
                var x = RecOnn;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                cmd.Parameters.AddWithValue("@IpNameNr", int.Parse(x.IpNameNr));
                cmd.Parameters.AddWithValue("@IpBaseNrRef", DBNull.Value);
                cmd.Parameters.AddWithValue("@IpNameNrRef", int.Parse(x.IpNameNrRef));
                cmd.Parameters.AddWithValue("@FstName", x.FstName);
                cmd.Parameters.AddWithValue("@Name", x.Name);
                cmd.Parameters.AddWithValue("@NameType", x.NameType);
                cmd.Parameters.AddWithValue("@CreDt", ParseFromTs(x.CreD, x.CreT));
                cmd.Parameters.AddWithValue("@AmdDt", ParseFromTs(x.AmdD, x.AmdT));
                cmd.Parameters.AddWithValue("@IsDeleted", 0);
                cmd.ExecuteNonQuery();
            }

            cmd.CommandText = SqlQueries.AddIpiNameUsage;
            if (RecInnList != null)
            {
                RecInnList.ForEach(x =>
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                    cmd.Parameters.AddWithValue("@IpNameNr", int.Parse(x.IpNameNr));
                    cmd.Parameters.AddWithValue("@CreClsCde", x.CreClsCde);
                    cmd.Parameters.AddWithValue("@RolCde", x.RolCde);
                    cmd.Parameters.AddWithValue("@IsDeleted", 0);
                    cmd.ExecuteNonQuery();
                });
            }

            cmd.CommandText = SqlQueries.AddIpiNameUsage;
            if (RecImnList != null)
            {
                RecImnList.ForEach(x =>
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IpBaseNr", UpdTrans.IpBaseNr);
                    cmd.Parameters.AddWithValue("@IpNameNr", int.Parse(x.IpNameNr));
                    cmd.Parameters.AddWithValue("@CreClsCde", x.CreClsCde);
                    cmd.Parameters.AddWithValue("@RolCde", x.RolCde);
                    cmd.Parameters.AddWithValue("@IsDeleted", 0);
                    cmd.ExecuteNonQuery();
                });
            }
        }

    }
}
